Public Class MailScanFlightStatusMessageForm
    Inherits System.Windows.Forms.Form
    Friend WithEvents flightStatusOKButton As System.Windows.Forms.Button
    Friend WithEvents flightStatusHeaderLabel As System.Windows.Forms.Label

#Region " Windows Form Designer generated code "

    Public Sub New()
        MyBase.New()

        'This call is required by the Windows Form Designer.
        InitializeComponent()

    End Sub



    Protected Overloads Overrides Sub Dispose(ByVal disposing As Boolean)
        MyBase.Dispose(disposing)
    End Sub

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    Friend WithEvents flightStatusCancelButton As System.Windows.Forms.Button
    Friend WithEvents arrivingFlightRadioButton As System.Windows.Forms.RadioButton
    Friend WithEvents departingFlightRadioButton As System.Windows.Forms.RadioButton
    Friend WithEvents arrivingFlightComboBox As System.Windows.Forms.ComboBox
    Friend WithEvents departingFlightComboBox As System.Windows.Forms.ComboBox
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.flightStatusCancelButton = New System.Windows.Forms.Button
        Me.flightStatusOKButton = New System.Windows.Forms.Button
        Me.flightStatusHeaderLabel = New System.Windows.Forms.Label
        Me.arrivingFlightRadioButton = New System.Windows.Forms.RadioButton
        Me.departingFlightRadioButton = New System.Windows.Forms.RadioButton
        Me.arrivingFlightComboBox = New System.Windows.Forms.ComboBox
        Me.departingFlightComboBox = New System.Windows.Forms.ComboBox
        '
        'flightStatusCancelButton
        '
        Me.flightStatusCancelButton.Location = New System.Drawing.Point(125, 194)
        Me.flightStatusCancelButton.Size = New System.Drawing.Size(80, 29)
        Me.flightStatusCancelButton.Text = "Cancel"
        '
        'flightStatusOKButton
        '
        Me.flightStatusOKButton.Location = New System.Drawing.Point(25, 194)
        Me.flightStatusOKButton.Size = New System.Drawing.Size(80, 29)
        Me.flightStatusOKButton.Text = "OK"
        '
        'flightStatusHeaderLabel
        '
        Me.flightStatusHeaderLabel.Font = New System.Drawing.Font("Tahoma", 14.25!, System.Drawing.FontStyle.Italic)
        Me.flightStatusHeaderLabel.Location = New System.Drawing.Point(10, 25)
        Me.flightStatusHeaderLabel.Size = New System.Drawing.Size(235, 28)
        Me.flightStatusHeaderLabel.Text = "Transmit Flight Status"
        Me.flightStatusHeaderLabel.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'arrivingFlightRadioButton
        '
        Me.arrivingFlightRadioButton.Checked = True
        Me.arrivingFlightRadioButton.Location = New System.Drawing.Point(12, 67)
        Me.arrivingFlightRadioButton.Size = New System.Drawing.Size(148, 21)
        Me.arrivingFlightRadioButton.Text = "Arriving Into BOS"
        '
        'departingFlightRadioButton
        '
        Me.departingFlightRadioButton.Location = New System.Drawing.Point(12, 133)
        Me.departingFlightRadioButton.Size = New System.Drawing.Size(141, 21)
        Me.departingFlightRadioButton.Text = "Departing From BOS"
        '
        'arrivingFlightComboBox
        '
        Me.arrivingFlightComboBox.Location = New System.Drawing.Point(163, 66)
        Me.arrivingFlightComboBox.Size = New System.Drawing.Size(77, 22)
        '
        'departingFlightComboBox
        '
        Me.departingFlightComboBox.Enabled = False
        Me.departingFlightComboBox.Location = New System.Drawing.Point(162, 133)
        Me.departingFlightComboBox.Size = New System.Drawing.Size(77, 22)
        '
        'MailScanFlightStatusMessageForm
        '
        Me.ClientSize = New System.Drawing.Size(234, 288)
        Me.Controls.Add(Me.departingFlightComboBox)
        Me.Controls.Add(Me.arrivingFlightComboBox)
        Me.Controls.Add(Me.departingFlightRadioButton)
        Me.Controls.Add(Me.arrivingFlightRadioButton)
        Me.Controls.Add(Me.flightStatusCancelButton)
        Me.Controls.Add(Me.flightStatusOKButton)
        Me.Controls.Add(Me.flightStatusHeaderLabel)
        Me.Text = "Flight Status Message"

    End Sub

#End Region

    Public Sub init(ByVal arriveFlightList As ArrayList, ByVal departFlightList As ArrayList)

        Me.arrivingFlightRadioButton.Text = "Arriving Into ABE"
        Me.departingFlightRadioButton.Text = "Departing From ABE"

        Dim flightNumber As String

        Me.arrivingFlightComboBox.Items.Clear()
        Me.arrivingFlightComboBox.Items.Add("")

        Me.departingFlightComboBox.Items.Clear()
        Me.departingFlightComboBox.Items.Add("")

        For Each flightNumber In arriveFlightList
            Me.arrivingFlightComboBox.Items.Add(flightNumber)
        Next

        For Each flightNumber In departFlightList
            Me.departingFlightComboBox.Items.Add(flightNumber)
        Next

    End Sub

    Private Sub formOnLoad(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        MyBase.MaximizeBox = False
        MyBase.MinimizeBox = False
        MyBase.ControlBox = False
        MyBase.WindowState = FormWindowState.Maximized

    End Sub

    Private Sub flightStatusOKButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles flightStatusOKButton.Click

        Me.Hide()

    End Sub

    Private Sub flightStatusCancelButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles flightStatusCancelButton.Click

        Me.Hide()

    End Sub

    Private Sub arrivingFlightRadioButton_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles arrivingFlightRadioButton.CheckedChanged

        If Not arrivingFlightRadioButton.Checked Then Exit Sub

        Me.arrivingFlightComboBox.Enabled = True
        Me.departingFlightComboBox.Enabled = False

    End Sub

    Private Sub departingFlightRadioButton_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles departingFlightRadioButton.CheckedChanged

        If Not departingFlightRadioButton.Checked Then Exit Sub

        Me.arrivingFlightComboBox.Enabled = False
        Me.departingFlightComboBox.Enabled = True

    End Sub

End Class
