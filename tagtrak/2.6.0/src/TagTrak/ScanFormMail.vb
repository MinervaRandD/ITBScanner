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

#Const incrementProgressBar = False

Public Class scanFormMail
    Inherits System.Windows.Forms.Form
    Friend WithEvents mainTabControl As System.Windows.Forms.TabControl
    Friend WithEvents mailLocationLabel As System.Windows.Forms.Label
    Friend WithEvents mailCarrierCodeLabel As System.Windows.Forms.Label
    Friend WithEvents releaseLabel As System.Windows.Forms.Label
    Friend WithEvents operationComboBox As System.Windows.Forms.ComboBox
    Friend WithEvents groupNumberTextBox As System.Windows.Forms.TextBox
    Friend WithEvents tailNumberTextBox As System.Windows.Forms.TextBox
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
    Friend WithEvents mailPieceCountLabel As System.Windows.Forms.Label

    'Friend WithEvents presetMenuItem As New Windows.Forms.MenuItem
    'Friend WithEvents scanMenuItem As New Windows.Forms.MenuItem
    'Friend WithEvents summaryMenuItem As New Windows.Forms.MenuItem
    'Friend WithEvents exitMenuItem As New Windows.Forms.MenuItem

    Friend WithEvents adminFunctionMenuItem As System.Windows.Forms.MenuItem
    Friend WithEvents messagesMenuItem As System.Windows.Forms.MenuItem
    Friend WithEvents mailOpsMenuItem As System.Windows.Forms.MenuItem
    Friend WithEvents mailOpsSimpleMenuItem As System.Windows.Forms.MenuItem
    Friend WithEvents cargoOpsMenuItem As System.Windows.Forms.MenuItem
    Friend WithEvents luggageOpsMenuItem As System.Windows.Forms.MenuItem
    Friend WithEvents setupMenuItem As System.Windows.Forms.MenuItem

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

    Dim textBoxControl As System.Windows.Forms.TextBox
    Dim nextTextBoxControl As System.windows.forms.TextBox

    Friend WithEvents keyboardPanel As System.Windows.Forms.Panel
    Friend WithEvents lowerCasePictureBox As System.Windows.Forms.PictureBox
    Friend WithEvents upperCasePictureBox As System.Windows.Forms.PictureBox

    Friend keyboard As keyboardClass

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

        'This call is required by the Windows Form Designer.

        InitializeComponent()

        Application.DoEvents()

        backgroundFtpTimer.Enabled = False
        uploadReminderTimer.Enabled = False

        'presetListBox.Items.Clear()

        rejectReasonTextBox.Enabled = False
        uploadButton.Enabled = True
        transferPointTextBox.Enabled = False

        activeReaderForm = Me

        loadMailFormLogo()
        loadMailSimpleFormLogo()
        'loadCargoFormLogo()
        'loadBaggageFormLogo()
        'loadMessageFormLogo()

        incrementProgramLoadProgressBar()

        startupProcessRoutine()

        incrementProgramLoadProgressBar()

        code93LockedPictureBox.Visible = False

        totalWeightLabel.Text = 0

        mailPieceCountLabel.Text = 0

        'cargoPieceCountLabel.Text = 0

#If deviceType = "PC" Then

        Me.mainTabControl.Location = New System.Drawing.Point(0, -20)

        DandRTextBox.Text = "DUMMYSCANN"
        weightTextBox.Text = "0"

        Me.mainTabControl.BringToFront()
        Me.selectItemButton.BringToFront()

#End If

        summaryButton.Enabled = False

        selectMailScanTabPage(Me)

        uploadReminderMinuteCount = 120
        'uploadReminderTimer.Interval = 60 * 1000

        Dim operation As String

        operationComboBox.Items.Clear()

        operationComboBox.Items.Add("")

        For Each operation In userSpecRecord.operationsList
            operationComboBox.Items.Add(operation)
        Next

        incrementProgramLoadProgressBar()

        operationComboBox.Items.Add("")

        setupReaderFormButtons()

        incrementProgramLoadProgressBar()

        Panel1.Location = New System.Drawing.Point(0, 296)

        Panel1.BringToFront()

        mailSimplePieceCountLabel.DataBindings.Add(New Binding("Text", Me.mailPieceCountLabel, "Text"))
        mailSimpleScanTotalWeightLabel.DataBindings.Add(New Binding("Text", Me.totalWeightLabel, "Text"))

        mailScanSimpleWeightTextBox.DataBindings.Add(New Binding("Text", Me.weightTextBox, "Text"))
        mailScanSimpleDandRTagTextBox.DataBindings.Add(New Binding("Text", Me.DandRTextBox, "Text"))
        mailScanSimpleOperationComboBox.DataBindings.Add(New Binding("SelectedIndex", Me.operationComboBox, "SelectedIndex"))
        mailScanSimpleCode93LockedPictureBox.DataBindings.Add(New Binding("Visible", Me.code93LockedPictureBox, "Visible"))
        mailScanSimpleLargeBarcodeCheckBox.DataBindings.Add(New Binding("CheckState", Me.enableCode93CheckBox, "CheckState"))
        mailScanSimpleLargeBarcodeCheckBox.DataBindings.Add(New Binding("Checked", Me.enableCode93CheckBox, "Checked"))

        'cargoLocationLabel.DataBindings.Add(New Binding("Text", Me.mailLocationLabel, "Text"))

        setupFormKeyboard()

        Me.mailSimpleScanFormLogoPictureBox.Image = Me.mailFormLogoPictureBox.Image
        'Me.cargoFormLogoPictureBox.Image = Me.mailFormLogoPictureBox.Image
        'Me.messagesFormLogoPictureBox.Image = Me.mailFormLogoPictureBox.Image

        Me.adminFunctionMenuItem = New System.Windows.Forms.MenuItem
        Me.messagesMenuItem = New System.Windows.Forms.MenuItem
        Me.mailOpsMenuItem = New System.Windows.Forms.MenuItem
        Me.mailOpsSimpleMenuItem = New System.Windows.Forms.MenuItem
        Me.cargoOpsMenuItem = New System.Windows.Forms.MenuItem
        Me.luggageOpsMenuItem = New System.Windows.Forms.MenuItem
        Me.setupMenuItem = New System.Windows.Forms.MenuItem

        Me.adminFunctionMenuItem.Text = "Admin Function"
        Me.messagesMenuItem.Text = "Messages"
        Me.mailOpsMenuItem.Text = "Mail Ops"
        Me.mailOpsSimpleMenuItem.Text = "Mail Ops (Simple)"
        Me.cargoOpsMenuItem.Text = "Cargo Ops"
        Me.luggageOpsMenuItem.Text = "Baggage Ops"
        Me.setupMenuItem.Text = "Setup"

        Me.changeOpsContextMenu.MenuItems.Add(Me.adminFunctionMenuItem)

        If userSpecRecord.messagesEnabled Then
            Me.changeOpsContextMenu.MenuItems.Add(Me.messagesMenuItem)
        End If

        If userSpecRecord.mailScanEnabled Then
            Me.changeOpsContextMenu.MenuItems.Add(Me.mailOpsMenuItem)
        End If

        If userSpecRecord.mailSimpleScanEnabled Then
            Me.changeOpsContextMenu.MenuItems.Add(Me.mailOpsSimpleMenuItem)
        End If

        If userSpecRecord.cargoScanEnabled Then
            Me.changeOpsContextMenu.MenuItems.Add(Me.cargoOpsMenuItem)
        End If

        If userSpecRecord.baggageScanEnabled Then
            Me.changeOpsContextMenu.MenuItems.Add(Me.luggageOpsMenuItem)
        End If

        'Me.changeOpsContextMenu.MenuItems.Add(Me.setupMenuItem)

    End Sub


    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  

#End Region

    Private Sub setupButton(ByRef buttonSpec As buttonSpecRecordClass, ByRef button As Windows.Forms.Button)

#If ValidationLevel >= 3 Then

        If diagnosticLevel >= 2 Then
            verify(Not buttonSpec Is Nothing, 32000)
            verify(Not button Is Nothing, 32001)
        End If

