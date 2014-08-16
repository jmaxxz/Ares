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
 * 1.0      jmaxxz Misc Refactoring, Server impl      Refactored codebase, added basic server
 * 1.0      jmaxxz Misc Refactoring, Server impl      Refactored codebase, added basic server
 */
namespace Ares.Common
{ 
    using System;

    /// <summary>
    /// Represents a percentage between 0 and 100.
    /// </summary>
    public class Percentage
    {
        /// <summary>
        /// The backing value of this percentage, ranging from 0-100.
        /// </summary>
        public double Value { get; private set; }

        /// <summary>
        /// Creates a new percentage from a double ranging between 0 and 100.
        /// Throws a <see cref="ArgumentOutOfRangeException"/> if <see cref="value"/>
        /// is outside of this range.
        /// </summary>
        /// <param name="value">A value between 0-100</param>
        public Percentage(double value)
        {
            if(value < 0)
            {
                throw new ArgumentOutOfRangeException("value",Resource.PercentageTooLow);
            }
            if(value >100)
            {
                throw new ArgumentOutOfRangeException("value", Resource.PercentageTooHigh);
            }
        }


        /// <summary>
        /// Returns a <see cref="T:System.String"/> that represents the current <see cref="T:System.Object"/>.
        /// </summary>
        /// <returns>
        /// A <see cref="T:System.String"/> that represents the current <see cref="T:System.Object"/>.
        /// </returns>
        /// <filterpriority>2</filterpriority>
        public override string ToString()
        {
            return string.Format(Resource.PercentageToStringFormat, Value);
        }
    }
}
