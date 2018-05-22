Public Class CityConfig

    Private wireless802 As Boolean
    Private wireless As Boolean
    Private wired As Boolean
    Private autosend As Boolean
    Private autosendWhenDocked As Boolean
    Private autosendPeriodicity As Integer
    Private groundHandler As Boolean
    Private lateMailPrompt As Boolean
    Private allowLateMailAccept As Boolean
    Private allowLateMailAcceptPeriod As Integer

    Private IsFTPOverrideProp As Boolean
    Private FTPHostNameProp As String
    Public FTPPort As Integer = -1
    Public FTPLogin As String
    Public FTPPassword As String

    Public ReadOnly Property IsFTPOverride()
        Get
            If FTPHostNameProp <> "" And FTPLogin <> "" And FTPPassword <> "" And FTPPort <> -1 Then
                Return True
            Else
                Return False
            End If
        End Get
    End Property

    Public Property FTPHostName() As String
        Get
            Return FTPHostNameProp
        End Get
        Set(ByVal Value As String)
            FTPHostNameProp = Value
            If FTPPort = -1 Then FTPPort = 21
            If FTPLogin = "" Then FTPLogin = "anonymous"
            If FTPPassword = "" Then FTPPassword = "tagtrak@tagtrak.com"
        End Set

    End Property

    Public Sub New()
        wireless802 = True
        wireless = True
        wired = True
        autosend = False
        autosendWhenDocked = False
        autosendPeriodicity = 20
        groundHandler = False
        lateMailPrompt = True
        allowLateMailAccept = False
        allowLateMailAcceptPeriod = 0
    End Sub

    Public Property GetSetWireless802() As Boolean
        Get
            Return wireless802
        End Get
        Set(ByVal Value As Boolean)
            wireless802 = Value
        End Set
    End Property

    Public Property GetSetWireless() As Boolean
        Get
            Return wireless
        End Get
        Set(ByVal Value As Boolean)
            wireless = Value
        End Set
    End Property

    Public Property GetSetWired() As Boolean
        Get
            Return wired
        End Get
        Set(ByVal Value As Boolean)
            wired = Value
        End Set
    End Property

    Public Property GetSetAutosend() As Boolean
        Get
            Return autosend
        End Get
        Set(ByVal Value As Boolean)
            autosend = Value
        End Set
    End Property

    'Added by MDD on 12/27/06 to allow for 'upload when docked' capability.

    Public Property GetSetAutosendWhenDocked() As Boolean
        Get
            Return autosendWhenDocked
        End Get
        Set(ByVal Value As Boolean)
            autosendWhenDocked = Value
        End Set
    End Property

    Public Property GetSetAutosendPeriodicity() As Integer
        Get
            Return autosendPeriodicity
        End Get
        Set(ByVal Value As Integer)
            autosendPeriodicity = Value
        End Set
    End Property

    Public Property GetSetgroundHandler() As Boolean
        Get
            Return groundHandler
        End Get
        Set(ByVal Value As Boolean)
            groundHandler = Value
        End Set
    End Property

    Public Property GetSetlateMailPrompt() As Boolean
        Get
            Return lateMailPrompt
        End Get
        Set(ByVal Value As Boolean)
            lateMailPrompt = Value
        End Set
    End Property

    Public Property GetSetAllowLateMailAccept() As Boolean
        Get
            Return allowLateMailAccept
        End Get
        Set(ByVal Value As Boolean)
            allowLateMailAccept = Value
        End Set
    End Property

    Public Property GetSetAllowLateMailAcceptPeriod() As Integer
        Get
            Return allowLateMailAcceptPeriod
        End Get
        Set(ByVal Value As Integer)
            allowLateMailAcceptPeriod = Value
        End Set
    End Property

    Public Overrides Function toString() As String

        If Not IsFTPOverride Then
            Return "<Wireless802.11>" & wireless802 & "</Wireless802.11>" _
                            & "<Wireless>" & wireless & "</Wireless>" _
                            & "<Wired>" & wired & "</Wired>" _
                            & "<Autosend>" & autosend & "</Autosend>" _
                            & "<AutosendPeriodicity>" & autosendPeriodicity & "</AutosendPeriodicity>" _
                            & "<Groundhandler>" & groundHandler & "</Groundhandler>" _
                            & "<LateMailPrompt>" & lateMailPrompt & "</LateMailPrompt>" _
                            & "<AllowLateMailAccept>" & allowLateMailAccept & "</AllowLateMailAccept>" _
                            & "<AllowLateMailAcceptPeriod>" & allowLateMailAcceptPeriod & "</AllowLateMailAcceptPeriod>"

        Else
            Return "<Wireless802.11>" & wireless802 & "</Wireless802.11>" _
                            & "<Wireless>" & wireless & "</Wireless>" _
                            & "<Wired>" & wired & "</Wired>" _
                            & "<Autosend>" & autosend & "</Autosend>" _
                            & "<AutosendPeriodicity>" & autosendPeriodicity & "</AutosendPeriodicity>" _
                            & "<Groundhandler>" & groundHandler & "</Groundhandler>" _
                            & "<LateMailPrompt>" & lateMailPrompt & "</LateMailPrompt>" _
                            & "<AllowLateMailAccept>" & allowLateMailAccept & "</AllowLateMailAccept>" _
                            & "<AllowLateMailAcceptPeriod>" & allowLateMailAcceptPeriod & "</AllowLateMailAcceptPeriod>" _
                            & "<FtpHostName>" & FTPHostName & "</FtpHostName>" _
                            & "<FtpPortNumber>" & FTPPort.ToString & "</FtpPortNumber>" _
                            & "<FtpLoginID>" & FTPLogin & "</FtpLoginID>" _
                            & "<FtpPassword>" & FTPPassword & "</FtpPassword>"
        End If


    End Function

End Class
