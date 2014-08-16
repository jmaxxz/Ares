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
 * File: Angle.cs
 * Purpose: Provides an angle class, that is able to be read in Degrees, Minutes, Seconds, 
 *          or as a decimal equivalent.
 * 
 * 
 * Change log
 * 
 * Version | Author | Reason for change                | Description of change
 * -------- -------- ---------------------------------- ------------------------------------------------------
 * 0.95     jmaxxz initial development                Fully implemented every method
 * 0.95     jmaxxz initial development                Removed limit on angle size, and added more operators
 * 1.0      jmaxxz Distance calculation needed        Added support for converting an angle to radians
 */
namespace Ares.Common.Position
{
    using System.Text;
    using System;

    /// <summary>
    /// Represents an angle
    /// </summary>
    public class Angle
    {
        /// <summary>
        /// Gets the number of degrees in this <see cref="Angle"/>
        /// (Degrees, Minutes, Seconds)
        /// </summary>
        public short Degrees
        {
            get { return (short) DecimalDegrees; }
        }

        /// <summary>
        /// Gets the number of minutes in this <see cref="Angle"/>
        /// (Degrees, Minutes, Seconds)
        /// </summary>
        public short Minutes
        {
            get { return (short) DecimalMinutes; }
        }

        /// <summary>
        /// Gets the number of minutes in this <see cref="Angle"/> as a decimal value
        /// (Degrees, Minutes)
        /// </summary>
        public double DecimalMinutes
        {
            get { return (60.0 * (DecimalDegrees - Degrees)); }
        }


        /// <summary>
        /// Gets the number of seconds in this <see cref="Angle"/>
        /// (Degrees, Minutes, Seconds)
        /// </summary>
        public double Seconds
        {
            get { return (60.0*(DecimalMinutes - Minutes)); }
        }

        /// <summary>
        /// Gets the decimal representation of this this <see cref="Angle"/> in degrees
        /// </summary>
        public double DecimalDegrees { get; private set; }

        /// <summary>
        /// Creates a new angle of degree <see cref="degrees"/>
        /// </summary>
        /// <param name="degrees">The number of degrees the angle being created should have</param>
        public Angle(double degrees)
        {
            DecimalDegrees = degrees;
        }

        /// <summary>
        /// Creates a new angle from a specified Degree, Minutes, and Seconds value
        /// </summary>
        /// <param name="degrees">The number of degrees in the angle</param>
        /// <param name="minutes">The number of minutes in the angle</param>
        /// <param name="seconds">The number of seconds in the angle</param>
        public Angle(short degrees, short minutes, double seconds) : this(ToDecimalDegree(degrees, minutes, seconds))
        {
        }


        /// <summary>
        /// Converts from Degrees, Minute, Seconds to a decimal value.
        /// </summary>
        /// <param name="degrees">The number of degrees in the angle</param>
        /// <param name="minutes">The number of minutes in the angle</param>
        /// <param name="second">The number of seconds in the angle</param>
        /// <returns></returns>
        private static double ToDecimalDegree(short degrees, short minutes, double second)
        {
            double totalSeconds = minutes*60.0 + second;
            return degrees + totalSeconds/3600.0;
        }

        /// <summary>
        /// Returns a radian representation of this angle
        /// </summary>
        /// <returns>The radian representation of this angle</returns>
        public double ToRadians()
        {
            const double conversionConstant = Math.PI/180.0;
            return DecimalDegrees*conversionConstant;
        }


        /// <summary>
        /// Allows <see cref="Angle"/>s to be cast directly to type <see cref="double"/>
        /// so as to allow for use with the <see cref="Math"/> class
        /// </summary>
        /// <param name="angle">The angle being cast</param>
        /// <returns>A <see cref="double"/> representation of <see cref="angle"/> (in degrees)</returns>
       public static implicit operator double(Angle angle)
       {
           return angle.DecimalDegrees;
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
           StringBuilder stringBuilder = new StringBuilder(25);
           stringBuilder.AppendFormat(Resource.AngleDegrees, Degrees);

           if (Minutes != 0 || Seconds != 0.0)
           {
               stringBuilder.AppendFormat(Resource.AngleMinutes, Minutes);
           }
           if (Seconds != 0.0)
           {
               stringBuilder.AppendFormat(Resource.AngleSeconds, Seconds);
           }

           return stringBuilder.ToString();
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
            return Equals(obj as Angle);
        }

