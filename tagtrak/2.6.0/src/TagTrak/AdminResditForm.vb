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

Public Class adminResditForm
    Inherits System.Windows.Forms.Form

    Dim resditFileList As New ArrayList

#Region " Windows Form Designer generated code "

    Public Sub New()

        MyBase.New()

        'This call is required by the Windows Form Designer.

        InitializeComponent()

        ReloadFileList()


    End Sub

    Private Sub form_Closing(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles MyBase.Closing

    End Sub

    Protected Overloads Overrides Sub Dispose(ByVal disposing As Boolean)
        MyBase.Dispose(disposing)
    End Sub

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    Friend WithEvents uploadButton As System.Windows.Forms.Button
    Friend WithEvents editButton As System.Windows.Forms.Button
    Friend WithEvents resditFileListBox As System.Windows.Forms.ListBox
    Friend WithEvents resditFileDeleteButton As System.Windows.Forms.Button
    Friend WithEvents exitButton As System.Windows.Forms.Button
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.resditFileDeleteButton = New System.Windows.Forms.Button
        Me.uploadButton = New System.Windows.Forms.Button
        Me.editButton = New System.Windows.Forms.Button
        Me.resditFileListBox = New System.Windows.Forms.ListBox
        Me.exitButton = New System.Windows.Forms.Button
        '
        'resditFileDeleteButton
        '
        Me.resditFileDeleteButton.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold)
        Me.resditFileDeleteButton.Location = New System.Drawing.Point(152, 192)
        Me.resditFileDeleteButton.Size = New System.Drawing.Size(64, 24)
        Me.resditFileDeleteButton.Text = "Delete"
        '
        'uploadButton
        '
        Me.uploadButton.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold)
        Me.uploadButton.Location = New System.Drawing.Point(80, 192)
        Me.uploadButton.Size = New System.Drawing.Size(64, 24)
        Me.uploadButton.Text = "Upload"
        '
        'editButton
        '
        Me.editButton.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold)
        Me.editButton.Location = New System.Drawing.Point(8, 192)
        Me.editButton.Size = New System.Drawing.Size(64, 24)
        Me.editButton.Text = "Edit"
        '
        'resditFileListBox
        '
        Me.resditFileListBox.Font = New System.Drawing.Font("Courier New", 9.0!, System.Drawing.FontStyle.Regular)
        Me.resditFileListBox.Location = New System.Drawing.Point(5, 16)
        Me.resditFileListBox.Size = New System.Drawing.Size(224, 152)
        '
        'exitButton
        '
        Me.exitButton.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold)
        Me.exitButton.Location = New System.Drawing.Point(80, 232)
        Me.exitButton.Size = New System.Drawing.Size(64, 24)
        Me.exitButton.Text = "Exit"
        '
        'adminResditForm
        '
        Me.ClientSize = New System.Drawing.Size(234, 328)
        Me.ControlBox = False
        Me.Controls.Add(Me.exitButton)
        Me.Controls.Add(Me.resditFileDeleteButton)
        Me.Controls.Add(Me.uploadButton)
        Me.Controls.Add(Me.editButton)
        Me.Controls.Add(Me.resditFileListBox)
        Me.Text = "Resdit File Maintenance"

    End Sub

#End Region

    Private Sub editButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles editButton.Click

        Dim currentRecord As Integer = resditFileListBox.SelectedIndex

        If currentRecord < 0 Or currentRecord >= resditFileList.Count Then
            MsgBox("A valid resdit file must be selected.", MsgBoxStyle.Exclamation, "No Resdit File Selected")
            Exit Sub
        End If

        Dim resditFileSpecRecord As resditFileSpecRecordClass = resditFileList.Item(currentRecord)

        Dim filePath = resditFileSpecRecord.fileName

        Dim dispFrm As New adminResditFileDisplayForm
        dispFrm.init(filePath)
        dispFrm.ShowDialog()

    End Sub

    Private Sub uploadButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles uploadButton.Click

        Dim currentRecord As Integer = resditFileListBox.SelectedIndex

        If currentRecord < 0 Or currentRecord >= resditFileList.Count Then
            MsgBox("A valid resdit file must be selected.", MsgBoxStyle.Exclamation, "No Resdit File Selected")
            Exit Sub
        End If

        Dim resditFileSpecRecord As resditFileSpecRecordClass = resditFileList.Item(currentRecord)

        Dim filePath = resditFileSpecRecord.fileName

        If Not isNonNullString(filePath) Then Exit Sub

        Dim uploadFrm As New adminUploadResditFileForm
        uploadFrm.init(filePath)
        uploadFrm.ShowDialog()
    End Sub

    Private Sub resditFileDeleteButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles resditFileDeleteButton.Click

        Dim currentRecord As Integer = resditFileListBox.SelectedIndex
        Dim resditFileListCount As Integer = resditFileList.Count

        If currentRecord < 0 Or currentRecord >= resditFileListCount Then
            MsgBox("A valid resdit file must be selected.", MsgBoxStyle.Exclamation, "No Resdit File Selected")
            Exit Sub
        End If

        Dim resditFileSpecRecord As resditFileSpecRecordClass = resditFileList.Item(currentRecord)

        Dim filePath = resditFileSpecRecord.fileName

        If Not isNonNullString(filePath) Then Exit Sub

        If Not File.Exists(filePath) Then
            MsgBox("System error: attempt to delete non-existing file.", MsgBoxStyle.Exclamation, "No Resdit File Selected")
            Exit Sub
        End If

        resditFileList.RemoveAt(currentRecord)

        resditFileListBox.Items.RemoveAt(currentRecord)

        deleteLocalFile(filePath)

        If resditFileList.Count <= 0 Then Exit Sub

        If currentRecord >= resditFileList.Count Then
            currentRecord -= 1
        End If

        resditFileListBox.SelectedIndex = currentRecord

    End Sub

    Private Sub exitButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles exitButton.Click
        Me.Hide()
    End Sub

    Public Sub ReloadFileList()
        resditFileList.Clear()

        Dim resditFileSpecRecord As resditFileSpecRecordClass
        Dim filePath As String

        If File.Exists(scanDataPrimaryFilePath) Then

            resditFileSpecRecord = New resditFileSpecRecordClass(scanDataPrimaryFilePath)

            If Not resditFileSpecRecord.fileName Is Nothing Then
                resditFileList.Add(resditFileSpecRecord)
            End If

        End If

        Dim resditBackupFileList() As String

        Try

            resditBackupFileList = Directory.GetFiles(TagTrakBackupDirectory, userSpecRecord.userName & "MailDataBkup*.txt")

        Catch ex As Exception

            MsgBox("Unable to get backup resdit file list")

        End Try

        Dim fileName As String

        Dim i As Integer

        i = resditBackupFileList.Length - 1

        While i >= 0

            resditFileSpecRecord = New resditFileSpecRecordClass(resditBackupFileList(i))

            If Not resditFileSpecRecord.fileName Is Nothing Then
                resditFileList.Add(resditFileSpecRecord)
            End If

            i -= 1

        End While

        Dim myComparer = New myResditRecordReverserClass

        resditFileList.Sort(myComparer)

        resditFileListBox.Items.Clear()

        For Each resditFileSpecRecord In resditFileList
            resditFileListBox.Items.Add(resditFileSpecRecord.ToString)
        Next
    End Sub

End Class



