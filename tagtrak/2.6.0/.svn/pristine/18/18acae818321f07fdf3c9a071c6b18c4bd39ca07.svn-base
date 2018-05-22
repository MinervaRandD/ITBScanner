Imports System
Imports System.IO


Public Class MailScanIntlSimpleForm
    Inherits System.Windows.Forms.Form
    Friend WithEvents btnCarrier As System.Windows.Forms.Button
    Public WithEvents btnInternationalCartFull As System.Windows.Forms.Button
    Friend WithEvents Label19 As System.Windows.Forms.Label
    Public WithEvents cbxInternationalMailOperations As System.Windows.Forms.ComboBox
    Friend WithEvents tbxCartID As System.Windows.Forms.TextBox
    Friend WithEvents tbxHandoverPoint As System.Windows.Forms.TextBox
    Friend WithEvents Label51 As System.Windows.Forms.Label
    Public WithEvents btnInternationalSave As System.Windows.Forms.Button
    Friend WithEvents Label54 As System.Windows.Forms.Label
    Public WithEvents tbxInternationalBarcode As System.Windows.Forms.TextBox
    Friend WithEvents Label56 As System.Windows.Forms.Label
    Friend WithEvents Label58 As System.Windows.Forms.Label
    Friend WithEvents Label59 As System.Windows.Forms.Label
    Friend WithEvents Label61 As System.Windows.Forms.Label
    Public WithEvents lblIntMailTotWgt As System.Windows.Forms.Label
    Public WithEvents lblIntMailTotCountLabel As System.Windows.Forms.Label
    Friend WithEvents pbxInternationalMailScanForm As System.Windows.Forms.PictureBox
    Public WithEvents btnInternationalCartUpload As System.Windows.Forms.Button
    Public WithEvents btnInternationalSend As System.Windows.Forms.Button
    Friend WithEvents tbxInternationalWeight As System.Windows.Forms.TextBox
    Friend WithEvents Label50 As System.Windows.Forms.Label

    Public currentScanScreenPopulatedFromPreset As Boolean

    Public ignoreIntlOperationComboBoxChange As Boolean = True

    Dim withinHandleTbxInternationalBarcode_TextChanged As Boolean = False
    Public ignoreInternationalBarcodeTextChanged As Boolean = False

    Dim withinHandleTbxInternationalWeight_TextChanged As Boolean = False
    Public weightTextBoxChangedEnabled As Boolean = True

    'Added by MX
    Public IntlPostOffice As String

    Private Shared singlet As MailScanIntlSimpleForm = Nothing

    Public Shared Function GetInstance() As MailScanIntlSimpleForm
        If singlet Is Nothing Then
            singlet = New MailScanIntlSimpleForm
        End If
        Return singlet
    End Function

