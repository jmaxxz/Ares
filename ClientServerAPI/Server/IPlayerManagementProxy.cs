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
 * 0.95     jmaxxz initial development                Fully implemented every method
 * 1.0      jmaxxz Misc Refactoring, Server impl      Refactored codebase, added basic server
 * 1.0      jmaxxz continued development              Continued development
 */
namespace Ares.Common.Api.Server
{
    using System.Collections.Generic;


    /// <summary>
    /// This interface describes the a service on the game server which manages the list of active players.
    /// This interface is safer than <see cref="IPlayerManagement"/>.
    /// </summary>
    public interface IPlayerManagementProxy
    {
        /// <summary>
        /// Tells server a player wants to join
        /// </summary>
        /// <param name="player">The player who wishes to join</param>
        void Join(IPlayer player);

        /// <summary>
        /// Tells server a player is leave
        /// </summary>
        /// <param name="player">The player which is leaving the game</param>
        void Leave(IPlayer player);

        /// <summary>
        /// Gets a collection of all the active players
        /// </summary>
        /// <returns></returns>
        IEnumerable<IPlayer> GetPlayers();

        /// <summary>
        /// Updates internal player model, and pushes changes out to all clients.
        /// </summary>
        /// <param name="player">The updated player.  <see cref="IPlayer.Id"/> must remain the same.</param>
        void UpdatePlayer(IPlayer player);
    }
}
