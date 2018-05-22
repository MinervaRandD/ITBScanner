Public Class FlightScheduleError
    Inherits System.Windows.Forms.Form
    Friend WithEvents PictureBox1 As System.Windows.Forms.PictureBox
    Friend WithEvents ButtonYes As System.Windows.Forms.Button
    Friend WithEvents ButtonNo As System.Windows.Forms.Button
    Friend WithEvents CheckBoxDontAsk As System.Windows.Forms.CheckBox

    Public Shared DontAsk As Boolean

    Public Sub New(ByVal TheDescription As String)
        Me.New()
        LabelDescription.Text = TheDescription
        MySIP.Enabled = False
    End Sub

#Region " Windows Form Designer generated code "

    Public Sub New()
        MyBase.New()

        'This call is required by the Windows Form Designer.
        InitializeComponent()

        'Add any initialization after the InitializeComponent() call

    End Sub

    Protected Overloads Overrides Sub Dispose(ByVal disposing As Boolean)
        MyBase.Dispose(disposing)
    End Sub

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    Friend WithEvents LabelDescription As System.Windows.Forms.Label
    Friend WithEvents MySIP As Microsoft.WindowsCE.Forms.InputPanel
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Dim resources As System.Resources.ResourceManager = New System.Resources.ResourceManager(GetType(FlightScheduleError))
        Me.LabelDescription = New System.Windows.Forms.Label
        Me.PictureBox1 = New System.Windows.Forms.PictureBox
        Me.ButtonYes = New System.Windows.Forms.Button
        Me.ButtonNo = New System.Windows.Forms.Button
        Me.CheckBoxDontAsk = New System.Windows.Forms.CheckBox
        Me.MySIP = New Microsoft.WindowsCE.Forms.InputPanel
        '
        'LabelDescription
        '
        Me.LabelDescription.Location = New System.Drawing.Point(24, 76)
        Me.LabelDescription.Size = New System.Drawing.Size(192, 96)
        Me.LabelDescription.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'PictureBox1
        '
        Me.PictureBox1.Image = CType(resources.GetObject("PictureBox1.Image"), System.Drawing.Image)
        Me.PictureBox1.Location = New System.Drawing.Point(84, 8)
        Me.PictureBox1.Size = New System.Drawing.Size(61, 55)
        '
        'ButtonYes
        '
        Me.ButtonYes.Location = New System.Drawing.Point(24, 192)
        Me.ButtonYes.Text = "&Yes"
        '
        'ButtonNo
        '
        Me.ButtonNo.Location = New System.Drawing.Point(140, 192)
        Me.ButtonNo.Text = "&No"
        '
        'CheckBoxDontAsk
        '
        Me.CheckBoxDontAsk.Location = New System.Drawing.Point(28, 232)
        Me.CheckBoxDontAsk.Size = New System.Drawing.Size(184, 20)
        Me.CheckBoxDontAsk.Text = "Don't ask again for this flight"
        '
        'FlightScheduleError
        '
        Me.Controls.Add(Me.CheckBoxDontAsk)
        Me.Controls.Add(Me.ButtonNo)
        Me.Controls.Add(Me.ButtonYes)
        Me.Controls.Add(Me.PictureBox1)
        Me.Controls.Add(Me.LabelDescription)
        Me.Text = "Non-Scheduled Flight"

    End Sub

#End Region

    Private Sub ButtonYes_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonYes.Click
        Me.DialogResult = DialogResult.Yes
    End Sub

    Private Sub CheckBoxDontAsk_CheckStateChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CheckBoxDontAsk.CheckStateChanged
        FlightScheduleError.DontAsk = CheckBoxDontAsk.Checked
    End Sub

    Private Sub ButtonNo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonNo.Click
        FlightScheduleError.DontAsk = False
        Me.DialogResult = DialogResult.No
    End Sub

    Private Sub FlightScheduleError_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Load
        If FlightScheduleError.DontAsk Then
            Me.DialogResult = DialogResult.Yes
            Me.Close()
        End If
    End Sub
End Class
