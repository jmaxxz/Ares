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

    public class SignalStrengthTracker : ISignalStrengthTracker
    {

        private readonly ISignalStrengthTrackerProxy _trackerProxy;

        public SignalStrengthTracker(ISignalStrengthTrackerProxy trackerProxy)
        {
            _trackerProxy = trackerProxy;
        }

        /// <summary>
        /// Sets the signal strength of a specified player
        /// </summary>
        /// <param name="signal">the new signal strength</param>
        /// <param name="player">the player for which </param>
        public void SetSignalStrength(MutableSignalStrength signal, MutablePlayer player)
        {
            _trackerProxy.SetSignalStrength(signal.ToSignalStrength(), player.ToIPlayer());
        }
    }
}
