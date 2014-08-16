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
 * File: LatitudeTest.cs
 * Purpose: To test the Latitude class
 * 
 * 
 * Change log
 * 
 * Version | Author | Reason for change                | Description of change
 * -------- -------- ---------------------------------- ------------------------------------------------------
 * 0.95     jmaxxz initial development                Tested constructors, and getters
 */
namespace Ares.Common.Test.Position
{
    using Common.Position;
    using NUnit.Framework;
    using System;

    [TestFixture]
    public class LatitudeTest
    {
        [SetUp]
        public void Setup()
        {
            //A little round off error is to be expected.
            GlobalSettings.DefaultFloatingPointTolerance = 0.00001;
        }

        [Test]
        public void RawAngleConstructorTest1()
        {
            Angle angle = new Angle(45);

            Latitude latitude = new Latitude(angle);

            Assert.AreEqual(CardinalDirection.North, latitude.Hemisphere);
            Assert.AreEqual(angle, latitude.Value);
            Assert.AreEqual(angle,latitude.RawValue);
        }

        [Test]
        public void RawAngleConstructorTest2()
        {
            Angle angle = new Angle(0);

            Latitude latitude = new Latitude(angle);

            Assert.AreEqual(angle, latitude.Value);
            Assert.AreEqual(angle, latitude.RawValue);
        }

        [Test]
        public void RawAngleConstructorTest3()
        {
            Angle angle = new Angle(-45);

            Latitude latitude = new Latitude(angle);

            Assert.AreEqual(CardinalDirection.South, latitude.Hemisphere);
            Assert.AreEqual(-angle, latitude.Value);
            Assert.AreEqual(angle, latitude.RawValue);
        }

        [Test]
        public void RawAngleConstructorTest4()
        {
            Angle angle = new Angle(90);

            Latitude latitude = new Latitude(angle);

            Assert.AreEqual(CardinalDirection.North, latitude.Hemisphere);
            Assert.AreEqual(angle, latitude.Value);
            Assert.AreEqual(angle, latitude.RawValue);
        }

        [Test]
        public void RawAngleConstructorTest5()
        {
            Angle angle = new Angle(-90);

            Latitude latitude = new Latitude(angle);

            Assert.AreEqual(CardinalDirection.South, latitude.Hemisphere);
            Assert.AreEqual(-angle, latitude.Value);
            Assert.AreEqual(angle, latitude.RawValue);
        }

        [Test]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void RawAngleConstructorTest6()
        {
            Angle angle = new Angle(-91);
            new Latitude(angle);
        }

        [Test]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void RawAngleConstructorTest7()
        {
            Angle angle = new Angle(91);
            new Latitude(angle);
        }

        [Test]
        public void HemisphereAngleConstructorTest1()
        {
            Angle angle = new Angle(0);

            Latitude latitude = new Latitude(angle,CardinalDirection.South);

            Assert.AreEqual(angle, latitude.Value);
            Assert.AreEqual(angle, latitude.RawValue);
        }

        [Test]
        public void HemisphereAngleConstructorTest2()
        {
            Angle angle = new Angle(90);

            Latitude latitude = new Latitude(angle, CardinalDirection.North);

            Assert.AreEqual(CardinalDirection.North, latitude.Hemisphere);
            Assert.AreEqual(angle, latitude.Value);
            Assert.AreEqual(angle, latitude.RawValue);
        }

        [Test]
        public void HemisphereAngleConstructorTest3()
        {
            Angle angle = new Angle(90);

            Latitude latitude = new Latitude(angle, CardinalDirection.South);

            Assert.AreEqual(CardinalDirection.South, latitude.Hemisphere);
            Assert.AreEqual(angle, latitude.Value);
            Assert.AreEqual(-angle, latitude.RawValue);
        }


        [Test]
        [ExpectedException(typeof( ArgumentException ))]
        public void HemisphereAngleConstructorTest4()
        {
            Angle angle = new Angle(90);

            new Latitude(angle, CardinalDirection.East);
        }

        [Test]
        [ExpectedException(typeof(ArgumentException))]
        public void HemisphereAngleConstructorTest5()
        {
            Angle angle = new Angle(90);

            new Latitude(angle, CardinalDirection.West);
        }

        [Test]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void HemisphereAngleConstructorTest6()
        {
            Angle angle = new Angle(-1);

            new Latitude(angle, CardinalDirection.North);
        }

        [Test]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void HemisphereAngleConstructorTest7()
        {
            Angle angle = new Angle(91);

            new Latitude(angle, CardinalDirection.North);
        }

    }
}