#Region " Windows Form Designer generated code "

    Private Sub New()
        MyBase.New()

        Cursor.Current = Cursors.WaitCursor

        'This call is required by the Windows Form Designer.
        InitializeComponent()


        loadInternationalMailFormLogo()

        startupProcessRoutine()

        loadInternationalOperationComboBox()

        Dim adjunctCarrier As String
        Dim carrierFound As Boolean = False

        For Each adjunctCarrier In userSpecRecord.AdjunctCarrierList

            Dim adjunctCarrierMenuItem As New MenuItem

            adjunctCarrierMenuItem.Text = adjunctCarrier

            AddHandler adjunctCarrierMenuItem.Click, AddressOf adjunctCarrierMenuItem_Click

            cmuAdjunctCarrier.MenuItems.Add(adjunctCarrierMenuItem)

            If adjunctCarrier = userSpecRecord.carrierCode Then
                carrierFound = True
            End If

        Next

        If Not carrierFound Then

            Dim adjunctCarrierMenuItem As New MenuItem

            adjunctCarrierMenuItem.Text = userSpecRecord.carrierCode

            AddHandler adjunctCarrierMenuItem.Click, AddressOf adjunctCarrierMenuItem_Click

            cmuAdjunctCarrier.MenuItems.Add(adjunctCarrierMenuItem)

        End If

        ' Move the "Ignore barcode" "button" on top of (or under) the
        ' "Check barcode" button.

        cbxCheckCarditBarCode.Checked = True

        btnCarrier.Text = userSpecRecord.carrierCode
        btnInternationalSave.Enabled = False
        Save.Enabled = False

        'Me.cbxIntlMailScanLocation.SelectedItem = userSpecRecord.defaultLocation

        'Me.pbxInternationalMailScanForm.Image = TagTrakGlobals.globalInitFormLogo

        Me.MainMenu1.MenuItems.Clear()
        Me.MainMenu1.MenuItems.Add(NavigationMainMenu.Singlet)
        Me.MainMenu1.MenuItems.Add(Me.Tools)

        If TagTrakGlobals.userSpecRecord.UnloadEntireCart Then

            Me.cbxUnloadEntireCart.Visible = True
            Me.lblUnloadEntireCart.Visible = True

            Me.cbxUnloadEntireCart.Enabled = False
            Me.lblUnloadEntireCart.Enabled = False

        Else

            Me.cbxUnloadEntireCart.Visible = False
            Me.lblUnloadEntireCart.Visible = False

        End If

        Cursor.Current = Cursors.Default

    End Sub


    Private Sub formOnLoad(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        If productionDistribution Then
            Label51.ForeColor = Color.Black
            Label51.Text = "Operation Code"
        Else
            Label51.ForeColor = Color.Red
            Label51.Text = "DO NOT DISTRIBUTE"
        End If

        Dim result As String

        Dim test As Integer

        If emulatingPlatform Then
            test = 1
        Else
            test = scannerLib.SystemPowerStatus()
        End If

        'Not needed. Commented out by MDD on 12/27/06

        'If test <> 1 Then
        '    deviceInCradle = False
        '    TagTrakGlobals.backgroundFtpTimer.cradleTickCount = System.Int32.MaxValue
        'Else
        '    deviceInCradle = True
        '    TagTrakGlobals.backgroundFtpTimer.cradleTickCount = 6 * 30
        'End If

        Label19.Visible = True

        If emulatingPlatform Then Exit Sub


#If deviceType = "PC" Then
        Exit Sub
#End If

        removeExpiredBackupResditFiles()

        Util.turnScannerOff(7)

        backgroundFtpTimer.Enabled = True

        ignoreIntlOperationComboBoxChange = False

        readerFormLoaded = True

        Dim strCurrentLocation As String = TagTrakGlobals.scanLocation.currentLocation()

        Dim i, ilmt As Integer


        Me.SetCN41Box()

        If Not userSpecRecord.IntlPromptCardit Then
            Me.cbxCheckCarditBarCode.Checked = False
            Me.cbxCheckCarditBarCode.Visible = False
        End If

    End Sub

    Public Sub loadInternationalMailFormLogo()

        Dim mailFormLogoPath As String

        mailFormLogoPath = TagTrakConfigDirectory & "\" & userSpecRecord.userName & "scanFormLogo.bmp"

        If File.Exists(mailFormLogoPath) Then
            Me.pbxInternationalMailScanForm.Image = New System.Drawing.Bitmap(mailFormLogoPath)
            Exit Sub
        End If

        mailFormLogoPath = deviceNonVolatileMemoryDirectory & "\UspsMailConfig\scanFormLogo.bmp"

        If File.Exists(mailFormLogoPath) Then
            Me.pbxInternationalMailScanForm.Image = New System.Drawing.Bitmap(mailFormLogoPath)
        End If

    End Sub

    Protected Overloads Overrides Sub Dispose(ByVal disposing As Boolean)
        MyBase.Dispose(disposing)
    End Sub

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    Friend WithEvents cmuAdjunctCarrier As System.Windows.Forms.ContextMenu
    'Friend WithEvents lblIntlMailScanLocation As System.Windows.Forms.Label
    Public WithEvents cbxCheckCarditBarCode As System.Windows.Forms.CheckBox
    Friend WithEvents CN41 As System.Windows.Forms.Button
    Friend WithEvents CN41Label As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents ClearCN41 As System.Windows.Forms.ContextMenu
    Friend WithEvents MenuItem1 As System.Windows.Forms.MenuItem
#If deviceType <> "PC" Then
    Friend WithEvents InputPanel1 As Microsoft.WindowsCE.Forms.InputPanel
#End If
    Friend WithEvents MainMenu1 As System.Windows.Forms.MainMenu
    Friend WithEvents Tools As System.Windows.Forms.MenuItem
    Friend WithEvents Save As System.Windows.Forms.MenuItem
    Friend WithEvents Send As System.Windows.Forms.MenuItem
    Friend WithEvents CartFull As System.Windows.Forms.MenuItem
    Friend WithEvents CartUpload As System.Windows.Forms.MenuItem
    Friend WithEvents Counter As System.Windows.Forms.MenuItem
    Friend WithEvents ResetCounter As System.Windows.Forms.MenuItem
    Friend WithEvents ReloadCounter As System.Windows.Forms.MenuItem
    Friend WithEvents Timer1 As System.Windows.Forms.Timer
    Friend WithEvents Timer2 As System.Windows.Forms.Timer
    Friend WithEvents LogTimer1 As System.Windows.Forms.Timer
    Friend WithEvents LogTimer2 As System.Windows.Forms.Timer
    Friend WithEvents lblUnloadEntireCart As System.Windows.Forms.Label
    Public WithEvents cbxUnloadEntireCart As System.Windows.Forms.CheckBox
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Dim resources As System.Resources.ResourceManager = New System.Resources.ResourceManager(GetType(MailScanIntlSimpleForm))
        Me.btnCarrier = New System.Windows.Forms.Button
        Me.btnInternationalCartFull = New System.Windows.Forms.Button
        Me.Label19 = New System.Windows.Forms.Label
        Me.cbxInternationalMailOperations = New System.Windows.Forms.ComboBox
        Me.tbxCartID = New System.Windows.Forms.TextBox
        Me.tbxHandoverPoint = New System.Windows.Forms.TextBox
        Me.Label51 = New System.Windows.Forms.Label
        Me.btnInternationalSave = New System.Windows.Forms.Button
        Me.Label54 = New System.Windows.Forms.Label
        Me.tbxInternationalBarcode = New System.Windows.Forms.TextBox
        Me.Label56 = New System.Windows.Forms.Label
        Me.Label58 = New System.Windows.Forms.Label
        Me.Label59 = New System.Windows.Forms.Label
        Me.Label61 = New System.Windows.Forms.Label
        Me.lblIntMailTotWgt = New System.Windows.Forms.Label
        Me.lblIntMailTotCountLabel = New System.Windows.Forms.Label
        Me.pbxInternationalMailScanForm = New System.Windows.Forms.PictureBox
        Me.btnInternationalCartUpload = New System.Windows.Forms.Button
        Me.btnInternationalSend = New System.Windows.Forms.Button
        Me.tbxInternationalWeight = New System.Windows.Forms.TextBox
        Me.Label50 = New System.Windows.Forms.Label
        Me.cmuAdjunctCarrier = New System.Windows.Forms.ContextMenu
        Me.cbxCheckCarditBarCode = New System.Windows.Forms.CheckBox
        Me.CN41 = New System.Windows.Forms.Button
        Me.CN41Label = New System.Windows.Forms.Label
        Me.Label1 = New System.Windows.Forms.Label
        Me.ClearCN41 = New System.Windows.Forms.ContextMenu
        Me.MenuItem1 = New System.Windows.Forms.MenuItem
        Me.InputPanel1 = New Microsoft.WindowsCE.Forms.InputPanel
        Me.MainMenu1 = New System.Windows.Forms.MainMenu
        Me.Tools = New System.Windows.Forms.MenuItem
        Me.Save = New System.Windows.Forms.MenuItem
        Me.Send = New System.Windows.Forms.MenuItem
        Me.CartFull = New System.Windows.Forms.MenuItem
        Me.CartUpload = New System.Windows.Forms.MenuItem
        Me.Counter = New System.Windows.Forms.MenuItem
        Me.ResetCounter = New System.Windows.Forms.MenuItem
        Me.ReloadCounter = New System.Windows.Forms.MenuItem
        Me.Timer1 = New System.Windows.Forms.Timer
        Me.Timer2 = New System.Windows.Forms.Timer
        Me.LogTimer1 = New System.Windows.Forms.Timer
        Me.LogTimer2 = New System.Windows.Forms.Timer
        Me.lblUnloadEntireCart = New System.Windows.Forms.Label
        Me.cbxUnloadEntireCart = New System.Windows.Forms.CheckBox
        '
        'btnCarrier
        '
        Me.btnCarrier.Location = New System.Drawing.Point(8, 120)
        Me.btnCarrier.Size = New System.Drawing.Size(34, 22)
        Me.btnCarrier.Text = "AA"
        '
        'btnInternationalCartFull
        '
        Me.btnInternationalCartFull.Location = New System.Drawing.Point(12, 216)
        Me.btnInternationalCartFull.Size = New System.Drawing.Size(96, 21)
        Me.btnInternationalCartFull.Text = "Cart Full"
        '
        'Label19
        '
        Me.Label19.Font = New System.Drawing.Font("Tahoma", 10.0!, System.Drawing.FontStyle.Bold)
        Me.Label19.Location = New System.Drawing.Point(100, 2)
        Me.Label19.Size = New System.Drawing.Size(142, 16)
        Me.Label19.Text = "International Mail"
        Me.Label19.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'cbxInternationalMailOperations
        '
        Me.cbxInternationalMailOperations.Items.Add("")
        Me.cbxInternationalMailOperations.Items.Add("Possession")
        Me.cbxInternationalMailOperations.Items.Add("Load")
        Me.cbxInternationalMailOperations.Items.Add("Possession & Load")
        Me.cbxInternationalMailOperations.Items.Add("Reroute")
        Me.cbxInternationalMailOperations.Items.Add("Transfer")
        Me.cbxInternationalMailOperations.Items.Add("Unload")
        Me.cbxInternationalMailOperations.Items.Add("Partial Offload")
        Me.cbxInternationalMailOperations.Items.Add("Complete Offload")
        Me.cbxInternationalMailOperations.Items.Add("Delivery")
        Me.cbxInternationalMailOperations.Location = New System.Drawing.Point(100, 40)
        Me.cbxInternationalMailOperations.Size = New System.Drawing.Size(128, 22)
        '
        'tbxCartID
        '
        Me.tbxCartID.Location = New System.Drawing.Point(136, 120)
        Me.tbxCartID.Size = New System.Drawing.Size(88, 22)
        Me.tbxCartID.Text = ""
        '
        'tbxHandoverPoint
        '
        Me.tbxHandoverPoint.Location = New System.Drawing.Point(56, 120)
        Me.tbxHandoverPoint.Size = New System.Drawing.Size(64, 22)
        Me.tbxHandoverPoint.Text = ""
        '
        'Label51
        '
        Me.Label51.Location = New System.Drawing.Point(104, 24)
        Me.Label51.Size = New System.Drawing.Size(120, 16)
        Me.Label51.Text = "Operation Code"
        Me.Label51.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'btnInternationalSave
        '
        Me.btnInternationalSave.Location = New System.Drawing.Point(12, 194)
        Me.btnInternationalSave.Size = New System.Drawing.Size(96, 21)
        Me.btnInternationalSave.Text = "Save"
        '
        'Label54
        '
        Me.Label54.Location = New System.Drawing.Point(4, 64)
        Me.Label54.Size = New System.Drawing.Size(51, 16)
        Me.Label54.Text = "Barcode"
        '
        'tbxInternationalBarcode
        '
        Me.tbxInternationalBarcode.Font = New System.Drawing.Font("Arial Narrow", 9.0!, System.Drawing.FontStyle.Regular)
        Me.tbxInternationalBarcode.Location = New System.Drawing.Point(4, 80)
        Me.tbxInternationalBarcode.ScrollBars = System.Windows.Forms.ScrollBars.Horizontal
        Me.tbxInternationalBarcode.Size = New System.Drawing.Size(168, 21)
        Me.tbxInternationalBarcode.Text = ""
        '
        'Label56
        '
        Me.Label56.Location = New System.Drawing.Point(56, 104)
        Me.Label56.Size = New System.Drawing.Size(80, 16)
        Me.Label56.Text = "Handover Pt."
        '
        'Label58
        '
        Me.Label58.Location = New System.Drawing.Point(128, 104)
        Me.Label58.Size = New System.Drawing.Size(56, 16)
        Me.Label58.Text = "Cart ID"
        Me.Label58.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'Label59
        '
        Me.Label59.Location = New System.Drawing.Point(0, 104)
        Me.Label59.Size = New System.Drawing.Size(48, 16)
        Me.Label59.Text = "Carrier"
        Me.Label59.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'Label61
        '
        Me.Label61.Location = New System.Drawing.Point(8, 152)
        Me.Label61.Size = New System.Drawing.Size(72, 16)
        Me.Label61.Text = "Cnt. / Wgt."
        '
        'lblIntMailTotWgt
        '
        Me.lblIntMailTotWgt.Location = New System.Drawing.Point(44, 168)
        Me.lblIntMailTotWgt.Size = New System.Drawing.Size(36, 20)
        Me.lblIntMailTotWgt.Text = "0"
        '
        'lblIntMailTotCountLabel
        '
        Me.lblIntMailTotCountLabel.Location = New System.Drawing.Point(8, 168)
        Me.lblIntMailTotCountLabel.Size = New System.Drawing.Size(24, 20)
        Me.lblIntMailTotCountLabel.Text = "0"
        Me.lblIntMailTotCountLabel.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'pbxInternationalMailScanForm
        '
        Me.pbxInternationalMailScanForm.Image = CType(resources.GetObject("pbxInternationalMailScanForm.Image"), System.Drawing.Image)
        Me.pbxInternationalMailScanForm.Location = New System.Drawing.Point(0, 4)
        Me.pbxInternationalMailScanForm.Size = New System.Drawing.Size(100, 48)
        Me.pbxInternationalMailScanForm.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        '
        'btnInternationalCartUpload
        '
        Me.btnInternationalCartUpload.Location = New System.Drawing.Point(116, 216)
        Me.btnInternationalCartUpload.Size = New System.Drawing.Size(96, 21)
        Me.btnInternationalCartUpload.Text = "Cart Upload"
        '
        'btnInternationalSend
        '
        Me.btnInternationalSend.Location = New System.Drawing.Point(116, 194)
        Me.btnInternationalSend.Size = New System.Drawing.Size(96, 21)
        Me.btnInternationalSend.Text = "Send"
        '
        'tbxInternationalWeight
        '
        Me.tbxInternationalWeight.Location = New System.Drawing.Point(180, 80)
        Me.tbxInternationalWeight.Size = New System.Drawing.Size(44, 22)
        Me.tbxInternationalWeight.Text = ""
        '
        'Label50
        '
        Me.Label50.Location = New System.Drawing.Point(180, 64)
        Me.Label50.Size = New System.Drawing.Size(48, 12)
        Me.Label50.Text = "Weight"
        Me.Label50.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'cbxCheckCarditBarCode
        '
        Me.cbxCheckCarditBarCode.Checked = True
        Me.cbxCheckCarditBarCode.CheckState = System.Windows.Forms.CheckState.Checked
        Me.cbxCheckCarditBarCode.Location = New System.Drawing.Point(168, 160)
        Me.cbxCheckCarditBarCode.Size = New System.Drawing.Size(64, 24)
        Me.cbxCheckCarditBarCode.Text = "Prompt"
        '
        'CN41
        '
        Me.CN41.Font = New System.Drawing.Font("Arial Narrow", 9.0!, System.Drawing.FontStyle.Regular)
        Me.CN41.Location = New System.Drawing.Point(84, 168)
        Me.CN41.Size = New System.Drawing.Size(72, 21)
        '
        'CN41Label
        '
        Me.CN41Label.Location = New System.Drawing.Point(84, 152)
        Me.CN41Label.Size = New System.Drawing.Size(40, 16)
        Me.CN41Label.Text = "CN41"
        '
        'Label1
        '
        Me.Label1.Location = New System.Drawing.Point(36, 168)
        Me.Label1.Size = New System.Drawing.Size(8, 20)
        Me.Label1.Text = "/"
        '
        'ClearCN41
        '
        Me.ClearCN41.MenuItems.Add(Me.MenuItem1)
        '
        'MenuItem1
        '
        Me.MenuItem1.Text = "Clear"
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
        Me.Tools.MenuItems.Add(Me.CartUpload)
        Me.Tools.MenuItems.Add(Me.Counter)
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
        'CartUpload
        '
        Me.CartUpload.Text = "Cart Upload"
        '
        'Counter
        '
        Me.Counter.MenuItems.Add(Me.ResetCounter)
        Me.Counter.MenuItems.Add(Me.ReloadCounter)
        Me.Counter.Text = "Counter"
        '
        'ResetCounter
        '
        Me.ResetCounter.Text = "Reset"
        '
        'ReloadCounter
        '
        Me.ReloadCounter.Text = "Reload"
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
        'lblUnloadEntireCart
        '
        Me.lblUnloadEntireCart.Location = New System.Drawing.Point(92, 246)
        Me.lblUnloadEntireCart.Size = New System.Drawing.Size(100, 16)
        Me.lblUnloadEntireCart.Text = "Full Cart Unload"
        Me.lblUnloadEntireCart.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'cbxUnloadEntireCart
        '
        Me.cbxUnloadEntireCart.Checked = True
        Me.cbxUnloadEntireCart.CheckState = System.Windows.Forms.CheckState.Checked
        Me.cbxUnloadEntireCart.Location = New System.Drawing.Point(72, 240)
        Me.cbxUnloadEntireCart.Size = New System.Drawing.Size(16, 28)
        '
        'MailScanIntlSimpleForm
        '
        Me.ClientSize = New System.Drawing.Size(234, 320)
        Me.ControlBox = False
        Me.Controls.Add(Me.lblUnloadEntireCart)
        Me.Controls.Add(Me.cbxUnloadEntireCart)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.CN41Label)
        Me.Controls.Add(Me.CN41)
        Me.Controls.Add(Me.cbxCheckCarditBarCode)
        Me.Controls.Add(Me.btnCarrier)
        Me.Controls.Add(Me.btnInternationalCartFull)
        Me.Controls.Add(Me.Label19)
        Me.Controls.Add(Me.cbxInternationalMailOperations)
        Me.Controls.Add(Me.tbxCartID)
        Me.Controls.Add(Me.tbxHandoverPoint)
        Me.Controls.Add(Me.Label51)
        Me.Controls.Add(Me.btnInternationalSave)
        Me.Controls.Add(Me.Label54)
        Me.Controls.Add(Me.tbxInternationalBarcode)
        Me.Controls.Add(Me.Label56)
        Me.Controls.Add(Me.Label58)
        Me.Controls.Add(Me.Label59)
        Me.Controls.Add(Me.Label61)
        Me.Controls.Add(Me.lblIntMailTotWgt)
        Me.Controls.Add(Me.lblIntMailTotCountLabel)
        Me.Controls.Add(Me.pbxInternationalMailScanForm)
        Me.Controls.Add(Me.btnInternationalCartUpload)
        Me.Controls.Add(Me.btnInternationalSend)
        Me.Controls.Add(Me.tbxInternationalWeight)
        Me.Controls.Add(Me.Label50)
        Me.Menu = Me.MainMenu1
        Me.Text = "Intl Mail (Simple)"

    End Sub

