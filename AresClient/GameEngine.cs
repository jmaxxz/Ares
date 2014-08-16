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
 * 1.0      jmaxxz Misc Refactoring, Server impl      Refactored codebase, added basic server
 */
using System.Collections.Generic;
using Ares.Client.Gps;
using Ares.Common;
using Ares.Common.Network;
using Ares.Common.Video;

namespace Ares.Client
{
    public class GameEngine
    {
        public IWirelessStrengthMonitor WirelessMonitor{ get; private set; }
        public IGps Gps { get; private set; }
        public IList<IPlayer> AllPlayers { get; set; }
        public IPlayer ClientPlayer { get; private set; }
        public IVideoInput Video { get; private set; }

        public GameEngine(IWirelessStrengthMonitor wirelessMonitor, IGps gps, IPlayer player, IVideoInput video)
        {
            WirelessMonitor = wirelessMonitor;
            Gps = gps;
            ClientPlayer = player;
            AllPlayers = new List<IPlayer>();
            Video = video;
            
        }
    }
}
