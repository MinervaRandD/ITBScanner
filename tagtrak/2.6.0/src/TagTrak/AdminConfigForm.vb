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

Public Class adminConfigForm

    Inherits System.Windows.Forms.Form
    Friend WithEvents adminTabControl As System.Windows.Forms.TabControl

    Dim ignoreButtonSpecChange As Boolean = True

    Dim userInfoTextBoxCollection() As Windows.Forms.TextBox
    Dim ftpInfoTextBoxCollection() As Windows.Forms.TextBox
    Dim buttonInfoTextBoxCollection() As Windows.Forms.TextBox


#Region " Windows Form Designer generated code "

    Public Sub New()

        MyBase.New()

        Cursor.Current = Cursors.WaitCursor

        'This call is required by the Windows Form Designer.
        InitializeComponent()

        ftpLoginIDTextBox.Text = userSpecRecord.ftpLoginID
        ftpPasswordTextBox.Text = userSpecRecord.ftpPassword
        ftpHostTextBox.Text = userSpecRecord.ftpHostName
        ftpPortTextBox.Text = userSpecRecord.ftpPortNumber

        Me.UseProxyCheckBox.Checked = userSpecRecord.UseFtpProxy
        Me.ProxyTypeComboBox.SelectedItem = userSpecRecord.ProxyType
        Me.ProxyHostTextBox.Text = userSpecRecord.ProxyHost
        Me.ProxyPortTextBox.Text = CStr(userSpecRecord.ProxyPort)
        Me.ProxyUsernameTextBox.Text = userSpecRecord.ProxyUser
        Me.ProxyPasswordTextbox.Text = userSpecRecord.ProxyPassword

        usePresetOnLoadCheckBox.Checked = userSpecRecord.loadScansRequireSelectionFromPreset
        presetsRequireDestinationSpecCheckBox.Checked = userSpecRecord.presetsRequireDestinationSpecifications
        transferPointOnScanFormCheckBox.Checked = userSpecRecord.transferPointOnScanForm
        passwordRequiredForLocChangeCheckBox.Checked = userSpecRecord.passwordRequiredForLocationChangeOnScanForm
        treatTransferScansAsLoadScansCheckBox.Checked = userSpecRecord.treatTransferScansAsLoadScans
        lockdownReleasedOnAdminFormCheckBox.Checked = userSpecRecord.lockDownReleasedInAdminForm
        'canCreateBinChangeRecordsCheckBox.Checked = userSpecRecord.canCreateBinChangeRecords
        'canCreateBinUploadRecordsCheckBox.Checked = userSpecRecord.canCreateBinUploadRecords
        warnOfDuplicateScansCheckBox.Checked = userSpecRecord.warnOnDuplicateScan
        displayFlightValidationMessagesCheckBox.Checked = userSpecRecord.displayFlightValidationMessages
        triStateLargeBarcodeCheckBoxCheckBox.Checked = userSpecRecord.triStateLargeBarcodeCheckBox

        messagesCheckBox.Checked = userSpecRecord.messagesEnabled
        mailOpsCheckBox.Checked = userSpecRecord.mailScanEnabled
        mailSimpleOpsCheckBox.Checked = userSpecRecord.mailSimpleScanEnabled
        cargoOpsCheckBox.Checked = userSpecRecord.cargoScanEnabled
        baggageOpsCheckBox.Checked = userSpecRecord.baggageScanEnabled

        userNameTextBox.Text = userSpecRecord.userName
        userFullNameTextBox.Text = userSpecRecord.userFullName
        carrierCodeTextBox.Text = userSpecRecord.carrierCode

        Dim rValue As New StringBuilder

        rValue.Capacity = 256

        Dim i As Integer

        ipAddressLabel.Text = Util.getIPAddress()

        applyConfigChangesButton.Enabled = False
        saveConfigChangesButton.Enabled = False

        Dim city As String

        Me.currentCityListBox.Items.Clear()
        Me.availableCityListBox.Items.Clear()

        Dim SpecCity As String

        Dim AllCities() As String
        If Not Data.Cities.List.IsEmpty Then
            AllCities = Data.Cities.List.ToArray
        Else
            AllCities = userSpecRecord.cityList.ToArray(GetType(String))
        End If

        For Each SpecCity In AllCities
            If userSpecRecord.cityTable.ContainsKey(SpecCity) Then
                Me.currentCityListBox.Items.Add(SpecCity)
            Else
                Me.availableCityListBox.Items.Add(SpecCity)
            End If
        Next

        Me.addCityButton.Enabled = False
        Me.deleteCityButton.Enabled = False

        Me.currentCityListBox.SelectedIndex = -1
        Me.availableCityListBox.SelectedIndex = -1

        Dim operation As String

        Me.currentOperationsListBox.Items.Clear()
        Me.availableOperationsListBox.Items.Clear()

        For Each operation In operationsMasterList

            If userSpecRecord.operationsTable.ContainsKey(operation) Then
                Me.currentOperationsListBox.Items.Add(operation)
            Else
                Me.availableOperationsListBox.Items.Add(operation)
            End If

        Next

        Me.addOperationButton.Enabled = False
        Me.deleteOperationButton.Enabled = False

        Me.DialogResult = DialogResult.OK

        Cursor.Current = Cursors.Default

    End Sub

    Protected Overloads Overrides Sub Dispose(ByVal disposing As Boolean)
        MyBase.Dispose(disposing)
    End Sub

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    Friend WithEvents exitButton As System.Windows.Forms.Button
    Friend WithEvents ftpPasswordTextBox As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents ftpPortTextBox As System.Windows.Forms.TextBox
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents ftpHostTextBox As System.Windows.Forms.TextBox
    Friend WithEvents ftpLoginIDTextBox As System.Windows.Forms.TextBox
    Friend WithEvents usePresetOnLoadCheckBox As System.Windows.Forms.CheckBox
    Friend WithEvents presetsRequireDestinationSpecCheckBox As System.Windows.Forms.CheckBox
    Friend WithEvents transferPointOnScanFormCheckBox As System.Windows.Forms.CheckBox
    Friend WithEvents ipAddressLabel As System.Windows.Forms.Label
    Friend WithEvents Label22 As System.Windows.Forms.Label
    Friend WithEvents ftpConfig As System.Windows.Forms.TabPage
    Friend WithEvents switches1 As System.Windows.Forms.TabPage
    Friend WithEvents switches2 As System.Windows.Forms.TabPage
    Friend WithEvents warnOfDuplicateScansCheckBox As System.Windows.Forms.CheckBox
    Friend WithEvents lockdownReleasedOnAdminFormCheckBox As System.Windows.Forms.CheckBox
    Friend WithEvents treatTransferScansAsLoadScansCheckBox As System.Windows.Forms.CheckBox
    Friend WithEvents displayFlightValidationMessagesCheckBox As System.Windows.Forms.CheckBox
    Friend WithEvents triStateLargeBarcodeCheckBoxCheckBox As System.Windows.Forms.CheckBox
    Friend WithEvents ComboBox1 As System.Windows.Forms.ComboBox
    Friend WithEvents SizeYTextBox As System.Windows.Forms.TextBox
    Friend WithEvents passwordRequiredForLocChangeCheckBox As System.Windows.Forms.CheckBox
    Friend WithEvents applyConfigChangesButton As System.Windows.Forms.Button
    Friend WithEvents saveConfigChangesButton As System.Windows.Forms.Button
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents Label15 As System.Windows.Forms.Label
    Friend WithEvents cityListTabPage As System.Windows.Forms.TabPage
    Friend WithEvents currentCityListBox As System.Windows.Forms.ListBox
    Friend WithEvents availableCityListBox As System.Windows.Forms.ListBox
    Friend WithEvents Label16 As System.Windows.Forms.Label
    Friend WithEvents Label17 As System.Windows.Forms.Label
    Friend WithEvents operations As System.Windows.Forms.TabPage
    Friend WithEvents Label18 As System.Windows.Forms.Label
    Friend WithEvents Label19 As System.Windows.Forms.Label
    Friend WithEvents Label20 As System.Windows.Forms.Label
    Friend WithEvents Label21 As System.Windows.Forms.Label
    Friend WithEvents availableOperationsListBox As System.Windows.Forms.ListBox
    Friend WithEvents currentOperationsListBox As System.Windows.Forms.ListBox
    Friend WithEvents Label23 As System.Windows.Forms.Label
    Friend WithEvents Label24 As System.Windows.Forms.Label
    Friend WithEvents addOperationButton As System.Windows.Forms.Button
    Friend WithEvents deleteOperationButton As System.Windows.Forms.Button
    Friend WithEvents addCityButton As System.Windows.Forms.Button
    Friend WithEvents deleteCityButton As System.Windows.Forms.Button
    Friend WithEvents userInfoTabPage As System.Windows.Forms.TabPage
    Friend WithEvents Label25 As System.Windows.Forms.Label
    Friend WithEvents Label26 As System.Windows.Forms.Label
    Friend WithEvents Label27 As System.Windows.Forms.Label
    Friend WithEvents userNameTextBox As System.Windows.Forms.TextBox
    Friend WithEvents userFullNameTextBox As System.Windows.Forms.TextBox
    Friend WithEvents carrierCodeTextBox As System.Windows.Forms.TextBox
    Friend WithEvents scanFunctionsTabPage As System.Windows.Forms.TabPage
    Friend WithEvents baggageOpsCheckBox As System.Windows.Forms.CheckBox
    Friend WithEvents cargoOpsCheckBox As System.Windows.Forms.CheckBox
    Friend WithEvents mailSimpleOpsCheckBox As System.Windows.Forms.CheckBox
    Friend WithEvents mailOpsCheckBox As System.Windows.Forms.CheckBox
    Friend WithEvents messagesCheckBox As System.Windows.Forms.CheckBox
    Friend WithEvents availableOptionsLabel As System.Windows.Forms.Label
    Friend WithEvents scanningOptionsDisabledLabel As System.Windows.Forms.Label
    Friend WithEvents MainMenu1 As System.Windows.Forms.MainMenu
    Friend WithEvents InputPanel1 As Microsoft.WindowsCE.Forms.InputPanel
    Friend WithEvents proxyConfig As System.Windows.Forms.TabPage
    Friend WithEvents UseProxyCheckBox As System.Windows.Forms.CheckBox
    Friend WithEvents ProxyTypeComboBox As System.Windows.Forms.ComboBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents ProxyHostTextBox As System.Windows.Forms.TextBox
    Friend WithEvents ProxyPortTextBox As System.Windows.Forms.TextBox
    Friend WithEvents ProxyUsernameTextBox As System.Windows.Forms.TextBox
    Friend WithEvents ProxyPasswordTextbox As System.Windows.Forms.TextBox
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.exitButton = New System.Windows.Forms.Button
        Me.adminTabControl = New System.Windows.Forms.TabControl
        Me.scanFunctionsTabPage = New System.Windows.Forms.TabPage
        Me.scanningOptionsDisabledLabel = New System.Windows.Forms.Label
        Me.availableOptionsLabel = New System.Windows.Forms.Label
        Me.baggageOpsCheckBox = New System.Windows.Forms.CheckBox
        Me.cargoOpsCheckBox = New System.Windows.Forms.CheckBox
        Me.mailSimpleOpsCheckBox = New System.Windows.Forms.CheckBox
        Me.mailOpsCheckBox = New System.Windows.Forms.CheckBox
        Me.messagesCheckBox = New System.Windows.Forms.CheckBox
        Me.switches1 = New System.Windows.Forms.TabPage
        Me.Label12 = New System.Windows.Forms.Label
        Me.transferPointOnScanFormCheckBox = New System.Windows.Forms.CheckBox
        Me.presetsRequireDestinationSpecCheckBox = New System.Windows.Forms.CheckBox
        Me.usePresetOnLoadCheckBox = New System.Windows.Forms.CheckBox
        Me.switches2 = New System.Windows.Forms.TabPage
        Me.Label13 = New System.Windows.Forms.Label
        Me.passwordRequiredForLocChangeCheckBox = New System.Windows.Forms.CheckBox
        Me.triStateLargeBarcodeCheckBoxCheckBox = New System.Windows.Forms.CheckBox
        Me.displayFlightValidationMessagesCheckBox = New System.Windows.Forms.CheckBox
        Me.warnOfDuplicateScansCheckBox = New System.Windows.Forms.CheckBox
        Me.lockdownReleasedOnAdminFormCheckBox = New System.Windows.Forms.CheckBox
        Me.treatTransferScansAsLoadScansCheckBox = New System.Windows.Forms.CheckBox
        Me.ftpConfig = New System.Windows.Forms.TabPage
        Me.Label15 = New System.Windows.Forms.Label
        Me.Label22 = New System.Windows.Forms.Label
        Me.ipAddressLabel = New System.Windows.Forms.Label
        Me.ftpPasswordTextBox = New System.Windows.Forms.TextBox
        Me.Label1 = New System.Windows.Forms.Label
        Me.Label2 = New System.Windows.Forms.Label
        Me.ftpLoginIDTextBox = New System.Windows.Forms.TextBox
        Me.ftpPortTextBox = New System.Windows.Forms.TextBox
        Me.Label9 = New System.Windows.Forms.Label
        Me.Label10 = New System.Windows.Forms.Label
        Me.ftpHostTextBox = New System.Windows.Forms.TextBox
        Me.userInfoTabPage = New System.Windows.Forms.TabPage
        Me.carrierCodeTextBox = New System.Windows.Forms.TextBox
        Me.userFullNameTextBox = New System.Windows.Forms.TextBox
        Me.userNameTextBox = New System.Windows.Forms.TextBox
        Me.Label27 = New System.Windows.Forms.Label
        Me.Label26 = New System.Windows.Forms.Label
        Me.Label25 = New System.Windows.Forms.Label
        Me.operations = New System.Windows.Forms.TabPage
        Me.Label24 = New System.Windows.Forms.Label
        Me.Label23 = New System.Windows.Forms.Label
        Me.Label19 = New System.Windows.Forms.Label
        Me.Label20 = New System.Windows.Forms.Label
        Me.Label21 = New System.Windows.Forms.Label
        Me.addOperationButton = New System.Windows.Forms.Button
        Me.deleteOperationButton = New System.Windows.Forms.Button
        Me.availableOperationsListBox = New System.Windows.Forms.ListBox
        Me.currentOperationsListBox = New System.Windows.Forms.ListBox
        Me.cityListTabPage = New System.Windows.Forms.TabPage
        Me.Label18 = New System.Windows.Forms.Label
        Me.Label17 = New System.Windows.Forms.Label
        Me.Label16 = New System.Windows.Forms.Label
        Me.addCityButton = New System.Windows.Forms.Button
        Me.deleteCityButton = New System.Windows.Forms.Button
        Me.availableCityListBox = New System.Windows.Forms.ListBox
        Me.currentCityListBox = New System.Windows.Forms.ListBox
        Me.applyConfigChangesButton = New System.Windows.Forms.Button
        Me.saveConfigChangesButton = New System.Windows.Forms.Button
        Me.MainMenu1 = New System.Windows.Forms.MainMenu
        Me.InputPanel1 = New Microsoft.WindowsCE.Forms.InputPanel
        Me.proxyConfig = New System.Windows.Forms.TabPage
        Me.UseProxyCheckBox = New System.Windows.Forms.CheckBox
        Me.ProxyTypeComboBox = New System.Windows.Forms.ComboBox
        Me.Label3 = New System.Windows.Forms.Label
        Me.Label4 = New System.Windows.Forms.Label
        Me.Label5 = New System.Windows.Forms.Label
        Me.Label6 = New System.Windows.Forms.Label
        Me.Label7 = New System.Windows.Forms.Label
        Me.ProxyHostTextBox = New System.Windows.Forms.TextBox
        Me.ProxyPortTextBox = New System.Windows.Forms.TextBox
        Me.ProxyUsernameTextBox = New System.Windows.Forms.TextBox
        Me.ProxyPasswordTextbox = New System.Windows.Forms.TextBox
        '
        'exitButton
        '
        Me.exitButton.Location = New System.Drawing.Point(160, 216)
        Me.exitButton.Size = New System.Drawing.Size(64, 21)
        Me.exitButton.Text = "Exit"
        '
        'adminTabControl
        '
        Me.adminTabControl.Controls.Add(Me.scanFunctionsTabPage)
        Me.adminTabControl.Controls.Add(Me.switches1)
        Me.adminTabControl.Controls.Add(Me.switches2)
        Me.adminTabControl.Controls.Add(Me.ftpConfig)
        Me.adminTabControl.Controls.Add(Me.proxyConfig)
        Me.adminTabControl.Controls.Add(Me.operations)
        Me.adminTabControl.Controls.Add(Me.userInfoTabPage)
        Me.adminTabControl.Controls.Add(Me.cityListTabPage)
        Me.adminTabControl.SelectedIndex = 0
        Me.adminTabControl.Size = New System.Drawing.Size(234, 200)
        '
        'scanFunctionsTabPage
        '
        Me.scanFunctionsTabPage.Controls.Add(Me.scanningOptionsDisabledLabel)
        Me.scanFunctionsTabPage.Controls.Add(Me.availableOptionsLabel)
        Me.scanFunctionsTabPage.Controls.Add(Me.baggageOpsCheckBox)
        Me.scanFunctionsTabPage.Controls.Add(Me.cargoOpsCheckBox)
        Me.scanFunctionsTabPage.Controls.Add(Me.mailSimpleOpsCheckBox)
        Me.scanFunctionsTabPage.Controls.Add(Me.mailOpsCheckBox)
        Me.scanFunctionsTabPage.Controls.Add(Me.messagesCheckBox)
        Me.scanFunctionsTabPage.Location = New System.Drawing.Point(4, 4)
        Me.scanFunctionsTabPage.Size = New System.Drawing.Size(226, 174)
        Me.scanFunctionsTabPage.Text = "Scan Functions"
        '
        'scanningOptionsDisabledLabel
        '
        Me.scanningOptionsDisabledLabel.Location = New System.Drawing.Point(2, 1)
        Me.scanningOptionsDisabledLabel.Size = New System.Drawing.Size(236, 34)
        Me.scanningOptionsDisabledLabel.Text = "Initialization Process Must Be Completed Before Changing These Options"
        Me.scanningOptionsDisabledLabel.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'availableOptionsLabel
        '
        Me.availableOptionsLabel.Font = New System.Drawing.Font("Tahoma", 12.0!, System.Drawing.FontStyle.Regular)
        Me.availableOptionsLabel.Location = New System.Drawing.Point(10, 4)
        Me.availableOptionsLabel.Size = New System.Drawing.Size(216, 20)
        Me.availableOptionsLabel.Text = "Available Scanning Options"
        Me.availableOptionsLabel.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'baggageOpsCheckBox
        '
        Me.baggageOpsCheckBox.Location = New System.Drawing.Point(25, 136)
        Me.baggageOpsCheckBox.Size = New System.Drawing.Size(152, 20)
        Me.baggageOpsCheckBox.Text = "Baggage Operations"
        '
        'cargoOpsCheckBox
        '
        Me.cargoOpsCheckBox.Location = New System.Drawing.Point(25, 112)
        Me.cargoOpsCheckBox.Size = New System.Drawing.Size(126, 20)
        Me.cargoOpsCheckBox.Text = "Cargo Operations"
        '
        'mailSimpleOpsCheckBox
        '
        Me.mailSimpleOpsCheckBox.Location = New System.Drawing.Point(25, 88)
        Me.mailSimpleOpsCheckBox.Size = New System.Drawing.Size(170, 20)
        Me.mailSimpleOpsCheckBox.Text = "Mail Operations (Simple)"
        '
        'mailOpsCheckBox
        '
        Me.mailOpsCheckBox.Location = New System.Drawing.Point(25, 64)
        Me.mailOpsCheckBox.Size = New System.Drawing.Size(124, 20)
        Me.mailOpsCheckBox.Text = "Mail Operations"
        '
        'messagesCheckBox
        '
        Me.messagesCheckBox.Location = New System.Drawing.Point(25, 40)
        Me.messagesCheckBox.Size = New System.Drawing.Size(92, 20)
        Me.messagesCheckBox.Text = "Messages"
        '
        'switches1
        '
        Me.switches1.Controls.Add(Me.Label12)
        Me.switches1.Controls.Add(Me.transferPointOnScanFormCheckBox)
        Me.switches1.Controls.Add(Me.presetsRequireDestinationSpecCheckBox)
        Me.switches1.Controls.Add(Me.usePresetOnLoadCheckBox)
        Me.switches1.Location = New System.Drawing.Point(4, 4)
        Me.switches1.Size = New System.Drawing.Size(226, 174)
        Me.switches1.Text = "Switches (1)"
        '
        'Label12
        '
        Me.Label12.Location = New System.Drawing.Point(24, 24)
        Me.Label12.Size = New System.Drawing.Size(159, 15)
        Me.Label12.Text = "Switches (1 of 2)"
        Me.Label12.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'transferPointOnScanFormCheckBox
        '
        Me.transferPointOnScanFormCheckBox.Location = New System.Drawing.Point(6, 120)
        Me.transferPointOnScanFormCheckBox.Size = New System.Drawing.Size(226, 20)
        Me.transferPointOnScanFormCheckBox.Text = "Display Transfer Point On Scan Form"
        '
        'presetsRequireDestinationSpecCheckBox
        '
        Me.presetsRequireDestinationSpecCheckBox.Location = New System.Drawing.Point(6, 88)
        Me.presetsRequireDestinationSpecCheckBox.Size = New System.Drawing.Size(207, 20)
        Me.presetsRequireDestinationSpecCheckBox.Text = "Preset Require Destination"
        '
        'usePresetOnLoadCheckBox
        '
        Me.usePresetOnLoadCheckBox.Location = New System.Drawing.Point(6, 56)
        Me.usePresetOnLoadCheckBox.Size = New System.Drawing.Size(165, 20)
        Me.usePresetOnLoadCheckBox.Text = "Use Preset On Load Scan"
        '
        'switches2
        '
        Me.switches2.Controls.Add(Me.Label13)
        Me.switches2.Controls.Add(Me.passwordRequiredForLocChangeCheckBox)
        Me.switches2.Controls.Add(Me.triStateLargeBarcodeCheckBoxCheckBox)
        Me.switches2.Controls.Add(Me.displayFlightValidationMessagesCheckBox)
        Me.switches2.Controls.Add(Me.warnOfDuplicateScansCheckBox)
        Me.switches2.Controls.Add(Me.lockdownReleasedOnAdminFormCheckBox)
        Me.switches2.Controls.Add(Me.treatTransferScansAsLoadScansCheckBox)
        Me.switches2.Location = New System.Drawing.Point(4, 4)
        Me.switches2.Size = New System.Drawing.Size(226, 174)
        Me.switches2.Text = "Switches (2)"
        '
        'Label13
        '
        Me.Label13.Location = New System.Drawing.Point(36, 3)
        Me.Label13.Size = New System.Drawing.Size(159, 15)
        Me.Label13.Text = "Switches (2 of 2)"
        Me.Label13.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'passwordRequiredForLocChangeCheckBox
        '
        Me.passwordRequiredForLocChangeCheckBox.Location = New System.Drawing.Point(7, 29)
        Me.passwordRequiredForLocChangeCheckBox.Size = New System.Drawing.Size(223, 20)
        Me.passwordRequiredForLocChangeCheckBox.Text = "Password Required For Loc Change"
        '
        'triStateLargeBarcodeCheckBoxCheckBox
        '
        Me.triStateLargeBarcodeCheckBoxCheckBox.Location = New System.Drawing.Point(7, 144)
        Me.triStateLargeBarcodeCheckBoxCheckBox.Size = New System.Drawing.Size(220, 20)
        Me.triStateLargeBarcodeCheckBoxCheckBox.Text = "Tri-State Large Barcode Check Box"
        '
        'displayFlightValidationMessagesCheckBox
        '
        Me.displayFlightValidationMessagesCheckBox.Location = New System.Drawing.Point(7, 121)
        Me.displayFlightValidationMessagesCheckBox.Size = New System.Drawing.Size(220, 20)
        Me.displayFlightValidationMessagesCheckBox.Text = "Display Flight Validation Messages"
        '
        'warnOfDuplicateScansCheckBox
        '
        Me.warnOfDuplicateScansCheckBox.Location = New System.Drawing.Point(7, 98)
        Me.warnOfDuplicateScansCheckBox.Size = New System.Drawing.Size(212, 20)
        Me.warnOfDuplicateScansCheckBox.Text = "Warn Of Duplicate Scans"
        '
        'lockdownReleasedOnAdminFormCheckBox
        '
        Me.lockdownReleasedOnAdminFormCheckBox.Location = New System.Drawing.Point(7, 75)
        Me.lockdownReleasedOnAdminFormCheckBox.Size = New System.Drawing.Size(223, 20)
        Me.lockdownReleasedOnAdminFormCheckBox.Text = "Lockdown Released On Admin Form"
        '
        'treatTransferScansAsLoadScansCheckBox
        '
        Me.treatTransferScansAsLoadScansCheckBox.Location = New System.Drawing.Point(7, 52)
        Me.treatTransferScansAsLoadScansCheckBox.Size = New System.Drawing.Size(223, 20)
        Me.treatTransferScansAsLoadScansCheckBox.Text = "Treat Transfers as Loads"
        '
        'ftpConfig
        '
        Me.ftpConfig.Controls.Add(Me.Label15)
        Me.ftpConfig.Controls.Add(Me.Label22)
        Me.ftpConfig.Controls.Add(Me.ipAddressLabel)
        Me.ftpConfig.Controls.Add(Me.ftpPasswordTextBox)
        Me.ftpConfig.Controls.Add(Me.Label1)
        Me.ftpConfig.Controls.Add(Me.Label2)
        Me.ftpConfig.Controls.Add(Me.ftpLoginIDTextBox)
        Me.ftpConfig.Controls.Add(Me.ftpPortTextBox)
        Me.ftpConfig.Controls.Add(Me.Label9)
        Me.ftpConfig.Controls.Add(Me.Label10)
        Me.ftpConfig.Controls.Add(Me.ftpHostTextBox)
        Me.ftpConfig.Location = New System.Drawing.Point(4, 4)
        Me.ftpConfig.Size = New System.Drawing.Size(226, 174)
        Me.ftpConfig.Text = "Ftp Config"
        '
        'Label15
        '
        Me.Label15.Location = New System.Drawing.Point(37, 3)
        Me.Label15.Size = New System.Drawing.Size(174, 16)
        Me.Label15.Text = "FTP Configuration"
        Me.Label15.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'Label22
        '
        Me.Label22.Location = New System.Drawing.Point(5, 128)
        Me.Label22.Size = New System.Drawing.Size(82, 17)
        Me.Label22.Text = "IP Address:"
        '
        'ipAddressLabel
        '
        Me.ipAddressLabel.Location = New System.Drawing.Point(95, 128)
        Me.ipAddressLabel.Size = New System.Drawing.Size(134, 21)
        '
        'ftpPasswordTextBox
        '
        Me.ftpPasswordTextBox.Location = New System.Drawing.Point(95, 96)
        Me.ftpPasswordTextBox.Size = New System.Drawing.Size(133, 22)
        Me.ftpPasswordTextBox.Text = ""
        '
        'Label1
        '
        Me.Label1.Location = New System.Drawing.Point(5, 75)
        Me.Label1.Size = New System.Drawing.Size(78, 17)
        Me.Label1.Text = "Ftp Login ID:"
        '
        'Label2
        '
        Me.Label2.Location = New System.Drawing.Point(5, 99)
        Me.Label2.Size = New System.Drawing.Size(82, 17)
        Me.Label2.Text = "Ftp Password:"
        '
        'ftpLoginIDTextBox
        '
        Me.ftpLoginIDTextBox.Location = New System.Drawing.Point(95, 72)
        Me.ftpLoginIDTextBox.Size = New System.Drawing.Size(133, 22)
        Me.ftpLoginIDTextBox.Text = ""
        '
        'ftpPortTextBox
        '
        Me.ftpPortTextBox.Location = New System.Drawing.Point(95, 48)
        Me.ftpPortTextBox.Size = New System.Drawing.Size(133, 22)
        Me.ftpPortTextBox.Text = ""
        '
        'Label9
        '
        Me.Label9.Location = New System.Drawing.Point(5, 27)
        Me.Label9.Size = New System.Drawing.Size(70, 17)
        Me.Label9.Text = "Ftp Host:"
        '
        'Label10
        '
        Me.Label10.Location = New System.Drawing.Point(5, 51)
        Me.Label10.Size = New System.Drawing.Size(76, 17)
        Me.Label10.Text = "Ftp Port:"
        '
        'ftpHostTextBox
        '
        Me.ftpHostTextBox.Location = New System.Drawing.Point(95, 24)
        Me.ftpHostTextBox.Size = New System.Drawing.Size(133, 22)
        Me.ftpHostTextBox.Text = ""
        '
        'userInfoTabPage
        '
        Me.userInfoTabPage.Controls.Add(Me.carrierCodeTextBox)
        Me.userInfoTabPage.Controls.Add(Me.userFullNameTextBox)
        Me.userInfoTabPage.Controls.Add(Me.userNameTextBox)
        Me.userInfoTabPage.Controls.Add(Me.Label27)
        Me.userInfoTabPage.Controls.Add(Me.Label26)
        Me.userInfoTabPage.Controls.Add(Me.Label25)
        Me.userInfoTabPage.Location = New System.Drawing.Point(4, 4)
        Me.userInfoTabPage.Size = New System.Drawing.Size(226, 174)
        Me.userInfoTabPage.Text = "User Info"
        '
        'carrierCodeTextBox
        '
        Me.carrierCodeTextBox.Location = New System.Drawing.Point(106, 71)
        Me.carrierCodeTextBox.Size = New System.Drawing.Size(119, 22)
        Me.carrierCodeTextBox.Text = ""
        '
        'userFullNameTextBox
        '
        Me.userFullNameTextBox.Location = New System.Drawing.Point(106, 44)
        Me.userFullNameTextBox.Size = New System.Drawing.Size(119, 22)
        Me.userFullNameTextBox.Text = ""
        '
        'userNameTextBox
        '
        Me.userNameTextBox.Location = New System.Drawing.Point(106, 17)
        Me.userNameTextBox.Size = New System.Drawing.Size(119, 22)
        Me.userNameTextBox.Text = ""
        '
        'Label27
        '
        Me.Label27.Location = New System.Drawing.Point(6, 73)
        Me.Label27.Size = New System.Drawing.Size(94, 22)
        Me.Label27.Text = "Carrier Code"
        '
        'Label26
        '
        Me.Label26.Location = New System.Drawing.Point(6, 46)
        Me.Label26.Size = New System.Drawing.Size(116, 22)
        Me.Label26.Text = "User Full Name"
        '
        'Label25
        '
        Me.Label25.Location = New System.Drawing.Point(6, 19)
        Me.Label25.Size = New System.Drawing.Size(90, 22)
        Me.Label25.Text = "User Name"
        '
        'operations
        '
        Me.operations.Controls.Add(Me.Label24)
        Me.operations.Controls.Add(Me.Label23)
        Me.operations.Controls.Add(Me.Label19)
        Me.operations.Controls.Add(Me.Label20)
        Me.operations.Controls.Add(Me.Label21)
        Me.operations.Controls.Add(Me.addOperationButton)
        Me.operations.Controls.Add(Me.deleteOperationButton)
        Me.operations.Controls.Add(Me.availableOperationsListBox)
        Me.operations.Controls.Add(Me.currentOperationsListBox)
        Me.operations.Location = New System.Drawing.Point(4, 4)
        Me.operations.Size = New System.Drawing.Size(226, 174)
        Me.operations.Text = "Operations"
        '
        'Label24
        '
        Me.Label24.Location = New System.Drawing.Point(148, 40)
        Me.Label24.Size = New System.Drawing.Size(77, 13)
        Me.Label24.Text = "Operations"
        Me.Label24.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'Label23
        '
        Me.Label23.Location = New System.Drawing.Point(15, 40)
        Me.Label23.Size = New System.Drawing.Size(77, 13)
        Me.Label23.Text = "Operations"
        Me.Label23.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'Label19
        '
        Me.Label19.Location = New System.Drawing.Point(52, 4)
        Me.Label19.Size = New System.Drawing.Size(134, 13)
        Me.Label19.Text = "Edit Operation List"
        Me.Label19.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'Label20
        '
        Me.Label20.Location = New System.Drawing.Point(160, 25)
        Me.Label20.Size = New System.Drawing.Size(53, 13)
        Me.Label20.Text = "Available"
        Me.Label20.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'Label21
        '
        Me.Label21.Location = New System.Drawing.Point(28, 25)
        Me.Label21.Size = New System.Drawing.Size(51, 13)
        Me.Label21.Text = "Current"
        Me.Label21.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'addOperationButton
        '
        Me.addOperationButton.Font = New System.Drawing.Font("Tahoma", 7.8!, System.Drawing.FontStyle.Regular)
        Me.addOperationButton.Location = New System.Drawing.Point(103, 80)
        Me.addOperationButton.Size = New System.Drawing.Size(32, 23)
        Me.addOperationButton.Text = "<<"
        '
        'deleteOperationButton
        '
        Me.deleteOperationButton.Font = New System.Drawing.Font("Tahoma", 7.8!, System.Drawing.FontStyle.Regular)
        Me.deleteOperationButton.Location = New System.Drawing.Point(102, 117)
        Me.deleteOperationButton.Size = New System.Drawing.Size(32, 23)
        Me.deleteOperationButton.Text = ">>"
        '
        'availableOperationsListBox
        '
        Me.availableOperationsListBox.Font = New System.Drawing.Font("Tahoma", 7.8!, System.Drawing.FontStyle.Regular)
        Me.availableOperationsListBox.Location = New System.Drawing.Point(138, 58)
        Me.availableOperationsListBox.Size = New System.Drawing.Size(89, 98)
        '
        'currentOperationsListBox
        '
        Me.currentOperationsListBox.Font = New System.Drawing.Font("Tahoma", 7.8!, System.Drawing.FontStyle.Regular)
        Me.currentOperationsListBox.Location = New System.Drawing.Point(7, 58)
        Me.currentOperationsListBox.Size = New System.Drawing.Size(89, 98)
        '
        'cityListTabPage
        '
        Me.cityListTabPage.Controls.Add(Me.Label18)
        Me.cityListTabPage.Controls.Add(Me.Label17)
        Me.cityListTabPage.Controls.Add(Me.Label16)
        Me.cityListTabPage.Controls.Add(Me.addCityButton)
        Me.cityListTabPage.Controls.Add(Me.deleteCityButton)
        Me.cityListTabPage.Controls.Add(Me.availableCityListBox)
        Me.cityListTabPage.Controls.Add(Me.currentCityListBox)
        Me.cityListTabPage.Location = New System.Drawing.Point(4, 4)
        Me.cityListTabPage.Size = New System.Drawing.Size(226, 174)
        Me.cityListTabPage.Text = "City List"
        '
        'Label18
        '
        Me.Label18.Location = New System.Drawing.Point(52, 3)
        Me.Label18.Size = New System.Drawing.Size(134, 13)
        Me.Label18.Text = "Edit City List"
        Me.Label18.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'Label17
        '
        Me.Label17.Location = New System.Drawing.Point(141, 22)
        Me.Label17.Size = New System.Drawing.Size(88, 13)
        Me.Label17.Text = "Available Cities"
        Me.Label17.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'Label16
        '
        Me.Label16.Location = New System.Drawing.Point(7, 22)
        Me.Label16.Size = New System.Drawing.Size(88, 13)
        Me.Label16.Text = "Current Cities"
        Me.Label16.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'addCityButton
        '
        Me.addCityButton.Location = New System.Drawing.Point(94, 67)
        Me.addCityButton.Size = New System.Drawing.Size(46, 23)
        Me.addCityButton.Text = "<<"
        '
        'deleteCityButton
        '
        Me.deleteCityButton.Location = New System.Drawing.Point(94, 118)
        Me.deleteCityButton.Size = New System.Drawing.Size(46, 23)
        Me.deleteCityButton.Text = ">>"
        '
        'availableCityListBox
        '
        Me.availableCityListBox.Location = New System.Drawing.Point(153, 43)
        Me.availableCityListBox.Size = New System.Drawing.Size(64, 100)
        '
        'currentCityListBox
        '
        Me.currentCityListBox.Location = New System.Drawing.Point(17, 43)
        Me.currentCityListBox.Size = New System.Drawing.Size(64, 100)
        '
        'applyConfigChangesButton
        '
        Me.applyConfigChangesButton.Location = New System.Drawing.Point(16, 216)
        Me.applyConfigChangesButton.Size = New System.Drawing.Size(64, 21)
        Me.applyConfigChangesButton.Text = "Apply"
        '
        'saveConfigChangesButton
        '
        Me.saveConfigChangesButton.Location = New System.Drawing.Point(88, 216)
        Me.saveConfigChangesButton.Size = New System.Drawing.Size(64, 21)
        Me.saveConfigChangesButton.Text = "Save"
        '
        'proxyConfig
        '
        Me.proxyConfig.Controls.Add(Me.ProxyPasswordTextbox)
        Me.proxyConfig.Controls.Add(Me.ProxyUsernameTextBox)
        Me.proxyConfig.Controls.Add(Me.ProxyPortTextBox)
        Me.proxyConfig.Controls.Add(Me.ProxyHostTextBox)
        Me.proxyConfig.Controls.Add(Me.Label7)
        Me.proxyConfig.Controls.Add(Me.Label6)
        Me.proxyConfig.Controls.Add(Me.Label5)
        Me.proxyConfig.Controls.Add(Me.Label4)
        Me.proxyConfig.Controls.Add(Me.Label3)
        Me.proxyConfig.Controls.Add(Me.ProxyTypeComboBox)
        Me.proxyConfig.Controls.Add(Me.UseProxyCheckBox)
        Me.proxyConfig.Location = New System.Drawing.Point(4, 4)
        Me.proxyConfig.Size = New System.Drawing.Size(226, 174)
        Me.proxyConfig.Text = "Proxy"
        '
        'UseProxyCheckBox
        '
        Me.UseProxyCheckBox.Location = New System.Drawing.Point(8, 8)
        Me.UseProxyCheckBox.Text = "Use Proxy"
        '
        'ProxyTypeComboBox
        '
        Me.ProxyTypeComboBox.Items.Add("FtpOpen")
        Me.ProxyTypeComboBox.Items.Add("FtpSite")
        Me.ProxyTypeComboBox.Items.Add("FtpUser")
        Me.ProxyTypeComboBox.Items.Add("HttpConnect")
        Me.ProxyTypeComboBox.Items.Add("None")
        Me.ProxyTypeComboBox.Items.Add("Socks4")
        Me.ProxyTypeComboBox.Items.Add("Socks4a")
        Me.ProxyTypeComboBox.Items.Add("Socks5")
        Me.ProxyTypeComboBox.Location = New System.Drawing.Point(80, 33)
        Me.ProxyTypeComboBox.Size = New System.Drawing.Size(128, 22)
        '
        'Label3
        '
        Me.Label3.Location = New System.Drawing.Point(8, 35)
        Me.Label3.Size = New System.Drawing.Size(64, 20)
        Me.Label3.Text = "Type"
        '
        'Label4
        '
        Me.Label4.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular)
        Me.Label4.Location = New System.Drawing.Point(8, 62)
        Me.Label4.Size = New System.Drawing.Size(64, 20)
        Me.Label4.Text = "Host"
        '
        'Label5
        '
        Me.Label5.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular)
        Me.Label5.Location = New System.Drawing.Point(8, 89)
        Me.Label5.Size = New System.Drawing.Size(64, 20)
        Me.Label5.Text = "Port"
        '
        'Label6
        '
        Me.Label6.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular)
        Me.Label6.Location = New System.Drawing.Point(8, 116)
        Me.Label6.Size = New System.Drawing.Size(64, 20)
        Me.Label6.Text = "Username"
        '
        'Label7
        '
        Me.Label7.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular)
        Me.Label7.Location = New System.Drawing.Point(8, 143)
        Me.Label7.Size = New System.Drawing.Size(64, 20)
        Me.Label7.Text = "Password"
        '
        'ProxyHostTextBox
        '
        Me.ProxyHostTextBox.Location = New System.Drawing.Point(80, 60)
        Me.ProxyHostTextBox.Size = New System.Drawing.Size(128, 22)
        Me.ProxyHostTextBox.Text = ""
        '
        'ProxyPortTextBox
        '
        Me.ProxyPortTextBox.Location = New System.Drawing.Point(80, 87)
        Me.ProxyPortTextBox.Size = New System.Drawing.Size(128, 22)
        Me.ProxyPortTextBox.Text = ""
        '
        'ProxyUsernameTextBox
        '
        Me.ProxyUsernameTextBox.Location = New System.Drawing.Point(80, 114)
        Me.ProxyUsernameTextBox.Size = New System.Drawing.Size(128, 22)
        Me.ProxyUsernameTextBox.Text = ""
        '
        'ProxyPasswordTextbox
        '
        Me.ProxyPasswordTextbox.Location = New System.Drawing.Point(80, 141)
        Me.ProxyPasswordTextbox.Size = New System.Drawing.Size(128, 22)
        Me.ProxyPasswordTextbox.Text = ""
        '
        'adminConfigForm
        '
        Me.ClientSize = New System.Drawing.Size(234, 280)
        Me.ControlBox = False
        Me.Controls.Add(Me.saveConfigChangesButton)
        Me.Controls.Add(Me.applyConfigChangesButton)
        Me.Controls.Add(Me.adminTabControl)
        Me.Controls.Add(Me.exitButton)
        Me.Menu = Me.MainMenu1
        Me.Text = "Config Management"

    End Sub

