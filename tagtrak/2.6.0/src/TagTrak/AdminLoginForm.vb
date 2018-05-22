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

Public Class adminLoginForm
    Inherits System.Windows.Forms.Form
    Friend WithEvents cancelButton As System.Windows.Forms.Button
    Friend WithEvents passwordTextBox As System.Windows.Forms.TextBox
    Friend WithEvents adminLoginButton As System.Windows.Forms.Button
    Friend WithEvents Label24 As System.Windows.Forms.Label

#Region " Windows Form Designer generated code "

    Public Sub New()

        MyBase.New()

        Cursor.Current = Cursors.WaitCursor

        'This call is required by the Windows Form Designer.
        InitializeComponent()

        currentAdminLoginForm = Me

        'baseFormUTCDateTimeLabel.Text = String.Format("{0:MMM dd, yyyy  HH:mm:ss} (UTC)", DateTime.UtcNow())
        baseFormUTCDateTimeLabel.Text = String.Format("{0:yyyy-MM-dd hh:mm:ss tt} (UTC)", DateTime.UtcNow)
        If Time.Local.IsKnown(scannerTimeZone) Then
            baseFormLocalDateTimeLabel.Text = String.Format("{0:yyyy-MM-dd hh:mm:ss tt} local", Time.Local.GetTime(scannerTimeZone))
        Else
            baseFormLocalDateTimeLabel.Text = "LOCAL TIME UNKNOWN"
        End If

        baseFormTimer.Enabled = True

        loadAdminFormLogo()

        hideMenuBarButton.Visible = userSpecRecord.lockDownReleasedInAdminForm
        hideMenuBarButton.Enabled = userSpecRecord.lockDownReleasedInAdminForm
        showMenuBarButton.Visible = userSpecRecord.lockDownReleasedInAdminForm
        showMenuBarButton.Enabled = userSpecRecord.lockDownReleasedInAdminForm

        Me.DialogResult = DialogResult.OK

        Cursor.Current = Cursors.Default

    End Sub


    Private Sub baseFormOnLoad(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        passwordSeedLabel.Text = enterPasswordForm()

    End Sub

    Private Sub form_Closing(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles MyBase.Closing

        exitPasswordForm()

    End Sub

    Protected Overloads Overrides Sub Dispose(ByVal disposing As Boolean)
        MyBase.Dispose(disposing)
    End Sub

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    Friend WithEvents baseFormTimer As System.Windows.Forms.Timer
    Friend WithEvents passwordSeedLabel As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents adminFormLogoPictureBox As System.Windows.Forms.PictureBox
    Friend WithEvents baseFormUTCDateTimeLabel As System.Windows.Forms.Label
    Friend WithEvents baseFormLocalDateTimeLabel As System.Windows.Forms.Label
    Friend WithEvents hideMenuBarButton As System.Windows.Forms.Button
    Friend WithEvents showMenuBarButton As System.Windows.Forms.Button
    Friend WithEvents MainMenu1 As System.Windows.Forms.MainMenu
#If deviceType <> "PC" Then
    Friend WithEvents InputPanel1 As Microsoft.WindowsCE.Forms.InputPanel
#End If
    Friend WithEvents MenuItem1 As System.Windows.Forms.MenuItem
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Dim resources As System.Resources.ResourceManager = New System.Resources.ResourceManager(GetType(adminLoginForm))
        Me.cancelButton = New System.Windows.Forms.Button
        Me.adminFormLogoPictureBox = New System.Windows.Forms.PictureBox
        Me.passwordTextBox = New System.Windows.Forms.TextBox
        Me.adminLoginButton = New System.Windows.Forms.Button
        Me.baseFormUTCDateTimeLabel = New System.Windows.Forms.Label
        Me.Label24 = New System.Windows.Forms.Label
        Me.baseFormTimer = New System.Windows.Forms.Timer
        Me.passwordSeedLabel = New System.Windows.Forms.Label
        Me.Label1 = New System.Windows.Forms.Label
        Me.baseFormLocalDateTimeLabel = New System.Windows.Forms.Label
        Me.hideMenuBarButton = New System.Windows.Forms.Button
        Me.showMenuBarButton = New System.Windows.Forms.Button
        Me.MainMenu1 = New System.Windows.Forms.MainMenu
#If deviceType <> "PC" Then
        Me.InputPanel1 = New Microsoft.WindowsCE.Forms.InputPanel
#End If
        Me.MenuItem1 = New System.Windows.Forms.MenuItem
        '
        'cancelButton
        '
        Me.cancelButton.Location = New System.Drawing.Point(33, 128)
        Me.cancelButton.Size = New System.Drawing.Size(169, 21)
        Me.cancelButton.Text = "CANCEL"
        '
        'adminFormLogoPictureBox
        '
        Me.adminFormLogoPictureBox.Image = CType(resources.GetObject("adminFormLogoPictureBox.Image"), System.Drawing.Image)
        Me.adminFormLogoPictureBox.Location = New System.Drawing.Point(53, 0)
        Me.adminFormLogoPictureBox.Size = New System.Drawing.Size(148, 48)
        '
        'passwordTextBox
        '
        Me.passwordTextBox.Location = New System.Drawing.Point(31, 80)
        Me.passwordTextBox.Size = New System.Drawing.Size(173, 22)
        Me.passwordTextBox.Text = ""
        '
        'adminLoginButton
        '
        Me.adminLoginButton.Location = New System.Drawing.Point(33, 104)
        Me.adminLoginButton.Size = New System.Drawing.Size(169, 21)
        Me.adminLoginButton.Text = "CONTINUE"
        '
        'baseFormUTCDateTimeLabel
        '
        Me.baseFormUTCDateTimeLabel.Location = New System.Drawing.Point(31, 152)
        Me.baseFormUTCDateTimeLabel.Size = New System.Drawing.Size(193, 16)
        Me.baseFormUTCDateTimeLabel.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'Label24
        '
        Me.Label24.Location = New System.Drawing.Point(8, 48)
        Me.Label24.Size = New System.Drawing.Size(216, 32)
        Me.Label24.Text = "Enter password then tap continue or cancel to return to scan application"
        Me.Label24.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'baseFormTimer
        '
        '
        'passwordSeedLabel
        '
        Me.passwordSeedLabel.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Bold)
        Me.passwordSeedLabel.Location = New System.Drawing.Point(48, 216)
        Me.passwordSeedLabel.Size = New System.Drawing.Size(145, 14)
        Me.passwordSeedLabel.Text = "Label1"
        Me.passwordSeedLabel.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'Label1
        '
        Me.Label1.Location = New System.Drawing.Point(8, 192)
        Me.Label1.Size = New System.Drawing.Size(224, 16)
        Me.Label1.Text = "Report this String to Request Password"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'baseFormLocalDateTimeLabel
        '
        Me.baseFormLocalDateTimeLabel.Location = New System.Drawing.Point(31, 176)
        Me.baseFormLocalDateTimeLabel.Size = New System.Drawing.Size(193, 16)
        Me.baseFormLocalDateTimeLabel.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'hideMenuBarButton
        '
        Me.hideMenuBarButton.Location = New System.Drawing.Point(120, 240)
        Me.hideMenuBarButton.Size = New System.Drawing.Size(72, 24)
        Me.hideMenuBarButton.Text = "Lock"
        '
        'showMenuBarButton
        '
        Me.showMenuBarButton.Location = New System.Drawing.Point(40, 240)
        Me.showMenuBarButton.Size = New System.Drawing.Size(72, 24)
        Me.showMenuBarButton.Text = "Unlock"
        '
        'MainMenu1
        '
        Me.MainMenu1.MenuItems.Add(Me.MenuItem1)
        '
        'MenuItem1
        '
        Me.MenuItem1.Text = ""
        '
        'adminLoginForm
        '
        Me.ClientSize = New System.Drawing.Size(234, 288)
        Me.ControlBox = False
        Me.Controls.Add(Me.baseFormLocalDateTimeLabel)
        Me.Controls.Add(Me.hideMenuBarButton)
        Me.Controls.Add(Me.showMenuBarButton)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.passwordSeedLabel)
        Me.Controls.Add(Me.cancelButton)
        Me.Controls.Add(Me.adminFormLogoPictureBox)
        Me.Controls.Add(Me.passwordTextBox)
        Me.Controls.Add(Me.adminLoginButton)
        Me.Controls.Add(Me.baseFormUTCDateTimeLabel)
        Me.Controls.Add(Me.Label24)
        Me.Menu = Me.MainMenu1
        Me.Text = "Admin Login"

    End Sub

