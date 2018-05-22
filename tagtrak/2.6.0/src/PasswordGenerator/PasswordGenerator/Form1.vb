Public Class PasswordForm
    Inherits System.Windows.Forms.Form

#Region " Windows Form Designer generated code "

    Public Sub New()
        MyBase.New()

        'This call is required by the Windows Form Designer.
        InitializeComponent()

        'Add any initialization after the InitializeComponent() call

    End Sub

    'Form overrides dispose to clean up the component list.
    Protected Overloads Overrides Sub Dispose(ByVal disposing As Boolean)
        If disposing Then
            If Not (components Is Nothing) Then
                components.Dispose()
            End If
        End If
        MyBase.Dispose(disposing)
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents adminPasswordLabel As System.Windows.Forms.Label
    Friend WithEvents dateAndTimePasswordLabel As System.Windows.Forms.Label
    Friend WithEvents exitToWindowsPasswordLabel As System.Windows.Forms.Label
    Friend WithEvents Button1 As System.Windows.Forms.Button
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents PictureBox1 As System.Windows.Forms.PictureBox
    Friend WithEvents passwordKernelTextBox As System.Windows.Forms.TextBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents locationChangePasswordLabel As System.Windows.Forms.Label
    Friend WithEvents lblLogin As System.Windows.Forms.Label
    Friend WithEvents lblLoginCode As System.Windows.Forms.Label
    Friend WithEvents lblCompleteConfig As System.Windows.Forms.Label
    Friend WithEvents lblCompleteConfigCode As System.Windows.Forms.Label
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Dim resources As System.Resources.ResourceManager = New System.Resources.ResourceManager(GetType(PasswordForm))
        Me.passwordKernelTextBox = New System.Windows.Forms.TextBox
        Me.Label1 = New System.Windows.Forms.Label
        Me.adminPasswordLabel = New System.Windows.Forms.Label
        Me.dateAndTimePasswordLabel = New System.Windows.Forms.Label
        Me.exitToWindowsPasswordLabel = New System.Windows.Forms.Label
        Me.Button1 = New System.Windows.Forms.Button
        Me.Label2 = New System.Windows.Forms.Label
        Me.Label3 = New System.Windows.Forms.Label
        Me.Label4 = New System.Windows.Forms.Label
        Me.PictureBox1 = New System.Windows.Forms.PictureBox
        Me.Label5 = New System.Windows.Forms.Label
        Me.locationChangePasswordLabel = New System.Windows.Forms.Label
        Me.lblLogin = New System.Windows.Forms.Label
        Me.lblLoginCode = New System.Windows.Forms.Label
        Me.lblCompleteConfig = New System.Windows.Forms.Label
        Me.lblCompleteConfigCode = New System.Windows.Forms.Label
        Me.SuspendLayout()
        '
        'passwordKernelTextBox
        '
        Me.passwordKernelTextBox.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.passwordKernelTextBox.Location = New System.Drawing.Point(200, 180)
        Me.passwordKernelTextBox.Name = "passwordKernelTextBox"
        Me.passwordKernelTextBox.Size = New System.Drawing.Size(189, 26)
        Me.passwordKernelTextBox.TabIndex = 0
        Me.passwordKernelTextBox.Text = ""
        '
        'Label1
        '
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(39, 182)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(145, 23)
        Me.Label1.TabIndex = 1
        Me.Label1.Text = "Enter Code String:"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'adminPasswordLabel
        '
        Me.adminPasswordLabel.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.adminPasswordLabel.Location = New System.Drawing.Point(219, 277)
        Me.adminPasswordLabel.Name = "adminPasswordLabel"
        Me.adminPasswordLabel.Size = New System.Drawing.Size(185, 23)
        Me.adminPasswordLabel.TabIndex = 2
        Me.adminPasswordLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'dateAndTimePasswordLabel
        '
        Me.dateAndTimePasswordLabel.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dateAndTimePasswordLabel.Location = New System.Drawing.Point(219, 330)
        Me.dateAndTimePasswordLabel.Name = "dateAndTimePasswordLabel"
        Me.dateAndTimePasswordLabel.Size = New System.Drawing.Size(185, 23)
        Me.dateAndTimePasswordLabel.TabIndex = 3
        Me.dateAndTimePasswordLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'exitToWindowsPasswordLabel
        '
        Me.exitToWindowsPasswordLabel.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.exitToWindowsPasswordLabel.Location = New System.Drawing.Point(219, 436)
        Me.exitToWindowsPasswordLabel.Name = "exitToWindowsPasswordLabel"
        Me.exitToWindowsPasswordLabel.Size = New System.Drawing.Size(185, 23)
        Me.exitToWindowsPasswordLabel.TabIndex = 4
        Me.exitToWindowsPasswordLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Button1
        '
        Me.Button1.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button1.Location = New System.Drawing.Point(108, 227)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(208, 28)
        Me.Button1.TabIndex = 5
        Me.Button1.Text = "Generate Passwords"
        '
        'Label2
        '
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(26, 426)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(149, 39)
        Me.Label2.TabIndex = 8
        Me.Label2.Text = "Exit To Windows Password"
        Me.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label3
        '
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(26, 318)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(136, 38)
        Me.Label3.TabIndex = 7
        Me.Label3.Text = "Date And Time Password"
        '
        'Label4
        '
        Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(26, 277)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(148, 25)
        Me.Label4.TabIndex = 6
        Me.Label4.Text = "Admin Password"
        Me.Label4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'PictureBox1
        '
        Me.PictureBox1.Image = CType(resources.GetObject("PictureBox1.Image"), System.Drawing.Image)
        Me.PictureBox1.Location = New System.Drawing.Point(63, 41)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(293, 110)
        Me.PictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.PictureBox1.TabIndex = 9
        Me.PictureBox1.TabStop = False
        '
        'Label5
        '
        Me.Label5.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.Location = New System.Drawing.Point(26, 372)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(136, 38)
        Me.Label5.TabIndex = 11
        Me.Label5.Text = "Location Change Password"
        '
        'locationChangePasswordLabel
        '
        Me.locationChangePasswordLabel.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.locationChangePasswordLabel.Location = New System.Drawing.Point(219, 383)
        Me.locationChangePasswordLabel.Name = "locationChangePasswordLabel"
        Me.locationChangePasswordLabel.Size = New System.Drawing.Size(185, 23)
        Me.locationChangePasswordLabel.TabIndex = 10
        Me.locationChangePasswordLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblLogin
        '
        Me.lblLogin.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblLogin.Location = New System.Drawing.Point(25, 483)
        Me.lblLogin.Name = "lblLogin"
        Me.lblLogin.Size = New System.Drawing.Size(148, 25)
        Me.lblLogin.TabIndex = 13
        Me.lblLogin.Text = "Login Password"
        Me.lblLogin.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblLoginCode
        '
        Me.lblLoginCode.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblLoginCode.Location = New System.Drawing.Point(218, 483)
        Me.lblLoginCode.Name = "lblLoginCode"
        Me.lblLoginCode.Size = New System.Drawing.Size(185, 23)
        Me.lblLoginCode.TabIndex = 12
        Me.lblLoginCode.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblCompleteConfig
        '
        Me.lblCompleteConfig.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblCompleteConfig.Location = New System.Drawing.Point(27, 528)
        Me.lblCompleteConfig.Name = "lblCompleteConfig"
        Me.lblCompleteConfig.Size = New System.Drawing.Size(145, 32)
        Me.lblCompleteConfig.TabIndex = 15
        Me.lblCompleteConfig.Text = "Complete Config Password"
        Me.lblCompleteConfig.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblCompleteConfigCode
        '
        Me.lblCompleteConfigCode.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblCompleteConfigCode.Location = New System.Drawing.Point(218, 530)
        Me.lblCompleteConfigCode.Name = "lblCompleteConfigCode"
        Me.lblCompleteConfigCode.Size = New System.Drawing.Size(185, 23)
        Me.lblCompleteConfigCode.TabIndex = 16
        Me.lblCompleteConfigCode.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'PasswordForm
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
        Me.ClientSize = New System.Drawing.Size(438, 586)
        Me.Controls.Add(Me.lblCompleteConfigCode)
        Me.Controls.Add(Me.lblCompleteConfig)
        Me.Controls.Add(Me.lblLogin)
        Me.Controls.Add(Me.lblLoginCode)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.locationChangePasswordLabel)
        Me.Controls.Add(Me.PictureBox1)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.Button1)
        Me.Controls.Add(Me.exitToWindowsPasswordLabel)
        Me.Controls.Add(Me.dateAndTimePasswordLabel)
        Me.Controls.Add(Me.adminPasswordLabel)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.passwordKernelTextBox)
        Me.Name = "PasswordForm"
        Me.Text = "Password Generator"
        Me.ResumeLayout(False)

    End Sub

