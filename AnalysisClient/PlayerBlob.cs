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
 * 0.95     mcbridem Initial development                Fully defined every method
 * 1.0      jmaxxz Misc Refactoring, Server impl      Refactored codebase, added basic server
 */
namespace Ares.Client.Analysis
{
    using Common;

    /// <summary>
    /// An implementation of <see cref="IPlayerBlob"/>.
    /// </summary>
    public class PlayerBlob :IPlayerBlob
    {
        /// <summary>
        /// Default constructor.
        /// </summary>
        /// <param name="baseBlob">The base <see cref="IBlob"/> object.</param>
        /// <param name="player">The base <see cref="IPlayer"/> object.</param>
        public PlayerBlob(IBlob baseBlob, IPlayer player)
        {
            BaseBlob = baseBlob;
            Player = player;
        }

        /// <summary>
        /// The blob found in the image.
        /// </summary>
        public IBlob BaseBlob { get; private set; }

        /// <summary>
        /// The player this blob represents.
        /// </summary>
        public IPlayer Player { get; private set; }
    }
}
