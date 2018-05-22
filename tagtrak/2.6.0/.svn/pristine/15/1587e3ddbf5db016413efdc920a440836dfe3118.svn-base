Imports System
Imports System.io

Public Class waitForReaderFormMessageForm
    Inherits System.Windows.Forms.Form
    Friend WithEvents setupWaitLogoPictureBox As System.Windows.Forms.PictureBox
    Friend WithEvents Loading As System.Windows.Forms.Label

#Region " Windows Form Designer generated code "

    Public Sub New()
        MyBase.New()

        'This call is required by the Windows Form Designer.
        InitializeComponent()

        'Add any initialization after the InitializeComponent() call

        Dim result, lastActiveUsername As String

        result = getLastActiveUser(lastActiveUserName)

        If result = "OK" And isNonNullString(lastActiveUserName) Then

            Dim initFormLogoPath As String = TagTrakConfigDirectory & "\" & lastActiveUsername & "InitFormLogo.bmp"

            If File.Exists(initFormLogoPath) Then
                Me.setupWaitLogoPictureBox.Image = New System.Drawing.Bitmap(initFormLogoPath)
            End If

        End If

    End Sub

    Private Sub formOnLoad(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        Dim result As String
        Dim waitBarWidth As Integer = 160

        If lockDown Then
            MyBase.MaximizeBox = False
            MyBase.MinimizeBox = False
            MyBase.ControlBox = False
            MyBase.WindowState = FormWindowState.Maximized
        End If

        Application.DoEvents()

    End Sub

    Protected Overloads Overrides Sub Dispose(ByVal disposing As Boolean)
        MyBase.Dispose(disposing)
    End Sub

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    Friend WithEvents waitActivityPictureBox As System.Windows.Forms.PictureBox
    Friend WithEvents waitFormTimer As System.Windows.Forms.Timer
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Dim resources As System.Resources.ResourceManager = New System.Resources.ResourceManager(GetType(waitForReaderFormMessageForm))
        Me.setupWaitLogoPictureBox = New System.Windows.Forms.PictureBox
        Me.Loading = New System.Windows.Forms.Label
        Me.waitActivityPictureBox = New System.Windows.Forms.PictureBox
        Me.waitFormTimer = New System.Windows.Forms.Timer
        '
        'setupWaitLogoPictureBox
        '
        Me.setupWaitLogoPictureBox.Image = CType(resources.GetObject("setupWaitLogoPictureBox.Image"), System.Drawing.Image)
        Me.setupWaitLogoPictureBox.Location = New System.Drawing.Point(13, 14)
        Me.setupWaitLogoPictureBox.Size = New System.Drawing.Size(224, 64)
        '
        'Loading
        '
        Me.Loading.Font = New System.Drawing.Font("Tahoma", 14.25!, System.Drawing.FontStyle.Regular)
        Me.Loading.Location = New System.Drawing.Point(13, 96)
        Me.Loading.Size = New System.Drawing.Size(225, 89)
        Me.Loading.Text = "Please wait for additional set up procedures to complete..."
        '
        'waitActivityPictureBox
        '
        Me.waitActivityPictureBox.Image = CType(resources.GetObject("waitActivityPictureBox.Image"), System.Drawing.Image)
        Me.waitActivityPictureBox.Location = New System.Drawing.Point(45, 214)
        Me.waitActivityPictureBox.Size = New System.Drawing.Size(160, 16)
        Me.waitActivityPictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        '
        'waitFormTimer
        '
        Me.waitFormTimer.Enabled = True
        Me.waitFormTimer.Interval = 1000
        '
        'waitForReaderFormMessageForm
        '
        Me.ClientSize = New System.Drawing.Size(234, 288)
        Me.Controls.Add(Me.waitActivityPictureBox)
        Me.Controls.Add(Me.setupWaitLogoPictureBox)
        Me.Controls.Add(Me.Loading)
        Me.Text = "Please Wait..."

    End Sub

#End Region

    Private Sub waitActivityPictureBox_ParentChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles waitActivityPictureBox.ParentChanged

    End Sub

    Private Sub waitFormTimer_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles waitFormTimer.Tick

        If Not activeReaderForm Is Nothing Then
            Me.Close()
        End If

        Application.DoEvents()

    End Sub
End Class
