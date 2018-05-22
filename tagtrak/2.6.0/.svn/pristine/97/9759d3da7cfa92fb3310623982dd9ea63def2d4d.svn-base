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

Public Class adminLoggingForm
    Inherits System.Windows.Forms.Form

#Region " Windows Form Designer generated code "

    Public Sub New()

        MyBase.New()

        'This call is required by the Windows Form Designer.
        InitializeComponent()

        diagnosticLevelTextBox.Text = diagnosticLevel

        enableLoggingCheckBox.Checked = diagnosticLevel > 0

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
    Friend WithEvents loadLogButton As System.Windows.Forms.Button
    Friend WithEvents Label21 As System.Windows.Forms.Label
    Friend WithEvents enableLoggingCheckBox As System.Windows.Forms.CheckBox
    Friend WithEvents logClearButton As System.Windows.Forms.Button
    Friend WithEvents logUploadButton As System.Windows.Forms.Button
    Friend WithEvents logFileTextBox As System.Windows.Forms.TextBox
    Friend WithEvents diagnosticLevelTextBox As System.Windows.Forms.TextBox
    Friend WithEvents exitButton As System.Windows.Forms.Button
    Friend WithEvents MainMenu1 As System.Windows.Forms.MainMenu
#If deviceType <> "PC" Then
    Friend WithEvents InputPanel1 As Microsoft.WindowsCE.Forms.InputPanel
#End If
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.loadLogButton = New System.Windows.Forms.Button
        Me.Label21 = New System.Windows.Forms.Label
        Me.enableLoggingCheckBox = New System.Windows.Forms.CheckBox
        Me.logClearButton = New System.Windows.Forms.Button
        Me.logUploadButton = New System.Windows.Forms.Button
        Me.logFileTextBox = New System.Windows.Forms.TextBox
        Me.diagnosticLevelTextBox = New System.Windows.Forms.TextBox
        Me.exitButton = New System.Windows.Forms.Button
        Me.MainMenu1 = New System.Windows.Forms.MainMenu
#If devicetype <> "PC" Then
   Me.InputPanel1 = New Microsoft.WindowsCE.Forms.InputPanel
#End If
        '
        'loadLogButton
        '
        Me.loadLogButton.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold)
        Me.loadLogButton.Location = New System.Drawing.Point(32, 192)
        Me.loadLogButton.Size = New System.Drawing.Size(75, 24)
        Me.loadLogButton.Text = "Load Log"
        '
        'Label21
        '
        Me.Label21.Location = New System.Drawing.Point(174, 160)
        Me.Label21.Size = New System.Drawing.Size(69, 30)
        Me.Label21.Text = "Diagnostic Level"
        '
        'enableLoggingCheckBox
        '
        Me.enableLoggingCheckBox.Location = New System.Drawing.Point(8, 160)
        Me.enableLoggingCheckBox.Size = New System.Drawing.Size(124, 22)
        Me.enableLoggingCheckBox.Text = "Logging Enabled"
        '
        'logClearButton
        '
        Me.logClearButton.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold)
        Me.logClearButton.Location = New System.Drawing.Point(32, 224)
        Me.logClearButton.Size = New System.Drawing.Size(75, 24)
        Me.logClearButton.Text = "Clear"
        '
        'logUploadButton
        '
        Me.logUploadButton.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold)
        Me.logUploadButton.Location = New System.Drawing.Point(112, 192)
        Me.logUploadButton.Size = New System.Drawing.Size(75, 24)
        Me.logUploadButton.Text = "Upload"
        '
        'logFileTextBox
        '
        Me.logFileTextBox.Font = New System.Drawing.Font("Courier New", 8.25!, System.Drawing.FontStyle.Regular)
        Me.logFileTextBox.Location = New System.Drawing.Point(12, 16)
        Me.logFileTextBox.Multiline = True
        Me.logFileTextBox.ScrollBars = System.Windows.Forms.ScrollBars.Both
        Me.logFileTextBox.Size = New System.Drawing.Size(211, 136)
        Me.logFileTextBox.Text = ""
        Me.logFileTextBox.WordWrap = False
        '
        'diagnosticLevelTextBox
        '
        Me.diagnosticLevelTextBox.Location = New System.Drawing.Point(139, 160)
        Me.diagnosticLevelTextBox.Size = New System.Drawing.Size(22, 22)
        Me.diagnosticLevelTextBox.Text = ""
        '
        'exitButton
        '
        Me.exitButton.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold)
        Me.exitButton.Location = New System.Drawing.Point(112, 224)
        Me.exitButton.Size = New System.Drawing.Size(75, 24)
        Me.exitButton.Text = "Exit"
        '
        'adminLoggingForm
        '
        Me.ClientSize = New System.Drawing.Size(234, 288)
        Me.ControlBox = False
        Me.Controls.Add(Me.exitButton)
        Me.Controls.Add(Me.diagnosticLevelTextBox)
        Me.Controls.Add(Me.loadLogButton)
        Me.Controls.Add(Me.Label21)
        Me.Controls.Add(Me.enableLoggingCheckBox)
        Me.Controls.Add(Me.logClearButton)
        Me.Controls.Add(Me.logUploadButton)
        Me.Controls.Add(Me.logFileTextBox)
        Me.Menu = Me.MainMenu1
        Me.Text = "Log File Maintenance"

    End Sub

