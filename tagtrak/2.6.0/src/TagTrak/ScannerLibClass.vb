Imports System
Imports System.text

Public Class SYSTEM_POWER_STATUS_EX
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
End Class 'SYSTEM_POWER_STATUS_EX

Public Class scannerLibClass

    Declare Function GetSystemPowerStatusEx Lib "coredll" ( _
        ByVal lpSystemPowerStatus As SYSTEM_POWER_STATUS_EX, _
        ByVal fUpdate As Boolean) As System.UInt32

#If deviceType = "Intermec" Or deviceType = "Symbol" Or deviceType = "ViewSonic" Or deviceType = "Dolphin" Then

    Public Function SystemPowerStatus() As Int32

        Dim status As New SYSTEM_POWER_STATUS_EX

        GetSystemPowerStatusEx(status, True)

        Return status.ACLineStatus

    End Function

    Declare Function aesEncrypt Lib "AirlineSoftware.dll" ( _
    ByVal inputMode As Byte(), _
    ByVal inputBuff As Byte(), _
    ByVal inputLen As Int32, _
    ByVal outputBuff As Byte(), _
    ByVal key As Byte(), _
    ByVal keyLen As Int32) As Int32

    Declare Function aesDecrypt Lib "AirlineSoftware.dll" ( _
        ByVal inputMode As Byte(), _
        ByVal inputBuff As Byte(), _
        ByVal inputLen As Int32, _
        ByVal outputBuff As Byte(), _
        ByVal key As Byte(), _
        ByVal keyLen As Int32) As Int32

    Declare Sub md5 Lib "Md5.dll" ( _
        ByVal inputData As Byte(), _
        ByVal inputLen As Int32, _
        ByVal outputBuff As Byte())


#End If

#Region "IntermecRegion"

#If deviceType = "Intermec" Then

    Declare Sub Code93Active Lib "AirlineSoftware.dll" ()
    Declare Sub Code93NotActive Lib "AirlineSoftware.dll" ()

    Declare Sub Code128Active Lib "AirlineSoftware.dll" ()
    Declare Sub Code128NotActive Lib "AirlineSoftware.dll" ()

    Declare Sub TurnOnRegistrySave Lib "AirlineSoftware.dll" ()
    Declare Function GetTimeZone Lib "AirlineSoftware.dll" () As Int32
    Declare Sub SetTimeZone Lib "AirlineSoftware.dll" (ByVal nOffset As Int32)
    Declare Sub WarmBoot Lib "AirlineSoftware.dll" ()
    Declare Sub ColdBoot Lib "AirlineSoftware.dll" ()

    Declare Function GetRegistryString Lib "AirlineSoftware.dll" (ByVal rValue As StringBuilder, ByVal lpSubKey As String, ByVal lpEntry As String) As Integer
    Declare Function GetRegistryNumber Lib "AirlineSoftware.dll" (ByVal lpSubKey As String, ByVal lpEntry As String) As Int32

    Declare Sub BeepSound Lib "AirlineSoftware.dll" ()
    Declare Sub VibrateON Lib "AirlineSoftware.dll" ()
    Declare Sub VibrateOFF Lib "AirlineSoftware.dll" ()


    Public Function getDeviceSerialNumber() As String

        Dim intermecSerialNumber(128) As Byte
        Dim rc As Integer

        Try
            rc = psuuid.GetSerNum(intermecSerialNumber, 22)
        Catch ex As Exception
            MsgBox("Get serial number failed: " & ex.Message)
        End Try

        Dim deviceSerialNumber As String = ""
        Dim i As Integer

        For i = 0 To 10

            Dim nextChar As Char

            nextChar = Chr(intermecSerialNumber(2 * i))

            If Not Util.isTextCharacter(intermecSerialNumber(2 * i)) Then Exit For

            deviceSerialNumber &= nextChar

        Next

        Return deviceSerialNumber

    End Function

#End If

#End Region

