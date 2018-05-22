Public Class OntimeManagementHelpForm
    Inherits System.Windows.Forms.Form
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents lbl1 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label

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
    Friend WithEvents OKButton As System.Windows.Forms.Button
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.Label1 = New System.Windows.Forms.Label
        Me.Label2 = New System.Windows.Forms.Label
        Me.lbl1 = New System.Windows.Forms.Label
        Me.Label3 = New System.Windows.Forms.Label
        Me.Label4 = New System.Windows.Forms.Label
        Me.OKButton = New System.Windows.Forms.Button
        '
        'Label1
        '
        Me.Label1.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular)
        Me.Label1.Location = New System.Drawing.Point(8, 0)
        Me.Label1.Size = New System.Drawing.Size(224, 80)
        Me.Label1.Text = "The mail piece that was just scanned is destined for a flight that has either alr" & _
        "eady departed, or will depart very soon. Do not accept this piece unless you are" & _
        " sure that it will make this flight or unless authorized by a supervisor."
        '
        'Label2
        '
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular)
        Me.Label2.Location = New System.Drawing.Point(8, 86)
        Me.Label2.Size = New System.Drawing.Size(224, 16)
        Me.Label2.Text = "Options:"
        '
        'lbl1
        '
        Me.lbl1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular)
        Me.lbl1.Location = New System.Drawing.Point(8, 108)
        Me.lbl1.Size = New System.Drawing.Size(224, 40)
        Me.lbl1.Text = "Accept This Individual Piece: The mail that you just scanned will be accepted and" & _
        " recorded."
        '
        'Label3
        '
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular)
        Me.Label3.Location = New System.Drawing.Point(8, 154)
        Me.Label3.Size = New System.Drawing.Size(224, 40)
        Me.Label3.Text = "Accept All Pieces For This Flight: Any piece scanned for this flight will be auto" & _
        "matically accepted without a warning message."
        '
        'Label4
        '
        Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular)
        Me.Label4.Location = New System.Drawing.Point(8, 200)
        Me.Label4.Size = New System.Drawing.Size(224, 32)
        Me.Label4.Text = "Reject This Piece: This piece will be rejected and not recorded."
        '
        'OKButton
        '
        Me.OKButton.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular)
        Me.OKButton.Location = New System.Drawing.Point(72, 232)
        Me.OKButton.Size = New System.Drawing.Size(88, 24)
        Me.OKButton.Text = "OK"
        '
        'OntimeManagementHelpForm
        '
        Me.ControlBox = False
        Me.Controls.Add(Me.OKButton)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.lbl1)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Text = "On Time Management Help"

    End Sub

#End Region

    Private Sub OKButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles OKButton.Click
        Me.Close()
    End Sub
End Class
