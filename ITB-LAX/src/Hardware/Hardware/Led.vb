Option Explicit On 
Option Strict On

Public Class Led

#Region "DLL"
    <CLSCompliant(False)> _
    Class DLL

        Public Shared NLED_COUNT_INFO_ID As UInt32 = Convert.ToUInt32(0)
        Public Shared NLED_SUPPORTS_INFO_ID As UInt32 = Convert.ToUInt32(1)
        Public Shared NLED_SETTINGS_INFO_ID As UInt32 = Convert.ToUInt32(2)

        Public Structure NLED_COUNT_INFO
            Dim cLeds As UInt32
        End Structure

        Public Structure NLED_SETTINGS_INFO
            Public LedNum As UInt32
            Public OffOnBlink As Int32
            Public TotalCycleTime As Int32
            Public OnTime As Int32
            Public OffTime As Int32
            Public MetaCycleOn As Int32
            Public MetaCycleOff As Int32
        End Structure

        Public Structure NLED_SUPPORTS_INFO
            Public Lednum As UInt32
            Public lCycleAdjust As Long
            Public fAdjustTotalCycleTime As Boolean
            Public fAdjustOnTime As Boolean
            Public fAdjustOffTime As Boolean
            Public fMetaCycleOn As Boolean
            Public fMetaCycleOff As Boolean
        End Structure

        Public Enum OffOnBlink As Short
            TurnOff = 0
            TurnOn = 1
            Blink = 2
        End Enum

        <Runtime.InteropServices.DllImport("coredll.dll")> _
        Public Shared Function NLedSetDevice(ByVal nDeviceId As UInt32, ByRef pInput As NLED_SETTINGS_INFO) As Boolean
        End Function

        <Runtime.InteropServices.DllImport("coredll.dll", EntryPoint:="NLedGetDeviceInfo")> _
        Public Shared Function NLedGetDeviceInfoCount(ByVal nInfoId As UInt32, ByRef pOutput As NLED_COUNT_INFO) As Boolean
        End Function

        <Runtime.InteropServices.DllImport("coredll.dll")> _
        Public Shared Function NLedGetDeviceInfo(ByVal nInfoId As UInt32, ByRef pOutput As NLED_SUPPORTS_INFO) As Boolean
        End Function

    End Class
#End Region

    Public Shared Sub LedOn(ByVal TheLedNumber As Integer)
        Try
            Dim I As New DLL.NLED_SETTINGS_INFO
            I.LedNum = Convert.ToUInt32(TheLedNumber)
            I.OffOnBlink = DLL.OffOnBlink.TurnOn
            Dim R As Boolean
            R = DLL.NLedSetDevice(DLL.NLED_SETTINGS_INFO_ID, I)
        Catch ex As Exception
        End Try
    End Sub

    Public Shared Sub LedOff(ByVal TheLedNumber As Integer)
        Try
            Dim I As New DLL.NLED_SETTINGS_INFO
            I.LedNum = Convert.ToUInt32(TheLedNumber)
            I.OffOnBlink = DLL.OffOnBlink.TurnOff
            Dim R As Boolean
            R = DLL.NLedSetDevice(DLL.NLED_SETTINGS_INFO_ID, I)
        Catch ex As Exception
        End Try
    End Sub

    Public Shared Function Count() As Integer
        Try
            Dim O As DLL.NLED_COUNT_INFO
            Dim R As Boolean
            R = DLL.NLedGetDeviceInfoCount(DLL.NLED_COUNT_INFO_ID, O)
            Return Convert.ToInt32(O.cLeds)
        Catch ex As Exception
        End Try
    End Function

    'CLSCompliant(False) cannot return NLED_SUPPORTS_INFO_ID
    Public Shared Sub LoopDeviceInfo()
        Try
            For i As Integer = 0 To Count() - 1
                Dim DI As New DLL.NLED_SUPPORTS_INFO
                Dim bResult As Boolean
                DI.Lednum = Convert.ToUInt32(i)
                bResult = DLL.NLedGetDeviceInfo(DLL.NLED_SUPPORTS_INFO_ID, DI)
                LedOn(i) 'Identify LED from the device
                LedOff(i)
            Next
        Catch ex As Exception
        End Try
    End Sub
End Class