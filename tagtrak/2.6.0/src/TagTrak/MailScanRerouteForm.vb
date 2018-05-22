Public Class MailScanRerouteForm
    Inherits System.Windows.Forms.Form
    Friend WithEvents rerouteExitButton As System.Windows.Forms.Button

    Public presetRecord As presetRecordClass

    Dim mailScanDomsForm As mailScanDomsForm
    Dim mailScanIntlForm As mailScanIntlForm

    Private curProgType As Char

#Region " Windows Form Designer generated code "

    Public Sub New()

        MyBase.New()

        InitializeComponent()

    End Sub

    Public Sub init(ByRef inputMailScanDomsForm As mailScanDomsForm, ByRef inputPresetRecord As presetRecordClass)
        curProgType = "M"c

        mailScanDomsForm = inputMailScanDomsForm
        mailScanIntlForm = Nothing

        presetRecord = inputPresetRecord

        Util.LoadComboBoxFromList(mailDestinationComboBox, userSpecRecord.cityList)

        mailDestinationComboBox.Items.Insert(0, "")

        presetRecordLabel.Text = presetRecord.formatForListBox

        newInfoLabel.Text = presetRecord.newDestination.PadRight(3) & "/" & presetRecord.newFlightNumber.PadRight(4)

        If presetRecord.isReroutePreset Then
            flightNumberTextBox.Text = presetRecord.newFlightNumber.PadLeft(4, "0")
            mailDestinationComboBox.SelectedItem = presetRecord.newDestination
            txtCartID.Text = presetRecord.batchID
        Else
            flightNumberTextBox.Text = presetRecord.flightNumber.PadLeft(4, "0")
            mailDestinationComboBox.SelectedItem = presetRecord.destination
            txtCartID.Text = presetRecord.batchID
        End If

        'Add any initialization after the InitializeComponent() call

        If user = "TZ" Or user = "US" Then
            rerouteLabel1.Text = "org dst flgt  cart      new"
        End If

    End Sub

    Public Sub init(ByRef inputMailScanIntlForm As MailScanIntlForm, ByRef inputPresetRecord As presetRecordClass)
        curProgType = "I"c

        mailScanDomsForm = Nothing
        mailScanIntlForm = inputMailScanIntlForm

        presetRecord = inputPresetRecord

        Util.LoadComboBoxFromList(mailDestinationComboBox, userSpecRecord.cityList)

        mailDestinationComboBox.Items.Insert(0, "")

        presetRecordLabel.Text = presetRecord.formatForListBox

        newInfoLabel.Text = presetRecord.newDestination.PadRight(3) & "/" & presetRecord.newFlightNumber.PadRight(4)

        If presetRecord.isReroutePreset Then
            flightNumberTextBox.Text = presetRecord.newFlightNumber.PadLeft(4, "0")
            mailDestinationComboBox.SelectedItem = presetRecord.newDestination
            txtCartID.Text = presetRecord.batchID
        Else
            flightNumberTextBox.Text = presetRecord.flightNumber.PadLeft(4, "0")
            mailDestinationComboBox.SelectedItem = presetRecord.destination
            txtCartID.Text = presetRecord.batchID
        End If

        'Add any initialization after the InitializeComponent() call

        If user = "TZ" Or user = "US" Then
            rerouteLabel1.Text = "org dst flgt  cart      new"
        End If

    End Sub

    Protected Overloads Overrides Sub Dispose(ByVal disposing As Boolean)
        MyBase.Dispose(disposing)
    End Sub

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
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
    Friend WithEvents MainMenu1 As System.Windows.Forms.MainMenu
#If deviceType <> "PC" Then
    Friend WithEvents InputPanel1 As Microsoft.WindowsCE.Forms.InputPanel
#End If
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents txtCartID As System.Windows.Forms.TextBox
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.applyButton = New System.Windows.Forms.Button
        Me.rerouteExitButton = New System.Windows.Forms.Button
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
        Me.MainMenu1 = New System.Windows.Forms.MainMenu
