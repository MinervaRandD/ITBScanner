Namespace PanelHelpers
    Public Class Upload
        Inherits General

        '' Upload results to ASI
        Private WithEvents ButtonUpload As Button
        Private WithEvents ButtonNext As Button
        '' Upload status
        Private LabelStatus As Label
        '' Progress of upload
        Private ProgressBarUpload As ProgressBar

        Private WithEvents MyUploader As Uploader.Results

        Sub New(ByVal TheForm As FormMain)
            MyBase.New(TheForm)
        End Sub

        Public Overrides Sub Load()
            With MyForm
                ButtonUpload = .ButtonUpload
                ButtonNext = .ButtonUploadNext
                LabelStatus = .LabelUploadStatus
                ProgressBarUpload = .ProgressBarUpload
            End With

            ButtonUpload.Enabled = True
            ButtonNext.Enabled = False
            LabelStatus.Text = ""
            '' Make italic
            LabelStatus.Font = New Font(LabelStatus.Font.Name, LabelStatus.Font.Size, FontStyle.Italic)
            ProgressBarUpload.Visible = False
            ProgressBarUpload.Value = 0

            MyUploader = New Uploader.Results(myform, myform.MyWriter.GetStream)

        End Sub

        '' Go upload now
        Private Sub ButtonUpload_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles ButtonUpload.Click
            ButtonUpload.Enabled = False
            '' Make italic
            LabelStatus.Font = New Font(LabelStatus.Font.Name, LabelStatus.Font.Size, FontStyle.Italic)
            ProgressBarUpload.Visible = True

            MyUploader.Start()
        End Sub

        Private Sub ButtonNext_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles ButtonNext.Click
            MyForm.MyUIMan.SwitchToPanel(UIMan.PanelTypes.Finish)
        End Sub

        '' Progress/status update
        Private Sub MyUploader_ProgressUpdate(ByVal ThePercent As Integer, ByVal TheStatus As String) Handles MyUploader.ProgressUpdate
            ProgressBarUpload.Value = ThePercent
            LabelStatus.Text = TheStatus
        End Sub

        '' Upload finished, display success status and present retry option if not successful
        '' or allow to continue nevertheless
        Private Sub MyUploader_Finished(ByVal IsSuccess As Boolean) Handles MyUploader.Finished
            '' Make standard
            LabelStatus.Font = New Font(LabelStatus.Font.Name, LabelStatus.Font.Size, FontStyle.Regular)

            If IsSuccess Then
                LabelStatus.Text = "Uploaded results successfully."
                If Util.SerialNumber.ToString <> "" Then
                    LabelStatus.Text &= vbCrLf & "Scanner Serial Number: " & Util.SerialNumber.ToString
                End If
            Else
                LabelStatus.Text = "Failed to upload results." & vbCrLf & _
                                    "Check your connection and retry or tap next to continue without sending your results."

                ButtonUpload.Enabled = True
            End If
            ButtonNext.Enabled = True

        End Sub

    End Class

End Namespace
