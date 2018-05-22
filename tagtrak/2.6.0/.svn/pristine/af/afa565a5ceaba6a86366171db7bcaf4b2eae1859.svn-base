Public Class CargoScanFormRepository

    Private Shared CargoScanBaseFormRef As CargoScanBaseForm = Nothing

    Public Shared Property CargoScanBaseForm() As CargoScanBaseForm

        Get
            If CargoScanBaseFormRef Is Nothing Then CargoScanBaseFormRef = New CargoScanBaseForm
            CargoScanBaseFormRef.DialogResult = DialogResult.OK

            Return CargoScanBaseFormRef

        End Get

        Set(ByVal Value As CargoScanBaseForm)
            MsgBox("Cannot set CargoScanBaseForm")
        End Set

    End Property

    Public Shared Sub CloseAll()
        If Not CargoScanBaseFormRef Is Nothing Then
            CargoScanBaseFormRef.Close()
        End If
    End Sub

End Class
