' VALIDATE

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

Imports System
Imports System.io
Imports System.text

Public Class readerForm
    Inherits System.Windows.Forms.Form
    Friend WithEvents mainTabControl As System.Windows.Forms.TabControl
    Friend WithEvents scanFormTab As System.Windows.Forms.TabPage
    Friend WithEvents resetCounterButton As System.Windows.Forms.Button
    Friend WithEvents locationLabel As System.Windows.Forms.Label
    Friend WithEvents carrierCodeLabel As System.Windows.Forms.Label
    Friend WithEvents releaseLabel As System.Windows.Forms.Label
    Friend WithEvents operationComboBox As System.Windows.Forms.ComboBox
    Friend WithEvents groupNumberTextBox As System.Windows.Forms.TextBox
    Friend WithEvents tailNumberTextBox As System.Windows.Forms.TextBox
    Friend WithEvents destinationComboBox As System.Windows.Forms.ComboBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents flightNumberTextBox As System.Windows.Forms.TextBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents transferPointTextBox As System.Windows.Forms.TextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents rejectReasonTextBox As System.Windows.Forms.TextBox
    Friend WithEvents saveButton As System.Windows.Forms.Button
    Friend WithEvents weightTextBox As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents DandRTextBox As System.Windows.Forms.TextBox
    Friend WithEvents rejectReasonLabel As System.Windows.Forms.Label
    Friend WithEvents transferPointLabel As System.Windows.Forms.Label
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents destinationLabel As System.Windows.Forms.Label
    Friend WithEvents uploadButton As System.Windows.Forms.Button
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents totalWeightLabel As System.Windows.Forms.Label
    Friend WithEvents pieceCountLabel As System.Windows.Forms.Label
    Friend WithEvents preset As System.Windows.Forms.TabPage
    Friend WithEvents Label23 As System.Windows.Forms.Label
    Friend WithEvents rerouteButton As System.Windows.Forms.Button
    Friend WithEvents presetUpdateItemButton As System.Windows.Forms.Button
    Friend WithEvents presetLoadListButton As System.Windows.Forms.Button
    Friend WithEvents presetOriginLabel As System.Windows.Forms.Label
    Friend WithEvents presetSaveListButton As System.Windows.Forms.Button
    Friend WithEvents presetClearListButton As System.Windows.Forms.Button
    Friend WithEvents presetDeleteCurrentItemButton As System.Windows.Forms.Button
    Friend WithEvents Label20 As System.Windows.Forms.Label
    Friend WithEvents Label19 As System.Windows.Forms.Label
    Friend WithEvents Label18 As System.Windows.Forms.Label
    Friend WithEvents Label17 As System.Windows.Forms.Label
    Friend WithEvents addItemToPresetListButton As System.Windows.Forms.Button
    Friend WithEvents presetDestinationComboBox As System.Windows.Forms.ComboBox
    Friend WithEvents presetBatchIDTextBox As System.Windows.Forms.TextBox
    Friend WithEvents presetFlightNumberTextBox As System.Windows.Forms.TextBox
    Friend WithEvents summaryTab As System.Windows.Forms.TabPage
    Friend WithEvents Label15 As System.Windows.Forms.Label

    Public WithEvents presetMenuItem As New Windows.Forms.MenuItem
    Public WithEvents scanMenuItem As New Windows.Forms.MenuItem
    Public WithEvents summaryMenuItem As New Windows.Forms.MenuItem
    Public WithEvents exitMenuItem As New Windows.Forms.MenuItem

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

    Public deviceInCradle As Boolean = False

#Region " Windows Form Designer generated code "

    Public Sub New()

        MyBase.New()

        'This call is required by the Windows Form Designer.
        InitializeComponent()

        backgroundFtpTimer.Enabled = False
        uploadReminderTimer.Enabled = False

        presetListBox.Items.Clear()

        rejectReasonTextBox.Enabled = False
        uploadButton.Enabled = True
        transferPointTextBox.Enabled = False

        activeReaderForm = Me

        Dim scanFormLogoPath As String = deviceNonVolatileMemoryDirectory & "\UspsMailConfig\scanFormLogo.bmp"

        If File.Exists(scanFormLogoPath) Then
            scanFormLogoPictureBox.Image = New System.Drawing.Bitmap(scanFormLogoPath)
        End If

        startupProcessRoutine()

        code93LockedPictureBox.Visible = False

        totalWeightLabel.Text = 0
        pieceCountLabel.Text = 0

#If deviceType = "PC" Then

        DandRTextBox.Text = "DUMMYSCANN"
        weightTextBox.Text = "0"

#End If
       
        summaryButton.Enabled = False

        uploadReminderMinuteCount = 120
        uploadReminderTimer.Interval = 60 * 1000

        Dim operation As String

        operationComboBox.Items.Clear()

        operationComboBox.Items.Add("")

        For Each operation In userSpecRecord.operationsList
            operationComboBox.Items.Add(operation)
        Next

        operationComboBox.Items.Add("")

        setupReaderFormButtons()
        
    End Sub

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  

