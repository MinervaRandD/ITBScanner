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

Public Class adminPasswordForm
    Inherits System.Windows.Forms.Form

#Region " Windows Form Designer generated code "

    Public Sub New()

        MyBase.New()

        'This call is required by the Windows Form Designer.
        InitializeComponent()

    End Sub

    Private Sub form_Closing(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles MyBase.Closing

    End Sub

    Protected Overloads Overrides Sub Dispose(ByVal disposing As Boolean)
        MyBase.Dispose(disposing)
    End Sub

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    Friend WithEvents Label15 As System.Windows.Forms.Label
    Friend WithEvents passwordKernelTextBox As System.Windows.Forms.TextBox
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents locationChangePasswordLabel As System.Windows.Forms.Label
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents Label14 As System.Windows.Forms.Label
    Friend WithEvents exitToWindowsPasswordLabel As System.Windows.Forms.Label
    Friend WithEvents dateAndTimePasswordLabel As System.Windows.Forms.Label
    Friend WithEvents adminPasswordLabel As System.Windows.Forms.Label
    Friend WithEvents generatePasswordsButton As System.Windows.Forms.Button
    Friend WithEvents exitButton As System.Windows.Forms.Button
    Friend WithEvents MainMenu1 As System.Windows.Forms.MainMenu
#If deviceType <> "PC" Then
    Friend WithEvents InputPanel1 As Microsoft.WindowsCE.Forms.InputPanel
#End If
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.generatePasswordsButton = New System.Windows.Forms.Button
        Me.Label15 = New System.Windows.Forms.Label
        Me.passwordKernelTextBox = New System.Windows.Forms.TextBox
        Me.Label11 = New System.Windows.Forms.Label
        Me.locationChangePasswordLabel = New System.Windows.Forms.Label
        Me.Label12 = New System.Windows.Forms.Label
        Me.Label13 = New System.Windows.Forms.Label
        Me.Label14 = New System.Windows.Forms.Label
        Me.exitToWindowsPasswordLabel = New System.Windows.Forms.Label
        Me.dateAndTimePasswordLabel = New System.Windows.Forms.Label
        Me.adminPasswordLabel = New System.Windows.Forms.Label
        Me.exitButton = New System.Windows.Forms.Button
        Me.MainMenu1 = New System.Windows.Forms.MainMenu
#If devicetype <> "PC" Then
        Me.InputPanel1 = New Microsoft.WindowsCE.Forms.InputPanel
#End If
        '
        'generatePasswordsButton
        '
        Me.generatePasswordsButton.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold)
        Me.generatePasswordsButton.Location = New System.Drawing.Point(32, 56)
        Me.generatePasswordsButton.Size = New System.Drawing.Size(173, 26)
        Me.generatePasswordsButton.Text = "Generate Passwords"
        '
        'Label15
        '
        Me.Label15.Location = New System.Drawing.Point(8, 24)
        Me.Label15.Size = New System.Drawing.Size(105, 23)
        Me.Label15.Text = "Enter Code String:"
        '
        'passwordKernelTextBox
        '
        Me.passwordKernelTextBox.Location = New System.Drawing.Point(128, 24)
        Me.passwordKernelTextBox.Size = New System.Drawing.Size(103, 22)
        Me.passwordKernelTextBox.Text = ""
        '
        'Label11
        '
        Me.Label11.Location = New System.Drawing.Point(8, 152)
        Me.Label11.Size = New System.Drawing.Size(98, 29)
        Me.Label11.Text = "Location Change Password"
        '
        'locationChangePasswordLabel
        '
        Me.locationChangePasswordLabel.Location = New System.Drawing.Point(128, 160)
        Me.locationChangePasswordLabel.Size = New System.Drawing.Size(101, 16)
        '
        'Label12
        '
        Me.Label12.Location = New System.Drawing.Point(8, 184)
        Me.Label12.Size = New System.Drawing.Size(111, 30)
        Me.Label12.Text = "Exit To Windows Password"
        '
        'Label13
        '
        Me.Label13.Location = New System.Drawing.Point(8, 120)
        Me.Label13.Size = New System.Drawing.Size(98, 29)
        Me.Label13.Text = "Date And Time Password"
        '
        'Label14
        '
        Me.Label14.Location = New System.Drawing.Point(8, 96)
        Me.Label14.Size = New System.Drawing.Size(110, 16)
        Me.Label14.Text = "Admin Password"
        '
        'exitToWindowsPasswordLabel
        '
        Me.exitToWindowsPasswordLabel.Location = New System.Drawing.Point(128, 192)
        Me.exitToWindowsPasswordLabel.Size = New System.Drawing.Size(101, 16)
        '
        'dateAndTimePasswordLabel
        '
        Me.dateAndTimePasswordLabel.Location = New System.Drawing.Point(128, 128)
        Me.dateAndTimePasswordLabel.Size = New System.Drawing.Size(101, 16)
        '
        'adminPasswordLabel
        '
        Me.adminPasswordLabel.Location = New System.Drawing.Point(128, 96)
        Me.adminPasswordLabel.Size = New System.Drawing.Size(101, 16)
        '
        'exitButton
        '
        Me.exitButton.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold)
        Me.exitButton.Location = New System.Drawing.Point(80, 232)
        Me.exitButton.Size = New System.Drawing.Size(80, 20)
        Me.exitButton.Text = "Exit"
        '
        'adminPasswordForm
        '
        Me.ClientSize = New System.Drawing.Size(234, 288)
        Me.ControlBox = False
        Me.Controls.Add(Me.exitButton)
        Me.Controls.Add(Me.generatePasswordsButton)
        Me.Controls.Add(Me.Label15)
        Me.Controls.Add(Me.passwordKernelTextBox)
        Me.Controls.Add(Me.Label11)
        Me.Controls.Add(Me.locationChangePasswordLabel)
        Me.Controls.Add(Me.Label12)
        Me.Controls.Add(Me.Label13)
        Me.Controls.Add(Me.Label14)
        Me.Controls.Add(Me.exitToWindowsPasswordLabel)
        Me.Controls.Add(Me.dateAndTimePasswordLabel)
        Me.Controls.Add(Me.adminPasswordLabel)
        Me.Menu = Me.MainMenu1
        Me.Text = "Generate Passwords"

    End Sub

#End Region

    Private Sub generatePasswordsButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles generatePasswordsButton.Click

        If isNonNullString(passwordKernelTextBox.Text) Then

            passwordKernelTextBox.Text = Trim(passwordKernelTextBox.Text)

            If Length(passwordKernelTextBox.Text) <> 8 Then
                MsgBox("Invalid Password Kernel: Must be a non-null string of exactly 8 characters.", MsgBoxStyle.Exclamation, "Invalid Password Kernel")
                Exit Sub
            End If

        Else

            MsgBox("Invalid Password Kernel: Must be a non-null string of exactly 8 characters.", MsgBoxStyle.Exclamation, "Invalid Password Kernel")
            Exit Sub

        End If

        adminPasswordLabel.Text = genAdminPassword(passwordKernelTextBox.Text)
        dateAndTimePasswordLabel.Text = genDateAndTimePassword(passwordKernelTextBox.Text)
        exitToWindowsPasswordLabel.Text = genExitPassword(passwordKernelTextBox.Text)
        locationChangePasswordLabel.Text = genLocationChangePassword(passwordKernelTextBox.Text)

        Application.DoEvents()

    End Sub

    Private Sub exitButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles exitButton.Click
        Me.Hide()
    End Sub

End Class


