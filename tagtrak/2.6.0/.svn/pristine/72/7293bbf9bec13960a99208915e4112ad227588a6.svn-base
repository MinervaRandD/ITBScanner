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
Imports System.text

#Const incrementProgressBar = False

Public Class MailScanDomsForm
    Inherits System.Windows.Forms.Form
    Public WithEvents mainTabControl As System.Windows.Forms.TabControl
    Friend WithEvents mailCarrierCodeLabel As System.Windows.Forms.Label
    Friend WithEvents operationComboBox As System.Windows.Forms.ComboBox
    Friend WithEvents groupNumberTextBox As System.Windows.Forms.TextBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents flightNumberTextBox As System.Windows.Forms.TextBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents transferPointTextBox As System.Windows.Forms.TextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents saveButton As System.Windows.Forms.Button
    Friend WithEvents weightTextBox As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents DandRTextBox As System.Windows.Forms.TextBox
    Friend WithEvents transferPointLabel As System.Windows.Forms.Label
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents destinationLabel As System.Windows.Forms.Label
    Friend WithEvents uploadButton As System.Windows.Forms.Button
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents totalWeightLabel As System.Windows.Forms.Label
    Friend WithEvents mailPieceCountLabel As System.Windows.Forms.Label

    Public gotoBaseAfterInitialization As Boolean = False

    Public errorExitFormNextTabPage As String = ""
    Public uploadDownloadFormNextTabPage As String = ""

    Public exitString As String = ""

    Public checkingForUploadDownload As Boolean = True
    Public DandRTextBoxTextChangedEnabled As Boolean = True
    Public weightTextBoxTextChangedEnabled As Boolean = True

    Dim withinFtpProcess As Boolean = False

    Public currentScanScreenPopulatedFromPreset As Boolean = False

    Public doNotConfirmLocationChange As Boolean = False

    Public ignoreOperationComboBoxChange As Boolean = True


    Dim textBoxControl As System.Windows.Forms.TextBox
    Dim nextTextBoxControl As System.windows.forms.TextBox

    Friend WithEvents keyboardPanel As System.Windows.Forms.Panel
    Friend WithEvents lowerCasePictureBox As System.Windows.Forms.PictureBox
    Friend WithEvents upperCasePictureBox As System.Windows.Forms.PictureBox

    Dim textBoxCollection()() As System.Windows.Forms.TextBox
    Dim mailScanTextBoxCollection() As System.Windows.Forms.TextBox
    Dim mailScanSimpleTextBoxCollection() As System.Windows.Forms.TextBox

    Dim cargoScanTextBoxCollection() As System.Windows.Forms.TextBox
    Dim messagesTextBoxCollection() As System.Windows.Forms.TextBox

    Dim lastMailScanTextBox As Integer = 0
    Dim lastMailScanSimpleTextBox As Integer = 0
    Dim lastBaggageScanTextBox As Integer = 0
    Dim lastCargoScanTextBox As Integer = 0

    Dim tabbedTextBoxArrayList As New ArrayList

    'Public mailPieceCountBinding As New Binding("Text", Me.mailPieceCountLabel, "Text")

#Region " Windows Form Designer generated code "

    Public Sub New()

        MyBase.New()
        Cursor.Current = Cursors.WaitCursor

        'This call is required by the Windows Form Designer.

        InitializeComponent()

        Application.DoEvents()

        scanLocation.addControl(cbxMailScanLocation)
        'scanLocation.addControl(lblMailScanLocation)

        backgroundFtpTimer.Enabled = False

        uploadButton.Enabled = True
        transferPointTextBox.Enabled = False

        loadMailFormLogo()
        loadMailSimpleFormLogo()

        'incrementProgramLoadProgressBar()

        startupProcessRoutine()

        'incrementProgramLoadProgressBar()

        totalWeightLabel.Text = 0

        mailPieceCountLabel.Text = 0

        'cargoPieceCountLabel.Text = 0

#If deviceType = "PC" Then

        Me.mainTabControl.Location = New System.Drawing.Point(0, -20)

        DandRTextBox.Text = "DUMMYSCANN"
        weightTextBox.Text = "0"

        Me.mainTabControl.BringToFront()
        'Me.selectItemButton.BringToFront()

#End If


        'If currentSummaryFileIsValid Then
        '    Summary.Enabled = False
        'Else
        '    Summary.Enabled = True
        'End If

        'selectMailScanTabPage(Me)

        uploadReminderMinuteCount = 120

        loadOperationComboBox()

        mailSimplePieceCountLabel.DataBindings.Add(New Binding("Text", Me.mailPieceCountLabel, "Text"))
        mailSimpleScanTotalWeightLabel.DataBindings.Add(New Binding("Text", Me.totalWeightLabel, "Text"))

        mailScanSimpleWeightTextBox.DataBindings.Add(New Binding("Text", Me.weightTextBox, "Text"))
        mailScanSimpleDandRTagTextBox.DataBindings.Add(New Binding("Text", Me.DandRTextBox, "Text"))
        mailScanSimpleOperationComboBox.DataBindings.Add(New Binding("SelectedIndex", Me.operationComboBox, "SelectedIndex"))
        mailScanSimpleLargeBarcodeCheckBox.DataBindings.Add(New Binding("CheckState", Me.enableCode93CheckBox, "CheckState"))
        mailScanSimpleLargeBarcodeCheckBox.DataBindings.Add(New Binding("Checked", Me.enableCode93CheckBox, "Checked"))

        Me.mailSimpleScanFormLogoPictureBox.Image = Me.mailFormLogoPictureBox.Image

        Me.MainMenu1.MenuItems.Clear()
        Me.MainMenu1.MenuItems.Add(NavigationMainMenu.Singlet)
        Me.MainMenu1.MenuItems.Add(Me.Tools)

        Cursor.Current = Cursors.Default

    End Sub

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  

#End Region


    Private Sub formActive(ByVal sender As Object, ByVal e As EventArgs) Handles MyBase.Activated

        TagTrakGlobals.currentScanOperation = "MailScanDoms"

        'If Not currentSummaryFileIsValid Then
        '    Summary.Enabled = True
        'ElseIf Me.flightNumberTextBox.Text.Length <= 0 Then
        '    Summary.Enabled = False
        'End If

        If Me.operationComboBox.SelectedIndex > 0 Then
            If userSpecRecord.screenTimeOutValue > 0 Then
                Timer1.Enabled = True
            End If
        End If

        If userSpecRecord.loginEnabled = True Then
            If userSpecRecord.logoutTimeOutValue > 0 Then
                LogTimer1.Enabled = True
                LogTimer2.Interval = userSpecRecord.logoutTimeOutValue * 60000
            End If
        End If

    End Sub

    Private Sub enterKeyHandler(ByVal sender As Object, ByVal e As EventArgs)
        If saveButton.Enabled Then Me.saveButton_Click(Nothing, Nothing)
    End Sub

    Protected Overloads Overrides Sub Dispose(ByVal disposing As Boolean)
        MyBase.Dispose(disposing)
    End Sub

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    Friend WithEvents batchIDLabel As System.Windows.Forms.Label
    Friend WithEvents binUploadButton As System.Windows.Forms.Button
    Friend WithEvents mailFormLogoPictureBox As System.Windows.Forms.PictureBox
    Friend WithEvents operationCodeLabel As System.Windows.Forms.Label
    Friend WithEvents enableCode93CheckBox As System.Windows.Forms.CheckBox
    Friend WithEvents MailScanTab As System.Windows.Forms.TabPage
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents Label15 As System.Windows.Forms.Label
    Friend WithEvents Label21 As System.Windows.Forms.Label
    Friend WithEvents Label39 As System.Windows.Forms.Label
    Friend WithEvents Label45 As System.Windows.Forms.Label
    Friend WithEvents Label47 As System.Windows.Forms.Label
    Friend WithEvents mailScanSimpleForm As System.Windows.Forms.TabPage
    Friend WithEvents mailSimplePieceCountLabel As System.Windows.Forms.Label
    Friend WithEvents mailSimpleScanTotalWeightLabel As System.Windows.Forms.Label
    Friend WithEvents mailScanSimpleWeightTextBox As System.Windows.Forms.TextBox
    Friend WithEvents mailScanSimpleDandRTagTextBox As System.Windows.Forms.TextBox
    Friend WithEvents mailScanSimpleOperationComboBox As System.Windows.Forms.ComboBox
    Friend WithEvents mailScanSimpleLargeBarcodeCheckBox As System.Windows.Forms.CheckBox
    Friend WithEvents mailScanSimplePresetListBox As System.Windows.Forms.ListBox
    Friend WithEvents mailDestinationComboBox As System.Windows.Forms.ComboBox
    Friend WithEvents mailSimpleScanFormLogoPictureBox As System.Windows.Forms.PictureBox
    Friend WithEvents scanSimpleUploadButton As System.Windows.Forms.Button
    Friend WithEvents binFullButton As System.Windows.Forms.Button
    Friend WithEvents scanSimpleBinFullButton As System.Windows.Forms.Button
    Friend WithEvents mailScanSimpleBinUpload As System.Windows.Forms.Button
    Friend WithEvents simpleSaveButton As System.Windows.Forms.Button
    Public WithEvents cbxMailScanLocation As System.Windows.Forms.ComboBox
    'Friend WithEvents lblMailScanLocation As System.Windows.Forms.Label
    Friend WithEvents MainMenu1 As System.Windows.Forms.MainMenu
    Friend WithEvents Tools As System.Windows.Forms.MenuItem
    Friend WithEvents Save As System.Windows.Forms.MenuItem
    Friend WithEvents Send As System.Windows.Forms.MenuItem
    Friend WithEvents CartFull As System.Windows.Forms.MenuItem
    Friend WithEvents Summary As System.Windows.Forms.MenuItem
    Friend WithEvents Presets As System.Windows.Forms.MenuItem
    Friend WithEvents Manifest As System.Windows.Forms.MenuItem
    Friend WithEvents ChangeCart As System.Windows.Forms.MenuItem
    Friend WithEvents CartUpload As System.Windows.Forms.MenuItem
    Friend WithEvents Couter As System.Windows.Forms.MenuItem
    Friend WithEvents CouterReset As System.Windows.Forms.MenuItem
    Friend WithEvents CouterReload As System.Windows.Forms.MenuItem
    Friend WithEvents FlightStatus As System.Windows.Forms.MenuItem
