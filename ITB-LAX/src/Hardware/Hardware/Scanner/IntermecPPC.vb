Option Explicit On 
Option Strict On

Namespace Scanner
    Public Class IntermecPPC
        Inherits Base

        Private Enum LEDTypes
            OrangeBlink = 0
            RedBlink = 1
            Red = 2
            Green = 3
            Vibrate = 5
        End Enum

        <CLSCompliant(False)> _
        Public WithEvents MyReader As Intermec.DataCollection.BarcodeReader = Nothing
        Private MyReaderData As Intermec.DataCollection.BarcodeReadEventArgs = Nothing

        '' 0 length arrays
        Dim MyGoodScanBuf(-1) As Byte
        Dim MyBadScanBuf(-1) As Byte
        Dim MyWarningBuf(-1) As Byte
        Dim MyMistakeBuf(-1) As Byte

        Private MyGoodAudio As OpenNETCF.Media.SoundPlayer
        Private MyBadAudio As OpenNETCF.Media.SoundPlayer
        Private MyWarnAudio As OpenNETCF.Media.SoundPlayer
        Private MyMistakeAudio As OpenNETCF.Media.SoundPlayer

        Private WithEvents MyVibrateTimer As Windows.Forms.Timer
        Private WithEvents MyLEDTimer As Windows.Forms.Timer
        Private MyOnLED As Integer

#Region "DLL"
        Class DLL
            Enum ITC_BARCODEREADER_ATTRIBUTE_ID
                ITC_RDRATTR_GRID = 128
                ITC_RDRATTR_SCANNER_ENABLE = ITC_RDRATTR_GRID + 1
                ITC_RDRATTR_LASER_POWER_ON = ITC_RDRATTR_SCANNER_ENABLE + 1
                ITC_RDRATTR_GOOD_READ_LED_ENABLE = ITC_RDRATTR_LASER_POWER_ON + 1
                ITC_RDRATTR_DATA_VALID_LED_ENABLE = ITC_RDRATTR_GOOD_READ_LED_ENABLE + 1
                ITC_RDRATTR_TONE_ENABLE = ITC_RDRATTR_DATA_VALID_LED_ENABLE + 1
                ITC_RDRATTR_VOLUME_LEVEL = ITC_RDRATTR_TONE_ENABLE + 1
                ITC_RDRATTR_TONE_FREQUENCY = ITC_RDRATTR_VOLUME_LEVEL + 1
                ITC_RDRATTR_GOOD_READ_BEEPS_NUMBER = ITC_RDRATTR_TONE_FREQUENCY + 1
                ITC_RDRATTR_GOOD_READ_BEEP_DURATION = ITC_RDRATTR_GOOD_READ_BEEPS_NUMBER + 1
                ITC_RDRATTR_GOOD_READ_LED_DURATION = ITC_RDRATTR_GOOD_READ_BEEP_DURATION + 1
                ITC_RDRATTR_PDF417_CRACKLE = ITC_RDRATTR_GOOD_READ_LED_DURATION + 1
                ITC_RDRATTR_PDF417_LED_FLICKER = ITC_RDRATTR_PDF417_CRACKLE + 1
                ITC_RDRATTR_DEV_ADDR = ITC_RDRATTR_PDF417_LED_FLICKER + 1
            End Enum

            <Runtime.InteropServices.DllImport("ITC50.DLL")> _
            Public Shared Function ITCCommand(ByVal TheCommand As String) As Integer
            End Function

            '<Runtime.InteropServices.DllImport("itcscan.dll")> _
            'Public Shared Function ITCSCAN_Open(ByRef pHandle As Integer, ByVal pszDeviceName As String) As Integer
            'End Function

            '<Runtime.InteropServices.DllImport("itcscan.dll")> _
            'Public Shared Function ITCSCAN_Close(ByVal pHandle As IntPtr) As Integer
            'End Function

            '<Runtime.InteropServices.DllImport("itcscan.dll")> _
            'Public Shared Function ITCSCAN_SetAttribute(ByVal pHandle As IntPtr, ByVal eAttribID As Integer, ByVal rgbData As Byte(), ByVal dwBufferSize As Integer) As Integer
            'End Function

        End Class
#End Region

