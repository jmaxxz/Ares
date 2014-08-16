/*
 *  Ares, a multi-player augmented reality first person shooter
 *  Copyright (C) 2010  Jmaxxz, Mike McBride, and Kevin Curtis
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
 * 1.0      jmaxxz initial development                stubbed interface.
 */
using System;
using Ares.Common;
using Ares.Common.Network;
using Ares.Common.Position;

namespace Ares.Server
{
    /// <summary>
    /// Contains all the information about a specific player.
    /// </summary>
    public class PlayerState
    {
        /// <summary>
        /// The last known signal strength of <see cref="PlayerValue"/>.
        /// </summary>
        public SignalStrength PlayerSignalStrength { get; private set; }


        public double Score { get; set; }

        /// <summary>
        /// The last time the signal strength was updated.
        /// </summary>
        public DateTime SignalStrengthUpdated { get; private set; }

        /// <summary>
        /// The last time the position of the player was updated.
        /// </summary>
        public DateTime PositionUpdated { get; private set; }

        /// <summary>
        /// The last time <see cref="PlayerValue"/> was updated.
        /// </summary>
        public DateTime PlayerUpdated { get; private set; }

        /// <summary>
        /// If the player represented is dead, this stores the time the player died.
        /// </summary>
        public DateTime TimeOfDeath { get; private set; }

        /// <summary>
        /// The <see cref="IPlayer"/> to which this object pertains.
        /// </summary>
        public IPlayer PlayerValue { get; private set; }

        /// <summary>
        /// Creates a new instance with passed in values for all properties.
        /// </summary>
        /// <param name="player">The value to be used for <see cref="PlayerValue"/>.</param>
        /// <param name="playerSignalStrength">The value to be used for <see cref="PlayerSignalStrength"/>.</param>
        /// <param name="playerUpdated">The value to be used for <see cref="PlayerUpdated"/></param>
        /// <param name="timeOfDeath">The value to be used for <see cref="TimeOfDeath"/></param>
        /// <param name="positionUpdated">The value to be used for <see cref="PositionUpdated"/></param>
        /// <param name="signalStrengtUpdated">The value to be used for <see cref="SignalStrengthUpdated"/></param>
        public PlayerState(IPlayer player, SignalStrength playerSignalStrength, double score, DateTime playerUpdated, DateTime timeOfDeath, DateTime positionUpdated, DateTime signalStrengtUpdated)
        {
            PlayerValue = player;
            PlayerSignalStrength = playerSignalStrength;
            Score = score;
            PlayerUpdated = playerUpdated;
            TimeOfDeath = timeOfDeath;
            PositionUpdated = positionUpdated;
            SignalStrengthUpdated = signalStrengtUpdated;
            
        }

        /// <summary>
        /// Returns a new instance which is the same as this instance, except with a different <see cref="PlayerSignalStrength"/>
        /// and the <see cref="SignalStrengthUpdated"/> set to the current time.
        /// </summary>
        /// <param name="signalStrength">The new <see cref="SignalStrength"/> to be used.</param>
        /// <returns></returns>
        public PlayerState UpdateSignalStrength(SignalStrength signalStrength)
        {
            return new PlayerState(PlayerValue, signalStrength, Score, PlayerUpdated, TimeOfDeath, PositionUpdated, DateTime.UtcNow);
        }

        public PlayerState UpdateScore(double score)
        {
            return new PlayerState(PlayerValue, PlayerSignalStrength, score, PlayerUpdated, TimeOfDeath, PositionUpdated, SignalStrengthUpdated);
        }


        public PlayerState UpdatePlayer(IPlayer player)
        {
            return new PlayerState(player, PlayerSignalStrength, Score, DateTime.UtcNow, TimeOfDeath, PositionUpdated, SignalStrengthUpdated);
        }


    }
}
