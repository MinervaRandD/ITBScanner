

Public Class NavigationMainMenu
    Inherits System.Windows.Forms.MenuItem

    Private Shared sgl As MenuItem = Nothing

    Friend WithEvents adminFunctionMenuItem As System.Windows.Forms.MenuItem
    Friend WithEvents messagesMenuItem As System.Windows.Forms.MenuItem
    Friend WithEvents mailOpsMenuItem As System.Windows.Forms.MenuItem
    Friend WithEvents mailOpsSimpleMenuItem As System.Windows.Forms.MenuItem
    Friend WithEvents cargoOpsMenuItem As System.Windows.Forms.MenuItem
    Friend WithEvents luggageOpsMenuItem As System.Windows.Forms.MenuItem
    Friend WithEvents setupMenuItem As System.Windows.Forms.MenuItem
    Friend WithEvents intlMailMenuItem As System.Windows.Forms.MenuItem
    Friend WithEvents intlMailSimpleMenuItem As System.Windows.Forms.MenuItem
    Friend WithEvents aboutMenuItem As System.Windows.Forms.MenuItem
    Friend WithEvents switchCarrierMenuItem As System.Windows.Forms.MenuItem
    Friend WithEvents warmBootMenuItem As System.Windows.Forms.MenuItem
    Friend WithEvents logoutMenuItem As System.Windows.Forms.MenuItem
    Friend WithEvents exitMenuItem As System.Windows.Forms.MenuItem

    Private mailFormRef As MailScanDomsForm = Nothing
    Private setupMenuFormRef As tagTrakTagTrakSetupMenuForm = Nothing
    Private adminLoginFormRef As adminLoginForm = Nothing
    Private cargoFormRef As CargoScanBaseForm = Nothing
    Private messageFormRef As tagTrakMessageForm = Nothing
    Private bagFormRef As BagScanBaseForm = Nothing
    Private intlFormRef As MailScanIntlForm = Nothing

    Public Shared ReadOnly Property Singlet() As NavigationMainMenu
        Get
            'If sgl Is Nothing Then
            '    sgl = New NavigationMainMenu
            'End If
            'Return sgl

            Return New NavigationMainMenu
        End Get
    End Property

    Sub New()
        MyBase.New()
        adminFunctionMenuItem = New System.Windows.Forms.MenuItem
        messagesMenuItem = New System.Windows.Forms.MenuItem
        mailOpsMenuItem = New System.Windows.Forms.MenuItem
        mailOpsSimpleMenuItem = New System.Windows.Forms.MenuItem
        cargoOpsMenuItem = New System.Windows.Forms.MenuItem
        luggageOpsMenuItem = New System.Windows.Forms.MenuItem
        setupMenuItem = New System.Windows.Forms.MenuItem
        intlMailMenuItem = New System.Windows.Forms.MenuItem
        intlMailSimpleMenuItem = New System.Windows.Forms.MenuItem
        aboutMenuItem = New System.Windows.Forms.MenuItem
        switchCarrierMenuItem = New System.Windows.Forms.MenuItem
        warmBootMenuItem = New System.Windows.Forms.MenuItem
        logoutMenuItem = New System.Windows.Forms.MenuItem
        exitMenuItem = New System.Windows.Forms.MenuItem

        Text = "Start"
        adminFunctionMenuItem.Text = "Admin Function"
        messagesMenuItem.Text = "Messages"
        mailOpsMenuItem.Text = "Mail Ops"
        mailOpsSimpleMenuItem.Text = "Mail Ops (Simple)"
        cargoOpsMenuItem.Text = "Cargo Ops"
        luggageOpsMenuItem.Text = "Baggage Ops"
        setupMenuItem.Text = "Setup"
        intlMailMenuItem.Text = "International Mail Ops"
        Me.intlMailSimpleMenuItem.Text = "Intl Mail (Simple)"
        Me.aboutMenuItem.Text = "About TagTrak"
        switchCarrierMenuItem.Text = "Switch Carrier"
        warmBootMenuItem.Text = "Warm Boot"
        logoutMenuItem.Text = "Logout"
        exitMenuItem.Text = "Exit"

        Me.loadMenuItems()

    End Sub
    Public Sub reload()
        MenuItems.Clear()
        Me.loadMenuItems()
    End Sub
    Private Sub adminFunctionMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles adminFunctionMenuItem.Click

        'hideAll()

        MailScanFormRepository.MailScanDomsForm().resetOperationComboBoxWithoutWarning()

        adminLoginFormRef = AdminFormRepository.adminLoginForm
        adminLoginFormRef.Show()
        'adminLoginFormRef.Focus()

    End Sub

    Private Sub setupMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles setupMenuItem.Click
        'hideAll()

        setupMenuFormRef = tagTrakFormRepository.tagTrakTagTrakSetupMenuForm
        setupMenuFormRef.Show()
        'setupMenuFormRef.Focus()
    End Sub

    Private Sub messagesMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles messagesMenuItem.Click
        'hideAll()

        messageFormRef = tagTrakFormRepository.tagTrakMessageForm
        messageFormRef.Show()
        'messageFormRef.Focus()

    End Sub

    Private Sub cargoOpsMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cargoOpsMenuItem.Click
        'hideAll()

        cargoFormRef = CargoScanFormRepository.CargoScanBaseForm
        cargoFormRef.Show()
        'cargoFormRef.Focus()

    End Sub

    Private Sub mailOpsMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mailOpsMenuItem.Click
        'hideAll()
        FlightScheduleError.DontAsk = False
        mailFormRef = MailScanFormRepository.MailScanDomsForm
        mailFormRef.Show()
        'mailFormRef.Focus()
        selectMailScanTabPage(mailFormRef)
    End Sub

    Private Sub mailOpsSimpleMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mailOpsSimpleMenuItem.Click
        'hideAll()
        FlightScheduleError.DontAsk = False
        mailFormRef = MailScanFormRepository.MailScanDomsForm
        mailFormRef.Show()
        'mailFormRef.Focus()
        selectMailScanSimpleTabPage(mailFormRef)
    End Sub

    Private Sub luggageOpsMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles luggageOpsMenuItem.Click
        'hideAll()
        bagFormRef = BagScanFormRepository.BagScanBaseForm
        bagFormRef.Show()
        'bagFormRef.Focus()
    End Sub

    Private Sub intlMailMenuItem_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles intlMailMenuItem.Click
        'hideAll()
        FlightScheduleError.DontAsk = False
        intlFormRef = MailScanFormRepository.MailScanIntlForm
        intlFormRef.Show()
        'intlFormRef.Focus()
    End Sub

    Private Sub intlMailSimpleMenuItem_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles intlMailSimpleMenuItem.Click
        FlightScheduleError.DontAsk = False
        Dim frm As MailScanIntlSimpleForm = MailScanIntlSimpleForm.GetInstance()
        frm.Show()
    End Sub

    Private Sub aboutMenuItem_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles aboutMenuItem.Click
        Dim aboutMsg As String = "ASI TagTrak Scanning Program"
        If productionDistribution Then
            aboutMsg &= vbCrLf & "Version: " & myVersionFull & "P"
        Else
            aboutMsg &= vbCrLf & "Version: " & myVersionFull
        End If
        aboutMsg &= vbCrLf & "Configuration: " & userSpecRecord.myConfigVersion
        aboutMsg &= vbCrLf & "Copyright Aviation Software, Inc. 2004-2007"
        MsgBox(aboutMsg, MsgBoxStyle.OKOnly, "About TagTrak")

    End Sub

    'Added by MX
    Private Sub switchCarrierMenuItem_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles switchCarrierMenuItem.Click
        scannerLib.WarmBoot()
    End Sub

    Private Sub warmBootMenuItem_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles warmBootMenuItem.Click

        scannerLib.WarmBoot()

    End Sub


    Private Sub logoutMenuItem_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles logoutMenuItem.Click

        tagTrakFormRepository.TagTrakLogin.WriteLogRecord(False)
        Dim frmLogin As New TagTrakLogin
        frmLogin.ShowDialog()

    End Sub

    Private Sub exitMenuItem_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles exitMenuItem.Click

        System.Windows.Forms.Application.Exit()

    End Sub

    Private Sub loadMenuItems()

        MenuItems.Add(adminFunctionMenuItem)

        If userSpecRecord.messagesEnabled Then
            MenuItems.Add(Me.messagesMenuItem)
        End If

        If userSpecRecord.mailScanEnabled Then
            MenuItems.Add(Me.mailOpsMenuItem)
        End If

        If userSpecRecord.mailSimpleScanEnabled Then
            MenuItems.Add(Me.mailOpsSimpleMenuItem)
        End If

        If userSpecRecord.internationalMailEnabled Then
            MenuItems.Add(Me.intlMailMenuItem)
        End If

        If userSpecRecord.internationalSimpleMailEnabled Then
            MenuItems.Add(Me.intlMailSimpleMenuItem)
        End If

        If userSpecRecord.cargoScanEnabled Then
            MenuItems.Add(Me.cargoOpsMenuItem)
        End If

        If userSpecRecord.baggageScanEnabled Then
            MenuItems.Add(Me.luggageOpsMenuItem)
        End If

        If singleCarrier = False Then
            MenuItems.Add(switchCarrierMenuItem)
        End If

        MenuItems.Add(warmBootMenuItem)

        MenuItems.Add(Me.setupMenuItem)

        If userSpecRecord.loginEnabled Then
            MenuItems.Add(logoutMenuItem)
        End If

        If (userSpecRecord.CanExitProgram) Then
            MenuItems.Add(Me.exitMenuItem)
        End If

        MenuItems.Add(Me.aboutMenuItem)

    End Sub


End Class
