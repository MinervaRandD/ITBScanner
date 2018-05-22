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

Public Class newVersionNotification
    Inherits System.Windows.Forms.Form
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents PictureBox2 As System.Windows.Forms.PictureBox
    Friend WithEvents Label13 As System.Windows.Forms.Label

#Region " Windows Form Designer generated code "

    Public Sub New()
        MyBase.New()

        'This call is required by the Windows Form Designer.
        InitializeComponent()

        rebootTimer.Enabled = False

        'Add any initialization after the InitializeComponent() call

    End Sub

    Private Sub formOnLoad(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        rebootTimer.Enabled = True
        rebootTimer.Interval = 7500

    End Sub
    Protected Overloads Overrides Sub Dispose(ByVal disposing As Boolean)
        MyBase.Dispose(disposing)
    End Sub

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    Friend WithEvents OKButton As System.Windows.Forms.Button
    Friend WithEvents rebootTimer As System.Windows.Forms.Timer
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Dim resources As System.Resources.ResourceManager = New System.Resources.ResourceManager(GetType(newVersionNotification))
        Me.Label12 = New System.Windows.Forms.Label
        Me.PictureBox2 = New System.Windows.Forms.PictureBox
        Me.Label13 = New System.Windows.Forms.Label
        Me.OKButton = New System.Windows.Forms.Button
        Me.rebootTimer = New System.Windows.Forms.Timer
        '
        'Label12
        '
        Me.Label12.Font = New System.Drawing.Font("Tahoma", 11.25!, System.Drawing.FontStyle.Regular)
        Me.Label12.Location = New System.Drawing.Point(7, 142)
        Me.Label12.Size = New System.Drawing.Size(223, 87)
        Me.Label12.Text = "Please Click The OK Button Below. The System Will Then Reboot And Install The New" & _
        " Version Of The Software"
        Me.Label12.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'PictureBox2
        '
        Me.PictureBox2.Image = CType(resources.GetObject("PictureBox2.Image"), System.Drawing.Image)
        Me.PictureBox2.Location = New System.Drawing.Point(85, 2)
        Me.PictureBox2.Size = New System.Drawing.Size(61, 55)
        '
        'Label13
        '
        Me.Label13.Font = New System.Drawing.Font("Tahoma", 11.25!, System.Drawing.FontStyle.Regular)
        Me.Label13.Location = New System.Drawing.Point(15, 62)
        Me.Label13.Size = New System.Drawing.Size(206, 73)
        Me.Label13.Text = "A New Version Or Configuration Of The Mail Scanning Software Has Been Found On Th" & _
        "e Server"
        Me.Label13.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'OKButton
        '
        Me.OKButton.Location = New System.Drawing.Point(44, 238)
        Me.OKButton.Size = New System.Drawing.Size(144, 26)
        Me.OKButton.Text = "OK"
        '
        'rebootTimer
        '
        Me.rebootTimer.Interval = 10000
        '
        'newVersionNotification
        '
        Me.ClientSize = New System.Drawing.Size(234, 288)
        Me.ControlBox = False
        Me.Controls.Add(Me.OKButton)
        Me.Controls.Add(Me.Label12)
        Me.Controls.Add(Me.PictureBox2)
        Me.Controls.Add(Me.Label13)
        Me.Text = "New Version Found"

    End Sub

#End Region

    Private Sub OKButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Me.Close()
    End Sub

    'Private Sub formKeyPress(ByVal sender As System.Object, ByVal ex As KeyPressEventArgs) Handles MyBase.KeyPress

    '    If ex.KeyChar = "0" Then
    '        exitString = ""
    '        Exit Sub
    '    End If

    '    exitString &= ex.KeyChar

    '    If isValidExitPassword(exitString) Then
    '        appExitFlag.exitFlag = True
    '        Me.Close()
    '    End If

    'End Sub

    Private Sub OKButton_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles OKButton.Click

        If emulatingPlatform Then
            MsgBox("Emulation: Call To Warm Boot")
            Exit Sub
        End If

        scannerLib.WarmBoot()
    End Sub

    Private Sub rebootTimer_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rebootTimer.Tick
        scannerLib.WarmBoot()
    End Sub
End Class