#If deviceType <> "PC" Then
        Me.InputPanel1 = New Microsoft.WindowsCE.Forms.InputPanel
#End If
        Me.txtCartID = New System.Windows.Forms.TextBox
        Me.Label4 = New System.Windows.Forms.Label
        '
        'applyButton
        '
        Me.applyButton.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold)
        Me.applyButton.Location = New System.Drawing.Point(82, 192)
        Me.applyButton.Size = New System.Drawing.Size(69, 26)
        Me.applyButton.Text = "Apply"
        '
        'rerouteExitButton
        '
        Me.rerouteExitButton.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold)
        Me.rerouteExitButton.Location = New System.Drawing.Point(153, 192)
        Me.rerouteExitButton.Size = New System.Drawing.Size(69, 26)
        Me.rerouteExitButton.Text = "Exit"
        '
        'Label23
        '
        Me.Label23.Font = New System.Drawing.Font("Courier New", 8.25!, System.Drawing.FontStyle.Bold)
        Me.Label23.Location = New System.Drawing.Point(5, 48)
        Me.Label23.Size = New System.Drawing.Size(222, 17)
        Me.Label23.Text = "               ID    dst/flgt"
        '
        'rerouteLabel1
        '
        Me.rerouteLabel1.Font = New System.Drawing.Font("Courier New", 8.25!, System.Drawing.FontStyle.Bold)
        Me.rerouteLabel1.Location = New System.Drawing.Point(4, 32)
        Me.rerouteLabel1.Size = New System.Drawing.Size(225, 17)
        Me.rerouteLabel1.Text = "org dst flgt  cart     new"
        '
        'Label1
        '
        Me.Label1.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Regular)
        Me.Label1.Location = New System.Drawing.Point(33, 8)
        Me.Label1.Size = New System.Drawing.Size(169, 16)
        Me.Label1.Text = "Current Preset Record"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'presetRecordLabel
        '
        Me.presetRecordLabel.Font = New System.Drawing.Font("Courier New", 8.25!, System.Drawing.FontStyle.Regular)
        Me.presetRecordLabel.Location = New System.Drawing.Point(2, 64)
        Me.presetRecordLabel.Size = New System.Drawing.Size(138, 11)
        '
        'Label2
        '
        Me.Label2.Location = New System.Drawing.Point(8, 104)
        Me.Label2.Size = New System.Drawing.Size(67, 32)
        Me.Label2.Text = "New Destination"
        Me.Label2.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'mailDestinationComboBox
        '
        Me.mailDestinationComboBox.Location = New System.Drawing.Point(16, 144)
        Me.mailDestinationComboBox.Size = New System.Drawing.Size(56, 22)
        '
        'Label3
        '
        Me.Label3.Location = New System.Drawing.Point(160, 104)
        Me.Label3.Size = New System.Drawing.Size(67, 32)
        Me.Label3.Text = "New Flight Number"
        Me.Label3.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'flightNumberTextBox
        '
        Me.flightNumberTextBox.Location = New System.Drawing.Point(168, 144)
        Me.flightNumberTextBox.Size = New System.Drawing.Size(49, 22)
        Me.flightNumberTextBox.Text = ""
        '
        'clearRerouteButton
        '
        Me.clearRerouteButton.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold)
        Me.clearRerouteButton.Location = New System.Drawing.Point(11, 192)
        Me.clearRerouteButton.Size = New System.Drawing.Size(69, 26)
        Me.clearRerouteButton.Text = "Clear"
        '
        'newInfoLabel
        '
        Me.newInfoLabel.Font = New System.Drawing.Font("Courier New", 8.25!, System.Drawing.FontStyle.Regular)
        Me.newInfoLabel.Location = New System.Drawing.Point(152, 64)
        Me.newInfoLabel.Size = New System.Drawing.Size(60, 12)
        Me.newInfoLabel.Text = "Label4"
        '
        'txtCartID
        '
        Me.txtCartID.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular)
        Me.txtCartID.Location = New System.Drawing.Point(96, 144)
        Me.txtCartID.Size = New System.Drawing.Size(49, 22)
        Me.txtCartID.Text = ""
        '
        'Label4
        '
        Me.Label4.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular)
        Me.Label4.Location = New System.Drawing.Point(88, 104)
        Me.Label4.Size = New System.Drawing.Size(67, 32)
        Me.Label4.Text = "New Cart ID"
        Me.Label4.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'MailScanRerouteForm
        '
        Me.ClientSize = New System.Drawing.Size(234, 288)
        Me.ControlBox = False
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.txtCartID)
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
        Me.Controls.Add(Me.rerouteExitButton)
        Me.Controls.Add(Me.applyButton)
        Me.Menu = Me.MainMenu1
        Me.Text = "Process Reroute"

    End Sub

