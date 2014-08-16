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
 * Change log
 * 
 * Version | Author | Reason for change                | Description of change
 * -------- -------- ---------------------------------- ------------------------------------------------------
 * 0.95     jmaxxz initial development                Stubbed interface
 * 0.95     jmaxxz initial development                Fulling defined interface
 */
namespace Ares.Common.Api.Server
{
    using System.ServiceModel;
    using DataTypes;

    /// <summary>
    /// This interface describes the a service on the game server which tracks the signal strength of all players.
    /// This interface uses mutable data types and supports the WCF.
    /// </summary>
    [ServiceContract(Namespace = "http://Ares.Common.Api.Server")]
    public interface ISignalStrengthTracker
    {
        /// <summary>
        /// Sets the signal strength of a specified player
        /// </summary>
        /// <param name="signal">the new signal strength</param>
        /// <param name="player">the player for which </param>
        [OperationContract(IsOneWay = true)]
        void SetSignalStrength(MutableSignalStrength signal, MutablePlayer player);
    }
}
