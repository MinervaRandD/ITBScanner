Imports Microsoft.Win32

Namespace Networking
    Public Class WiFi
        Implements IDisposable

        Private Const POWER_NAME As Integer = &H1
        Private Const POWER_FORCE As Integer = 4096

        Private disposedValue As Boolean = False        ' To detect redundant calls

        <Flags()> _
       Public Enum DevicePowerState
            Unspecified = -1
            D0 = 0      'Full On: full power, full functionality 
            D1          'Low Power On: fully functional at low power/performance 
            D2          'Standby: partially powered with automatic wake 
            D3          'Sleep: partially powered with device initiated wake 
            D4          'Off: unpowered 
        End Enum

        <System.Runtime.InteropServices.DllImport("coredll.dll")> _
        Public Shared Function DevicePowerNotify(ByVal pvDevice As String, ByVal DeviceState As DevicePowerState, ByVal dwDeviceFlags As Integer) As Integer
        End Function

        <System.Runtime.InteropServices.DllImport("Coredll.dll")> _
        Private Shared Function SetDevicePower(ByVal pvDevice As String, ByVal dwDeviceFlags As Integer, ByVal DeviceState As DevicePowerState) As Integer
        End Function

        Private Shared Function FindDriverKey() As String

            Dim WiFiDriver As String = String.Empty
            '#define PMCLASS_NDIS_MINIPORT TEXT("{98C5250D-C29A-4985-AE5F-AFE5367E5006}")
            '(From "c:\Program Files (x86)\Windows Mobile 6 SDK\PocketPC\Include\Armv4i\pm.h")
            Dim WiFiDriverClass As String = "{98C5250D-C29A-4985-AE5F-AFE5367E5006}"

            For Each Driver As String In Registry.LocalMachine.OpenSubKey("System\CurrentControlSet\Control\Power\State", False).GetValueNames()
                If Driver.IndexOf(WiFiDriverClass) <> -1 Then
                    WiFiDriver = Driver
                    Exit For
                End If
            Next

            Return WiFiDriver

        End Function

        Public Sub TurnOffWiFi()

            Dim Driver As String = FindDriverKey()

            'Try to turn off WiFi with standard method (This method is not working on MC75 WM6)
            DevicePowerNotify(Driver, DevicePowerState.D4, POWER_NAME)
            SetDevicePower(Driver, POWER_NAME, DevicePowerState.D4)

            'Try to turn off WiFi using alternative method
            Dim rdm As New RadioManager.RadioDeviceManager()
            ChangeState(rdm.WiFiDevice, False)
            rdm.Dispose()

        End Sub

        Private Sub ChangeState(ByVal rd As RadioManager.RadioDevice, ByVal enabled As Boolean)
            If rd Is Nothing Then
                'MessageBox.Show("Device not found!")
                Exit Sub
            End If

            Dim [error] As String = rd.ChangeState(enabled)
            If [error] <> "" Then
                Debug.WriteLine("Error: " & [error])
            End If
        End Sub


        ' IDisposable
        Protected Overridable Sub Dispose(ByVal disposing As Boolean)
            If Not Me.disposedValue Then
                If disposing Then
                    ' TODO: free other state (managed objects).
                End If

                ' TODO: free your own state (unmanaged objects).
                ' TODO: set large fields to null.
            End If
            Me.disposedValue = True
        End Sub

#Region " IDisposable Support "
        ' This code added by Visual Basic to correctly implement the disposable pattern.
        Public Sub Dispose() Implements IDisposable.Dispose
            ' Do not change this code.  Put cleanup code in Dispose(ByVal disposing As Boolean) above.
            Dispose(True)
            GC.SuppressFinalize(Me)
        End Sub
#End Region

    End Class

End Namespace

