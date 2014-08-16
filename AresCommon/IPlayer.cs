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
 * 0.95     jmaxxz initial development                Wrote interface
 * 1.0      jmaxxz Misc Refactoring, Server impl      Refactored codebase, added basic server
 */
namespace Ares.Common
{
    using System.Drawing;
    using System;


    /// <summary>
    /// Represents a person playing the Ares game.
    /// </summary>
    public interface IPlayer
    {
        /// <summary>
        /// The current health of this instance. 
        /// </summary>
        double Health { get; }

        /// <summary>
        /// Returns <see langword="true"/>  if instance is still a player who is alive, and <see langword="false"/> if they are dead.
        /// </summary>
        bool IsAlive { get; }

        /// <summary>
        /// The color associated with the player this instance represents
        /// </summary>
        Color ClothingColor { get; }

        /// <summary>
        /// The nickname associated with this player. (Can't be <see langword="null"/>)
        /// </summary>
        string Nickname { get; }

        /// <summary>
        /// The current location of the player, if known
        /// </summary>
        Position.Position CurrentPosition { get; }

        /// <summary>
        /// Gets the unique identifier associated with the player this instance represents
        /// </summary>
        Guid Id { get; }


        /// <summary>
        /// Creates a new instance which represents this player, with a new nickname, position, health, and color.
        /// 
        /// multiple value to be changed at once
        /// </summary>
        /// <param name="nickname">new nickname</param>
        /// <param name="position">new position</param>
        /// <param name="health">new health value</param>
        /// <param name="color">new color</param>
        /// <returns></returns>
        IPlayer ChangeTo(string nickname, Position.Position position, double health, Color color);

        /// <summary>
        /// Creates a new instance which represents this player, but with a new nickname
        /// </summary>
        /// <param name="nickname">new nickname</param>
        /// <returns></returns>
        IPlayer ChangeNickname(string nickname);

        /// <summary>
        /// Creates a new instance which represents this player, but at a new location
        /// </summary>
        /// <param name="position">new location</param>
        /// <returns></returns>
        IPlayer ChangePosition(Position.Position position);
        
        
        /// <summary>
        /// Creates a new instance which represents this player, but with a new health
        /// </summary>
        /// <param name="health">new health value</param>
        /// <returns></returns>
        IPlayer ChangeHealth(double health);

        /// <summary>
        /// Creates a new instance which represents this player, but with a new color
        /// </summary>
        /// <param name="color">new color</param>
        /// <returns></returns>
        IPlayer ChangeColor(Color color);
    }
}
