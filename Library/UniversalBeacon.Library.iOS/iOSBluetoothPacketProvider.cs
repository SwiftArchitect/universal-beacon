using System;
using CoreBluetooth;
using Foundation;
using UniversalBeacon.Library.Core.Interfaces;
using UniversalBeacon.Library.Core.Interop;

namespace UniversalBeacon.Library
{
    public class iOSBluetoothPacketProvider : NSObject, IBluetoothPacketProvider
    {
        public event EventHandler<BLEAdvertisementPacketArgs> AdvertisementPacketReceived;
        public event EventHandler<BTError> WatcherStopped;

        private readonly BluetoothCentralDelegate bluetoothCentralDelegate;
        private readonly CBCentralManager bluetoothCentralManager;

        public iOSBluetoothPacketProvider()
        {
            bluetoothCentralDelegate = new BluetoothCentralDelegate();
            bluetoothCentralManager = new CBCentralManager(bluetoothCentralDelegate, null);
        }

        private void ScanCallback_OnAdvertisementPacketReceived(object sender, BLEAdvertisementPacketArgs e)
        {
            AdvertisementPacketReceived?.Invoke(this, e);
        }

        public void Start()
        {
            bluetoothCentralManager.ScanForPeripherals(serviceUuid: null);
        }


        public void Stop()
        {
            bluetoothCentralManager.StopScan();
            WatcherStopped?.Invoke(sender: this, e: new BTError(BTError.BluetoothError.Success));
        }
    }

    internal class BluetoothCentralDelegate : CBCentralManagerDelegate
    {
        #region CBCentralManagerDelegate
        public override void DiscoveredPeripheral(CBCentralManager central, CBPeripheral peripheral, NSDictionary advertisementData, NSNumber RSSI)
        {
        }

        public override void UpdatedState(CBCentralManager central)
        {
            switch (central.State)
            {
                case CBCentralManagerState.Unknown:
                    break;
                case CBCentralManagerState.Resetting:
                    break;
                case CBCentralManagerState.Unsupported:
                    break;
                case CBCentralManagerState.Unauthorized:
                    break;
                case CBCentralManagerState.PoweredOff:
                    break;
                case CBCentralManagerState.PoweredOn:
                    break;
                default:
                    throw new NotImplementedException();
            }
        }
        #endregion CBCentralManagerDelegate
    }
}
