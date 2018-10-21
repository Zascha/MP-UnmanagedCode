using System;
using System.ComponentModel;
using System.Runtime.InteropServices;
using MP.UnmanagedCode.PowerManagementAPI.ApiInterop;
using MP.UnmanagedCode.PowerManagementAPI.ComInterfaces;
using MP.UnmanagedCode.PowerManagementAPI.Models;

namespace MP.UnmanagedCode.PowerManagementAPI
{
    [ComVisible(true)]
    [Guid("ED2A3C6E-E4D8-4E0D-8B8F-FB675CFF88F4")]
    [ClassInterface(ClassInterfaceType.None)]
    public class PowerInformationManager : AllocatedMemoryAbsolvent, IPowerInformationManager
    {
        public double LastSleepTime
        {
            get
            {
                var intPtr = IntPtr.Zero;

                return ExecuteWithAllocatedMemoryRelease(() =>
                {
                    var lastSleepTime = Marshal.AllocCoTaskMem(Marshal.SizeOf(typeof(long)));

                    var resultCode = PowerManagementApiInterop.CallNtPowerInformation(PowerInformationLevel.LastSleepTime,
                                                                                      intPtr, 0,
                                                                                      lastSleepTime, 
                                                                                      Marshal.SizeOf(typeof(long)));

                    return ProceedExternalResult(GetResultTimeInMilliseconds, (ulong)lastSleepTime, resultCode);
                }, intPtr);
            }
        }

        public double LastWakeTime
        {
            get
            {
                var intPtr = IntPtr.Zero;

                return ExecuteWithAllocatedMemoryRelease(() =>
                {
                    var lastWakeTime = Marshal.AllocCoTaskMem(Marshal.SizeOf(typeof(long)));

                    var resultCode = PowerManagementApiInterop.CallNtPowerInformation(PowerInformationLevel.LastSleepTime,
                                                                                      intPtr, 0,
                                                                                      lastWakeTime, 
                                                                                      Marshal.SizeOf(typeof(long)));

                    return ProceedExternalResult(GetResultTimeInMilliseconds, (ulong) lastWakeTime, resultCode);
                }, intPtr);
            }
        }

        public SystemBatteryState SystemBatteryState
        {
            get
            {
                var intPtr = IntPtr.Zero;

                return ExecuteWithAllocatedMemoryRelease(() =>
                {
                    var resultCode = PowerManagementApiInterop.CallNtPowerInformation(PowerInformationLevel.SystemBatteryState,
                                                                                      intPtr, 0,
                                                                                      out SystemBatteryState systemBatteryState, 
                                                                                      Marshal.SizeOf(typeof(SystemBatteryState)));

                    return ProceedExternalResult(batteryState => batteryState, systemBatteryState, resultCode);
                }, intPtr);
            }
        }

        public SystemPowerInformation SystemPowerInformation
        {
            get
            {
                var intPtr = IntPtr.Zero;

                return ExecuteWithAllocatedMemoryRelease(() =>
                {
                    var resultCode = PowerManagementApiInterop.CallNtPowerInformation(PowerInformationLevel.SystemBatteryState,
                                                                                      intPtr, 0,
                                                                                      out SystemPowerInformation systemPowerInformation,
                                                                                      Marshal.SizeOf(typeof(SystemPowerInformation)));

                    return ProceedExternalResult(powerInfo => powerInfo, systemPowerInformation, resultCode);
                }, intPtr);
            }
        }

        #region Private methods

        private TOutput ProceedExternalResult<TInput, TOutput>(Func<TInput, TOutput> operation, TInput operationParam, uint resultCode)
        {
            var resultStatus = (OperationStatus)Enum.Parse(typeof(OperationStatus), resultCode.ToString());

            if (resultStatus != OperationStatus.Success)
            {
                throw new Win32Exception($"Calling external CallNtPowerInformation method has finished with status: {resultStatus}");
            }

            return operation(operationParam);
        }

        private double GetResultTimeInMilliseconds(ulong interruptTimeCount)
        {
            return interruptTimeCount / 1000D;
        }

        #endregion

    }
}
