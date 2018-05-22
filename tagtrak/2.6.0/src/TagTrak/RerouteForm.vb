Public Class rerouteForm
    Inherits System.Windows.Forms.Form
    Friend WithEvents rerouteExitButton As System.Windows.Forms.Button

    Public presetRecord As presetRecordClass

    Dim readerDisplayForm As scanFormMail

#Region " Windows Form Designer generated code "

    Public Sub New(ByRef inputReaderDisplayForm As scanFormMail, ByRef inputPresetRecord As presetRecordClass)

        MyBase.New()

#If ValidationLevel >= 3 Then

        If diagnosticLevel >= 2 Then
            verify(Not inputReaderDisplayForm Is Nothing, 12000)
            verify(Not inputPresetRecord Is Nothing, 12010)
        End If

#End If


        'This call is required by the Windows Form Designer.
        InitializeComponent()

        readerDisplayForm = inputReaderDisplayForm

        presetRecord = inputPresetRecord

        loadDestinationComboBox(mailDestinationComboBox, userSpecRecord.cityList)

        mailDestinationComboBox.Items.Insert(0, "")

        presetRecordLabel.Text = presetRecord.formatForListBox

        newInfoLabel.Text = presetRecord.newDestination.PadRight(3) & "/" & presetRecord.newFlightNumber.PadRight(4)

        If presetRecord.isReroutePreset Then
            flightNumberTextBox.Text = presetRecord.newFlightNumber.PadLeft(4, "0")
            mailDestinationComboBox.SelectedItem = presetRecord.newDestination
        Else
            flightNumberTextBox.Text = presetRecord.flightNumber.PadLeft(4, "0")
            mailDestinationComboBox.SelectedItem = presetRecord.destination
        End If

        'Add any initialization after the InitializeComponent() call

        If user = "ATA" Or user = "USAirways" Then
            rerouteLabel1.Text = "org dst flgt  cart      new"
        End If

    End Sub

    Dim keyboard As keyboardClass

    Private Sub setupKeyboard()

        Dim textBoxList() As System.windows.forms.TextBox = { _
            flightNumberTextBox}

        keyboard = New keyboardClass(Me, textBoxList, keyboardIcon, AddressOf applyButton_Click)

    End Sub

    Protected Overloads Overrides Sub Dispose(ByVal disposing As Boolean)
        MyBase.Dispose(disposing)
    End Sub

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    Friend WithEvents Label17 As System.Windows.Forms.Label
    Friend WithEvents Label23 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents presetRecordLabel As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents mailDestinationComboBox As System.Windows.Forms.ComboBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents flightNumberTextBox As System.Windows.Forms.TextBox
    Friend WithEvents applyButton As System.Windows.Forms.Button
    Friend WithEvents clearRerouteButton As System.Windows.Forms.Button
    Friend WithEvents rerouteLabel1 As System.Windows.Forms.Label
    Friend WithEvents newInfoLabel As System.Windows.Forms.Label
    Friend WithEvents keyboardIcon As System.Windows.Forms.PictureBox
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.applyButton = New System.Windows.Forms.Button
        Me.rerouteExitButton = New System.Windows.Forms.Button
        Me.Label17 = New System.Windows.Forms.Label
        Me.Label23 = New System.Windows.Forms.Label
        Me.rerouteLabel1 = New System.Windows.Forms.Label
        Me.Label1 = New System.Windows.Forms.Label
        Me.presetRecordLabel = New System.Windows.Forms.Label
        Me.Label2 = New System.Windows.Forms.Label
        Me.mailDestinationComboBox = New System.Windows.Forms.ComboBox
        Me.Label3 = New System.Windows.Forms.Label
        Me.flightNumberTextBox = New System.Windows.Forms.TextBox
        Me.clearRerouteButton = New System.Windows.Forms.Button
        Me.newInfoLabel = New System.Windows.Forms.Label
        Me.keyboardIcon = New System.Windows.Forms.PictureBox
        '
        'applyButton
        '
        Me.applyButton.Location = New System.Drawing.Point(82, 221)
        Me.applyButton.Size = New System.Drawing.Size(69, 34)
        Me.applyButton.Text = "APPLY"
        '
        'rerouteExitButton
        '
        Me.rerouteExitButton.Location = New System.Drawing.Point(153, 221)
        Me.rerouteExitButton.Size = New System.Drawing.Size(69, 34)
        Me.rerouteExitButton.Text = "EXIT"
        '
        'Label17
        '
        Me.Label17.Font = New System.Drawing.Font("Arial", 11.25!, System.Drawing.FontStyle.Italic)
        Me.Label17.Location = New System.Drawing.Point(56, 11)
        Me.Label17.Size = New System.Drawing.Size(127, 16)
        Me.Label17.Text = "Process Reroute"
        Me.Label17.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'Label23
        '
        Me.Label23.Font = New System.Drawing.Font("Courier New", 8.25!, System.Drawing.FontStyle.Bold)
        Me.Label23.Location = New System.Drawing.Point(5, 82)
        Me.Label23.Size = New System.Drawing.Size(222, 17)
        Me.Label23.Text = "               ID    dst/flgt"
        '
        'rerouteLabel1
        '
        Me.rerouteLabel1.Font = New System.Drawing.Font("Courier New", 8.25!, System.Drawing.FontStyle.Bold)
        Me.rerouteLabel1.Location = New System.Drawing.Point(4, 71)
        Me.rerouteLabel1.Size = New System.Drawing.Size(225, 17)
        Me.rerouteLabel1.Text = "org dst flgt  cart     new"
        '
        'Label1
        '
        Me.Label1.Font = New System.Drawing.Font("Arial", 11.25!, System.Drawing.FontStyle.Regular)
        Me.Label1.Location = New System.Drawing.Point(35, 39)
        Me.Label1.Size = New System.Drawing.Size(169, 16)
        Me.Label1.Text = "Current Preset Record"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'presetRecordLabel
        '
        Me.presetRecordLabel.Font = New System.Drawing.Font("Courier New", 8.25!, System.Drawing.FontStyle.Regular)
        Me.presetRecordLabel.Location = New System.Drawing.Point(2, 99)
        Me.presetRecordLabel.Size = New System.Drawing.Size(138, 11)
        '
        'Label2
        '
        Me.Label2.Location = New System.Drawing.Point(21, 149)
        Me.Label2.Size = New System.Drawing.Size(83, 28)
        Me.Label2.Text = "New Destination"
        Me.Label2.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'mailDestinationComboBox
        '
        Me.mailDestinationComboBox.Location = New System.Drawing.Point(36, 188)
        Me.mailDestinationComboBox.Size = New System.Drawing.Size(53, 22)
        '
        'Label3
        '
        Me.Label3.Location = New System.Drawing.Point(125, 149)
        Me.Label3.Size = New System.Drawing.Size(83, 28)
        Me.Label3.Text = "New Flight Number"
        Me.Label3.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'flightNumberTextBox
        '
        Me.flightNumberTextBox.Location = New System.Drawing.Point(141, 189)
        Me.flightNumberTextBox.Size = New System.Drawing.Size(49, 22)
        Me.flightNumberTextBox.Text = "TextBox1"
        '
        'clearRerouteButton
        '
        Me.clearRerouteButton.Location = New System.Drawing.Point(11, 221)
        Me.clearRerouteButton.Size = New System.Drawing.Size(69, 34)
        Me.clearRerouteButton.Text = "CLEAR"
        '
        'newInfoLabel
        '
        Me.newInfoLabel.Font = New System.Drawing.Font("Courier New", 8.25!, System.Drawing.FontStyle.Regular)
        Me.newInfoLabel.Location = New System.Drawing.Point(152, 98)
        Me.newInfoLabel.Size = New System.Drawing.Size(60, 12)
        Me.newInfoLabel.Text = "Label4"
        '
        'keyboardIcon
        '
        Me.keyboardIcon.Location = New System.Drawing.Point(13, 267)
        Me.keyboardIcon.Size = New System.Drawing.Size(23, 16)
        '
        'rerouteForm
        '
        Me.ClientSize = New System.Drawing.Size(257, 399)
        Me.Controls.Add(Me.keyboardIcon)
        Me.Controls.Add(Me.newInfoLabel)
        Me.Controls.Add(Me.clearRerouteButton)
        Me.Controls.Add(Me.flightNumberTextBox)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.mailDestinationComboBox)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.presetRecordLabel)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.Label23)
        Me.Controls.Add(Me.rerouteLabel1)
        Me.Controls.Add(Me.Label17)
        Me.Controls.Add(Me.rerouteExitButton)
        Me.Controls.Add(Me.applyButton)
        Me.Text = "Process Reroute"

    End Sub

