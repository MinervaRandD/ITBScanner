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

Public Class adminBaseForm
    Inherits System.Windows.Forms.Form

    'Dim localTimeZone As String
    Public blnCompleteConfig As Boolean = False

#Region " Windows Form Designer generated code "

    Public Sub New()

        MyBase.New()

        Cursor.Current = Cursors.WaitCursor

        InitializeComponent()

        userLabel.Text = user
        deviceTypeLabel.Text = device
        versionLabel.Text = myVersion
        serialNumberLabel.Text = deviceSerialNumber

        baseFormTimer.Interval = 250
        baseFormTimer.Enabled = True

        Me.ipAddressLabel.Text = Util.getIPAddress()

        Me.DialogResult = DialogResult.OK

        Cursor.Current = Cursors.Default

    End Sub

    Private Sub form_Closing(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles MyBase.Closing

    End Sub

    Protected Overloads Overrides Sub Dispose(ByVal disposing As Boolean)
        MyBase.Dispose(disposing)
    End Sub

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    Friend WithEvents baseFormTimer As System.Windows.Forms.Timer
    Friend WithEvents returnToScanButton As System.Windows.Forms.Button
    Friend WithEvents passwordsButton As System.Windows.Forms.Button
    Friend WithEvents adminConfigButton As System.Windows.Forms.Button
    Friend WithEvents serialNumberLabel As System.Windows.Forms.Label
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents deviceTypeLabel As System.Windows.Forms.Label
    Friend WithEvents deviceTitleLabel As System.Windows.Forms.Label
    Friend WithEvents userLabel As System.Windows.Forms.Label
    Friend WithEvents userTitleLabel As System.Windows.Forms.Label
    Friend WithEvents versionLabel As System.Windows.Forms.Label
    Friend WithEvents versionTitleLabel As System.Windows.Forms.Label
    Friend WithEvents ftpClientButton As System.Windows.Forms.Button
    Friend WithEvents operationLogButton As System.Windows.Forms.Button
    Friend WithEvents resditButton As System.Windows.Forms.Button
    Friend WithEvents Label22 As System.Windows.Forms.Label
    Friend WithEvents ipAddressLabel As System.Windows.Forms.Label
    Friend WithEvents adminDateAndTimeButton As System.Windows.Forms.Button
    Friend WithEvents localDateAndTimeLabel As System.Windows.Forms.Label
    Friend WithEvents UtcDateAndTimeLabel As System.Windows.Forms.Label
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.baseFormTimer = New System.Windows.Forms.Timer
        Me.returnToScanButton = New System.Windows.Forms.Button
        Me.adminConfigButton = New System.Windows.Forms.Button
        Me.passwordsButton = New System.Windows.Forms.Button
        Me.serialNumberLabel = New System.Windows.Forms.Label
        Me.Label8 = New System.Windows.Forms.Label
        Me.deviceTypeLabel = New System.Windows.Forms.Label
        Me.deviceTitleLabel = New System.Windows.Forms.Label
        Me.userLabel = New System.Windows.Forms.Label
        Me.userTitleLabel = New System.Windows.Forms.Label
        Me.versionLabel = New System.Windows.Forms.Label
        Me.versionTitleLabel = New System.Windows.Forms.Label
        Me.ftpClientButton = New System.Windows.Forms.Button
        Me.operationLogButton = New System.Windows.Forms.Button
        Me.resditButton = New System.Windows.Forms.Button
        Me.Label22 = New System.Windows.Forms.Label
        Me.ipAddressLabel = New System.Windows.Forms.Label
        Me.adminDateAndTimeButton = New System.Windows.Forms.Button
        Me.localDateAndTimeLabel = New System.Windows.Forms.Label
        Me.UtcDateAndTimeLabel = New System.Windows.Forms.Label
        '
        'baseFormTimer
        '
        '
        'returnToScanButton
        '
        Me.returnToScanButton.Location = New System.Drawing.Point(36, 260)
        Me.returnToScanButton.Size = New System.Drawing.Size(164, 25)
        Me.returnToScanButton.Text = "Return To Admin Login"
        '
        'adminConfigButton
        '
        Me.adminConfigButton.Location = New System.Drawing.Point(120, 176)
        Me.adminConfigButton.Size = New System.Drawing.Size(104, 25)
        Me.adminConfigButton.Text = "Configuration"
        '
        'passwordsButton
        '
        Me.passwordsButton.Location = New System.Drawing.Point(12, 176)
        Me.passwordsButton.Size = New System.Drawing.Size(104, 25)
        Me.passwordsButton.Text = "Passwords"
        '
        'serialNumberLabel
        '
        Me.serialNumberLabel.Location = New System.Drawing.Point(126, 84)
        Me.serialNumberLabel.Size = New System.Drawing.Size(102, 15)
        '
        'Label8
        '
        Me.Label8.Location = New System.Drawing.Point(30, 84)
        Me.Label8.Size = New System.Drawing.Size(86, 17)
        Me.Label8.Text = "Serial Number:"
        '
        'deviceTypeLabel
        '
        Me.deviceTypeLabel.Location = New System.Drawing.Point(126, 64)
        Me.deviceTypeLabel.Size = New System.Drawing.Size(102, 15)
        '
        'deviceTitleLabel
        '
        Me.deviceTitleLabel.Location = New System.Drawing.Point(30, 60)
        Me.deviceTitleLabel.Size = New System.Drawing.Size(92, 17)
        Me.deviceTitleLabel.Text = "Device Type:"
        '
        'userLabel
        '
        Me.userLabel.Location = New System.Drawing.Point(126, 40)
        Me.userLabel.Size = New System.Drawing.Size(102, 16)
        '
        'userTitleLabel
        '
        Me.userTitleLabel.Location = New System.Drawing.Point(30, 40)
        Me.userTitleLabel.Size = New System.Drawing.Size(86, 17)
        Me.userTitleLabel.Text = "User:"
        '
        'versionLabel
        '
        Me.versionLabel.Location = New System.Drawing.Point(126, 20)
        Me.versionLabel.Size = New System.Drawing.Size(102, 15)
        '
        'versionTitleLabel
        '
        Me.versionTitleLabel.Location = New System.Drawing.Point(30, 20)
        Me.versionTitleLabel.Size = New System.Drawing.Size(85, 14)
        Me.versionTitleLabel.Text = "Version:"
        '
        'ftpClientButton
        '
        Me.ftpClientButton.Location = New System.Drawing.Point(120, 232)
        Me.ftpClientButton.Size = New System.Drawing.Size(104, 25)
        Me.ftpClientButton.Text = "Ftp Client"
        '
        'operationLogButton
        '
        Me.operationLogButton.Location = New System.Drawing.Point(12, 232)
        Me.operationLogButton.Size = New System.Drawing.Size(104, 25)
        Me.operationLogButton.Text = "Device Op Log"
        '
        'resditButton
        '
        Me.resditButton.Location = New System.Drawing.Point(12, 204)
        Me.resditButton.Size = New System.Drawing.Size(104, 25)
        Me.resditButton.Text = "Resdit"
        '
        'Label22
        '
        Me.Label22.Location = New System.Drawing.Point(30, 104)
        Me.Label22.Size = New System.Drawing.Size(82, 17)
        Me.Label22.Text = "IP Address:"
        '
        'ipAddressLabel
        '
        Me.ipAddressLabel.Location = New System.Drawing.Point(126, 104)
        Me.ipAddressLabel.Size = New System.Drawing.Size(134, 21)
        '
        'adminDateAndTimeButton
        '
        Me.adminDateAndTimeButton.Location = New System.Drawing.Point(120, 204)
        Me.adminDateAndTimeButton.Size = New System.Drawing.Size(104, 25)
        Me.adminDateAndTimeButton.Text = "Date And Time"
        '
        'localDateAndTimeLabel
        '
        Me.localDateAndTimeLabel.Location = New System.Drawing.Point(8, 156)
        Me.localDateAndTimeLabel.Size = New System.Drawing.Size(220, 18)
        Me.localDateAndTimeLabel.Text = "Date And Time"
        Me.localDateAndTimeLabel.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'UtcDateAndTimeLabel
        '
        Me.UtcDateAndTimeLabel.Location = New System.Drawing.Point(25, 128)
        Me.UtcDateAndTimeLabel.Size = New System.Drawing.Size(185, 18)
        Me.UtcDateAndTimeLabel.Text = "Date And Time"
        Me.UtcDateAndTimeLabel.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'adminBaseForm
        '
        Me.ClientSize = New System.Drawing.Size(234, 308)
        Me.ControlBox = False
        Me.Controls.Add(Me.UtcDateAndTimeLabel)
        Me.Controls.Add(Me.localDateAndTimeLabel)
        Me.Controls.Add(Me.adminDateAndTimeButton)
        Me.Controls.Add(Me.Label22)
        Me.Controls.Add(Me.ipAddressLabel)
        Me.Controls.Add(Me.resditButton)
        Me.Controls.Add(Me.operationLogButton)
        Me.Controls.Add(Me.ftpClientButton)
        Me.Controls.Add(Me.serialNumberLabel)
        Me.Controls.Add(Me.Label8)
        Me.Controls.Add(Me.deviceTypeLabel)
        Me.Controls.Add(Me.deviceTitleLabel)
        Me.Controls.Add(Me.userLabel)
        Me.Controls.Add(Me.userTitleLabel)
        Me.Controls.Add(Me.versionLabel)
        Me.Controls.Add(Me.versionTitleLabel)
        Me.Controls.Add(Me.passwordsButton)
        Me.Controls.Add(Me.adminConfigButton)
        Me.Controls.Add(Me.returnToScanButton)
        Me.Text = "Admin Functionality"

    End Sub

#End Region

    Private Sub adminConfigButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles adminConfigButton.Click

        'Modified by MX
        If Not blnCompleteConfig Then

            AdminFormRepository.adminSubConfigForm.Show()

        Else

            AdminFormRepository.adminConfigForm.Show()

        End If

    End Sub

    Private Sub passwordsButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles passwordsButton.Click

        AdminFormRepository.adminPasswordForm.Show()

    End Sub

    Private Sub resditButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles resditButton.Click

        Dim dialogResult As DialogResult

        Dim resditDisplayForm As adminResditForm = AdminFormRepository.adminResditForm

        resditDisplayForm.ReloadFileList()

        resditDisplayForm.Show()

    End Sub

    Private Sub operationLogButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles operationLogButton.Click

        AdminFormRepository.adminLoggingForm.Show()
    End Sub

    Private Sub adminDateAndTimeButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles adminDateAndTimeButton.Click
        'AdminFormRepository.adminDateTimeForm.Show()
        'AdminFormRepository.adminDateTimeForm.WindowState = FormWindowState.Maximized
        Dim dlg As New adminDateTimeForm
        dlg.ShowDialog()
    End Sub

    Private Sub returnToScanButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles returnToScanButton.Click
        Me.Hide()
    End Sub

    Private Sub baseFormTimer_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles baseFormTimer.Tick
        If Time.Local.IsKnown(scannerTimeZone) Then
            localDateAndTimeLabel.Text = String.Format("{0:yyyy-MM-dd hh:mm:ss tt} local", Time.Local.GetTime(scannerTimeZone))
        Else
            localDateAndTimeLabel.Text = "LOCAL TIME UNKNOWN"
        End If
        Me.UtcDateAndTimeLabel.Text = String.Format("{0:yyyy-MM-dd hh:mm:ss tt} ", DateTime.UtcNow) & "(UTC)"
    End Sub

    Private Sub ftpClientButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ftpClientButton.Click
        AdminFormRepository.adminFtpClientForm.Show()
    End Sub

End Class


