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

Public Class ftpMsgFormDeviceNotInCradle

    ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
    '                                                                              '
    ' Form: ftpMsgFormDeviceNotInCradle.                                           '
    '                                                                              '
    ' Returns:  Based on user response:                                            '
    '                                                                              '
    '           Retry  (DialogResult) --                                           '
    '                                User wishes to reattempt process that caused  '
    '                                this error (presumbably after he/she places   '
    '                                device in the cradle.                         '
    '                                                                              '
    '           Cancel (DialogResult) --                                           '
    '                                User does not with to reattempt process that  '
    '                                caused this error.                            '
    '                                                                              '
    ' Author:   Marc Diamond                                                       '
    '                                                                              '
    ' Displays an error message indicating that the device is not in the cradle or '
    ' that there is some reason why the cradle is not being detected, when it is   '
    ' required for the current operation.                                          '
    '                                                                              '
    ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

    Inherits System.Windows.Forms.Form
    Friend WithEvents PictureBox2 As System.Windows.Forms.PictureBox

    Dim exitString As String = ""

    Dim ftpConnectionDelay As Integer
    Dim attemptNumber As String

#Region " Windows Form Designer generated code "

    Public Sub New()
        MyBase.New()

        'This call is required by the Windows Form Designer.
        InitializeComponent()

    End Sub

    Protected Overloads Overrides Sub Dispose(ByVal disposing As Boolean)
        MyBase.Dispose(disposing)
    End Sub

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    Friend WithEvents message2TextBox As System.Windows.Forms.Label
    Friend WithEvents message1TextBox As System.Windows.Forms.Label
    Friend WithEvents retryButton As System.Windows.Forms.Button
    Friend WithEvents cancelButton As System.Windows.Forms.Button
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents helpButton As System.Windows.Forms.Button
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Dim resources As System.Resources.ResourceManager = New System.Resources.ResourceManager(GetType(ftpMsgFormDeviceNotInCradle))
        Me.message2TextBox = New System.Windows.Forms.Label
        Me.PictureBox2 = New System.Windows.Forms.PictureBox
        Me.message1TextBox = New System.Windows.Forms.Label
        Me.retryButton = New System.Windows.Forms.Button
        Me.cancelButton = New System.Windows.Forms.Button
        Me.Label1 = New System.Windows.Forms.Label
        Me.Label2 = New System.Windows.Forms.Label
        Me.Label3 = New System.Windows.Forms.Label
        Me.Label4 = New System.Windows.Forms.Label
        Me.helpButton = New System.Windows.Forms.Button
        '
        'message2TextBox
        '
        Me.message2TextBox.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Regular)
        Me.message2TextBox.Location = New System.Drawing.Point(16, 88)
        Me.message2TextBox.Size = New System.Drawing.Size(202, 52)
        Me.message2TextBox.Text = "The Scanner Must Be In A Cradle To Do An Upload or Download From This Location. E" & _
        "ther,"
        '
        'PictureBox2
        '
        Me.PictureBox2.Image = CType(resources.GetObject("PictureBox2.Image"), System.Drawing.Image)
        Me.PictureBox2.Location = New System.Drawing.Point(89, 2)
        Me.PictureBox2.Size = New System.Drawing.Size(61, 55)
        '
        'message1TextBox
        '
        Me.message1TextBox.Font = New System.Drawing.Font("Tahoma", 12.0!, System.Drawing.FontStyle.Regular)
        Me.message1TextBox.Location = New System.Drawing.Point(12, 61)
        Me.message1TextBox.Size = New System.Drawing.Size(214, 23)
        Me.message1TextBox.Text = "Device Not In Cradle"
        Me.message1TextBox.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'retryButton
        '
        Me.retryButton.Location = New System.Drawing.Point(6, 227)
        Me.retryButton.Size = New System.Drawing.Size(107, 26)
        Me.retryButton.Text = "Retry"
        '
        'cancelButton
        '
        Me.cancelButton.Location = New System.Drawing.Point(121, 228)
        Me.cancelButton.Size = New System.Drawing.Size(107, 26)
        Me.cancelButton.Text = "Cancel"
        '
        'Label1
        '
        Me.Label1.Location = New System.Drawing.Point(36, 144)
        Me.Label1.Size = New System.Drawing.Size(181, 27)
        Me.Label1.Text = "Place device in cradle and tap ""Retry"", or,"
        '
        'Label2
        '
        Me.Label2.Location = New System.Drawing.Point(36, 178)
        Me.Label2.Size = New System.Drawing.Size(181, 27)
        Me.Label2.Text = "Tap ""Cancel"" to abort upload and download operation"
        '
        'Label3
        '
        Me.Label3.Location = New System.Drawing.Point(16, 144)
        Me.Label3.Size = New System.Drawing.Size(17, 21)
        Me.Label3.Text = "1."
        '
        'Label4
        '
        Me.Label4.Location = New System.Drawing.Point(16, 178)
        Me.Label4.Size = New System.Drawing.Size(17, 21)
        Me.Label4.Text = "2."
        '
        'helpButton
        '
        Me.helpButton.Font = New System.Drawing.Font("Tahoma", 12.0!, System.Drawing.FontStyle.Bold)
        Me.helpButton.Location = New System.Drawing.Point(178, 18)
        Me.helpButton.Size = New System.Drawing.Size(24, 24)
        Me.helpButton.Text = "?"
        '
        'ftpMsgFormDeviceNotInCradle
        '
        Me.ClientSize = New System.Drawing.Size(234, 288)
        Me.ControlBox = False
        Me.Controls.Add(Me.helpButton)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.cancelButton)
        Me.Controls.Add(Me.retryButton)
        Me.Controls.Add(Me.message2TextBox)
        Me.Controls.Add(Me.PictureBox2)
        Me.Controls.Add(Me.message1TextBox)
        Me.Text = "Device Not In Cradle"

    End Sub

#End Region

    Private Sub RetryButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles retryButton.Click

        Me.DialogResult = DialogResult.Retry
        Me.Close()

        Application.DoEvents()

    End Sub

    Private Sub cancelButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cancelButton.Click

        Me.DialogResult = DialogResult.Cancel
        Me.Close()

        Application.DoEvents()

    End Sub

    Private Sub helpButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles helpButton.Click

        Me.DialogResult = FtpFormRepository.ftpMsgFormDeviceNotInCradleHelp.ShowDialog()
        If Me.DialogResult = DialogResult.Abort Then
            Me.Close()
            Exit Sub
        End If

        Me.BringToFront()
        Application.DoEvents()

    End Sub

End Class

