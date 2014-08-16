/*
 *  Ares, a multi-player augmented reality first person shooter
 *  Copyright (C) 2009  Jmaxxz, Mike McBride, and Kevin Curtis
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
 * File: StatusUpdateArgs.cs
 * Purpose: Holds event details relating to a gps status update
 * 
 * 
 * Change log
 * 
 * Version | Author | Reason for change                | Description of change
 * -------- -------- ---------------------------------- ------------------------------------------------------
 * 0.95     jmaxxz initial development                Fully implemented
 */
namespace Ares.Client.Gps
{
    /// <summary>
    /// Holds event details relating to a gps status update
    /// </summary>
    public class StatusUpdateArgs
    {
        /// <summary>
        /// The new <see cref="GpsStatus"/>
        /// </summary>
        public GpsStatus Status { get; private set; }


        /// <summary>
        /// Creates a new instance of <see cref="StatusUpdateArgs"/>
        /// </summary>
        /// <param name="status">The new <see cref="GpsStatus"/></param>
        public StatusUpdateArgs(GpsStatus status)
        {
            Status = status;
        }
    }
}