#End Region

    Private Sub setupButton(ByRef buttonSpec As buttonSpecRecordClass, ByRef button As Windows.Forms.Button)

        If Not buttonSpec.visible Then

            button.Visible = False
            button.Enabled = False

            Exit Sub

        End If

        button.Visible = True
        button.Enabled = True
        button.Location = buttonSpec.location
        button.Size = buttonSpec.size
        button.Text = buttonSpec.text

    End Sub

    Private Sub setupReaderFormButtons()

        With userSpecRecord

            setupButton(.summaryButtonSpec, summaryButton)
            setupButton(.presetsButtonSpec, presetButton)
            'setupButton(.adminButtonSpec, exitButton)
            setupButton(.binUploadButtonSpec, binUploadButton)
            setupButton(.binChangeButtonSpec, binChangeButton)
            setupButton(.manifestButtonSpec, manifestButton)
            'setupButton(.scanButtonSpec, scanButton)

        End With

    End Sub

    Protected Overloads Overrides Sub Dispose(ByVal disposing As Boolean)
        MyBase.Dispose(disposing)
    End Sub

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    Friend WithEvents backgroundFtpTimer As System.Windows.Forms.Timer
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents summaryButton As System.Windows.Forms.Button
    Friend WithEvents presetButton As System.Windows.Forms.Button
    Friend WithEvents scanButton As System.Windows.Forms.Button
    Friend WithEvents exitButton As System.Windows.Forms.Button
    Friend WithEvents selectItemButton As System.Windows.Forms.Button
    Friend WithEvents uploadReminderTimer As System.Windows.Forms.Timer
    Friend WithEvents tailNumberLabel As System.Windows.Forms.Label
    Friend WithEvents batchIDLabel As System.Windows.Forms.Label
    Friend WithEvents presetListBox As System.Windows.Forms.ListBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents staticPresetCheckBox As System.Windows.Forms.CheckBox
    Friend WithEvents presetListBoxHeader1Label As System.Windows.Forms.Label
    Friend WithEvents locationComboBox As System.Windows.Forms.ComboBox
    Friend WithEvents summaryListBox As System.Windows.Forms.ListBox
    Friend WithEvents presetBatchIDLabel As System.Windows.Forms.Label
    Friend WithEvents binChangeButton As System.Windows.Forms.Button
    Friend WithEvents binChangeTab As System.Windows.Forms.TabPage
    Friend WithEvents binChangeHeaderLabel As System.Windows.Forms.Label
    Friend WithEvents oldBinTextBox As System.Windows.Forms.TextBox
    Friend WithEvents newBinTextBox As System.Windows.Forms.TextBox
    Friend WithEvents oldBinLabel As System.Windows.Forms.Label
    Friend WithEvents newBinLabel As System.Windows.Forms.Label
    Friend WithEvents Button2 As System.Windows.Forms.Button
    Friend WithEvents OKButton As System.Windows.Forms.Button
    Friend WithEvents binChangeFlightNumberTextBox As System.Windows.Forms.TextBox
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents binChangeLocationLabel As System.Windows.Forms.Label
    Friend WithEvents binUploadButton As System.Windows.Forms.Button
    Friend WithEvents binUploadTab As System.Windows.Forms.TabPage
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents Label14 As System.Windows.Forms.Label
    Friend WithEvents binUploadHeaderLabel As System.Windows.Forms.Label
    Friend WithEvents binUploadClearButton As System.Windows.Forms.Button
    Friend WithEvents binUploadOKButton As System.Windows.Forms.Button
    Friend WithEvents binUploadBinIDTextBox As System.Windows.Forms.TextBox
    Friend WithEvents binUploadFlightNumberTextBox As System.Windows.Forms.TextBox
    Friend WithEvents binUploadLabel As System.Windows.Forms.Label
    Friend WithEvents scanFormLogoPictureBox As System.Windows.Forms.PictureBox
    Friend WithEvents manifestButton As System.Windows.Forms.Button
    Friend WithEvents operationCodeLabel As System.Windows.Forms.Label
    Friend WithEvents binUploadDestinationComboBox As System.Windows.Forms.ComboBox
    Friend WithEvents enableCode93CheckBox As System.Windows.Forms.CheckBox
    Friend WithEvents code93LockedPictureBox As System.Windows.Forms.PictureBox
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Dim resources As System.Resources.ResourceManager = New System.Resources.ResourceManager(GetType(readerForm))
        Me.mainTabControl = New System.Windows.Forms.TabControl
        Me.preset = New System.Windows.Forms.TabPage
        Me.Label5 = New System.Windows.Forms.Label
        Me.staticPresetCheckBox = New System.Windows.Forms.CheckBox
        Me.selectItemButton = New System.Windows.Forms.Button
        Me.Label23 = New System.Windows.Forms.Label
        Me.rerouteButton = New System.Windows.Forms.Button
        Me.presetUpdateItemButton = New System.Windows.Forms.Button
        Me.presetLoadListButton = New System.Windows.Forms.Button
        Me.presetListBoxHeader1Label = New System.Windows.Forms.Label
        Me.presetOriginLabel = New System.Windows.Forms.Label
        Me.presetSaveListButton = New System.Windows.Forms.Button
        Me.presetClearListButton = New System.Windows.Forms.Button
        Me.presetDeleteCurrentItemButton = New System.Windows.Forms.Button
        Me.presetBatchIDLabel = New System.Windows.Forms.Label
        Me.Label20 = New System.Windows.Forms.Label
        Me.Label19 = New System.Windows.Forms.Label
        Me.Label18 = New System.Windows.Forms.Label
        Me.Label17 = New System.Windows.Forms.Label
        Me.addItemToPresetListButton = New System.Windows.Forms.Button
        Me.presetDestinationComboBox = New System.Windows.Forms.ComboBox
        Me.presetListBox = New System.Windows.Forms.ListBox
        Me.presetBatchIDTextBox = New System.Windows.Forms.TextBox
        Me.presetFlightNumberTextBox = New System.Windows.Forms.TextBox
        Me.scanFormTab = New System.Windows.Forms.TabPage
        Me.code93LockedPictureBox = New System.Windows.Forms.PictureBox
        Me.locationComboBox = New System.Windows.Forms.ComboBox
        Me.enableCode93CheckBox = New System.Windows.Forms.CheckBox
        Me.resetCounterButton = New System.Windows.Forms.Button
        Me.locationLabel = New System.Windows.Forms.Label
        Me.carrierCodeLabel = New System.Windows.Forms.Label
        Me.operationComboBox = New System.Windows.Forms.ComboBox
        Me.groupNumberTextBox = New System.Windows.Forms.TextBox
        Me.tailNumberLabel = New System.Windows.Forms.Label
        Me.tailNumberTextBox = New System.Windows.Forms.TextBox
        Me.destinationComboBox = New System.Windows.Forms.ComboBox
        Me.Label4 = New System.Windows.Forms.Label
        Me.flightNumberTextBox = New System.Windows.Forms.TextBox
        Me.Label3 = New System.Windows.Forms.Label
        Me.transferPointTextBox = New System.Windows.Forms.TextBox
        Me.Label2 = New System.Windows.Forms.Label
        Me.rejectReasonTextBox = New System.Windows.Forms.TextBox
        Me.operationCodeLabel = New System.Windows.Forms.Label
        Me.saveButton = New System.Windows.Forms.Button
        Me.weightTextBox = New System.Windows.Forms.TextBox
        Me.Label1 = New System.Windows.Forms.Label
        Me.DandRTextBox = New System.Windows.Forms.TextBox
        Me.rejectReasonLabel = New System.Windows.Forms.Label
        Me.transferPointLabel = New System.Windows.Forms.Label
        Me.Label8 = New System.Windows.Forms.Label
        Me.batchIDLabel = New System.Windows.Forms.Label
        Me.Label7 = New System.Windows.Forms.Label
        Me.destinationLabel = New System.Windows.Forms.Label
        Me.uploadButton = New System.Windows.Forms.Button
        Me.Label11 = New System.Windows.Forms.Label
        Me.totalWeightLabel = New System.Windows.Forms.Label
        Me.pieceCountLabel = New System.Windows.Forms.Label
        Me.scanFormLogoPictureBox = New System.Windows.Forms.PictureBox
        Me.summaryTab = New System.Windows.Forms.TabPage
        Me.summaryListBox = New System.Windows.Forms.ListBox
        Me.Label15 = New System.Windows.Forms.Label
        Me.binChangeTab = New System.Windows.Forms.TabPage
        Me.binChangeLocationLabel = New System.Windows.Forms.Label
        Me.Label9 = New System.Windows.Forms.Label
        Me.Label6 = New System.Windows.Forms.Label
        Me.binChangeFlightNumberTextBox = New System.Windows.Forms.TextBox
        Me.Button2 = New System.Windows.Forms.Button
        Me.OKButton = New System.Windows.Forms.Button
        Me.newBinLabel = New System.Windows.Forms.Label
        Me.oldBinLabel = New System.Windows.Forms.Label
        Me.newBinTextBox = New System.Windows.Forms.TextBox
        Me.oldBinTextBox = New System.Windows.Forms.TextBox
        Me.binChangeHeaderLabel = New System.Windows.Forms.Label
        Me.binUploadTab = New System.Windows.Forms.TabPage
        Me.binUploadDestinationComboBox = New System.Windows.Forms.ComboBox
        Me.Label13 = New System.Windows.Forms.Label
        Me.Label14 = New System.Windows.Forms.Label
        Me.binUploadFlightNumberTextBox = New System.Windows.Forms.TextBox
        Me.binUploadClearButton = New System.Windows.Forms.Button
        Me.binUploadOKButton = New System.Windows.Forms.Button
        Me.binUploadLabel = New System.Windows.Forms.Label
        Me.binUploadBinIDTextBox = New System.Windows.Forms.TextBox
        Me.binUploadHeaderLabel = New System.Windows.Forms.Label
        Me.releaseLabel = New System.Windows.Forms.Label
        Me.backgroundFtpTimer = New System.Windows.Forms.Timer
        Me.scanButton = New System.Windows.Forms.Button
        Me.presetButton = New System.Windows.Forms.Button
        Me.summaryButton = New System.Windows.Forms.Button
        Me.Panel1 = New System.Windows.Forms.Panel
        Me.manifestButton = New System.Windows.Forms.Button
        Me.binUploadButton = New System.Windows.Forms.Button
        Me.binChangeButton = New System.Windows.Forms.Button
        Me.exitButton = New System.Windows.Forms.Button
        Me.uploadReminderTimer = New System.Windows.Forms.Timer
        '
        'mainTabControl
        '
        Me.mainTabControl.Controls.Add(Me.preset)
        Me.mainTabControl.Controls.Add(Me.scanFormTab)
        Me.mainTabControl.Controls.Add(Me.summaryTab)
        Me.mainTabControl.Controls.Add(Me.binChangeTab)
        Me.mainTabControl.Controls.Add(Me.binUploadTab)
        Me.mainTabControl.SelectedIndex = 0
        Me.mainTabControl.Size = New System.Drawing.Size(253, 304)
        '
        'preset
        '
        Me.preset.Controls.Add(Me.presetListBox)
        Me.preset.Controls.Add(Me.Label5)
        Me.preset.Controls.Add(Me.staticPresetCheckBox)
        Me.preset.Controls.Add(Me.selectItemButton)
        Me.preset.Controls.Add(Me.Label23)
        Me.preset.Controls.Add(Me.rerouteButton)
        Me.preset.Controls.Add(Me.presetUpdateItemButton)
        Me.preset.Controls.Add(Me.presetLoadListButton)
        Me.preset.Controls.Add(Me.presetListBoxHeader1Label)
        Me.preset.Controls.Add(Me.presetOriginLabel)
        Me.preset.Controls.Add(Me.presetSaveListButton)
        Me.preset.Controls.Add(Me.presetClearListButton)
        Me.preset.Controls.Add(Me.presetDeleteCurrentItemButton)
        Me.preset.Controls.Add(Me.presetBatchIDLabel)
        Me.preset.Controls.Add(Me.Label20)
        Me.preset.Controls.Add(Me.Label19)
        Me.preset.Controls.Add(Me.Label18)
        Me.preset.Controls.Add(Me.Label17)
        Me.preset.Controls.Add(Me.addItemToPresetListButton)
        Me.preset.Controls.Add(Me.presetDestinationComboBox)
        Me.preset.Controls.Add(Me.presetBatchIDTextBox)
        Me.preset.Controls.Add(Me.presetFlightNumberTextBox)
        Me.preset.Location = New System.Drawing.Point(4, 22)
        Me.preset.Size = New System.Drawing.Size(245, 278)
        Me.preset.Text = "preset"
        '
        'Label5
        '
        Me.Label5.Location = New System.Drawing.Point(203, 24)
        Me.Label5.Size = New System.Drawing.Size(36, 15)
        Me.Label5.Text = "Keep"
        Me.Label5.Visible = False
        '
        'staticPresetCheckBox
        '
        Me.staticPresetCheckBox.Location = New System.Drawing.Point(212, 43)
        Me.staticPresetCheckBox.Size = New System.Drawing.Size(17, 20)
        Me.staticPresetCheckBox.Visible = False
        '
        'selectItemButton
        '
        Me.selectItemButton.Location = New System.Drawing.Point(5, 234)
        Me.selectItemButton.Size = New System.Drawing.Size(231, 19)
        Me.selectItemButton.Text = "Select Current Item For Scan Page"
        '
        'Label23
        '
        Me.Label23.Font = New System.Drawing.Font("Courier New", 8.25!, System.Drawing.FontStyle.Regular)
        Me.Label23.Location = New System.Drawing.Point(16, 103)
        Me.Label23.Size = New System.Drawing.Size(227, 13)
        Me.Label23.Text = "               ID    dst/flgt"
        '
        'rerouteButton
        '
        Me.rerouteButton.Location = New System.Drawing.Point(156, 68)
        Me.rerouteButton.Size = New System.Drawing.Size(85, 21)
        Me.rerouteButton.Text = "Reroute Item"
        Me.rerouteButton.Visible = False
        '
        'presetUpdateItemButton
        '
        Me.presetUpdateItemButton.Location = New System.Drawing.Point(73, 68)
        Me.presetUpdateItemButton.Size = New System.Drawing.Size(83, 21)
        Me.presetUpdateItemButton.Text = "Update Item"
        Me.presetUpdateItemButton.Visible = False
        '
        'presetLoadListButton
        '
        Me.presetLoadListButton.Location = New System.Drawing.Point(6, 207)
        Me.presetLoadListButton.Size = New System.Drawing.Size(113, 21)
        Me.presetLoadListButton.Text = "Load List"
        Me.presetLoadListButton.Visible = False
        '
        'presetListBoxHeader1Label
        '
        Me.presetListBoxHeader1Label.Font = New System.Drawing.Font("Courier New", 8.25!, System.Drawing.FontStyle.Regular)
        Me.presetListBoxHeader1Label.Location = New System.Drawing.Point(13, 24)
        Me.presetListBoxHeader1Label.Size = New System.Drawing.Size(225, 17)
        Me.presetListBoxHeader1Label.Text = "org dst flgt  batch    new"
        '
        'presetOriginLabel
        '
        Me.presetOriginLabel.Location = New System.Drawing.Point(8, 44)
        Me.presetOriginLabel.Size = New System.Drawing.Size(33, 20)
        Me.presetOriginLabel.TextAlign = System.Drawing.ContentAlignment.TopCenter
        Me.presetOriginLabel.Visible = False
        '
        'presetSaveListButton
        '
        Me.presetSaveListButton.Location = New System.Drawing.Point(123, 207)
        Me.presetSaveListButton.Size = New System.Drawing.Size(113, 21)
        Me.presetSaveListButton.Text = "Save  List"
        Me.presetSaveListButton.Visible = False
        '
        'presetClearListButton
        '
        Me.presetClearListButton.Location = New System.Drawing.Point(123, 186)
        Me.presetClearListButton.Size = New System.Drawing.Size(113, 21)
        Me.presetClearListButton.Text = "Clear List"
        Me.presetClearListButton.Visible = False
        '
        'presetDeleteCurrentItemButton
        '
        Me.presetDeleteCurrentItemButton.Location = New System.Drawing.Point(6, 186)
        Me.presetDeleteCurrentItemButton.Size = New System.Drawing.Size(113, 21)
        Me.presetDeleteCurrentItemButton.Text = "Delete This Item"
        Me.presetDeleteCurrentItemButton.Visible = False
        '
        'presetBatchIDLabel
        '
        Me.presetBatchIDLabel.Location = New System.Drawing.Point(91, 23)
        Me.presetBatchIDLabel.Size = New System.Drawing.Size(55, 16)
        Me.presetBatchIDLabel.Text = "Batch ID"
        Me.presetBatchIDLabel.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'Label20
        '
        Me.Label20.Location = New System.Drawing.Point(48, 23)
        Me.Label20.Size = New System.Drawing.Size(45, 17)
        Me.Label20.Text = "Flt Nbr"
        Me.Label20.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'Label19
        '
        Me.Label19.Location = New System.Drawing.Point(157, 23)
        Me.Label19.Size = New System.Drawing.Size(40, 17)
        Me.Label19.Text = "Dest."
        Me.Label19.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'Label18
        '
        Me.Label18.Location = New System.Drawing.Point(2, 23)
        Me.Label18.Size = New System.Drawing.Size(40, 17)
        Me.Label18.Text = "Origin"
        Me.Label18.TextAlign = System.Drawing.ContentAlignment.TopCenter
        Me.Label18.Visible = False
        '
        'Label17
        '
        Me.Label17.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Bold)
        Me.Label17.Location = New System.Drawing.Point(36, 2)
        Me.Label17.Size = New System.Drawing.Size(178, 16)
        Me.Label17.Text = "Process Presets List"
        Me.Label17.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'addItemToPresetListButton
        '
        Me.addItemToPresetListButton.Location = New System.Drawing.Point(5, 68)
        Me.addItemToPresetListButton.Size = New System.Drawing.Size(68, 21)
        Me.addItemToPresetListButton.Text = "Add Item"
        Me.addItemToPresetListButton.Visible = False
        '
        'presetDestinationComboBox
        '
        Me.presetDestinationComboBox.Items.Add("ATL")
        Me.presetDestinationComboBox.Items.Add("BOS")
        Me.presetDestinationComboBox.Items.Add("BTV")
        Me.presetDestinationComboBox.Items.Add("BUF")
        Me.presetDestinationComboBox.Items.Add("DEN")
        Me.presetDestinationComboBox.Items.Add("FLL")
        Me.presetDestinationComboBox.Items.Add("IAD")
        Me.presetDestinationComboBox.Items.Add("JFK")
        Me.presetDestinationComboBox.Items.Add("LAS")
        Me.presetDestinationComboBox.Items.Add("LGB")
        Me.presetDestinationComboBox.Items.Add("MCO")
        Me.presetDestinationComboBox.Items.Add("MSY")
        Me.presetDestinationComboBox.Items.Add("OAK")
        Me.presetDestinationComboBox.Items.Add("ONT")
        Me.presetDestinationComboBox.Items.Add("PBI")
        Me.presetDestinationComboBox.Items.Add("ROC")
        Me.presetDestinationComboBox.Items.Add("RSW")
        Me.presetDestinationComboBox.Items.Add("SAN")
        Me.presetDestinationComboBox.Items.Add("SEA")
        Me.presetDestinationComboBox.Items.Add("SJU")
        Me.presetDestinationComboBox.Items.Add("SLC")
        Me.presetDestinationComboBox.Items.Add("SYR")
        Me.presetDestinationComboBox.Items.Add("TPA")
        Me.presetDestinationComboBox.Location = New System.Drawing.Point(148, 42)
        Me.presetDestinationComboBox.Size = New System.Drawing.Size(55, 22)
        Me.presetDestinationComboBox.Visible = False
        '
        'presetListBox
        '
        Me.presetListBox.Font = New System.Drawing.Font("Courier New", 8.25!, System.Drawing.FontStyle.Regular)
        Me.presetListBox.Items.Add("12345678901234567890123456789012345")
        Me.presetListBox.Location = New System.Drawing.Point(2, 43)
        Me.presetListBox.Size = New System.Drawing.Size(244, 170)
        '
        'presetBatchIDTextBox
        '
        Me.presetBatchIDTextBox.Location = New System.Drawing.Point(100, 42)
        Me.presetBatchIDTextBox.Size = New System.Drawing.Size(39, 22)
        Me.presetBatchIDTextBox.Text = ""
        Me.presetBatchIDTextBox.Visible = False
        '
        'presetFlightNumberTextBox
        '
        Me.presetFlightNumberTextBox.Location = New System.Drawing.Point(50, 42)
        Me.presetFlightNumberTextBox.Size = New System.Drawing.Size(41, 22)
        Me.presetFlightNumberTextBox.Text = ""
        Me.presetFlightNumberTextBox.Visible = False
        '
        'scanFormTab
        '
        Me.scanFormTab.Controls.Add(Me.code93LockedPictureBox)
        Me.scanFormTab.Controls.Add(Me.locationComboBox)
        Me.scanFormTab.Controls.Add(Me.enableCode93CheckBox)
        Me.scanFormTab.Controls.Add(Me.resetCounterButton)
        Me.scanFormTab.Controls.Add(Me.locationLabel)
        Me.scanFormTab.Controls.Add(Me.carrierCodeLabel)
        Me.scanFormTab.Controls.Add(Me.operationComboBox)
        Me.scanFormTab.Controls.Add(Me.groupNumberTextBox)
        Me.scanFormTab.Controls.Add(Me.tailNumberLabel)
        Me.scanFormTab.Controls.Add(Me.tailNumberTextBox)
        Me.scanFormTab.Controls.Add(Me.destinationComboBox)
        Me.scanFormTab.Controls.Add(Me.Label4)
        Me.scanFormTab.Controls.Add(Me.flightNumberTextBox)
        Me.scanFormTab.Controls.Add(Me.Label3)
        Me.scanFormTab.Controls.Add(Me.transferPointTextBox)
        Me.scanFormTab.Controls.Add(Me.Label2)
        Me.scanFormTab.Controls.Add(Me.rejectReasonTextBox)
        Me.scanFormTab.Controls.Add(Me.operationCodeLabel)
        Me.scanFormTab.Controls.Add(Me.saveButton)
        Me.scanFormTab.Controls.Add(Me.weightTextBox)
        Me.scanFormTab.Controls.Add(Me.Label1)
        Me.scanFormTab.Controls.Add(Me.DandRTextBox)
        Me.scanFormTab.Controls.Add(Me.rejectReasonLabel)
        Me.scanFormTab.Controls.Add(Me.transferPointLabel)
        Me.scanFormTab.Controls.Add(Me.Label8)
        Me.scanFormTab.Controls.Add(Me.batchIDLabel)
        Me.scanFormTab.Controls.Add(Me.Label7)
        Me.scanFormTab.Controls.Add(Me.destinationLabel)
        Me.scanFormTab.Controls.Add(Me.uploadButton)
        Me.scanFormTab.Controls.Add(Me.Label11)
        Me.scanFormTab.Controls.Add(Me.totalWeightLabel)
        Me.scanFormTab.Controls.Add(Me.pieceCountLabel)
        Me.scanFormTab.Controls.Add(Me.scanFormLogoPictureBox)
        Me.scanFormTab.Location = New System.Drawing.Point(4, 22)
        Me.scanFormTab.Size = New System.Drawing.Size(245, 278)
        Me.scanFormTab.Text = "scan"
        '
        'code93LockedPictureBox
        '
        Me.code93LockedPictureBox.Image = CType(resources.GetObject("code93LockedPictureBox.Image"), System.Drawing.Image)
        Me.code93LockedPictureBox.Location = New System.Drawing.Point(6, 200)
        Me.code93LockedPictureBox.Size = New System.Drawing.Size(16, 26)
        '
        'locationComboBox
        '
        Me.locationComboBox.Location = New System.Drawing.Point(4, 108)
        Me.locationComboBox.Size = New System.Drawing.Size(72, 22)
        '
        'enableCode93CheckBox
        '
        Me.enableCode93CheckBox.Checked = True
        Me.enableCode93CheckBox.CheckState = System.Windows.Forms.CheckState.Indeterminate
        Me.enableCode93CheckBox.Location = New System.Drawing.Point(28, 205)
        Me.enableCode93CheckBox.Size = New System.Drawing.Size(103, 21)
        Me.enableCode93CheckBox.Text = "Large Barcode"
        '
        'resetCounterButton
        '
        Me.resetCounterButton.Location = New System.Drawing.Point(133, 178)
        Me.resetCounterButton.Size = New System.Drawing.Size(103, 20)
        Me.resetCounterButton.Text = "Reset Counters"
        '
        'locationLabel
        '
        Me.locationLabel.Location = New System.Drawing.Point(8, 111)
        Me.locationLabel.Size = New System.Drawing.Size(32, 16)
        Me.locationLabel.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'carrierCodeLabel
        '
        Me.carrierCodeLabel.Location = New System.Drawing.Point(80, 113)
        Me.carrierCodeLabel.Size = New System.Drawing.Size(22, 16)
        Me.carrierCodeLabel.Text = "B6"
        Me.carrierCodeLabel.TextAlign = System.Drawing.ContentAlignment.TopCenter
        Me.carrierCodeLabel.Visible = False
        '
        'operationComboBox
        '
        Me.operationComboBox.Font = New System.Drawing.Font("Tahoma", 11.25!, System.Drawing.FontStyle.Regular)
        Me.operationComboBox.Items.Add("")
        Me.operationComboBox.Items.Add("Possession")
        Me.operationComboBox.Items.Add("Load")
        Me.operationComboBox.Items.Add("Possession & Load")
        Me.operationComboBox.Items.Add("Reroute")
        Me.operationComboBox.Items.Add("Transfer")
        Me.operationComboBox.Items.Add("Unload")
        Me.operationComboBox.Items.Add("Partial Offload")
        Me.operationComboBox.Items.Add("Complete Offload")
        Me.operationComboBox.Items.Add("Delivery")
        Me.operationComboBox.Location = New System.Drawing.Point(105, 21)
        Me.operationComboBox.Size = New System.Drawing.Size(137, 26)
        '
        'groupNumberTextBox
        '
        Me.groupNumberTextBox.Location = New System.Drawing.Point(160, 68)
        Me.groupNumberTextBox.Size = New System.Drawing.Size(72, 22)
        Me.groupNumberTextBox.Text = ""
        Me.groupNumberTextBox.Visible = False
        '
        'tailNumberLabel
        '
        Me.tailNumberLabel.Location = New System.Drawing.Point(80, 132)
        Me.tailNumberLabel.Size = New System.Drawing.Size(48, 16)
        Me.tailNumberLabel.Text = "Tail"
        Me.tailNumberLabel.TextAlign = System.Drawing.ContentAlignment.TopCenter
        Me.tailNumberLabel.Visible = False
        '
        'tailNumberTextBox
        '
        Me.tailNumberTextBox.Location = New System.Drawing.Point(80, 148)
        Me.tailNumberTextBox.Size = New System.Drawing.Size(56, 22)
        Me.tailNumberTextBox.Text = ""
        Me.tailNumberTextBox.Visible = False
        '
        'destinationComboBox
        '
        Me.destinationComboBox.Items.Add("ATL")
        Me.destinationComboBox.Items.Add("BOS")
        Me.destinationComboBox.Items.Add("BTV")
        Me.destinationComboBox.Items.Add("BUF")
        Me.destinationComboBox.Items.Add("DEN")
        Me.destinationComboBox.Items.Add("FLL")
        Me.destinationComboBox.Items.Add("IAD")
        Me.destinationComboBox.Items.Add("JFK")
        Me.destinationComboBox.Items.Add("LAS")
        Me.destinationComboBox.Items.Add("LGB")
        Me.destinationComboBox.Items.Add("MCO")
        Me.destinationComboBox.Items.Add("MSY")
        Me.destinationComboBox.Items.Add("OAK")
        Me.destinationComboBox.Items.Add("ONT")
        Me.destinationComboBox.Items.Add("PBI")
        Me.destinationComboBox.Items.Add("ROC")
        Me.destinationComboBox.Items.Add("RSW")
        Me.destinationComboBox.Items.Add("SAN")
        Me.destinationComboBox.Items.Add("SEA")
        Me.destinationComboBox.Items.Add("SJU")
        Me.destinationComboBox.Items.Add("SLC")
        Me.destinationComboBox.Items.Add("SYR")
        Me.destinationComboBox.Items.Add("TPA")
        Me.destinationComboBox.Location = New System.Drawing.Point(181, 107)
        Me.destinationComboBox.Size = New System.Drawing.Size(52, 22)
        '
        'Label4
        '
        Me.Label4.Location = New System.Drawing.Point(116, 91)
        Me.Label4.Size = New System.Drawing.Size(40, 16)
        Me.Label4.Text = "Flight"
        '
        'flightNumberTextBox
        '
        Me.flightNumberTextBox.Location = New System.Drawing.Point(106, 108)
        Me.flightNumberTextBox.Size = New System.Drawing.Size(60, 22)
        Me.flightNumberTextBox.Text = ""
        '
        'Label3
        '
        Me.Label3.Location = New System.Drawing.Point(21, 91)
        Me.Label3.Size = New System.Drawing.Size(32, 16)
        Me.Label3.Text = "Loc"
        Me.Label3.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'transferPointTextBox
        '
        Me.transferPointTextBox.Location = New System.Drawing.Point(8, 148)
        Me.transferPointTextBox.Size = New System.Drawing.Size(56, 22)
        Me.transferPointTextBox.Text = ""
        Me.transferPointTextBox.Visible = False
        '
        'Label2
        '
        Me.Label2.Location = New System.Drawing.Point(100, 52)
        Me.Label2.Size = New System.Drawing.Size(48, 16)
        Me.Label2.Text = "Weight"
        Me.Label2.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'rejectReasonTextBox
        '
        Me.rejectReasonTextBox.Location = New System.Drawing.Point(160, 148)
        Me.rejectReasonTextBox.Size = New System.Drawing.Size(56, 22)
        Me.rejectReasonTextBox.Text = ""
        Me.rejectReasonTextBox.Visible = False
        '
        'operationCodeLabel
        '
        Me.operationCodeLabel.Location = New System.Drawing.Point(120, 1)
        Me.operationCodeLabel.Size = New System.Drawing.Size(104, 16)
        Me.operationCodeLabel.Text = "Operation Code"
        Me.operationCodeLabel.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'saveButton
        '
        Me.saveButton.Location = New System.Drawing.Point(133, 204)
        Me.saveButton.Size = New System.Drawing.Size(48, 19)
        Me.saveButton.Text = "Save"
        Me.saveButton.Visible = False
        '
        'weightTextBox
        '
        Me.weightTextBox.Location = New System.Drawing.Point(104, 68)
        Me.weightTextBox.Size = New System.Drawing.Size(40, 22)
        Me.weightTextBox.Text = ""
        '
        'Label1
        '
        Me.Label1.Location = New System.Drawing.Point(8, 52)
        Me.Label1.Size = New System.Drawing.Size(80, 16)
        Me.Label1.Text = "D and R Tag"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'DandRTextBox
        '
        Me.DandRTextBox.Location = New System.Drawing.Point(0, 68)
        Me.DandRTextBox.Size = New System.Drawing.Size(96, 22)
        Me.DandRTextBox.Text = ""
        '
        'rejectReasonLabel
        '
        Me.rejectReasonLabel.Location = New System.Drawing.Point(144, 132)
        Me.rejectReasonLabel.Size = New System.Drawing.Size(88, 16)
        Me.rejectReasonLabel.Text = "Reject Reason"
        Me.rejectReasonLabel.Visible = False
        '
        'transferPointLabel
        '
        Me.transferPointLabel.Location = New System.Drawing.Point(0, 132)
        Me.transferPointLabel.Size = New System.Drawing.Size(72, 16)
        Me.transferPointLabel.Text = "Transfer Pt."
        Me.transferPointLabel.TextAlign = System.Drawing.ContentAlignment.TopCenter
        Me.transferPointLabel.Visible = False
        '
        'Label8
        '
        Me.Label8.Location = New System.Drawing.Point(59, 172)
        Me.Label8.Size = New System.Drawing.Size(64, 16)
        Me.Label8.Text = "Tot. Wgt"
        Me.Label8.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'batchIDLabel
        '
        Me.batchIDLabel.Location = New System.Drawing.Point(161, 52)
        Me.batchIDLabel.Size = New System.Drawing.Size(72, 16)
        Me.batchIDLabel.Text = "Batch ID"
        Me.batchIDLabel.TextAlign = System.Drawing.ContentAlignment.TopCenter
        Me.batchIDLabel.Visible = False
        '
        'Label7
        '
        Me.Label7.Location = New System.Drawing.Point(70, 91)
        Me.Label7.Size = New System.Drawing.Size(34, 16)
        Me.Label7.Text = "Carr."
        Me.Label7.TextAlign = System.Drawing.ContentAlignment.TopCenter
        Me.Label7.Visible = False
        '
        'destinationLabel
        '
        Me.destinationLabel.Location = New System.Drawing.Point(181, 91)
        Me.destinationLabel.Size = New System.Drawing.Size(53, 16)
        Me.destinationLabel.Text = "Dest"
        Me.destinationLabel.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'uploadButton
        '
        Me.uploadButton.Location = New System.Drawing.Point(183, 204)
        Me.uploadButton.Size = New System.Drawing.Size(52, 19)
        Me.uploadButton.Text = "Upload"
        Me.uploadButton.Visible = False
        '
        'Label11
        '
        Me.Label11.Location = New System.Drawing.Point(27, 172)
        Me.Label11.Size = New System.Drawing.Size(40, 16)
        Me.Label11.Text = "Cnt"
        Me.Label11.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'totalWeightLabel
        '
        Me.totalWeightLabel.Location = New System.Drawing.Point(75, 188)
        Me.totalWeightLabel.Size = New System.Drawing.Size(40, 20)
        Me.totalWeightLabel.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'pieceCountLabel
        '
        Me.pieceCountLabel.Location = New System.Drawing.Point(35, 188)
        Me.pieceCountLabel.Size = New System.Drawing.Size(24, 20)
        '
        'scanFormLogoPictureBox
        '
        Me.scanFormLogoPictureBox.Image = CType(resources.GetObject("scanFormLogoPictureBox.Image"), System.Drawing.Image)
        Me.scanFormLogoPictureBox.Location = New System.Drawing.Point(-1, 3)
        Me.scanFormLogoPictureBox.Size = New System.Drawing.Size(100, 48)
        '
        'summaryTab
        '
        Me.summaryTab.Controls.Add(Me.summaryListBox)
        Me.summaryTab.Controls.Add(Me.Label15)
        Me.summaryTab.Location = New System.Drawing.Point(4, 22)
        Me.summaryTab.Size = New System.Drawing.Size(245, 278)
        Me.summaryTab.Text = "summary"
        '
        'summaryListBox
        '
        Me.summaryListBox.Location = New System.Drawing.Point(6, 30)
        Me.summaryListBox.Size = New System.Drawing.Size(227, 198)
        '
        'Label15
        '
        Me.Label15.Location = New System.Drawing.Point(16, 7)
        Me.Label15.Size = New System.Drawing.Size(204, 16)
        Me.Label15.Text = "MANIFEST SUMMARY"
        Me.Label15.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'binChangeTab
        '
        Me.binChangeTab.Controls.Add(Me.binChangeLocationLabel)
        Me.binChangeTab.Controls.Add(Me.Label9)
        Me.binChangeTab.Controls.Add(Me.Label6)
        Me.binChangeTab.Controls.Add(Me.binChangeFlightNumberTextBox)
        Me.binChangeTab.Controls.Add(Me.Button2)
        Me.binChangeTab.Controls.Add(Me.OKButton)
        Me.binChangeTab.Controls.Add(Me.newBinLabel)
        Me.binChangeTab.Controls.Add(Me.oldBinLabel)
        Me.binChangeTab.Controls.Add(Me.newBinTextBox)
        Me.binChangeTab.Controls.Add(Me.oldBinTextBox)
        Me.binChangeTab.Controls.Add(Me.binChangeHeaderLabel)
        Me.binChangeTab.Location = New System.Drawing.Point(4, 22)
        Me.binChangeTab.Size = New System.Drawing.Size(245, 278)
        Me.binChangeTab.Text = "binchange"
        '
        'binChangeLocationLabel
        '
        Me.binChangeLocationLabel.Location = New System.Drawing.Point(99, 135)
        Me.binChangeLocationLabel.Size = New System.Drawing.Size(62, 17)
        Me.binChangeLocationLabel.Text = "Location"
        '
        'Label9
        '
        Me.Label9.Location = New System.Drawing.Point(11, 137)
        Me.Label9.Size = New System.Drawing.Size(84, 17)
        Me.Label9.Text = "Location"
        '
        'Label6
        '
        Me.Label6.Location = New System.Drawing.Point(11, 109)
        Me.Label6.Size = New System.Drawing.Size(84, 17)
        Me.Label6.Text = "Flight Number"
        '
        'binChangeFlightNumberTextBox
        '
        Me.binChangeFlightNumberTextBox.Location = New System.Drawing.Point(99, 105)
        Me.binChangeFlightNumberTextBox.Size = New System.Drawing.Size(127, 22)
        Me.binChangeFlightNumberTextBox.Text = ""
        '
        'Button2
        '
        Me.Button2.Location = New System.Drawing.Point(130, 173)
        Me.Button2.Size = New System.Drawing.Size(86, 29)
        Me.Button2.Text = "Clear"
        '
        'OKButton
        '
        Me.OKButton.Location = New System.Drawing.Point(27, 173)
        Me.OKButton.Size = New System.Drawing.Size(86, 29)
        Me.OKButton.Text = "OK"
        '
        'newBinLabel
        '
        Me.newBinLabel.Location = New System.Drawing.Point(11, 81)
        Me.newBinLabel.Size = New System.Drawing.Size(80, 17)
        Me.newBinLabel.Text = "New Batch ID"
        '
        'oldBinLabel
        '
        Me.oldBinLabel.Location = New System.Drawing.Point(11, 53)
        Me.oldBinLabel.Size = New System.Drawing.Size(80, 17)
        Me.oldBinLabel.Text = "Old Batch ID"
        '
        'newBinTextBox
        '
        Me.newBinTextBox.Location = New System.Drawing.Point(99, 75)
        Me.newBinTextBox.Size = New System.Drawing.Size(127, 22)
        Me.newBinTextBox.Text = ""
        '
        'oldBinTextBox
        '
        Me.oldBinTextBox.Location = New System.Drawing.Point(99, 45)
        Me.oldBinTextBox.Size = New System.Drawing.Size(127, 22)
        Me.oldBinTextBox.Text = ""
        '
        'binChangeHeaderLabel
        '
        Me.binChangeHeaderLabel.Font = New System.Drawing.Font("Tahoma", 14.25!, System.Drawing.FontStyle.Italic)
        Me.binChangeHeaderLabel.Location = New System.Drawing.Point(8, 12)
        Me.binChangeHeaderLabel.Size = New System.Drawing.Size(235, 28)
        Me.binChangeHeaderLabel.Text = "Create Bin Change Record"
        Me.binChangeHeaderLabel.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'binUploadTab
        '
        Me.binUploadTab.Controls.Add(Me.binUploadDestinationComboBox)
        Me.binUploadTab.Controls.Add(Me.Label13)
        Me.binUploadTab.Controls.Add(Me.Label14)
        Me.binUploadTab.Controls.Add(Me.binUploadFlightNumberTextBox)
        Me.binUploadTab.Controls.Add(Me.binUploadClearButton)
        Me.binUploadTab.Controls.Add(Me.binUploadOKButton)
        Me.binUploadTab.Controls.Add(Me.binUploadLabel)
        Me.binUploadTab.Controls.Add(Me.binUploadBinIDTextBox)
        Me.binUploadTab.Controls.Add(Me.binUploadHeaderLabel)
        Me.binUploadTab.Location = New System.Drawing.Point(4, 22)
        Me.binUploadTab.Size = New System.Drawing.Size(245, 278)
        Me.binUploadTab.Text = "binupload"
        '
        'binUploadDestinationComboBox
        '
        Me.binUploadDestinationComboBox.Location = New System.Drawing.Point(99, 123)
        Me.binUploadDestinationComboBox.Size = New System.Drawing.Size(72, 22)
        '
        'Label13
        '
        Me.Label13.Location = New System.Drawing.Point(14, 126)
        Me.Label13.Size = New System.Drawing.Size(71, 17)
        Me.Label13.Text = "Destination"
        '
        'Label14
        '
        Me.Label14.Location = New System.Drawing.Point(14, 92)
        Me.Label14.Size = New System.Drawing.Size(84, 17)
        Me.Label14.Text = "Flight Number"
        '
        'binUploadFlightNumberTextBox
        '
        Me.binUploadFlightNumberTextBox.Location = New System.Drawing.Point(99, 89)
        Me.binUploadFlightNumberTextBox.Size = New System.Drawing.Size(127, 22)
        Me.binUploadFlightNumberTextBox.Text = ""
        '
        'binUploadClearButton
        '
        Me.binUploadClearButton.Location = New System.Drawing.Point(130, 163)
        Me.binUploadClearButton.Size = New System.Drawing.Size(86, 29)
        Me.binUploadClearButton.Text = "Clear"
        '
        'binUploadOKButton
        '
        Me.binUploadOKButton.Location = New System.Drawing.Point(25, 163)
        Me.binUploadOKButton.Size = New System.Drawing.Size(86, 29)
        Me.binUploadOKButton.Text = "OK"
        '
        'binUploadLabel
        '
        Me.binUploadLabel.Location = New System.Drawing.Point(14, 58)
        Me.binUploadLabel.Size = New System.Drawing.Size(80, 17)
        Me.binUploadLabel.Text = "Bin ID"
        '
        'binUploadBinIDTextBox
        '
        Me.binUploadBinIDTextBox.Location = New System.Drawing.Point(99, 55)
        Me.binUploadBinIDTextBox.Size = New System.Drawing.Size(127, 22)
        Me.binUploadBinIDTextBox.Text = ""
        '
        'binUploadHeaderLabel
        '
        Me.binUploadHeaderLabel.Font = New System.Drawing.Font("Tahoma", 14.25!, System.Drawing.FontStyle.Italic)
        Me.binUploadHeaderLabel.Location = New System.Drawing.Point(4, 14)
        Me.binUploadHeaderLabel.Size = New System.Drawing.Size(235, 28)
        Me.binUploadHeaderLabel.Text = "Create Bin Upload Record"
        Me.binUploadHeaderLabel.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'releaseLabel
        '
        Me.releaseLabel.Location = New System.Drawing.Point(53, 45)
        Me.releaseLabel.Size = New System.Drawing.Size(144, 18)
        Me.releaseLabel.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'backgroundFtpTimer
        '
        Me.backgroundFtpTimer.Interval = 5000
        '
        'scanButton
        '
        Me.scanButton.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular)
        Me.scanButton.Location = New System.Drawing.Point(128, 5)
        Me.scanButton.Size = New System.Drawing.Size(124, 37)
        Me.scanButton.Text = "Scan"
        '
        'presetButton
        '
        Me.presetButton.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular)
        Me.presetButton.Location = New System.Drawing.Point(10, 5)
        Me.presetButton.Size = New System.Drawing.Size(118, 37)
        Me.presetButton.Text = "Presets"
        '
        'summaryButton
        '
        Me.summaryButton.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular)
        Me.summaryButton.Location = New System.Drawing.Point(11, 5)
        Me.summaryButton.Size = New System.Drawing.Size(61, 19)
        Me.summaryButton.Text = "Summary"
        Me.summaryButton.Visible = False
        '
        'Panel1
        '
        Me.Panel1.Controls.Add(Me.scanButton)
        Me.Panel1.Controls.Add(Me.presetButton)
        Me.Panel1.Controls.Add(Me.manifestButton)
        Me.Panel1.Controls.Add(Me.binUploadButton)
        Me.Panel1.Controls.Add(Me.binChangeButton)
        Me.Panel1.Controls.Add(Me.exitButton)
        Me.Panel1.Controls.Add(Me.summaryButton)
        Me.Panel1.Controls.Add(Me.releaseLabel)
        Me.Panel1.Location = New System.Drawing.Point(-4, 258)
        Me.Panel1.Size = New System.Drawing.Size(263, 107)
        Me.Panel1.Visible = False
        '
        'manifestButton
        '
        Me.manifestButton.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular)
        Me.manifestButton.Location = New System.Drawing.Point(161, 23)
        Me.manifestButton.Size = New System.Drawing.Size(78, 19)
        Me.manifestButton.Text = "Manifest"
        Me.manifestButton.Visible = False
        '
        'binUploadButton
        '
        Me.binUploadButton.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular)
        Me.binUploadButton.Location = New System.Drawing.Point(10, 23)
        Me.binUploadButton.Size = New System.Drawing.Size(77, 19)
        Me.binUploadButton.Text = "Bin Upload"
        Me.binUploadButton.Visible = False
        '
        'binChangeButton
        '
        Me.binChangeButton.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular)
        Me.binChangeButton.Location = New System.Drawing.Point(87, 23)
        Me.binChangeButton.Size = New System.Drawing.Size(74, 19)
        Me.binChangeButton.Text = "Chnge Bin"
        Me.binChangeButton.Visible = False
        '
        'exitButton
        '
        Me.exitButton.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular)
        Me.exitButton.Location = New System.Drawing.Point(128, 5)
        Me.exitButton.Size = New System.Drawing.Size(56, 19)
        Me.exitButton.Text = "Admin"
        Me.exitButton.Visible = False
        '
        'uploadReminderTimer
        '
        Me.uploadReminderTimer.Interval = 1000
        '
        'readerForm
        '
        Me.ClientSize = New System.Drawing.Size(253, 367)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.mainTabControl)
        Me.Text = "USPS MAIL"

    End Sub

    Private Sub readerFormOnLoad(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        Dim result As String

        If lockDown Then
            MyBase.MaximizeBox = False
            MyBase.MinimizeBox = False
            MyBase.ControlBox = False
            MyBase.WindowState = FormWindowState.Maximized
        End If

        Dim test As Integer

        If emulatingPlatform Then
            test = 1
        Else
            test = scannerLib.SystemPowerStatus()
        End If

        If test <> 1 Then
            deviceInCradle = False
            cradleTickCount = 2147483647
        Else
            deviceInCradle = True
            cradleTickCount = 6 * 30
        End If

        Me.enableCode93CheckBox.ThreeState = userSpecRecord.triStateLargeBarcodeCheckBox

        Me.enableCode93CheckBox.Checked = False

        If emulatingPlatform Then Exit Sub

#If deviceType = "PC" Then
        exit sub
#End If

#If deviceType = "Symbol" Then
        StartRead()
#End If

        removeExpiredBackupResditFiles()

        'scannerLib.Code128Active()

        turnScannerOff(7)

        backgroundFtpTimer.Enabled = True

        ignoreOperationComboBoxChange = False


    End Sub


    Private Function validateDestinationCode(ByRef destinationCode As String) As Boolean

        If Length(destinationCode) = 0 Or destinationCode Is Nothing Then
            warning("Missing Destination Code, Required For This Operation", MsgBoxStyle.Exclamation, "Missing Destination Code")
            Return False
        End If

        If Length(destinationCode) < 3 Then
            warning("Required Destination Code Is Invalid: Too Few Characters", MsgBoxStyle.Exclamation, "Invalid Destination Code")
            Return False
        End If

        If Length(destinationCode) > 3 Then
            warning("Required Destination Code Is Invalid: Too Many Characters", MsgBoxStyle.Exclamation, "Invalid Destination Code")
            Return False
        End If

        Return True

    End Function

    Private Function validateTransferPointCode(ByRef transferPointCode As String) As Boolean

        If Length(transferPointCode) = 0 Or transferPointCode Is Nothing Then
            warning("Missing Transfer Point Code, Required For This Operation", MsgBoxStyle.Exclamation, "Missing Transfer Point Code")
            Return False
        End If

        If Length(transferPointCode) < 3 Then
            warning("Required Transfer Point Code Is Invalid: Too Few Characters", MsgBoxStyle.Exclamation, "Invalid Destination Code")
            Return False
        End If

        If Length(transferPointCode) > 3 Then
            warning("Required Transfer Point  Code Is Invalid: Too Many Characters", MsgBoxStyle.Exclamation, "Invalid Destination Code")
            Return False
        End If

        Return True

    End Function

    Private Sub saveButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles saveButton.Click

        Dim result As String

        logScanSequenceEvent(20001, "Save Button exit to process transaction")

        processTransaction()

#If deviceType <> "PC" Then
        DandRTextBox.Text = ""
        weightTextBox.Text = ""
#End If

        logScanSequenceEvent(20002, "Save Button handler exits")

    End Sub

    Private Sub Label9_ParentChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles batchIDLabel.ParentChanged

    End Sub

    Dim withinoperationComboBoxSelectedIndexChanged As Boolean = False

    Dim previousOperation As String = ""

    Private Sub operationComboBox_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles operationComboBox.SelectedIndexChanged

        Dim currentOperation As String

        If withinoperationComboBoxSelectedIndexChanged Then Exit Sub

        withinoperationComboBoxSelectedIndexChanged = True

        If isNonNullString(operationComboBox.Text) Then
            currentOperation = Trim(operationComboBox.Text)
        Else
            currentOperation = ""
        End If

        If currentOperation = previousOperation Then
            withinoperationComboBoxSelectedIndexChanged = False
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

                withinoperationComboBoxSelectedIndexChanged = False

                Exit Sub

            End If

        End If

        previousOperation = currentOperation

        If Not isNonNullString(currentOperation) Then

            turnScannerOff(8)
            withinoperationComboBoxSelectedIndexChanged = False

            Exit Sub

        Else

            turnScannerOn(9)

        End If

        DandRTextBox.Text = ""
        weightTextBox.Text = ""
        groupNumberTextBox.Text = ""
        destinationComboBox.SelectedIndex = -1
        destinationComboBox.Text = ""
        flightNumberTextBox.Text = ""
        transferPointTextBox.Text = ""
        tailNumberTextBox.Text = ""
        rejectReasonTextBox.Text = ""

        Select Case currentOperation
            Case "Possession"
                transferPointTextBox.Enabled = False
                transferPointLabel.Enabled = False
                rejectReasonTextBox.Enabled = False
                rejectReasonTextBox.Text = ""
                rejectReasonLabel.Enabled = False
                flightNumberTextBox.Text = ""
                destinationComboBox.SelectedIndex = 0
            Case "Load"
                transferPointTextBox.Enabled = False
                transferPointLabel.Enabled = False
                rejectReasonTextBox.Enabled = False
                rejectReasonLabel.Enabled = False
            Case "Possession & Load"
                transferPointTextBox.Enabled = False
                transferPointLabel.Enabled = False
                rejectReasonTextBox.Enabled = False
                rejectReasonTextBox.Text = ""
                rejectReasonLabel.Enabled = False
            Case "Reroute"
                transferPointTextBox.Enabled = False
                transferPointLabel.Enabled = False
                rejectReasonTextBox.Enabled = False
                rejectReasonLabel.Enabled = False
            Case "Transfer"
                transferPointTextBox.Enabled = True
                transferPointLabel.Enabled = True
                rejectReasonTextBox.Enabled = False
                rejectReasonTextBox.Text = ""
                rejectReasonLabel.Enabled = False
            Case "Unload"
                transferPointTextBox.Enabled = False
                transferPointLabel.Enabled = False
                rejectReasonTextBox.Enabled = False
                rejectReasonTextBox.Text = ""
                rejectReasonLabel.Enabled = False
            Case "Partial Offload"
                transferPointTextBox.Enabled = False
                transferPointLabel.Enabled = False
                rejectReasonTextBox.Enabled = True
                rejectReasonLabel.Enabled = True
            Case "Complete Offload"
                transferPointTextBox.Enabled = False
                transferPointLabel.Enabled = False
                rejectReasonTextBox.Enabled = True
                rejectReasonLabel.Enabled = True
            Case "Return"
                transferPointTextBox.Enabled = False
                transferPointLabel.Enabled = False
                rejectReasonTextBox.Enabled = False
                rejectReasonLabel.Enabled = False

                scanFormLogoPictureBox.Visible = False
                operationComboBox.Visible = False
                operationCodeLabel.Visible = False

                rejectReasonTextBox.Text = InputBox("Please Specify A Return Reason", "Specify Reject Reason", "", 0, 0)

                scanFormLogoPictureBox.Visible = True
                operationComboBox.Visible = True
                operationCodeLabel.Visible = True

            Case "Delivery"
                transferPointTextBox.Enabled = False
                transferPointLabel.Enabled = False
                rejectReasonTextBox.Enabled = False
                rejectReasonTextBox.Text = ""
                rejectReasonLabel.Enabled = False

        End Select

        withinoperationComboBoxSelectedIndexChanged = False

    End Sub


    Private Sub OKButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Close()
    End Sub

    Private Sub exitButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        '
        ' Exit button click after upload. This can occur only when an upload of the resdit file has completed. It returns
        ' the user to the main scan display form.
        '
        'selectTabPage(Me, uploadDownloadFormNextTabPage)

    End Sub

    Private Sub errorExitButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)

        If errorExitFormNextTabPage Is Nothing Then
            Me.Close()
        Else
            selectTabPage(Me, errorExitFormNextTabPage)
        End If

    End Sub

    Public Sub HandleData(ByRef readerString As String)

        scanSequenceVerify(Not readerString Is Nothing, 1)

        logScanSequenceEvent(10001, "HandleData entry point")

        Dim MessageToDisplay As String

        If Len(readerString) <> 12 And Len(readerString) <> 10 Then
            MsgBox("Invalid Mail Tag Bar Code: Must be either 10 or 12 characters long", MsgBoxStyle.Exclamation, "Invalid Scan")
            Exit Sub
        End If

        saveButton.Enabled = False

        DandRTextBoxTextChangedEnabled = False
        weightTextBoxTextChangedEnabled = False

        DandRTextBox.Text = ""
        weightTextBox.Text = ""

        DandRTextBoxTextChangedEnabled = True
        weightTextBoxTextChangedEnabled = True

        DandRTextBox.Text = Substring(readerString, 0, 10)

        scanSequenceVerify(Length(DandRTextBox.Text) = 10, 2)

        If enableCode93CheckBox.Checked Then

            logScanSequenceEvent(10003, "HandleData checking code 93")

            If Length(readerString) = 10 Then

                weightTextBox.Text = "0"

                Dim weightString As String = InputBox("Enter A Weight For This Item")

                If Not isNonNullString(weightString) Then
                    weightString = ""
                Else
                    weightString = Trim(weightString)
                End If

                While Not isValidWeight(weightString)

                    MsgBox("'" & weightString & "' is not a valid weight string.", MsgBoxStyle.Exclamation, "Invalid Weight String")

                    weightString = InputBox("Enter A Weight For This Item")

                    If Not isNonNullString(weightString) Then
                        weightString = ""
                    Else
                        weightString = Trim(weightString)
                    End If

                End While

                weightTextBox.Text = weightString

            ElseIf Length(readerString) = 12 Then

                weightTextBox.Text = Substring(readerString, 10, 2)

                If Not isValidWeight(weightTextBox.Text) Then
                    MsgBox("Invalid weight in D and R Tag: scan ignored", MsgBoxStyle.Exclamation, "Invalid D and R Tag")
                    Exit Sub
                End If

            Else
                systemError("Invalid reader string length")
                Stop
            End If

        Else ' Not using code 93

            If Length(readerString) <> 12 Then
                MsgBox("Invalid D and R Tag: Too few characters.", MsgBoxStyle.Exclamation, "Invalid D and R Tag")
                Exit Sub
            End If

            weightTextBox.Text = Substring(readerString, 10, 2)

        End If

        resetCode93CheckBox()

        logScanSequenceEvent(10003, "HandleData exit to process transaction")

        processTransaction()

        logScanSequenceEvent(10999, "HandleData exit point")

    End Sub

    Private Sub returnToScanPageButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        selectScanTabPage(Me)
    End Sub

    Dim cradleTickCount As Int32 = 2147483647

    Private Sub handleBackgroundFtpTimerEvent()

        Dim test As Integer

