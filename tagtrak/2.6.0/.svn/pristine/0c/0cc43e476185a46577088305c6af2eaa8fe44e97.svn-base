Public Class OntimeManagementForm

    Inherits System.Windows.Forms.Form

#Region " Windows Form Designer generated code "

    Public ontimeRecord As OntimeRecord

    Public Sub New(ByVal inputOntimeRecord As OntimeRecord)
        MyBase.New()

        'This call is required by the Windows Form Designer.
        InitializeComponent()

        ontimeRecord = inputOntimeRecord

        Me.lblCurrentDateTime.Text = Time.Local.GetTime(scannerTimeZone).ToString()
        Me.lblDepartDateTime.Text = ontimeRecord.departureDateAndTime.ToString()
        Me.lblFlightNumber.Text = ontimeRecord.flightNumber.PadLeft(4, "0"c)

    End Sub

    Protected Overloads Overrides Sub Dispose(ByVal disposing As Boolean)
        MyBase.Dispose(disposing)
    End Sub

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    Friend WithEvents message2TextBox As System.Windows.Forms.Label
    Friend WithEvents helpButton As System.Windows.Forms.Button
    Friend WithEvents PictureBox1 As System.Windows.Forms.PictureBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents lblFlightNumber As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents lblDepartDateTime As System.Windows.Forms.Label
    Friend WithEvents lblCurrentDateTime As System.Windows.Forms.Label
    Friend WithEvents tmrCurrent As System.Windows.Forms.Timer
    Friend WithEvents btnAcceptPiece As System.Windows.Forms.Button
    Friend WithEvents btnAcceptAllPieces As System.Windows.Forms.Button
    Friend WithEvents btnRejectPiece As System.Windows.Forms.Button
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Dim resources As System.Resources.ResourceManager = New System.Resources.ResourceManager(GetType(OntimeManagementForm))
        Me.message2TextBox = New System.Windows.Forms.Label
        Me.btnAcceptPiece = New System.Windows.Forms.Button
        Me.btnAcceptAllPieces = New System.Windows.Forms.Button
        Me.helpButton = New System.Windows.Forms.Button
        Me.PictureBox1 = New System.Windows.Forms.PictureBox
        Me.btnRejectPiece = New System.Windows.Forms.Button
        Me.Label1 = New System.Windows.Forms.Label
        Me.lblFlightNumber = New System.Windows.Forms.Label
        Me.Label2 = New System.Windows.Forms.Label
        Me.Label3 = New System.Windows.Forms.Label
        Me.lblDepartDateTime = New System.Windows.Forms.Label
        Me.lblCurrentDateTime = New System.Windows.Forms.Label
        Me.tmrCurrent = New System.Windows.Forms.Timer
        '
        'message2TextBox
        '
        Me.message2TextBox.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Bold)
        Me.message2TextBox.Location = New System.Drawing.Point(32, 34)
        Me.message2TextBox.Size = New System.Drawing.Size(176, 32)
        Me.message2TextBox.Text = "Scanned Mail Is Beyond Closeout Date And Time"
        '
        'btnAcceptPiece
        '
        Me.btnAcceptPiece.Location = New System.Drawing.Point(24, 168)
        Me.btnAcceptPiece.Size = New System.Drawing.Size(192, 23)
        Me.btnAcceptPiece.Text = "Accept This Individual Piece"
        '
        'btnAcceptAllPieces
        '
        Me.btnAcceptAllPieces.Location = New System.Drawing.Point(24, 200)
        Me.btnAcceptAllPieces.Size = New System.Drawing.Size(192, 23)
        Me.btnAcceptAllPieces.Text = "Accept All Pieces For This Flight"
        '
        'helpButton
        '
        Me.helpButton.Font = New System.Drawing.Font("Tahoma", 12.0!, System.Drawing.FontStyle.Bold)
        Me.helpButton.Location = New System.Drawing.Point(179, 8)
        Me.helpButton.Size = New System.Drawing.Size(29, 24)
        Me.helpButton.Text = "?"
        '
        'PictureBox1
        '
        Me.PictureBox1.Image = CType(resources.GetObject("PictureBox1.Image"), System.Drawing.Image)
        Me.PictureBox1.Location = New System.Drawing.Point(88, 0)
        Me.PictureBox1.Size = New System.Drawing.Size(40, 32)
        Me.PictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        '
        'btnRejectPiece
        '
        Me.btnRejectPiece.Location = New System.Drawing.Point(24, 232)
        Me.btnRejectPiece.Size = New System.Drawing.Size(192, 24)
        Me.btnRejectPiece.Text = "Reject This Piece"
        '
        'Label1
        '
        Me.Label1.Location = New System.Drawing.Point(8, 80)
        Me.Label1.Size = New System.Drawing.Size(88, 16)
        Me.Label1.Text = "Flight Number"
        '
        'lblFlightNumber
        '
        Me.lblFlightNumber.Location = New System.Drawing.Point(104, 80)
        Me.lblFlightNumber.Size = New System.Drawing.Size(80, 16)
        Me.lblFlightNumber.Text = "Flight"
        '
        'Label2
        '
        Me.Label2.Location = New System.Drawing.Point(8, 100)
        Me.Label2.Size = New System.Drawing.Size(88, 32)
        Me.Label2.Text = "Departure Date/Time"
        '
        'Label3
        '
        Me.Label3.Location = New System.Drawing.Point(8, 136)
        Me.Label3.Size = New System.Drawing.Size(88, 32)
        Me.Label3.Text = "Current Date/Time"
        '
        'lblDepartDateTime
        '
        Me.lblDepartDateTime.Location = New System.Drawing.Point(104, 108)
        Me.lblDepartDateTime.Size = New System.Drawing.Size(120, 16)
        Me.lblDepartDateTime.Text = "Date/Time"
        '
        'lblCurrentDateTime
        '
        Me.lblCurrentDateTime.Location = New System.Drawing.Point(104, 144)
        Me.lblCurrentDateTime.Size = New System.Drawing.Size(120, 16)
        Me.lblCurrentDateTime.Text = "Date/Time"
        '
        'tmrCurrent
        '
        Me.tmrCurrent.Enabled = True
        Me.tmrCurrent.Interval = 1000
        '
        'OntimeManagementForm
        '
        Me.ClientSize = New System.Drawing.Size(234, 288)
        Me.ControlBox = False
        Me.Controls.Add(Me.lblCurrentDateTime)
        Me.Controls.Add(Me.lblDepartDateTime)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.lblFlightNumber)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.btnRejectPiece)
        Me.Controls.Add(Me.PictureBox1)
        Me.Controls.Add(Me.helpButton)
        Me.Controls.Add(Me.btnAcceptAllPieces)
        Me.Controls.Add(Me.btnAcceptPiece)
        Me.Controls.Add(Me.message2TextBox)
        Me.Text = "On Time Management"

    End Sub

