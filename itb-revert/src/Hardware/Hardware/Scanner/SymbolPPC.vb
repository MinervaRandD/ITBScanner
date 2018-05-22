Option Explicit On
Option Strict On

Namespace Scanner
    Public Class SymbolPPC
        Inherits Base

        'For Symbol MC75 ONLY
        Private Enum LEDTypes
            Green = 0
            Red = 1
            GreenRight = 2
            Unknown1 = 3
            Unknown2 = 4
            Unknown3 = 5
            Vibrate = 6
        End Enum

        <CLSCompliant(False)> _
        Public WithEvents MyReader As Symbol.Barcode.Reader = Nothing
        Private MyReaderData As Symbol.Barcode.ReaderData = Nothing
        Private MyReaderHandler As System.EventHandler = Nothing

        Private MyGoodAudio As OpenNETCF.Media.SoundPlayer
        Private MyBadAudio As OpenNETCF.Media.SoundPlayer
        Private MyWarnAudio As OpenNETCF.Media.SoundPlayer
        Private MyMistakeAudio As OpenNETCF.Media.SoundPlayer

        Private WithEvents MyVibrateTimer As Windows.Forms.Timer
        Private WithEvents MyLEDTimer As Windows.Forms.Timer
        Private MyOnLED As Integer

        '0 length arrays
        Private MyGoodScanBuf(-1) As Byte
        Private MyBadScanBuf(-1) As Byte
        Private MyWarningBuf(-1) As Byte
        Private MyMistakeBuf(-1) As Byte

#Region "Properties"
        Private ContinuousProp As Boolean
        Private BeepProp As Boolean
        Private LEDProp As Boolean
        Private VibrateProp As Boolean
        Private VolumePercentProp As Integer

        Public Overrides Property Enabled() As Boolean
            Get
                Return MyReader.Info.IsEnabled
            End Get
            Set(ByVal Value As Boolean)
                Select Case Value
                    Case True
                        Enable()
                    Case False
                        Disable()
                End Select
            End Set
        End Property

        Public Overrides ReadOnly Property ContinuousSupported() As Boolean
            Get
                Return True
            End Get
        End Property

        Public Overrides Property Continuous() As Boolean
            Get
                Return ContinuousProp
            End Get
            Set(ByVal Value As Boolean)
                ContinuousProp = Value
            End Set
        End Property

        Public Overrides Property VolumePercent() As Integer
            Get
                Return VolumePercentProp
            End Get
            Set(ByVal Value As Integer)
                VolumePercentProp = Value
            End Set
        End Property

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
                    Return MyReader.Decoders.CODE128.Enabled
                Else
                    Return True
                End If
            End Get
            Set(ByVal Value As Boolean)
                If SymbologySupported Then
                    MyReader.Decoders.CODE128.Enabled = Value
                End If
            End Set
        End Property

        Public Overrides Property Code93() As Boolean
            Get
                If SymbologySupported Then
                    Return MyReader.Decoders.CODE93.Enabled
                Else
                    Return True
                End If
            End Get
            Set(ByVal Value As Boolean)
                If SymbologySupported Then
                    MyReader.Decoders.CODE93.Enabled = Value
                End If
            End Set
        End Property

        Public Overrides Property Interleaved2of5() As Boolean
            Get
                If SymbologySupported Then
                    Return MyReader.Decoders.I2OF5.Enabled
                Else
                    Return True
                End If
            End Get
            Set(ByVal Value As Boolean)
                If SymbologySupported Then
                    MyReader.Decoders.I2OF5.Enabled = Value
                End If
            End Set
        End Property
