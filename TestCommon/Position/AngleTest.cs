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
 * File: AngleTest.cs
 * Purpose: To test the Angle class
 * 
 * 
 * Change log
 * 
 * Version | Author | Reason for change                | Description of change
 * -------- -------- ---------------------------------- ------------------------------------------------------
 * 0.95     jmaxxz initial development                Tested angle constructors, getters, and casting
 * 0.95     jmaxxz initial development                Removed limit on angle size
 * 1.0      jmaxxz Distance calculations needed       Added test cases for new distance calculation
 */
namespace Ares.Common.Test.Position
{
    using Common.Position;
    using NUnit.Framework;
    using System;

    [TestFixture]
    public class AngleTest
    {
        [SetUp]
        public void Setup()
        {
            //A little round off error is to be expected.
            GlobalSettings.DefaultFloatingPointTolerance = 0.00001;
        }

        [Test]
        public void ZeroDecimalConstructor()
        {
            Angle angle = new Angle(0);

            Assert.AreEqual(0, angle.Degrees);
            Assert.AreEqual(0, angle.Minutes);
            Assert.AreEqual(0.0, angle.DecimalMinutes);
            Assert.AreEqual(0.0, angle.Seconds);
            Assert.AreEqual(0.0, angle.DecimalDegrees);
        }

        [Test]
        public void ZeroDmsConstructor()
        {
            Angle angle = new Angle(0,0,0.0);

            Assert.AreEqual(0, angle.Degrees);
            Assert.AreEqual(0, angle.Minutes);
            Assert.AreEqual(0.0, angle.DecimalMinutes);
            Assert.AreEqual(0.0, angle.Seconds);
            Assert.AreEqual(0.0, angle.DecimalDegrees);
            
        }

        [Test]
        public void ThreeSixtyDecimalConstructor()
        {
            Angle angle = new Angle(360);

            Assert.AreEqual(360, angle.Degrees);
            Assert.AreEqual(0, angle.Minutes);
            Assert.AreEqual(0.0, angle.DecimalMinutes);
            Assert.AreEqual(0.0, angle.Seconds);
            Assert.AreEqual(360.0, angle.DecimalDegrees);
        }

        [Test]
        public void ThreeSixtyDmsConstructor()
        {
            Angle angle = new Angle(360, 0, 0.0);

            Assert.AreEqual(360, angle.Degrees);
            Assert.AreEqual(0, angle.Minutes);
            Assert.AreEqual(0.0, angle.DecimalMinutes);
            Assert.AreEqual(0.0, angle.Seconds);
            Assert.AreEqual(360.0, angle.DecimalDegrees);

        }

        [Test]
        public void DecimalConstructorTest1()
        {
            Angle angle = new Angle(89.1875);

            Assert.AreEqual(89, angle.Degrees);
            Assert.AreEqual(11, angle.Minutes);
            Assert.AreEqual(11.25, angle.DecimalMinutes);
            Assert.AreEqual(15, angle.Seconds);
            Assert.AreEqual(89.1875, angle.DecimalDegrees);
        }

        [Test]
        public void DecimalConstructorTest2()
        {
            Angle angle = new Angle(12.25);

            Assert.AreEqual(12, angle.Degrees);
            Assert.AreEqual(15, angle.Minutes);
            Assert.AreEqual(15.0, angle.DecimalMinutes);
            Assert.AreEqual(0.0, angle.Seconds);
            Assert.AreEqual(12.25, angle.DecimalDegrees);
        }

        [Test]
        public void DecimalConstructorTest3()
        {
            Angle angle = new Angle(33.5);

            Assert.AreEqual(33, angle.Degrees);
            Assert.AreEqual(30, angle.Minutes);
            Assert.AreEqual(30.0, angle.DecimalMinutes);
            Assert.AreEqual(0.0, angle.Seconds);
            Assert.AreEqual(33.5, angle.DecimalDegrees);
        }

        [Test]
        public void DecimalConstructorTest4()
        {
            Angle angle = new Angle(13.12345);

            Assert.AreEqual(13, angle.Degrees);
            Assert.AreEqual(7, angle.Minutes);
            Assert.AreEqual(7.407, angle.DecimalMinutes);
            Assert.AreEqual(24.42, angle.Seconds);
            Assert.AreEqual(13.12345, angle.DecimalDegrees);
        }



