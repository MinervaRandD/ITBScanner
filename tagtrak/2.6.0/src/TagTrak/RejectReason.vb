Public Class RejectReason
    Inherits System.Windows.Forms.Form
    Friend WithEvents Prompt As System.Windows.Forms.Label
    Friend WithEvents Reason As System.Windows.Forms.TextBox
    Friend WithEvents OK As System.Windows.Forms.Button
    Friend WithEvents Cancel As System.Windows.Forms.Button
    Private LastRet As String = ""

    Public ReadOnly Property ReasonVal() As String
        Get
            Return LastRet
        End Get
    End Property


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
    Friend WithEvents MainMenu1 As System.Windows.Forms.MainMenu
#If deviceType <> "PC" Then
    Friend WithEvents InputPanel1 As Microsoft.WindowsCE.Forms.InputPanel
#End If
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.Prompt = New System.Windows.Forms.Label
        Me.Reason = New System.Windows.Forms.TextBox
        Me.OK = New System.Windows.Forms.Button
        Me.Cancel = New System.Windows.Forms.Button
        Me.MainMenu1 = New System.Windows.Forms.MainMenu
#If devicetype <> "PC" Then
        Me.InputPanel1 = New Microsoft.WindowsCE.Forms.InputPanel
#End If
        '
        'Prompt
        '
        Me.Prompt.Location = New System.Drawing.Point(16, 24)
        Me.Prompt.Size = New System.Drawing.Size(208, 20)
        Me.Prompt.Text = "Please Specify A Return Reason"
        '
        'Reason
        '
        Me.Reason.Location = New System.Drawing.Point(16, 56)
        Me.Reason.Size = New System.Drawing.Size(208, 22)
        Me.Reason.Text = ""
        '
        'OK
        '
        Me.OK.Location = New System.Drawing.Point(64, 96)
        Me.OK.Text = "OK"
        '
        'Cancel
        '
        Me.Cancel.Location = New System.Drawing.Point(144, 96)
        Me.Cancel.Text = "Cancel"
        '
        'RejectReason
        '
        Me.ClientSize = New System.Drawing.Size(240, 320)
        Me.ControlBox = False
        Me.Controls.Add(Me.Cancel)
        Me.Controls.Add(Me.OK)
        Me.Controls.Add(Me.Reason)
        Me.Controls.Add(Me.Prompt)
        Me.Menu = Me.MainMenu1
        Me.Text = "Return Reason"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized

    End Sub

#End Region

    Private Sub OK_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles OK.Click
        If Me.ValidateForm Then
            DialogResult = DialogResult.OK
            LastRet = Reason.Text
            Close()
        End If
    End Sub

    Private Function ValidateForm() As Boolean
        If isNonNullString(Me.Reason.Text) Then
            Return True
        Else
            MsgBox("Please enter a return reason")
            Return False
        End If
    End Function

    Private Sub Cancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Cancel.Click
        DialogResult = DialogResult.Abort
        Close()
    End Sub

    Private Sub RejectReason_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.WindowState = FormWindowState.Maximized
    End Sub

    Private Sub Reason_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles Reason.GotFocus
#If deviceType <> "PC" Then
        If userSpecRecord.showKeyboardOnFocus Then Me.InputPanel1.Enabled = True
#End If
    End Sub
End Class
