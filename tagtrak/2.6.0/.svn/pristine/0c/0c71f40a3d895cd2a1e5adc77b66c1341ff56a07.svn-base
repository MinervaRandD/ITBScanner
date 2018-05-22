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

Imports System.IO

Module TagTrakGlobals


    ' The following choice specified the device type. Current options are "Intermec", "Symbol", or "PC"

#If deviceType = "Intermec" Then

    Public Const device As String = "Intermec"
    'Public scanReader As scanReaderIntermecClass = Nothing
    Public scanReader As ScanReaderClass

#ElseIf deviceType = "Symbol" Then

    Public Const device As String = "Symbol"
    'Public symbolReader As scanReaderSymbolClass = Nothing
    Public scanReader As ScanReaderClass

#ElseIf deviceType = "Dolphin" Then

    Public Const device As String = "Dolphin"
    Public scanReader As scanReaderClass

#ElseIf deviceType = "ViewSonic" Then

    Public Const device As String = "ViewSonic"

#ElseIf deviceType = "PC" Then

    public const device as String = "PC"

#End If

    ' !!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!
    ' !! Note: The order of the elements in the user list is critical. If new users are added, always add them   !!
    ' !!       to the END of the list. Also, this user list must be sync'ed with the user list in the encryption !!
    ' !!       program                                                                                           !!
    ' !!                                                                                                         !!                                                                                             
    ' !!                     KEEP THIS LIST IN SYNC WITH TagTrakEncrypt                                         !!     
    ' !!                        |  |  |  |  |  |  |  |  |  |  |  |  |                                            !!
    ' !!                        V  V  V  V  V  V  V  V  V  V  V  V  V
    'Public userList() As String = {"ASI", "ATA", "JetBlue", "USAirways", "PacificAirCargo", "MNAviation", "SpiritAir", _
    '    "Roblex", "AirFlamenco", "Olympic", "Aloha", "Alpine", "AirTran", "AirCanada", "AirNewZealand", "Lufthansa"}
    Public userList() As String = {"AS", "TZ", "B6", "US", "K4", "W4", "NK", _
        "7O", "60", "OA", "AQ", "5A", "FL", "AC", "NZ", "LH", "RG", "99"}
    ' !!                        ^  ^  ^  ^  ^  ^  ^  ^  ^  ^  ^  ^  ^
    ' !!                        |  |  |  |  |  |  |  |  |  |  |  |  |                                            !!
    ' !!                                                                                                         !!                                                                                             
    ' !!                     KEEP THIS LIST IN SYNC WITH TagTrakEncrypt                                         !!     
    ' !!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!

    'This is a one time change, will be removed after upgrading
    Public oldLastUser As String = ""
    Public oldLastUsedLocation As String = ""

    Public cultureInfo As New System.Globalization.CultureInfo("en-US", False)

    Public loginUserName As String

    'Public isTagTrakBaseFormLoaded = False

    'Public numberOfUsers As Integer = userList.Length

    Public loadedUserList As New ArrayList

    Public userNumberTable As New Hashtable

    'Public mainRemoteUpdateFileName As String = "Update.cab"    ' Release value is "Update.cab"

#If DEBUG Then
    Public lockDown As Boolean = False
#Else
    Public lockDown As Boolean = True
