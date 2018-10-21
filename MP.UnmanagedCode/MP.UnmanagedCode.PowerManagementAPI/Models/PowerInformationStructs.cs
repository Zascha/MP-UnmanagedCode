using System;
using System.Runtime.InteropServices;

namespace MP.UnmanagedCode.PowerManagementAPI.Models
{
    public struct SystemBatteryState
    {
        public bool AcOnLine;
        public bool BatteryPresent;
        public bool Charging;
        public bool Discharging;
        public bool Spare;
        public byte Tag;
        public uint MaxCapacity;
        public uint RemainingCapacity;
        public uint Rate;
        public uint EstimatedTime;
        public uint DefaultAlert1;
        public uint DefaultAlert2;
    }

    public struct SystemPowerInformation
    {
        public ulong MaxIdlenessAllowed;
        public ulong Idleness;
        public ulong TimeRemaining;
        public ulong CoolingMode;
    }
}