#Region "SymbolRegion"

    '#If deviceType = "Symbol" Then

    '    Public Sub Code93Active()

    '        If symbolReader.MyReader Is Nothing Then Exit Sub

    '        turnScannerOff(1001)

    '        symbolReader.MyReader.Decoders.CODE93.Enabled = True

    '        turnScannerOn(1001)

    '    End Sub

    '    Public Sub Code93NotActive()

    '        If symbolReader.MyReader Is Nothing Then Exit Sub

    '        turnScannerOff(1001)

    '        symbolReader.MyReader.Decoders.CODE93.Enabled = False

    '        turnScannerOn(1001)

    '    End Sub

    '    Public Sub code128Active()

    '        If symbolReader.MyReader Is Nothing Then Exit Sub

    '        symbolReader.MyReader.Decoders.CODE128.Enabled = True

    '        'If SymbolApi Is Nothing Then Exit Sub

    '        'SymbolApi.SetEnabled(Symbol.Barcode.DecoderTypes.CODE128, True)

    '    End Sub

    '    Public Sub code128NotActive()

    '        If symbolReader.MyReader Is Nothing Then Exit Sub

    '        symbolReader.MyReader.Decoders.CODE128.Enabled = False

    '        'If SymbolApi Is Nothing Then Exit Sub

    '        'SymbolApi.SetEnabled(Symbol.Barcode.DecoderTypes.CODE128, False)

    '    End Sub

    '    Declare Sub WarmBoot Lib "AirlineSoftware.dll" ()
    '    Declare Sub ColdBoot Lib "AirlineSoftware.dll" ()

    '    Public Function GetRegistryString(ByVal rValue As StringBuilder, ByVal lpSubKey As String, ByVal lpEntry As String) As Integer
    '        Return 0
    '    End Function

    '    Public Function GetRegistryNumber(ByVal lpSubKey As String, ByVal lpEntry As String) As Int32
    '        Return 0
    '    End Function

    '    'Declare Sub md5 Lib "Md5.dll" ( _
    '    '    ByVal inputData As Byte(), _
    '    '    ByVal inputLen As Int32, _
    '    '    ByVal outputBuff As Byte())

    '    Public Function getDeviceSerialNumber() As String

    '        Dim terminalInfo As Symbol.ResourceCoordination.TerminalInfo = New Symbol.ResourceCoordination.TerminalInfo

    '        Dim uuid As String = ""

    '        If (terminalInfo.UniqueUnitID Is Nothing) Then

    '            Return "UUID not set"

    '        Else
    '            For Each b As Byte In terminalInfo.UniqueUnitID

    '                uuid += b.ToString("X2")

    '            Next

    '        End If

    '        If Len(uuid) > 32 Then
    '            uuid = Substring(uuid, 0, 32)
    '        End If

    '        Return uuid

    '    End Function

    '#End If

#If deviceType = "Symbol" Then

    Public Sub Code93Active()

        If scanReader.MyReader Is Nothing Then Exit Sub

        Util.turnScannerOff(1001)

        'scanReader.MyReader.Decoders.CODE93.Enabled = True

        Util.turnScannerOn(1001)

    End Sub

    Public Sub Code93NotActive()

        If scanReader.MyReader Is Nothing Then Exit Sub

        Util.turnScannerOff(1001)

        'scanReader.MyReader.Decoders.CODE93.Enabled = False

        Util.turnScannerOn(1001)

    End Sub

    Public Sub code128Active()

        If scanReader.MyReader Is Nothing Then Exit Sub

        'scanReader.MyReader.Decoders.CODE128.Enabled = True

        'If SymbolApi Is Nothing Then Exit Sub

        'SymbolApi.SetEnabled(Symbol.Barcode.DecoderTypes.CODE128, True)

    End Sub

    Public Sub code128NotActive()

        If scanReader.MyReader Is Nothing Then Exit Sub

        'scanReader.MyReader.Decoders.CODE128.Enabled = False

        'If SymbolApi Is Nothing Then Exit Sub

        'SymbolApi.SetEnabled(Symbol.Barcode.DecoderTypes.CODE128, False)

    End Sub

    Declare Sub WarmBoot Lib "AirlineSoftware.dll" ()
    Declare Sub ColdBoot Lib "AirlineSoftware.dll" ()

    Public Function GetRegistryString(ByVal rValue As StringBuilder, ByVal lpSubKey As String, ByVal lpEntry As String) As Integer
        Return 0
    End Function

    Public Function GetRegistryNumber(ByVal lpSubKey As String, ByVal lpEntry As String) As Int32
        Return 0
    End Function

    'Declare Sub md5 Lib "Md5.dll" ( _
    '    ByVal inputData As Byte(), _
    '    ByVal inputLen As Int32, _
    '    ByVal outputBuff As Byte())

    Public Function getDeviceSerialNumber() As String

        Dim terminalInfo As Symbol.ResourceCoordination.TerminalInfo = New Symbol.ResourceCoordination.TerminalInfo

        Dim uuid As String = ""

        If (terminalInfo.UniqueUnitID Is Nothing) Then

            Return "UUID not set"

        Else
            For Each b As Byte In terminalInfo.UniqueUnitID

                uuid += b.ToString("X2")

            Next

        End If

        If Len(uuid) > 32 Then
            uuid = Substring(uuid, 0, 32)
        End If

        Return uuid

    End Function

#End If

#End Region

#Region "Dolphin"

