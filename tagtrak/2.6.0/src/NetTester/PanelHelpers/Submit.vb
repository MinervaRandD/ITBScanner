Namespace PanelHelpers
    Public Class Submit
        Inherits General

        '' Submit to ASI (Yes/No)?
        Private WithEvents ButtonYes As Button
        Private WithEvents ButtonNo As Button

        Sub New(ByVal TheForm As FormMain)
            MyBase.New(TheForm)
        End Sub

        Public Overrides Sub Load()
            With MyForm
                ButtonYes = .ButtonSubmitYes
                ButtonNo = .ButtonSubmitNo
            End With
        End Sub

        Private Sub ButtonYes_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles ButtonYes.Click
            MyForm.MyUIMan.SwitchToPanel(UIMan.PanelTypes.Upload)
        End Sub

        Private Sub ButtonNo_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles ButtonNo.Click
            MyForm.MyUIMan.SwitchToPanel(UIMan.PanelTypes.Finish)
        End Sub

    End Class

End Namespace