#End Region

    Private Sub formActive(ByVal sender As Object, ByVal e As EventArgs) Handles MyBase.Activated

        TagTrakGlobals.currentScanOperation = "MailScanIntlSimple"

        If isNonNullString(Me.cbxInternationalMailOperations.Text) Then
            Util.turnScannerOn(9)
            If userSpecRecord.screenTimeOutValue > 0 Then
                Timer1.Enabled = True
            End If
        Else
            Util.turnScannerOff(8)
        End If

        If userSpecRecord.loginEnabled = True Then
            If userSpecRecord.logoutTimeOutValue > 0 Then
                LogTimer1.Enabled = True
                LogTimer2.Interval = userSpecRecord.logoutTimeOutValue * 60000
            End If
        End If

    End Sub

    Private Sub btnCarrier_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCarrier.Click
        Me.cmuAdjunctCarrier.Show(Me, btnCarrier.Location)
    End Sub

    Private Sub adjunctCarrierMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)

        Dim adjunctCarrierMenuItem As MenuItem = sender
        Me.btnCarrier.Text = adjunctCarrierMenuItem.Text.Trim

    End Sub

    Private Sub btnInternationalSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnInternationalSave.Click, Save.Click

        Dim result As String

        processIntlMailScanTransaction(Me)

#If deviceType <> "PC" Then
        tbxInternationalBarcode.Text = ""
        tbxInternationalWeight.Text = ""
