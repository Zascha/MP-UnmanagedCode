using System.Runtime.InteropServices;

namespace MP.UnmanagedCode.PowerManagementAPI.ComInterfaces
{
    [ComVisible(true)]
    [Guid("4066B872-E594-421E-A7DE-B82723181BAC")]
    [InterfaceType(ComInterfaceType.InterfaceIsDual)]
    public interface IHibernationFileManager
    {
        void ReserveHibernationFile();

        void DeleteHibernationFile();

        void SwitchToHibernationMode(bool disableWakeEvents = false);
    }
}