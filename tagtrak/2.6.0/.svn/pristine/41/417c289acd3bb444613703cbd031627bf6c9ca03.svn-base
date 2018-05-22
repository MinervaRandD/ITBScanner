Public Class tagTrakMessageForm
    Inherits System.Windows.Forms.Form
    Friend WithEvents messagesFormLogoPictureBox As System.Windows.Forms.PictureBox
    Friend WithEvents totalMessageCountLabel As System.Windows.Forms.Label
    Friend WithEvents Label24 As System.Windows.Forms.Label
    Friend WithEvents messageNumberLabel As System.Windows.Forms.Label
    Friend WithEvents Label16 As System.Windows.Forms.Label
    Friend WithEvents nextMessageButton As System.Windows.Forms.Button
    Friend WithEvents previousMessageButton As System.Windows.Forms.Button
    Friend WithEvents messsagesTextBox As System.Windows.Forms.TextBox

#Region " Windows Form Designer generated code "

    Public Sub New()
        MyBase.New()

        'This call is required by the Windows Form Designer.
        InitializeComponent()

        'Add any initialization after the InitializeComponent() call

        loadFormLogo()

        Me.MainMenu1.MenuItems.Clear()
        Me.MainMenu1.MenuItems.Add(NavigationMainMenu.Singlet)
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
        Dim resources As System.Resources.ResourceManager = New System.Resources.ResourceManager(GetType(tagTrakMessageForm))
        Me.messagesFormLogoPictureBox = New System.Windows.Forms.PictureBox
        Me.totalMessageCountLabel = New System.Windows.Forms.Label
        Me.Label24 = New System.Windows.Forms.Label
        Me.messageNumberLabel = New System.Windows.Forms.Label
        Me.Label16 = New System.Windows.Forms.Label
        Me.nextMessageButton = New System.Windows.Forms.Button
        Me.previousMessageButton = New System.Windows.Forms.Button
        Me.messsagesTextBox = New System.Windows.Forms.TextBox
        Me.MainMenu1 = New System.Windows.Forms.MainMenu
#If devicetype <> "PC" Then
        Me.InputPanel1 = New Microsoft.WindowsCE.Forms.InputPanel
#End If
        '
        'messagesFormLogoPictureBox
        '
        Me.messagesFormLogoPictureBox.Image = CType(resources.GetObject("messagesFormLogoPictureBox.Image"), System.Drawing.Image)
        Me.messagesFormLogoPictureBox.Location = New System.Drawing.Point(9, 7)
        Me.messagesFormLogoPictureBox.Size = New System.Drawing.Size(100, 48)
        Me.messagesFormLogoPictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        '
        'totalMessageCountLabel
        '
        Me.totalMessageCountLabel.Location = New System.Drawing.Point(213, 38)
        Me.totalMessageCountLabel.Size = New System.Drawing.Size(38, 16)
        Me.totalMessageCountLabel.Text = "0"
        Me.totalMessageCountLabel.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'Label24
        '
        Me.Label24.Location = New System.Drawing.Point(185, 38)
        Me.Label24.Size = New System.Drawing.Size(25, 16)
        Me.Label24.Text = "Of"
        Me.Label24.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'messageNumberLabel
        '
        Me.messageNumberLabel.Location = New System.Drawing.Point(148, 38)
        Me.messageNumberLabel.Size = New System.Drawing.Size(34, 16)
        Me.messageNumberLabel.Text = "0"
        Me.messageNumberLabel.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'Label16
        '
        Me.Label16.Location = New System.Drawing.Point(118, 38)
        Me.Label16.Size = New System.Drawing.Size(27, 16)
        Me.Label16.Text = "Msg"
        '
        'nextMessageButton
        '
        Me.nextMessageButton.Location = New System.Drawing.Point(172, 8)
        Me.nextMessageButton.Size = New System.Drawing.Size(60, 24)
        Me.nextMessageButton.Text = "Next >"
        '
        'previousMessageButton
        '
        Me.previousMessageButton.Location = New System.Drawing.Point(112, 8)
        Me.previousMessageButton.Size = New System.Drawing.Size(56, 24)
        Me.previousMessageButton.Text = "< Prev"
        '
        'messsagesTextBox
        '
        Me.messsagesTextBox.AcceptsReturn = True
        Me.messsagesTextBox.AcceptsTab = True
        Me.messsagesTextBox.Location = New System.Drawing.Point(9, 58)
        Me.messsagesTextBox.Multiline = True
        Me.messsagesTextBox.ScrollBars = System.Windows.Forms.ScrollBars.Both
        Me.messsagesTextBox.Size = New System.Drawing.Size(228, 206)
        Me.messsagesTextBox.Text = ""
        '
        'InputPanel1
        '
        '
        'tagTrakMessageForm
        '
        Me.ClientSize = New System.Drawing.Size(240, 288)
        Me.ControlBox = False
        Me.Controls.Add(Me.messagesFormLogoPictureBox)
        Me.Controls.Add(Me.totalMessageCountLabel)
        Me.Controls.Add(Me.Label24)
        Me.Controls.Add(Me.messageNumberLabel)
        Me.Controls.Add(Me.Label16)
        Me.Controls.Add(Me.nextMessageButton)
        Me.Controls.Add(Me.previousMessageButton)
        Me.Controls.Add(Me.messsagesTextBox)
        Me.MaximizeBox = False
        Me.Menu = Me.MainMenu1
        Me.MinimizeBox = False
        Me.Text = "Messages"

    End Sub

#End Region

    'Private Sub messagesFormLogoPictureBox_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles messagesFormLogoPictureBox.Click
    '    NavigationMenu.Singlet().Show(Me.messagesFormLogoPictureBox, New System.Drawing.Point(0, 0))
    'End Sub

    Private Sub loadFormLogo()

        Dim FormLogoPath As String

        FormLogoPath = TagTrakConfigDirectory & "\" & userSpecRecord.userName & "scanFormLogo.bmp"

        If System.IO.File.Exists(FormLogoPath) Then
            Me.messagesFormLogoPictureBox.Image = New System.Drawing.Bitmap(FormLogoPath)
            Exit Sub
        End If

        FormLogoPath = TagTrakConfigDirectory & "\scanFormLogo.bmp"

        If System.IO.File.Exists(FormLogoPath) Then
            Me.messagesFormLogoPictureBox.Image = New System.Drawing.Bitmap(FormLogoPath)
        End If

    End Sub

#If deviceType <> "PC" Then
    Private Sub InputPanel1_EnabledChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles InputPanel1.EnabledChanged
        If Me.InputPanel1.Enabled Then
            Me.messsagesTextBox.Height = 206 - Me.InputPanel1.Bounds.Height
        Else
            Me.messsagesTextBox.Height = 206
        End If
    End Sub
#End If

End Class
