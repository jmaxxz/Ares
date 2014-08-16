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
 * Change log
 * 
 * Version | Author | Reason for change                | Description of change
 * -------- -------- ---------------------------------- ------------------------------------------------------
 * 0.95     mcbridem Initial development                Fully defined every method
 * 1.0      jmaxxz Optimization attempt               Merged HSL, GS and Dilation + more parrelization
 * 1.0      jmaxxz Too much coupling to Aforge        Conversion is now down in constructor, additional constructor was added to allow for the manual creation of a blob.
 * 1.0      mcbridem Typos, Bitmap removal              Removed redundant Area property and _baseImage attribute, fixed comment typos.
 */
namespace Ares.Client.Analysis
{
    using System.Drawing;

    /// <summary>
    /// A blob is a group of connected pixels of the same relative color in an image.
    /// </summary>
    public class Blob :IBlob
    {
        /// <summary>
        /// This constructor takes in the AForge Blob object to interact with.
        /// </summary>
        /// <param name="baseBlob"><see cref="AForge.Imaging.Blob"/> object to interface with.</param>
        /// <param name="color">The color of the blob.</param>
        public Blob(AForge.Imaging.Blob baseBlob, Color color)
        {
            Center = new Point(baseBlob.CenterOfGravity.X, baseBlob.CenterOfGravity.Y);
            Dimension = baseBlob.Rectangle.Size;
            Position = baseBlob.Rectangle.Location;
            Size = baseBlob.Area;
            Color = color;
        }

        /// <summary>
        /// Creates a new representation of a blob.
        /// </summary>
        /// <param name="center">The center of the blob.</param>
        /// <param name="dimension">The size of the rectangle which encloses the blob</param>
        /// <param name="position">The position of the rectangle (upper left corner) within the base image</param>
        /// <param name="area">The total area occupied by the blob</param>
        /// <param name="color">The color of the blob.</param>
        public Blob(Point center, Size dimension, Point position, int area, Color color)
        {
            Center = center;
            Dimension = dimension;
            Position = position;
            Size = area;
            Color = color;
        }

        /// <summary>
        /// This constructor takes in the Blob object to interact with.
        /// </summary>
        /// <param name="baseBlob">An existing blob.</param>
        /// <param name="color">The color of the blob.</param>
        public Blob(IBlob baseBlob, Color color)
            : this(baseBlob.Center, baseBlob.Dimension, baseBlob.Position, baseBlob.Size, color)
        {
        }

        /// <summary>
        /// Returns a Size object representing the width and height of the bounding box that surrounds the blob.
        /// </summary>
        public Size Dimension { get; private set; }

        /// <summary>
        /// Returns a two-dimensional Point object representing the upper left corner of the bounding box 
        /// (see <see cref="Dimension"/>).
        /// </summary>
        public Point Position { get; private set; }

        /// <summary>
        /// Returns the number of pixels in the blob.
        /// </summary>
        public int Size { get; private set; }

        /// <summary>
        /// Returns the center of the blob within the bounding box, which is not necessarily the center of the box.
        /// The coordinates are in reference to the upper left corner of the base image.
        /// </summary>
        public Point Center { get; private set; }

        /// <summary>
        /// Returns the color of the blob.
        /// </summary>
        public Color Color { get; private set; }
    }
}
