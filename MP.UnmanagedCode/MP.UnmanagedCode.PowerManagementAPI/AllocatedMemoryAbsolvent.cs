using System;
using System.Runtime.InteropServices;

namespace MP.UnmanagedCode.PowerManagementAPI
{
    public abstract class AllocatedMemoryAbsolvent
    {
        protected TOutput ExecuteWithAllocatedMemoryRelease<TOutput>(Func<TOutput> operation, IntPtr handle)
        {
            try
            {
                return operation();
            }
            finally
            {
                if (handle != IntPtr.Zero)
                {
                    Marshal.FreeCoTaskMem(handle);
                }
            }
        }

        protected void ExecuteWithAllocatedMemoryRelease(Action operation, IntPtr handle)
        {
            try
            {
                operation();
            }
            finally
            {
                if (handle != IntPtr.Zero)
                {
                    Marshal.FreeCoTaskMem(handle);
                }
            }
        }
    }
}