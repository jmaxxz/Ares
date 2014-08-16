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
 * Change log
 * 
 * Version | Author | Reason for change                | Description of change
 * -------- -------- ---------------------------------- ------------------------------------------------------
 * 1.0      jmaxxz initial development                Intial creation
 */
namespace Ares.Server
{
    using System.Windows.Forms;
    using Common.Api.Server;
    using System;

    public partial class GameManagementInterface : UserControl
    {
        /// <summary>
        /// Gets and sets the <see cref="IGameManagerProxy"/> to be used
        /// by this instance.
        /// </summary>
        public IGameManagerProxy GameManager { get; set; }

        /// <summary>
        /// Initializes a new instance.
        /// </summary>
        public GameManagementInterface()
        {
            InitializeComponent();
        }

        private void cmdStart_Click(object sender, EventArgs e)
        {
            StartMatch();
        }

        private void cmdStop_Click(object sender, EventArgs e)
        {
            StopMatch();
        }

        /// <summary>
        /// Sets the game length and starts a new match.
        /// </summary>
        private void StartMatch()
        {
            cmdStop.Enabled = true;
            cmdStart.Enabled = false;
            txtTimePermatch.Enabled = false;

            GameManager.SetGameLength(TimeSpan.Parse("00:" + txtTimePermatch.Text));

            GameManager.StartGame();
        }

        /// <summary>
        /// Stops the current match.
        /// </summary>
        private void StopMatch()
        {
            cmdStart.Enabled = true;
            cmdStop.Enabled = false;
            txtTimePermatch.Enabled = true;

            GameManager.StopGame();
        }


    }
}
