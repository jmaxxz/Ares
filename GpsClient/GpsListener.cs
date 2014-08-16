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
 * 0.95     jmaxxz bug 272                            Misc bug fixes
 * 1.00     jmaxxz bug 293                            Changed status default to NoFix
 */
namespace Ares.Client.Gps
{
    using Common.Position;
    using System;

    /// <summary>
    /// Wraps a event generating instance of <see cref="IGpsAdapter"/> and provides a pollable interface for positioning data
    /// </summary>
    public class GpsListener : IGps, IDisposable

    {
        /// <summary>
        /// The current position
        /// </summary>
        public Position CurrentPosition { get; private set; }

        /// <summary>
        /// The current status of the gps
        /// </summary>
        public GpsStatus Status { get; private set; }
        
        /// <summary>
        /// The backing object which actually talks to the gps and generates events as gps updates
        /// </summary>
        private readonly IGpsAdapter _gpsAdapter;


        /// <summary>
        /// Creates a new instance which updates its current position with data from <see cref="gps"/>
        /// </summary>
        /// <param name="gps">The source new instance will use for position and status updates</param>
        public GpsListener(IGpsAdapter gps)
        {
            _gpsAdapter = gps;
            Status = GpsStatus.NoFix;
            _gpsAdapter.PositionEventHandler += UpdatePosition;
            _gpsAdapter.StatusEventHandler += StatusPosition;
        }

        /// <summary>
        /// Sets <see cref="CurrentPosition"/> based on data in <see cref="args"/>
        /// </summary>
        /// <param name="sender">What class generated this the call to this method</param>
        /// <param name="args">Updated positioning data</param>
        private void UpdatePosition(object sender, PositionUpdateArgs args)
        {
            CurrentPosition = args.CurrentPosition;
        }

        /// <summary>
        /// Sets <see cref="Status"/> based on data in <see cref="args"/>
        /// </summary>
        /// <param name="sender">What class generated this the call to this method</param>
        /// <param name="args">Updated status data</param>
        private void StatusPosition(object sender, StatusUpdateArgs args)
        {
            Status = args.Status;
        }

        /// <summary>
        /// Unsubscribes from backing <see cref="IGpsAdapter"/>. Should be called in order
        /// to ensure proper garbage collection of this instance.
        /// </summary>
        public void Dispose()
        {
            _gpsAdapter.PositionEventHandler -= UpdatePosition;
            _gpsAdapter.StatusEventHandler -= StatusPosition;
        }

    }
}
