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
 * 0.95     jmaxxz initial development                Fully implemented all methods
 * 1.0      jmaxxz Misc Refactoring, Server impl      Refactored codebase, added basic server
 */
namespace Ares.Common
{
    using System.Drawing;
    using System;

    /// <summary>
    /// Represents a player in the Ares system
    /// </summary>
    public class Player: IPlayer, IEquatable<IPlayer>
    {
        protected static Color  DefaultClothingColor = Color.Empty;
        protected static double  DefaultHealth = 100.0;
        protected static Position.Position DefaultPosition;

        /// <summary>
        /// The current health of this instance. 
        /// </summary>
        public double Health { get; private set; }


        /// <summary>
        /// Returns <see langword="true"/> if instance is still a player who is alive, and <see langword="false"/> if they are dead.
        /// </summary>
        public bool IsAlive 
        {
            get
            {
                return Health > 0.0;
            }
        }


        /// <summary>
        /// The color associated with the player this instance represents
        /// </summary>
        public Color ClothingColor { get; private set; }

        /// <summary>
        /// The nickname associated with this player. (Can't be <see langword="null"/>)
        /// </summary>
        public string Nickname { get; private set; }


        /// <summary>
        /// The current location of the player, if known
        /// </summary>
        public Position.Position CurrentPosition { get; private set; }

        /// <summary>
        /// Gets the unique identifier associated with the player this instance represents
        /// </summary>
        public Guid Id { get; private set; }

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
        public IPlayer ChangeTo(string nickname, Position.Position position, double health, Color color)
        {
            return new Player(Id, nickname,color,health, position);
        }

        /// <summary>
        /// Creates a new instance which represents this player, but with a new nickname
        /// </summary>
        /// <param name="nickname">new nickname</param>
        /// <returns></returns>
        public IPlayer ChangeNickname(string nickname)
        {
            return ChangeTo(nickname, CurrentPosition, Health, ClothingColor);
        }

        /// <summary>
        /// Creates a new instance which represents this player, but at a new location
        /// </summary>
        /// <param name="position">new location</param>
        /// <returns></returns>
        public IPlayer ChangePosition(Position.Position position)
        {
            return ChangeTo(Nickname, position, Health, ClothingColor);
        }

        /// <summary>
        /// Indicates whether the current object is equal to another object of the same type.
        /// </summary>
        /// <returns>
        /// <see langword="true"/> if the current object is equal to the <paramref name="other"/> parameter; otherwise, <see langword="false"/>.
        /// </returns>
        /// <param name="other">An object to compare with this object.
        ///                 </param>
        public bool Equals(IPlayer other)
        {
            if (ReferenceEquals(null, other))
            {
                return false;
            }
            if (ReferenceEquals(this, other))
            {
                return true;
            }
            return other.Health.Equals(Health) && other.ClothingColor.Equals(ClothingColor) && Equals(other.Nickname, Nickname) && Equals(other.CurrentPosition, CurrentPosition) && other.Id.Equals(Id);
        }

