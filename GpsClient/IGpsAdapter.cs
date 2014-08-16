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
 * Change log
 * 
 * Version | Author | Reason for change                | Description of change
 * -------- -------- ---------------------------------- ------------------------------------------------------
 * 0.95     jmaxxz initial development                Initial interface creation
 */
namespace Ares.Client.Gps
{
    /// <summary>
    /// Describes an event driven gps system which updates position and status periodically
    /// </summary>
    public interface IGpsAdapter
    {
        /// <summary>
        /// This event will be fired when gps has a position update
        /// </summary>
        event PositionUpdate PositionEventHandler;
        
        /// <summary>
        /// This event will be fired when gps has a status update
        /// </summary>
        event StatusUpdate StatusEventHandler; 
    }

    /// <summary>
    /// The delegate type definition which will be called when the gps has a status update
    /// </summary>
    /// <param name="sender">The class which caused the event to be fired</param>
    /// <param name="args">Event details</param>
    public delegate void StatusUpdate(object sender, StatusUpdateArgs args);

    /// <summary>
    /// The delegate type definition which will be called when the gps has a position update
    /// </summary>
    /// <param name="sender">The class which caused the event to be fired</param>
    /// <param name="args">Event details</param>
    public delegate void PositionUpdate(object sender, PositionUpdateArgs args);
}
