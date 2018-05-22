Public Class verifyTimeZoneForm

    Inherits System.Windows.Forms.Form
    Friend WithEvents PictureBox2 As System.Windows.Forms.PictureBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents timeZoneLabel As System.Windows.Forms.Label
    Friend WithEvents OKButton As System.Windows.Forms.Button

#Region " Windows Form Designer generated code "

    Public Sub New(ByRef timeZone As String)

        MyBase.New()

#If ValidationLevel >= 3 Then

        If diagnosticLevel >= 2 Then
            verify(Not timeZone Is Nothing, 24)
        End If

#End If

        'This call is required by the Windows Form Designer.
        InitializeComponent()

        timeZoneLabel.Text = timeZone

        'Add any initialization after the InitializeComponent() call

    End Sub

    Private Sub initializationFormOnLoad(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        MyBase.MaximizeBox = False
        MyBase.MinimizeBox = False
        MyBase.ControlBox = False

    End Sub

    Protected Overloads Overrides Sub Dispose(ByVal disposing As Boolean)
        MyBase.Dispose(disposing)
    End Sub

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    Friend WithEvents cancelButton As System.Windows.Forms.Button
    Friend WithEvents MainMenu1 As System.Windows.Forms.MainMenu
    Friend WithEvents Label2 As System.Windows.Forms.Label
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Dim resources As System.Resources.ResourceManager = New System.Resources.ResourceManager(GetType(verifyTimeZoneForm))
        Me.PictureBox2 = New System.Windows.Forms.PictureBox
        Me.Label1 = New System.Windows.Forms.Label
        Me.timeZoneLabel = New System.Windows.Forms.Label
        Me.OKButton = New System.Windows.Forms.Button
        Me.cancelButton = New System.Windows.Forms.Button
        Me.MainMenu1 = New System.Windows.Forms.MainMenu
        Me.Label2 = New System.Windows.Forms.Label
        '
        'PictureBox2
        '
        Me.PictureBox2.Image = CType(resources.GetObject("PictureBox2.Image"), System.Drawing.Image)
        Me.PictureBox2.Location = New System.Drawing.Point(88, 10)
        Me.PictureBox2.Size = New System.Drawing.Size(61, 55)
        '
        'Label1
        '
        Me.Label1.Font = New System.Drawing.Font("Tahoma", 12.0!, System.Drawing.FontStyle.Bold)
        Me.Label1.Location = New System.Drawing.Point(15, 76)
        Me.Label1.Size = New System.Drawing.Size(72, 18)
        Me.Label1.Text = "Notice:"
        '
        'timeZoneLabel
        '
        Me.timeZoneLabel.Font = New System.Drawing.Font("Tahoma", 12.0!, System.Drawing.FontStyle.Bold)
        Me.timeZoneLabel.Location = New System.Drawing.Point(29, 192)
        Me.timeZoneLabel.Size = New System.Drawing.Size(174, 18)
        Me.timeZoneLabel.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'OKButton
        '
        Me.OKButton.Location = New System.Drawing.Point(27, 235)
        Me.OKButton.Size = New System.Drawing.Size(78, 25)
        Me.OKButton.Text = "OK"
        '
        'cancelButton
        '
        Me.cancelButton.Location = New System.Drawing.Point(122, 235)
        Me.cancelButton.Size = New System.Drawing.Size(78, 25)
        Me.cancelButton.Text = "Cancel"
        '
        'Label2
        '
        Me.Label2.Font = New System.Drawing.Font("Tahoma", 11.25!, System.Drawing.FontStyle.Regular)
        Me.Label2.Location = New System.Drawing.Point(21, 110)
        Me.Label2.Size = New System.Drawing.Size(205, 62)
        Me.Label2.Text = "Time Change Will Not Function Properly Unless Device Time Zone Is Set To:"
        '
        'verifyTimeZoneForm
        '
        Me.ClientSize = New System.Drawing.Size(250, 297)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.cancelButton)
        Me.Controls.Add(Me.OKButton)
        Me.Controls.Add(Me.timeZoneLabel)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.PictureBox2)
        Me.Menu = Me.MainMenu1
        Me.Text = "VerifyTimeZoneForm"

    End Sub

#End Region

    Private Sub OKButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles OKButton.Click

        Me.Close()

    End Sub

    Private Sub cancelButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cancelButton.Click

        Me.Close()

    End Sub

End Class
