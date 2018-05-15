Option Explicit On 
Option Strict On

Imports OpenNETCF.Telephony

Public Class Device
    Enum DeviceTypes
        Unknown
        IntermecPPC
        Symbol
        HHP
        PsionTeklogix
    End Enum

#Region "DLL"
    Class DLL

        Public Shared ITC_SUCCESS As Integer = &H1910000
        Public Shared ITC_ERROR As Integer = &HC1910000

        Public Shared FILE_DEVICE_HAL As Integer = &H101
        Public Shared FILE_ANY_ACCESS As Integer = &H0
        Public Shared METHOD_BUFFERED As Integer = &H0

        Public Const POWER_STATE_RESET As Integer = &H800000

        '' NOTE: Does not work as expected!
        '<System.Runtime.InteropServices.DllImport("ITC50.DLL")> _
        'Public Shared Function ITCGetSerialNumber(ByVal number() As Byte, ByVal buffSize As Integer) As Integer
        'End Function

        Shared Sub New()
            '' Create psuuid0c file if missing
            Dim FI As New IO.FileInfo(Device.AppPath.FullName & "\PSUUID0C.DLL")
            Dim ResourceStream As IO.Stream = System.Reflection.Assembly.GetExecutingAssembly().GetManifestResourceStream("Hardware.psuuid0c.dll")
            If Not FI.Exists OrElse FI.Length <> ResourceStream.Length Then
                Using WriteFS As IO.FileStream = IO.File.OpenWrite(Device.AppPath.FullName & "\PSUUID0C.DLL")
                    Dim Buffer(CInt(ResourceStream.Length - 1)) As Byte
                    ResourceStream.Read(Buffer, 0, Buffer.Length)
                    WriteFS.Write(Buffer, 0, Buffer.Length)
                    WriteFS.Close()
                End Using
            End If
        End Sub

        <System.Runtime.InteropServices.DllImport("PSUUID0C.DLL", EntryPoint:="?GetSerNum@@YAHPAGK@Z")> _
        Public Shared Function GetSerialNum(ByVal TheSerial As Text.StringBuilder, ByVal TheSerialLength As Int32) As Integer
        End Function

        <System.Runtime.InteropServices.DllImport("Coredll.dll")> _
        Public Shared Sub SetCleanRebootFlag()
        End Sub

        <System.Runtime.InteropServices.DllImport("Coredll.dll")> _
        Public Shared Function KernelIoControl(ByVal dwIoControlCode As Integer, ByVal lpInBuf As IntPtr, ByVal nInBufSize As Integer, ByVal lpOutBuf As IntPtr, ByVal nOutBufSize As Integer, ByRef lpBytesReturned As Integer) As Integer
        End Function

        <System.Runtime.InteropServices.DllImport("Coredll.dll")> _
        Public Shared Function GetSystemTime(ByRef lpSystemTime As SYSTEMTIME) As UInt32
        End Function

        <System.Runtime.InteropServices.DllImport("Coredll.dll")> _
        Public Shared Function SetSystemTime(ByRef lpSystemTime As SYSTEMTIME) As UInt32
        End Function

        <System.Runtime.InteropServices.DllImport("coredll.dll")> Public Shared Function SetSystemPowerState(ByVal psState() As System.Char, ByVal StateFlags As System.Int32, ByVal Options As System.Int32) As Int32
        End Function

        Public Shared Function CTL_CODE(ByVal TheDeviceType As Integer, ByVal TheFunction As Integer, ByVal TheMethod As Integer, ByVal TheAccess As Integer) As Integer
            Return ((TheDeviceType << 16) Or (TheAccess << 14) Or (TheFunction << 2) Or TheMethod)
        End Function

    End Class
#End Region