#End Region
    Private Sub logClearButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        logClearLogFile()
        logFileTextBox.Text = "*** Log File Is Empty ***"
    End Sub

    Private Sub enableLoggingCheckBox_CheckStateChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)

        If enableLoggingCheckBox.Checked Then
            diagnosticLevel = diagnosticLevelTextBox.Text
            'logSetupLogging()
        Else
            diagnosticLevel = 0
        End If

    End Sub

    Private Sub diagnosticLevelTextBox_LostFocus(ByVal sender As System.Object, ByVal e As System.EventArgs)

        Dim newDiagnosticLevelString As String = Trim(diagnosticLevelTextBox.Text)

        If Not Util.IsInteger(newDiagnosticLevelString) Then
            MsgBox("The Diagnostic Level must be an integral value between 0 and 5", MsgBoxStyle.Exclamation, "Invalid Diagnostic Level")
            diagnosticLevelTextBox.Text = diagnosticLevel
            Exit Sub
        End If

        Dim newDiagnosticLevel As Integer = newDiagnosticLevelString

        If newDiagnosticLevel < 0 Or newDiagnosticLevel > 5 Then
            MsgBox("The Diagnostic Level must be an integral value between 0 and 5", MsgBoxStyle.Exclamation, "Invalid Diagnostic Level")
            diagnosticLevelTextBox.Text = diagnosticLevel
            Exit Sub
        End If

        diagnosticLevel = newDiagnosticLevel

        If diagnosticLevel <= 0 Then
            Me.enableLoggingCheckBox.Checked = False
        Else
            Me.enableLoggingCheckBox.Checked = True
            logSetupLogging()
        End If

        diagnosticLevelTextBox.Text = newDiagnosticLevelString

    End Sub


    Private Sub loadLogButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)

        Dim result As String
        Dim logFileRecordList() As String

        result = logBuildLogRecordArray(logFileRecordList)

        If result <> "OK" Then
            MsgBox("Unable to build log file record list: " & result)
            Exit Sub
        End If

        If logFileRecordList Is Nothing Then
            logFileTextBox.Text = "*** Log File Is Empty ***"
        Else
            logFileTextBox.Text = Util.convertStringArrayToStringBuffer(logFileRecordList)
        End If

    End Sub

    Private Sub exitButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles exitButton.Click
        Me.Hide()
    End Sub

    Private Sub logUploadButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles logUploadButton.Click

        Dim yy As String = CStr(serverDateAndTimeUTC.Year Mod 100).PadLeft(2, "0")
        Dim mm As String = CStr(serverDateAndTimeUTC.Month).PadLeft(2, "0")
        Dim dd As String = CStr(serverDateAndTimeUTC.Day).PadLeft(2, "0")
        Dim hh As String = CStr(serverDateAndTimeUTC.Hour).PadLeft(2, "0")
        Dim mn As String = CStr(serverDateAndTimeUTC.Minute).PadLeft(2, "0")

        Dim tempLogFilePath As String = TagTrakTempDirectory & "\TempLogFile.txt"
        Dim remoteFilePath As String = "/LogFile" & userSpecRecord.carrierCode.ToUpper & yy & mm & dd & "." & hh & mn & ".txt"

        logCreateLogFileSummary(tempLogFilePath)

        Dim uploadLogFileDisplayForm As New uploadLogFileForm(tempLogFilePath, remoteFilePath)

        uploadLogFileDisplayForm.ShowDialog()

        deleteLocalFile(tempLogFilePath)

    End Sub

  
End Class


