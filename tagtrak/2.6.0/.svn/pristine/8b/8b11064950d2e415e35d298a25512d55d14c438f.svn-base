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
Imports System.io
Imports Rebex.Net
'Imports OpenNETCF.Win32.Win32Window

Public Class ftpProcessForm

    Inherits System.Windows.Forms.Form

    Friend WithEvents stateLabel As System.Windows.Forms.Label
    Friend WithEvents pbProgress As System.Windows.Forms.ProgressBar
    Friend WithEvents transferStatusLabel As System.Windows.Forms.Label

    Dim messagesFoundFlag As Boolean

    Dim progressRadioButtonList(7) As RadioButton

    Public autoClose As Boolean = False

    'Dim AlwaysOnTop As Boolean = False 'When set will block the wireless connection bubble window, which provides means to OS screen.


#Region " Windows Form Designer generated code "

    Dim ftpProcessor As ftpProcessClass

    Public Sub New()

        MyBase.New()

        Cursor.Current = Cursors.WaitCursor

        'This call is required by the Windows Form Designer.
        InitializeComponent()

        'ftpProcessor = New ftpProcessClass(Me, stateLabel, pbProgress, transferStatusLabel)
        ftpProcessor = New ftpProcessClass(Me, Nothing, pbProgress, transferStatusLabel)

        activityDisplayPanel.Visible = False

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

        Cursor.Current = Cursors.Default

    End Sub

    Protected Overloads Overrides Sub Dispose(ByVal disposing As Boolean)
        MyBase.Dispose(disposing)
    End Sub

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    Friend WithEvents finishButton As System.Windows.Forms.Button
    Friend WithEvents retryFtpButton As System.Windows.Forms.Button
    Friend WithEvents activityDisplayPanel As System.Windows.Forms.Panel
    Friend WithEvents activityTimer As System.Windows.Forms.Timer
    Friend WithEvents RadioButton1 As System.Windows.Forms.RadioButton
    Friend WithEvents RadioButton2 As System.Windows.Forms.RadioButton
    Friend WithEvents RadioButton3 As System.Windows.Forms.RadioButton
    Friend WithEvents RadioButton4 As System.Windows.Forms.RadioButton
    Friend WithEvents RadioButton5 As System.Windows.Forms.RadioButton
    Friend WithEvents RadioButton6 As System.Windows.Forms.RadioButton
    Friend WithEvents RadioButton7 As System.Windows.Forms.RadioButton
    Friend WithEvents RadioButton8 As System.Windows.Forms.RadioButton

    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.finishButton = New System.Windows.Forms.Button
        Me.stateLabel = New System.Windows.Forms.Label
        Me.pbProgress = New System.Windows.Forms.ProgressBar
        Me.transferStatusLabel = New System.Windows.Forms.Label
        Me.retryFtpButton = New System.Windows.Forms.Button
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
        'finishButton
        '
        Me.finishButton.Location = New System.Drawing.Point(33, 158)
        Me.finishButton.Size = New System.Drawing.Size(168, 27)
        Me.finishButton.Text = "Finished"
        '
        'stateLabel
        '
        Me.stateLabel.Font = New System.Drawing.Font("Tahoma", 12.0!, System.Drawing.FontStyle.Regular)
        Me.stateLabel.Location = New System.Drawing.Point(24, 114)
        Me.stateLabel.Size = New System.Drawing.Size(191, 30)
        Me.stateLabel.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'pbProgress
        '
        Me.pbProgress.Location = New System.Drawing.Point(25, 72)
        Me.pbProgress.Maximum = 10000
        Me.pbProgress.Size = New System.Drawing.Size(184, 32)
        '
        'transferStatusLabel
        '
        Me.transferStatusLabel.Font = New System.Drawing.Font("Tahoma", 11.25!, System.Drawing.FontStyle.Bold)
        Me.transferStatusLabel.Location = New System.Drawing.Point(5, 16)
        Me.transferStatusLabel.Size = New System.Drawing.Size(224, 48)
        Me.transferStatusLabel.Text = "Transfer Completed"
        Me.transferStatusLabel.TextAlign = System.Drawing.ContentAlignment.TopCenter
        Me.transferStatusLabel.Visible = False
        '
        'retryFtpButton
        '
        Me.retryFtpButton.Location = New System.Drawing.Point(34, 192)
        Me.retryFtpButton.Size = New System.Drawing.Size(167, 27)
        Me.retryFtpButton.Text = "Retry Upload / Download"
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
        Me.activityDisplayPanel.Location = New System.Drawing.Point(17, 233)
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
        '
        'ftpProcessForm
        '
        Me.ClientSize = New System.Drawing.Size(234, 318)
        Me.ControlBox = False
        Me.Controls.Add(Me.activityDisplayPanel)
        Me.Controls.Add(Me.transferStatusLabel)
        Me.Controls.Add(Me.retryFtpButton)
        Me.Controls.Add(Me.finishButton)
        Me.Controls.Add(Me.stateLabel)
        Me.Controls.Add(Me.pbProgress)
        Me.Text = "Upload / Download"

    End Sub

