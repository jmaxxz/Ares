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
 * 0.95     jmaxxz initial development                Fully implemented
 * 0.95     jmaxxz namespace change                   changed namespace
 */
namespace Ares.Client.Network.WiFi.Demo
{
    using System.Threading;
    using Common.ReflectUI;
    using Common.Network;
    using System;

    /// <summary>
    /// This is a demo program which shows the use the use of <see cref="WiFiStrengthMonitor"/> to monitor a WiFi connection
    /// </summary>
    class Program
    {

        [STAThread]
        static void Main()
        {
            IWirelessStrengthMonitor wifi = new WiFiStrengthMonitor(500);
            while (true)
            {
                Console.Clear();
                Console.Write(ReflectTools.ReflectToString(wifi, @"IWirelessStrengthMonitor"));
                Thread.Sleep(1000/60);
            }
        }
    }
}