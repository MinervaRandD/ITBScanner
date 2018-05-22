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

Public Class adminDateTimeForm

    Inherits System.Windows.Forms.Form

#Region " Windows Form Designer generated code "

    Public Sub New()

        MyBase.New()

        'This call is required by the Windows Form Designer.
        InitializeComponent()

        Dim i As Integer

        Dim currentDateAndTime As DateTime

        If Time.Local.IsKnown(scannerTimeZone) Then
            currentDateAndTime = Time.Local.GetTime(scannerTimeZone)
            TextBoxOffset.Text = scannerTimeZone.OffsetInfo.OffsetUTC.ToString
            exitButton.Enabled = True
            Me.localTimeRadioButton.Checked = True
        Else
            currentDateAndTime = Date.Now
            TextBoxOffset.Text = Time.TimeZone.GetOSUTCOffset().ToString
            exitButton.Enabled = False
            Me.localTimeRadioButton.Checked = True
        End If

        Me.dayTextBox.Text = currentDateAndTime.Day
        Me.monthTextBox.Text = currentDateAndTime.Month
        Me.yearTextBox.Text = currentDateAndTime.Year

        Dim hour As Integer = currentDateAndTime.Hour

        If hour >= 12 Then
            Me.PmRadioButton.Checked = True
            Me.AmRadioButton.Checked = False
        Else
            Me.PmRadioButton.Checked = False
            Me.AmRadioButton.Checked = True
        End If

        If hour = 0 Then
            hour = 12
        ElseIf hour > 12 Then
            hour -= 12
        End If

        Me.hourTextBox.Text = hour
        Me.minuteTextBox.Text = currentDateAndTime.Minute

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
    Friend WithEvents baseFormTimer As System.Windows.Forms.Timer
    Friend WithEvents exitButton As System.Windows.Forms.Button
    Friend WithEvents Panel3 As System.Windows.Forms.Panel
    Friend WithEvents PmRadioButton As System.Windows.Forms.RadioButton
    Friend WithEvents AmRadioButton As System.Windows.Forms.RadioButton
    Friend WithEvents Panel2 As System.Windows.Forms.Panel
    Friend WithEvents GmtTimeRadioButton As System.Windows.Forms.RadioButton
    Friend WithEvents localTimeRadioButton As System.Windows.Forms.RadioButton
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents Label23 As System.Windows.Forms.Label
    Friend WithEvents minuteTextBox As System.Windows.Forms.TextBox
    Friend WithEvents hourTextBox As System.Windows.Forms.TextBox
    Friend WithEvents Label24 As System.Windows.Forms.Label
    Friend WithEvents Label25 As System.Windows.Forms.Label
    Friend WithEvents Label26 As System.Windows.Forms.Label
    Friend WithEvents yearTextBox As System.Windows.Forms.TextBox
    Friend WithEvents monthTextBox As System.Windows.Forms.TextBox
    Friend WithEvents dayTextBox As System.Windows.Forms.TextBox
    Friend WithEvents dateTimeApplyButton As System.Windows.Forms.Button
    Friend WithEvents timeZonePanel As System.Windows.Forms.Panel
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents MainMenu1 As System.Windows.Forms.MainMenu
#If deviceType <> "PC" Then
    Friend WithEvents InputPanel1 As Microsoft.WindowsCE.Forms.InputPanel