#End Region

    Private Sub rerouteExitButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rerouteExitButton.Click
        'mailScanDomsForm.updateExpiredPresetsInListBox()
        Me.Close()
    End Sub

    Private Sub applyButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles applyButton.Click

        'Modified by MX
        If Not isNonNullString(flightNumberTextBox.Text) And Not isNonNullString(mailDestinationComboBox.Text) _
        And Not isNonNullString(txtCartID.Text) Then
            clearRerouteButton_Click(Nothing, Nothing)
            Exit Sub
        End If

        If Not Util.isValidFlightNumber(flightNumberTextBox.Text) Then
            MsgBox("A Valid Flight Number Must Be Specified For Reroute", MsgBoxStyle.Exclamation, "Invalid Flight Number")
            Exit Sub
        End If

        If Not Util.isValidLocation(mailDestinationComboBox.Text) Then
            MsgBox("A Valid Location Must Be Specified For Reroute", MsgBoxStyle.Exclamation, "Invalid Location")
            Exit Sub
        End If

        'Added by MX
        If Not Util.isValidBatchID(txtCartID.Text) Then
            MsgBox("A Valid Cart ID Must Be Specified For Reroute", MsgBoxStyle.Exclamation, "Invalid Cart ID")
            Exit Sub
        End If

        Dim newflightNumber As Integer = CInt(flightNumberTextBox.Text)
        Dim presetFlightNumber As Integer = CInt(presetRecord.flightNumber)

        'Modified by MX
        If newflightNumber = presetFlightNumber And mailDestinationComboBox.Text = presetRecord.destination _
        And Trim(txtCartID.Text) = Trim(presetRecord.batchID) Then
            clearRerouteButton_Click(Nothing, Nothing)
            Exit Sub
        End If

        'Added by MX
        If presetRecord.batchID <> txtCartID.Text Then
            SaveBinChange(presetRecord.batchID, txtCartID.Text, flightNumberTextBox.Text, presetRecord.origin, Me.curProgType)
        End If

        presetRecord.newFlightNumber = Trim(flightNumberTextBox.Text).PadLeft(4, "0")
        presetRecord.newDestination = mailDestinationComboBox.Text
        'Added by MX
        presetRecord.batchID = Trim(txtCartID.Text)

        presetRecordLabel.Text = presetRecord.formatForListBox
        newInfoLabel.Text = presetRecord.newDestination.PadRight(3) & "/" & presetRecord.newFlightNumber.PadRight(4)

        presetRecord.presetCreationDateAndTime = DateTime.UtcNow()

    End Sub

    Private Sub clearRerouteButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles clearRerouteButton.Click

        presetRecord.newDestination = ""
        presetRecord.newFlightNumber = ""

        mailDestinationComboBox.SelectedItem = presetRecord.destination
        flightNumberTextBox.Text = presetRecord.flightNumber.PadLeft(4, "0")
        'Added by MX
        txtCartID.Text = presetRecord.batchID

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

    Private Sub flightNumberTextBox_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles flightNumberTextBox.GotFocus
#If deviceType <> "PC" Then
        If userSpecRecord.showKeyboardOnFocus Then Me.InputPanel1.Enabled = True
#End If
    End Sub

End Class
