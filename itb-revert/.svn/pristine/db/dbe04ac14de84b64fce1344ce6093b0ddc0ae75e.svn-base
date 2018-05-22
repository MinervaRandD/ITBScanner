Option Explicit On
Option Strict On

Namespace Scanner
    Public Class PsionTeklogixScanner
        Inherits Base

        Friend WithEvents moScanner As PsionTeklogix.Barcode.Scanner
        Friend WithEvents moScannerServicesDriver As PsionTeklogix.Barcode.ScannerServices.ScannerServicesDriver
        'Friend moScannerDriver2 As PsionTeklogix.Barcode.ScannerServices.ScannerServicesDriver

        Private mbBeep As Boolean = True

        Private MyGoodAudio As OpenNETCF.Media.SoundPlayer
        Private MyBadAudio As OpenNETCF.Media.SoundPlayer
        Private MyWarnAudio As OpenNETCF.Media.SoundPlayer
        Private MyMistakeAudio As OpenNETCF.Media.SoundPlayer

        '' 0 length arrays
        Private MyGoodScanBuf(-1) As Byte
        Private MyBadScanBuf(-1) As Byte
        Private MyWarningBuf(-1) As Byte
        Private MyMistakeBuf(-1) As Byte

        Private mnVolumePercentProp As Integer = 100

        Private mbIsHHP As Boolean = False

        'these are stored for access when scanner is disabled
        Private mbLastReadCode93 As Boolean = False
        Private mbLastReadCode128 As Boolean = False
        Private mbLastReadI2of5 As Boolean = False

        Public Sub New()
            moScanner = New PsionTeklogix.Barcode.Scanner
            moScannerServicesDriver = New PsionTeklogix.Barcode.ScannerServices.ScannerServicesDriver
            moScanner.Driver = moScannerServicesDriver

            Dim sScanner As String = PsionTeklogix.Barcode.ScannerServices.ScannerServicesDriver.InternalScannerType.ToUpper
            mbIsHHP = InStr(sScanner, "HHP") > 0
            ReadCodeTypeProp()
            ScanFixBeep(True)

            LoadSounds()
        End Sub

        Protected Overrides Sub Disposing()
            MyBase.Disposing()

            If Not moScanner Is Nothing Then
                'Scanner1.Dispose()
                moScanner = Nothing
                moScannerServicesDriver.Dispose()
                moScannerServicesDriver = Nothing
            End If

        End Sub

        Private Sub ReadCodeTypeProp()
            If mbIsHHP Then
                mbLastReadCode128 = moScannerServicesDriver.Code128Enabled
                mbLastReadCode93 = moScannerServicesDriver.Code93Enabled
                mbLastReadI2of5 = moScannerServicesDriver.I2Of5Enabled
            Else
                mbLastReadCode128 = CBool(moScannerServicesDriver.GetProperty("Barcode\C128\HHP\Enabled"))
                mbLastReadCode93 = CBool(moScannerServicesDriver.GetProperty("Barcode\C93\HHP\Enabled"))
                mbLastReadI2of5 = CBool(moScannerServicesDriver.GetProperty("Barcode\I25\HHP\Enabled"))
            End If
        End Sub

        Private Sub moScanner_ScanCompleteEvent(ByVal sender As Object, ByVal e As PsionTeklogix.Barcode.ScanCompleteEventArgs) Handles moScanner.ScanCompleteEvent

            RaiseEventBarCodeRead(e.Text, MapSymbology(e.Symbology))

            '' Scan next barcode
            'If moContinuousProp Then
            '    moScanner.Scan()
            'End If

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
        End Sub

        Private Function GetVolume(ByVal TheVolumePercent As Integer) As Integer
            Dim Factor As Double = TheVolumePercent / 100
            Dim Result As Integer = CInt(Factor * &HFFFF)
            Return Result Or (Result << 16)
        End Function

        Private Function MapSymbology(ByVal i_ePsionSymbology As PsionTeklogix.Barcode.BarcodeSymbology) As Symbologies
            Select Case i_ePsionSymbology
                Case PsionTeklogix.Barcode.BarcodeSymbology.Code128
                    Return Base.Symbologies.Code128
                Case PsionTeklogix.Barcode.BarcodeSymbology.Code93
                    Return Base.Symbologies.Code93
                Case PsionTeklogix.Barcode.BarcodeSymbology.Interleaved2of5
                    Return Base.Symbologies.Interleaved2of5
                Case Else
                    Return Base.Symbologies.Unknown
            End Select
        End Function

        Private Sub ApplySymbologies()
            If Me.Enabled Then
                moScannerServicesDriver.SetProperty("Barcode\C128\HHP\Enabled", mbLastReadCode128)
                moScannerServicesDriver.Code128Enabled = mbLastReadCode128

                moScannerServicesDriver.SetProperty("Barcode\C93\HHP\Enabled", mbLastReadCode93)
                moScannerServicesDriver.Code93Enabled = mbLastReadCode93

                moScannerServicesDriver.I2Of5Enabled = mbLastReadI2of5
                moScannerServicesDriver.SetProperty("Barcode\I25\HHP\Enabled", mbLastReadI2of5)

                moScannerServicesDriver.ApplySettingChanges()
            End If
        End Sub

        Public Overrides Property Code128() As Boolean
            Get
                Return mbLastReadCode128
            End Get
            Set(ByVal value As Boolean)
                If mbLastReadCode128 <> value Then
                    mbLastReadCode128 = value
                    ApplySymbologies()
                End If
            End Set
        End Property

        Public Overrides Property Code93() As Boolean
            Get
                Return mbLastReadCode93
            End Get
            Set(ByVal value As Boolean)
                If mbLastReadCode93 <> value Then
                    mbLastReadCode93 = value
                    ApplySymbologies()
                End If
            End Set
        End Property

        Public Overrides Property Interleaved2of5() As Boolean
            Get
                Return mbLastReadI2of5
            End Get
            Set(ByVal value As Boolean)
                If mbLastReadI2of5 <> value Then
                    mbLastReadI2of5 = value
                    ApplySymbologies()
                End If
            End Set
        End Property

        Public Overrides Property Continuous() As Boolean
            Get
                Return False 'moContinuousProp
            End Get
            Set(ByVal value As Boolean)
                'moContinuousProp = value

                'If moContinuousProp Then
                '    moScanner.Scan()
                'Else
                '    If moScanner.Enabled Then
                '        moScanner.Enabled = False
                '        moScanner.Enabled = True
                '    End If
                'End If
            End Set
        End Property

        Public Overrides ReadOnly Property ContinuousSupported() As Boolean
            Get
                Return False
            End Get
        End Property

        Public Overrides Property Enabled() As Boolean
            Get
                If moScannerServicesDriver Is Nothing Then
                    Return False
                End If
                Return moScanner.Enabled
            End Get
            Set(ByVal value As Boolean)
                moScanner.Enabled = value
                If value Then
                    ScanFixBeep(False) 'false because the next function does this
                    ApplySymbologies()
                End If
            End Set
        End Property

        Public Overrides Property Beep() As Boolean
            Get
                Return mbBeep
            End Get
            Set(ByVal value As Boolean)
                If mbBeep <> value Then
                    mbBeep = value
                    ScanFixBeep(True)
                End If
            End Set
        End Property

        Private Sub ScanFixBeep(ByVal i_bApplySettings As Boolean)
            If Me.Enabled Then
                If mbBeep Then
                    moScannerServicesDriver.ScanBeep = False
                    moScannerServicesDriver.ScanFailedBeep = False
                Else
                    moScannerServicesDriver.ScanBeep = True
                    moScannerServicesDriver.ScanFailedBeep = True
                End If
                If i_bApplySettings Then
                    moScannerServicesDriver.ApplySettingChanges()
                End If
            End If
        End Sub

        Public Overrides ReadOnly Property BeepSupported() As Boolean
            Get
                Return True
            End Get
        End Property

        Public Overrides Property LED() As Boolean
            Get
                Return False
            End Get
            Set(ByVal value As Boolean)

            End Set
        End Property

        Public Overrides ReadOnly Property LEDSupported() As Boolean
            Get
                Return False
            End Get
        End Property

        Public Overrides Property Vibrate() As Boolean
            Get
                Return False
            End Get
            Set(ByVal value As Boolean)

            End Set
        End Property

        Public Overrides ReadOnly Property VibrateSupported() As Boolean
            Get
                Return False
            End Get
        End Property

        Public Overrides Property VolumePercent() As Integer
            Get
                Return mnVolumePercentProp
            End Get
            Set(ByVal value As Integer)
                mnVolumePercentProp = value
            End Set
        End Property

    End Class

End Namespace