Public Class ftpMsgUploadDownloadProcessFailHelp

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
    Friend WithEvents message1TextBox As System.Windows.Forms.Label
    Friend WithEvents OKButton As System.Windows.Forms.Button
    Friend WithEvents helpListBox As System.Windows.Forms.ListBox
    Friend WithEvents errorDetailsButton As System.Windows.Forms.Button
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.message1TextBox = New System.Windows.Forms.Label
        Me.OKButton = New System.Windows.Forms.Button
        Me.helpListBox = New System.Windows.Forms.ListBox
        Me.errorDetailsButton = New System.Windows.Forms.Button
        '
        'message1TextBox
        '
        Me.message1TextBox.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Regular)
        Me.message1TextBox.Location = New System.Drawing.Point(10, 7)
        Me.message1TextBox.Size = New System.Drawing.Size(195, 33)
        Me.message1TextBox.Text = "Upload / Download Process Failure Help"
        Me.message1TextBox.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'OKButton
        '
        Me.OKButton.Location = New System.Drawing.Point(9, 235)
        Me.OKButton.Size = New System.Drawing.Size(101, 26)
        Me.OKButton.Text = "OK"
        '
        'helpListBox
        '
        Me.helpListBox.Items.Add("The process of uploading and/or")
        Me.helpListBox.Items.Add("downloading information to/from")
        Me.helpListBox.Items.Add("the main mail service computer")
        Me.helpListBox.Items.Add("involves many steps. One of")
        Me.helpListBox.Items.Add("these steps has failed to complete")
        Me.helpListBox.Items.Add("successfully.")
        Me.helpListBox.Items.Add("")
        Me.helpListBox.Items.Add("Most often this is the result of a")
        Me.helpListBox.Items.Add("failure in the connection between")
        Me.helpListBox.Items.Add("the scanner device and the host")
        Me.helpListBox.Items.Add("computer. If you are working")
        Me.helpListBox.Items.Add("on a wireless scanner, this means")
        Me.helpListBox.Items.Add("that the wireless service")
        Me.helpListBox.Items.Add("connection has been broken. In")
        Me.helpListBox.Items.Add("this case, it recommended that")
        Me.helpListBox.Items.Add("you cancel the current upload /")
        Me.helpListBox.Items.Add("download process, wait a few")
        Me.helpListBox.Items.Add("minutes and try again.")
        Me.helpListBox.Items.Add("")
        Me.helpListBox.Items.Add("Contact your systems admin-")
        Me.helpListBox.Items.Add("istrator for further help or")
        Me.helpListBox.Items.Add("instructions.")
        Me.helpListBox.Location = New System.Drawing.Point(7, 47)
        Me.helpListBox.Size = New System.Drawing.Size(226, 156)
        '
        'errorDetailsButton
        '
        Me.errorDetailsButton.Location = New System.Drawing.Point(125, 235)
        Me.errorDetailsButton.Size = New System.Drawing.Size(101, 26)
        Me.errorDetailsButton.Text = "Error Details"
        '
        'ftpMsgUploadDownloadProcessFailHelp
        '
        Me.ClientSize = New System.Drawing.Size(234, 288)
        Me.ControlBox = False
        Me.Controls.Add(Me.errorDetailsButton)
        Me.Controls.Add(Me.helpListBox)
        Me.Controls.Add(Me.OKButton)
        Me.Controls.Add(Me.message1TextBox)
        Me.Text = "Upload / Download Failed"

    End Sub

#End Region

    Private Sub OKButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles OKButton.Click

        Me.DialogResult = DialogResult.OK
        Me.Close()
        Application.DoEvents()

    End Sub

    Private Sub errorDetailsButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles errorDetailsButton.Click

        Dim errorLogDisplayForm As errorLogForm = New errorLogForm(errorMessage)
        errorLogDisplayForm.ShowDialog()

        'Me.BringToFront()

        Application.DoEvents()

    End Sub

End Class