#End Region

    Dim cancelButtonClickEvent As Boolean = False

    Private Sub cancelButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cancelButton.Click

        Me.Hide()

    End Sub

    Dim exitButtonClickEvent As Boolean = False

    Private Sub adminLoginButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles adminLoginButton.Click

        Me.DialogResult = DialogResult.OK

        If Not isNonNullString(passwordTextBox.Text) Then
            passwordTextBox.Text = ""
        End If

        'If passwordTextBox.Text = "989666444222010" Then

        '    Dim changeUserDisplayForm As New ChangeUserForm

        '    If changeUserDisplayForm.ShowDialog() = DialogResult.Abort Then
        '        Me.Hide()
        '    End If

        'End If

        Dim passwordType As String = getPasswordType(passwordTextBox.Text)

        Select Case passwordType

            Case "Admin"

                AdminFormRepository.adminBaseForm.blnCompleteConfig = False
                AdminFormRepository.adminBaseForm.Show()
                setUsedPassword(passwordTextBox.Text, "Admin")

            Case "Exit"

                Me.baseFormTimer.Enabled = False
                Me.EndProgram()
                Exit Sub

            Case "DateAndTime"


                'Dim setDateAndTimeDisplayForm As New setDateAndTime
                'Me.DialogResult = setDateAndTimeDisplayForm.ShowDialog()

                'AdminFormRepository.adminDateTimeForm.Show()
                'AdminFormRepository.adminDateTimeForm.WindowState = FormWindowState.Maximized
                Dim dlg As New adminDateTimeForm
                dlg.ShowDialog()

                setUsedPassword(passwordTextBox.Text, "DateAndTime")

            Case "CompleteConfig"

                AdminFormRepository.adminBaseForm.blnCompleteConfig = True
                AdminFormRepository.adminBaseForm.Show()
                setUsedPassword(passwordTextBox.Text, "CompleteConfig")

            Case Else

                MsgBox("Invalid Administrative Password", MsgBoxStyle.Exclamation, "Invalid Password")

        End Select

        passwordTextBox.Text = ""

    End Sub

    Private Sub baseFormTimer_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles baseFormTimer.Tick
        baseFormUTCDateTimeLabel.Text = String.Format("{0:yyyy-MM-dd hh:mm:ss tt} (UTC)", DateTime.UtcNow)
        If Time.Local.IsKnown(scannerTimeZone) Then
            baseFormLocalDateTimeLabel.Text = String.Format("{0:yyyy-MM-dd hh:mm:ss tt} local", Time.Local.GetTime(scannerTimeZone))
        Else
            baseFormLocalDateTimeLabel.Text = "LOCAL TIME UNKNOWN"
        End If
    End Sub

    Private Sub showMenuBarButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles showMenuBarButton.Click
        lockDown = False
        MsgBox("Screen lockdown disabled.")
    End Sub

    Private Sub hideMenuBarButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles hideMenuBarButton.Click
        lockDown = True
        MsgBox("Screen lockdown enabled.")
    End Sub

    Public Sub loadAdminFormLogo()

        Dim adminFormLogoPath As String

        adminFormLogoPath = TagTrakConfigDirectory & "\" & userSpecRecord.userName & "AdminFormLogo.bmp"

        If File.Exists(adminFormLogoPath) Then
            adminFormLogoPictureBox.Image = New System.Drawing.Bitmap(adminFormLogoPath)
            Exit Sub
        End If

        adminFormLogoPath = TagTrakConfigDirectory & "\AdminFormLogo.bmp"

        If File.Exists(adminFormLogoPath) Then
            adminFormLogoPictureBox.Image = New System.Drawing.Bitmap(adminFormLogoPath)
            Exit Sub
        End If

    End Sub

    Private Shared Sub EndProgram()
        MailScanFormRepository.CloseAll()
        AdminFormRepository.CloseAll()
        tagTrakFormRepository.CloseAll()
        CargoScanFormRepository.CloseAll()
        BagScanFormRepository.CloseAll()
        Application.Exit()
    End Sub

    Private Sub passwordTextBox_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles passwordTextBox.GotFocus
#If deviceType <> "PC" Then
        If userSpecRecord.showKeyboardOnFocus Then Me.InputPanel1.Enabled = True
#End If
    End Sub
End Class

