Class BagScanFormRepository

    Private Shared BagScanBaseFormRef As BagScanBaseForm = Nothing

    Public Shared ReadOnly Property BagScanBaseForm() As BagScanBaseForm

        Get
            If BagScanBaseFormRef Is Nothing Then BagScanBaseFormRef = New BagScanBaseForm
            BagScanBaseFormRef.DialogResult = DialogResult.OK

            Return BagScanBaseFormRef

        End Get

        'Set(ByVal Value As BagScanBaseForm)
        '    MsgBox("Cannot set BagScanBaseForm")
        'End Set

    End Property

    Public Shared Sub CloseAll()
        If Not BagScanBaseFormRef Is Nothing Then
            BagScanBaseFormRef.Close()
        End If
    End Sub
End Class
