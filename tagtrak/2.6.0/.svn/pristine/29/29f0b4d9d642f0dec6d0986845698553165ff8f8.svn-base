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

Imports System
Imports System.IO
Imports Rebex.Net

Public Class autoFtpProcessForm

    Inherits System.Windows.Forms.Form

    Friend WithEvents stateLabel As System.Windows.Forms.Label
    Friend WithEvents pbProgress As System.Windows.Forms.ProgressBar
    Friend WithEvents transferStatusLabel As System.Windows.Forms.Label

    Dim progressRadioButtonList(7) As RadioButton

#Region " Windows Form Designer generated code "

    Dim messagesFoundFlag As Boolean

    Dim ftpProcessor As ftpProcessClass

    Public Sub New()

        MyBase.New()

        'This call is required by the Windows Form Designer.
        InitializeComponent()


        activityTimer.Enabled = False
        activityTimer.Interval = 750

        progressRadioButtonList(0) = Me.RadioButton1
        progressRadioButtonList(1) = Me.RadioButton2
        progressRadioButtonList(2) = Me.RadioButton3
        progressRadioButtonList(3) = Me.RadioButton4
        progressRadioButtonList(4) = Me.RadioButton5
        progressRadioButtonList(5) = Me.RadioButton6
        progressRadioButtonList(6) = Me.RadioButton7
        progressRadioButtonList(7) = Me.RadioButton8

        ftpProcessor = New ftpProcessClass(Me, Nothing, pbProgress, transferStatusLabel, False)

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
    Friend WithEvents activityDisplayPanel As System.Windows.Forms.Panel
    Friend WithEvents RadioButton8 As System.Windows.Forms.RadioButton
    Friend WithEvents RadioButton7 As System.Windows.Forms.RadioButton
    Friend WithEvents RadioButton6 As System.Windows.Forms.RadioButton
    Friend WithEvents RadioButton5 As System.Windows.Forms.RadioButton
    Friend WithEvents RadioButton4 As System.Windows.Forms.RadioButton
    Friend WithEvents RadioButton3 As System.Windows.Forms.RadioButton
    Friend WithEvents RadioButton2 As System.Windows.Forms.RadioButton
    Friend WithEvents RadioButton1 As System.Windows.Forms.RadioButton
    Friend WithEvents activityTimer As System.Windows.Forms.Timer

    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Dim resources As System.Resources.ResourceManager = New System.Resources.ResourceManager(GetType(autoFtpProcessForm))
        Me.stateLabel = New System.Windows.Forms.Label
        Me.pbProgress = New System.Windows.Forms.ProgressBar
        Me.transferStatusLabel = New System.Windows.Forms.Label
        Me.Label1 = New System.Windows.Forms.Label
        Me.PictureBox2 = New System.Windows.Forms.PictureBox
        Me.Label2 = New System.Windows.Forms.Label
        Me.activityDisplayPanel = New System.Windows.Forms.Panel
        Me.RadioButton8 = New System.Windows.Forms.RadioButton
        Me.RadioButton7 = New System.Windows.Forms.RadioButton
        Me.RadioButton6 = New System.Windows.Forms.RadioButton
        Me.RadioButton5 = New System.Windows.Forms.RadioButton
        Me.RadioButton4 = New System.Windows.Forms.RadioButton
        Me.RadioButton3 = New System.Windows.Forms.RadioButton
        Me.RadioButton2 = New System.Windows.Forms.RadioButton
        Me.RadioButton1 = New System.Windows.Forms.RadioButton
        Me.activityTimer = New System.Windows.Forms.Timer
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
        Me.Label1.Location = New System.Drawing.Point(9, 69)
        Me.Label1.Size = New System.Drawing.Size(213, 41)
        Me.Label1.Text = "Automatic Upload / Download In Progress"
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
        Me.Label2.Location = New System.Drawing.Point(33, 122)
        Me.Label2.Size = New System.Drawing.Size(165, 19)
        Me.Label2.Text = "PLEASE STAND BY"
        Me.Label2.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'activityDisplayPanel
        '
        Me.activityDisplayPanel.Controls.Add(Me.RadioButton8)
        Me.activityDisplayPanel.Controls.Add(Me.RadioButton7)
        Me.activityDisplayPanel.Controls.Add(Me.RadioButton6)
        Me.activityDisplayPanel.Controls.Add(Me.RadioButton5)
        Me.activityDisplayPanel.Controls.Add(Me.RadioButton4)
        Me.activityDisplayPanel.Controls.Add(Me.RadioButton3)
        Me.activityDisplayPanel.Controls.Add(Me.RadioButton2)
        Me.activityDisplayPanel.Controls.Add(Me.RadioButton1)
        Me.activityDisplayPanel.Location = New System.Drawing.Point(13, 263)
        Me.activityDisplayPanel.Size = New System.Drawing.Size(204, 45)
        '
        'RadioButton8
        '
        Me.RadioButton8.Font = New System.Drawing.Font("Tahoma", 12.0!, System.Drawing.FontStyle.Regular)
        Me.RadioButton8.Location = New System.Drawing.Point(176, 8)
        Me.RadioButton8.Size = New System.Drawing.Size(18, 27)
        '
        'RadioButton7
        '
        Me.RadioButton7.Font = New System.Drawing.Font("Tahoma", 12.0!, System.Drawing.FontStyle.Regular)
        Me.RadioButton7.Location = New System.Drawing.Point(153, 8)
        Me.RadioButton7.Size = New System.Drawing.Size(18, 27)
        '
        'RadioButton6
        '
        Me.RadioButton6.Font = New System.Drawing.Font("Tahoma", 12.0!, System.Drawing.FontStyle.Regular)
        Me.RadioButton6.Location = New System.Drawing.Point(130, 8)
        Me.RadioButton6.Size = New System.Drawing.Size(18, 27)
        '
        'RadioButton5
        '
        Me.RadioButton5.Font = New System.Drawing.Font("Tahoma", 12.0!, System.Drawing.FontStyle.Regular)
        Me.RadioButton5.Location = New System.Drawing.Point(107, 8)
        Me.RadioButton5.Size = New System.Drawing.Size(18, 27)
        '
        'RadioButton4
        '
        Me.RadioButton4.Font = New System.Drawing.Font("Tahoma", 12.0!, System.Drawing.FontStyle.Regular)
        Me.RadioButton4.Location = New System.Drawing.Point(84, 8)
        Me.RadioButton4.Size = New System.Drawing.Size(18, 27)
        '
        'RadioButton3
        '
        Me.RadioButton3.Font = New System.Drawing.Font("Tahoma", 12.0!, System.Drawing.FontStyle.Regular)
        Me.RadioButton3.Location = New System.Drawing.Point(61, 8)
        Me.RadioButton3.Size = New System.Drawing.Size(18, 27)
        '
        'RadioButton2
        '
        Me.RadioButton2.Font = New System.Drawing.Font("Tahoma", 12.0!, System.Drawing.FontStyle.Regular)
        Me.RadioButton2.Location = New System.Drawing.Point(38, 8)
        Me.RadioButton2.Size = New System.Drawing.Size(18, 27)
        '
        'RadioButton1
        '
        Me.RadioButton1.Checked = True
        Me.RadioButton1.Font = New System.Drawing.Font("Tahoma", 12.0!, System.Drawing.FontStyle.Regular)
        Me.RadioButton1.Location = New System.Drawing.Point(15, 8)
        Me.RadioButton1.Size = New System.Drawing.Size(18, 27)
        '
        'activityTimer
        '
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        '
        'autoFtpProcessForm
        '
        Me.BackColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(236, 311)
        Me.ControlBox = False
        Me.Controls.Add(Me.activityDisplayPanel)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.PictureBox2)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.transferStatusLabel)
        Me.Controls.Add(Me.stateLabel)
        Me.Controls.Add(Me.pbProgress)
        Me.Text = "Upload / Download"

    End Sub

