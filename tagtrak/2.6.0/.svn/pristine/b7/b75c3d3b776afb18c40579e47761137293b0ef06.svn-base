Public Class AdminSubConfigForm
    Inherits System.Windows.Forms.Form

    Dim ignoreButtonSpecChange As Boolean = True

    Dim userInfoTextBoxCollection() As Windows.Forms.TextBox
    Dim ftpInfoTextBoxCollection() As Windows.Forms.TextBox
    Dim buttonInfoTextBoxCollection() As Windows.Forms.TextBox


#Region " Windows Form Designer generated code "

    Public Sub New()

        MyBase.New()

        Cursor.Current = Cursors.WaitCursor

        'This call is required by the Windows Form Designer.
        InitializeComponent()

        ftpLoginIDTextBox.Text = userSpecRecord.ftpLoginID
        ftpPasswordTextBox.Text = userSpecRecord.ftpPassword
        ftpHostTextBox.Text = userSpecRecord.ftpHostName
        ftpPortTextBox.Text = userSpecRecord.ftpPortNumber

        ipAddressLabel.Text = Util.getIPAddress()

        applyConfigChangesButton.Enabled = False
        saveConfigChangesButton.Enabled = False

        Me.DialogResult = DialogResult.OK

        Cursor.Current = Cursors.Default

    End Sub

    Protected Overloads Overrides Sub Dispose(ByVal disposing As Boolean)
        MyBase.Dispose(disposing)
    End Sub

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    Friend WithEvents exitButton As System.Windows.Forms.Button
    Friend WithEvents ComboBox1 As System.Windows.Forms.ComboBox
    Friend WithEvents SizeYTextBox As System.Windows.Forms.TextBox
    Friend WithEvents applyConfigChangesButton As System.Windows.Forms.Button
    Friend WithEvents saveConfigChangesButton As System.Windows.Forms.Button
    Friend WithEvents MainMenu1 As System.Windows.Forms.MainMenu
    Friend WithEvents InputPanel1 As Microsoft.WindowsCE.Forms.InputPanel
    Friend WithEvents Label15 As System.Windows.Forms.Label
    Friend WithEvents Label22 As System.Windows.Forms.Label
    Friend WithEvents ipAddressLabel As System.Windows.Forms.Label
    Friend WithEvents ftpPasswordTextBox As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents ftpLoginIDTextBox As System.Windows.Forms.TextBox
    Friend WithEvents ftpPortTextBox As System.Windows.Forms.TextBox
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents ftpHostTextBox As System.Windows.Forms.TextBox
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.exitButton = New System.Windows.Forms.Button
        Me.applyConfigChangesButton = New System.Windows.Forms.Button
        Me.saveConfigChangesButton = New System.Windows.Forms.Button
        Me.MainMenu1 = New System.Windows.Forms.MainMenu
        Me.InputPanel1 = New Microsoft.WindowsCE.Forms.InputPanel
        Me.Label15 = New System.Windows.Forms.Label
        Me.Label22 = New System.Windows.Forms.Label
        Me.ipAddressLabel = New System.Windows.Forms.Label
        Me.ftpPasswordTextBox = New System.Windows.Forms.TextBox
        Me.Label1 = New System.Windows.Forms.Label
        Me.Label2 = New System.Windows.Forms.Label
        Me.ftpLoginIDTextBox = New System.Windows.Forms.TextBox
        Me.ftpPortTextBox = New System.Windows.Forms.TextBox
        Me.Label9 = New System.Windows.Forms.Label
        Me.Label10 = New System.Windows.Forms.Label
        Me.ftpHostTextBox = New System.Windows.Forms.TextBox
        '
        'exitButton
        '
        Me.exitButton.Location = New System.Drawing.Point(160, 224)
        Me.exitButton.Size = New System.Drawing.Size(64, 21)
        Me.exitButton.Text = "Exit"
        '
        'applyConfigChangesButton
        '
        Me.applyConfigChangesButton.Location = New System.Drawing.Point(16, 224)
        Me.applyConfigChangesButton.Size = New System.Drawing.Size(64, 21)
        Me.applyConfigChangesButton.Text = "Apply"
        '
        'saveConfigChangesButton
        '
        Me.saveConfigChangesButton.Location = New System.Drawing.Point(88, 224)
        Me.saveConfigChangesButton.Size = New System.Drawing.Size(64, 21)
        Me.saveConfigChangesButton.Text = "Save"
        '
        'Label15
        '
        Me.Label15.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular)
        Me.Label15.Location = New System.Drawing.Point(37, 24)
        Me.Label15.Size = New System.Drawing.Size(174, 16)
        Me.Label15.Text = "FTP Configuration"
        Me.Label15.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'Label22
        '
        Me.Label22.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular)
        Me.Label22.Location = New System.Drawing.Point(5, 176)
        Me.Label22.Size = New System.Drawing.Size(82, 17)
        Me.Label22.Text = "IP Address:"
        '
        'ipAddressLabel
        '
        Me.ipAddressLabel.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular)
        Me.ipAddressLabel.Location = New System.Drawing.Point(95, 176)
        Me.ipAddressLabel.Size = New System.Drawing.Size(134, 21)
        '
        'ftpPasswordTextBox
        '
        Me.ftpPasswordTextBox.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular)
        Me.ftpPasswordTextBox.Location = New System.Drawing.Point(95, 136)
        Me.ftpPasswordTextBox.Size = New System.Drawing.Size(133, 22)
        Me.ftpPasswordTextBox.Text = ""
        '
        'Label1
        '
        Me.Label1.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular)
        Me.Label1.Location = New System.Drawing.Point(5, 112)
        Me.Label1.Size = New System.Drawing.Size(78, 17)
        Me.Label1.Text = "Ftp Login ID:"
        '
        'Label2
        '
        Me.Label2.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular)
        Me.Label2.Location = New System.Drawing.Point(5, 136)
        Me.Label2.Size = New System.Drawing.Size(82, 17)
        Me.Label2.Text = "Ftp Password:"
        '
        'ftpLoginIDTextBox
        '
        Me.ftpLoginIDTextBox.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular)
        Me.ftpLoginIDTextBox.Location = New System.Drawing.Point(95, 112)
        Me.ftpLoginIDTextBox.Size = New System.Drawing.Size(133, 22)
        Me.ftpLoginIDTextBox.Text = ""
        '
        'ftpPortTextBox
        '
        Me.ftpPortTextBox.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular)
        Me.ftpPortTextBox.Location = New System.Drawing.Point(95, 88)
        Me.ftpPortTextBox.Size = New System.Drawing.Size(133, 22)
        Me.ftpPortTextBox.Text = ""
        '
        'Label9
        '
        Me.Label9.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular)
        Me.Label9.Location = New System.Drawing.Point(5, 64)
        Me.Label9.Size = New System.Drawing.Size(70, 17)
        Me.Label9.Text = "Ftp Host:"
        '
        'Label10
        '
        Me.Label10.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular)
        Me.Label10.Location = New System.Drawing.Point(5, 88)
        Me.Label10.Size = New System.Drawing.Size(76, 17)
        Me.Label10.Text = "Ftp Port:"
        '
        'ftpHostTextBox
        '
        Me.ftpHostTextBox.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular)
        Me.ftpHostTextBox.Location = New System.Drawing.Point(95, 64)
        Me.ftpHostTextBox.Size = New System.Drawing.Size(133, 22)
        Me.ftpHostTextBox.Text = ""
        '
        'AdminSubConfigForm
        '
        Me.ClientSize = New System.Drawing.Size(234, 280)
        Me.ControlBox = False
        Me.Controls.Add(Me.Label15)
        Me.Controls.Add(Me.Label22)
        Me.Controls.Add(Me.ipAddressLabel)
        Me.Controls.Add(Me.ftpPasswordTextBox)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.ftpLoginIDTextBox)
        Me.Controls.Add(Me.ftpPortTextBox)
        Me.Controls.Add(Me.Label9)
        Me.Controls.Add(Me.Label10)
        Me.Controls.Add(Me.ftpHostTextBox)
        Me.Controls.Add(Me.saveConfigChangesButton)
        Me.Controls.Add(Me.applyConfigChangesButton)
        Me.Controls.Add(Me.exitButton)
        Me.Menu = Me.MainMenu1
        Me.Text = "Config Management"

    End Sub

