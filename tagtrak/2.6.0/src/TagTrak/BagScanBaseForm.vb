Imports System
Imports System.IO

Public Class BagScanBaseForm

    Inherits System.Windows.Forms.Form
    Friend WithEvents baggageFormLogoPictureBox As System.Windows.Forms.PictureBox
    Friend WithEvents baggageCarrierCodeLabel As System.Windows.Forms.Label
    Friend WithEvents Label23 As System.Windows.Forms.Label
    Friend WithEvents Label22 As System.Windows.Forms.Label
    Friend WithEvents Label18 As System.Windows.Forms.Label
    Friend WithEvents baggagePieceCountLabel As System.Windows.Forms.Label
    Friend WithEvents Label43 As System.Windows.Forms.Label
    Friend WithEvents Label36 As System.Windows.Forms.Label
    Friend WithEvents baggageContainerPositionTextBox As System.Windows.Forms.TextBox
    Friend WithEvents baggageHoldPositionTextBox As System.Windows.Forms.TextBox
    Friend WithEvents baggageOperationComboBox As System.Windows.Forms.ComboBox
    Friend WithEvents Label38 As System.Windows.Forms.Label
    Friend WithEvents baggageFlightNumberTextBox As System.Windows.Forms.TextBox
    Friend WithEvents baggageACBinIDTextBox As System.Windows.Forms.TextBox
    Friend WithEvents Label41 As System.Windows.Forms.Label
    Friend WithEvents Label42 As System.Windows.Forms.Label
    Friend WithEvents Label44 As System.Windows.Forms.Label

    Dim baggageScanTextBoxCollection() As System.Windows.Forms.TextBox

    Dim initBaggageScanTextBoxCollection() As System.windows.forms.TextBox = { _
        baggageFlightNumberTextBox, _
        tbxBagTagID, _
        baggageACBinIDTextBox, _
        baggageHoldPositionTextBox, _
        baggageContainerPositionTextBox}

#Region " Windows Form Designer generated code "

    Public Sub New()
        MyBase.New()

        Cursor.Current = Cursors.WaitCursor

        'This call is required by the Windows Form Designer.
        InitializeComponent()

        scanLocation.addControl(cbxBagScanLocation)
        'scanLocation.addControl(lblBagScanLocation)

        baggagePieceCountLabel.Text = 0
        'loadDestinationComboBox(cbxBagScanLocation, userSpecRecord.airportLocationList)
        baggageCarrierCodeLabel.Text = userSpecRecord.carrierCode
        'change location on baggage scan form spec

        'lblBagScanLocation.Visible = Not userSpecRecord.canChangeLocationOnScanForm
        'cbxBagScanLocation.Visible = userSpecRecord.canChangeLocationOnScanForm
        'cbxBagScanLocation.Enabled = userSpecRecord.canChangeLocationOnScanForm
        'lblBagScanLocation.DataBindings.Add(New Binding("Text", activeReaderForm.lblMailScanLocation, "Text"))
        baggageFormLogoPictureBox.Image = MailScanFormRepository.MailScanDomsForm.mailFormLogoPictureBox.Image

        baggageScanTextBoxCollection = initBaggageScanTextBoxCollection

        'Add any initialization after the InitializeComponent() call

        Me.loadLocationComboBox()

        Me.MainMenu1.MenuItems.Clear()
        Me.MainMenu1.MenuItems.Add(NavigationMainMenu.Singlet)
        Me.MainMenu1.MenuItems.Add(Me.Tools)

        Cursor.Current = Cursors.Default

    End Sub

    Protected Overloads Overrides Sub Dispose(ByVal disposing As Boolean)
        MyBase.Dispose(disposing)
    End Sub

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    Friend WithEvents cbxBagScanLocation As System.Windows.Forms.ComboBox
    'Friend WithEvents lblBagScanLocation As System.Windows.Forms.Label
    Friend WithEvents tbxBagTagID As System.Windows.Forms.TextBox
    Friend WithEvents MainMenu1 As System.Windows.Forms.MainMenu
