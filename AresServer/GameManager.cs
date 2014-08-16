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
 * 1.0      jmaxxz Initial development                Initial implementation
 */
using System;
using System.Collections.Generic;
using Ares.Common;
using Ares.Common.Api.DataTypes;
using Ares.Common.Api.Server;

namespace Ares.Server
{
    public class GameManager : IGameManager
    {
        private readonly IGameManagerProxy _gameManagerProxy;

        public GameManager(IGameManagerProxy gameManagerProxy)
        {
            _gameManagerProxy = gameManagerProxy;
        }

        public TimeSpan GetTimeLeftInGame()
        {
            return _gameManagerProxy.GetTimeLeftInGame();
        }

        public IList<MutablePlayer> GetRankings()
        {
            IList<IPlayer> rankings = _gameManagerProxy.GetRankings();
            IList<MutablePlayer> results = new List<MutablePlayer>();

            foreach (IPlayer player in rankings)
            {
                results.Add(player.ToMutablePlayer());
            }

            return results;
        }

        public void SetGameLength(TimeSpan length)
        {
            _gameManagerProxy.SetGameLength(length);
        }

        public void StartGame()
        {
            _gameManagerProxy.StartGame();
        }

        public void StopGame()
        {
            _gameManagerProxy.StopGame();
        }
    }
}
