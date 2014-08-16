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
 * 0.95     mcbridem Initial development                Fully defined every method
 * 1.00     mcbridem Tweaking                           Various changes to adjust for design changes in detection algorithms.
 * 1.0      jmaxxz Misc Refactoring, Server impl      Refactored codebase, added basic server
 *                                                      
 */

namespace Ares.Client.AnalysisTest
{
    using System.Collections.Generic;
    using Common;
    using System.Drawing;
    using System.Windows.Forms;
    using Analysis;
    using Common.Video;
    using System.Threading;
    using Common.Webcam;

    /// <summary>
    /// A simple interface for verifying blob tracking systems.
    /// </summary>
    public partial class StreamViewer : Form
    {
        private readonly BlobDetectionAnalysis _analyzer;
        private readonly IList<IPlayer> _players;
        private readonly IVideoInput _videoInput;
        private int _activeFrameCount;
        private int _dropCount;

        /// <summary>
        /// Default constructor.
        /// </summary>
        public StreamViewer()
        {
            InitializeComponent();

            _analyzer = new BlobDetectionAnalysis(45, 45, 400, 400, 15, .3f, 0.45f);
            _players = new List<IPlayer> { new Player(System.Guid.NewGuid(), "Test Player 1", Color.FromArgb(137, 155, 180)) };//,
                            //new Player(System.Guid.NewGuid(), "Test Player 2", Color.FromArgb(164, 105, 116)) };

            //_videoInput = new BitmapCamera("D:\\My Documents\\Senior Design\\repo\\trunk\\test_files\\Green_Blob\\cap", 850, 200);
            _videoInput = new DSCapture(0, 0, 0, 0);
            _videoInput.VideoEventHandler += FrameUpdateHandler;
        }

        private void btnStart_Click(object sender, System.EventArgs e)
        {
            _videoInput.Start();
        }

        private void FrameUpdateHandler(object sender, Frame frame)
        {
            if (InvokeRequired)
            {
                if (_activeFrameCount > 0)
                {
                    _dropCount++;
                    return;
                }
                // Execute the same method, but this time on the GUI thread
                BeginInvoke(new ThreadStart(() => FrameUpdateHandler(sender, frame)));
                return;
            }
            _activeFrameCount++;
            NextFrame(frame);
            _activeFrameCount--;
        }

        private void NextFrame(Frame frame)
        {
            lblDrops.Text = "Drops: " + _dropCount;

            // Process image
            ProcessedImage analyzedFrame = (ProcessedImage) _analyzer.Analyze(frame.Image, _players);
            // Put the image into the box
            pbxPicBox.Image = analyzedFrame.BaseImage;

            // Draw frames around the blobs
            IList<IPlayerBlob> blobs = (IList<IPlayerBlob>)analyzedFrame.Blobs;
            List<IBlob> rawblobs = (List<IBlob>)analyzedFrame.RawBlobs;
            
            using (Graphics g = Graphics.FromImage(analyzedFrame.BaseImage))
            using (Pen greenPen = new Pen(Color.LimeGreen, 3))
            using (Pen redPen = new Pen(Color.Red, 3))
            using (Pen blackPen = new Pen(Color.Black, 3))
            {
                //foreach (var blob in rawblobs)
                //{
                //    //Pen blobPen = new Pen(blob.Color, 3);
                //    //g.DrawRectangle(blobPen, blob.Position.X, blob.Position.Y, blob.Dimension.Width,
                //    //                blob.Dimension.Height);
                //    //blobPen.Dispose();

                //    g.DrawRectangle(redPen, blob.Position.X, blob.Position.Y, blob.Dimension.Width, blob.Dimension.Height);
                //    g.DrawEllipse(blackPen, blob.Center.X - 5, blob.Center.Y - 5, 5, 5);
                //}
                //foreach (var blob in blobs)
                //{
                //    g.DrawRectangle(greenPen, blob.BaseBlob.Position.X, blob.BaseBlob.Position.Y, blob.BaseBlob.Dimension.Width, blob.BaseBlob.Dimension.Height);
                //}
            }
            
            // Refresh the box to force graphics updates
            pbxPicBox.Refresh();

        }
    }
}