#If deviceType <> "PC" Then
    Friend WithEvents InputPanel1 As Microsoft.WindowsCE.Forms.InputPanel
#End If
    Friend WithEvents Tools As System.Windows.Forms.MenuItem
    Friend WithEvents Upload As System.Windows.Forms.MenuItem
    Friend WithEvents Counter As System.Windows.Forms.MenuItem
    Friend WithEvents CounterReset As System.Windows.Forms.MenuItem
    Friend WithEvents CounterReload As System.Windows.Forms.MenuItem
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.baggageFormLogoPictureBox = New System.Windows.Forms.PictureBox
        Me.cbxBagScanLocation = New System.Windows.Forms.ComboBox
        Me.baggageCarrierCodeLabel = New System.Windows.Forms.Label
        Me.Label23 = New System.Windows.Forms.Label
        Me.Label22 = New System.Windows.Forms.Label
        Me.Label18 = New System.Windows.Forms.Label
        Me.baggagePieceCountLabel = New System.Windows.Forms.Label
        Me.Label43 = New System.Windows.Forms.Label
        Me.Label36 = New System.Windows.Forms.Label
        Me.baggageContainerPositionTextBox = New System.Windows.Forms.TextBox
        Me.baggageHoldPositionTextBox = New System.Windows.Forms.TextBox
        Me.baggageOperationComboBox = New System.Windows.Forms.ComboBox
        Me.Label38 = New System.Windows.Forms.Label
        Me.baggageFlightNumberTextBox = New System.Windows.Forms.TextBox
        Me.baggageACBinIDTextBox = New System.Windows.Forms.TextBox
        Me.Label41 = New System.Windows.Forms.Label
        Me.Label42 = New System.Windows.Forms.Label
        Me.tbxBagTagID = New System.Windows.Forms.TextBox
        Me.Label44 = New System.Windows.Forms.Label
        Me.MainMenu1 = New System.Windows.Forms.MainMenu
        Me.Tools = New System.Windows.Forms.MenuItem
        Me.Upload = New System.Windows.Forms.MenuItem
        Me.Counter = New System.Windows.Forms.MenuItem
        Me.CounterReset = New System.Windows.Forms.MenuItem
        Me.CounterReload = New System.Windows.Forms.MenuItem
        Me.InputPanel1 = New Microsoft.WindowsCE.Forms.InputPanel
        '
        'baggageFormLogoPictureBox
        '
        Me.baggageFormLogoPictureBox.Location = New System.Drawing.Point(4, 6)
        Me.baggageFormLogoPictureBox.Size = New System.Drawing.Size(100, 48)
        Me.baggageFormLogoPictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        '
        'cbxBagScanLocation
        '
        Me.cbxBagScanLocation.Location = New System.Drawing.Point(160, 72)
        Me.cbxBagScanLocation.Size = New System.Drawing.Size(65, 22)
        '
        'baggageCarrierCodeLabel
        '
        Me.baggageCarrierCodeLabel.Location = New System.Drawing.Point(112, 80)
        Me.baggageCarrierCodeLabel.Size = New System.Drawing.Size(30, 16)
        Me.baggageCarrierCodeLabel.Text = "B6"
        Me.baggageCarrierCodeLabel.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'Label23
        '
        Me.Label23.Location = New System.Drawing.Point(104, 56)
        Me.Label23.Size = New System.Drawing.Size(46, 16)
        Me.Label23.Text = "Carr."
        Me.Label23.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'Label22
        '
        Me.Label22.Location = New System.Drawing.Point(160, 56)
        Me.Label22.Size = New System.Drawing.Size(46, 16)
        Me.Label22.Text = "Loc"
        '
        'Label18
        '
        Me.Label18.Location = New System.Drawing.Point(120, 152)
        Me.Label18.Size = New System.Drawing.Size(72, 16)
        Me.Label18.Text = "Piece Count"
        Me.Label18.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'baggagePieceCountLabel
        '
        Me.baggagePieceCountLabel.Location = New System.Drawing.Point(120, 168)
        Me.baggagePieceCountLabel.Size = New System.Drawing.Size(64, 20)
        Me.baggagePieceCountLabel.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'Label43
        '
        Me.Label43.Location = New System.Drawing.Point(144, 104)
        Me.Label43.Size = New System.Drawing.Size(88, 16)
        Me.Label43.Text = "Hold Position"
        '
        'Label36
        '
        Me.Label36.Location = New System.Drawing.Point(8, 152)
        Me.Label36.Size = New System.Drawing.Size(112, 16)
        Me.Label36.Text = "Container Position"
        '
        'baggageContainerPositionTextBox
        '
        Me.baggageContainerPositionTextBox.Location = New System.Drawing.Point(8, 168)
        Me.baggageContainerPositionTextBox.Size = New System.Drawing.Size(88, 22)
        Me.baggageContainerPositionTextBox.Text = ""
        '
        'baggageHoldPositionTextBox
        '
        Me.baggageHoldPositionTextBox.Location = New System.Drawing.Point(144, 120)
        Me.baggageHoldPositionTextBox.Size = New System.Drawing.Size(56, 22)
        Me.baggageHoldPositionTextBox.Text = ""
        '
        'baggageOperationComboBox
        '
        Me.baggageOperationComboBox.Items.Add("")
        Me.baggageOperationComboBox.Items.Add("Check Baggage")
        Me.baggageOperationComboBox.Items.Add("Load")
        Me.baggageOperationComboBox.Items.Add("Transfer Online")
        Me.baggageOperationComboBox.Items.Add("Transfer OAL")
        Me.baggageOperationComboBox.Items.Add("Unload")
        Me.baggageOperationComboBox.Items.Add("Delivery")
        Me.baggageOperationComboBox.Location = New System.Drawing.Point(108, 24)
        Me.baggageOperationComboBox.Size = New System.Drawing.Size(124, 22)
        '
        'Label38
        '
        Me.Label38.Location = New System.Drawing.Point(8, 104)
        Me.Label38.Size = New System.Drawing.Size(37, 16)
        Me.Label38.Text = "Flight"
        Me.Label38.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'baggageFlightNumberTextBox
        '
        Me.baggageFlightNumberTextBox.Location = New System.Drawing.Point(8, 120)
        Me.baggageFlightNumberTextBox.Size = New System.Drawing.Size(48, 22)
        Me.baggageFlightNumberTextBox.Text = ""
        '
        'baggageACBinIDTextBox
        '
        Me.baggageACBinIDTextBox.Location = New System.Drawing.Point(72, 120)
        Me.baggageACBinIDTextBox.Size = New System.Drawing.Size(56, 22)
        Me.baggageACBinIDTextBox.Text = ""
        '
        'Label41
        '
        Me.Label41.Location = New System.Drawing.Point(108, 8)
        Me.Label41.Size = New System.Drawing.Size(120, 16)
        Me.Label41.Text = "Operation Code"
        Me.Label41.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'Label42
        '
        Me.Label42.Location = New System.Drawing.Point(8, 56)
        Me.Label42.Size = New System.Drawing.Size(47, 16)
        Me.Label42.Text = "Tag ID"
        '
        'tbxBagTagID
        '
        Me.tbxBagTagID.Location = New System.Drawing.Point(8, 72)
        Me.tbxBagTagID.Size = New System.Drawing.Size(79, 22)
        Me.tbxBagTagID.Text = ""
        '
        'Label44
        '
        Me.Label44.Location = New System.Drawing.Point(72, 104)
        Me.Label44.Size = New System.Drawing.Size(72, 16)
        Me.Label44.Text = "A/C Cart ID"
        '
        'MainMenu1
        '
        Me.MainMenu1.MenuItems.Add(Me.Tools)
        '
        'Tools
        '
        Me.Tools.MenuItems.Add(Me.Upload)
        Me.Tools.MenuItems.Add(Me.Counter)
        Me.Tools.Text = "Tools"
        '
        'Upload
        '
        Me.Upload.Text = "Upload"
        '
        'Counter
        '
        Me.Counter.MenuItems.Add(Me.CounterReset)
        Me.Counter.MenuItems.Add(Me.CounterReload)
        Me.Counter.Text = "Counter"
        '
        'CounterReset
        '
        Me.CounterReset.Text = "Reset"
        '
        'CounterReload
        '
        Me.CounterReload.Text = "Reload"
        '
        'BagScanBaseForm
        '
        Me.ClientSize = New System.Drawing.Size(234, 265)
        Me.ControlBox = False
        Me.Controls.Add(Me.baggageFormLogoPictureBox)
        Me.Controls.Add(Me.cbxBagScanLocation)
        Me.Controls.Add(Me.baggageCarrierCodeLabel)
        Me.Controls.Add(Me.Label23)
        Me.Controls.Add(Me.Label22)
        Me.Controls.Add(Me.Label18)
        Me.Controls.Add(Me.baggagePieceCountLabel)
        Me.Controls.Add(Me.Label43)
        Me.Controls.Add(Me.Label36)
        Me.Controls.Add(Me.baggageContainerPositionTextBox)
        Me.Controls.Add(Me.baggageHoldPositionTextBox)
        Me.Controls.Add(Me.baggageOperationComboBox)
        Me.Controls.Add(Me.Label38)
        Me.Controls.Add(Me.baggageFlightNumberTextBox)
        Me.Controls.Add(Me.baggageACBinIDTextBox)
        Me.Controls.Add(Me.Label41)
        Me.Controls.Add(Me.Label42)
        Me.Controls.Add(Me.tbxBagTagID)
        Me.Controls.Add(Me.Label44)
        Me.Menu = Me.MainMenu1
        Me.Text = "Baggage"

    End Sub

