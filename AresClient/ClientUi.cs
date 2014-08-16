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
 * 
 * 
 * Change log
 * 
 * Version | Author | Reason for change                | Description of change
 * -------- -------- ---------------------------------- ------------------------------------------------------
 * 1.00     curtisk  Initial development                Implemented most client side actions
 */

using System;
using System.Collections.Generic;
using System.Configuration;
using System.Drawing;
using System.Threading;
using System.Windows.Forms;
using Ares.Client.Analysis;
using Ares.Client.Display;
using Ares.Client.Gps;
using Ares.Client.Network.WiFi;
using Ares.Common;
using Ares.Common.Api.DataTypes;
using Ares.Common.Api.Server;
using Ares.Common.Network;
using Ares.Common.Video;
using Microsoft.Practices.Unity;
using Microsoft.Practices.Unity.Configuration;
using System.Timers;
using Timer = System.Timers.Timer;
using System.ServiceModel;

namespace Ares.Client
{
    /// <summary>
    /// Back end of Client UI, connects UI with neccessary components, Unity, and ARES server.
    /// </summary>
    [CallbackBehavior(ConcurrencyMode = ConcurrencyMode.Reentrant)]
    public partial class ClientUi : Form
    {
        private Guid _guid;
        private GameClient _client;
        private GamePlay _gamePlay;
        private IPlayer _player;
        private IList<IPlayer> _allPlayers;
        private IWirelessStrengthMonitor _signal;

        private bool displayScore = false;
        
        private int activeFrameCount;
        private int dropCount;
        private int frameCount;
        
        private BlobDetectionAnalysis _analyzer;
        private Bitmap _currentImage;
        private DisplayManager _dispMan;
        private GameEngine _gameEngine;
        private UnityContainer _container;
        private TimeSpan _gameTime;

        private IPositionTrackerProxy _positionTracker;
        
        
        private bool _running;
        private Thread _timeThread;
        private Thread _positionThread;
        
        private IList<IPlayerBlob> blobs;
        private bool _clock = false;

        private Timer _timer;

        /// <summary>
        /// Initializes GUI components, connections to the Heads Up Display, the video analysis,
        /// the game client, and the hardware components throught Unity.
        /// Connects
        /// </summary>
        public ClientUi()
        {
            InitializeComponent();
            _allPlayers = new List<IPlayer>();
            _analyzer = new BlobDetectionAnalysis(45, 45, 800, 800, 15, .3f, 0.5f);
            _dispMan = new DisplayManager { DisplayTimer = true, DisplaySignalStrength = true };
            _client = new GameClient();
            _player = _client.GetPlayer();
            _guid = _client.GetGuid();
            _client.PlayerEventHandler += PlayerUpdateHandler;
            _client.AllPlayersEventHandler += AllPlayersUpdateHandler;
             var config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
            UnityConfigurationSection section = (UnityConfigurationSection)config.GetSection("unity");
            _container = new UnityContainer();
            section.Configure(_container, "container");

            _gamePlay = new GamePlay(_player);
            _gameEngine = new GameEngine(_container.Resolve<IWirelessStrengthMonitor>(), _container.Resolve<IGps>(), _player, _container.Resolve<IVideoInput>());

            _signal = _container.Resolve<IWirelessStrengthMonitor>();


            _running = true;

            /* // Threads for timer and positioning updating
            _timeThread = new Thread(TimeUpdateLoop) {IsBackground = true};
            _timeThread.Start();
            _positionThread = new Thread(PositionUpdateLoop);
            _positionThread.Start();
            */

            _gameTime = new TimeSpan(0,5,0);

            _timer = new Timer(1000);
            _timer.Elapsed += gameTimeSim;
            
        }

        /// <summary>
        /// Connects the VideoEventHandler to the FrameUpdateHandler and starts
        /// the webcam.
        /// </summary>
        private void InitCamera()
        {
            _gameEngine.Video.VideoEventHandler += FrameUpdateHandler;
            _gameEngine.Video.Start();
        }

