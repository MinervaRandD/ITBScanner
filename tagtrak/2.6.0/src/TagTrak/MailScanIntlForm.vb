Imports System
Imports System.IO


Public Class MailScanIntlForm
    Inherits System.Windows.Forms.Form
    Friend WithEvents Label62 As System.Windows.Forms.Label
    Friend WithEvents tbxPieces As System.Windows.Forms.TextBox
    Friend WithEvents btnCarrier As System.Windows.Forms.Button
    Public WithEvents btnInternationalCartFull As System.Windows.Forms.Button
    Friend WithEvents Label19 As System.Windows.Forms.Label
    Public WithEvents cbxInternationalMailOperations As System.Windows.Forms.ComboBox
    Friend WithEvents tbxCartID As System.Windows.Forms.TextBox
    Friend WithEvents cbxDestination As System.Windows.Forms.ComboBox
    Public WithEvents tbxFlightNumber As System.Windows.Forms.TextBox
    Friend WithEvents Label49 As System.Windows.Forms.Label
    Friend WithEvents tbxHandoverPoint As System.Windows.Forms.TextBox
    Friend WithEvents Label51 As System.Windows.Forms.Label
    Public WithEvents btnInternationalSave As System.Windows.Forms.Button
    Friend WithEvents Label54 As System.Windows.Forms.Label
    Public WithEvents tbxInternationalBarcode As System.Windows.Forms.TextBox
    Friend WithEvents Label56 As System.Windows.Forms.Label
    Friend WithEvents Label57 As System.Windows.Forms.Label
    Friend WithEvents Label58 As System.Windows.Forms.Label
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


#Region " Windows Form Designer generated code "

    Public Sub New()
        MyBase.New()

        Cursor.Current = Cursors.WaitCursor

        'This call is required by the Windows Form Designer.
        InitializeComponent()

        scanLocation.addControl(cbxIntlMailScanLocation)
        'scanLocation.addControl(lblIntlMailScanLocation)

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

        Cursor.Current = Cursors.Default

        If TagTrakGlobals.userSpecRecord.UnloadEntireCart Then

            Me.cbxUnloadEntireCart.Visible = True
            Me.lblUnloadEntireCart.Visible = True

            Me.cbxUnloadEntireCart.Enabled = False
            Me.lblUnloadEntireCart.Enabled = False

            btnInternationalSave.Location = New Point(4, 212)
            btnInternationalSend.Location = New Point(76, 212)
            btnInternationalCartFull.Location = New Point(4, 236)
            btnInternationalCartUpload.Location = New Point(76, 236)


        Else

            Me.cbxUnloadEntireCart.Visible = False
            Me.lblUnloadEntireCart.Visible = False

            btnInternationalSave.Location = New Point(40, 212)
            btnInternationalSend.Location = New Point(112, 212)
            btnInternationalCartFull.Location = New Point(40, 236)
            btnInternationalCartUpload.Location = New Point(112, 236)

        End If
    End Sub

    Private Sub loadIntlLocationComboBox()

        Me.cbxIntlMailScanLocation.Items.Clear()

        Dim city As String

        For Each city In userSpecRecord.cityList
            Me.cbxIntlMailScanLocation.Items.Add(city)
        Next

        ' MDD Test

        If scanLocation Is Nothing Then
            Me.cbxIntlMailScanLocation.SelectedItem = userSpecRecord.defaultLocation
        Else
            Me.cbxIntlMailScanLocation.SelectedItem = scanLocation.currentLocation
        End If

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

        'If test <> 1 Then
        '    deviceInCradle = False
        '    TagTrakGlobals.backgroundFtpTimer.cradleTickCount = System.Int32.MaxValue
        'Else
        '    deviceInCradle = True
        '    TagTrakGlobals.backgroundFtpTimer.cradleTickCount = 6 * 30
        'End If


#If deviceType <> "PC" Then

        removeExpiredBackupResditFiles()

        Util.turnScannerOff(7)
#End If

        backgroundFtpTimer.Enabled = True

        ignoreIntlOperationComboBoxChange = False

        readerFormLoaded = True

        loadIntlLocationComboBox()

        Dim strCurrentLocation As String = TagTrakGlobals.scanLocation.currentLocation()

        Dim i, ilmt As Integer

        ilmt = cbxIntlMailScanLocation.Items.Count - 1

        cbxIntlMailScanLocation.SelectedItem = strCurrentLocation

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
    Public WithEvents cbxIntlMailScanLocation As System.Windows.Forms.ComboBox
    'Friend WithEvents lblIntlMailScanLocation As System.Windows.Forms.Label
    Public WithEvents cbxCheckCarditBarCode As System.Windows.Forms.CheckBox
    Friend WithEvents CN41 As System.Windows.Forms.Button
    Friend WithEvents CN41Label As System.Windows.Forms.Label
    Friend WithEvents CN41Clear As System.Windows.Forms.ContextMenu
    Friend WithEvents MenuItem1 As System.Windows.Forms.MenuItem
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
    Friend WithEvents Counter As System.Windows.Forms.MenuItem
    Friend WithEvents ResetCounter As System.Windows.Forms.MenuItem
    Friend WithEvents ReloadCounter As System.Windows.Forms.MenuItem
    Friend WithEvents FlightStatus As System.Windows.Forms.MenuItem
