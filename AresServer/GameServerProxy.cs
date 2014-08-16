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
 * 1.0      jmaxxz initial development                Fully implemented every method
 * 1.0      jmaxxz was not thread safe                locked access to backing data structures.
 * 1.0      jmaxxz Added push notification            Wired up PushServer
 */
namespace Ares.Server
{
    using System.Collections.Generic;
    using Common.Api.DataTypes;
    using Common.Api.Server;
    using System.Threading;
    using Common.Network;
    using System.Linq;
    using Console;
    using Common;
    using System;
    

    /// <summary>
    /// Manages the current the state of the Ares game, and pushes updates to clients
    /// </summary>
    public class GameServerProxy : IPlayerManagementProxy, IShotTrackerProxy, ISignalStrengthTrackerProxy, IGameManagerProxy, IPositionTrackerProxy
    {
        /// <summary>
        /// Used by <see cref="GameServerProxy"/> to output logging messages.
        /// </summary>
        protected readonly Console.Console ServerConsole;
        protected double DefaultHealth  = 100;

        protected DateTime StartTime;
        protected TimeSpan Duration;

        protected readonly IDictionary<Guid, PlayerState> PlayerStates;
        
        //Use individual times to cause players to respawn, and push damage out
        //based on signal strength.
        //Move signal strength onto the player class.


        /// <summary>
        /// Creates a new instance of this game server
        /// </summary>
        public GameServerProxy(Console.Console serverConsole)
        {
            PlayerStates = new Dictionary<Guid, PlayerState>();
            ServerConsole = serverConsole;
        }

        /// <summary>
        /// Tells server a player wants to join
        /// </summary>
        /// <param name="player">The player who wishes to join</param>
        public virtual void Join(IPlayer player)
        {
            lock (PlayerStates)
            {
                if (!PlayerStates.ContainsKey(player.Id))
                {
                    PlayerStates.Add(player.Id,
                                     new PlayerState(player, new SignalStrength(100), 0, DateTime.UtcNow, DateTime.MaxValue,
                                                     DateTime.UtcNow, DateTime.UtcNow));
                    ServerConsole.SafeLog(string.Format("{0} joined server.", player), ErrorLevel.Message);
                }
                else
                {
                    ServerConsole.SafeLog(string.Format("{0} tried to join server twice.", player), ErrorLevel.Warning);
                }
            }

        }

        /// <summary>
        /// Tells server a player is leave
        /// </summary>
        /// <param name="player">The player which is leaving the game</param>
        public virtual void Leave(IPlayer player)
        {
            lock (PlayerStates)
            {
                if (PlayerStates.ContainsKey(player.Id))
                {
                    PlayerStates.Remove(player.Id);
                    ServerConsole.SafeLog(string.Format("{0} left server.", player), ErrorLevel.Message);
                }
                else
                {
                    ServerConsole.SafeLog(string.Format("Nonexistent player ({0}) tried to leave server.", player),
                                          ErrorLevel.Warning);
                }
            }
        }

        /// <summary>
        /// Gets a collection of all the active players
        /// </summary>
        /// <returns></returns>
        public virtual IEnumerable<IPlayer> GetPlayers()
        {
            lock (PlayerStates)
            {
                return PlayerStates.Values.Select(playerState => playerState.PlayerValue);
            }
        }

        /// <summary>
        /// Updates internal player model, and pushes changes out to all clients.
        /// </summary>
        /// <param name="player">The updated player.  <see cref="IPlayer.Id"/> must remain the same.</param>
        public void UpdatePlayer(IPlayer player)
        {
            lock (PlayerStates)
            {
                if (PlayerStates.ContainsKey(player.Id))
                {
                    PlayerState tempPlayerState = PlayerStates[player.Id];
                    IPlayer oldPlayer = tempPlayerState.PlayerValue;

                    PlayerStates[player.Id] = new PlayerState(player, tempPlayerState.PlayerSignalStrength,tempPlayerState.Score, DateTime.UtcNow,
                                                              tempPlayerState.TimeOfDeath,
                                                              tempPlayerState.PositionUpdated,
                                                              tempPlayerState.SignalStrengthUpdated);
                    ServerConsole.SafeLog(string.Format("{0} Updated to {1}.", oldPlayer, player), ErrorLevel.Message);
                    return;
                }

                ServerConsole.SafeLog(string.Format("{0} does not exist so updated failed.", player), ErrorLevel.Warning);
                return;
            }
        }


