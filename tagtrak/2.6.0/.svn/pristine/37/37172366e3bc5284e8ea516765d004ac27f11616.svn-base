
Public Class ftpMsgFormSysWarning

    Inherits System.Windows.Forms.Form
    Friend WithEvents PictureBox2 As System.Windows.Forms.PictureBox

    Dim exitString As String = ""

    Dim ftpConnectionDelay As Integer
    Dim attemptNumber As String

#Region " Windows Form Designer generated code "

    Public Sub New()
        MyBase.New()

        'This call is required by the Windows Form Designer.
        InitializeComponent()

    End Sub

    Public Sub init(ByVal sysWarningMessage As String)

        Me.sysWarningMessageLabel.Text = sysWarningMessage

    End Sub

    Protected Overloads Overrides Sub Dispose(ByVal disposing As Boolean)
        MyBase.Dispose(disposing)
    End Sub

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    Friend WithEvents message2TextBox As System.Windows.Forms.Label
    Friend WithEvents message1TextBox As System.Windows.Forms.Label
    Friend WithEvents Button1 As System.Windows.Forms.Button
    Friend WithEvents sysWarningMessageLabel As System.Windows.Forms.Label
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Dim resources As System.Resources.ResourceManager = New System.Resources.ResourceManager(GetType(ftpMsgFormSysWarning))
        Me.message2TextBox = New System.Windows.Forms.Label
        Me.PictureBox2 = New System.Windows.Forms.PictureBox
        Me.message1TextBox = New System.Windows.Forms.Label
        Me.sysWarningMessageLabel = New System.Windows.Forms.Label
        Me.Button1 = New System.Windows.Forms.Button
        '
        'message2TextBox
        '
        Me.message2TextBox.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Regular)
        Me.message2TextBox.Location = New System.Drawing.Point(9, 99)
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
        Me.message1TextBox.Text = "Ftp System Warning"
        Me.message1TextBox.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'sysWarningMessageLabel
        '
        Me.sysWarningMessageLabel.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Regular)
        Me.sysWarningMessageLabel.Location = New System.Drawing.Point(9, 173)
        Me.sysWarningMessageLabel.Size = New System.Drawing.Size(221, 41)
        Me.sysWarningMessageLabel.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'Button1
        '
        Me.Button1.Location = New System.Drawing.Point(54, 223)
        Me.Button1.Size = New System.Drawing.Size(128, 26)
        Me.Button1.Text = "Close"
        '
        'ftpMsgFormSysWarning
        '
        Me.ClientSize = New System.Drawing.Size(234, 288)
        Me.ControlBox = False
        Me.Controls.Add(Me.Button1)
        Me.Controls.Add(Me.sysWarningMessageLabel)
        Me.Controls.Add(Me.message2TextBox)
        Me.Controls.Add(Me.PictureBox2)
        Me.Controls.Add(Me.message1TextBox)
        Me.Text = "Ftp System Warning"

    End Sub

#End Region

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click

        Me.Close()

        Application.DoEvents()

    End Sub
End Class