#End Region


    Private Sub tmrCurrent_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tmrCurrent.Tick
        Me.lblCurrentDateTime.Text = Time.Local.GetTime(scannerTimeZone).ToString()
    End Sub

    Private Sub helpButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles helpButton.Click

        Dim ontimeManagementHelp As New OntimeManagementHelpForm
        ontimeManagementHelp.ShowDialog()

    End Sub

    Private Sub btnAcceptPiece_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAcceptPiece.Click
        Me.DialogResult = DialogResult.OK
        Me.Close()
    End Sub

    Private Sub btnAcceptAllPieces_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAcceptAllPieces.Click
        Me.ontimeRecord.acceptWithoutPrompting = True
        If Not ontimePrompt.ContainsKey(ontimeRecord.flightNumber & ontimeRecord.departureDateAndTime) Then
            ontimePrompt.Add(ontimeRecord.flightNumber & ontimeRecord.departureDateAndTime, ontimeRecord.acceptWithoutPrompting)
        End If
        Me.DialogResult = DialogResult.OK
        Me.Close()
    End Sub

    Private Sub btnRejectPiece_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnRejectPiece.Click
        Me.ontimeRecord.acceptWithoutPrompting = False
        Me.DialogResult = DialogResult.Cancel
    End Sub
End Class

