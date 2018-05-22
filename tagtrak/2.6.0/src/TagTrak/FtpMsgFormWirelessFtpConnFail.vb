Public Class ftpMsgFormWirelessFtpConnFail

    Inherits System.Windows.Forms.Form
    Friend WithEvents PictureBox2 As System.Windows.Forms.PictureBox

    Dim errorMessage As String

#Region " Windows Form Designer generated code "

    Public Sub New(ByVal inputErrorMessage As String)
        MyBase.New()

        'This call is required by the Windows Form Designer.
        InitializeComponent()

        errorMessage = inputErrorMessage

    End Sub

    Protected Overloads Overrides Sub Dispose(ByVal disposing As Boolean)
        MyBase.Dispose(disposing)
    End Sub

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    Friend WithEvents message2TextBox As System.Windows.Forms.Label
    Friend WithEvents message1TextBox As System.Windows.Forms.Label
    Friend WithEvents retryButton As System.Windows.Forms.Button
    Friend WithEvents cancelButton As System.Windows.Forms.Button
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents helpButton As System.Windows.Forms.Button
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Dim resources As System.Resources.ResourceManager = New System.Resources.ResourceManager(GetType(ftpMsgFormWirelessFtpConnFail))
        Me.message2TextBox = New System.Windows.Forms.Label
        Me.PictureBox2 = New System.Windows.Forms.PictureBox
        Me.message1TextBox = New System.Windows.Forms.Label
        Me.retryButton = New System.Windows.Forms.Button
        Me.cancelButton = New System.Windows.Forms.Button
        Me.Label1 = New System.Windows.Forms.Label
        Me.Label2 = New System.Windows.Forms.Label
        Me.Label3 = New System.Windows.Forms.Label
        Me.Label4 = New System.Windows.Forms.Label
        Me.helpButton = New System.Windows.Forms.Button
        '
        'message2TextBox
        '
        Me.message2TextBox.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Regular)
        Me.message2TextBox.Location = New System.Drawing.Point(6, 81)
        Me.message2TextBox.Size = New System.Drawing.Size(221, 68)
        Me.message2TextBox.Text = "Unable to establish connection to the server through your network connection. Con" & _
        "tact your systems administrator if problem persists."
        '
        'PictureBox2
        '
        Me.PictureBox2.Image = CType(resources.GetObject("PictureBox2.Image"), System.Drawing.Image)
        Me.PictureBox2.Location = New System.Drawing.Point(89, 2)
        Me.PictureBox2.Size = New System.Drawing.Size(61, 55)
        '
        'message1TextBox
        '
        Me.message1TextBox.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Bold)
        Me.message1TextBox.Location = New System.Drawing.Point(12, 60)
        Me.message1TextBox.Size = New System.Drawing.Size(214, 14)
        Me.message1TextBox.Text = "Unable To Connect To Server"
        Me.message1TextBox.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'retryButton
        '
        Me.retryButton.Location = New System.Drawing.Point(5, 224)
        Me.retryButton.Size = New System.Drawing.Size(108, 26)
        Me.retryButton.Text = "Retry"
        '
        'cancelButton
        '
        Me.cancelButton.Location = New System.Drawing.Point(120, 224)
        Me.cancelButton.Size = New System.Drawing.Size(108, 26)
        Me.cancelButton.Text = "Cancel"
        '
        'Label1
        '
        Me.Label1.Location = New System.Drawing.Point(36, 167)
        Me.Label1.Size = New System.Drawing.Size(181, 15)
        Me.Label1.Text = "Tap ""Retry"" to retry connection."
        '
        'Label2
        '
        Me.Label2.Location = New System.Drawing.Point(36, 187)
        Me.Label2.Size = New System.Drawing.Size(181, 27)
        Me.Label2.Text = "Tap ""Cancel"" to abort upload and download operation"
        '
        'Label3
        '
        Me.Label3.Location = New System.Drawing.Point(16, 167)
        Me.Label3.Size = New System.Drawing.Size(17, 21)
        Me.Label3.Text = "1."
        '
        'Label4
        '
        Me.Label4.Location = New System.Drawing.Point(16, 187)
        Me.Label4.Size = New System.Drawing.Size(17, 21)
        Me.Label4.Text = "2."
        '
        'helpButton
        '
        Me.helpButton.Font = New System.Drawing.Font("Tahoma", 12.0!, System.Drawing.FontStyle.Bold)
        Me.helpButton.Location = New System.Drawing.Point(180, 16)
        Me.helpButton.Size = New System.Drawing.Size(24, 24)
        Me.helpButton.Text = "?"
        '
        'ftpMsgFormWirelessFtpConnFail
        '
        Me.ClientSize = New System.Drawing.Size(234, 288)
        Me.ControlBox = False
        Me.Controls.Add(Me.helpButton)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.cancelButton)
        Me.Controls.Add(Me.retryButton)
        Me.Controls.Add(Me.message2TextBox)
        Me.Controls.Add(Me.PictureBox2)
        Me.Controls.Add(Me.message1TextBox)
        Me.Text = "Unable To Connect To Server"

    End Sub

#End Region

    Private Sub RetryButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles retryButton.Click

        Me.DialogResult = DialogResult.Retry
        Me.Close()

        Application.DoEvents()

    End Sub

    Private Sub cancelButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cancelButton.Click

        Me.DialogResult = DialogResult.Cancel
        Me.Close()

        Application.DoEvents()

    End Sub

    Private Sub helpButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles helpButton.Click

        FtpFormRepository.ftpMsgFormWirelessFtpConnFailHelp.init(errorMessage)
        Me.DialogResult = FtpFormRepository.ftpMsgFormWirelessFtpConnFailHelp.ShowDialog()
        If Me.DialogResult = DialogResult.Abort Then
            Me.Close()
            Exit Sub
        End If

        Me.BringToFront()

        Application.DoEvents()

    End Sub

End Class