#If deviceType <> "PC" Then
    Friend WithEvents InputPanel1 As Microsoft.WindowsCE.Forms.InputPanel
#End If
    Friend WithEvents Timer1 As System.Windows.Forms.Timer
    Friend WithEvents Timer2 As System.Windows.Forms.Timer
    Friend WithEvents lblDest As System.Windows.Forms.Label
    Friend WithEvents lblCarrier As System.Windows.Forms.Label
    Friend WithEvents LogTimer2 As System.Windows.Forms.Timer
    Friend WithEvents LogTimer1 As System.Windows.Forms.Timer
    Friend WithEvents lblFlight As System.Windows.Forms.Label
    Public WithEvents cbxUnloadEntireCart As System.Windows.Forms.CheckBox
    Friend WithEvents lblUnloadEntireCart As System.Windows.Forms.Label
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Dim resources As System.Resources.ResourceManager = New System.Resources.ResourceManager(GetType(MailScanIntlForm))
        Me.Label62 = New System.Windows.Forms.Label
        Me.tbxPieces = New System.Windows.Forms.TextBox
        Me.btnCarrier = New System.Windows.Forms.Button
        Me.btnInternationalCartFull = New System.Windows.Forms.Button
        Me.Label19 = New System.Windows.Forms.Label
        Me.cbxIntlMailScanLocation = New System.Windows.Forms.ComboBox
        Me.cbxInternationalMailOperations = New System.Windows.Forms.ComboBox
        Me.tbxCartID = New System.Windows.Forms.TextBox
        Me.cbxDestination = New System.Windows.Forms.ComboBox
        Me.lblFlight = New System.Windows.Forms.Label
        Me.tbxFlightNumber = New System.Windows.Forms.TextBox
        Me.Label49 = New System.Windows.Forms.Label
        Me.tbxHandoverPoint = New System.Windows.Forms.TextBox
        Me.Label51 = New System.Windows.Forms.Label
        Me.btnInternationalSave = New System.Windows.Forms.Button
        Me.Label54 = New System.Windows.Forms.Label
        Me.tbxInternationalBarcode = New System.Windows.Forms.TextBox
        Me.Label56 = New System.Windows.Forms.Label
        Me.Label57 = New System.Windows.Forms.Label
        Me.Label58 = New System.Windows.Forms.Label
        Me.lblCarrier = New System.Windows.Forms.Label
        Me.lblDest = New System.Windows.Forms.Label
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
        Me.CN41Clear = New System.Windows.Forms.ContextMenu
        Me.MenuItem1 = New System.Windows.Forms.MenuItem
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
        Me.Counter = New System.Windows.Forms.MenuItem
        Me.ResetCounter = New System.Windows.Forms.MenuItem
        Me.ReloadCounter = New System.Windows.Forms.MenuItem
        Me.FlightStatus = New System.Windows.Forms.MenuItem
        Me.InputPanel1 = New Microsoft.WindowsCE.Forms.InputPanel
        Me.Timer1 = New System.Windows.Forms.Timer
        Me.Timer2 = New System.Windows.Forms.Timer
        Me.LogTimer2 = New System.Windows.Forms.Timer
        Me.LogTimer1 = New System.Windows.Forms.Timer
        Me.cbxUnloadEntireCart = New System.Windows.Forms.CheckBox
        Me.lblUnloadEntireCart = New System.Windows.Forms.Label
        '
        'Label62
        '
        Me.Label62.Location = New System.Drawing.Point(68, 104)
        Me.Label62.Size = New System.Drawing.Size(44, 16)
        Me.Label62.Text = "Pieces"
        Me.Label62.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'tbxPieces
        '
        Me.tbxPieces.Location = New System.Drawing.Point(72, 120)
        Me.tbxPieces.Size = New System.Drawing.Size(44, 22)
        Me.tbxPieces.Text = ""
        '
        'btnCarrier
        '
        Me.btnCarrier.Location = New System.Drawing.Point(128, 120)
        Me.btnCarrier.Size = New System.Drawing.Size(34, 22)
        Me.btnCarrier.Text = "AA"
        '
        'btnInternationalCartFull
        '
        Me.btnInternationalCartFull.Location = New System.Drawing.Point(4, 236)
        Me.btnInternationalCartFull.Size = New System.Drawing.Size(68, 20)
        Me.btnInternationalCartFull.Text = "Cart Full"
        '
        'Label19
        '
        Me.Label19.Font = New System.Drawing.Font("Tahoma", 10.0!, System.Drawing.FontStyle.Bold)
        Me.Label19.Location = New System.Drawing.Point(100, 4)
        Me.Label19.Size = New System.Drawing.Size(142, 22)
        Me.Label19.Text = "International Mail"
        Me.Label19.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'cbxIntlMailScanLocation
        '
        Me.cbxIntlMailScanLocation.Items.Add("ATL")
        Me.cbxIntlMailScanLocation.Items.Add("BOS")
        Me.cbxIntlMailScanLocation.Items.Add("BTV")
        Me.cbxIntlMailScanLocation.Items.Add("BUF")
        Me.cbxIntlMailScanLocation.Items.Add("DEN")
        Me.cbxIntlMailScanLocation.Items.Add("FLL")
        Me.cbxIntlMailScanLocation.Items.Add("IAD")
        Me.cbxIntlMailScanLocation.Items.Add("JFK")
        Me.cbxIntlMailScanLocation.Items.Add("LAS")
        Me.cbxIntlMailScanLocation.Items.Add("LGB")
        Me.cbxIntlMailScanLocation.Items.Add("MCO")
        Me.cbxIntlMailScanLocation.Items.Add("MSY")
        Me.cbxIntlMailScanLocation.Items.Add("OAK")
        Me.cbxIntlMailScanLocation.Items.Add("ONT")
        Me.cbxIntlMailScanLocation.Items.Add("PBI")
        Me.cbxIntlMailScanLocation.Items.Add("ROC")
        Me.cbxIntlMailScanLocation.Items.Add("RSW")
        Me.cbxIntlMailScanLocation.Items.Add("SAN")
        Me.cbxIntlMailScanLocation.Items.Add("SEA")
        Me.cbxIntlMailScanLocation.Items.Add("SJU")
        Me.cbxIntlMailScanLocation.Items.Add("SLC")
        Me.cbxIntlMailScanLocation.Items.Add("SYR")
        Me.cbxIntlMailScanLocation.Items.Add("TPA")
        Me.cbxIntlMailScanLocation.Location = New System.Drawing.Point(4, 120)
        Me.cbxIntlMailScanLocation.Size = New System.Drawing.Size(60, 22)
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
        Me.cbxInternationalMailOperations.Location = New System.Drawing.Point(100, 44)
        Me.cbxInternationalMailOperations.Size = New System.Drawing.Size(132, 22)
        '
        'tbxCartID
        '
        Me.tbxCartID.Font = New System.Drawing.Font("Arial Narrow", 9.0!, System.Drawing.FontStyle.Regular)
        Me.tbxCartID.Location = New System.Drawing.Point(176, 164)
        Me.tbxCartID.Size = New System.Drawing.Size(52, 21)
        Me.tbxCartID.Text = ""
        '
        'cbxDestination
        '
        Me.cbxDestination.Items.Add("ATL")
        Me.cbxDestination.Items.Add("BOS")
        Me.cbxDestination.Items.Add("BTV")
        Me.cbxDestination.Items.Add("BUF")
        Me.cbxDestination.Items.Add("DEN")
        Me.cbxDestination.Items.Add("FLL")
        Me.cbxDestination.Items.Add("IAD")
        Me.cbxDestination.Items.Add("JFK")
        Me.cbxDestination.Items.Add("LAS")
        Me.cbxDestination.Items.Add("LGB")
        Me.cbxDestination.Items.Add("MCO")
        Me.cbxDestination.Items.Add("MSY")
        Me.cbxDestination.Items.Add("OAK")
        Me.cbxDestination.Items.Add("ONT")
        Me.cbxDestination.Items.Add("PBI")
        Me.cbxDestination.Items.Add("ROC")
        Me.cbxDestination.Items.Add("RSW")
        Me.cbxDestination.Items.Add("SAN")
        Me.cbxDestination.Items.Add("SEA")
        Me.cbxDestination.Items.Add("SJU")
        Me.cbxDestination.Items.Add("SLC")
        Me.cbxDestination.Items.Add("SYR")
        Me.cbxDestination.Items.Add("TPA")
        Me.cbxDestination.Location = New System.Drawing.Point(120, 164)
        Me.cbxDestination.Size = New System.Drawing.Size(52, 22)
        '
        'lblFlight
        '
        Me.lblFlight.Location = New System.Drawing.Point(176, 104)
        Me.lblFlight.Size = New System.Drawing.Size(52, 16)
        Me.lblFlight.Text = "Flight"
        Me.lblFlight.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'tbxFlightNumber
        '
        Me.tbxFlightNumber.Location = New System.Drawing.Point(176, 120)
        Me.tbxFlightNumber.Size = New System.Drawing.Size(52, 22)
        Me.tbxFlightNumber.Text = ""
        '
        'Label49
        '
        Me.Label49.Location = New System.Drawing.Point(12, 104)
        Me.Label49.Size = New System.Drawing.Size(32, 16)
        Me.Label49.Text = "Loc"
        Me.Label49.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'tbxHandoverPoint
        '
        Me.tbxHandoverPoint.Location = New System.Drawing.Point(72, 164)
        Me.tbxHandoverPoint.Size = New System.Drawing.Size(44, 22)
        Me.tbxHandoverPoint.Text = ""
        '
        'Label51
        '
        Me.Label51.Location = New System.Drawing.Point(104, 28)
        Me.Label51.Size = New System.Drawing.Size(120, 16)
        Me.Label51.Text = "Operation Code"
        Me.Label51.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'btnInternationalSave
        '
        Me.btnInternationalSave.Location = New System.Drawing.Point(4, 212)
        Me.btnInternationalSave.Size = New System.Drawing.Size(68, 20)
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
        Me.tbxInternationalBarcode.Size = New System.Drawing.Size(164, 21)
        Me.tbxInternationalBarcode.Text = ""
        '
        'Label56
        '
        Me.Label56.Location = New System.Drawing.Point(44, 148)
        Me.Label56.Size = New System.Drawing.Size(84, 16)
        Me.Label56.Text = "Handover Pt."
        Me.Label56.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'Label57
        '
        Me.Label57.Location = New System.Drawing.Point(60, 192)
        Me.Label57.Size = New System.Drawing.Size(60, 16)
        Me.Label57.Text = "Tot. Wgt"
        Me.Label57.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'Label58
        '
        Me.Label58.Location = New System.Drawing.Point(168, 148)
        Me.Label58.Size = New System.Drawing.Size(56, 16)
        Me.Label58.Text = "Cart ID"
        Me.Label58.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'lblCarrier
        '
        Me.lblCarrier.Location = New System.Drawing.Point(116, 104)
        Me.lblCarrier.Size = New System.Drawing.Size(64, 16)
        Me.lblCarrier.Text = "Carrier"
        Me.lblCarrier.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'lblDest
        '
        Me.lblDest.Location = New System.Drawing.Point(128, 148)
        Me.lblDest.Size = New System.Drawing.Size(40, 16)
        Me.lblDest.Text = "Dest"
        Me.lblDest.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'Label61
        '
        Me.Label61.Location = New System.Drawing.Point(0, 192)
        Me.Label61.Size = New System.Drawing.Size(28, 16)
        Me.Label61.Text = "Cnt"
        Me.Label61.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'lblIntMailTotWgt
        '
        Me.lblIntMailTotWgt.Location = New System.Drawing.Point(124, 192)
        Me.lblIntMailTotWgt.Size = New System.Drawing.Size(32, 20)
        Me.lblIntMailTotWgt.Text = "0"
        '
        'lblIntMailTotCountLabel
        '
        Me.lblIntMailTotCountLabel.Location = New System.Drawing.Point(36, 192)
        Me.lblIntMailTotCountLabel.Size = New System.Drawing.Size(20, 20)
        Me.lblIntMailTotCountLabel.Text = "0"
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
        Me.btnInternationalCartUpload.Location = New System.Drawing.Point(76, 236)
        Me.btnInternationalCartUpload.Size = New System.Drawing.Size(80, 20)
        Me.btnInternationalCartUpload.Text = "Cart Upload"
        '
        'btnInternationalSend
        '
        Me.btnInternationalSend.Location = New System.Drawing.Point(76, 212)
        Me.btnInternationalSend.Size = New System.Drawing.Size(80, 20)
        Me.btnInternationalSend.Text = "Send"
        '
        'tbxInternationalWeight
        '
        Me.tbxInternationalWeight.Location = New System.Drawing.Point(176, 80)
        Me.tbxInternationalWeight.Size = New System.Drawing.Size(52, 22)
        Me.tbxInternationalWeight.Text = ""
        '
        'Label50
        '
        Me.Label50.Location = New System.Drawing.Point(176, 64)
        Me.Label50.Size = New System.Drawing.Size(48, 16)
        Me.Label50.Text = "Weight"
        Me.Label50.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'cbxCheckCarditBarCode
        '
        Me.cbxCheckCarditBarCode.Checked = True
        Me.cbxCheckCarditBarCode.CheckState = System.Windows.Forms.CheckState.Checked
        Me.cbxCheckCarditBarCode.Location = New System.Drawing.Point(164, 188)
        Me.cbxCheckCarditBarCode.Size = New System.Drawing.Size(60, 24)
        Me.cbxCheckCarditBarCode.Text = "Prompt"
        '
        'CN41
        '
        Me.CN41.Font = New System.Drawing.Font("Arial Narrow", 9.0!, System.Drawing.FontStyle.Regular)
        Me.CN41.Location = New System.Drawing.Point(4, 164)
        Me.CN41.Size = New System.Drawing.Size(60, 21)
        '
        'CN41Label
        '
        Me.CN41Label.Location = New System.Drawing.Point(4, 148)
        Me.CN41Label.Size = New System.Drawing.Size(40, 16)
        Me.CN41Label.Text = "CN41"
        '
        'CN41Clear
        '
        Me.CN41Clear.MenuItems.Add(Me.MenuItem1)
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
        Me.Tools.MenuItems.Add(Me.Summary)
        Me.Tools.MenuItems.Add(Me.Presets)
        Me.Tools.MenuItems.Add(Me.Manifest)
        Me.Tools.MenuItems.Add(Me.ChangeCart)
        Me.Tools.MenuItems.Add(Me.CartUpload)
        Me.Tools.MenuItems.Add(Me.Counter)
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
        'LogTimer2
        '
        Me.LogTimer2.Interval = 60000
        '
        'LogTimer1
        '
        Me.LogTimer1.Interval = 10000
        '
        'cbxUnloadEntireCart
        '
        Me.cbxUnloadEntireCart.Checked = True
        Me.cbxUnloadEntireCart.CheckState = System.Windows.Forms.CheckState.Checked
        Me.cbxUnloadEntireCart.Location = New System.Drawing.Point(164, 224)
        Me.cbxUnloadEntireCart.Size = New System.Drawing.Size(16, 28)
        '
        'lblUnloadEntireCart
        '
        Me.lblUnloadEntireCart.Location = New System.Drawing.Point(184, 224)
        Me.lblUnloadEntireCart.Size = New System.Drawing.Size(52, 28)
        Me.lblUnloadEntireCart.Text = "Full Cart Unload"
        Me.lblUnloadEntireCart.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'MailScanIntlForm
        '
        Me.ClientSize = New System.Drawing.Size(234, 265)
        Me.ControlBox = False
        Me.Controls.Add(Me.lblUnloadEntireCart)
        Me.Controls.Add(Me.cbxUnloadEntireCart)
        Me.Controls.Add(Me.CN41Label)
        Me.Controls.Add(Me.CN41)
        Me.Controls.Add(Me.cbxCheckCarditBarCode)
        Me.Controls.Add(Me.Label62)
        Me.Controls.Add(Me.tbxPieces)
        Me.Controls.Add(Me.btnCarrier)
        Me.Controls.Add(Me.btnInternationalCartFull)
        Me.Controls.Add(Me.Label19)
        Me.Controls.Add(Me.cbxIntlMailScanLocation)
        Me.Controls.Add(Me.cbxInternationalMailOperations)
        Me.Controls.Add(Me.tbxCartID)
        Me.Controls.Add(Me.cbxDestination)
        Me.Controls.Add(Me.lblFlight)
        Me.Controls.Add(Me.tbxFlightNumber)
        Me.Controls.Add(Me.Label49)
        Me.Controls.Add(Me.tbxHandoverPoint)
        Me.Controls.Add(Me.Label51)
        Me.Controls.Add(Me.btnInternationalSave)
        Me.Controls.Add(Me.Label54)
        Me.Controls.Add(Me.tbxInternationalBarcode)
        Me.Controls.Add(Me.Label56)
        Me.Controls.Add(Me.Label57)
        Me.Controls.Add(Me.Label58)
        Me.Controls.Add(Me.lblCarrier)
        Me.Controls.Add(Me.lblDest)
        Me.Controls.Add(Me.Label61)
        Me.Controls.Add(Me.lblIntMailTotWgt)
        Me.Controls.Add(Me.lblIntMailTotCountLabel)
        Me.Controls.Add(Me.pbxInternationalMailScanForm)
        Me.Controls.Add(Me.btnInternationalCartUpload)
        Me.Controls.Add(Me.btnInternationalSend)
        Me.Controls.Add(Me.tbxInternationalWeight)
        Me.Controls.Add(Me.Label50)
        Me.Menu = Me.MainMenu1
        Me.Text = "International Mail"

    End Sub

