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
 * 
 * Change log
 * 
 * Version | Author | Reason for change                | Description of change
 * -------- -------- ---------------------------------- ------------------------------------------------------
 * 1.00     mcbridem Initial development                Fully defined every method
 */

namespace Ares.Client.Network.WiFi
{
    using Common.Network;

    /// <summary>
    /// Adapter for client machines that do not have wireless NICs.
    /// </summary>
    class MockWifiStrengthMonitor : IWirelessStrengthMonitor
    {
        /// <summary>
        /// Creates a MockWifiStrengthMonitor with a static <see cref="SignalStrength"/>.
        /// </summary>
        /// <param name="value">The strength of the wireless signal this mock object will hold.</param>
        public MockWifiStrengthMonitor(double value)
        {
            Strength = new SignalStrength(value);
        }

        /// <summary>
        /// Performs application-defined tasks associated with freeing, releasing, or resetting unmanaged resources.
        /// </summary>
        /// <filterpriority>2</filterpriority>
        public void Dispose()
        {
            // No resources
        }

        /// <summary>
        /// The current strength of the active wireless connection.
        /// </summary>
        public SignalStrength Strength
        {
            get; private set;
        }
    }
}
