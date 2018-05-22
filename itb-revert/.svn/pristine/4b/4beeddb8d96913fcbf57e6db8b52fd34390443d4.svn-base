Public Class FormMain
    Inherits System.Windows.Forms.Form

    '' Conducts network tests
    Public MyTester As Test.Tester
    '' Writes detailed test output to logs
    Public MyWriter As Test.Writer

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
    Friend WithEvents LabelWelcome As System.Windows.Forms.Label
    Friend WithEvents ButtonWelcomeStart As System.Windows.Forms.Button
    Friend WithEvents PanelTesting As System.Windows.Forms.Panel
    Friend WithEvents ButtonTestingNext As System.Windows.Forms.Button
    Friend WithEvents LabelTesting As System.Windows.Forms.Label
    Friend WithEvents ProgressBarTesting As System.Windows.Forms.ProgressBar
    Friend WithEvents LabelTestingStatus As System.Windows.Forms.Label
    Friend WithEvents PanelSubmit As System.Windows.Forms.Panel
    Friend WithEvents LabelSubmit As System.Windows.Forms.Label
    Friend WithEvents ButtonSubmitYes As System.Windows.Forms.Button
    Friend WithEvents ButtonSubmitNo As System.Windows.Forms.Button
    Friend WithEvents PanelUpload As System.Windows.Forms.Panel
    Friend WithEvents LabelUpload As System.Windows.Forms.Label
    Friend WithEvents ButtonUpload As System.Windows.Forms.Button
    Friend WithEvents ButtonUploadNext As System.Windows.Forms.Button
    Friend WithEvents LabelUploadStatus As System.Windows.Forms.Label
    Friend WithEvents PanelFinish As System.Windows.Forms.Panel
    Friend WithEvents ButtonFinish As System.Windows.Forms.Button
    Friend WithEvents LabelFinish As System.Windows.Forms.Label
    Friend WithEvents ButtonAdvanced As System.Windows.Forms.Button
    Public WithEvents PanelWelcome As System.Windows.Forms.Panel
    Friend WithEvents LabelFinishDescription As System.Windows.Forms.Label
    Friend WithEvents ComboBoxFinishTests As System.Windows.Forms.ComboBox
    Friend WithEvents LabelFinishTest As System.Windows.Forms.Label
    Friend WithEvents LabelFinishPassFail As System.Windows.Forms.Label
    Friend WithEvents PictureBox1 As System.Windows.Forms.PictureBox
    Friend WithEvents LabelWelcomeCopyright As System.Windows.Forms.Label
    Friend WithEvents ProgressBarUpload As System.Windows.Forms.ProgressBar
    Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FormMain))
        Me.PanelWelcome = New System.Windows.Forms.Panel
        Me.LabelWelcomeCopyright = New System.Windows.Forms.Label
        Me.PictureBox1 = New System.Windows.Forms.PictureBox
        Me.ButtonAdvanced = New System.Windows.Forms.Button
        Me.ButtonWelcomeStart = New System.Windows.Forms.Button
        Me.LabelWelcome = New System.Windows.Forms.Label
        Me.PanelTesting = New System.Windows.Forms.Panel
        Me.LabelTestingStatus = New System.Windows.Forms.Label
        Me.ProgressBarTesting = New System.Windows.Forms.ProgressBar
        Me.ButtonTestingNext = New System.Windows.Forms.Button
        Me.LabelTesting = New System.Windows.Forms.Label
        Me.PanelSubmit = New System.Windows.Forms.Panel
        Me.ButtonSubmitNo = New System.Windows.Forms.Button
        Me.ButtonSubmitYes = New System.Windows.Forms.Button
        Me.LabelSubmit = New System.Windows.Forms.Label
        Me.PanelUpload = New System.Windows.Forms.Panel
        Me.ProgressBarUpload = New System.Windows.Forms.ProgressBar
        Me.LabelUploadStatus = New System.Windows.Forms.Label
        Me.ButtonUpload = New System.Windows.Forms.Button
        Me.ButtonUploadNext = New System.Windows.Forms.Button
        Me.LabelUpload = New System.Windows.Forms.Label
        Me.PanelFinish = New System.Windows.Forms.Panel
        Me.LabelFinishPassFail = New System.Windows.Forms.Label
        Me.LabelFinishDescription = New System.Windows.Forms.Label
        Me.ComboBoxFinishTests = New System.Windows.Forms.ComboBox
        Me.LabelFinishTest = New System.Windows.Forms.Label
        Me.ButtonFinish = New System.Windows.Forms.Button
        Me.LabelFinish = New System.Windows.Forms.Label
        Me.PanelWelcome.SuspendLayout()
        Me.PanelTesting.SuspendLayout()
        Me.PanelSubmit.SuspendLayout()
        Me.PanelUpload.SuspendLayout()
        Me.PanelFinish.SuspendLayout()
        Me.SuspendLayout()
        '
        'PanelWelcome
        '
        Me.PanelWelcome.Controls.Add(Me.LabelWelcomeCopyright)
        Me.PanelWelcome.Controls.Add(Me.PictureBox1)
        Me.PanelWelcome.Controls.Add(Me.ButtonAdvanced)
        Me.PanelWelcome.Controls.Add(Me.ButtonWelcomeStart)
        Me.PanelWelcome.Controls.Add(Me.LabelWelcome)
        Me.PanelWelcome.Location = New System.Drawing.Point(4, 4)
        Me.PanelWelcome.Name = "PanelWelcome"
        Me.PanelWelcome.Size = New System.Drawing.Size(240, 294)
        '
        'LabelWelcomeCopyright
        '
        Me.LabelWelcomeCopyright.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular)
        Me.LabelWelcomeCopyright.Location = New System.Drawing.Point(8, 268)
        Me.LabelWelcomeCopyright.Name = "LabelWelcomeCopyright"
        Me.LabelWelcomeCopyright.Size = New System.Drawing.Size(224, 20)
        Me.LabelWelcomeCopyright.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'PictureBox1
        '
        Me.PictureBox1.Image = CType(resources.GetObject("PictureBox1.Image"), System.Drawing.Image)
        Me.PictureBox1.Location = New System.Drawing.Point(4, 4)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(232, 63)
        Me.PictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        '
        'ButtonAdvanced
        '
        Me.ButtonAdvanced.Enabled = False
        Me.ButtonAdvanced.Location = New System.Drawing.Point(8, 240)
        Me.ButtonAdvanced.Name = "ButtonAdvanced"
        Me.ButtonAdvanced.Size = New System.Drawing.Size(72, 20)
        Me.ButtonAdvanced.TabIndex = 2
        Me.ButtonAdvanced.Text = "&Advaned"
        '
        'ButtonWelcomeStart
        '
        Me.ButtonWelcomeStart.Location = New System.Drawing.Point(156, 240)
        Me.ButtonWelcomeStart.Name = "ButtonWelcomeStart"
        Me.ButtonWelcomeStart.Size = New System.Drawing.Size(72, 20)
        Me.ButtonWelcomeStart.TabIndex = 3
        Me.ButtonWelcomeStart.Text = "&Start >"
        '
        'LabelWelcome
        '
        Me.LabelWelcome.Location = New System.Drawing.Point(8, 76)
        Me.LabelWelcome.Name = "LabelWelcome"
        Me.LabelWelcome.Size = New System.Drawing.Size(224, 80)
        Me.LabelWelcome.Text = "Welcome to the ASI Network Testing tool. Please connect your scanner to the netwo" & _
            "rk. If you normally dock your scanner, please do so now. Then tap Start to begin" & _
            " testing."
        '
        'PanelTesting
        '
        Me.PanelTesting.Controls.Add(Me.LabelTestingStatus)
        Me.PanelTesting.Controls.Add(Me.ProgressBarTesting)
        Me.PanelTesting.Controls.Add(Me.ButtonTestingNext)
        Me.PanelTesting.Controls.Add(Me.LabelTesting)
        Me.PanelTesting.Location = New System.Drawing.Point(48, 28)
        Me.PanelTesting.Name = "PanelTesting"
        Me.PanelTesting.Size = New System.Drawing.Size(240, 294)
        '
        'LabelTestingStatus
        '
        Me.LabelTestingStatus.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Italic)
        Me.LabelTestingStatus.Location = New System.Drawing.Point(24, 188)
        Me.LabelTestingStatus.Name = "LabelTestingStatus"
        Me.LabelTestingStatus.Size = New System.Drawing.Size(196, 48)
        Me.LabelTestingStatus.Text = "..."
        Me.LabelTestingStatus.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'ProgressBarTesting
        '
        Me.ProgressBarTesting.Location = New System.Drawing.Point(20, 148)
        Me.ProgressBarTesting.Name = "ProgressBarTesting"
        Me.ProgressBarTesting.Size = New System.Drawing.Size(200, 20)
        '
        'ButtonTestingNext
        '
        Me.ButtonTestingNext.Enabled = False
        Me.ButtonTestingNext.Location = New System.Drawing.Point(156, 260)
        Me.ButtonTestingNext.Name = "ButtonTestingNext"
        Me.ButtonTestingNext.Size = New System.Drawing.Size(72, 20)
        Me.ButtonTestingNext.TabIndex = 2
        Me.ButtonTestingNext.Text = "&Next >"
        '
        'LabelTesting
        '
        Me.LabelTesting.Location = New System.Drawing.Point(12, 12)
        Me.LabelTesting.Name = "LabelTesting"
        Me.LabelTesting.Size = New System.Drawing.Size(220, 48)
        Me.LabelTesting.Text = "Please wait while we run some tests on your scanner and network connection. Pleas" & _
            "e stand by."
        '
        'PanelSubmit
        '
        Me.PanelSubmit.Controls.Add(Me.ButtonSubmitNo)
        Me.PanelSubmit.Controls.Add(Me.ButtonSubmitYes)
        Me.PanelSubmit.Controls.Add(Me.LabelSubmit)
        Me.PanelSubmit.Location = New System.Drawing.Point(104, 68)
        Me.PanelSubmit.Name = "PanelSubmit"
        Me.PanelSubmit.Size = New System.Drawing.Size(240, 294)
        '
        'ButtonSubmitNo
        '
        Me.ButtonSubmitNo.Location = New System.Drawing.Point(136, 236)
        Me.ButtonSubmitNo.Name = "ButtonSubmitNo"
        Me.ButtonSubmitNo.Size = New System.Drawing.Size(72, 20)
        Me.ButtonSubmitNo.TabIndex = 0
        Me.ButtonSubmitNo.Text = "&No"
        '
        'ButtonSubmitYes
        '
        Me.ButtonSubmitYes.Location = New System.Drawing.Point(32, 236)
        Me.ButtonSubmitYes.Name = "ButtonSubmitYes"
        Me.ButtonSubmitYes.Size = New System.Drawing.Size(72, 20)
        Me.ButtonSubmitYes.TabIndex = 1
        Me.ButtonSubmitYes.Text = "&Yes"
        '
        'LabelSubmit
        '
        Me.LabelSubmit.Location = New System.Drawing.Point(12, 12)
        Me.LabelSubmit.Name = "LabelSubmit"
        Me.LabelSubmit.Size = New System.Drawing.Size(220, 32)
        Me.LabelSubmit.Text = "We've generated some results, would you like to submit them to ASI?"
        '
        'PanelUpload
        '
        Me.PanelUpload.Controls.Add(Me.ProgressBarUpload)
        Me.PanelUpload.Controls.Add(Me.LabelUploadStatus)
        Me.PanelUpload.Controls.Add(Me.ButtonUpload)
        Me.PanelUpload.Controls.Add(Me.ButtonUploadNext)
        Me.PanelUpload.Controls.Add(Me.LabelUpload)
        Me.PanelUpload.Location = New System.Drawing.Point(164, 116)
        Me.PanelUpload.Name = "PanelUpload"
        Me.PanelUpload.Size = New System.Drawing.Size(240, 294)
        '
        'ProgressBarUpload
        '
        Me.ProgressBarUpload.Location = New System.Drawing.Point(20, 152)
        Me.ProgressBarUpload.Name = "ProgressBarUpload"
        Me.ProgressBarUpload.Size = New System.Drawing.Size(200, 20)
        Me.ProgressBarUpload.Visible = False
        '
        'LabelUploadStatus
        '
        Me.LabelUploadStatus.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Italic)
        Me.LabelUploadStatus.Location = New System.Drawing.Point(16, 184)
        Me.LabelUploadStatus.Name = "LabelUploadStatus"
        Me.LabelUploadStatus.Size = New System.Drawing.Size(212, 68)
        Me.LabelUploadStatus.Text = "..."
        Me.LabelUploadStatus.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'ButtonUpload
        '
        Me.ButtonUpload.Location = New System.Drawing.Point(48, 124)
        Me.ButtonUpload.Name = "ButtonUpload"
        Me.ButtonUpload.Size = New System.Drawing.Size(148, 20)
        Me.ButtonUpload.TabIndex = 2
        Me.ButtonUpload.Text = "&Send Resuts to ASI"
        '
        'ButtonUploadNext
        '
        Me.ButtonUploadNext.Enabled = False
        Me.ButtonUploadNext.Location = New System.Drawing.Point(156, 260)
        Me.ButtonUploadNext.Name = "ButtonUploadNext"
        Me.ButtonUploadNext.Size = New System.Drawing.Size(72, 20)
        Me.ButtonUploadNext.TabIndex = 3
        Me.ButtonUploadNext.Text = "&Next >"
        '
        'LabelUpload
        '
        Me.LabelUpload.Location = New System.Drawing.Point(12, 12)
        Me.LabelUpload.Name = "LabelUpload"
        Me.LabelUpload.Size = New System.Drawing.Size(216, 80)
        Me.LabelUpload.Text = "Please connect your scanner with a USB cable to a Desktop computer with Internet " & _
            "access (and ActiveSync installed). Then tap the Send Results button."
        '
        'PanelFinish
        '
        Me.PanelFinish.Controls.Add(Me.LabelFinishPassFail)
        Me.PanelFinish.Controls.Add(Me.LabelFinishDescription)
        Me.PanelFinish.Controls.Add(Me.ComboBoxFinishTests)
        Me.PanelFinish.Controls.Add(Me.LabelFinishTest)
        Me.PanelFinish.Controls.Add(Me.ButtonFinish)
        Me.PanelFinish.Controls.Add(Me.LabelFinish)
        Me.PanelFinish.Location = New System.Drawing.Point(236, 176)
        Me.PanelFinish.Name = "PanelFinish"
        Me.PanelFinish.Size = New System.Drawing.Size(240, 294)
        '
        'LabelFinishPassFail
        '
        Me.LabelFinishPassFail.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold)
        Me.LabelFinishPassFail.Location = New System.Drawing.Point(20, 92)
        Me.LabelFinishPassFail.Name = "LabelFinishPassFail"
        Me.LabelFinishPassFail.Size = New System.Drawing.Size(204, 20)
        Me.LabelFinishPassFail.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'LabelFinishDescription
        '
        Me.LabelFinishDescription.Location = New System.Drawing.Point(20, 116)
        Me.LabelFinishDescription.Name = "LabelFinishDescription"
        Me.LabelFinishDescription.Size = New System.Drawing.Size(204, 132)
        '
        'ComboBoxFinishTests
        '
        Me.ComboBoxFinishTests.Location = New System.Drawing.Point(88, 64)
        Me.ComboBoxFinishTests.Name = "ComboBoxFinishTests"
        Me.ComboBoxFinishTests.Size = New System.Drawing.Size(136, 22)
        Me.ComboBoxFinishTests.TabIndex = 2
        '
        'LabelFinishTest
        '
        Me.LabelFinishTest.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold)
        Me.LabelFinishTest.Location = New System.Drawing.Point(28, 68)
        Me.LabelFinishTest.Name = "LabelFinishTest"
        Me.LabelFinishTest.Size = New System.Drawing.Size(40, 16)
        Me.LabelFinishTest.Text = "Test:"
        '
        'ButtonFinish
        '
        Me.ButtonFinish.Location = New System.Drawing.Point(156, 260)
        Me.ButtonFinish.Name = "ButtonFinish"
        Me.ButtonFinish.Size = New System.Drawing.Size(72, 20)
        Me.ButtonFinish.TabIndex = 4
        Me.ButtonFinish.Text = "&Finish"
        '
        'LabelFinish
        '
        Me.LabelFinish.Location = New System.Drawing.Point(12, 12)
        Me.LabelFinish.Name = "LabelFinish"
        Me.LabelFinish.Size = New System.Drawing.Size(216, 36)
        Me.LabelFinish.Text = "You can review your results here. Tap Finish to exit."
        '
        'FormMain
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(96.0!, 96.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi
        Me.ClientSize = New System.Drawing.Size(596, 568)
        Me.ControlBox = False
        Me.Controls.Add(Me.PanelWelcome)
        Me.Controls.Add(Me.PanelUpload)
        Me.Controls.Add(Me.PanelFinish)
        Me.Controls.Add(Me.PanelSubmit)
        Me.Controls.Add(Me.PanelTesting)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.MinimizeBox = False
        Me.Name = "FormMain"
        Me.Text = "ASI Net Tester"
        Me.PanelWelcome.ResumeLayout(False)
        Me.PanelTesting.ResumeLayout(False)
        Me.PanelSubmit.ResumeLayout(False)
        Me.PanelUpload.ResumeLayout(False)
        Me.PanelFinish.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub

#End Region

    '' Manages the multi-panel UI
    Public MyUIMan As UIMan

    Private Sub FormMain_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Load

        '' Init Writer and Tester
        MyWriter = New Test.Writer
        MyTester = New Test.Tester(Me, MyWriter)

        '' Init UI Man, store out panels
        MyUIMan = New UIMan(Me)
        MyUIMan.SetPanel(UIMan.PanelTypes.Welcome, PanelWelcome)
        MyUIMan.SetPanel(UIMan.PanelTypes.Testing, PanelTesting)
        MyUIMan.SetPanel(UIMan.PanelTypes.Submit, PanelSubmit)
        MyUIMan.SetPanel(UIMan.PanelTypes.Upload, PanelUpload)
        MyUIMan.SetPanel(UIMan.PanelTypes.Finish, PanelFinish)

        '' Switch to welcome panel
        MyUIMan.SwitchToPanel(UIMan.PanelTypes.Welcome)

    End Sub

End Class
