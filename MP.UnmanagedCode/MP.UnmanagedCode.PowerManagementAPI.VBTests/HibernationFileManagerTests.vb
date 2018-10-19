Imports Xunit

Public Class HibernationFileManagerTests
    Private ReadOnly _hibernationFileManager As HibernationFileManager

    Sub New()
        _hibernationFileManager = New HibernationFileManager()
    End Sub

    <Fact>
    Sub ReserveHibernationFile_Test()
        _hibernationFileManager.ReserveHibernationFile()
    End Sub

    <Fact>
    Sub DeleteHibernationFile_Test()
        _hibernationFileManager.DeleteHibernationFile()
    End Sub

    <Fact(Skip := "Switches to hibernation mode")>
    Sub SwitchToHibernationModeToHibernationMode_DisableWakeEventsFalse_Test()
        _hibernationFileManager.SwitchToHibernationMode()
    End Sub

    <Fact(Skip := "Switches to hibernation mode")>
    Sub SwitchToHibernationModeToHibernationMode_DisableWakeEventsTrue_Test()
        _hibernationFileManager.SwitchToHibernationMode(disableWakeEvents := true)
    End Sub

End Class