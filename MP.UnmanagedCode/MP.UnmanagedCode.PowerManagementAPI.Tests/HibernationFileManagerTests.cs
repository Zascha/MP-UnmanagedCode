using Xunit;

namespace MP.UnmanagedCode.PowerManagementAPI.Tests
{
    public class HibernationFileManagerTests
    {
        private readonly HibernationFileManager _hibernationFileManager;

        public HibernationFileManagerTests()
        {
            _hibernationFileManager = new HibernationFileManager();
        }

        [Fact]
        public void ReserveHibernationFile_Test()
        {
            _hibernationFileManager.ReserveHibernationFile();
        }

        [Fact]
        public void DeleteHibernationFile_Test()
        {
            _hibernationFileManager.DeleteHibernationFile();
        }

        [Fact (Skip = "Switches to hibernation mode")]
        public void SwitchToHibernationModeToHibernationMode_DisableWakeEventsFalse_Test()
        {
            _hibernationFileManager.SwitchToHibernationMode();
        }

        [Fact(Skip = "Switches to hibernation mode")]
        public void SwitchToHibernationModeToHibernationMode_DisableWakeEventsTrue_Test()
        {
            _hibernationFileManager.SwitchToHibernationMode(disableWakeEvents: true);
        }
    }
}
