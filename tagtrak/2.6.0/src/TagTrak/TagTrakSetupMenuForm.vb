Public Class tagTrakTagTrakSetupMenuForm
    Inherits System.Windows.Forms.Form


#Region " Windows Form Designer generated code "

    Public Sub New()
        MyBase.New()

        'This call is required by the Windows Form Designer.
        InitializeComponent()

        beepOnScanCheckBox.Checked = userSpecRecord.beepOnScan
        buzzOnScanCheckBox.Checked = userSpecRecord.buzzOnScan

#If deviceType <> "PC" Then
        buzzLengthHScrollBar.Value = userSpecRecord.buzzLength
#End If

        autoShowKeyboardCheckbox.Checked = userSpecRecord.showKeyboardOnFocus

        'Add any initialization after the InitializeComponent() call

    End Sub

    Protected Overloads Overrides Sub Dispose(ByVal disposing As Boolean)
        MyBase.Dispose(disposing)
    End Sub

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    Friend WithEvents buzzLengthHScrollBar As System.Windows.Forms.HScrollBar
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents OKButton As System.Windows.Forms.Button
    Friend WithEvents cancelButton As System.Windows.Forms.Button
    Friend WithEvents beepOnScanCheckBox As System.Windows.Forms.CheckBox
    Friend WithEvents buzzOnScanCheckBox As System.Windows.Forms.CheckBox
    Friend WithEvents buzzLengthPanel As System.Windows.Forms.Panel
    Friend WithEvents autoShowKeyboardCheckbox As System.Windows.Forms.CheckBox
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.buzzLengthHScrollBar = New System.Windows.Forms.HScrollBar
        Me.beepOnScanCheckBox = New System.Windows.Forms.CheckBox
        Me.buzzOnScanCheckBox = New System.Windows.Forms.CheckBox
        Me.Label2 = New System.Windows.Forms.Label
        Me.Label3 = New System.Windows.Forms.Label
        Me.Label4 = New System.Windows.Forms.Label
        Me.autoShowKeyboardCheckbox = New System.Windows.Forms.CheckBox
        Me.OKButton = New System.Windows.Forms.Button
        Me.cancelButton = New System.Windows.Forms.Button
        Me.buzzLengthPanel = New System.Windows.Forms.Panel
        '
        'buzzLengthHScrollBar
        '
        Me.buzzLengthHScrollBar.LargeChange = 100
        Me.buzzLengthHScrollBar.Location = New System.Drawing.Point(14, 33)
        Me.buzzLengthHScrollBar.Maximum = 2000
        Me.buzzLengthHScrollBar.Minimum = 1
        Me.buzzLengthHScrollBar.Size = New System.Drawing.Size(154, 17)
        Me.buzzLengthHScrollBar.SmallChange = 10
        Me.buzzLengthHScrollBar.Value = 1
        '
        'beepOnScanCheckBox
        '
        Me.beepOnScanCheckBox.Location = New System.Drawing.Point(25, 5)
        Me.beepOnScanCheckBox.Size = New System.Drawing.Size(157, 19)
        Me.beepOnScanCheckBox.Text = "Beep"
        '
        'buzzOnScanCheckBox
        '
        Me.buzzOnScanCheckBox.Location = New System.Drawing.Point(25, 38)
        Me.buzzOnScanCheckBox.Size = New System.Drawing.Size(157, 19)
        Me.buzzOnScanCheckBox.Text = "Buzz"
        '
        'Label2
        '
        Me.Label2.Location = New System.Drawing.Point(44, 6)
        Me.Label2.Size = New System.Drawing.Size(95, 15)
        Me.Label2.Text = "Buzz length"
        Me.Label2.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'Label3
        '
        Me.Label3.Location = New System.Drawing.Point(14, 63)
        Me.Label3.Size = New System.Drawing.Size(40, 16)
        Me.Label3.Text = "Short"
        '
        'Label4
        '
        Me.Label4.Location = New System.Drawing.Point(136, 62)
        Me.Label4.Size = New System.Drawing.Size(32, 19)
        Me.Label4.Text = "Long"
        Me.Label4.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'autoShowKeyboardCheckbox
        '
        Me.autoShowKeyboardCheckbox.Location = New System.Drawing.Point(25, 173)
        Me.autoShowKeyboardCheckbox.Size = New System.Drawing.Size(199, 19)
        Me.autoShowKeyboardCheckbox.Text = "Automatically Pop-up Keyboard"
        '
        'OKButton
        '
        Me.OKButton.Location = New System.Drawing.Point(40, 213)
        Me.OKButton.Size = New System.Drawing.Size(60, 28)
        Me.OKButton.Text = "OK"
        '
        'cancelButton
        '
        Me.cancelButton.Location = New System.Drawing.Point(125, 213)
        Me.cancelButton.Size = New System.Drawing.Size(60, 28)
        Me.cancelButton.Text = "Cancel"
        '
        'buzzLengthPanel
        '
        Me.buzzLengthPanel.Controls.Add(Me.buzzLengthHScrollBar)
        Me.buzzLengthPanel.Controls.Add(Me.Label2)
        Me.buzzLengthPanel.Controls.Add(Me.Label3)
        Me.buzzLengthPanel.Controls.Add(Me.Label4)
        Me.buzzLengthPanel.Location = New System.Drawing.Point(27, 76)
        Me.buzzLengthPanel.Size = New System.Drawing.Size(196, 88)
        '
        'tagTrakTagTrakSetupMenuForm
        '
        Me.ClientSize = New System.Drawing.Size(234, 288)
        Me.ControlBox = False
        Me.Controls.Add(Me.buzzLengthPanel)
        Me.Controls.Add(Me.cancelButton)
        Me.Controls.Add(Me.OKButton)
        Me.Controls.Add(Me.autoShowKeyboardCheckbox)
        Me.Controls.Add(Me.buzzOnScanCheckBox)
        Me.Controls.Add(Me.beepOnScanCheckBox)
        Me.Text = "Scanner Options"

    End Sub

#End Region

    Private Sub cancelButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cancelButton.Click
        'Me.Close()
        Me.Hide()
    End Sub

    Private Sub OKButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles OKButton.Click

        userSpecRecord.beepOnScan = beepOnScanCheckBox.Checked
        userSpecRecord.buzzOnScan = buzzOnScanCheckBox.Checked
        userSpecRecord.buzzLength = Me.buzzLengthHScrollBar.Value
        userSpecRecord.showKeyboardOnFocus = Me.autoShowKeyboardCheckbox.Checked

        'Me.Close()
        Me.Hide()

    End Sub

    Private Sub buzzOnScanCheckBox_CheckStateChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles buzzOnScanCheckBox.CheckStateChanged

        If buzzOnScanCheckBox.Checked Then
            Me.buzzLengthPanel.Enabled = True
        Else
            Me.buzzLengthPanel.Enabled = False
        End If

    End Sub

End Class
