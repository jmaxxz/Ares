/*
 *  Ares, a multi-player augmented reality first person shooter
 *  Copyright (C) 2009-2010  Jmaxxz, Mike McBride, and Kevin Curtis
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
 * 0.95     mcbridem Initial development                Fully defined every method
 */

using System.Drawing;

namespace Ares.Client.Analysis
{
    /// <summary>
    /// An interface to define a Blob object, which is a grouping of similarly colored pixels in an image, to 
    /// within a certain tolerance.
    /// </summary>
    public interface IBlob
    {
        /// <summary>
        /// Returns a Size object representing the width and height of the bounding box that surrounds the blob.
        /// </summary>
        Size Dimension { get; }

        /// <summary>
        /// Returns a two-dimensional Point object representing the upper left corner of the bounding box 
        /// (<see cref="Dimension"/>).
        /// </summary>
        Point Position { get; }

        /// <summary>
        /// Returns the number of pixels in the blob.
        /// </summary>
        int Size { get; }

        /// <summary>
        /// Returns the center of the blob within the bounding box, which is not necessarily the center of the box.
        /// The coordinates are in reference to
        /// </summary>
        Point Center { get; }

        /// <summary>
        /// Returns the color at the center of the blob.
        /// </summary>
        Color Color { get; }
    }
}
