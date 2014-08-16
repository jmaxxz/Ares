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
 * 0.95     mcbridem Design change                      Removed GetBlobCount method for redundancy, changed type
 *                                                      on Blobs to an IEnumerable containing IPlayerBlob objects.
 */

using System.Collections.Generic;
using System.Drawing;

namespace Ares.Client.Analysis
{
    /// <summary>
    /// An interface for a Processed Image object, which contains an Image object and the blobs contained within
    /// it that represent players in the game.
    /// </summary>
    public interface IProcessedImage
    {
        /// <summary>
        /// The base Image object used to find the blobs, for reference and display purposes.
        /// </summary>
        Bitmap BaseImage { get; }

        /// <summary>
        /// The array of blobs contained in the image that represent players.
        /// </summary>
        IEnumerable<IPlayerBlob> Blobs { get; }
    }
}
