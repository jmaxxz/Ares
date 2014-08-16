/*
 *  Ares, a multi-player augmented reality first person shooter
 *  Copyright (C) 2010  Jmaxxz, Mike McBride, and Kevin Curtis
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
 */

using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Timers;

namespace Ares.Common.Video
{
    /// <summary>
    /// 
    /// </summary>
    public class BitmapCamera : IVideoInput
    {
        private readonly IList<Bitmap> _frames;
        private int _currentFrame;
        private readonly Timer _timer;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="filePathToFiles"></param>
        public BitmapCamera(string filePathToFiles): this(filePathToFiles, 0, 1200)
        {
        }

        /// <summary>
        /// Create a new BitmapCamera object from a collection of bitmap images. Assumes the images are zero-indexed and that the number of frames includes the 0 frame.
        /// </summary>
        /// <param name="filePathToFiles"></param>
        /// <param name="startFrame"></param>
        /// <param name="maxFrames"></param>
        public BitmapCamera(string filePathToFiles, int startFrame, int maxFrames)
        {
            _frames = new List<Bitmap>(maxFrames); // temp

            bool done = false;
            int i = startFrame;
            try
            {
                while (!done)
                {
                    string currFramePath = filePathToFiles + i + ".bmp";
                    if (i < startFrame + maxFrames && File.Exists(currFramePath))
                    {
                        _frames.Add(new Bitmap(currFramePath));
                        i++;
                    }
                    else
                    {
                        done = true;
                    }
                }

                _timer = new Timer(34);
                _timer.Elapsed += NextFrame;
            }
            catch (Exception)
            {
                Dispose();
                throw;
            }
        }

        /// <summary>
        /// Performs application-defined tasks associated with freeing, releasing, or resetting unmanaged resources.
        /// </summary>
        /// <filterpriority>2</filterpriority>
        public void Dispose()
        {
            foreach (var bitmap in _frames)
            {
                bitmap.Dispose();
            }
        }

        /// <summary>
        /// 
        /// </summary>
        public event VideoUpdate VideoEventHandler;

        /// <summary>
        ///  Starts the webcam and displaying the video stream
        ///  </summary>
        public void Start()
        {
            _timer.Start();
        }

        /// <summary>
        ///  Stops the  webcam and displaying the video stream
        ///  </summary>
        public void Stop()
        {
            _timer.Stop();
        }

        private void NextFrame(object source, ElapsedEventArgs e)
        {
            VideoUpdate handler = VideoEventHandler;
            if (handler != null)
            {
                handler(this, new Frame(_frames[_currentFrame], _currentFrame));
            }
            if (++_currentFrame >= _frames.Count)
                _currentFrame = 0;
        }
    }
}


