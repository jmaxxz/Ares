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
 * Change log
 * 
 * Version | Author | Reason for change                | Description of change
 * -------- -------- ---------------------------------- ------------------------------------------------------
 * 0.95     mcbridem Initial development                Fully defined every method.
 */

namespace Ares.Client.Audio
{
    /// <summary>
    /// An interface to define a mapping between a sound and the file to load the sound from.
    /// </summary>
    public interface ISoundMapping
    {
        /// <summary>
        /// The file to be played when a player shoots.
        /// </summary>
        string Shooting { get; }

        /// <summary>
        /// The file to be played when a player kills another player.
        /// </summary>
        string Killing { get; }

        /// <summary>
        /// The file to be played when a player dies.
        /// </summary>
        string Dying { get; }

        /// <summary>
        /// The file to be played when a player does damage to another player without killing them.
        /// </summary>
        string DoingDamage { get; }

        /// <summary>
        /// The file to be played when a player takes damage.
        /// </summary>
        string TakingDamage { get; }
    }
}


