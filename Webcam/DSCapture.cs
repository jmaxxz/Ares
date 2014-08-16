﻿/*
 *  Ares, a multi-player augmented reality first person shooter
 *  Copyright (C) 2009-2010  Jmaxxz, Mike McBride, and Kevin Curtis
 * 
 * This file is under the the following License
 *          DO WHAT THE FUCK YOU WANT TO PUBLIC LICENSE
 *                   Version 2, December 2004
 *       Copyright (C) 2004 Sam Hocevar <sam@hocevar.net>
 *
 *       Everyone is permitted to copy and distribute verbatim or modified
 *       copies of this license document, and changing it is allowed as long
 *       as the name is changed.
 *
 *                  DO WHAT THE FUCK YOU WANT TO PUBLIC LICENSE
 *         TERMS AND CONDITIONS FOR COPYING, DISTRIBUTION AND MODIFICATION
 *
 *          0. You just DO WHAT THE FUCK YOU WANT TO.
 * 
 * 
 * Change log
 * 
 * Version | Author | Reason for change                | Description of change
 * -------- -------- ---------------------------------- ------------------------------------------------------
 * 0.95     curtisk   Initial development                Interface Design
 */

using System;
using System.Drawing;
using System.Drawing.Imaging;
using System.Runtime.InteropServices;
using System.Threading;
using Ares.Common.Video;
using DirectShowLib;

namespace Ares.Common.Webcam
{
    /// <summary> Summary description for MainForm. </summary>
    public class DSCapture : ISampleGrabberCB, IDisposable, IVideoInput
    {
        private int deviceNum;
        private int width;
        private int height;
        private short bitsPerPixel;

        /// <summary> graph builder interface. </summary>
        private IFilterGraph2 m_FilterGraph;

        private bool _enabled;
        private long index;

        /// <summary> so we can wait for the async job to finish </summary>
        private ManualResetEvent m_PictureReady;


        // Zero based device index and device params and output window
        public DSCapture(int iDeviceNum, int iWidth, int iHeight, short iBPP)
        {
            deviceNum = iDeviceNum;
            width = iWidth;
            height = iHeight;
            bitsPerPixel = iBPP;
        }

        /// <summary>
        ///  Starts the webcam and displaying the video stream
        ///  </summary>
        public void Start()
        {
            _enabled = true;
            
            DsDevice[] capDevices;

            // Get the collection of video devices
            capDevices = DsDevice.GetDevicesOfCat(FilterCategory.VideoInputDevice);

            if (deviceNum + 1 > capDevices.Length)
            {
                throw new Exception("No video capture devices found at that index!");
            }

            try
            {
                // Set up the capture graph
                SetupGraph(capDevices[deviceNum], width, height, bitsPerPixel);

                // tell the callback to ignore new images
                m_PictureReady = new ManualResetEvent(false);
            }
            catch
            {
                Dispose();
                throw;
            }
        }

        /// <summary>
        ///  Stops the  webcam and displaying the video stream
        ///  </summary>
        public void Stop()
        {
            _enabled = false;
            Dispose();
        }

        /// <summary> release everything. </summary>
        public void Dispose()
        {
            CloseInterfaces();
            if (m_PictureReady != null)
            {
                m_PictureReady.Close();
            }
        }

        // Destructor
        ~DSCapture()
        {
            Dispose();
        }


        public int Width { get; private set; }

        public int Height { get; private set; }

        public int Stride { get; private set; }


        /// <summary> build the capture graph for grabber. </summary>
        private void SetupGraph(DsDevice dev, int iWidth, int iHeight, short iBPP)
        {
            ISampleGrabber sampGrabber = null;
            IPin pCaptureOut = null;
            IPin pRenderIn = null;

            // Get the graphbuilder object
            m_FilterGraph = (IFilterGraph2)new FilterGraph();

            try
            {

                // add the video input device
                IBaseFilter capFilter;
                int hr = m_FilterGraph.AddSourceFilterForMoniker(dev.Mon, null, dev.Name, out capFilter);
                DsError.ThrowExceptionForHR(hr);


                //if (iHeight + iWidth + iBPP > 0)
                //{
                //SetConfigParms(pRaw, iWidth, iHeight, iBPP);
                //}
                pCaptureOut = DsFindPin.ByCategory(capFilter, PinCategory.Capture, 0);

                // Get the SampleGrabber interface
                sampGrabber = new SampleGrabber() as ISampleGrabber;
                // Configure the sample grabber
                IBaseFilter baseGrabFlt = sampGrabber as IBaseFilter;
                ConfigureSampleGrabber(sampGrabber);

                // Add the sample grabber to the graph
                hr = m_FilterGraph.AddFilter(baseGrabFlt, "Ares Video Grabber");
                DsError.ThrowExceptionForHR(hr);


                pRenderIn = DsFindPin.ByDirection(baseGrabFlt, PinDirection.Input, 0);



                // Connect the capture pin to the renderer
                hr = m_FilterGraph.Connect(pCaptureOut, pRenderIn);
                DsError.ThrowExceptionForHR(hr);


                // Learn the video properties
                SaveSizeInfo(sampGrabber);

                // Start the graph
                IMediaControl mediaCtrl = (IMediaControl)m_FilterGraph;
                hr = mediaCtrl.Run();
                DsError.ThrowExceptionForHR(hr);
            }
            finally
            {
                if (sampGrabber != null)
                {
                    Marshal.ReleaseComObject(sampGrabber);
                }
                if (pCaptureOut != null)
                {
                    Marshal.ReleaseComObject(pCaptureOut);
                }
                if (pRenderIn != null)
                {
                    Marshal.ReleaseComObject(pRenderIn);
                }
            }
        }