#End Region

    Private Function doUploadDownload(ByRef userRecord As userSpecRecordClass) As String

        Dim result As String

        TagTrakGlobals.uploadReminderTimer.Enabled = False
        If userSpecRecord.FirstReminderInterval > 0 Then
            TagTrakGlobals.uploadReminderTimer.Interval = userSpecRecord.FirstReminderInterval * 60000
            TagTrakGlobals.timeCounter = 120 - userSpecRecord.FirstReminderInterval
        End If

        ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
        '   Set up transfer display form status label and actio buttons            '
        ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

        transferStatusLabel.Visible = True
        transferStatusLabel.Text = "Checking For Connection"

        Application.DoEvents()

        ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
        '   Establish / Open ftp connection to mail server host                    '
        ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
        result = ftpProcessor.ftpEstablishFtpSession()

        If result <> "OK" Then

            ftpProcessor.ftpCloseFtpSession()

            transferStatusLabel.Text = "Connection Failed"

            Application.DoEvents()

            Return result

        End If

        Me.RadioButton1.Checked = True

        activityDisplayPanel.Visible = True
        transferStatusLabel.Text = "Connection Found"

        Application.DoEvents()

        '' Get the actual time, try using NTP first, if that fails
        '' fall back to the FTP /time method.
        Dim NTPConnector As New NtpClass(userRecord)
        Try
            scannerDateAndTimeUTC = DateTime.UtcNow
            NTPConnector.SetTime()
            serverDateAndTimeUTC = DateTime.UtcNow
            lastTimeSync = TagTrakGlobals.TimeSyncTypes.NTP
            serverDateAndTimeSource = NTPConnector.CurrentServer

        Catch ex As Exception
            '' Try FTP time.
            '' We need this because ActiveSync does not support UDP passthrough which is required for NTP.
            result = ftpProcessor.GetServerTime()

            If result <> "OK" Then
                '' All time sync methods failed.
                serverDateAndTimeUTC = DateTime.UtcNow
                scannerDateAndTimeUTC = DateTime.UtcNow
                lastTimeSync = TagTrakGlobals.TimeSyncTypes.None
            End If
        End Try

        ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
        'Created Auth file on server
        ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
        If userSpecRecord.ftpAuthorization Then

            result = ftpProcessor.UploadAuthFile()

            'If result <> "OK" Then
            '    ftpProcessor.ftpCloseFtpSession()
            '    Return result
            'End If
        End If

        result = ftpProcessor.ftpDownloadTimeZoneOffsetFile()
        If result <> "OK" Then : ftpProcessor.ftpCloseFtpSession() : Return result : End If

        ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
        '   Upload the resdit file if there exists resdit and/or related info.     '
        ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

        result = ftpProcessor.ftpUploadResditFile()

        If result = "OK" Then
            userRecord.scanRecordSet.Clear()
        Else
            ftpProcessor.ftpCloseFtpSession() : Return result
        End If

        ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
        '   Upload new routings if they exist                                      '
        ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

        result = ftpProcessor.ftpUploadNewRoutings()
        If result <> "OK" Then : ftpProcessor.ftpCloseFtpSession() : Return result : End If


        ' Download of new program and configuration should happen right after
        ' upload of resdit and routings, since other downloads may not be 
        ' needed in new version if available, and might even cause problems which
        ' is to be fixed in new version.
