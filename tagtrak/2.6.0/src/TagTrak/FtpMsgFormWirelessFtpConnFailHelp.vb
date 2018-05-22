Public Class ftpMsgFormWirelessFtpConnFailHelp

    Inherits System.Windows.Forms.Form

    Dim errorMessage As String

#Region " Windows Form Designer generated code "

    Public Sub New()
        MyBase.New()

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
        Me.message1TextBox.Size = New System.Drawing.Size(214, 23)
        Me.message1TextBox.Text = "Wireless Connection Failed Help"
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
        Me.helpListBox.Items.Add("The scanner is not able to connect")
        Me.helpListBox.Items.Add("to the main mail service computer")
        Me.helpListBox.Items.Add("through your wireless service")
        Me.helpListBox.Items.Add("provider.")
        Me.helpListBox.Items.Add("")
        Me.helpListBox.Items.Add("It is possible that the wireless")
        Me.helpListBox.Items.Add("connection that has been established")
        Me.helpListBox.Items.Add("was lost. ")
        Me.helpListBox.Items.Add("")
        Me.helpListBox.Items.Add("If this scanner or other scanners")
        Me.helpListBox.Items.Add("that you are using have recently")
        Me.helpListBox.Items.Add("been able to make a connection")
        Me.helpListBox.Items.Add("and upload/download information")
        Me.helpListBox.Items.Add("then cancel out of the current")
        Me.helpListBox.Items.Add("upload / download operation. Then")
        Me.helpListBox.Items.Add("try waiting a few minutes and then")
        Me.helpListBox.Items.Add("retry to connect to the server.")
        Me.helpListBox.Items.Add("")
        Me.helpListBox.Items.Add("Contact your systems administrator")
        Me.helpListBox.Items.Add("if you need further assistance.")
        Me.helpListBox.Location = New System.Drawing.Point(7, 32)
        Me.helpListBox.Size = New System.Drawing.Size(226, 184)
        '
        'errorDetailsButton
        '
        Me.errorDetailsButton.Location = New System.Drawing.Point(125, 235)
        Me.errorDetailsButton.Size = New System.Drawing.Size(101, 26)
        Me.errorDetailsButton.Text = "Error Details"
        '
        'ftpMsgFormWirelessFtpConnFailHelp
        '
        Me.ClientSize = New System.Drawing.Size(234, 288)
        Me.ControlBox = False
        Me.Controls.Add(Me.errorDetailsButton)
        Me.Controls.Add(Me.helpListBox)
        Me.Controls.Add(Me.OKButton)
        Me.Controls.Add(Me.message1TextBox)
        Me.Text = "Wireless Connection Failed"

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

        Application.DoEvents()

    End Sub

End Class



