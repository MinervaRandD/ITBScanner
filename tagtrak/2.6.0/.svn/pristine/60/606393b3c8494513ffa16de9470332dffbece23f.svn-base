Imports System
Imports System.io

Public Class presetsForm
    Inherits System.Windows.Forms.Form
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents staticPresetCheckBox As System.Windows.Forms.CheckBox
    Friend WithEvents selectItemButton As System.Windows.Forms.Button
    Friend WithEvents Label23 As System.Windows.Forms.Label
    Friend WithEvents rerouteButton As System.Windows.Forms.Button
    Friend WithEvents presetUpdateItemButton As System.Windows.Forms.Button
    Friend WithEvents presetListBoxHeader1Label As System.Windows.Forms.Label
    Friend WithEvents presetOriginLabel As System.Windows.Forms.Label
    Friend WithEvents presetDeleteCurrentItemButton As System.Windows.Forms.Button
    Friend WithEvents presetBatchIDLabel As System.Windows.Forms.Label
    Friend WithEvents Label20 As System.Windows.Forms.Label
    Friend WithEvents Label19 As System.Windows.Forms.Label
    Friend WithEvents Label18 As System.Windows.Forms.Label
    Friend WithEvents Label17 As System.Windows.Forms.Label
    Friend WithEvents addItemToPresetListButton As System.Windows.Forms.Button
    Friend WithEvents presetDestinationComboBox As System.Windows.Forms.ComboBox
    Friend WithEvents presetListBox As System.Windows.Forms.ListBox
    Friend WithEvents presetBatchIDTextBox As System.Windows.Forms.TextBox
    Friend WithEvents presetFlightNumberTextBox As System.Windows.Forms.TextBox

    Dim scanFormMail As scanFormMail

    'Dim userSpecRecord.presetList As New ArrayList
    Dim presetsListCurrentRecord As Integer = -1
    Dim presetListBoxDoubleClickTimeOut As DateTime = #1/1/1900#

