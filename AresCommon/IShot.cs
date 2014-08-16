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
 * 
 * 
 * Change log
 * 
 * Version | Author | Reason for change                | Description of change
 * -------- -------- ---------------------------------- ------------------------------------------------------
 * 1.0      jmaxxz initial development                Defined every method
 * 1.0      jmaxxz Misc Refactoring, Server impl      Refactored codebase, added basic server
 */
namespace Ares.Common
{
    using System;

    public interface IShot
    {
        /// <summary>
        /// Gets a jpeg copy of the shooters webcam output at the time
        /// this shot was fired
        /// </summary>
        byte[] Image { get; }

        /// <summary>
        /// Gets the player who fired this shot
        /// </summary>
        IPlayer Shooter { get; }

        /// <summary>
        /// Gets the targeted player
        /// </summary>
        IPlayer Target { get; }

        /// <summary>
        /// Gets the unique identifier for this shot
        /// </summary>
        Guid Id { get; }
    }
}


