/*
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
 * 0.95     jmaxxz Initial development                Fully defined every method
 * 1.00     mcbridem Design changes                     Various changes to adjust for design changes in detection algorithms.
 * 1.0      jmaxxz Optimization attempt               Added frame drop rate indicator
 * 1.0      jmaxxz Support for new engine             changed constructor call                                              
 */

using System;
using System.Collections.Generic;
using System.Drawing;
using System.Threading;
using System.Windows.Forms;
using Ares.Client;
using Ares.Client.Analysis;
using Ares.Client.Gps;
using Ares.Client.Gps.SharpGps;
using Ares.Client.Network.WiFi;
using Ares.Common;
using Ares.Common.Video;
using Ares.Common.Webcam;

namespace ReflectUIClient
{
    public partial class AresUi : Form
    {
        private GameEngine _gameEngine;
        private IVideoInput _cam;
        private const int Videodevice = 0; // zero based index of video capture device to use
        private const int Videowidth = 640; // Depends on video device caps
        private const int Videoheight = 480; // Depends on video device caps
        private const int Videobitsperpixel = 24; // BitsPerPixel values determined by device

        private int activeFrameCount = 0;
        private int dropCount = 0;
        private int frameCount = 0;
        private BlobDetectionAnalysis _analyzer;
        private Bitmap currentImage;

        public AresUi()
        {
            InitializeComponent();
            _gameEngine = new GameEngine(new WiFiStrengthMonitor(500), new GpsListener(new SharperGpsAdapter()), new Player(Guid.NewGuid(), "You", Color.DarkViolet, 120), new DSCapture(Videodevice, Videowidth, Videoheight, Videobitsperpixel));
            reflectUI1.Subject = _gameEngine;

            reflectUI1.UpdateView();
            _analyzer = new BlobDetectionAnalysis(45, 45, 800, 800, 15, .3f, 0.5f);
            numericUpDown4.Value = _analyzer.HueTolerance;
            numericUpDown5.Value = (decimal) _analyzer.SaturationTolerance;
            numericUpDown6.Value = (decimal) _analyzer.BrightnessTolerance;
            new Thread(InitCamera).Start();

        }

        private void InitCamera()
        {
            _cam = _gameEngine.Video;
            _cam.VideoEventHandler += FrameUpdateHandler;
            _cam.Start();
        }



        public Bitmap Render(ProcessedImage frame)
        {
            Bitmap bmp;
            //if(rbRaw.Checked)
            {
               bmp =  (Bitmap)frame.BaseImage.Clone();
            }
            
            if (ckOverlay.Checked)
            {
                Font f = new Font("Microsoft Sans Serif", 16F, FontStyle.Regular);
                Brush b = new SolidBrush(Color.Blue);
                Graphics g = Graphics.FromImage(bmp);
                Pen redPen = new Pen(Color.Red, 2);
                string health = string.Format("Health:{0}", _gameEngine.ClientPlayer.Health);

                g.DrawString(string.Format("WiFi:{0}%", _gameEngine.WirelessMonitor.Strength.Value), f, b, 0, 0);

                StringFormat strFormat = StringFormat.GenericTypographic;
                SizeF s = g.MeasureString(health, f, 100000, strFormat);
                g.DrawString(health, f, b, (bmp.Width - s.Width) - (f.Size*0.7F), 0);

                g.DrawEllipse(redPen, (bmp.Width / 2) - 5, (bmp.Height / 2) - 5, 5, 5);

                b.Dispose();
                f.Dispose();
                g.Dispose();
            }

            if(ckBlobs.Checked)
            {
                RenderAllBlobs(bmp, frame);
            }
            if(ckPBlobs.Checked)
            {
                RenderPlayerBlobs(bmp, frame);
            }

            return bmp;
        }

        private void RenderAllBlobs(Bitmap bmp, ProcessedImage processedImage)
        {
            // Draw frames around the blobs
            IList<IPlayerBlob> blobs = (IList<IPlayerBlob>)processedImage.Blobs;
            List<IBlob> rawblobs = (List<IBlob>)processedImage.RawBlobs;

            using (Graphics g = Graphics.FromImage(bmp))
            using (Pen greenPen = new Pen(Color.LimeGreen, 2))
            using (Pen redPen = new Pen(Color.Orange, 2))
            using (Pen blackPen = new Pen(Color.Black, 2))
            using (Pen yellowPen = new Pen(Color.YellowGreen, 2))
            {
                foreach (var blob in rawblobs)
                {
                    //Pen blobPen = new Pen(blob.Color, 3);
                    //g.DrawRectangle(blobPen, blob.Position.X, blob.Position.Y, blob.Dimension.Width,
                    //                blob.Dimension.Height);
                    //blobPen.Dispose();

                    g.DrawRectangle(redPen, blob.Position.X, blob.Position.Y, blob.Dimension.Width, blob.Dimension.Height);
                    g.DrawEllipse(yellowPen, blob.Center.X - 5, blob.Center.Y - 5, 5, 5);
                }
            }
        }

