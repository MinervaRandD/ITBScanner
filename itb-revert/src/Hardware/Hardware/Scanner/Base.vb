Option Explicit On 
Option Strict On

Namespace Scanner
    Public MustInherit Class Base
        Implements IDisposable

        Public Enum FeedbackTypes
            GoodScan
            BadScan
            Warning
            Mistake '' ie Error
        End Enum

        Public Enum Symbologies
            Unknown
            Code128
            Code93
            Interleaved2of5
        End Enum

        Protected MyDeviceType As Device.DeviceTypes

        Private MyLastBarCode As String
        Private MyLastSymbology As Symbologies

        '' Called when barcode was read in
        Public Event BarCodeRead(ByVal TheBarCode As String, ByVal TheSymbology As Symbologies)

        '' Called when a duplicate barcode was read in
        Public Event BarCodeReadDuplicate()

        '' Support required, enables/disables scan beam
        Public MustOverride Property Enabled() As Boolean

        '' Support not required, do nothing if requested and not supported
        Public MustOverride Property Code93() As Boolean

        '' Support not required, do nothing if requested and not supported
        Public MustOverride Property Code128() As Boolean

        '' Support not required, do nothing if requested and not supported
        Public MustOverride Property Interleaved2of5() As Boolean

        '' Support not required, do nothing if requested and not supported
        Public MustOverride Property Continuous() As Boolean

        '' Must report if device supports continuous mode
        Public MustOverride ReadOnly Property ContinuousSupported() As Boolean

        '' Support not required, do nothing if requested and not supported
        '' Volume for beeper in percent
        Public MustOverride Property VolumePercent() As Integer

        '' Support not required, do nothing if requested and not supported
        Public MustOverride Sub Feedback(ByVal TheType As Base.FeedbackTypes)

        '' Support not required, do nothing if requested and not supported
        Public MustOverride Property Vibrate() As Boolean

        '' Must report if device supports vibration
        Public MustOverride ReadOnly Property VibrateSupported() As Boolean

        '' Support not required, do nothing if requested and not supported
        Public MustOverride Property Beep() As Boolean

        '' Must report if device supports beeps
        Public MustOverride ReadOnly Property BeepSupported() As Boolean

        '' Support not required, do nothing if requested and not supported
        Public MustOverride Property LED() As Boolean

        '' Must report if device supports LED operations
        Public MustOverride ReadOnly Property LEDSupported() As Boolean

        '' Ignores duplicate scans (On by default)
        Private IgnoreDuplicatesProp As Boolean
        Public Property IgnoreDuplicates() As Boolean
            Get
                Return IgnoreDuplicatesProp
            End Get
            Set(ByVal Value As Boolean)
                IgnoreDuplicatesProp = Value
            End Set
        End Property

        Sub New()
            VolumePercent = 100
            Continuous = False
            IgnoreDuplicatesProp = True

            If BeepSupported Then Beep = True
            If LEDSupported Then LED = True
            If VibrateSupported Then Vibrate = True

        End Sub

        '' Gets an instance if the Hardware.Scanner.Base class specific to the current device
        Public Shared Function GetInstance() As Base
            Select Case Hardware.Device.GetDeviceType
                Case Device.DeviceTypes.IntermecPPC
                    'Return New IntermecPPC

                Case Device.DeviceTypes.Symbol
                    Return New SymbolPPC

                Case Device.DeviceTypes.PsionTeklogix
                    Return New PsionTeklogixScanner

                Case Device.DeviceTypes.Unknown
                    Return New Unknown

                Case Else
                    Throw New ApplicationException("This device is not supported yet.")

            End Select
        End Function

        '' Called from derived classes on a bar code read
        Protected Sub RaiseEventBarCodeRead(ByVal TheBarCode As String, ByVal TheSymbology As Symbologies)
            If IgnoreDuplicatesProp Then
                If MyLastBarCode <> TheBarCode Or MyLastSymbology <> TheSymbology Then
                    MyLastBarCode = TheBarCode
                    MyLastSymbology = TheSymbology
                    RaiseEvent BarCodeRead(TheBarCode, TheSymbology)
                Else
                    RaiseEvent BarCodeReadDuplicate()
                End If
            Else
                RaiseEvent BarCodeRead(TheBarCode, TheSymbology)
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
End Namespace
