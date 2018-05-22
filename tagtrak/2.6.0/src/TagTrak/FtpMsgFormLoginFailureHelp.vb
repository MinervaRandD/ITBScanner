Public Class ftpMsgFormLoginFailureHelp

    Inherits System.Windows.Forms.Form

    Dim errorMessage As String

#Region " Windows Form Designer generated code "

    Public Sub New()
        MyBase.New()

        'This call is required by the Windows Form Designer.
        InitializeComponent()


    End Sub

    Public Sub init(ByVal inputErrorMessage As String)

        errorMessage = inputErrorMessage

    End Sub

    Protected Overloads Overrides Sub Dispose(ByVal disposing As Boolean)
        MyBase.Dispose(disposing)
    End Sub

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    Friend WithEvents OKButton As System.Windows.Forms.Button
    Friend WithEvents helpListBox As System.Windows.Forms.ListBox
    Friend WithEvents errorDetailsButton As System.Windows.Forms.Button
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.OKButton = New System.Windows.Forms.Button
        Me.helpListBox = New System.Windows.Forms.ListBox
        Me.errorDetailsButton = New System.Windows.Forms.Button
        '
        'OKButton
        '
        Me.OKButton.Location = New System.Drawing.Point(9, 235)
        Me.OKButton.Size = New System.Drawing.Size(101, 26)
        Me.OKButton.Text = "OK"
        '
        'helpListBox
        '
        Me.helpListBox.Items.Add("The scanner is not able to log in")
        Me.helpListBox.Items.Add("to the mail mail service computer.")
        Me.helpListBox.Items.Add("")
        Me.helpListBox.Items.Add("You should contact your systems")
        Me.helpListBox.Items.Add("administrator or Aviation Software,")
        Me.helpListBox.Items.Add("Inc. scanner support at")
        Me.helpListBox.Items.Add("845 357-7101  to resolve")
        Me.helpListBox.Items.Add("this issue")
        Me.helpListBox.Location = New System.Drawing.Point(8, 24)
        Me.helpListBox.Size = New System.Drawing.Size(216, 184)
        '
        'errorDetailsButton
        '
        Me.errorDetailsButton.Location = New System.Drawing.Point(125, 235)
        Me.errorDetailsButton.Size = New System.Drawing.Size(101, 26)
        Me.errorDetailsButton.Text = "Error Details"
        '
        'ftpMsgFormLoginFailureHelp
        '
        Me.ClientSize = New System.Drawing.Size(234, 288)
        Me.ControlBox = False
        Me.Controls.Add(Me.errorDetailsButton)
        Me.Controls.Add(Me.helpListBox)
        Me.Controls.Add(Me.OKButton)
        Me.Text = "Unable to Log In to Server Help"

    End Sub

#End Region

    Private Sub OKButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles OKButton.Click

        Me.Close()

        Application.DoEvents()

    End Sub

    Private Sub errorDetailsButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles errorDetailsButton.Click

        Dim errorLogDisplayForm As errorLogForm = New errorLogForm(errorMessage)
        errorLogDisplayForm.ShowDialog()

        Me.BringToFront()

    End Sub

End Class


