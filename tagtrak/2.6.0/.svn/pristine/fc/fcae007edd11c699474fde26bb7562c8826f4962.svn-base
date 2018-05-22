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

Public Class adminFtpClientForm
    Inherits System.Windows.Forms.Form

#Region " Windows Form Designer generated code "

    Public Sub New()

        MyBase.New()

        'This call is required by the Windows Form Designer.
        InitializeComponent()

        Me.DialogResult = DialogResult.OK

    End Sub


    Private Sub form_Closing(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles MyBase.Closing

    End Sub

    Protected Overloads Overrides Sub Dispose(ByVal disposing As Boolean)
        MyBase.Dispose(disposing)
    End Sub

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    Friend WithEvents putFileButton As System.Windows.Forms.Button
    Friend WithEvents getFileButton As System.Windows.Forms.Button
    Friend WithEvents remoteFileNameTextBox As System.Windows.Forms.TextBox
    Friend WithEvents Label19 As System.Windows.Forms.Label
    Friend WithEvents remoteFilePathTextBox As System.Windows.Forms.TextBox
    Friend WithEvents Label20 As System.Windows.Forms.Label
    Friend WithEvents localFileNameTextBox As System.Windows.Forms.TextBox
    Friend WithEvents Label18 As System.Windows.Forms.Label
    Friend WithEvents localFilePathTextBox As System.Windows.Forms.TextBox
    Friend WithEvents Label16 As System.Windows.Forms.Label
    Friend WithEvents exitButton As System.Windows.Forms.Button
    Friend WithEvents MainMenu1 As System.Windows.Forms.MainMenu
#If deviceType <> "PC" Then
    Friend WithEvents InputPanel1 As Microsoft.WindowsCE.Forms.InputPanel
#End If
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.putFileButton = New System.Windows.Forms.Button
        Me.getFileButton = New System.Windows.Forms.Button
        Me.remoteFileNameTextBox = New System.Windows.Forms.TextBox
        Me.Label19 = New System.Windows.Forms.Label
        Me.remoteFilePathTextBox = New System.Windows.Forms.TextBox
        Me.Label20 = New System.Windows.Forms.Label
        Me.localFileNameTextBox = New System.Windows.Forms.TextBox
        Me.Label18 = New System.Windows.Forms.Label
        Me.localFilePathTextBox = New System.Windows.Forms.TextBox
        Me.Label16 = New System.Windows.Forms.Label
        Me.exitButton = New System.Windows.Forms.Button
        Me.MainMenu1 = New System.Windows.Forms.MainMenu
#If devicetype <> "PC" Then
    Me.InputPanel1 = New Microsoft.WindowsCE.Forms.InputPanel
#End If
        '
        'putFileButton
        '
        Me.putFileButton.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold)
        Me.putFileButton.Location = New System.Drawing.Point(120, 200)
        Me.putFileButton.Size = New System.Drawing.Size(80, 20)
        Me.putFileButton.Text = "Put File"
        '
        'getFileButton
        '
        Me.getFileButton.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold)
        Me.getFileButton.Location = New System.Drawing.Point(24, 200)
        Me.getFileButton.Size = New System.Drawing.Size(80, 20)
        Me.getFileButton.Text = "Get File"
        '
        'remoteFileNameTextBox
        '
        Me.remoteFileNameTextBox.Location = New System.Drawing.Point(8, 160)
        Me.remoteFileNameTextBox.Size = New System.Drawing.Size(215, 22)
        Me.remoteFileNameTextBox.Text = ""
        '
        'Label19
        '
        Me.Label19.Location = New System.Drawing.Point(8, 144)
        Me.Label19.Size = New System.Drawing.Size(116, 16)
        Me.Label19.Text = "Remote File Name"
        '
        'remoteFilePathTextBox
        '
        Me.remoteFilePathTextBox.Location = New System.Drawing.Point(8, 120)
        Me.remoteFilePathTextBox.Size = New System.Drawing.Size(215, 22)
        Me.remoteFilePathTextBox.Text = ""
        '
        'Label20
        '
        Me.Label20.Location = New System.Drawing.Point(8, 104)
        Me.Label20.Size = New System.Drawing.Size(136, 16)
        Me.Label20.Text = "Remote Directory Path"
        '
        'localFileNameTextBox
        '
        Me.localFileNameTextBox.Location = New System.Drawing.Point(8, 80)
        Me.localFileNameTextBox.Size = New System.Drawing.Size(215, 22)
        Me.localFileNameTextBox.Text = ""
        '
        'Label18
        '
        Me.Label18.Location = New System.Drawing.Point(8, 56)
        Me.Label18.Size = New System.Drawing.Size(116, 16)
        Me.Label18.Text = "Local File Name"
        '
        'localFilePathTextBox
        '
        Me.localFilePathTextBox.Location = New System.Drawing.Point(8, 32)
        Me.localFilePathTextBox.Size = New System.Drawing.Size(215, 22)
        Me.localFilePathTextBox.Text = ""
        '
        'Label16
        '
        Me.Label16.Location = New System.Drawing.Point(8, 16)
        Me.Label16.Size = New System.Drawing.Size(116, 16)
        Me.Label16.Text = "Local Directory Path"
        '
        'exitButton
        '
        Me.exitButton.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold)
        Me.exitButton.Location = New System.Drawing.Point(72, 224)
        Me.exitButton.Size = New System.Drawing.Size(80, 20)
        Me.exitButton.Text = "Exit"
        '
        'adminFtpClientForm
        '
        Me.ClientSize = New System.Drawing.Size(234, 328)
        Me.ControlBox = False
        Me.Controls.Add(Me.exitButton)
        Me.Controls.Add(Me.putFileButton)
        Me.Controls.Add(Me.getFileButton)
        Me.Controls.Add(Me.remoteFileNameTextBox)
        Me.Controls.Add(Me.Label19)
        Me.Controls.Add(Me.remoteFilePathTextBox)
        Me.Controls.Add(Me.Label20)
        Me.Controls.Add(Me.localFileNameTextBox)
        Me.Controls.Add(Me.Label18)
        Me.Controls.Add(Me.localFilePathTextBox)
        Me.Controls.Add(Me.Label16)
        Me.Menu = Me.MainMenu1
        Me.Text = "Upload / Download Files"

    End Sub