#End Region

    Private Sub ftpErrorWrapUp()

        ftpProcessor.ftpCloseFtpSession()

        transferStatusLabel.Text = "Transfer Terminated"
        transferStatusLabel.Visible = True
        finishButton.Enabled = True

        Application.DoEvents()

    End Sub

    ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
    '                                                                              '
    ' Function: doUploadDownloadProcess. Returns: status information as a string   '
    '                                                                              '
    ' Note: Status information is a cascaded record of error strings propogated    '
    '       upward from subroutine calls.                                          '
    '                                                                              '
    ' Uploads and downloads information from the mail system server. The following '
    ' operations are performed in order:                                           '
    '                                                                              '
    ' 1. Upload a resdit file if one exists                                       '
    ' 2. Upload any new routings that may have been created by the user           '
    ' 3. Download the summary (manifest) file                                     '
    ' 4. Download a new USPS routines file if necessary                           '
    ' 5. Download any routing updates that may have been provided by the USPS     '
    ' 6. Download the flight schedule file if necessary                            '
    ' 7  Download the ontime file if necessary                                    '
    ' 8. Download a new copy of this program if one has been found.               '
    ' 9. Download a new configuration file if one is found.                       '
    ' 10. Download any local messages.                                            '
    ' 11. (Not implemented/tested) Downloads an auxillary system to be run on the  '
    '    scanner.                                                                  '
    '                                                                              '
    ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

    Private Function doUploadDownloadProcess(ByRef userRecord As userSpecRecordClass) As String

        Dim result As String

        If Me.autoClose Then
            Me.ftpProcessor.ShowErrors = False
        End If

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

        retryFtpButton.Enabled = False
        retryFtpButton.Visible = False

        finishButton.Enabled = False
        updateProgressBar = False

        Application.DoEvents()

        ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
        '   Establish / Open ftp connection to mail server host                    '
        ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
        result = ftpProcessor.ftpEstablishFtpSession()

        If result <> "OK" Then

            ftpProcessor.ftpCloseFtpSession()

            retryFtpButton.Enabled = True
            retryFtpButton.Visible = True

            transferStatusLabel.Text = "Connection Failed"
            finishButton.Enabled = True

            Application.DoEvents()

            Return result

        End If

        Me.RadioButton1.Checked = True

        activityDisplayPanel.Visible = True
        transferStatusLabel.Text = "Connection Found"

        Application.DoEvents()

        '' Get the actual time, try using NTP first, if that fails
        '' fall back to the FTPtime method.
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

        ''Download time zone offset/city information
        result = ftpProcessor.ftpDownloadTimeZoneOffsetFile()
        If result <> "OK" Then : ftpProcessor.ftpCloseFtpSession() : Return result : End If

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
        '   Download the flight schedule file if it exists and is newer then the   '
        '   current version on the scanner.                                        '
        ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

        result = ftpProcessor.ftpDownloadFlightSchedule()
        If result <> "OK" Then : ftpProcessor.ftpCloseFtpSession() : Return result : End If

        ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
        '   Download the flight load info file if it exists and is newer then the  '
        '   current version on the scanner if enabled.                             '
        ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

        If userSpecRecord.UnloadEntireFlight Then
            result = ftpProcessor.ftpDownloadFlightLoadInfo()
            If result <> "OK" Then : ftpProcessor.ftpCloseFtpSession() : Return result : End If
        End If

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

        finishButton.Enabled = True

        If messagesFoundFlag Then
            MsgBox("Messages Have Been Downloaded. Go To Message Pages To View.", MsgBoxStyle.Information, "Messages Found.")
        End If

        'activeReaderForm.resetOperationComboBoxWithoutWarning()

    End Function

    Private Function doUploadDownload() As String

        Dim result As String

        TagTrakGlobals.backgroundFtpTimer.cradleTickCount = 12 * 30

        activityTimer.Enabled = True
        result = doUploadDownloadProcess(userSpecRecord)
        activityTimer.Enabled = False
        finishButton.Enabled = True

        'Added by MX
        ftpProcessor.ftpDoNotDisconnectWireless = False
        ftpProcessor.ftpDisconnectWireless()

        If Me.autoClose Then
            Me.finishButton_Click(Nothing, Nothing)
        End If

        Return result

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

        If device <> "PC" Then
            doUploadDownload()
        End If

    End Sub

    Dim withinftpProcessActivated As Boolean = False

    Private Sub ftpProcessActivated(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Activated

        If device <> "PC" Then Exit Sub

        If withinftpProcessActivated Then Exit Sub

        withinftpProcessActivated = True

        doUploadDownload()

        withinftpProcessActivated = False


    End Sub

    Dim closingFromFinishButtonClick As Boolean = False

    Private Sub finishButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles finishButton.Click

        closingFromFinishButtonClick = True

        ftpProcessor.ftpDoNotDisconnectWireless = False

        ftpProcessor.ftpDisconnectWireless()

        Me.Close()

    End Sub

    Private Sub ftpProcessForm_Closing(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles MyBase.Closing

        If File.Exists("\Flash File Store\HardwareError.txt") Then
            Dim hardwareErrorLockDown As New deviceHardwareErrorMessage
            hardwareErrorLockDown.ShowDialog()
        End If

    End Sub

    Private Sub retryFtpButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles retryFtpButton.Click

        ftpProcessor.ftpDoNotDisconnectWireless = True

        doUploadDownload()

    End Sub

    'Private Sub formKeyPress(ByVal sender As System.Object, ByVal ex As KeyPressEventArgs) Handles MyBase.KeyPress

    '    'If ex.KeyChar = "0" Then
    '    '    exitString = ""
    '    '    Exit Sub
    '    'End If

    '    'exitString &= ex.KeyChar

    '    'If isValidExitPassword(exitString) Then
    '    '    appExitFlag.exitFlag = True
    '    '    Me.Close()
    '    'End If

    'End Sub


    Dim progressIndex As Integer = 1

    Private Sub activityTimer_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles activityTimer.Tick
        If closingFromFinishButtonClick Then Return

        progressRadioButtonList(progressIndex).Checked = True
        progressIndex = (progressIndex + 1) Mod 8


    End Sub

    ' Note: line Me.BringToFront() is to deal with ftpProcessForm get lost during program starting
    ' up when invoked from initiateform, which by itself is a modal form.
    ' A risky operation which may cause infinite loop or user getting stuck on this form. 
    ' hopefully by narrowing it to only the time when AttemptingWireless is true, 
    ' none of above disaster will occur.

    'Private Sub ftpProcessForm_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.LostFocus
    '    If AttemptingWireless Then
    '        Dim ipt As System.IntPtr = FindWindow(Nothing, "Trouble Connecting")
    '        If ipt.ToInt32() <> 0 Then
    '            SendMessage(ipt, 16, 0, 0)
    '        Else
    '            Dim dlg As New BalloonTerminator
    '            dlg.ShowDialog()
    '            Me.BringToFront()
    '        End If
    '    End If
    'End Sub
End Class
