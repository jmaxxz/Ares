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
 * 0.95     mcbridem Code review                        Created private setters and constructor for immutability.
 */

namespace Ares.Client.Audio
{
    /// <summary>
    /// A default implementation of the <see cref="ISoundMapping"/> interface.  Immutable.
    /// </summary>
    public class SoundMapping: ISoundMapping
    {
        /// <summary>
        /// Standard constructor to fully initialize the SoundMapping object.
        /// </summary>
        /// <param name="shooting">The file to play when a player shoots.</param>
        /// <param name="killing">The file to play when a player kills another player.</param>
        /// <param name="dying">The file to play when a player dies.</param>
        /// <param name="doingDamage">The file to play when a player deals damage.</param>
        /// <param name="takingDamage">The file to play when a player takes damage.</param>
        public SoundMapping(string shooting, string killing, string dying,
            string doingDamage, string takingDamage)
        {
            Shooting = shooting;
            Killing = killing;
            Dying = dying;
            DoingDamage = doingDamage;
            TakingDamage = takingDamage;
        }

        /// <summary>
        /// The file to be played when a player shoots.
        /// </summary>
        public string Shooting { get; private set; }

        /// <summary>
        /// The file to be played when a player kills another player.
        /// </summary>
        public string Killing { get; private set; }

        /// <summary>
        /// The file to be played when a player dies.
        /// </summary>
        public string Dying { get; private set; }

        /// <summary>
        /// The file to be played when a player does damage to another player without killing them.
        /// </summary>
        public string DoingDamage { get; private set; }

        /// <summary>
        /// The file to be played when a player takes damage.
        /// </summary>
        public string TakingDamage { get; private set; }
    }
}