#Region "Properties"

        Public Overrides Property Enabled() As Boolean
            Get
                Return MyReader.ScannerEnable
            End Get
            Set(ByVal Value As Boolean)
                Select Case Value
                    Case True
                        If Not MyReader.ScannerEnable Then
                            MyReader.ScannerEnable = True
                            MyReader.ThreadedRead(True)
                        End If

                    Case False
                        If MyReader.ScannerEnable Then
                            If MyReader.ScannerOn Then
                                MyReader.ScannerOn = False
                            End If
                            MyReader.CancelRead(True)
                            MyReader.ScannerEnable = False
                        End If

                End Select

            End Set
        End Property

        Public Overrides ReadOnly Property ContinuousSupported() As Boolean
            Get
                Return True
            End Get
        End Property

        Private ContinuousProp As Boolean
        Public Overrides Property Continuous() As Boolean
            Get
                Return ContinuousProp
            End Get
            Set(ByVal Value As Boolean)
                ContinuousProp = Value
            End Set
        End Property

        Dim VolumePercentProp As Integer
        Public Overrides Property VolumePercent() As Integer
            Get
                Return VolumePercentProp
            End Get
            Set(ByVal Value As Integer)
                VolumePercentProp = Value
            End Set
        End Property

        Private BeepProp As Boolean
        Public Overrides Property Beep() As Boolean
            Get
                Return BeepProp
            End Get
            Set(ByVal Value As Boolean)
                BeepProp = Value
            End Set
        End Property

        Public Overrides ReadOnly Property BeepSupported() As Boolean
            Get
                Return True
            End Get
        End Property

        Private LEDProp As Boolean
        Public Overrides Property LED() As Boolean
            Get
                Return LEDProp
            End Get
            Set(ByVal Value As Boolean)
                LEDProp = Value
            End Set
        End Property

        Public Overrides ReadOnly Property LEDSupported() As Boolean
            Get
                Return True
            End Get
        End Property

        Private VibrateProp As Boolean
        Public Overrides Property Vibrate() As Boolean
            Get
                Return VibrateProp
            End Get
            Set(ByVal Value As Boolean)
                VibrateProp = Value
            End Set
        End Property

        Public Overrides ReadOnly Property VibrateSupported() As Boolean
            Get
                Return True
            End Get
        End Property

#End Region

#Region "Symbology"
        Private SymbologySupported As Boolean
        Public Overrides Property Code128() As Boolean
            Get
                If SymbologySupported Then
                    Return MyReader.symbology.Code128.Enable
                Else
                    Return True
                End If
            End Get
            Set(ByVal Value As Boolean)
                If SymbologySupported Then
                    MyReader.symbology.Code128.Enable = Value
                End If
            End Set
        End Property

        Public Overrides Property Code93() As Boolean
            Get
                If SymbologySupported Then
                    Return MyReader.symbology.Code93.Enable
                Else
                    Return True
                End If
            End Get
            Set(ByVal Value As Boolean)
                If SymbologySupported Then
                    MyReader.symbology.Code93.Enable = Value
                End If
            End Set
        End Property

        Public Overrides Property Interleaved2of5() As Boolean
            Get
                If SymbologySupported Then
                    Return MyReader.symbology.Interleaved2Of5.Enable
                Else
                    Return True
                End If
            End Get
            Set(ByVal Value As Boolean)
                If SymbologySupported Then
                    MyReader.symbology.Interleaved2Of5.Enable = Value
                End If
            End Set
        End Property
