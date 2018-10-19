using System.Runtime.InteropServices;
using MP.UnmanagedCode.PowerManagementAPI.Models;

namespace MP.UnmanagedCode.PowerManagementAPI.ComInterfaces
{
    [ComVisible(true)]
    [Guid("BBC61B74-27F4-43B0-982C-3D67846B7AE9")]
    public interface IPowerInformationManager
    {
        double LastSleepTime { get; }

        double LastWakeTime { get; }

        SystemBatteryState SystemBatteryState { get; }

        SystemPowerInformation SystemPowerInformation { get; }
    }
}