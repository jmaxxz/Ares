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
 * 1.0      jmaxxz initial development                Fully implemented every method
 */
namespace Ares.Server
{
    using Microsoft.Practices.Unity.Configuration;
    using System.Collections.Generic;
    using Microsoft.Practices.Unity;
    using System.Configuration;
    using Common.Api.DataTypes;
    using Common.Api.Server;
    
    
    /// <summary>
    /// Represents a server constructed by reading the "unity.config" file. This server should effectively be a singleton.
    /// While <see cref="UnityServer"/> is not a singleton all of its backing references should be.
    /// 
    /// <see cref="UnityServer"/> Attempts to resolve one of the following from "unity.config".
    /// <see cref="IShotTracker"/>
    /// <see cref="IPositionTracker"/>
    /// <see cref="IPlayerManagement"/>
    /// <see cref="ISignalStrengthTracker"/>
    /// 
    /// All calls to <see cref="UnityServer"/> are simply forwarded on to the corresponding backing object.
    /// </summary>
    public class UnityServer : IShotTracker, IPositionTracker, IPlayerManagement,ISignalStrengthTracker, IGameManager
    {
        private readonly IUnityContainer _container;
        private readonly IShotTracker _shotTracker;
        private readonly IPositionTracker _positionTracker;
        private readonly IPlayerManagement _playerManagement;
        private readonly ISignalStrengthTracker _signalStrengthTracker;
        private readonly IGameManager _gameManager;

        /// <summary>
        /// Used by server front end to listen for logging messages.
        /// </summary>
        public Console.Console ServerConsole { get; private set; }


        /// <summary>
        /// Constructs a new instance of <see cref="UnityServer"/> from "unity.config" file.
        /// </summary>
        public UnityServer()
        {
            var map = new ExeConfigurationFileMap {ExeConfigFilename = "unity.config"};
            var config = ConfigurationManager.OpenMappedExeConfiguration(map, ConfigurationUserLevel.None);
            UnityConfigurationSection section = (UnityConfigurationSection) config.GetSection("unity");
            _container = new UnityContainer();
            section.Configure(_container, "container");

            
            _shotTracker = _container.Resolve<IShotTracker>();
            _positionTracker = _container.Resolve<IPositionTracker>();
            _playerManagement = _container.Resolve<IPlayerManagement>();
            _signalStrengthTracker = _container.Resolve<ISignalStrengthTracker>();
            _gameManager = _container.Resolve<IGameManager>();
            ServerConsole = _container.Resolve<Console.Console>();
        }

        /// <summary>
        /// Notifies server that a shot was fired
        /// </summary>
        /// <param name="shot">the shot that was fired</param>
        /// <returns>returns <see langword="true"/> of shot was a hit, and <see langword="false"/> if shot was a miss</returns>
        public bool FireShot(MutableShot shot)
        {
            return _shotTracker.FireShot(shot);
        }

        /// <summary>
        /// Sets the position of a specified player
        /// </summary>
        /// <param name="position">the new position</param>
        /// <param name="player">the player for which </param>
        public void SetPosition(MutablePosition position, MutablePlayer player)
        {
            _positionTracker.SetPosition(position, player);
        }

        /// <summary>
        /// Tells server a player wants to join
        /// </summary>
        /// <param name="player">The player who wishes to join</param>
        public void Join(MutablePlayer player)
        {
            _playerManagement.Join(player);
        }

        /// <summary>
        /// Tells server a player is leave
        /// </summary>
        /// <param name="player">The player which is leaving the game</param>
        public void Leave(MutablePlayer player)
        {
            _playerManagement.Leave(player);
        }

        /// <summary>
        /// Gets a collection of all the active players
        /// </summary>
        /// <returns></returns>
        public IEnumerable<MutablePlayer> GetPlayers()
        {
            return _playerManagement.GetPlayers();
        }

        /// <summary>
        /// Updates internal player model, and pushes changes out to all clients.
        /// </summary>
        /// <param name="player">The updated player.  <see cref="MutablePlayer.Id"/> must remain the same.</param>
        public void UpdatePlayer(MutablePlayer player)
        {
            _playerManagement.UpdatePlayer(player);
        }

        /// <summary>
        /// Sets the signal strength of a specified player
        /// </summary>
        /// <param name="signal">the new signal strength</param>
        /// <param name="player">the player for which </param>
        public void SetSignalStrength(MutableSignalStrength signal, MutablePlayer player)
        {
            _signalStrengthTracker.SetSignalStrength(signal, player);
        }

        public System.TimeSpan GetTimeLeftInGame()
        {
            return _gameManager.GetTimeLeftInGame();
        }

        public IList<MutablePlayer> GetRankings()
        {
            return _gameManager.GetRankings();
        }

        public void SetGameLength(System.TimeSpan length)
        {
            _gameManager.SetGameLength(length);
        }

        public void StartGame()
        {
            _gameManager.StartGame();
        }

        public void StopGame()
        {
            _gameManager.StopGame();
        }

    }
}