#If deviceType <> "PC" Then

        ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
        '   Download a new version of the scanner program. Download will occur if  '
        '   a newer version exists. A scanner configuration file on the server is  '
        '   first brought down to the scanner. The scanner configuration file has  '
        '   the information as to which version of the scanner program is current  '
        ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

        result = ftpProcessor.ftpDownloadUpdatedProgram()
        If result <> "OK" Then : ftpProcessor.ftpCloseFtpSession() : Return result : End If

        ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
        '   Download a new version of the user configuration file. Download will   '
        '   occur if a newer version of the file exists.                           '
        ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

        'ftpProcessor.ftpDownloadScannerConfig()
        'If result <> "OK" Then : ftpProcessor.ftpCloseFtpSession() : Return result : End If

#End If

        ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
        '   Download the flight summary file if it exists and is newer then the    '
        '   current version on the scanner.                                        '
        ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

        result = ftpProcessor.ftpDownloadSummaryFile()
        If result <> "OK" Then : ftpProcessor.ftpCloseFtpSession() : Return result : End If

        ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
        '   Download a routings file if it exists and is newer then the current    '
        '   version on the scanner.                                                '
        ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

        result = ftpProcessor.ftpDownloadRoutings()
        If result <> "OK" Then : ftpProcessor.ftpCloseFtpSession() : Return result : End If

        ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
        '   Download a file of routing updates if it exists and is newer then the  '
        '   current version on the scanner.                                        '
        ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

        result = ftpProcessor.ftpDownloadRoutingUpdates()
        If result <> "OK" Then : ftpProcessor.ftpCloseFtpSession() : Return result : End If

        ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
        '   Download the cardit routings file if it exists and is newer then the   '
        '   current version on the scanner.                                        '
        ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

        result = ftpProcessor.ftpDownloadCarditRoutings()
        If result <> "OK" Then : ftpProcessor.ftpCloseFtpSession() : Return result : End If

        ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
        '   Download the ontime file if it exists and is newer then the            '
        '   current version on the scanner.                                        '
        ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

        result = ftpProcessor.ftpDownloadOntimeFile()
        If result <> "OK" Then : ftpProcessor.ftpCloseFtpSession() : Return result : End If

        ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
        '   Download the flight routes file if it exists and is newer then the            '
        '   current version on the scanner.                                        '
        ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

        result = ftpProcessor.ftpDownloadFlightRoutesFile()
        If result <> "OK" Then : ftpProcessor.ftpCloseFtpSession() : Return result : End If


        ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
        '   Download any messages for this device.                                 '
        ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

        messagesFoundFlag = False

        result = ftpProcessor.ftpDownloadMessages(messagesFoundFlag)
        If result <> "OK" Then Return result

        'result = ftpProcessor.ftpDownloadAuxillarySystem()
        'If result <> "OK" Then
        '    MsgBox("Download of auxillary system " & result)
        'End If

        ftpProcessor.ftpCloseFtpSession()

        'Added by MX
        DownloadPasswordFile()

        DownloadAirportCodesFile()

        transferStatusLabel.Text = "Transfer Completed"
        transferStatusLabel.Visible = True

        activityDisplayPanel.Visible = False