#End Region

        Sub New()

            'Init audio
            LoadSounds()

            'To obtain new device led information
            '////////////////////////////////////
            'Hardware.Led.LoopDeviceInfo()

            'Init Vibrate
            MyVibrateTimer = New Windows.Forms.Timer
            MyVibrateTimer.Enabled = False
            Hardware.Led.LedOff(LEDTypes.Vibrate)

            'Init LEDs
            MyLEDTimer = New Windows.Forms.Timer
            MyLEDTimer.Enabled = False
            LEDsOff()

            MyDeviceType = Device.DeviceTypes.Symbol
            MyReader = New Symbol.Barcode.Reader
            MyReaderData = New Symbol.Barcode.ReaderData(Symbol.Barcode.ReaderDataTypes.Text, Symbol.Barcode.ReaderDataLengths.MaximumLabel)
            MyReaderHandler = New System.EventHandler(AddressOf ReadCallback)

            Try
                Enable()
                SymbologySupported = True
            Catch ex As Exception
                SymbologySupported = False
            End Try

        End Sub

        Private Sub Enable()

            Dim MyDevice As Symbol.Generic.Device = Nothing

            MyDevice = Symbol.StandardForms.SelectDevice.Select("The Barcode Reader Type", Symbol.Barcode.Device.AvailableDevices, 0)
            If Not MyDevice Is Nothing Then
                If MyReader.Info.IsEnabled = False Then
                    MyReader.Actions.Enable()
                    'DO NOT USE SYMBOL DEFAULT BEEP WHEN BARCODE IS SCANNED
                    '//////////////////////////////////////////////////////
                    MyReader.Parameters.Feedback.Success.BeepTime = 0
                    AddHandler MyReader.ReadNotify, MyReaderHandler
                    MyReader.Actions.Read(MyReaderData)
                End If
            Else
                'TODO: PUT ERROR HERE
            End If

        End Sub

        Private Sub Disable()

            If MyReader.Info.IsEnabled Then
                'Flush (Cancel all pending reads)
                RemoveHandler MyReader.ReadNotify, MyReaderHandler
                MyReader.Actions.Disable()
                MyReader.Actions.Flush()
            End If

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
                FS.Close()
            Else
                S = Ass.GetManifestResourceStream("Hardware.GoodScan.wav")
                ReDim MyGoodScanBuf(CInt(S.Length - 1))
                S.Read(MyGoodScanBuf, 0, MyGoodScanBuf.Length)
                S.Close()
            End If

            FName = Device.AppPath.FullName & "\BadScan.wav"
            If IO.File.Exists(FName) Then
                FS = New IO.FileStream(FName, IO.FileMode.Open)
                ReDim MyBadScanBuf(CInt(FS.Length) - 1)
                FS.Read(MyBadScanBuf, 0, CInt(FS.Length))
                FS.Close()
            Else
                S = Ass.GetManifestResourceStream("Hardware.BadScan.wav")
                ReDim MyBadScanBuf(CInt(S.Length - 1))
                S.Read(MyBadScanBuf, 0, MyBadScanBuf.Length)
                S.Close()
            End If

            FName = Device.AppPath.FullName & "\Warning.wav"
            If IO.File.Exists(FName) Then
                FS = New IO.FileStream(FName, IO.FileMode.Open)
                ReDim MyWarningBuf(CInt(FS.Length) - 1)
                FS.Read(MyWarningBuf, 0, CInt(FS.Length))
                FS.Close()
            Else
                S = Ass.GetManifestResourceStream("Hardware.Warning.wav")
                ReDim MyWarningBuf(CInt(S.Length - 1))
                S.Read(MyWarningBuf, 0, MyWarningBuf.Length)
                S.Close()
            End If

            FName = Device.AppPath.FullName & "\Mistake.wav"
            If IO.File.Exists(FName) Then
                FS = New IO.FileStream(FName, IO.FileMode.Open)
                ReDim MyMistakeBuf(CInt(FS.Length) - 1)
                FS.Read(MyMistakeBuf, 0, CInt(FS.Length))
                FS.Close()
            Else
                S = Ass.GetManifestResourceStream("Hardware.Mistake.wav")
                ReDim MyMistakeBuf(CInt(S.Length - 1))
                S.Read(MyMistakeBuf, 0, MyMistakeBuf.Length)
                S.Close()
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

                        '///////////////////////////////////////////////////////////////////
                        'TODO: Future project --> Simulate blink for "Warning" and "Mistake"
                        '///////////////////////////////////////////////////////////////////
                    Case Base.FeedbackTypes.Warning
                        LEDOnFor(LEDTypes.Red, TimeSpan.FromMilliseconds(1000))
                    Case Base.FeedbackTypes.Mistake
                        LEDOnFor(LEDTypes.Red, TimeSpan.FromMilliseconds(2000))
                End Select
            End If
        End Sub

        Private Function GetVolume(ByVal TheVolumePercent As Integer) As Integer
            Dim Factor As Double = TheVolumePercent / 100
            Dim Result As Integer = CInt(Factor * &HFFFF)
            Return Result Or (Result << 16)
        End Function

        Private Sub ReadCallback(ByVal sender As System.Object, ByVal e As System.EventArgs)

            If Not ContinuousProp Then
                Disable()
            End If

            If MyReaderData.Result = Symbol.Results.SUCCESS Then
                RaiseEventBarCodeRead(MyReaderData.Text, MapSymbology(MyReaderData.Type))
            End If

            If Not ContinuousProp Then
                Enable()
            Else
                MyReader.Actions.Read(MyReaderData)
            End If

        End Sub

        Private Function MapSymbology(ByVal TheSymbology As Symbol.Barcode.DecoderTypes) As Symbologies

            Select Case TheSymbology
                Case Symbol.Barcode.DecoderTypes.CODE128
                    Return Base.Symbologies.Code128
                Case Symbol.Barcode.DecoderTypes.CODE93
                    Return Base.Symbologies.Code93
                Case Symbol.Barcode.DecoderTypes.I2OF5
                    Return Base.Symbologies.Interleaved2of5
                Case Else
                    Return Base.Symbologies.Unknown
            End Select

        End Function

        Private Sub LEDsOff()

            For i As Integer = 0 To Hardware.Led.Count - 1
                Hardware.Led.LedOff(i)
            Next

        End Sub

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

            If Not MyReaderData Is Nothing Then
                MyReaderData.Dispose()
            End If
            If Not MyReader Is Nothing Then
                MyReader.Dispose()
            End If

        End Sub

    End Class
End Namespace