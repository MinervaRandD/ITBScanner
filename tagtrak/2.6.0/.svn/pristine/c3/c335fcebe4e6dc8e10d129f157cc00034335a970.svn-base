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

Public Class ftpFailureNotification
    Inherits System.Windows.Forms.Form
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents PictureBox1 As System.Windows.Forms.PictureBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents ftpErrorLabel As System.Windows.Forms.Label

#Region " Windows Form Designer generated code "

    Public Sub New()
        MyBase.New()

        'This call is required by the Windows Form Designer.
        InitializeComponent()

    End Sub

    Public Sub init(ByRef errorString As String)
        ftpErrorLabel.Text = errorString
    End Sub

    Protected Overloads Overrides Sub Dispose(ByVal disposing As Boolean)
        MyBase.Dispose(disposing)
    End Sub

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    Friend WithEvents OKButton As System.Windows.Forms.Button
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Dim resources As System.Resources.ResourceManager = New System.Resources.ResourceManager(GetType(ftpFailureNotification))
        Me.Label1 = New System.Windows.Forms.Label
        Me.Label2 = New System.Windows.Forms.Label
        Me.PictureBox1 = New System.Windows.Forms.PictureBox
        Me.Label3 = New System.Windows.Forms.Label
        Me.ftpErrorLabel = New System.Windows.Forms.Label
        Me.OKButton = New System.Windows.Forms.Button
        '
        'Label1
        '
        Me.Label1.Font = New System.Drawing.Font("Tahoma", 12.0!, System.Drawing.FontStyle.Regular)
        Me.Label1.Location = New System.Drawing.Point(41, 65)
        Me.Label1.Size = New System.Drawing.Size(178, 42)
        Me.Label1.Text = "An Upload or Download Error Has Occurred"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'Label2
        '
        Me.Label2.Font = New System.Drawing.Font("Tahoma", 12.0!, System.Drawing.FontStyle.Regular)
        Me.Label2.Location = New System.Drawing.Point(21, 114)
        Me.Label2.Size = New System.Drawing.Size(221, 66)
        Me.Label2.Text = "Please Be Sure Device Is Properly Seated In The Cradle"
        Me.Label2.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'PictureBox1
        '
        Me.PictureBox1.Image = CType(resources.GetObject("PictureBox1.Image"), System.Drawing.Image)
        Me.PictureBox1.Location = New System.Drawing.Point(99, 5)
        Me.PictureBox1.Size = New System.Drawing.Size(61, 55)
        '
        'Label3
        '
        Me.Label3.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Regular)
        Me.Label3.Location = New System.Drawing.Point(42, 177)
        Me.Label3.Size = New System.Drawing.Size(188, 60)
        Me.Label3.Text = "If problem persists, please call 845 357 -7101 and report the following error:"
        '
        'ftpErrorLabel
        '
        Me.ftpErrorLabel.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Regular)
        Me.ftpErrorLabel.Location = New System.Drawing.Point(38, 249)
        Me.ftpErrorLabel.Size = New System.Drawing.Size(192, 32)
        '
        'OKButton
        '
        Me.OKButton.Location = New System.Drawing.Point(73, 295)
        Me.OKButton.Size = New System.Drawing.Size(103, 30)
        Me.OKButton.Text = "OK"
        '
        'ftpFailureNotification
        '
        Me.ClientSize = New System.Drawing.Size(234, 288)
        Me.ControlBox = False
        Me.Controls.Add(Me.OKButton)
        Me.Controls.Add(Me.ftpErrorLabel)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.PictureBox1)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Text = "Ftp Failure"

    End Sub

#End Region

    Private Sub OKButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles OKButton.Click
        Me.Close()
    End Sub

End Class
