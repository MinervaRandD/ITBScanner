Public Class FormMain
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
        MyBase.Dispose(disposing)
    End Sub

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    Friend WithEvents RadioButtonEnable As System.Windows.Forms.RadioButton
    Friend WithEvents RadioButtonDisable As System.Windows.Forms.RadioButton
    Friend WithEvents ListBoxScans As System.Windows.Forms.ListBox
    Friend WithEvents ButtonClear As System.Windows.Forms.Button
    Friend WithEvents CheckBoxCode93 As System.Windows.Forms.CheckBox
    Friend WithEvents CheckBoxCode128 As System.Windows.Forms.CheckBox
    Friend WithEvents CheckBoxI2of5 As System.Windows.Forms.CheckBox
    Friend WithEvents ButtonBeepGood As System.Windows.Forms.Button
    Friend WithEvents ButtonBeepBad As System.Windows.Forms.Button
    Friend WithEvents ButtonBeepWarning As System.Windows.Forms.Button
    Friend WithEvents ButtonBeepError As System.Windows.Forms.Button
    Friend WithEvents CheckBoxContinuous As System.Windows.Forms.CheckBox
    Friend WithEvents CheckBoxVibrate As System.Windows.Forms.CheckBox
    Friend WithEvents TrackBarVolume As System.Windows.Forms.TrackBar
    Friend WithEvents CheckBoxLed As System.Windows.Forms.CheckBox
    Friend WithEvents CheckBoxBeep As System.Windows.Forms.CheckBox
    Friend WithEvents ButtonColdBoot As System.Windows.Forms.Button
    Friend WithEvents funcitionKeyCheckBox As System.Windows.Forms.CheckBox
    Friend WithEvents ButtonWarmBoot As System.Windows.Forms.Button
    Private Sub InitializeComponent()
        Me.RadioButtonEnable = New System.Windows.Forms.RadioButton
        Me.RadioButtonDisable = New System.Windows.Forms.RadioButton
        Me.ListBoxScans = New System.Windows.Forms.ListBox
        Me.CheckBoxCode93 = New System.Windows.Forms.CheckBox
        Me.ButtonClear = New System.Windows.Forms.Button
        Me.CheckBoxCode128 = New System.Windows.Forms.CheckBox
        Me.CheckBoxI2of5 = New System.Windows.Forms.CheckBox
        Me.ButtonBeepGood = New System.Windows.Forms.Button
        Me.CheckBoxLed = New System.Windows.Forms.CheckBox
        Me.ButtonBeepBad = New System.Windows.Forms.Button
        Me.ButtonBeepWarning = New System.Windows.Forms.Button
        Me.ButtonBeepError = New System.Windows.Forms.Button
        Me.CheckBoxContinuous = New System.Windows.Forms.CheckBox
        Me.CheckBoxVibrate = New System.Windows.Forms.CheckBox
        Me.TrackBarVolume = New System.Windows.Forms.TrackBar
        Me.CheckBoxBeep = New System.Windows.Forms.CheckBox
        Me.ButtonWarmBoot = New System.Windows.Forms.Button
        Me.ButtonColdBoot = New System.Windows.Forms.Button
        Me.funcitionKeyCheckBox = New System.Windows.Forms.CheckBox
        Me.SuspendLayout()
        '
        'RadioButtonEnable
        '
        Me.RadioButtonEnable.Location = New System.Drawing.Point(8, 12)
        Me.RadioButtonEnable.Name = "RadioButtonEnable"
        Me.RadioButtonEnable.Size = New System.Drawing.Size(68, 20)
        Me.RadioButtonEnable.TabIndex = 17
        Me.RadioButtonEnable.Text = "Enable"
        '
        'RadioButtonDisable
        '
        Me.RadioButtonDisable.Checked = True
        Me.RadioButtonDisable.Location = New System.Drawing.Point(79, 13)
        Me.RadioButtonDisable.Name = "RadioButtonDisable"
        Me.RadioButtonDisable.Size = New System.Drawing.Size(68, 20)
        Me.RadioButtonDisable.TabIndex = 16
        Me.RadioButtonDisable.Text = "Disable"
        '
        'ListBoxScans
        '
        Me.ListBoxScans.Location = New System.Drawing.Point(4, 196)
        Me.ListBoxScans.Name = "ListBoxScans"
        Me.ListBoxScans.Size = New System.Drawing.Size(224, 72)
        Me.ListBoxScans.TabIndex = 15
        '
        'CheckBoxCode93
        '
        Me.CheckBoxCode93.Location = New System.Drawing.Point(8, 44)
        Me.CheckBoxCode93.Name = "CheckBoxCode93"
        Me.CheckBoxCode93.Size = New System.Drawing.Size(72, 20)
        Me.CheckBoxCode93.TabIndex = 14
        Me.CheckBoxCode93.Text = "Code93"
        '
        'ButtonClear
        '
        Me.ButtonClear.Location = New System.Drawing.Point(188, 272)
        Me.ButtonClear.Name = "ButtonClear"
        Me.ButtonClear.Size = New System.Drawing.Size(40, 20)
        Me.ButtonClear.TabIndex = 13
        Me.ButtonClear.Text = "Clear"
        '
        'CheckBoxCode128
        '
        Me.CheckBoxCode128.Location = New System.Drawing.Point(84, 44)
        Me.CheckBoxCode128.Name = "CheckBoxCode128"
        Me.CheckBoxCode128.Size = New System.Drawing.Size(72, 20)
        Me.CheckBoxCode128.TabIndex = 12
        Me.CheckBoxCode128.Text = "Code128"
        '
        'CheckBoxI2of5
        '
        Me.CheckBoxI2of5.Location = New System.Drawing.Point(160, 44)
        Me.CheckBoxI2of5.Name = "CheckBoxI2of5"
        Me.CheckBoxI2of5.Size = New System.Drawing.Size(72, 20)
        Me.CheckBoxI2of5.TabIndex = 11
        Me.CheckBoxI2of5.Text = "I 2 of 5"
        '
        'ButtonBeepGood
        '
        Me.ButtonBeepGood.Location = New System.Drawing.Point(4, 72)
        Me.ButtonBeepGood.Name = "ButtonBeepGood"
        Me.ButtonBeepGood.Size = New System.Drawing.Size(56, 20)
        Me.ButtonBeepGood.TabIndex = 10
        Me.ButtonBeepGood.Text = "Good"
        '
        'CheckBoxLed
        '
        Me.CheckBoxLed.Location = New System.Drawing.Point(100, 172)
        Me.CheckBoxLed.Name = "CheckBoxLed"
        Me.CheckBoxLed.Size = New System.Drawing.Size(48, 20)
        Me.CheckBoxLed.TabIndex = 9
        Me.CheckBoxLed.Text = "LED"
        '
        'ButtonBeepBad
        '
        Me.ButtonBeepBad.Location = New System.Drawing.Point(64, 72)
        Me.ButtonBeepBad.Name = "ButtonBeepBad"
        Me.ButtonBeepBad.Size = New System.Drawing.Size(52, 20)
        Me.ButtonBeepBad.TabIndex = 8
        Me.ButtonBeepBad.Text = "Bad"
        '
        'ButtonBeepWarning
        '
        Me.ButtonBeepWarning.Location = New System.Drawing.Point(120, 72)
        Me.ButtonBeepWarning.Name = "ButtonBeepWarning"
        Me.ButtonBeepWarning.Size = New System.Drawing.Size(52, 20)
        Me.ButtonBeepWarning.TabIndex = 7
        Me.ButtonBeepWarning.Text = "Warn"
        '
        'ButtonBeepError
        '
        Me.ButtonBeepError.Location = New System.Drawing.Point(180, 72)
        Me.ButtonBeepError.Name = "ButtonBeepError"
        Me.ButtonBeepError.Size = New System.Drawing.Size(52, 20)
        Me.ButtonBeepError.TabIndex = 6
        Me.ButtonBeepError.Text = "Error"
        '
        'CheckBoxContinuous
        '
        Me.CheckBoxContinuous.Location = New System.Drawing.Point(56, 144)
        Me.CheckBoxContinuous.Name = "CheckBoxContinuous"
        Me.CheckBoxContinuous.Size = New System.Drawing.Size(124, 20)
        Me.CheckBoxContinuous.TabIndex = 5
        Me.CheckBoxContinuous.Text = "Continuous Mode"
        '
        'CheckBoxVibrate
        '
        Me.CheckBoxVibrate.Location = New System.Drawing.Point(4, 172)
        Me.CheckBoxVibrate.Name = "CheckBoxVibrate"
        Me.CheckBoxVibrate.Size = New System.Drawing.Size(68, 20)
        Me.CheckBoxVibrate.TabIndex = 4
        Me.CheckBoxVibrate.Text = "Vibrate"
        '
        'TrackBarVolume
        '
        Me.TrackBarVolume.LargeChange = 10
        Me.TrackBarVolume.Location = New System.Drawing.Point(8, 96)
        Me.TrackBarVolume.Maximum = 100
        Me.TrackBarVolume.Name = "TrackBarVolume"
        Me.TrackBarVolume.Size = New System.Drawing.Size(220, 45)
        Me.TrackBarVolume.TabIndex = 3
        Me.TrackBarVolume.TickFrequency = 10
        '
        'CheckBoxBeep
        '
        Me.CheckBoxBeep.Location = New System.Drawing.Point(172, 172)
        Me.CheckBoxBeep.Name = "CheckBoxBeep"
        Me.CheckBoxBeep.Size = New System.Drawing.Size(56, 20)
        Me.CheckBoxBeep.TabIndex = 2
        Me.CheckBoxBeep.Text = "Beep"
        '
        'ButtonWarmBoot
        '
        Me.ButtonWarmBoot.Location = New System.Drawing.Point(4, 272)
        Me.ButtonWarmBoot.Name = "ButtonWarmBoot"
        Me.ButtonWarmBoot.Size = New System.Drawing.Size(80, 20)
        Me.ButtonWarmBoot.TabIndex = 1
        Me.ButtonWarmBoot.Text = "Warm Boot"
        '
        'ButtonColdBoot
        '
        Me.ButtonColdBoot.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular)
        Me.ButtonColdBoot.Location = New System.Drawing.Point(88, 272)
        Me.ButtonColdBoot.Name = "ButtonColdBoot"
        Me.ButtonColdBoot.Size = New System.Drawing.Size(68, 20)
        Me.ButtonColdBoot.TabIndex = 0
        Me.ButtonColdBoot.Text = "Cold Boot"
        '
        'funcitionKeyCheckBox
        '
        Me.funcitionKeyCheckBox.Location = New System.Drawing.Point(155, 12)
        Me.funcitionKeyCheckBox.Name = "funcitionKeyCheckBox"
        Me.funcitionKeyCheckBox.Size = New System.Drawing.Size(85, 20)
        Me.funcitionKeyCheckBox.TabIndex = 18
        Me.funcitionKeyCheckBox.Text = "Func. Key"
        '
        'FormMain
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(96.0!, 96.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi
        Me.ClientSize = New System.Drawing.Size(240, 294)
        Me.Controls.Add(Me.funcitionKeyCheckBox)
        Me.Controls.Add(Me.ButtonColdBoot)
        Me.Controls.Add(Me.ButtonWarmBoot)
        Me.Controls.Add(Me.CheckBoxBeep)
        Me.Controls.Add(Me.TrackBarVolume)
        Me.Controls.Add(Me.CheckBoxVibrate)
        Me.Controls.Add(Me.CheckBoxContinuous)
        Me.Controls.Add(Me.ButtonBeepError)
        Me.Controls.Add(Me.ButtonBeepWarning)
        Me.Controls.Add(Me.ButtonBeepBad)
        Me.Controls.Add(Me.CheckBoxLed)
        Me.Controls.Add(Me.ButtonBeepGood)
        Me.Controls.Add(Me.CheckBoxI2of5)
        Me.Controls.Add(Me.CheckBoxCode128)
        Me.Controls.Add(Me.ButtonClear)
        Me.Controls.Add(Me.CheckBoxCode93)
        Me.Controls.Add(Me.ListBoxScans)
        Me.Controls.Add(Me.RadioButtonDisable)
        Me.Controls.Add(Me.RadioButtonEnable)
        Me.Name = "FormMain"
        Me.Text = "Main"
        Me.ResumeLayout(False)

    End Sub

    Public Shared Sub Main()
        Application.Run(New FormMain)
    End Sub

#End Region

    Dim WithEvents MyScanner As Hardware.Scanner.Base = Hardware.Scanner.Base.GetInstance()

    Private Sub FormMain_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        Me.Text = "BT: " & Hardware.Device.GetBlueToothAddress

        MyScanner.VolumePercent = 20

        CheckBoxCode93.Checked = MyScanner.Code93
        CheckBoxCode128.Checked = MyScanner.Code128
        CheckBoxI2of5.Checked = MyScanner.Interleaved2of5

        CheckBoxVibrate.Enabled = MyScanner.VibrateSupported
        CheckBoxVibrate.Checked = MyScanner.Vibrate
        CheckBoxLed.Enabled = MyScanner.LEDSupported
        CheckBoxLed.Checked = MyScanner.LED
        CheckBoxBeep.Enabled = MyScanner.BeepSupported
        CheckBoxBeep.Checked = MyScanner.Beep

        If MyScanner.ContinuousSupported Then
            CheckBoxContinuous.Checked = MyScanner.Continuous
        Else
            CheckBoxContinuous.Enabled = False
        End If

        TrackBarVolume.Value = MyScanner.VolumePercent

    End Sub

    Private Sub RadioButtonEnable_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RadioButtonEnable.CheckedChanged
        If RadioButtonEnable.Checked Then
            MyScanner.Enabled = True
        End If
    End Sub

    Private Sub RadioButtonDisable_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RadioButtonDisable.CheckedChanged
        If RadioButtonDisable.Checked Then
            MyScanner.Enabled = False
        End If
    End Sub

    Private Sub MyScanner_BarCodeRead(ByVal TheBarCode As String, ByVal TheSymbology As Hardware.Scanner.Base.Symbologies) Handles MyScanner.BarCodeRead
        MyScanner.Feedback(Hardware.Scanner.Base.FeedbackTypes.GoodScan)
        ListBoxScans.Items.Add(TheBarCode & " (" & TheSymbology.ToString & ")")
        ListBoxScans.SelectedIndex = ListBoxScans.Items.Count - 1
    End Sub

    Private Sub MyScanner_BarCodeReadDuplicate() Handles MyScanner.BarCodeReadDuplicate
        If MyScanner.Continuous = False Then
            MyScanner.Feedback(Hardware.Scanner.Base.FeedbackTypes.BadScan)
        End If
    End Sub

    Private Sub ButtonBeepGood_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonBeepGood.Click
        MyScanner.Feedback(Hardware.Scanner.Base.FeedbackTypes.GoodScan)
    End Sub

    Private Sub ButtonBeepBad_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonBeepBad.Click
        MyScanner.Feedback(Hardware.Scanner.Base.FeedbackTypes.BadScan)
    End Sub

    Private Sub ButtonBeepWarning_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonBeepWarning.Click
        MyScanner.Feedback(Hardware.Scanner.Base.FeedbackTypes.Warning)
    End Sub

    Private Sub ButtonBeepError_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonBeepError.Click
        MyScanner.Feedback(Hardware.Scanner.Base.FeedbackTypes.Mistake)
    End Sub

    Private Sub CheckBoxCode93_CheckStateChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CheckBoxCode93.CheckStateChanged
        MyScanner.Code93 = CheckBoxCode93.Checked
    End Sub

    Private Sub CheckBoxCode128_CheckStateChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CheckBoxCode128.CheckStateChanged
        MyScanner.Code128 = CheckBoxCode128.Checked
    End Sub

    Private Sub CheckBoxI2of5_CheckStateChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CheckBoxI2of5.CheckStateChanged
        MyScanner.Interleaved2of5 = CheckBoxI2of5.Checked
    End Sub

    Private Sub CheckBoxLed_CheckStateChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CheckBoxLed.CheckStateChanged
        MyScanner.LED = CheckBoxLed.Checked
    End Sub

    Private Sub ButtonClear_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonClear.Click
        ListBoxScans.Items.Clear()
    End Sub

    Private Sub CheckBoxContinuous_CheckStateChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CheckBoxContinuous.CheckStateChanged
        MyScanner.Continuous = CheckBoxContinuous.Checked
    End Sub

    Private Sub CheckBoxVibrate_CheckStateChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CheckBoxVibrate.CheckStateChanged
        MyScanner.Vibrate = CheckBoxVibrate.Checked
    End Sub

    Private Sub TrackBarVolume_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TrackBarVolume.ValueChanged
        MyScanner.VolumePercent = TrackBarVolume.Value
    End Sub

    Private Sub CheckBoxBeep_CheckStateChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CheckBoxBeep.CheckStateChanged
        MyScanner.Beep = CheckBoxBeep.Checked
    End Sub

    Private Sub ButtonBoot_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonWarmBoot.Click
        Hardware.Device.WarmBoot()
    End Sub

    Private Sub ButtonColdBoot_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonColdBoot.Click
        If MsgBox("Are you sure you want to attempt a cold boot?", MsgBoxStyle.YesNo, "Cold Boot?") = MsgBoxResult.Yes Then
            Hardware.Device.ColdBoot()
        End If
    End Sub

    Private Sub funcitionKeyCheckBox_CheckStateChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles funcitionKeyCheckBox.CheckStateChanged
        Dim myDevice As New Hardware.Device()
        If funcitionKeyCheckBox.Checked Then
            myDevice.EnableFunctionKey()
        Else
            myDevice.DisableFunctionKey()
        End If
    End Sub
End Class