#Region "Sound"
    Public Class Sound
        Implements IDisposable

        Private m_soundBytes() As Byte
        Private m_fileName As String

        Public Declare Function WCE_PlaySound Lib "CoreDll.dll" Alias "PlaySound" (ByVal szSound As String, ByVal hMod As IntPtr, ByVal flags As Integer) As Integer
        Public Declare Function WCE_PlaySoundBytes Lib "CoreDll.dll" Alias "PlaySound" (ByVal szSound() As Byte, ByVal hMod As IntPtr, ByVal flags As Integer) As Integer

        Private Enum Flags
            SND_SYNC = &H0          ' play synchronously (default) 
            SND_ASYNC = &H1         ' play asynchronously 
            SND_NODEFAULT = &H2     ' silence (!default) if sound not found 
            SND_MEMORY = &H4        ' pszSound points to a memory file 
            SND_LOOP = &H8          ' loop the sound until next sndPlaySound 
            SND_NOSTOP = &H10       ' don't stop any currently playing sound 
            SND_NOWAIT = &H2000     ' don't wait if the driver is busy 
            SND_ALIAS = &H10000     ' name is a registry alias 
            SND_ALIAS_ID = &H110000 ' alias is a predefined ID 
            SND_FILENAME = &H20000  ' name is file name 
            SND_RESOURCE = &H40004  ' name is resource name or atom
        End Enum

        ' Construct the Sound object to play sound data from the specified file.
        Public Sub New(ByVal fileName As String)
            m_fileName = fileName
        End Sub

        ' Construct the Sound object to play sound data from the specified stream.
        Public Sub New(ByVal stream As System.IO.Stream)
            ' read the data from the stream
            m_soundBytes = New Byte(CInt(stream.Length)) {}
            stream.Read(m_soundBytes, 0, CInt(stream.Length))
        End Sub 'New

        ' Play the sound
        Public Sub Play()
            ' If a file name has been registered, call WCE_PlaySound, 
            ' otherwise call WCE_PlaySoundBytes.
            If Not (m_fileName Is Nothing) Then
                WCE_PlaySound(m_fileName, IntPtr.Zero, Fix(Flags.SND_ASYNC Or Flags.SND_FILENAME))
            Else
                WCE_PlaySoundBytes(m_soundBytes, IntPtr.Zero, Fix(Flags.SND_ASYNC Or Flags.SND_MEMORY))
            End If
        End Sub

#Region "IDisposable Support"
        Protected Overrides Sub Finalize()
            MyBase.Finalize()
            Dispose()
        End Sub

        Private MyDisposedValue As Boolean = False

        Public Sub Dispose() Implements System.IDisposable.Dispose
            If Not MyDisposedValue Then
                Disposing()
                Me.MyDisposedValue = True
            End If

            GC.SuppressFinalize(Me)
        End Sub

        Protected Overridable Sub Disposing()
        End Sub
#End Region

    End Class
#End Region

#Region "TAPI"
    Public Class TAPI
        Implements IDisposable

        Friend WithEvents TapiObj As Telephony
        Friend thisLine As Line
        Private DisplayedNoCellWarning As Boolean
        Private es As EquipmentState
        Private rs As RadioState

        Sub New()
            TapiObj = New Telephony
            TapiObj.Initialize()
            thisLine = FindCellularLine()
            DisplayedNoCellWarning = False
        End Sub

        Public Sub TurnOnCellularRadio()
            If thisLine Is Nothing Then
                If Not DisplayedNoCellWarning Then
                    Windows.Forms.MessageBox.Show("Could not detect cellular line", "ITB ERROR")
                    DisplayedNoCellWarning = True
                End If
            Else
                NativeMethods.lineGetEquipmentState(thisLine.hLine, es, rs)
                If rs = RadioState.Off Then
                    NativeMethods.lineSetEquipmentState(thisLine.hLine, EquipmentState.Full)
                    NativeMethods.lineRegister(thisLine.hLine, LineRegMode.Automatic, Nothing, 0)
                End If
            End If
        End Sub

        Public Function IsRadioOn() As Boolean
            If Not thisLine Is Nothing Then
                NativeMethods.lineGetEquipmentState(thisLine.hLine, es, rs)
                Return rs = RadioState.On
            Else
                Return False
            End If
        End Function

        Private Function FindCellularLine() As Line
            Dim CellularLine As Line
            Dim numLines As Integer = TapiObj.NumberOfDevices
            For i As Integer = 0 To numLines - 1
                Try
                    Dim dc As New DeviceCapabilities(1024)
                    dc.Store()
                    Dim dwVersion As Integer = TapiObj.NegotiateVersion(i)
                    NativeMethods.lineGetDevCaps(TapiObj.hLineApp, i, dwVersion, 0, dc.Data)
                    dc.Load()
                    If dc.LineName.StartsWith(NativeMethods.CELLTSP_LINENAME_STRING) Then
                        CellularLine = TapiObj.CreateLine(i, MediaMode.InteractiveVoice, CallPrivilege.Owner Or CallPrivilege.Monitor)
                        Return CellularLine
                    End If
                Catch e As TelephonyException
                End Try
            Next

            Return Nothing
        End Function