#End If


    Public primaryDataFileDirectoryIsValid As Boolean = True
    Public secondaryDataFileDirectoryIsValid As Boolean = True

    'Public Const maxNumberOfResditBackupFiles As Integer = 500

    Public configTextFileIsEncrypted As Boolean = True


    ' *********************************************************************************************
    ' *********************************************************************************************

    Public Const backSlash As Char = "\"c

    'Public scannerState As String = ""

    Public criticalSectionSemiphore As New crticalSectionSemiphoreClass(False)

    Public userSpecRecord As New userSpecRecordClass

    Public currentTabPage As String = ""
    Public previousTabPage As String = ""
    Public lastUsedMailScanPage As String = ""

    Public routingSet As New routingSetClass
    Public flightScheduleSet As New Data.FlightSchedule.Flights(False)      '' Tracks Flight Direction and which City.
    Public flightLoadInfo As New Data.FlightLoadInfo.Info               '' Is the load known for the entire flight.

    Public newRoutingsRecordSet As New ArrayList

    Public binChangeTable As New Hashtable
    Public binChangeFilePath As String

    Public scanDataPrimaryFilePath As String
    Public scanDataSecondaryFilePath As String

    Public binUploadFilePath As String
    Public manifestFilePath As String
    Public flightStatusFilePath As String
    Public carditRoutingFilePath As String
    Public fullCartUnloadFilePath As String
    Public fullFlightUnloadFilePath As String

    Public scannerTimeZone As New Time.TimeZone

    '' Saves the type of last successful time query
    Enum TimeSyncTypes
        None
        NTP
        FTPTime
    End Enum
    Public lastTimeSync As TimeSyncTypes = TimeSyncTypes.None

    'Public Const serverDateAndTimeIsUTC As Boolean = True

    'Public cancelClosingEvent As Boolean = True

    'Public resditVersionNumber As String = "40107"
    'Public usingNormalOutputFormat As Boolean = True

    Public newApplicationVersionFound As Boolean = False
    Public newConfigurationFileFound As Boolean = False
    Public newCarditRoutingFileFound As Boolean = False
    Public newFlightScheduleFileFound As Boolean = False
    Public newFlightLoadInfoFound As Boolean = False

    Public newOntimeFileFound As Boolean = False
    Public newFlightRoutesFileFound As Boolean = False

    Public deviceSerialNumber As String

    '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
    '  Declarations for directory path names used by program  '
    '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

    Public deviceNonVolatileMemoryDirectory As String
    Public deviceBackupDirectory As String
    'Added by MX
    Public selectedCarrierPath As String

    Public D2577Directory As String
    Public CabfilesDirectory As String

    Public TagTrakTempDirectory As String
    Public TagTrakConfigDirectory As String
    Public TagTrakBackupDirectory As String
    'Public TagTrakReloadDirectory As String
    Public TagTrakDataDirectory As String
    Public TagTrakSummariesDirectory As String

    'Public updateVersionFilePath As String
    'Public updateVersionDirectory As String

    Public summaryFilePath As String = "summaries\ORG"
    Public summaryFileDirectory As String = "summaries"

    'Public presetFilePath As String = "Application\PresetYYMMDDHHMM"
    'Public presetFileDirectory As String = "Application"

    Public backupResditFilePath As String
    Public backupCargoFilePath As String
    Public backupBaggageFilePath As String

    'Public activeReaderForm As MailScanDomsForm
    Public activeInitForm As initializationForm

    Public currentAdminLoginForm As adminLoginForm

    'Public mainHostName As String = "ftp.airline-software.com"
    'Public mainPort As Integer = 21

    'Public mainRemoteFile As String = "Resdit"
    'Public mainRemoteFileName As String

    'Public mainLocalFileSize As Integer = 0

    'Public mainTransferBinary As Boolean = True

    'Public resditFileFound As Boolean = False

    'Public mainLocalUpdateFileName As String = "Update.cab"

    'Public mainInstallCabFileName As String = "Application\USPS Install\Three.arm.CAB"

    'Public summaryFileName As String

    'Public summaryFileOrg As String
    'Public summaryFileDst As String
    'Public summaryFileFlightNumber As String
    'Public summaryFilePossessionPieces As Integer
    'Public summaryFilePossessionWeight As Integer
    'Public summaryFileThroughPieces As Integer
    'Public summaryFileThroughWeight As Integer

    'Public applicationShouldExit As Boolean

    Public serverDateAndTimeUTC As DateTime = DateTime.UtcNow
    '' For NTP stores the server used
    Public serverDateAndTimeSource As String
    Public scannerDateAndTimeUTC As DateTime = DateTime.UtcNow

    'Public timerValue As Integer

    '    Public daylightSavingsTimeEnd(10) As DateTime

    Public systemDateString As String
    'Public tomorrow As Date

    Public updateProgressBar As Boolean = True

    'Public dateTimeMustBeReset As Boolean = False

    'Public uploadDownloadCriticalSection As Object
    'Public summaryFileAccessCriticalSection As New Object

    'Public processingTimerAlarm As Boolean = False
    'Public doingManualUploadDownload As Boolean = False

    'Public lastFtpConnectionPoint As String = ""

    Public uploadReminderMinuteCount As Integer

    Public dateAndTimeSet As Boolean = False

    Public defaultLocation As String = ""

    'Public flightValidationMessageDisplayed As Boolean = False

    Public psuuid As New psuuidClass
    Public scannerLib As New scannerLibClass

    Public globalScanCount As Integer = 0

    Public withinAddRoutingForm As Boolean = False

    'Public largeBarcodeButtonState As Integer = 0

    Public operationsMasterList() As String = { _
        "Possession", _
        "Load", _
        "Delivery", _
        "Transfer", _
        "Possession & Load", _
        "Reroute", _
        "Unload", _
        "Partial Offload", _
        "Complete Offload", _
        "Return"}

    Public internationalOperationsMasterList() As String = { _
        "Possession", _
        "Load", _
        "Delivery", _
        "Partial Offload", _
        "Complete Offload", _
        "Offline Trns. Conveyed", _
        "Offline Trns. Received", _
        "Online Transfer", _
        "Unload", _
        "Arrived", _
        "Return"}

    Public operationsMasterTable As New Hashtable

    'Public DSTChangeDatesSet As New DSTChangeDateProtocolSetClass

    'Public timeZoneSet As New timeZoneSetClass
    'Public airportSet As New airportSetClass
    'Public airlineSet As New AirlineSetClass
    'Public countrySet As New countrySetClass

    Public logMaintenanceThread As System.threading.Thread

    Public loggingIsActive As Boolean = False

    Public programLoadProgressBar As System.Windows.Forms.ProgressBar

    Public messageList As New ArrayList

    Public lastSelectedPresetForScanScreen As presetRecordClass = Nothing

    Private _scanLocation As New TagTrakCurrentLocationClass

    Public Property scanLocation() As TagTrakCurrentLocationClass
        Get
            Return _scanLocation
        End Get

        Set(ByVal Value As TagTrakCurrentLocationClass)
            _scanLocation = Value
        End Set

    End Property

