using System;
using Foundation;
using UniversalBeacon.Library.Core.Interfaces;
using UniversalBeacon.Library.Core.Interop;

namespace UniversalBeacon.Library
{
    public class IOSBluetoothPacketProvider : NSObject, IBluetoothPacketProvider
    {
        public event EventHandler<BLEAdvertisementPacketArgs> AdvertisementPacketReceived;
        public event EventHandler<BTError> WatcherStopped;

        public IOSBluetoothPacketProvider()
        {
        }

        public void Start()
        {
            throw new NotImplementedException();
        }

        public void Stop()
        {
            throw new NotImplementedException();
        }
    }
}