#End If

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

    Public Sub setupReaderFormButtons()

        With userSpecRecord

            setupButton(.summaryButtonSpec, summaryButton)
            setupButton(.presetsButtonSpec, presetButton)
            'setupButton(.adminButtonSpec, exitButton)
            setupButton(.binUploadButtonSpec, binUploadButton)
            setupButton(.binChangeButtonSpec, binChangeButton)
            setupButton(.manifestButtonSpec, manifestButton)
            'setupButton(.mailButtonSpec, mailScanButton)
            'setupButton(.cargoButtonSpec, cargoScanButton)

        End With

    End Sub

    Private Sub setupFormKeyboard()

        Dim initMailScanTextBoxCollection() As System.Windows.Forms.TextBox = { _
            DandRTextBox, _
            weightTextBox, _
            groupNumberTextBox, _
            flightNumberTextBox, _
            transferPointTextBox, _
            tailNumberTextBox, _
            rejectReasonTextBox}

        mailScanTextBoxCollection = initMailScanTextBoxCollection

        Dim initMailScanSimpleTextBoxCollection() As System.Windows.Forms.TextBox = { _
            mailScanSimpleDandRTagTextBox, _
            mailScanSimpleWeightTextBox}

        mailScanSimpleTextBoxCollection = initMailScanSimpleTextBoxCollection

        'Dim initCargoScanTextBoxCollection() As System.windows.forms.TextBox = { _
        '    cargoAirwayBillTextBox, _
        '    tbxCargoACBinID, _
        '    tbxCargoFlightNumber, _
        '    tbxCargoContainer}

        'cargoScanTextBoxCollection = initCargoScanTextBoxCollection

        'Dim initMessagesTextBoxCollection() As System.windows.forms.TextBox = { _
        '    messsagesTextBox}

        'messagesTextBoxCollection = initMessagesTextBoxCollection

        Dim textBoxCollection()() As System.windows.forms.TextBox = { _
            mailScanTextBoxCollection, _
            mailScanSimpleTextBoxCollection, _
            cargoScanTextBoxCollection, _
            messagesTextBoxCollection}

        Dim textBoxCollectionElement() As Windows.Forms.TextBox

        Dim i, ilmt As Integer

        Dim j, k, jlmt, listLength As Integer
        Dim tabbedTextBoxSpec As tabbedTextBoxSpecClass

        ilmt = textBoxCollection.Length - 1

        For i = 0 To ilmt

            textBoxCollectionElement = textBoxCollection(i)

            listLength = textBoxCollectionElement.Length

            jlmt = listLength - 1

            k = tabbedTextBoxArrayList.Count

            For j = 0 To jlmt

                textBoxControl = textBoxCollectionElement(j)
                tabbedTextBoxSpec = New tabbedTextBoxSpecClass(textBoxControl, j, Nothing, i)
                Me.tabbedTextBoxArrayList.Add(tabbedTextBoxSpec)

            Next

            tabbedTextBoxSpec = Me.tabbedTextBoxArrayList(k)

            For j = 1 To listLength

                Dim nextTabbedTextBoxSpec As tabbedTextBoxSpecClass = Me.tabbedTextBoxArrayList(k + (j Mod listLength))

                tabbedTextBoxSpec.nextTextBoxSpec = nextTabbedTextBoxSpec
                tabbedTextBoxSpec = nextTabbedTextBoxSpec

            Next

        Next

        listLength = tabbedTextBoxArrayList.Count

        Dim tabbedTextBoxList(listLength - 1) As tabbedTextBoxSpecClass

        ilmt = listLength - 1

        For i = 0 To ilmt
            tabbedTextBoxList(i) = tabbedTextBoxArrayList(i)
        Next

        keyboard = New keyboardClass(Me, tabbedTextBoxList, readerFormKeyboardIcon, AddressOf enterKeyHandler)
        keyboard.hide()

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
    Friend WithEvents backgroundFtpTimer As System.Windows.Forms.Timer
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents summaryButton As System.Windows.Forms.Button
    Friend WithEvents presetButton As System.Windows.Forms.Button
    Friend WithEvents uploadReminderTimer As System.Windows.Forms.Timer
    Friend WithEvents tailNumberLabel As System.Windows.Forms.Label
    Friend WithEvents batchIDLabel As System.Windows.Forms.Label
    Friend WithEvents mailLocationComboBox As System.Windows.Forms.ComboBox
    Friend WithEvents binChangeButton As System.Windows.Forms.Button
    Friend WithEvents binUploadButton As System.Windows.Forms.Button
    Friend WithEvents mailFormLogoPictureBox As System.Windows.Forms.PictureBox
    Friend WithEvents manifestButton As System.Windows.Forms.Button
    Friend WithEvents operationCodeLabel As System.Windows.Forms.Label
    Friend WithEvents enableCode93CheckBox As System.Windows.Forms.CheckBox
    Friend WithEvents code93LockedPictureBox As System.Windows.Forms.PictureBox
    Friend WithEvents mailScanFormTab As System.Windows.Forms.TabPage
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents changeOpsContextMenu As System.Windows.Forms.ContextMenu
    Friend WithEvents counterContextMenu As System.Windows.Forms.ContextMenu
    Friend WithEvents counterIcon As System.Windows.Forms.PictureBox
    Friend WithEvents resetCountersMenuItem As System.Windows.Forms.MenuItem
    Friend WithEvents reloadCountersMenuItem As System.Windows.Forms.MenuItem
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents Label15 As System.Windows.Forms.Label
    Friend WithEvents Label21 As System.Windows.Forms.Label
    Friend WithEvents Label39 As System.Windows.Forms.Label
    Friend WithEvents Label45 As System.Windows.Forms.Label
    Friend WithEvents Label47 As System.Windows.Forms.Label
    Friend WithEvents mailScanSimpleForm As System.Windows.Forms.TabPage
    Friend WithEvents Label52 As System.Windows.Forms.Label
    Friend WithEvents mailSimplePieceCountLabel As System.Windows.Forms.Label
    Friend WithEvents mailSimpleScanTotalWeightLabel As System.Windows.Forms.Label
    Friend WithEvents mailScanSimpleWeightTextBox As System.Windows.Forms.TextBox
    Friend WithEvents mailScanSimpleDandRTagTextBox As System.Windows.Forms.TextBox
    Friend WithEvents mailScanSimpleOperationComboBox As System.Windows.Forms.ComboBox
    Friend WithEvents mailScanSimpleCode93LockedPictureBox As System.Windows.Forms.PictureBox
    Friend WithEvents mailScanSimpleLargeBarcodeCheckBox As System.Windows.Forms.CheckBox
    Friend WithEvents mailScanSimplePresetListBox As System.Windows.Forms.ListBox
    Friend WithEvents mailDestinationComboBox As System.Windows.Forms.ComboBox
    Friend WithEvents readerFormKeyboardIcon As System.Windows.Forms.PictureBox
    Friend WithEvents mailSimpleScanFormLogoPictureBox As System.Windows.Forms.PictureBox
    Friend WithEvents scanSimpleUploadButton As System.Windows.Forms.Button
    Friend WithEvents binFullButton As System.Windows.Forms.Button
    Friend WithEvents scanSimpleBinFullButton As System.Windows.Forms.Button
    Friend WithEvents buzzLengthTimer As System.Windows.Forms.Timer
    Friend WithEvents mailScanSimpleBinUpload As System.Windows.Forms.Button
    Friend WithEvents simpleSaveButton As System.Windows.Forms.Button
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Dim resources As System.Resources.ResourceManager = New System.Resources.ResourceManager(GetType(scanFormMail))
        Me.mainTabControl = New System.Windows.Forms.TabControl
        Me.mailScanSimpleForm = New System.Windows.Forms.TabPage
        Me.simpleSaveButton = New System.Windows.Forms.Button
        Me.mailScanSimpleBinUpload = New System.Windows.Forms.Button
        Me.scanSimpleBinFullButton = New System.Windows.Forms.Button
        Me.mailSimpleScanFormLogoPictureBox = New System.Windows.Forms.PictureBox
        Me.Label52 = New System.Windows.Forms.Label
        Me.Label6 = New System.Windows.Forms.Label
        Me.Label9 = New System.Windows.Forms.Label
        Me.mailScanSimplePresetListBox = New System.Windows.Forms.ListBox
        Me.mailScanSimpleOperationComboBox = New System.Windows.Forms.ComboBox
        Me.Label15 = New System.Windows.Forms.Label
        Me.Label21 = New System.Windows.Forms.Label
        Me.mailScanSimpleWeightTextBox = New System.Windows.Forms.TextBox
        Me.Label39 = New System.Windows.Forms.Label
        Me.mailScanSimpleDandRTagTextBox = New System.Windows.Forms.TextBox
        Me.mailScanSimpleCode93LockedPictureBox = New System.Windows.Forms.PictureBox
        Me.mailScanSimpleLargeBarcodeCheckBox = New System.Windows.Forms.CheckBox
        Me.Label45 = New System.Windows.Forms.Label
        Me.Label47 = New System.Windows.Forms.Label
        Me.mailSimpleScanTotalWeightLabel = New System.Windows.Forms.Label
        Me.mailSimplePieceCountLabel = New System.Windows.Forms.Label
        Me.scanSimpleUploadButton = New System.Windows.Forms.Button
        Me.mailScanFormTab = New System.Windows.Forms.TabPage
        Me.binFullButton = New System.Windows.Forms.Button
        Me.counterIcon = New System.Windows.Forms.PictureBox
        Me.Label13 = New System.Windows.Forms.Label
        Me.code93LockedPictureBox = New System.Windows.Forms.PictureBox
        Me.mailLocationComboBox = New System.Windows.Forms.ComboBox
        Me.enableCode93CheckBox = New System.Windows.Forms.CheckBox
        Me.mailLocationLabel = New System.Windows.Forms.Label
        Me.mailCarrierCodeLabel = New System.Windows.Forms.Label
        Me.operationComboBox = New System.Windows.Forms.ComboBox
        Me.groupNumberTextBox = New System.Windows.Forms.TextBox
        Me.tailNumberLabel = New System.Windows.Forms.Label
        Me.tailNumberTextBox = New System.Windows.Forms.TextBox
        Me.mailDestinationComboBox = New System.Windows.Forms.ComboBox
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
        Me.Label11 = New System.Windows.Forms.Label
        Me.totalWeightLabel = New System.Windows.Forms.Label
        Me.mailPieceCountLabel = New System.Windows.Forms.Label
        Me.mailFormLogoPictureBox = New System.Windows.Forms.PictureBox
        Me.summaryButton = New System.Windows.Forms.Button
        Me.presetButton = New System.Windows.Forms.Button
        Me.binUploadButton = New System.Windows.Forms.Button
        Me.binChangeButton = New System.Windows.Forms.Button
        Me.manifestButton = New System.Windows.Forms.Button
        Me.uploadButton = New System.Windows.Forms.Button
        Me.readerFormKeyboardIcon = New System.Windows.Forms.PictureBox
        Me.releaseLabel = New System.Windows.Forms.Label
        Me.backgroundFtpTimer = New System.Windows.Forms.Timer
        Me.Panel1 = New System.Windows.Forms.Panel
        Me.uploadReminderTimer = New System.Windows.Forms.Timer
        Me.changeOpsContextMenu = New System.Windows.Forms.ContextMenu
        Me.counterContextMenu = New System.Windows.Forms.ContextMenu
        Me.resetCountersMenuItem = New System.Windows.Forms.MenuItem
        Me.reloadCountersMenuItem = New System.Windows.Forms.MenuItem
        Me.buzzLengthTimer = New System.Windows.Forms.Timer
        '
        'mainTabControl
        '
        Me.mainTabControl.Controls.Add(Me.mailScanSimpleForm)
        Me.mainTabControl.Controls.Add(Me.mailScanFormTab)
        Me.mainTabControl.SelectedIndex = 0
        Me.mainTabControl.Size = New System.Drawing.Size(253, 328)
        '
        'mailScanSimpleForm
        '
        Me.mailScanSimpleForm.Controls.Add(Me.simpleSaveButton)
        Me.mailScanSimpleForm.Controls.Add(Me.mailScanSimpleBinUpload)
        Me.mailScanSimpleForm.Controls.Add(Me.scanSimpleBinFullButton)
        Me.mailScanSimpleForm.Controls.Add(Me.mailSimpleScanFormLogoPictureBox)
        Me.mailScanSimpleForm.Controls.Add(Me.Label52)
        Me.mailScanSimpleForm.Controls.Add(Me.Label6)
        Me.mailScanSimpleForm.Controls.Add(Me.Label9)
        Me.mailScanSimpleForm.Controls.Add(Me.mailScanSimplePresetListBox)
        Me.mailScanSimpleForm.Controls.Add(Me.mailScanSimpleOperationComboBox)
        Me.mailScanSimpleForm.Controls.Add(Me.Label15)
        Me.mailScanSimpleForm.Controls.Add(Me.Label21)
        Me.mailScanSimpleForm.Controls.Add(Me.mailScanSimpleWeightTextBox)
        Me.mailScanSimpleForm.Controls.Add(Me.Label39)
        Me.mailScanSimpleForm.Controls.Add(Me.mailScanSimpleDandRTagTextBox)
        Me.mailScanSimpleForm.Controls.Add(Me.mailScanSimpleCode93LockedPictureBox)
        Me.mailScanSimpleForm.Controls.Add(Me.mailScanSimpleLargeBarcodeCheckBox)
        Me.mailScanSimpleForm.Controls.Add(Me.Label45)
        Me.mailScanSimpleForm.Controls.Add(Me.Label47)
        Me.mailScanSimpleForm.Controls.Add(Me.mailSimpleScanTotalWeightLabel)
        Me.mailScanSimpleForm.Controls.Add(Me.mailSimplePieceCountLabel)
        Me.mailScanSimpleForm.Controls.Add(Me.scanSimpleUploadButton)
        Me.mailScanSimpleForm.Location = New System.Drawing.Point(4, 22)
        Me.mailScanSimpleForm.Size = New System.Drawing.Size(245, 302)
        Me.mailScanSimpleForm.Text = "mail scan simple"
        '
        'simpleSaveButton
        '
        Me.simpleSaveButton.Location = New System.Drawing.Point(132, 187)
        Me.simpleSaveButton.Size = New System.Drawing.Size(58, 19)
        Me.simpleSaveButton.Text = "Save"
        '
        'mailScanSimpleBinUpload
        '
        Me.mailScanSimpleBinUpload.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular)
        Me.mailScanSimpleBinUpload.Location = New System.Drawing.Point(5, 187)
        Me.mailScanSimpleBinUpload.Size = New System.Drawing.Size(67, 19)
        Me.mailScanSimpleBinUpload.Text = "Cart Upload"
        '
        'scanSimpleBinFullButton
        '
        Me.scanSimpleBinFullButton.Location = New System.Drawing.Point(72, 187)
        Me.scanSimpleBinFullButton.Size = New System.Drawing.Size(60, 19)
        Me.scanSimpleBinFullButton.Text = "Cart Full"
        '
        'mailSimpleScanFormLogoPictureBox
        '
        Me.mailSimpleScanFormLogoPictureBox.Location = New System.Drawing.Point(0, 8)
        Me.mailSimpleScanFormLogoPictureBox.Size = New System.Drawing.Size(100, 48)
        Me.mailSimpleScanFormLogoPictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        '
        'Label52
        '
        Me.Label52.Font = New System.Drawing.Font("Tahoma", 14.25!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Italic), System.Drawing.FontStyle))
        Me.Label52.Location = New System.Drawing.Point(120, 16)
        Me.Label52.Size = New System.Drawing.Size(112, 30)
        Me.Label52.Text = "Mail"
        Me.Label52.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'Label6
        '
        Me.Label6.Location = New System.Drawing.Point(14, 223)
        Me.Label6.Size = New System.Drawing.Size(227, 13)
        Me.Label6.Text = "                      ID        dst/flgt"
        '
        'Label9
        '
        Me.Label9.Location = New System.Drawing.Point(15, 210)
        Me.Label9.Size = New System.Drawing.Size(225, 17)
        Me.Label9.Text = "org dst   flgt  cart        new"
        '
        'mailScanSimplePresetListBox
        '
        Me.mailScanSimplePresetListBox.Items.Add("12345678901234567890123456789012345")
        Me.mailScanSimplePresetListBox.Location = New System.Drawing.Point(0, 241)
        Me.mailScanSimplePresetListBox.Size = New System.Drawing.Size(244, 44)
        '
        'mailScanSimpleOperationComboBox
        '
        Me.mailScanSimpleOperationComboBox.Font = New System.Drawing.Font("Tahoma", 12.0!, System.Drawing.FontStyle.Regular)
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
        Me.mailScanSimpleOperationComboBox.Location = New System.Drawing.Point(103, 62)
        Me.mailScanSimpleOperationComboBox.Size = New System.Drawing.Size(137, 27)
        '
        'Label15
        '
        Me.Label15.Location = New System.Drawing.Point(131, 98)
        Me.Label15.Size = New System.Drawing.Size(111, 16)
        Me.Label15.Text = "Weight"
        Me.Label15.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'Label21
        '
        Me.Label21.Location = New System.Drawing.Point(2, 67)
        Me.Label21.Size = New System.Drawing.Size(92, 16)
        Me.Label21.Text = "Operation Code"
        Me.Label21.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'mailScanSimpleWeightTextBox
        '
        Me.mailScanSimpleWeightTextBox.Location = New System.Drawing.Point(141, 114)
        Me.mailScanSimpleWeightTextBox.Size = New System.Drawing.Size(97, 22)
        Me.mailScanSimpleWeightTextBox.Text = ""
        '
        'Label39
        '
        Me.Label39.Location = New System.Drawing.Point(10, 97)
        Me.Label39.Size = New System.Drawing.Size(109, 16)
        Me.Label39.Text = "D and R Tag"
        Me.Label39.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'mailScanSimpleDandRTagTextBox
        '
        Me.mailScanSimpleDandRTagTextBox.Location = New System.Drawing.Point(2, 113)
        Me.mailScanSimpleDandRTagTextBox.Size = New System.Drawing.Size(125, 22)
        Me.mailScanSimpleDandRTagTextBox.Text = ""
        '
        'mailScanSimpleCode93LockedPictureBox
        '
        Me.mailScanSimpleCode93LockedPictureBox.Image = CType(resources.GetObject("mailScanSimpleCode93LockedPictureBox.Image"), System.Drawing.Image)
        Me.mailScanSimpleCode93LockedPictureBox.Location = New System.Drawing.Point(106, 146)
        Me.mailScanSimpleCode93LockedPictureBox.Size = New System.Drawing.Size(16, 26)
        '
        'mailScanSimpleLargeBarcodeCheckBox
        '
        Me.mailScanSimpleLargeBarcodeCheckBox.Checked = True
        Me.mailScanSimpleLargeBarcodeCheckBox.CheckState = System.Windows.Forms.CheckState.Indeterminate
        Me.mailScanSimpleLargeBarcodeCheckBox.Location = New System.Drawing.Point(135, 148)
        Me.mailScanSimpleLargeBarcodeCheckBox.Size = New System.Drawing.Size(103, 21)
        Me.mailScanSimpleLargeBarcodeCheckBox.Text = "Large Barcode"
        '
        'Label45
        '
        Me.Label45.Location = New System.Drawing.Point(35, 140)
        Me.Label45.Size = New System.Drawing.Size(64, 16)
        Me.Label45.Text = "Tot. Wgt"
        Me.Label45.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'Label47
        '
        Me.Label47.Location = New System.Drawing.Point(3, 140)
        Me.Label47.Size = New System.Drawing.Size(40, 16)
        Me.Label47.Text = "Cnt"
        Me.Label47.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'mailSimpleScanTotalWeightLabel
        '
        Me.mailSimpleScanTotalWeightLabel.Location = New System.Drawing.Point(51, 160)
        Me.mailSimpleScanTotalWeightLabel.Size = New System.Drawing.Size(40, 20)
        Me.mailSimpleScanTotalWeightLabel.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'mailSimplePieceCountLabel
        '
        Me.mailSimplePieceCountLabel.Location = New System.Drawing.Point(11, 160)
        Me.mailSimplePieceCountLabel.Size = New System.Drawing.Size(24, 20)
        '
        'scanSimpleUploadButton
        '
        Me.scanSimpleUploadButton.Location = New System.Drawing.Point(188, 187)
        Me.scanSimpleUploadButton.Size = New System.Drawing.Size(51, 19)
        Me.scanSimpleUploadButton.Text = "Send"
        '
        'mailScanFormTab
        '
        Me.mailScanFormTab.Controls.Add(Me.binFullButton)
        Me.mailScanFormTab.Controls.Add(Me.counterIcon)
        Me.mailScanFormTab.Controls.Add(Me.Label13)
        Me.mailScanFormTab.Controls.Add(Me.code93LockedPictureBox)
        Me.mailScanFormTab.Controls.Add(Me.mailLocationComboBox)
        Me.mailScanFormTab.Controls.Add(Me.enableCode93CheckBox)
        Me.mailScanFormTab.Controls.Add(Me.mailLocationLabel)
        Me.mailScanFormTab.Controls.Add(Me.mailCarrierCodeLabel)
        Me.mailScanFormTab.Controls.Add(Me.operationComboBox)
        Me.mailScanFormTab.Controls.Add(Me.groupNumberTextBox)
        Me.mailScanFormTab.Controls.Add(Me.tailNumberLabel)
        Me.mailScanFormTab.Controls.Add(Me.tailNumberTextBox)
        Me.mailScanFormTab.Controls.Add(Me.mailDestinationComboBox)
        Me.mailScanFormTab.Controls.Add(Me.Label4)
        Me.mailScanFormTab.Controls.Add(Me.flightNumberTextBox)
        Me.mailScanFormTab.Controls.Add(Me.Label3)
        Me.mailScanFormTab.Controls.Add(Me.transferPointTextBox)
        Me.mailScanFormTab.Controls.Add(Me.Label2)
        Me.mailScanFormTab.Controls.Add(Me.rejectReasonTextBox)
        Me.mailScanFormTab.Controls.Add(Me.operationCodeLabel)
        Me.mailScanFormTab.Controls.Add(Me.saveButton)
        Me.mailScanFormTab.Controls.Add(Me.weightTextBox)
        Me.mailScanFormTab.Controls.Add(Me.Label1)
        Me.mailScanFormTab.Controls.Add(Me.DandRTextBox)
        Me.mailScanFormTab.Controls.Add(Me.rejectReasonLabel)
        Me.mailScanFormTab.Controls.Add(Me.transferPointLabel)
        Me.mailScanFormTab.Controls.Add(Me.Label8)
        Me.mailScanFormTab.Controls.Add(Me.batchIDLabel)
        Me.mailScanFormTab.Controls.Add(Me.Label7)
        Me.mailScanFormTab.Controls.Add(Me.destinationLabel)
        Me.mailScanFormTab.Controls.Add(Me.Label11)
        Me.mailScanFormTab.Controls.Add(Me.totalWeightLabel)
        Me.mailScanFormTab.Controls.Add(Me.mailPieceCountLabel)
        Me.mailScanFormTab.Controls.Add(Me.mailFormLogoPictureBox)
        Me.mailScanFormTab.Controls.Add(Me.summaryButton)
        Me.mailScanFormTab.Controls.Add(Me.presetButton)
        Me.mailScanFormTab.Controls.Add(Me.binUploadButton)
        Me.mailScanFormTab.Controls.Add(Me.binChangeButton)
        Me.mailScanFormTab.Controls.Add(Me.manifestButton)
        Me.mailScanFormTab.Controls.Add(Me.uploadButton)
        Me.mailScanFormTab.Location = New System.Drawing.Point(4, 22)
        Me.mailScanFormTab.Size = New System.Drawing.Size(245, 302)
        Me.mailScanFormTab.Text = "mail scan"
        '
        'binFullButton
        '
        Me.binFullButton.Location = New System.Drawing.Point(173, 227)
        Me.binFullButton.Size = New System.Drawing.Size(62, 19)
        Me.binFullButton.Text = "Cart Full"
        '
        'counterIcon
        '
        Me.counterIcon.Image = CType(resources.GetObject("counterIcon.Image"), System.Drawing.Image)
        Me.counterIcon.Location = New System.Drawing.Point(115, 202)
        Me.counterIcon.Size = New System.Drawing.Size(44, 20)
        '
        'Label13
        '
        Me.Label13.Font = New System.Drawing.Font("Tahoma", 12.0!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Italic), System.Drawing.FontStyle))
        Me.Label13.Location = New System.Drawing.Point(132, 1)
        Me.Label13.Size = New System.Drawing.Size(73, 22)
        Me.Label13.Text = "Mail"
        Me.Label13.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'code93LockedPictureBox
        '
        Me.code93LockedPictureBox.Image = CType(resources.GetObject("code93LockedPictureBox.Image"), System.Drawing.Image)
        Me.code93LockedPictureBox.Location = New System.Drawing.Point(6, 224)
        Me.code93LockedPictureBox.Size = New System.Drawing.Size(16, 26)
        '
        'mailLocationComboBox
        '
        Me.mailLocationComboBox.Location = New System.Drawing.Point(5, 122)
        Me.mailLocationComboBox.Size = New System.Drawing.Size(72, 22)
        '
        'enableCode93CheckBox
        '
        Me.enableCode93CheckBox.Checked = True
        Me.enableCode93CheckBox.CheckState = System.Windows.Forms.CheckState.Indeterminate
        Me.enableCode93CheckBox.Location = New System.Drawing.Point(28, 227)
        Me.enableCode93CheckBox.Size = New System.Drawing.Size(103, 21)
        Me.enableCode93CheckBox.Text = "Large Barcode"
        '
        'mailLocationLabel
        '
        Me.mailLocationLabel.Location = New System.Drawing.Point(22, 121)
        Me.mailLocationLabel.Size = New System.Drawing.Size(32, 16)
        '
        'mailCarrierCodeLabel
        '
        Me.mailCarrierCodeLabel.Location = New System.Drawing.Point(80, 125)
        Me.mailCarrierCodeLabel.Size = New System.Drawing.Size(22, 16)
        Me.mailCarrierCodeLabel.Text = "B6"
        Me.mailCarrierCodeLabel.TextAlign = System.Drawing.ContentAlignment.TopCenter
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
        Me.operationComboBox.Location = New System.Drawing.Point(105, 36)
        Me.operationComboBox.Size = New System.Drawing.Size(137, 26)
        '
        'groupNumberTextBox
        '
        Me.groupNumberTextBox.Location = New System.Drawing.Point(160, 81)
        Me.groupNumberTextBox.Size = New System.Drawing.Size(72, 22)
        Me.groupNumberTextBox.Text = ""
        '
        'tailNumberLabel
        '
        Me.tailNumberLabel.Location = New System.Drawing.Point(80, 147)
        Me.tailNumberLabel.Size = New System.Drawing.Size(48, 16)
        Me.tailNumberLabel.Text = "Tail"
        Me.tailNumberLabel.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'tailNumberTextBox
        '
        Me.tailNumberTextBox.Location = New System.Drawing.Point(80, 163)
        Me.tailNumberTextBox.Size = New System.Drawing.Size(56, 22)
        Me.tailNumberTextBox.Text = ""
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
        Me.mailDestinationComboBox.Location = New System.Drawing.Point(181, 122)
        Me.mailDestinationComboBox.Size = New System.Drawing.Size(52, 22)
        '
        'Label4
        '
        Me.Label4.Location = New System.Drawing.Point(116, 104)
        Me.Label4.Size = New System.Drawing.Size(40, 16)
        Me.Label4.Text = "Flight"
        '
        'flightNumberTextBox
        '
        Me.flightNumberTextBox.Location = New System.Drawing.Point(106, 122)
        Me.flightNumberTextBox.Size = New System.Drawing.Size(60, 22)
        Me.flightNumberTextBox.Text = ""
        '
        'Label3
        '
        Me.Label3.Location = New System.Drawing.Point(21, 104)
        Me.Label3.Size = New System.Drawing.Size(32, 16)
        Me.Label3.Text = "Loc"
        Me.Label3.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'transferPointTextBox
        '
        Me.transferPointTextBox.Location = New System.Drawing.Point(12, 163)
        Me.transferPointTextBox.Size = New System.Drawing.Size(56, 22)
        Me.transferPointTextBox.Text = ""
        '
        'Label2
        '
        Me.Label2.Location = New System.Drawing.Point(100, 63)
        Me.Label2.Size = New System.Drawing.Size(48, 16)
        Me.Label2.Text = "Weight"
        Me.Label2.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'rejectReasonTextBox
        '
        Me.rejectReasonTextBox.Location = New System.Drawing.Point(160, 163)
        Me.rejectReasonTextBox.Size = New System.Drawing.Size(56, 22)
        Me.rejectReasonTextBox.Text = ""
        '
        'operationCodeLabel
        '
        Me.operationCodeLabel.Location = New System.Drawing.Point(120, 21)
        Me.operationCodeLabel.Size = New System.Drawing.Size(104, 16)
        Me.operationCodeLabel.Text = "Operation Code"
        Me.operationCodeLabel.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'saveButton
        '
        Me.saveButton.Location = New System.Drawing.Point(173, 190)
        Me.saveButton.Size = New System.Drawing.Size(62, 18)
        Me.saveButton.Text = "Save"
        '
        'weightTextBox
        '
        Me.weightTextBox.Location = New System.Drawing.Point(104, 81)
        Me.weightTextBox.Size = New System.Drawing.Size(40, 22)
        Me.weightTextBox.Text = ""
        '
        'Label1
        '
        Me.Label1.Location = New System.Drawing.Point(8, 63)
        Me.Label1.Size = New System.Drawing.Size(80, 16)
        Me.Label1.Text = "D and R Tag"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'DandRTextBox
        '
        Me.DandRTextBox.Location = New System.Drawing.Point(0, 81)
        Me.DandRTextBox.Size = New System.Drawing.Size(96, 22)
        Me.DandRTextBox.Text = ""
        '
        'rejectReasonLabel
        '
        Me.rejectReasonLabel.Location = New System.Drawing.Point(144, 147)
        Me.rejectReasonLabel.Size = New System.Drawing.Size(88, 16)
        Me.rejectReasonLabel.Text = "Reject Reason"
        '
        'transferPointLabel
        '
        Me.transferPointLabel.Location = New System.Drawing.Point(0, 147)
        Me.transferPointLabel.Size = New System.Drawing.Size(72, 16)
        Me.transferPointLabel.Text = "Transfer Pt."
        Me.transferPointLabel.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'Label8
        '
        Me.Label8.Location = New System.Drawing.Point(47, 188)
        Me.Label8.Size = New System.Drawing.Size(64, 16)
        Me.Label8.Text = "Tot. Wgt"
        Me.Label8.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'batchIDLabel
        '
        Me.batchIDLabel.Location = New System.Drawing.Point(161, 63)
        Me.batchIDLabel.Size = New System.Drawing.Size(72, 16)
        Me.batchIDLabel.Text = "Cart ID"
        Me.batchIDLabel.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'Label7
        '
        Me.Label7.Location = New System.Drawing.Point(70, 104)
        Me.Label7.Size = New System.Drawing.Size(34, 16)
        Me.Label7.Text = "Carr."
        Me.Label7.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'destinationLabel
        '
        Me.destinationLabel.Location = New System.Drawing.Point(181, 104)
        Me.destinationLabel.Size = New System.Drawing.Size(53, 16)
        Me.destinationLabel.Text = "Dest"
        Me.destinationLabel.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'Label11
        '
        Me.Label11.Location = New System.Drawing.Point(4, 188)
        Me.Label11.Size = New System.Drawing.Size(40, 16)
        Me.Label11.Text = "Cnt"
        Me.Label11.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'totalWeightLabel
        '
        Me.totalWeightLabel.Location = New System.Drawing.Point(57, 202)
        Me.totalWeightLabel.Size = New System.Drawing.Size(45, 20)
        Me.totalWeightLabel.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'mailPieceCountLabel
        '
        Me.mailPieceCountLabel.Location = New System.Drawing.Point(7, 202)
        Me.mailPieceCountLabel.Size = New System.Drawing.Size(35, 20)
        '
        'mailFormLogoPictureBox
        '
        Me.mailFormLogoPictureBox.Image = CType(resources.GetObject("mailFormLogoPictureBox.Image"), System.Drawing.Image)
        Me.mailFormLogoPictureBox.Location = New System.Drawing.Point(0, 8)
        Me.mailFormLogoPictureBox.Size = New System.Drawing.Size(103, 48)
        Me.mailFormLogoPictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        '
        'summaryButton
        '
        Me.summaryButton.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular)
        Me.summaryButton.Location = New System.Drawing.Point(45, 252)
        Me.summaryButton.Size = New System.Drawing.Size(70, 19)
        Me.summaryButton.Text = "Summary"
        '
        'presetButton
        '
        Me.presetButton.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular)
        Me.presetButton.Location = New System.Drawing.Point(115, 252)
        Me.presetButton.Size = New System.Drawing.Size(67, 19)
        Me.presetButton.Text = "Presets"
        '
        'binUploadButton
        '
        Me.binUploadButton.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular)
        Me.binUploadButton.Location = New System.Drawing.Point(144, 270)
        Me.binUploadButton.Size = New System.Drawing.Size(99, 19)
        Me.binUploadButton.Text = "Cart Upload"
        '
        'binChangeButton
        '
        Me.binChangeButton.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular)
        Me.binChangeButton.Location = New System.Drawing.Point(45, 270)
        Me.binChangeButton.Size = New System.Drawing.Size(99, 19)
        Me.binChangeButton.Text = "Change Cart"
        '
        'manifestButton
        '
        Me.manifestButton.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular)
        Me.manifestButton.Location = New System.Drawing.Point(182, 252)
        Me.manifestButton.Size = New System.Drawing.Size(61, 19)
        Me.manifestButton.Text = "Manifest"
        '
        'uploadButton
        '
        Me.uploadButton.Location = New System.Drawing.Point(173, 208)
        Me.uploadButton.Size = New System.Drawing.Size(62, 19)
        Me.uploadButton.Text = "Send"
        '
        'readerFormKeyboardIcon
        '
        Me.readerFormKeyboardIcon.Location = New System.Drawing.Point(218, 7)
        Me.readerFormKeyboardIcon.Size = New System.Drawing.Size(23, 16)
        '
        'releaseLabel
        '
        Me.releaseLabel.Location = New System.Drawing.Point(62, 5)
        Me.releaseLabel.Size = New System.Drawing.Size(144, 17)
        Me.releaseLabel.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'backgroundFtpTimer
        '
        Me.backgroundFtpTimer.Interval = 5000
        '
        'Panel1
        '
        Me.Panel1.Controls.Add(Me.releaseLabel)
        Me.Panel1.Controls.Add(Me.readerFormKeyboardIcon)
        Me.Panel1.Location = New System.Drawing.Point(0, 337)
        Me.Panel1.Size = New System.Drawing.Size(263, 73)
        '
        'uploadReminderTimer
        '
        Me.uploadReminderTimer.Interval = 1000
        '
        'counterContextMenu
        '
        Me.counterContextMenu.MenuItems.Add(Me.resetCountersMenuItem)
        Me.counterContextMenu.MenuItems.Add(Me.reloadCountersMenuItem)
        '
        'resetCountersMenuItem
        '
        Me.resetCountersMenuItem.Text = "Reset Counters"
        '
        'reloadCountersMenuItem
        '
        Me.reloadCountersMenuItem.Text = "Reload Counters"
        '
        'buzzLengthTimer
        '
        '
        'scanFormMail
        '
        Me.ClientSize = New System.Drawing.Size(253, 603)
        Me.Controls.Add(Me.mainTabControl)
        Me.Controls.Add(Me.Panel1)
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


        selectMailScanTabPage(Me)

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
        'symbolReader.MyReader.StartRead()