#If deviceType <> "PC" Then
    Friend WithEvents InputPanel1 As Microsoft.WindowsCE.Forms.InputPanel
#End If
    Friend WithEvents Timer1 As System.Windows.Forms.Timer
    Friend WithEvents Timer2 As System.Windows.Forms.Timer
    Friend WithEvents LogTimer1 As System.Windows.Forms.Timer
    Friend WithEvents LogTimer2 As System.Windows.Forms.Timer
    Friend WithEvents lblRejectReason As System.Windows.Forms.Label
    Friend WithEvents txtRejectReason As System.Windows.Forms.TextBox

    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Dim resources As System.Resources.ResourceManager = New System.Resources.ResourceManager(GetType(MailScanDomsForm))
        Me.mainTabControl = New System.Windows.Forms.TabControl
        Me.MailScanTab = New System.Windows.Forms.TabPage
        Me.txtRejectReason = New System.Windows.Forms.TextBox
        Me.lblRejectReason = New System.Windows.Forms.Label
        Me.binFullButton = New System.Windows.Forms.Button
        Me.cbxMailScanLocation = New System.Windows.Forms.ComboBox
        Me.enableCode93CheckBox = New System.Windows.Forms.CheckBox
        Me.mailCarrierCodeLabel = New System.Windows.Forms.Label
        Me.operationComboBox = New System.Windows.Forms.ComboBox
        Me.groupNumberTextBox = New System.Windows.Forms.TextBox
        Me.mailDestinationComboBox = New System.Windows.Forms.ComboBox
        Me.Label4 = New System.Windows.Forms.Label
        Me.flightNumberTextBox = New System.Windows.Forms.TextBox
        Me.Label3 = New System.Windows.Forms.Label
        Me.transferPointTextBox = New System.Windows.Forms.TextBox
        Me.Label2 = New System.Windows.Forms.Label
        Me.operationCodeLabel = New System.Windows.Forms.Label
        Me.saveButton = New System.Windows.Forms.Button
        Me.weightTextBox = New System.Windows.Forms.TextBox
        Me.Label1 = New System.Windows.Forms.Label
        Me.DandRTextBox = New System.Windows.Forms.TextBox
        Me.transferPointLabel = New System.Windows.Forms.Label
        Me.Label8 = New System.Windows.Forms.Label
        Me.batchIDLabel = New System.Windows.Forms.Label
        Me.Label7 = New System.Windows.Forms.Label
        Me.destinationLabel = New System.Windows.Forms.Label
        Me.Label11 = New System.Windows.Forms.Label
        Me.totalWeightLabel = New System.Windows.Forms.Label
        Me.mailPieceCountLabel = New System.Windows.Forms.Label
        Me.mailFormLogoPictureBox = New System.Windows.Forms.PictureBox
        Me.binUploadButton = New System.Windows.Forms.Button
        Me.uploadButton = New System.Windows.Forms.Button
        Me.mailScanSimpleForm = New System.Windows.Forms.TabPage
        Me.simpleSaveButton = New System.Windows.Forms.Button
        Me.mailScanSimpleBinUpload = New System.Windows.Forms.Button
        Me.scanSimpleBinFullButton = New System.Windows.Forms.Button
        Me.mailSimpleScanFormLogoPictureBox = New System.Windows.Forms.PictureBox
        Me.Label6 = New System.Windows.Forms.Label
        Me.Label9 = New System.Windows.Forms.Label
        Me.mailScanSimplePresetListBox = New System.Windows.Forms.ListBox
        Me.mailScanSimpleOperationComboBox = New System.Windows.Forms.ComboBox
        Me.Label15 = New System.Windows.Forms.Label
        Me.Label21 = New System.Windows.Forms.Label
        Me.mailScanSimpleWeightTextBox = New System.Windows.Forms.TextBox
        Me.Label39 = New System.Windows.Forms.Label
        Me.mailScanSimpleDandRTagTextBox = New System.Windows.Forms.TextBox
        Me.mailScanSimpleLargeBarcodeCheckBox = New System.Windows.Forms.CheckBox
        Me.Label45 = New System.Windows.Forms.Label
        Me.Label47 = New System.Windows.Forms.Label
        Me.mailSimpleScanTotalWeightLabel = New System.Windows.Forms.Label
        Me.mailSimplePieceCountLabel = New System.Windows.Forms.Label
        Me.scanSimpleUploadButton = New System.Windows.Forms.Button
        Me.MainMenu1 = New System.Windows.Forms.MainMenu
        Me.Tools = New System.Windows.Forms.MenuItem
        Me.Save = New System.Windows.Forms.MenuItem
        Me.Send = New System.Windows.Forms.MenuItem
        Me.CartFull = New System.Windows.Forms.MenuItem
        Me.Summary = New System.Windows.Forms.MenuItem
        Me.Presets = New System.Windows.Forms.MenuItem
        Me.Manifest = New System.Windows.Forms.MenuItem
        Me.ChangeCart = New System.Windows.Forms.MenuItem
        Me.CartUpload = New System.Windows.Forms.MenuItem
        Me.Couter = New System.Windows.Forms.MenuItem
        Me.CouterReset = New System.Windows.Forms.MenuItem
        Me.CouterReload = New System.Windows.Forms.MenuItem
        Me.FlightStatus = New System.Windows.Forms.MenuItem
        Me.InputPanel1 = New Microsoft.WindowsCE.Forms.InputPanel
        Me.Timer1 = New System.Windows.Forms.Timer
        Me.Timer2 = New System.Windows.Forms.Timer
        Me.LogTimer1 = New System.Windows.Forms.Timer
        Me.LogTimer2 = New System.Windows.Forms.Timer
        '
        'mainTabControl
        '
        Me.mainTabControl.Controls.Add(Me.MailScanTab)
        Me.mainTabControl.Controls.Add(Me.mailScanSimpleForm)
        Me.mainTabControl.SelectedIndex = 0
        Me.mainTabControl.Size = New System.Drawing.Size(247, 328)
        '
        'MailScanTab
        '
        Me.MailScanTab.Controls.Add(Me.txtRejectReason)
        Me.MailScanTab.Controls.Add(Me.lblRejectReason)
        Me.MailScanTab.Controls.Add(Me.binFullButton)
        Me.MailScanTab.Controls.Add(Me.cbxMailScanLocation)
        Me.MailScanTab.Controls.Add(Me.enableCode93CheckBox)
        Me.MailScanTab.Controls.Add(Me.mailCarrierCodeLabel)
        Me.MailScanTab.Controls.Add(Me.operationComboBox)
        Me.MailScanTab.Controls.Add(Me.groupNumberTextBox)
        Me.MailScanTab.Controls.Add(Me.mailDestinationComboBox)
        Me.MailScanTab.Controls.Add(Me.Label4)
        Me.MailScanTab.Controls.Add(Me.flightNumberTextBox)
        Me.MailScanTab.Controls.Add(Me.Label3)
        Me.MailScanTab.Controls.Add(Me.transferPointTextBox)
        Me.MailScanTab.Controls.Add(Me.Label2)
        Me.MailScanTab.Controls.Add(Me.operationCodeLabel)
        Me.MailScanTab.Controls.Add(Me.saveButton)
        Me.MailScanTab.Controls.Add(Me.weightTextBox)
        Me.MailScanTab.Controls.Add(Me.Label1)
        Me.MailScanTab.Controls.Add(Me.DandRTextBox)
        Me.MailScanTab.Controls.Add(Me.transferPointLabel)
        Me.MailScanTab.Controls.Add(Me.Label8)
        Me.MailScanTab.Controls.Add(Me.batchIDLabel)
        Me.MailScanTab.Controls.Add(Me.Label7)
        Me.MailScanTab.Controls.Add(Me.destinationLabel)
        Me.MailScanTab.Controls.Add(Me.Label11)
        Me.MailScanTab.Controls.Add(Me.totalWeightLabel)
        Me.MailScanTab.Controls.Add(Me.mailPieceCountLabel)
        Me.MailScanTab.Controls.Add(Me.mailFormLogoPictureBox)
        Me.MailScanTab.Controls.Add(Me.binUploadButton)
        Me.MailScanTab.Controls.Add(Me.uploadButton)
        Me.MailScanTab.Location = New System.Drawing.Point(4, 4)
        Me.MailScanTab.Size = New System.Drawing.Size(239, 302)
        Me.MailScanTab.Text = "mail scan"
        '
        'txtRejectReason
        '
        Me.txtRejectReason.Location = New System.Drawing.Point(112, 152)
        Me.txtRejectReason.Text = ""
        '
        'lblRejectReason
        '
        Me.lblRejectReason.Location = New System.Drawing.Point(112, 136)
        Me.lblRejectReason.Size = New System.Drawing.Size(100, 16)
        Me.lblRejectReason.Text = "Reject Reason"
        '
        'binFullButton
        '
        Me.binFullButton.Location = New System.Drawing.Point(124, 244)
        Me.binFullButton.Size = New System.Drawing.Size(96, 19)
        Me.binFullButton.Text = "Cart Full"
        '
        'cbxMailScanLocation
        '
        Me.cbxMailScanLocation.Location = New System.Drawing.Point(8, 112)
        Me.cbxMailScanLocation.Size = New System.Drawing.Size(52, 22)
        '
        'enableCode93CheckBox
        '
        Me.enableCode93CheckBox.Checked = True
        Me.enableCode93CheckBox.CheckState = System.Windows.Forms.CheckState.Indeterminate
        Me.enableCode93CheckBox.Location = New System.Drawing.Point(112, 188)
        Me.enableCode93CheckBox.Size = New System.Drawing.Size(100, 21)
        Me.enableCode93CheckBox.Text = "Large Barcode"
        '
        'mailCarrierCodeLabel
        '
        Me.mailCarrierCodeLabel.Location = New System.Drawing.Point(72, 116)
        Me.mailCarrierCodeLabel.Size = New System.Drawing.Size(22, 16)
        Me.mailCarrierCodeLabel.Text = "B6"
        Me.mailCarrierCodeLabel.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'operationComboBox
        '
        Me.operationComboBox.Items.Add("")
        Me.operationComboBox.Items.Add("Possession")
        Me.operationComboBox.Items.Add("Load")
        Me.operationComboBox.Items.Add("Possession & Load")
        Me.operationComboBox.Items.Add("Reroute")
        Me.operationComboBox.Items.Add("Transfer")
        Me.operationComboBox.Items.Add("Unload")
        Me.operationComboBox.Items.Add("Partial Offload")
        Me.operationComboBox.Items.Add("Complete Offload")
        Me.operationComboBox.Items.Add("Return")
        Me.operationComboBox.Items.Add("Delivery")
        Me.operationComboBox.Location = New System.Drawing.Point(96, 24)
        Me.operationComboBox.Size = New System.Drawing.Size(137, 22)
        '
        'groupNumberTextBox
        '
        Me.groupNumberTextBox.Font = New System.Drawing.Font("Arial Narrow", 9.0!, System.Drawing.FontStyle.Regular)
        Me.groupNumberTextBox.Location = New System.Drawing.Point(168, 72)
        Me.groupNumberTextBox.Size = New System.Drawing.Size(64, 21)
        Me.groupNumberTextBox.Text = ""
        '
        'mailDestinationComboBox
        '
        Me.mailDestinationComboBox.Items.Add("ATL")
        Me.mailDestinationComboBox.Items.Add("BOS")
        Me.mailDestinationComboBox.Items.Add("BTV")
        Me.mailDestinationComboBox.Items.Add("BUF")
        Me.mailDestinationComboBox.Items.Add("DEN")
        Me.mailDestinationComboBox.Items.Add("FLL")
        Me.mailDestinationComboBox.Items.Add("IAD")
        Me.mailDestinationComboBox.Items.Add("JFK")
        Me.mailDestinationComboBox.Items.Add("LAS")
        Me.mailDestinationComboBox.Items.Add("LGB")
        Me.mailDestinationComboBox.Items.Add("MCO")
        Me.mailDestinationComboBox.Items.Add("MSY")
        Me.mailDestinationComboBox.Items.Add("OAK")
        Me.mailDestinationComboBox.Items.Add("ONT")
        Me.mailDestinationComboBox.Items.Add("PBI")
        Me.mailDestinationComboBox.Items.Add("ROC")
        Me.mailDestinationComboBox.Items.Add("RSW")
        Me.mailDestinationComboBox.Items.Add("SAN")
        Me.mailDestinationComboBox.Items.Add("SEA")
        Me.mailDestinationComboBox.Items.Add("SJU")
        Me.mailDestinationComboBox.Items.Add("SLC")
        Me.mailDestinationComboBox.Items.Add("SYR")
        Me.mailDestinationComboBox.Items.Add("TPA")
        Me.mailDestinationComboBox.Location = New System.Drawing.Point(168, 112)
        Me.mailDestinationComboBox.Size = New System.Drawing.Size(56, 22)
        '
        'Label4
        '
        Me.Label4.Location = New System.Drawing.Point(112, 96)
        Me.Label4.Size = New System.Drawing.Size(40, 16)
        Me.Label4.Text = "Flight"
        Me.Label4.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'flightNumberTextBox
        '
        Me.flightNumberTextBox.Location = New System.Drawing.Point(112, 112)
        Me.flightNumberTextBox.Size = New System.Drawing.Size(40, 22)
        Me.flightNumberTextBox.Text = ""
        '
        'Label3
        '
        Me.Label3.Location = New System.Drawing.Point(8, 96)
        Me.Label3.Size = New System.Drawing.Size(32, 16)
        Me.Label3.Text = "Loc"
        '
        'transferPointTextBox
        '
        Me.transferPointTextBox.Location = New System.Drawing.Point(8, 152)
        Me.transferPointTextBox.Size = New System.Drawing.Size(48, 22)
        Me.transferPointTextBox.Text = ""
        '
        'Label2
        '
        Me.Label2.Location = New System.Drawing.Point(112, 56)
        Me.Label2.Size = New System.Drawing.Size(48, 16)
        Me.Label2.Text = "Weight"
        '
        'operationCodeLabel
        '
        Me.operationCodeLabel.Location = New System.Drawing.Point(100, 8)
        Me.operationCodeLabel.Size = New System.Drawing.Size(124, 16)
        Me.operationCodeLabel.Text = "Operation Code"
        Me.operationCodeLabel.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'saveButton
        '
        Me.saveButton.Location = New System.Drawing.Point(16, 220)
        Me.saveButton.Size = New System.Drawing.Size(96, 19)
        Me.saveButton.Text = "Save"
        '
        'weightTextBox
        '
        Me.weightTextBox.Location = New System.Drawing.Point(112, 72)
        Me.weightTextBox.Size = New System.Drawing.Size(40, 22)
        Me.weightTextBox.Text = ""
        '
        'Label1
        '
        Me.Label1.Location = New System.Drawing.Point(8, 56)
        Me.Label1.Size = New System.Drawing.Size(80, 16)
        Me.Label1.Text = "D and R Tag"
        '
        'DandRTextBox
        '
        Me.DandRTextBox.Location = New System.Drawing.Point(8, 72)
        Me.DandRTextBox.Size = New System.Drawing.Size(88, 22)
        Me.DandRTextBox.Text = ""
        '
        'transferPointLabel
        '
        Me.transferPointLabel.Location = New System.Drawing.Point(4, 136)
        Me.transferPointLabel.Size = New System.Drawing.Size(68, 16)
        Me.transferPointLabel.Text = "Transfer Pt."
        '
        'Label8
        '
        Me.Label8.Location = New System.Drawing.Point(52, 176)
        Me.Label8.Size = New System.Drawing.Size(48, 16)
        Me.Label8.Text = "T. Wgt"
        '
        'batchIDLabel
        '
        Me.batchIDLabel.Location = New System.Drawing.Point(168, 56)
        Me.batchIDLabel.Size = New System.Drawing.Size(52, 16)
        Me.batchIDLabel.Text = "Cart ID"
        '
        'Label7
        '
        Me.Label7.Location = New System.Drawing.Point(72, 96)
        Me.Label7.Size = New System.Drawing.Size(32, 16)
        Me.Label7.Text = "Carr."
        Me.Label7.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'destinationLabel
        '
        Me.destinationLabel.Location = New System.Drawing.Point(160, 96)
        Me.destinationLabel.Size = New System.Drawing.Size(41, 16)
        Me.destinationLabel.Text = "Dest"
        Me.destinationLabel.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'Label11
        '
        Me.Label11.Location = New System.Drawing.Point(8, 176)
        Me.Label11.Size = New System.Drawing.Size(40, 16)
        Me.Label11.Text = "Cnt"
        Me.Label11.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'totalWeightLabel
        '
        Me.totalWeightLabel.Location = New System.Drawing.Point(56, 192)
        Me.totalWeightLabel.Size = New System.Drawing.Size(45, 20)
        Me.totalWeightLabel.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'mailPieceCountLabel
        '
        Me.mailPieceCountLabel.Location = New System.Drawing.Point(8, 192)
        Me.mailPieceCountLabel.Size = New System.Drawing.Size(35, 20)
        Me.mailPieceCountLabel.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'mailFormLogoPictureBox
        '
        Me.mailFormLogoPictureBox.Image = CType(resources.GetObject("mailFormLogoPictureBox.Image"), System.Drawing.Image)
        Me.mailFormLogoPictureBox.Location = New System.Drawing.Point(0, 8)
        Me.mailFormLogoPictureBox.Size = New System.Drawing.Size(92, 48)
        Me.mailFormLogoPictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        '
        'binUploadButton
        '
        Me.binUploadButton.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold)
        Me.binUploadButton.Location = New System.Drawing.Point(16, 244)
        Me.binUploadButton.Size = New System.Drawing.Size(96, 19)
        Me.binUploadButton.Text = "Cart Upload"
        '
        'uploadButton
        '
        Me.uploadButton.Location = New System.Drawing.Point(124, 220)
        Me.uploadButton.Size = New System.Drawing.Size(96, 19)
        Me.uploadButton.Text = "Send"
        '
        'mailScanSimpleForm
        '
        Me.mailScanSimpleForm.Controls.Add(Me.simpleSaveButton)
        Me.mailScanSimpleForm.Controls.Add(Me.mailScanSimpleBinUpload)
        Me.mailScanSimpleForm.Controls.Add(Me.scanSimpleBinFullButton)
        Me.mailScanSimpleForm.Controls.Add(Me.mailSimpleScanFormLogoPictureBox)
        Me.mailScanSimpleForm.Controls.Add(Me.Label6)
        Me.mailScanSimpleForm.Controls.Add(Me.Label9)
        Me.mailScanSimpleForm.Controls.Add(Me.mailScanSimplePresetListBox)
        Me.mailScanSimpleForm.Controls.Add(Me.mailScanSimpleOperationComboBox)
        Me.mailScanSimpleForm.Controls.Add(Me.Label15)
        Me.mailScanSimpleForm.Controls.Add(Me.Label21)
        Me.mailScanSimpleForm.Controls.Add(Me.mailScanSimpleWeightTextBox)
        Me.mailScanSimpleForm.Controls.Add(Me.Label39)
        Me.mailScanSimpleForm.Controls.Add(Me.mailScanSimpleDandRTagTextBox)
        Me.mailScanSimpleForm.Controls.Add(Me.mailScanSimpleLargeBarcodeCheckBox)
        Me.mailScanSimpleForm.Controls.Add(Me.Label45)
        Me.mailScanSimpleForm.Controls.Add(Me.Label47)
        Me.mailScanSimpleForm.Controls.Add(Me.mailSimpleScanTotalWeightLabel)
        Me.mailScanSimpleForm.Controls.Add(Me.mailSimplePieceCountLabel)
        Me.mailScanSimpleForm.Controls.Add(Me.scanSimpleUploadButton)
        Me.mailScanSimpleForm.Location = New System.Drawing.Point(4, 4)
        Me.mailScanSimpleForm.Size = New System.Drawing.Size(239, 302)
        Me.mailScanSimpleForm.Text = "mail scan simple"
        '
        'simpleSaveButton
        '
        Me.simpleSaveButton.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold)
        Me.simpleSaveButton.Location = New System.Drawing.Point(24, 144)
        Me.simpleSaveButton.Size = New System.Drawing.Size(88, 19)
        Me.simpleSaveButton.Text = "Save"
        '
        'mailScanSimpleBinUpload
        '
        Me.mailScanSimpleBinUpload.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold)
        Me.mailScanSimpleBinUpload.Location = New System.Drawing.Point(24, 168)
        Me.mailScanSimpleBinUpload.Size = New System.Drawing.Size(88, 19)
        Me.mailScanSimpleBinUpload.Text = "Cart Upload"
        '
        'scanSimpleBinFullButton
        '
        Me.scanSimpleBinFullButton.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold)
        Me.scanSimpleBinFullButton.Location = New System.Drawing.Point(128, 168)
        Me.scanSimpleBinFullButton.Size = New System.Drawing.Size(88, 19)
        Me.scanSimpleBinFullButton.Text = "Cart Full"
        '
        'mailSimpleScanFormLogoPictureBox
        '
        Me.mailSimpleScanFormLogoPictureBox.Location = New System.Drawing.Point(0, 8)
        Me.mailSimpleScanFormLogoPictureBox.Size = New System.Drawing.Size(100, 48)
        Me.mailSimpleScanFormLogoPictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        '
        'Label6
        '
        Me.Label6.Location = New System.Drawing.Point(14, 208)
        Me.Label6.Size = New System.Drawing.Size(227, 13)
        Me.Label6.Text = "                      ID        dst/flgt"
        '
        'Label9
        '
        Me.Label9.Location = New System.Drawing.Point(15, 192)
        Me.Label9.Size = New System.Drawing.Size(225, 17)
        Me.Label9.Text = "org dst   flgt  cart        new"
        '
        'mailScanSimplePresetListBox
        '
        Me.mailScanSimplePresetListBox.Items.Add("12345678901234567890123456789012345")
        Me.mailScanSimplePresetListBox.Location = New System.Drawing.Point(0, 224)
        Me.mailScanSimplePresetListBox.Size = New System.Drawing.Size(236, 44)
        '
        'mailScanSimpleOperationComboBox
        '
        Me.mailScanSimpleOperationComboBox.Items.Add("")
        Me.mailScanSimpleOperationComboBox.Items.Add("Possession")
        Me.mailScanSimpleOperationComboBox.Items.Add("Load")
        Me.mailScanSimpleOperationComboBox.Items.Add("Possession & Load")
        Me.mailScanSimpleOperationComboBox.Items.Add("Reroute")
        Me.mailScanSimpleOperationComboBox.Items.Add("Transfer")
        Me.mailScanSimpleOperationComboBox.Items.Add("Unload")
        Me.mailScanSimpleOperationComboBox.Items.Add("Partial Offload")
        Me.mailScanSimpleOperationComboBox.Items.Add("Complete Offload")
        Me.mailScanSimpleOperationComboBox.Items.Add("Delivery")
        Me.mailScanSimpleOperationComboBox.Location = New System.Drawing.Point(112, 24)
        Me.mailScanSimpleOperationComboBox.Size = New System.Drawing.Size(120, 22)
        '
        'Label15
        '
        Me.Label15.Location = New System.Drawing.Point(144, 56)
        Me.Label15.Size = New System.Drawing.Size(80, 16)
        Me.Label15.Text = "Weight"
        Me.Label15.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'Label21
        '
        Me.Label21.Location = New System.Drawing.Point(104, 8)
        Me.Label21.Size = New System.Drawing.Size(132, 16)
        Me.Label21.Text = "Operation Code"
        Me.Label21.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'mailScanSimpleWeightTextBox
        '
        Me.mailScanSimpleWeightTextBox.Location = New System.Drawing.Point(144, 72)
        Me.mailScanSimpleWeightTextBox.Size = New System.Drawing.Size(80, 22)
        Me.mailScanSimpleWeightTextBox.Text = ""
        '
        'Label39
        '
        Me.Label39.Location = New System.Drawing.Point(16, 56)
        Me.Label39.Size = New System.Drawing.Size(94, 16)
        Me.Label39.Text = "D and R Tag"
        Me.Label39.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'mailScanSimpleDandRTagTextBox
        '
        Me.mailScanSimpleDandRTagTextBox.Location = New System.Drawing.Point(8, 72)
        Me.mailScanSimpleDandRTagTextBox.Size = New System.Drawing.Size(110, 22)
        Me.mailScanSimpleDandRTagTextBox.Text = ""
        '
        'mailScanSimpleLargeBarcodeCheckBox
        '
        Me.mailScanSimpleLargeBarcodeCheckBox.Checked = True
        Me.mailScanSimpleLargeBarcodeCheckBox.CheckState = System.Windows.Forms.CheckState.Indeterminate
        Me.mailScanSimpleLargeBarcodeCheckBox.Location = New System.Drawing.Point(136, 120)
        Me.mailScanSimpleLargeBarcodeCheckBox.Size = New System.Drawing.Size(104, 21)
        Me.mailScanSimpleLargeBarcodeCheckBox.Text = "Large Barcode"
        '
        'Label45
        '
        Me.Label45.Location = New System.Drawing.Point(48, 104)
        Me.Label45.Size = New System.Drawing.Size(64, 16)
        Me.Label45.Text = "Tot. Wgt"
        Me.Label45.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'Label47
        '
        Me.Label47.Location = New System.Drawing.Point(3, 104)
        Me.Label47.Size = New System.Drawing.Size(40, 16)
        Me.Label47.Text = "Cnt"
        Me.Label47.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'mailSimpleScanTotalWeightLabel
        '
        Me.mailSimpleScanTotalWeightLabel.Location = New System.Drawing.Point(64, 120)
        Me.mailSimpleScanTotalWeightLabel.Size = New System.Drawing.Size(40, 20)
        Me.mailSimpleScanTotalWeightLabel.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'mailSimplePieceCountLabel
        '
        Me.mailSimplePieceCountLabel.Location = New System.Drawing.Point(11, 120)
        Me.mailSimplePieceCountLabel.Size = New System.Drawing.Size(24, 20)
        '
        'scanSimpleUploadButton
        '
        Me.scanSimpleUploadButton.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold)
        Me.scanSimpleUploadButton.Location = New System.Drawing.Point(128, 144)
        Me.scanSimpleUploadButton.Size = New System.Drawing.Size(88, 19)
        Me.scanSimpleUploadButton.Text = "Send"
        '
        'MainMenu1
        '
        Me.MainMenu1.MenuItems.Add(Me.Tools)
        '
        'Tools
        '
        Me.Tools.MenuItems.Add(Me.Save)
        Me.Tools.MenuItems.Add(Me.Send)
        Me.Tools.MenuItems.Add(Me.CartFull)
        Me.Tools.MenuItems.Add(Me.Summary)
        Me.Tools.MenuItems.Add(Me.Presets)
        Me.Tools.MenuItems.Add(Me.Manifest)
        Me.Tools.MenuItems.Add(Me.ChangeCart)
        Me.Tools.MenuItems.Add(Me.CartUpload)
        Me.Tools.MenuItems.Add(Me.Couter)
        Me.Tools.MenuItems.Add(Me.FlightStatus)
        Me.Tools.Text = "Tools"
        '
        'Save
        '
        Me.Save.Text = "Save"
        '
        'Send
        '
        Me.Send.Text = "Send"
        '
        'CartFull
        '
        Me.CartFull.Text = "Cart Full"
        '
        'Summary
        '
        Me.Summary.Text = "Summary"
        '
        'Presets
        '
        Me.Presets.Text = "Presets"
        '
        'Manifest
        '
        Me.Manifest.Text = "Manifest"
        '
        'ChangeCart
        '
        Me.ChangeCart.Text = "Change Cart"
        '
        'CartUpload
        '
        Me.CartUpload.Text = "Cart Upload"
        '
        'Couter
        '
        Me.Couter.MenuItems.Add(Me.CouterReset)
        Me.Couter.MenuItems.Add(Me.CouterReload)
        Me.Couter.Text = "Counter"
        '
        'CouterReset
        '
        Me.CouterReset.Text = "Reset"
        '
        'CouterReload
        '
        Me.CouterReload.Text = "Reload"
        '
        'FlightStatus
        '
        Me.FlightStatus.Text = "Flight Status"
        '
        'Timer1
        '
        Me.Timer1.Interval = 10000
        '
        'Timer2
        '
        Me.Timer2.Interval = 60000
        '
        'LogTimer1
        '
        Me.LogTimer1.Interval = 10000
        '
        'LogTimer2
        '
        Me.LogTimer2.Interval = 60000
        '
        'MailScanDomsForm
        '
        Me.ClientSize = New System.Drawing.Size(247, 321)
        Me.ControlBox = False
        Me.Controls.Add(Me.mainTabControl)
        Me.Menu = Me.MainMenu1
        Me.Text = "USPS Mail"

    End Sub

    Private Sub readerFormOnLoad(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        If productionDistribution Then
            operationCodeLabel.ForeColor = Color.Black
            operationCodeLabel.Text = "Operation Code"
            Label21.ForeColor = Color.Black
            Label21.Text = "Operation Code"
        Else
            operationCodeLabel.ForeColor = Color.Red
            operationCodeLabel.Text = "DO NOT DISTRIBUTE"
            Label21.ForeColor = Color.Red
            Label21.Text = "DO NOT DISTRIBUTE"
        End If

        Dim result As String

        Me.loadLocationComboBox()

        selectMailScanTabPage(Me)

        Dim test As Integer

        If emulatingPlatform Then
            test = 1
        Else
            test = scannerLib.SystemPowerStatus()
        End If

        'If test <> 1 Then
        '    deviceInCradle = False
        '    TagTrakGlobals.backgroundFtpTimer.cradleTickCount = System.Int32.MaxValue
        'Else
        '    deviceInCradle = True
        '    TagTrakGlobals.backgroundFtpTimer.cradleTickCount = 6 * 30
        'End If

        Me.enableCode93CheckBox.ThreeState = userSpecRecord.triStateLargeBarcodeCheckBox

        Me.enableCode93CheckBox.Checked = False

        If emulatingPlatform Then Exit Sub

#If deviceType = "PC" Then
        exit sub
#End If

#If deviceType = "Symbol" Then
        'symbolReader.MyReader.StartRead()
#End If

        removeExpiredBackupResditFiles()

        scannerLib.Code128Active()

        Util.turnScannerOff(7)

        backgroundFtpTimer.Enabled = True

        ignoreOperationComboBoxChange = False

        readerFormLoaded = True

        Timer1.Enabled = False
        Timer2.Enabled = False

    End Sub

    Private Function validateDestinationCode(ByRef destinationCode As String) As Boolean

        If Length(destinationCode) = 0 Or destinationCode Is Nothing Then
            Util.warning("Missing Destination Code, Required For This Operation", MsgBoxStyle.Exclamation, "Missing Destination Code")
            Return False
        End If

        If Length(destinationCode) < 3 Then
            Util.warning("Required Destination Code Is Invalid: Too Few Characters", MsgBoxStyle.Exclamation, "Invalid Destination Code")
            Return False
        End If

        If Length(destinationCode) > 3 Then
            Util.warning("Required Destination Code Is Invalid: Too Many Characters", MsgBoxStyle.Exclamation, "Invalid Destination Code")
            Return False
        End If

        Return True

    End Function

    Private Function validateTransferPointCode(ByRef transferPointCode As String) As Boolean

        If Length(transferPointCode) = 0 Or transferPointCode Is Nothing Then
            Util.warning("Missing Transfer Point Code, Required For This Operation", MsgBoxStyle.Exclamation, "Missing Transfer Point Code")
            Return False
        End If

        If Length(transferPointCode) < 3 Then
            Util.warning("Required Transfer Point Code Is Invalid: Too Few Characters", MsgBoxStyle.Exclamation, "Invalid Destination Code")
            Return False
        End If

        If Length(transferPointCode) > 3 Then
            Util.warning("Required Transfer Point  Code Is Invalid: Too Many Characters", MsgBoxStyle.Exclamation, "Invalid Destination Code")
            Return False
        End If

        Return True

    End Function

    Private Sub saveButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles saveButton.Click, Save.Click

        flag = True

        Dim result As String

        logScanSequenceEvent(20001, "Save Button exit to process transaction")

        processDomsMailScanTransaction()

#If deviceType <> "PC" Then
        DandRTextBox.Text = ""
        weightTextBox.Text = ""
#End If

        logScanSequenceEvent(20002, "Save Button handler exits")

    End Sub

    Dim previousOperation As String = ""

    Private Sub clearAllTextBoxes()
        DandRTextBox.Text = ""
        weightTextBox.Text = ""
        groupNumberTextBox.Text = ""
        mailDestinationComboBox.SelectedIndex = -1
        mailDestinationComboBox.Text = ""
        flightNumberTextBox.Text = ""
        transferPointTextBox.Text = ""
        txtRejectReason.Text = ""

        Me.mailScanSimplePresetListBox.SelectedIndex = -1

    End Sub

    Private Sub handleOperationComboBoxSelectedIndexChanged()

        Dim currentOperation As String

        If isNonNullString(operationComboBox.Text) Then
            currentOperation = operationComboBox.Text
        Else
            currentOperation = ""
        End If

        If currentOperation = previousOperation Then
            Exit Sub
        End If

        logOperationChange(1)

        If Not ignoreOperationComboBoxChange Then

            Dim result As MsgBoxResult = MsgBox("You Are Changing The Type Of Scan Operation. Please Confirm!", MsgBoxStyle.YesNo, "Confirm Operation Change")

            If result = MsgBoxResult.No Then

                If isNonNullString(previousOperation) Then
                    operationComboBox.SelectedItem = previousOperation
                Else
                    operationComboBox.SelectedIndex = 0
                    previousOperation = ""
                    operationComboBox.Text = ""
                End If

                Exit Sub

            End If

        End If

        previousOperation = currentOperation

        If Not isNonNullString(currentOperation) Then

            Util.turnScannerOff(8)

            'Added by MX to clear counter
            totalWeightLabel.Text = 0
            mailPieceCountLabel.Text = 0

            Exit Sub

        Else

            Util.turnScannerOn(9)

        End If

#If deviceType = "PC" Then

        If isNonNullString(DandRTextBox.Text) Then

            If DandRTextBox.Text <> "DUMMYSCANN" Then
                clearAllTextBoxes()
            End If

        Else
            clearAllTextBoxes()
        End If
#Else
        clearAllTextBoxes()
#End If

        txtRejectReason.Text = ""
        txtRejectReason.Visible = False
        lblRejectReason.Visible = False

        Application.DoEvents()

        Select Case userSpecRecord.operationsMapping.GetOperation(currentOperation)

            Case "Possession"
                transferPointTextBox.Enabled = False
                transferPointLabel.Enabled = False
                mailDestinationComboBox.SelectedIndex = 0
            Case "Load"
                transferPointTextBox.Enabled = False
                transferPointLabel.Enabled = False
            Case "Possession & Load"
                transferPointTextBox.Enabled = False
                transferPointLabel.Enabled = False
            Case "Reroute"
                transferPointTextBox.Enabled = False
                transferPointLabel.Enabled = False
            Case "Transfer"
                transferPointTextBox.Enabled = True
                transferPointLabel.Enabled = True
            Case "Unload"
                transferPointTextBox.Enabled = False
                transferPointLabel.Enabled = False
            Case "Partial Offload"
                transferPointTextBox.Enabled = False
                transferPointLabel.Enabled = False
            Case "Complete Offload"
                transferPointTextBox.Enabled = False
                transferPointLabel.Enabled = False
            Case "Return"
                transferPointTextBox.Enabled = False
                transferPointLabel.Enabled = False

                txtRejectReason.Visible = True
                lblRejectReason.Visible = True

            Case "Delivery"
                transferPointTextBox.Enabled = False
                transferPointLabel.Enabled = False

        End Select

        'Added by MX to clear counter
        totalWeightLabel.Text = 0
        mailPieceCountLabel.Text = 0

        Application.DoEvents()

    End Sub


    Private Sub operationComboBox_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles operationComboBox.SelectedIndexChanged

        'Added by MX
        If operationComboBox.SelectedIndex > 0 Then
            If userSpecRecord.screenTimeOutValue > 0 Then
                Timer1.Enabled = True
                Timer2.Interval = userSpecRecord.screenTimeOutValue * 60000
            End If
        Else
            Timer1.Enabled = False
            Timer2.Enabled = False
        End If

        handleOperationComboBoxSelectedIndexChanged()

    End Sub

    '' Process domestic scan data. This called when a bar code is scanner for processing for domestic.
    Public Sub ProcessScanData(ByRef readerString As String, ByVal symbology As Integer)
        '' Domestic bar code:
        '' MCN F 99ZC BX 01
        '' a   b c    d  e
        ''
        '' a. Day of month and SFC combination
        '' b. Mail class
        '' c. Route code (contains carrier)
        '' d. Unique identifier
        '' e. Weight


        Dim MessageToDisplay As String

        '' If there is a pattern defined for a cart id
        If isNonNullString(userSpecRecord.MailCartIdPattern) Then
            '' If the scanned bar code matches this pattern
            If System.Text.RegularExpressions.Regex.IsMatch(readerString, userSpecRecord.MailCartIdPattern) Then
                '' Save the cart id
                Me.groupNumberTextBox.Text = readerString
                Exit Sub
            End If
        End If

        '' Make sure the bar code is either 12 or 10 characters long
        If Len(readerString) <> 12 And Len(readerString) <> 10 Then
            MsgBox("Invalid Mail Tag Bar Code: Must be either 10 or 12 characters long", MsgBoxStyle.Exclamation, "Invalid Scan")
            Exit Sub
        End If

        saveButton.Enabled = False
        simpleSaveButton.Enabled = False

        DandRTextBoxTextChangedEnabled = False
        weightTextBoxTextChangedEnabled = False

        DandRTextBox.Text = ""
        weightTextBox.Text = ""

        DandRTextBoxTextChangedEnabled = True
        weightTextBoxTextChangedEnabled = True

        DandRTextBox.Text = Substring(readerString, 0, 10)

        '' Verify the length of DandRTextBox.Text is 10
        Util.scanSequenceVerify(Length(DandRTextBox.Text) = 10, 2)

        '' Check the D and R tag for sanity
        If Not Util.isValidDandRTag(DandRTextBox.Text) Then
            MsgBox("Invalid D and R Tag Format. Scan Ignored", MsgBoxStyle.Exclamation, "Invalid D and R Tag")
            Exit Sub
        End If

        '' Handle large bar codes
        If enableCode93CheckBox.Checked Then
            logScanSequenceEvent(10003, "HandleData checking code 93")
            If Length(readerString) = 10 Then
                '' If length is 10, ask for weight

                'MailScanFormRepository.MailScanGetWeightForm.Show()

                'If MailScanFormRepository.MailScanGetWeightForm.DialogResult = DialogResult.OK Then
                '    weightTextBox.Text = MailScanFormRepository.MailScanGetWeightForm.weight
                'End If

                Dim frmGetWeight As New MailScanGetWeightForm(Me)
                frmGetWeight.ShowDialog()
                frmGetWeight.Dispose()

            ElseIf Length(readerString) = 12 Then
                '' If length is 12 extract weight

                weightTextBox.Text = Substring(readerString, 10, 2)
                '' Validate weight for sanity
                If Not Util.isValidWeight(weightTextBox.Text) Then
                    MsgBox("Invalid weight in D and R Tag: mail scan ignored", MsgBoxStyle.Exclamation, "Invalid D and R Tag")
                    Exit Sub
                End If

            Else
                '' Length is not 10 or 12, invalid
                Util.systemError("Invalid reader string length")
                Stop
            End If

        Else
            '' Not using code 93, MUST be 12 characters long
            If Length(readerString) <> 12 Then
                MsgBox("Invalid D and R Tag: Too few characters.", MsgBoxStyle.Exclamation, "Invalid D and R Tag")
                Exit Sub
            End If

            '' Extract weight
            weightTextBox.Text = Substring(readerString, 10, 2)

        End If

        '' Activate/deactivate code 93 mode on scanner based on "Large barcode" check box
        resetCode93CheckBox()

        logScanSequenceEvent(10003, "HandleData exit to process transaction")

        processDomsMailScanTransaction()

    End Sub

    Private Sub returnToScanPageButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        selectMailScanTabPage(Me)
    End Sub


    Private Sub UploadButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles uploadButton.Click, Send.Click

        Me.DialogResult = TagTrakGlobals.uploadButtonClick()

        If userSpecRecord.screenBlankAfterSend = True Then

            Me.ResetScreen()

        End If

        If Me.DialogResult = DialogResult.Abort Then
            Me.Close()
        End If

    End Sub

    Private Sub destinationComboBox_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mailDestinationComboBox.SelectedIndexChanged

        Dim destinationCode As String = mailDestinationComboBox.Text
        Dim operationCode As String = userSpecRecord.operationsMapping.GetOperation(operationComboBox.Text)

        Util.verify(Length(scanLocation.currentLocation) >= 3, 10)

        Dim locationCode As String = Substring(scanLocation.currentLocation, 0, 3)

        If Not isNonNullString(destinationCode) Then Exit Sub
        If Not isNonNullString(operationCode) Then Exit Sub
        If Not isNonNullString(locationCode) Then Exit Sub

        destinationCode = destinationCode.ToUpper
        locationCode = locationCode.ToUpper
        operationCode = operationCode.ToUpper

        If destinationCode = locationCode Then

            If operationCode = "LOAD" Or operationCode = "POSSESSION & LOAD" Then

                MsgBox("Destination Cannot Be The Same As Origin or Current Location For Load Or Possession and Load Operations", MsgBoxStyle.Exclamation, "Invalid Destination Code")
                mailDestinationComboBox.Text = ""
                mailDestinationComboBox.SelectedIndex = -1

            End If

        End If

        flag = True

    End Sub

    Private Sub flightNumberTextBox_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles flightNumberTextBox.TextChanged

        'If Not currentSummaryFileIsValid Then
        '    Summary.Enabled = True
        'Else
        '    If Length(flightNumberTextBox.Text) > 0 Then
        '        Summary.Enabled = True
        '    Else
        '        Summary.Enabled = False
        '    End If
        'End If

        FlightScheduleError.DontAsk = False

        currentScanScreenPopulatedFromPreset = False

        flag = True

    End Sub


    Private Sub closeoutReaderOperations()
        If emulatingPlatform Then Exit Sub

        scanReader.Disable()

    End Sub

    Private Sub readerForm_Closing(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles MyBase.Closing

#If deviceType = "PC" Then
        Exit Sub
#End If

        'If Me.DialogResult = DialogResult.Abort Then
        '    closeoutReaderOperations()
        '    Exit Sub
        'End If

        'Me.DialogResult = AdminFormRepository.adminLoginForm.ShowDialog()

        'If DialogResult = DialogResult.Abort Then
        '    Exit Sub
        'End If
        closeoutReaderOperations()

        'e.Cancel = True

    End Sub

    Private Sub DandRTextBox_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DandRTextBox.TextChanged

        If Not DandRTextBoxTextChangedEnabled Then Exit Sub

        setSaveButtonStatus()

        flag = True

    End Sub

    Private Sub weightTextBox_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles weightTextBox.TextChanged

        If Not weightTextBoxTextChangedEnabled Then Exit Sub

        setSaveButtonStatus()

        flag = True

    End Sub

    Public Sub setSaveButtonStatus()

        If Util.isValidDandRTag(DandRTextBox.Text) And Util.isValidWeight(weightTextBox.Text) Then
            Save.Enabled = True
            saveButton.Enabled = True
            simpleSaveButton.Enabled = True
        Else
            Save.Enabled = False
            saveButton.Enabled = False
            simpleSaveButton.Enabled = False
        End If

    End Sub


    Private Sub summaryButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Summary.Click
        MailScanFormRepository.MailScanManifestSummaryForm.loadSummaryInformation()
        MailScanFormRepository.MailScanManifestSummaryForm.Show()
        'Me.resetOperationComboBoxWithoutWarning()
    End Sub

    Private Sub scanButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)

        selectMailScanTabPage(Me)

    End Sub

    Private Sub exitButton_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs)

        resetOperationComboBoxWithoutWarning()

        Me.DialogResult = AdminFormRepository.adminLoginForm.ShowDialog()
        If Me.DialogResult = DialogResult.Abort Then Me.Close()

    End Sub

    Dim withinUploadReminderTimer As Boolean = False



    Dim enable93CheckBoxState As Integer = 0

    Private Sub processResetCode93CheckBox()

        If userSpecRecord.triStateLargeBarcodeCheckBox Then

            If enableCode93CheckBox.CheckState = CheckState.Checked Then

                If Not emulatingPlatform Then
                    scannerLib.Code93Active()
                End If

                Exit Sub

            End If

        End If

        enableCode93CheckBox.Checked = False
        enable93CheckBoxState = 0

        If emulatingPlatform Then Exit Sub

        scannerLib.Code93NotActive()

    End Sub

    Dim withinEnableCode93CheckBoxEvent As Boolean = False

    Private Sub resetCode93CheckBox()

        If withinEnableCode93CheckBoxEvent Then Exit Sub

        withinEnableCode93CheckBoxEvent = True
        processResetCode93CheckBox()
        withinEnableCode93CheckBoxEvent = False

    End Sub

    Private Sub processEnable93CheckBoxEvent()

        If Not userSpecRecord.triStateLargeBarcodeCheckBox Then

            If emulatingPlatform Then Exit Sub

            If enableCode93CheckBox.Checked Then
                scannerLib.Code93Active()
            Else
                scannerLib.Code93NotActive()
            End If

            Exit Sub

        End If

        enable93CheckBoxState = (enable93CheckBoxState + 1) Mod 3

        If enable93CheckBoxState = 0 Then

            enableCode93CheckBox.Checked = False

            If emulatingPlatform Then Exit Sub

            scannerLib.Code93NotActive()

            Exit Sub

        ElseIf enable93CheckBoxState = 1 Then

            'enableCode93CheckBox.Checked = True
            enableCode93CheckBox.CheckState = CheckState.Indeterminate

            If emulatingPlatform Then Exit Sub

            scannerLib.Code93Active()

            Exit Sub

        ElseIf enable93CheckBoxState = 2 Then
            'enableCode93CheckBox.Checked = True
            enableCode93CheckBox.CheckState = CheckState.Checked

            If emulatingPlatform Then Exit Sub

            scannerLib.Code93Active()

            Exit Sub

        End If

    End Sub

    Private Sub enableCode93CheckBox_CheckStateChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles enableCode93CheckBox.CheckStateChanged

        If withinEnableCode93CheckBoxEvent Then Exit Sub

        withinEnableCode93CheckBoxEvent = True
        processEnable93CheckBoxEvent()
        withinEnableCode93CheckBoxEvent = False

        flag = True

    End Sub

    Dim withinLocationComboBoxSelectedIndexChanged As Boolean = False

    Dim cbxMailScanLocationSelectedIndexChanged As Boolean = False

    Private Sub cbxMailScanLocation_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cbxMailScanLocation.SelectedIndexChanged

        If TagTrakGlobals.scanLocation.ignoreLocationChange Then Return

        If cbxMailScanLocationSelectedIndexChanged Then Exit Sub

        cbxMailScanLocationSelectedIndexChanged = True

        TagTrakGlobals.scanLocation.update(Me.cbxMailScanLocation.Text, Me.cbxMailScanLocation)

        cbxMailScanLocationSelectedIndexChanged = False

        flag = True

    End Sub


    Private Sub groupNumberTextBox_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles groupNumberTextBox.TextChanged
        currentScanScreenPopulatedFromPreset = False

        flag = True

    End Sub

    Private Sub changeBin_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ChangeCart.Click

        MailScanFormRepository.MailScanBinChangeForm.init(Me)
        MailScanFormRepository.MailScanBinChangeForm.Show()

    End Sub

    Private Sub binUploadButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles binUploadButton.Click, CartUpload.Click

        If currentScanScreenPopulatedFromPreset Then

            Dim result As MsgBoxResult

            result = MsgBox("Create a cart upload record for this preset?", MsgBoxStyle.YesNo, "Create Cart Upload Record?")

            If result = MsgBoxResult.Yes Then

                If Not Util.isValidBatchID(Trim(Me.groupNumberTextBox.Text)) Then

                    MsgBox("Invalid Cart ID", MsgBoxStyle.Exclamation, "Invalid Cart ID")

                    Exit Sub

                End If

                Dim batchID As String = Trim(Me.groupNumberTextBox.Text)

                If Not Util.isValidFlightNumber(Trim(Me.flightNumberTextBox.Text)) Then

                    MsgBox("Invalid Flight Number", MsgBoxStyle.Exclamation, "Invalid Flight Number")
                    Exit Sub

                End If

                Dim flightNumber = Trim(Me.flightNumberTextBox.Text).PadLeft(4, "0")

                If Not Util.isValidLocation(Me.mailDestinationComboBox.Text) Then

                    MsgBox("A valid destination must be specified", MsgBoxStyle.Exclamation, "Invalid Destination")
                    Exit Sub

                End If

                Dim destinationCode = Me.mailDestinationComboBox.Text

                Dim binUploadRecord As New binUploadRecordClass(batchID, flightNumber, destinationCode, "M")

                Dim writeResult As String

                writeResult = binUploadRecord.write(binUploadFilePath)

                If writeResult <> "OK" Then

                    MsgBox("Write of cart upload record failed: " & result, MsgBoxStyle.Exclamation, "Write Of Cart Upload Record Failed")

                    Exit Sub

                End If

                MsgBox("New Cart Upload Record Created", MsgBoxStyle.Information, "New Cart Upload Record Created")

                Exit Sub

            End If

        End If

        MailScanFormRepository.MailScanBinUploadForm.init(Me)
        MailScanFormRepository.MailScanBinUploadForm.Show()

    End Sub


    Private Sub mainTabControl_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mainTabControl.SelectedIndexChanged

        logReaderFormTabChanged(1)

    End Sub

    Private Sub manifestButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Manifest.Click

        'Added by MX
        MailScanFormRepository.MailScanManifestForm.scanType = "M"
        MailScanFormRepository.MailScanManifestForm.Show()

    End Sub

    Public Sub resetOperationComboBoxWithoutWarning()
        ignoreOperationComboBoxChange = True

        operationComboBox.SelectedIndex = 0
        operationComboBox.Text = ""
        previousOperation = ""

        Util.turnScannerOff(1)

        Me.DandRTextBox.Text = ""
        Me.weightTextBox.Text = ""

        ignoreOperationComboBoxChange = False
    End Sub

    Private Function getValidResditFilePath() As String

        Dim resditFilePath As String

        If primaryDataFileDirectoryIsValid Then

            resditFilePath = scanDataPrimaryFilePath

            If File.Exists(resditFilePath) Then
                Return resditFilePath
            Else
                Return Nothing
            End If

        ElseIf secondaryDataFileDirectoryIsValid Then

            resditFilePath = scanDataSecondaryFilePath

            If File.Exists(resditFilePath) Then
                Return resditFilePath
            Else
                Return Nothing
            End If

        End If

        Return Nothing

    End Function

    Public Sub loadLocationComboBox()

        Me.cbxMailScanLocation.Items.Clear()
        'Me.cargoLocationComboBox.Items.Clear()

        Dim city As String

        For Each city In userSpecRecord.cityList
            Me.cbxMailScanLocation.Items.Add(city)
            'Me.cargoLocationComboBox.Items.Add(city)
        Next

        ' MDD Test

        If scanLocation Is Nothing Then
            Me.cbxMailScanLocation.SelectedItem = userSpecRecord.defaultLocation
            'Me.cargoLocationComboBox.SelectedItem = userSpecRecord.defaultLocation
        Else
            Me.cbxMailScanLocation.SelectedItem = scanLocation.currentLocation
            'Me.cargoLocationComboBox.SelectedItem = scanLocation
        End If

    End Sub

    Public Sub loadOperationComboBox()

        Me.operationComboBox.Items.Clear()

        Dim operation As String

        Me.operationComboBox.Items.Add("")

        For Each operation In userSpecRecord.operationsList
            '' If there's a mapping for the current operation use it
            Me.operationComboBox.Items.Add(userSpecRecord.operationsMapping.GetMappedOperation(operation))
        Next

    End Sub

    Private Sub resetCountersMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CouterReset.Click

        Dim logMaintenanceThread As New System.threading.Thread(AddressOf logMaintenanceThreadSub)

        logMaintenanceThread.Priority = Threading.ThreadPriority.Lowest

        logMaintenanceThread.Start()

        Dim response As MsgBoxResult

        response = MsgBox("This Will Reset The Location Counters Only", MsgBoxStyle.OKCancel, "Confirm Counter Reset")

        If response = MsgBoxResult.Cancel Then Exit Sub

        If currentTabPage = "mail scan" Or currentTabPage = "mail scan simple" Then
            totalWeightLabel.Text = 0
            mailPieceCountLabel.Text = 0
        End If

    End Sub

    'Private Sub reloadMailPieceCounts()

    '    Dim countFilePath As String = deviceNonVolatileMemoryDirectory & backSlash & "MailScanPieceCounts.txt"

    '    Dim totalWeight As Integer = 0
    '    Dim totalCount As Integer = 0

    '    If Not File.Exists(countFilePath) Then

    '        Exit Sub

    '    End If

    '    Dim countFileInputStream As StreamReader

    '    Try
    '        countFileInputStream = New StreamReader(countFilePath)
    '    Catch ex As Exception
    '        MsgBox("Unable to open count file in order to reset mail counters: " & ex.Message, MsgBoxStyle.Exclamation, "Open On Resdit File Failed.")
    '        Exit Sub
    '    End Try

    '    Dim countFileRecord As String

    '    Try
    '        countFileRecord = countFileInputStream.ReadLine
    '    Catch ex As Exception
    '        countFileInputStream.Close()
    '        MsgBox("Unable to read count file in order to reset mail counters: " & ex.Message, MsgBoxStyle.Exclamation, "Open On Resdit File Failed.")
    '        Exit Sub
    '    End Try

    '    If Not countFileRecord Is Nothing Then

    '        Dim tokenSet() As String = countFileRecord.Split(",")

    '        Me.totalWeightLabel.Text = tokenSet(1)
    '        Me.mailPieceCountLabel.Text = tokenSet(0)

    '    Else

    '        Me.totalWeightLabel.Text = "0"
    '        Me.mailPieceCountLabel.Text = "0"

    '    End If

    '    countFileInputStream.Close()

    'End Sub

    'Private Sub reloadCargoPieceCounts()

    '    Dim countFilePath As String = deviceNonVolatileMemoryDirectory & backSlash & "CargoScanPieceCounts.txt"

    '    Dim totalCount As Integer = 0

    '    If Not File.Exists(countFilePath) Then

    '        Exit Sub

    '    End If

    '    Dim countFileInputStream As StreamReader

    '    Try
    '        countFileInputStream = New StreamReader(countFilePath)
    '    Catch ex As Exception
    '        MsgBox("Unable to open count file in order to reset cargo counters: " & ex.Message, MsgBoxStyle.Exclamation, "Open On Resdit File Failed.")
    '        Exit Sub
    '    End Try

    '    Dim countFileRecord As String

    '    Try
    '        countFileRecord = countFileInputStream.ReadLine
    '    Catch ex As Exception
    '        MsgBox("Unable to read count file in order to reset cargo counters: " & ex.Message, MsgBoxStyle.Exclamation, "Open On Resdit File Failed.")
    '        Exit Sub
    '    End Try

    '    'If Not countFileRecord Is Nothing Then
    '    '    Me.cargoPieceCountLabel.Text = Trim(countFileRecord)
    '    'Else
    '    '    Me.cargoPieceCountLabel.Text = "0"
    '    'End If

    'End Sub

    Private Sub reloadCountersMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CouterReload.Click

        'If currentTabPage = "mail scan" Or currentTabPage = "mail scan simple" Then
        'reloadMailPieceCounts()
        'ElseIf currentTabPage = "cargo scan" Then
        '    reloadCargoPieceCounts()
        'End If
        fileUtilities.reloadCounters(Me.mailPieceCountLabel, Me.totalWeightLabel, "MailScanPieceCounts.txt")

    End Sub

    Private Sub presetButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Presets.Click

        MailScanFormRepository.MailScanPresetsForm.init(Me)
        MailScanFormRepository.MailScanPresetsForm.Show()

    End Sub

    Private Sub mailScanSimpleOperationComboBox_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mailScanSimpleOperationComboBox.SelectedIndexChanged

        Me.operationComboBox.SelectedIndex = mailScanSimpleOperationComboBox.SelectedIndex

    End Sub

    Private Sub mailScanSimpleDandRTagTextBox_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mailScanSimpleDandRTagTextBox.TextChanged

        Me.DandRTextBox.Text = mailScanSimpleDandRTagTextBox.Text

    End Sub

    Private Sub mailScanSimpleWeightTextBox_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mailScanSimpleWeightTextBox.TextChanged

        Me.weightTextBox.Text = mailScanSimpleWeightTextBox.Text

    End Sub

    Private Sub mailScanSimpleLargeBarcodeCheckBox_CheckStateChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mailScanSimpleLargeBarcodeCheckBox.CheckStateChanged

        Me.enableCode93CheckBox.CheckState = mailScanSimpleLargeBarcodeCheckBox.CheckState

    End Sub


    Public Sub loadMailFormLogo()

        Dim mailFormLogoPath As String

        mailFormLogoPath = TagTrakConfigDirectory & "\" & userSpecRecord.userName & "scanFormLogo.bmp"

        If File.Exists(mailFormLogoPath) Then
            mailFormLogoPictureBox.Image = New System.Drawing.Bitmap(mailFormLogoPath)
            Exit Sub
        End If

        mailFormLogoPath = TagTrakConfigDirectory & "\scanFormLogo.bmp"

        If File.Exists(mailFormLogoPath) Then
            mailFormLogoPictureBox.Image = New System.Drawing.Bitmap(mailFormLogoPath)
        End If

    End Sub

    Public Sub loadMailSimpleFormLogo()

        Dim mailFormLogoPath As String

        mailFormLogoPath = TagTrakConfigDirectory & "\" & userSpecRecord.userName & "scanFormLogo.bmp"

        If File.Exists(mailFormLogoPath) Then
            mailSimpleScanFormLogoPictureBox.Image = New System.Drawing.Bitmap(mailFormLogoPath)
            Exit Sub
        End If

        mailFormLogoPath = TagTrakConfigDirectory & "\scanFormLogo.bmp"

        If File.Exists(mailFormLogoPath) Then
            mailSimpleScanFormLogoPictureBox.Image = New System.Drawing.Bitmap(mailFormLogoPath)
        End If

    End Sub


    'Private Sub mailFormLogoPictureBox_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mailFormLogoPictureBox.Click
    '    NavigationMenu.Singlet.Show(mailFormLogoPictureBox, New System.Drawing.Point(0, 0))
    'End Sub

    'Private Sub mailSimpleScanFormLogoPictureBox_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mailSimpleScanFormLogoPictureBox.Click
    '    NavigationMenu.Singlet.Show(mailSimpleScanFormLogoPictureBox, New System.Drawing.Point(0, 0))
    'End Sub

    Private Sub scanSimpleUploadButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles scanSimpleUploadButton.Click
        UploadButton_Click(sender, e)
    End Sub

    Private Sub binFullButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles binFullButton.Click, CartFull.Click

        MailScanFormRepository.MailScanCreateNewPresetForm.init(Me)

        MailScanFormRepository.MailScanCreateNewPresetForm.Show()

        loadPresetListFromFile(userSpecRecord, userSpecRecord.presetList, "M"c)

    End Sub

    Private Sub scanSimpleBinFullButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles scanSimpleBinFullButton.Click
        binFullButton_Click(sender, e)
        Dim presetRecord As presetRecordClass

        mailScanSimplePresetListBox.Items.Clear()

        For Each presetRecord In userSpecRecord.presetList
            mailScanSimplePresetListBox.Items.Add(presetRecord.formatForListBox)
        Next

    End Sub


    Private Sub mailScanSimpleBinUpload_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mailScanSimpleBinUpload.Click
        Me.binUploadButton_Click(Nothing, Nothing)
    End Sub

    Public lastSimplePresetBoxIndex As Integer = -1

    Private Sub mailScanSimplePresetListBox_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mailScanSimplePresetListBox.SelectedIndexChanged

        Dim result As String

        Dim selectedIndex As Integer = mailScanSimplePresetListBox.SelectedIndex

        If selectedIndex < 0 Or selectedIndex >= mailScanSimplePresetListBox.Items.Count Then
            Exit Sub
        End If

        lastSimplePresetBoxIndex = selectedIndex

        Dim presetRecord As presetRecordClass = userSpecRecord.presetList(selectedIndex)

        groupNumberTextBox.Text = presetRecord.batchID

        If presetRecord.isReroutePreset Then
            flightNumberTextBox.Text = presetRecord.newFlightNumber
            mailDestinationComboBox.SelectedItem = presetRecord.newDestination
        Else
            flightNumberTextBox.Text = presetRecord.flightNumber
            mailDestinationComboBox.SelectedItem = presetRecord.destination
        End If

        presetRecord.presetLastUsedDateAndTime = DateTime.UtcNow

        currentScanScreenPopulatedFromPreset = True
        lastSelectedPresetForScanScreen = userSpecRecord.presetList(selectedIndex)

        savePresetListToFile(userSpecRecord, userSpecRecord.presetList)

    End Sub

    Private Sub simpleSaveButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles simpleSaveButton.Click
        saveButton_Click(Nothing, Nothing)
    End Sub

    'Private Sub WeightTextBox_KeyPress(ByVal sender As System.Object, ByVal e As KeyPressEventArgs) Handles 
    '    If e.KeyChar = tabKeyChar Then
    '        keyboard.processTabRoutine(sender)
    '    End If
    'End Sub

    'Private Sub groupNumberTextBox_KeyPress(ByVal sender As System.Object, ByVal e As KeyPressEventArgs) Handles 
    '    If e.KeyChar = tabKeyChar Then
    '        keyboard.processTabRoutine(sender)
    '    End If
    'End Sub

    'Private Sub groupNumberTextBox_KeyPress(ByVal sender As System.Object, ByVal e As KeyPressEventArgs) Handles groupNumberTextBox.KeyPress
    '    If e.KeyChar = tabKeyChar Then
    '        keyboard.processTabRoutine(groupNumberTextBox)
    '    End If
    'End Sub
    'Private Sub groupNumberTextBox_KeyPress(ByVal sender As System.Object, ByVal e As KeyPressEventArgs) Handles groupNumberTextBox.KeyPress
    '    If e.KeyChar = tabKeyChar Then
    '        keyboard.processTabRoutine(groupNumberTextBox)
    '    End If
    'End Sub

    Private Sub flightStatusPictureBox_ParentChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles FlightStatus.Click

        Dim flightStatusForm As FlightStatusMessage = FlightStatusMessage.GetInstance()

        flightStatusForm.Show()

    End Sub

    Private Sub Label15_ParentChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Label15.ParentChanged

    End Sub

    Private Sub TextBox_GotFocus(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mailScanSimpleDandRTagTextBox.GotFocus, DandRTextBox.GotFocus, flightNumberTextBox.GotFocus, groupNumberTextBox.GotFocus, mailScanSimpleWeightTextBox.GotFocus, transferPointTextBox.GotFocus, weightTextBox.GotFocus
#If deviceType <> "PC" Then
        If userSpecRecord.showKeyboardOnFocus Then Me.InputPanel1.Enabled = True
        flag = True
        logoutFlag = False
#End If
    End Sub

    'Added by MX
    Private Sub ComboBox_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles mailDestinationComboBox.GotFocus, cbxMailScanLocation.GotFocus
        flag = True
        logoutFlag = False
    End Sub

    Private Sub startupProcessRoutine()

        Util.LoadComboBoxFromList(mailDestinationComboBox, userSpecRecord.cityList)
        'Changed by MX 9/14
        Util.LoadComboBoxFromList(cbxMailScanLocation, userSpecRecord.cityList)
        mailDestinationComboBox.Items.Insert(0, "")

        mailCarrierCodeLabel.Text = userSpecRecord.carrierCode

        'transfer point spec

        transferPointLabel.Enabled = userSpecRecord.transferPointOnScanForm
        transferPointTextBox.Enabled = userSpecRecord.transferPointOnScanForm
        transferPointLabel.Visible = userSpecRecord.transferPointOnScanForm
        transferPointTextBox.Visible = userSpecRecord.transferPointOnScanForm

        If user = "TZ" Or user = "US" Then
            batchIDLabel.Text = "Cart ID"
        End If

        Enabled = True

    End Sub

    'Added by MX
    Dim flag As Boolean = False
    Dim logoutFlag As Boolean = True

    Private Sub MailScanDomsForm_MouseUp(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles MyBase.MouseUp
        flag = True
        logoutFlag = False
    End Sub

    Private Sub MailScanDomsForm_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles MyBase.KeyUp
        flag = True
        logoutFlag = False
    End Sub

    Private Sub MailScanTab_MouseUp(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles MailScanTab.MouseUp
        flag = True
        logoutFlag = False
    End Sub

    Private Sub mailScanSimpleForm_MouseUp(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles mailScanSimpleForm.MouseUp
        flag = True
        logoutFlag = False
    End Sub

    Private Sub Timer1_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Timer1.Tick

        If flag = True Then
            flag = False
            If Timer2.Enabled = True Then
                Timer2.Enabled = False
            End If
        Else
            If Timer2.Enabled = False Then
                Timer2.Enabled = True
            End If
        End If

    End Sub


    Private Sub Timer2_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Timer2.Tick

        Me.ResetScreen()

        Timer1.Enabled = False
        Timer2.Enabled = False

    End Sub


    Private Sub transferPointTextBox_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles transferPointTextBox.TextChanged
        flag = True
        logoutFlag = False
    End Sub

    Private Sub rejectReasonTextBox_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)
        flag = True
        logoutFlag = False
    End Sub


    Private Sub MailScanDomsForm_Deactivate(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Deactivate

        Timer2.Enabled = False
        Timer1.Enabled = False
        LogTimer1.Enabled = False
        LogTimer2.Enabled = False

    End Sub

    Private Sub ResetScreen()

        Me.resetOperationComboBoxWithoutWarning()
        Me.flightNumberTextBox.Text = ""
        Me.mailDestinationComboBox.SelectedIndex = -1
        Me.groupNumberTextBox.Text = ""
        Me.transferPointTextBox.Text = ""
        Me.txtRejectReason.Text = ""
        Me.mailPieceCountLabel.Text = ""
        Me.totalWeightLabel.Text = ""

    End Sub

    Private Sub LogTimer1_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles LogTimer1.Tick

        If logoutFlag = False Then
            logoutFlag = True
            If LogTimer2.Enabled = True Then
                LogTimer2.Enabled = False
            End If
        Else
            If LogTimer2.Enabled = False Then
                LogTimer2.Enabled = True
            End If
        End If

    End Sub

    Private Sub LogTimer2_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles LogTimer2.Tick

        LogTimer1.Enabled = False
        LogTimer2.Enabled = False

        Dim frmLogin As New TagTrakLogin
        frmLogin.WriteLogRecord(False)
        frmLogin.ShowDialog()

    End Sub

End Class

