Public Class getWeightForm
    Inherits System.Windows.Forms.Form
    Friend WithEvents weightTextBox As System.Windows.Forms.TextBox
    Friend WithEvents OKButton As System.Windows.Forms.Button
    Friend WithEvents cancelButton As System.Windows.Forms.Button
    Friend WithEvents Label1 As System.Windows.Forms.Label

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
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.weightTextBox = New System.Windows.Forms.TextBox
        Me.OKButton = New System.Windows.Forms.Button
        Me.cancelButton = New System.Windows.Forms.Button
        Me.Label1 = New System.Windows.Forms.Label
        Me.MainMenu1 = New System.Windows.Forms.MainMenu
        '
        'weightTextBox
        '
        Me.weightTextBox.Location = New System.Drawing.Point(30, 76)
        Me.weightTextBox.Size = New System.Drawing.Size(125, 22)
        Me.weightTextBox.Text = ""
        '
        'OKButton
        '
        Me.OKButton.Location = New System.Drawing.Point(20, 120)
        Me.OKButton.Size = New System.Drawing.Size(62, 33)
        Me.OKButton.Text = "OK"
        '
        'cancelButton
        '
        Me.cancelButton.Location = New System.Drawing.Point(104, 120)
        Me.cancelButton.Size = New System.Drawing.Size(62, 33)
        Me.cancelButton.Text = "Cancel"
        '
        'Label1
        '
        Me.Label1.Location = New System.Drawing.Point(12, 15)
        Me.Label1.Size = New System.Drawing.Size(161, 49)
        Me.Label1.Text = "Please Specify A Valid Weight For This Item Between 0 and 65,536"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'getWeightForm
        '
        Me.ClientSize = New System.Drawing.Size(207, 292)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.cancelButton)
        Me.Controls.Add(Me.OKButton)
        Me.Controls.Add(Me.weightTextBox)
        Me.Menu = Me.MainMenu1
        Me.Text = "Specify Weight"

    End Sub

#End Region

    Private Sub formOnLoad(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        If lockDown Then
            MyBase.MaximizeBox = False
            MyBase.MinimizeBox = False
            MyBase.ControlBox = False
            MyBase.WindowState = FormWindowState.Maximized
        End If

        weightTextBox.Focus()

    End Sub

    Private Sub OKButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles OKButton.Click

        Dim weightString As String = Trim(weightTextBox.Text)
        Dim weightValue As Integer

        If Not isNonNullString(weightString) Then
            MsgBox("You must specify a valid weight between 1 and 65,536")
            Exit Sub
        End If

        If Not IsInteger(weightString) Then
            MsgBox("You must specify a valid weight between 1 and 65,536")
            Exit Sub
        End If

        Try
            getWeightDialogResult = Integer.Parse(weightString, Globalization.NumberStyles.AllowThousands)
        Catch ex As Exception
            MsgBox("You must specify a valid weight between 1 and 65,536")
            Exit Sub
        End Try

        If getWeightDialogResult <= 0 Then
            MsgBox("You must specify a valid weight between 1 and 65,536")
            Exit Sub
        End If

        If getWeightDialogResult > 65536 Then
            MsgBox("You must specify a valid weight between 1 and 65,536")
            Exit Sub
        End If

        MyBase.DialogResult = DialogResult.OK

        Me.Close()

    End Sub

    Private Sub cancelButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cancelButton.Click

        MyBase.DialogResult = DialogResult.Cancel

        Me.Close()

    End Sub

End Class
