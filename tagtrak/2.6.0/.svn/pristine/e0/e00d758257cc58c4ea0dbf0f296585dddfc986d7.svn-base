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

Public Class ftpMsgFormDeviceNotInCradleHelp

    ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
    '                                                                              '
    ' Form: ftpMsgFormDeviceNotInCradleHelp                                        '
    '                                                                              '
    ' Author:   Marc Diamond                                                       '
    '                                                                              '
    ' Displays general help information related to the "Device Not In Cradle"      '
    ' error.                                                                       
    '                                                                              '
    ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

    Inherits System.Windows.Forms.Form

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
    Friend WithEvents OKButton As System.Windows.Forms.Button
    Friend WithEvents helpListBox As System.Windows.Forms.ListBox
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.OKButton = New System.Windows.Forms.Button
        Me.helpListBox = New System.Windows.Forms.ListBox
        '
        'OKButton
        '
        Me.OKButton.Location = New System.Drawing.Point(65, 215)
        Me.OKButton.Size = New System.Drawing.Size(107, 26)
        Me.OKButton.Text = "OK"
        '
        'helpListBox
        '
        Me.helpListBox.Items.Add("You are attempting to upload")
        Me.helpListBox.Items.Add("and/or download data from a")
        Me.helpListBox.Items.Add("location that requires that the")
        Me.helpListBox.Items.Add("scanner be in a cradle in order")
        Me.helpListBox.Items.Add("to connect to the main mail service")
        Me.helpListBox.Items.Add("computer.")
        Me.helpListBox.Items.Add("")
        Me.helpListBox.Items.Add("In order to do this, please be sure")
        Me.helpListBox.Items.Add("that the device is securely placed in")
        Me.helpListBox.Items.Add("the cradle.")
        Me.helpListBox.Items.Add("")
        Me.helpListBox.Items.Add("There is an electrical connector")
        Me.helpListBox.Items.Add("inside the cradle, and this must fit")
        Me.helpListBox.Items.Add("securely into the receptor at the")
        Me.helpListBox.Items.Add("bottom of the scanner in order to")
        Me.helpListBox.Items.Add("make a good connection.")
        Me.helpListBox.Items.Add("")
        Me.helpListBox.Items.Add("Be sure that the power cord is")
        Me.helpListBox.Items.Add("attached to the cradle and that the")
        Me.helpListBox.Items.Add("indicator light on the device and/or")
        Me.helpListBox.Items.Add("cradle indicates that the device")
        Me.helpListBox.Items.Add("and cradle are receiving power.")
        Me.helpListBox.Items.Add("")
        Me.helpListBox.Items.Add("If necessary contact your local compute")
        Me.helpListBox.Items.Add("support department for further")
        Me.helpListBox.Items.Add("instructions")
        Me.helpListBox.Location = New System.Drawing.Point(7, 20)
        Me.helpListBox.Size = New System.Drawing.Size(226, 184)
        '
        'ftpMsgFormDeviceNotInCradleHelp
        '
        Me.ClientSize = New System.Drawing.Size(234, 288)
        Me.ControlBox = False
        Me.Controls.Add(Me.helpListBox)
        Me.Controls.Add(Me.OKButton)
        Me.Text = "Device Not In Cradle"

    End Sub

#End Region

    Private Sub OKButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles OKButton.Click

        Me.Close()

        Application.DoEvents()

    End Sub

End Class

