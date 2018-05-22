Public Class CN41Entry
    Inherits System.Windows.Forms.Form
    Friend WithEvents title As System.Windows.Forms.Label
    Friend WithEvents CN41 As System.Windows.Forms.TextBox
    Friend WithEvents OK As System.Windows.Forms.Button
    Friend WithEvents Upgraded As System.Windows.Forms.Button
    Friend WithEvents CN41Label As System.Windows.Forms.Label

    Private outputField As System.Windows.Forms.Control

#Region " Windows Form Designer generated code "

    Public Sub New(ByRef output As System.Windows.Forms.Control)
        MyBase.New()

        'This call is required by the Windows Form Designer.
        InitializeComponent()

        'Add any initialization after the InitializeComponent() call
        Me.outputField = output

    End Sub

    Protected Overloads Overrides Sub Dispose(ByVal disposing As Boolean)
        MyBase.Dispose(disposing)
    End Sub

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    Friend WithEvents MainMenu1 As System.Windows.Forms.MainMenu
#If deviceType <> "PC" Then
    Friend WithEvents InputPanel1 As Microsoft.WindowsCE.Forms.InputPanel
#End If
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.title = New System.Windows.Forms.Label
        Me.CN41 = New System.Windows.Forms.TextBox
        Me.OK = New System.Windows.Forms.Button
        Me.Upgraded = New System.Windows.Forms.Button
        Me.CN41Label = New System.Windows.Forms.Label
        Me.MainMenu1 = New System.Windows.Forms.MainMenu
#If devicetype <> "PC" Then
        Me.InputPanel1 = New Microsoft.WindowsCE.Forms.InputPanel
#End If
        '
        'title
        '
        Me.title.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold)
        Me.title.Location = New System.Drawing.Point(72, 16)
        Me.title.Size = New System.Drawing.Size(72, 20)
        Me.title.Text = "ISAL Mail"
        '
        'CN41
        '
        Me.CN41.Location = New System.Drawing.Point(104, 48)
        Me.CN41.Text = ""
        '
        'OK
        '
        Me.OK.Location = New System.Drawing.Point(24, 88)
        Me.OK.Text = "OK"
        '
        'Upgraded
        '
        Me.Upgraded.Location = New System.Drawing.Point(104, 88)
        Me.Upgraded.Size = New System.Drawing.Size(96, 20)
        Me.Upgraded.Text = "Upgraded ISAL"
        '
        'CN41Label
        '
        Me.CN41Label.Location = New System.Drawing.Point(24, 48)
        Me.CN41Label.Size = New System.Drawing.Size(72, 20)
        Me.CN41Label.Text = "CN41 Code"
        '
        'CN41Entry
        '
        Me.ClientSize = New System.Drawing.Size(240, 312)
        Me.ControlBox = False
        Me.Controls.Add(Me.CN41Label)
        Me.Controls.Add(Me.Upgraded)
        Me.Controls.Add(Me.OK)
        Me.Controls.Add(Me.CN41)
        Me.Controls.Add(Me.title)
        Me.Menu = Me.MainMenu1
        Me.Text = "CN41Entry"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized

    End Sub

#End Region

    Private Sub OK_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles OK.Click
        If isNonNullString(Me.CN41.Text.Trim()) Then
            Me.outputField.Text = Me.CN41.Text.Trim()
            Me.Close()
        Else
            MsgBox("Please Enter CN41 Code")
            Exit Sub
        End If
    End Sub

    Private Sub Upgraded_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Upgraded.Click
        Me.outputField.Text = "Upgraded ISAL"
        Me.Close()
    End Sub

    Private Sub CN41Entry_Activated(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Activated
        Me.WindowState = FormWindowState.Maximized
    End Sub

    Private Sub CN41Entry_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.Hide()
        Me.Show()
        Me.WindowState = FormWindowState.Maximized
    End Sub

    Private Sub CN41_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles CN41.GotFocus
#If deviceType <> "PC" Then
        If userSpecRecord.showKeyboardOnFocus Then Me.InputPanel1.Enabled = True
#End If
    End Sub
End Class
