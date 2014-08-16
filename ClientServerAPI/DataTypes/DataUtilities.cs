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
 * 0.95     jmaxxz initial development                Fully implemented every method
 * 1.0      jmaxxz Misc Refactoring, Server impl      Refactored codebase, added basic server
 */
namespace Ares.Common.Api.DataTypes
{
    using Position;
    using Network;

    /// <summary>
    /// Contains Utility methods to assist in conversion of data from
    /// types used throughout Ares to types that can be used with the
    /// client server api
    /// </summary>
    public static class DataUtilities
    {
        /// <summary>
        /// Converts an instance <see cref="IPlayer"/> to an instance of <see cref="MutablePlayer"/>
        /// if <see cref="player"/> is <see langword="null"/> then <see langword="null"/> will be returned
        /// </summary>
        /// <param name="player"></param>
        /// <returns></returns>
        public static MutablePlayer ToMutablePlayer(this IPlayer player)
        {
            return player == null ? null : new MutablePlayer(player);
        }

        /// <summary>
        /// Converts an instance <see cref="Position"/> to an instance of <see cref="MutablePosition"/>
        /// if <see cref="position"/> is <see langword="null"/> then <see langword="null"/> will be returned
        /// </summary>
        /// <param name="position"></param>
        /// <returns></returns>
        public static MutablePosition ToMutablePosition(this Position position)
        {
            return position == null ? null : new MutablePosition(position);
        }

        /// <summary>
        /// Converts an instance <see cref="Position"/> to an instance of <see cref="MutableSignalStrength"/>
        /// if <see cref="signal"/> is <see langword="null"/> then <see langword="null"/> will be returned
        /// </summary>
        /// <param name="signal"></param>
        /// <returns></returns>
        public static MutableSignalStrength ToMutableSignalStrength(this SignalStrength signal)
        {
            return signal == null ? null : new MutableSignalStrength(signal);
        }
    }
}
