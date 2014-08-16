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
 * 0.95     jmaxxz initial development                Fully implemented every method
 * 0.95     jmaxxz Fixed Bug 271                      Fixed constructors 
 * 0.95     jmaxxz Fixed Bug 279                      ToString
 */
namespace Ares.Common.Position
{
    using System;

    /// <summary>
    /// Represents a geographic latitude
    /// </summary>
    public class Latitude
    {
        /// <summary>
        /// Gets the latitude prior to normalization in a hemisphere. (value is between -90 and 90)
        /// </summary>
        public Angle RawValue { get; private set; }

        /// <summary>
        /// Gets the hemisphere in which this <see cref="Latitude"/> resides
        /// </summary>
        public CardinalDirection Hemisphere
        {
            get 
            {
                return RawValue > 0.0 ? CardinalDirection.North : CardinalDirection.South;
            }
        }

        /// <summary>
        /// Gets the latitude normalized in a hemisphere. (value is between 0 and 90)
        /// </summary>
        public Angle Value
        {
            get
            {
                return new Angle(Math.Abs(RawValue));
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
            string direction = Hemisphere == CardinalDirection.North ? Resource.LatitudeNorth : Resource.LatitudeSouth;
            return string.Format(Resource.LatitudeToString,Value,direction);
        }

        /// <summary>
        /// Creates a new instance from a raw angle. (one which can be positive or negative)
        /// </summary>
        /// <param name="rawValue"></param>
        public Latitude(Angle rawValue)
        {
            if (rawValue == null)
            {
                throw new ArgumentNullException("rawValue");
            }
            if(Math.Abs(rawValue.DecimalDegrees) > 90)
            {
                throw new ArgumentOutOfRangeException("rawValue", Resource.LatitudeOutOfRangeNoHemisphere);
            }


            RawValue = rawValue;
        }

        /// <summary>
        /// Creates a new instance from angle, and direction. The angle must be positive.
        /// </summary>
        /// <param name="value"></param>
        /// <param name="hemisphere">the hemisphere in which this value resides</param>
        public Latitude(Angle value, CardinalDirection hemisphere)
        {
            if (value == null)
            {
                throw new ArgumentNullException("value");
            }
            if (value.DecimalDegrees < 0 || value.DecimalDegrees > 90)
            {
                throw new ArgumentOutOfRangeException("value", Resource.LatitudeOutOfRange);
            }
            if(hemisphere !=  CardinalDirection.North && hemisphere != CardinalDirection.South)
            {
                throw new ArgumentException(Resource.LatitudeInvalidHemisphere,"hemisphere");
            }


            RawValue = hemisphere == CardinalDirection.North ? value : new Angle(-value);
        }

        /// <summary>
        /// compares to instances and returns <see langword="true"/> if the are equivalent
        /// </summary>
        /// <param name="l0"></param>
        /// <param name="l1"></param>
        /// <returns></returns>
        public static bool operator ==(Latitude l0, Latitude l1)
        {
            return l0.Equals(l1);
        }

        /// <summary>
        /// compares to instances and returns <see langword="true"/> if the are not equivalent
        /// </summary>
        /// <param name="l0"></param>
        /// <param name="l1"></param>
        /// <returns></returns>
        public static bool operator !=(Latitude l0, Latitude l1)
        {
            return !(l0 == l1);
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
            return Equals(obj as Latitude);
        }

        /// <summary>
        /// Compare this to another instance of <see cref="Latitude"/>
        /// </summary>
        /// <param name="other">The other instance of <see cref="Latitude"/></param>
        /// <returns>If they are equivalent then <see langword="true"/> is return else <see langword="false"/></returns>
        public bool Equals(Latitude other)
        {
            if (ReferenceEquals(null, other))
            {
                return false;
            }
            if (ReferenceEquals(this, other))
            {
                return true;
            }
            return Equals(other.RawValue, RawValue);
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
            return (RawValue != null ? RawValue.GetHashCode() : 0);
        }
    }
}
