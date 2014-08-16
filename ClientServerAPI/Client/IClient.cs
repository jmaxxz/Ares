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
 * 1.0      jmaxxz Added push notification            Wired up PushServer
 */
namespace Ares.Common.Api.Client
{
    using System.Collections.Generic;
    using System.ServiceModel;
    using DataTypes;
    using System;

    /// <summary>
    /// An Api for communication with Ares clients, which it uses mutable data types and support the WCF.
    /// </summary>
    [ServiceContract(Namespace = "http://Ares.Common.Api.Client")]
    public interface IClient
    {
        /// <summary>
        /// Notifies client of damage to a player. 
        /// </summary>
        /// <param name="updatedPlayerState">The updated state of the player.</param>
        [OperationContract(IsOneWay = true)]
        void Damage(MutablePlayer updatedPlayerState);

        /// <summary>
        /// Notifies client they have been kicked from the server they were connected to
        /// </summary>
        /// <param name="reason">A description of the reason the client was kicked</param>
        [OperationContract(IsOneWay = true)]
        void Kick(string reason);

        /// <summary>
        /// Notifies client of shooting.
        /// </summary>
        /// <param name="source">The location which shots originated from</param>
        [OperationContract(IsOneWay = true)]
        void NotifyOfShooting(MutablePosition source);

        /// <summary>
        /// Notifies client that a player has respawned.
        /// </summary>
        /// <param name="updatedPlayerState"></param>
        [OperationContract(IsOneWay = true)]
        void Respawn(MutablePlayer updatedPlayerState);


        /// <summary>
        /// Notifies client that a player has been shot.
        /// </summary>
        /// <param name="updatedPlayerState">The updated state of the player who was shot</param>
        [OperationContract(IsOneWay = true)]
        void Shoot(MutablePlayer updatedPlayerState);


        /// <summary>
        /// Pushes a collection of players (and their current states) to the clients.
        /// </summary>
        /// <param name="players">The complete list of all player currently playing</param>
        [OperationContract(IsOneWay = true)]
        void UpdatePlayerList(IEnumerable<MutablePlayer> players);

        /// <summary>
        /// Gets the <see cref="Guid"/> of the player which this client represents
        /// </summary>
        /// <returns>The <see cref="Guid"/> of the player associated with this client</returns>
        [OperationContract]
        Guid GetGuid();

    }
}
