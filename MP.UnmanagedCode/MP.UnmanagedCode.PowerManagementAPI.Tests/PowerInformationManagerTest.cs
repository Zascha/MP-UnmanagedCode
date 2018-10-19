using MP.UnmanagedCode.PowerManagementAPI.Models;
using Xunit;

namespace MP.UnmanagedCode.PowerManagementAPI.Tests
{
    public class PowerInformationManagerTest
    {
        private readonly PowerInformationManager _powerInformationManager;

        public PowerInformationManagerTest()
        {
            _powerInformationManager = new PowerInformationManager();
        }

        [Fact]
        public void GetPowerInformation_LastSleepTime()
        {
            var lastSleepTime = _powerInformationManager.LastSleepTime;

            Assert.NotEqual(0, lastSleepTime);
        }

        [Fact]
        public void GetPowerInformation_LastWakeTime()
        {
            var lastWakeTime = _powerInformationManager.LastWakeTime;

            Assert.NotEqual(0, lastWakeTime);
        }

        [Fact]
        public void GetPowerInformation_SystemBatteryState()
        {
            var systemBatteryState = _powerInformationManager.SystemBatteryState;

            Assert.IsType<SystemBatteryState>(systemBatteryState);
            Assert.True(systemBatteryState.AcOnLine); // true - the system battery charger is currently operating on external power
        }

        [Fact]
        public void GetPowerInformation_SystemPowerInformation()
        {
            var systemPowerInformation = _powerInformationManager.SystemPowerInformation;

            Assert.IsType<SystemPowerInformation>(systemPowerInformation);
            Assert.Equal(0, (int)systemPowerInformation.CoolingMode); // 0 - system is currently in Active cooling mode
            Assert.Equal(0, (int)systemPowerInformation.Idleness);    // the current idle level
        }
    }
}
