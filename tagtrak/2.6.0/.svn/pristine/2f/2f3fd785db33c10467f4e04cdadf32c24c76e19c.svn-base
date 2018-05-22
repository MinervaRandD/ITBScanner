Imports System
Imports System.IO

Public Class ChangeUserForm
    Inherits System.Windows.Forms.Form
    Friend WithEvents Label1 As System.Windows.Forms.Label

    Dim oldUser As String
    Dim newUser As String

#Region " Windows Form Designer generated code "

    Public Sub New()

        MyBase.New()

        'This call is required by the Windows Form Designer.
        InitializeComponent()

        If user = "ATA" Or user = "USAirways" Then
            ATARadioButton.Checked = True
        ElseIf user = "JetBlue" Then
            JetBlueRadioButton.Checked = True
        ElseIf user = "USAirways" Then
            USAirwaysRadioButton.Checked = True
        ElseIf user = "PacificAirCargo" Then
            PacificAirRadioButton.Checked = True
        ElseIf user = "MNAviation" Then
            MNRadioButton.Checked = True
        ElseIf user = "ASI" Then
            ASIRadioButton.Checked = True
        End If

        oldUser = user

        'Add any initialization after the InitializeComponent() call

    End Sub

    Private Sub formOnLoad(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        If lockDown Then
            MyBase.MaximizeBox = False
            MyBase.MinimizeBox = False
            MyBase.ControlBox = False
            MyBase.WindowState = FormWindowState.Maximized
        End If

    End Sub

    Protected Overloads Overrides Sub Dispose(ByVal disposing As Boolean)
        MyBase.Dispose(disposing)
    End Sub

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    Friend WithEvents PictureBox1 As System.Windows.Forms.PictureBox
    Friend WithEvents PictureBox2 As System.Windows.Forms.PictureBox
    Friend WithEvents PictureBox3 As System.Windows.Forms.PictureBox
    Friend WithEvents PictureBox4 As System.Windows.Forms.PictureBox
    Friend WithEvents ATARadioButton As System.Windows.Forms.RadioButton
    Friend WithEvents JetBlueRadioButton As System.Windows.Forms.RadioButton
    Friend WithEvents USAirwaysRadioButton As System.Windows.Forms.RadioButton
    Friend WithEvents ASIRadioButton As System.Windows.Forms.RadioButton
    Friend WithEvents OKButton As System.Windows.Forms.Button
    Friend WithEvents cancelButton As System.Windows.Forms.Button
    Friend WithEvents PictureBox5 As System.Windows.Forms.PictureBox
    Friend WithEvents PacificAirRadioButton As System.Windows.Forms.RadioButton
    Friend WithEvents PictureBox6 As System.Windows.Forms.PictureBox
    Friend WithEvents MNRadioButton As System.Windows.Forms.RadioButton
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Dim resources As System.Resources.ResourceManager = New System.Resources.ResourceManager(GetType(ChangeUserForm))
        Me.ATARadioButton = New System.Windows.Forms.RadioButton
        Me.JetBlueRadioButton = New System.Windows.Forms.RadioButton
        Me.USAirwaysRadioButton = New System.Windows.Forms.RadioButton
        Me.ASIRadioButton = New System.Windows.Forms.RadioButton
        Me.OKButton = New System.Windows.Forms.Button
        Me.cancelButton = New System.Windows.Forms.Button
        Me.Label1 = New System.Windows.Forms.Label
        Me.PictureBox1 = New System.Windows.Forms.PictureBox
        Me.PictureBox2 = New System.Windows.Forms.PictureBox
        Me.PictureBox3 = New System.Windows.Forms.PictureBox
        Me.PictureBox4 = New System.Windows.Forms.PictureBox
        Me.PictureBox5 = New System.Windows.Forms.PictureBox
        Me.PacificAirRadioButton = New System.Windows.Forms.RadioButton
        Me.PictureBox6 = New System.Windows.Forms.PictureBox
        Me.MNRadioButton = New System.Windows.Forms.RadioButton
        '
        'ATARadioButton
        '
        Me.ATARadioButton.Location = New System.Drawing.Point(15, 49)
        Me.ATARadioButton.Size = New System.Drawing.Size(18, 28)
        Me.ATARadioButton.Text = "ATA"
        '
        'JetBlueRadioButton
        '
        Me.JetBlueRadioButton.Location = New System.Drawing.Point(129, 51)
        Me.JetBlueRadioButton.Size = New System.Drawing.Size(16, 25)
        Me.JetBlueRadioButton.Text = "Jet Blue"
        '
        'USAirwaysRadioButton
        '
        Me.USAirwaysRadioButton.Location = New System.Drawing.Point(15, 95)
        Me.USAirwaysRadioButton.Size = New System.Drawing.Size(17, 28)
        Me.USAirwaysRadioButton.Text = "US Airways"
        '
        'ASIRadioButton
        '
        Me.ASIRadioButton.Location = New System.Drawing.Point(129, 141)
        Me.ASIRadioButton.Size = New System.Drawing.Size(14, 28)
        Me.ASIRadioButton.Text = "ASI"
        '
        'OKButton
        '
        Me.OKButton.Location = New System.Drawing.Point(28, 237)
        Me.OKButton.Size = New System.Drawing.Size(83, 30)
        Me.OKButton.Text = "OK"
        '
        'cancelButton
        '
        Me.cancelButton.Location = New System.Drawing.Point(131, 238)
        Me.cancelButton.Size = New System.Drawing.Size(83, 30)
        Me.cancelButton.Text = "Cancel"
        '
        'Label1
        '
        Me.Label1.Font = New System.Drawing.Font("Tahoma", 14.25!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Italic), System.Drawing.FontStyle))
        Me.Label1.Location = New System.Drawing.Point(45, 7)
        Me.Label1.Size = New System.Drawing.Size(157, 22)
        Me.Label1.Text = "Change User"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'PictureBox1
        '
        Me.PictureBox1.Image = CType(resources.GetObject("PictureBox1.Image"), System.Drawing.Image)
        Me.PictureBox1.Location = New System.Drawing.Point(35, 49)
        Me.PictureBox1.Size = New System.Drawing.Size(75, 28)
        '
        'PictureBox2
        '
        Me.PictureBox2.Image = CType(resources.GetObject("PictureBox2.Image"), System.Drawing.Image)
        Me.PictureBox2.Location = New System.Drawing.Point(148, 47)
        Me.PictureBox2.Size = New System.Drawing.Size(71, 32)
        '
        'PictureBox3
        '
        Me.PictureBox3.Image = CType(resources.GetObject("PictureBox3.Image"), System.Drawing.Image)
        Me.PictureBox3.Location = New System.Drawing.Point(35, 88)
        Me.PictureBox3.Size = New System.Drawing.Size(73, 37)
        '
        'PictureBox4
        '
        Me.PictureBox4.Image = CType(resources.GetObject("PictureBox4.Image"), System.Drawing.Image)
        Me.PictureBox4.Location = New System.Drawing.Point(148, 140)
        Me.PictureBox4.Size = New System.Drawing.Size(74, 30)
        '
        'PictureBox5
        '
        Me.PictureBox5.Image = CType(resources.GetObject("PictureBox5.Image"), System.Drawing.Image)
        Me.PictureBox5.Location = New System.Drawing.Point(149, 91)
        Me.PictureBox5.Size = New System.Drawing.Size(72, 37)
        '
        'PacificAirRadioButton
        '
        Me.PacificAirRadioButton.Location = New System.Drawing.Point(129, 95)
        Me.PacificAirRadioButton.Size = New System.Drawing.Size(16, 28)
        Me.PacificAirRadioButton.Text = "PacificAir"
        '
        'PictureBox6
        '
        Me.PictureBox6.Image = CType(resources.GetObject("PictureBox6.Image"), System.Drawing.Image)
        Me.PictureBox6.Location = New System.Drawing.Point(34, 136)
        Me.PictureBox6.Size = New System.Drawing.Size(75, 38)
        '
        'MNRadioButton
        '
        Me.MNRadioButton.Location = New System.Drawing.Point(15, 141)
        Me.MNRadioButton.Size = New System.Drawing.Size(14, 28)
        Me.MNRadioButton.Text = "MN"
        '
        'ChangeUserForm
        '
        Me.ClientSize = New System.Drawing.Size(234, 288)
        Me.ControlBox = False
        Me.Controls.Add(Me.MNRadioButton)
        Me.Controls.Add(Me.PictureBox6)
        Me.Controls.Add(Me.PictureBox5)
        Me.Controls.Add(Me.PacificAirRadioButton)
        Me.Controls.Add(Me.PictureBox4)
        Me.Controls.Add(Me.PictureBox3)
        Me.Controls.Add(Me.PictureBox2)
        Me.Controls.Add(Me.PictureBox1)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.cancelButton)
        Me.Controls.Add(Me.OKButton)
        Me.Controls.Add(Me.ASIRadioButton)
        Me.Controls.Add(Me.USAirwaysRadioButton)
        Me.Controls.Add(Me.JetBlueRadioButton)
        Me.Controls.Add(Me.ATARadioButton)
        Me.Text = "Change User"

    End Sub

