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
 * 0.95     mcbridem Design change                      Changed Blobs to be an IEnumerable of IPlayerBlobs from
 *                                                      IProcessedImage change, added RawBlobs property for debugging.
 * 1.00     mcbridem Debug removal                      Removed the previously added accessors for the multiple
 *                                                      filtering step bitmaps.
 */

using System.Collections.Generic;
using System.Drawing;

namespace Ares.Client.Analysis
{
    /// <summary>
    /// A processed image contains a base image the blobs found within it. Immutable.
    /// </summary>
    public class ProcessedImage :IProcessedImage
    {
        /// <summary>
        /// Default constructor.
        /// </summary>
        /// <param name="image">The base image for the object, accessible through the BaseImage property.</param>
        /// <param name="blobs">The array of blobs found in the image, accessible through the Blobs property.</param>
        public ProcessedImage(Bitmap image, IEnumerable<IPlayerBlob> blobs)
        {
            BaseImage = image;
            Blobs = blobs;
            RawBlobs = new List<IBlob>();
        }

        /// <summary>
        /// Debugging constructor.
        /// </summary>
        /// <param name="image">The base image for the object, accessible through the BaseImage property.</param>
        /// <param name="blobs">The array of blobs found in the image, accessible through the Blobs property.</param>
        /// <param name="rawBlobs">The array of blobs found in the image, accessible through the RawBlobs property.</param>
        public ProcessedImage(Bitmap image, IEnumerable<IPlayerBlob> blobs, IEnumerable<IBlob> rawBlobs)
        {
            BaseImage = image;
            Blobs = blobs;
            RawBlobs = rawBlobs;
        }

        /// <summary>
        /// The base Image object used to find the blobs, for reference and display purposes.
        /// </summary>
        public Bitmap BaseImage { get; private set; }

        /// <summary>
        /// The array of blobs contained in the image that represent players.
        /// </summary>
        public IEnumerable<IPlayerBlob> Blobs { get; private set; }

        /// <summary>
        /// The array of blobs contained in the image.
        /// </summary>
        public IEnumerable<IBlob> RawBlobs { get; private set; }
    }
}
