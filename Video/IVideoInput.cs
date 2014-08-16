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
 * 0.95     curtisk   Initial development                Interface Design
 * 0.95     jmaxxz should really require disposable   Requires IDisposable to be implemented
 */
namespace Ares.Common.Video
{
    using System;
    

    /// <summary>
    /// Describes a class defining the video input from a webcam and 
    /// an event driven video capture system which updates the current frame the player is seeing
    /// </summary>
    public interface IVideoInput : IDisposable
    {
        /// <summary>
        /// This event will be fired when the video input has a new frame.
        /// </summary>
        event VideoUpdate VideoEventHandler;
        
        /// <summary>
        ///  Starts the webcam and displaying the video stream
        ///  </summary>
        void Start();

        /// <summary>
        ///  Stops the  webcam and displaying the video stream
        ///  </summary>
        void Stop();
    }
    
    /// <summary>
    /// The delegate type definition which will be called when the video input has a new frame
    /// </summary>
    /// <param name="sender">The class which caused the event to be fired</param>
    /// <param name="frame">The Frame details</param>
    public delegate void VideoUpdate(object sender, Frame frame);

}


