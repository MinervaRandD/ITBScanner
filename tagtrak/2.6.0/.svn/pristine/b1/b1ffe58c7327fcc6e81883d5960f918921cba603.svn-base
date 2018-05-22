' Copyright (c) 2003-2004 Aviation Software, Inc.,
' All Rights Reserved. 
' Reproduction of this document in whole or in part without written permission of   
' Aviation Software, Inc. is strictly prohibited.
'
' Aviation Software, Inc., Confidential - Restricted Access
'
' This document contains proprietary information that shall be
' distributed or routed only within Aviation Software, Inc.,
' and its authorized clients, except with written permission of
' Aviation Software, Inc. 


Public Class adminUploadResditFileForm

    Inherits System.Windows.Forms.Form

    Friend WithEvents stateLabel As System.Windows.Forms.Label
    Friend WithEvents pbProgress As System.Windows.Forms.ProgressBar
    Friend WithEvents transferStatusLabel As System.Windows.Forms.Label

    Dim filePath As String

#Region " Windows Form Designer generated code "

    Dim ftpProcessor As ftpProcessClass

    Public Sub New()

        MyBase.New()

#If ValidationLevel >= 3 Then

        if diagnosticLevel >= 2 then
            verify(Not inputFilePath Is Nothing, 26000)
        End If

#End If

        'This call is required by the Windows Form Designer.
        InitializeComponent()


    End Sub

    Public Sub init(ByVal inputFilePath)

        filePath = inputFilePath

    End Sub

    Protected Overloads Overrides Sub Dispose(ByVal disposing As Boolean)
        MyBase.Dispose(disposing)
    End Sub

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents PictureBox2 As System.Windows.Forms.PictureBox
    Friend WithEvents Label2 As System.Windows.Forms.Label

    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Dim resources As System.Resources.ResourceManager = New System.Resources.ResourceManager(GetType(adminUploadResditFileForm))
        Me.stateLabel = New System.Windows.Forms.Label
        Me.pbProgress = New System.Windows.Forms.ProgressBar
        Me.transferStatusLabel = New System.Windows.Forms.Label
        Me.Label1 = New System.Windows.Forms.Label
        Me.PictureBox2 = New System.Windows.Forms.PictureBox
        Me.Label2 = New System.Windows.Forms.Label
        '
        'stateLabel
        '
        Me.stateLabel.Font = New System.Drawing.Font("Tahoma", 12.0!, System.Drawing.FontStyle.Regular)
        Me.stateLabel.Location = New System.Drawing.Point(20, 231)
        Me.stateLabel.Size = New System.Drawing.Size(191, 20)
        Me.stateLabel.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'pbProgress
        '
        Me.pbProgress.Location = New System.Drawing.Point(23, 184)
        Me.pbProgress.Maximum = 10000
        Me.pbProgress.Size = New System.Drawing.Size(184, 35)
        '
        'transferStatusLabel
        '
        Me.transferStatusLabel.Font = New System.Drawing.Font("Tahoma", 12.0!, System.Drawing.FontStyle.Regular)
        Me.transferStatusLabel.Location = New System.Drawing.Point(21, 153)
        Me.transferStatusLabel.Size = New System.Drawing.Size(189, 19)
        Me.transferStatusLabel.Text = "Transfer Completed"
        Me.transferStatusLabel.TextAlign = System.Drawing.ContentAlignment.TopCenter
        Me.transferStatusLabel.Visible = False
        '
        'Label1
        '
        Me.Label1.Font = New System.Drawing.Font("Tahoma", 12.0!, System.Drawing.FontStyle.Bold)
        Me.Label1.Location = New System.Drawing.Point(11, 71)
        Me.Label1.Size = New System.Drawing.Size(213, 25)
        Me.Label1.Text = "Uploading Resdit File"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'PictureBox2
        '
        Me.PictureBox2.Image = CType(resources.GetObject("PictureBox2.Image"), System.Drawing.Image)
        Me.PictureBox2.Location = New System.Drawing.Point(85, 2)
        Me.PictureBox2.Size = New System.Drawing.Size(61, 55)
        '
        'Label2
        '
        Me.Label2.Font = New System.Drawing.Font("Tahoma", 12.0!, System.Drawing.FontStyle.Bold)
        Me.Label2.Location = New System.Drawing.Point(34, 107)
        Me.Label2.Size = New System.Drawing.Size(165, 19)
        Me.Label2.Text = "PLEASE STAND BY"
        Me.Label2.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'adminUploadResditFileForm
        '
        Me.ClientSize = New System.Drawing.Size(234, 288)
        Me.ControlBox = False
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.PictureBox2)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.transferStatusLabel)
        Me.Controls.Add(Me.stateLabel)
        Me.Controls.Add(Me.pbProgress)
        Me.Text = "Upload Resdit File"

    End Sub

#End Region

    Private Function doUploadDownloadProcess(ByRef userRecord As userSpecRecordClass) As String

        transferStatusLabel.Visible = True
        transferStatusLabel.Text = "Checking For Connection"

        updateProgressBar = False

        Dim result As String

        result = ftpProcessor.ftpEstablishFtpSession()
        If result <> "OK" Then
            ftpProcessor.ftpCloseFtpSession()
            Return result
        End If

        transferStatusLabel.Text = "Connection Found"

        Dim location As String = Substring(scanLocation.currentLocation, 0, 3).ToUpper

        result = ftpProcessor.ftpUploadResditFileToServer(filePath, location, True)
        If result <> "OK" Then

            ftpProcessor.ftpCloseFtpSession()
            transferStatusLabel.Text = "Upload Failed"

            Return result

        End If

        ftpProcessor.ftpCloseFtpSession()

        transferStatusLabel.Text = "Transfer Completed"

        Return "OK"

    End Function

    Private Sub ftpProcess_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        Dim result As String

        ftpProcessor = New ftpProcessClass(Me, stateLabel, pbProgress, transferStatusLabel)

        result = doUploadDownloadProcess(userSpecRecord)

        Me.Close()
        Me.Dispose()

    End Sub

    Dim withinftpProcessActivated As Boolean = False

    Private Sub ftpProcessActivated(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Activated

        Dim result As String

        If device <> "PC" Then Exit Sub

        If withinftpProcessActivated Then Exit Sub

        withinftpProcessActivated = True

        result = doUploadDownloadProcess(userSpecRecord)
        If result <> "OK" Then
            MsgBox("Upload of resdit file failed: " & result, MsgBoxStyle.Exclamation, "Upload Failed")
        End If

        Me.Hide()

        Exit Sub

    End Sub

End Class
