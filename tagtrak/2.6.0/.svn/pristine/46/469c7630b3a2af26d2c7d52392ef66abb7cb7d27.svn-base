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


Public Class uploadLogFileForm

    Inherits System.Windows.Forms.Form

    Friend WithEvents stateLabel As System.Windows.Forms.Label
    Friend WithEvents pbProgress As System.Windows.Forms.ProgressBar
    Friend WithEvents transferStatusLabel As System.Windows.Forms.Label

    Dim remoteFilePath As String
    Dim localFilePath As String


#Region " Windows Form Designer generated code "

    Dim ftpProcessor As ftpProcessClass

    Public Sub New(ByVal inputLocalFilePath As String, ByVal inputRemoteFilePath As String)

        MyBase.New()

#if ValidationLevel >= 3 then

        if diagnosticLevel >= 2 then
            verify(Not inputLocalFilePath Is Nothing, 20)
            verify(Not inputRemoteFilePath Is Nothing, 21)
        End If

#End If

        'This call is required by the Windows Form Designer.
        InitializeComponent()

        remoteFilePath = inputRemoteFilePath

        localFilePath = inputLocalFilePath

        fileNameLabel.Text = "Uploading log file to server"

        Dim result As String

    End Sub

    Protected Overloads Overrides Sub Dispose(ByVal disposing As Boolean)
        MyBase.Dispose(disposing)
    End Sub

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    Friend WithEvents PictureBox2 As System.Windows.Forms.PictureBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents fileNameLabel As System.Windows.Forms.Label

    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Dim resources As System.Resources.ResourceManager = New System.Resources.ResourceManager(GetType(uploadLogFileForm))
        Me.stateLabel = New System.Windows.Forms.Label
        Me.pbProgress = New System.Windows.Forms.ProgressBar
        Me.transferStatusLabel = New System.Windows.Forms.Label
        Me.fileNameLabel = New System.Windows.Forms.Label
        Me.PictureBox2 = New System.Windows.Forms.PictureBox
        Me.Label2 = New System.Windows.Forms.Label
        '
        'stateLabel
        '
        Me.stateLabel.Font = New System.Drawing.Font("Tahoma", 12.0!, System.Drawing.FontStyle.Regular)
        Me.stateLabel.Location = New System.Drawing.Point(19, 245)
        Me.stateLabel.Size = New System.Drawing.Size(191, 20)
        Me.stateLabel.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'pbProgress
        '
        Me.pbProgress.Location = New System.Drawing.Point(22, 210)
        Me.pbProgress.Maximum = 10000
        Me.pbProgress.Size = New System.Drawing.Size(184, 35)
        '
        'transferStatusLabel
        '
        Me.transferStatusLabel.Font = New System.Drawing.Font("Tahoma", 12.0!, System.Drawing.FontStyle.Regular)
        Me.transferStatusLabel.Location = New System.Drawing.Point(20, 179)
        Me.transferStatusLabel.Size = New System.Drawing.Size(189, 19)
        Me.transferStatusLabel.Text = "Transfer Completed"
        Me.transferStatusLabel.TextAlign = System.Drawing.ContentAlignment.TopCenter
        Me.transferStatusLabel.Visible = False
        '
        'fileNameLabel
        '
        Me.fileNameLabel.Font = New System.Drawing.Font("Tahoma", 12.0!, System.Drawing.FontStyle.Bold)
        Me.fileNameLabel.Location = New System.Drawing.Point(10, 61)
        Me.fileNameLabel.Size = New System.Drawing.Size(213, 81)
        Me.fileNameLabel.TextAlign = System.Drawing.ContentAlignment.TopCenter
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
        Me.Label2.Location = New System.Drawing.Point(34, 149)
        Me.Label2.Size = New System.Drawing.Size(165, 19)
        Me.Label2.Text = "PLEASE STAND BY"
        Me.Label2.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'uploadLogFileForm
        '
        Me.ClientSize = New System.Drawing.Size(234, 288)
        Me.ControlBox = False
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.PictureBox2)
        Me.Controls.Add(Me.fileNameLabel)
        Me.Controls.Add(Me.transferStatusLabel)
        Me.Controls.Add(Me.stateLabel)
        Me.Controls.Add(Me.pbProgress)
        Me.Text = "Upload Log File"

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
            transferStatusLabel.Text = "Connection Failed"

            Return result

        End If

        transferStatusLabel.Text = "Connection Found"


        result = ftpProcessor.ftpUploadFileToServer(localFilePath, remoteFilePath)

        If result <> "OK" Then

            ftpProcessor.ftpCloseFtpSession()
            transferStatusLabel.Text = "Upload Failed"

            Return result

        End If

        ftpProcessor.ftpCloseFtpSession()

        transferStatusLabel.Text = "Transfer Completed"

        Return result

    End Function

    Private Sub ftpProcess_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        ftpProcessor = New ftpProcessClass(Me, Nothing, pbProgress, transferStatusLabel)

        doUploadDownloadProcess(userSpecRecord)

        Me.Visible = False
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
            MsgBox("Upload of log file failed: " & result)
        End If

        Me.Visible = False
        Me.Close()
        Me.Dispose()

        Exit Sub

    End Sub

End Class