#End If

        removeExpiredBackupResditFiles()

        'scannerLib.Code128Active()

        turnScannerOff(7)

        backgroundFtpTimer.Enabled = True

        ignoreOperationComboBoxChange = False

        readerFormLoaded = True

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

        processMailScanTransaction()

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
        tailNumberTextBox.Text = ""
        rejectReasonTextBox.Text = ""
    End Sub

    Private Sub handleOperationComboBoxSelectedIndexChanged()

        Dim currentOperation As String

        If isNonNullString(operationComboBox.Text) Then
            currentOperation = Trim(operationComboBox.Text)
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

            turnScannerOff(8)
            Exit Sub

        Else

            turnScannerOn(9)

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

        Select Case currentOperation
            Case "Possession"
                transferPointTextBox.Enabled = False
                transferPointLabel.Enabled = False
                rejectReasonTextBox.Enabled = False
                rejectReasonTextBox.Text = ""
                rejectReasonLabel.Enabled = False
                flightNumberTextBox.Text = ""
                mailDestinationComboBox.SelectedIndex = 0
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

                mailFormLogoPictureBox.Visible = False
                operationComboBox.Visible = False
                operationCodeLabel.Visible = False

                rejectReasonTextBox.Text = InputBox("Please Specify A Return Reason", "Specify Reject Reason", "", 0, 0)

                mailFormLogoPictureBox.Visible = True
                operationComboBox.Visible = True
                operationCodeLabel.Visible = True

            Case "Delivery"
                transferPointTextBox.Enabled = False
                transferPointLabel.Enabled = False
                rejectReasonTextBox.Enabled = False
                rejectReasonTextBox.Text = ""
                rejectReasonLabel.Enabled = False

        End Select

    End Sub

    Dim withinoperationComboBoxSelectedIndexChanged As Boolean = False

    Private Sub operationComboBox_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles operationComboBox.SelectedIndexChanged

        If withinoperationComboBoxSelectedIndexChanged Then Exit Sub

        withinoperationComboBoxSelectedIndexChanged = True
        handleOperationComboBoxSelectedIndexChanged()
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

    Public Sub HandleMailScanData(ByRef readerString As String, ByVal symbology As Integer)

        scanSequenceVerify(Not readerString Is Nothing, 1)

        logScanSequenceEvent(10001, "HandleMailData entry point")

        Dim MessageToDisplay As String

        If currentTabPage <> "mail scan" And currentTabPage <> "mail scan simple" Then

            Dim queryResult As MsgBoxResult = MsgBox("You have scanned a mail bar code. Convert to mail scanning operations?", MsgBoxStyle.YesNo, "Mail Bar Code Scanned")

            If queryResult = MsgBoxResult.No Then
                MsgBox("Invalid Bar Code Scanned.", MsgBoxStyle.Exclamation, "Invalid Bar Code")
                Exit Sub
            End If

            If lastUsedMailScanPage = "mail scan" Then
                selectMailScanTabPage(Me)
            Else
                selectMailScanSimpleTabPage(Me)
            End If

            Exit Sub

        End If

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

        If Not isValidDandRTag(DandRTextBox.Text) Then
            MsgBox("Invalid D and R Tag Format. Scan Ignored", MsgBoxStyle.Exclamation, "Invalid D and R Tag")
            Exit Sub
        End If

        If enableCode93CheckBox.Checked Then

            logScanSequenceEvent(10003, "HandleData checking code 93")

            If Length(readerString) = 10 Then

                weightTextBox.Text = "0"

                Dim getWeightDisplayForm As New getWeightForm

                Dim result As DialogResult = getWeightDisplayForm.ShowDialog

                If result = DialogResult.Cancel Then
                    MsgBox("Scan Ignored.", MsgBoxStyle.Information, "Scan Ignored")
                    Exit Sub
                End If

                weightTextBox.Text = getWeightDialogResult

            ElseIf Length(readerString) = 12 Then

                weightTextBox.Text = Substring(readerString, 10, 2)

                If Not isValidWeight(weightTextBox.Text) Then
                    MsgBox("Invalid weight in D and R Tag: mail scan ignored", MsgBoxStyle.Exclamation, "Invalid D and R Tag")
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

        processMailScanTransaction()

        logScanSequenceEvent(10999, "HandleData exit point")

    End Sub

    Public Sub HandleCargoScanData(ByVal readerString As String, ByVal symbology As Integer)

        Dim result As String

        If currentTabPage <> "cargo scan" Then

            Dim queryResult As MsgBoxResult = MsgBox("You have scanned a cargo bar code. Convert to cargo scanning operations?", MsgBoxStyle.YesNo, "Mail Bar Code Scanned")

            If queryResult = MsgBoxResult.No Then
                MsgBox("Invalid Bar Code Scanned.", MsgBoxStyle.Exclamation, "Invalid Bar Code")
                Exit Sub
            End If

            FormRepository.cargoScanForm.ShowDialog()

            Exit Sub

        End If

        FormRepository.cargoScanForm.cargoAirwayBillTextBox.Text = readerString

        result = processCargoScanTransaction()
        If result <> "OK" Then Exit Sub

        Dim pieceCount As Integer = FormRepository.cargoScanForm.cargoPieceCountLabel.Text

        pieceCount += 1

        FormRepository.cargoScanForm.cargoPieceCountLabel.Text = pieceCount

        saveUpdatedCargoScanCounts()
    End Sub

    Public Sub HandleData(ByRef readerString As String, ByVal symbology As Integer)

        If symbology = Code128 Or symbology = code93 Then

            HandleMailScanData(readerString, symbology)

            '    If Length(readerString) = 11 Then
            '        HandleCargoScanData(readerString, symbology)
            '    Else
            '        HandleMailScanData(readerString, symbology)
            '    End If
            'ElseIf symbology = code39 Then
            '    HandleBaggageScanData(readerString)

        Else

            MsgBox("Invalid Scan Data", MsgBoxStyle.Exclamation, "Invalid Scan Data")

        End If

    End Sub

    Private Sub returnToScanPageButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        selectMailScanTabPage(Me)
    End Sub

    Dim cradleTickCount As Int32 = 2147483647

    Private Sub decrementCradleTickCountAndDoAutoUploadIfAppropriate()

        Dim dialogResult As DialogResult

        cradleTickCount -= 1

        If cradleTickCount <= 0 Then

            turnScannerOff(1001)
            Dim autoFtpProcessDisplayForm As New autoFtpProcessForm
            dialogResult = autoFtpProcessDisplayForm.ShowDialog()
            turnScannerOn(1002)

            If dialogResult = dialogResult.Abort Then
                Me.DialogResult = dialogResult.Abort
                Me.Close()
                Exit Sub
            End If

            cradleTickCount = 12 * 30 ' Reset autoupload timer to 30 minutes

        End If

    End Sub

    Private Sub handleBackgroundFtpTimerEvent()

        Dim deviceNowInCradle As Boolean