#End Region

    Private Sub OKButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles OKButton.Click

        If newUser = oldUser Then
            Me.Close()
            Exit Sub
        End If

        Dim auxillaryFilePath As String = deviceNonVolatileMemoryDirectory & "\AuxCnfg.txt"

        deleteLocalFile(auxillaryFilePath)

        Dim auxFileOutputStream As StreamWriter

        Try
            auxFileOutputStream = New StreamWriter(auxillaryFilePath)
        Catch ex As Exception
            MsgBox("Unable to create user auxillary file.")
            Exit Sub
        End Try

        Dim userString As String = ""

        If ATARadioButton.Checked Then
            userString = "1"
        ElseIf JetBlueRadioButton.Checked Then
            userString = "2"
        ElseIf USAirwaysRadioButton.Checked Then
            userString = "3"
        ElseIf PacificAirRadioButton.Checked Then
            userString = "4"
        ElseIf MNRadioButton.Checked Then
            userString = "5"
        ElseIf ASIRadioButton.Checked Then
            userString = "6"

        End If

        Try
            auxFileOutputStream.WriteLine(userString)
        Catch ex As Exception
            MsgBox("Unable to create user auxillary file.")
            Exit Sub
        End Try

        auxFileOutputStream.Close()

        Dim newUserNotificationDisplayForm As New newUserNotification

        newUserNotificationDisplayForm.ShowDialog()

        Me.Close()

    End Sub

    Private Sub cancelButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cancelButton.Click
        Me.Close()
    End Sub

    Dim withinSetNewUser As Boolean = False

    Private Sub setNewUser()

        If withinSetNewUser Then Exit Sub

        withinSetNewUser = True

        If ATARadioButton.Checked Then
            newUser = "ATA"
        ElseIf JetBlueRadioButton.Checked Then
            newUser = "JetBlue"
        ElseIf USAirwaysRadioButton.Checked Then
            newUser = "USAirways"
        ElseIf PacificAirRadioButton.Checked Then
            newUser = "PacificAirCargo"
        ElseIf MNRadioButton.Checked Then
            newUser = "MNAviation"
        ElseIf ASIRadioButton.Checked Then
            newUser = "ASI"
        End If

        withinSetNewUser = False

    End Sub

    Private Sub ATARadioButton_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ATARadioButton.CheckedChanged
        setNewUser()
    End Sub

    Private Sub JetBlueRadioButton_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles JetBlueRadioButton.CheckedChanged
        setNewUser()
    End Sub

    Private Sub USAirwaysRadioButton_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles USAirwaysRadioButton.CheckedChanged
        setNewUser()
    End Sub

    Private Sub PacificAirRadioButton_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PacificAirRadioButton.CheckedChanged
        setNewUser()
    End Sub

    Private Sub ASIRadioButton_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ASIRadioButton.CheckedChanged
        setNewUser()
    End Sub

   
End Class