#End Region


    Private Sub getFileButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles getFileButton.Click

        Dim localFileName As String
        Dim localFilePath As String

        Dim remoteFileName As String
        Dim remoteFilePath As String

        If Not isNonNullString(Trim(remoteFileNameTextBox.Text)) Then

            MsgBox("The name of the file on the server must be specified.", MsgBoxStyle.Exclamation, "Missing File Name")
            Exit Sub

        End If

        remoteFileName = Trim(remoteFileNameTextBox.Text)

        If isNonNullString(Trim(localFileNameTextBox.Text)) Then
            localFileName = Trim(localFileNameTextBox.Text)
        Else
            localFileName = remoteFileName
        End If

        If isNonNullString(Trim(remoteFilePathTextBox.Text)) Then
            remoteFilePath = Trim(remoteFilePathTextBox.Text)
        Else
            remoteFilePath = "/"
        End If

        If isNonNullString(Trim(localFilePathTextBox.Text)) Then
            localFilePath = Trim(localFilePathTextBox.Text)
        Else
            localFilePath = backSlash
        End If

        If remoteFilePath.StartsWith(backSlash) Then
            remoteFilePath = "/" & Substring(remoteFilePath, 1)
        ElseIf Not remoteFilePath.StartsWith("/") Then
            remoteFilePath = "/" & remoteFilePath
        End If

        If localFilePath.StartsWith("/") Then
            localFilePath = backSlash & Substring(localFilePath, 1)
        ElseIf Not localFilePath.StartsWith(backSlash) Then
            localFilePath = backSlash & localFilePath
        End If

        AdminFormRepository.adminDownloadFileForm.init(remoteFileName, remoteFilePath, localFileName, localFilePath)
        AdminFormRepository.adminDownloadFileForm.Show()

    End Sub

    Private Sub putFileButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles putFileButton.Click

        Dim localFileName As String
        Dim localFilePath As String

        Dim remoteFileName As String
        Dim remoteFilePath As String

        If Not isNonNullString(Trim(localFileNameTextBox.Text)) Then

            MsgBox("The name of the file on the device must be specified.", MsgBoxStyle.Exclamation, "Missing File Name")
            Exit Sub

        End If

        localFileName = Trim(localFileNameTextBox.Text)

        If isNonNullString(Trim(remoteFileNameTextBox.Text)) Then
            localFileName = Trim(remoteFileNameTextBox.Text)
        Else
            remoteFileName = localFileName
        End If

        If isNonNullString(Trim(remoteFilePathTextBox.Text)) Then
            remoteFilePath = Trim(remoteFilePathTextBox.Text)
        Else
            remoteFilePath = "/"
        End If

        If isNonNullString(Trim(localFilePathTextBox.Text)) Then
            localFilePath = Trim(localFilePathTextBox.Text)
        Else
            localFilePath = backSlash
        End If

        If remoteFilePath.StartsWith(backSlash) Then
            remoteFilePath = "/" & Substring(remoteFilePath, 1)
        ElseIf Not remoteFilePath.StartsWith("/") Then
            remoteFilePath = "/" & remoteFilePath
        End If

        If localFilePath.StartsWith("/") Then
            localFilePath = backSlash & Substring(localFilePath, 1)
        ElseIf Not localFilePath.StartsWith(backSlash) Then
            localFilePath = backSlash & localFilePath
        End If

        AdminFormRepository.adminUploadFileForm.initAdminUploadFileForm(localFileName, localFilePath, remoteFileName, remoteFilePath)
        AdminFormRepository.adminUploadFileForm.Show()

    End Sub

    Private Sub exitButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles exitButton.Click
        Me.Hide()
    End Sub

End Class

