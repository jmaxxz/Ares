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
 * 1.0      jmaxxz initial development                initial implementation
 */
using System;
using System.ServiceModel;
using Ares.Common.Api.Client;
using Ares.Common.Api.Server;

namespace Ares.Server
{
    /// <summary>
    /// Handles the registration of clients for push based event notification.
    /// </summary>
    [ServiceBehavior(InstanceContextMode = InstanceContextMode.PerSession)]
    public class ClientRegistration : IClientRegistration
    {
        /// <summary>
        /// Registers the player with an id of <see cref="playerId"/> for push updates.
        /// </summary>
        /// <param name="playerId"></param>
        public void Register(Guid playerId)
        {
            PushServer.GetDefault().RegisterClient(playerId, OperationContext.Current.GetCallbackChannel<IClient>());
        }

        /// <summary>
        /// Unregisters the player with an id of <see cref="playerId"/>, from push updates.
        /// </summary>
        /// <param name="playerId"></param>
        public void Unregister(Guid playerId)
        {
            PushServer.GetDefault().UnregisterClient(playerId);
        }
    }
}
