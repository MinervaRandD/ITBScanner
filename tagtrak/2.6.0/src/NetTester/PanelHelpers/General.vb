Namespace PanelHelpers

    '' Represents the Generic PanelHelper
    '' All PanelHelpers must have a Load sub
    Public MustInherit Class General

        Protected MyForm As FormMain
        Sub New(ByVal TheForm As FormMain)
            MyForm = TheForm
        End Sub

        Public MustOverride Sub Load()

    End Class

End Namespace