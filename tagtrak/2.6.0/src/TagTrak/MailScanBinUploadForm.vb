Public Class MailScanBinUploadForm
    Inherits System.Windows.Forms.Form
    Friend WithEvents binUploadDestinationComboBox As System.Windows.Forms.ComboBox
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents Label14 As System.Windows.Forms.Label
    Friend WithEvents binUploadFlightNumberTextBox As System.Windows.Forms.TextBox
    Friend WithEvents binUploadOKButton As System.Windows.Forms.Button
    Friend WithEvents binUploadLabel As System.Windows.Forms.Label
    Friend WithEvents binUploadBinIDTextBox As System.Windows.Forms.TextBox

    Private curScanType As String = ""


#Region " Windows Form Designer generated code "

    Public Sub New()
        MyBase.New()

        'This call is required by the Windows Form Designer.
        InitializeComponent()


    End Sub

    Public Sub init(ByRef MailScanDomsForm As MailScanDomsForm)

        curScanType = "M"

        'Changed by MX 9/14
        Util.LoadComboBoxFromList(binUploadDestinationComboBox, userSpecRecord.cityList)
        binUploadDestinationComboBox.Items.Insert(0, "")

        If userSpecRecord.userName = "ATA" Then

            binUploadLabel.Text = "Cart ID"

        End If

        If isNonNullString(MailScanDomsForm.flightNumberTextBox.Text) Then
            binUploadFlightNumberTextBox.Text = MailScanDomsForm.flightNumberTextBox.Text.PadLeft(4, "0")
        Else
            binUploadFlightNumberTextBox.Text = ""
        End If

        If isNonNullString(MailScanDomsForm.mailDestinationComboBox.Text) Then
            binUploadDestinationComboBox.Text = MailScanDomsForm.mailDestinationComboBox.Text
        Else
            binUploadDestinationComboBox.Text = ""
        End If

        If isNonNullString(MailScanDomsForm.groupNumberTextBox.Text) Then
            binUploadBinIDTextBox.Text = MailScanDomsForm.groupNumberTextBox.Text
        Else
            binUploadBinIDTextBox.Text = ""
        End If

    End Sub

    Public Sub init(ByRef MailScanIntlForm As MailScanIntlForm)

        curScanType = "I"

        'Changed by MX 9/14
        Util.LoadComboBoxFromList(binUploadDestinationComboBox, userSpecRecord.cityList)
        binUploadDestinationComboBox.Items.Insert(0, "")

        If userSpecRecord.userName = "ATA" Then

            binUploadLabel.Text = "Cart ID"

        End If

        If isNonNullString(MailScanIntlForm.tbxFlightNumber.Text) Then
            binUploadFlightNumberTextBox.Text = MailScanIntlForm.tbxFlightNumber.Text.PadLeft(4, "0")
        Else
            binUploadFlightNumberTextBox.Text = ""
        End If

        If isNonNullString(MailScanIntlForm.cbxDestination.Text) Then
            binUploadDestinationComboBox.Text = MailScanIntlForm.cbxDestination.Text
        Else
            binUploadDestinationComboBox.Text = ""
        End If

        If isNonNullString(MailScanIntlForm.tbxCartID.Text) Then
            binUploadBinIDTextBox.Text = MailScanIntlForm.tbxCartID.Text
        Else
            binUploadBinIDTextBox.Text = ""
        End If

    End Sub

    Public Sub init(ByRef MailScanIntlForm As MailScanIntlSimpleForm)

        curScanType = "I"

        'Changed by MX 9/14
        Util.LoadComboBoxFromList(binUploadDestinationComboBox, userSpecRecord.cityList)
        binUploadDestinationComboBox.Items.Insert(0, "")

        If userSpecRecord.userName = "ATA" Then

            binUploadLabel.Text = "Cart ID"

        End If

        binUploadFlightNumberTextBox.Text = ""

        binUploadDestinationComboBox.Text = ""

        If isNonNullString(MailScanIntlForm.tbxCartID.Text) Then
            binUploadBinIDTextBox.Text = MailScanIntlForm.tbxCartID.Text
        Else
            binUploadBinIDTextBox.Text = ""
        End If

    End Sub

    Protected Overloads Overrides Sub Dispose(ByVal disposing As Boolean)
        MyBase.Dispose(disposing)
    End Sub

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    Friend WithEvents binUploadCancelButton As System.Windows.Forms.Button
    Friend WithEvents MainMenu1 As System.Windows.Forms.MainMenu
#If deviceType <> "PC" Then
    Friend WithEvents InputPanel1 As Microsoft.WindowsCE.Forms.InputPanel
#End If
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.binUploadDestinationComboBox = New System.Windows.Forms.ComboBox
        Me.Label13 = New System.Windows.Forms.Label
        Me.Label14 = New System.Windows.Forms.Label
        Me.binUploadFlightNumberTextBox = New System.Windows.Forms.TextBox
        Me.binUploadCancelButton = New System.Windows.Forms.Button
        Me.binUploadOKButton = New System.Windows.Forms.Button
        Me.binUploadLabel = New System.Windows.Forms.Label
        Me.binUploadBinIDTextBox = New System.Windows.Forms.TextBox
        Me.MainMenu1 = New System.Windows.Forms.MainMenu
