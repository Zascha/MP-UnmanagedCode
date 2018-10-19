using System.Runtime.InteropServices;

namespace MP.UnmanagedCode.PowerManagementAPI.ApiInterop
{
    internal static class SuspendStateApiInterop
    {
        [DllImport("powrprof.dll", SetLastError = true, CallingConvention = CallingConvention.Cdecl)]
        internal static extern bool SetSuspendState(bool toHibernateMode, bool bForce, bool bWakeupEventsDisabled);
    }
}