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

Public Class deviceHardwareErrorMessage
    Inherits System.Windows.Forms.Form
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents PictureBox2 As System.Windows.Forms.PictureBox
    Friend WithEvents Label13 As System.Windows.Forms.Label

#Region " Windows Form Designer generated code "

    Public Sub New()

        MyBase.New()

        'This call is required by the Windows Form Designer.
        InitializeComponent()

        'Add any initialization after the InitializeComponent() call

        If Not File.Exists("\Flash File Store\HardwareError.txt") Then
            File.Create("\Flash File Store\HardwareError.txt")
        End If

    End Sub

    Protected Overloads Overrides Sub Dispose(ByVal disposing As Boolean)
        MyBase.Dispose(disposing)
    End Sub

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Dim resources As System.Resources.ResourceManager = New System.Resources.ResourceManager(GetType(deviceHardwareErrorMessage))
        Me.Label12 = New System.Windows.Forms.Label
        Me.PictureBox2 = New System.Windows.Forms.PictureBox
        Me.Label13 = New System.Windows.Forms.Label
        '
        'Label12
        '
        Me.Label12.Font = New System.Drawing.Font("Tahoma", 14.25!, System.Drawing.FontStyle.Regular)
        Me.Label12.Location = New System.Drawing.Point(4, 161)
        Me.Label12.Size = New System.Drawing.Size(223, 71)
        Me.Label12.Text = "Do Not Attempt To Use This Device Until It Has Been Serviced"
        Me.Label12.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'PictureBox2
        '
        Me.PictureBox2.Image = CType(resources.GetObject("PictureBox2.Image"), System.Drawing.Image)
        Me.PictureBox2.Location = New System.Drawing.Point(86, 4)
        Me.PictureBox2.Size = New System.Drawing.Size(61, 55)
        '
        'Label13
        '
        Me.Label13.Font = New System.Drawing.Font("Tahoma", 14.25!, System.Drawing.FontStyle.Regular)
        Me.Label13.Location = New System.Drawing.Point(13, 72)
        Me.Label13.Size = New System.Drawing.Size(206, 78)
        Me.Label13.Text = "A Failure Of The Main Memory Card Has Been Detected"
        Me.Label13.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'deviceHardwareErrorMessage
        '
        Me.ClientSize = New System.Drawing.Size(234, 288)
        Me.ControlBox = False
        Me.Controls.Add(Me.Label12)
        Me.Controls.Add(Me.PictureBox2)
        Me.Controls.Add(Me.Label13)
        Me.Text = "Hardware Error"

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


End Class
