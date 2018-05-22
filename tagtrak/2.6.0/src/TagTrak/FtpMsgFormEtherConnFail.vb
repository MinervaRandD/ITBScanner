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

Public Class ftpMsgFormEtherConnFail

    ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
    '                                                                              '
    ' Form: ftpMsgFormEtherConnFail.                                               '
    '                                                                              '
    ' Returns:  Based on user response:                                            '
    '                                                                              '
    '           "Retry"  (DialogResult) --                                         '
    '                                User wishes to reattempt process that caused  '
    '                                this error (presumbably after he/she places   '
    '                                device in the cradle.                         '
    '                                                                              '
    '           "Cancel" (DialogResult) --                                         '
    '                                User does not with to reattempt process that  '
    '                                caused this error.                            '
    '                                                                              '
    ' Author:   Marc Diamond                                                       '
    '                                                                              '
    ' Displays an error message indicating that the attempt to open an ftp         '
    ' connection failed. The user is provided with the option to retry the         '
    ' operation or to cancel further attempts.                                     '
    '                                                                              '
    ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

    Inherits System.Windows.Forms.Form
    Friend WithEvents PictureBox2 As System.Windows.Forms.PictureBox

    Dim errorMessage As String

#Region " Windows Form Designer generated code "

    Public Sub New()
        MyBase.New()

        'This call is required by the Windows Form Designer.
        InitializeComponent()

    End Sub

    Public Sub init(ByVal inputErrorMessage As String)

        errorMessage = inputErrorMessage

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
        Dim resources As System.Resources.ResourceManager = New System.Resources.ResourceManager(GetType(ftpMsgFormEtherConnFail))
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
        Me.message2TextBox.Location = New System.Drawing.Point(6, 82)
        Me.message2TextBox.Size = New System.Drawing.Size(221, 52)
        Me.message2TextBox.Text = "Make sure all cables are connected to the cradle. Contact your systems administra" & _
        "tor if problem persists."
        '
        'PictureBox2
        '
        Me.PictureBox2.Image = CType(resources.GetObject("PictureBox2.Image"), System.Drawing.Image)
        Me.PictureBox2.Location = New System.Drawing.Point(89, 2)
        Me.PictureBox2.Size = New System.Drawing.Size(61, 55)
        '
        'message1TextBox
        '
        Me.message1TextBox.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Bold)
        Me.message1TextBox.Location = New System.Drawing.Point(12, 60)
        Me.message1TextBox.Size = New System.Drawing.Size(214, 14)
        Me.message1TextBox.Text = "Unable To Connect To Server"
        Me.message1TextBox.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'retryButton
        '
        Me.retryButton.Location = New System.Drawing.Point(5, 224)
        Me.retryButton.Size = New System.Drawing.Size(108, 26)
        Me.retryButton.Text = "Retry"
        '
        'cancelButton
        '
        Me.cancelButton.Location = New System.Drawing.Point(120, 224)
        Me.cancelButton.Size = New System.Drawing.Size(108, 26)
        Me.cancelButton.Text = "Cancel"
        '
        'Label1
        '
        Me.Label1.Location = New System.Drawing.Point(36, 140)
        Me.Label1.Size = New System.Drawing.Size(181, 15)
        Me.Label1.Text = "Tap ""Retry"" to retry connection."
        '
        'Label2
        '
        Me.Label2.Location = New System.Drawing.Point(36, 160)
        Me.Label2.Size = New System.Drawing.Size(181, 27)
        Me.Label2.Text = "Tap ""Cancel"" to abort upload and download operation"
        '
        'Label3
        '
        Me.Label3.Location = New System.Drawing.Point(16, 140)
        Me.Label3.Size = New System.Drawing.Size(17, 21)
        Me.Label3.Text = "1."
        '
        'Label4
        '
        Me.Label4.Location = New System.Drawing.Point(16, 160)
        Me.Label4.Size = New System.Drawing.Size(17, 21)
        Me.Label4.Text = "2."
        '
        'helpButton
        '
        Me.helpButton.Font = New System.Drawing.Font("Tahoma", 12.0!, System.Drawing.FontStyle.Bold)
        Me.helpButton.Location = New System.Drawing.Point(180, 16)
        Me.helpButton.Size = New System.Drawing.Size(24, 24)
        Me.helpButton.Text = "?"
        '
        'ftpMsgFormEtherConnFail
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
        Me.Text = "Ftp Connection Failure"

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

        FtpFormRepository.ftpMsgFormEtherConnFailHelp.init(errorMessage)

        Me.DialogResult = FtpFormRepository.ftpMsgFormEtherConnFailHelp.ShowDialog()
        If Me.DialogResult = DialogResult.Abort Then
            Me.Close()
            Exit Sub
        End If

        Me.BringToFront()

        Application.DoEvents()

    End Sub
End Class


