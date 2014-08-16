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
 * 0.95     jmaxxz Bug 269                            fixed equals method
 * 1.0      jmaxxz Distance calculation needed        Added support for calculating the distance between two positions
 * 1.0      jmaxxz Fixed bug                          Added support for using == where left or right value was null
 **/
namespace Ares.Common.Position
{
    using System;

    /// <summary>
    /// Represents a geographic coordinate
    /// </summary>
    public class Position
    {
        /// <summary>
        /// The longitude of the geographic coordinate this instance represents
        /// </summary>
        public Longitude Longitude { get; private set; }

        /// <summary>
        /// The latitude of the geographic coordinate this instance represents
        /// </summary>
        public Latitude Latitude { get; private set; }


        /// <summary>
        /// Creates a new instance from a specified <see cref="Latitude"/> and <see cref="Longitude"/>
        /// </summary>
        /// <param name="longitude"></param>
        /// <param name="latitude"></param>
        public Position(Longitude longitude,Latitude latitude)
        {
            if (longitude == null)
            {
                throw new ArgumentNullException("longitude");
            }
            if (latitude == null)
            {
                throw new ArgumentNullException("latitude");
            }

            Longitude = longitude;
            Latitude = latitude;
        }

        /// <summary>
        /// Returns the distance between this position and <see cref="position"/> in meters
        /// </summary>
        /// <param name="position"></param>
        /// <returns></returns>
        public double DistanceFrom(Position position)
        {
            double lat1 = Latitude.RawValue.ToRadians();
            double long1 = Longitude.RawValue.ToRadians();

            double lat2 = position.Latitude.RawValue.ToRadians();
            double long2 = position.Longitude.RawValue.ToRadians();

            double longitudeDistance = long1 - long2;
            double latitudeDistance = lat1 - lat2;


            double a = Math.Pow(Math.Sin(latitudeDistance / 2.0), 2.0) +
                   Math.Cos(lat1) * Math.Cos(lat2) *
                   Math.Pow(Math.Sin(longitudeDistance / 2.0), 2.0);

            double c = 2.0*Math.Atan2(Math.Sqrt(a), Math.Sqrt(1.0 - a));

            const double radiusOfEarth = 6371009;

            return radiusOfEarth*c;

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
            return Equals(obj as Position);
        }

        /// <summary>
        /// Returns <see langword="true"/> if <see cref="p0"/> and <see cref="p1"/> are equivalent
        /// </summary>
        /// <param name="p0"></param>
        /// <param name="p1"></param>
        /// <returns></returns>
        public static bool operator ==(Position p0, Position p1)
        {
            if (ReferenceEquals(p0,p1))
            {
                return true;
            }
            if(p0 == null || p1 == null)
            {
                return false;
            }

            return p0.Equals(p1);
        }

        /// <summary>
        /// Returns <see langword="true"/> if <see cref="p0"/> and <see cref="p1"/> are not equivalent
        /// </summary>
        /// <param name="p0"></param>
        /// <param name="p1"></param>
        /// <returns></returns>
        public static bool operator !=(Position p0, Position p1)
        {
            return !(p0 == p1);
        }

        /// <summary>
        /// Returns <see langword="true"/> if current instance is equivalent to <see cref="other"/>, else <see langword="false"/>
        /// </summary>
        /// <param name="other"></param>
        /// <returns></returns>
        public bool Equals(Position other)
        {
            if (ReferenceEquals(null, other))
            {
                return false;
            }
            if (ReferenceEquals(this, other))
            {
                return true;
            }
            return Equals(other.Longitude, Longitude) && Equals(other.Latitude, Latitude);
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
                return (Longitude.GetHashCode()*397) ^ Latitude.GetHashCode();
            }
        }
    }
}
