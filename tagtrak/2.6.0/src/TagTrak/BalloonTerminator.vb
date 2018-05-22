' This form shows up then disappear instantly, for the sole purpose to kill 
' the balloon window from wireless connection, which provides access to OS user interface

Public Class BalloonTerminator
    Inherits System.Windows.Forms.Form

    'Public ParentForm As Windows.Forms.Form

#Region " Windows Form Designer generated code "

    Public Sub New()
        MyBase.New()

        'This call is required by the Windows Form Designer.
        InitializeComponent()

        'Add any initialization after the InitializeComponent() call

    End Sub

    Protected Overloads Overrides Sub Dispose(ByVal disposing As Boolean)
        MyBase.Dispose(disposing)
    End Sub

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        '
        'BalloonTerminator
        '
        Me.ControlBox = False
        Me.Text = "TagTrak"

    End Sub

#End Region

    Private Sub BalloonTerminator_Paint(ByVal sender As Object, ByVal e As System.Windows.Forms.PaintEventArgs) Handles MyBase.Paint
        'If Not Me.ParentForm Is Nothing Then Me.ParentForm.BringToFront()
        Me.Close()
    End Sub

    ' Serve as a fall-back approach, in case onpaint event above somehow failed, user can still get back to main form.
    Private Sub BalloonTerminator_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Click
        Me.Close()
    End Sub
End Class