#If deviceType = "Dolphin" Then

    Public Sub Code93Active()
        Exit Sub
    End Sub

    Public Sub Code93NotActive()
        Exit Sub
    End Sub

    Public Sub code128Active()
        Exit Sub
    End Sub

    Public Sub code128NotActive()
        Exit Sub
    End Sub

    Declare Sub WarmBoot Lib "AirlineSoftware.dll" ()
    Declare Sub ColdBoot Lib "AirlineSoftware.dll" ()

    Public Function GetRegistryString(ByVal rValue As StringBuilder, ByVal lpSubKey As String, ByVal lpEntry As String) As Integer
        Return 0
    End Function

    Public Function GetRegistryNumber(ByVal lpSubKey As String, ByVal lpEntry As String) As Int32
        Return 0
    End Function

    'Declare Sub md5 Lib "Md5.dll" ( _
    '    ByVal inputData As Byte(), _
    '    ByVal inputLen As Int32, _
    '    ByVal outputBuff As Byte())

    Public Function getDeviceSerialNumber() As String
        Return HHP.Device.UtilMethods.GetSerialNumber()
    End Function

#End If

#End Region

#Region "ViewSonicRegion"

#If deviceType = "ViewSonic" Then

    Public Sub Code93Active()
        Exit Sub
    End Sub

    Public Sub Code93NotActive()
        Exit Sub
    End Sub

    Public Sub Code128Active()
        Exit Sub
    End Sub

    Public Sub Code128NotActive()
        Exit Sub
    End Sub

    Declare Sub TurnOnRegistrySave Lib "AirlineSoftware.dll" ()
    Declare Function GetTimeZone Lib "AirlineSoftware.dll" () As Int32
    Declare Sub SetTimeZone Lib "AirlineSoftware.dll" (ByVal nOffset As Int32)
    Declare Sub WarmBoot Lib "AirlineSoftware.dll" ()
    Declare Sub ColdBoot Lib "AirlineSoftware.dll" ()

    Declare Function GetRegistryString Lib "AirlineSoftware.dll" (ByVal rValue As StringBuilder, ByVal lpSubKey As String, ByVal lpEntry As String) As Integer
    Declare Function GetRegistryNumber Lib "AirlineSoftware.dll" (ByVal lpSubKey As String, ByVal lpEntry As String) As Int32

    Declare Sub BeepSound Lib "AirlineSoftware.dll" ()
    Declare Sub VibrateON Lib "AirlineSoftware.dll" ()
    Declare Sub VibrateOFF Lib "AirlineSoftware.dll" ()

    Declare Sub md5 Lib "Md5.dll" ( _
        ByVal inputData As Byte(), _
        ByVal inputLen As Int32, _
        ByVal outputBuff As Byte())

    Public Function getDeviceSerialNumber() As String

        Dim intermecSerialNumber(128) As Byte
        Dim rc As Integer

        Try
            rc = psuuid.GetSerNum(intermecSerialNumber, 22)
        Catch ex As Exception
            MsgBox("Get serial number failed: " & ex.Message)
        End Try

        Dim deviceSerialNumber As String = ""
        Dim i As Integer

        For i = 0 To 10

            Dim nextChar As Char

            nextChar = Chr(intermecSerialNumber(2 * i))

            If Not isTextCharacter(intermecSerialNumber(2 * i)) Then Exit For

            deviceSerialNumber &= nextChar

        Next

        Return deviceSerialNumber

    End Function

#End If

#End Region

#Region "PCRegion"

#If deviceType = "PC" Then

    Public Function getDeviceSerialNumber() As String
        Return "PC000000001"
    End Function

    Public Sub Code93Active()

    End Sub

    Public Sub Code93NotActive()

    End Sub

    Public Sub Code128Active()

    End Sub

    Public Sub Code128NotActive()

    End Sub

    Public Function SystemPowerStatus() As Int32
        Return 1
    End Function

    Public Sub WarmBoot()
        MsgBox("PC: Must do manual warm boot")
        Stop
    End Sub

    Public Sub ColdBoot()
        MsgBox("PC: Must do manual cold boot")
        Stop
    End Sub

    Public Function GetRegistryString(ByVal rValue As StringBuilder, ByVal lpSubKey As String, ByVal lpEntry As String) As Integer
        Return 0
    End Function

    Public Function GetRegistryNumber(ByVal lpSubKey As String, ByVal lpEntry As String) As Int32
        Return 0
    End Function

    Public Function aesEncrypt( _
        ByVal inputMode As Byte(), _
        ByVal inputBuff As Byte(), _
        ByVal inputLen As Int32, _
        ByVal outputBuff As Byte(), _
        ByVal key As Byte(), _
        ByVal keyLen As Int32) As Int32
        Return 0
    End Function


    Public Function aesDecrypt( _
        ByVal inputMode As Byte(), _
        ByVal inputBuff As Byte(), _
        ByVal inputLen As Int32, _
        ByVal outputBuff As Byte(), _
        ByVal key As Byte(), _
        ByVal keyLen As Int32) As Int32
        Return 0
    End Function

    Public Sub md5( _
        ByVal inputData As Byte(), _
        ByVal inputLen As Int32, _
        ByVal outputBuff As Byte())

    End Sub
#End If

#End Region

End Class
