Imports System
Imports System.io

Public Class MailScanBinChangeForm
    Inherits System.Windows.Forms.Form
    Friend WithEvents binChangeLocationLabel As System.Windows.Forms.Label
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents binChangeFlightNumberTextBox As System.Windows.Forms.TextBox
    Friend WithEvents OKButton As System.Windows.Forms.Button
    Friend WithEvents newBinLabel As System.Windows.Forms.Label
    Friend WithEvents oldBinLabel As System.Windows.Forms.Label
    Friend WithEvents newBinTextBox As System.Windows.Forms.TextBox
    Friend WithEvents oldBinTextBox As System.Windows.Forms.TextBox

    Private curProgType As Char

#Region " Windows Form Designer generated code "

    Public Sub New()
        MyBase.New()

        'This call is required by the Windows Form Designer.
        InitializeComponent()

    End Sub

    Public Sub init(ByRef MailScanDomsForm As MailScanDomsForm)
        curProgType = "M"c

        If userSpecRecord.userName = "ATA" Then
            oldBinLabel.Text = "Old Cart ID"
            newBinLabel.Text = "New Cart ID"
        End If

        If isNonNullString(MailScanDomsForm.flightNumberTextBox.Text) Then
            binChangeFlightNumberTextBox.Text = MailScanDomsForm.flightNumberTextBox.Text.PadLeft(4, "0")
        Else
            binChangeFlightNumberTextBox.Text = ""
        End If

        binChangeLocationLabel.Text = Substring(scanLocation.currentLocation, 0, 3)

    End Sub

    Public Sub init(ByRef MailScanIntlForm As MailScanIntlForm)
        curProgType = "I"c

        If userSpecRecord.userName = "ATA" Then
            oldBinLabel.Text = "Old Cart ID"
            newBinLabel.Text = "New Cart ID"
        End If

        If isNonNullString(MailScanIntlForm.tbxFlightNumber.Text) Then
            binChangeFlightNumberTextBox.Text = MailScanIntlForm.tbxFlightNumber.Text.PadLeft(4, "0")
        Else
            binChangeFlightNumberTextBox.Text = ""
        End If

        binChangeLocationLabel.Text = Substring(scanLocation.currentLocation, 0, 3)

    End Sub

    Protected Overloads Overrides Sub Dispose(ByVal disposing As Boolean)
        MyBase.Dispose(disposing)
    End Sub

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    Friend WithEvents binChangeCancelButton As System.Windows.Forms.Button
    Friend WithEvents MainMenu1 As System.Windows.Forms.MainMenu
#If deviceType <> "PC" Then
    Friend WithEvents InputPanel1 As Microsoft.WindowsCE.Forms.InputPanel
#End If
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.binChangeLocationLabel = New System.Windows.Forms.Label
        Me.Label9 = New System.Windows.Forms.Label
        Me.Label6 = New System.Windows.Forms.Label
        Me.binChangeFlightNumberTextBox = New System.Windows.Forms.TextBox
        Me.binChangeCancelButton = New System.Windows.Forms.Button
        Me.OKButton = New System.Windows.Forms.Button
        Me.newBinLabel = New System.Windows.Forms.Label
        Me.oldBinLabel = New System.Windows.Forms.Label
        Me.newBinTextBox = New System.Windows.Forms.TextBox
        Me.oldBinTextBox = New System.Windows.Forms.TextBox
        Me.MainMenu1 = New System.Windows.Forms.MainMenu
#If devicetype <> "PC" Then
        Me.InputPanel1 = New Microsoft.WindowsCE.Forms.InputPanel
