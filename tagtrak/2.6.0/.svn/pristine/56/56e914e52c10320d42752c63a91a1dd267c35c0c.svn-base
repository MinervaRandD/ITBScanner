Imports System
Imports System.IO
Imports System.Threading.Thread

Public Class adminFunctionsNotification
    Inherits System.Windows.Forms.Form
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents PictureBox2 As System.Windows.Forms.PictureBox
    Friend WithEvents Label13 As System.Windows.Forms.Label

#Region " Windows Form Designer generated code "

    Public Sub New()
        MyBase.New()

        'This call is required by the Windows Form Designer.
        InitializeComponent()

        launchTimer.Enabled = False
        terminationTimer.Enabled = False

        rebootLabel.Visible = False

    End Sub

    Declare Function openCabFile Lib "AirlineSoftware.dll" (ByVal cabFilePath As String) As Integer
    Declare Function executeProgram Lib "AirlineSoftware.dll" (ByVal programPath As String) As Integer

    Private Sub formOnLoad(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        If lockDown Then
            MyBase.MaximizeBox = False
            MyBase.MinimizeBox = False
            MyBase.ControlBox = False
            MyBase.WindowState = FormWindowState.Maximized
        End If

        launchTimer.Interval = 2000

        launchTimer.Enabled = True

    End Sub


    Private Sub launchTimer_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles launchTimer.Tick

        launchTimer.Enabled = False

        Application.DoEvents()

        Dim cabFilePath As String = deviceNonVolatileMemoryDirectory & "\AuxInstall.cab"

        If Not File.Exists(cabFilePath) Then
            Sleep(2000)
            Me.Close()
            Exit Sub
        End If

        Dim result As Integer

        result = openCabFile(cabFilePath)

        If result <> 1 Then
            Sleep(2000)
            Me.Close()
            Exit Sub
        End If

        Application.DoEvents()

        Dim auxPgmExePath As String = "\Program Files\AuxPgm\AuxPgm.exe"

        If Not File.Exists(auxPgmExePath) Then

            Sleep(2000)
            Me.Close()
            Exit Sub

        End If

        Dim resultFilePath As String = deviceNonVolatileMemoryDirectory & "\AuxPgmResult.txt"

        deleteLocalFile(resultFilePath)

        result = executeProgram(auxPgmExePath)

        If result <> 1 Then

            Sleep(2000)
            Me.Close()
            Exit Sub

        End If

        While Not File.Exists(resultFilePath)
            Sleep(1000)
        End While

        Dim resultFileStream As StreamReader

        Try
            resultFileStream = New StreamReader(resultFilePath)
        Catch ex As Exception

            Sleep(2000)
            Me.Close()
            Exit Sub

        End Try

        Dim resultLine As String

        Try
            resultLine = resultFileStream.ReadLine()
        Catch ex As Exception

            resultFileStream.Close()
            Sleep(2000)
            Me.Close()
            Exit Sub

        End Try

        resultFileStream.Close()

        If Not resultLine Is Nothing Then

            resultLine = resultLine.ToUpper.Trim

            If resultLine = "COLDBOOT" Then

                rebootLabel.Visible = True
                Sleep(5000)
                scannerLib.ColdBoot()

            ElseIf resultLine = "WARMBOOT" Then

                rebootLabel.Visible = True
                Sleep(5000)

                scannerLib.WarmBoot()

            ElseIf resultLine = "ABORT" Then

                rebootLabel.Text = "The Scanning Program Will Now Terminate"
                rebootLabel.Visible = True
                Sleep(5000)

                Me.DialogResult = DialogResult.Abort

                Exit Sub

            End If
        End If

        Sleep(2000)
        Me.Close()

        Exit Sub

    End Sub
    Protected Overloads Overrides Sub Dispose(ByVal disposing As Boolean)
        MyBase.Dispose(disposing)
    End Sub

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    Friend WithEvents rebootLabel As System.Windows.Forms.Label
    Friend WithEvents launchTimer As System.Windows.Forms.Timer
    Friend WithEvents terminationTimer As System.Windows.Forms.Timer
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Dim resources As System.Resources.ResourceManager = New System.Resources.ResourceManager(GetType(adminFunctionsNotification))
        Me.Label12 = New System.Windows.Forms.Label
        Me.PictureBox2 = New System.Windows.Forms.PictureBox
        Me.Label13 = New System.Windows.Forms.Label
        Me.rebootLabel = New System.Windows.Forms.Label
        Me.launchTimer = New System.Windows.Forms.Timer
        Me.terminationTimer = New System.Windows.Forms.Timer
        '
        'Label12
        '
        Me.Label12.Font = New System.Drawing.Font("Tahoma", 11.25!, System.Drawing.FontStyle.Regular)
        Me.Label12.Location = New System.Drawing.Point(7, 142)
        Me.Label12.Size = New System.Drawing.Size(223, 22)
        Me.Label12.Text = "Please Stand By"
        Me.Label12.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'PictureBox2
        '
        Me.PictureBox2.Image = CType(resources.GetObject("PictureBox2.Image"), System.Drawing.Image)
        Me.PictureBox2.Location = New System.Drawing.Point(85, 2)
        Me.PictureBox2.Size = New System.Drawing.Size(61, 55)
        '
        'Label13
        '
        Me.Label13.Font = New System.Drawing.Font("Tahoma", 11.25!, System.Drawing.FontStyle.Regular)
        Me.Label13.Location = New System.Drawing.Point(15, 62)
        Me.Label13.Size = New System.Drawing.Size(206, 73)
        Me.Label13.Text = "Administrative Functions Are Being Performed On Your Scanner"
        Me.Label13.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'rebootLabel
        '
        Me.rebootLabel.Font = New System.Drawing.Font("Tahoma", 18.0!, System.Drawing.FontStyle.Regular)
        Me.rebootLabel.Location = New System.Drawing.Point(13, 72)
        Me.rebootLabel.Size = New System.Drawing.Size(206, 195)
        Me.rebootLabel.Text = "The System Must Now Reboot To Complete Administrative Functions"
        Me.rebootLabel.TextAlign = System.Drawing.ContentAlignment.TopCenter
        Me.rebootLabel.Visible = False
        '
        'launchTimer
        '
        Me.launchTimer.Interval = 2000
        '
        'adminFunctionsNotification
        '
        Me.ClientSize = New System.Drawing.Size(237, 311)
        Me.Controls.Add(Me.Label12)
        Me.Controls.Add(Me.PictureBox2)
        Me.Controls.Add(Me.Label13)
        Me.Controls.Add(Me.rebootLabel)
        Me.Text = "New Version Found"

    End Sub

#End Region

End Class
