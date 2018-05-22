Public Class binUploadForm
    Inherits System.Windows.Forms.Form
    Friend WithEvents binUploadDestinationComboBox As System.Windows.Forms.ComboBox
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents Label14 As System.Windows.Forms.Label
    Friend WithEvents binUploadFlightNumberTextBox As System.Windows.Forms.TextBox
    Friend WithEvents binUploadOKButton As System.Windows.Forms.Button
    Friend WithEvents binUploadLabel As System.Windows.Forms.Label
    Friend WithEvents binUploadBinIDTextBox As System.Windows.Forms.TextBox
    Friend WithEvents binUploadHeaderLabel As System.Windows.Forms.Label

#Region " Windows Form Designer generated code "

    Public Sub New(ByRef scanFormMail As scanFormMail)
        MyBase.New()

        'This call is required by the Windows Form Designer.
        InitializeComponent()

        loadDestinationComboBox(binUploadDestinationComboBox, userSpecRecord.airportLocationList)
        binUploadDestinationComboBox.Items.Insert(0, "")

        If userSpecRecord.userName = "ATA" Then

            binUploadHeaderLabel.Text = "Create Cart Upload Record"
            binUploadLabel.Text = "Cart ID"

        End If

        If isNonNullString(scanFormMail.flightNumberTextBox.Text) Then
            binUploadFlightNumberTextBox.Text = scanFormMail.flightNumberTextBox.Text.PadLeft(4, "0")
        Else
            binUploadFlightNumberTextBox.Text = ""
        End If

        If isNonNullString(scanFormMail.mailDestinationComboBox.Text) Then
            binUploadDestinationComboBox.Text = scanFormMail.mailDestinationComboBox.Text
        Else
            binUploadDestinationComboBox.Text = ""
        End If

        If isNonNullString(scanFormMail.groupNumberTextBox.Text) Then
            binUploadBinIDTextBox.Text = scanFormMail.groupNumberTextBox.Text
        Else
            binUploadBinIDTextBox.Text = ""
        End If

        'Add any initialization after the InitializeComponent() call

        setupKeyboard()

    End Sub

    Dim keyboard As keyboardClass

    Private Sub setupKeyboard()

        Dim textBoxList() As System.windows.forms.TextBox = { _
            binUploadBinIDTextBox, _
            binUploadFlightNumberTextBox}

        keyboard = New keyboardClass(Me, textBoxList, keyboardIcon, AddressOf binUploadOKButton_Click)

    End Sub

    Protected Overloads Overrides Sub Dispose(ByVal disposing As Boolean)
        MyBase.Dispose(disposing)
    End Sub

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    Friend WithEvents binUploadCancelButton As System.Windows.Forms.Button
    Friend WithEvents keyboardIcon As System.Windows.Forms.PictureBox
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.binUploadDestinationComboBox = New System.Windows.Forms.ComboBox
        Me.Label13 = New System.Windows.Forms.Label
        Me.Label14 = New System.Windows.Forms.Label
        Me.binUploadFlightNumberTextBox = New System.Windows.Forms.TextBox
        Me.binUploadCancelButton = New System.Windows.Forms.Button
        Me.binUploadOKButton = New System.Windows.Forms.Button
        Me.binUploadLabel = New System.Windows.Forms.Label
        Me.binUploadBinIDTextBox = New System.Windows.Forms.TextBox
        Me.binUploadHeaderLabel = New System.Windows.Forms.Label
        Me.keyboardIcon = New System.Windows.Forms.PictureBox
        '
        'binUploadDestinationComboBox
        '
        Me.binUploadDestinationComboBox.Location = New System.Drawing.Point(105, 134)
        Me.binUploadDestinationComboBox.Size = New System.Drawing.Size(72, 22)
        '
        'Label13
        '
        Me.Label13.Location = New System.Drawing.Point(20, 137)
        Me.Label13.Size = New System.Drawing.Size(71, 17)
        Me.Label13.Text = "Destination"
        '
        'Label14
        '
        Me.Label14.Location = New System.Drawing.Point(20, 103)
        Me.Label14.Size = New System.Drawing.Size(84, 17)
        Me.Label14.Text = "Flight Number"
        '
        'binUploadFlightNumberTextBox
        '
        Me.binUploadFlightNumberTextBox.Location = New System.Drawing.Point(105, 100)
        Me.binUploadFlightNumberTextBox.Size = New System.Drawing.Size(127, 22)
        Me.binUploadFlightNumberTextBox.Text = ""
        '
        'binUploadCancelButton
        '
        Me.binUploadCancelButton.Location = New System.Drawing.Point(111, 178)
        Me.binUploadCancelButton.Size = New System.Drawing.Size(80, 29)
        Me.binUploadCancelButton.Text = "Cancel"
        '
        'binUploadOKButton
        '
        Me.binUploadOKButton.Location = New System.Drawing.Point(21, 178)
        Me.binUploadOKButton.Size = New System.Drawing.Size(80, 29)
        Me.binUploadOKButton.Text = "OK"
        '
        'binUploadLabel
        '
        Me.binUploadLabel.Location = New System.Drawing.Point(20, 69)
        Me.binUploadLabel.Size = New System.Drawing.Size(80, 17)
        Me.binUploadLabel.Text = "Cart ID"
        '
        'binUploadBinIDTextBox
        '
        Me.binUploadBinIDTextBox.Location = New System.Drawing.Point(105, 66)
        Me.binUploadBinIDTextBox.Size = New System.Drawing.Size(127, 22)
        Me.binUploadBinIDTextBox.Text = ""
        '
        'binUploadHeaderLabel
        '
        Me.binUploadHeaderLabel.Font = New System.Drawing.Font("Tahoma", 14.25!, System.Drawing.FontStyle.Italic)
        Me.binUploadHeaderLabel.Location = New System.Drawing.Point(10, 25)
        Me.binUploadHeaderLabel.Size = New System.Drawing.Size(235, 28)
        Me.binUploadHeaderLabel.Text = "Create Cart Upload Record"
        Me.binUploadHeaderLabel.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'keyboardIcon
        '
        Me.keyboardIcon.Location = New System.Drawing.Point(201, 184)
        Me.keyboardIcon.Size = New System.Drawing.Size(23, 16)
        '
        'binUploadForm
        '
        Me.ClientSize = New System.Drawing.Size(253, 329)
        Me.Controls.Add(Me.keyboardIcon)
        Me.Controls.Add(Me.binUploadDestinationComboBox)
        Me.Controls.Add(Me.Label13)
        Me.Controls.Add(Me.Label14)
        Me.Controls.Add(Me.binUploadFlightNumberTextBox)
        Me.Controls.Add(Me.binUploadCancelButton)
        Me.Controls.Add(Me.binUploadOKButton)
        Me.Controls.Add(Me.binUploadLabel)
        Me.Controls.Add(Me.binUploadBinIDTextBox)
        Me.Controls.Add(Me.binUploadHeaderLabel)
        Me.Text = "BinUploadForm"

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

    Private Sub processBinUploadOKButtonClick()

        If Not isNonNullString(binUploadFlightNumberTextBox.Text) Then
            MsgBox("A valid flight number must be specified to create a Cart upload record.", MsgBoxStyle.Exclamation, "Missing Flight Number")
            Exit Sub
        End If

        If Not isValidBatchID(binUploadBinIDTextBox.Text) Then
            If user = "ATA" Or user = "USAirways" Then
                MsgBox("Invalid Cart ID", MsgBoxStyle.Exclamation, "Invalid Cart ID")
            Else
                MsgBox("Invalid Cart ID", MsgBoxStyle.Exclamation, "Invalid Cart ID")
            End If
            Exit Sub
        End If

        If Not isValidFlightNumber(binUploadFlightNumberTextBox.Text) Then

            MsgBox("Invalid Flight Number", MsgBoxStyle.Exclamation, "Invalid Flight Number")
            Exit Sub

        End If

        If Not isValidLocation(Me.binUploadDestinationComboBox.Text) Then

            MsgBox("A valid destination must be specified", MsgBoxStyle.Exclamation, "Invalid Destination")
            Exit Sub

        End If

        Dim binUploadRecord As New binUploadRecordClass(binUploadBinIDTextBox.Text, binUploadFlightNumberTextBox.Text, binUploadDestinationComboBox.Text)

        Dim result As String

        result = binUploadRecord.write(binUploadFilePath)

        If result <> "OK" Then

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

        binUploadBinIDTextBox.Text = ""

    End Sub


    Private Sub processBinUploadCancelButtonClick()

        binUploadBinIDTextBox.Text = ""

        Me.Close()

    End Sub

    Private Sub binUploadOKButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles binUploadOKButton.Click

        Me.processBinUploadOKButtonClick()
        keyboard.hide()
        Me.Close()

    End Sub

    Private Sub binUploadCancelButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles binUploadCancelButton.Click

        Me.processBinUploadCancelButtonClick()
        Me.Close()

    End Sub

    Private Sub binUploadForm_KeyPress(ByVal sender As System.Object, ByVal e As KeyPressEventArgs) _
            Handles binUploadBinIDTextBox.KeyPress, binUploadFlightNumberTextBox.KeyPress

        If e.KeyChar = tabKeyChar Then
            keyboard.processTabRoutine(sender)
        End If

    End Sub

End Class
