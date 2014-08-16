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
 * 1.0      jmaxxz initial development                Fully implemented every method
 */
namespace Ares.Server
{
    using Common.Api.DataTypes;
    using Common.Api.Server;

    public class ShotTracker : IShotTracker
    {
        private readonly IShotTrackerProxy _shotTrackerProxy;

        public ShotTracker(IShotTrackerProxy shotTrackerProxy)
        {
            _shotTrackerProxy = shotTrackerProxy;
        }

        /// <summary>
        /// Notifies server that a shot was fired
        /// </summary>
        /// <param name="shot">the shot that was fired</param>
        /// <returns>returns <see langword="true"/> of shot was a hit, and <see langword="false"/> if shot was a miss</returns>
        public bool FireShot(MutableShot shot)
        {
            return _shotTrackerProxy.FireShot(shot.ToShot());
        }
    }
}
