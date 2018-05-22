Public Class msMsgInvalidRouting

    Inherits System.Windows.Forms.Form
    Friend WithEvents PictureBox2 As System.Windows.Forms.PictureBox

#Region " Windows Form Designer generated code "

    Public Sub New(ByVal inputRoutingCode As String)
        MyBase.New()

        'This call is required by the Windows Form Designer.
        InitializeComponent()

        Me.routingCodeLabel.Text = inputRoutingCode

    End Sub

    Protected Overloads Overrides Sub Dispose(ByVal disposing As Boolean)
        MyBase.Dispose(disposing)
    End Sub

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    Friend WithEvents message2TextBox As System.Windows.Forms.Label
    Friend WithEvents message1TextBox As System.Windows.Forms.Label
    Friend WithEvents routingCodeLabel As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents OKButton As System.Windows.Forms.Button
    Friend WithEvents Button1 As System.Windows.Forms.Button
    Friend WithEvents routingCodeTextBox As System.Windows.Forms.TextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents helpButton As System.Windows.Forms.Button
    Friend WithEvents MainMenu1 As System.Windows.Forms.MainMenu
#If deviceType <> "PC" Then
    Friend WithEvents InputPanel1 As Microsoft.WindowsCE.Forms.InputPanel
#End If
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Dim resources As System.Resources.ResourceManager = New System.Resources.ResourceManager(GetType(msMsgInvalidRouting))
        Me.message2TextBox = New System.Windows.Forms.Label
        Me.PictureBox2 = New System.Windows.Forms.PictureBox
        Me.message1TextBox = New System.Windows.Forms.Label
        Me.routingCodeLabel = New System.Windows.Forms.Label
        Me.Label1 = New System.Windows.Forms.Label
        Me.OKButton = New System.Windows.Forms.Button
        Me.Button1 = New System.Windows.Forms.Button
        Me.routingCodeTextBox = New System.Windows.Forms.TextBox
        Me.Label2 = New System.Windows.Forms.Label
        Me.helpButton = New System.Windows.Forms.Button
        Me.MainMenu1 = New System.Windows.Forms.MainMenu
#If devicetype <> "PC" Then
        Me.InputPanel1 = New Microsoft.WindowsCE.Forms.InputPanel
#End If
        '
        'message2TextBox
        '
        Me.message2TextBox.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Regular)
        Me.message2TextBox.Location = New System.Drawing.Point(19, 88)
        Me.message2TextBox.Size = New System.Drawing.Size(139, 22)
        Me.message2TextBox.Text = "Invalid Routing Code:"
        Me.message2TextBox.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'PictureBox2
        '
        Me.PictureBox2.Image = CType(resources.GetObject("PictureBox2.Image"), System.Drawing.Image)
        Me.PictureBox2.Location = New System.Drawing.Point(89, 2)
        Me.PictureBox2.Size = New System.Drawing.Size(61, 55)
        '
        'message1TextBox
        '
        Me.message1TextBox.Font = New System.Drawing.Font("Tahoma", 12.0!, System.Drawing.FontStyle.Regular)
        Me.message1TextBox.Location = New System.Drawing.Point(49, 60)
        Me.message1TextBox.Size = New System.Drawing.Size(141, 23)
        Me.message1TextBox.Text = "Mail Scan Error"
        Me.message1TextBox.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'routingCodeLabel
        '
        Me.routingCodeLabel.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Bold)
        Me.routingCodeLabel.Location = New System.Drawing.Point(162, 90)
        Me.routingCodeLabel.Size = New System.Drawing.Size(51, 18)
        Me.routingCodeLabel.Text = "XXXX"
        Me.routingCodeLabel.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'Label1
        '
        Me.Label1.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Regular)
        Me.Label1.Location = New System.Drawing.Point(14, 118)
        Me.Label1.Size = New System.Drawing.Size(212, 53)
        Me.Label1.Text = "Enter a valid routing code in the box below and tap ""OK"" or tap ""Cancel"" to ignor" & _
        "e the current scan"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'OKButton
        '
        Me.OKButton.Location = New System.Drawing.Point(31, 222)
        Me.OKButton.Size = New System.Drawing.Size(74, 23)
        Me.OKButton.Text = "OK"
        '
        'Button1
        '
        Me.Button1.Location = New System.Drawing.Point(125, 222)
        Me.Button1.Size = New System.Drawing.Size(74, 23)
        Me.Button1.Text = "Cancel"
        '
        'routingCodeTextBox
        '
        Me.routingCodeTextBox.Location = New System.Drawing.Point(167, 182)
        Me.routingCodeTextBox.Size = New System.Drawing.Size(40, 22)
        Me.routingCodeTextBox.Text = ""
        '
        'Label2
        '
        Me.Label2.Location = New System.Drawing.Point(12, 183)
        Me.Label2.Size = New System.Drawing.Size(145, 20)
        Me.Label2.Text = "Enter New Routing Code:"
        '
        'helpButton
        '
        Me.helpButton.Font = New System.Drawing.Font("Tahoma", 12.0!, System.Drawing.FontStyle.Bold)
        Me.helpButton.Location = New System.Drawing.Point(179, 17)
        Me.helpButton.Size = New System.Drawing.Size(24, 24)
        Me.helpButton.Text = "?"
        '
        'msMsgInvalidRouting
        '
        Me.ClientSize = New System.Drawing.Size(234, 288)
        Me.ControlBox = False
        Me.Controls.Add(Me.helpButton)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.routingCodeTextBox)
        Me.Controls.Add(Me.Button1)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.routingCodeLabel)
        Me.Controls.Add(Me.OKButton)
        Me.Controls.Add(Me.message2TextBox)
        Me.Controls.Add(Me.PictureBox2)
        Me.Controls.Add(Me.message1TextBox)
        Me.Menu = Me.MainMenu1
        Me.Text = "Invalid Routing"

    End Sub

#End Region

    Private Sub OK_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles OKButton.Click

        If isNonNullString(Me.routingCodeTextBox.Text) Then
            msRoutingCode = Me.routingCodeTextBox.Text.ToUpper
        Else
            msRoutingCode = ""
        End If

        Me.DialogResult = DialogResult.OK
        Me.Close()

    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click

        Me.DialogResult = DialogResult.Cancel
        Me.Close()

    End Sub
End Class

