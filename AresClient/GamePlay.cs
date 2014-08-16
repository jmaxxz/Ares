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
using System.Linq;
using System.Text;
using Ares.Client.Analysis;
using Ares.Common;
using Ares.Common.Video;
using System.Drawing;
using Ares.Common.Api.Server;

namespace Ares.Client
{
    class GamePlay
    {
        private IGameManager _gameManager = null;
        private IShotTrackerProxy _shotTracker;
        private IPlayer _player;

        public GamePlay() { }

        public GamePlay(IPlayer player)
        {
            _player = player;
        }

        public IPlayer Fire_Shot(IList<IPlayerBlob> blobs, Frame videoOut)
        {
            IList<IPlayerBlob> currentList = blobs;
            IPlayer _target = null;
            if (currentList != null)
            {
                foreach (IPlayerBlob playerBlob in currentList)
                {
                    // see if the width encompases the middle
                    // see if the height encompases the middle
                    // if both true, use blob as the player being shot at
                    if ((playerBlob.BaseBlob.Position.X < (videoOut.Image.Size.Width / 2)) &&
                        ((playerBlob.BaseBlob.Position.X + playerBlob.BaseBlob.Dimension.Width) >
                         (videoOut.Image.Size.Width / 2)) &&
                        ((playerBlob.BaseBlob.Position.Y < (videoOut.Image.Size.Width / 2))) &&
                        ((playerBlob.BaseBlob.Position.Y + playerBlob.BaseBlob.Dimension.Height) >
                         (videoOut.Image.Size.Width / 2)))
                    {
                        _target = playerBlob.Player; 
                        //_shotTracker.FireShot(new Shot(_player, _target ));
                        break;
                    }
                }
            }

            return _target;
        }

        public TimeSpan getGameTime()
        {
            return _gameManager.GetTimeLeftInGame();
        }

    }
}