#If deviceType <> "Intermec" And deviceType <> "Symbol" Then
        Exit Sub
#End If

        If withinFtpProcess Then Exit Sub

        withinFtpProcess = True

        If scannerLib.SystemPowerStatus() = 1 Then
            deviceNowInCradle = True
        Else
            deviceNowInCradle = False
        End If

        If deviceInCradle Then

            ' If here, then device was in the cradle at last timer event

            If deviceNowInCradle Then

                ' Device was previously in the cradle and is in the cradle now. The following steps are taken:
                ' 1. The cradle tick counter is decremented.
                ' 2. If the cradle tick counter is less than or equal to zero, the auto upload is triggered.
                ' 3. If auto upload is triggered, the cradle tick count is set to 30 minutes.

                decrementCradleTickCountAndDoAutoUploadIfAppropriate()

            Else

                ' Device was previously in the cradle and now removed. Turn off
                ' auto upload feature.

                deviceInCradle = False             ' Set state variable to "device not in cradle"
                cradleTickCount = 2147483647       ' Not really necessary -- set autoupload timer to infinity

                logCradleStateChange(1, False)

            End If

        Else ' If here, then device was not previously in cradle at last timer event

            If deviceNowInCradle Then

                ' Device was not previously in the cradle and has been put in since the last
                ' cradle event. Turn on auto upload feature and set timer to 30 seconds.

                cradleTickCount = 6      ' Set auto upload timer to go off after 30 seconds.
                deviceInCradle = True    ' Set the state variable to "device in cradle

                resetOperationComboBoxWithoutWarning()

                logCradleStateChange(2, True)

            Else

                ' device remains out of cradle -- nothing to do.

                cradleTickCount = 2147483647       ' Not really necessary -- set autoupload timer to infinity

            End If

        End If

        withinFtpProcess = False

    End Sub

    Private Sub backgroundFtpTimer_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles backgroundFtpTimer.Tick

