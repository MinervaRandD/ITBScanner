' Copyright (c) 2003-2004 Aviation Software, Inc.,
' All Rights Reserved. 
' Reproduction of this document in whole or in part without written permission of   
' Aviation Software, Inc. is strictly prohibited.
'
' Aviation Software, Inc., Confidential - Restricted Access
'
' This document contains proprietary information that shall be
' distributed or routed only within Aviation Software, Inc.,
' and its authorized clients, except with written permission of
' Aviation Software, Inc. 
Imports System
Imports System.io
Imports System.Text
Imports OpenNETCF.Win32.Core

Public Class TagTrakBaseForm
    Inherits System.Windows.Forms.Form

    Dim lastActiveUserName As String

    Dim initFormClosed As Boolean = False

#Region " Windows Form Designer generated code "

    Public Sub New()

        MyBase.New()

        If scannerLib.SystemPowerStatus() = 1 Then
            deviceInCradle = True
        Else
            deviceInCradle = False
        End If

        tagTrakFormRepository.TagTrakBaseForm = Me ' register the base form

#If deviceType <> "PC" Then
        ' make sure the keyboard mapping setting can take effect.
        Dim ret As System.IntPtr = CreateEvent(False, False, "ITC_KEYBOARD_CHANGE")
        If ret.ToInt32() <> 0 Then SetEvent(ret)
#End If


        'This call is required by the Windows Form Designer.

        InitializeComponent()

        programLoadProgressBar = Me.baseFormProgressBar
        programLoadProgressBar.Value = 0

        Dim result As String

        ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
        ' Manually install dynamic libraries if necessary. This may be archaic -- need to check.     '
        ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
        'result = installDynamicLibraries()
        'If result <> "OK" Then : Me.Close() : Exit Sub : End If

        ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
        ' Perform all tag trak base data initializations. This includes building tables that must be '
        ' done with in-line code.                                                                    '
        ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

        result = setupBaseTagTrakDataStructures()
        If result <> "OK" Then : Me.Close() : Exit Sub : End If

        ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
        ' Load base (user independent) configuration settings, if the configuration file exists.     '
        ' Base configuration parameters include items such as the release number and whether or not  '
        ' this is a production distribution.                                                         '                                                               '
        ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

        result = setupBaseConfiguration()
        If result <> "OK" Then : Me.Close() : Exit Sub : End If

        ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
        ' Set up the file system for the specific device. Create needed directories and sub-direct-  '
        ' ories if necessary. Note: also creates global string directory definitions.               '                                                      '                                                               '
        ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

        result = fileUtilities.setupDeviceFileSystem()
        If result <> "OK" Then : Me.Close() : Exit Sub : End If

        ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
        ' Get the last active user and initialize the logo for the base form and initialization form '
        ' appropriately.                                                                             '                                                      '                                                               '
        ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

        result = initFromLastActiveUser()
        If result <> "OK" Then : Me.Close() : Exit Sub : End If


        ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
        ' Load ontime file if one exists                                                             '                                                     '                                                               '
        ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

        result = loadBaseOntimeFile()
        If result <> "OK" Then : Me.Close() : Exit Sub : End If

#If deviceType = "PC" Then
        MyBase.Visible = False
