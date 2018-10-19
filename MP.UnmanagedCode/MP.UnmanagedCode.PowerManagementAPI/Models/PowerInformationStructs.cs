using System;

namespace MP.UnmanagedCode.PowerManagementAPI.Models
{
    public struct SystemBatteryState
    {
        public bool AcOnLine { get; internal set; }
        public bool BatteryPresent { get; internal set; }
        public bool Charging { get; internal set; }
        public bool Discharging { get; internal set; }
        public bool Spare { get; internal set; }
        public byte Tag { get; internal set; }
        public uint MaxCapacity { get; internal set; }
        public uint RemainingCapacity { get; internal set; }
        public uint Rate { get; internal set; }
        public uint EstimatedTime { get; internal set; }
        public uint DefaultAlert1 { get; internal set; }
        public uint DefaultAlert2 { get; internal set; }
    }

    public struct SystemPowerInformation
    {
        public ulong MaxIdlenessAllowed { get; internal set; }
        public ulong Idleness { get; internal set; }
        public ulong TimeRemaining { get; internal set; }
        public ulong CoolingMode { get; internal set; }
    }
}
