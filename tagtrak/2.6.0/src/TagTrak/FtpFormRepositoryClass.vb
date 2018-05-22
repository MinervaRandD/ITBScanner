Public Class FtpFormRepository

    Private Shared ftpFailureNotificationRef As ftpFailureNotification = Nothing
    Private Shared ftpMsgFormDeviceNotInCradleRef As ftpMsgFormDeviceNotInCradle = Nothing
    Private Shared ftpMsgFormDeviceNotInCradleHelpRef As ftpMsgFormDeviceNotInCradleHelp = Nothing
    Private Shared ftpMsgFormEtherConnFailRef As ftpMsgFormEtherConnFail = Nothing
    Private Shared ftpMsgFormEtherConnFailHelpRef As ftpMsgFormEtherConnFailHelp = Nothing
    Private Shared ftpMsgFormLoginFailureRef As ftpMsgFormLoginFailure = Nothing
    Private Shared ftpMsgFormLoginFailureHelpRef As ftpMsgFormLoginFailureHelp = Nothing
    Private Shared ftpMsgFormSysErrorRef As ftpMsgFormSysError = Nothing
    Private Shared ftpMsgFormSysWarningRef As ftpMsgFormSysWarning = Nothing
    Private Shared ftpMsgFormWirelessConnFailRef As ftpMsgFormWirelessConnFail = Nothing
    Private Shared ftpMsgFormWirelessFtpConnFailHelpRef As ftpMsgFormWirelessFtpConnFailHelp = Nothing
    Private Shared ftpUploadDownloadProcessFailRef As ftpUploadDownloadProcessFail = Nothing
    Private Shared ftpMsgUploadDownloadProcessFailHelpRef As ftpMsgUploadDownloadProcessFailHelp = Nothing

    Public Shared ReadOnly Property ftpFailureNotificiation() As ftpFailureNotification

        Get
            If ftpFailureNotificationRef Is Nothing Then ftpFailureNotificationRef = New ftpFailureNotification
            'ftpFailureNotificationRef.DialogResult = DialogResult.OK

            Return ftpFailureNotificationRef

        End Get

        'Set(ByVal Value As ftpFailureNotification)
        '    MsgBox("Cannot set ftpFailureNotificiation")
        'End Set

    End Property

    Public Shared ReadOnly Property ftpMsgFormDeviceNotInCradle() As ftpMsgFormDeviceNotInCradle

        Get
            If ftpMsgFormDeviceNotInCradleRef Is Nothing Then ftpMsgFormDeviceNotInCradleRef = New ftpMsgFormDeviceNotInCradle
            'ftpMsgFormDeviceNotInCradleRef.DialogResult = DialogResult.OK

            Return ftpMsgFormDeviceNotInCradleRef

        End Get

        'Set(ByVal Value As ftpMsgFormDeviceNotInCradle)
        '    MsgBox("Cannot set ftpMsgFormDeviceNotInCradle")
        'End Set

    End Property

    Public Shared ReadOnly Property ftpMsgFormDeviceNotInCradleHelp() As ftpMsgFormDeviceNotInCradleHelp

        Get
            If ftpMsgFormDeviceNotInCradleHelpRef Is Nothing Then ftpMsgFormDeviceNotInCradleHelpRef = New ftpMsgFormDeviceNotInCradleHelp
            'ftpMsgFormDeviceNotInCradleHelpRef.DialogResult = DialogResult.OK

            Return ftpMsgFormDeviceNotInCradleHelpRef

        End Get

        'Set(ByVal Value As ftpMsgFormDeviceNotInCradleHelp)
        '    MsgBox("Cannot set ftpMsgFormDeviceNotInCradleHelp")
        'End Set

    End Property

    Public Shared ReadOnly Property ftpMsgFormEtherConnFail() As ftpMsgFormEtherConnFail

        Get
            If ftpMsgFormEtherConnFailRef Is Nothing Then ftpMsgFormEtherConnFailRef = New ftpMsgFormEtherConnFail
            'ftpMsgFormDeviceNotInCradleHelpRef.DialogResult = DialogResult.OK

            Return ftpMsgFormEtherConnFailRef

        End Get

        'Set(ByVal Value As ftpMsgFormEtherConnFail)
        '    MsgBox("Cannot set ftpMsgFormEtherConnFail")
        'End Set

    End Property

    Public Shared ReadOnly Property ftpMsgFormEtherConnFailHelp() As ftpMsgFormEtherConnFailHelp

        Get
            If ftpMsgFormEtherConnFailHelpRef Is Nothing Then ftpMsgFormEtherConnFailHelpRef = New ftpMsgFormEtherConnFailHelp
            'ftpMsgFormEtherConnFailHelpRef.DialogResult = DialogResult.OK

            Return ftpMsgFormEtherConnFailHelpRef

        End Get

        'Set(ByVal Value As ftpMsgFormEtherConnFailHelp)
        '    MsgBox("Cannot set ftpMsgFormEtherConnFailHelp")
        'End Set

    End Property

    Public Shared ReadOnly Property ftpMsgFormLoginFailure() As ftpMsgFormLoginFailure

        Get
            If ftpMsgFormLoginFailureRef Is Nothing Then ftpMsgFormLoginFailureRef = New ftpMsgFormLoginFailure
            'ftpMsgFormLoginFailureRef.DialogResult = DialogResult.OK

            Return ftpMsgFormLoginFailureRef

        End Get

        'Set(ByVal Value As ftpMsgFormLoginFailure)
        '    MsgBox("Cannot set ftpMsgFormLoginFailure")
        'End Set

    End Property

    Public Shared ReadOnly Property ftpMsgFormLoginFailureHelp() As ftpMsgFormLoginFailureHelp

        Get
            If ftpMsgFormLoginFailureHelpRef Is Nothing Then ftpMsgFormLoginFailureHelpRef = New ftpMsgFormLoginFailureHelp
            'ftpMsgFormLoginFailureHelpRef.DialogResult = DialogResult.OK

            Return ftpMsgFormLoginFailureHelpRef

        End Get

        'Set(ByVal Value As ftpMsgFormLoginFailureHelp)
        '    MsgBox("Cannot set ftpMsgFormLoginFailureHelp")
        'End Set

    End Property

    Public Shared ReadOnly Property ftpMsgFormSysError() As ftpMsgFormSysError

        Get
            If ftpMsgFormSysErrorRef Is Nothing Then ftpMsgFormSysErrorRef = New ftpMsgFormSysError
            'ftpMsgFormSysError.DialogResult = DialogResult.OK

            Return ftpMsgFormSysErrorRef

        End Get

        'Set(ByVal Value As ftpMsgFormSysError)
        '    MsgBox("Cannot set ftpMsgFormSysError")
        'End Set

    End Property

    Public Shared ReadOnly Property ftpMsgFormSysWarning() As ftpMsgFormSysWarning

        Get
            If ftpMsgFormSysWarningRef Is Nothing Then ftpMsgFormSysWarningRef = New ftpMsgFormSysWarning
            'ftpMsgFormSysWarning.DialogResult = DialogResult.OK

            Return ftpMsgFormSysWarningRef

        End Get

        'Set(ByVal Value As ftpMsgFormSysWarning)
        '    MsgBox("Cannot set ftpMsgFormSysWarning")
        'End Set

    End Property

    Public Shared ReadOnly Property ftpMsgFormWirelessConnFail() As ftpMsgFormWirelessConnFail

        Get
            If ftpMsgFormWirelessConnFailRef Is Nothing Then ftpMsgFormWirelessConnFailRef = New ftpMsgFormWirelessConnFail
            'ftpMsgFormDeviceNotInCradleHelpRef.DialogResult = DialogResult.OK

            Return ftpMsgFormWirelessConnFailRef

        End Get

        'Set(ByVal Value As ftpMsgFormWirelessConnFail)
        '    MsgBox("Cannot set ftpMsgFormWirelessConnFail")
        'End Set

    End Property

    Public Shared ReadOnly Property ftpMsgFormWirelessFtpConnFailHelp() As ftpMsgFormWirelessFtpConnFailHelp

        Get
            If ftpMsgFormWirelessFtpConnFailHelpRef Is Nothing Then ftpMsgFormWirelessFtpConnFailHelpRef = New ftpMsgFormWirelessFtpConnFailHelp
            'ftpMsgFormWirelessFtpConnFailHelpRef.DialogResult = DialogResult.OK

            Return ftpMsgFormWirelessFtpConnFailHelpRef

        End Get

        'Set(ByVal Value As ftpMsgFormWirelessFtpConnFailHelp)
        '    MsgBox("Cannot set ftpMsgFormWirelessFtpConnFailHelp")
        'End Set

    End Property

    Public Shared ReadOnly Property ftpUploadDownloadProcessFail() As ftpUploadDownloadProcessFail

        Get
            If ftpUploadDownloadProcessFailRef Is Nothing Then ftpUploadDownloadProcessFailRef = New ftpUploadDownloadProcessFail
            'ftpUploadDownloadProcessFailRef.DialogResult = DialogResult.OK

            Return ftpUploadDownloadProcessFailRef

        End Get

        'Set(ByVal Value As ftpUploadDownloadProcessFail)
        '    MsgBox("Cannot set ftpUploadDownloadProcessFail")
        'End Set

    End Property

    Public Shared ReadOnly Property ftpMsgUploadDownloadProcessFailHelp() As ftpMsgUploadDownloadProcessFailHelp

        Get
            If ftpMsgUploadDownloadProcessFailHelpRef Is Nothing Then ftpMsgUploadDownloadProcessFailHelpRef = New ftpMsgUploadDownloadProcessFailHelp
            'ftpMsgUploadDownloadProcessFailHelpRef.DialogResult = DialogResult.OK

            Return ftpMsgUploadDownloadProcessFailHelpRef

        End Get

        'Set(ByVal Value As ftpMsgUploadDownloadProcessFailHelp)
        '    MsgBox("Cannot set ftpMsgUploadDownloadProcessFailHelp")
        'End Set

    End Property

End Class
