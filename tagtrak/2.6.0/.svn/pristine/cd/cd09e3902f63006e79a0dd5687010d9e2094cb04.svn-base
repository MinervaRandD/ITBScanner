' Copyright (c) 2003-2004 Airline Software, Inc.,
' All Rights Reserved. 
' Reproduction of this document in whole or in part without written permission of   
' Airline Software, Inc. is strictly prohibited.
'
' Airline Software, Inc., Confidential - Restricted Access
'
' This document contains proprietary information that shall be
' distributed or routed only within Airline Software, Inc.,
' and its authorized clients, except with written permission of
' Airline Software, Inc. 

Imports System
Imports System.Globalization

Public Class setDateAndTime
    Inherits System.Windows.Forms.Form
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label

#Region " Windows Form Designer generated code "

    Public Sub New()

        MyBase.New()

        'This call is required by the Windows Form Designer.
        InitializeComponent()

        Dim currentDateAndTime As DateTime = scannerNow()

        dayTextBox.Text = currentDateAndTime.Day
        monthTextBox.Text = currentDateAndTime.Month
        yearTextBox.Text = currentDateAndTime.Year

        If currentDateAndTime.Hour > 12 Then
            hourTextBox.Text = currentDateAndTime.Hour - 12
            PmRadioButton.Checked = True
        Else
            hourTextBox.Text = currentDateAndTime.Hour
            PmRadioButton.Checked = False
        End If

        minuteTextBox.Text = currentDateAndTime.Minute

        setupKeyboard()

    End Sub

    Dim keyboard As keyboardClass

    Private Sub setupKeyboard()

        Dim textBoxList() As System.windows.forms.TextBox = { _
            dayTextBox, _
            monthTextBox, _
            yearTextBox, _
            hourTextBox, _
            minuteTextBox}

        keyboard = New keyboardClass(Me, textBoxList, keyboardIcon, AddressOf OKButton_Click)

    End Sub

    Protected Overloads Overrides Sub Dispose(ByVal disposing As Boolean)
        MyBase.Dispose(disposing)
    End Sub

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    Friend WithEvents OKButton As System.Windows.Forms.Button
    Friend WithEvents cancelButton As System.Windows.Forms.Button
    Friend WithEvents localTimeRadioButton As System.Windows.Forms.RadioButton
    Friend WithEvents GmtTimeRadioButton As System.Windows.Forms.RadioButton
    Friend WithEvents dayTextBox As System.Windows.Forms.TextBox
    Friend WithEvents monthTextBox As System.Windows.Forms.TextBox
    Friend WithEvents yearTextBox As System.Windows.Forms.TextBox
    Friend WithEvents minuteTextBox As System.Windows.Forms.TextBox
    Friend WithEvents hourTextBox As System.Windows.Forms.TextBox
    Friend WithEvents Panel2 As System.Windows.Forms.Panel
    Friend WithEvents Panel3 As System.Windows.Forms.Panel
    Friend WithEvents AmRadioButton As System.Windows.Forms.RadioButton
    Friend WithEvents PmRadioButton As System.Windows.Forms.RadioButton
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents keyboardIcon As System.Windows.Forms.PictureBox
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.dayTextBox = New System.Windows.Forms.TextBox
        Me.monthTextBox = New System.Windows.Forms.TextBox
        Me.yearTextBox = New System.Windows.Forms.TextBox
        Me.Label1 = New System.Windows.Forms.Label
        Me.Label2 = New System.Windows.Forms.Label
        Me.Label3 = New System.Windows.Forms.Label
        Me.Label5 = New System.Windows.Forms.Label
        Me.Label6 = New System.Windows.Forms.Label
        Me.minuteTextBox = New System.Windows.Forms.TextBox
        Me.hourTextBox = New System.Windows.Forms.TextBox
        Me.Label4 = New System.Windows.Forms.Label
        Me.localTimeRadioButton = New System.Windows.Forms.RadioButton
        Me.GmtTimeRadioButton = New System.Windows.Forms.RadioButton
        Me.OKButton = New System.Windows.Forms.Button
        Me.cancelButton = New System.Windows.Forms.Button
        Me.Panel2 = New System.Windows.Forms.Panel
        Me.Panel3 = New System.Windows.Forms.Panel
        Me.PmRadioButton = New System.Windows.Forms.RadioButton
        Me.AmRadioButton = New System.Windows.Forms.RadioButton
        Me.Label8 = New System.Windows.Forms.Label
        Me.keyboardIcon = New System.Windows.Forms.PictureBox
        '
        'dayTextBox
        '
        Me.dayTextBox.Location = New System.Drawing.Point(31, 60)
        Me.dayTextBox.Size = New System.Drawing.Size(38, 22)
        Me.dayTextBox.Text = ""
        '
        'monthTextBox
        '
        Me.monthTextBox.Location = New System.Drawing.Point(91, 60)
        Me.monthTextBox.Size = New System.Drawing.Size(38, 22)
        Me.monthTextBox.Text = ""
        '
        'yearTextBox
        '
        Me.yearTextBox.Location = New System.Drawing.Point(152, 60)
        Me.yearTextBox.Size = New System.Drawing.Size(39, 22)
        Me.yearTextBox.Text = ""
        '
        'Label1
        '
        Me.Label1.Location = New System.Drawing.Point(35, 44)
        Me.Label1.Size = New System.Drawing.Size(31, 13)
        Me.Label1.Text = "Day"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'Label2
        '
        Me.Label2.Location = New System.Drawing.Point(86, 44)
        Me.Label2.Size = New System.Drawing.Size(49, 13)
        Me.Label2.Text = "Month"
        Me.Label2.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'Label3
        '
        Me.Label3.Location = New System.Drawing.Point(151, 44)
        Me.Label3.Size = New System.Drawing.Size(40, 13)
        Me.Label3.Text = "Year"
        Me.Label3.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'Label5
        '
        Me.Label5.Location = New System.Drawing.Point(86, 83)
        Me.Label5.Size = New System.Drawing.Size(49, 13)
        Me.Label5.Text = "Minute"
        Me.Label5.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'Label6
        '
        Me.Label6.Location = New System.Drawing.Point(35, 83)
        Me.Label6.Size = New System.Drawing.Size(31, 13)
        Me.Label6.Text = "Hour"
        Me.Label6.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'minuteTextBox
        '
        Me.minuteTextBox.Location = New System.Drawing.Point(91, 98)
        Me.minuteTextBox.Size = New System.Drawing.Size(38, 22)
        Me.minuteTextBox.Text = ""
        '
        'hourTextBox
        '
        Me.hourTextBox.Location = New System.Drawing.Point(31, 98)
        Me.hourTextBox.Size = New System.Drawing.Size(38, 22)
        Me.hourTextBox.Text = ""
        '
        'Label4
        '
        Me.Label4.Location = New System.Drawing.Point(3, 6)
        Me.Label4.Size = New System.Drawing.Size(54, 19)
        Me.Label4.Text = "This Is:"
        '
        'localTimeRadioButton
        '
        Me.localTimeRadioButton.Checked = True
        Me.localTimeRadioButton.Location = New System.Drawing.Point(65, 6)
        Me.localTimeRadioButton.Size = New System.Drawing.Size(84, 19)
        Me.localTimeRadioButton.Text = "Local Time"
        '
        'GmtTimeRadioButton
        '
        Me.GmtTimeRadioButton.Location = New System.Drawing.Point(150, 4)
        Me.GmtTimeRadioButton.Size = New System.Drawing.Size(57, 19)
        Me.GmtTimeRadioButton.Text = "GMT"
        '
        'OKButton
        '
        Me.OKButton.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold)
        Me.OKButton.Location = New System.Drawing.Point(23, 181)
        Me.OKButton.Size = New System.Drawing.Size(82, 25)
        Me.OKButton.Text = "OK"
        '
        'cancelButton
        '
        Me.cancelButton.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold)
        Me.cancelButton.Location = New System.Drawing.Point(117, 181)
        Me.cancelButton.Size = New System.Drawing.Size(82, 25)
        Me.cancelButton.Text = "Cancel"
        '
        'Panel2
        '
        Me.Panel2.Controls.Add(Me.GmtTimeRadioButton)
        Me.Panel2.Controls.Add(Me.localTimeRadioButton)
        Me.Panel2.Controls.Add(Me.Label4)
        Me.Panel2.Location = New System.Drawing.Point(21, 137)
        Me.Panel2.Size = New System.Drawing.Size(219, 27)
        '
        'Panel3
        '
        Me.Panel3.Controls.Add(Me.PmRadioButton)
        Me.Panel3.Controls.Add(Me.AmRadioButton)
        Me.Panel3.Location = New System.Drawing.Point(149, 94)
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
        'Label8
        '
        Me.Label8.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Bold)
        Me.Label8.Location = New System.Drawing.Point(32, 5)
        Me.Label8.Size = New System.Drawing.Size(171, 18)
        Me.Label8.Text = "Set Date And Time"
        Me.Label8.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'keyboardIcon
        '
        Me.keyboardIcon.Location = New System.Drawing.Point(211, 185)
        Me.keyboardIcon.Size = New System.Drawing.Size(23, 16)
        '
        'setDateAndTime
        '
        Me.ClientSize = New System.Drawing.Size(234, 288)
        Me.Controls.Add(Me.keyboardIcon)
        Me.Controls.Add(Me.Label8)
        Me.Controls.Add(Me.Panel3)
        Me.Controls.Add(Me.Panel2)
        Me.Controls.Add(Me.cancelButton)
        Me.Controls.Add(Me.OKButton)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.minuteTextBox)
        Me.Controls.Add(Me.hourTextBox)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.yearTextBox)
        Me.Controls.Add(Me.monthTextBox)
        Me.Controls.Add(Me.dayTextBox)
        Me.Text = "Set Date And Time"

    End Sub

