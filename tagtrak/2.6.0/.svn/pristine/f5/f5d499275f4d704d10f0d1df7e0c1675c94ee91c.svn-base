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

Public Class setDateAndTimeLoginForm
    Inherits System.Windows.Forms.Form


    Dim passwordUsed As Boolean = False

#Region " Windows Form Designer generated code "

    Public Sub New()

        MyBase.New()

        'This call is required by the Windows Form Designer.
        InitializeComponent()

        'passwordTextBox.PasswordChar = Chr(149)

        'Add any initialization after the InitializeComponent() call

    End Sub


    Protected Overloads Overrides Sub Dispose(ByVal disposing As Boolean)
        MyBase.Dispose(disposing)
    End Sub

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents passwordTextBox As System.Windows.Forms.TextBox
    Friend WithEvents loginButton As System.Windows.Forms.Button
    Friend WithEvents cancelButton As System.Windows.Forms.Button
    Friend WithEvents passwordKernelLabel As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents MainMenu1 As System.Windows.Forms.MainMenu
#If deviceType <> "PC" Then
    Friend WithEvents InputPanel1 As Microsoft.WindowsCE.Forms.InputPanel
#End If
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.passwordTextBox = New System.Windows.Forms.TextBox
        Me.Label2 = New System.Windows.Forms.Label
        Me.loginButton = New System.Windows.Forms.Button
        Me.cancelButton = New System.Windows.Forms.Button
        Me.passwordKernelLabel = New System.Windows.Forms.Label
        Me.Label3 = New System.Windows.Forms.Label
        Me.MainMenu1 = New System.Windows.Forms.MainMenu
#If devicetype <> "PC" Then
        Me.InputPanel1 = New Microsoft.WindowsCE.Forms.InputPanel
#End If
        '
        'passwordTextBox
        '
        Me.passwordTextBox.Location = New System.Drawing.Point(96, 24)
        Me.passwordTextBox.Size = New System.Drawing.Size(128, 22)
        Me.passwordTextBox.Text = ""
        '
        'Label2
        '
        Me.Label2.Location = New System.Drawing.Point(32, 24)
        Me.Label2.Size = New System.Drawing.Size(64, 17)
        Me.Label2.Text = "Password:"
        '
        'loginButton
        '
        Me.loginButton.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold)
        Me.loginButton.Location = New System.Drawing.Point(48, 72)
        Me.loginButton.Size = New System.Drawing.Size(64, 24)
        Me.loginButton.Text = "Login"
        '
        'cancelButton
        '
        Me.cancelButton.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold)
        Me.cancelButton.Location = New System.Drawing.Point(120, 72)
        Me.cancelButton.Size = New System.Drawing.Size(64, 24)
        Me.cancelButton.Text = "Cancel"
        '
        'passwordKernelLabel
        '
        Me.passwordKernelLabel.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Bold)
        Me.passwordKernelLabel.Location = New System.Drawing.Point(39, 160)
        Me.passwordKernelLabel.Size = New System.Drawing.Size(156, 20)
        Me.passwordKernelLabel.Text = "Label3"
        Me.passwordKernelLabel.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'Label3
        '
        Me.Label3.Location = New System.Drawing.Point(12, 112)
        Me.Label3.Size = New System.Drawing.Size(211, 30)
        Me.Label3.Text = "Report The Following String When Requesting Password"
        Me.Label3.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'setDateAndTimeLoginForm
        '
        Me.ClientSize = New System.Drawing.Size(234, 288)
        Me.ControlBox = False
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.passwordKernelLabel)
        Me.Controls.Add(Me.cancelButton)
        Me.Controls.Add(Me.loginButton)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.passwordTextBox)
        Me.Menu = Me.MainMenu1
        Me.Text = "Login To Set Date And Time"

    End Sub

#End Region

    Private Sub formOnLoad(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        passwordKernelLabel.Text = enterPasswordForm()
    End Sub

    Private Sub formClosing(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles MyBase.Closing
        exitPasswordForm()
    End Sub

    Private Sub loginButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles loginButton.Click

        If isValidDateAndTimePassword(passwordTextBox.Text) Then

            'Dim dateAndTimeDisplayForm As New setDateAndTime
            'dateAndTimeDisplayForm.ShowDialog()

            'AdminFormRepository.adminDateTimeForm.Show()
            'AdminFormRepository.adminDateTimeForm.WindowState = FormWindowState.Maximized

            Dim dlg As New adminDateTimeForm
            dlg.ShowDialog()

            setUsedPassword(passwordTextBox.Text, "DateAndTime")

            passwordTextBox.Text = ""

            Me.Close()
        Else
            MsgBox("Invalid Password For Access To Date And Time Functionality", MsgBoxStyle.Exclamation, "Invalid Password")
        End If

    End Sub

    Private Sub cancelButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cancelButton.Click
        Me.Close()
    End Sub

    Private Sub passwordTextBox_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles passwordTextBox.GotFocus
#If deviceType <> "PC" Then
        If userSpecRecord.showKeyboardOnFocus Then Me.InputPanel1.Enabled = True
#End If
    End Sub
End Class