#End If

    End Sub

    Protected Overloads Overrides Sub Dispose(ByVal disposing As Boolean)
        MyBase.Dispose(disposing)
    End Sub

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    Friend WithEvents HScrollBar1 As System.Windows.Forms.HScrollBar
    Friend WithEvents Loading As System.Windows.Forms.Label
    Friend WithEvents baseFormPictureBox As System.Windows.Forms.PictureBox
    Friend WithEvents baseFormProgressBar As System.Windows.Forms.ProgressBar
    Friend WithEvents releaseLabel As System.Windows.Forms.Label
    Friend WithEvents buzzLengthTimer As System.Windows.Forms.Timer
    Friend WithEvents LabelStatus As System.Windows.Forms.Label
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Dim resources As System.Resources.ResourceManager = New System.Resources.ResourceManager(GetType(TagTrakBaseForm))
        Me.HScrollBar1 = New System.Windows.Forms.HScrollBar
        Me.Loading = New System.Windows.Forms.Label
        Me.baseFormPictureBox = New System.Windows.Forms.PictureBox
        Me.LabelStatus = New System.Windows.Forms.Label
        Me.baseFormProgressBar = New System.Windows.Forms.ProgressBar
        Me.releaseLabel = New System.Windows.Forms.Label
        Me.buzzLengthTimer = New System.Windows.Forms.Timer
        '
        'HScrollBar1
        '
        Me.HScrollBar1.Location = New System.Drawing.Point(507, 362)
        Me.HScrollBar1.Maximum = 91
        Me.HScrollBar1.Size = New System.Drawing.Size(4, 0)
        '
        'Loading
        '
        Me.Loading.Font = New System.Drawing.Font("Tahoma", 16.2!, System.Drawing.FontStyle.Regular)
        Me.Loading.Location = New System.Drawing.Point(21, 90)
        Me.Loading.Size = New System.Drawing.Size(197, 70)
        Me.Loading.Text = "NOT FOR DISTRIBUTION"
        Me.Loading.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'baseFormPictureBox
        '
        Me.baseFormPictureBox.Image = CType(resources.GetObject("baseFormPictureBox.Image"), System.Drawing.Image)
        Me.baseFormPictureBox.Location = New System.Drawing.Point(7, 8)
        Me.baseFormPictureBox.Size = New System.Drawing.Size(224, 67)
        '
        'LabelStatus
        '
        Me.LabelStatus.Font = New System.Drawing.Font("Tahoma", 12.0!, System.Drawing.FontStyle.Regular)
        Me.LabelStatus.Location = New System.Drawing.Point(30, 168)
        Me.LabelStatus.Size = New System.Drawing.Size(178, 29)
        Me.LabelStatus.Text = "Test Version"
        Me.LabelStatus.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'baseFormProgressBar
        '
        Me.baseFormProgressBar.Location = New System.Drawing.Point(15, 208)
        Me.baseFormProgressBar.Size = New System.Drawing.Size(206, 29)
        '
        'releaseLabel
        '
        Me.releaseLabel.Location = New System.Drawing.Point(36, 248)
        Me.releaseLabel.Size = New System.Drawing.Size(155, 19)
        Me.releaseLabel.Text = "Label2"
        Me.releaseLabel.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'buzzLengthTimer
        '
        '
        'TagTrakBaseForm
        '
        Me.ClientSize = New System.Drawing.Size(234, 343)
        Me.ControlBox = False
        Me.Controls.Add(Me.releaseLabel)
        Me.Controls.Add(Me.baseFormProgressBar)
        Me.Controls.Add(Me.LabelStatus)
        Me.Controls.Add(Me.baseFormPictureBox)
        Me.Controls.Add(Me.Loading)
        Me.Controls.Add(Me.HScrollBar1)
        Me.Text = "TagTrak Loading ..."

    End Sub

#End Region

    Private Function loadBaseOntimeFile() As String

        Dim localOntimeFilePath As String = TagTrakConfigDirectory & "\ontime.txt"

        If Not File.Exists(localOntimeFilePath) Then Return "OK"

        Dim result As String = loadOntimeFile(localOntimeFilePath, False)

        Return result

    End Function

    Private Function setupBaseTagTrakDataStructures() As String

        ' Build user number table from user list

        Dim i, ilmt As Integer

        ilmt = userList.Length - 1

        For i = 0 To ilmt
            userNumberTable.Add(userList(i), i)
        Next

        Return "OK"

    End Function

    Private Function setupReaderDataClass() As String

        If emulatingPlatform Then Return "OK"

        '#If deviceType = "Intermec" Then

        '        scanReader = New scanReaderIntermecClass
        '        scanReader.disable()

        '#ElseIf deviceType = "Symbol" Then

        '        symbolReader = New scanReaderSymbolClass
        '        'symbolReader.ReaderForm_Load(Nothing, Nothing)
        '        symbolReader.disable()

        '#End If
#If deviceType <> "PC" Then
        scanReader = New scanReaderClass
        scanReader.disable()
