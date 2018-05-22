Public Class AutoSendTimer

    Private WithEvents FTPTimer As System.Windows.Forms.Timer

    Public Sub New()
        FTPTimer = New System.Windows.Forms.Timer
        Me.Enabled = False
    End Sub

    Public Property Enabled() As Boolean
        Get
            Return FTPTimer.Enabled
        End Get
        Set(ByVal Value As Boolean)
            FTPTimer.Enabled = Value
        End Set
    End Property

    Public Property Interval() As Integer
        Get
            Return FTPTimer.Interval
        End Get
        Set(ByVal Value As Integer)
            FTPTimer.Interval = Value
        End Set
    End Property

    Public Sub FTPTimer_Tick(ByVal sender As Object, ByVal e As System.EventArgs) Handles FTPTimer.Tick

        Me.Enabled = False
        'Dim FTPThread As System.Threading.Thread
        'FTPThread = New System.Threading.Thread(AddressOf AutoSend)
        'FTPThread.Start()
        AutoSend()

    End Sub

    Public Sub AutoSend()

        'If scannerLib.SystemPowerStatus() = 1 Then

        SyncLock criticalSectionSemiphore

            If criticalSectionSemiphore.getSemiphoreState = False Then

                criticalSectionSemiphore.setSemiphoreState(True)

                Util.turnScannerOff(1001)
                Dim autoSendDisplayForm As New ftpProcessForm
                autoSendDisplayForm.autoClose = True
                autoSendDisplayForm.ShowDialog()
                Util.turnScannerOn(1002)

                criticalSectionSemiphore.setSemiphoreState(False)

            End If

        End SyncLock

        Me.Interval = CType(userSpecRecord.cityTable.Item(scanLocation.currentLocation), CityConfig).GetSetAutosendPeriodicity * 60000
        Me.Enabled = True

        'Else

        '    Me.Interval = 30000
        '    Me.Enabled = True

        'End If

    End Sub

End Class
