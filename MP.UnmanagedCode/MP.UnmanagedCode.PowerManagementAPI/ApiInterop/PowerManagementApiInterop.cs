using System;
using System.Runtime.InteropServices;
using MP.UnmanagedCode.PowerManagementAPI.Models;

namespace MP.UnmanagedCode.PowerManagementAPI.ApiInterop
{
    internal static class PowerManagementApiInterop
    {
        [DllImport("powrprof.dll", SetLastError = true, CallingConvention = CallingConvention.Cdecl)]
        internal static extern uint CallNtPowerInformation(PowerInformationLevel informationLevel,
                                                           IntPtr inputBuffer, int onputBufferSize,
                                                           IntPtr outputResult, int outputBufferSize);

        [DllImport("powrprof.dll", SetLastError = true, CallingConvention = CallingConvention.Cdecl)]
        internal static extern uint CallNtPowerInformation(PowerInformationLevel informationLevel,
                                                           IntPtr inputBuffer, int inputBufferSize,
                                                           out SystemBatteryState outputBuffer, int outputBufferSize);

        [DllImport("powrprof.dll", SetLastError = true, CallingConvention = CallingConvention.Cdecl)]
        internal static extern uint CallNtPowerInformation(PowerInformationLevel informationLevel,
                                                           IntPtr inputBuffer, int inputBufferSize,
                                                           out SystemPowerInformation outputBuffer, int outputBufferSize);
    }
}
