Imports System
Imports System.IO

Public Class CargoScanBaseForm
    Inherits System.Windows.Forms.Form
    Friend WithEvents Label35 As System.Windows.Forms.Label
    Friend WithEvents Label29 As System.Windows.Forms.Label
    Friend WithEvents Label26 As System.Windows.Forms.Label
    Friend WithEvents Label27 As System.Windows.Forms.Label
    Friend WithEvents Label30 As System.Windows.Forms.Label
    Friend WithEvents Label31 As System.Windows.Forms.Label
    Friend WithEvents Label32 As System.Windows.Forms.Label
    Friend WithEvents Label33 As System.Windows.Forms.Label


#Region " Windows Form Designer generated code "

    Public Sub New()
        MyBase.New()

        Cursor.Current = Cursors.WaitCursor

        'This call is required by the Windows Form Designer.
        InitializeComponent()

        TagTrakGlobals.scanLocation.addControl(Me.ScanLocation)

        loadCargoFormLogo()

        If userSpecRecord.cargoOperationsList.Count > 0 Then
            Util.LoadComboBoxFromList(Me.Operations, userSpecRecord.cargoOperationsList)
            Me.Operations.Items.Insert(0, "")
        End If

        Util.LoadComboBoxFromList(Me.Destination, userSpecRecord.cityList)
        Me.Destination.Items.Insert(0, "")

        Me.Carrier.Text = userSpecRecord.carrierCode

        Me.setControlStatus()
        'Me.pbxCargoFormLogo.Image = TagTrakGlobals.globalInitFormLogo

        Me.MainMenu1.MenuItems.Clear()
        Me.MainMenu1.MenuItems.Add(NavigationMainMenu.Singlet)
        Me.MainMenu1.MenuItems.Add(Me.Tools)

        Cursor.Current = Cursors.Default
    End Sub



    Private Sub formOnLoad(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        If productionDistribution Then
            Label26.ForeColor = Color.Black
            Label26.Text = "Operation Code"
        Else
            Label26.ForeColor = Color.Red
            Label26.Text = "DO NOT DISTRIBUTE"
        End If

        Dim result As String

        loadLocationComboBox()

        Util.turnScannerOff(7)

    End Sub

    Protected Overloads Overrides Sub Dispose(ByVal disposing As Boolean)
        MyBase.Dispose(disposing)
    End Sub

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    'Friend WithEvents lblCargoScanLocation As System.Windows.Forms.Label
    Friend WithEvents pbxCargoFormLogo As System.Windows.Forms.PictureBox
    Friend WithEvents MainMenu1 As System.Windows.Forms.MainMenu
#If deviceType <> "PC" Then
    Friend WithEvents InputPanel1 As Microsoft.WindowsCE.Forms.InputPanel
#End If
    Friend WithEvents Tools As System.Windows.Forms.MenuItem
    Friend WithEvents Save As System.Windows.Forms.MenuItem
    Friend WithEvents Counter As System.Windows.Forms.MenuItem
    Friend WithEvents CounterReset As System.Windows.Forms.MenuItem
    Friend WithEvents CounterReload As System.Windows.Forms.MenuItem
    Friend WithEvents Hazmat As System.Windows.Forms.CheckBox
    Friend WithEvents Send As System.Windows.Forms.MenuItem
    Friend WithEvents ToolBar1 As System.Windows.Forms.ToolBar
    Friend WithEvents ImageList1 As System.Windows.Forms.ImageList
    Friend WithEvents SaveButton As System.Windows.Forms.ToolBarButton
    Friend WithEvents SeparateBar As System.Windows.Forms.ToolBarButton
    Friend WithEvents TransCarrier As System.Windows.Forms.TextBox
    Friend WithEvents TransCarrierLabel As System.Windows.Forms.Label
    Friend WithEvents Pieces As System.Windows.Forms.TextBox
    Friend WithEvents Weight As System.Windows.Forms.TextBox
    Friend WithEvents PiecesLabel As System.Windows.Forms.Label
    Friend WithEvents WeightLabel As System.Windows.Forms.Label
    Friend WithEvents AcCartId As System.Windows.Forms.TextBox
    Friend WithEvents AirwayBill As System.Windows.Forms.TextBox
    Friend WithEvents Carrier As System.Windows.Forms.Label
    Friend WithEvents Operations As System.Windows.Forms.ComboBox
    Friend WithEvents Destination As System.Windows.Forms.ComboBox
    Friend WithEvents Flight As System.Windows.Forms.TextBox
    Friend WithEvents PieceCount As System.Windows.Forms.Label
    Friend WithEvents ScanLocation As System.Windows.Forms.ComboBox
    Friend WithEvents TotalWeightLabel As System.Windows.Forms.Label
    Friend WithEvents TotalWeight As System.Windows.Forms.Label
    Friend WithEvents txtShelf As System.Windows.Forms.TextBox
    Friend WithEvents lbl As System.Windows.Forms.Label
    Friend WithEvents lblBin As System.Windows.Forms.Label
    Friend WithEvents txtBin As System.Windows.Forms.TextBox
    Friend WithEvents lblOldFlight As System.Windows.Forms.Label
    Friend WithEvents OldFlight As System.Windows.Forms.TextBox
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Dim resources As System.Resources.ResourceManager = New System.Resources.ResourceManager(GetType(CargoScanBaseForm))
        Me.pbxCargoFormLogo = New System.Windows.Forms.PictureBox
        Me.ScanLocation = New System.Windows.Forms.ComboBox
        Me.Hazmat = New System.Windows.Forms.CheckBox
        Me.Label35 = New System.Windows.Forms.Label
        Me.Label29 = New System.Windows.Forms.Label
        Me.AcCartId = New System.Windows.Forms.TextBox
        Me.AirwayBill = New System.Windows.Forms.TextBox
        Me.Carrier = New System.Windows.Forms.Label
        Me.Operations = New System.Windows.Forms.ComboBox
        Me.Destination = New System.Windows.Forms.ComboBox
        Me.Flight = New System.Windows.Forms.TextBox
        Me.Label26 = New System.Windows.Forms.Label
        Me.Label27 = New System.Windows.Forms.Label
        Me.Label30 = New System.Windows.Forms.Label
        Me.Label31 = New System.Windows.Forms.Label
        Me.Label32 = New System.Windows.Forms.Label
        Me.Label33 = New System.Windows.Forms.Label
        Me.PieceCount = New System.Windows.Forms.Label
        Me.MainMenu1 = New System.Windows.Forms.MainMenu
        Me.Tools = New System.Windows.Forms.MenuItem
        Me.Save = New System.Windows.Forms.MenuItem
        Me.Send = New System.Windows.Forms.MenuItem
        Me.Counter = New System.Windows.Forms.MenuItem
        Me.CounterReset = New System.Windows.Forms.MenuItem
        Me.CounterReload = New System.Windows.Forms.MenuItem
        Me.ToolBar1 = New System.Windows.Forms.ToolBar
        Me.SeparateBar = New System.Windows.Forms.ToolBarButton
        Me.SaveButton = New System.Windows.Forms.ToolBarButton
        Me.ImageList1 = New System.Windows.Forms.ImageList
        Me.TransCarrier = New System.Windows.Forms.TextBox
        Me.TransCarrierLabel = New System.Windows.Forms.Label
        Me.PiecesLabel = New System.Windows.Forms.Label
        Me.Pieces = New System.Windows.Forms.TextBox
        Me.Weight = New System.Windows.Forms.TextBox
        Me.WeightLabel = New System.Windows.Forms.Label
        Me.InputPanel1 = New Microsoft.WindowsCE.Forms.InputPanel
        Me.TotalWeightLabel = New System.Windows.Forms.Label
        Me.TotalWeight = New System.Windows.Forms.Label
        Me.txtShelf = New System.Windows.Forms.TextBox
        Me.lbl = New System.Windows.Forms.Label
        Me.txtBin = New System.Windows.Forms.TextBox
        Me.lblBin = New System.Windows.Forms.Label
        Me.lblOldFlight = New System.Windows.Forms.Label
        Me.OldFlight = New System.Windows.Forms.TextBox
        '
        'pbxCargoFormLogo
        '
        Me.pbxCargoFormLogo.Image = CType(resources.GetObject("pbxCargoFormLogo.Image"), System.Drawing.Image)
        Me.pbxCargoFormLogo.Location = New System.Drawing.Point(5, 6)
        Me.pbxCargoFormLogo.Size = New System.Drawing.Size(100, 48)
        Me.pbxCargoFormLogo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        '
        'ScanLocation
        '
        Me.ScanLocation.Location = New System.Drawing.Point(136, 72)
        Me.ScanLocation.Size = New System.Drawing.Size(58, 22)
        '
        'Hazmat
        '
        Me.Hazmat.Location = New System.Drawing.Point(152, 224)
        Me.Hazmat.Size = New System.Drawing.Size(74, 22)
        Me.Hazmat.Text = "HAZMAT"
        '
        'Label35
        '
        Me.Label35.Location = New System.Drawing.Point(8, 96)
        Me.Label35.Size = New System.Drawing.Size(40, 16)
        Me.Label35.Text = "Flight"
        '
        'Label29
        '
        Me.Label29.Location = New System.Drawing.Point(64, 96)
        Me.Label29.Size = New System.Drawing.Size(53, 16)
        Me.Label29.Text = "Dest"
        '
        'AcCartId
        '
        Me.AcCartId.Location = New System.Drawing.Point(120, 152)
        Me.AcCartId.Size = New System.Drawing.Size(112, 22)
        Me.AcCartId.Text = ""
        '
        'AirwayBill
        '
        Me.AirwayBill.Location = New System.Drawing.Point(8, 72)
        Me.AirwayBill.Size = New System.Drawing.Size(120, 22)
        Me.AirwayBill.Text = ""
        '
        'Carrier
        '
        Me.Carrier.Location = New System.Drawing.Point(200, 72)
        Me.Carrier.Size = New System.Drawing.Size(24, 18)
        Me.Carrier.Text = "AS"
        '
        'Operations
        '
        Me.Operations.Items.Add("")
        Me.Operations.Items.Add("Acceptance")
        Me.Operations.Items.Add("Load")
        Me.Operations.Items.Add("Unload")
        Me.Operations.Items.Add("Offload")
        Me.Operations.Items.Add("Offline Transfer ")
        Me.Operations.Items.Add("Delivery")
        Me.Operations.Items.Add("Online Transfer")
        Me.Operations.Items.Add("Warehouse Move")
        Me.Operations.Location = New System.Drawing.Point(120, 24)
        Me.Operations.Size = New System.Drawing.Size(120, 22)
        '
        'Destination
        '
        Me.Destination.Items.Add("ATL")
        Me.Destination.Items.Add("BOS")
        Me.Destination.Items.Add("BTV")
        Me.Destination.Items.Add("BUF")
        Me.Destination.Items.Add("DEN")
        Me.Destination.Items.Add("FLL")
        Me.Destination.Items.Add("IAD")
        Me.Destination.Items.Add("JFK")
        Me.Destination.Items.Add("LAS")
        Me.Destination.Items.Add("LGB")
        Me.Destination.Items.Add("MCO")
        Me.Destination.Items.Add("MSY")
        Me.Destination.Items.Add("OAK")
        Me.Destination.Items.Add("ONT")
        Me.Destination.Items.Add("PBI")
        Me.Destination.Items.Add("ROC")
        Me.Destination.Items.Add("RSW")
        Me.Destination.Items.Add("SAN")
        Me.Destination.Items.Add("SEA")
        Me.Destination.Items.Add("SJU")
        Me.Destination.Items.Add("SLC")
        Me.Destination.Items.Add("SYR")
        Me.Destination.Items.Add("TPA")
        Me.Destination.Location = New System.Drawing.Point(64, 112)
        Me.Destination.Size = New System.Drawing.Size(52, 22)
        '
        'Flight
        '
        Me.Flight.Location = New System.Drawing.Point(8, 112)
        Me.Flight.Size = New System.Drawing.Size(48, 22)
        Me.Flight.Text = ""
        '
        'Label26
        '
        Me.Label26.Location = New System.Drawing.Point(112, 8)
        Me.Label26.Size = New System.Drawing.Size(128, 16)
        Me.Label26.Text = "Operation Code"
        Me.Label26.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'Label27
        '
        Me.Label27.Location = New System.Drawing.Point(8, 56)
        Me.Label27.Size = New System.Drawing.Size(88, 16)
        Me.Label27.Text = "Air Waybill No."
        '
        'Label30
        '
        Me.Label30.Location = New System.Drawing.Point(120, 136)
        Me.Label30.Size = New System.Drawing.Size(74, 16)
        Me.Label30.Text = "A/C Cart ID"
        '
        'Label31
        '
        Me.Label31.Location = New System.Drawing.Point(192, 56)
        Me.Label31.Size = New System.Drawing.Size(40, 16)
        Me.Label31.Text = "Carr."
        Me.Label31.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'Label32
        '
        Me.Label32.Location = New System.Drawing.Point(144, 56)
        Me.Label32.Size = New System.Drawing.Size(53, 16)
        Me.Label32.Text = "Loc"
        '
        'Label33
        '
        Me.Label33.Location = New System.Drawing.Point(16, 240)
        Me.Label33.Size = New System.Drawing.Size(40, 16)
        Me.Label33.Text = "Count"
        Me.Label33.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'PieceCount
        '
        Me.PieceCount.Location = New System.Drawing.Point(16, 224)
        Me.PieceCount.Size = New System.Drawing.Size(40, 16)
        Me.PieceCount.Text = "0"
        Me.PieceCount.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'MainMenu1
        '
        Me.MainMenu1.MenuItems.Add(Me.Tools)
        '
        'Tools
        '
        Me.Tools.MenuItems.Add(Me.Save)
        Me.Tools.MenuItems.Add(Me.Send)
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
        'ToolBar1
        '
        Me.ToolBar1.Buttons.Add(Me.SeparateBar)
        Me.ToolBar1.Buttons.Add(Me.SaveButton)
        Me.ToolBar1.ImageList = Me.ImageList1
        '
        'SeparateBar
        '
        Me.SeparateBar.Style = System.Windows.Forms.ToolBarButtonStyle.Separator
        '
        'SaveButton
        '
        Me.SaveButton.Enabled = False
        Me.SaveButton.ImageIndex = 0
        '
        'ImageList1
        '
        Me.ImageList1.Images.Add(CType(resources.GetObject("resource"), System.Drawing.Image))
        Me.ImageList1.Images.Add(CType(resources.GetObject("resource1"), System.Drawing.Image))
        Me.ImageList1.ImageSize = New System.Drawing.Size(16, 16)
        '
        'TransCarrier
        '
        Me.TransCarrier.Enabled = False
        Me.TransCarrier.Location = New System.Drawing.Point(136, 112)
        Me.TransCarrier.Size = New System.Drawing.Size(40, 22)
        Me.TransCarrier.Text = ""
        '
        'TransCarrierLabel
        '
        Me.TransCarrierLabel.Location = New System.Drawing.Point(136, 96)
        Me.TransCarrierLabel.Size = New System.Drawing.Size(72, 16)
        Me.TransCarrierLabel.Text = "Trans. Carr."
        '
        'PiecesLabel
        '
        Me.PiecesLabel.Location = New System.Drawing.Point(8, 136)
        Me.PiecesLabel.Size = New System.Drawing.Size(40, 16)
        Me.PiecesLabel.Text = "Pieces"
        '
        'Pieces
        '
        Me.Pieces.Location = New System.Drawing.Point(8, 152)
        Me.Pieces.Size = New System.Drawing.Size(48, 22)
        Me.Pieces.Text = "1"
        '
        'Weight
        '
        Me.Weight.Location = New System.Drawing.Point(64, 152)
        Me.Weight.Size = New System.Drawing.Size(48, 22)
        Me.Weight.Text = ""
        '
        'WeightLabel
        '
        Me.WeightLabel.Location = New System.Drawing.Point(64, 136)
        Me.WeightLabel.Size = New System.Drawing.Size(48, 16)
        Me.WeightLabel.Text = "Weight"
        '
        'TotalWeightLabel
        '
        Me.TotalWeightLabel.Location = New System.Drawing.Point(72, 240)
        Me.TotalWeightLabel.Size = New System.Drawing.Size(72, 16)
        Me.TotalWeightLabel.Text = "Tot. Wgt."
        Me.TotalWeightLabel.Visible = False
        '
        'TotalWeight
        '
        Me.TotalWeight.Location = New System.Drawing.Point(80, 224)
        Me.TotalWeight.Size = New System.Drawing.Size(40, 16)
        Me.TotalWeight.Text = "0"
        Me.TotalWeight.TextAlign = System.Drawing.ContentAlignment.TopCenter
        Me.TotalWeight.Visible = False
        '
        'txtShelf
        '
        Me.txtShelf.Location = New System.Drawing.Point(8, 192)
        Me.txtShelf.Size = New System.Drawing.Size(48, 22)
        Me.txtShelf.Text = ""
        '
        'lbl
        '
        Me.lbl.Location = New System.Drawing.Point(8, 176)
        Me.lbl.Size = New System.Drawing.Size(40, 16)
        Me.lbl.Text = "Shelf"
        '
        'txtBin
        '
        Me.txtBin.Location = New System.Drawing.Point(64, 192)
        Me.txtBin.Size = New System.Drawing.Size(48, 22)
        Me.txtBin.Text = ""
        '
        'lblBin
        '
        Me.lblBin.Location = New System.Drawing.Point(64, 176)
        Me.lblBin.Size = New System.Drawing.Size(40, 16)
        Me.lblBin.Text = "Bin"
        '
        'lblOldFlight
        '
        Me.lblOldFlight.Location = New System.Drawing.Point(120, 176)
        Me.lblOldFlight.Size = New System.Drawing.Size(64, 16)
        Me.lblOldFlight.Text = "Old Flight"
        '
        'OldFlight
        '
        Me.OldFlight.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular)
        Me.OldFlight.Location = New System.Drawing.Point(120, 192)
        Me.OldFlight.Size = New System.Drawing.Size(48, 22)
        Me.OldFlight.Text = ""
        '
        'CargoScanBaseForm
        '
        Me.ClientSize = New System.Drawing.Size(240, 265)
        Me.ControlBox = False
        Me.Controls.Add(Me.OldFlight)
        Me.Controls.Add(Me.lblOldFlight)
        Me.Controls.Add(Me.txtBin)
        Me.Controls.Add(Me.lblBin)
        Me.Controls.Add(Me.txtShelf)
        Me.Controls.Add(Me.lbl)
        Me.Controls.Add(Me.TotalWeight)
        Me.Controls.Add(Me.TotalWeightLabel)
        Me.Controls.Add(Me.WeightLabel)
        Me.Controls.Add(Me.Weight)
        Me.Controls.Add(Me.Pieces)
        Me.Controls.Add(Me.PiecesLabel)
        Me.Controls.Add(Me.TransCarrierLabel)
        Me.Controls.Add(Me.TransCarrier)
        Me.Controls.Add(Me.pbxCargoFormLogo)
        Me.Controls.Add(Me.ScanLocation)
        Me.Controls.Add(Me.Hazmat)
        Me.Controls.Add(Me.Label35)
        Me.Controls.Add(Me.Label29)
        Me.Controls.Add(Me.AcCartId)
        Me.Controls.Add(Me.AirwayBill)
        Me.Controls.Add(Me.Carrier)
        Me.Controls.Add(Me.Operations)
        Me.Controls.Add(Me.Destination)
        Me.Controls.Add(Me.Flight)
        Me.Controls.Add(Me.Label26)
        Me.Controls.Add(Me.Label27)
        Me.Controls.Add(Me.Label30)
        Me.Controls.Add(Me.Label31)
        Me.Controls.Add(Me.Label32)
        Me.Controls.Add(Me.Label33)
        Me.Controls.Add(Me.PieceCount)
        Me.Controls.Add(Me.ToolBar1)
        Me.Menu = Me.MainMenu1
        Me.Text = "Cargo Scan"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized

    End Sub

