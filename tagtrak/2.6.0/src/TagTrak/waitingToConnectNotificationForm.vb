Public Class waitingToConnectNotificationForm
    Inherits System.Windows.Forms.Form
    Friend WithEvents PictureBox2 As System.Windows.Forms.PictureBox

    Dim exitString As String = ""

    Dim ftpConnectionDelay As Integer
    Dim attemptNumber As String

#Region " Windows Form Designer generated code "

    Public Sub New(ByVal inputftpConnectionDelay As Integer, ByVal inputAttemptNumber As Integer)
        MyBase.New()

        'This call is required by the Windows Form Designer.
        InitializeComponent()

        connectionTimer.Enabled = False

        ftpConnectionDelay = inputftpConnectionDelay
        attemptNumber = inputAttemptNumber

    End Sub

    Private Sub formOnLoad(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        If lockDown Then
            MyBase.MaximizeBox = False
            MyBase.MinimizeBox = False
            MyBase.ControlBox = False
            MyBase.WindowState = FormWindowState.Maximized
        End If

        If attemptNumber = 1 Then
            Me.message1TextBox.Text = "Initial Connection Attempt"
            Me.message2TextBox.Text = "Initializing system to connect to the internet. Please wait."
        Else
            Me.message1TextBox.Text = "Connection Failed. Attempting To Reconnect"
            Me.message2TextBox.Text = "Initializing system to re-connect to the internet. Please wait."
        End If

        connectionTimer.Enabled = True
        connectionTimer.Interval = 1000

        Me.initTimerLabel.Text = ftpConnectionDelay

    End Sub

    Protected Overloads Overrides Sub Dispose(ByVal disposing As Boolean)
        MyBase.Dispose(disposing)
    End Sub

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    Friend WithEvents message2TextBox As System.Windows.Forms.Label
    Friend WithEvents message1TextBox As System.Windows.Forms.Label
    Friend WithEvents connectionTimer As System.Windows.Forms.Timer
    Friend WithEvents initTimerLabel As System.Windows.Forms.Label
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Dim resources As System.Resources.ResourceManager = New System.Resources.ResourceManager(GetType(waitingToConnectNotificationForm))
        Me.message2TextBox = New System.Windows.Forms.Label
        Me.PictureBox2 = New System.Windows.Forms.PictureBox
        Me.message1TextBox = New System.Windows.Forms.Label
        Me.connectionTimer = New System.Windows.Forms.Timer
        Me.initTimerLabel = New System.Windows.Forms.Label
        '
        'message2TextBox
        '
        Me.message2TextBox.Font = New System.Drawing.Font("Tahoma", 14.25!, System.Drawing.FontStyle.Regular)
        Me.message2TextBox.Location = New System.Drawing.Point(8, 140)
        Me.message2TextBox.Size = New System.Drawing.Size(223, 81)
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
        Me.message1TextBox.Location = New System.Drawing.Point(12, 70)
        Me.message1TextBox.Size = New System.Drawing.Size(214, 64)
        Me.message1TextBox.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'connectionTimer
        '
        Me.connectionTimer.Interval = 10000
        '
        'initTimerLabel
        '
        Me.initTimerLabel.Font = New System.Drawing.Font("Tahoma", 14.25!, System.Drawing.FontStyle.Regular)
        Me.initTimerLabel.Location = New System.Drawing.Point(80, 246)
        Me.initTimerLabel.Size = New System.Drawing.Size(78, 33)
        Me.initTimerLabel.Text = "Label1"
        Me.initTimerLabel.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'waitingToConnectNotificationForm
        '
        Me.ClientSize = New System.Drawing.Size(234, 288)
        Me.Controls.Add(Me.initTimerLabel)
        Me.Controls.Add(Me.message2TextBox)
        Me.Controls.Add(Me.PictureBox2)
        Me.Controls.Add(Me.message1TextBox)
        Me.Text = "New Version Found"

    End Sub

#End Region

    Private Sub connectionTimer_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles connectionTimer.Tick

        ftpConnectionDelay -= 1
        Me.initTimerLabel.Text = ftpConnectionDelay

        If ftpConnectionDelay < 0 Then
            connectionTimer.Enabled = False
            Me.Close()
        End If

    End Sub
End Class
