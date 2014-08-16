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
 * 1.0      jmaxxz initial development                Fully implemented every method
 */
namespace Ares.Server
{
    using System.Collections.Generic;
    using Common.Api.DataTypes;
    using Common.Api.Server;
    using Common;

    public class PlayerManagement : IPlayerManagement
    {
        private readonly IPlayerManagementProxy _playerManagementProxy;

        public PlayerManagement(IPlayerManagementProxy playerManagementProxy)
        {
            _playerManagementProxy = playerManagementProxy;
        }

        /// <summary>
        /// Tells server a player wants to join
        /// </summary>
        /// <param name="player">The player who wishes to join</param>
        public void Join(MutablePlayer player)
        {
            _playerManagementProxy.Join(player.ToIPlayer());
        }

        /// <summary>
        /// Tells server a player is leave
        /// </summary>
        /// <param name="player">The player which is leaving the game</param>
        public void Leave(MutablePlayer player)
        {
            _playerManagementProxy.Leave(player.ToIPlayer());
        }

        /// <summary>
        /// Gets a collection of all the active players
        /// </summary>
        /// <returns></returns>
        public IEnumerable<MutablePlayer> GetPlayers()
        {
            IList<MutablePlayer> players = new List<MutablePlayer>();

            foreach(IPlayer p in _playerManagementProxy.GetPlayers())
            {
                players.Add(p.ToMutablePlayer());
            }

            return players;
        }

        /// <summary>
        /// Updates internal player model, and pushes changes out to all clients.
        /// </summary>
        /// <param name="player">The updated player.  <see cref="MutablePlayer.Id"/> must remain the same.</param>
        public void UpdatePlayer(MutablePlayer player)
        {
            _playerManagementProxy.UpdatePlayer(player.ToIPlayer());
        }
    }
}
