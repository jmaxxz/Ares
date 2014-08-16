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
 */
namespace Ares.Common.Api.DataTypes
{
    using System;

    /// <summary>
    /// This is a mutable representation of a player's score. This class should not be used unless interfacing with a library
    /// that requires mutable object (like .net's built in serialization library, or WCF)
    /// </summary>
    [Serializable]
    public class MutablePlayerScore : IEquatable<MutablePlayerScore>
    {
        /// <summary>
        /// The player to which this score applies
        /// </summary>
        public MutablePlayer PlayerValue { get; set; }

        /// <summary>
        /// The number of kills caused by <see cref="PlayerValue"/>
        /// </summary>
        public uint Kills { get; set; }

        /// <summary>
        /// The number of times <see cref="PlayerValue"/> has died
        /// </summary>
        public uint Deaths { get; set; }

        /// <summary>
        /// The total number of point accumulated by <see cref="PlayerValue"/>
        /// </summary>
        public float Points { get; set; }

        /// <summary>
        /// Indicates whether the current object is equal to another object of the same type.
        /// </summary>
        /// <returns>
        /// <see langword="true"/> if the current object is equal to the <paramref name="other"/> parameter; otherwise, <see langword="false"/>.
        /// </returns>
        /// <param name="other">An object to compare with this object.
        ///                 </param>
        public bool Equals(MutablePlayerScore other)
        {
            if (ReferenceEquals(null, other))
            {
                return false;
            }
            if (ReferenceEquals(this, other))
            {
                return true;
            }
            return other.Points.Equals(Points) && other.Deaths == Deaths && other.Kills == Kills && Equals(other.PlayerValue, PlayerValue);
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
            return Equals(obj as MutablePlayerScore);
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
            unchecked
            {
                int result = Points.GetHashCode();
                result = (result*397) ^ Deaths.GetHashCode();
                result = (result*397) ^ Kills.GetHashCode();
                result = (result*397) ^ (PlayerValue != null ? PlayerValue.GetHashCode() : 0);
                return result;
            }
        }

        /// <summary>
        /// Checks to see if <see cref="left"/> and <see cref="right"/> are equivalent.
        /// </summary>
        /// <param name="left"></param>
        /// <param name="right"></param>
        /// <returns>returns <see langword="true"/> if <see cref="left"/> and <see cref="right"/> are equivalent
        /// else <see langword="false"/> is returned</returns>
        public static bool operator ==(MutablePlayerScore left, MutablePlayerScore right)
        {
            return Equals(left, right);
        }

        /// <summary>
        /// Checks to see if <see cref="left"/> and <see cref="right"/> are equivalent.
        /// </summary>
        /// <param name="left"></param>
        /// <param name="right"></param>
        /// <returns>returns <see langword="true"/> if <see cref="left"/> and <see cref="right"/> are not equivalent
        /// else <see langword="false"/> is returned</returns>
        public static bool operator !=(MutablePlayerScore left, MutablePlayerScore right)
        {
            return !Equals(left, right);
        }
    }
}