#End Region

    Private Sub formOnLoad(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        If lockDown Then
            MyBase.MaximizeBox = False
            MyBase.MinimizeBox = False
            MyBase.ControlBox = False
            MyBase.WindowState = FormWindowState.Maximized
        End If

    End Sub

    Dim withinCancelButtonClick As Boolean = False

    Private Sub cancelButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cancelButton.Click
        Me.Hide()
        'If withinCancelButtonClick Then Exit Sub

        'withinCancelButtonClick = True

        'Me.Close()

        'withinCancelButtonClick = False

    End Sub

    Private Sub OKButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles OKButton.Click

        Dim dayString As String = dayTextBox.Text
        Dim monthString As String = monthTextBox.Text
        Dim yearString As String = yearTextBox.Text
        Dim hourString As String = hourTextBox.Text
        Dim minuteString As String = minuteTextBox.Text
        Dim AmValue As Boolean = AmRadioButton.Checked
        Dim GmtValue As Boolean = GmtTimeRadioButton.Checked

        If Not IsInteger(hourString) Then

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

        keyboard.hide()
        Me.Close()

    End Sub

    Dim withinGmtTimeRadioButtonCheckedChanged As Boolean = False

    Private Sub GmtTimeRadioButton_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles GmtTimeRadioButton.CheckedChanged

        If withinGmtTimeRadioButtonCheckedChanged Then Exit Sub

        withinGmtTimeRadioButtonCheckedChanged = True

        'If GmtTimeRadioButton.Checked Then
        '    timeZonePanel.Enabled = False
        'Else
        '    timeZonePanel.Enabled = True
        'End If

        withinGmtTimeRadioButtonCheckedChanged = False


    End Sub

    Dim withinLocalTimeRadioButtonCheckedChanged As Boolean = False

    Private Sub localTimeRadioButton_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles localTimeRadioButton.CheckedChanged

        If withinLocalTimeRadioButtonCheckedChanged Then Exit Sub

        withinLocalTimeRadioButtonCheckedChanged = True

        'If localTimeRadioButton.Checked Then
        '    timeZonePanel.Enabled = True
        'Else
        '    timeZonePanel.Enabled = False
        'End If

        withinLocalTimeRadioButtonCheckedChanged = False

    End Sub

    Private Sub setDateAndTimeForm_KeyPress(ByVal sender As System.Object, ByVal e As KeyPressEventArgs) _
                Handles dayTextBox.KeyPress, monthTextBox.KeyPress, yearTextBox.KeyPress, hourTextBox.KeyPress, minuteTextBox.KeyPress

        If e.KeyChar = tabKeyChar Then
            keyboard.processTabRoutine(sender)
        End If

    End Sub
   
End Class