#End Region

    Private Sub formActive(ByVal sender As Object, ByVal e As EventArgs) Handles MyBase.Activated
        TagTrakGlobals.currentScanOperation = "MailScanIntl"

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

    Private Sub pbxFlightStatusIcon_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles FlightStatus.Click

        Dim flightStatusForm As FlightStatusMessage = FlightStatusMessage.GetInstance()

        flightStatusForm.Show()

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
        tbxPieces.Text = ""
        tbxFlightNumber.Text = ""
        tbxHandoverPoint.Text = ""
        tbxCartID.Text = ""
        Me.lblIntMailTotCountLabel.Text = "0"
        Me.lblIntMailTotWgt.Text = "0"
    End Sub

    Dim previousOperation As String = ""

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

        'If isNonNullString(tbxInternationalBarcode.Text) Then

        '    'If DandRTextBox.Text <> "DUMMYSCANN" Then
        '    '    clearAllIntlTextBoxes()
        '    'End If

        'Else
            clearAllIntlTextBoxes()
        'End If
#Else
        clearAllIntlTextBoxes()
#End If
        If userSpecRecord.IntlPromptCardit Then cbxCheckCarditBarCode.Checked = True

        lblDest.Visible = True
        lblDest.Text = "Dest"
        lblCarrier.Text = "Carrier"
        lblFlight.Text = "Flight"

        Select Case userSpecRecord.operationsMapping.GetOperation(currentOperation)
            Case "Possession"
                tbxInternationalBarcode.Enabled = True
                cbxIntlMailScanLocation.Enabled = True
                tbxInternationalWeight.Enabled = True
                tbxPieces.Enabled = True
                btnCarrier.Enabled = True
                tbxFlightNumber.Enabled = True
                tbxHandoverPoint.Enabled = False
                cbxDestination.Visible = True
                tbxCartID.Enabled = True

            Case "Load"
                tbxInternationalBarcode.Enabled = True
                cbxIntlMailScanLocation.Enabled = True
                tbxInternationalWeight.Enabled = True
                tbxPieces.Enabled = True
                btnCarrier.Enabled = True
                tbxFlightNumber.Enabled = True
                tbxHandoverPoint.Enabled = False
                cbxDestination.Visible = True
                tbxCartID.Enabled = True

            Case "Delivery"
                tbxInternationalBarcode.Enabled = True
                cbxIntlMailScanLocation.Enabled = True
                tbxInternationalWeight.Enabled = True
                tbxPieces.Enabled = True
                btnCarrier.Enabled = True
                tbxFlightNumber.Enabled = True
                tbxHandoverPoint.Enabled = False
                cbxDestination.SelectedIndex = -1
                cbxDestination.Visible = False
                tbxCartID.Enabled = True

                lblDest.Visible = False

            Case "Partial Offload"
                tbxInternationalBarcode.Enabled = True
                cbxIntlMailScanLocation.Enabled = True
                tbxInternationalWeight.Enabled = True
                tbxPieces.Enabled = True
                btnCarrier.Enabled = True
                tbxFlightNumber.Enabled = True
                tbxHandoverPoint.Enabled = False
                cbxDestination.Visible = True
                tbxCartID.Enabled = True

            Case "Complete Offload"
                tbxInternationalBarcode.Enabled = True
                cbxIntlMailScanLocation.Enabled = True
                tbxInternationalWeight.Enabled = True
                tbxPieces.Enabled = True
                btnCarrier.Enabled = True
                tbxFlightNumber.Enabled = True
                tbxHandoverPoint.Enabled = False
                cbxDestination.Visible = True
                tbxCartID.Enabled = True

            Case "Offline Trns. Conveyed"
                tbxInternationalBarcode.Enabled = True
                cbxIntlMailScanLocation.Enabled = True
                tbxInternationalWeight.Enabled = True
                tbxPieces.Enabled = True
                btnCarrier.Enabled = True
                tbxFlightNumber.Enabled = True
                tbxHandoverPoint.Enabled = True
                cbxDestination.Visible = True
                tbxCartID.Enabled = True

                lblCarrier.Text = "To Carr."
                lblFlight.Text = "To Flt"

            Case "Offline Trns. Received"
                tbxInternationalBarcode.Enabled = True
                cbxIntlMailScanLocation.Enabled = True
                tbxInternationalWeight.Enabled = True
                tbxPieces.Enabled = True
                btnCarrier.Enabled = True
                tbxFlightNumber.Enabled = True
                tbxHandoverPoint.Enabled = True
                cbxDestination.Visible = True
                tbxCartID.Enabled = True

                lblCarrier.Text = "From Carr."
                lblFlight.Text = "From Flt"
                lblDest.Text = "Origin"

            Case "Online Transfer"
                tbxInternationalBarcode.Enabled = True
                cbxIntlMailScanLocation.Enabled = True
                tbxInternationalWeight.Enabled = True
                tbxPieces.Enabled = True
                btnCarrier.Enabled = True
                tbxFlightNumber.Enabled = True
                tbxHandoverPoint.Enabled = True
                cbxDestination.Visible = True
                tbxCartID.Enabled = True
            Case "Unload"
                tbxInternationalBarcode.Enabled = True
                cbxIntlMailScanLocation.Enabled = True
                tbxInternationalWeight.Enabled = True
                tbxPieces.Enabled = True
                btnCarrier.Enabled = True
                tbxFlightNumber.Enabled = True
                tbxHandoverPoint.Enabled = False
                cbxDestination.Visible = True
                tbxCartID.Enabled = True

                lblDest.Text = "Origin"

            Case "Arrived"
                tbxInternationalBarcode.Enabled = True
                cbxIntlMailScanLocation.Enabled = True
                tbxInternationalWeight.Enabled = True
                tbxPieces.Enabled = True
                btnCarrier.Enabled = True
                tbxFlightNumber.Enabled = True
                tbxHandoverPoint.Enabled = False
                cbxDestination.SelectedIndex = -1
                cbxDestination.Visible = False
                tbxCartID.Enabled = True

                lblDest.Visible = False

            Case "Return"
                tbxInternationalBarcode.Enabled = True
                cbxIntlMailScanLocation.Enabled = True
                tbxInternationalWeight.Enabled = True
                tbxPieces.Enabled = True
                btnCarrier.Enabled = True
                tbxFlightNumber.Enabled = True
                tbxHandoverPoint.Enabled = False
                cbxDestination.Visible = True
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

    Public ignoreOperationComboBoxChange As Boolean = False
    Dim withinoperationComboBoxSelectedIndexChanged As Boolean = False

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

    Dim cbxIntlMailScanLocationSelectedIndexChanged As Boolean = False

    Private Sub cbxIntlMailScanLocation_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cbxIntlMailScanLocation.SelectedIndexChanged

        If TagTrakGlobals.scanLocation.ignoreLocationChange Then Return

        If cbxIntlMailScanLocationSelectedIndexChanged Then Exit Sub

        cbxIntlMailScanLocationSelectedIndexChanged = True

        TagTrakGlobals.scanLocation.update(Me.cbxIntlMailScanLocation.Text, Me.cbxIntlMailScanLocation)

        cbxIntlMailScanLocationSelectedIndexChanged = False

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

        'Me.DialogResult = TagTrakGlobals.uploadButtonClick()
        TagTrakGlobals.uploadButtonClick()

        'If Me.DialogResult = DialogResult.Abort Then
        '    Me.Close()
        'End If

        'Added by MX
        If userSpecRecord.screenBlankAfterSend = True Then

            Me.ResetScreen()

        End If

    End Sub

    Private Sub btnInternationalCartFull_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnInternationalCartFull.Click, CartFull.Click

        MailScanFormRepository.MailScanCreateNewPresetForm.init(Me)
        MailScanFormRepository.MailScanCreateNewPresetForm.Show()

        loadPresetListFromFile(userSpecRecord, userSpecRecord.presetList, "I"c)

    End Sub


    Private Sub btnInternationalSummary_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Summary.Click
        MailScanFormRepository.MailScanManifestSummaryForm.loadSummaryInformation()
        MailScanFormRepository.MailScanManifestSummaryForm.Show()
    End Sub

    Private Sub btnInternationalPreset_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Presets.Click

        MailScanFormRepository.MailScanPresetsForm.init(Me)
        MailScanFormRepository.MailScanPresetsForm.Show()

    End Sub

    Private Sub btnInternationalManifest_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Manifest.Click

        'Added by MX
        MailScanFormRepository.MailScanManifestForm.scanType = "I"
        MailScanFormRepository.MailScanManifestForm.Show()

    End Sub

    Private Sub btnInternationalChangeCart_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ChangeCart.Click

        MailScanFormRepository.MailScanBinChangeForm.init(Me)
        MailScanFormRepository.MailScanBinChangeForm.Show()

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

                If Not Util.isValidFlightNumber(Trim(Me.tbxFlightNumber.Text)) Then

                    MsgBox("Invalid Flight Number", MsgBoxStyle.Exclamation, "Invalid Flight Number")
                    Exit Sub

                End If

                Dim flightNumber = Trim(Me.tbxFlightNumber.Text).PadLeft(4, "0")

                If Not Util.isValidLocation(Me.cbxDestination.Text) Then

                    MsgBox("A valid destination must be specified", MsgBoxStyle.Exclamation, "Invalid Destination")
                    Exit Sub

                End If

                Dim destinationCode = Me.cbxDestination.Text

                Dim binUploadRecord As New binUploadRecordClass(batchID, flightNumber, destinationCode, "I")

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

    '' Is called by the bar code reader to process scanned data
    Public Sub ProcessScanData(ByRef readerString As String, ByVal symbology As Integer)

        '' International bar code:
        '' USJFKK AUSYDX A CB 7 0089 045 1 0 0002
        '' a      b      c d  e f    g   h i j
        ''
        '' a. Origin (std S6)
        '' b. Destination (std S6)
        '' c. Category (A=Airmail; B=SAL Mail; C=Surface)
        '' d. Mail sub-class code
        '' e. Last digit of year
        '' f. Serial of dispatch
        '' g. Receptacle serial
        '' h. Highest receptacle
        '' i. Registered/insured indicator
        '' j. Weight (in 0.1 Kg increments)

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

        btnInternationalSave.Enabled = False
        Save.Enabled = False
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

        'If Me.cbxInternationalMailOperations.Text = "Possession" Then

        '' Set pieces to 1 is not specified
        If Me.tbxPieces.Text = "" Then
            Me.tbxPieces.Text = "1"
        End If

        '' Process international transaction
        processIntlMailScanTransaction(Me)

        ignoreInternationalBarcodeTextChanged = False
        Me.weightTextBoxChangedEnabled = True

        btnInternationalSave.Enabled = False
        Save.Enabled = False

        'Added by MX
        If flag Then
            '' Reset weight and bar code after processing
            flag = False
            Me.tbxInternationalWeight.Text = ""
            Me.tbxInternationalBarcode.Text = ""
        End If

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
        reloadCounters(lblIntMailTotCountLabel, lblIntMailTotWgt, "IntlMailScanPieceCounts.txt")
    End Sub

    Private Sub startupProcessRoutine()


        Util.LoadComboBoxFromList(Me.cbxDestination, userSpecRecord.cityList)
        'loadDestinationComboBox(Me.cbxIntlMailScanLocation, userSpecRecord.airportLocationList)
        Me.cbxDestination.Items.Insert(0, "")

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

    Private Sub handleTbxInternationalBarcode_TextChanged()

        'Added by MX for manuel input
        IntlPostOffice = Substring(tbxInternationalBarcode.Text.Trim, 0, 2)

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
        Me.CN41Clear.Show(Me.CN41, New System.Drawing.Point(0, Me.CN41.Height / 2))
    End Sub

    Private Sub textBox_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles tbxCartID.GotFocus, tbxFlightNumber.GotFocus, tbxHandoverPoint.GotFocus, tbxInternationalBarcode.GotFocus, tbxInternationalWeight.GotFocus, tbxPieces.GotFocus
