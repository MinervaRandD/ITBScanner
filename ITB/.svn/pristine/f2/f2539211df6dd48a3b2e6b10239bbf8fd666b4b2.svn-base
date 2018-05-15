Imports System
Imports System.Collections.Generic
Imports System.Text
Imports System.Runtime.InteropServices

Namespace RadioManager
    Class Win32
#Region "DllImports"

        <DllImport("ossvcs.dll", EntryPoint:="#276")> _
        Friend Shared Function GetWirelessDevices(ByRef pDevices As IntPtr, ByVal dwFlags As Integer) As Integer
        End Function

        <DllImport("ossvcs.dll", EntryPoint:="#280")> _
        Friend Shared Function FreeDevicesList(ByVal pDevices As IntPtr) As Integer
        End Function

        <DllImport("ossvcs.dll", EntryPoint:="#273")> _
        Friend Shared Function ChangeRadioState(ByVal pDevices As IntPtr, ByVal dwState As Integer, ByVal sa As SAVEACTION) As Integer
        End Function

#End Region

        Friend Const S_OK As Integer = 0
    End Class
End Namespace