#End If

    End Sub

    Private Sub clearAllIntlTextBoxes()
        tbxInternationalBarcode.Text = ""
        tbxInternationalWeight.Text = ""
        tbxHandoverPoint.Text = ""
        tbxCartID.Text = ""

        Me.lblIntMailTotCountLabel.Text = "0"
        Me.lblIntMailTotWgt.Text = "0"
    End Sub

    Dim previousOperation As String = ""

    'Private Sub pbxInternationalMailScanForm_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles pbxInternationalMailScanForm.Click
    '    NavigationMenu.Singlet.Show(Me.pbxInternationalMailScanForm, New System.Drawing.Point(0, 0))
    'End Sub

    Private Sub tbxInternationalBarcode_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tbxInternationalBarcode.TextChanged

        If ignoreInternationalBarcodeTextChanged Then Exit Sub

        If withinHandleTbxInternationalBarcode_TextChanged Then Exit Sub

        withinHandleTbxInternationalBarcode_TextChanged = True

        handleTbxInternationalBarcode_TextChanged()

        withinHandleTbxInternationalBarcode_TextChanged = False

        flag = True
        logoutFlag = False

    End Sub

    Private Sub ttbxInternationalWeight_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tbxInternationalWeight.TextChanged

        If Not weightTextBoxChangedEnabled Then Exit Sub

        If withinHandleTbxInternationalWeight_TextChanged Then Exit Sub

        withinHandleTbxInternationalWeight_TextChanged = True

        handleTbxInternationalWeight_TextChanged()

        withinHandleTbxInternationalWeight_TextChanged = False

        flag = True
        logoutFlag = False

    End Sub

    Private Sub btnInternationalSend_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnInternationalSend.Click, Send.Click

        TagTrakGlobals.uploadButtonClick()

        If userSpecRecord.screenBlankAfterSend = True Then

            Me.ResetScreen()

        End If
    End Sub

    Private Sub btnInternationalCartFull_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnInternationalCartFull.Click, CartFull.Click

        MailScanFormRepository.MailScanCreateNewPresetForm.init(Me)
        MailScanFormRepository.MailScanCreateNewPresetForm.Show()

        loadPresetListFromFile(userSpecRecord, userSpecRecord.presetList, "I"c)

    End Sub


    Private Sub btnInternationalCartUpload_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnInternationalCartUpload.Click, CartUpload.Click

        If currentScanScreenPopulatedFromPreset Then

            Dim result As MsgBoxResult

            result = MsgBox("Create a cart upload record for this preset?", MsgBoxStyle.YesNo, "Create Cart Upload Record?")

            If result = MsgBoxResult.Yes Then

                If Not Util.isValidBatchID(Trim(Me.tbxCartID.Text)) Then

                    MsgBox("Invalid Cart ID", MsgBoxStyle.Exclamation, "Invalid Cart ID")

                    Exit Sub

                End If

                Dim batchID As String = Trim(Me.tbxCartID.Text)

                Dim binUploadRecord As New binUploadRecordClass(batchID, "", "", "I")

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

    Public Sub ProcessScanData(ByRef readerString As String, ByVal symbology As Integer)

        Dim flag As Boolean = False

        IntlPostOffice = ""

        '' If regex is specified in config to verify bar code of a cart, if match, treat as a cart scan
        If isNonNullString(userSpecRecord.IntlCartIdPattern) Then
            If System.Text.RegularExpressions.Regex.IsMatch(readerString, userSpecRecord.IntlCartIdPattern) Then
                Me.tbxCartID.Text = readerString
                Exit Sub
            End If
        End If

        '' Sanity check on bar code
        If Len(readerString) < 1 Or Len(readerString) > 35 Then
            MsgBox("Invalid International Mail Tag Bar Code: Must be either at least 1 character and no more than 35 characters long", MsgBoxStyle.Exclamation, "Invalid Scan")
            Exit Sub
        End If

        '' First 2 characters specify the Intl. post office. (e.g. "US")
        IntlPostOffice = Substring(readerString, 0, 2)

        If userSpecRecord.nonUSMailWarning Then
            If Not IntlPostOffice = "US" Then
                Dim frmNonUSMailWarning As New NonUSMailWarning
                If frmNonUSMailWarning.ShowDialog = DialogResult.No Then
                    MsgBox("Scan operation will be ignored.")

                    Exit Sub

                End If

            End If

        End If

        btnInternationalSave.Enabled = False
        ignoreInternationalBarcodeTextChanged = True
        weightTextBoxChangedEnabled = False

        '' Get weight for US mail,
        '' If bar code is 29 characters then weight is char 25 to 28 (start = 0)
        '' Weigth is specified in .1 Kg increments (e.g. 0002 = 0.2 Kg)
        If IntlPostOffice = "US" Then
            If Len(readerString) = 29 Then
                'Me.tbxInternationalWeight.Text = Substring(readerString, 25, 3) & "." & Substring(readerString, 28, 1)
                Me.tbxInternationalBarcode.Text = Substring(readerString, 0, 25)
                Me.tbxInternationalWeight.Text = (Double.Parse(Substring(readerString, 25, 4)) / 10).ToString

            Else
                '' US bar codes MUST be 29 characters long
                MsgBox("Invalid barcode. The operation is ignored")
                Exit Sub
            End If

        Else
            '' Intl. bar code
            If Len(readerString) = 29 Then
                If (Substring(readerString, 12, 1) = "A" Or Substring(readerString, 12, 1) = "B" _
                Or Substring(readerString, 12, 1) = "C" Or Substring(readerString, 12, 1) = "E" _
                Or Substring(readerString, 12, 1) = "L") And IsNumeric(Substring(readerString, 15, 1)) Then
                    '' Mail category code is "A", "B", "C", "E", or "L" and Last digit of year is numeric.
                    '' Fill in the weight

                    'Me.tbxInternationalWeight.Text = Substring(readerString, 25, 3) & "." & Substring(readerString, 28, 1)
                    Me.tbxInternationalBarcode.Text = Substring(readerString, 0, 25)
                    Me.tbxInternationalWeight.Text = (Double.Parse(Substring(readerString, 25, 4)) / 10).ToString

                Else
                    '' Unknown weight
                    Me.tbxInternationalBarcode.Text = readerString
                    flag = True

                End If

            Else
                '' Unknown weight
                Me.tbxInternationalBarcode.Text = readerString
                flag = True

            End If

        End If

        '' Process international transaction
        processIntlMailScanTransaction(Me)

        ignoreInternationalBarcodeTextChanged = False
        Me.weightTextBoxChangedEnabled = True

        btnInternationalSave.Enabled = False
        Me.Save.Enabled = False

        'Added by MX
        If flag Then
            flag = False
            Me.tbxInternationalWeight.Text = ""
            Me.tbxInternationalBarcode.Text = ""
        End If

    End Sub

    ' Copied from StartUpProcess.vb
    Private Sub startupProcessRoutine()

    End Sub

    Private Sub SetCN41Box()
        'If IntlPostOffice = "US" Then
        '    Me.CN41.Enabled = True
        '    Me.CN41.BackColor = System.Drawing.Color.White
        'Else
        '    Me.CN41.Enabled = False
        '    Me.CN41.BackColor = System.Drawing.Color.LightGray
        'End If

        Me.CN41.Enabled = True
        Me.CN41.BackColor = System.Drawing.Color.White
    End Sub

    'Private Sub IntlPostOffices_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)
    '    Me.SetCN41Box()
    'End Sub

    Private Sub handleIntlOperationComboBoxSelectedIndexChanged()

        Dim currentOperation As String

        If isNonNullString(cbxInternationalMailOperations.Text) Then
            currentOperation = cbxInternationalMailOperations.Text
        Else
            currentOperation = ""
        End If

        If currentOperation = previousOperation Then
            Exit Sub
        End If

        If Not ignoreIntlOperationComboBoxChange Then

            Dim result As MsgBoxResult = MsgBox("You Are Changing The Type Of Scan Operation. Please Confirm!", MsgBoxStyle.YesNo, "Confirm Operation Change")

            If result = MsgBoxResult.No Then

                If isNonNullString(previousOperation) Then
                    cbxInternationalMailOperations.SelectedItem = previousOperation
                Else
                    cbxInternationalMailOperations.SelectedIndex = 0
                    previousOperation = ""
                    cbxInternationalMailOperations.Text = ""
                End If

                Exit Sub

            End If

        End If

        previousOperation = currentOperation

        If Not isNonNullString(currentOperation) Then

            Util.turnScannerOff(8)
            Exit Sub

        Else

            Util.turnScannerOn(9)

        End If