        private void RenderPlayerBlobs(Bitmap bmp, ProcessedImage processedImage)
        {
            // Draw frames around the blobs
            IList<IPlayerBlob> blobs = (IList<IPlayerBlob>)processedImage.Blobs;

            using (Graphics g = Graphics.FromImage(bmp))
            using (Pen greenPen = new Pen(Color.LimeGreen, 2))
            using (Pen yellowPen = new Pen(Color.YellowGreen, 2))
            {
                foreach (var blob in blobs)
                {
                    g.DrawRectangle(greenPen, blob.BaseBlob.Position.X, blob.BaseBlob.Position.Y, blob.BaseBlob.Dimension.Width, blob.BaseBlob.Dimension.Height);
                    g.DrawEllipse(yellowPen, blob.BaseBlob.Center.X - 5, blob.BaseBlob.Center.Y - 5, 5, 5);
                }
            }
        }


        private void FrameUpdateHandler(object sender, Frame frame)
        {
            if (InvokeRequired)
            {
                if (activeFrameCount > 0)
                {
                    dropCount++;
                    frameCount++;
                    return;
                }
                // Execute the same method, but this time on the GUI thread
                BeginInvoke(new ThreadStart(() => FrameUpdateHandler(sender, frame)));
                return;
            }
            frameCount++;
            activeFrameCount++;
            // Process image
            ProcessedImage analyzedFrame = (ProcessedImage)_analyzer.Analyze(frame.Image, _gameEngine.AllPlayers);
            // Put the image into the box
            VideoOut.Image = Render(analyzedFrame);
            currentImage = frame.Image;
            activeFrameCount--;
        }

        private void RefreshToolStripMenuItemClick(object sender, EventArgs e)
        {
            reflectUI1.UpdateView();
        }

        private void AresUi_FormClosed(object sender, FormClosedEventArgs e)
        {
            _gameEngine.Gps.Dispose();
            _gameEngine.WirelessMonitor.Dispose();
            _cam.Dispose();
            Environment.Exit(0);
        }

        private void AresUi_FormClosing(object sender, FormClosingEventArgs e)
        {
            //makes form appear to close faster, (trickery)
            Hide();
        }

        private void ckScale_CheckedChanged(object sender, EventArgs e)
        {
            VideoOut.SizeMode = ckScale.Checked ? PictureBoxSizeMode.AutoSize : PictureBoxSizeMode.CenterImage;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (currentImage == null)
                return;

            Color c = currentImage.GetPixel(currentImage.Width/2, currentImage.Height/2);
            nRed.Value = c.R;
            nBlue.Value = c.B;
            nGreen.Value = c.G;

            
        }

        private void nGreen_ValueChanged(object sender, EventArgs e)
        {
            pnlSample.BackColor = Color.FromArgb((int) nRed.Value, (int) nGreen.Value, (int) nBlue.Value);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            _gameEngine.AllPlayers.Add(new Player(Guid.NewGuid(), textBox1.Text, Color.FromArgb((int)nRed.Value, (int)nGreen.Value, (int)nBlue.Value)));
        }

        private void numericUpDown4_ValueChanged(object sender, EventArgs e)
        {
            _analyzer.HueTolerance = (int) numericUpDown4.Value;
        }

        private void numericUpDown5_ValueChanged(object sender, EventArgs e)
        {
            _analyzer.SaturationTolerance = (float) numericUpDown5.Value;
        }

        private void numericUpDown6_ValueChanged(object sender, EventArgs e)
        {
            _analyzer.BrightnessTolerance = (float) numericUpDown6.Value;
        }

        private void dropRateTimer_Tick(object sender, EventArgs e)
        {
            lblDropped.Text = string.Format("Drop Rate: {0:0.000}%", dropCount / (double)(frameCount) * 100.0);
            lblFps.Text = string.Format("FPS: {0}", frameCount);
            frameCount = 0;
            dropCount = 0;
        }
    }
}
