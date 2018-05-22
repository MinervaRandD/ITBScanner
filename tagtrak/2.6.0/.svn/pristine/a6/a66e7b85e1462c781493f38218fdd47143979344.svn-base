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

Public Class ATASplash
    Inherits System.Windows.Forms.Form
    Friend WithEvents PictureBox1 As System.Windows.Forms.PictureBox
    Friend WithEvents Label1 As System.Windows.Forms.Label

#Region " Windows Form Designer generated code "

    Public Sub New()
        MyBase.New()

        'This call is required by the Windows Form Designer.
        InitializeComponent()

        'Add any initialization after the InitializeComponent() call

    End Sub

    Protected Overloads Overrides Sub Dispose(ByVal disposing As Boolean)
        MyBase.Dispose(disposing)
    End Sub

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    Friend WithEvents ATAOKButton As System.Windows.Forms.Button
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Dim resources As System.Resources.ResourceManager = New System.Resources.ResourceManager(GetType(ATASplash))
        Me.PictureBox1 = New System.Windows.Forms.PictureBox
        Me.Label1 = New System.Windows.Forms.Label
        Me.ATAOKButton = New System.Windows.Forms.Button
        '
        'PictureBox1
        '
        Me.PictureBox1.Image = CType(resources.GetObject("PictureBox1.Image"), System.Drawing.Image)
        Me.PictureBox1.Location = New System.Drawing.Point(1, 10)
        Me.PictureBox1.Size = New System.Drawing.Size(242, 139)
        '
        'Label1
        '
        Me.Label1.Font = New System.Drawing.Font("MS Reference Serif", 14.25!, System.Drawing.FontStyle.Bold)
        Me.Label1.Location = New System.Drawing.Point(6, 156)
        Me.Label1.Size = New System.Drawing.Size(233, 74)
        Me.Label1.Text = "WELCOME TO  ATA MAIL HANDLING OPERATIONS"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'ATAOKButton
        '
        Me.ATAOKButton.Location = New System.Drawing.Point(77, 246)
        Me.ATAOKButton.Size = New System.Drawing.Size(91, 24)
        Me.ATAOKButton.Text = "OK"
        '
        'ATASplash
        '
        Me.ClientSize = New System.Drawing.Size(252, 292)
        Me.Controls.Add(Me.ATAOKButton)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.PictureBox1)
        Me.Text = "ATASplash"

    End Sub

#End Region

    Private Sub ATAOKButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ATAOKButton.Click
        Me.Close()
    End Sub

End Class
