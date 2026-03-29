using System;
using System.Collections.Generic;

namespace NetworkStatistics
{
    public class NetworkInfo
    {
        public string SSID { get; set; }
        public string BSSID { get; set; }
        public string SignalStrength { get; set; }
        public string EncryptionType { get; set; }
        public DateTime LastConnected { get; set; }
    }

    public class DeviceInfo
    {
        public string DeviceName { get; set; }
        public string MACAddress { get; set; }
        public string IPAddress { get; set; }
        public string OperatingSystem { get; set; }
        public DateTime LastUpdated { get; set; }
    }
}