#If deviceType = "Intermec" Then
    Public Const Code128 As Integer = 7
    Public Const code93 As Integer = 2
    Public Const code39 As Integer = 1
#End If

#If deviceType = "Symbol" Then
    Public Const Code128 As Integer = 60
    Public Const code93 As Integer = 59
    Public Const code39 As Integer = 1
#End If

    ' Not really readed for ViewSonic since it does not scan. But added
    ' so that the application compiles

#If deviceType = "ViewSonic" Then
    Public Const Code128 As Integer = 60
    Public Const code93 As Integer = 59
    Public Const code39 As Integer = 1
#End If

    'Friend WithEvents globalLowerCasePictureBox As Windows.Forms.PictureBox
    'Friend WithEvents globalUpperCasePictureBox As Windows.Forms.PictureBox
    'Friend WithEvents globalKeyboardPanel As Windows.forms.Panel

    'Friend WithEvents globalKeyboardIcon As Windows.Forms.PictureBox

    'Public globalInitFormLogo As System.Drawing.Image

    'Public Const tabKeyChar As Char = Chr(27)

    Public auxInstallAvailable As Boolean = False

    Public readerFormLoaded As Boolean = False

    Public currentSummaryFileIsValid As Boolean = False

    'Public tagTrakFormRepository As New tagTrakFormRepository

    Public deviceInCradle As Boolean = False

    Public backgroundFtpTimer As New TagTrakBackgroundFtpTimerClass

    'Added by MX
    Public autoFTPTimer As New AutoSendTimer
    Public WithEvents uploadReminderTimer As New System.Windows.Forms.Timer
    Public timeCounter As Integer = 0

    Public fieldSepChar As Char = Chr(9)

    'Public ProgEnded As Boolean = False ' flag variable, used in some event handlers to facilitate a complete exit

    Public defaultPostOfficeList As String = "CA,NZ,US"

    Public AttemptingWireless As Boolean = False ' a flag indicating whether the program is attempting wireless connection, a period the ballon may appear and need to be killed.

    Private Function handleUploadButtonClick() As DialogResult

        Dim dialogResult As DialogResult

        Dim ftpProcessDisplayForm As New ftpProcessForm

        dialogResult = ftpProcessDisplayForm.ShowDialog()

        If dialogResult = dialogResult.Abort Then
            Return dialogResult.Abort
        End If

        If auxInstallAvailable Then
            Dim dlg As New adminFunctionsNotificationForm


            dialogResult = dlg.ShowDialog()

            If dialogResult = dialogResult.Abort Then
                Return dialogResult.Abort
            End If

        End If

        If newApplicationVersionFound Or newConfigurationFileFound Then

            Dim newVersionDisplayForm As New newVersionNotification
            dialogResult = newVersionDisplayForm.ShowDialog()

            If dialogResult = dialogResult.Abort Then
                Return dialogResult.Abort
            End If

        End If

        If newOntimeFileFound Then

            Dim localOntimeFilePath As String = TagTrakConfigDirectory & "\ontime.txt"

            loadOntimeFile(localOntimeFilePath)

        End If

        If newFlightRoutesFileFound Then

            TagTrakGlobals.FlightRoutes = New FlightRoutesClass(TagTrakDataDirectory & "\FlightRoutes.txt")

        End If

        If newFlightScheduleFileFound Then
            flightScheduleSet = Data.FlightSchedule.Flights.ParseFile(TagTrakDataDirectory & "\FlightScheduleExt.txt")
            newFlightScheduleFileFound = False
        End If

        If newFlightLoadInfoFound Then
            flightLoadInfo = Data.FlightLoadInfo.Info.ParseFile(TagTrakDataDirectory & "\FlightLoadInfo.txt")
            newFlightLoadInfoFound = False
        End If

        If newCarditRoutingFileFound Then
            loadCarditRoutingFile()
        End If

        Return dialogResult.OK

    End Function

    Public Function uploadButtonClick() As DialogResult

        Dim dialogResult As DialogResult

        logUploadButtonClickEvent(1, "Entering upload button click handler")

        ' The following semiphore should never be needed by this event handler. It is used in
        '    1. The various timers and
        '    2. Ftp processes
        ' to avoid having anything interrupt the scan handling process.

        SyncLock criticalSectionSemiphore

            If criticalSectionSemiphore.getSemiphoreState = False Then

                criticalSectionSemiphore.setSemiphoreState(True)

                Util.turnScannerOff(44)
                TagTrakGlobals.backgroundFtpTimer.Enabled = False

                dialogResult = handleUploadButtonClick()

                Util.turnScannerOn(45)

                TagTrakGlobals.backgroundFtpTimer.Enabled = True

                criticalSectionSemiphore.setSemiphoreState(False)

            End If

        End SyncLock

        Application.DoEvents()

        Return dialogResult

    End Function

    Public currentScanOperation As String = ""

    Public FlightRoutes As FlightRoutesClass = Nothing


    Private Sub uploadReminderTimer_Tick(ByVal sender As Object, ByVal e As System.EventArgs) Handles uploadReminderTimer.Tick

        Dim secondInterval As Integer = 0

        TagTrakGlobals.uploadReminderTimer.Enabled = False

        If userSpecRecord.SecondReminderInterval > 0 Then
            secondInterval = userSpecRecord.SecondReminderInterval
        Else
            secondInterval = 15
        End If

        TagTrakGlobals.uploadReminderTimer.Interval = secondInterval * 60000

        TagTrakGlobals.uploadReminderTimer.Enabled = True

        If timeCounter > 0 Then

            MsgBox("You have " & timeCounter.ToString & " minutes left to upload your scanner data and you will be reminded every " & secondInterval & "  minutes.", MsgBoxStyle.Exclamation)

            If userSpecRecord.SecondReminderInterval > 0 Then
                timeCounter -= userSpecRecord.SecondReminderInterval
            Else
                timeCounter -= 15
            End If

        Else
            TagTrakGlobals.uploadReminderTimer.Enabled = False
        End If

    End Sub

    'Function loadTimeZoneOffsetInfo(ByVal timeZoneFilePath As String, ByVal airportCode As String) As String

    '    If timeZoneFilePath Is Nothing Or airportCode Is Nothing Then
    '        Return "Invalid parameters passed to 'loadTimeZoneOffsetInfo'"
    '    End If

    '    If airportCode.Length <> 3 Then
    '        Return "Invalid parameters passed to 'loadTimeZoneOffsetInfo'"
    '    End If

    '    If Not File.Exists(timeZoneFilePath) Then Return "OK"

    '    Dim timeZoneFileReader As StreamReader

    '    Try

    '        timeZoneFileReader = New StreamReader(timeZoneFilePath)

    '    Catch ex As Exception

    '        timeZoneFileReader.Close()
    '        Return "Attempt to open time zone file for input failed: " + ex.Message

    '    End Try

    '    Dim baseUTCOffset As Double = System.Double.NaN

    '    Try
    '        Dim inputLine As String

    '        inputLine = timeZoneFileReader.ReadLine()

    '        While Not inputLine Is Nothing And System.Double.IsNaN(baseUTCOffset)

    '            If inputLine.Length > 3 Then

    '                If String.Compare(airportCode, 0, inputLine, 0, 3, True) = 0 Then

    '                    Dim strTimeZoneOffset As String = inputLine.Substring(3).Trim()

    '                    If Not Util.IsDouble(strTimeZoneOffset) Then
    '                        timeZoneFileReader.Close()
    '                        Return "Invalid data in time zone file for airport """ & airportCode & """"
    '                    End If

    '                    Try
    '                        baseUTCOffset = System.Double.Parse(strTimeZoneOffset)
    '                    Catch ex As Exception
    '                        timeZoneFileReader.Close()
    '                        Return "Invalid data in time zone file for airport """ & airportCode & """"
    '                    End Try

    '                End If

    '            End If

    '            inputLine = timeZoneFileReader.ReadLine()

    '        End While

    '    Catch ex As Exception
    '        timeZoneFileReader.Close()
    '        Return "Attempt to read time zone file failed: " + ex.Message
    '    End Try

    '    timeZoneFileReader.Close()

    '    If System.Double.IsNaN(baseUTCOffset) Then
    '        Return "OK"
    '    End If
    '    scannerTimeZone.OffsetUTC = baseUTCOffset

    '    If TagTrakGlobals.scanLocation Is Nothing Then Return "OK"

    '    Dim location As String = TagTrakGlobals.scanLocation.currentLocation

    '    If location Is Nothing Then Return "OK"

    '    Dim airport As locationClass = airportSetClass.Instance.Item(location)

    '    If airport Is Nothing Then Return "OK"

    '    Dim timeZoneRecord As TimeZoneRecordClass = airport.timeZone

    '    If timeZoneRecord Is Nothing Then Return "OK"

    '    timeZoneRecord.BaseUTCOffset = baseUTCOffset

    'End Function

End Module
