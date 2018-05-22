Public Class ftpMsgFormSysError

    Inherits System.Windows.Forms.Form
    Friend WithEvents PictureBox2 As System.Windows.Forms.PictureBox

    Dim exitString As String = ""

    Dim ftpConnectionDelay As Integer
    Dim attemptNumber As String
    Dim fullErrorString As String

#Region " Windows Form Designer generated code "

    Public Sub New()
        MyBase.New()

        'This call is required by the Windows Form Designer.
        InitializeComponent()

    End Sub

    Public Sub init(ByVal sysErrorMessage As String, Optional ByVal inputFullErrorString As String = "")

        If (isNonNullString(inputFullErrorString)) Then
            fullErrorString = inputFullErrorString
        Else
            Me.errorDetailsButton.Enabled = False
        End If

        Me.sysErrorMessageLabel.Text = sysErrorMessage

    End Sub

    Protected Overloads Overrides Sub Dispose(ByVal disposing As Boolean)
        MyBase.Dispose(disposing)
    End Sub

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    Friend WithEvents message2TextBox As System.Windows.Forms.Label
    Friend WithEvents message1TextBox As System.Windows.Forms.Label
    Friend WithEvents sysErrorMessageLabel As System.Windows.Forms.Label
    Friend WithEvents closeButton As System.Windows.Forms.Button
    Friend WithEvents errorDetailsButton As System.Windows.Forms.Button
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Dim resources As System.Resources.ResourceManager = New System.Resources.ResourceManager(GetType(ftpMsgFormSysError))
        Me.message2TextBox = New System.Windows.Forms.Label
        Me.PictureBox2 = New System.Windows.Forms.PictureBox
        Me.message1TextBox = New System.Windows.Forms.Label
        Me.sysErrorMessageLabel = New System.Windows.Forms.Label
        Me.closeButton = New System.Windows.Forms.Button
        Me.errorDetailsButton = New System.Windows.Forms.Button
        '
        'message2TextBox
        '
        Me.message2TextBox.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Regular)
        Me.message2TextBox.Location = New System.Drawing.Point(9, 98)
        Me.message2TextBox.Size = New System.Drawing.Size(221, 66)
        Me.message2TextBox.Text = "An Ftp Related System Error Has Occured. Please Report The Following Error Messag" & _
        "e To Your Systems Administrator"
        Me.message2TextBox.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'PictureBox2
        '
        Me.PictureBox2.Image = CType(resources.GetObject("PictureBox2.Image"), System.Drawing.Image)
        Me.PictureBox2.Location = New System.Drawing.Point(89, 2)
        Me.PictureBox2.Size = New System.Drawing.Size(61, 55)
        '
        'message1TextBox
        '
        Me.message1TextBox.Font = New System.Drawing.Font("Tahoma", 14.25!, System.Drawing.FontStyle.Regular)
        Me.message1TextBox.Location = New System.Drawing.Point(12, 64)
        Me.message1TextBox.Size = New System.Drawing.Size(214, 26)
        Me.message1TextBox.Text = "Ftp System Error"
        Me.message1TextBox.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'sysErrorMessageLabel
        '
        Me.sysErrorMessageLabel.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Regular)
        Me.sysErrorMessageLabel.Location = New System.Drawing.Point(9, 171)
        Me.sysErrorMessageLabel.Size = New System.Drawing.Size(221, 41)
        Me.sysErrorMessageLabel.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'closeButton
        '
        Me.closeButton.Location = New System.Drawing.Point(12, 222)
        Me.closeButton.Size = New System.Drawing.Size(106, 26)
        Me.closeButton.Text = "Close"
        '
        'errorDetailsButton
        '
        Me.errorDetailsButton.Location = New System.Drawing.Point(125, 222)
        Me.errorDetailsButton.Size = New System.Drawing.Size(106, 26)
        Me.errorDetailsButton.Text = "Error Details"
        '
        'ftpMsgFormSysError
        '
        Me.ClientSize = New System.Drawing.Size(234, 288)
        Me.ControlBox = False
        Me.Controls.Add(Me.errorDetailsButton)
        Me.Controls.Add(Me.closeButton)
        Me.Controls.Add(Me.sysErrorMessageLabel)
        Me.Controls.Add(Me.message2TextBox)
        Me.Controls.Add(Me.PictureBox2)
        Me.Controls.Add(Me.message1TextBox)
        Me.Text = "Ftp System Error"

    End Sub

#End Region

    Private Sub closeButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles closeButton.Click

        Me.Close()
        Application.DoEvents()

    End Sub

    Private Sub errorDetailsButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles errorDetailsButton.Click

        Dim errorLogDisplayForm As errorLogForm = New errorLogForm(fullErrorString)
        errorLogDisplayForm.ShowDialog()

        Me.BringToFront()

        Application.DoEvents()

    End Sub
End Class