#End Region

    Private Sub formOnLoad(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        ' For some unknown reason, the context menu associated with the scanning operations
        ' cannot be changed until the reader form (which contains the context menu) is loaded.
        ' The following section guarantees that the user will not try to change the options associated
        ' with this menu

        If Not TagTrakGlobals.readerFormLoaded Then

            Me.scanningOptionsDisabledLabel.Visible = True
            Me.scanningOptionsDisabledLabel.BringToFront()

            Me.availableOptionsLabel.Visible = False

            Me.messagesCheckBox.Enabled = False
            Me.mailOpsCheckBox.Enabled = False
            Me.mailSimpleOpsCheckBox.Enabled = False
            Me.cargoOpsCheckBox.Enabled = False
            Me.baggageOpsCheckBox.Enabled = False
        Else

            Me.availableOptionsLabel.Visible = True
            Me.availableOptionsLabel.BringToFront()

            Me.scanningOptionsDisabledLabel.Visible = False

            Me.availableOptionsLabel.Enabled = True
            Me.messagesCheckBox.Enabled = True
            Me.mailOpsCheckBox.Enabled = True
            Me.mailSimpleOpsCheckBox.Enabled = True
            Me.cargoOpsCheckBox.Enabled = True
            Me.baggageOpsCheckBox.Enabled = True

        End If
        'Cursor.Current = Cursors.Default
    End Sub

    Private Sub exitButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles exitButton.Click

        processUserSpecRecordChange()

        Me.Hide()

    End Sub

    Private Sub processConfigurationChanges()
        Dim result As String

        user = Trim(userNameTextBox.Text)

        userSpecRecord.userName = Trim(userNameTextBox.Text)
        userSpecRecord.userFullName = Trim(userFullNameTextBox.Text)
        userSpecRecord.carrierCode = Trim(carrierCodeTextBox.Text)


        userSpecRecord.lockDownReleasedInAdminForm = lockdownReleasedOnAdminFormCheckBox.Checked
        userSpecRecord.passwordRequiredForLocationChangeOnScanForm = passwordRequiredForLocChangeCheckBox.Checked
        userSpecRecord.presetsRequireDestinationSpecifications = presetsRequireDestinationSpecCheckBox.Checked
        userSpecRecord.transferPointOnScanForm = transferPointOnScanFormCheckBox.Checked
        userSpecRecord.treatTransferScansAsLoadScans = treatTransferScansAsLoadScansCheckBox.Checked
        userSpecRecord.loadScansRequireSelectionFromPreset = usePresetOnLoadCheckBox.Checked
        userSpecRecord.warnOnDuplicateScan = warnOfDuplicateScansCheckBox.Checked
        userSpecRecord.displayFlightValidationMessages = displayFlightValidationMessagesCheckBox.Checked
        userSpecRecord.triStateLargeBarcodeCheckBox = triStateLargeBarcodeCheckBoxCheckBox.Checked
        userSpecRecord.baggageScanEnabled = baggageOpsCheckBox.Checked

        userSpecRecord.cargoScanEnabled = cargoOpsCheckBox.Checked
        userSpecRecord.mailScanEnabled = mailOpsCheckBox.Checked
        userSpecRecord.mailSimpleScanEnabled = mailSimpleOpsCheckBox.Checked
        userSpecRecord.messagesEnabled = messagesCheckBox.Checked

        userSpecRecord.ftpLoginID = Trim(ftpLoginIDTextBox.Text)
        userSpecRecord.ftpPassword = Trim(ftpPasswordTextBox.Text)
        userSpecRecord.ftpHostName = Trim(ftpHostTextBox.Text)
        userSpecRecord.ftpPortNumber = Trim(ftpPortTextBox.Text)

        userSpecRecord.UseFtpProxy = Me.UseProxyCheckBox.Checked
        userSpecRecord.ProxyHost = Trim(Me.ProxyHostTextBox.Text)
        If Trim(Me.ProxyPortTextBox.Text) <> "" Then
            userSpecRecord.ProxyPort = Integer.Parse(Trim(Me.ProxyPortTextBox.Text))
        End If
        userSpecRecord.ProxyType = Trim(CStr(Me.ProxyTypeComboBox.SelectedItem))
        userSpecRecord.ProxyUser = Trim(Me.ProxyUsernameTextBox.Text)
        userSpecRecord.ProxyPassword = Trim(Me.ProxyPasswordTextbox.Text)

        With MailScanFormRepository.MailScanDomsForm
            .mailCarrierCodeLabel.Text = userSpecRecord.carrierCode

            'transfer point spec

            .transferPointLabel.Enabled = userSpecRecord.transferPointOnScanForm
            .transferPointTextBox.Enabled = userSpecRecord.transferPointOnScanForm
            .transferPointLabel.Visible = userSpecRecord.transferPointOnScanForm
            .transferPointTextBox.Visible = userSpecRecord.transferPointOnScanForm

        End With


        currentAdminLoginForm.hideMenuBarButton.Visible = userSpecRecord.lockDownReleasedInAdminForm
        currentAdminLoginForm.hideMenuBarButton.Enabled = userSpecRecord.lockDownReleasedInAdminForm
        currentAdminLoginForm.showMenuBarButton.Visible = userSpecRecord.lockDownReleasedInAdminForm
        currentAdminLoginForm.showMenuBarButton.Enabled = userSpecRecord.lockDownReleasedInAdminForm

        userSpecRecord.cityListString = ""

        'Modified by MX for new configuration format
        'If Me.currentCityListBox.Items.Count > 0 Then

        '    Dim city As String

        '    Dim i, ilmt As Integer

        '    ilmt = Me.currentCityListBox.Items.Count - 1

        '    i = 0

        '    While i < ilmt

        '        userSpecRecord.cityListString &= Me.currentCityListBox.Items.Item(i) & ", "

        '        i += 1

        '    End While

        '    userSpecRecord.cityListString &= Me.currentCityListBox.Items.Item(i)

        'End If

        For Each city As String In userSpecRecord.cityList

            If userSpecRecord.cityTable.ContainsKey(city) Then

                userSpecRecord.cityListString &= "<" & city & ">" _
                    & CType(userSpecRecord.cityTable.Item(city), CityConfig).ToString _
                    & "</" & city & ">"

            End If

        Next

        userSpecRecord.operationListString = ""

        If Me.currentOperationsListBox.Items.Count > 0 Then

            Dim operation As String

            Dim i, ilmt As Integer

            ilmt = Me.currentOperationsListBox.Items.Count - 1

            i = 0

            While i < ilmt

                userSpecRecord.operationListString &= Me.currentOperationsListBox.Items.Item(i) & ", "

                i += 1

            End While

            userSpecRecord.operationListString &= Me.currentOperationsListBox.Items.Item(i)

        End If

        userSpecRecord.parseOperationListString()

        applyConfigChangesButton.Enabled = False

    End Sub

    Private Sub applyConfigChangesButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles applyConfigChangesButton.Click

        processConfigurationChanges()

    End Sub


    Private Sub saveConfigurationChanges()

        processConfigurationChanges()
        userSpecRecord.updateXMLDocument()
        userSpecRecord.saveXMLDocument()

        saveConfigChangesButton.Enabled = False
    End Sub

    Private Sub processUserSpecRecordChange()

        If applyConfigChangesButton.Enabled Then

            Dim msgResult As MsgBoxResult = MsgBox("Apply Changes To Current User Configuration?", MsgBoxStyle.YesNo, "Save Changes?")
            If msgResult = MsgBoxResult.Yes Then
                processConfigurationChanges()
            End If

        End If

        If saveConfigChangesButton.Enabled Then

            Dim msgResult As MsgBoxResult = MsgBox("Save Current User Configuration Changes (Make Changes Permanent)?", MsgBoxStyle.YesNo, "Save Changes?")
            If msgResult = MsgBoxResult.Yes Then
                saveConfigurationChanges()
            End If

        End If

    End Sub

    Dim currentTabPageIndex As Integer = -1

    Private Sub adminTabPage_EnabledChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles adminTabControl.SelectedIndexChanged

        Dim nextTabPageIndex As Integer = adminTabControl.SelectedIndex

        currentTabPageIndex = nextTabPageIndex
    End Sub

    Private Sub currentConfigChanged()
        applyConfigChangesButton.Enabled = True
        saveConfigChangesButton.Enabled = True
    End Sub

    Private Sub usePresetOnLoadCheckBox_CheckStateChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles usePresetOnLoadCheckBox.CheckStateChanged
        currentConfigChanged()
    End Sub

    Private Sub presetsRequireDestinationSpecCheckBox_CheckStateChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles presetsRequireDestinationSpecCheckBox.CheckStateChanged
        currentConfigChanged()
    End Sub

    Private Sub transferPointOnScanFormCheckBox_CheckStateChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles transferPointOnScanFormCheckBox.CheckStateChanged
        currentConfigChanged()
    End Sub

    Private Sub tailNumberOnScanFormCheckBox_CheckStateChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)
        currentConfigChanged()
    End Sub

    Private Sub locationChangeOnScanFormCheckBox_CheckStateChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)
        currentConfigChanged()
    End Sub

    Private Sub passwordRequiredForLocChangeCheckBox_CheckStateChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles passwordRequiredForLocChangeCheckBox.CheckStateChanged
        currentConfigChanged()
    End Sub

    Private Sub treatTransferScansAsLoadScansCheckBox_CheckStateChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles treatTransferScansAsLoadScansCheckBox.CheckStateChanged
        currentConfigChanged()
    End Sub

    Private Sub lockdownReleasedOnAdminFormCheckBox_CheckStateChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lockdownReleasedOnAdminFormCheckBox.CheckStateChanged
        currentConfigChanged()
    End Sub

    Private Sub warnOfDuplicateScansCheckBox_CheckStateChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles warnOfDuplicateScansCheckBox.CheckStateChanged
        currentConfigChanged()
    End Sub

    Private Sub displayFlightValidationMessagesCheckBox_CheckStateChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles displayFlightValidationMessagesCheckBox.CheckStateChanged
        currentConfigChanged()
    End Sub

    Private Sub triStateLargeBarcodeCheckBoxCheckBox_CheckStateChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles triStateLargeBarcodeCheckBoxCheckBox.CheckStateChanged
        currentConfigChanged()
    End Sub

    Private Sub ftpHostTextBox_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ftpHostTextBox.TextChanged
        currentConfigChanged()
    End Sub

    Private Sub ftpPortTextBox_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ftpPortTextBox.TextChanged
        currentConfigChanged()
    End Sub

    Private Sub ftpLoginIDTextBox_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ftpLoginIDTextBox.TextChanged
        currentConfigChanged()
    End Sub

    Private Sub ftpPasswordTextBox_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ftpPasswordTextBox.TextChanged
        currentConfigChanged()
    End Sub

    Dim processingButtonSpec As Boolean = False


    Private Sub saveConfigChangesButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles saveConfigChangesButton.Click
        saveConfigurationChanges()
    End Sub

    Private Sub transferCityElement(ByRef fromListBox As System.Windows.Forms.ListBox, ByRef toListBox As System.Windows.Forms.ListBox)

        Dim selectedIndex As Integer = fromListBox.SelectedIndex

        If selectedIndex < 0 Then Exit Sub

        applyConfigChangesButton.Enabled = True
        saveConfigChangesButton.Enabled = True

        Dim city As String = fromListBox.Items.Item(selectedIndex)

        Dim i, ilmt As Integer

        ilmt = toListBox.Items.Count - 1

        Dim locationFound As Boolean = False
        For i = 0 To ilmt

            If String.Compare(city, toListBox.Items.Item(i)) < 0 Then
                locationFound = True
                toListBox.Items.Insert(i, city)
                toListBox.SelectedIndex = i
                Exit For
            End If

        Next

        If Not locationFound Then
            toListBox.Items.Add(city)
            toListBox.SelectedIndex = toListBox.Items.Count - 1
        End If

        fromListBox.Items.RemoveAt(selectedIndex)

        If fromListBox.Items.Count > 0 Then

            If selectedIndex >= fromListBox.Items.Count Then
                selectedIndex = fromListBox.Items.Count - 1
            End If

            fromListBox.SelectedIndex = selectedIndex

        End If

    End Sub

    Private Sub addCityButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles addCityButton.Click

        transferCityElement(Me.availableCityListBox, Me.currentCityListBox)

        If Me.availableCityListBox.Items.Count <= 0 Then
            Me.addCityButton.Enabled = False
        End If

        If Me.currentCityListBox.Items.Count > 0 Then
            Me.deleteCityButton.Enabled = True
        End If

    End Sub

    Private Sub deleteCityButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles deleteCityButton.Click

        transferCityElement(Me.currentCityListBox, Me.availableCityListBox)

        If Me.availableCityListBox.Items.Count > 0 Then
            Me.addCityButton.Enabled = True
        End If

        If Me.currentCityListBox.Items.Count <= 0 Then
            Me.deleteCityButton.Enabled = False
        End If

    End Sub

    Private Sub transferOperationElement(ByRef fromListBox As System.Windows.Forms.ListBox, ByRef toListBox As System.Windows.Forms.ListBox)

        Dim selectedIndex As Integer = fromListBox.SelectedIndex

        If selectedIndex < 0 Then Exit Sub

        applyConfigChangesButton.Enabled = True
        saveConfigChangesButton.Enabled = True

        Dim fromOperation As String = fromListBox.Items.Item(selectedIndex)
        Dim fromOperationIndex As Integer

        Try
            fromOperationIndex = operationsMasterTable.Item(fromOperation)
        Catch ex As Exception
            fromOperationIndex = 999
        End Try

        Dim i, ilmt As Integer

        ilmt = toListBox.Items.Count - 1

        Dim locationFound As Boolean = False

        For i = 0 To ilmt

            Dim toOperation As String = toListBox.Items.Item(i)
            Dim toOperationIndex As Integer

            Try
                toOperationIndex = operationsMasterTable.Item(toOperation)
            Catch ex As Exception
                toOperationIndex = 999
            End Try

            If fromOperationIndex < toOperationIndex Then
                locationFound = True
                toListBox.Items.Insert(i, fromOperation)
                toListBox.SelectedIndex = i
                Exit For
            End If

        Next

        If Not locationFound Then
            toListBox.Items.Add(fromOperation)
            toListBox.SelectedIndex = toListBox.Items.Count - 1
        End If

        fromListBox.Items.RemoveAt(selectedIndex)

        If fromListBox.Items.Count > 0 Then

            If selectedIndex >= fromListBox.Items.Count Then
                selectedIndex = fromListBox.Items.Count - 1
            End If

            fromListBox.SelectedIndex = selectedIndex

        End If

    End Sub

    Private Sub addOperationButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles addOperationButton.Click

        transferOperationElement(Me.availableOperationsListBox, Me.currentOperationsListBox)

        If Me.availableOperationsListBox.Items.Count <= 0 Then
            Me.addOperationButton.Enabled = False
        End If

        If Me.currentOperationsListBox.Items.Count > 0 Then
            Me.deleteOperationButton.Enabled = True
        End If

    End Sub

    Private Sub deleteOperationButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles deleteOperationButton.Click

        transferOperationElement(Me.currentOperationsListBox, Me.availableOperationsListBox)

        If Me.availableOperationsListBox.Items.Count > 0 Then
            Me.addOperationButton.Enabled = True
        End If

        If Me.currentOperationsListBox.Items.Count <= 0 Then
            Me.deleteOperationButton.Enabled = False
        End If

    End Sub

    Dim currentTabPageTitle As String = "Switches (1)"

    Private Sub selectConfigTabPage(ByVal pageTitle As String)

        'applyConfigChangesButton.Enabled = True
        'saveConfigChangesButton.Enabled = True

        Dim i, ilmt As Integer

        ilmt = Me.adminTabControl.TabPages.Count - 1

        For i = 0 To ilmt

            Dim tabPage As System.Windows.Forms.TabPage

            tabPage = Me.adminTabControl.TabPages.Item(i)

            If tabPage.Text = pageTitle Then

                Me.adminTabControl.SelectedIndex = i
                currentTabPageTitle = pageTitle

                Exit Sub

            End If

        Next

    End Sub

    Private Sub switches1Button_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        selectConfigTabPage("Switches (1)")
    End Sub

    Private Sub switches2Button_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        selectConfigTabPage("Switches (2)")
    End Sub

    Private Sub buttonsButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        selectConfigTabPage("Buttons")
    End Sub

    Private Sub ftpConfigButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        selectConfigTabPage("Ftp Config")
    End Sub

    Private Sub cityListButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        selectConfigTabPage("City List")
    End Sub

    Private Sub operationsListButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        selectConfigTabPage("Operations")
    End Sub

    Private Sub userInfoButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        selectConfigTabPage("User Info")
    End Sub

    Private Sub scanFunctionsButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        selectConfigTabPage("Scan Functions")
    End Sub

    Private Sub userNameTextBox_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles userNameTextBox.TextChanged
        currentConfigChanged()
    End Sub

    Private Sub userFullNameTextBox_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles userFullNameTextBox.TextChanged
        currentConfigChanged()
    End Sub

    Private Sub carrierCodeTextBox_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles carrierCodeTextBox.TextChanged
        currentConfigChanged()
    End Sub

    Private Sub currentCityListBox_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles currentCityListBox.SelectedIndexChanged

        If currentCityListBox.SelectedIndex >= 0 And currentCityListBox.SelectedIndex < currentCityListBox.Items.Count Then
            deleteCityButton.Enabled = True
        Else
            deleteCityButton.Enabled = False
        End If

    End Sub

    Private Sub availableCityListBox_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles availableCityListBox.SelectedIndexChanged

        If availableCityListBox.SelectedIndex >= 0 And availableCityListBox.SelectedIndex < availableCityListBox.Items.Count Then
            addCityButton.Enabled = True
        Else
            addCityButton.Enabled = False
        End If

    End Sub

    Private Sub currentOperationsListBox_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles currentOperationsListBox.SelectedIndexChanged

        If currentOperationsListBox.SelectedIndex >= 0 And currentOperationsListBox.SelectedIndex < currentOperationsListBox.Items.Count Then
            deleteOperationButton.Enabled = True
        Else
            deleteOperationButton.Enabled = False
        End If

    End Sub

    Private Sub availableOperationsListBox_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles availableOperationsListBox.SelectedIndexChanged

        If availableOperationsListBox.SelectedIndex >= 0 And availableOperationsListBox.SelectedIndex < availableOperationsListBox.Items.Count Then
            addOperationButton.Enabled = True
        Else
            addOperationButton.Enabled = False
        End If

    End Sub


    Private Sub scanOptionsConfigChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles messagesCheckBox.CheckStateChanged, mailOpsCheckBox.CheckStateChanged, mailSimpleOpsCheckBox.CheckStateChanged, cargoOpsCheckBox.CheckStateChanged, baggageOpsCheckBox.CheckStateChanged

        applyConfigChangesButton.Enabled = True
        saveConfigChangesButton.Enabled = True

    End Sub

    Private Sub UseProxyCheckBox_CheckStateChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles UseProxyCheckBox.CheckStateChanged
        currentConfigChanged()
    End Sub

    Private Sub ProxyTypeComboBox_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ProxyTypeComboBox.SelectedIndexChanged
        currentConfigChanged()
    End Sub

    Private Sub ProxyHostTextBox_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ProxyHostTextBox.TextChanged
        currentConfigChanged()
    End Sub

    Private Sub ProxyPortTextBox_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ProxyPortTextBox.TextChanged
        currentConfigChanged()
    End Sub

    Private Sub ProxyUsernameTextBox_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ProxyUsernameTextBox.TextChanged
        currentConfigChanged()
    End Sub

    Private Sub ProxyPasswordTextbox_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ProxyPasswordTextbox.TextChanged
        currentConfigChanged()
    End Sub
End Class



