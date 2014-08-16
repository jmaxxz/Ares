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
 * 1.0      jmaxxz initial development                Fully implemented every method
 * 1.0      jmaxxz Misc Refactoring, Server impl      Refactored codebase, added basic server
 */
namespace Ares.Common.Api.Server
{

    public interface IShotTrackerProxy
    {
        /// <summary>
        /// Register a shot fired with the game server
        /// </summary>
        /// <param name="shot">The shot being fired</param>
        /// <returns>True is returned if the shot is a hit, False if the shot does not miss</returns>
        bool FireShot(Shot shot);
    }
}
