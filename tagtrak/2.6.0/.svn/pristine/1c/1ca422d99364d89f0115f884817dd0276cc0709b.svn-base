Public Class TagTrakBackgroundFtpTimerClass

    Private WithEvents backgroundFtpTimer As System.Windows.Forms.Timer

    Private _cradleTickCount As Int32 = System.Int32.MaxValue

    Public Property cradleTickCount() As Int32

        Get
            Return _cradleTickCount
        End Get

        Set(ByVal Value As Integer)
            _cradleTickCount = Value

        End Set

    End Property

    Public Sub New()

        Me.backgroundFtpTimer = New System.Windows.Forms.Timer

        Me.backgroundFtpTimer.Interval = 5000

        backgroundFtpTimer.Enabled = False

    End Sub

    Public Property Enabled() As Boolean
        Get
            Return backgroundFtpTimer.Enabled
        End Get

        Set(ByVal Value As Boolean)
            backgroundFtpTimer.Enabled = Value
        End Set

    End Property

    Private Sub decrementCradleTickCountAndDoAutoUploadIfAppropriate()

        Dim dialogResult As DialogResult

        cradleTickCount -= 1

        If cradleTickCount <= 0 Then

            cradleTickCount = 12 * 30 ' Reset autoupload timer to 30 minutes

            Util.turnScannerOff(1001)

            Dim autoFtpProcessDisplayForm As New autoFtpProcessForm
            dialogResult = autoFtpProcessDisplayForm.ShowDialog()

            Util.turnScannerOn(1002)

            If dialogResult = dialogResult.Abort Then
                dialogResult = dialogResult.Abort
                Exit Sub
            End If

        End If

    End Sub

    Dim withinFtpProcess As Boolean = False

    Private Sub handleBackgroundFtpTimerEvent()

        Dim deviceNowInCradle As Boolean

#If deviceType <> "Intermec" And deviceType <> "Symbol" Then
            Exit Sub
#End If

        If withinFtpProcess Then Exit Sub

        withinFtpProcess = True

        If scannerLib.SystemPowerStatus() = 1 Then
            deviceNowInCradle = True
        Else
            deviceNowInCradle = False
        End If

        If deviceInCradle Then

            ' If here, then device was in the cradle at last timer event

            If deviceNowInCradle Then

                ' Device was previously in the cradle and is in the cradle now. The following steps are taken:
                ' 1. The cradle tick counter is decremented.
                ' 2. If the cradle tick counter is less than or equal to zero, the auto upload is triggered.
                ' 3. If auto upload is triggered, the cradle tick count is set to 30 minutes.

                decrementCradleTickCountAndDoAutoUploadIfAppropriate()

            Else

                ' Device was previously in the cradle and now removed. Turn off
                ' auto upload feature.

                deviceInCradle = False             ' Set state variable to "device not in cradle"
                cradleTickCount = System.Int32.MaxValue       ' Not really necessary -- set autoupload timer to infinity

                logCradleStateChange(1, False)

            End If

        Else ' If here, then device was not previously in cradle at last timer event

            If deviceNowInCradle Then

                ' Device was not previously in the cradle and has been put in since the last
                ' cradle event. Turn on auto upload feature and set timer to 30 seconds.

                cradleTickCount = 6      ' Set auto upload timer to go off after 30 seconds.
                deviceInCradle = True    ' Set the state variable to "device in cradle

                'resetOperationComboBoxWithoutWarning()

                logCradleStateChange(2, True)

            Else

                ' device remains out of cradle -- nothing to do.

                cradleTickCount = System.Int32.MaxValue       ' Not really necessary -- set autoupload timer to infinity

            End If

        End If

        withinFtpProcess = False

    End Sub

    Private Sub backgroundFtpTimer_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles backgroundFtpTimer.Tick
        Static lastPowerStatus As Integer = -1

        Dim curPowerStatus As Integer = scannerLib.SystemPowerStatus

        If lastPowerStatus <> 1 And lastPowerStatus <> -1 And curPowerStatus = 1 And autoFTPTimer.Enabled Then
            System.Threading.Thread.Sleep(5000)
            autoFTPTimer.FTPTimer_Tick(Nothing, Nothing)
        End If

        lastPowerStatus = curPowerStatus

#If True Then

        If emulatingPlatform Then Exit Sub

        SyncLock criticalSectionSemiphore

            If criticalSectionSemiphore.getSemiphoreState = False Then

                criticalSectionSemiphore.setSemiphoreState(True)

                'activeReaderForm.backgroundFtpTimer.Enabled = False
                'activeReaderForm.uploadReminderTimer.Enabled = False

                handleBackgroundFtpTimerEvent()

                'activeReaderForm.backgroundFtpTimer.Enabled = True
                'activeReaderForm.uploadReminderTimer.Enabled = True

                criticalSectionSemiphore.setSemiphoreState(False)

            End If

        End SyncLock

        Application.DoEvents()

#End If

    End Sub

End Class
