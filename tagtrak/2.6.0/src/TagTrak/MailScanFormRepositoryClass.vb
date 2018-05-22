Public Class MailScanFormRepository

    Private Shared MailScanManifestFormRef As MailScanManifestForm = Nothing
    Private Shared MailScanPresetsFormRef As MailScanPresetsForm = Nothing
    Private Shared MailScanRerouteFormRef As MailScanRerouteForm = Nothing
    Private Shared MailScanBinUploadFormRef As MailScanBinUploadForm = Nothing
    Private Shared MailScanBinChangeFormRef As MailScanBinChangeForm = Nothing
    Private Shared MailScanGetWeightFormRef As MailScanGetWeightForm = Nothing
    Private Shared MailScanCreateNewPresetFormRef As MailScanCreateNewPresetForm = Nothing
    Private Shared MailScanManifestSummaryFormRef As MailScanManifestSummaryForm = Nothing
    Private Shared MailScanDomsFormRef As MailScanDomsForm = Nothing
    Private Shared MailScanIntlFormRef As MailScanIntlForm = Nothing
    Private Shared MailScanGetCarditRoutingFormRef As getCarditRouteForm = Nothing

    'Private Shared MailScanFlightStatusMessageFormRef As MailScanFlightStatusMessageForm = Nothing

    Public Shared ReadOnly Property MailScanDomsForm() As MailScanDomsForm

        Get
            If MailScanDomsFormRef Is Nothing Then MailScanDomsFormRef = New MailScanDomsForm
            'MailScanDomsFormRef.DialogResult = DialogResult.OK

            Return MailScanDomsFormRef

        End Get

        'Set(ByVal Value As MailScanDomsForm)
        '    MsgBox("Cannot set MailScanDomsForm")
        'End Set

    End Property

    Public Shared ReadOnly Property MailScanIntlForm() As MailScanIntlForm

        Get
            If MailScanIntlFormRef Is Nothing Then MailScanIntlFormRef = New MailScanIntlForm
            MailScanIntlFormRef.DialogResult = DialogResult.OK

            Return MailScanIntlFormRef

        End Get

        'Set(ByVal Value As MailScanIntlForm)
        '    MsgBox("Cannot set MailScanIntlForm")
        'End Set

    End Property

    Public Shared ReadOnly Property MailScanManifestForm() As MailScanManifestForm

        Get
            If MailScanManifestFormRef Is Nothing Then MailScanManifestFormRef = New MailScanManifestForm
            MailScanManifestFormRef.DialogResult = DialogResult.OK

            Return MailScanManifestFormRef

        End Get

        'Set(ByVal Value As MailScanManifestForm)
        '    MsgBox("Cannot set MailScanManifestForm")
        'End Set

    End Property
    Public Shared ReadOnly Property MailScanPresetsForm() As MailScanPresetsForm

        Get
            If MailScanPresetsFormRef Is Nothing Then MailScanPresetsFormRef = New MailScanPresetsForm
            MailScanPresetsFormRef.DialogResult = DialogResult.OK

            Return MailScanPresetsFormRef

        End Get

        'Set(ByVal Value As MailScanPresetsForm)
        '    MsgBox("Cannot set MailScanPresetsForm")
        'End Set

    End Property

    Public Shared ReadOnly Property MailScanRerouteForm() As MailScanRerouteForm

        Get
            If MailScanRerouteFormRef Is Nothing Then MailScanRerouteFormRef = New MailScanRerouteForm
            MailScanRerouteFormRef.DialogResult = DialogResult.OK

            Return MailScanRerouteFormRef

        End Get

        'Set(ByVal Value As MailScanRerouteForm)
        '    MsgBox("Cannot set MailScanRerouteForm")
        'End Set

    End Property

    Public Shared ReadOnly Property MailScanBinUploadForm() As MailScanBinUploadForm

        Get
            If MailScanBinUploadFormRef Is Nothing Then MailScanBinUploadFormRef = New MailScanBinUploadForm
            MailScanBinUploadFormRef.DialogResult = DialogResult.OK

            Return MailScanBinUploadFormRef

        End Get

        'Set(ByVal Value As MailScanBinUploadForm)
        '    MsgBox("Cannot set MailScanBinUploadForm")
        'End Set

    End Property

    Public Shared ReadOnly Property MailScanBinChangeForm() As MailScanBinChangeForm

        Get
            If MailScanBinChangeFormRef Is Nothing Then MailScanBinChangeFormRef = New MailScanBinChangeForm
            MailScanBinChangeFormRef.DialogResult = DialogResult.OK

            Return MailScanBinChangeFormRef

        End Get

        'Set(ByVal Value As MailScanBinChangeForm)
        '    MsgBox("Cannot set MailScanBinChangeForm")
        'End Set

    End Property

    Public Shared ReadOnly Property MailScanGetWeightForm() As MailScanGetWeightForm

        Get
            If MailScanGetWeightFormRef Is Nothing Then MailScanGetWeightFormRef = New MailScanGetWeightForm
            'MailScanGetWeightFormRef.DialogResult = DialogResult.OK

            Return MailScanGetWeightFormRef

        End Get

        'Set(ByVal Value As MailScanGetWeightForm)
        '    MsgBox("Cannot set MailScanGetWeightForm")
        'End Set

    End Property

    Public Shared ReadOnly Property MailScanCreateNewPresetForm() As MailScanCreateNewPresetForm

        Get
            If MailScanCreateNewPresetFormRef Is Nothing Then MailScanCreateNewPresetFormRef = New MailScanCreateNewPresetForm
            MailScanCreateNewPresetFormRef.DialogResult = DialogResult.OK

            Return MailScanCreateNewPresetFormRef

        End Get

        'Set(ByVal Value As MailScanCreateNewPresetForm)
        '    MsgBox("Cannot set MailScanCreateNewPresetForm")
        'End Set

    End Property

    Public Shared ReadOnly Property MailScanManifestSummaryForm() As MailScanManifestSummaryForm

        Get
            If MailScanManifestSummaryFormRef Is Nothing Then MailScanManifestSummaryFormRef = New MailScanManifestSummaryForm
            MailScanManifestSummaryFormRef.DialogResult = DialogResult.OK

            Return MailScanManifestSummaryFormRef

        End Get

        'Set(ByVal Value As MailScanManifestSummaryForm)
        '    MsgBox("Cannot set MailScanManifestSummaryForm")
        'End Set

    End Property

    Public Shared ReadOnly Property MailScanGetCarditRouting() As getCarditRouteForm

        Get
            If MailScanGetCarditRoutingFormRef Is Nothing Then MailScanGetCarditRoutingFormRef = New getCarditRouteForm
            MailScanGetCarditRoutingFormRef.DialogResult = DialogResult.OK

            Return MailScanGetCarditRoutingFormRef

        End Get

    End Property

    Public Shared Sub CloseAll()
        If Not MailScanManifestFormRef Is Nothing Then MailScanManifestFormRef.Close()
        If Not MailScanPresetsFormRef Is Nothing Then MailScanPresetsFormRef.Close()
        If Not MailScanRerouteFormRef Is Nothing Then MailScanRerouteFormRef.Close()
        If Not MailScanBinUploadFormRef Is Nothing Then MailScanBinUploadFormRef.Close()
        If Not MailScanBinChangeFormRef Is Nothing Then MailScanBinChangeFormRef.Close()
        If Not MailScanGetWeightFormRef Is Nothing Then MailScanGetWeightFormRef.Close()
        If Not MailScanCreateNewPresetFormRef Is Nothing Then MailScanCreateNewPresetFormRef.Close()
        If Not MailScanManifestSummaryFormRef Is Nothing Then MailScanManifestSummaryFormRef.Close()
        If Not MailScanDomsFormRef Is Nothing Then MailScanDomsFormRef.Close()
        If Not MailScanIntlFormRef Is Nothing Then MailScanIntlFormRef.Close()
        If Not MailScanGetCarditRoutingFormRef Is Nothing Then MailScanGetCarditRoutingFormRef.Close()
        'If Not MailScanFlightStatusMessageFormRef Is Nothing Then MailScanFlightStatusMessageFormRef.Close()
    End Sub

End Class
