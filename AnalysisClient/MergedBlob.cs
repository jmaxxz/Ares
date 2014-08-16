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
 * 1.00     mcbridem Initial development                Fully defined every method
 * 1.00     mcbridem Color initialization               Color was initially not set in the constructor due to locking problems with
 *                                                      the Blob object's locally stored bitmap, but now that the Blob no longer 
 *                                                      stores a bitmap locally, the color can be set as normal.
 */

using System;
using System.Collections.Generic;
using System.Drawing;

namespace Ares.Client.Analysis
{
    /// <summary>
    /// Class for managing merged blobs.  Provides a methodology for merging a blob with one or more other blobs.
    /// </summary>
    class MergedBlob :IBlob
    {
        /// <summary>
        /// Initializes the base for the merged blob.
        /// </summary>
        /// <param name="baseBlob">The blob object to inherit properties from.</param>
        public MergedBlob(IBlob baseBlob)
        {
            Dimension = baseBlob.Dimension;
            Position = baseBlob.Position;
            Size = baseBlob.Size;
            Center = baseBlob.Center;
            Color = baseBlob.Color;
        }

        /// <summary>
        /// Initializes a base blob and then adds in the specified list of blobs.
        /// </summary>
        /// <param name="baseBlob">The blob object to inherit properties from.</param>
        /// <param name="blobList">A list of blobs to merge with the base blob.</param>
        public MergedBlob(IBlob baseBlob, IEnumerable<IBlob> blobList)
        {
            Dimension = baseBlob.Dimension;
            Position = baseBlob.Position;
            Size = baseBlob.Size;
            Center = baseBlob.Center;
            Color = baseBlob.Color;

            foreach (var blob in blobList)
            {
                AddBlob(blob);
            }
        }

        /// <summary>
        /// Merges a blob with the properties of the existing blob.
        /// </summary>
        /// <param name="blob">The blob to merge into the current blob.</param>
        public void AddBlob(IBlob blob)
        {
            // Set the position
            Point pos = new Point
                            {
                                X = Math.Min(blob.Position.X, Position.X),
                                Y = Math.Min(blob.Position.Y, Position.Y)
                            };
            Position = pos;

            // Sets the dimensions
            Size dim = new Size
                           {
                               Width =
                                   Math.Max(blob.Position.X + blob.Dimension.Width, Position.X + Dimension.Width) -
                                   Position.X,
                               Height =
                                   Math.Max(blob.Position.Y + blob.Dimension.Height, Position.Y + Dimension.Height) -
                                   Position.Y
                           };
            Dimension = dim;

            // Modifies the size
            Size += blob.Size;

            // Move center naively to center of merged blob rectangle
            Point cen = new Point {X = Position.X + Dimension.Width/2, Y = Position.Y + Dimension.Height/2};
            Center = cen;

            // Color remains unchanged
        }

        /// <summary>
        /// Returns a Size object representing the width and height of the bounding box that surrounds the blob.
        /// </summary>
        public Size Dimension { get; private set; }

        /// <summary>
        /// Returns a two-dimensional Point object representing the upper left corner of the bounding box 
        /// (<see cref="Dimension"/>).
        /// </summary>
        public Point Position { get; private set; }

        /// <summary>
        /// Returns the number of pixels in the blob.
        /// </summary>
        public int Size { get; private set; }

        /// <summary>
        /// Returns the center of the blob within the bounding box, which is not necessarily the center of the box.
        /// The coordinates are in reference to
        /// </summary>
        public Point Center { get; private set;  }

        /// <summary>
        /// Returns the color at the center of the blob.
        /// </summary>
        public Color Color { get; private set;  }
    }
}
