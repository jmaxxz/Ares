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
 * 0.95     jmaxxz initial development                Fully implemented every method
 * 1.0      jmaxxz Misc Refactoring, Server impl      Refactored codebase, added basic server
 */
namespace Ares.Common.Api.DataTypes
{
    using System.Drawing;
    using System;

    /// <summary>
    /// This is a mutable representation of a player. This class should not be used unless interfacing with a library
    /// that requires mutable object (like .net's built in serialization library, or WCF)
    /// </summary>
    [Serializable]
    public class MutablePlayer : IEquatable<MutablePlayer>
    {

        /// <summary>
        /// Gets or sets the current health of this instance. 
        /// </summary>
        public double Health { get; set; }

        /// <summary>
        /// Gets or sets the color associated with the player this instance represents
        /// </summary>
        public Color ClothingColor { get; set; }

        /// <summary>
        /// Gets or sets the nickname associated with this player. (Can't be <see langword="null"/>)
        /// </summary>
        public string Nickname { get; set; }

        /// <summary>
        /// Gets or sets the current location of the player, if known
        /// </summary>
        public MutablePosition CurrentPosition { get; set; }

        /// <summary>
        /// Gets or sets the unique identifier associated with the player this instance represents
        /// </summary>
        public Guid Id { get; set; }

        /// <summary>
        /// Creates a new instance with default values for all properties
        /// </summary>
        public MutablePlayer()
        {
        }

        /// <summary>
        /// Creates a new instance from an instance of <see cref="IPlayer"/>
        /// </summary>
        /// <param name="player"></param>
        public MutablePlayer(IPlayer player)
        {
            ClothingColor = player.ClothingColor;
            CurrentPosition = player.CurrentPosition.ToMutablePosition();
            Health = player.Health;
            Id = player.Id;
            Nickname = player.Nickname;
        }

        /// <summary>
        /// Creates an instance of <see cref="IPlayer"/> from the current state of this instance
        /// </summary>
        /// <returns></returns>
        public IPlayer ToIPlayer()
        {
            Position.Position position = CurrentPosition == null ?  null : CurrentPosition.ToPosition();
            return new Player(Id, Nickname,ClothingColor,Health, position);
        }

        /// <summary>
        /// Indicates whether the current object is equal to another object of the same type.
        /// </summary>
        /// <returns>
        /// <see langword="true"/> if the current object is equal to the <paramref name="other"/> parameter; otherwise, <see langword="false"/>.
        /// </returns>
        /// <param name="other">An object to compare with this object.
        ///                 </param>
        public bool Equals(MutablePlayer other)
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
            return Equals(obj as MutablePlayer);
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
                result = (result * 397) ^ ClothingColor.GetHashCode();
                result = (result * 397) ^ (Nickname != null ? Nickname.GetHashCode() : 0);
                result = (result * 397) ^ (CurrentPosition != null ? CurrentPosition.GetHashCode() : 0);
                result = (result * 397) ^ Id.GetHashCode();
                return result;
            }
        }

        /// <summary>
        /// Checks to see if <see cref="left"/> and <see cref="right"/> are equivalent.
        /// </summary>
        /// <param name="left"></param>
        /// <param name="right"></param>
        /// <returns>returns <see langword="true"/> if <see cref="left"/> and <see cref="right"/> are equivalent
        /// else <see langword="false"/> is returned</returns>
        public static bool operator ==(MutablePlayer left, MutablePlayer right)
        {
            return Equals(left, right);
        }

        /// <summary>
        /// Checks to see if <see cref="left"/> and <see cref="right"/> are equivalent.
        /// </summary>
        /// <param name="left"></param>
        /// <param name="right"></param>
        /// <returns>returns <see langword="true"/> if <see cref="left"/> and <see cref="right"/> are not equivalent
        /// else <see langword="false"/> is returned</returns>
        public static bool operator !=(MutablePlayer left, MutablePlayer right)
        {
            return !Equals(left, right);
        }
    }
}
