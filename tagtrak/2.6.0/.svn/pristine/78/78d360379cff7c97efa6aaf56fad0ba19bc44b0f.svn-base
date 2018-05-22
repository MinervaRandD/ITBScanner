Imports System
Imports System.IO

Public Class scanFormLuggage

    Inherits System.Windows.Forms.Form
    Friend WithEvents baggageFormLogoPictureBox As System.Windows.Forms.PictureBox
    Friend WithEvents baggageLocationComboBox As System.Windows.Forms.ComboBox
    Friend WithEvents baggageCarrierCodeLabel As System.Windows.Forms.Label
    Friend WithEvents Label23 As System.Windows.Forms.Label
    Friend WithEvents baggageLocationLabel As System.Windows.Forms.Label
    Friend WithEvents Label22 As System.Windows.Forms.Label
    Friend WithEvents Label17 As System.Windows.Forms.Label
    Friend WithEvents baggageFormCounterIcon As System.Windows.Forms.PictureBox
    Friend WithEvents Label18 As System.Windows.Forms.Label
    Friend WithEvents baggagePieceCountLabel As System.Windows.Forms.Label
    Friend WithEvents Label43 As System.Windows.Forms.Label
    Friend WithEvents Label36 As System.Windows.Forms.Label
    Friend WithEvents baggageContainerPositionTextBox As System.Windows.Forms.TextBox
    Friend WithEvents Label40 As System.Windows.Forms.Label
    Friend WithEvents baggageHoldPositionTextBox As System.Windows.Forms.TextBox
    Friend WithEvents Label37 As System.Windows.Forms.Label
    Friend WithEvents Label14 As System.Windows.Forms.Label
    Friend WithEvents baggageOperationComboBox As System.Windows.Forms.ComboBox
    Friend WithEvents Label38 As System.Windows.Forms.Label
    Friend WithEvents baggageFlightNumberTextBox As System.Windows.Forms.TextBox
    Friend WithEvents baggageACBinIDTextBox As System.Windows.Forms.TextBox
    Friend WithEvents Label41 As System.Windows.Forms.Label
    Friend WithEvents Label42 As System.Windows.Forms.Label
    Friend WithEvents baggageTagIDTextBox As System.Windows.Forms.TextBox
    Friend WithEvents Label44 As System.Windows.Forms.Label
    Friend WithEvents baggageScanUploadButton As System.Windows.Forms.Button

    Dim baggageScanTextBoxCollection() As System.Windows.Forms.TextBox

    Dim initBaggageScanTextBoxCollection() As System.windows.forms.TextBox = { _
        baggageFlightNumberTextBox, _
        baggageTagIDTextBox, _
        baggageACBinIDTextBox, _
        baggageHoldPositionTextBox, _
        baggageContainerPositionTextBox}

