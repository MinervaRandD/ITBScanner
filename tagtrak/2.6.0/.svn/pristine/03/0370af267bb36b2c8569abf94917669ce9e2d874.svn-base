Public Class AdminFormRepository

    Private Shared adminBaseFormRef As adminBaseForm = Nothing

    'Modified by MX
    Private Shared adminSubConfigFormRef As AdminSubConfigForm = Nothing

    Private Shared adminConfigFormRef As adminConfigForm = Nothing
    Private Shared adminFtpClientFormRef As adminFtpClientForm = Nothing
    Private Shared adminFunctionsNotificationFormRef As adminFunctionsNotificationForm = Nothing
    Private Shared adminLoggingFormRef As adminLoggingForm = Nothing
    Private Shared adminLoginFormRef As adminLoginForm = Nothing
    Private Shared adminPasswordFormRef As adminPasswordForm = Nothing
    Private Shared adminResditFormRef As adminResditForm = Nothing
    Private Shared adminUploadFileFormRef As adminUploadFileForm = Nothing
    Private Shared adminResditFileDisplayFormRef As adminResditFileDisplayForm = Nothing
    Private Shared adminUploadResditFileFormRef As adminUploadResditFileForm = Nothing
    Private Shared adminDownloadFileFormRef As adminDownloadFileForm = Nothing

    Public Shared ReadOnly Property adminBaseForm() As adminBaseForm

        Get
            If adminBaseFormRef Is Nothing Then adminBaseFormRef = New adminBaseForm
            adminBaseFormRef.DialogResult = DialogResult.OK

            Return adminBaseFormRef

        End Get

    End Property

    'Added by MX
    Public Shared ReadOnly Property adminSubConfigForm() As adminSubConfigForm

        Get

            If adminSubConfigFormRef Is Nothing Then adminSubConfigFormRef = New AdminSubConfigForm
            adminSubConfigFormRef.DialogResult = DialogResult.OK

            Return adminSubConfigFormRef

        End Get

    End Property

    Public Shared ReadOnly Property adminConfigForm() As adminConfigForm

        Get

            If adminConfigFormRef Is Nothing Then adminConfigFormRef = New adminConfigForm
            adminConfigFormRef.DialogResult = DialogResult.OK

            Return adminConfigFormRef

        End Get

    End Property

    'Public Shared ReadOnly Property adminDateTimeForm() As adminDateTimeForm

    '    Get
    '        If adminDateTimeFormRef Is Nothing Then adminDateTimeFormRef = New adminDateTimeForm
    '        adminDateTimeFormRef.DialogResult = DialogResult.OK

    '        Return adminDateTimeFormRef

    '    End Get

    'End Property

    Public Shared ReadOnly Property adminFtpClientForm() As adminFtpClientForm

        Get
            If adminFtpClientForm Is Nothing Then adminFtpClientFormRef = New adminFtpClientForm
            adminFtpClientFormRef.DialogResult = DialogResult.OK

            Return adminFtpClientFormRef

        End Get

    End Property

    Public Shared ReadOnly Property adminFunctionsNotificationForm() As adminFunctionsNotificationForm

        Get
            If adminFunctionsNotificationFormRef Is Nothing Then adminFunctionsNotificationFormRef = New adminFunctionsNotificationForm
            adminFunctionsNotificationFormRef.DialogResult = DialogResult.OK

            Return adminFunctionsNotificationFormRef

        End Get

    End Property

    Public Shared ReadOnly Property adminLoggingForm() As adminLoggingForm

        Get
            If adminLoggingFormRef Is Nothing Then adminLoggingFormRef = New adminLoggingForm
            adminLoggingFormRef.DialogResult = DialogResult.OK

            Return adminLoggingFormRef

        End Get

    End Property

    Public Shared ReadOnly Property adminLoginForm() As adminLoginForm

        Get
            If adminLoginFormRef Is Nothing Then adminLoginFormRef = New adminLoginForm
            adminLoginFormRef.DialogResult = DialogResult.OK

            Return adminLoginFormRef

        End Get

    End Property

    Public Shared ReadOnly Property adminPasswordForm() As adminPasswordForm

        Get
            If adminPasswordFormRef Is Nothing Then adminPasswordFormRef = New adminPasswordForm
            adminPasswordFormRef.DialogResult = DialogResult.OK

            Return adminPasswordFormRef

        End Get

    End Property

    Public Shared ReadOnly Property adminResditForm() As adminResditForm

        Get
            If adminResditFormRef Is Nothing Then adminResditFormRef = New adminResditForm
            adminResditFormRef.DialogResult = DialogResult.OK

            Return adminResditFormRef

        End Get

    End Property

    Public Shared ReadOnly Property adminUploadFileForm() As adminUploadFileForm

        Get
            If adminUploadFileFormRef Is Nothing Then adminUploadFileFormRef = New adminUploadFileForm
            adminUploadFileFormRef.DialogResult = DialogResult.OK

            Return adminUploadFileFormRef

        End Get

    End Property

    Public Shared ReadOnly Property adminResditFileDisplayForm() As adminResditFileDisplayForm

        Get
            If adminResditFileDisplayFormRef Is Nothing Then adminResditFileDisplayFormRef = New adminResditFileDisplayForm
            adminResditFileDisplayFormRef.DialogResult = DialogResult.OK

            Return adminResditFileDisplayFormRef

        End Get

    End Property

    Public Shared ReadOnly Property adminUploadResditFileForm() As adminUploadResditFileForm

        Get
            If adminUploadResditFileFormRef Is Nothing Then adminUploadResditFileFormRef = New adminUploadResditFileForm
            adminUploadResditFileFormRef.DialogResult = DialogResult.OK

            Return adminUploadResditFileFormRef

        End Get

    End Property

    Public Shared ReadOnly Property adminDownloadFileForm() As adminDownloadFileForm

        Get
            If adminDownloadFileFormRef Is Nothing Then adminDownloadFileFormRef = New adminDownloadFileForm
            adminDownloadFileFormRef.DialogResult = DialogResult.OK

            Return adminDownloadFileFormRef

        End Get

    End Property

    Public Shared Sub CloseAll()
        If Not adminBaseFormRef Is Nothing Then
            adminBaseFormRef.baseFormTimer.Enabled = False
            adminBaseFormRef.Close()
        End If
        'Added by MX
        If Not adminSubConfigFormRef Is Nothing Then adminSubConfigFormRef.Close()

        If Not adminConfigFormRef Is Nothing Then adminConfigFormRef.Close()
        'If Not adminDateTimeFormRef Is Nothing Then adminDateTimeFormRef.Close()
        If Not adminFtpClientFormRef Is Nothing Then adminFtpClientFormRef.Close()
        If Not adminFunctionsNotificationFormRef Is Nothing Then adminFunctionsNotificationFormRef.Close()
        If Not adminLoggingFormRef Is Nothing Then adminLoggingFormRef.Close()
        If Not adminLoginFormRef Is Nothing Then adminLoginFormRef.Close()
        If Not adminPasswordFormRef Is Nothing Then adminPasswordFormRef.Close()
        If Not adminResditFormRef Is Nothing Then adminResditFormRef.Close()
        If Not adminUploadFileFormRef Is Nothing Then adminUploadFileFormRef.Close()
        If Not adminResditFileDisplayFormRef Is Nothing Then adminResditFileDisplayFormRef.Close()
        If Not adminUploadResditFileFormRef Is Nothing Then adminUploadResditFileFormRef.Close()
        If Not adminDownloadFileFormRef Is Nothing Then adminDownloadFileFormRef.Close()
    End Sub
End Class
