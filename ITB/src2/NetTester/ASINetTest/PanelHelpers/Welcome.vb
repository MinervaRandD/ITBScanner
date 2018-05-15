Namespace PanelHelpers
    Public Class Welcome
        Inherits General

        Private WithEvents ButtonStart As Button
        Private LabelCopyright As Label

        Sub New(ByVal TheForm As FormMain)
            MyBase.New(TheForm)
        End Sub

        Public Overrides Sub Load()
            With MyForm
                ButtonStart = .ButtonWelcomeStart
                LabelCopyright = .LabelWelcomeCopyright
            End With

            ButtonStart.Enabled = True
            '' Display version/copyright
            Dim Ver As Version = System.Reflection.Assembly.GetExecutingAssembly.GetName.Version
            LabelCopyright.Text = "Version " & Ver.ToString & " (C) 2007-2008 ASI"

        End Sub

        Private Sub ButtonStart_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles ButtonStart.Click
            MyForm.MyUIMan.SwitchToPanel(UIMan.PanelTypes.Testing)
        End Sub

    End Class

End Namespace
