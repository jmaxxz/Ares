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
 * 0.95     mcbridem Code review                        Changed SoundPlayer to readonly and changed naming, 
 *                                                      clarified asynchronous playback, fixed namespace,
 *                                                      removed unused imports.
 */

namespace Ares.Client.Audio
{
    /// <summary>
    /// Interface for an audio engine for the Ares System.
    /// </summary>
    public interface IAudioEngine
    {
        /// <summary>
        /// Plays the specified sound for when a player shoots a weapon.
        /// </summary>
        /// <param name="distance">The distance between the current player and 
        /// the shooting player.  -1 distance refers to the current player.</param>
        void PlayShooting(double distance);

        /// <summary>
        /// Plays the specified sound for when the current player kills another player.
        /// </summary>
        void PlayKilling();

        /// <summary>
        /// Plays the specified sound for when the current player dies.
        /// </summary>
        void PlayDying();

        /// <summary>
        /// Plays the specified sound for when the current player is doing damage.
        /// </summary>
        void PlayDoingDamage();

        /// <summary>
        /// Plays the specified sound for when the current player is taking damage.
        /// </summary>
        void PlayTakingDamage();
    }
}


