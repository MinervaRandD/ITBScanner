Public Class changeLocationInputBox
    Inherits System.Windows.Forms.Form
    Friend WithEvents passwordTextBox As System.Windows.Forms.TextBox


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
    Friend WithEvents OKButton As System.Windows.Forms.Button
    Friend WithEvents cancelButton As System.Windows.Forms.Button
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents passwordSeedLabel As System.Windows.Forms.Label
    Friend WithEvents MainMenu1 As System.Windows.Forms.MainMenu
#If deviceType <> "PC" Then
    Friend WithEvents InputPanel1 As Microsoft.WindowsCE.Forms.InputPanel
#End If
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.passwordTextBox = New System.Windows.Forms.TextBox
        Me.OKButton = New System.Windows.Forms.Button
        Me.cancelButton = New System.Windows.Forms.Button
        Me.Label1 = New System.Windows.Forms.Label
        Me.Label2 = New System.Windows.Forms.Label
        Me.passwordSeedLabel = New System.Windows.Forms.Label
        Me.MainMenu1 = New System.Windows.Forms.MainMenu
#If devicetype <> "PC" Then
        Me.InputPanel1 = New Microsoft.WindowsCE.Forms.InputPanel
#End If
        '
        'passwordTextBox
        '
        Me.passwordTextBox.Location = New System.Drawing.Point(17, 57)
        Me.passwordTextBox.Size = New System.Drawing.Size(199, 22)
        Me.passwordTextBox.Text = ""
        '
        'OKButton
        '
        Me.OKButton.Location = New System.Drawing.Point(63, 88)
        Me.OKButton.Size = New System.Drawing.Size(67, 24)
        Me.OKButton.Text = "OK"
        '
        'cancelButton
        '
        Me.cancelButton.Location = New System.Drawing.Point(147, 88)
        Me.cancelButton.Size = New System.Drawing.Size(67, 24)
        Me.cancelButton.Text = "Cancel"
        '
        'Label1
        '
        Me.Label1.Location = New System.Drawing.Point(14, 32)
        Me.Label1.Size = New System.Drawing.Size(205, 20)
        Me.Label1.Text = "Enter Password to Change Location"
        '
        'Label2
        '
        Me.Label2.Location = New System.Drawing.Point(11, 137)
        Me.Label2.Size = New System.Drawing.Size(211, 30)
        Me.Label2.Text = "Report The Following String When Requesting Password"
        Me.Label2.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'passwordSeedLabel
        '
        Me.passwordSeedLabel.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Bold)
        Me.passwordSeedLabel.Location = New System.Drawing.Point(44, 170)
        Me.passwordSeedLabel.Size = New System.Drawing.Size(145, 14)
        Me.passwordSeedLabel.Text = "Label1"
        Me.passwordSeedLabel.TextAlign = System.Drawing.ContentAlignment.TopCenter
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        '
        'changeLocationInputBox
        '
        Me.ClientSize = New System.Drawing.Size(234, 288)
        Me.ControlBox = False
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.passwordSeedLabel)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.cancelButton)
        Me.Controls.Add(Me.OKButton)
        Me.Controls.Add(Me.passwordTextBox)
        Me.Menu = Me.MainMenu1
        Me.Text = "Enter Password to Change Location"

    End Sub

#End Region

    Private Sub readerFormOnLoad(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        passwordSeedLabel.Text = enterPasswordForm()

    End Sub

    Private Sub changeLocationInputBox_Closed(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Closed

        exitPasswordForm()

    End Sub

    Private Sub OKButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles OKButton.Click

        If isValidLocationChangePassword(passwordTextBox.Text) Then

            setUsedPassword(passwordTextBox.Text, "LocationChange")

            passwordTextBox.Text = ""

            Me.DialogResult = DialogResult.OK
            Me.Close()

            Exit Sub

        End If

        MsgBox("Invalid location change password.", MsgBoxStyle.Exclamation, "Invalid Password")

        passwordTextBox.Text = ""

    End Sub

    Private Sub cancelButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cancelButton.Click

        Me.DialogResult = DialogResult.Cancel

        Me.Close()

    End Sub
End Class
