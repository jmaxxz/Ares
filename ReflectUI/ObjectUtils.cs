/*
 *  Ares, a multi-player augmented reality first person shooter
 *  Copyright (C) 2009  Jmaxxz, Mike McBride, and Kevin Curtis
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
 * File: ObjectUtils.cs
 * Purpose: Contains helper methods for use in the reflection of objects
 * 
 * 
 * Change log
 * 
 * Version | Author | Reason for change                | Description of change
 * -------- -------- ---------------------------------- ------------------------------------------------------
 * 0.95     jmaxxz initial development                Fully implemented
 */
namespace Ares.Common.ReflectUI
{
    using System;

    /// <summary>
    /// Provides helper methods for reflecting objects.
    /// </summary>
    public static class ObjectUtils
    {
        /// <summary>
        /// Returns the result of ToString(), if <see cref="obj"/> is <see langword="null"/> then <see langword="null"/> is returned.
        /// 
        /// This methods removed the need for an if <c>obj == null</c> check before calling to string.
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public static string SafeToString(this object obj)
        {
            return obj == null ? null : obj.ToString();
        }

        /// <summary>
        /// Returns the result of GetType(), if <see cref="obj"/> is <see langword="null"/> object is returned.
        /// This methods removed the need for an if <c>obj == null</c> check before calling GetType.
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public static Type SafeGetType(this object obj)
        {
            return obj == null ? typeof(object) : obj.GetType();
        }

        /// <summary>
        /// Return <see langword="true"/> if passed in <see cref="Type"/> is primitive like (primitives, strings, etc)
        /// </summary>
        /// <param name="type">The <see cref="Type"/> to be checked</param>
        /// <returns><see langword="true"/> of value is primitive like.</returns>
        public static bool IsPrimitiveLike(this Type type)
        {
            return type.IsPrimitive || type.Equals(typeof(string));
        }
    }
}
