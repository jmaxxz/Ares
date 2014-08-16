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
 * 0.95     mcbridem Code review                        Changed SoundPlayer to readonly and changed naming, 
 *                                                      clarified asynchronous playback, fixed namespace,
 *                                                      removed unused imports, renamed class.
 * 0.95     mcbridem Design review, requirements        Design change to cache player objects required the file
 *                                                      to be loaded in the constructor, which also creates
 *                                                      true immutability.
 */

using System.Media;

namespace Ares.Client.Audio
{
    /// <summary>
    /// A wav sound file player.  Immutable.
    /// </summary>
    public class WavAudioPlayer :IAudioPlayer
    {
        /// <summary>
        /// Wav playback object
        /// </summary>
        private readonly SoundPlayer _soundPlayer;

        /// <summary>
        /// Creates a new WavAudioPlayer instance.
        /// </summary>
        /// <param name="filePath">The path to the audio file.</param>
        public WavAudioPlayer(string filePath)
        {
            _soundPlayer = new SoundPlayer {SoundLocation = filePath};
            _soundPlayer.LoadAsync();
        }

        /// <summary>
        /// Plays the wav sound file associated with this <see cref="WavAudioPlayer"/> object.  Multiple sounds 
        /// cannot be played simultaneously using the <see cref="SoundPlayer"/> object; 
        /// see http://bytes.com/topic/c-sharp/answers/638572-simultaneous-sounds.
        /// </summary>
        public void Play()
        {
            _soundPlayer.Play();
        }
    }


}