        /// <summary>
        /// Register a shot fired with the game server
        /// </summary>
        /// <param name="shot">The shot being fired</param>
        /// <returns>True is returned if the shot is a hit, False if the shot does not miss</returns>
        public virtual bool FireShot(Shot shot)
        {
            if(!_running)
            {
                return false;
            }

            PushServer.GetDefault().NotifyAllOfShot(shot);

            if (shot.Target !=null && shot.Shooter.IsAlive && shot.Target.IsAlive && shot.Target.CurrentPosition.DistanceFrom(shot.Shooter.CurrentPosition) > 20)
            {
                lock (PlayerStates)
                {
                    IPlayer resultingTarget = DamagePlayer(shot.Target, 25);
                    
                    if(!resultingTarget.IsAlive && shot.Target.IsAlive)
                    {
                        PlayerStates[shot.Shooter.Id].UpdateScore(PlayerStates[shot.Shooter.Id].Score +1);
                    }
                }

                ServerConsole.SafeLog( string.Format("Shot ({0}) fired and hit.", shot), ErrorLevel.Message);
                return true;
            }

            ServerConsole.SafeLog(string.Format("Shot ({0}) fired and missed.", shot), ErrorLevel.Message);
            return false;
        }

        /// <summary>
        /// Sets the signal strength of a specified player
        /// </summary>
        /// <param name="signal">the new signal strength</param>
        /// <param name="player">the player for which </param>
        public virtual void SetSignalStrength(SignalStrength signal, IPlayer player)
        {
            lock (PlayerStates)
            {
                PlayerState tempPlayerState = PlayerStates[player.Id];
                PlayerStates[player.Id] = new PlayerState(tempPlayerState.PlayerValue, signal, tempPlayerState.Score,
                                                          tempPlayerState.PlayerUpdated, tempPlayerState.TimeOfDeath,
                                                          tempPlayerState.PositionUpdated, DateTime.UtcNow);
            }
        }



        public void SetPosition(Common.Position.Position position, IPlayer player)
        {
            lock (PlayerStates)
            {
                PlayerStates[player.Id].UpdatePlayer(PlayerStates[player.Id].PlayerValue.ChangePosition(position));
            }
        }

        public TimeSpan GetTimeLeftInGame()
        {
            return StartTime.ToUniversalTime().AddMilliseconds(Duration.TotalMilliseconds) - DateTime.UtcNow;
        }

        public IList<IPlayer> GetRankings()
        {
            IList<IPlayer> rankings = (IList<IPlayer>) (from player in PlayerStates.Values orderby player.PlayerValue select player).ToList();
            return rankings;
        }

        public void SetGameLength(TimeSpan length)
        {
            if (_running)
            {
                ServerConsole.SafeLog(string.Format("Game length could not be set, the game is already started"), ErrorLevel.Warning);
                return;
            }

            Duration = length;
            ServerConsole.SafeLog(string.Format("New game length is: {0}",length), ErrorLevel.Message);
        }

        private Thread _serverThread;
        private bool _running;
        private Thread _serverThread2;

        public void StartGame()
        {
            if (_running)
            {
                ServerConsole.SafeLog(string.Format("Game could not be started, the game is already started"), ErrorLevel.Warning);
                return;
            }
            _running = true;
            StartTime = DateTime.UtcNow;
            _serverThread =  new Thread(ServerLoop) {IsBackground = true};
            _serverThread.Start();

            _serverThread2 = new Thread(PushLoop) { IsBackground = true };
            _serverThread2.Start();

            ServerConsole.SafeLog("Game started", ErrorLevel.Message);
        }