#If deviceType <> "Intermec" And deviceType <> "Symbol" Then
        Exit Sub
#End If

        If withinFtpProcess Then Exit Sub

        withinFtpProcess = True

        test = scannerLib.SystemPowerStatus()

        If test <> 1 Then

            ' device is not in cradle.

            If deviceInCradle Then

                ' Status changed. Log event.

                logCradleStateChange(1, False)

            End If

            cradleTickCount = 2147483647       ' Not really necessary -- set autoupload timer to infinity
            deviceInCradle = False             ' Set state variable to "device not in cradle"
            withinFtpProcess = False

            Exit Sub

        Else

            If Not deviceInCradle Then

                ' Status changed. Log event and clear operation code.

                logCradleStateChange(2, True)

                resetOperationComboBoxWithoutWarning()

            End If

        End If

        '
        ' At this point, we know the device is in the cradle.
        '

        If Not deviceInCradle Then

            ' Device has been put in the cradle since the last tick. State change: do transition operation.

            cradleTickCount = 6      ' Set auto upload timer to go off after 30 seconds.
            deviceInCradle = True    ' Set the state variable to "device in cradle

            withinFtpProcess = False

            Exit Sub

        End If

        ' Device is in cradle and was in cradle previously (no state change).

        cradleTickCount -= 1

        If cradleTickCount <= 0 Then

            ' Auto upload timer has gone off.

            turnScannerOff(1001)
            Dim autoFtpProcessDisplayForm As New autoFtpProcessForm
            autoFtpProcessDisplayForm.ShowDialog()
            turnScannerOn(1002)

            cradleTickCount = 12 * 30 ' Reset autoupload timer to 30 minutes

        End If

        withinFtpProcess = False

    End Sub

    Private Sub backgroundFtpTimer_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles backgroundFtpTimer.Tick

        If emulatingPlatform Then Exit Sub

        SyncLock criticalSectionSemiphore

            If criticalSectionSemiphore.getSemiphoreState = False Then

                criticalSectionSemiphore.setSemiphoreState(True)

                activeReaderForm.backgroundFtpTimer.Enabled = False
                activeReaderForm.uploadReminderTimer.Enabled = False

                handleBackgroundFtpTimerEvent()

                activeReaderForm.backgroundFtpTimer.Enabled = True
                activeReaderForm.uploadReminderTimer.Enabled = True

                criticalSectionSemiphore.setSemiphoreState(False)

            End If

        End SyncLock

        Application.DoEvents()

    End Sub

    Private Sub handleUploadButtonClick()

        Dim ftpProcessDisplayForm As New ftpProcessForm
        ftpProcessDisplayForm.ShowDialog()

        If newApplicationVersionFound Then

            Dim newVersionDisplayForm As New newVersionNotification
            newVersionDisplayForm.ShowDialog()

        End If

    End Sub

    Private Sub UploadButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles uploadButton.Click

        logUploadButtonClickEvent(1, "Entering upload button click handler")

        ' The following semiphore should never be needed by this event handler. It is used in
        '    1. The various timers and
        '    2. Ftp processes
        ' to avoid having anything interrupt the scan handling process.

        SyncLock criticalSectionSemiphore

            If criticalSectionSemiphore.getSemiphoreState = False Then

                criticalSectionSemiphore.setSemiphoreState(True)

                turnScannerOff(44)
                activeReaderForm.backgroundFtpTimer.Enabled = False
                activeReaderForm.uploadReminderTimer.Enabled = False

                handleUploadButtonClick()

                turnScannerOn(45)
                activeReaderForm.backgroundFtpTimer.Enabled = True
                activeReaderForm.uploadReminderTimer.Enabled = True

                criticalSectionSemiphore.setSemiphoreState(False)

            End If

        End SyncLock

        Application.DoEvents()

        logUploadButtonClickEvent(2, "Exiting upload button click handler")

    End Sub

    Private Sub destinationComboBox_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles destinationComboBox.SelectedIndexChanged

        Dim destinationCode As String = destinationComboBox.Text
        Dim operationCode As String = operationComboBox.Text

        verify(Length(locationLabel.Text) >= 3, 10)

        Dim locationCode As String = Substring(locationLabel.Text, 0, 3)

        If Not isNonNullString(destinationCode) Then Exit Sub
        If Not isNonNullString(operationCode) Then Exit Sub
        If Not isNonNullString(locationCode) Then Exit Sub

        destinationCode = destinationCode.ToUpper
        locationCode = locationCode.ToUpper
        operationCode = operationCode.ToUpper

        If destinationCode = locationCode Then

            If operationCode = "LOAD" Or operationCode = "POSSESSION & LOAD" Then

                MsgBox("Destination Cannot Be The Same As Origin or Current Location For Load Or Possession and Load Operations", MsgBoxStyle.Exclamation, "Invalid Destination Code")
                destinationComboBox.Text = ""
                destinationComboBox.SelectedIndex = -1

            End If

        End If

    End Sub

    Private Sub flightNumberTextBox_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles flightNumberTextBox.TextChanged

        If Length(flightNumberTextBox.Text) > 0 Then
            summaryButton.Enabled = True
        Else
            summaryButton.Enabled = False
        End If

        flightValidationMessageDisplayed = False

        currentScanScreenPopulatedFromPreset = False

    End Sub


    Private Sub resetCounterButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles resetCounterButton.Click

        Dim response As MsgBoxResult

        response = MsgBox("This Will Reset The Location Counters Only", MsgBoxStyle.OKCancel, "Confirm Counter Reset")

        If response = MsgBoxResult.Cancel Then Exit Sub

        totalWeightLabel.Text = 0
        pieceCountLabel.Text = 0

    End Sub

    Dim withinupdateExpiredPresetsInListBox As Boolean = False

    Public Sub updateExpiredPresetsInListBox()

        Exit Sub

        If withinupdateExpiredPresetsInListBox Then Exit Sub

        withinupdateExpiredPresetsInListBox = True

        Dim currentRecord As Integer = presetListBox.SelectedIndex

        Dim i, ilmt As Integer
        Dim presetRecord As presetRecordClass

        ilmt = presetListBox.Items.Count - 1

        For i = 0 To ilmt
            presetRecord = presetListBox.Items.Item(i)
            presetListBox.Items.Item(i) = presetRecord
        Next

        'For i = 0 To ilmt

        '    Dim presetRecord As presetRecordClass

        '    presetRecord = presetListBox.Items.Item(i)

        '    MsgBox(presetRecord.ToString & " expired = " & presetRecord.presetHasExpired())

        '    If presetRecord.presetHasExpired Then

        '        presetListBox.
        '        'MsgBox("Preset: " & presetRecord.ToString)

        '        'Dim tempPresetRecord As presetRecordClass

        '        'tempPresetRecord = presetListBox.Items.Item(i)

        '        'presetListBox.Items.Item(i) = tempPresetRecord

        '    End If

        '    i += 1

        'Next

        presetListBox.Refresh()

        presetListBox.SelectedIndex = currentRecord

        withinupdateExpiredPresetsInListBox = False

    End Sub

    Dim withinSetCurrentRecord As Boolean = False

    Private Sub setCurrentRecord(ByVal currentRecord As Integer)

        If withinSetCurrentRecord Then Exit Sub

        withinSetCurrentRecord = True

        'updateExpiredPresetsInListBox()

        If currentRecord < 0 Or currentRecord >= presetListBox.Items.Count Then

            presetFlightNumberTextBox.Text = ""
            presetBatchIDTextBox.Text = ""
            presetDestinationComboBox.SelectedIndex = -1
            presetDestinationComboBox.Text = ""
            withinSetCurrentRecord = False

            presetListBox.Refresh()

            presetListBox.SelectedIndex = -1

            withinSetCurrentRecord = False

            Exit Sub

        End If

        Dim presetRecord As presetRecordClass = presetListBox.Items.Item(currentRecord)

        If presetRecord.isReroutePreset Then

            presetFlightNumberTextBox.Text = presetRecord.newFlightNumber.PadLeft(4, "0")

            If isNonNullString(presetRecord.newDestination) Then

                presetDestinationComboBox.SelectedItem = presetRecord.newDestination

            Else

                presetDestinationComboBox.SelectedIndex = -1
                presetDestinationComboBox.Text = ""

            End If

        Else

            presetFlightNumberTextBox.Text = presetRecord.flightNumber.PadLeft(4, "0")

            If isNonNullString(presetRecord.destination) Then

                presetDestinationComboBox.SelectedItem = presetRecord.destination

            Else

                presetDestinationComboBox.SelectedIndex = -1
                presetDestinationComboBox.Text = ""

            End If

        End If


        presetBatchIDTextBox.Text = presetRecord.batchID
        staticPresetCheckBox.Checked = presetRecord.staticPresetFlag

        'presetRecord = presetListBox.Items.Item(currentRecord)
        'presetListBox.Items.Item(currentRecord) = presetRecord

        presetListBox.SelectedIndex = currentRecord

        'presetListBox.Refresh()
        presetListBox.SelectedIndex = currentRecord

        withinSetCurrentRecord = False

    End Sub

    Private Function verifyNonUniqueKeepPreset(ByRef presetRecord As presetRecordClass, ByVal currentRecordNumber As Integer) As Boolean

        If Not presetRecord.staticPresetFlag Then Return True

        Dim comparePresetRecord As presetRecordClass

        Dim i As Integer = 0

        For Each comparePresetRecord In presetListBox.Items

            If i <> currentRecordNumber Then

                If comparePresetRecord.staticPresetFlag Then

                    If comparePresetRecord.origin = presetRecord.origin Then

                        If comparePresetRecord.destination = presetRecord.destination Then

                            If comparePresetRecord.batchID = presetRecord.batchID Then
                                Return False
                            End If

                        End If

                    End If

                End If

            End If

            i += 1
        Next

        Return True

    End Function

    Dim processingAddItemToPresetListButtonClick As Boolean = False

    Private Sub addItemToPresetListButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles addItemToPresetListButton.Click

        If processingAddItemToPresetListButtonClick Then Exit Sub

        processingAddItemToPresetListButtonClick = True

        updateExpiredPresetsInListBox()

        Dim origin As String
        Dim destination As String
        Dim flightNumber As String
        Dim batchID As String
        Dim staticPreset As Boolean = staticPresetCheckBox.Checked

        origin = presetOriginLabel.Text
        destination = presetDestinationComboBox.Text
        flightNumber = presetFlightNumberTextBox.Text
        batchID = presetBatchIDTextBox.Text

        If Not isValidLocationCode(origin) Then
            MsgBox("You must select a valid origin to create a preset record", MsgBoxStyle.Exclamation, "Invalid Origin")
            processingAddItemToPresetListButtonClick = False
            Exit Sub
        End If

        If Not isValidFlightNumber(flightNumber) Then
            MsgBox("You must specify a valid flight number to create a preset record", MsgBoxStyle.Exclamation, "Invalid Flight Number")
            processingAddItemToPresetListButtonClick = False
            Exit Sub
        End If

        If Not isValidBatchID(batchID) Then
            If user = "ATA" Then
                MsgBox("You must specify a valid cart ID to create a preset record", MsgBoxStyle.Exclamation, "Invalid Cart ID")
            Else
                MsgBox("You must specify a valid batch ID to create a preset record", MsgBoxStyle.Exclamation, "Invalid Batch ID")
            End If

            processingAddItemToPresetListButtonClick = False
            Exit Sub
        End If

        If userSpecRecord.presetsRequireDestinationSpecifications Or Not isNonNullString(destination) Then

            If Not isValidLocationCode(destination) Then
                MsgBox("Invalid destination code specified", MsgBoxStyle.Exclamation, "Invalid Destination")
                processingAddItemToPresetListButtonClick = False
                Exit Sub
            End If

            If origin = destination Then
                MsgBox("Origin Cannot Be The Same As Destination", MsgBoxStyle.Exclamation, "Invalid Destination")
                processingAddItemToPresetListButtonClick = False
                Exit Sub
            End If

        End If

        Dim newPresetRecord As New presetRecordClass(staticPreset.ToString, origin, destination, flightNumber, batchID)

        If presetListBox.Items.Contains(newPresetRecord) Then
            MsgBox("Preset record already defined.", MsgBoxStyle.Exclamation, "Dupicate Preset Record")
            processingAddItemToPresetListButtonClick = False
            Exit Sub
        End If

        If Not verifyNonUniqueKeepPreset(newPresetRecord, -1) Then

            Dim errorString As String = "Only one keep preset allowed with this origin, destination, and "

            If user = "ATA" Then
                errorString &= "cart id"
            Else
                errorString &= "batch id"
            End If

            MsgBox(errorString, MsgBoxStyle.Exclamation, "Duplicate Keep Preset")
            processingAddItemToPresetListButtonClick = False
            Exit Sub

        End If

        Dim i, ilmt As Integer

        ilmt = presetListBox.Items.Count - 1

        For i = 0 To ilmt
            If newPresetRecord.compare(presetListBox.Items.Item(i)) = 0 Then
                MsgBox("This Preset Record Is Already In The List of Existing Preset Records.", MsgBoxStyle.Exclamation, "Duplicate Preset Record")
                processingAddItemToPresetListButtonClick = False
                Exit Sub
            End If
        Next

        logPresetEvent(1, "Add", newPresetRecord.formatForUpload)

        presetListBox.Items.Add(newPresetRecord)

        setCurrentRecord(presetListBox.Items.Count - 1)

        processingAddItemToPresetListButtonClick = False

    End Sub

    Dim withinPresetListBoxSelectedIndexChanged As Boolean = False

    Private Sub presetListBox_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles presetListBox.SelectedIndexChanged

        If withinPresetListBoxSelectedIndexChanged Then Exit Sub

        withinPresetListBoxSelectedIndexChanged = True

        setCurrentRecord(presetListBox.SelectedIndex)

        withinPresetListBoxSelectedIndexChanged = False

    End Sub

    Dim withinPresetDeleteCurrentItemButtonClick As Boolean = False

    Private Sub presetDeleteCurrentItemButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles presetDeleteCurrentItemButton.Click

        If withinPresetDeleteCurrentItemButtonClick Then Exit Sub

        withinPresetDeleteCurrentItemButtonClick = True

        If presetListBox.Items.Count <= 0 Then

            MsgBox("No Item Selected To Delete")

            withinPresetDeleteCurrentItemButtonClick = False
            Exit Sub
        End If

        Dim currentRecord As Integer = presetListBox.SelectedIndex

        If currentRecord < 0 Or currentRecord >= presetListBox.Items.Count Then
            MsgBox("No Item Selected To Delete")
            withinPresetDeleteCurrentItemButtonClick = False
            Exit Sub
        End If

        Dim presetRecord As presetRecordClass = presetListBox.Items.Item(currentRecord)

        logPresetEvent(1, "Deleted", presetRecord.formatForUpload)

        presetListBox.Items.RemoveAt(currentRecord)

        If currentRecord >= presetListBox.Items.Count Then
            currentRecord -= 1
        End If

        setCurrentRecord(currentRecord)

        withinPresetDeleteCurrentItemButtonClick = False

    End Sub

    Dim withinPresetClearListButtonClick As Boolean = False

    Private Sub presetClearListButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles presetClearListButton.Click

        If withinPresetClearListButtonClick Then Exit Sub

        withinPresetClearListButtonClick = True

        presetListBox.Items.Clear()
        presetListBox.SelectedIndex = -1

        withinPresetClearListButtonClick = False

    End Sub

    Dim withinPresetUpdateItemButtonClick As Boolean = False

    Private Sub presetUpdateItemButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles presetUpdateItemButton.Click

        If withinPresetUpdateItemButtonClick Then Exit Sub

        withinPresetUpdateItemButtonClick = True

        Dim currentRecord As Integer = presetListBox.SelectedIndex

        'updateExpiredPresetsInListBox()

        If currentRecord < 0 Or currentRecord >= presetListBox.Items.Count Then
            MsgBox("No item selected to update")
            withinPresetUpdateItemButtonClick = False
            Exit Sub
        End If

        Dim presetRecord As presetRecordClass = presetListBox.Items.Item(currentRecord)

        Dim origin As String
        Dim destination As String
        Dim flightNumber As String
        Dim batchID As String

        origin = presetOriginLabel.Text
        destination = presetDestinationComboBox.Text
        flightNumber = presetFlightNumberTextBox.Text
        batchID = presetBatchIDTextBox.Text

        If Not isValidLocationCode(origin) Then
            MsgBox("You must select a valid origin to update a preset record", MsgBoxStyle.Exclamation, "Invalid Origin")
            withinPresetUpdateItemButtonClick = False
            Exit Sub
        End If

        If Not isValidFlightNumber(flightNumber) Then
            MsgBox("You must specify a valid flight number to update a preset record", MsgBoxStyle.Exclamation, "Invalid Flight Number")
            withinPresetUpdateItemButtonClick = False
            Exit Sub
        End If

        If Not isValidBatchID(batchID) Then
            If user = "ATA" Then
                warning("A Cart ID Is Required to update a preset record", MsgBoxStyle.Exclamation, "Invalid Cart ID")
            Else
                warning("A Batch ID Is Required to update a preset record", MsgBoxStyle.Exclamation, "Invalid Batch ID")
            End If

            withinPresetUpdateItemButtonClick = False
            Exit Sub
        End If

        If isNonNullString(destination) Then

            If Not isValidLocationCode(destination) Then
                MsgBox("Invalid destination code specified", MsgBoxStyle.Exclamation, "Invalid Destination")
                withinPresetUpdateItemButtonClick = False
                Exit Sub

                If origin = destination Then
                    MsgBox("Origin Cannot Be The Same As Destination", MsgBoxStyle.Exclamation, "Invalid Destination")
                    withinPresetUpdateItemButtonClick = False
                    Exit Sub
                End If

                presetDestinationComboBox.SelectedItem = destination

            End If
        End If

        presetRecord.staticPresetFlag = staticPresetCheckBox.Checked
        presetRecord.origin = origin
        presetRecord.destination = destination
        presetRecord.flightNumber = flightNumber.PadLeft(4, "0")
        presetRecord.batchID = batchID
        presetRecord.presetCreationDateAndTime = DateTime.UtcNow

        Dim i, ilmt As Integer

        ilmt = presetListBox.Items.Count - 1

        For i = 0 To ilmt
            If i <> currentRecord Then
                If presetRecord.compare(presetListBox.Items.Item(i)) = 0 Then
                    MsgBox("Updated Preset Record Is Now The Same As An Existing Preset Record.", MsgBoxStyle.Exclamation, "Duplicate Preset Record")
                    withinPresetUpdateItemButtonClick = False
                    Exit Sub
                End If
            End If
        Next

        If Not verifyNonUniqueKeepPreset(presetRecord, presetListBox.SelectedIndex) Then

            Dim errorString As String = "Only one keep preset allowed with this origin, destination, and "

            If user = "ATA" Then
                errorString &= "cart id"
            Else
                errorString &= "batch id"
            End If

            errorString &= ": Update creates a duplicate"

            MsgBox(errorString, MsgBoxStyle.Exclamation, "Duplicate Keep Preset")
            withinPresetUpdateItemButtonClick = False
            Exit Sub

        End If

        updateGlobalScanCount()
        presetRecord.globalScanCountOnCreation = globalScanCount

        presetListBox.Items.Item(currentRecord) = presetRecord

        setCurrentRecord(currentRecord)

        presetListBox.SelectedIndex = currentRecord

        logPresetEvent(1, "Updated", presetRecord.formatForUpload)

        withinPresetUpdateItemButtonClick = False

    End Sub

    Private Function isValidPresetFileName(ByRef fileName As String) As Boolean

        verify(Not fileName Is Nothing, 11)

        Dim presetFileName As String = fileName

        If Not presetFileName.StartsWith("Preset") Then Return False

        If Not presetFileName.EndsWith(".txt") Then Return False

        verify(Length(fileName) >= 6, 12)

        Dim presetFileDateStampString As String = Substring(fileName, 6)

        If Length(presetFileDateStampString) <> 14 Then Return False

        verify(Length(presetFileDateStampString) >= 10, 13)

        presetFileDateStampString = Substring(presetFileDateStampString, 0, 10)

        If Not IsNumeric(presetFileDateStampString) Then Return False

        Dim yy As Integer = Substring(presetFileDateStampString, 0, 2) + 2000
        Dim mm As Integer = Substring(presetFileDateStampString, 2, 2)
        Dim dd As Integer = Substring(presetFileDateStampString, 4, 2)
        Dim hh As Integer = Substring(presetFileDateStampString, 6, 2)
        Dim mx As Integer = Substring(presetFileDateStampString, 8, 2)

        Dim presetFileDateStamp As New DateTime(yy, mm, dd, hh, mx, 0)
        Dim presetFileAge As TimeSpan = presetFileDateStamp.Subtract(scannerNow())

        Dim presetFileAgeHours As Integer = presetFileAge.Days * 24 + presetFileAge.Hours

        If presetFileAgeHours > 8 Then Return False

        Return True

    End Function

    Dim withinPresetLoadListButtonClick As Boolean = False

    Private Sub presetLoadListButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles presetLoadListButton.Click

        If withinPresetLoadListButtonClick Then Exit Sub

        withinPresetLoadListButtonClick = True
        Dim di As DirectoryInfo

        Try
            di = New DirectoryInfo(presetFileDirectory)
        Catch ex As Exception
            MsgBox("Unable To Access The Preset File Directory," & presetFileDirectory & ": " & ex.Message)
            Exit Sub
        End Try

        Dim i As Integer

        Dim files() As FileInfo

        Try
            files = di.GetFiles()
        Catch ex As Exception
            MsgBox("Stat on files in directory " & presetFileDirectory & " failed: " & ex.Message)
            Exit Sub
        End Try

        Dim presetFileFound As Boolean = False
        Dim currentPresetFileName As String = ""

        For i = 0 To files.Length - 1

            Dim nextFileName As String = files(i).Name

            If isValidPresetFileName(nextFileName) Then
                If nextFileName > currentPresetFileName Then
                    currentPresetFileName = nextFileName
                End If
                presetFileFound = True
            End If

        Next i

        If presetFileFound Then

            presetListBox.Items.Clear()

            Dim presetAgeLimit As DateTime = DateTime.UtcNow

            presetAgeLimit.AddHours(-8.0)

            Dim presetFileStream As StreamReader

            Try
                presetFileStream = New StreamReader(presetFileDirectory & backSlash & currentPresetFileName)
            Catch ex As Exception
                MsgBox("Attempt to open preset file " & presetFileDirectory & backSlash & currentPresetFileName & " failed: " & ex.Message)
                Exit Sub
            End Try

            Dim inputPresetRecordString As String
            Dim recordNumber As Integer = 1

            Try
                inputPresetRecordString = presetFileStream.ReadLine()
            Catch ex As Exception
                MsgBox("Read of record " & recordNumber & " from preset file" & presetFileDirectory & backSlash & currentPresetFileName & " failed: " & ex.Message)
                Exit Sub
            End Try

            While Not inputPresetRecordString Is Nothing

                Dim tokenSet() As String = inputPresetRecordString.Split(",")

                If tokenSet.Length <> 9 Then
                    systemError("Invalid Record In Preset File")
                End If

                Dim staticPreset As String = Trim(tokenSet(0))
                Dim origin As String = Trim(tokenSet(1))
                Dim destination As String = Trim(tokenSet(2))
                Dim flightNumber As String = Trim(tokenSet(3))
                Dim batchID As String = Trim(tokenSet(4))
                Dim newDestination As String = Trim(tokenSet(5))
                Dim newFlightNumber As String = Trim(tokenSet(6))
                Dim newDateAndTime As String = Trim(tokenSet(7))
                Dim newGlobalScanCountOnCreation As Integer = CInt(tokenSet(8))

                updateGlobalScanCount()
                Dim nextPresetRecord As New presetRecordClass(staticPreset, origin, destination, flightNumber, batchID, newDestination, newFlightNumber, newDateAndTime, globalScanCount)

                presetListBox.Items.Add(nextPresetRecord)

                recordNumber += 1

                Try
                    inputPresetRecordString = presetFileStream.ReadLine()
                Catch ex As Exception
                    MsgBox("Read of record " & recordNumber & " from preset file" & presetFileDirectory & backSlash & currentPresetFileName & " failed: " & ex.Message)
                    Exit Sub
                End Try

            End While

            Try
                presetFileStream.Close()
            Catch ex As Exception
                MsgBox("Attempt to close preset file" & presetFileDirectory & backSlash & currentPresetFileName & " failed: " & ex.Message)
                Exit Sub
            End Try

            If recordNumber > 0 Then
                setCurrentRecord(0)
            End If

        Else
            MsgBox("No Current Preset List Defined", MsgBoxStyle.Exclamation, "No Current Preset List")
        End If

        withinPresetLoadListButtonClick = False


    End Sub

    Dim withinPresetSaveListButtonClick As Boolean = False

    Private Sub presetSaveListButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles presetSaveListButton.Click

        If withinPresetSaveListButtonClick Then Exit Sub

        withinPresetSaveListButtonClick = True

        Dim deleteExpiredPresets As Boolean = False

        Dim containsExpiredRecords As Boolean = False
        Dim presetRecord As presetRecordClass

        For Each presetRecord In presetListBox.Items
            If presetRecord.presetHasExpired Then
                containsExpiredRecords = True
                Exit For
            End If
        Next
        If containsExpiredRecords Then

            updateExpiredPresetsInListBox()

            Dim result As MsgBoxResult = MsgBox("Remove Expired Records From Saved Preset Set?", MsgBoxStyle.YesNo)
            If result = MsgBoxResult.Yes Then
                deleteExpiredPresets = True
            Else
                deleteExpiredPresets = False
            End If
        End If

        Dim di As New DirectoryInfo(presetFileDirectory)
        Dim i As Integer

        Dim files As FileInfo() = di.GetFiles()

        Dim presetFileFound As Boolean = False
        Dim currentPresetFileName As String = ""

        If files.Length > 1 Then

            For i = 0 To files.Length - 2

                Dim nextFileName As String = files(i).Name

                If nextFileName.StartsWith("Preset") Then
                    deleteLocalFile(presetFileDirectory & backSlash & nextFileName)
                End If

            Next i

        End If

        Dim presetFileName As String = String.Format("\Preset{0:yyMMddHHmm}.txt", scannerNow())
        Dim presetFilePath As String = presetFileDirectory & presetFileName

        deleteLocalFile(presetFilePath)

        'If File.Exists(presetFilePath) Then
        '    deleteLocalFile(presetFilePath)
        'End If

        Dim presetFileStream As New StreamWriter(presetFilePath)

        Dim presetOutputString As String

        i = 0

        For Each presetRecord In presetListBox.Items

            If presetRecord.staticPresetFlag Then

                If presetRecord.isReroutePreset Then

                    Dim outputPreset As New presetRecordClass(presetRecord)

                    outputPreset.newDestination = ""
                    outputPreset.newFlightNumber = ""

                    presetOutputString = outputPreset.formatForOutput
                    presetFileStream.WriteLine(presetOutputString)

                Else

                    presetOutputString = presetRecord.formatForOutput
                    presetFileStream.WriteLine(presetOutputString)

                End If

            Else

                Dim listBoxItem As String = presetListBox.Items.Item(i).ToString

                If listBoxItem.StartsWith("E") Then

                    If Not deleteExpiredPresets Then

                        presetOutputString = presetRecord.formatForOutput
                        presetFileStream.WriteLine(presetOutputString)

                    End If

                Else

                    presetOutputString = presetRecord.formatForOutput
                    presetFileStream.WriteLine(presetOutputString)

                End If

            End If

            i += 1

        Next

        presetFileStream.Close()


        MsgBox("List Saved", MsgBoxStyle.Information)

        withinPresetSaveListButtonClick = False

    End Sub

    Private Sub closeoutReaderOperations()
