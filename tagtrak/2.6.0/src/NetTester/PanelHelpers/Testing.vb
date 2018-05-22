Namespace PanelHelpers
    Public Class Testing
        Inherits General

        '' After tests finish, Next is enabled to go to submission question
        Private WithEvents ButtonNext As Button
        '' Overall test progress bar
        Private ProgressBarTest As ProgressBar
        '' Status of each test as it's conducted
        Private LabelStatus As Label
        '' The tester that conducts tests
        Private WithEvents MyTester As Test.Tester

        Sub New(ByVal TheForm As FormMain)
            MyBase.New(TheForm)
            MyTester = TheForm.MyTester
        End Sub

        Public Overrides Sub Load()
            With MyForm
                ButtonNext = .ButtonTestingNext
                ProgressBarTest = .ProgressBarTesting
                LabelStatus = .LabelTestingStatus
            End With

            ButtonNext.Enabled = False
            LabelStatus.Text = ""
            '' Make italic
            LabelStatus.Font = New Font(LabelStatus.Font.Name, LabelStatus.Font.Size, FontStyle.Italic)
            LabelStatus.ForeColor = Color.Black
            ProgressBarTest.Value = 0

            '' Start the actual testing
            MyTester.Start()

        End Sub

        Private Sub ButtonNext_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles ButtonNext.Click
            MyForm.MyUIMan.SwitchToPanel(UIMan.PanelTypes.Submit)
        End Sub

        '' All tests finished
        Private Sub MyTester_Finished() Handles MyTester.Finished
            ProgressBarTest.Value = 100
            ButtonNext.Enabled = True
            '' Make bold
            LabelStatus.Font = New Font(LabelStatus.Font.Name, LabelStatus.Font.Size, FontStyle.Bold)
            If MyTester.Score = 100 Then
                LabelStatus.ForeColor = Color.Green
            ElseIf MyTester.Score >= 50 Then
                LabelStatus.ForeColor = Color.Orange
            Else
                LabelStatus.ForeColor = Color.Red
            End If
            LabelStatus.Text = "Your connectivity score is " & MyTester.Score.ToString & "%"
        End Sub

        '' Update progress/status
        Private Sub MyTester_ProgressUpdate(ByVal TheProgress As Integer, ByVal TheStatus As String) Handles MyTester.ProgressUpdate
            ProgressBarTest.Value = TheProgress
            LabelStatus.Text = TheStatus
        End Sub

    End Class

End Namespace
