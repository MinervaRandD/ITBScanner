Public Class MsMsgGetCarditRoutingHelp
    Inherits System.Windows.Forms.Form
    Friend WithEvents helpListBox As System.Windows.Forms.ListBox
    Friend WithEvents OKButton As System.Windows.Forms.Button

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
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.helpListBox = New System.Windows.Forms.ListBox
        Me.OKButton = New System.Windows.Forms.Button
        '
        'helpListBox
        '
        Me.helpListBox.Items.Add("The routing for the mail package that you")
        Me.helpListBox.Items.Add("just scanned cannot be found. You should")
        Me.helpListBox.Items.Add("specify the routing using this form.")
        Me.helpListBox.Items.Add("")
        Me.helpListBox.Items.Add("Specify up to 6 flight legs and a final")
        Me.helpListBox.Items.Add("destination. Each flight leg specification")
        Me.helpListBox.Items.Add("requires:")
        Me.helpListBox.Items.Add("")
        Me.helpListBox.Items.Add("1. a carrier code")
        Me.helpListBox.Items.Add("2. a flight number")
        Me.helpListBox.Items.Add("3. a city code, and")
        Me.helpListBox.Items.Add("4. a country code")
        Me.helpListBox.Items.Add("")
        Me.helpListBox.Items.Add("The city code is the code for the city")
        Me.helpListBox.Items.Add("from which the corresponding flight")
        Me.helpListBox.Items.Add("departs. The same holds for the country")
        Me.helpListBox.Items.Add("code.")
        Me.helpListBox.Items.Add("")
        Me.helpListBox.Items.Add("If the current scan operation is ""Offline")
        Me.helpListBox.Items.Add("Transfer Received"" (you are taken ")
        Me.helpListBox.Items.Add("mail from another carrier), then the")
        Me.helpListBox.Items.Add("first leg is deactivated and should")
        Me.helpListBox.Items.Add("not be filled in.")
        Me.helpListBox.Items.Add("")
        Me.helpListBox.Items.Add("Tap the ""Stop Checking"" button in the")
        Me.helpListBox.Items.Add("lower right corner to stop further display")
        Me.helpListBox.Items.Add("of this message.")
        Me.helpListBox.Location = New System.Drawing.Point(5, 16)
        Me.helpListBox.Size = New System.Drawing.Size(226, 212)
        '
        'OKButton
        '
        Me.OKButton.Location = New System.Drawing.Point(64, 240)
        Me.OKButton.Size = New System.Drawing.Size(101, 26)
        Me.OKButton.Text = "Close"
        '
        'MsMsgGetCarditRoutingHelp
        '
        Me.ClientSize = New System.Drawing.Size(240, 328)
        Me.ControlBox = False
        Me.Controls.Add(Me.helpListBox)
        Me.Controls.Add(Me.OKButton)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Text = "Specify Routing Help"

    End Sub

#End Region

    Private Sub OKButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles OKButton.Click
        Me.Close()
    End Sub
End Class