#Region " Windows Form Designer generated code "

    Public Sub New(ByRef inputReaderForm As scanFormMail)
        MyBase.New()

        InitializeComponent()

        scanFormMail = inputReaderForm

        loadDestinationComboBox(presetDestinationComboBox, userSpecRecord.cityList)
        presetDestinationComboBox.Items.Insert(0, "")

        If userSpecRecord.userName = "ATA" Then
            presetBatchIDLabel.Text = "Cart ID"
            presetListBoxHeader1Label.Text = "org dst flgt  cart     new"
        End If

        setupKeyboard()

    End Sub

    Dim keyboard As keyboardClass

    Private Sub setupKeyboard()

        Dim textBoxList() As System.windows.forms.TextBox = { _
            presetBatchIDTextBox, _
            presetFlightNumberTextBox}

        keyboard = New keyboardClass(Me, textBoxList, keyboardIcon, AddressOf selectItemButton_Click)

    End Sub

    Protected Overloads Overrides Sub Dispose(ByVal disposing As Boolean)
        MyBase.Dispose(disposing)
    End Sub

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    Friend WithEvents exitButton As System.Windows.Forms.Button
    Friend WithEvents keyboardIcon As System.Windows.Forms.PictureBox
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.Label5 = New System.Windows.Forms.Label
        Me.staticPresetCheckBox = New System.Windows.Forms.CheckBox
        Me.selectItemButton = New System.Windows.Forms.Button
        Me.Label23 = New System.Windows.Forms.Label
        Me.rerouteButton = New System.Windows.Forms.Button
        Me.presetUpdateItemButton = New System.Windows.Forms.Button
        Me.presetListBoxHeader1Label = New System.Windows.Forms.Label
        Me.presetOriginLabel = New System.Windows.Forms.Label
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
        Me.exitButton = New System.Windows.Forms.Button
        Me.keyboardIcon = New System.Windows.Forms.PictureBox
        '
        'Label5
        '
        Me.Label5.Location = New System.Drawing.Point(202, 35)
        Me.Label5.Size = New System.Drawing.Size(36, 15)
        Me.Label5.Text = "Keep"
        '
        'staticPresetCheckBox
        '
        Me.staticPresetCheckBox.Location = New System.Drawing.Point(211, 54)
        Me.staticPresetCheckBox.Size = New System.Drawing.Size(17, 20)
        '
        'selectItemButton
        '
        Me.selectItemButton.Location = New System.Drawing.Point(9, 238)
        Me.selectItemButton.Size = New System.Drawing.Size(228, 29)
        Me.selectItemButton.Text = "Select Current Item For Scan Page"
        '
        'Label23
        '
        Me.Label23.Font = New System.Drawing.Font("Courier New", 9.0!, System.Drawing.FontStyle.Regular)
        Me.Label23.Location = New System.Drawing.Point(15, 157)
        Me.Label23.Size = New System.Drawing.Size(227, 13)
        Me.Label23.Text = "               ID    dst/flgt"
        '
        'rerouteButton
        '
        Me.rerouteButton.Location = New System.Drawing.Point(129, 113)
        Me.rerouteButton.Size = New System.Drawing.Size(97, 21)
        Me.rerouteButton.Text = "Reroute Item"
        '
        'presetUpdateItemButton
        '
        Me.presetUpdateItemButton.Location = New System.Drawing.Point(129, 91)
        Me.presetUpdateItemButton.Size = New System.Drawing.Size(97, 21)
        Me.presetUpdateItemButton.Text = "Update Item"
        '
        'presetListBoxHeader1Label
        '
        Me.presetListBoxHeader1Label.Font = New System.Drawing.Font("Courier New", 9.0!, System.Drawing.FontStyle.Regular)
        Me.presetListBoxHeader1Label.Location = New System.Drawing.Point(16, 144)
        Me.presetListBoxHeader1Label.Size = New System.Drawing.Size(225, 17)
        Me.presetListBoxHeader1Label.Text = "org dst flgt  cart    new"
        '
        'presetOriginLabel
        '
        Me.presetOriginLabel.Location = New System.Drawing.Point(7, 55)
        Me.presetOriginLabel.Size = New System.Drawing.Size(33, 20)
        Me.presetOriginLabel.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'presetDeleteCurrentItemButton
        '
        Me.presetDeleteCurrentItemButton.Location = New System.Drawing.Point(31, 113)
        Me.presetDeleteCurrentItemButton.Size = New System.Drawing.Size(97, 21)
        Me.presetDeleteCurrentItemButton.Text = "Delete Item"
        '
        'presetBatchIDLabel
        '
        Me.presetBatchIDLabel.Location = New System.Drawing.Point(90, 34)
        Me.presetBatchIDLabel.Size = New System.Drawing.Size(55, 16)
        Me.presetBatchIDLabel.Text = "Cart ID"
        Me.presetBatchIDLabel.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'Label20
        '
        Me.Label20.Location = New System.Drawing.Point(47, 34)
        Me.Label20.Size = New System.Drawing.Size(45, 17)
        Me.Label20.Text = "Flt Nbr"
        Me.Label20.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'Label19
        '
        Me.Label19.Location = New System.Drawing.Point(156, 34)
        Me.Label19.Size = New System.Drawing.Size(40, 17)
        Me.Label19.Text = "Dest."
        Me.Label19.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'Label18
        '
        Me.Label18.Location = New System.Drawing.Point(1, 34)
        Me.Label18.Size = New System.Drawing.Size(40, 17)
        Me.Label18.Text = "Origin"
        Me.Label18.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'Label17
        '
        Me.Label17.Font = New System.Drawing.Font("Tahoma", 12.0!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Italic), System.Drawing.FontStyle))
        Me.Label17.Location = New System.Drawing.Point(39, 5)
        Me.Label17.Size = New System.Drawing.Size(178, 16)
        Me.Label17.Text = "Process Presets List"
        Me.Label17.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'addItemToPresetListButton
        '
        Me.addItemToPresetListButton.Location = New System.Drawing.Point(31, 91)
        Me.addItemToPresetListButton.Size = New System.Drawing.Size(97, 21)
        Me.addItemToPresetListButton.Text = "Add Item"
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
        Me.presetDestinationComboBox.Location = New System.Drawing.Point(147, 53)
        Me.presetDestinationComboBox.Size = New System.Drawing.Size(55, 22)
        '
        'presetListBox
        '
        Me.presetListBox.Font = New System.Drawing.Font("Courier New", 9.0!, System.Drawing.FontStyle.Regular)
        Me.presetListBox.Items.Add("12345678901234567890123456789012345")
        Me.presetListBox.Location = New System.Drawing.Point(1, 175)
        Me.presetListBox.Size = New System.Drawing.Size(244, 47)
        '
        'presetBatchIDTextBox
        '
        Me.presetBatchIDTextBox.Location = New System.Drawing.Point(99, 53)
        Me.presetBatchIDTextBox.Size = New System.Drawing.Size(39, 22)
        Me.presetBatchIDTextBox.Text = ""
        '
        'presetFlightNumberTextBox
        '
        Me.presetFlightNumberTextBox.Location = New System.Drawing.Point(49, 53)
        Me.presetFlightNumberTextBox.Size = New System.Drawing.Size(41, 22)
        Me.presetFlightNumberTextBox.Text = ""
        '
        'exitButton
        '
        Me.exitButton.Location = New System.Drawing.Point(69, 283)
        Me.exitButton.Size = New System.Drawing.Size(109, 24)
        Me.exitButton.Text = "Exit"
        '
        'keyboardIcon
        '
        Me.keyboardIcon.Location = New System.Drawing.Point(207, 287)
        Me.keyboardIcon.Size = New System.Drawing.Size(23, 16)
        '
        'presetsForm
        '
        Me.ClientSize = New System.Drawing.Size(250, 368)
        Me.Controls.Add(Me.keyboardIcon)
        Me.Controls.Add(Me.exitButton)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.staticPresetCheckBox)
        Me.Controls.Add(Me.selectItemButton)
        Me.Controls.Add(Me.Label23)
        Me.Controls.Add(Me.rerouteButton)
        Me.Controls.Add(Me.presetUpdateItemButton)
        Me.Controls.Add(Me.presetListBoxHeader1Label)
        Me.Controls.Add(Me.presetOriginLabel)
        Me.Controls.Add(Me.presetDeleteCurrentItemButton)
        Me.Controls.Add(Me.presetBatchIDLabel)
        Me.Controls.Add(Me.Label20)
        Me.Controls.Add(Me.Label19)
        Me.Controls.Add(Me.Label18)
        Me.Controls.Add(Me.Label17)
        Me.Controls.Add(Me.addItemToPresetListButton)
        Me.Controls.Add(Me.presetDestinationComboBox)
        Me.Controls.Add(Me.presetListBox)
        Me.Controls.Add(Me.presetBatchIDTextBox)
        Me.Controls.Add(Me.presetFlightNumberTextBox)
        Me.Text = "Presets"

    End Sub

