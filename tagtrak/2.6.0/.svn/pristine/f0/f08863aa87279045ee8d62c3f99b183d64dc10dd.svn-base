Imports System.Runtime.InteropServices
Public Class DeviceUI

    <DllImport("coredll.dll", EntryPoint:="GetForegroundWindow", SetLastError:=True)> _
    Private Shared Function GetForegroundWindow() As IntPtr
    End Function

    <DllImport("aygshell.dll", EntryPoint:="SHFullScreen", SetLastError:=True)> _
    Private Shared Function SHFullScreen( _
    ByVal hwndRequester As IntPtr, _
    ByVal dwState As Integer) As Boolean
    End Function

    Private Const SHFS_SHOWSTARTICON As Integer = &H10
    Private Const SHFS_HIDESTARTICON As Integer = &H20

    Private Shared lastHwnd As IntPtr

    Private Shared Function SetStartButtonVisible(ByVal visible As Boolean) As Boolean
        Dim hwnd As IntPtr = GetForegroundWindow()
        If hwnd.Equals(lastHwnd) Then
            Return True
        Else
            lastHwnd = hwnd
        End If

        If Not hwnd.Equals(IntPtr.Zero) Then
            If visible Then
                Return SHFullScreen(hwnd, SHFS_SHOWSTARTICON)
            Else
                Return SHFullScreen(hwnd, SHFS_HIDESTARTICON)
            End If
        End If
    End Function

    Public Shared Sub HideStartButton()
        SetStartButtonVisible(False)
    End Sub

    Public Shared Sub ShowStartButton()
        SetStartButtonVisible(True)
    End Sub

End Class

