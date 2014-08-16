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
 * 0.95     jmaxxz interface change                   added dispose method
 * 1.0      jmaxxz bug 294                            gaurded optional data getters with try blocks
 * 1.0      jmaxxz bug 425                            Clean up internal timer on dispose.
 */
using System;

namespace Ares.Client.Network.WiFi
{
    using System.ComponentModel;
    using Common.Network;
    using System.Timers;
    using System.Text;
    using NativeWifi;

    /// <summary>
    /// An implementation of <see cref="IWirelessStrengthMonitor"/> which uses the ManagedWifi library
    /// to monitor the WiFi connection Strength 
    /// </summary>
    public class WiFiStrengthMonitor : IWirelessStrengthMonitor
    {
        private readonly Timer _timer;
        private readonly WlanClient _client;

        /// <summary>
        /// The current strength of the active wifi connection. 
        /// </summary>
        public SignalStrength Strength { get; private set; }

        /// <summary>
        /// The ssid of the active wifi connection. 
        /// </summary>
        public string Ssid { get; private set; }

        /// <summary>
        /// The upload rate of the connection in Mb/s
        /// </summary>
        public double UploadRate { get; private set; }

        /// <summary>
        /// The download rate of the connection in Mb/s
        /// </summary>
        public double DownloadRate { get; private set; }

        /// <summary>
        /// The download rate of the connection in kb/s
        /// </summary>
        public int Channel { get; private set; }

        /// <summary>
        /// The active wifi adapter 
        /// </summary>
        public string Adapter { get; private set; }

        /// <summary>
        /// Creates a new instance which updates internally every <see cref="updateRate"/>ms
        /// </summary>
        /// <param name="updateRate">The refresh rate of <see cref="Strength"/> in milliseconds</param>
        public WiFiStrengthMonitor(uint updateRate)
        {
            _client = new WlanClient();
            Update();

            _timer = new Timer(updateRate);
            
            _timer.Elapsed += Update;
            _timer.Start();
        }

        /// <summary>
        /// Fetches and caches value to be returned for <see cref="Strength"/>
        /// </summary>
        private void Update()
        {
            bool updated = false;
            
            //Iterate over all wireless interfaces and use the first one that is connected to a network
            foreach (WlanClient.WlanInterface wlanIface in _client.Interfaces)
            {
                if (!updated)
                {
                    updated = UpdateFromInterface(wlanIface);
                }
            }

            //If a wireless interface which is connected to a network can not be found set strength to zero
            if (!updated)
            {
                Reset();
            }
        }

        /// <summary>
        /// Defaults status of wireless connection. (default is no connection)
        /// </summary>
        private void Reset()
        {
            Strength = new SignalStrength(0);
            Adapter = string.Empty;
            Channel = -1;
            UploadRate = 0;
            DownloadRate = 0;
            Ssid = string.Empty;
        }

        /// <summary>
        /// Attempts to update local values concerning the status of the active connection using a passed in wireless interface.
        /// </summary>
        /// <param name="wlanIface">The interface to be used</param>
        /// <returns>Returns <see langword="true"/> if update is completed, <see langword="false"/> when interface is not connected, or unable to be used for update</returns>
        private bool UpdateFromInterface(WlanClient.WlanInterface wlanIface)
        {
            //Check if interface is connected
            if (wlanIface.InterfaceState == Wlan.WlanInterfaceState.Connected)
            {
                try
                {
                    Strength = new SignalStrength(wlanIface.CurrentConnection.wlanAssociationAttributes.wlanSignalQuality);
                    TrySsidUpdate(wlanIface);
                    TryRateUpdate(wlanIface);
                    TryChannelUpdate(wlanIface);
                    TryAdapterUpdate(wlanIface);

                    return true;
                }
                catch (Win32Exception e)
                {
                    //This exception occurs if wifi is disabled midupdate, can be ignored
                    if (e.NativeErrorCode != 5023)
                    {
                        throw;
                    }

                    Reset();
                }
            }

            return false;
        }

        /// <summary>
        /// Tries to update <see cref="Adapter"/>. Exceptions are ignored
        /// </summary>
        /// <param name="wlanIface">Interface to be updated from</param>
        private void TryAdapterUpdate(WlanClient.WlanInterface wlanIface)
        {
            try
            {
                Adapter = wlanIface.InterfaceName;
            }
            catch (Exception)
            {
            }
        }

        /// <summary>
        /// Tries to update <see cref="Channel"/>. Exceptions are ignored
        /// </summary>
        /// <param name="wlanIface">Interface to be updated from</param>
        private void TryChannelUpdate(WlanClient.WlanInterface wlanIface)
        {
            try
            {
                Channel = wlanIface.Channel;
            }
            catch (Exception)
            {
            }
        }

        /// <summary>
        /// Tries to update <see cref="UploadRate"/> and <see cref="DownloadRate"/>. Exceptions are ignored
        /// </summary>
        /// <param name="wlanIface">Interface to be updated from</param>
        private void TryRateUpdate(WlanClient.WlanInterface wlanIface)
        {
            try
            {
                UploadRate = wlanIface.CurrentConnection.wlanAssociationAttributes.txRate / 1000.0;
                DownloadRate = wlanIface.CurrentConnection.wlanAssociationAttributes.rxRate / 1000.0;
            }
            catch (Exception)
            {
            }
        }

        /// <summary>
        /// Tries to update <see cref="Ssid"/>. Exceptions are ignored
        /// </summary>
        /// <param name="wlanIface">Interface to be updated from</param>
        private void TrySsidUpdate(WlanClient.WlanInterface wlanIface)
        {
            try
            {
                Wlan.Dot11Ssid dotSsid = wlanIface.CurrentConnection.wlanAssociationAttributes.dot11Ssid;
                Ssid = new string(Encoding.ASCII.GetChars(dotSsid.SSID, 0, (int)dotSsid.SSIDLength));
            }
            catch (Exception)
            {
            }
        }

        /// <summary>
        /// Handles timer events, triggers an update of <see cref="Strength"/>
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="elapsedEventArgs"></param>
        private void Update(object sender, ElapsedEventArgs elapsedEventArgs)
        {
            Update();
        }

        /// <summary>
        /// Performs application-defined tasks associated with freeing, releasing, or resetting unmanaged resources.
        /// </summary>
        /// <filterpriority>2</filterpriority>
        public void Dispose()
        {
            _timer.Stop();
            _timer.Dispose();
        }
    }
}
