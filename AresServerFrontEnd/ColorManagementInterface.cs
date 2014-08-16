/*
 *  Ares, a multi-player augmented reality first person shooter
 *  Copyright (C) 2010  Jmaxxz, Mike McBride, and Kevin Curtis
 * 
 *  This program is free software; you can redistribute it and/or modify
 *  it under the terms of the GNU General Public License as published by
 *  the Free Software Foundation; either version 2 of the License, or
 *  (at your option) any later version.
 * 
 *  This program is distributed in the hope that it will be useful,
 *  but WITHOUT ANY WARRANTY; without even the implied warranty of
 *  MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
 *  GNU General Public License for more details.
 *  You should have received a copy of the GNU General Public License along
 *  with this program; if not, write to the Free Software Foundation, Inc.,
 *  51 Franklin Street, Fifth Floor, Boston, MA 02110-1301 USA.
 *  
 * 
 * Change log
 * 
 * Version | Author | Reason for change                | Description of change
 * -------- -------- ---------------------------------- ------------------------------------------------------
 * 1.0      jmaxxz initial development                Intial creation
 */
namespace Ares.Server
{
    using System.Collections.Generic;
    using System.Windows.Forms;
    using Common.Api.Server;
    using System.Threading;
    using System.Drawing;
    using Common.Webcam;
    using Common.Video;
    using System;
    using Common;

    /// <summary>
    /// Provides an interface for setting the color of players on
    /// a server.
    /// </summary>
    public partial class ColorManagementInterface : UserControl
    {
        private IVideoInput _cam;
        private uint _activeFrameCount;
        private Bitmap _currentFrame;
        private Color _currentColor;
        private const int Videodevice = 0; // zero based index of video capture device to use
        private const int Videowidth = 640; // Depends on video device caps
        private const int Videoheight = 480; // Depends on video device caps
        private const int Videobitsperpixel = 24; // BitsPerPixel values determined by device


        private IPlayerManagementProxy _playerManagementServer;
        /// <summary>
        /// Gets and sets the <see cref="IPlayerManagementProxy"/> which will be used
        /// by this instance to get and set player data.
        /// </summary>
        public IPlayerManagementProxy PlayerManagementServer 
        { 
            get
            {
                return _playerManagementServer;
            }
            set
            {
                _playerManagementServer = value;
                UpdatePlayerList();
            }
        }

        /// <summary>
        /// Constructs a new instance.
        /// </summary>
        public ColorManagementInterface()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Initializes webcam and outputs a video stream. 
        /// </summary>
        public void InitCamera()
        {
            _cam = new DSCapture(Videodevice, Videowidth, Videoheight, Videobitsperpixel);
            _cam.VideoEventHandler += FrameUpdateHandler;
            _cam.Start();
        }


        private void FrameUpdateHandler(object sender, Frame frame)
        {
            if (InvokeRequired)
            {
                if (_activeFrameCount > 0)
                {
                    return;
                }
                // Execute the same method, but this time on the GUI thread
                BeginInvoke(new ThreadStart(() => FrameUpdateHandler(sender, frame)));
                return;
            }

            _activeFrameCount++;

            videoFeed.Image = Render(frame);
            _currentFrame = frame.Image;
            _activeFrameCount--;
        }

        private void cmdRefreshPlayerList_Click(object sender, EventArgs e)
        {
            UpdatePlayerList();
        }

        private void cmdGetPlayerColor_Click(object sender, EventArgs e)
        {
            if (_currentFrame == null)
                return;

            _currentColor = _currentFrame.GetPixel(_currentFrame.Width / 2, _currentFrame.Height / 2);
            lblCurrentPlayerColor.BackColor = _currentColor;
        }

        private void cmdSetPlayerColor_Click(object sender, EventArgs e)
        {
            PlayerManagementServer.UpdatePlayer(GetSelectedPlayer().ChangeColor(_currentColor));
            cmdRefreshPlayerList.PerformClick();
        }

        private void lboxPlayers_SelectedValueChanged(object sender, EventArgs e)
        {
            UpdateUiForSectionChange();
        }


        private void ColorManagementInterface_Load(object sender, EventArgs e)
        {
            UpdateUiForSectionChange();
        }

        /// <summary>
        /// Updates the list of players currently on the server
        /// </summary>
        private void UpdatePlayerList()
        {
            if(PlayerManagementServer == null)
            {
                lboxPlayers.Items.Clear();
            }
            else
            {
                IEnumerable<IPlayer> tempPlayerList = PlayerManagementServer.GetPlayers();
                lboxPlayers.Items.Clear();

                foreach (IPlayer curPlayer in tempPlayerList)
                {
                    lboxPlayers.Items.Add(curPlayer);
                }
            }

            UpdateUiForSectionChange();
        }

        /// <summary>
        /// Gets the currently selected player
        /// </summary>
        /// <returns></returns>
        private IPlayer GetSelectedPlayer()
        {
            return ((IPlayer)(lboxPlayers.SelectedItem));
        }

        /// <summary>
        /// Renders targeting reticle on passed in bitmap
        /// </summary>
        /// <param name="frame"></param>
        /// <returns></returns>
        private Bitmap Render(Frame frame)
        {
            Bitmap bmp = (Bitmap)frame.Image.Clone();

            Graphics g = Graphics.FromImage(bmp);
            Pen redPen = new Pen(Color.Red, 2);

            g.DrawEllipse(redPen, (bmp.Width / 2) - 5, (bmp.Height / 2) - 5, 5, 5);
            g.Dispose();

            return bmp;
        }

        /// <summary>
        /// Handles a change with the currently selected player
        /// </summary>
        private void UpdateUiForSectionChange()
        {
            if (GetSelectedPlayer() == null)
            {
                cmdGetPlayerColor.Enabled = false;
                cmdSetPlayerColor.Enabled = false;
                _currentColor = Color.Transparent;
            }
            else
            {
                cmdGetPlayerColor.Enabled = true;
                cmdSetPlayerColor.Enabled = true;

                _currentColor = GetSelectedPlayer().ClothingColor;
            }

            lblCurrentPlayerColor.BackColor = _currentColor;
        }
    }
}