#End Region

        Sub New()
            ''' Set-up Intermec configuration
            'Try
            '    Dim Dev As Integer
            '    Dim PtrDev As IntPtr
            '    Dim R As Integer
            '    R = DLL.ITCSCAN_Open(Dev, "default")
            '    PtrDev = New IntPtr(Dev)
            '    R = DLL.ITCSCAN_SetAttribute(PtrDev, DLL.ITC_BARCODEREADER_ATTRIBUTE_ID.ITC_RDRATTR_GOOD_READ_BEEPS_NUMBER, BitConverter.GetBytes(0), 4)
            '    R = DLL.ITCSCAN_SetAttribute(PtrDev, DLL.ITC_BARCODEREADER_ATTRIBUTE_ID.ITC_RDRATTR_GOOD_READ_LED_ENABLE, BitConverter.GetBytes(False), 1)
            '    R = DLL.ITCSCAN_Close(PtrDev)

            '    '' Disable key clicks
            '    DLL.ITCCommand("$+KC0")
            'Catch ex As Exception
            'End Try

            '' Init audio
            LoadSounds()

            '' Init Vibrate
            MyVibrateTimer = New Windows.Forms.Timer
            MyVibrateTimer.Enabled = False
            Hardware.Led.LedOff(LEDTypes.Vibrate)

            '' Init LEDs
            MyLEDTimer = New Windows.Forms.Timer
            MyLEDTimer.Enabled = False
            LEDsOff()

            '' Init scanner reader
            MyDeviceType = Device.DeviceTypes.IntermecPPC
            MyReader = New Intermec.DataCollection.BarcodeReader(UInt32.Parse("65536"))

            '' Enable all symbologies
            Try
                MyReader.symbology.EnableAll()
                SymbologySupported = True
            Catch ex As Exception
                SymbologySupported = False
            End Try

        End Sub

        Private Sub LoadSounds()
            Dim FS As IO.FileStream
            Dim S As IO.Stream
            Dim Ass As System.Reflection.Assembly = System.Reflection.Assembly.GetExecutingAssembly()
            Dim FName As String

            FName = Device.AppPath.FullName & "\GoodScan.wav"
            If IO.File.Exists(FName) Then
                FS = New IO.FileStream(FName, IO.FileMode.Open)
                ReDim MyGoodScanBuf(CInt(FS.Length) - 1)
                FS.Read(MyGoodScanBuf, 0, CInt(FS.Length))
            Else
                S = Ass.GetManifestResourceStream("Hardware.GoodScan.wav")
                ReDim MyGoodScanBuf(CInt(S.Length - 1))
                S.Read(MyGoodScanBuf, 0, MyGoodScanBuf.Length)
            End If

            FName = Device.AppPath.FullName & "\BadScan.wav"
            If IO.File.Exists(FName) Then
                FS = New IO.FileStream(FName, IO.FileMode.Open)
                ReDim MyBadScanBuf(CInt(FS.Length) - 1)
                FS.Read(MyBadScanBuf, 0, CInt(FS.Length))
            Else
                S = Ass.GetManifestResourceStream("Hardware.BadScan.wav")
                ReDim MyBadScanBuf(CInt(S.Length - 1))
                S.Read(MyBadScanBuf, 0, MyBadScanBuf.Length)
            End If

            FName = Device.AppPath.FullName & "\Warning.wav"
            If IO.File.Exists(FName) Then
                FS = New IO.FileStream(FName, IO.FileMode.Open)
                ReDim MyWarningBuf(CInt(FS.Length) - 1)
                FS.Read(MyWarningBuf, 0, CInt(FS.Length))
            Else
                S = Ass.GetManifestResourceStream("Hardware.Warning.wav")
                ReDim MyWarningBuf(CInt(S.Length - 1))
                S.Read(MyWarningBuf, 0, MyWarningBuf.Length)
            End If

            FName = Device.AppPath.FullName & "\Mistake.wav"
            If IO.File.Exists(FName) Then
                FS = New IO.FileStream(FName, IO.FileMode.Open)
                ReDim MyMistakeBuf(CInt(FS.Length) - 1)
                FS.Read(MyMistakeBuf, 0, CInt(FS.Length))
            Else
                S = Ass.GetManifestResourceStream("Hardware.Mistake.wav")
                ReDim MyMistakeBuf(CInt(S.Length - 1))
                S.Read(MyMistakeBuf, 0, MyMistakeBuf.Length)
            End If

        End Sub

        '' User feedback (beeps, vibrate, leds)
        Public Overrides Sub Feedback(ByVal TheType As Base.FeedbackTypes)
            If Beep Then
                Select Case TheType
                    Case Base.FeedbackTypes.GoodScan
                        If MyGoodScanBuf.Length = 0 Then
                            Return
                        End If

                        Try
                            If MyGoodAudio Is Nothing Then
                                Using GoodScanStream As New IO.MemoryStream(MyGoodScanBuf, False)
                                    MyGoodAudio = New OpenNETCF.Media.SoundPlayer(GoodScanStream)
                                End Using
                            End If
                            MyGoodAudio.PlaySync()
                        Catch ex As Exception
                        End Try

                    Case Base.FeedbackTypes.BadScan
                        If MyBadScanBuf.Length = 0 Then
                            Return
                        End If

                        Try
                            If MyBadAudio Is Nothing Then
                                Using BadScanStream As New IO.MemoryStream(MyBadScanBuf, False)
                                    MyBadAudio = New OpenNETCF.Media.SoundPlayer(BadScanStream)
                                End Using
                            End If
                            MyBadAudio.PlaySync()
                        Catch ex As Exception
                        End Try

                    Case Base.FeedbackTypes.Warning
                        If MyWarningBuf.Length = 0 Then
                            Return
                        End If

                        Try
                            If MyWarnAudio Is Nothing Then
                                Using WarningStream As New IO.MemoryStream(MyWarningBuf, False)
                                    MyWarnAudio = New OpenNETCF.Media.SoundPlayer(WarningStream)
                                End Using
                            End If
                            MyWarnAudio.PlaySync()
                        Catch ex As Exception
                        End Try

                    Case Base.FeedbackTypes.Mistake
                        If MyMistakeBuf.Length = 0 Then
                            Return
                        End If

                        Try
                            If MyMistakeAudio Is Nothing Then
                                Using MistakeStream As New IO.MemoryStream(MyMistakeBuf, False)
                                    MyMistakeAudio = New OpenNETCF.Media.SoundPlayer(MistakeStream)
                                End Using
                            End If
                            MyMistakeAudio.PlaySync()
                        Catch ex As Exception
                        End Try

                End Select
            End If

            If Vibrate Then
                Select Case TheType
                    Case Base.FeedbackTypes.GoodScan
                        If Not ContinuousProp Then
                            '' Only vibrate if not continuous mode
                            VibrateFor(TimeSpan.FromMilliseconds(250))
                        End If

                    Case Base.FeedbackTypes.BadScan
                        If ContinuousProp Then
                            '' Inform of bad scans in continuous mode
                            VibrateFor(TimeSpan.FromMilliseconds(250))
                        End If

                    Case Base.FeedbackTypes.Warning
                        VibrateFor(TimeSpan.FromMilliseconds(1500))

                    Case Base.FeedbackTypes.Mistake
                        VibrateFor(TimeSpan.FromMilliseconds(2000))

                End Select
            End If

            If LED Then
                Select Case TheType
                    Case Base.FeedbackTypes.GoodScan
                        LEDOnFor(LEDTypes.Green, TimeSpan.FromMilliseconds(500))

                    Case Base.FeedbackTypes.BadScan
                        LEDOnFor(LEDTypes.Red, TimeSpan.FromMilliseconds(500))

                    Case Base.FeedbackTypes.Warning
                        '' Around 3 blinks
                        LEDOnFor(LEDTypes.OrangeBlink, TimeSpan.FromMilliseconds(6000))

                    Case Base.FeedbackTypes.Mistake
                        '' Around 3 blinks
                        LEDOnFor(LEDTypes.RedBlink, TimeSpan.FromMilliseconds(6000))

                End Select
            End If

        End Sub

        Private Function GetVolume(ByVal TheVolumePercent As Integer) As Integer
            Dim Factor As Double = TheVolumePercent / 100
            Dim Result As Integer = CInt(Factor * &HFFFF)
            Return Result Or (Result << 16)
        End Function

        Private Sub ReadCallback(ByVal sender As System.Object, ByVal e As Intermec.DataCollection.BarcodeReadEventArgs) Handles MyReader.BarcodeRead
            If Not ContinuousProp Then
                MyReader.ScannerEnable = False
            End If

            RaiseEventBarCodeRead(e.strDataBuffer, MapSymbology(e.Symbology))

            '' Scan next barcode
            If Not ContinuousProp Then
                MyReader.ScannerEnable = True
            Else
                MyReader.ScannerOn = True
            End If

        End Sub

        Private Function MapSymbology(ByVal TheIntermecSymbology As Integer) As Symbologies
            Select Case TheIntermecSymbology
                Case 7
                    Return Base.Symbologies.Code128
                Case 2
                    Return Base.Symbologies.Code93
                Case 4
                    Return Base.Symbologies.Interleaved2of5
                Case Else
                    Return Base.Symbologies.Unknown
            End Select
        End Function

        '' Vibrate on
        Private Sub VibrateFor(ByVal TheInterval As TimeSpan)
            Hardware.Led.LedOff(LEDTypes.Vibrate)
            MyVibrateTimer.Enabled = False

            Hardware.Led.LedOn(LEDTypes.Vibrate)
            MyVibrateTimer.Interval = CInt(TheInterval.TotalMilliseconds)
            MyVibrateTimer.Enabled = True

        End Sub

        '' Vibrate off (not threaded)
        Private Sub MyVibrateTimer_Tick(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyVibrateTimer.Tick
            MyVibrateTimer.Enabled = False
            Hardware.Led.LedOff(LEDTypes.Vibrate)
        End Sub

        Private Sub LEDsOff()
            Hardware.Led.LedOff(0)
            Hardware.Led.LedOff(1)
            Hardware.Led.LedOff(2)
            Hardware.Led.LedOff(3)
            Hardware.Led.LedOff(4)
        End Sub

        Private Sub LEDOnFor(ByVal TheLED As LEDTypes, ByVal TheInterval As TimeSpan)
            MyLEDTimer.Enabled = False
            LEDsOff()

            Hardware.Led.LedOn(TheLED)
            MyOnLED = TheLED
            MyLEDTimer.Interval = CInt(TheInterval.TotalMilliseconds)
            MyLEDTimer.Enabled = True
        End Sub

        Private Sub MyLEDTimer_Tick(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyLEDTimer.Tick
            MyLEDTimer.Enabled = False
            Hardware.Led.LedOff(MyOnLED)
        End Sub

        '' Clean up
        Protected Overrides Sub Disposing()
            LEDsOff()
            Hardware.Led.LedOff(LEDTypes.Vibrate)

            '' NOTE: These freeze up sometimes
            'Me.Enabled = False
            'MyReader.Dispose()
        End Sub


        'TODO: Device beeps on scan (intermec settings)

    End Class

End Namespace