Imports System.IO

Public Class TagTrakCarrier
    Inherits System.Windows.Forms.Form

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
    Friend WithEvents initFormLogoPictureBox As System.Windows.Forms.PictureBox
    Friend WithEvents cbxCarrier As System.Windows.Forms.ComboBox
    Friend WithEvents btnConfirmCarrier As System.Windows.Forms.Button
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents btnExit As System.Windows.Forms.Button
    Friend WithEvents Timer1 As System.Windows.Forms.Timer
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Dim resources As System.Resources.ResourceManager = New System.Resources.ResourceManager(GetType(TagTrakCarrier))
        Me.cbxCarrier = New System.Windows.Forms.ComboBox
        Me.btnConfirmCarrier = New System.Windows.Forms.Button
        Me.initFormLogoPictureBox = New System.Windows.Forms.PictureBox
        Me.Label1 = New System.Windows.Forms.Label
        Me.btnExit = New System.Windows.Forms.Button
        Me.Timer1 = New System.Windows.Forms.Timer
        '
        'cbxCarrier
        '
        Me.cbxCarrier.Location = New System.Drawing.Point(32, 128)
        Me.cbxCarrier.Size = New System.Drawing.Size(64, 22)
        '
        'btnConfirmCarrier
        '
        Me.btnConfirmCarrier.Location = New System.Drawing.Point(112, 128)
        Me.btnConfirmCarrier.Size = New System.Drawing.Size(104, 20)
        Me.btnConfirmCarrier.Text = "Confirm Carrier"
        '
        'initFormLogoPictureBox
        '
        Me.initFormLogoPictureBox.Image = CType(resources.GetObject("initFormLogoPictureBox.Image"), System.Drawing.Image)
        Me.initFormLogoPictureBox.Location = New System.Drawing.Point(8, 8)
        Me.initFormLogoPictureBox.Size = New System.Drawing.Size(224, 64)
        '
        'Label1
        '
        Me.Label1.Location = New System.Drawing.Point(40, 88)
        Me.Label1.Size = New System.Drawing.Size(168, 32)
        Me.Label1.Text = "Select Carrier Code And Tap Confirm To Continue"
        '
        'btnExit
        '
        Me.btnExit.Location = New System.Drawing.Point(80, 224)
        Me.btnExit.Text = "Exit"
        '
        'Timer1
        '
        Me.Timer1.Interval = 500
        '
        'TagTrakCarrier
        '
        Me.ControlBox = False
        Me.Controls.Add(Me.btnExit)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.initFormLogoPictureBox)
        Me.Controls.Add(Me.btnConfirmCarrier)
        Me.Controls.Add(Me.cbxCarrier)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Text = "TagTrak Carrier"

    End Sub

#End Region

    Private carrierList() As String
    Private carrierListPath As String

    Public Shared Sub Main()

#If Debug = False Then
        Try
#End If
            Application.Run(New TagTrakCarrier)

#If Debug = False Then
        Catch ex As Exception
            MsgBox("An unexpected error occurred: " & vbCrLf _
            & ex.Message & ". " & vbCrLf _
            & "Please reboot the device.")
        End Try
#End If

    End Sub

    Private Sub TagTrakCarrier_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

#If deviceType <> "PC" Then

        Dim carrier As String
        Dim i As Integer

#If deviceType = "Intermec" Then
        If Directory.Exists("\SDMMC Disk\carriers") Then
            carrierListPath = "\SDMMC Disk\carriers"
        ElseIf Directory.Exists("\Flash File Store\carriers") Then
            carrierListPath = "\Flash File Store\carriers"
        Else
            MsgBox("Can not find carriers directory.", MsgBoxStyle.Exclamation, "Carrier Not Found")
            Me.Close()
        End If
#End If

#If deviceType = "Symbol" Then
        If Directory.Exists("\Storage Card\carriers") Then
            carrierListPath = "\Storage Card\carriers"
        ElseIf Directory.Exists("\Application\carriers") Then
            carrierListPath = "\Application\carriers"
        Else
            MsgBox("Can not find carriers directory.", MsgBoxStyle.Exclamation, "Carrier Not Found")
            Me.Close()
        End If
#End If

#If deviceType = "Dolphin" Then
        If Directory.Exists("\Storage Card\carriers") Then
            carrierListPath = "\Storage Card\carriers"
        ElseIf Directory.Exists("\IPSM\carriers") Then
            carrierListPath = "\IPSM\carriers"
        Else
            MsgBox("Can not find carriers directory.", MsgBoxStyle.Exclamation, "Carrier Not Found")
            Me.Close()
        End If