#If deviceType = "PC" Then

        If isNonNullString(tbxInternationalBarcode.Text) Then

            'If DandRTextBox.Text <> "DUMMYSCANN" Then
            '    clearAllIntlTextBoxes()
            'End If

        Else
            clearAllIntlTextBoxes()
        End If
#Else
        clearAllIntlTextBoxes()
#End If
        If userSpecRecord.IntlPromptCardit Then cbxCheckCarditBarCode.Checked = True

        Select Case userSpecRecord.operationsMapping.GetOperation(currentOperation)
            Case "Possession"
                tbxInternationalBarcode.Enabled = True
                tbxInternationalWeight.Enabled = True
                btnCarrier.Enabled = True
                tbxHandoverPoint.Enabled = False
                tbxCartID.Enabled = True
            Case "Load"
                tbxInternationalBarcode.Enabled = True
                tbxInternationalWeight.Enabled = True
                btnCarrier.Enabled = True
                tbxHandoverPoint.Enabled = False
                tbxCartID.Enabled = True
            Case "Delivery"
                tbxInternationalBarcode.Enabled = True
                tbxInternationalWeight.Enabled = True
                btnCarrier.Enabled = True
                tbxHandoverPoint.Enabled = False
                tbxCartID.Enabled = True
            Case "Partial Offload"
                tbxInternationalBarcode.Enabled = True
                tbxInternationalWeight.Enabled = True
                btnCarrier.Enabled = True
                tbxHandoverPoint.Enabled = False
                tbxCartID.Enabled = True
            Case "Complete Offload"
                tbxInternationalBarcode.Enabled = True
                tbxInternationalWeight.Enabled = True
                btnCarrier.Enabled = True
                tbxHandoverPoint.Enabled = False
                tbxCartID.Enabled = True
            Case "Offline Trns. Conveyed"
                tbxInternationalBarcode.Enabled = True
                tbxInternationalWeight.Enabled = True
                btnCarrier.Enabled = True
                tbxHandoverPoint.Enabled = True
                tbxCartID.Enabled = True
            Case "Offline Trns. Received"
                tbxInternationalBarcode.Enabled = True
                tbxInternationalWeight.Enabled = True
                btnCarrier.Enabled = True
                tbxHandoverPoint.Enabled = True
                tbxCartID.Enabled = True
            Case "Online Transfer"
                tbxInternationalBarcode.Enabled = True
                tbxInternationalWeight.Enabled = True
                btnCarrier.Enabled = True
                tbxHandoverPoint.Enabled = True
                tbxCartID.Enabled = True
            Case "Unload"
                tbxInternationalBarcode.Enabled = True
                tbxInternationalWeight.Enabled = True
                btnCarrier.Enabled = True
                tbxHandoverPoint.Enabled = False
                tbxCartID.Enabled = True
            Case "Arrived"
                tbxInternationalBarcode.Enabled = True
                tbxInternationalWeight.Enabled = True
                btnCarrier.Enabled = True
                tbxHandoverPoint.Enabled = False
                tbxCartID.Enabled = True
            Case "Return"
                tbxInternationalBarcode.Enabled = True
                tbxInternationalWeight.Enabled = True
                btnCarrier.Enabled = True
                tbxHandoverPoint.Enabled = False
                tbxCartID.Enabled = True
        End Select

        If userSpecRecord.operationsMapping.GetOperation(currentOperation) = "Unload" Then
            Me.cbxUnloadEntireCart.Enabled = True
            Me.lblUnloadEntireCart.Enabled = True
        Else
            Me.cbxUnloadEntireCart.Enabled = False
            Me.lblUnloadEntireCart.Enabled = False
        End If

    End Sub

    Private ignoreOperationComboBoxChange As Boolean = False
    Private withinoperationComboBoxSelectedIndexChanged As Boolean = False
    Private Sub cbxInternationalMailOperations_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cbxInternationalMailOperations.SelectedIndexChanged

        'Added by MX
        If cbxInternationalMailOperations.SelectedIndex > 0 Then
            If userSpecRecord.screenTimeOutValue > 0 Then
                Timer1.Enabled = True
                Timer2.Interval = userSpecRecord.screenTimeOutValue * 60000
            End If
        Else
            Timer1.Enabled = False
            Timer2.Enabled = False
        End If

        If ignoreOperationComboBoxChange Then Exit Sub
        If withinoperationComboBoxSelectedIndexChanged Then Exit Sub

        withinoperationComboBoxSelectedIndexChanged = True
        handleIntlOperationComboBoxSelectedIndexChanged()
        withinoperationComboBoxSelectedIndexChanged = False

    End Sub

    Private Sub MailScanIntlSimpleForm_Disposed(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Disposed
        singlet = Nothing
    End Sub

    Private Sub handleTbxInternationalBarcode_TextChanged()

        If ValidateInternationalFields.isValidIntlBarcode(tbxInternationalBarcode.Text, IntlPostOffice) Then
            btnInternationalSave.Enabled = True
            Save.Enabled = True
        Else
            btnInternationalSave.Enabled = False
            Save.Enabled = False
        End If

    End Sub

    Private Sub handleTbxInternationalWeight_TextChanged()

        If ValidateInternationalFields.isValidIntlBarcode(tbxInternationalBarcode.Text, IntlPostOffice) Then
            btnInternationalSave.Enabled = True
            Save.Enabled = True
        Else
            btnInternationalSave.Enabled = False
            Save.Enabled = False
        End If

    End Sub

    Private Sub MenuItem1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MenuItem1.Click
        Me.CN41.Text = ""
    End Sub

    Private Sub CN41_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CN41.Click
        Me.ClearCN41.Show(Me.CN41, New System.Drawing.Point(0, Me.CN41.Height / 2))
    End Sub

    Private Sub tbxCartID_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles tbxCartID.GotFocus, tbxHandoverPoint.GotFocus, tbxInternationalBarcode.GotFocus, tbxInternationalWeight.GotFocus
#If deviceType <> "PC" Then
        If userSpecRecord.showKeyboardOnFocus Then Me.InputPanel1.Enabled = True
#End If
    End Sub

    Private Sub resetCountersMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ResetCounter.Click
        Dim logMaintenanceThread As New System.threading.Thread(AddressOf logMaintenanceThreadSub)

        logMaintenanceThread.Priority = Threading.ThreadPriority.Lowest

        logMaintenanceThread.Start()

        Dim response As MsgBoxResult

        response = MsgBox("This Will Reset The Location Counters Only", MsgBoxStyle.OKCancel, "Confirm Counter Reset")

        If response = MsgBoxResult.Cancel Then Exit Sub

        lblIntMailTotCountLabel.Text = 0
        lblIntMailTotWgt.Text = 0
    End Sub

    Private Sub reloadCountersMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ReloadCounter.Click

        Dim countFilePath As String = deviceNonVolatileMemoryDirectory & "\" & selectedCarrierPath & backSlash & "IntlMailScanPieceCounts.txt"

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

            lblIntMailTotWgt.Text = tokenSet(1)
            lblIntMailTotCountLabel.Text = tokenSet(0)

        Else

            lblIntMailTotWgt.Text = "0"
            lblIntMailTotCountLabel.Text = "0"

        End If

        countFileInputStream.Close()

    End Sub

    Private Sub textBox_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles tbxCartID.GotFocus, tbxHandoverPoint.GotFocus, tbxInternationalBarcode.GotFocus, tbxInternationalWeight.GotFocus
#If deviceType <> "PC" Then
        If userSpecRecord.showKeyboardOnFocus Then Me.InputPanel1.Enabled = True
#End If
        flag = True
        logoutFlag = False
    End Sub


    'Added by MX
    Dim flag As Boolean = False
    Dim logoutFlag = False

    Public Sub resetOperationComboBoxWithoutWarning()
        ignoreOperationComboBoxChange = True

        Me.cbxInternationalMailOperations.SelectedIndex = 0
        Me.cbxInternationalMailOperations.Text = ""
        Me.previousOperation = ""

        Util.turnScannerOff(1)

        Me.tbxInternationalBarcode.Text = ""
        Me.tbxInternationalWeight.Text = ""

        ignoreOperationComboBoxChange = False

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

    Private Sub MailScanIntlForm_MouseUp(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles MyBase.MouseUp
        flag = True
        logoutFlag = False
    End Sub

    Private Sub MailScanIntlForm_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles MyBase.KeyUp
        flag = True
        logoutFlag = False
    End Sub

    Private Sub TextBox_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tbxHandoverPoint.TextChanged, tbxCartID.TextChanged
        flag = True
        logoutFlag = False
    End Sub

    Private Sub cbxCheckCarditBarCode_CheckStateChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cbxCheckCarditBarCode.CheckStateChanged
        flag = True
        logoutFlag = False
    End Sub

    Private Sub MailScanIntlSimpleForm_Deactivate(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Deactivate
        Timer2.Enabled = False
        Timer1.Enabled = False
        LogTimer1.Enabled = False
        LogTimer2.Enabled = False
    End Sub

    Private Sub ResetScreen()
        Me.resetOperationComboBoxWithoutWarning()
        Me.tbxCartID.Text = ""
        Me.tbxHandoverPoint.Text = ""
        Me.lblIntMailTotCountLabel.Text = ""
        Me.lblIntMailTotWgt.Text = ""
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

    Public Sub loadInternationalOperationComboBox()

        Me.cbxInternationalMailOperations.Items.Clear()

        Dim operation As String

        Me.cbxInternationalMailOperations.Items.Add("")

        For Each operation In userSpecRecord.intlSimpleOperationsList
            '' If there's a mapping for the current operation use it
            Me.cbxInternationalMailOperations.Items.Add(userSpecRecord.operationsMapping.GetMappedOperation(operation))
        Next

    End Sub

End Class
