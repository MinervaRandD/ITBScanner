Public Class DestinationWarning
    Inherits System.Windows.Forms.Form
    Friend WithEvents btnYes As System.Windows.Forms.Button
    Friend WithEvents btnNo As System.Windows.Forms.Button
    Friend WithEvents lblDestinationWarning As System.Windows.Forms.Label

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
        Dim resources As System.Resources.ResourceManager = New System.Resources.ResourceManager(GetType(DestinationWarning))
        Me.lblDestinationWarning = New System.Windows.Forms.Label
        Me.btnYes = New System.Windows.Forms.Button
        Me.btnNo = New System.Windows.Forms.Button
        '
        'lblDestinationWarning
        '
        Me.lblDestinationWarning.Location = New System.Drawing.Point(48, 40)
        Me.lblDestinationWarning.Size = New System.Drawing.Size(152, 112)
        Me.lblDestinationWarning.Text = "This piece of mail has different destination from the first piece of mail you put" & _
        " in your cart. Are you sure you want to put it in the cart?"
        '
        'btnYes
        '
        Me.btnYes.Location = New System.Drawing.Point(40, 192)
        Me.btnYes.Text = "Yes"
        '
        'btnNo
        '
        Me.btnNo.Location = New System.Drawing.Point(128, 192)
        Me.btnNo.Text = "No"
        '
        'DestinationWarning
        '
        Me.ControlBox = False
        Me.Controls.Add(Me.btnNo)
        Me.Controls.Add(Me.btnYes)
        Me.Controls.Add(Me.lblDestinationWarning)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Text = "DestinationWarning"

    End Sub

#End Region

    Private Sub btnYes_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnYes.Click
        Me.DialogResult = DialogResult.Yes
        Me.Close()
    End Sub


    Private Sub btnNo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnNo.Click
        Me.DialogResult = DialogResult.No
        Me.Close()
    End Sub
End Class
