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

Public Class resditUploadReminderForm
    Inherits System.Windows.Forms.Form
    Friend WithEvents PictureBox1 As System.Windows.Forms.PictureBox
    Friend WithEvents OKButton As System.Windows.Forms.Button

#Region " Windows Form Designer generated code "

    Public Sub New()

        MyBase.New()

        'This call is required by the Windows Form Designer.
        InitializeComponent()

        'Add any initialization after the InitializeComponent() call

        Me.DialogResult = DialogResult.OK

    End Sub

    Public Sub initResditUploadReminderForm(ByVal minuteValue As Integer)

        uploadReminderLabel1.Text = "A SCAN SET EXISTS THAT MUST BE UPLOADED WITHIN THE NEXT " & minuteValue & " MINUTES"
        uploadReminderLabel2.Text = "PLEASE RETURN THE SCANNER TO THE CRADLE AND TAP UPLOAD IN ORDER TO CONFORM TO THE 2 HOUR RULE."

        Util.turnScannerOff(3)

    End Sub

    Protected Overloads Overrides Sub Dispose(ByVal disposing As Boolean)
        MyBase.Dispose(disposing)
    End Sub

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    Friend WithEvents uploadReminderLabel1 As System.Windows.Forms.Label
    Friend WithEvents uploadReminderLabel2 As System.Windows.Forms.Label
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Dim resources As System.Resources.ResourceManager = New System.Resources.ResourceManager(GetType(resditUploadReminderForm))
        Me.PictureBox1 = New System.Windows.Forms.PictureBox
        Me.uploadReminderLabel1 = New System.Windows.Forms.Label
        Me.OKButton = New System.Windows.Forms.Button
        Me.uploadReminderLabel2 = New System.Windows.Forms.Label
        '
        'PictureBox1
        '
        Me.PictureBox1.Image = CType(resources.GetObject("PictureBox1.Image"), System.Drawing.Image)
        Me.PictureBox1.Location = New System.Drawing.Point(99, 7)
        Me.PictureBox1.Size = New System.Drawing.Size(61, 55)
        '
        'uploadReminderLabel1
        '
        Me.uploadReminderLabel1.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Bold)
        Me.uploadReminderLabel1.Location = New System.Drawing.Point(30, 77)
        Me.uploadReminderLabel1.Size = New System.Drawing.Size(198, 53)
        Me.uploadReminderLabel1.Text = "Label1"
        Me.uploadReminderLabel1.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'OKButton
        '
        Me.OKButton.Location = New System.Drawing.Point(66, 231)
        Me.OKButton.Size = New System.Drawing.Size(126, 27)
        Me.OKButton.Text = "OK"
        '
        'uploadReminderLabel2
        '
        Me.uploadReminderLabel2.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Bold)
        Me.uploadReminderLabel2.Location = New System.Drawing.Point(30, 145)
        Me.uploadReminderLabel2.Size = New System.Drawing.Size(198, 71)
        Me.uploadReminderLabel2.Text = "Label1"
        Me.uploadReminderLabel2.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'resditUploadReminderForm
        '
        Me.ClientSize = New System.Drawing.Size(234, 288)
        Me.ControlBox = False
        Me.Controls.Add(Me.uploadReminderLabel2)
        Me.Controls.Add(Me.OKButton)
        Me.Controls.Add(Me.uploadReminderLabel1)
        Me.Controls.Add(Me.PictureBox1)
        Me.Text = "Upload Reminder"

    End Sub

#End Region


    Private Sub OKButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles OKButton.Click
        Me.Close()
    End Sub


    Private Sub form_Closing(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles MyBase.Closing
        Util.turnScannerOn(6)
    End Sub

End Class
