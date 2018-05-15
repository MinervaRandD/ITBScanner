Option Explicit On 
Option Strict On

'' Queries hardware power status
Public Class Power

    Private Shared UInt32MaxValue As UInt32 = UInt32.Parse("4294967295")

    Public Enum ACStatus
        Offline = 0
        Online = 1
        BackupPower = 2
        Unknown = 255
    End Enum

    Enum BackupStatus
        High = &H1
        Low = &H2
        Critical = &H4
        Charging = &H8
        NoBattery = &H80
        Unknown = &HFF
    End Enum

#Region "SPS"
    '' Wraps the DLL SPS info in a class for easy reading
    <CLSCompliant(False)> _
    Class SPS

        Public MySPS As DLL.SYSTEM_POWER_STATUS_EX
        Public IsValid As Boolean

        Sub New()
            Try
                IsValid = DLL.GetSystemPowerStatusEx(MySPS, True)
            Catch ex As Exception
            End Try
        End Sub

    End Class
#End Region

#Region "DLL"
    <CLSCompliant(False)> _
    Class DLL
        Public Structure SYSTEM_POWER_STATUS_EX
            Public ACLineStatus As Byte
            Public BatteryFlag As Byte
            Public BatteryLifePercent As Byte
            Public Reserved1 As Byte
            Public BatteryLifeTime As System.UInt32
            Public BatteryFullLifeTime As System.UInt32
            Public Reserved2 As Byte
            Public BackupBatteryFlag As Byte
            Public BackupBatteryLifePercent As Byte
            Public Reserved3 As Byte
            Public BackupBatteryLifeTime As System.UInt32
            Public BackupBatteryFullLifeTime As System.UInt32
        End Structure

        <System.Runtime.InteropServices.DllImport("coredll.dll")> _
        Public Shared Function GetSystemPowerStatusEx(ByRef lpSystemPowerStatus As SYSTEM_POWER_STATUS_EX, ByVal fUpdate As Boolean) As Boolean
        End Function

    End Class
#End Region

    '' Returns the AC line power status (Are we plugged in?)
    Public Shared Function GetACStatus() As ACStatus
        Dim S As New SPS
        If S.IsValid Then
            Return CType(S.MySPS.ACLineStatus, ACStatus)
        End If
    End Function

    '' Returns the battery life percent (0-100; 100 if unknown)
    Public Shared Function BatteryPercent() As Integer
        Dim S As New SPS
        If S.IsValid Then
            If S.MySPS.BatteryLifePercent = 255 Then
                '' Unknown
                Return 100
            Else
                Return S.MySPS.BatteryLifePercent
            End If
        End If
    End Function

    '' Returns the battery run time remaining
    Public Shared Function BatteryTime() As TimeSpan
        Dim S As New SPS
        If S.IsValid Then
            If S.MySPS.BackupBatteryLifeTime.Equals(UInt32MaxValue) Then
                Return TimeSpan.MaxValue
            Else
                '' Safe to convert UInt32 to Double without overflow
                Return TimeSpan.FromSeconds(Convert.ToDouble(S.MySPS.BackupBatteryLifeTime))
            End If
        End If
    End Function

    '' Returns the battery run time when full
    Public Shared Function BatteryFullTime() As TimeSpan
        Dim S As New SPS
        If S.IsValid Then
            If S.MySPS.BackupBatteryFullLifeTime.Equals(UInt32MaxValue) Then
                Return TimeSpan.MaxValue
            Else
                '' Safe to convert UInt32 to Double without overflow
                Return TimeSpan.FromSeconds(Convert.ToDouble(S.MySPS.BackupBatteryFullLifeTime))
            End If
        End If
    End Function

    '' Returns backup battery status
    Public Shared Function BackupBatteryStatus() As BackupStatus
        Dim S As New SPS
        If S.IsValid Then
            Return CType(S.MySPS.BackupBatteryFlag, BackupStatus)
        End If
    End Function

End Class