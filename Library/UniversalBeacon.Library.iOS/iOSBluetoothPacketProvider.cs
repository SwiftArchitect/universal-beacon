using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using Foundation;
using UniversalBeacon.Library.Core.Interfaces;
using UniversalBeacon.Library.Core.Interop;

namespace UniversalBeacon.Library
{
    public class iOSBluetoothPacketProvider : NSObject, IBluetoothPacketProvider
    {
        public event EventHandler<BLEAdvertisementPacketArgs> AdvertisementPacketReceived;
        public event EventHandler<BTError> WatcherStopped;

        public iOSBluetoothPacketProvider()
        {
            Debug.WriteLine("BluetoothPacketProvider()");
        }

        public void Start()
        {
            Debug.WriteLine("BluetoothPacketProvider:Start()");
        }

        public void Stop()
        {
            Debug.WriteLine("BluetoothPacketProvider:Stop()");
        }
    }
}
