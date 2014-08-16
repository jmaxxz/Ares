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
    /// Base implementation for a DisplayManager.  Mutable to allow for customizable displaying.
    /// </summary>
    public class DisplayManager :IDisplayManager
    {
        /// <summary>
        /// 
        /// </summary>
        public bool DisplayTimer { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public bool DisplaySignalStrength { get; set; }

        private int _currentDeathFrame = -1;
        private int _currentFiringFrame = -1;
        private int _currentHitFrame = -1;

        /// <summary>
        /// This method generates the items to be displayed on a player's heads up display (HUD), which can
        /// includes items such as the player's health and wifi signal strength, as well as the remaining 
        /// time in the game.
        /// </summary>
        /// <param name="input">The bitmap to overlay HUD items onto.</param>
        /// <param name="currentPlayer">The current player.</param>
        /// <param name="gameTime">Time remaining in the current game.</param>
        /// <param name="wifiSignal">Client's wifi signal strength.</param>
        /// <returns>The original bitmap with the HUD overlaid on top of it.</returns>
        public Bitmap OverlayHud(IProcessedImage input, IPlayer currentPlayer, TimeSpan gameTime, SignalStrength wifiSignal)
        {
            if (currentPlayer.IsAlive)
                _currentDeathFrame = -1;

            Bitmap overlayImage = (Bitmap)input.BaseImage.Clone();
            IEnumerable<IPlayerBlob> blobs = input.Blobs;
            Point center = new Point(overlayImage.Size.Width/2, overlayImage.Size.Height/2);
            int healthModifier = (int)currentPlayer.Health/20; // Range: 5 (full) - 0 (<20)
            int wifiModifier = (int) wifiSignal.Value/25 + 1; // Range: 5 (full) - 1 (<25)

            using (Graphics g = Graphics.FromImage(overlayImage))
            using (Pen blobPen = new Pen(Color.Red, 1))
            using (Pen crosshairPen = new Pen(Color.LimeGreen, 2))
            using (Pen crosshairBorderPen = new Pen(Color.Black, 1))
            using (Pen firingPen = new Pen(Color.Yellow, 2))
            using (Pen borderPen = new Pen(Color.Black, 2))
            using (Brush healthBarBrush = new SolidBrush(Color.FromArgb(230, 34 * (5 - healthModifier), 34 * healthModifier, 0)))
            using (Font timerFont = new Font("Microsoft Sans Serif", 16F, FontStyle.Regular))
            using (Brush timerBrush = new SolidBrush(Color.Black))
            using (Brush timerBgBrush = new SolidBrush(Color.FromArgb(120, 175, 175, 175)))
            using (Brush hitBrush = new SolidBrush(Color.FromArgb(200, 255, 0, 0)))
            using (Brush wifiBrush = new SolidBrush(Color.FromArgb(230, 51 * Math.Min(6 - wifiModifier, 5), 51 * wifiModifier, 0)))
            {
                // Display blobs
                foreach(IPlayerBlob blob in blobs)
                {
                    g.DrawRectangle(blobPen, blob.BaseBlob.Position.X, blob.BaseBlob.Position.Y, blob.BaseBlob.Dimension.Width, blob.BaseBlob.Dimension.Height);
                }

                // Display crosshair
                g.DrawLine(crosshairPen, center.X + 10, center.Y, center.X + 3, center.Y);
                g.DrawRectangle(crosshairBorderPen, center.X + 3, center.Y - 1, 7, 2);
                g.DrawLine(crosshairPen, center.X - 3, center.Y, center.X - 10, center.Y);
                g.DrawRectangle(crosshairBorderPen, center.X - 10, center.Y - 1, 7, 2);
                g.DrawLine(crosshairPen, center.X, center.Y + 10, center.X, center.Y + 3);
                g.DrawRectangle(crosshairBorderPen, center.X - 1, center.Y + 3, 2, 7);
                g.DrawLine(crosshairPen, center.X, center.Y - 3, center.X, center.Y - 10);
                g.DrawRectangle(crosshairBorderPen, center.X - 1, center.Y - 10, 2, 7);

                // Display firing indicator
                if(_currentFiringFrame >= 0)
                {
                    g.DrawEllipse(firingPen, center.X - 10 + _currentFiringFrame*2, center.Y - 10 + _currentFiringFrame*2, 20 - _currentFiringFrame*4, 20 - _currentFiringFrame*4);

                    if (_currentFiringFrame++ > 3)
                        _currentFiringFrame = -1;
                }

                // Display health
                int seventyPercent = (int) (overlayImage.Width * 7.0 / 10.0);
                g.DrawRectangle(borderPen, center.X - seventyPercent / 2, overlayImage.Height - 35, seventyPercent, 10);
                g.FillRectangle(healthBarBrush, center.X - seventyPercent / 2, overlayImage.Height - 35, (int) (seventyPercent * (currentPlayer.Health / 100.0)), 10);

                // Display timer
                if (DisplayTimer)
                {
                    int timerBoxBound = overlayImage.Width * 29 / 400;
                    g.DrawRectangle(borderPen, center.X - timerBoxBound, 5, timerBoxBound * 2, 25);
                    g.FillRectangle(timerBgBrush, center.X - timerBoxBound, 5, timerBoxBound * 2, 25);
                    g.DrawString(gameTime.ToString(), timerFont, timerBrush, center.X - timerBoxBound, 5);
                }

                // Display wifi signal
                if (DisplaySignalStrength)
                {
                    if (wifiSignal.Value > 85)
                        g.FillRectangle(wifiBrush, overlayImage.Width - 10, 5, 5, 20);
                    if (wifiSignal.Value > 70)
                        g.FillRectangle(wifiBrush, overlayImage.Width - 17, 9, 5, 16);
                    if (wifiSignal.Value > 55)
                        g.FillRectangle(wifiBrush, overlayImage.Width - 24, 13, 5, 12);
                    if (wifiSignal.Value > 40)
                        g.FillRectangle(wifiBrush, overlayImage.Width - 31, 17, 5, 8);
                    if (wifiSignal.Value > 25)
                        g.FillRectangle(wifiBrush, overlayImage.Width - 38, 21, 5, 4);
                }

                // Display being hit
                if(_currentHitFrame >= 0)
                {
                    g.FillEllipse(hitBrush, 15, 15, 15, overlayImage.Height - 30);
                    g.FillEllipse(hitBrush, overlayImage.Width - 30, 15, 15, overlayImage.Height - 30);

                    if (_currentHitFrame++ > 10)
                        _currentHitFrame = -1;
                }

            }

            return overlayImage;
        }

        /// <summary>
        /// This method overlays the overall score display onto the bitmap.  The overall score display is,
        /// at minimum, a list of the players in the current game and their score.
        /// </summary>
        /// <param name="input">The bitmap to overlay the display onto.</param>
        /// <param name="players">An ordered list of players to display, in order of current ranking.</param>
        /// <returns>The original bitmap with the score display overlaid onto it.</returns>
        public Bitmap OverlayScoreDisplay(Bitmap input, IEnumerable<IPlayer> players)
        {
            Bitmap overlayImage = (Bitmap)input.Clone();
            Point center = new Point(overlayImage.Size.Width/2, overlayImage.Size.Height/2);

            using (Graphics g = Graphics.FromImage(overlayImage))
            using (Brush tableBgBrush = new SolidBrush(Color.FromArgb(200, 200, 200, 200)))
            using (Font timerFont = new Font("Microsoft Sans Serif", 16F, FontStyle.Regular))
            using (Brush textBrush = new SolidBrush(Color.Black))
            {
                g.FillRectangle(tableBgBrush, 60, 40, overlayImage.Width - 120, overlayImage.Height - 80);
                
                g.DrawString("SCORE", timerFont, textBrush, center.X - 40, 43);

                int rankingCounter = 1;
                foreach(IPlayer player in players)
                {
                    g.DrawString(rankingCounter++ + " " + player.Nickname, timerFont, textBrush, 63, 43 + rankingCounter * 25);
                }
            }

            return overlayImage;
        }

        /// <summary>
        /// Modifies the input image in such a way so that the user has visual confirmation that they are
        /// currently dead.
        /// </summary>
        /// <param name="input">The bitmap to overlay the notification on to.</param>
        /// <param name="message">The message to display on the screen.</param>
        /// <returns>The original bitmap with the death notification overlaid onto it.</returns>
        public Bitmap OverlayDeadDisplay(Bitmap input, string message)
        {
            Bitmap overlayImage = (Bitmap)input.Clone();

            using (Graphics g = Graphics.FromImage(overlayImage))
            using (Brush bgBrush = new SolidBrush(Color.FromArgb(180, 200, 0, 0)))
            using (Font messageFont = new Font("Microsoft Sans Serif", 16F, FontStyle.Regular))
            using (Brush textBrush = new SolidBrush(Color.Black))
            {
                g.FillRectangle(bgBrush, 0, 0, overlayImage.Width, overlayImage.Height);
                string[] messageLines = message.Split('\n');
                int maxLength = messageLines[0].Length;
                for (int i = 1; i < messageLines.Length; i++)
                    maxLength = Math.Max(maxLength, messageLines[i].Length);
                int messageOffset = maxLength * 13 / 2;
                g.DrawString(message, messageFont, textBrush, (overlayImage.Width / 2) - messageOffset, (overlayImage.Height / 2) - 25);
            }

            return overlayImage;
        }

        /// <summary>
        /// This method informs the overlay manager to start/restart the animation for taking damage.  The
        /// animation has a fixed length, and this flag will reset itself with time.  If this method is
        /// called while the animation is already playing, the animation should restart.
        /// </summary>
        public void TriggerDamageTaken()
        {
            _currentHitFrame = 0;
        }

        /// <summary>
        /// 
        /// </summary>
        public void TriggerFiredShot()
        {
            _currentFiringFrame = 0;
        }
    }
}