#End If

        Try
            carrierList = Directory.GetDirectories(carrierListPath)
        Catch ex As Exception
            MsgBox("Carrier list parsing failed." & ex.Message, MsgBoxStyle.Information, "Carrier Parsing Error")
            Me.Close()
        End Try

        For i = 1 To carrierList.Length
            carrierList(i - 1) = carrierList(i - 1).Split("\")(3).Trim()
        Next

        EraseOldFiles()

        ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
        ' Lock down base form. The process here is different than the normal lock down. For some     '
        ' reason, the lock-down command must be issued several times to be effective.                '
        ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
        lockdownBaseForm()

        cbxCarrier.DataSource = carrierList

        If carrierList.Length = 1 Then

            Me.Hide()

            selectedCarrierPath = "\carriers" & "\" & carrierList(0)
            TagTrakBaseConfigParms.user = carrierList(0)

            Dim frmTagTrak As New TagTrakBaseForm
            frmTagTrak.Show()

        Else
            singleCarrier = False
        End If

        'parseSuperConfigFile()
#Else

        Me.Hide()
        Dim frmTagTrak As New TagTrakBaseForm
        frmTagTrak.Show()

#End If

    End Sub

    'Public Sub parseSuperConfigFile()
    '    Dim superConfigFilePath As String
    '    Dim sr As New System.IO.StreamReader(superConfigFilePath)
    '    Dim superConfigXML As New Xml.XmlDocument
    '    'Will add more code here.
    'End Sub

    Private Sub btnConfirmCarrier_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnConfirmCarrier.Click

        selectedCarrierPath = "\carriers" & "\" & cbxCarrier.SelectedItem
        TagTrakBaseConfigParms.user = cbxCarrier.SelectedItem

        Dim frmTagTrak As New TagTrakBaseForm
        frmTagTrak.Show()

        Me.Hide()

    End Sub

    Private Sub btnExit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnExit.Click

        AdminFormRepository.adminLoginForm.Show()

    End Sub

    Private Sub EraseOldFiles()

        Dim RootPath As String = "\SDMMC Disk"
        Dim FlashRootPath As String = "\Flash File Store"
        Dim fileNames() As String
        Dim directoryNames() As String

        If Directory.Exists(RootPath & "\TagTrakBackup") Then
            If Not Directory.Exists(RootPath & "\OldVerBackup") Then
                Directory.Move(RootPath & "\TagTrakBackup", RootPath & "\OldVerBackup")
            End If
        ElseIf Directory.Exists(RootPath & "\UspsMailBackup") Then
            If Not Directory.Exists(RootPath & "\OldVerBackup") Then
                Directory.Move(RootPath & "\UspsMailBackup", RootPath & "\OldVerBackup")
            End If
        End If

        Try
            directoryNames = Directory.GetDirectories(RootPath)
        Catch ex As Exception
            directoryNames = Nothing
        End Try

        If Not directoryNames Is Nothing Then
            For Each directoryName As String In directoryNames

                'If (Not directoryName.ToUpper.EndsWith("2577")) And (Not directoryName.ToUpper.EndsWith("CABFILES")) _
                'And (Not directoryName.ToUpper.EndsWith("CARRIERS")) And (Not directoryName.ToUpper.EndsWith("OLDVERBACKUP") _
                'And (Not directoryName.EndsWith("CORE"))) Then

                If (directoryName.ToUpper.EndsWith("TAGTRAKCONFIG")) Or (directoryName.ToUpper.EndsWith("TAGTRAKDATA")) _
                Or (directoryName.ToUpper.EndsWith("TAGTRAKRELOAD")) Or (directoryName.ToUpper.EndsWith("TAGTRAKTEMP")) _
                Or (directoryName.ToUpper.EndsWith("USPSMAILCONFIG")) Or (directoryName.ToUpper.EndsWith("USPSMAILRELOAD")) _
                Or (directoryName.ToUpper.EndsWith("USPSMAILTEMP")) Or (directoryName.ToUpper.EndsWith("USPSMAILDATA")) Then

                    If directoryName.ToUpper.EndsWith("TAGTRAKRELOAD") Or directoryName.ToUpper.EndsWith("USPSMAILRELOAD") Then

                        Dim reloadFileNames() As String

                        Try
                            reloadFileNames = Directory.GetFiles(directoryName)
                        Catch ex As Exception
                            reloadFileNames = Nothing
                        End Try

                        If Not reloadFileNames Is Nothing Then

                            For Each reloadFileName As String In reloadFileNames
                                deleteLocalFile(reloadFileName)
                            Next

                        End If

                    End If

                    'This is a one time change, will be removed after upgrading
                    If directoryName.ToUpper.EndsWith("TAGTRAKCONFIG") Then

                        Dim oldLastUserPath As String = RootPath & "\TagTrakConfig\LastUser.txt"

                        If File.Exists(oldLastUserPath) Then

                            Dim srLastUser As StreamReader

                            Try
                                srLastUser = New StreamReader(oldLastUserPath)
                            Catch ex As Exception
                                MsgBox("Can't open " & oldLastUserPath)
                            End Try

                            oldLastUser = srLastUser.ReadLine.Trim

                            srLastUser.Close()

                            Dim oldLastUsedLocationPath As String = RootPath & "\TagTrakConfig\" & oldLastUser & "LastUsedLocation.txt"

                            If File.Exists(oldLastUsedLocationPath) Then

                                Dim srLastUsedLocation As StreamReader

                                Try
                                    srLastUsedLocation = New StreamReader(oldLastUsedLocationPath)
                                Catch ex As Exception
                                    MsgBox("Can't open " & oldLastUsedLocationPath)
                                End Try

                                oldLastUsedLocation = srLastUsedLocation.ReadLine.Trim

                                srLastUsedLocation.Close()

                            End If

                        End If

                    End If

                    Try
                        Directory.Delete(directoryName, True)
                    Catch ex As Exception
                        ex = Nothing
                    End Try

                End If

            Next
        End If

        Try
            fileNames = Directory.GetFiles(RootPath)
        Catch ex As Exception
            fileNames = Nothing
        End Try

        If Not fileNames Is Nothing Then
            For Each fileName As String In fileNames
                'New added for 2.5.2
                If fileName.Trim.ToUpper.EndsWith("ROUTINGS.BIN") Or fileName.Trim.ToUpper.EndsWith("LOGINDEX.TXT") _
                Or fileName.Trim.ToUpper.EndsWith("SCANNERLOG.TXT") Or fileName.Trim.ToUpper.EndsWith("SCHEDULE.TXT") _
                Or fileName.Trim.ToUpper.EndsWith("ROUTINGUPDATES.TXT") Then
                    deleteLocalFile(fileName)
                End If
            Next
        End If

        If File.Exists(RootPath & "\cabfiles\DependentFiles.cab") Then
            deleteLocalFile(RootPath & "\cabfiles\DependentFiles.cab")
        End If

        If File.Exists(RootPath & "\cabfiles\dep_files.cab") Then
            deleteLocalFile(RootPath & "\cabfiles\dep_files.cab")
        End If

        If File.Exists(RootPath & "\cabfiles\net-internet.cab") Then
            deleteLocalFile(RootPath & "\cabfiles\net-internet.cab")
        End If

        If File.Exists(RootPath & "\cabfiles\olddel.cab") Then
            deleteLocalFile(RootPath & "\cabfiles\olddel.cab")
        End If

        If File.Exists(RootPath & "\cabfiles\uspsata.cab") Then
            deleteLocalFile(RootPath & "\cabfiles\uspsata.cab")
        End If

        If Directory.Exists(FlashRootPath & "\MailData.txt") Then
            recursiveRemoveDirectory(FlashRootPath & "\MailData.txt")
        End If

        If Directory.Exists(FlashRootPath & "\CargoData.txt") Then
            recursiveRemoveDirectory(FlashRootPath & "\CargoData.txt")
        End If

        If Directory.Exists(FlashRootPath & "\BaggageData.txt") Then
            recursiveRemoveDirectory(FlashRootPath & "\BaggageData.txt")
        End If

    End Sub

    Private Function lockdownBaseForm() As String

#If deviceType <> "PC" Then

        If lockDown Then

            Me.Timer1.Enabled = True

        End If
#End If

        Return "OK"

    End Function

    Private Sub Timer1_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Timer1.Tick

        If lockDown Then
            DeviceUI.HideStartButton()
        Else
            DeviceUI.ShowStartButton()
        End If

    End Sub

End Class
