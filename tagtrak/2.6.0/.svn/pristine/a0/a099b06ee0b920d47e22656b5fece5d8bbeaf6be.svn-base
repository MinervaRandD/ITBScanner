Public Class MsMsgInvalidRoutingHelp

    Inherits System.Windows.Forms.Form

    Dim errorMessage As String

#Region " Windows Form Designer generated code "

    Public Sub New(ByVal inputErrorMessage As String)
        MyBase.New()

        'This call is required by the Windows Form Designer.
        InitializeComponent()

        errorMessage = inputErrorMessage

    End Sub

    Protected Overloads Overrides Sub Dispose(ByVal disposing As Boolean)
        MyBase.Dispose(disposing)
    End Sub

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    Friend WithEvents OKButton As System.Windows.Forms.Button
    Friend WithEvents helpListBox As System.Windows.Forms.ListBox
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.OKButton = New System.Windows.Forms.Button
        Me.helpListBox = New System.Windows.Forms.ListBox
        '
        'OKButton
        '
        Me.OKButton.Location = New System.Drawing.Point(67, 211)
        Me.OKButton.Size = New System.Drawing.Size(101, 26)
        Me.OKButton.Text = "OK"
        '
        'helpListBox
        '
        Me.helpListBox.Items.Add("The routing code is a four character")
        Me.helpListBox.Items.Add("code taken from positions 5-8 in the")
        Me.helpListBox.Items.Add("D and R Tag. The routing code")
        Me.helpListBox.Items.Add("found in the current D and R Tag is")
        Me.helpListBox.Items.Add("invalid.")
        Me.helpListBox.Items.Add("")
        Me.helpListBox.Items.Add("To be valid a routing code must")
        Me.helpListBox.Items.Add("containonly characters: A-Z or a-z,")
        Me.helpListBox.Items.Add("or numbers: 0-9.")
        Me.helpListBox.Items.Add("")
        Me.helpListBox.Items.Add("If the current D and R Tag was")
        Me.helpListBox.Items.Add("filled in as a result of the scan of")
        Me.helpListBox.Items.Add("a bar code, then either (1) the scan")
        Me.helpListBox.Items.Add("recorded invalid data, or (2) the")
        Me.helpListBox.Items.Add("D and R Tag bar code is invalid.")
        Me.helpListBox.Items.Add("")
        Me.helpListBox.Items.Add("If the current D and R Tag was")
        Me.helpListBox.Items.Add("entered manually, an invalid routing")
        Me.helpListBox.Items.Add("code was entered as part of the")
        Me.helpListBox.Items.Add("D and R Tag.")
        Me.helpListBox.Items.Add("")
        Me.helpListBox.Items.Add("You may correct the invalid routing")
        Me.helpListBox.Items.Add("code manually and then tap ""OK""")
        Me.helpListBox.Items.Add("to continue processing the current")
        Me.helpListBox.Items.Add("scan, or tap ""Cancel"" and the current")
        Me.helpListBox.Items.Add("scan will be ignored.")
        Me.helpListBox.Location = New System.Drawing.Point(7, 12)
        Me.helpListBox.Size = New System.Drawing.Size(226, 184)
        '
        'MsMsgInvalidRoutingHelp
        '
        Me.ClientSize = New System.Drawing.Size(234, 288)
        Me.ControlBox = False
        Me.Controls.Add(Me.helpListBox)
        Me.Controls.Add(Me.OKButton)
        Me.Text = "Invalid Routing Help"

    End Sub

#End Region

    Private Sub OKButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles OKButton.Click

        Me.Close()

    End Sub

    Private Sub errorDetailsButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)

        Dim errorLogDisplayForm As errorLogForm = New errorLogForm(errorMessage)
        errorLogDisplayForm.ShowDialog()

    End Sub

End Class