#End Region

    Private Sub formOnLoad(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        If lockDown Then
            MyBase.MaximizeBox = False
            MyBase.MinimizeBox = False
            MyBase.ControlBox = False
            MyBase.WindowState = FormWindowState.Maximized
        End If

    End Sub

    Private Sub rerouteExitButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rerouteExitButton.Click
        'readerDisplayForm.updateExpiredPresetsInListBox()
        Me.Close()
    End Sub

    Private Sub applyButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles applyButton.Click

        If Not isNonNullString(flightNumberTextBox.Text) And Not isNonNullString(mailDestinationComboBox.Text) Then
            clearRerouteButton_Click(Nothing, Nothing)
            Exit Sub
        End If

        If Not isValidFlightNumber(flightNumberTextBox.Text) Then
            MsgBox("A Valid Flight Number Must Be Specified For Reroute", MsgBoxStyle.Exclamation, "Invalid Flight Number")
            Exit Sub
        End If

        If Not isValidLocation(mailDestinationComboBox.Text) Then
            MsgBox("A Valid Location Must Be Specified For Reroute", MsgBoxStyle.Exclamation, "Invalid Location")
            Exit Sub
        End If

        Dim newflightNumber As Integer = CInt(flightNumberTextBox.Text)
        Dim presetFlightNumber As Integer = CInt(presetRecord.flightNumber)

        If newflightNumber = presetFlightNumber And mailDestinationComboBox.Text = presetRecord.destination Then
            clearRerouteButton_Click(Nothing, Nothing)
            Exit Sub
        End If

        presetRecord.newFlightNumber = Trim(flightNumberTextBox.Text).PadLeft(4, "0")
        presetRecord.newDestination = mailDestinationComboBox.Text

        presetRecordLabel.Text = presetRecord.formatForListBox
        newInfoLabel.Text = presetRecord.newDestination.PadRight(3) & "/" & presetRecord.newFlightNumber.PadRight(4)

        presetRecord.presetCreationDateAndTime = DateTime.UtcNow()

    End Sub

    Private Sub clearRerouteButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles clearRerouteButton.Click

        presetRecord.newDestination = ""
        presetRecord.newFlightNumber = ""

        mailDestinationComboBox.SelectedItem = presetRecord.destination
        flightNumberTextBox.Text = presetRecord.flightNumber.PadLeft(4, "0")

        presetRecordLabel.Text = presetRecord.formatForListBox
        newInfoLabel.Text = presetRecord.newDestination.PadRight(3) & "/" & presetRecord.newFlightNumber.PadRight(4)
    End Sub

    'Private Sub formKeyPress(ByVal sender As System.Object, ByVal ex As KeyPressEventArgs) Handles MyBase.KeyPress

        'If ex.KeyChar = "0" Then
        '    exitString = ""
        '    Exit Sub
        'End If

        'exitString &= ex.KeyChar

        'If isValidExitPassword(exitString) Then
        '    appExitFlag.exitFlag = True
        '    Me.Close()
        'End If

    'End Sub

End Class
