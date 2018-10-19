namespace MP.UnmanagedCode.PowerManagementAPI.Models
{
    internal enum PowerInformationLevel
    {
        SystemBatteryState = 5,
        SystemReserveHiberFile = 10,
        SystemPowerInformation = 12,
        LastWakeTime = 14,
        LastSleepTime = 15
    }

    internal enum OperationStatus
    {
        Success,
        Information,
        Warning,
        Error
    }
}