        /// <summary>
        /// Compare this to another instance of <see cref="Angle"/>
        /// </summary>
        /// <param name="other">The other instance of <see cref="Angle"/></param>
        /// <returns>If they are equivalent then <see langword="true"/> is return else <see langword="false"/></returns>
        public bool Equals(Angle other)
        {
            if (ReferenceEquals(null, other))
            {
                return false;
            }
            if (ReferenceEquals(this, other))
            {
                return true;
            }
            return other.DecimalDegrees.Equals(DecimalDegrees);
        }

        /// <summary>
        /// Returns <see langword="true"/> if <see cref="angle0"/> is equivalent to <see cref="angle1"/> else <see langword="false"/>
        /// </summary>
        /// <param name="angle0"></param>
        /// <param name="angle1"></param>
        /// <returns></returns>
        public static bool operator ==(Angle angle0, Angle angle1)
        {
            return angle0.Equals(angle1);
        }

        /// <summary>
        /// Returns <see langword="false"/> if <see cref="angle0"/> is equivalent to <see cref="angle1"/> else <see langword="true"/>
        /// </summary>
        /// <param name="angle0"></param>
        /// <param name="angle1"></param>
        /// <returns></returns>
        public static bool operator !=(Angle angle0, Angle angle1)
        {
            return !(angle0 == angle1);
        }

        /// <summary>
        /// Allows <see cref="Angle"/>s to be compared using &gt;
        /// </summary>
        /// <param name="angle0"></param>
        /// <param name="angle1"></param>
        /// <returns></returns>
        public static bool operator >(Angle angle0, Angle angle1)
        {
            return angle0.DecimalDegrees > angle1.DecimalDegrees;
        }

        /// <summary>
        /// Allows <see cref="Angle"/>s to be compared using &lt;
        /// </summary>
        /// <param name="angle0"></param>
        /// <param name="angle1"></param>
        /// <returns></returns>
        public static bool operator <(Angle angle0, Angle angle1)
        {
            return angle0.DecimalDegrees < angle1.DecimalDegrees;
        }

        /// <summary>
        /// Allows <see cref="Angle"/>s to be compared using &gt;=
        /// </summary>
        /// <param name="angle0"></param>
        /// <param name="angle1"></param>
        /// <returns></returns>
        public static bool operator >=(Angle angle0, Angle angle1)
        {
            return angle0.DecimalDegrees > angle1.DecimalDegrees || angle0 == angle1;
        }

        /// <summary>
        /// Allows <see cref="Angle"/>s to be compared using &lt;=
        /// </summary>
        /// <param name="angle0"></param>
        /// <param name="angle1"></param>
        /// <returns></returns>
        public static bool operator <=(Angle angle0, Angle angle1)
        {
            return angle0.DecimalDegrees < angle1.DecimalDegrees || angle0 == angle1;
        }

        /// <summary>
        /// Allows <see cref="Angle"/>s to be negated
        /// </summary>
        /// <param name="angle"></param>
        /// <returns>A new <see cref="Angle"/> which is the additive inverse of <see cref="angle"/></returns>
        public static Angle operator -(Angle angle)
        {
            return new Angle(-angle.DecimalDegrees);
        }

        /// <summary>
        /// Returns the sum of two <see cref="Angle"/>s
        /// </summary>
        /// <param name="angle0"></param>
        /// <param name="angle1"></param>
        /// <returns></returns>
        public static Angle operator +(Angle angle0, Angle angle1)
        {
            return new Angle(angle0.DecimalDegrees+angle1.DecimalDegrees);
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
            return DecimalDegrees.GetHashCode();
        }
    }
}