#End Region

    Private Sub formOnLoad(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        Dim result As String

        If lockDown Then
            MyBase.MaximizeBox = False
            MyBase.MinimizeBox = False
            MyBase.ControlBox = False
            MyBase.WindowState = FormWindowState.Maximized
        End If

        result = loadPresetListFromFile(userSpecRecord, userSpecRecord.presetList)
        If result <> "OK" Then
            MsgBox("Load of preset file failed: " & result)
            Me.Close()
            Exit Sub
        End If

        presetOriginLabel.Text = scanLocation

        presetListBox.Items.Clear()

        If userSpecRecord.presetList.Count <= 0 Then
            setCurrentRecord(-1)
            Exit Sub
        End If

        Dim presetRecord As presetRecordClass

        For Each presetRecord In userSpecRecord.presetList
            presetListBox.Items.Add(presetRecord.formatForListBox)
        Next

        setCurrentRecord(0)

    End Sub

    Dim withinupdateExpiredPresetsInListBox As Boolean = False

    Private Sub doSetCurrentRecord(ByVal currentRecord As Integer)

        If currentRecord < 0 Or currentRecord >= userSpecRecord.presetList.Count Then

            presetFlightNumberTextBox.Text = ""
            presetBatchIDTextBox.Text = ""
            presetDestinationComboBox.SelectedIndex = -1
            presetsListCurrentRecord = -1
            presetDestinationComboBox.Text = ""

            presetListBox.Refresh()

            Exit Sub

        End If

        Dim presetRecord As presetRecordClass = userSpecRecord.presetList(currentRecord)

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

        presetListBox.SelectedIndex = currentRecord

        presetsListCurrentRecord = currentRecord

        savePresetListToFile(userSpecRecord, userSpecRecord.presetList)

    End Sub

    Private Sub handlePresetUpdateItemButtonClick()

#If ValidationLevel >= 1 Then
        verify(presetListBox.SelectedIndex = presetsListCurrentRecord)
        verify(presetListBox.Items.Count = userSpecRecord.presetList.Count)
#End If

        Dim currentRecord As Integer = presetListBox.SelectedIndex

        'updateExpiredPresetsInListBox()

        If currentRecord < 0 Or currentRecord >= userSpecRecord.presetList.Count Then
            MsgBox("No item selected to update")
            Exit Sub
        End If

        Dim currentPresetRecord As presetRecordClass = userSpecRecord.presetList(presetsListCurrentRecord)

        Dim presetRecord As New presetRecordClass(currentPresetRecord)

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
            Exit Sub
        End If

        If Not isValidFlightNumber(flightNumber) Then
            MsgBox("You must specify a valid flight number to update a preset record", MsgBoxStyle.Exclamation, "Invalid Flight Number")
            Exit Sub
        End If

        If Not isValidBatchID(batchID) Then
            If user = "ATA" Or user = "USAirways" Then
                warning("A Cart ID Is Required to update a preset record", MsgBoxStyle.Exclamation, "Invalid Cart ID")
            Else
                warning("A Cart ID Is Required to update a preset record", MsgBoxStyle.Exclamation, "Invalid Cart ID")
            End If

            Exit Sub
        End If

        If isNonNullString(destination) Then

            If Not isValidLocationCode(destination) Then
                MsgBox("Invalid destination code specified", MsgBoxStyle.Exclamation, "Invalid Destination")
                Exit Sub

                If origin = destination Then
                    MsgBox("Origin Cannot Be The Same As Destination", MsgBoxStyle.Exclamation, "Invalid Destination")
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
        presetRecord.presetLastUsedDateAndTime = New DateTime(0)

        Dim i, ilmt As Integer

        ilmt = userSpecRecord.presetList.Count - 1

        For i = 0 To ilmt
            If i <> currentRecord Then
                If presetRecord.compare(userSpecRecord.presetList(i)) = 0 Then
                    MsgBox("Updated Preset Record Is Now The Same As An Existing Preset Record.", MsgBoxStyle.Exclamation, "Duplicate Preset Record")
                    Exit Sub
                End If
            End If
        Next

        If Not verifyNonUniqueKeepPreset(presetRecord, presetListBox.SelectedIndex) Then

            Dim errorString As String = "Only one keep preset allowed with this origin, destination, and "

            If user = "ATA" Or user = "USAirways" Then
                errorString &= "cart id"
            Else
                errorString &= "cart id"
            End If

            errorString &= ": Update creates a duplicate"

            MsgBox(errorString, MsgBoxStyle.Exclamation, "Duplicate Keep Preset")
            Exit Sub

        End If

        presetListBox.Items.Item(currentRecord) = presetRecord.formatForListBox
        userSpecRecord.presetList(presetsListCurrentRecord) = presetRecord

        setCurrentRecord(currentRecord)

        presetListBox.SelectedIndex = currentRecord

        logPresetEvent(1, "Updated", presetRecord.formatForUpload)

        savePresetListToFile(userSpecRecord, userSpecRecord.presetList)

    End Sub

    Dim withinPresetUpdateItemButtonClick As Boolean = False

    Private Sub presetUpdateItemButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles presetUpdateItemButton.Click

        If withinPresetUpdateItemButtonClick Then Exit Sub

        withinPresetUpdateItemButtonClick = True

        presetListBoxDoubleClickTimeOut = #1/1/1900#

        handlePresetUpdateItemButtonClick()

        presetListBoxDoubleClickTimeOut = #1/1/1900#

        withinPresetUpdateItemButtonClick = False

    End Sub

    Dim withinSetCurrentRecord As Boolean = False

    Private Sub setCurrentRecord(ByVal currentRecord As Integer)

        If withinSetCurrentRecord Then Exit Sub

        withinSetCurrentRecord = True
        doSetCurrentRecord(currentRecord)
        withinSetCurrentRecord = False

    End Sub

    Private Function verifyNonUniqueKeepPreset(ByRef presetRecord As presetRecordClass, ByVal currentRecordNumber As Integer) As Boolean

#If ValidationLevel >= 3 Then

        If diagnosticLevel >= 2 Then
            verify(Not presetRecord Is Nothing, 34000)
            verify(currentRecordNumber >= 0, 7020)
        End If

#End If

        If Not presetRecord.staticPresetFlag Then Return True

        Dim comparePresetRecord As presetRecordClass

        Dim i As Integer = 0

        For Each comparePresetRecord In userSpecRecord.presetList

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

    Private Sub handleAddItemToPresetListButtonClick()

#If ValidationLevel >= 1 Then
        verify(presetListBox.SelectedIndex = presetsListCurrentRecord)
        verify(presetListBox.Items.Count = userSpecRecord.presetList.Count)
#End If

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
            Exit Sub
        End If

        If Not isValidFlightNumber(flightNumber) Then
            MsgBox("You must specify a valid flight number to create a preset record", MsgBoxStyle.Exclamation, "Invalid Flight Number")
            Exit Sub
        End If

        If Not isValidBatchID(batchID) Then
            If user = "ATA" Or user = "USAirways" Then
                MsgBox("You must specify a valid cart ID to create a preset record", MsgBoxStyle.Exclamation, "Invalid Cart ID")
            Else
                MsgBox("You must specify a valid cart ID to create a preset record", MsgBoxStyle.Exclamation, "Invalid Cart ID")
            End If

            Exit Sub
        End If

        If userSpecRecord.presetsRequireDestinationSpecifications Or isNonNullString(destination) Then

            If Not isValidLocationCode(destination) Then
                MsgBox("Invalid destination code specified", MsgBoxStyle.Exclamation, "Invalid Destination")
                Exit Sub
            End If

            If origin = destination Then
                MsgBox("Origin Cannot Be The Same As Destination", MsgBoxStyle.Exclamation, "Invalid Destination")
                Exit Sub
            End If

        End If

        Dim newPresetRecord As New presetRecordClass(staticPreset.ToString, origin, destination, flightNumber, batchID)

        ' MDD revisit the reason for the following

        Dim presetRecordAlreadyInList As Boolean = False
        Dim presetRecord As presetRecordClass

        For Each presetRecord In userSpecRecord.presetList
            If presetRecord.compare(newPresetRecord) = 0 Then
                presetRecordAlreadyInList = True
                Exit For
            End If
        Next

        If presetRecordAlreadyInList Then
            MsgBox("Preset record already defined.", MsgBoxStyle.Exclamation, "Dupicate Preset Record")
            Exit Sub
        End If

        If Not verifyNonUniqueKeepPreset(newPresetRecord, -1) Then

            Dim errorString As String = "Only one keep preset allowed with this origin, destination, and "

            If user = "ATA" Or user = "USAirways" Then
                errorString &= "cart id"
            Else
                errorString &= "cart id"
            End If

            MsgBox(errorString, MsgBoxStyle.Exclamation, "Duplicate Keep Preset")
            Exit Sub

        End If

        Dim i, ilmt As Integer

        ilmt = userSpecRecord.presetList.Count - 1

        For i = 0 To ilmt
            If newPresetRecord.compare(userSpecRecord.presetList(i)) = 0 Then
                MsgBox("This Preset Record Is Already In The List of Existing Preset Records.", MsgBoxStyle.Exclamation, "Duplicate Preset Record")
                Exit Sub
            End If
        Next

        logPresetEvent(1, "Add", newPresetRecord.formatForUpload)

        presetListBox.Items.Add(newPresetRecord.formatForListBox)
        userSpecRecord.presetList.Add(newPresetRecord)
        presetListBox.Refresh()

        setCurrentRecord(userSpecRecord.presetList.Count - 1)

        savePresetListToFile(userSpecRecord, userSpecRecord.presetList)

    End Sub

    Dim withinAddItemToPresetListButtonClick As Boolean = False

    Private Sub addItemToPresetListButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles addItemToPresetListButton.Click

        If withinAddItemToPresetListButtonClick Then Exit Sub

        withinAddItemToPresetListButtonClick = True

        presetListBoxDoubleClickTimeOut = #1/1/1900#

        handleAddItemToPresetListButtonClick()

        presetListBoxDoubleClickTimeOut = #1/1/1900#

        withinAddItemToPresetListButtonClick = False


    End Sub

    Dim withinPresetListBoxSelectedIndexChanged As Boolean = False


    Private Sub presetListBox_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles presetListBox.SelectedIndexChanged

        If presetListBox.SelectedIndex = presetsListCurrentRecord Then

            Dim currentDateAndTime As DateTime = DateTime.UtcNow

            If DateTime.Compare(presetListBoxDoubleClickTimeOut, currentDateAndTime) >= 0 Then
                selectItemButton_Click(Nothing, Nothing)
                withinPresetListBoxSelectedIndexChanged = False
                Exit Sub
            End If

        End If

        presetListBoxDoubleClickTimeOut = DateTime.UtcNow.AddSeconds(1.0)

        If withinPresetListBoxSelectedIndexChanged Then Exit Sub

        withinPresetListBoxSelectedIndexChanged = True

        setCurrentRecord(presetListBox.SelectedIndex)
        withinPresetListBoxSelectedIndexChanged = False

    End Sub

    Dim withinPresetListBoxClick As Boolean = False

    Private Sub presetListBox_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles presetListBox.Click

        If withinPresetListBoxClick Then Exit Sub

        withinPresetListBoxClick = True

        withinPresetListBoxClick = False

    End Sub

    Private Sub handlePresetDeleteCurrentItemButtonClick()

#If ValidationLevel >= 1 Then
        verify(presetListBox.SelectedIndex = presetsListCurrentRecord)
        verify(presetListBox.Items.Count = userSpecRecord.presetList.Count)
#End If

        If userSpecRecord.presetList.Count <= 0 Then
            MsgBox("No Item Selected To Delete")
            Exit Sub
        End If

        Dim currentRecord As Integer = presetListBox.SelectedIndex

        If currentRecord < 0 Or currentRecord >= presetListBox.Items.Count Then
            MsgBox("No Item Selected To Delete")
            Exit Sub
        End If

        Dim presetRecord As presetRecordClass = userSpecRecord.presetList(presetsListCurrentRecord)

        logPresetEvent(1, "Deleted", presetRecord.formatForUpload)

        presetListBox.Items.RemoveAt(currentRecord)
        userSpecRecord.presetList.RemoveAt(presetsListCurrentRecord)

        If currentRecord >= presetListBox.Items.Count Then
            currentRecord -= 1
        End If

        setCurrentRecord(currentRecord)

        savePresetListToFile(userSpecRecord, userSpecRecord.presetList)

    End Sub

    Dim withinPresetDeleteCurrentItemButtonClick As Boolean = False

    Private Sub presetDeleteCurrentItemButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles presetDeleteCurrentItemButton.Click


        If withinPresetDeleteCurrentItemButtonClick Then Exit Sub

        withinPresetDeleteCurrentItemButtonClick = True

        presetListBoxDoubleClickTimeOut = #1/1/1900#

        handlePresetDeleteCurrentItemButtonClick()

        presetListBoxDoubleClickTimeOut = #1/1/1900#

        withinPresetDeleteCurrentItemButtonClick = False

    End Sub

    Private Sub handlererouteButtonClick()

#If ValidationLevel >= 1 Then
        verify(presetListBox.SelectedIndex = presetsListCurrentRecord)
        verify(presetListBox.Items.Count = userSpecRecord.presetList.Count)
#End If

        If presetListBox.SelectedIndex < 0 Or presetListBox.SelectedIndex >= presetListBox.Items.Count Or presetListBox.Items.Count = 0 Then

            MsgBox("No preset record to reroute", MsgBoxStyle.Exclamation)
            Exit Sub

        End If

        Dim currentRecord As Integer = presetListBox.SelectedIndex

        Dim currentPresetRecord As presetRecordClass = userSpecRecord.presetList(presetsListCurrentRecord)
        Dim presetRecord As New presetRecordClass(currentPresetRecord)

        Dim rerouteDisplayForm As New rerouteForm(scanFormMail, presetRecord)
        rerouteDisplayForm.ShowDialog()

        Dim i, ilmt As Integer

        ilmt = userSpecRecord.presetList.Count - 1

        For i = 0 To ilmt
            If i <> currentRecord Then

                If presetRecord.compare(userSpecRecord.presetList(i)) = 0 Then
                    MsgBox("Reroute Preset Record Is Now The Same As An Existing Preset Record.", MsgBoxStyle.Exclamation, "Duplicate Preset Record")
                    Exit Sub
                End If

            End If
        Next

        logPresetEvent(1, "Rerouted", presetRecord.formatForUpload)

        presetListBox.Items.Item(currentRecord) = presetRecord.formatForListBox
        userSpecRecord.presetList(presetsListCurrentRecord) = presetRecord

        setCurrentRecord(currentRecord)

        presetListBox.Refresh()

        presetListBox.SelectedIndex = currentRecord

        savePresetListToFile(userSpecRecord, userSpecRecord.presetList)

    End Sub

    Dim withinRerouteButtonClick As Boolean = False

    Private Sub rerouteButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rerouteButton.Click

        If withinRerouteButtonClick Then Exit Sub

        withinRerouteButtonClick = True

        presetListBoxDoubleClickTimeOut = #1/1/1900#

        handlererouteButtonClick()

        presetListBoxDoubleClickTimeOut = #1/1/1900#

        withinRerouteButtonClick = False

    End Sub

    Private Sub handleSelectButtonClick()

#If ValidationLevel >= 1 Then
        verify(presetListBox.SelectedIndex = presetsListCurrentRecord)
        verify(presetListBox.Items.Count = userSpecRecord.presetList.Count)
#End If

        Dim result As String

        Dim selectedIndex As Integer = presetListBox.SelectedIndex

        If selectedIndex < 0 Or selectedIndex >= presetListBox.Items.Count Then
            MsgBox("No Preset Record Selected")
            Exit Sub
        End If

        Dim presetRecord As presetRecordClass = userSpecRecord.presetList(selectedIndex)

        scanFormMail.groupNumberTextBox.Text = presetRecord.batchID

        Dim lastUseTimeOut As DateTime = presetRecord.presetLastUsedDateAndTime.AddHours(18.0)

        If DateTime.Compare(lastUseTimeOut, DateTime.UtcNow) >= 0 Then
            Dim queryResult As MsgBoxResult = MsgBox("This Preset Has Already Been Used. Use It Again?", MsgBoxStyle.YesNo, "Reuse of Preset")
            If queryResult = MsgBoxResult.No Then Exit Sub
        End If

        verify(Length(scanLocation) >= 3, 14)

        If presetRecord.origin <> Substring(scanLocation, 0, 3) Then
            MsgBox("Preset Origin Does Not Correspond To Current Location")
            Exit Sub
        End If

        If presetRecord.presetHasExpired Then
            Dim queryResult As MsgBoxResult = MsgBox("This Preset Has Expired. Use It Anyway?", MsgBoxStyle.YesNo, "Expired Preset")
            If queryResult = MsgBoxResult.No Then Exit Sub
        End If

        If presetRecord.isReroutePreset Then
            scanFormMail.flightNumberTextBox.Text = presetRecord.newFlightNumber
            scanFormMail.mailDestinationComboBox.SelectedItem = presetRecord.newDestination
        Else
            scanFormMail.flightNumberTextBox.Text = presetRecord.flightNumber
            scanFormMail.mailDestinationComboBox.SelectedItem = presetRecord.destination
        End If

        presetRecord.presetLastUsedDateAndTime = DateTime.UtcNow

        scanFormMail.currentScanScreenPopulatedFromPreset = True
        lastSelectedPresetForScanScreen = userSpecRecord.presetList(selectedIndex)

        savePresetListToFile(userSpecRecord, userSpecRecord.presetList)

    End Sub

    Dim withinSelectButtonClick As Boolean = False

    Private Sub selectItemButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles selectItemButton.Click

        If withinSelectButtonClick Then Exit Sub

        withinSelectButtonClick = True

        presetListBoxDoubleClickTimeOut = #1/1/1900#

        handleSelectButtonClick()

        presetListBoxDoubleClickTimeOut = #1/1/1900#

        withinSelectButtonClick = False

        keyboard.hide()
        Me.Close()

    End Sub

    Private Sub exitButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles exitButton.Click
        Me.Close()
    End Sub

    Private Sub presetsForm_KeyPress(ByVal sender As System.Object, ByVal e As KeyPressEventArgs) _
               Handles presetFlightNumberTextBox.KeyPress, presetBatchIDTextBox.KeyPress

        If e.KeyChar = tabKeyChar Then
            keyboard.processTabRoutine(sender)
        End If

    End Sub
End Class
