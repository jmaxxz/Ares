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
 * File: ReflectedProperty.cs
 * Purpose: Represents a property of an object
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
    using System.Reflection;
    using System;

    /// <summary>
    /// Represents a property of an object
    /// </summary>
    public class ReflectedProperty
    {
        /// <summary>
        /// The name of this property
        /// </summary>
        public string Name { get; private set; }

        /// <summary>
        /// The value of this property as a string
        /// </summary>
        public string ValueAsString { get; private set; }

        /// <summary>
        /// The value of this property
        /// </summary>
        public object Value { get; private set; }

        /// <summary>
        /// Indicates whether an exception was thrown while trying to get the value of
        /// this property.
        /// </summary>
        public bool ThrewAnException { get; private set; }
        
        /// <summary>
        /// The <see cref="Type"/> this property holds
        /// </summary>
        public Type ValueTypeOf { get; private set; }

        /// <summary>
        /// Constructs a new instance from a specified <see cref="PropertyInfo"/> used to indicate which property 
        /// of <see cref="backingObject"/> the new instance of this class will describe.
        /// </summary>
        /// <param name="propertyInfo">Indicates which property this instance will describe</param>
        /// <param name="backingObject">The instance in which this property resides</param>
        public ReflectedProperty(PropertyInfo propertyInfo, object backingObject)
        {
            ValueTypeOf = typeof(object);
            Name = propertyInfo.Name;
            
            //Handle cases where getting value (or value.ToString()) throws and exception
            try
            {
                Value = propertyInfo.GetValue(backingObject, null);
                ValueAsString = Value.SafeToString();
                ValueTypeOf = Value.GetType();
            }
            catch (Exception e)
            {
                ThrewAnException = true;
                Value = e;
                ValueAsString = e.ToString();
            }
        }

        /// <summary>
        /// Initializes a new instance using passed in values for all publicly visible properties.
        /// </summary>
        /// <param name="name">The name of the property</param>
        /// <param name="valueTypeOf">The <see cref="Type"/> of the property</param>
        /// <param name="value">The value of the property</param>
        /// <param name="valueAsString">The value of the property as a string</param>
        /// <param name="threwAnException">If while getting the value an exception was thrown. If <see langword="true"/> value must be of type <see cref="Exception"/></param>
        public ReflectedProperty( string name, Type valueTypeOf, object value, string valueAsString, bool threwAnException)
        {
            if(threwAnException && value.GetType() != typeof(Exception))
            {
                throw new ArgumentException("Exception was allegedly thrown while value was being gotten, yet value is not of type exception.", "value");
            }

            Name = name;
            ValueTypeOf = valueTypeOf;
            Value = value;
            ValueAsString = valueAsString;
            ThrewAnException = threwAnException;
        }

        /// <summary>
        /// Constructs a new instance from a name and a object
        /// </summary>
        /// <param name="name">The name to be given to the new instance</param>
        /// <param name="value">An object describing the value of the new instance</param>
        public ReflectedProperty(string name, object value)
        {
            Name = name;
            Value = value;

            try
            {
                ValueTypeOf = value.SafeGetType();
                ValueAsString = Value.SafeToString();
            }
            catch (Exception e)
            {
                Value = e;
                ValueAsString = e.ToString();
                ThrewAnException = true;
            }
        }
    }
}
