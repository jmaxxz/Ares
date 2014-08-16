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
 * 1.0      jmaxxz Added push notification            Wired up PushServer
 */
using System;
using System.Collections.Generic;
using System.Drawing;
using System.ServiceModel;
using System.ServiceModel.Description;
using System.Windows.Forms;
using Ares.Common.Api.Server;
using Ares.Server.Utils;

namespace Ares.Server
{
    /// <summary>
    /// Provides a visual interface for monitoring an managing a Ares game server
    /// </summary>
    public partial class ServerUi : Form
    {


        private readonly IEnumerable<ServiceHost> _serviceHosts;
        private readonly UnityServer _unityServer;


        /// <summary>
        /// Creates a new instance for a specified <see cref="ServiceHost"/> which is running the server.
        /// </summary>
        /// <param name="serviceHosts"></param>
        public ServerUi(IEnumerable<ServiceHost> serviceHosts)
        {
            _unityServer = new UnityServer();
            _serviceHosts = serviceHosts;
            InitializeComponent();

            colorManagementInterface.PlayerManagementServer = new PlayerManagementProxy(_unityServer);
            consoleInterface.BackingConsole = _unityServer.ServerConsole;
            gameManagementInterface.GameManager = new GameManagerProxy(_unityServer);
        }

        private void ServerUi_Load(object sender, EventArgs e)
        {
            //Output all the endpoint on the server
            foreach (ServiceHost serviceHost in _serviceHosts)
            {
                txtBoxEndpoints.AppendColoredText(serviceHost.Description.Name, Color.Black);
                txtBoxEndpoints.AppendText(Environment.NewLine);

                foreach (ServiceEndpoint endpoint in serviceHost.Description.Endpoints)
                {
                    string contract = endpoint.Contract.Name;
                    string uri = endpoint.ListenUri.ToString();
                    txtBoxEndpoints.AppendText("\t");
                    txtBoxEndpoints.AppendColoredText(contract, Color.DarkRed);
                    txtBoxEndpoints.AppendColoredText("@", txtBoxEndpoints.ForeColor);
                    txtBoxEndpoints.AppendColoredText(uri, Color.DarkBlue);
                    txtBoxEndpoints.AppendText(Environment.NewLine);

                } 
            }
            
            colorManagementInterface.InitCamera();
        }



    }
}