#End If
    Friend WithEvents TextBoxOffset As System.Windows.Forms.TextBox
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.baseFormTimer = New System.Windows.Forms.Timer
        Me.exitButton = New System.Windows.Forms.Button
        Me.Panel3 = New System.Windows.Forms.Panel
        Me.PmRadioButton = New System.Windows.Forms.RadioButton
        Me.AmRadioButton = New System.Windows.Forms.RadioButton
        Me.Panel2 = New System.Windows.Forms.Panel
        Me.GmtTimeRadioButton = New System.Windows.Forms.RadioButton
        Me.localTimeRadioButton = New System.Windows.Forms.RadioButton
        Me.Label4 = New System.Windows.Forms.Label
        Me.Label7 = New System.Windows.Forms.Label
        Me.Label23 = New System.Windows.Forms.Label
        Me.minuteTextBox = New System.Windows.Forms.TextBox
        Me.hourTextBox = New System.Windows.Forms.TextBox
        Me.Label24 = New System.Windows.Forms.Label
        Me.Label25 = New System.Windows.Forms.Label
        Me.Label26 = New System.Windows.Forms.Label
        Me.yearTextBox = New System.Windows.Forms.TextBox
        Me.monthTextBox = New System.Windows.Forms.TextBox
        Me.dayTextBox = New System.Windows.Forms.TextBox
        Me.dateTimeApplyButton = New System.Windows.Forms.Button
        Me.timeZonePanel = New System.Windows.Forms.Panel
        Me.Label5 = New System.Windows.Forms.Label
        Me.MainMenu1 = New System.Windows.Forms.MainMenu
        Me.InputPanel1 = New Microsoft.WindowsCE.Forms.InputPanel
        Me.TextBoxOffset = New System.Windows.Forms.TextBox
        '
        'exitButton
        '
        Me.exitButton.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold)
        Me.exitButton.Location = New System.Drawing.Point(110, 208)
        Me.exitButton.Size = New System.Drawing.Size(73, 25)
        Me.exitButton.Text = "Exit"
        '
        'Panel3
        '
        Me.Panel3.Controls.Add(Me.PmRadioButton)
        Me.Panel3.Controls.Add(Me.AmRadioButton)
        Me.Panel3.Location = New System.Drawing.Point(148, 72)
        Me.Panel3.Size = New System.Drawing.Size(91, 29)
        '
        'PmRadioButton
        '
        Me.PmRadioButton.Location = New System.Drawing.Point(49, 6)
        Me.PmRadioButton.Size = New System.Drawing.Size(42, 19)
        Me.PmRadioButton.Text = "PM"
        '
        'AmRadioButton
        '
        Me.AmRadioButton.Checked = True
        Me.AmRadioButton.Location = New System.Drawing.Point(6, 6)
        Me.AmRadioButton.Size = New System.Drawing.Size(42, 19)
        Me.AmRadioButton.Text = "AM"
        '
        'Panel2
        '
        Me.Panel2.Controls.Add(Me.GmtTimeRadioButton)
        Me.Panel2.Controls.Add(Me.localTimeRadioButton)
        Me.Panel2.Controls.Add(Me.Label4)
        Me.Panel2.Location = New System.Drawing.Point(20, 120)
        Me.Panel2.Size = New System.Drawing.Size(219, 27)
        '
        'GmtTimeRadioButton
        '
        Me.GmtTimeRadioButton.Location = New System.Drawing.Point(150, 4)
        Me.GmtTimeRadioButton.Size = New System.Drawing.Size(57, 19)
        Me.GmtTimeRadioButton.Text = "GMT"
        '
        'localTimeRadioButton
        '
        Me.localTimeRadioButton.Checked = True
        Me.localTimeRadioButton.Location = New System.Drawing.Point(57, 5)
        Me.localTimeRadioButton.Size = New System.Drawing.Size(84, 19)
        Me.localTimeRadioButton.Text = "Local Time"
        '
        'Label4
        '
        Me.Label4.Location = New System.Drawing.Point(3, 6)
        Me.Label4.Size = New System.Drawing.Size(54, 19)
        Me.Label4.Text = "This Is:"
        '
        'Label7
        '
        Me.Label7.Location = New System.Drawing.Point(86, 64)
        Me.Label7.Size = New System.Drawing.Size(49, 13)
        Me.Label7.Text = "Minute"
        Me.Label7.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'Label23
        '
        Me.Label23.Location = New System.Drawing.Point(36, 64)
        Me.Label23.Size = New System.Drawing.Size(31, 13)
        Me.Label23.Text = "Hour"
        Me.Label23.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'minuteTextBox
        '
        Me.minuteTextBox.Location = New System.Drawing.Point(90, 80)
        Me.minuteTextBox.Size = New System.Drawing.Size(38, 22)
        Me.minuteTextBox.Text = ""
        '
        'hourTextBox
        '
        Me.hourTextBox.Location = New System.Drawing.Point(30, 80)
        Me.hourTextBox.Size = New System.Drawing.Size(38, 22)
        Me.hourTextBox.Text = ""
        '
        'Label24
        '
        Me.Label24.Location = New System.Drawing.Point(150, 16)
        Me.Label24.Size = New System.Drawing.Size(40, 13)
        Me.Label24.Text = "Year"
        Me.Label24.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'Label25
        '
        Me.Label25.Location = New System.Drawing.Point(85, 16)
        Me.Label25.Size = New System.Drawing.Size(49, 13)
        Me.Label25.Text = "Month"
        Me.Label25.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'Label26
        '
        Me.Label26.Location = New System.Drawing.Point(34, 16)
        Me.Label26.Size = New System.Drawing.Size(31, 13)
        Me.Label26.Text = "Day"
        Me.Label26.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'yearTextBox
        '
        Me.yearTextBox.Location = New System.Drawing.Point(151, 32)
        Me.yearTextBox.Size = New System.Drawing.Size(39, 22)
        Me.yearTextBox.Text = ""
        '
        'monthTextBox
        '
        Me.monthTextBox.Location = New System.Drawing.Point(90, 32)
        Me.monthTextBox.Size = New System.Drawing.Size(38, 22)
        Me.monthTextBox.Text = ""
        '
        'dayTextBox
        '
        Me.dayTextBox.Location = New System.Drawing.Point(30, 32)
        Me.dayTextBox.Size = New System.Drawing.Size(38, 22)
        Me.dayTextBox.Text = ""
        '
        'dateTimeApplyButton
        '
        Me.dateTimeApplyButton.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold)
        Me.dateTimeApplyButton.Location = New System.Drawing.Point(30, 208)
        Me.dateTimeApplyButton.Size = New System.Drawing.Size(73, 25)
        Me.dateTimeApplyButton.Text = "Apply"
        '
        'timeZonePanel
        '
        Me.timeZonePanel.Controls.Add(Me.TextBoxOffset)
        Me.timeZonePanel.Controls.Add(Me.Label5)
        Me.timeZonePanel.Location = New System.Drawing.Point(18, 152)
        Me.timeZonePanel.Size = New System.Drawing.Size(219, 39)
        '
        'Label5
        '
        Me.Label5.Location = New System.Drawing.Point(7, 13)
        Me.Label5.Size = New System.Drawing.Size(104, 17)
        Me.Label5.Text = "Time Zone Offset:"
        '
        'TextBoxOffset
        '
        Me.TextBoxOffset.Location = New System.Drawing.Point(119, 9)
        Me.TextBoxOffset.MaxLength = 6
        Me.TextBoxOffset.Size = New System.Drawing.Size(88, 22)
        Me.TextBoxOffset.Text = ""
        '
        'adminDateTimeForm
        '
        Me.ClientSize = New System.Drawing.Size(234, 288)
        Me.ControlBox = False
        Me.Controls.Add(Me.Panel3)
        Me.Controls.Add(Me.Panel2)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.Label23)
        Me.Controls.Add(Me.minuteTextBox)
        Me.Controls.Add(Me.hourTextBox)
        Me.Controls.Add(Me.Label24)
        Me.Controls.Add(Me.Label25)
        Me.Controls.Add(Me.Label26)
        Me.Controls.Add(Me.yearTextBox)
        Me.Controls.Add(Me.monthTextBox)
        Me.Controls.Add(Me.dayTextBox)
        Me.Controls.Add(Me.dateTimeApplyButton)
        Me.Controls.Add(Me.timeZonePanel)
        Me.Controls.Add(Me.exitButton)
        Me.Menu = Me.MainMenu1
        Me.Text = "Set Date And Time"

    End Sub

