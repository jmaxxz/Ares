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
 * 0.95     mcbridem Initial development                Fully implemented every method, defined constants for sound files
 * 0.95     mcbridem Code review                        Eliminated .wav dependence (class renamed to reflect this), fixed
 *                                                      namespace, removed unused imports, renamed IPlayer object, changed
 *                                                      constructor to match design, fixed class visibility, made sound
 *                                                      file variables readonly.
 * 0.95     mcbridem Code review                        Changed from using backing variables for the sound file paths to
 *                                                      storing the instance of the ISoundMapping object.
 * 0.95     mcbridem Design review, requirements        Created IAudioPlayer object for each sound to be played to improve
 *                                                      performance and come closer to 50 ms playback response requirement.
 */

namespace Ares.Client.Audio
{
    /// <summary>
    /// Interface for an audio engine for the Ares System that plays only .wave audio files.  Immutable.
    /// </summary>
    public class AudioEngine :IAudioEngine
    {
        /// <summary>
        /// The mapping of sounds to the file that should be played.
        /// </summary>
        private readonly ISoundMapping _soundList;

        /// <summary>
        /// Sound playback object for shooting.
        /// </summary>
        private readonly IAudioPlayer _shootingPlayer;

        /// <summary>
        /// Sound playback object for killing.
        /// </summary>
        private readonly IAudioPlayer _killingPlayer;

        /// <summary>
        /// Sound playback object for dying.
        /// </summary>
        private readonly IAudioPlayer _dyingPlayer;

        /// <summary>
        /// Sound playback object for doing damage.
        /// </summary>
        private readonly IAudioPlayer _doingDamagePlayer;

        /// <summary>
        /// Sound playback object for taking damage.
        /// </summary>
        private readonly IAudioPlayer _takingDamagePlayer;

        /// <summary>
        /// Creates a new AudioEngine instance, assigning sound file paths from the mapping object.
        /// Sounds assigned to <see langword="null"/> will not be playable.
        /// </summary>
        public AudioEngine(ISoundMapping soundList)
        {
            _soundList = soundList;

            _shootingPlayer = CheckExtensionMapping(_soundList.Shooting);
            _killingPlayer = CheckExtensionMapping(_soundList.Killing);
            _dyingPlayer = CheckExtensionMapping(_soundList.Dying);
            _doingDamagePlayer = CheckExtensionMapping(_soundList.DoingDamage);
            _takingDamagePlayer = CheckExtensionMapping(_soundList.TakingDamage);
        }

        /// <summary>
        /// Plays the specified sound for when a player shoots a weapon.
        /// </summary>
        /// <param name="distance">The distance between the current player and 
        /// the shooting player.  -1 distance refers to the current player.</param>
        public void PlayShooting(double distance)
        {
            if (_shootingPlayer != null)
                _shootingPlayer.Play();
        }

        /// <summary>
        /// Plays the specified sound for when the current player kills another player.
        /// </summary>
        public void PlayKilling()
        {
            if (_killingPlayer != null)
                _killingPlayer.Play();
        }

        /// <summary>
        /// Plays the specified sound for when the current player dies.
        /// </summary>
        public void PlayDying()
        {
            if (_dyingPlayer != null)
                _dyingPlayer.Play();
        }

        /// <summary>
        /// Plays the specified sound for when the current player is doing damage.
        /// </summary>
        public void PlayDoingDamage()
        {
            if (_doingDamagePlayer != null)
                _doingDamagePlayer.Play();
        }

        /// <summary>
        /// Plays the specified sound for when the current player is taking damage.
        /// </summary>
        public void PlayTakingDamage()
        {
            if (_takingDamagePlayer != null)
                _takingDamagePlayer.Play();
        }

        /// <summary>
        /// Checks the given file path against the file extension mapping ad returns an appropriate 
        /// <see cref="IAudioPlayer"/> object for playing the file.
        /// </summary>
        /// <param name="filepath">The path to the desired audio file</param>
        /// <returns>An IAudioObject best suited for playing the file, or <see langword="null"/> if no proper object 
        /// exists to play the file (for example, if a non-audio file is passed).</returns>
        private static IAudioPlayer CheckExtensionMapping(string filepath)
        {
            IAudioPlayer retVal = null;

            var extension = filepath.Substring(filepath.LastIndexOf('.') + 1).ToLower();

            if(extension.Equals("wav"))
            {
                retVal = new WavAudioPlayer(filepath);
            }

            return retVal;
        }
    }
}


