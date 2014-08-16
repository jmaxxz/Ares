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
using System;
using Ares.Common.Api.DataTypes;
using System.Collections.Generic;

namespace Ares.Common.Api.Server
{
    public class GameManagerProxy : IGameManagerProxy
    {
        private readonly IGameManager _gameManager;

        public GameManagerProxy(IGameManager gameManager)
        {
            _gameManager = gameManager;
        }

        public TimeSpan GetTimeLeftInGame()
        {
            return _gameManager.GetTimeLeftInGame();
        }

        public IList<IPlayer> GetRankings()
        {
            IList<MutablePlayer> rankings = _gameManager.GetRankings();
            IList<IPlayer> results = new List<IPlayer>();

            foreach (MutablePlayer mutablePlayer in rankings)
            {
                results.Add(mutablePlayer.ToIPlayer());
            }

            return results;
        }

        public void SetGameLength(TimeSpan length)
        {
            _gameManager.SetGameLength(length);
        }

        public void StartGame()
        {
            _gameManager.StartGame();
        }

        public void StopGame()
        {
            _gameManager.StopGame();
        }
    }
}