#Region " Windows Form Designer generated code "

    Public Sub New()
        MyBase.New()

        'This call is required by the Windows Form Designer.
        InitializeComponent()

        baggagePieceCountLabel.Text = 0
        loadDestinationComboBox(baggageLocationComboBox, userSpecRecord.airportLocationList)
        baggageCarrierCodeLabel.Text = userSpecRecord.carrierCode
        'change location on baggage scan form spec

        baggageLocationLabel.Visible = Not userSpecRecord.canChangeLocationOnScanForm
        baggageLocationComboBox.Visible = userSpecRecord.canChangeLocationOnScanForm
        baggageLocationComboBox.Enabled = userSpecRecord.canChangeLocationOnScanForm
        baggageLocationLabel.DataBindings.Add(New Binding("Text", activeReaderForm.mailLocationLabel, "Text"))
        baggageFormLogoPictureBox.Image = activeReaderForm.mailFormLogoPictureBox.Image

        baggageScanTextBoxCollection = initBaggageScanTextBoxCollection

        'Add any initialization after the InitializeComponent() call

        baggageLocationComboBox.Items.Clear()

        Dim city As String

        For Each city In userSpecRecord.cityList
            Me.baggageLocationComboBox.Items.Add(city)
        Next

        If scanLocation Is Nothing Then
            Me.baggageLocationComboBox.SelectedItem = userSpecRecord.defaultLocation
        Else
            Me.baggageLocationComboBox.SelectedItem = scanLocation
        End If

    End Sub

    Protected Overloads Overrides Sub Dispose(ByVal disposing As Boolean)
        MyBase.Dispose(disposing)
    End Sub

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Dim resources As System.Resources.ResourceManager = New System.Resources.ResourceManager(GetType(scanFormLuggage))
        Me.baggageFormLogoPictureBox = New System.Windows.Forms.PictureBox
        Me.baggageLocationComboBox = New System.Windows.Forms.ComboBox
        Me.baggageCarrierCodeLabel = New System.Windows.Forms.Label
        Me.Label23 = New System.Windows.Forms.Label
        Me.baggageLocationLabel = New System.Windows.Forms.Label
        Me.Label22 = New System.Windows.Forms.Label
        Me.Label17 = New System.Windows.Forms.Label
        Me.baggageFormCounterIcon = New System.Windows.Forms.PictureBox
        Me.Label18 = New System.Windows.Forms.Label
        Me.baggagePieceCountLabel = New System.Windows.Forms.Label
        Me.Label43 = New System.Windows.Forms.Label
        Me.Label36 = New System.Windows.Forms.Label
        Me.baggageContainerPositionTextBox = New System.Windows.Forms.TextBox
        Me.Label40 = New System.Windows.Forms.Label
        Me.baggageHoldPositionTextBox = New System.Windows.Forms.TextBox
        Me.Label37 = New System.Windows.Forms.Label
        Me.Label14 = New System.Windows.Forms.Label
        Me.baggageOperationComboBox = New System.Windows.Forms.ComboBox
        Me.Label38 = New System.Windows.Forms.Label
        Me.baggageFlightNumberTextBox = New System.Windows.Forms.TextBox
        Me.baggageACBinIDTextBox = New System.Windows.Forms.TextBox
        Me.Label41 = New System.Windows.Forms.Label
        Me.Label42 = New System.Windows.Forms.Label
        Me.baggageTagIDTextBox = New System.Windows.Forms.TextBox
        Me.Label44 = New System.Windows.Forms.Label
        Me.baggageScanUploadButton = New System.Windows.Forms.Button
        '
        'baggageFormLogoPictureBox
        '
        Me.baggageFormLogoPictureBox.Location = New System.Drawing.Point(4, 6)
        Me.baggageFormLogoPictureBox.Size = New System.Drawing.Size(100, 48)
        Me.baggageFormLogoPictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        '
        'baggageLocationComboBox
        '
        Me.baggageLocationComboBox.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular)
        Me.baggageLocationComboBox.Location = New System.Drawing.Point(160, 137)
        Me.baggageLocationComboBox.Size = New System.Drawing.Size(65, 22)
        '
        'baggageCarrierCodeLabel
        '
        Me.baggageCarrierCodeLabel.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular)
        Me.baggageCarrierCodeLabel.Location = New System.Drawing.Point(16, 140)
        Me.baggageCarrierCodeLabel.Size = New System.Drawing.Size(30, 16)
        Me.baggageCarrierCodeLabel.Text = "B6"
        Me.baggageCarrierCodeLabel.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'Label23
        '
        Me.Label23.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular)
        Me.Label23.Location = New System.Drawing.Point(8, 118)
        Me.Label23.Size = New System.Drawing.Size(46, 16)
        Me.Label23.Text = "Carr."
        Me.Label23.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'baggageLocationLabel
        '
        Me.baggageLocationLabel.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular)
        Me.baggageLocationLabel.Location = New System.Drawing.Point(172, 140)
        Me.baggageLocationLabel.Size = New System.Drawing.Size(30, 16)
        Me.baggageLocationLabel.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'Label22
        '
        Me.Label22.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular)
        Me.Label22.Location = New System.Drawing.Point(171, 118)
        Me.Label22.Size = New System.Drawing.Size(46, 16)
        Me.Label22.Text = "Loc"
        Me.Label22.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'Label17
        '
        Me.Label17.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular)
        Me.Label17.Location = New System.Drawing.Point(9, 254)
        Me.Label17.Size = New System.Drawing.Size(40, 16)
        Me.Label17.Text = "Count"
        Me.Label17.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'baggageFormCounterIcon
        '
        Me.baggageFormCounterIcon.Image = CType(resources.GetObject("baggageFormCounterIcon.Image"), System.Drawing.Image)
        Me.baggageFormCounterIcon.Location = New System.Drawing.Point(102, 243)
        Me.baggageFormCounterIcon.Size = New System.Drawing.Size(44, 20)
        '
        'Label18
        '
        Me.Label18.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular)
        Me.Label18.Location = New System.Drawing.Point(9, 235)
        Me.Label18.Size = New System.Drawing.Size(40, 16)
        Me.Label18.Text = "Piece"
        Me.Label18.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'baggagePieceCountLabel
        '
        Me.baggagePieceCountLabel.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular)
        Me.baggagePieceCountLabel.Location = New System.Drawing.Point(58, 245)
        Me.baggagePieceCountLabel.Size = New System.Drawing.Size(35, 20)
        '
        'Label43
        '
        Me.Label43.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular)
        Me.Label43.Location = New System.Drawing.Point(81, 178)
        Me.Label43.Size = New System.Drawing.Size(60, 17)
        Me.Label43.Text = "Position"
        Me.Label43.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'Label36
        '
        Me.Label36.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular)
        Me.Label36.Location = New System.Drawing.Point(160, 177)
        Me.Label36.Size = New System.Drawing.Size(60, 17)
        Me.Label36.Text = "Position"
        Me.Label36.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'baggageContainerPositionTextBox
        '
        Me.baggageContainerPositionTextBox.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular)
        Me.baggageContainerPositionTextBox.Location = New System.Drawing.Point(162, 195)
        Me.baggageContainerPositionTextBox.Size = New System.Drawing.Size(56, 22)
        Me.baggageContainerPositionTextBox.Text = ""
        '
        'Label40
        '
        Me.Label40.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular)
        Me.Label40.Location = New System.Drawing.Point(154, 164)
        Me.Label40.Size = New System.Drawing.Size(72, 16)
        Me.Label40.Text = "Container"
        Me.Label40.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'baggageHoldPositionTextBox
        '
        Me.baggageHoldPositionTextBox.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular)
        Me.baggageHoldPositionTextBox.Location = New System.Drawing.Point(83, 195)
        Me.baggageHoldPositionTextBox.Size = New System.Drawing.Size(56, 22)
        Me.baggageHoldPositionTextBox.Text = ""
        '
        'Label37
        '
        Me.Label37.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular)
        Me.Label37.Location = New System.Drawing.Point(87, 165)
        Me.Label37.Size = New System.Drawing.Size(49, 17)
        Me.Label37.Text = "Hold"
        Me.Label37.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'Label14
        '
        Me.Label14.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular)
        Me.Label14.Location = New System.Drawing.Point(124, 14)
        Me.Label14.Size = New System.Drawing.Size(112, 32)
        Me.Label14.Text = "Baggage"
        Me.Label14.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'baggageOperationComboBox
        '
        Me.baggageOperationComboBox.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular)
        Me.baggageOperationComboBox.Items.Add("")
        Me.baggageOperationComboBox.Items.Add("Check Baggage")
        Me.baggageOperationComboBox.Items.Add("Load")
        Me.baggageOperationComboBox.Items.Add("Transfer Online")
        Me.baggageOperationComboBox.Items.Add("Transfer OAL")
        Me.baggageOperationComboBox.Items.Add("Unload")
        Me.baggageOperationComboBox.Items.Add("Delivery")
        Me.baggageOperationComboBox.Location = New System.Drawing.Point(22, 87)
        Me.baggageOperationComboBox.Size = New System.Drawing.Size(124, 22)
        '
        'Label38
        '
        Me.Label38.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular)
        Me.Label38.Location = New System.Drawing.Point(171, 66)
        Me.Label38.Size = New System.Drawing.Size(37, 16)
        Me.Label38.Text = "Flight"
        Me.Label38.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'baggageFlightNumberTextBox
        '
        Me.baggageFlightNumberTextBox.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular)
        Me.baggageFlightNumberTextBox.Location = New System.Drawing.Point(165, 87)
        Me.baggageFlightNumberTextBox.Size = New System.Drawing.Size(48, 22)
        Me.baggageFlightNumberTextBox.Text = ""
        '
        'baggageACBinIDTextBox
        '
        Me.baggageACBinIDTextBox.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular)
        Me.baggageACBinIDTextBox.Location = New System.Drawing.Point(13, 196)
        Me.baggageACBinIDTextBox.Size = New System.Drawing.Size(56, 22)
        Me.baggageACBinIDTextBox.Text = ""
        '
        'Label41
        '
        Me.Label41.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular)
        Me.Label41.Location = New System.Drawing.Point(38, 66)
        Me.Label41.Size = New System.Drawing.Size(92, 16)
        Me.Label41.Text = "Operation Code"
        Me.Label41.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'Label42
        '
        Me.Label42.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular)
        Me.Label42.Location = New System.Drawing.Point(75, 118)
        Me.Label42.Size = New System.Drawing.Size(47, 16)
        Me.Label42.Text = "Tag ID"
        Me.Label42.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'baggageTagIDTextBox
        '
        Me.baggageTagIDTextBox.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular)
        Me.baggageTagIDTextBox.Location = New System.Drawing.Point(59, 137)
        Me.baggageTagIDTextBox.Size = New System.Drawing.Size(79, 22)
        Me.baggageTagIDTextBox.Text = ""
        '
        'Label44
        '
        Me.Label44.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular)
        Me.Label44.Location = New System.Drawing.Point(12, 177)
        Me.Label44.Size = New System.Drawing.Size(67, 16)
        Me.Label44.Text = "A/C Cart ID"
        Me.Label44.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'baggageScanUploadButton
        '
        Me.baggageScanUploadButton.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular)
        Me.baggageScanUploadButton.Location = New System.Drawing.Point(162, 243)
        Me.baggageScanUploadButton.Size = New System.Drawing.Size(62, 22)
        Me.baggageScanUploadButton.Text = "Upload"
        '
        'ReaderFormLuggage
        '
        Me.ClientSize = New System.Drawing.Size(245, 311)
        Me.Controls.Add(Me.baggageFormLogoPictureBox)
        Me.Controls.Add(Me.baggageLocationComboBox)
        Me.Controls.Add(Me.baggageCarrierCodeLabel)
        Me.Controls.Add(Me.Label23)
        Me.Controls.Add(Me.baggageLocationLabel)
        Me.Controls.Add(Me.Label22)
        Me.Controls.Add(Me.Label17)
        Me.Controls.Add(Me.baggageFormCounterIcon)
        Me.Controls.Add(Me.Label18)
        Me.Controls.Add(Me.baggagePieceCountLabel)
        Me.Controls.Add(Me.Label43)
        Me.Controls.Add(Me.Label36)
        Me.Controls.Add(Me.baggageContainerPositionTextBox)
        Me.Controls.Add(Me.Label40)
        Me.Controls.Add(Me.baggageHoldPositionTextBox)
        Me.Controls.Add(Me.Label37)
        Me.Controls.Add(Me.Label14)
        Me.Controls.Add(Me.baggageOperationComboBox)
        Me.Controls.Add(Me.Label38)
        Me.Controls.Add(Me.baggageFlightNumberTextBox)
        Me.Controls.Add(Me.baggageACBinIDTextBox)
        Me.Controls.Add(Me.Label41)
        Me.Controls.Add(Me.Label42)
        Me.Controls.Add(Me.baggageTagIDTextBox)
        Me.Controls.Add(Me.Label44)
        Me.Controls.Add(Me.baggageScanUploadButton)
        Me.Text = "ReaderFormLuggage"

    End Sub

