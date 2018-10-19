Imports MP.UnmanagedCode.PowerManagementAPI.Models
Imports Xunit

Public Class PowerInformationManagerTest
    Private ReadOnly _powerInformationManager As PowerInformationManager

    Sub New
        _powerInformationManager = New PowerInformationManager()
    End Sub

    <Fact>
    Sub GetPowerInformation_LastSleepTime()
        Dim lastSleepTime As Double = _powerInformationManager.LastSleepTime
        Xunit.Assert.NotEqual(0, lastSleepTime)
    End Sub

    <Fact>
    Sub GetPowerInformation_LastWakeTime()
        Dim lastWakeTime As Double = _powerInformationManager.LastWakeTime
        Xunit.Assert.NotEqual(0, lastWakeTime)
    End Sub

    <Fact>
    Sub GetPowerInformation_SystemBatteryState()
        Dim result As SystemBatteryState = _powerInformationManager.SystemBatteryState
        Xunit.Assert.True(result.AcOnLine) 'true - the system battery charger is currently operating on external power
    End Sub

    <Fact>
    Sub GetPowerInformation_SystemPowerInformation()
        Dim result As SystemPowerInformation = _powerInformationManager.SystemPowerInformation
        Xunit.Assert.Equal(0.ToString(), result.CoolingMode.ToString()) '0 - system is currently in Active cooling mode
        Xunit.Assert.Equal(0.ToString(), result.Idleness.ToString())    'the current idle level
    End Sub
End Class