        [Test]
        public void DmsConstructorTest1()
        {
            Angle angle = new Angle(89,11,15);

            Assert.AreEqual(89, angle.Degrees);
            Assert.AreEqual(11, angle.Minutes);
            Assert.AreEqual(11.25, angle.DecimalMinutes);
            Assert.AreEqual(15, angle.Seconds);
            Assert.AreEqual(89.1875, angle.DecimalDegrees);
        }

        [Test]
        public void DmsConstructorTest2()
        {
            Angle angle = new Angle(12,15,0);

            Assert.AreEqual(12, angle.Degrees);
            Assert.AreEqual(15, angle.Minutes);
            Assert.AreEqual(15.0, angle.DecimalMinutes);
            Assert.AreEqual(0.0, angle.Seconds);
            Assert.AreEqual(12.25, angle.DecimalDegrees);
        }

        [Test]
        public void DmsConstructorTest3()
        {
            Angle angle = new Angle(33,30,0.0);

            Assert.AreEqual(33, angle.Degrees);
            Assert.AreEqual(30, angle.Minutes);
            Assert.AreEqual(30.0, angle.DecimalMinutes);
            Assert.AreEqual(0.0, angle.Seconds);
            Assert.AreEqual(33.5, angle.DecimalDegrees);
        }

        [Test]
        public void DmsConstructorTest4()
        {
            Angle angle = new Angle(13,7,24.42);

            Assert.AreEqual(13, angle.Degrees);
            Assert.AreEqual(7, angle.Minutes);
            Assert.AreEqual(7.407, angle.DecimalMinutes);
            Assert.AreEqual(24.42, angle.Seconds);
            Assert.AreEqual(13.12345, angle.DecimalDegrees);
        }


        [Test]
        public void RandomConstructionTest()
        {
            Random random = new Random();
            for(uint i=0; i<10000; i++)
            {
                double decimalAngle = random.Next(-360, 360);
                Angle angle = new Angle(decimalAngle);
                Angle angle2 = new Angle(angle.Degrees,angle.Minutes,angle.Seconds);

                Assert.AreEqual(angle2.Degrees, angle.Degrees);
                Assert.AreEqual(angle2.Minutes, angle.Minutes);
                Assert.AreEqual(angle2.DecimalMinutes, angle.DecimalMinutes);
                Assert.AreEqual(angle2.Seconds, angle.Seconds);
                Assert.AreEqual(angle2.Degrees, angle.DecimalDegrees);

                //Ensure casting is working
                double castedAngle = angle;
                Assert.AreEqual(decimalAngle, castedAngle);

                //Ensure == is working
                Assert.AreEqual(true,angle2 == angle);
                Assert.False(angle2 != angle);
                Assert.True(angle2 == angle);
                Assert.True(angle2.Equals(angle));
            }
        }

        [Test]
        public void TestDistance()
        {
            //Test case from: http://www.movable-type.co.uk/scripts/latlong.html
            Angle lat1 = new Angle(53,8,50);
            Angle long1 = new Angle(1,50,58);
            Position p1  =  new Position(new Longitude(long1,CardinalDirection.West), new Latitude(lat1,CardinalDirection.North));
            
            Angle lat2 = new Angle(52, 12, 16);
            Angle long2 = new Angle(0, 8 , 26);
            Position p2 = new Position(new Longitude(long2,CardinalDirection.East), new Latitude(lat2, CardinalDirection.North));
            
            Assert.AreEqual(170300.0,p1.DistanceFrom(p2),47);
        }

        [Test]
        public void TestDistanceCloseUp()
        {
            Angle lat1 = new Angle(53, 8, 50);
            Angle long1 = new Angle(1, 50, 58);
            Position p1 = new Position(new Longitude(long1, CardinalDirection.West), new Latitude(lat1, CardinalDirection.North));

            Angle lat2 = new Angle(53, 8, 50);
            Angle long2 = new Angle(1, 50, 59);
            Position p2 = new Position(new Longitude(long2, CardinalDirection.West), new Latitude(lat2, CardinalDirection.North));

            Assert.AreEqual(18.51255400844088,p1.DistanceFrom(p2),.5);
        }
    }
}