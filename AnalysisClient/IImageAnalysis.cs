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
 * 0.95     mcbridem Design change                      Renamed GetBlobs to Analyze, added players parameter.
 * 1.0      jmaxxz Misc Refactoring, Server impl      Refactored codebase, added basic server
 */
namespace Ares.Client.Analysis
{
    using System.Collections.Generic;
    using System.Drawing;
    using Common;

    /// <summary>
    /// An interface to define a class that analyzes image input for augmented reality purposes.
    /// </summary>
    public interface IImageAnalysis
    {
        /// <summary>
        /// This method scans an Image object for players and returns an <see cref="IProcessedImage"/> object.
        /// </summary>
        /// <param name="image">An image to process for blob objects.</param>
        /// <param name="players">A list of players to scan for.</param>
        /// <returns>An <see cref="IProcessedImage"/> object, which contains the image input and a list of players found.</returns>
        IProcessedImage Analyze(Bitmap image, IEnumerable<IPlayer> players);
    }
}