#End Region

    Private Sub exitButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles exitButton.Click
        Me.Close()
    End Sub

    Private Sub dateTimeApplyButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles dateTimeApplyButton.Click

        Dim dayString As String = dayTextBox.Text
        Dim monthString As String = monthTextBox.Text
        Dim yearString As String = yearTextBox.Text
        Dim hourString As String = hourTextBox.Text
        Dim minuteString As String = minuteTextBox.Text
        Dim AmValue As Boolean = AmRadioButton.Checked
        Dim GmtValue As Boolean = GmtTimeRadioButton.Checked

        Dim timeZoneString As String = TextBoxOffset.Text
        If Not GmtValue Then
            If Util.IsDouble(timeZoneString) Then
                scannerTimeZone.OffsetInfo = New Time.TimeZone.Offset(Double.Parse(timeZoneString), Time.TimeZone.Offset.ConfidenceLevels.AskedUser)
            Else
                MsgBox("Invalid Date / Time Specification: " & "Invalid Offset", MsgBoxStyle.Exclamation, "Invalid Date / Time Specification")
                Exit Sub
            End If
        End If

        If Not Util.IsInteger(hourString) Then

            MsgBox("Invalid Date / Time Specification: " & "Invalid Hour", MsgBoxStyle.Exclamation, "Invalid Date / Time Specification")
            Exit Sub

        End If

        Dim hour As Integer = hourTextBox.Text

        If hour < 1 Or hour > 13 Then

            MsgBox("Invalid Date / Time Specification: " & "Invalid Hour", MsgBoxStyle.Exclamation, "Invalid Date / Time Specification")
            Exit Sub

        End If

        If hour = 12 Then
            hour -= 12
            hourString = hour
        End If

        Dim result As String = setSystemDateAndTime( _
            dayString, monthString, yearString, hourString, minuteString, AmValue, GmtValue)

        If result <> "OK" Then

            MsgBox("Invalid Date / Time Specification: " & result, MsgBoxStyle.Exclamation, "Invalid Date / Time Specification")
            Exit Sub

        End If

        '' Save offset to a file if known
        If scannerTimeZone.IsKnown Then
            scannerTimeZone.WriteToFile(TagTrakGlobals.scanLocation.currentLocation)
        End If

        Me.Close()

    End Sub

    Private Sub TextBox_OnFocus(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles dayTextBox.GotFocus, hourTextBox.GotFocus, minuteTextBox.GotFocus, monthTextBox.GotFocus
#If deviceType <> "PC" Then
        If userSpecRecord.showKeyboardOnFocus Then Me.InputPanel1.Enabled = True
#End If
    End Sub

    Private Sub Label5_ParentChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Label5.ParentChanged

    End Sub
End Class