#If False Then

        If emulatingPlatform Then Exit Sub

        SyncLock criticalSectionSemiphore

            If criticalSectionSemiphore.getSemiphoreState = False Then

                criticalSectionSemiphore.setSemiphoreState(True)

                activeReaderForm.backgroundFtpTimer.Enabled = False
                activeReaderForm.uploadReminderTimer.Enabled = False

                handleBackgroundFtpTimerEvent()

                activeReaderForm.backgroundFtpTimer.Enabled = True
                'activeReaderForm.uploadReminderTimer.Enabled = True

                criticalSectionSemiphore.setSemiphoreState(False)

            End If

        End SyncLock

        Application.DoEvents()

#End If

    End Sub

    Private Sub handleUploadButtonClick()

        Dim ftpProcessDisplayForm As New ftpProcessForm
        Dim ftpDialogResult As DialogResult = ftpProcessDisplayForm.ShowDialog()

        If ftpDialogResult = DialogResult.Abort Then
            Me.DialogResult = DialogResult.Abort
            Me.Close()
            Exit Sub
        End If

        If auxInstallAvailable Then

            Me.DialogResult = AdminFormRepository.adminFunctionsNotificationForm.ShowDialog()

            If Me.DialogResult = DialogResult.Abort Then
                Me.Close()
                Exit Sub
            End If

        End If

        If newApplicationVersionFound Then

            Dim newVersionDisplayForm As New newVersionNotification
            DialogResult = newVersionDisplayForm.ShowDialog()

            If DialogResult = DialogResult.Abort Then
                Me.DialogResult = DialogResult.Abort
                Me.Close()
                Exit Sub
            End If

        End If

        If newConfigurationFileFound Then

            Dim localBinFilePath As String = UspsMailConfigDirectory & "\ScannerConfig.bin"

            loadConfigurationsFromBinaryFile(localBinFilePath)
            deleteLocalFile(localBinFilePath)

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
                'activeReaderForm.uploadReminderTimer.Enabled = False

                handleUploadButtonClick()

                turnScannerOn(45)
                activeReaderForm.backgroundFtpTimer.Enabled = True
                'activeReaderForm.uploadReminderTimer.Enabled = True

                criticalSectionSemiphore.setSemiphoreState(False)

            End If

        End SyncLock

        Application.DoEvents()

        logUploadButtonClickEvent(2, "Exiting upload button click handler")

    End Sub

    Private Sub destinationComboBox_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mailDestinationComboBox.SelectedIndexChanged

        Dim destinationCode As String = mailDestinationComboBox.Text
        Dim operationCode As String = operationComboBox.Text

        verify(Length(scanLocation) >= 3, 10)

        Dim locationCode As String = Substring(scanLocation, 0, 3)

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

        Me.DialogResult = AdminFormRepository.adminLoginForm.ShowDialog()

        If dialogResult = dialogResult.Abort Then
            closeoutReaderOperations()
            Exit Sub
        End If

        e.Cancel = True

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
            simpleSaveButton.Enabled = True
        Else
            saveButton.Enabled = False
            simpleSaveButton.Enabled = False
        End If

    End Sub


    Private Sub summaryButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles summaryButton.Click

        Dim manifestSummaryDisplayForm As New manifestSummaryForm
        manifestSummaryDisplayForm.ShowDialog()

    End Sub

    'Private Sub presetButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles presetButton.Click

    '    updateExpiredPresetsInListBox()

    '    selectPresetTabPage(Me)

    'End Sub

    Private Sub scanButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)

        selectMailScanTabPage(Me)

    End Sub

    Private Sub exitButton_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs)

        resetOperationComboBoxWithoutWarning()

        Me.DialogResult = AdminFormRepository.adminLoginForm.ShowDialog()
        If Me.DialogResult = DialogResult.Abort Then Me.Close()

    End Sub

    Dim withinUploadReminderTimer As Boolean = False

    Private Sub updateUploadReminder()

        Dim resditFileSize As Integer = getFileSize(mailDataFilePath)

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

        Exit Sub

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
                'activeReaderForm.uploadReminderTimer.Enabled = True

                criticalSectionSemiphore.setSemiphoreState(False)

            End If

        End SyncLock

        Application.DoEvents()

    End Sub

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

    Private Sub setNewLocation()

        scanLocation = mailLocationComboBox.Text
        mailLocationLabel.Text = scanLocation
        'cargoLocationLabel.Text = scanLocation
        'luggageScanForm.baggageLocationLabel.Text = scanLocation

        verify(Length(scanLocation) >= 3, 6)

        Dim airport As locationClass = airportSet.Item(Substring(scanLocation, 0, 3).ToUpper)

        If airport Is Nothing Then
            MsgBox("Airport '" & scanLocation & "' is not in the current location set.")
            Stop
        End If

        scannerTimeZone = airport.timeZone

        saveLastLocation(Substring(scanLocation, 0, 3))

    End Sub

    Private Sub processLocationComboBoxSelectedIndexChanged()

        If Not isNonNullString(Trim(mailLocationComboBox.Text)) Then
            MsgBox("Please select a valid location.", MsgBoxStyle.Exclamation, "Select Valid Location")
        End If

        If doNotConfirmLocationChange Then
            setNewLocation()
            Exit Sub
        End If

        If Not userSpecRecord.passwordRequiredForLocationChangeOnScanForm Then
            setNewLocation()
            Exit Sub
        End If

        verify(Length(scanLocation) >= 3, 7)

        Dim newLocation As String = mailLocationComboBox.SelectedItem
        Dim oldLocation As String = Substring(scanLocation, 0, 3).ToUpper

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

            mailLocationComboBox.SelectedItem = scanLocation
            'cargoLocationComboBox.SelectedItem = scanLocation
            'luggageScanForm.baggageLocationComboBox.SelectedItem = scanLocation

            Exit Sub

        End If

        setNewLocation()
    End Sub

    Dim withinLocationComboBoxSelectedIndexChanged As Boolean = False

    Private Sub mailLocationComboBox_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mailLocationComboBox.SelectedIndexChanged

        If withinLocationComboBoxSelectedIndexChanged Then Exit Sub

        withinLocationComboBoxSelectedIndexChanged = True

        'cargoLocationComboBox.SelectedIndex = mailLocationComboBox.SelectedIndex
        'luggageScanForm.baggageLocationComboBox.SelectedIndex = mailLocationComboBox.SelectedIndex

        processLocationComboBoxSelectedIndexChanged()

        withinLocationComboBoxSelectedIndexChanged = False

    End Sub

    Private Sub cargoLocationComboBox_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)

        If withinLocationComboBoxSelectedIndexChanged Then Exit Sub

        withinLocationComboBoxSelectedIndexChanged = True

        'mailLocationComboBox.SelectedIndex = cargoLocationComboBox.SelectedIndex
        'luggageScanForm.baggageLocationComboBox.SelectedIndex = cargoLocationComboBox.SelectedIndex

        processLocationComboBoxSelectedIndexChanged()
        withinLocationComboBoxSelectedIndexChanged = False

    End Sub

    Private Sub locationLabel_textChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mailLocationLabel.TextChanged

        logLocationChange(1)

        currentScanScreenPopulatedFromPreset = False

    End Sub

    Private Sub groupNumberTextBox_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles groupNumberTextBox.TextChanged
        currentScanScreenPopulatedFromPreset = False
    End Sub

    Private Sub changeBin_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles binChangeButton.Click

        Dim binChangeDisplayForm As New binChangeForm(Me)
        binChangeDisplayForm.ShowDialog()

    End Sub

    Private Sub binUploadButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles binUploadButton.Click

        If currentScanScreenPopulatedFromPreset Then

            Dim result As MsgBoxResult

            If user = "ATA" Or user = "USAirways" Then
                result = MsgBox("Create a cart upload record for this preset?", MsgBoxStyle.YesNo, "Create Cart Upload Record?")
            Else
                result = MsgBox("Create a Cart upload record for this preset?", MsgBoxStyle.YesNo, "Create Cart Upload Record?")
            End If

            If result = MsgBoxResult.Yes Then

                If Not isValidBatchID(Trim(Me.groupNumberTextBox.Text)) Then

                    If user = "ATA" Or user = "USAirways" Then
                        MsgBox("Invalid Cart ID", MsgBoxStyle.Exclamation, "Invalid Cart ID")
                    Else
                        MsgBox("Invalid Cart ID", MsgBoxStyle.Exclamation, "Invalid Cart ID")
                    End If

                    Exit Sub

                End If

                Dim batchID As String = Trim(Me.groupNumberTextBox.Text)

                If Not isValidFlightNumber(Trim(Me.flightNumberTextBox.Text)) Then

                    MsgBox("Invalid Flight Number", MsgBoxStyle.Exclamation, "Invalid Flight Number")
                    Exit Sub

                End If

                Dim flightNumber = Trim(Me.flightNumberTextBox.Text).PadLeft(4, "0")

                If Not isValidLocation(Me.mailDestinationComboBox.Text) Then

                    MsgBox("A valid destination must be specified", MsgBoxStyle.Exclamation, "Invalid Destination")
                    Exit Sub

                End If

                Dim destinationCode = Me.mailDestinationComboBox.Text

                Dim binUploadRecord As New binUploadRecordClass(batchID, flightNumber, destinationCode)

                Dim writeResult As String

                writeResult = binUploadRecord.write(binUploadFilePath)

                If writeResult <> "OK" Then

                    If user = "ATA" Or user = "USAirways" Then
                        MsgBox("Write of cart upload record failed: " & result, MsgBoxStyle.Exclamation, "Write Of Cart Upload Record Failed")
                    Else
                        MsgBox("Write of Cart upload record failed: " & result, MsgBoxStyle.Exclamation, "Write Of Cart Upload Record Failed")
                    End If

                    Exit Sub

                End If

                If user = "ATA" Or user = "USAirways" Then
                    MsgBox("New Cart Upload Record Created", MsgBoxStyle.Information, "New Cart Upload Record Created")
                Else
                    MsgBox("New Cart Upload Record Created", MsgBoxStyle.Information, "New Cart Upload Record Created")
                End If

                Exit Sub

            End If

        End If

        Dim binUploadDisplayForm As New binUploadForm(Me)
        binUploadDisplayForm.ShowDialog()

    End Sub


    Private Sub mainTabControl_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mainTabControl.SelectedIndexChanged

        logReaderFormTabChanged(1)

    End Sub

    Private Sub manifestButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles manifestButton.Click

        Dim manifestDisplayForm As New manifestForm
        Me.DialogResult = manifestDisplayForm.ShowDialog()

    End Sub

    Public Sub resetOperationComboBoxWithoutWarning()
        ignoreOperationComboBoxChange = True

        operationComboBox.SelectedIndex = 0
        operationComboBox.Text = ""

        ignoreOperationComboBoxChange = False
    End Sub

    Private Function getValidResditFilePath() As String

        Dim resditFilePath As String

        If primaryDataFileDirectoryIsValid Then

            resditFilePath = mailDataFilePath

            If File.Exists(resditFilePath) Then
                Return resditFilePath
            Else
                Return Nothing
            End If

        ElseIf secondaryDataFileDirectoryIsValid Then

            resditFilePath = backupMailDataFilePath

            If File.Exists(resditFilePath) Then
                Return resditFilePath
            Else
                Return Nothing
            End If

        End If

        Return Nothing

    End Function


    'Private Sub setupMessageButtons()

    '    Dim currentMessageNumber As Integer = CInt(Me.messageNumberLabel.Text)
    '    Dim totalMessages = CInt(Me.totalMessageCountLabel.Text)

    '    If currentMessageNumber > 1 Then
    '        Me.previousMessageButton.Enabled = True
    '    Else
    '        Me.previousMessageButton.Enabled = False
    '    End If

    '    If currentMessageNumber < totalMessages Then
    '        Me.nextMessageButton.Enabled = True
    '    Else
    '        Me.nextMessageButton.Enabled = False
    '    End If

    'End Sub

    'Public Sub setupMessagesPage()

    '    If messageList.Count <= 0 Then

    '        Me.messsagesTextBox.Text = ""

    '        Me.messageNumberLabel.Text = "0"
    '        Me.totalMessageCountLabel.Text = "0"

    '        setupMessageButtons()

    '        Exit Sub

    '    End If

    '    If Me.messageNumberLabel.Text = "0" Then

    '        Me.messageNumberLabel.Text = "1"
    '        Me.totalMessageCountLabel.Text = CStr(messageList.Count)

    '    End If

    '    setupMessageButtons()

    '    Dim currentMessageNumber As Integer = CInt(Me.messageNumberLabel.Text)

    '    Me.messsagesTextBox.Text = messageList(currentMessageNumber - 1)

    'End Sub

    'Private Sub previousMessageButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)

    '    If messageList.Count <= 0 Then
    '        setupMessagesPage()
    '        Exit Sub
    '    End If

    '    Dim currentMessageNumber As Integer = CInt(Me.messageNumberLabel.Text)

    '    If currentMessageNumber > 1 Then

    '        currentMessageNumber -= 1

    '        Me.messageNumberLabel.Text = currentMessageNumber
    '        Me.messsagesTextBox.Text = messageList(currentMessageNumber - 1)


    '    End If

    '    setupMessageButtons()

    'End Sub

    'Private Sub nextMessageButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)

    '    If messageList.Count <= 0 Then
    '        setupMessagesPage()
    '        Exit Sub
    '    End If

    '    Dim currentMessageNumber As Integer = CInt(Me.messageNumberLabel.Text)

    '    If currentMessageNumber < messageList.Count Then

    '        currentMessageNumber += 1

    '        Me.messageNumberLabel.Text = currentMessageNumber
    '        Me.messsagesTextBox.Text = messageList(currentMessageNumber - 1)


    '    End If

    '    setupMessageButtons()

    'End Sub

    Public Sub loadLocationComboBox()

        Me.mailLocationComboBox.Items.Clear()
        'Me.cargoLocationComboBox.Items.Clear()

        Dim city As String

        For Each city In userSpecRecord.cityList
            Me.mailLocationComboBox.Items.Add(city)
            'Me.cargoLocationComboBox.Items.Add(city)
        Next

        ' MDD Test

        If scanLocation Is Nothing Then
            Me.mailLocationComboBox.SelectedItem = userSpecRecord.defaultLocation
            'Me.cargoLocationComboBox.SelectedItem = userSpecRecord.defaultLocation
        Else
            Me.mailLocationComboBox.SelectedItem = scanLocation
            'Me.cargoLocationComboBox.SelectedItem = scanLocation
        End If

    End Sub

    Public Sub loadOperationComboBox()

        Me.operationComboBox.Items.Clear()

        Dim operation As String

        For Each operation In userSpecRecord.operationsList
            Me.operationComboBox.Items.Add(operation)
        Next

        Me.operationComboBox.Items.Insert(0, "")

    End Sub

    'Private Sub cargoOperationComboBox_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)

    '    If Me.cargoOperationComboBox.SelectedIndex > 0 Then
    '        turnScannerOn(901)
    '    Else
    '        turnScannerOff(902)
    '    End If

    'End Sub

    'Private Sub cargoScanButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
    '    selectCargoScanTabPage(Me)
    'End Sub

    Private Sub counterIcon_ParentChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles counterIcon.Click
        Me.counterContextMenu.Show(Me.counterIcon, New System.Drawing.Point(0, 0))
    End Sub

    Private Sub resetCountersMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles resetCountersMenuItem.Click

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

    Private Sub reloadMailPieceCounts()

        Dim countFilePath As String = deviceNonVolatileMemoryDirectory & backSlash & "MailScanPieceCounts.txt"

        Dim totalWeight As Integer = 0
        Dim totalCount As Integer = 0

        If Not File.Exists(countFilePath) Then

            Exit Sub

        End If

        Dim countFileInputStream As StreamReader

        Try
            countFileInputStream = New StreamReader(countFilePath)
        Catch ex As Exception
            MsgBox("Unable to open count file in order to reset mail counters: " & ex.Message, MsgBoxStyle.Exclamation, "Open On Resdit File Failed.")
            Exit Sub
        End Try

        Dim countFileRecord As String

        Try
            countFileRecord = countFileInputStream.ReadLine
        Catch ex As Exception
            countFileInputStream.Close()
            MsgBox("Unable to read count file in order to reset mail counters: " & ex.Message, MsgBoxStyle.Exclamation, "Open On Resdit File Failed.")
            Exit Sub
        End Try

        If Not countFileRecord Is Nothing Then

            Dim tokenSet() As String = countFileRecord.Split(",")

            Me.totalWeightLabel.Text = tokenSet(1)
            Me.mailPieceCountLabel.Text = tokenSet(0)

        Else

            Me.totalWeightLabel.Text = "0"
            Me.mailPieceCountLabel.Text = "0"

        End If

        countFileInputStream.Close()

    End Sub

    Private Sub reloadCargoPieceCounts()

        Dim countFilePath As String = deviceNonVolatileMemoryDirectory & backSlash & "CargoScanPieceCounts.txt"

        Dim totalCount As Integer = 0

        If Not File.Exists(countFilePath) Then

            Exit Sub

        End If

        Dim countFileInputStream As StreamReader

        Try
            countFileInputStream = New StreamReader(countFilePath)
        Catch ex As Exception
            MsgBox("Unable to open count file in order to reset cargo counters: " & ex.Message, MsgBoxStyle.Exclamation, "Open On Resdit File Failed.")
            Exit Sub
        End Try

        Dim countFileRecord As String

        Try
            countFileRecord = countFileInputStream.ReadLine
        Catch ex As Exception
            MsgBox("Unable to read count file in order to reset cargo counters: " & ex.Message, MsgBoxStyle.Exclamation, "Open On Resdit File Failed.")
            Exit Sub
        End Try

        'If Not countFileRecord Is Nothing Then
        '    Me.cargoPieceCountLabel.Text = Trim(countFileRecord)
        'Else
        '    Me.cargoPieceCountLabel.Text = "0"
        'End If

    End Sub

    Private Sub reloadCountersMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles reloadCountersMenuItem.Click

        If currentTabPage = "mail scan" Or currentTabPage = "mail scan simple" Then
            reloadMailPieceCounts()
        ElseIf currentTabPage = "cargo scan" Then
            reloadCargoPieceCounts()
        End If

    End Sub

    Private Sub adminFunctionMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles adminFunctionMenuItem.Click

        resetOperationComboBoxWithoutWarning()

        Me.DialogResult = AdminFormRepository.adminLoginForm.ShowDialog()
        If Me.DialogResult = DialogResult.Abort Then Me.Close()

    End Sub

    Private Sub setupMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles setupMenuItem.Click

        Dim setupMenuDisplayForm As New SetupMenuForm
        setupMenuDisplayForm.ShowDialog()

    End Sub

    'Private Sub messagesMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles messagesMenuItem.Click

    '    ' MDD

    '    'If messageList.Count <= 0 Then
    '    '    setupMessagesPage()
    '    '    Exit Sub
    '    'End If

    '    Dim currentMessageNumber As Integer = CInt(Me.messageNumberLabel.Text)

    '    If currentMessageNumber > 1 Then

    '        currentMessageNumber -= 1

    '        Me.messageNumberLabel.Text = currentMessageNumber
    '        Me.messsagesTextBox.Text = messageList(currentMessageNumber - 1)


    '    End If

    '    setupMessageButtons()

    '    selectMessagesTabPage(Me)

    'End Sub

    'Private Sub cargoOpsMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cargoOpsMenuItem.Click
    '    selectCargoScanTabPage(Me)
    'End Sub

    Private Sub mailOpsMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mailOpsMenuItem.Click
        selectMailScanTabPage(Me)
    End Sub

    Private Sub mailOpsSimpleMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mailOpsSimpleMenuItem.Click
        selectMailScanSimpleTabPage(Me)
    End Sub

    Private Sub luggageOpsMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles luggageOpsMenuItem.Click

    End Sub

    'Private Sub cargoFormCounterIcon_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
    '    Me.counterContextMenu.Show(cargoFormCounterIcon, New System.Drawing.Point(0, 0))
    'End Sub


    Private Sub presetButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles presetButton.Click

        Dim presetsDisplayForm As New presetsForm(Me)
        presetsDisplayForm.ShowDialog()

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

    Private Sub baggageScanUploadButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)

        UploadButton_Click(Nothing, Nothing)

    End Sub

    Private Sub cargoScanUploadButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)

        UploadButton_Click(Nothing, Nothing)

    End Sub

    Public Sub loadMailFormLogo()

        Dim mailFormLogoPath As String

        mailFormLogoPath = UspsMailConfigDirectory & "\" & userSpecRecord.userName & "scanFormLogo.bmp"

        If File.Exists(mailFormLogoPath) Then
            mailFormLogoPictureBox.Image = New System.Drawing.Bitmap(mailFormLogoPath)
            Exit Sub
        End If

        mailFormLogoPath = UspsMailConfigDirectory & "\scanFormLogo.bmp"

        If File.Exists(mailFormLogoPath) Then
            mailFormLogoPictureBox.Image = New System.Drawing.Bitmap(mailFormLogoPath)
        End If

    End Sub

    Public Sub loadMailSimpleFormLogo()

        Dim mailFormLogoPath As String

        mailFormLogoPath = UspsMailConfigDirectory & "\" & userSpecRecord.userName & "scanFormLogo.bmp"

        If File.Exists(mailFormLogoPath) Then
            mailSimpleScanFormLogoPictureBox.Image = New System.Drawing.Bitmap(mailFormLogoPath)
            Exit Sub
        End If

        mailFormLogoPath = UspsMailConfigDirectory & "\scanFormLogo.bmp"

        If File.Exists(mailFormLogoPath) Then
            mailSimpleScanFormLogoPictureBox.Image = New System.Drawing.Bitmap(mailFormLogoPath)
        End If

    End Sub

    'Public Sub loadCargoFormLogo()

    '    Dim cargoFormLogoPath As String

    '    cargoFormLogoPath = UspsMailConfigDirectory & "\" & userSpecRecord.userName & "scanFormLogo.bmp"

    '    'If File.Exists(cargoFormLogoPath) Then
    '    '    cargoFormLogoPictureBox.Image = New System.Drawing.Bitmap(cargoFormLogoPath)
    '    '    Exit Sub
    '    'End If

    '    cargoFormLogoPath = UspsMailConfigDirectory & "\scanFormLogo.bmp"

    '    If File.Exists(cargoFormLogoPath) Then
    '        cargoFormLogoPictureBox.Image = New System.Drawing.Bitmap(cargoFormLogoPath)
    '    End If

    'End Sub

    'Public Sub loadMessageFormLogo()

    '    Dim messageFormLogoPath As String

    '    messageFormLogoPath = UspsMailConfigDirectory & "\" & userSpecRecord.userName & "scanFormLogo.bmp"

    '    If File.Exists(messageFormLogoPath) Then
    '        messagesFormLogoPictureBox.Image = New System.Drawing.Bitmap(messageFormLogoPath)
    '        Exit Sub
    '    End If

    '    messageFormLogoPath = UspsMailConfigDirectory & "\scanFormLogo.bmp"

    '    If File.Exists(messageFormLogoPath) Then
    '        messagesFormLogoPictureBox.Image = New System.Drawing.Bitmap(messageFormLogoPath)
    '    End If

    'End Sub

    'Public Sub loadBaggageFormLogo()

    '    Dim baggageFormLogoPath As String

    '    baggageFormLogoPath = UspsMailConfigDirectory & "\" & userSpecRecord.userName & "scanFormLogo.bmp"

    '    If File.Exists(baggageFormLogoPath) Then
    '        cargoFormLogoPictureBox.Image = New System.Drawing.Bitmap(baggageFormLogoPath)
    '        Exit Sub
    '    End If

    '    baggageFormLogoPath = UspsMailConfigDirectory & "\scanFormLogo.bmp"

    '    If File.Exists(baggageFormLogoPath) Then
    '        cargoFormLogoPictureBox.Image = New System.Drawing.Bitmap(baggageFormLogoPath)
    '    End If

    'End Sub

    Private Sub mailFormLogoPictureBox_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mailFormLogoPictureBox.Click
        Me.changeOpsContextMenu.Show(mailFormLogoPictureBox, New System.Drawing.Point(0, 0))
    End Sub

    Private Sub mailSimpleScanFormLogoPictureBox_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mailSimpleScanFormLogoPictureBox.Click
        Me.changeOpsContextMenu.Show(mailSimpleScanFormLogoPictureBox, New System.Drawing.Point(0, 0))
    End Sub

    'Private Sub cargoFormLogoPictureBox_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
    '    Me.changeOpsContextMenu.Show(cargoFormLogoPictureBox, New System.Drawing.Point(0, 0))
    'End Sub


    'Private Sub messagesFormLogoPictureBox_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
    'Me.changeOpsContextMenu.Show(messagesFormLogoPictureBox, New System.Drawing.Point(0, 0))
    'End Sub

    Private Sub TextBox1_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)

    End Sub


    'Private Sub cargoFormSaveButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)

    '    cargoAirwayBillTextBox.Text = ""

    '    Dim pieceCount As Integer = cargoPieceCountLabel.Text

    '    pieceCount += 1

    '    cargoPieceCountLabel.Text = pieceCount

    '    saveUpdatedCargoScanCounts()

    'End Sub

    Private Sub scanSimpleUploadButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles scanSimpleUploadButton.Click
        UploadButton_Click(sender, e)
    End Sub

    Private Sub binFullButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles binFullButton.Click
        Dim createNewPresetDisplayForm As New createNewPresetForm(Me)
        createNewPresetDisplayForm.ShowDialog()
        loadPresetListFromFile(userSpecRecord, userSpecRecord.presetList)



    End Sub

    Private Sub scanSimpleBinFullButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles scanSimpleBinFullButton.Click
        binFullButton_Click(sender, e)
        Dim presetRecord As presetRecordClass

        mailScanSimplePresetListBox.Items.Clear()

        For Each presetRecord In userSpecRecord.presetList
            mailScanSimplePresetListBox.Items.Add(presetRecord.formatForListBox)
        Next

        mailScanSimpleOperationComboBox.Items.Clear()
    End Sub

    Private Sub buzzLengthTimer_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles buzzLengthTimer.Tick
        buzzLengthTimer.Enabled = False
#If deviceType = "Intermec" Then
        scannerLib.VibrateOFF()
#End If

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

    Private Sub newReaderForm_KeyPress(ByVal sender As System.Object, ByVal e As KeyPressEventArgs) _
            Handles DandRTextBox.KeyPress, weightTextBox.KeyPress, groupNumberTextBox.KeyPress, flightNumberTextBox.KeyPress, transferPointTextBox.KeyPress, _
                    transferPointTextBox.KeyPress, rejectReasonTextBox.KeyPress, mailScanSimpleDandRTagTextBox.KeyPress, mailScanSimpleWeightTextBox.KeyPress
        If e.KeyChar = tabKeyChar Then
            keyboard.processTabRoutine(sender)
        End If
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

End Class