        /// <summary>
        /// Determines whether the specified <see cref="T:System.Object"/> is equal to the current <see cref="T:System.Object"/>.
        /// </summary>
        /// <returns>
        /// <see langword="true"/> if the specified <see cref="T:System.Object"/> is equal to the current <see cref="T:System.Object"/>; otherwise, <see langword="false"/>.
        /// </returns>
        /// <param name="obj">The <see cref="T:System.Object"/> to compare with the current <see cref="T:System.Object"/>. 
        ///                 </param><filterpriority>2</filterpriority>
        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj))
            {
                return false;
            }
            if (ReferenceEquals(this, obj))
            {
                return true;
            }
            return Equals(obj as Player);
        }

        /// <summary>
        /// Serves as a hash function for a particular type. 
        /// </summary>
        /// <returns>
        /// A hash code for the current <see cref="T:System.Object"/>.
        /// </returns>
        /// <filterpriority>2</filterpriority>
        public override int GetHashCode()
        {
            unchecked
            {
                int result = Health.GetHashCode();
                result = (result*397) ^ ClothingColor.GetHashCode();
                result = (result*397) ^ (Nickname != null ? Nickname.GetHashCode() : 0);
                result = (result*397) ^ (CurrentPosition != null ? CurrentPosition.GetHashCode() : 0);
                result = (result*397) ^ Id.GetHashCode();
                return result;
            }
        }

        /// <summary>
        /// checks to see if <see cref="left"/> is equal to<see cref="right"/>
        /// </summary>
        /// <param name="left"></param>
        /// <param name="right"></param>
        /// <returns></returns>
        public static bool operator ==(Player left, Player right)
        {
            return Equals(left, right);
        }

        /// <summary>
        /// checks to see if <see cref="left"/> is not equal to<see cref="right"/>
        /// </summary>
        /// <param name="left"></param>
        /// <param name="right"></param>
        /// <returns></returns>
        public static bool operator !=(Player left, Player right)
        {
            return !Equals(left, right);
        }


        /// <summary>
        /// Returns a <see cref="T:System.String"/> that represents the current <see cref="T:System.Object"/>.
        /// </summary>
        /// <returns>
        /// A <see cref="T:System.String"/> that represents the current <see cref="T:System.Object"/>.
        /// </returns>
        /// <filterpriority>2</filterpriority>
        public override string ToString()
        {
            return string.Format(Resource.PlayerToString, Nickname, Health, ClothingColor, CurrentPosition, Id);
        }

        /// <summary>
        /// Creates a new instance which represents this player, but with a new health
        /// </summary>
        /// <param name="health">new health value</param>
        /// <returns></returns>
        public IPlayer ChangeHealth(double health)
        {
            return ChangeTo(Nickname, CurrentPosition, health, ClothingColor);
        }

        /// <summary>
        /// Creates a new instance which represents this player, but with a new color
        /// </summary>
        /// <param name="color">new color</param>
        /// <returns></returns>
        public IPlayer ChangeColor(Color color)
        {
            return ChangeTo(Nickname, CurrentPosition, Health, color);
        }

        /// <summary>
        /// Creates a new instance
        /// </summary>
        /// <param name="id">The Unique identifier to be associated with this player</param>
        /// <param name="nickname">The nickname of this player</param>
        public Player(Guid id, string nickname) : this(id,nickname, DefaultClothingColor)
        {
        }

        /// <summary>
        /// Creates a new instance
        /// </summary>
        /// <param name="id">The Unique identifier to be associated with this player</param>
        /// <param name="nickname">The nickname of this player</param>
        /// <param name="clothingColor">The color associated with this player</param>
        public Player(Guid id, string nickname, Color clothingColor) : this(id, nickname, clothingColor, DefaultHealth)
        {
        }

        /// <summary>
        /// Creates a new instance
        /// </summary>
        /// <param name="id">The Unique identifier to be associated with this player</param>
        /// <param name="nickname">The nickname of this player</param>
        /// <param name="clothingColor">The color associated with this player</param>
        /// <param name="health">The current health of this player</param>
        public Player(Guid id, string nickname, Color clothingColor, double health) : this(id,nickname,clothingColor,health, DefaultPosition)
        {
        }

        /// <summary>
        /// Creates a new instance
        /// </summary>
        /// <param name="id">The Unique identifier to be associated with this player</param>
        /// <param name="nickname">The nickname of this player</param>
        /// <param name="clothingColor">The color associated with this player</param>
        /// <param name="health">The current health of this player</param>
        /// <param name="currentPosition">The current location of this player if known</param>
        public Player(Guid id, string nickname, Color clothingColor, double health, Position.Position currentPosition)
        {
            Id = id;
            Nickname = nickname;
            ClothingColor = clothingColor;
            Health = health;
            CurrentPosition = currentPosition;
        }
    }
}