#If False Then

        Dim result As String

        transferStatusLabel.Visible = True
        transferStatusLabel.Text = "Checking For Connection"

        updateProgressBar = False

        result = ftpProcessor.ftpEstablishFtpSession()
        If result <> "OK" Then

            ftpProcessor.ftpCloseFtpSession()
            transferStatusLabel.Text = "Connection Failed"

            Return result

        End If

        transferStatusLabel.Text = "Connection Found"

        ftpProcessor.ftpDownloadTimeZoneOffsetFile()
        ftpProcessor.ftpDownloadSummaryFile()
        ftpProcessor.ftpDownloadRoutings()
        ftpProcessor.ftpDownloadRoutingUpdates()
        ftpProcessor.ftpDownloadSchedule()
        ftpProcessor.ftpDownloadCarditRoutings()
        ftpProcessor.ftpDownloadOntimeFile()
        ftpProcessor.ftpDownloadFlightRoutesFile()
        result = ftpProcessor.ftpUploadResditFile()

        If result = "OK" Then
            userRecord.scanRecordSet.Clear()
        Else
            MsgBox(result.ToString, MsgBoxStyle.Exclamation, "Upload Of Resdit File Failed.")
        End If

        ftpProcessor.ftpDownloadSummaryFile()
        ftpProcessor.ftpDownloadUpdatedProgram()

        ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
        '   Download the ontime file if it exists and is newer then the            '
        '   current version on the scanner.                                        '
        ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

        result = ftpProcessor.ftpDownloadOntimeFile()
        If result <> "OK" Then : ftpProcessor.ftpCloseFtpSession() : Return result : End If

        ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
        '   Download the flight routes file if it exists and is newer then the            '
        '   current version on the scanner.                                        '
        ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

        result = ftpProcessor.ftpDownloadFlightRoutesFile()
        If result <> "OK" Then : ftpProcessor.ftpCloseFtpSession() : Return result : End If

        ftpProcessor.ftpCloseFtpSession()

        transferStatusLabel.Text = "Transfer Completed"

        MailScanFormRepository.MailScanDomsForm.resetOperationComboBoxWithoutWarning()