#If deviceType <> "PC" Then
        If userSpecRecord.showKeyboardOnFocus Then Me.InputPanel1.Enabled = True
#End If
        flag = True
        logOutFlag = False
    End Sub

    Private Sub ComboBox_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles cbxIntlMailScanLocation.GotFocus, cbxDestination.GotFocus
        flag = True
        logOutFlag = False
    End Sub

    'Added by MX

    Dim flag As Boolean = False
    Dim logOutFlag As Boolean = True

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
        logOutFlag = False
    End Sub

    Private Sub MailScanIntlForm_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles MyBase.KeyUp
        flag = True
        logOutFlag = False
    End Sub

    Private Sub TextBox_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tbxPieces.TextChanged, tbxFlightNumber.TextChanged, tbxHandoverPoint.TextChanged, tbxCartID.TextChanged
        FlightScheduleError.DontAsk = False
        flag = True
        logOutFlag = False
    End Sub

    Private Sub MailScanIntlForm_Deactivate(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Deactivate
        Timer2.Enabled = False
        Timer1.Enabled = False
        LogTimer1.Enabled = False
        LogTimer2.Enabled = False
    End Sub

    Private Sub ResetScreen()
        Me.resetOperationComboBoxWithoutWarning()
        Me.tbxFlightNumber.Text = ""
        Me.cbxDestination.SelectedIndex = -1
        Me.tbxCartID.Text = ""
        Me.tbxHandoverPoint.Text = ""
        Me.tbxPieces.Text = ""
        Me.lblIntMailTotCountLabel.Text = ""
        Me.lblIntMailTotWgt.Text = ""
    End Sub

    Private Sub LogTimer1_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles LogTimer1.Tick

        If logOutFlag = False Then
            logOutFlag = True
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

        For Each operation In userSpecRecord.internationalOperationsList
            '' If there's a mapping for the current operation use it
            Me.cbxInternationalMailOperations.Items.Add(userSpecRecord.operationsMapping.GetMappedOperation(operation))
        Next

    End Sub

End Class
