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
 * File: SharperGpsAdapter.cs
 * Purpose: Provides an adapter to the SharperGps library
 * 
 * 
 * Change log
 * 
 * Version | Author | Reason for change                | Description of change
 * -------- -------- ---------------------------------- ------------------------------------------------------
 * 0.95     jmaxxz initial development                Fully implemented 
 * 0.95     jmaxxz Bug 278                            Added com scanning functionality
 */
using System.Runtime.InteropServices;
using System.Threading;

namespace Ares.Client.Gps.SharpGps
{
    using Common.Position;
    using SharperGps;
    using System;

    /// <summary>
    /// Provides an adapter to the SharperGps library, which reads data in from a NMEA gps unit
    /// </summary>
    public class SharperGpsAdapter : IGpsAdapter, IDisposable 
    {
        /// <summary>
        /// This is the wrapped instance of SharperGps
        /// </summary>
        private readonly GpsHandler _gps;


        /// <summary>
        /// This event will be fired when gps has a position update
        /// </summary>
        public event PositionUpdate PositionEventHandler;


        /// <summary>
        /// This event will be fired when gps has a status update
        /// </summary>
        public event StatusUpdate StatusEventHandler;

        /// <summary>
        /// Creates a new instance of <see cref="SharperGpsAdapter"/> which
        /// listens on the specified COM port
        /// </summary>
        /// <param name="comPort">the COM port on which the new instance should listen</param>
        public SharperGpsAdapter(string comPort)
        {
            _gps = new GpsHandler {TimeOut = 5};
            _gps.NewGpsFix += GpsEventHandler; //Hook up GPS data events to a handler
            try
            {
                _gps.Start(comPort, 4800);
            }
            catch (Exception)
            {
                _gps.Stop();
                throw;
            }
           
        }

        /// <summary>
        /// Creates a new instance of <see cref="SharperGpsAdapter"/> which
        /// listens on the first com port it find which SharperGps accepts.
        /// </summary>
        public SharperGpsAdapter()
        {
            foreach (string portName in System.IO.Ports.SerialPort.GetPortNames())
            {
                GpsHandler gps = new GpsHandler { TimeOut = 5 };
                
                try
                {
                    gps.Start(portName, 4800);
                    DateTime start = DateTime.Now;

                    while (!gps.IsPortOpen && (DateTime.Now.Ticks - start.Ticks) < (gps.TimeOut * 10000000))
                    {
                        Thread.Sleep(100);
                    }
                    if (gps.IsPortOpen)
                    {
                        _gps = gps;
                        _gps.NewGpsFix += GpsEventHandler; //Hook up GPS data events to a handler
                        return;
                    }
                    gps.Stop();
                }
                catch (Exception)
                {
                    gps.Stop();
                }
            }

            throw new COMException("Could not initialize any gps units");

        }

        /// <summary>
        /// Handles events coming in from SharperGps
        /// </summary>
        /// <param name="sender">The class which cause this event</param>
        /// <param name="e">Event details</param>
        private void GpsEventHandler(object sender, GpsHandler.GpsEventArgs e)
        {
           switch (e.TypeOfEvent)
            {
                case GpsEventType.GPRMC: //Gps new fix information
                    InvokePositionEventHandler();
                    InvokeStatusEventHandler(_gps.HasGpsFix ? GpsStatus.HasFix : GpsStatus.NoFix);
                    break;
                case GpsEventType.GPGLL: //position update
                    InvokePositionEventHandler();
                    InvokeStatusEventHandler(GpsStatus.HasFix);
                    break;
            }
        }

        /// <summary>
        /// Triggers a <see cref="PositionUpdate"/> to be fired with the most
        /// resent <see cref="Position"/>
        /// </summary>
        private void InvokePositionEventHandler()
        {
            PositionUpdate handler = PositionEventHandler;
            if (handler != null)
            {
                handler(this, new PositionUpdateArgs(GetPosition()));
            }
        }

        /// <summary>
        /// Triggers a <see cref="StatusUpdate"/> to be fired
        /// </summary>
        /// <param name="status">The new <see cref="GpsStatus"/></param>
        private void InvokeStatusEventHandler(GpsStatus status)
        {
            StatusUpdate handler = StatusEventHandler;
            if (handler != null)
            {
                handler(this, new StatusUpdateArgs(status));
            }
        }

        /// <summary>
        /// Gets last position read by gps
        /// </summary>
        /// <returns></returns>
        private Position GetPosition()
        {
            Coordinate coordinate = _gps.GPRMC.Position;
            Angle latitude = new Angle(coordinate.Latitude);
            Angle longitude = new Angle(coordinate.Longitude);

            return new Position(new Longitude(longitude), new Latitude(latitude) );
        }

        /// <summary>
        /// Unsubscribes from ShaperGps
        /// </summary>
        /// <filterpriority>2</filterpriority>
        public void Dispose()
        {
            _gps.NewGpsFix -= GpsEventHandler;
        }
    }
}