#If deviceType = "Intermec" Then

        If emulatingPlatform Then Exit Sub

        scanReader.disable()
#End If
    End Sub

    Private Sub readerForm_Closing(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles MyBase.Closing

#If deviceType = "PC" Then
        Exit Sub
#End If

        If Me.DialogResult = DialogResult.Abort Then
            closeoutReaderOperations()
            Exit Sub
        End If

        'Dim baseDisplayForm As New baseForm(appExitFlag)

        'baseDisplayForm.ShowDialog()

        'If appExitFlag.exitFlag Then
        '    closeoutReaderOperations()
        '    Exit Sub
        'End If

        'e.Cancel = True

    End Sub

    Private Sub DandRTextBox_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DandRTextBox.TextChanged

        If Not DandRTextBoxTextChangedEnabled Then Exit Sub

        setSaveButtonStatus()

    End Sub

    Private Sub weightTextBox_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles weightTextBox.TextChanged

        If Not weightTextBoxTextChangedEnabled Then Exit Sub

        setSaveButtonStatus()

    End Sub

    Public Sub setSaveButtonStatus()

        If isValidDandRTag(DandRTextBox.Text) And isValidWeight(weightTextBox.Text) Then
            saveButton.Enabled = True
        Else
            saveButton.Enabled = False
        End If

    End Sub

    Dim withinReroutButtonClick As Boolean = False

    Private Sub rerouteButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rerouteButton.Click

        If withinReroutButtonClick Then Exit Sub

        withinReroutButtonClick = True

        If presetListBox.SelectedIndex < 0 Or presetListBox.SelectedIndex >= presetListBox.Items.Count Or presetListBox.Items.Count = 0 Then

            MsgBox("No preset record to reroute", MsgBoxStyle.Exclamation)

            withinReroutButtonClick = False

            Exit Sub

        End If

        Dim currentRecord As Integer = presetListBox.SelectedIndex

        Dim presetRecord As presetRecordClass = presetListBox.Items.Item(presetListBox.SelectedIndex)

        Dim rerouteDisplayForm As New rerouteForm(Me, presetRecord)

        rerouteDisplayForm.ShowDialog()

        Dim i, ilmt As Integer

        ilmt = presetListBox.Items.Count - 1

        For i = 0 To ilmt
            If i <> currentRecord Then

                If presetRecord.compare(presetListBox.Items.Item(i)) = 0 Then
                    MsgBox("Reroute Preset Record Is Now The Same As An Existing Preset Record.", MsgBoxStyle.Exclamation, "Duplicate Preset Record")
                    withinPresetUpdateItemButtonClick = False
                    Exit Sub
                End If

            End If
        Next

        logPresetEvent(1, "Rerouted", presetRecord.formatForUpload)

        presetListBox.Items.Item(currentRecord) = presetRecord

        setCurrentRecord(currentRecord)

        presetListBox.Refresh()

        presetListBox.SelectedIndex = currentRecord

        withinReroutButtonClick = False

    End Sub

    Private Sub summaryButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles summaryButton.Click

        selectSummaryTabPage(Me)

    End Sub

    Private Sub presetButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles presetButton.Click

        updateExpiredPresetsInListBox()

        selectPresetTabPage(Me)

    End Sub

    Private Sub scanButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles scanButton.Click

        selectScanTabPage(Me)

    End Sub

    Private Sub exitButton_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles exitButton.Click

        'Dim baseDisplayForm As New baseForm(appExitFlag)

        'resetOperationComboBoxWithoutWarning()

        'baseDisplayForm.ShowDialog()

        'If appExitFlag.exitFlag Then
        '    Me.Close()
        '    Exit Sub
        'End If

        'updateExpiredPresetsInListBox()

    End Sub

    Private Sub selectItemButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles selectItemButton.Click

        If presetListBox.SelectedIndex < 0 Or presetListBox.SelectedIndex >= presetListBox.Items.Count Then
            MsgBox("No Preset Record Selected")
            Exit Sub
        End If

        Dim presetRecord As presetRecordClass = presetListBox.Items.Item(presetListBox.SelectedIndex)

        groupNumberTextBox.Text = presetRecord.batchID

        updateExpiredPresetsInListBox()

        If presetRecord.presetHasBeenUsed Then
            Dim result As MsgBoxResult = MsgBox("This Preset Has Already Been Used. Use It Again?", MsgBoxStyle.YesNo, "Reuse of Preset")
            If result = MsgBoxResult.No Then Exit Sub
        End If

        verify(Length(locationLabel.Text) >= 3, 14)

        If presetRecord.origin <> Substring(locationLabel.Text, 0, 3) Then
            MsgBox("Preset Origin Does Not Correspond To Current Location")
            Exit Sub
        End If

        Dim listBoxItem As String = presetListBox.Items.Item(presetListBox.SelectedIndex).ToString

        If listBoxItem.StartsWith("E") Then
            Dim result As MsgBoxResult = MsgBox("This Preset Has Expired. Use It Anyway?", MsgBoxStyle.YesNo, "Expired Preset")
            If result = MsgBoxResult.No Then Exit Sub
        End If

        If presetRecord.isReroutePreset Then
            flightNumberTextBox.Text = presetRecord.newFlightNumber
            destinationComboBox.SelectedItem = presetRecord.newDestination
        Else
            flightNumberTextBox.Text = presetRecord.flightNumber
            destinationComboBox.SelectedItem = presetRecord.destination
        End If

        presetRecord.presetHasBeenUsed = True

        currentScanScreenPopulatedFromPreset = True
        lastSelectedPresetForScanScreen = presetListBox.SelectedIndex

        selectScanTabPage(Me)

    End Sub


    Private Sub formKeyPress(ByVal sender As System.Object, ByVal ex As KeyPressEventArgs) Handles MyBase.KeyPress

        'If ex.KeyChar = "0" Then
        '    exitString = ""
        '    Exit Sub
        'End If

        'exitString &= ex.KeyChar

        'If exitString = backdoorExitPassword Then
        '    appExitFlag.exitFlag = True
        '    Me.Close()
        'End If

    End Sub

    Dim withinUploadReminderTimer As Boolean = False

    Private Sub updateUploadReminder()

        Dim resditFileSize As Integer = getFileSize(localResditFileName, resditFileDirectory)

        If resditFileSize <= 0 Then

            uploadReminderMinuteCount = 120
            Exit Sub

        End If

        If uploadReminderMinuteCount = 30 Then

            FormRepository.resditUploadReminderForm.initResditUploadReminderForm(30)
            Me.DialogResult = FormRepository.resditUploadReminderForm.ShowDialog()
            If Me.DialogResult = DialogResult.Abort Then
                Me.Close()
                Exit Sub
            End If

        End If

        If uploadReminderMinuteCount = 15 Then

            FormRepository.resditUploadReminderForm.initResditUploadReminderForm(15)
            Me.DialogResult = FormRepository.resditUploadReminderForm.ShowDialog()
            If Me.DialogResult = DialogResult.Abort Then
                Me.Close()
                Exit Sub
            End If

        End If

        If uploadReminderMinuteCount = 10 Then

            FormRepository.resditUploadReminderForm.initResditUploadReminderForm(10)
            Me.DialogResult = FormRepository.resditUploadReminderForm.ShowDialog()
            If Me.DialogResult = DialogResult.Abort Then
                Me.Close()
                Exit Sub
            End If

        End If

        If uploadReminderMinuteCount = 5 Then

            FormRepository.resditUploadReminderForm.initResditUploadReminderForm(5)
            Me.DialogResult = FormRepository.resditUploadReminderForm.ShowDialog()
            If Me.DialogResult = DialogResult.Abort Then
                Me.Close()
                Exit Sub
            End If

        End If

        If uploadReminderMinuteCount <= 0 Then
            uploadReminderMinuteCount = 5
        End If

    End Sub

    Private Sub uploadReminderTimer_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles uploadReminderTimer.Tick

#If deviceType = "PC" Then
        Exit Sub
#End If

        If emulatingPlatform Then Exit Sub

        SyncLock criticalSectionSemiphore

            If criticalSectionSemiphore.getSemiphoreState = False Then

                criticalSectionSemiphore.setSemiphoreState(True)

                activeReaderForm.backgroundFtpTimer.Enabled = False
                activeReaderForm.uploadReminderTimer.Enabled = False

                uploadReminderMinuteCount -= 1

                updateUploadReminder()

                activeReaderForm.backgroundFtpTimer.Enabled = True
                activeReaderForm.uploadReminderTimer.Enabled = True

                criticalSectionSemiphore.setSemiphoreState(False)

            End If

        End SyncLock

        Application.DoEvents()

    End Sub

    Dim enable93CheckBoxState As Integer = 0
    Dim withinEnableCode93CheckBoxEvent As Boolean = False

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
            code93LockedPictureBox.Visible = False

            If emulatingPlatform Then Exit Sub

            scannerLib.Code93NotActive()

            Exit Sub

        ElseIf enable93CheckBoxState = 1 Then

            'enableCode93CheckBox.Checked = True
            code93LockedPictureBox.Visible = False
            enableCode93CheckBox.CheckState = CheckState.Indeterminate

            If emulatingPlatform Then Exit Sub

            scannerLib.Code93Active()

            Exit Sub

        ElseIf enable93CheckBoxState = 2 Then
            'enableCode93CheckBox.Checked = True
            code93LockedPictureBox.Visible = True
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

    End Sub

    Private Sub startUpButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)

        'Dim initDisplayForm As New initializationForm(Me, appExitFlag)

        'resetOperationComboBoxWithoutWarning()

        'initDisplayForm.ShowDialog()

        'If appExitFlag.exitFlag Then
        '    Me.Close()
        'End If

        'updateExpiredPresetsInListBox()


    End Sub

    Private Sub setNewLocation()

        locationLabel.Text = locationComboBox.Text

        verify(Length(locationLabel.Text) >= 3, 6)

        Dim airport As locationClass = airportSet.Item(Substring(activeReaderForm.locationLabel.Text, 0, 3).ToUpper)

        If airport Is Nothing Then
            MsgBox("Airport '" & locationLabel.Text & "' is not in the current location set.")
            Stop
        End If

        scannerTimeZone = airport.timeZone

        saveLastLocation(Substring(locationLabel.Text, 0, 3))

    End Sub

    Private Sub locationComboBox_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles locationComboBox.SelectedIndexChanged

        If doNotConfirmLocationChange Then
            setNewLocation()
            Exit Sub
        End If

        If Not userSpecRecord.passwordRequiredForLocationChangeOnScanForm Then
            setNewLocation()
            Exit Sub
        End If

        verify(Length(locationLabel.Text) >= 3, 7)

        Dim newLocation As String = locationComboBox.SelectedItem
        Dim oldLocation As String = Substring(locationLabel.Text, 0, 3).ToUpper

        verify(Length(newLocation) >= 3, 8)

        newLocation = Substring(newLocation, 0, 3).ToUpper

        If newLocation = oldLocation Then ' this can happen because of suffixes on locations
            setNewLocation()
            Exit Sub
        End If

        Select Case oldLocation

            Case "TPA"

                If newLocation = "PIE" Then
                    setNewLocation()
                    Exit Sub
                End If

            Case "PIE"

                If newLocation = "TPA" Then
                    setNewLocation()
                    Exit Sub
                End If

            Case "SFO"

                If newLocation = "SMF" Then
                    setNewLocation()
                    Exit Sub
                End If

            Case "SMF"

                If newLocation = "SFO" Then
                    setNewLocation()
                    Exit Sub
                End If

        End Select

        Dim changeLocationPasswordDialog As New changeLocationInputBox

        Dim result As DialogResult = changeLocationPasswordDialog.ShowDialog

        If result = DialogResult.Cancel Then

            locationComboBox.SelectedItem = locationLabel.Text

            Exit Sub

        End If

        setNewLocation()
    End Sub

    Private Sub locationLabel_textChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles locationLabel.TextChanged

        logLocationChange(1)

        currentScanScreenPopulatedFromPreset = False

    End Sub

    Private Sub groupNumberTextBox_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles groupNumberTextBox.TextChanged
        currentScanScreenPopulatedFromPreset = False
    End Sub

    'Private Sub scanFormTab_GotFocus(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles scanFormTab.GotFocus

    '    StartRead()

    'End Sub

    'Private Sub scanFormTab_LostFocus(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles scanFormTab.LostFocus

    '    StopRead()

    '    MsgBox("Lost Focus")

    'End Sub

    Private Sub changeBin_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles binChangeButton.Click
        selectBinChangeTabPage(Me)
    End Sub

    Private Sub BinChangeOKButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles OKButton.Click

        If Not isNonNullString(binChangeFlightNumberTextBox.Text) Then
            MsgBox("A valid flight number must be specified to create a bin change record.", MsgBoxStyle.Exclamation, "Missing Flight Number")
            Exit Sub
        End If

        If Not isValidBatchID(oldBinTextBox.Text) Then
            If user = "ATA" Then
                MsgBox("Invalid Old Cart ID", MsgBoxStyle.Exclamation, "Invalid Cart ID")
            Else
                MsgBox("Invalid Old Batch ID", MsgBoxStyle.Exclamation, "Invalid Batch ID")
            End If
            Exit Sub
        End If

        If Not isValidBatchID(newBinTextBox.Text) Then
            If user = "ATA" Then
                MsgBox("Invalid New Cart ID", MsgBoxStyle.Exclamation, "Invalid Cart ID")
            Else
                MsgBox("Invalid New Batch ID", MsgBoxStyle.Exclamation, "Invalid Batch ID")
            End If
            Exit Sub

        End If

        If Not isValidFlightNumber(binChangeFlightNumberTextBox.Text) Then

            MsgBox("Invalid Flight Number", MsgBoxStyle.Exclamation, "Invalid Flight Number")

            Exit Sub

        End If

        Dim binChangeRecordKey = oldBinTextBox.Text & newBinTextBox.Text & binChangeFlightNumberTextBox.Text & binChangeLocationLabel.Text

        If binChangeTable.ContainsKey(binChangeRecordKey) Then

            If user = "ATA" Then
                MsgBox("Batch Change Record Already Exists.", MsgBoxStyle.Exclamation, "Duplicate Bin Change Record")
            Else
                MsgBox("Bin Change Record Already Exists.", MsgBoxStyle.Exclamation, "Duplicate Bin Change Record")
            End If

            Exit Sub

        End If

        Dim binChangeRecord As New BinChangeRecordClass(oldBinTextBox.Text, newBinTextBox.Text, binChangeFlightNumberTextBox.Text, binChangeLocationLabel.Text)

        binChangeTable.Add(binChangeRecordKey, binChangeRecord)

        Dim binChangeOutputStream As StreamWriter

        Try
            binChangeOutputStream = New StreamWriter(binChangeFilePath, True)
        Catch ex As Exception
            MsgBox("Unable to open bin change file: " & ex.Message)
            Exit Sub
        End Try

        Try
            binChangeOutputStream.WriteLine(binChangeRecord.ToString)
        Catch ex As Exception
            MsgBox("Unable to write to bin change file: " & ex.Message)
            Exit Sub
        End Try

        binChangeOutputStream.Close()

        oldBinTextBox.Text = ""
        newBinTextBox.Text = ""

    End Sub

    Private Sub cancelButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        oldBinTextBox.Text = ""
        newBinTextBox.Text = ""
    End Sub

    Private Sub binUploadOKButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles binUploadOKButton.Click

        If Not isNonNullString(binUploadFlightNumberTextBox.Text) Then
            MsgBox("A valid flight number must be specified to create a bin upload record.", MsgBoxStyle.Exclamation, "Missing Flight Number")
            Exit Sub
        End If

        If Not isValidBatchID(binUploadBinIDTextBox.Text) Then
            If user = "ATA" Then
                MsgBox("Invalid Cart ID", MsgBoxStyle.Exclamation, "Invalid Cart ID")
            Else
                MsgBox("Invalid Batch ID", MsgBoxStyle.Exclamation, "Invalid Batch ID")
            End If
            Exit Sub
        End If

        If Not isValidFlightNumber(binUploadFlightNumberTextBox.Text) Then

            MsgBox("Invalid Flight Number", MsgBoxStyle.Exclamation, "Invalid Flight Number")
            Exit Sub

        End If

        If Not isValidLocation(Me.binUploadDestinationComboBox.Text) Then

            MsgBox("A valid destination must be specified", MsgBoxStyle.Exclamation, "Invalid Destination")
            Exit Sub

        End If

        Dim binUploadRecord As New binUploadRecordClass(binUploadBinIDTextBox.Text, binUploadFlightNumberTextBox.Text, binUploadDestinationComboBox.Text)

        Dim result As String

        result = binUploadRecord.write(binUploadFilePath)

        If result <> "OK" Then

            If user = "ATA" Then
                MsgBox("Write of batch upload record failed: " & result, MsgBoxStyle.Exclamation, "Write Of Batch Upload Record Failed")
            Else
                MsgBox("Write of bin upload record failed: " & result, MsgBoxStyle.Exclamation, "Write Of Bin Upload Record Failed")
            End If

            Exit Sub

        End If

        binUploadBinIDTextBox.Text = ""

    End Sub

    Private Sub binUploadClearButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles binUploadClearButton.Click

        binUploadBinIDTextBox.Text = ""

    End Sub

    Private Sub binUploadButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles binUploadButton.Click

        If currentScanScreenPopulatedFromPreset Then

            Dim result As MsgBoxResult

            If user = "ATA" Then
                result = MsgBox("Create a cart upload record for this preset?", MsgBoxStyle.YesNo, "Create Cart Upload Record?")
            Else
                result = MsgBox("Create a bin upload record for this preset?", MsgBoxStyle.YesNo, "Create Bin Upload Record?")
            End If

            If result = MsgBoxResult.Yes Then

                If Not isValidBatchID(Trim(Me.groupNumberTextBox.Text)) Then

                    If user = "ATA" Then
                        MsgBox("Invalid Cart ID", MsgBoxStyle.Exclamation, "Invalid Cart ID")
                    Else
                        MsgBox("Invalid Batch ID", MsgBoxStyle.Exclamation, "Invalid Batch ID")
                    End If

                    Exit Sub

                End If

                Dim batchID As String = Trim(Me.groupNumberTextBox.Text)

                If Not isValidFlightNumber(Trim(Me.flightNumberTextBox.Text)) Then

                    MsgBox("Invalid Flight Number", MsgBoxStyle.Exclamation, "Invalid Flight Number")
                    Exit Sub

                End If

                Dim flightNumber = Trim(Me.flightNumberTextBox.Text).PadLeft(4, "0")

                If Not isValidLocation(Me.destinationComboBox.Text) Then

                    MsgBox("A valid destination must be specified", MsgBoxStyle.Exclamation, "Invalid Destination")
                    Exit Sub

                End If

                Dim destinationCode = Me.destinationComboBox.Text

                Dim binUploadRecord As New binUploadRecordClass(batchID, flightNumber, destinationCode)

                Dim writeResult As String

                writeResult = binUploadRecord.write(binUploadFilePath)

                If writeResult <> "OK" Then

                    If user = "ATA" Then
                        MsgBox("Write of batch upload record failed: " & result, MsgBoxStyle.Exclamation, "Write Of Batch Upload Record Failed")
                    Else
                        MsgBox("Write of bin upload record failed: " & result, MsgBoxStyle.Exclamation, "Write Of Bin Upload Record Failed")
                    End If

                    Exit Sub

                End If

                If user = "ATA" Then
                    MsgBox("New Batch Upload Record Created", MsgBoxStyle.Information, "New Batch Upload Record Created")
                Else
                    MsgBox("New Bin Upload Record Created", MsgBoxStyle.Information, "New Bin Upload Record Created")
                End If

                Exit Sub

            End If

        End If

        selectBinUploadTabPage(Me)

    End Sub


    Private Sub mainTabControl_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mainTabControl.SelectedIndexChanged

        logReaderFormTabChanged(1)

    End Sub

    Private Sub manifestButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles manifestButton.Click

        Dim manifestDisplayForm As New manifestForm(appExitFlag)

        manifestDisplayForm.ShowDialog()

    End Sub

    Public Sub resetOperationComboBoxWithoutWarning()
        ignoreOperationComboBoxChange = True

        operationComboBox.SelectedIndex = 0
        operationComboBox.Text = ""

        ignoreOperationComboBoxChange = False
    End Sub

    Private Sub scanFormLogoPictureBox_ParentChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles scanFormLogoPictureBox.ParentChanged

    End Sub
End Class