#End If

        Return "OK"

    End Function

    Private Function initFromLastActiveUser() As String

        Dim result As String

        result = getLastActiveUser(lastActiveUserName)
        If result <> "OK" Then Return result

        If isNonNullString(lastActiveUserName) Then

            Dim initFormLogoPath As String = TagTrakConfigDirectory & "\" & lastActiveUserName & "InitFormLogo.bmp"

            If File.Exists(initFormLogoPath) Then
                baseFormPictureBox.Image = New System.Drawing.Bitmap(initFormLogoPath)
            End If

        End If

        Return "OK"

    End Function

    Private Function setupBaseConfiguration() As String

        releaseLabel.Text = "Release:" & myVersion

        If productionDistribution Then
            releaseLabel.Text &= "P"
        End If

        Dim baseConfigFileName = "BaseConfig.bin"

        If Not File.Exists(baseConfigFileName) Then Return "OK"

        Dim configFileInfo As FileInfo

        Try
            configFileInfo = New FileInfo(baseConfigFileName)
        Catch ex As Exception
            MsgBox("Stat on base configuration file failed: " & ex.Message)
            Return "Stat on base configuration file failed: " & ex.Message
        End Try

        Dim configFileLength As Integer = configFileInfo.Length

        If configFileLength <= 0 Then Return "OK"

        Dim inputStream As FileStream

        Try
            inputStream = New FileStream(baseConfigFileName, FileMode.Open)
        Catch ex As Exception
            MsgBox("Open on base configuration file failed: " & ex.Message)
            Return "Open on base configuration file failed: " & ex.Message
        End Try

        Dim inputBuffer(configFileLength - 1) As Byte

        Dim bytesRead As Integer = inputStream.Read(inputBuffer, 0, configFileLength)

        If (bytesRead <> configFileLength) Then
            MsgBox("Read on base configuration file failed: full file not read")
            Return "Read on base configuration file failed: full file not read"

            inputStream.Close()
        End If

        inputStream.Close()

        Dim i As Integer

        Dim configFileBuffer(configFileLength - 1) As Char

        For i = 0 To configFileLength - 1
            configFileBuffer(i) = Chr(inputBuffer(i) And &H7F)
        Next

        Dim configFileString As String = New String(configFileBuffer)

        releaseLabel.Text = configFileString

        If configFileString.EndsWith("P") Then
            productionDistribution = True
        Else
            productionDistribution = False
        End If

        Return "OK"

    End Function


    Private Sub formOnLoad(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        If productionDistribution Then
            Loading.ForeColor = Color.Black
            Loading.Text = "Scanning Program is Loading"
            LabelStatus.Text = "Please stand by..."
        Else
            Loading.ForeColor = Color.Red
            Loading.Text = "NOT FOR DISTRIBUTION"
            LabelStatus.Text = "TEST VERSION"
        End If

        Dim result As String

        Me.Refresh()

        ' Following block of code is moved out from start up routine of individual scan forms, as the serial number might be needed
        ' before any scan form is loaded, e.g. in check upload/download process
        If emulatingPlatform Then
            deviceSerialNumber = "emulator001"
        Else
            deviceSerialNumber = scannerLib.getDeviceSerialNumber()
        End If

#If deviceType = "PC" Then
        deviceSerialNumber = "PC0001"
#End If

        ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
        ' Load configuration file(s) and perform user configuration operations.                      '
        ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

        result = loadConfigurationFiles()

        If result <> "OK" Then

            MsgBox("Error in loading required configuration file: " & result & " Program will now terminate.")
            loggingIsActive = False
            Me.Close()
            Me.Dispose()

            Exit Sub

        End If

        ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
        ' Set up the device reader data structure for the specific device type                       '                                                     '                                                               '
        ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

        result = setupReaderDataClass()

        If result <> "OK" Then
            Me.Close()
            Me.Dispose()
            Exit Sub
        End If

        user = userSpecRecord.carrierCode

        Util.incrementProgramLoadProgressBar()

        ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
        ' After the configuration files have been loaded / parsed, a new base form logo may be       '
        ' available. At this point, the base form logo is reloaded.                                  '
        ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

        reloadBaseFormLogo()

        ' For migration purpose, copy the lastUsedLocation file over from UspsMail
        ' directory if the new one is unavailable, which indicates it is the first run
        ' of the new program.

        migrateLastUsedLocation()

        ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
        ' Remove old versions of the distribution cab files (note: probably not necessary at this    '
        ' point -- although harmless, should eventually be removed).                                 '
        ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

        removeOldVersionCabFiles()

        Util.incrementProgramLoadProgressBar()

        Dim configFileUserNumber As Integer = -1

        defaultLocation = userSpecRecord.defaultLocation

        'Dim itcscanDllSrc As String = deviceNonVolatileMemoryDirectory & "\TagTrakReload\itcscan.dll"
        'Dim itcscanDllDst As String = "Windows\itcscan.dll"

        'Dim psuuid0cDllSrc As String = deviceNonVolatileMemoryDirectory & "\TagTrakReload\psuuid0c.dll"
        'Dim psuuid0cDllDst As String = "Windows\psuuid0c.dll"

        scanDataPrimaryFilePath = TagTrakDataDirectory & "\" & userSpecRecord.userName & "MailData.txt"
        'scanDataSecondaryFilePath = "Flash File Store\" & userSpecRecord.userName & "MailData.txt"
        scanDataSecondaryFilePath = TagTrakBackupDirectory & "\" & userSpecRecord.userName & "MailData.txt"

        userSpecRecord.scanRecordSet = New ScanRecordSetClass(scanDataPrimaryFilePath, scanDataSecondaryFilePath)

        binChangeFilePath = TagTrakDataDirectory & "\" & userSpecRecord.userName & "BinChanges.txt"
        binUploadFilePath = TagTrakDataDirectory & "\" & userSpecRecord.userName & "BinUploads.txt"
        manifestFilePath = TagTrakDataDirectory & "\" & userSpecRecord.userName & "Manifest.txt"
        flightStatusFilePath = TagTrakDataDirectory & "\" & userSpecRecord.userName & "FlightStatus.txt"
        carditRoutingFilePath = TagTrakDataDirectory & "\NewCarditRoutings.txt"
        fullCartUnloadFilePath = TagTrakDataDirectory & "\" & userSpecRecord.userName & "FullCartUnloads.txt"
        fullFlightUnloadFilePath = TagTrakDataDirectory & "\" & userSpecRecord.userName & "FullFlightUnloads.txt"

        'reloadFileIfNecessary(itcscanDllSrc, itcscanDllDst)
        'reloadFileIfNecessary(psuuid0cDllSrc, psuuid0cDllDst)

        If File.Exists("\Flash File Store\HardwareError.txt") Then
            Dim hardwareErrorLockDown As New deviceHardwareErrorMessage
            hardwareErrorLockDown.ShowDialog()
        End If

        Dim lastUsedLocation As String = getLastLocation()

        If Not isNonNullString(lastUsedLocation) Then
            lastUsedLocation = userSpecRecord.defaultLocation
        End If

        'Dim lastUsedAirport As locationClass = airportSetClass.Instance.Item(Substring(lastUsedLocation, 0, 3))

        'If lastUsedAirport Is Nothing Then

        '    scannerTimeZone = timeZoneSet.Item(timeZoneName.EasternUS)

        'Else

        '    scannerTimeZone = lastUsedAirport.timeZone

        '    If scannerTimeZone Is Nothing Then
        '        MsgBox("Cannot get time zone for location: " & lastUsedLocation)
        '        Stop
        '    End If

        'End If

        logSetupLogging()

        Util.incrementProgramLoadProgressBar()

        loadCarditRoutingFile()
        loadNewCarditRoutings()

        Dim localDataFile As String = TagTrakDataDirectory & "\FlightRoutes.txt"
        If File.Exists(localDataFile) Then
            TagTrakGlobals.FlightRoutes = New FlightRoutesClass(localDataFile)
        End If

        localDataFile = TagTrakDataDirectory & "\FlightScheduleExt.txt"
        If File.Exists(localDataFile) Then
            flightScheduleSet = Data.FlightSchedule.Flights.ParseFile(localDataFile)
        End If

        localDataFile = TagTrakDataDirectory & "\FlightLoadInfo.txt"
        If File.Exists(localDataFile) Then
            flightLoadInfo = Data.FlightLoadInfo.Info.ParseFile(localDataFile)
        End If

        '' Retrieve time zone info for last used location
        localDataFile = TagTrakDataDirectory & "\tz2.txt"
        If File.Exists(localDataFile) And lastUsedLocation Is Nothing = False Then
            scannerTimeZone = Time.TimeZone.Load(localDataFile, lastUsedLocation)
        End If

        '' Try to load the city list if it exists
        localDataFile = TagTrakDataDirectory & "\airport_codes.txt"
        If File.Exists(localDataFile) Then
            Data.Cities.List.Load(localDataFile)
        End If


        If Not validatePlatform() Then
            loggingIsActive = False
            Me.Close()
            Me.Dispose()
            Exit Sub
        End If

        Dim operation As String
        Dim i As Integer

        i = 0

        For Each operation In operationsMasterList
            operationsMasterTable.Add(operation, i)
            i += 1
        Next

        Me.baseFormPictureBox.Visible = True
        Me.baseFormPictureBox.Update()

        'System.Threading.Thread.Sleep(1000)

        'Application.DoEvents()
        '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

        activeInitForm = tagTrakFormRepository.initializationForm

        programLoadProgressBar.Value = 100

        'Added by MX
        If userSpecRecord.loginEnabled = True Then
            Dim frmLogin As New TagTrakLogin
            frmLogin.ShowDialog()
        End If

        Try
            'Me.Hide()
            DialogResult = activeInitForm.ShowDialog()
            'activeInitForm.Show()
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try

        If DialogResult = DialogResult.Abort Then
            Me.DialogResult = DialogResult.Abort
            loggingIsActive = False
            Me.Close()
            Me.Dispose()
            Exit Sub
        End If

        'scanLocation.update(lastUsedLocation)


        If CType(userSpecRecord.cityTable.Item(scanLocation.currentLocation), CityConfig).GetSetAutosendWhenDocked Then
            autoFTPTimer.Interval = CType(userSpecRecord.cityTable.Item(scanLocation.currentLocation), CityConfig).GetSetAutosendPeriodicity * 60000
            backgroundFtpTimer.Enabled = True
        End If

        If CType(userSpecRecord.cityTable.Item(scanLocation.currentLocation), CityConfig).GetSetAutosend Then
            autoFTPTimer.Interval = CType(userSpecRecord.cityTable.Item(scanLocation.currentLocation), CityConfig).GetSetAutosendPeriodicity * 60000
            autoFTPTimer.Enabled = True
        End If

        If userSpecRecord.mailScanEnabled Then
            Dim domMailForm As MailScanDomsForm
            domMailForm = MailScanFormRepository.MailScanDomsForm
            domMailForm.Show()
        ElseIf userSpecRecord.internationalMailEnabled Then
            Dim intlMailForm As MailScanIntlForm
            intlMailForm = MailScanFormRepository.MailScanIntlForm()
            intlMailForm.Show()
        End If

        removeOldVersion()

        ' Since we are restarting the program we must reload the cardit routing table

        loggingIsActive = False

        'Me.Close()

    End Sub

    Private Sub removeOldVersionCabFiles()

        'Dim oldFileFound As Boolean = False

        Dim oldCabs() As String = { _
            deviceNonVolatileMemoryDirectory & "\cabfiles\UspsMail.cab", _
            deviceNonVolatileMemoryDirectory & "\cabfiles\dep_files.cab", _
            deviceNonVolatileMemoryDirectory & "\cabfiles\net-internet.cab", _
            deviceNonVolatileMemoryDirectory & "\cabfiles\uspsata.cab", _
            deviceNonVolatileMemoryDirectory & "\cabfiles\olddel.cab" _
        }

        Dim cabFilePath As String

        For Each cabFilePath In oldCabs
            If File.Exists(cabFilePath) Then
                deleteLocalFile(cabFilePath)
                'oldFileFound = True
            End If
        Next

        'If oldFileFound Then
        '    Dim x1 As New scannerLibClass
        '    MsgBox("A ColdBoot is now required to ensure system functionality.  Please Click OK.", MsgBoxStyle.Exclamation, "Cold Boot Required")
        '    x1.ColdBoot()
        'Else
        ' targeting the first boot from above coldboot(), put aside the flash autostart if REGISTRY.SYS exists, 
        ' to ensure the program can boot in widest circumstances as possible. On the other hand, if the REGISTRY.SYS
        ' is removed sometime later, we want to get autorun.exe back.
        Dim flashAutoRun As String = "\Flash File Store\2577\autorun.exe"
        Dim flashAutoRunBk As String = "\Flash File Store\2577\autorun.exe.bk"
        Dim regSys As String = deviceNonVolatileMemoryDirectory & "\REGISTRY.SYS"
        If Not File.Exists(regSys) And File.Exists(flashAutoRunBk) And Not File.Exists(flashAutoRun) Then
            moveLocalFile(flashAutoRunBk, flashAutoRun)
        ElseIf File.Exists(regSys) And File.Exists(flashAutoRun) Then
            moveLocalFile(flashAutoRun, flashAutoRunBk)
        End If
        'End If
    End Sub


    Private Function validatePlatform() As Boolean

#If deviceType = "Intermec" Then

        If Not Directory.Exists("Flash File Store") Then
            MsgBox("This Software Is Not Configured For An Intermec Device", MsgBoxStyle.Exclamation, "Invalid Platform")
            Return False
        End If

        Return True

#ElseIf deviceType = "Symbol" Then

        If Not Directory.Exists("Application") Then
            MsgBox("This Software Is Not Configured For A Symbol Device", MsgBoxStyle.Exclamation, "Invalid Platform")
            Return False
        End If

        Return True

#ElseIf deviceType = "ViewSonic" Then

        If Not Directory.Exists("My Flash Disk") Then
            MsgBox("This Software Is Not Configured For A Symbol Device", MsgBoxStyle.Exclamation, "Invalid Platform")
            Return False
        End If

        Return True
#End If

        Return True

    End Function

    Private Sub reloadFileIfNecessary(ByRef sourceFilePath As String, ByRef destinationFilePath As String)

#If ValidationLevel >= 3 Then

        If diagnosticLevel >= 2 Then
            verify(Not sourceFilePath Is Nothing, 2)
            verify(Not destinationFilePath Is Nothing, 3)
        End If

#End If

        If File.Exists(destinationFilePath) Then Exit Sub

        If Not File.Exists(sourceFilePath) Then Exit Sub

        copyLocalFile(sourceFilePath, destinationFilePath)

    End Sub

    Private Sub reloadBaseFormLogo()
        Dim initFormLogoPath As String = TagTrakConfigDirectory & "\" & userSpecRecord.userName & "InitFormLogo.bmp"

        If File.Exists(initFormLogoPath) Then
            baseFormPictureBox.Image = New System.Drawing.Bitmap(initFormLogoPath)
        End If
    End Sub

    Private Sub migrateLastUsedLocation()
        Dim lastLocationFilePath As String = TagTrakConfigDirectory & "\" & userSpecRecord.userName & "LastUsedLocation.txt"
        Dim oldLastLocationFilePath As String = deviceNonVolatileMemoryDirectory & "\UspsMailConfig\" & userSpecRecord.userName & "LastUsedLocation.txt"
        If File.Exists(oldLastLocationFilePath) And Not File.Exists(lastLocationFilePath) Then
            copyLocalFile(oldLastLocationFilePath, lastLocationFilePath)
        End If
    End Sub

    Private Sub buzzLengthTimer_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles buzzLengthTimer.Tick
        buzzLengthTimer.Enabled = False
#If deviceType = "Intermec" Then
        scannerLib.VibrateOFF()
#End If

    End Sub

    Private Sub updateUploadReminder()

        Dim resditFileSize As Integer = getFileSize(scanDataPrimaryFilePath)

        If resditFileSize <= 0 Then

            uploadReminderMinuteCount = 120
            Exit Sub

        End If

        If uploadReminderMinuteCount = 30 Then

            tagTrakFormRepository.resditUploadReminderForm.initResditUploadReminderForm(30)
            Me.DialogResult = tagTrakFormRepository.resditUploadReminderForm.ShowDialog()
            If Me.DialogResult = DialogResult.Abort Then
                Me.Close()
                Exit Sub
            End If

        End If

        If uploadReminderMinuteCount = 15 Then

            tagTrakFormRepository.resditUploadReminderForm.initResditUploadReminderForm(15)
            Me.DialogResult = tagTrakFormRepository.resditUploadReminderForm.ShowDialog()
            If Me.DialogResult = DialogResult.Abort Then
                Me.Close()
                Exit Sub
            End If

        End If

        If uploadReminderMinuteCount = 10 Then

            tagTrakFormRepository.resditUploadReminderForm.initResditUploadReminderForm(10)
            Me.DialogResult = tagTrakFormRepository.resditUploadReminderForm.ShowDialog()
            If Me.DialogResult = DialogResult.Abort Then
                Me.Close()
                Exit Sub
            End If

        End If

        If uploadReminderMinuteCount = 5 Then

            tagTrakFormRepository.resditUploadReminderForm.initResditUploadReminderForm(5)
            Me.DialogResult = tagTrakFormRepository.resditUploadReminderForm.ShowDialog()
            If Me.DialogResult = DialogResult.Abort Then
                Me.Close()
                Exit Sub
            End If

        End If

        If uploadReminderMinuteCount <= 0 Then
            uploadReminderMinuteCount = 5
        End If

    End Sub

End Class
