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
 * 1.0      jmaxxz Initial development                Initial implementation
 */
using System.Collections.Generic;
using Ares.Common.Api.DataTypes;

namespace Ares.Common.Api.Server
{
    /// <summary>
    /// Wraps an instance of <see cref="IPlayerManagement"/> and presents an <see cref="IPlayerManagementProxy"/>
    /// interface
    /// </summary>
    public class PlayerManagementProxy : IPlayerManagementProxy
    {
        private readonly IPlayerManagement _playerManagement;

        /// <summary>
        /// Creates a new instance which wraps <see cref="playerManagement"/>
        /// </summary>
        /// <param name="playerManagement">The instance to be wrapped</param>
        public PlayerManagementProxy(IPlayerManagement playerManagement)
        {
            _playerManagement = playerManagement;
        }

        /// <summary>
        /// Tells server a player wants to join
        /// </summary>
        /// <param name="player">The player who wishes to join</param>
        public void Join(IPlayer player)
        {
            _playerManagement.Join(player.ToMutablePlayer());
        }

        /// <summary>
        /// Tells server a player is leave
        /// </summary>
        /// <param name="player">The player which is leaving the game</param>
        public void Leave(IPlayer player)
        {
            _playerManagement.Leave(player.ToMutablePlayer());
        }

        /// <summary>
        /// Gets a collection of all the active players
        /// </summary>
        /// <returns></returns>
        public IEnumerable<IPlayer> GetPlayers()
        {
            IEnumerable<MutablePlayer> players = _playerManagement.GetPlayers();
            List<IPlayer> results = new List<IPlayer>();
            
            foreach (MutablePlayer mutablePlayer in players)
            {
                results.Add(mutablePlayer.ToIPlayer());
            }

            return results;

        }

        /// <summary>
        /// Updates internal player model, and pushes changes out to all clients.
        /// </summary>
        /// <param name="player">The updated player.  <see cref="IPlayer.Id"/> must remain the same.</param>
        public void UpdatePlayer(IPlayer player)
        {
            _playerManagement.UpdatePlayer(player.ToMutablePlayer());
        }
    }
}
