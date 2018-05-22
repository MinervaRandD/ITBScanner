Public Class errorLogForm

    Inherits System.Windows.Forms.Form

    Dim exitString As String = ""

    Dim ftpConnectionDelay As Integer
    Dim attemptNumber As String

#Region " Windows Form Designer generated code "

    Public Sub New(ByVal errorMessage As String)
        MyBase.New()

        'This call is required by the Windows Form Designer.
        InitializeComponent()

        If Not isNonNullString(errorMessage) Then Exit Sub

        Dim errorMessageSet() As String = errorMessage.Split("|")

        Dim returnSequence As String = Chr(13) & Chr(10)

        Me.errorLogTextBox.Text = ""

        Dim ilmt As Integer = errorMessageSet.Length - 1

        Dim i As Integer = 0

        While i < ilmt
            Me.errorLogTextBox.Text &= errorMessageSet(i) & returnSequence
            Me.errorLogTextBox.Text &= "----------------------------" & returnSequence
            i += 1
        end while

        Me.errorLogTextBox.Text &= errorMessageSet(ilmt)

    End Sub

    Protected Overloads Overrides Sub Dispose(ByVal disposing As Boolean)
        MyBase.Dispose(disposing)
    End Sub

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    Friend WithEvents message1TextBox As System.Windows.Forms.Label
    Friend WithEvents Button1 As System.Windows.Forms.Button
    Friend WithEvents errorLogTextBox As System.Windows.Forms.TextBox
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.message1TextBox = New System.Windows.Forms.Label
        Me.Button1 = New System.Windows.Forms.Button
        Me.errorLogTextBox = New System.Windows.Forms.TextBox
        '
        'message1TextBox
        '
        Me.message1TextBox.Font = New System.Drawing.Font("Tahoma", 14.25!, System.Drawing.FontStyle.Regular)
        Me.message1TextBox.Location = New System.Drawing.Point(12, 17)
        Me.message1TextBox.Size = New System.Drawing.Size(214, 26)
        Me.message1TextBox.Text = "Error Details"
        Me.message1TextBox.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'Button1
        '
        Me.Button1.Location = New System.Drawing.Point(54, 223)
        Me.Button1.Size = New System.Drawing.Size(128, 26)
        Me.Button1.Text = "Close"
        '
        'errorLogTextBox
        '
        Me.errorLogTextBox.AcceptsReturn = True
        Me.errorLogTextBox.Location = New System.Drawing.Point(12, 52)
        Me.errorLogTextBox.Multiline = True
        Me.errorLogTextBox.ScrollBars = System.Windows.Forms.ScrollBars.Both
        Me.errorLogTextBox.Size = New System.Drawing.Size(216, 158)
        Me.errorLogTextBox.Text = ""
        '
        'errorLogForm
        '
        Me.ClientSize = New System.Drawing.Size(234, 288)
        Me.ControlBox = False
        Me.Controls.Add(Me.errorLogTextBox)
        Me.Controls.Add(Me.Button1)
        Me.Controls.Add(Me.message1TextBox)
        Me.Text = "Error Details"

    End Sub

#End Region

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click

        'Me.Visible = False
        Me.Close()

        Application.DoEvents()

    End Sub
End Class


