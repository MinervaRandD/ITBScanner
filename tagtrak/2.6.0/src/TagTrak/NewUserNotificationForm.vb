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

Public Class newUserNotification
    Inherits System.Windows.Forms.Form
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents PictureBox2 As System.Windows.Forms.PictureBox
    Friend WithEvents Label13 As System.Windows.Forms.Label

#Region " Windows Form Designer generated code "

    Public Sub New()
        MyBase.New()

        'This call is required by the Windows Form Designer.
        InitializeComponent()

    End Sub

    Private Sub formOnLoad(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        If lockDown Then
            MyBase.MaximizeBox = False
            MyBase.MinimizeBox = False
            MyBase.ControlBox = False
            MyBase.WindowState = FormWindowState.Maximized
        End If

    End Sub
    Protected Overloads Overrides Sub Dispose(ByVal disposing As Boolean)
        MyBase.Dispose(disposing)
    End Sub

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    Friend WithEvents YesButton As System.Windows.Forms.Button
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents NoButton As System.Windows.Forms.Button
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Dim resources As System.Resources.ResourceManager = New System.Resources.ResourceManager(GetType(newUserNotification))
        Me.Label12 = New System.Windows.Forms.Label
        Me.PictureBox2 = New System.Windows.Forms.PictureBox
        Me.Label13 = New System.Windows.Forms.Label
        Me.YesButton = New System.Windows.Forms.Button
        Me.Label1 = New System.Windows.Forms.Label
        Me.NoButton = New System.Windows.Forms.Button
        Me.Label2 = New System.Windows.Forms.Label
        Me.Label3 = New System.Windows.Forms.Label
        '
        'Label12
        '
        Me.Label12.Font = New System.Drawing.Font("Tahoma", 11.25!, System.Drawing.FontStyle.Regular)
        Me.Label12.Location = New System.Drawing.Point(3, 111)
        Me.Label12.Size = New System.Drawing.Size(223, 62)
        Me.Label12.Text = "You Must Exit The Program And Restart It In Order For This Change To Take Effect"
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
        Me.Label13.Font = New System.Drawing.Font("Tahoma", 11.25!, System.Drawing.FontStyle.Regular)
        Me.Label13.Location = New System.Drawing.Point(31, 68)
        Me.Label13.Size = New System.Drawing.Size(167, 34)
        Me.Label13.Text = "You Have Selected A New User"
        Me.Label13.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'YesButton
        '
        Me.YesButton.Location = New System.Drawing.Point(9, 235)
        Me.YesButton.Size = New System.Drawing.Size(66, 26)
        Me.YesButton.Text = "Yes"
        '
        'Label1
        '
        Me.Label1.Font = New System.Drawing.Font("Tahoma", 11.25!, System.Drawing.FontStyle.Regular)
        Me.Label1.Location = New System.Drawing.Point(6, 182)
        Me.Label1.Size = New System.Drawing.Size(223, 39)
        Me.Label1.Text = "Do You Want To Exit The Program Now?"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'NoButton
        '
        Me.NoButton.Location = New System.Drawing.Point(8, 264)
        Me.NoButton.Size = New System.Drawing.Size(66, 26)
        Me.NoButton.Text = "No"
        '
        'Label2
        '
        Me.Label2.Location = New System.Drawing.Point(78, 239)
        Me.Label2.Size = New System.Drawing.Size(129, 18)
        Me.Label2.Text = "Exit The Program Now"
        '
        'Label3
        '
        Me.Label3.Location = New System.Drawing.Point(78, 268)
        Me.Label3.Size = New System.Drawing.Size(141, 18)
        Me.Label3.Text = "Return To Scan Program"
        '
        'newUserNotification
        '
        Me.ClientSize = New System.Drawing.Size(234, 288)
        Me.ControlBox = False
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.NoButton)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.YesButton)
        Me.Controls.Add(Me.Label12)
        Me.Controls.Add(Me.PictureBox2)
        Me.Controls.Add(Me.Label13)
        Me.Text = "New User Selected"

    End Sub

#End Region

    Private Sub OKButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Me.Close()
    End Sub

    Private Sub YesButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles YesButton.Click
        Me.DialogResult = DialogResult.Abort
        Me.Close()
    End Sub

    Private Sub NoButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles NoButton.Click
        Me.DialogResult = DialogResult.OK
        Me.Close()
    End Sub
End Class