#End Region

    Private Sub formActive(ByVal sender As Object, ByVal e As EventArgs) Handles MyBase.Activated
        TagTrakGlobals.currentScanOperation = "BagScan"
        If isNonNullString(Me.baggageOperationComboBox.Text) Then
            Util.turnScannerOn(9)
        Else
            Util.turnScannerOff(8)
        End If
    End Sub

    Public Sub ProcessScanData(ByRef readerString As String, ByVal symbology As Integer)

        If Len(readerString) < 1 Or Len(readerString) > 35 Then
            MsgBox("Invalid International Mail Tag Bar Code: Must be between 1 to 35 characters long", MsgBoxStyle.Exclamation, "Invalid Scan")
            Exit Sub
        End If

        ignoreBagTagIDTExtChanged = True

        tbxBagTagID.Text = readerString

        processBagScanData(Me)

        ignoreBagTagIDTExtChanged = False

    End Sub

    Dim ignoreBagTagIDTExtChanged As Boolean = False
    Dim withinCargoAirwayBillTextChanged As Boolean = False

    Private Sub tbxCargoAirwayBill_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tbxBagTagID.TextChanged

        If ignoreBagTagIDTExtChanged Then Exit Sub

        If withinCargoAirwayBillTextChanged Then Exit Sub

        withinCargoAirwayBillTextChanged = True


        withinCargoAirwayBillTextChanged = False

    End Sub

    Private Sub baggageLocationComboBox_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)

    End Sub

    Private Sub reloadBaggagePieceCounts()

        Dim countFilePath As String = deviceNonVolatileMemoryDirectory & "\" & selectedCarrierPath & backSlash & "BaggageScanPieceCounts.txt"

        Dim totalCount As Integer = 0

        If Not File.Exists(countFilePath) Then

            Exit Sub

        End If

        Dim countFileInputStream As StreamReader

        Try
            countFileInputStream = New StreamReader(countFilePath)
        Catch ex As Exception
            MsgBox("Unable to open count file in order to reset baggage counters: " & ex.Message, MsgBoxStyle.Exclamation, "Open On Resdit File Failed.")
            Exit Sub
        End Try

        Dim countFileRecord As String

        Try
            countFileRecord = countFileInputStream.ReadLine
        Catch ex As Exception
            MsgBox("Unable to read count file in order to reset baggage counters: " & ex.Message, MsgBoxStyle.Exclamation, "Open On Resdit File Failed.")
            Exit Sub
        End Try

        If Not countFileRecord Is Nothing Then
            Me.baggagePieceCountLabel.Text = Trim(countFileRecord)
        Else
            Me.baggagePieceCountLabel.Text = "0"
        End If

    End Sub

    Private Sub baggageFormCounterIcon_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        'Me.counterContextMenu.Show(baggageFormCounterIcon, New System.Drawing.Point(0, 0))
    End Sub

    Private Sub baggageFormLogoPictureBox_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        'Me.changeOpsContextMenu.Show(baggageFormLogoPictureBox, New System.Drawing.Point(0, 0))
    End Sub

    Private Sub baggageOperationComboBox_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)

        If Me.baggageOperationComboBox.SelectedIndex > 0 Then
            Util.turnScannerOn(901)
        Else
            Util.turnScannerOff(902)
        End If

    End Sub

    Dim cbxBagScanLocationSelectedIndexChanged As Boolean = False

    Private Sub cbxBagScanLocation_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cbxBagScanLocation.SelectedIndexChanged

        If TagTrakGlobals.scanLocation.ignoreLocationChange Then Return

        If cbxBagScanLocationSelectedIndexChanged Then Exit Sub

        cbxBagScanLocationSelectedIndexChanged = True

        TagTrakGlobals.scanLocation.update(Me.cbxBagScanLocation.Text, Me.cbxBagScanLocation)

        cbxBagScanLocationSelectedIndexChanged = False

    End Sub

    Private Sub baggageScanUploadButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Upload.Click

        Me.DialogResult = TagTrakGlobals.uploadButtonClick()

        If Me.DialogResult = DialogResult.Abort Then
            Me.Close()
        End If

    End Sub

    'Private Sub baggageFormLogoPictureBox_Click1(ByVal sender As Object, ByVal e As System.EventArgs) Handles baggageFormLogoPictureBox.Click
    '    NavigationMenu.Singlet.Show(Me.baggageFormLogoPictureBox, New System.Drawing.Point(0, 0))
    'End Sub

    Private Sub baggageOperationComboBox_SelectedIndexChanged1(ByVal sender As Object, ByVal e As System.EventArgs) Handles baggageOperationComboBox.SelectedIndexChanged
        If isNonNullString(Me.baggageOperationComboBox.Text) Then
            Util.turnScannerOn(9)
        Else
            Util.turnScannerOff(8)
        End If
    End Sub

    Private Sub loadLocationComboBox()

        Me.cbxBagScanLocation.Items.Clear()

        Dim city As String

        For Each city In userSpecRecord.cityList
            Me.cbxBagScanLocation.Items.Add(city)
        Next

        ' MDD Test

        If scanLocation Is Nothing Then
            Me.cbxBagScanLocation.SelectedItem = userSpecRecord.defaultLocation
        Else
            Me.cbxBagScanLocation.SelectedItem = scanLocation.currentLocation
        End If

    End Sub

    Private Sub BagScanBaseForm_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Load
        If productionDistribution Then
            Label41.ForeColor = Color.Black
            Label41.Text = "Operation Code"
        Else
            Label41.ForeColor = Color.Red
            Label41.Text = "DO NOT DISTRIBUTE"
        End If

        Me.loadLocationComboBox()
    End Sub

    Private Sub textBox_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles tbxBagTagID.GotFocus, baggageACBinIDTextBox.GotFocus, baggageContainerPositionTextBox.GotFocus, baggageFlightNumberTextBox.GotFocus, baggageHoldPositionTextBox.GotFocus
#If deviceType <> "PC" Then
        If userSpecRecord.showKeyboardOnFocus Then Me.InputPanel1.Enabled = True
#End If
    End Sub
End Class
