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
 * 0.95     jmaxxz initial development                Fully implemented every method
 */
namespace Ares.Common.Api.DataTypes
{
    using System.Collections.Generic;
    using System;

    /// <summary>
    /// This is a mutable representation of all players' scores. This class should not be used unless interfacing with a library
    /// that requires mutable object (like .net's built in serialization library, or WCF)
    /// </summary>
    [Serializable]
    public class MutableScore
    {
        /// <summary>
        /// An ordered collection of players and their respective scores.
        /// Collection is ordered such that the winner is at index 0 and the loser is
        /// at index length -1.
        /// </summary>
        public IList<MutablePlayerScore> Scores { get; set; }
    }
}