#End Region

    Public Sub HandleBaggageScanData(ByVal readerString As String)

        If currentTabPage <> "baggage scan" Then

            Dim queryResult As MsgBoxResult = MsgBox("You have scanned a baggage bar code. Convert to baggage scanning operations?", MsgBoxStyle.YesNo, "Mail Bar Code Scanned")

            If queryResult = MsgBoxResult.No Then
                MsgBox("Invalid Bar Code Scanned.", MsgBoxStyle.Exclamation, "Invalid Bar Code")
                Exit Sub
            End If

            Me.ShowDialog()
            Me.BringToFront()

            Exit Sub

        End If

        If Len(readerString) <> 10 Then
            MsgBox("Invalid Baggage Tag Bar Code: Must be 10 characters long", MsgBoxStyle.Exclamation, "Invalid Scan")
            Exit Sub
        End If

        Me.baggageTagIDTextBox.Text = readerString

        Dim pieceCount As Integer = Me.baggagePieceCountLabel.Text

        pieceCount += 1

        Me.baggagePieceCountLabel.Text = pieceCount

        saveUpdatedBaggageScanCounts()

    End Sub

    Private Sub baggageLocationComboBox_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)

    End Sub

    Private Sub reloadBaggagePieceCounts()

        Dim countFilePath As String = deviceNonVolatileMemoryDirectory & backSlash & "BaggageScanPieceCounts.txt"

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
            turnScannerOn(901)
        Else
            turnScannerOff(902)
        End If

    End Sub

End Class