        public void StopGame()
        {
            if (!_running)
            {
                ServerConsole.SafeLog(string.Format("Game could not be stopped, the game is not running"), ErrorLevel.Warning);
                return;
            }
            _running = false;
            _serverThread = null;
            _serverThread2.Join();
            _serverThread2 = null;


            ServerConsole.SafeLog("Game stopped", ErrorLevel.Message);
        }

        private void ServerLoop()
        {
            while (_running)
            {
                EvaluateGameState();
                Thread.Sleep(200);
            }
        }


        private void PushLoop()
        {
            while (_running)
            {
                lock (PlayerStates)
                {
                    List<IPlayer> temp = new List<IPlayer>();
                    foreach (var playerState in PlayerStates.Values)
                    {
                        temp.Add(playerState.PlayerValue);
                    }
                    PushServer.GetDefault().PushPlayerList(temp);
                }

                Thread.Sleep(2000);

                
            }
        }
        private void EvaluateGameState()
        {
            if(GetTimeLeftInGame().TotalMilliseconds <=0)
            {
                StopGame();
                return;
            }

            IDictionary<IPlayer, double> damageMap = new Dictionary<IPlayer, double>();
            IList<IPlayer> respawnList = new List<IPlayer>();

            lock (respawnList)
            {
                foreach (PlayerState playerState in PlayerStates.Values)
                {
                    //if player is up for a respawn
                    if (DateTime.UtcNow.Subtract(playerState.TimeOfDeath).TotalSeconds >= 15)
                    {
                        respawnList.Add(playerState.PlayerValue);
                    }
                    else
                    {
                        double damage = 0;
                        // Evaluate wifi strength, hurt people who have low strengths
                        if (playerState.PlayerSignalStrength.Value < 30)
                        {
                            damage += 10;
                        }
                        if (DateTime.UtcNow.Subtract(playerState.PositionUpdated).Seconds > 5)
                        {
                            damage += playerState.PlayerValue.Health + 1;
                        }

                        if (DateTime.UtcNow.Subtract(playerState.SignalStrengthUpdated).Seconds > 5)
                        {
                            damage += playerState.PlayerValue.Health + 1;
                        }

                        damageMap.Add(playerState.PlayerValue, damage);
                    }
                }
            }

            foreach (var damageMapping in damageMap)
            {
                DamagePlayer(damageMapping.Key, damageMapping.Value);
            }

            foreach (var player in respawnList)
            {
                Respawn(player);
            }
        }

        private void Respawn(IPlayer player)
        {
            PushServer.GetDefault().NotifyAllOfRespawn(player);
            lock (PlayerStates)
            {
                PlayerState tempState = PlayerStates[player.Id];
                PlayerStates[player.Id] = new PlayerState(tempState.PlayerValue.ChangeHealth(DefaultHealth), tempState.PlayerSignalStrength, tempState.Score, DateTime.UtcNow, DateTime.MaxValue, tempState.PositionUpdated, tempState.SignalStrengthUpdated);
            }
        }

        private IPlayer DamagePlayer(IPlayer player, double damage)
        {
            
            lock (PlayerStates)
            {
                PlayerState tempPlayerState = PlayerStates[player.Id];
                IPlayer resultingPlayer = player.ChangeHealth(player.Health - damage);
                DateTime timeOfDeath = tempPlayerState.TimeOfDeath;
                double score = tempPlayerState.Score;
                if (player.IsAlive && !resultingPlayer.IsAlive)
                {
                    score -= .5;
                    timeOfDeath = DateTime.UtcNow;
                }

                PlayerStates[player.Id] = new PlayerState(resultingPlayer,
                                                               tempPlayerState.PlayerSignalStrength, score, DateTime.UtcNow,
                                                               timeOfDeath,
                                                               tempPlayerState.PositionUpdated,
                                                               tempPlayerState.SignalStrengthUpdated);

                PushServer.GetDefault().GetClient(player.Id).Damage(resultingPlayer.ToMutablePlayer());
                PushServer.GetDefault().NotifyAllOfDamage(resultingPlayer);

                return resultingPlayer;
            }
            
        }
    }
}