#End If
        '
        'binChangeLocationLabel
        '
        Me.binChangeLocationLabel.Location = New System.Drawing.Point(112, 112)
        Me.binChangeLocationLabel.Size = New System.Drawing.Size(62, 17)
        Me.binChangeLocationLabel.Text = "Location"
        '
        'Label9
        '
        Me.Label9.Location = New System.Drawing.Point(24, 112)
        Me.Label9.Size = New System.Drawing.Size(84, 17)
        Me.Label9.Text = "Location"
        '
        'Label6
        '
        Me.Label6.Location = New System.Drawing.Point(24, 80)
        Me.Label6.Size = New System.Drawing.Size(84, 17)
        Me.Label6.Text = "Flight Number"
        '
        'binChangeFlightNumberTextBox
        '
        Me.binChangeFlightNumberTextBox.Location = New System.Drawing.Point(112, 80)
        Me.binChangeFlightNumberTextBox.Size = New System.Drawing.Size(104, 22)
        Me.binChangeFlightNumberTextBox.Text = ""
        '
        'binChangeCancelButton
        '
        Me.binChangeCancelButton.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold)
        Me.binChangeCancelButton.Location = New System.Drawing.Point(112, 144)
        Me.binChangeCancelButton.Size = New System.Drawing.Size(86, 29)
        Me.binChangeCancelButton.Text = "Cancel"
        '
        'OKButton
        '
        Me.OKButton.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold)
        Me.OKButton.Location = New System.Drawing.Point(16, 144)
        Me.OKButton.Size = New System.Drawing.Size(86, 29)
        Me.OKButton.Text = "OK"
        '
        'newBinLabel
        '
        Me.newBinLabel.Location = New System.Drawing.Point(24, 56)
        Me.newBinLabel.Size = New System.Drawing.Size(80, 17)
        Me.newBinLabel.Text = "New Cart ID"
        '
        'oldBinLabel
        '
        Me.oldBinLabel.Location = New System.Drawing.Point(24, 24)
        Me.oldBinLabel.Size = New System.Drawing.Size(80, 17)
        Me.oldBinLabel.Text = "Old Cart ID"
        '
        'newBinTextBox
        '
        Me.newBinTextBox.Location = New System.Drawing.Point(112, 48)
        Me.newBinTextBox.Size = New System.Drawing.Size(104, 22)
        Me.newBinTextBox.Text = ""
        '
        'oldBinTextBox
        '
        Me.oldBinTextBox.Location = New System.Drawing.Point(112, 16)
        Me.oldBinTextBox.Size = New System.Drawing.Size(104, 22)
        Me.oldBinTextBox.Text = ""
        '
        'MailScanBinChangeForm
        '
        Me.ClientSize = New System.Drawing.Size(234, 328)
        Me.ControlBox = False
        Me.Controls.Add(Me.binChangeLocationLabel)
        Me.Controls.Add(Me.Label9)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.binChangeFlightNumberTextBox)
        Me.Controls.Add(Me.binChangeCancelButton)
        Me.Controls.Add(Me.OKButton)
        Me.Controls.Add(Me.newBinLabel)
        Me.Controls.Add(Me.oldBinLabel)
        Me.Controls.Add(Me.newBinTextBox)
        Me.Controls.Add(Me.oldBinTextBox)
        Me.Menu = Me.MainMenu1
        Me.Text = "Create Cart Change Record"

    End Sub

#End Region

    Private Sub OKButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles OKButton.Click

        If Not isNonNullString(binChangeFlightNumberTextBox.Text) Then
            MsgBox("A valid flight number must be specified to create a Cart change record.", MsgBoxStyle.Exclamation, "Missing Flight Number")
            Exit Sub
        End If

        If Not Util.isValidBatchID(oldBinTextBox.Text) Then
            MsgBox("Invalid Old Cart ID", MsgBoxStyle.Exclamation, "Invalid Cart ID")
            Exit Sub
        End If

        If Not Util.isValidBatchID(newBinTextBox.Text) Then
            MsgBox("Invalid New Cart ID", MsgBoxStyle.Exclamation, "Invalid Cart ID")
            Exit Sub

        End If

        If Not Util.isValidFlightNumber(binChangeFlightNumberTextBox.Text) Then

            MsgBox("Invalid Flight Number", MsgBoxStyle.Exclamation, "Invalid Flight Number")

            Exit Sub

        End If

        'Modified by MX
        SaveBinChange(oldBinTextBox.Text, newBinTextBox.Text, binChangeFlightNumberTextBox.Text, binChangeLocationLabel.Text, Me.curProgType)

        oldBinTextBox.Text = ""
        newBinTextBox.Text = ""

        Me.Hide()

    End Sub

    Private Sub binChangeCancelButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles binChangeCancelButton.Click

        oldBinTextBox.Text = ""
        newBinTextBox.Text = ""
        Me.Hide()

    End Sub

    'Private Sub OKButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles OKButton.Click

    '    processBinChangeOKButtonClick()
    '    keyboard.hide()
    '    Me.Hide()

    'End Sub

    'Private Sub binChangeCancelButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles binChangeCancelButton.Click

    '    processBinChangeCancelButtonClick()
    '    Me.Hide()

    'End Sub

End Class
