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
 */
 using System;
using System.Collections.Generic;
using System.Drawing;
using Ares.Common;
using Ares.Common.Api.Client;
using Ares.Common.Api.DataTypes;
using Ares.Common.Api.Server;
using Ares.Common.Network;
using System.ServiceModel;

namespace Ares.Client
{
    [CallbackBehavior(ConcurrencyMode = ConcurrencyMode.Reentrant)]
    public class GameClient : IClient, IDisposable
    {
        private IPlayer _player;
        private IList<IPlayer> _allPlayers;
        
        private IPlayerManagement _playerManagement = null;
        private IClientRegistration _registration = null;
        private IPositionTracker _positionTracker = null;
        private ISignalStrengthTracker _signalTracker = null;

        
        public GameClient()
        {
            _player = new Player(Guid.NewGuid(), "Player", Color.DarkViolet, 100);
            
            //Hooks for service references
            //_playerManagement.Join(_player.ToMutablePlayer());
            //_registration.Register(_player.Id);
        }

        /// <summary>
        /// Notifies client of damage to a player. 
        /// </summary>
        /// <param name="updatedPlayerState">The updated state of the player.</param>
        public void Damage(MutablePlayer updatedPlayerState)
        {
            _player.ChangeHealth(updatedPlayerState.Health);
            InvokePlayerUpdateEventHandler();

        }

        /// <summary>
        /// Notifies client they have been kicked from the server they were connected to
        /// </summary>
        /// <param name="reason">A description of the reason the client was kicked</param>
        public void Kick(string reason)
        {
            //Hooks to service reference
            _registration.Unregister(_player.Id);
            _playerManagement.Leave(_player.ToMutablePlayer());
        }

        /// <summary>
        /// Notifies client of shooting.
        /// </summary>
        /// <param name="source">The location which shots originated from</param>
        public void NotifyOfShooting(MutablePosition source)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Notifies client that a player has respawned.
        /// </summary>
        /// <param name="updatedPlayerState"></param>
        public void Respawn(MutablePlayer updatedPlayerState)
        {
            _player = (Player)updatedPlayerState.ToIPlayer();
            InvokePlayerUpdateEventHandler();
        }

        /// <summary>
        /// Notifies client that a player has been shot.
        /// </summary>
        /// <param name="updatedPlayerState">The updated state of the player who was shot</param>
        public void Shoot(MutablePlayer updatedPlayerState)
        {
            _player = (Player)updatedPlayerState.ToIPlayer();
            InvokePlayerUpdateEventHandler();
        }

        /// <summary>
        /// Pushes a collection of players (and their current states) to the clients.
        /// </summary>
        /// <param name="players">The complete list of all player currently playing</param>
        public void UpdatePlayerList(IEnumerable<MutablePlayer> players)
        {
            _allPlayers = (IList<IPlayer>)players;
            InvokeAllPlayersUpdateEventHandler();
        }

        /// <summary>
        /// Gets the <see cref="Guid"/> of the player which this client represents
        /// </summary>
        /// <returns>The <see cref="Guid"/> of the player associated with this client</returns>
        public Guid GetGuid()
        {
            return _player.Id;
        }

        /// <summary>
        /// Gets the information about the player which this client represents
        /// </summary>
        /// <returns>The informaiton about the player</returns>
        public IPlayer GetPlayer()
        {
            return _player;
        }

        private void InvokePlayerUpdateEventHandler()
        {
            PlayerUpdate handler = PlayerEventHandler;
            if (handler != null)
            {
                handler(this, _player);
            }
        }

        private void InvokeAllPlayersUpdateEventHandler()
        {
            AllPlayersUpdate handler = AllPlayersEventHandler;
            if (handler != null)
            {
                handler(this, _allPlayers);
            }
        }

        /*
        private void InvokeWifiUpdateEventHandler()
        {
            WifiUpdate handler = WifiEventHandler;
            if (handler != null)
            {
                handler(this, _gameEngine.WirelessMonitor);
            }
        }
         */

        public event PlayerUpdate PlayerEventHandler;
        public event AllPlayersUpdate AllPlayersEventHandler;
        public event WifiUpdate WifiEventHandler;

        public void Dispose()
        {
            //Hooks to service reference
            //_registration.Unregister(_player.Id);
            //_playerManagement.Leave(_player.ToMutablePlayer());
        }
    }

    public delegate void PlayerUpdate(object sender, IPlayer player);
    public delegate void AllPlayersUpdate(object sender, IList<IPlayer> allPlayers);
    public delegate void WifiUpdate(object sender, IWirelessStrengthMonitor signal);
}
