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
 * 0.95     jmaxxz initial development                Prevented invalid value in properties
 */
namespace Ares.Common.Api.DataTypes
{
    using Position;
    using System;

    /// <summary>
    /// This is a mutable representation of a position. This class should not be used unless interfacing with a library
    /// that requires mutable object (like .net's built in serialization library, or WCF)
    /// </summary>
    [Serializable]
    public class MutablePosition : IEquatable<MutablePosition>
    {
        private double _longitude;
        /// <summary>
        /// Gets and sets the longitude of the geographic coordinate this instance represents
        /// </summary>
        public double Longitude
        {
            get
            {
                return _longitude;
            }
            set
            {
                if (Math.Abs(value) > 180)
                {
                    throw new ArgumentOutOfRangeException("value", Resource.InvalidLongitude);
                }
                _longitude = value;
            }
        }

        private double _latitude;
        /// <summary>
        /// Gets and sets the latitude of the geographic coordinate this instance represents
        /// </summary>
        public double Latitude
        {
            get
            {
                return _latitude;
            }
            set
            {
                if(Math.Abs(value) > 90)
                {
                    throw new ArgumentOutOfRangeException("value", Resource.InvalidLatitude);
                }
                _latitude = value;
            }
        }
        
        /// <summary>
        /// Creates a new instance with default values for all properties
        /// </summary>
        public MutablePosition()
        {
        }

        /// <summary>
        /// Creates a new instance from an instance of <see cref="Position"/>
        /// </summary>
        /// <param name="position"></param>
        public MutablePosition(Position position)
        {
            Longitude = position.Longitude.RawValue;
            Latitude = position.Latitude.RawValue;
        }


        /// <summary>
        /// Creates an instance of <see cref="Position"/> from the current state of this instance
        /// </summary>
        /// <returns></returns>
        public Position ToPosition()
        {
            return new Position(new Longitude(new Angle(Longitude)), new Latitude(new Angle(Latitude)));
        }



        /// <summary>
        /// Indicates whether the current object is equal to another object of the same type.
        /// </summary>
        /// <returns>
        /// <see langword="true"/> if the current object is equal to the <paramref name="other"/> parameter; otherwise, <see langword="false"/>.
        /// </returns>
        /// <param name="other">An object to compare with this object.
        ///                 </param>
        public bool Equals(MutablePosition other)
        {
            if (ReferenceEquals(null, other))
            {
                return false;
            }
            if (ReferenceEquals(this, other))
            {
                return true;
            }
            return other.Latitude.Equals(Latitude) && other.Longitude.Equals(Longitude);
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
            return Equals(obj as MutablePosition);
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
                return (Latitude.GetHashCode() * 397) ^ Longitude.GetHashCode();
            }
        }

        /// <summary>
        /// Checks to see if <see cref="left"/> and <see cref="right"/> are equivalent.
        /// </summary>
        /// <param name="left"></param>
        /// <param name="right"></param>
        /// <returns>returns <see langword="true"/> if <see cref="left"/> and <see cref="right"/> are equivalent
        /// else <see langword="false"/> is returned</returns>
        public static bool operator ==(MutablePosition left, MutablePosition right)
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
        public static bool operator !=(MutablePosition left, MutablePosition right)
        {
            return !Equals(left, right);
        }
    }
}
