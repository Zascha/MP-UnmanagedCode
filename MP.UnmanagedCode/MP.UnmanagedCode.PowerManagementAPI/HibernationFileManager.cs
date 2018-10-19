using System;
using System.ComponentModel;
using System.Runtime.InteropServices;
using MP.UnmanagedCode.PowerManagementAPI.ApiInterop;
using MP.UnmanagedCode.PowerManagementAPI.ComInterfaces;
using MP.UnmanagedCode.PowerManagementAPI.Models;

namespace MP.UnmanagedCode.PowerManagementAPI
{
    [ComVisible(true)]
    [Guid("3423C2CA-F262-4574-A0AC-4F41A8C96B00")]
    [ClassInterface(ClassInterfaceType.None)]
    public class HibernationFileManager : AllocatedMemoryAbsolvent, IHibernationFileManager
    {
        public void ReserveHibernationFile()
        {
            var boolValue = 0;
            var intPtr = Marshal.AllocCoTaskMem(boolValue);
            Marshal.WriteInt32(intPtr, 0);

            ExecuteWithAllocatedMemoryRelease(() =>
            {
                var resultCode = PowerManagementApiInterop.CallNtPowerInformation(PowerInformationLevel.SystemReserveHiberFile,
                                                                                  intPtr, Marshal.SizeOf(typeof(int)),
                                                                                  IntPtr.Zero, 0);
                ProcceedExternalResult(resultCode);
            }, intPtr);
        }

        public void DeleteHibernationFile()
        {
            var boolValue = 1;
            var intPtr = Marshal.AllocCoTaskMem(boolValue);
            Marshal.WriteInt32(intPtr, 0);

            ExecuteWithAllocatedMemoryRelease(() =>
            {
                var resultCode = PowerManagementApiInterop.CallNtPowerInformation(PowerInformationLevel.SystemReserveHiberFile,
                                                                              intPtr, Marshal.SizeOf(typeof(int)),
                                                                              IntPtr.Zero, 0);
                ProcceedExternalResult(resultCode);
            }, intPtr);
        }

        public void SwitchToHibernationMode(bool disableWakeEvents = false)
        {
            SuspendStateApiInterop.SetSuspendState(true, default(bool), disableWakeEvents);
        }

        #region Private methods

        private void ProcceedExternalResult(uint resultCode)
        {
            var resultStatus = (OperationStatus)Enum.Parse(typeof(OperationStatus), resultCode.ToString());

            if (resultStatus != OperationStatus.Success)
            {
                throw new Win32Exception($"Calling external CallNtPowerInformation method has finished with status: {resultStatus}");
            }
        }

        #endregion
    }
}