#If devicetype <> "PC" Then
        Me.InputPanel1 = New Microsoft.WindowsCE.Forms.InputPanel
#End If
        '
        'binUploadDestinationComboBox
        '
        Me.binUploadDestinationComboBox.Location = New System.Drawing.Point(111, 88)
        Me.binUploadDestinationComboBox.Size = New System.Drawing.Size(72, 22)
        '
        'Label13
        '
        Me.Label13.Location = New System.Drawing.Point(17, 88)
        Me.Label13.Size = New System.Drawing.Size(84, 17)
        Me.Label13.Text = "Destination"
        '
        'Label14
        '
        Me.Label14.Location = New System.Drawing.Point(17, 56)
        Me.Label14.Size = New System.Drawing.Size(84, 17)
        Me.Label14.Text = "Flight Number"
        '
        'binUploadFlightNumberTextBox
        '
        Me.binUploadFlightNumberTextBox.Location = New System.Drawing.Point(111, 48)
        Me.binUploadFlightNumberTextBox.Size = New System.Drawing.Size(95, 22)
        Me.binUploadFlightNumberTextBox.Text = ""
        '
        'binUploadCancelButton
        '
        Me.binUploadCancelButton.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold)
        Me.binUploadCancelButton.Location = New System.Drawing.Point(111, 128)
        Me.binUploadCancelButton.Size = New System.Drawing.Size(80, 29)
        Me.binUploadCancelButton.Text = "Cancel"
        '
        'binUploadOKButton
        '
        Me.binUploadOKButton.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold)
        Me.binUploadOKButton.Location = New System.Drawing.Point(21, 128)
        Me.binUploadOKButton.Size = New System.Drawing.Size(80, 29)
        Me.binUploadOKButton.Text = "OK"
        '
        'binUploadLabel
        '
        Me.binUploadLabel.Location = New System.Drawing.Point(17, 24)
        Me.binUploadLabel.Size = New System.Drawing.Size(84, 17)
        Me.binUploadLabel.Text = "Cart ID"
        '
        'binUploadBinIDTextBox
        '
        Me.binUploadBinIDTextBox.Location = New System.Drawing.Point(111, 16)
        Me.binUploadBinIDTextBox.Size = New System.Drawing.Size(95, 22)
        Me.binUploadBinIDTextBox.Text = ""
        '
        'MailScanBinUploadForm
        '
        Me.ClientSize = New System.Drawing.Size(234, 328)
        Me.ControlBox = False
        Me.Controls.Add(Me.binUploadDestinationComboBox)
        Me.Controls.Add(Me.Label13)
        Me.Controls.Add(Me.Label14)
        Me.Controls.Add(Me.binUploadFlightNumberTextBox)
        Me.Controls.Add(Me.binUploadCancelButton)
        Me.Controls.Add(Me.binUploadOKButton)
        Me.Controls.Add(Me.binUploadLabel)
        Me.Controls.Add(Me.binUploadBinIDTextBox)
        Me.Menu = Me.MainMenu1
        Me.Text = "Create Cart Upload Record"

    End Sub

#End Region

    Private Sub binUploadOKButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles binUploadOKButton.Click

        If Not isNonNullString(binUploadFlightNumberTextBox.Text) Then
            MsgBox("A valid flight number must be specified to create a Cart upload record.", MsgBoxStyle.Exclamation, "Missing Flight Number")
            Exit Sub
        End If

        If Not Util.isValidBatchID(binUploadBinIDTextBox.Text) Then
            MsgBox("Invalid Cart ID", MsgBoxStyle.Exclamation, "Invalid Cart ID")
            Exit Sub
        End If

        If Not Util.isValidFlightNumber(binUploadFlightNumberTextBox.Text) Then

            MsgBox("Invalid Flight Number", MsgBoxStyle.Exclamation, "Invalid Flight Number")
            Exit Sub

        End If

        If Not Util.isValidLocation(Me.binUploadDestinationComboBox.Text) Then

            MsgBox("A valid destination must be specified", MsgBoxStyle.Exclamation, "Invalid Destination")
            Exit Sub

        End If

        Dim binUploadRecord As New binUploadRecordClass(binUploadBinIDTextBox.Text, binUploadFlightNumberTextBox.Text, binUploadDestinationComboBox.Text, curScanType)

        Dim result As String

        result = binUploadRecord.write(binUploadFilePath)
        userSpecRecord.scanRecordSet.TimeZoneUsed.OffsetUTC = scannerTimeZone.OffsetInfo.OffsetUTC

        If result <> "OK" Then

            MsgBox("Write of cart upload record failed: " & result, MsgBoxStyle.Exclamation, "Write Of Cart Upload Record Failed")

            Exit Sub

        End If

        MsgBox("New Cart Upload Record Created", MsgBoxStyle.Information, "New Cart Upload Record Created")

        binUploadBinIDTextBox.Text = ""

        Me.Hide()

    End Sub


    Private Sub binUploadCancelButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles binUploadCancelButton.Click

        binUploadBinIDTextBox.Text = ""

        Me.Hide()

    End Sub

    'Private Sub binUploadOKButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles binUploadOKButton.Click

    '    Me.processBinUploadOKButtonClick()

    'End Sub

    'Private Sub binUploadCancelButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles binUploadCancelButton.Click

    '    Me.processBinUploadCancelButtonClick()

    'End Sub

End Class