#End Region

    Private Function isNonNullString(ByVal x As String) As Boolean

        If x Is Nothing Then Return False

        If x.Length <= 0 Then Return False

        Return True

    End Function

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click

        If isNonNullString(passwordKernelTextBox.Text) Then

            passwordKernelTextBox.Text.Trim()

            If passwordKernelTextBox.Text.Length <> 8 Then
                MsgBox("Invalid Password Kernel: Must be a non-null string of exactly 8 characters.", MsgBoxStyle.Exclamation, "Invalid Password Kernel")
                Exit Sub
            End If

        Else

            MsgBox("Invalid Password Kernel: Must be a non-null string of exactly 8 characters.", MsgBoxStyle.Exclamation, "Invalid Password Kernel")
            Exit Sub

        End If

        adminPasswordLabel.Text = genAdminPassword(passwordKernelTextBox.Text)
        dateAndTimePasswordLabel.Text = genDateAndTimePassword(passwordKernelTextBox.Text)
        exitToWindowsPasswordLabel.Text = genExitPassword(passwordKernelTextBox.Text)
        locationChangePasswordLabel.Text = genLocationChangePassword(passwordKernelTextBox.Text)

        'Added by MX
        lblLoginCode.Text = genLoginPassword(passwordKernelTextBox.Text)
        lblCompleteConfigCode.Text = genCompleteConfigPassword(passwordKernelTextBox.Text)

        Application.DoEvents()

    End Sub

    Private Sub formKeyPress(ByVal sender As System.Object, ByVal ex As KeyPressEventArgs) Handles passwordKernelTextBox.KeyPress

        If Asc(ex.KeyChar) = 13 Then
            Button1_Click(Nothing, Nothing)
        End If

    End Sub

    Private Sub passwordKernelTextBox_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles passwordKernelTextBox.TextChanged

    End Sub
    Private Sub Label1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Label1.Click

    End Sub
End Class
