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
 * 
 * Change log
 * 
 * Version | Author | Reason for change                | Description of change
 * -------- -------- ---------------------------------- ------------------------------------------------------
 * 0.95     jmaxxz initial development                Fully implemented
 * 1.0      jmaxxz Added support for collections      Collections can not be reflected
 */
using System.Collections;

namespace Ares.Common.ReflectUI
{
    using System.Reflection;
    using System.Text;
    using System;

    /// <summary>
    /// Provides general reflection based tools
    /// </summary>
    public static class ReflectTools
    {
        /// <summary>
        /// Returns a string representation of an object hierarchy
        /// </summary>
        /// <param name="obj">The object to be reflected</param>
        /// <param name="name">The name of the object being reflected</param>
        /// <returns>a string representation of <see cref="obj"/></returns>
        public static string ReflectToString(object obj, string name)
        {
            return ReflectToString(obj, name, 0);
        }

        /// <summary>
        /// Returns a string representation of an object hierarchy
        /// </summary>
        /// <param name="obj">The object to be reflected</param>
        /// <param name="name">The name of the object being reflected</param>
        /// <param name="level">The depth of the <see cref="obj"/> in the object tree</param>
        /// <returns>a string representation of <see cref="obj"/></returns>
        private static string ReflectToString(object obj, string name, uint level)
        {
            //if object is null return early
            if (obj == null)
            {
                return name + ": null";
            }
            
            StringBuilder output = new StringBuilder();
            output.Append(name + ": " + obj);

            //if object is primative return early
            Type type = obj.GetType();
            if (type.IsPrimitiveLike())
            {
                return output.ToString();
            }


            //Builds up padding
            string prefex = "";
            for (uint i = 0; i <= level; i++)
            {
                prefex = prefex +  "   | ";
            }


            IEnumerable enumerable = obj as IEnumerable;

            if (enumerable != null)
            {
                int i = 0;
                foreach (var v in enumerable)
                {
                    ReflectedProperty childProperty = new ReflectedProperty(i.ToString(), v);
                    output.Append("\r\n" + prefex + ReflectToString(childProperty.Value, childProperty.Name, level + 1));
                    i++;
                }
            }


            //Handles complex case and builds a string representation of all child objects
            PropertyInfo[] properties = obj.GetType().GetProperties();
            foreach (PropertyInfo propertyInfo in properties)
            {
                ReflectedProperty property = new ReflectedProperty(propertyInfo, obj);
                output.Append("\r\n"+prefex + ReflectToString(property.Value, property.Name, level + 1));
            }

            return output.ToString();
        }
    }
}