#End Region


    Private Sub exitButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles exitButton.Click

        processUserSpecRecordChange()

        Me.Hide()

    End Sub

    Private Sub processConfigurationChanges()

        Dim result As String

        userSpecRecord.ftpLoginID = Trim(ftpLoginIDTextBox.Text)
        userSpecRecord.ftpPassword = Trim(ftpPasswordTextBox.Text)
        userSpecRecord.ftpHostName = Trim(ftpHostTextBox.Text)
        userSpecRecord.ftpPortNumber = Trim(ftpPortTextBox.Text)

        currentAdminLoginForm.hideMenuBarButton.Visible = userSpecRecord.lockDownReleasedInAdminForm
        currentAdminLoginForm.hideMenuBarButton.Enabled = userSpecRecord.lockDownReleasedInAdminForm
        currentAdminLoginForm.showMenuBarButton.Visible = userSpecRecord.lockDownReleasedInAdminForm
        currentAdminLoginForm.showMenuBarButton.Enabled = userSpecRecord.lockDownReleasedInAdminForm

        applyConfigChangesButton.Enabled = False

    End Sub

    Private Sub applyConfigChangesButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles applyConfigChangesButton.Click

        processConfigurationChanges()

    End Sub


    Private Sub saveConfigurationChanges()

        processConfigurationChanges()
        userSpecRecord.updateXMLDocument()
        userSpecRecord.saveXMLDocument()

        saveConfigChangesButton.Enabled = False

    End Sub

    Private Sub processUserSpecRecordChange()

        If applyConfigChangesButton.Enabled Then

            Dim msgResult As MsgBoxResult = MsgBox("Apply Changes To Current User Configuration?", MsgBoxStyle.YesNo, "Save Changes?")
            If msgResult = MsgBoxResult.Yes Then
                processConfigurationChanges()
            End If

        End If

        If saveConfigChangesButton.Enabled Then

            Dim msgResult As MsgBoxResult = MsgBox("Save Current User Configuration Changes (Make Changes Permanent)?", MsgBoxStyle.YesNo, "Save Changes?")
            If msgResult = MsgBoxResult.Yes Then
                saveConfigurationChanges()
            End If

        End If

    End Sub

    Private Sub currentConfigChanged()
        applyConfigChangesButton.Enabled = True
        saveConfigChangesButton.Enabled = True
    End Sub


    Private Sub ftpHostTextBox_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ftpHostTextBox.TextChanged
        currentConfigChanged()
    End Sub

    Private Sub ftpPortTextBox_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ftpPortTextBox.TextChanged
        currentConfigChanged()
    End Sub

    Private Sub ftpLoginIDTextBox_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ftpLoginIDTextBox.TextChanged
        currentConfigChanged()
    End Sub

    Private Sub ftpPasswordTextBox_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ftpPasswordTextBox.TextChanged
        currentConfigChanged()
    End Sub


    Private Sub saveConfigChangesButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles saveConfigChangesButton.Click
        saveConfigurationChanges()
    End Sub

End Class
