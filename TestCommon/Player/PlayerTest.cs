/*
 *  Ares, a multi-player augmented reality first person shooter
 *  Copyright (C) 2009-2010  Jmaxxz, Mike McBride, and Kevin Curtis
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
 */
 using NUnit.Framework;

namespace Ares.Common.Test.Player
{
    public class PlayerTest
    {
        private readonly IPlayer _player;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="player">An instance of <see cref="IPlayer"/> to be tested</param>
        public PlayerTest(IPlayer player)
        {
            _player = player;
        }


        public void TestImmutability()
        {
            Assert.False(ReferenceEquals(_player.ChangeHealth(_player.Health + 1),_player));
        }
    }
}
