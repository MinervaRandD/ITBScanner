Public Class NonUSMailWarning
    Inherits System.Windows.Forms.Form
    Friend WithEvents btnNo As System.Windows.Forms.Button
    Friend WithEvents btnYes As System.Windows.Forms.Button
    Friend WithEvents lblNonUSMailWarning As System.Windows.Forms.Label

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
        Me.btnNo = New System.Windows.Forms.Button
        Me.btnYes = New System.Windows.Forms.Button
        Me.lblNonUSMailWarning = New System.Windows.Forms.Label
        '
        'btnNo
        '
        Me.btnNo.Location = New System.Drawing.Point(128, 200)
        Me.btnNo.Text = "No"
        '
        'btnYes
        '
        Me.btnYes.Location = New System.Drawing.Point(40, 200)
        Me.btnYes.Text = "Yes"
        '
        'lblNonUSMailWarning
        '
        Me.lblNonUSMailWarning.Location = New System.Drawing.Point(48, 48)
        Me.lblNonUSMailWarning.Size = New System.Drawing.Size(152, 88)
        Me.lblNonUSMailWarning.Text = "You are attempting to scan non-USPS mail. Would you like to accept this piece of " & _
        "mail?"
        '
        'NonUSMailWarning
        '
        Me.ControlBox = False
        Me.Controls.Add(Me.btnNo)
        Me.Controls.Add(Me.btnYes)
        Me.Controls.Add(Me.lblNonUSMailWarning)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Text = "NonUSMailWarning"

    End Sub

#End Region

    Private Sub btnYes_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnYes.Click
        Me.DialogResult = DialogResult.Yes
        Me.Close()
    End Sub

    Private Sub btnNo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnNo.Click
        Me.DialogResult = DialogResult.No
        Me.Close()
    End Sub

End Class
