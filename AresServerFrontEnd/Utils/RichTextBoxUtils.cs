/*
 *  Ares, a multi-player augmented reality first person shooter
 *  Copyright (C) 2010  Jmaxxz, Mike McBride, and Kevin Curtis
 * 
 *  This program is free software; you can redistribute it and/or modify
 *  it under the terms of the GNU General Public License as published by
 *  the Free Software Foundation; either version 2 of the License, or
 *  (at your option) any later version.
 * 
 *  This program is distributed in the hope that it will be useful,
 *  but WITHOUT ANY WARRANTY; without even the implied warranty of
 *  MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
 *  GNU General Public License for more details.
 *  You should have received a copy of the GNU General Public License along
 *  with this program; if not, write to the Free Software Foundation, Inc.,
 *  51 Franklin Street, Fifth Floor, Boston, MA 02110-1301 USA.
 *  
 * 
 * Change log
 * 
 * Version | Author | Reason for change                | Description of change
 * -------- -------- ---------------------------------- ------------------------------------------------------
 * 1.0      jmaxxz initial development                Fully implemented every method
 */
namespace Ares.Server.Utils
{
    using System.Drawing;
    using System.Windows.Forms;

    /// <summary>
    /// Provides static helper methods for <see cref="RichTextBox"/> objects.
    /// </summary>
    public static class RichTextBoxUtils
    {
        /// <summary>
        /// Appends <see cref="text"/> of color <see cref="color"/> to <see cref="richTextBox"/>.
        /// </summary>
        /// <param name="richTextBox">The <see cref="RichTextBox"/> to which <see cref="text"/> should be appended.</param>
        /// <param name="text">The text to be appended.</param>
        /// <param name="color">The color of the text to be appended</param>
        public static void AppendColoredText(this RichTextBox richTextBox, string text, Color color)
        {
            int intialLength = richTextBox.TextLength;
            richTextBox.AppendText(text);
            richTextBox.Select(intialLength, richTextBox.TextLength);
            richTextBox.SelectionColor = color;
            richTextBox.DeselectAll();
        }
    }
}