#End If

        Return "OK"

    End Function

    Private Function DownloadPasswordFile() As Boolean

        Dim ftp As New Ftp

        Dim ftpServerName As String = "ftp.asiscan.com"
        Dim ftpServerPort As Integer = 21
        Dim ftpUserName As String = "asi_general"
        Dim ftpPassword As String = "g3n3r@l!ti3s"
        Dim ftpRemotePath As String = "/scanner_passwd.gz"
        Dim ftpLocalPath As String = TagTrakConfigDirectory & "\scanner_passwd.gz"
        Dim ftpRemoteFileDate As Date
        Dim localPasswdFileDate As Date
        Dim passwordFilePath As String = TagTrakConfigDirectory & "\password.txt"
        Dim localPasswdStampFilePath As String = TagTrakConfigDirectory & "\passwdTimeStamp.txt"

        If File.Exists(localPasswdStampFilePath) Then

            If getDateStampFromDateStampFile(localPasswdStampFilePath, localPasswdFileDate) <> "OK" Then
                localPasswdFileDate = Date.MinValue
            End If

        Else
            localPasswdFileDate = Date.MinValue
        End If

        'Connecting using proxy (copied from FtpProcessClass)
        With userSpecRecord

            If .UseFtpProxy And isNonNullString(.ProxyHost) And .ProxyPort <> Nothing Then

                Dim t As FtpProxyType

                Select Case .ProxyType.ToLower()
                    Case "ftpopen"
                        t = FtpProxyType.FtpOpen
                    Case "ftpsite"
                        t = FtpProxyType.FtpSite
                    Case "ftpuser"
                        t = FtpProxyType.FtpUser
                    Case "httpconnect"
                        t = FtpProxyType.HttpConnect
                    Case "socks4"
                        t = FtpProxyType.Socks4
                    Case "socks4a"
                        t = FtpProxyType.Socks4a
                    Case "socks5"
                        t = FtpProxyType.Socks5
                    Case Else
                        t = FtpProxyType.None
                End Select

                If isNonNullString(.ProxyUser) And isNonNullString(.ProxyPassword) Then
                    Dim crd As New System.Net.NetworkCredential(.ProxyUser, .ProxyPassword)
                    ftp.Proxy = New Rebex.Net.FtpProxy(t, .ProxyHost, .ProxyPort, crd)
                ElseIf isNonNullString(.ProxyUser) Then
                    ftp.Proxy = New Rebex.Net.FtpProxy(t, .ProxyHost, .ProxyPort, .ProxyUser)
                Else
                    ftp.Proxy = New Rebex.Net.FtpProxy(t, .ProxyHost, .ProxyPort)
                End If
            End If

        End With

        Try
            ftp.Connect(ftpServerName, ftpServerPort)
        Catch ex As Exception
            Return False
        End Try

        Try
            ftp.Login(ftpUserName, ftpPassword)
        Catch ex As Exception
            Return False
        End Try

        Try
            ftp.SetTransferType(FtpTransferType.Binary)
        Catch ex As Exception
            Return False
        End Try

        Try
            ftpRemoteFileDate = ftp.GetFileDateTime(ftpRemotePath)
        Catch ex As Exception
            Return False
        End Try

        If Date.Compare(localPasswdFileDate, ftpRemoteFileDate) < 0 Then

            Try
                ftp.GetFile(ftpRemotePath, ftpLocalPath)
            Catch ex As Exception
                Return False
            End Try

            Try
                If ftp.State <> FtpState.Disconnected Then
                    ftp.Disconnect()
                    ftp.Dispose()
                End If
            Catch ex As Exception
                Return False
            End Try

            Try
                gunzip(ftpLocalPath, passwordFilePath)
                deleteLocalFile(ftpLocalPath)
            Catch ex As Exception
                Return False
            End Try

            Try
                If saveDateStampToDateStampFile(ftpRemoteFileDate, localPasswdStampFilePath) <> "OK" Then
                    Return False
                End If
            Catch ex As Exception
                Return False
            End Try

        End If

        Try
            If ftp.State <> FtpState.Disconnected Then
                ftp.Disconnect()
                ftp.Dispose()
            End If
        Catch ex As Exception
            Return False
        End Try

        Return True

    End Function

    Private Function DownloadAirportCodesFile() As Boolean

        Dim ftp As New Ftp

        Dim ftpServerName As String = "ftp.asiscan.com"
        Dim ftpServerPort As Integer = 21
        Dim ftpUserName As String = "asi_general"
        Dim ftpPassword As String = "g3n3r@l!ti3s"
        Dim ftpRemotePath As String = "/airport_codes.gz"
        Dim ftpLocalPath As String = TagTrakDataDirectory & "\airport_codes.gz"
        Dim ftpRemoteFileDate As Date
        Dim localFileDate As Date
        Dim localFilePath As String = TagTrakDataDirectory & "\airport_codes.txt"
        Dim localStampFilePath As String = TagTrakConfigDirectory & "\airport_codesTimeStamp.txt"

        If File.Exists(localStampFilePath) Then

            If getDateStampFromDateStampFile(localStampFilePath, localFileDate) <> "OK" Then
                localFileDate = Date.MinValue
            End If

        Else
            localFileDate = Date.MinValue
        End If

        'Connecting using proxy (copied from FtpProcessClass)
        With userSpecRecord

            If .UseFtpProxy And isNonNullString(.ProxyHost) And .ProxyPort <> Nothing Then

                Dim t As FtpProxyType

                Select Case .ProxyType.ToLower()
                    Case "ftpopen"
                        t = FtpProxyType.FtpOpen
                    Case "ftpsite"
                        t = FtpProxyType.FtpSite
                    Case "ftpuser"
                        t = FtpProxyType.FtpUser
                    Case "httpconnect"
                        t = FtpProxyType.HttpConnect
                    Case "socks4"
                        t = FtpProxyType.Socks4
                    Case "socks4a"
                        t = FtpProxyType.Socks4a
                    Case "socks5"
                        t = FtpProxyType.Socks5
                    Case Else
                        t = FtpProxyType.None
                End Select

                If isNonNullString(.ProxyUser) And isNonNullString(.ProxyPassword) Then
                    Dim crd As New System.Net.NetworkCredential(.ProxyUser, .ProxyPassword)
                    ftp.Proxy = New Rebex.Net.FtpProxy(t, .ProxyHost, .ProxyPort, crd)
                ElseIf isNonNullString(.ProxyUser) Then
                    ftp.Proxy = New Rebex.Net.FtpProxy(t, .ProxyHost, .ProxyPort, .ProxyUser)
                Else
                    ftp.Proxy = New Rebex.Net.FtpProxy(t, .ProxyHost, .ProxyPort)
                End If
            End If

        End With

        Try
            ftp.Connect(ftpServerName, ftpServerPort)
        Catch ex As Exception
            Return False
        End Try

        Try
            ftp.Login(ftpUserName, ftpPassword)
        Catch ex As Exception
            Return False
        End Try

        Try
            ftp.SetTransferType(FtpTransferType.Binary)
        Catch ex As Exception
            Return False
        End Try

        Try
            ftpRemoteFileDate = ftp.GetFileDateTime(ftpRemotePath)
        Catch ex As Exception
            Return False
        End Try

        If Date.Compare(localFileDate, ftpRemoteFileDate) < 0 Then

            Try
                ftp.GetFile(ftpRemotePath, ftpLocalPath)
            Catch ex As Exception
                Return False
            End Try

            Try
                If ftp.State <> FtpState.Disconnected Then
                    ftp.Disconnect()
                    ftp.Dispose()
                End If
            Catch ex As Exception
                Return False
            End Try

            Try
                gunzip(ftpLocalPath, localFilePath)
                deleteLocalFile(ftpLocalPath)
            Catch ex As Exception
                Return False
            End Try

            Try
                If saveDateStampToDateStampFile(ftpRemoteFileDate, localStampFilePath) <> "OK" Then
                    Return False
                End If
            Catch ex As Exception
                Return False
            End Try

            Data.Cities.List.Load(localFilePath)

        End If

        Try
            If ftp.State <> FtpState.Disconnected Then
                ftp.Disconnect()
                ftp.Dispose()
            End If
        Catch ex As Exception
            Return False
        End Try

        Return True

    End Function

    Private Sub ftpProcess_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        Dim result As String

