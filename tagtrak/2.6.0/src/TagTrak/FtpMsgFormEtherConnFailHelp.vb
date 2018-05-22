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

Public Class ftpMsgFormEtherConnFailHelp

    ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
    '                                                                              '
    ' Form: ftpMsgFormEtherConnFailHelp                                            '
    '                                                                              '
    ' Author:   Marc Diamond                                                       '
    '                                                                              '
    ' Displays general help information related to the "Ftp Connection Failure"    '
    ' error.                                                                       '
    '                                                                              '
    ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

    Inherits System.Windows.Forms.Form

    Dim errorMessage As String

#Region " Windows Form Designer generated code "

    Public Sub New()
        MyBase.New()

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
    Friend WithEvents message1TextBox As System.Windows.Forms.Label
    Friend WithEvents OKButton As System.Windows.Forms.Button
    Friend WithEvents helpListBox As System.Windows.Forms.ListBox
    Friend WithEvents errorDetailsButton As System.Windows.Forms.Button
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.message1TextBox = New System.Windows.Forms.Label
        Me.OKButton = New System.Windows.Forms.Button
        Me.helpListBox = New System.Windows.Forms.ListBox
        Me.errorDetailsButton = New System.Windows.Forms.Button
        '
        'message1TextBox
        '
        Me.message1TextBox.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Regular)
        Me.message1TextBox.Location = New System.Drawing.Point(10, 7)
        Me.message1TextBox.Size = New System.Drawing.Size(214, 23)
        Me.message1TextBox.Text = "Unable To Connect To Server Help"
        Me.message1TextBox.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'OKButton
        '
        Me.OKButton.Location = New System.Drawing.Point(9, 235)
        Me.OKButton.Size = New System.Drawing.Size(101, 26)
        Me.OKButton.Text = "OK"
        '
        'helpListBox
        '
        Me.helpListBox.Items.Add("The scanner is not able to connect")
        Me.helpListBox.Items.Add("to the main mail service computer.")
        Me.helpListBox.Items.Add("")
        Me.helpListBox.Items.Add("Please check to be sure that the")
        Me.helpListBox.Items.Add("proper cables are connected from")
        Me.helpListBox.Items.Add("the cradle to the local area network")
        Me.helpListBox.Items.Add("connectors or to another computer.")
        Me.helpListBox.Items.Add("")
        Me.helpListBox.Items.Add("Contact your systems administrator")
        Me.helpListBox.Items.Add("if you need further assistance.")
        Me.helpListBox.Location = New System.Drawing.Point(7, 32)
        Me.helpListBox.Size = New System.Drawing.Size(226, 184)
        '
        'errorDetailsButton
        '
        Me.errorDetailsButton.Location = New System.Drawing.Point(125, 235)
        Me.errorDetailsButton.Size = New System.Drawing.Size(101, 26)
        Me.errorDetailsButton.Text = "Error Details"
        '
        'ftpMsgFormEtherConnFailHelp
        '
        Me.ClientSize = New System.Drawing.Size(234, 288)
        Me.ControlBox = False
        Me.Controls.Add(Me.errorDetailsButton)
        Me.Controls.Add(Me.helpListBox)
        Me.Controls.Add(Me.OKButton)
        Me.Controls.Add(Me.message1TextBox)
        Me.Text = "Connection Failed"

    End Sub

#End Region

    Private Sub OKButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles OKButton.Click

        Me.Close()

        Application.DoEvents()

    End Sub

    Private Sub errorDetailsButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles errorDetailsButton.Click

        Dim errorLogDisplayForm As errorLogForm = New errorLogForm(errorMessage)
        errorLogDisplayForm.ShowDialog()

        Me.BringToFront()

        Application.DoEvents()

    End Sub

End Class