        private void SaveSizeInfo(ISampleGrabber sampGrabber)
        {
            int hr;

            // Get the media type from the SampleGrabber
            AMMediaType media = new AMMediaType();

            hr = sampGrabber.GetConnectedMediaType(media);
            DsError.ThrowExceptionForHR(hr);

            if ((media.formatType != FormatType.VideoInfo) || (media.formatPtr == IntPtr.Zero))
            {
                throw new NotSupportedException("Unknown Grabber Media Format");
            }

            // Grab the size info
            VideoInfoHeader videoInfoHeader = (VideoInfoHeader)Marshal.PtrToStructure(media.formatPtr, typeof(VideoInfoHeader));
            Width = videoInfoHeader.BmiHeader.Width;
            Height = videoInfoHeader.BmiHeader.Height;
            Stride = Width * (videoInfoHeader.BmiHeader.BitCount / 8);

            DsUtils.FreeAMMediaType(media);
        }

        //This should be in a utility class
        public Bitmap CopyDataToBitmap(byte[] data)
        {
            //Here create the Bitmap to the know height, width and format
            Bitmap bmp = new Bitmap(Width, Height, PixelFormat.Format24bppRgb);

            //Create a BitmapData and Lock all pixels to be written
            BitmapData bmpData = bmp.LockBits(
                                                 new Rectangle(0, 0, bmp.Width, bmp.Height),
                                                 ImageLockMode.WriteOnly, bmp.PixelFormat);

            //Copy the data from the byte array into BitmapData.Scan0
            Marshal.Copy(data, 0, bmpData.Scan0, data.Length);

            //Unlock the pixels
            bmp.UnlockBits(bmpData);
            bmp.RotateFlip(RotateFlipType.RotateNoneFlipY);

            //Return the bitmap
            return bmp;
        }

        private void ConfigureSampleGrabber(ISampleGrabber sampGrabber)
        {
            AMMediaType media = new AMMediaType
                                    {
                                        majorType = MediaType.Video,
                                        subType = MediaSubType.RGB24,
                                        formatType = FormatType.VideoInfo
                                    };

            // Set the media type to Video/RBG24
            int hr = sampGrabber.SetMediaType(media);
            DsError.ThrowExceptionForHR(hr);

            DsUtils.FreeAMMediaType(media);

            // Configure the samplegrabber
            hr = sampGrabber.SetCallback(this, 1);
            DsError.ThrowExceptionForHR(hr);
        }

        // Set the Framerate, and video size
        private void SetConfigParms(IPin pStill, int iWidth, int iHeight, short iBPP)
        {
            int hr;
            AMMediaType media;
            VideoInfoHeader v;

            IAMStreamConfig videoStreamConfig = pStill as IAMStreamConfig;

            // Get the existing format block
            hr = videoStreamConfig.GetFormat(out media);

            DsError.ThrowExceptionForHR(hr);

            try
            {
                // copy out the videoinfoheader
                v = new VideoInfoHeader();
                Marshal.PtrToStructure(media.formatPtr, v);

                // if overriding the width, set the width
                if (iWidth > 0)
                {
                    v.BmiHeader.Width = iWidth;
                }

                // if overriding the Height, set the Height
                if (iHeight > 0)
                {
                    v.BmiHeader.Height = iHeight;
                }

                // if overriding the bits per pixel
                if (iBPP > 0)
                {
                    v.BmiHeader.BitCount = iBPP;
                }

                // Copy the media structure back
                Marshal.StructureToPtr(v, media.formatPtr, false);

                // Set the new format
                hr = videoStreamConfig.SetFormat(media);
                DsError.ThrowExceptionForHR(hr);
            }
            finally
            {
                DsUtils.FreeAMMediaType(media);
            }
        }

        /// <summary> Shut down capture </summary>
        private void CloseInterfaces()
        {
            try
            {
                if (m_FilterGraph != null)
                {
                    IMediaControl mediaCtrl = (IMediaControl)m_FilterGraph;

                    // Stop the graph
                    mediaCtrl.Stop();
                }
            }
            catch
            {
            }

            if (m_FilterGraph != null)
            {
                Marshal.ReleaseComObject(m_FilterGraph);
                m_FilterGraph = null;
            }
        }

        /// <summary> sample callback, NOT USED. </summary>
        int ISampleGrabberCB.SampleCB(double sampleTime, IMediaSample pSample)
        {

            Marshal.ReleaseComObject(pSample);
            return 0;
        }

        /// <summary> buffer callback, COULD BE FROM FOREIGN THREAD. </summary>
        int ISampleGrabberCB.BufferCB(double sampleTime, IntPtr pBuffer, int bufferLen)
        {

            // Get that data out of that ugly unmanged memory and into something with teeth
            byte[] mem = new byte[bufferLen];
            Marshal.Copy(pBuffer, mem, 0, bufferLen);

            //m_WantOne = true; //<--who doesn't want me

            Bitmap b = CopyDataToBitmap(mem);
            if (true)
            {
                InvokeFrameUpdateEventHandler(b);
            }

            m_PictureReady.Set();
            return 0;
        }

        //This should be a custom type, use generics
        public event EventHandler FrameUpdate;

        private void InvokeFrameUpdateEventHandler(Bitmap bitmap)
        {
            VideoUpdate handler = VideoEventHandler;
            if (handler != null)
            {
                //bitmap should not go in source, but in the event args, need custom eventargs type
                handler(this , new Frame(bitmap , index) );
            }
            index++;
        }

        public event VideoUpdate VideoEventHandler;

        
    }
}


