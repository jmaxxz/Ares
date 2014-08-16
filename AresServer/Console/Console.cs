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
 */
using System;

namespace Ares.Server.Console
{
    public class Console
    {
        public void Log(string message, ErrorLevel errorLevel)
        {
            Log(new Message(message,errorLevel));
        }

        public void Log(Message message)
        {
            InvokeItemLogged(message);
        }

        public event EventHandler<Message> ItemLogged;

        private void InvokeItemLogged(Message message)
        {
            EventHandler<Message> handler = ItemLogged;
            if (handler != null)
            {
                handler(this, message);
            }
        }
    }

}
