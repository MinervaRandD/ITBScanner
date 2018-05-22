Public Class NavigationMenu
    Inherits System.Windows.Forms.ContextMenu

    Private Shared sgl As NavigationMenu = Nothing

    Friend WithEvents adminFunctionMenuItem As System.Windows.Forms.MenuItem
    Friend WithEvents messagesMenuItem As System.Windows.Forms.MenuItem
    Friend WithEvents mailOpsMenuItem As System.Windows.Forms.MenuItem
    Friend WithEvents mailOpsSimpleMenuItem As System.Windows.Forms.MenuItem
    Friend WithEvents cargoOpsMenuItem As System.Windows.Forms.MenuItem
    Friend WithEvents luggageOpsMenuItem As System.Windows.Forms.MenuItem
    Friend WithEvents setupMenuItem As System.Windows.Forms.MenuItem
    Friend WithEvents intlMailMenuItem As System.Windows.Forms.MenuItem
    Friend WithEvents intlMailSimpleMenuItem As System.Windows.Forms.MenuItem

    Private mailFormRef As MailScanDomsForm = Nothing
    Private setupMenuFormRef As tagTrakTagTrakSetupMenuForm = Nothing
    Private adminLoginFormRef As adminLoginForm = Nothing
    Private cargoFormRef As CargoScanBaseForm = Nothing
    Private messageFormRef As tagTrakMessageForm = Nothing
    Private bagFormRef As BagScanBaseForm = Nothing
    Private intlFormRef As MailScanIntlForm = Nothing

    Public Shared ReadOnly Property Singlet() As NavigationMenu
        Get
            If sgl Is Nothing Then
                sgl = New NavigationMenu
            End If
            Return sgl
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

        adminFunctionMenuItem.Text = "Admin Function"
        messagesMenuItem.Text = "Messages"
        mailOpsMenuItem.Text = "Mail Ops"
        mailOpsSimpleMenuItem.Text = "Mail Ops (Simple)"
        cargoOpsMenuItem.Text = "Cargo Ops"
        luggageOpsMenuItem.Text = "Baggage Ops"
        setupMenuItem.Text = "Setup"
        intlMailMenuItem.Text = "International Mail Ops"
        Me.intlMailSimpleMenuItem.Text = "Intl Mail (Simple)"

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
        mailFormRef = MailScanFormRepository.MailScanDomsForm
        mailFormRef.Show()
        'mailFormRef.Focus()
        selectMailScanTabPage(mailFormRef)
    End Sub

    Private Sub mailOpsSimpleMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mailOpsSimpleMenuItem.Click
        'hideAll()
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
        intlFormRef = MailScanFormRepository.MailScanIntlForm
        intlFormRef.Show()
        'intlFormRef.Focus()
    End Sub

    Private Sub intlMailSimpleMenuItem_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles intlMailSimpleMenuItem.Click
        Dim frm As MailScanIntlSimpleForm = MailScanIntlSimpleForm.GetInstance()
        frm.Show()
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

        MenuItems.Add(Me.setupMenuItem)
    End Sub

End Class
