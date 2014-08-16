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
using Ares.Common;
using Ares.Common.Api.DataTypes;

namespace Ares.Server
{
    using System.Collections.Generic;
    using Common.Api.Client;
    using System;

    /// <summary>
    /// Provides a mapping which lets consuming classes look up the <see cref="IClient"/> to be used
    /// when pushing updates to a player with a specified ID.
    /// </summary>
    public class PushServer
    {
        private readonly IDictionary<Guid, IClient> _clients;
        private static PushServer _defaultInstance;
        private static object _defaultInstanceLock = new object();

        /// <summary>
        /// Creates a new and empty instance
        /// </summary>
        public PushServer()
        {
            _clients = new Dictionary<Guid, IClient>();
        }

        /// <summary>
        /// Registers a client to handle push notifications for a specified player id
        /// </summary>
        /// <param name="id">The unique id of the player which <see cref="client"/> should handle requests for</param>
        /// <param name="client">The <see cref="IClient"/> which will handle push notifications for player id <see cref="id"/></param>
        public void RegisterClient(Guid id, IClient client)
        {
            lock (_clients)
            {
                if (_clients.ContainsKey(id))
                {
                    UnregisterClient(id);
                }

                _clients.Add(id, client);
            }
        }

        /// <summary>
        /// Removes a specified player id from this <see cref="PushServer"/>
        /// </summary>
        /// <param name="id">The player id to be removed</param>
        public void UnregisterClient(Guid id)
        {
            lock (_clients)
            {
                if (!_clients.ContainsKey(id))
                {
                    return;
                }

                _clients.Remove(id);
            }
        }

        /// <summary>
        /// Returns the <see cref="IClient"/> to be used for a player with an id of <see cref="id"/>
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public IClient GetClient(Guid id)
        {
            IClient client = null;

            lock (_clients)
            {
                if (_clients.ContainsKey(id))
                {
                    client = _clients[id];
                }
            }

            return client;
        }

        public void NotifyAllOfDamage(IPlayer player)
        {
            lock (_clients)
            {
                foreach (var client in _clients.Values)
                {
                    client.Damage(player.ToMutablePlayer());
                }
            }
        }

        public void NotifyAllOfRespawn(IPlayer player)
        {
            lock (_clients)
            {
                foreach (var client in _clients.Values)
                {
                    client.Respawn(player.ToMutablePlayer());
                }
            }
        }

        public void NotifyAllOfShot(IShot shot)
        {
            lock (_clients)
            {
                foreach (var client in _clients.Values)
                {
                    client.NotifyOfShooting(shot.Shooter.CurrentPosition.ToMutablePosition());
                }
            }

        }

        /// <summary>
        /// Returns the default (static) instance of <see cref="PushServer"/>
        /// </summary>
        /// <returns>The default instance of <see cref="PushServer"/></returns>
        public static PushServer GetDefault()
        {
            if (_defaultInstance == null)
            {
                lock (_defaultInstanceLock)
                {
                    if (_defaultInstance == null)
                    {
                        _defaultInstance = new PushServer();
                    }
                }
            }

            return _defaultInstance;
        }

        public void PushPlayerList(IList<IPlayer> players)
        {
            IList<MutablePlayer> mutablePlayers = new List<MutablePlayer>();

            foreach (var player in players)
            {
                mutablePlayers.Add(player.ToMutablePlayer());
            }

            lock (_clients)
            {
                foreach (var client in _clients.Values)
                {
                    client.UpdatePlayerList(mutablePlayers);
                }
            }
        }
    }
}
