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
 * 0.95     jmaxxz initial development                Fully implemented
 * 0.95     jmaxxz namespace change                   changed namespace
 */
namespace Ares.Common.Network
{
    using System;

    /// <summary>
    /// Represents a wireless network signal strength/quality (on a scale from 0-100)
    /// </summary>
    public class SignalStrength : IEquatable<SignalStrength>
    {
        /// <summary>
        /// A representation of the signal strength/quality as a double (on a scale from 0-100)
        /// </summary>
        public double Value { get; private set; }

        /// <summary>
        /// Creates a new instance to represent a signal strength of <see cref="value"/> where <see cref="value"/>
        /// has a value between 0 and 100
        /// </summary>
        /// <param name="value"></param>
        public SignalStrength(double value)
        {
            if(value < 0.0 )
            {
                throw new ArgumentOutOfRangeException("value", Resource.SignalStrengthLessThanZero);
            }
            if (value > 100.0)
            {
                throw new ArgumentOutOfRangeException("value", Resource.SignalStrengthGreaterThanOneHundred);
            }

            Value = value;
        }

        /// <summary>
        /// Indicates whether the current object is equal to another object of the same type.
        /// </summary>
        /// <returns>
        /// <see langword="true"/> if the current object is equal to the <paramref name="other"/> parameter; otherwise, <see langword="false"/>.
        /// </returns>
        /// <param name="other">An object to compare with this object.
        ///                 </param>
        public bool Equals(SignalStrength other)
        {
            if (ReferenceEquals(null, other))
            {
                return false;
            }
            if (ReferenceEquals(this, other))
            {
                return true;
            }
            return other.Value.Equals(Value);
        }

        /// <summary>
        /// Determines whether the specified <see cref="T:System.Object"/> is equal to the current <see cref="T:System.Object"/>.
        /// </summary>
        /// <returns>
        /// <see langword="true"/> if the specified <see cref="T:System.Object"/> is equal to the current <see cref="T:System.Object"/>; otherwise, <see langword="false"/>.
        /// </returns>
        /// <param name="obj">The <see cref="T:System.Object"/> to compare with the current <see cref="T:System.Object"/>. 
        ///                 </param><filterpriority>2</filterpriority>
        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj))
            {
                return false;
            }
            if (ReferenceEquals(this, obj))
            {
                return true;
            }
            if (obj.GetType() != typeof (SignalStrength))
            {
                return false;
            }
            return Equals((SignalStrength) obj);
        }

        /// <summary>
        /// Serves as a hash function for a particular type. 
        /// </summary>
        /// <returns>
        /// A hash code for the current <see cref="T:System.Object"/>.
        /// </returns>
        /// <filterpriority>2</filterpriority>
        public override int GetHashCode()
        {
            return Value.GetHashCode();
        }

        /// <summary>
        /// Returns <see langword="true"/> if values are equivalent, else <see langword="false"/>
        /// </summary>
        /// <param name="left"></param>
        /// <param name="right"></param>
        /// <returns></returns>
        public static bool operator ==(SignalStrength left, SignalStrength right)
        {
            return Equals(left, right);
        }

        /// <summary>
        /// Returns <see langword="true"/> if values are not equivalent, else <see langword="false"/>
        /// </summary>
        /// <param name="left"></param>
        /// <param name="right"></param>
        /// <returns></returns>
        public static bool operator !=(SignalStrength left, SignalStrength right)
        {
            return !Equals(left, right);
        }

        /// <summary>
        /// Returns <see langword="true"/> if left &gt; right, else <see langword="false"/>
        /// </summary>
        /// <param name="left"></param>
        /// <param name="right"></param>
        /// <returns></returns>
        public static bool operator >(SignalStrength left, SignalStrength right)
        {
            return left.Value < right.Value;
        }

        /// <summary>
        /// Returns <see langword="true"/> if left &lt; right, else <see langword="false"/>
        /// </summary>
        /// <param name="left"></param>
        /// <param name="right"></param>
        /// <returns></returns>
        public static bool operator <(SignalStrength left, SignalStrength right)
        {
            return left.Value < right.Value;
        }

        /// <summary>
        /// Returns <see langword="true"/> if left &lt;= right, else <see langword="false"/>
        /// </summary>
        /// <param name="left"></param>
        /// <param name="right"></param>
        /// <returns></returns>
        public static bool operator <=(SignalStrength left, SignalStrength right)
        {
            return left.Value <= right.Value;
        }

        /// <summary>
        /// Returns <see langword="true"/> if left &gt;= right, else <see langword="false"/>
        /// </summary>
        /// <param name="left"></param>
        /// <param name="right"></param>
        /// <returns></returns>
        public static bool operator >=(SignalStrength left, SignalStrength right)
        {
            return left.Value >= right.Value;
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
            return string.Format("{0}%", Value);
        }
    }
}