#Region "IDisposable Support"
        Protected Overrides Sub Finalize()
            MyBase.Finalize()
            Dispose()
        End Sub

        Private MyDisposedValue As Boolean = False

        Public Sub Dispose() Implements System.IDisposable.Dispose
            If Not MyDisposedValue Then
                Disposing()
                Me.MyDisposedValue = True
            End If

            GC.SuppressFinalize(Me)
        End Sub

        Protected Overridable Sub Disposing()
            If Not thisLine Is Nothing Then
                thisLine.Dispose()
            End If
            If Not TapiObj Is Nothing Then
                TapiObj.Shutdown()
            End If
        End Sub
#End Region

    End Class
#End Region

    '' Cache detects, device type never changes
    Private Shared IsDetected As Boolean
    Private Shared MyDeviceType As DeviceTypes
    Private Shared KeyPad As Symbol.Keyboard.KeyPad

    '' Detect the device type in use
    Public Shared Function GetDeviceType() As DeviceTypes
        If IsDetected Then
            Return MyDeviceType
        Else
            MyDeviceType = Detect()
            IsDetected = True
            Return MyDeviceType
        End If

    End Function

    Private Shared Function Detect() As DeviceTypes

        'Psion scanner must be the first to detect. Psion scanner is not throwing an exception when detecting Symbol scanners

        'Detect Psion Teklogix
        Try
            If IsPsionTeklogix() Then
                Return DeviceTypes.PsionTeklogix
            End If
        Catch ex As Exception
        End Try

        '' Detect Intermec
        Try
            Dim BR As New Intermec.DataCollection.BarcodeReader
            'BR.Dispose()
            BR = Nothing
            Return DeviceTypes.IntermecPPC
        Catch ex As Exception
        End Try

        Try
            Dim BR As New Symbol.Barcode.Reader
            'BR.Dispose()
            BR = Nothing
            Return DeviceTypes.Symbol
        Catch ex As Exception
        End Try

        '' None detected, either corrupted device, or unknown
        Return DeviceTypes.Unknown

    End Function

    '' Returns a unique identifies
    Public Shared Function GetUniqueID() As String
        Select Case GetDeviceType()
            Case DeviceTypes.IntermecPPC
                '' Call native itc50.dll to get SN
                Dim SN As New Text.StringBuilder(12)
                Dim R As Integer
                Try
                    R = DLL.GetSerialNum(SN, 12)
                    Return SN.ToString.Trim
                Catch ex As Exception
                    Return ""
                End Try
            Case DeviceTypes.Symbol
                Return getSymbolDeviceSerialNumber()
            Case Else
                Return ""

        End Select

    End Function

    '' Returns a blue tooth address
    Public Shared Function GetBlueToothAddress() As String
        'Dim mysp As New Symbol.PowerTools.ScanAndPairTool()
        'Return mysp.BluetoothInfo.Address

        Return ""

    End Function

    Public Shared Sub WarmBoot()
        If GetDeviceType() = DeviceTypes.PsionTeklogix Then
            WarmBootSafe()
            Return
        End If

        Dim bytesReturned As Integer = 0
        Dim IOCTL_HAL_REBOOT As Integer = DLL.CTL_CODE(DLL.FILE_DEVICE_HAL, 15, DLL.METHOD_BUFFERED, DLL.FILE_ANY_ACCESS)
        Try
            DLL.KernelIoControl(IOCTL_HAL_REBOOT, IntPtr.Zero, 0, IntPtr.Zero, 0, bytesReturned)
        Catch ex As Exception
        End Try
    End Sub

    '' WARNING: No confirmation, all volatile data is lost!
    Public Shared Sub ColdBoot()
        If GetDeviceType() = DeviceTypes.PsionTeklogix Then
            ColdBootSafe()
            Return
        End If

        Try
            DLL.SetCleanRebootFlag()
            WarmBoot()
        Catch ex As Exception
            Return
        End Try
    End Sub

    Public Shared Function AppPath() As IO.DirectoryInfo
        Return New IO.DirectoryInfo(IO.Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().GetModules(0).FullyQualifiedName))
    End Function

    Public Shared Function GetTime() As Date
        Dim st As New SYSTEMTIME
        DLL.GetSystemTime(st)
        Dim ret As Date
        ret = New Date(st.wYear, st.wMonth, st.wDay, st.wHour, st.wMinute, st.wSecond, st.wMilliseconds)
        Return ret
    End Function

    Public Shared Sub SetTime(ByVal dateTime As Date)
        Dim st As New SYSTEMTIME
        st.wYear = Convert.ToUInt16(dateTime.Year)
        st.wMonth = Convert.ToUInt16(dateTime.Month)
        st.wDay = Convert.ToUInt16(dateTime.Day)
        st.wHour = Convert.ToUInt16(dateTime.Hour)
        st.wMinute = Convert.ToUInt16(dateTime.Minute)
        st.wSecond = Convert.ToUInt16(dateTime.Second)
        st.wMilliseconds = Convert.ToUInt16(dateTime.Millisecond)
        DLL.SetSystemTime(st)
    End Sub

