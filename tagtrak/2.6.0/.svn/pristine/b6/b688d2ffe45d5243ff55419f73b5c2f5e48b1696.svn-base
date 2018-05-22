Imports System
Imports System.io

Public Class binChangeForm
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
    Friend WithEvents binChangeHeaderLabel As System.Windows.Forms.Label

#Region " Windows Form Designer generated code "

    Public Sub New(ByRef scanFormMail As scanFormMail)
        MyBase.New()

        'This call is required by the Windows Form Designer.
        InitializeComponent()

        If userSpecRecord.userName = "ATA" Then
            binChangeHeaderLabel.Text = "Create Cart Change Record"
            oldBinLabel.Text = "Old Cart ID"
            newBinLabel.Text = "New Cart ID"
            'binUploadButton.Text = "Cart Upload"
        End If

        If isNonNullString(scanFormMail.flightNumberTextBox.Text) Then
            binChangeFlightNumberTextBox.Text = scanFormMail.flightNumberTextBox.Text.PadLeft(4, "0")
        Else
            binChangeFlightNumberTextBox.Text = ""
        End If

        binChangeLocationLabel.Text = Substring(scanLocation, 0, 3)

        'Add any initialization after the InitializeComponent() call

        setupKeyboard()

    End Sub

    Dim keyboard As keyboardClass

    Private Sub setupKeyboard()

        Dim textBoxList() As System.windows.forms.TextBox = { _
            oldBinTextBox, _
            newBinTextBox, _
            binChangeFlightNumberTextBox}

        keyboard = New keyboardClass(Me, textBoxList, keyboardIcon, AddressOf OKButton_Click)

    End Sub

    Protected Overloads Overrides Sub Dispose(ByVal disposing As Boolean)
        MyBase.Dispose(disposing)
    End Sub

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    Friend WithEvents binChangeCancelButton As System.Windows.Forms.Button
    Friend WithEvents keyboardIcon As System.Windows.Forms.PictureBox
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
        Me.binChangeHeaderLabel = New System.Windows.Forms.Label
        Me.keyboardIcon = New System.Windows.Forms.PictureBox
        '
        'binChangeLocationLabel
        '
        Me.binChangeLocationLabel.Location = New System.Drawing.Point(103, 140)
        Me.binChangeLocationLabel.Size = New System.Drawing.Size(62, 17)
        Me.binChangeLocationLabel.Text = "Location"
        '
        'Label9
        '
        Me.Label9.Location = New System.Drawing.Point(15, 142)
        Me.Label9.Size = New System.Drawing.Size(84, 17)
        Me.Label9.Text = "Location"
        '
        'Label6
        '
        Me.Label6.Location = New System.Drawing.Point(15, 114)
        Me.Label6.Size = New System.Drawing.Size(84, 17)
        Me.Label6.Text = "Flight Number"
        '
        'binChangeFlightNumberTextBox
        '
        Me.binChangeFlightNumberTextBox.Location = New System.Drawing.Point(103, 110)
        Me.binChangeFlightNumberTextBox.Size = New System.Drawing.Size(127, 22)
        Me.binChangeFlightNumberTextBox.Text = ""
        '
        'binChangeCancelButton
        '
        Me.binChangeCancelButton.Location = New System.Drawing.Point(111, 175)
        Me.binChangeCancelButton.Size = New System.Drawing.Size(86, 29)
        Me.binChangeCancelButton.Text = "Cancel"
        '
        'OKButton
        '
        Me.OKButton.Location = New System.Drawing.Point(17, 175)
        Me.OKButton.Size = New System.Drawing.Size(86, 29)
        Me.OKButton.Text = "OK"
        '
        'newBinLabel
        '
        Me.newBinLabel.Location = New System.Drawing.Point(15, 86)
        Me.newBinLabel.Size = New System.Drawing.Size(80, 17)
        Me.newBinLabel.Text = "New Cart ID"
        '
        'oldBinLabel
        '
        Me.oldBinLabel.Location = New System.Drawing.Point(15, 58)
        Me.oldBinLabel.Size = New System.Drawing.Size(80, 17)
        Me.oldBinLabel.Text = "Old Cart ID"
        '
        'newBinTextBox
        '
        Me.newBinTextBox.Location = New System.Drawing.Point(103, 80)
        Me.newBinTextBox.Size = New System.Drawing.Size(127, 22)
        Me.newBinTextBox.Text = ""
        '
        'oldBinTextBox
        '
        Me.oldBinTextBox.Location = New System.Drawing.Point(103, 50)
        Me.oldBinTextBox.Size = New System.Drawing.Size(127, 22)
        Me.oldBinTextBox.Text = ""
        '
        'binChangeHeaderLabel
        '
        Me.binChangeHeaderLabel.Font = New System.Drawing.Font("Tahoma", 14.25!, System.Drawing.FontStyle.Italic)
        Me.binChangeHeaderLabel.Location = New System.Drawing.Point(12, 17)
        Me.binChangeHeaderLabel.Size = New System.Drawing.Size(235, 28)
        Me.binChangeHeaderLabel.Text = "Create Cart Change Record"
        Me.binChangeHeaderLabel.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'keyboardIcon
        '
        Me.keyboardIcon.Location = New System.Drawing.Point(205, 181)
        Me.keyboardIcon.Size = New System.Drawing.Size(23, 16)
        '
        'binChangeForm
        '
        Me.ClientSize = New System.Drawing.Size(265, 418)
        Me.Controls.Add(Me.keyboardIcon)
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
        Me.Controls.Add(Me.binChangeHeaderLabel)
        Me.Text = "binChangeForm"

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

    Private Sub processBinChangeOKButtonClick()

        If Not isNonNullString(binChangeFlightNumberTextBox.Text) Then
            MsgBox("A valid flight number must be specified to create a Cart change record.", MsgBoxStyle.Exclamation, "Missing Flight Number")
            Exit Sub
        End If

        If Not isValidBatchID(oldBinTextBox.Text) Then
            If user = "ATA" Or user = "USAirways" Then
                MsgBox("Invalid Old Cart ID", MsgBoxStyle.Exclamation, "Invalid Cart ID")
            Else
                MsgBox("Invalid Old Cart ID", MsgBoxStyle.Exclamation, "Invalid Cart ID")
            End If
            Exit Sub
        End If

        If Not isValidBatchID(newBinTextBox.Text) Then
            If user = "ATA" Or user = "USAirways" Then
                MsgBox("Invalid New Cart ID", MsgBoxStyle.Exclamation, "Invalid Cart ID")
            Else
                MsgBox("Invalid New Cart ID", MsgBoxStyle.Exclamation, "Invalid Cart ID")
            End If
            Exit Sub

        End If

        If Not isValidFlightNumber(binChangeFlightNumberTextBox.Text) Then

            MsgBox("Invalid Flight Number", MsgBoxStyle.Exclamation, "Invalid Flight Number")

            Exit Sub

        End If

        Dim binChangeRecordKey = oldBinTextBox.Text & newBinTextBox.Text & binChangeFlightNumberTextBox.Text & binChangeLocationLabel.Text

        If binChangeTable.ContainsKey(binChangeRecordKey) Then

            If user = "ATA" Or user = "USAirways" Then
                MsgBox("Cart Change Record Already Exists.", MsgBoxStyle.Exclamation, "Duplicate Cart Change Record")
            Else
                MsgBox("Cart Change Record Already Exists.", MsgBoxStyle.Exclamation, "Duplicate Cart Change Record")
            End If

            Exit Sub

        End If

        Dim binChangeRecord As New BinChangeRecordClass(oldBinTextBox.Text, newBinTextBox.Text, binChangeFlightNumberTextBox.Text, binChangeLocationLabel.Text)

        binChangeTable.Add(binChangeRecordKey, binChangeRecord)

        Dim binChangeOutputStream As StreamWriter

        Try
            binChangeOutputStream = New StreamWriter(binChangeFilePath, True)
        Catch ex As Exception
            MsgBox("Unable to open Cart change file: " & ex.Message)
            Exit Sub
        End Try

        Try
            binChangeOutputStream.WriteLine(binChangeRecord.ToString)
        Catch ex As Exception
            binChangeOutputStream.Close()
            MsgBox("Unable to write to Cart change file: " & ex.Message)
            Exit Sub
        End Try

        binChangeOutputStream.Close()

        oldBinTextBox.Text = ""
        newBinTextBox.Text = ""

    End Sub

    Private Sub processBinChangeCancelButtonClick()

        oldBinTextBox.Text = ""
        newBinTextBox.Text = ""

    End Sub

    Private Sub OKButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles OKButton.Click

        processBinChangeOKButtonClick()
        keyboard.hide()
        Me.Close()

    End Sub

    Private Sub binChangeCancelButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles binChangeCancelButton.Click

        processBinChangeCancelButtonClick()
        Me.Close()

    End Sub

    Private Sub binChangeForm_KeyPress(ByVal sender As System.Object, ByVal e As KeyPressEventArgs) _
               Handles oldBinTextBox.KeyPress, newBinTextBox.KeyPress, binChangeFlightNumberTextBox.KeyPress

        If e.KeyChar = tabKeyChar Then
            keyboard.processTabRoutine(sender)
        End If

    End Sub
End Class