        /// <summary>
        /// On the time thread, updates the amount of time left in the game every second
        /// from the server.
        /// </summary>
        public void TimeUpdateLoop()
        {
            while (_running)
            {
                _gameTime = _gamePlay.getGameTime();
                Thread.Sleep(1000);
            }
        }

        /// <summary>
        /// On the position thread, updates the player's position to the server every
        /// half of a second.
        /// </summary>
        public void PositionUpdateLoop()
        {
            while (_running)
            {
                _positionTracker.SetPosition(_gameEngine.Gps.CurrentPosition, _player);
                Thread.Sleep(500);
            }
        }
        /// <summary>
        /// Renders the output image with the heads up display (HUD) and the game scores.
        /// </summary>
        /// <param name="frame"></param>
        /// <returns></returns>
        public Bitmap Render(ProcessedImage frame)
        {
            Bitmap bmp = _dispMan.OverlayHud(frame, _player, _gameTime, _signal.Strength);
            
            if (displayScore)
            {
                bmp = _dispMan.OverlayScoreDisplay(bmp, _allPlayers);
            }
            if (_player.Health < 5)
            {
                bmp = _dispMan.OverlayDeadDisplay(bmp, "You have died. \n Waiting for Respawn...");
            }
            
            return bmp;
        }

        /// <summary>
        /// Updates the frame counter and updates the displayed image
        /// </summary>
        /// <param name="sender">Object sending the signal to update</param>
        /// <param name="frame">The Frame container holding the Image and the index of the image in the bitstream</param>
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
            ProcessedImage analyzedFrame = (ProcessedImage)_analyzer.Analyze(frame.Image, _allPlayers);
            // Put the image into the box
            videoOut.Image = Render(analyzedFrame);
            _currentImage = frame.Image;
            activeFrameCount--;
        }

        /// <summary>
        /// Updates the player's information
        /// </summary>
        /// <param name="sender">Object sending the signal to update</param>
        /// <param name="player">The Player container with updated information</param>
        private void PlayerUpdateHandler(object sender, IPlayer player)
        {
            if (InvokeRequired)
            {
                BeginInvoke(new ThreadStart(() => PlayerUpdateHandler(sender, player)));
                return;
            }
            _player = player;
        }