#Region "Symbol"
    Public Shared Function getSymbolDeviceSerialNumber() As String
        Dim terminalInfo As Symbol.ResourceCoordination.TerminalInfo = New Symbol.ResourceCoordination.TerminalInfo
        Dim uuid As String = ""

        If (terminalInfo.UniqueUnitID Is Nothing) Then
            Return Nothing
        Else
            For Each b As Byte In terminalInfo.UniqueUnitID
                uuid += b.ToString("X2")
            Next
        End If
        If Len(uuid) > 32 Then
            uuid = Mid(uuid, 1, 32)
        End If
        Return uuid
    End Function

    Public Sub DisableFunctionKey()
        If KeyPad Is Nothing Then
            KeyPad = New Symbol.Keyboard.KeyPad
        End If
        If Detect() = DeviceTypes.Symbol Then
            AddHandler KeyPad.KeyStateNotify, New Symbol.Keyboard.KeyPad.KeyboardEventHandler(AddressOf Me.KeyPad_KeyStateNotify)
        End If
    End Sub

    Public Sub EnableFunctionKey()
        If KeyPad Is Nothing Then
            KeyPad = New Symbol.Keyboard.KeyPad
        End If
        If Detect() = DeviceTypes.Symbol Then
            RemoveHandler KeyPad.KeyStateNotify, AddressOf Me.KeyPad_KeyStateNotify
        End If
    End Sub

    Private Sub KeyPad_KeyStateNotify(ByVal sender As Object, ByVal e As Symbol.Keyboard.KeyboardEventArgs)
        Dim State As Integer = 0
        If CBool(e.KeyState And Symbol.Keyboard.KeyStates.KEYSTATE_FUNC) Then
            KeyPad.SetKeyState(Symbol.Keyboard.KeyStates.KEYSTATE_UNSHIFT, 0, False)
        End If
    End Sub
#End Region

#Region "Psion"
    Private Shared Function IsPsionTeklogix() As Boolean
        Dim oReg As Microsoft.Win32.RegistryKey = Microsoft.Win32.Registry.LocalMachine.OpenSubKey("Ident", False)
        Dim sDesc As String
        Dim bReturn As Boolean = False

        sDesc = CStr(oReg.GetValue("Desc", ""))

        If InStr(sDesc.ToLower, "psion") > 0 Then
            bReturn = True
        End If

        Return bReturn
    End Function

    Private Shared Function GetPsionTeklogixUniqueIdentifier() As String
        Try
            Return PsionTeklogix.SystemPTX.SystemInformation.SystemInformationList.Item("Machine Unique Identifier")
        Catch ex As Exception

        End Try

        Return ""

    End Function

    Public Shared Sub ColdBootSafe()
        Dim cState() As System.Char

        cState = "ResetCold".ToCharArray   'the string "reboot" will perform a warm boot

        DLL.SetSystemPowerState(cState, 0, 0)
    End Sub

    Public Shared Sub WarmBootSafe()
        DLL.SetSystemPowerState(Nothing, DLL.POWER_STATE_RESET, 0)
    End Sub
#End Region

End Class

<CLSCompliant(False)> _
Public Structure SYSTEMTIME
    Public wYear As UInt16
    Public wMonth As UInt16
    Public wDayOfWeek As UInt16
    Public wDay As UInt16
    Public wHour As UInt16
    Public wMinute As UInt16
    Public wSecond As UInt16
    Public wMilliseconds As UInt16
End Structure


