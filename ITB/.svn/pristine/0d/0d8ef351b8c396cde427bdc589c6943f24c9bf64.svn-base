Option Explicit On 
Option Strict On

Namespace Scanner

    '' Unknown device does nothing because we don't know how to do stuff on unknown devices.
    Public Class Unknown
        Inherits Base

        Public Overrides Sub Feedback(ByVal TheType As Base.FeedbackTypes)
        End Sub

        Public Overrides Property Code128() As Boolean
            Get
                Return False
            End Get
            Set(ByVal Value As Boolean)
            End Set
        End Property

        Public Overrides Property Code93() As Boolean
            Get
                Return False
            End Get
            Set(ByVal Value As Boolean)
            End Set
        End Property

        Public Overrides Property Continuous() As Boolean
            Get
                Return False
            End Get
            Set(ByVal Value As Boolean)
            End Set
        End Property

        Public Overrides Property Enabled() As Boolean
            Get
                Return False
            End Get
            Set(ByVal Value As Boolean)
            End Set
        End Property

        Public Overrides Property Interleaved2of5() As Boolean
            Get
                Return False
            End Get
            Set(ByVal Value As Boolean)
            End Set
        End Property

        Public Overrides ReadOnly Property ContinuousSupported() As Boolean
            Get
                Return False
            End Get
        End Property

        Public Overrides Property VolumePercent() As Integer
            Get
                Return 0
            End Get
            Set(ByVal Value As Integer)
            End Set
        End Property

        Public Overrides Property Beep() As Boolean
            Get
                Return False
            End Get
            Set(ByVal Value As Boolean)
            End Set
        End Property

        Public Overrides ReadOnly Property BeepSupported() As Boolean
            Get
                Return False
            End Get
        End Property

        Public Overrides Property LED() As Boolean
            Get
                Return False
            End Get
            Set(ByVal Value As Boolean)
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
            Set(ByVal Value As Boolean)
            End Set
        End Property

        Public Overrides ReadOnly Property VibrateSupported() As Boolean
            Get
                Return False
            End Get
        End Property
    End Class

End Namespace
