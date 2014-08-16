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
 * 0.95     jmaxxz initial development                Initial interface creation
 * 0.95     jmaxxz bug 272                            Misc bug fixes 
 * 0.95     jmaxxz should really require disposable   Requires IDisposable to be implemented
 */
namespace Ares.Client.Gps
{
    using System;
    using Common.Position;

    /// <summary>
    /// Describes a class which holds the current position and the status of the gps subsystem
    /// </summary>
    public interface IGps : IDisposable
    {
        /// <summary>
        /// The current position
        /// </summary>
        Position CurrentPosition{ get; }

        /// <summary>
        /// The current status of the gps
        /// </summary>
        GpsStatus Status { get; }
    }
}
