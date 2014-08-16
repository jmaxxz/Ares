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
 * 1.0      jmaxxz initial development                Implemented every method
 * 1.0      jmaxxz Misc Refactoring, Server impl      Refactored codebase, added basic server
 */
namespace Ares.Common
{
    using System;

    public class Shot: IShot
    {
        /// <summary>
        /// Gets the player who fired this shot
        /// </summary>
        public IPlayer Shooter { get; private set; }

        /// <summary>
        /// Gets the targeted player
        /// </summary>
        public IPlayer Target { get; private set; }

        /// <summary>
        /// Gets the unique identifier for this shot
        /// </summary>
        public Guid Id {get; private set;}

        /// <summary>
        /// Gets a jpeg copy of the shooters webcam output at the time
        /// this shot was fired
        /// </summary>
        public byte[] Image { get; private set; }

        /// <summary>
        /// Instantiates a new object representing a shot fired by <see cref="shooter"/>
        /// at <see cref="target"/>.
        /// </summary>
        /// <param name="shooter">The player who fired the shot</param>
        /// <param name="target">The player who is being shot at</param>
        public Shot(IPlayer shooter, IPlayer target)
            : this(shooter, target, Guid.NewGuid())
        {
        }


        /// <summary>
        /// Instantiates a new object representing a shot fired by <see cref="shooter"/>
        /// at <see cref="target"/>.
        /// </summary>
        /// <param name="shooter">The player who fired the shot</param>
        /// <param name="target">The player who is being shot at</param>
        /// <param name="id">A unique id identifying this shot</param>
        public Shot(IPlayer shooter, IPlayer target, Guid id) : this(shooter, target, id, null)
        {
        }


        /// <summary>
        /// Instantiates a new object representing a shot fired by <see cref="shooter"/>
        /// at <see cref="target"/>.
        /// </summary>
        /// <param name="shooter">The player who fired the shot</param>
        /// <param name="target">The player who is being shot at</param>
        /// <param name="id">A unique id identifying this shot</param>
        /// <param name="image">An optional jpeg snap shot of the <see cref="shooter"/>'s video feed at the time the shot was fired</param>
        public Shot(IPlayer shooter, IPlayer target, Guid id, byte[] image)
        {
            Shooter = shooter;
            Target = target;
            Id = id;
            Image = image;
        }
    }
}