#If deviceType = "PC" Then
        exit sub
#End If

        activityTimer.Enabled = True

        result = doUploadDownload(userSpecRecord)

        activityTimer.Enabled = False

        If File.Exists("\Flash File Store\HardwareError.txt") Then
            Dim hardwareErrorLockDown As New deviceHardwareErrorMessage
            hardwareErrorLockDown.ShowDialog()
        End If

        If newApplicationVersionFound Or newConfigurationFileFound Then
            Dim newVersionDisplayForm As New newVersionNotification
            DialogResult = newVersionDisplayForm.ShowDialog()
            Me.DialogResult = DialogResult.Abort
            Exit Sub
        End If

        If newCarditRoutingFileFound Then
            loadCarditRoutingFile()
        End If

        Me.Visible = False
        Me.Close()
        Me.Dispose()

    End Sub

    Dim withinftpProcessActivated As Boolean = False

    '    Private Sub ftpProcessActivated(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Activated

    '        Dim result As String

    '#If deviceType <> "PC" Then
    '        Exit Sub
    '#End If

    '        If withinftpProcessActivated Then Exit Sub

    '        withinftpProcessActivated = True

    '        result = doUploadDownloadProcess(userSpecRecord)

    '        If result <> "OK" Then
    '            Me.Visible = False


    '            Me.Close()
    '            Me.Dispose()

    '            Exit Sub
    '        End If

    '        If File.Exists("\Flash File Store\HardwareError.txt") Then
    '            Dim hardwareErrorLockDown As New deviceHardwareErrorMessage
    '            hardwareErrorLockDown.ShowDialog()
    '        End If

    '        If newApplicationVersionFound Or newConfigurationFileFound Then
    '            Dim newVersionDisplayForm As New newVersionNotification
    '            newVersionDisplayForm.ShowDialog()
    '            Me.DialogResult = DialogResult.Abort
    '            Exit Sub
    '        End If

    '        If newCarditRoutingFileFound Then
    '            loadCarditRoutingFile()
    '        End If

    '        Me.Visible = False


    '        Me.Close()
    '        Me.Dispose()

    '        Exit Sub

    '    End Sub

    Dim closingFromFinishButtonClick As Boolean = False

    Private Sub ftpProcessForm_Closing(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles MyBase.Closing

        If File.Exists("\Flash File Store\HardwareError.txt") Then
            Dim hardwareErrorLockDown As New deviceHardwareErrorMessage
            hardwareErrorLockDown.ShowDialog()
        End If

    End Sub

    Private Sub activityTimer_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles activityTimer.Tick

        Dim currentCheckedIndex As Integer = getCurrentCheckedIndex()

        Dim index As Integer

        For index = 0 To 7
            progressRadioButtonList(index).Checked = False
        Next

        currentCheckedIndex = (currentCheckedIndex + 1) Mod 8

        progressRadioButtonList(currentCheckedIndex).Checked = True

    End Sub

    Private Function getCurrentCheckedIndex() As Integer

        Dim index As Integer

        For index = 0 To 7
            If progressRadioButtonList(index).Checked Then
                Return index
            End If
        Next

        Return 0

    End Function

End Class

