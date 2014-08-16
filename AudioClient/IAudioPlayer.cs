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
 * 0.95     mcbridem Initial development                Fully implemented every method
 * 0.95     mcbridem Code review                        Fixed namespace, removed unused imports.
 * 0.95     mcbridem Design review, requirements        Removed file path from Play() method; file path to
 *                                                      audio file must now be supplied in implementing class'
 *                                                      constructor.
 */

namespace Ares.Client.Audio
{
    /// <summary>
    /// Interface for a sound file player.
    /// </summary>
    public interface IAudioPlayer
    {
        /// <summary>
        /// Plays an audio file.
        /// </summary>
        void Play();
    }
}


