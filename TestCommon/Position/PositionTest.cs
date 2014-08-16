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
 * File: PositionTest.cs
 * Purpose: To test the Position class
 * 
 * 
 * Change log
 * 
 * Version | Author | Reason for change                | Description of change
 * -------- -------- ---------------------------------- ------------------------------------------------------
 * 0.95     jmaxxz initial development                Tested constructor, ==, and getters
 */
namespace Ares.Common.Test.Position
{
    using Common.Position;
    using NUnit.Framework;
    using System;

    [TestFixture]
    public class PositionTest
    {
        [Test]
        public void EqualityTest()
        {
            Random random = new Random();
            for (int i = 0; i < 10000; i++)
            {

                Angle longitude0 = new Angle(random.Next(-180,180));
                Angle latitude0 = new Angle(random.Next(-90, 90));

                //construct an equivalent set of angles
                Angle longitude1 = new Angle(longitude0.DecimalDegrees);
                Angle latitude1 = new Angle(latitude0.DecimalDegrees);

                Position position0 = new Position(new Longitude(longitude0), new Latitude(latitude0));
                Position position1 = new Position(new Longitude(longitude1), new Latitude(latitude1));

                Assert.True(position0.Equals(position1));
                Assert.True(position0 == position1);
            }
        }
    }
}
