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
 * 1.00     mcbridem Initial development                Fully defined every method
 */

namespace Ares.Client.Display
{
    using System;
    using System.Collections.Generic;
    using System.Drawing;
    using Common;
    using Common.Network;
    using Analysis;

    /// <summary>
    /// Interface for creating a class that manages the displays required to know the current game state.
    /// </summary>
    interface IDisplayManager
    {
        /// <summary>
        /// This method generates the items to be displayed on a player's heads up display (HUD), which can
        /// includes items such as the player's health and wifi signal strength, as well as the remaining 
        /// time in the game.
        /// </summary>
        /// <param name="input">The image information containing the base bitmap and blob locations.</param>
        /// <param name="currentPlayer">The current player.</param>
        /// <param name="gameTime">Time remaining in the current game.</param>
        /// <param name="wifiSignal">Client's wifi signal strength.</param>
        /// <returns>The original bitmap with the HUD overlaid on top of it.</returns>
        Bitmap OverlayHud(IProcessedImage input, IPlayer currentPlayer, TimeSpan gameTime, SignalStrength wifiSignal);

        /// <summary>
        /// This method overlays the overall score display onto the bitmap.  The overall score display is,
        /// at minimum, a list of the players in the current game and their score.
        /// </summary>
        /// <param name="input">The bitmap to overlay the display onto.</param>
        /// <param name="players">An ordered list of players to display, in order of current ranking.</param>
        /// <returns>The original bitmap with the score display overlaid onto it.</returns>
        Bitmap OverlayScoreDisplay(Bitmap input, IEnumerable<IPlayer> players);

        /// <summary>
        /// Modifies the input image in such a way so that the user has visual confirmation that they are
        /// currently dead.
        /// </summary>
        /// <param name="input">The bitmap to overlay the notification on to.</param>
        /// <param name="message">The message to display on the screen.</param>
        /// <returns>The original bitmap with the death notification overlaid onto it.</returns>
        Bitmap OverlayDeadDisplay(Bitmap input, string message);

        /// <summary>
        /// This method informs the overlay manager to start/restart the animation for taking damage.  The
        /// animation has a fixed length, and this flag will reset itself with time.  If this method is
        /// called while the animation is already playing, the animation should restart.
        /// </summary>
        void TriggerDamageTaken();

        /// <summary>
        /// 
        /// </summary>
        void TriggerFiredShot();
    }
}
