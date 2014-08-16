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
 * 1.0      jmaxxz initial development                stubbed interface.
 */
namespace Ares.Common.Api.Server
{
    using System.ServiceModel;
    using System;
    using Client;

    /// <summary>
    /// Allows clients to register and unregister for server pushed data.
    /// </summary>
    [ServiceContract(
        Name = "IClientRegistration",
        Namespace = "http://Ares.Common.Api.Server",
        CallbackContract = typeof(IClient),
        SessionMode = SessionMode.Required)]
    public interface IClientRegistration
    {
        /// <summary>
        /// Registers the player with an id of <see cref="playerId"/> for push updates.
        /// </summary>
        /// <param name="playerId"></param>
        [OperationContract(IsOneWay = true)]
        void Register(Guid playerId);

        /// <summary>
        /// Unregisters the player with an id of <see cref="playerId"/>, from push updates.
        /// </summary>
        /// <param name="playerId"></param>
        [OperationContract(IsOneWay = true)]
        void Unregister(Guid playerId);
    }

}
