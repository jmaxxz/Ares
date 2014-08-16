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
 * File: IWirelessStrengthMonitor.cs
 * Purpose: Describes a class which monitors the strenght/quality of a wireless connection
 * 
 * 
 * Change log
 * 
 * Version | Author | Reason for change                | Description of change
 * -------- -------- ---------------------------------- ------------------------------------------------------
 * 0.95     jmaxxz initial development                Fully implemented
 * 0.95     jmaxxz should really require disposable   Requires IDisposable to be implemented
 */
namespace Ares.Common.Network
{
    using System;


    /// <summary>
    /// Describes a class which monitors the strength/quality of a wireless connection.
    /// </summary>
    public interface IWirelessStrengthMonitor: IDisposable
    {
        /// <summary>
        /// The current strength of the active wireless connection.
        /// </summary>
        SignalStrength Strength { get;}
    }
}