#End Region

    Private Sub formActive(ByVal sender As Object, ByVal e As EventArgs) Handles MyBase.Activated
        TagTrakGlobals.currentScanOperation = "CargoScan"
        If isNonNullString(Me.Operations.Text) Then
            Util.turnScannerOn(9)
        Else
            Util.turnScannerOff(8)
        End If
    End Sub

    Public Sub loadCargoFormLogo()

        Dim cargoFormLogoPath As String

        cargoFormLogoPath = TagTrakConfigDirectory & "\" & userSpecRecord.userName & "scanFormLogo.bmp"

        If File.Exists(cargoFormLogoPath) Then
            pbxCargoFormLogo.Image = New System.Drawing.Bitmap(cargoFormLogoPath)
            Exit Sub
        End If

        cargoFormLogoPath = TagTrakConfigDirectory & "\scanFormLogo.bmp"

        If File.Exists(cargoFormLogoPath) Then
            pbxCargoFormLogo.Image = New System.Drawing.Bitmap(cargoFormLogoPath)
        End If

    End Sub

    Private activatedProcessed As Boolean = False

    Private Sub cargScanBaseForm_Closed(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Closed
        activatedProcessed = False
    End Sub

    Private Sub cargoOperationComboBox_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Operations.SelectedIndexChanged
        Static prevIndex As Integer = 0

        If Me.Operations.SelectedIndex <> prevIndex Then
            Dim result As MsgBoxResult = MsgBox("You Are Changing The Type Of Scan Operation. Please Confirm!", MsgBoxStyle.YesNo, "Confirm Operation Change")
            If result = MsgBoxResult.Yes Then
                Me.resetControls()
                prevIndex = Me.Operations.SelectedIndex
            Else
                Me.Operations.SelectedIndex = prevIndex
            End If
        End If

        If Me.Operations.SelectedIndex > 0 Then
            Util.turnScannerOn(901)
        Else
            Util.turnScannerOff(902)
        End If

        Me.setControlStatus()
    End Sub

    Private Sub resetCountersMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CounterReset.Click

        Dim logMaintenanceThread As New System.threading.Thread(AddressOf logMaintenanceThreadSub)

        logMaintenanceThread.Priority = Threading.ThreadPriority.Lowest

        logMaintenanceThread.Start()

        Dim response As MsgBoxResult

        response = MsgBox("This Will Reset The Location Counters Only", MsgBoxStyle.OKCancel, "Confirm Counter Reset")

        If response = MsgBoxResult.Cancel Then Exit Sub

        Me.PieceCount.Text = "0"
        Me.TotalWeight.Text = "0"

    End Sub

    Dim cbxCargoScanLocationSelectedIndexChanged As Boolean = False

    Private Sub cbxCargoScanLocation_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ScanLocation.SelectedIndexChanged

        If TagTrakGlobals.scanLocation.ignoreLocationChange Then Return

        If cbxCargoScanLocationSelectedIndexChanged Then Exit Sub

        cbxCargoScanLocationSelectedIndexChanged = True

        TagTrakGlobals.scanLocation.update(Me.ScanLocation.Text, Me.ScanLocation)

        cbxCargoScanLocationSelectedIndexChanged = False

    End Sub

    Private Sub cargoScanUploadButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Send.Click

        Me.DialogResult = TagTrakGlobals.uploadButtonClick()

        If Me.DialogResult = DialogResult.Abort Then
            Me.Close()
        End If

    End Sub

    Public Sub ProcessScanData(ByRef readerString As String, ByVal symbology As Integer)

        If Len(readerString) < 1 Or Len(readerString) > 35 Then
            MsgBox("Tag Bar Code: Must be either at least 1 character and no more than 35 characters long", MsgBoxStyle.Exclamation, "Invalid Scan")
            Exit Sub
        End If

        'Modified by MX
        Dim i As Integer
        Dim charArray() As Char

        charArray = readerString.ToCharArray

        readerString = ""

        For Each readerChar As Char In charArray
            If readerChar <> " "c And readerChar <> "-"c Then
                readerString &= readerChar.ToString
            End If
        Next

        Me.Save.Enabled = False

        ignoreCargoAirwayBillTextChanged = True

        Me.AirwayBill.Text = readerString

        If Me.Pieces.Text = "" Then
            Me.Pieces.Text = "1"
        End If

        processCargoScanData(Me)

        ignoreCargoAirwayBillTextChanged = False

    End Sub

    Dim ignoreCargoAirwayBillTextChanged As Boolean = False
    Dim withinCargoAirwayBillTextChanged As Boolean = False

    Private Sub tbxCargoAirwayBill_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles AirwayBill.TextChanged

        If ignoreCargoAirwayBillTextChanged Then Exit Sub

        If withinCargoAirwayBillTextChanged Then Exit Sub

        withinCargoAirwayBillTextChanged = True

        Me.setControlStatus()

        withinCargoAirwayBillTextChanged = False

    End Sub

    Private Sub loadLocationComboBox()

        Me.ScanLocation.Items.Clear()

        Dim city As String

        For Each city In userSpecRecord.cityList
            Me.ScanLocation.Items.Add(city)
        Next

        ' MDD Test

        If ScanLocation Is Nothing Then
            Me.ScanLocation.SelectedItem = userSpecRecord.defaultLocation
        Else
            Me.ScanLocation.SelectedItem = TagTrakGlobals.scanLocation.currentLocation
        End If

    End Sub

    Private Sub textBox_GotFocus(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles AcCartId.GotFocus, AirwayBill.GotFocus, Flight.GotFocus, Pieces.GotFocus, Weight.GotFocus, TransCarrier.GotFocus
#If deviceType <> "PC" Then
        If userSpecRecord.showKeyboardOnFocus Then Me.InputPanel1.Enabled = True
#End If
    End Sub

    Private Sub setControlStatus()
        If Me.Operations.SelectedIndex > 0 Then
            If isNonNullString(Me.AirwayBill.Text) And Me.AirwayBill.Text.Length >= 11 Then
                Me.Save.Enabled = True
                Me.SaveButton.Enabled = True
            Else
                Me.Save.Enabled = False
                Me.SaveButton.Enabled = False
            End If

            If Me.Operations.SelectedItem = "Offline transfer" Then
                Me.TransCarrier.Enabled = True
                Me.AcCartId.Enabled = False
            Else
                Me.TransCarrier.Enabled = False
                Me.AcCartId.Enabled = True
            End If
        Else
            Me.Save.Enabled = False
            Me.SaveButton.Enabled = False

            Me.TransCarrier.Enabled = False
            Me.AcCartId.Enabled = False
        End If
    End Sub

    Private Sub btnCargoSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Save.Click

        cargoScanTransaction.processCargoScanData(Me)

#If deviceType <> "PC" Then
        Me.AirwayBill.Text = ""
#End If

    End Sub

    Private Sub resetControls()
        Me.AirwayBill.Text = ""
        Me.AcCartId.Text = ""
        Me.Flight.Text = ""
        Me.Hazmat.Checked = False
        Me.Pieces.Text = ""
        Me.Weight.Text = ""
        Me.TransCarrier.Text = ""
        Me.Destination.SelectedIndex = 0
        Me.PieceCount.Text = "0"
        Me.TotalWeight.Text = "0"
        Me.txtShelf.Text = ""
        Me.txtBin.Text = ""
    End Sub

    Private Sub CargoScanBaseForm_Deactivate(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Deactivate
        Util.turnScannerOff(999)
    End Sub

    Private Sub CounterReload_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles CounterReload.Click
        reloadCounters(Me.PieceCount, Me.TotalWeight, "CargoPieceCounts.txt")
    End Sub

    Private Sub ToolBar1_ButtonClick(ByVal sender As Object, ByVal e As System.Windows.Forms.ToolBarButtonClickEventArgs) Handles ToolBar1.ButtonClick
        If e.Button.ImageIndex = 0 Then
            btnCargoSave_Click(sender, e)
        End If
    End Sub

End Class
