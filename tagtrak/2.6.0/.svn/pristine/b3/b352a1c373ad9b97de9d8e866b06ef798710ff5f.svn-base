Public Class tagTrakFormRepository

    Private Shared tagTrakMessageFormRef As tagTrakMessageForm = Nothing
    Private Shared tagTrakTagTrakSetupMenuFormRef As tagTrakTagTrakSetupMenuForm = Nothing

    Private Shared resditUploadReminderFormRef As resditUploadReminderForm = Nothing

    Private Shared initializationFormRef As initializationForm = Nothing

    Private Shared TagTrakBaseFormRef As TagTrakBaseForm = Nothing

    'Added by MX
    Private Shared TagTrakLoginRef As TagTrakLogin = Nothing


    Public Shared Property resditUploadReminderForm() As resditUploadReminderForm

        Get

            If resditUploadReminderFormRef Is Nothing Then resditUploadReminderFormRef = New resditUploadReminderForm
            resditUploadReminderFormRef.DialogResult = DialogResult.OK

            Return resditUploadReminderFormRef

        End Get

        Set(ByVal Value As resditUploadReminderForm)
            MsgBox("Cannot set resditUploadReminderForm")
        End Set

    End Property

    Public Shared Property tagTrakMessageForm() As tagTrakMessageForm

        Get

            If tagTrakMessageFormRef Is Nothing Then tagTrakMessageFormRef = New tagTrakMessageForm
            tagTrakMessageFormRef.DialogResult = DialogResult.OK

            Return tagTrakMessageFormRef

        End Get

        Set(ByVal Value As tagTrakMessageForm)
            MsgBox("Cannot set tagTrakMessageForm")
        End Set
    End Property

    Public Shared Property tagTrakTagTrakSetupMenuForm() As tagTrakTagTrakSetupMenuForm

        Get

            If tagTrakTagTrakSetupMenuFormRef Is Nothing Then tagTrakTagTrakSetupMenuFormRef = New tagTrakTagTrakSetupMenuForm
            tagTrakTagTrakSetupMenuFormRef.DialogResult = DialogResult.OK

            Return tagTrakTagTrakSetupMenuFormRef

        End Get

        Set(ByVal Value As tagTrakTagTrakSetupMenuForm)
            MsgBox("Cannot set tagTrakTagTrakSetupMenuForm")
        End Set

    End Property

    Public Shared Property initializationForm() As initializationForm

        Get

            If initializationFormRef Is Nothing Then initializationFormRef = New initializationForm
            initializationFormRef.DialogResult = DialogResult.OK

            Return initializationFormRef

        End Get

        Set(ByVal Value As initializationForm)
            MsgBox("Cannot set tagTrakTagTrakSetupMenuForm")
        End Set

    End Property


    'Added by MX
    Public Shared Property TagTrakLogin() As TagTrakLogin

        Get

            If TagTrakLoginRef Is Nothing Then

                TagTrakLoginRef = New TagTrakLogin

            End If

            Return TagTrakLoginRef

        End Get

        Set(ByVal Value As TagTrakLogin)

            TagTrakLoginRef = Value

        End Set

    End Property


    Public Shared Property TagTrakBaseForm() As TagTrakBaseForm
        Get
            If TagTrakBaseFormRef Is Nothing Then TagTrakBaseFormRef = New TagTrakBaseForm
            Return TagTrakBaseFormRef
        End Get

        Set(ByVal Value As TagTrakBaseForm)
            TagTrakBaseFormRef = Value
        End Set
    End Property

    Public Shared Sub CloseAll()
        If Not tagTrakMessageFormRef Is Nothing Then tagTrakMessageFormRef.Close()
        If Not tagTrakTagTrakSetupMenuFormRef Is Nothing Then tagTrakTagTrakSetupMenuFormRef.Close()
        If Not resditUploadReminderFormRef Is Nothing Then resditUploadReminderFormRef.Close()
        If Not initializationFormRef Is Nothing Then
            initializationFormRef.DialogResult = DialogResult.Abort
            initializationFormRef.Close()
        End If
        If Not TagTrakBaseFormRef Is Nothing Then
            TagTrakBaseFormRef.DialogResult = DialogResult.Abort
            TagTrakBaseFormRef.Close()
        End If
    End Sub
End Class