        /// <summary>
        /// Updates the player of information of all players currently in the game
        /// </summary>
        /// <param name="sender">Object sending the signal to update</param>
        /// <param name="allPlayers">A list of all players</param>
        private void AllPlayersUpdateHandler(object sender, IList<IPlayer> allPlayers)
        {
            if (InvokeRequired)
            {
                BeginInvoke(new ThreadStart(() => AllPlayersUpdateHandler(sender, allPlayers)));
                return;
            }
            _allPlayers = allPlayers;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="signal"></param>
        private void WifiUpdateHandler(object sender, IWirelessStrengthMonitor signal)
        {
            if (InvokeRequired)
            {
                BeginInvoke(new ThreadStart(() => WifiUpdateHandler(sender, signal)));
                return;
            }
            _signal = signal;
        }

        /// <summary>
        /// Method for when the mouse is clicked down on the image. Right click
        /// displays the scores in the game.
        /// </summary>
        /// <param name="sender">Object sending the signal</param>
        /// <param name="e">Event fired when mouse is clicked down</param>
        private void ClientUi_MouseDown(object sender, MouseEventArgs e)
        {
            switch (e.Button)
            {
                case MouseButtons.Right:
                    {
                        displayScore = true;
                        break;
                    }
            }
        }

        /// <summary>
        /// Method for when the mouse click is released on the image. Left click 
        /// fires a shot in the system; Right click hides the scores.
        /// </summary>
        /// <param name="sender">Object sending the signal</param>
        /// <param name="e">Event fired when mouse click is released</param>
        private void ClientUi_MouseUp(object sender, MouseEventArgs e)
        {
            switch (e.Button)
            {
                case MouseButtons.Left:
                    {
                        _dispMan.TriggerFiredShot();
                        _gamePlay.Fire_Shot(blobs, new Frame((Bitmap)videoOut.Image, frameCount));
                        break;
                    }
                case MouseButtons.Right:
                    {
                        displayScore = false;
                        break;
                    }
            }
        }

        /// <summary>
        /// Closing of the program
        /// </summary>
        /// <param name="sender">Object sending the signal</param>
        /// <param name="e">Event of closing the form</param>
        private void ClientUi_FormClosing(object sender, FormClosingEventArgs e)
        {
            //Leave game
            _running = false;
            _gameEngine.Video.Stop();
            _client.Dispose();
            _gameEngine.Video.Dispose();
        }

        private void ClientUi_Load(object sender, EventArgs e)
        {
            InitCamera();
        }


        //Key Codes - Mainly for testing purposes
        private void ClientUi_KeyUp(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.F:
                    {
                        FullScreen = !FullScreen;
                        break;
                    }
                case Keys.Escape:
                    {
                        FullScreen = false;
                        break;
                    }
                case Keys.H: //lower health
                    {
                        if(_player.Health > 4)
                        {
                            IPlayer player = new Player(_player.Id, _player.Nickname,
                                                        _player.ClothingColor, _player.Health - 5,
                                                        _player.CurrentPosition);
                            //_client.Damage(player.ToMutablePlayer());
                            _player = player;
                        }
                        break;
                    }
                case Keys.J: //increase health
                    {
                        if(_player.Health < 96)
                        {
                            IPlayer player = new Player(_player.Id, _player.Nickname,
                                                        _player.ClothingColor, _player.Health + 5,
                                                        _player.CurrentPosition);
                            //_client.Damage(player.ToMutablePlayer());
                            _player = player;
                        }
                        break;
                    }
                case Keys.O: //start and stop clock
                    {
                        if (!_timer.Enabled)
                        {
                            _timer.Start();
                        }
                        else
                        {
                            _timer.Stop();
                        }
                        break;
                    }
                case Keys.R: //reset player life total
                    {
                        IPlayer player = new Player(_player.Id, _player.Nickname,
                                                        _player.ClothingColor, 100,
                                                        _player.CurrentPosition);
                        //_client.Damage(player.ToMutablePlayer());
                        _player = player;
                        break;
                    }
                case Keys.E: //add a player
                    {
                        addPlayerSim();
                        break;
                    }
                case Keys.T: //reset time
                    {
                        _gameTime = new TimeSpan(0,5,0);
                        break;
                    }
                case Keys.C: //reset all players
                    {
                        _allPlayers.Clear();
                        break;
                    }
            }
        }

        /// <summary>
        /// Timer simulation, not for final production
        /// </summary>
        /// <param name="sender">Object sending he signal</param>
        /// <param name="elapsedEventArgs">Timer event for updating the time</param>
        public void gameTimeSim (object sender, ElapsedEventArgs elapsedEventArgs)
        {
            TimeSpan second = new TimeSpan(0, 0, 1);
            _gameTime = _gameTime - second;
            if(_gameTime.TotalSeconds <=0)
            {
                _gameTime = new TimeSpan(0, 5, 0);
            }
            
        }

        /// <summary>
        /// Simulation for adding players to the game, not for final production
        /// </summary>
        public void addPlayerSim ()
        {
            if (_currentImage == null)
                return;

            Color c = _currentImage.GetPixel(_currentImage.Width/2, _currentImage.Height/2);
            
            _allPlayers.Add(new Player(new Guid(), "Enemy", c));
        }

        public bool FullScreen 
        {
            get
            {
                return FormBorderStyle == FormBorderStyle.None;
            }
            set
            {
                if(value)
                {
                    FormBorderStyle = FormBorderStyle.None;
                    WindowState = FormWindowState.Maximized;
                }
                else
                {
                    FormBorderStyle = FormBorderStyle.Fixed3D;
                }
            }
        }
    }
}
