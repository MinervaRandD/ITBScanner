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

Public Class initializationForm

    Inherits System.Windows.Forms.Form

    Friend WithEvents dateTimePanel As System.Windows.Forms.Panel
    Friend WithEvents Label14 As System.Windows.Forms.Label
    Friend WithEvents dateTimeLabel As System.Windows.Forms.Label
    Friend WithEvents dateTimeCorrectButton As System.Windows.Forms.Button
    Friend WithEvents dateTimeIncorrectButton As System.Windows.Forms.Button
    Friend WithEvents verifyDateTimeLabel As System.Windows.Forms.Label
    Friend WithEvents continueToScanButton As System.Windows.Forms.Button
    Friend WithEvents uploadDownLoadButton As System.Windows.Forms.Button
    Friend WithEvents confirmLocationButton As System.Windows.Forms.Button
    Friend WithEvents selectLocationLabel As System.Windows.Forms.Label

    Dim lastLocation As String
    Dim lastLocationIndex As Integer

#Region " Windows Form Designer generated code "

    Public Sub New()

        MyBase.New()

        'This call is required by the Windows Form Designer.
        InitializeComponent()

        scanLocation.addControl(cbxInitLocation)

        Util.incrementProgramLoadProgressBar()

        dateTimePanel.Visible = False
        dateTimePanel.Enabled = False

        verifyDateTimeLabel.Enabled = False
        dateTimeLabel.Enabled = False

        dateTimeCorrectButton.Enabled = False
        dateTimeIncorrectButton.Enabled = False

        uploadDownLoadButton.Enabled = False

        uploadDownLoadButton.Enabled = False
        uploadDownLoadButton.Visible = False

        continueToScanButton.Enabled = False
        continueToScanButton.Visible = False

        Dim initFormLogoPath As String
        Dim userName As String

        If loadedUserList.Count = 1 Then

            loadInitFormLogo()

            initFormLogoPictureBox.Visible = True

            setLastActiveUser(userSpecRecord.userName)

        ElseIf loadedUserList.Count > 1 Then

            Dim lastActiveUser As String

            getLastActiveUser(lastActiveUser)

            initFormLogoPictureBox.Visible = False

            confirmLocationButton.Enabled = False
            cbxInitLocation.Enabled = False

            selectLocationLabel.Visible = False

            cbxInitLocation.Visible = False
            cbxInitLocation.Enabled = False

            confirmLocationButton.Visible = False
            confirmLocationButton.Enabled = False

            Dim nextUserSpecRecord As userSpecRecordClass

            Dim selectedIndex As Integer = 0
            Dim i As Integer = 0

            For Each nextUserSpecRecord In loadedUserList

                If nextUserSpecRecord.userName = lastActiveUser Then
                    selectedIndex = i
                End If

                i += 1
            Next

        Else

        End If

        'Changed by MX 9/14
        Util.LoadComboBoxFromList(cbxInitLocation, userSpecRecord.cityList)

        If cbxInitLocation.Items.Count > 0 Then
            If isNonNullString(cbxInitLocation.Items.Item(0)) Then
                cbxInitLocation.Items.Insert(0, "")
            End If
        End If

    End Sub

    Private Sub formOnLoad(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        Dim localFilePath As String
        Dim result As Object

        'Modified by MX
        localFilePath = deviceNonVolatileMemoryDirectory & selectedCarrierPath & "\Routings.bin"

        If File.Exists(localFilePath) Then

            result = routingSet.read(localFilePath)

            If result.GetType.ToString = "String" Then
                MsgBox("Load Of Routings File Failed: " & result)
                Exit Sub
            End If

        End If

        lastLocation = getLastLocation()

        If isNonNullString(lastLocation) Then
            If cbxInitLocation.Items.Contains(lastLocation) Then
                cbxInitLocation.SelectedItem = lastLocation
                TagTrakGlobals.scanLocation.currentLocation = lastLocation ' in order to fire password prompt when user attempts to change location, which would have been bypassed if currentlocation is empty --- not cleanest approach
            Else
                cbxInitLocation.SelectedIndex = -1
            End If
        End If

        lastLocationIndex = cbxInitLocation.SelectedIndex

    End Sub

    Protected Overloads Overrides Sub Dispose(ByVal disposing As Boolean)
        MyBase.Dispose(disposing)
    End Sub

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    Friend WithEvents exitButton As System.Windows.Forms.Button
    Friend WithEvents initFormLogoPictureBox As System.Windows.Forms.PictureBox
    Friend WithEvents cbxInitLocation As System.Windows.Forms.ComboBox
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Dim resources As System.Resources.ResourceManager = New System.Resources.ResourceManager(GetType(initializationForm))
        Me.initFormLogoPictureBox = New System.Windows.Forms.PictureBox
        Me.dateTimePanel = New System.Windows.Forms.Panel
        Me.Label14 = New System.Windows.Forms.Label
        Me.dateTimeLabel = New System.Windows.Forms.Label
        Me.dateTimeCorrectButton = New System.Windows.Forms.Button
        Me.dateTimeIncorrectButton = New System.Windows.Forms.Button
        Me.verifyDateTimeLabel = New System.Windows.Forms.Label
        Me.continueToScanButton = New System.Windows.Forms.Button
        Me.uploadDownLoadButton = New System.Windows.Forms.Button
        Me.confirmLocationButton = New System.Windows.Forms.Button
        Me.selectLocationLabel = New System.Windows.Forms.Label
        Me.cbxInitLocation = New System.Windows.Forms.ComboBox
        Me.exitButton = New System.Windows.Forms.Button
        '
        'initFormLogoPictureBox
        '
        Me.initFormLogoPictureBox.Image = CType(resources.GetObject("initFormLogoPictureBox.Image"), System.Drawing.Image)
        Me.initFormLogoPictureBox.Location = New System.Drawing.Point(12, 4)
        Me.initFormLogoPictureBox.Size = New System.Drawing.Size(224, 64)
        '
        'dateTimePanel
        '
        Me.dateTimePanel.Controls.Add(Me.Label14)
        Me.dateTimePanel.Controls.Add(Me.dateTimeLabel)
        Me.dateTimePanel.Controls.Add(Me.dateTimeCorrectButton)
        Me.dateTimePanel.Controls.Add(Me.dateTimeIncorrectButton)
        Me.dateTimePanel.Controls.Add(Me.verifyDateTimeLabel)
        Me.dateTimePanel.Location = New System.Drawing.Point(8, 165)
        Me.dateTimePanel.Size = New System.Drawing.Size(224, 75)
        '
        'Label14
        '
        Me.Label14.Location = New System.Drawing.Point(8, 5)
        Me.Label14.Size = New System.Drawing.Size(208, 18)
        Me.Label14.Text = "Confirm Date and Time"
        '
        'dateTimeLabel
        '
        Me.dateTimeLabel.Location = New System.Drawing.Point(20, 25)
        Me.dateTimeLabel.Size = New System.Drawing.Size(187, 16)
        Me.dateTimeLabel.Text = "Date"
        Me.dateTimeLabel.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'dateTimeCorrectButton
        '
        Me.dateTimeCorrectButton.Location = New System.Drawing.Point(62, 48)
        Me.dateTimeCorrectButton.Size = New System.Drawing.Size(66, 24)
        Me.dateTimeCorrectButton.Text = "Correct"
        '
        'dateTimeIncorrectButton
        '
        Me.dateTimeIncorrectButton.Location = New System.Drawing.Point(136, 48)
        Me.dateTimeIncorrectButton.Size = New System.Drawing.Size(72, 24)
        Me.dateTimeIncorrectButton.Text = "Incorrect"
        '
        'verifyDateTimeLabel
        '
        Me.verifyDateTimeLabel.Location = New System.Drawing.Point(-1, 41)
        Me.verifyDateTimeLabel.Size = New System.Drawing.Size(64, 29)
        Me.verifyDateTimeLabel.Text = "Date and Time Are"
        Me.verifyDateTimeLabel.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'continueToScanButton
        '
        Me.continueToScanButton.Location = New System.Drawing.Point(144, 248)
        Me.continueToScanButton.Size = New System.Drawing.Size(88, 24)
        Me.continueToScanButton.Text = "Continue >>"
        '
        'uploadDownLoadButton
        '
        Me.uploadDownLoadButton.Location = New System.Drawing.Point(29, 136)
        Me.uploadDownLoadButton.Size = New System.Drawing.Size(176, 24)
        Me.uploadDownLoadButton.Text = "Check Upload / Download"
        '
        'confirmLocationButton
        '
        Me.confirmLocationButton.Location = New System.Drawing.Point(105, 104)
        Me.confirmLocationButton.Size = New System.Drawing.Size(119, 24)
        Me.confirmLocationButton.Text = "Confirm Location"
        '
        'selectLocationLabel
        '
        Me.selectLocationLabel.Location = New System.Drawing.Point(34, 74)
        Me.selectLocationLabel.Size = New System.Drawing.Size(180, 26)
        Me.selectLocationLabel.Text = "Select Your Current Location Tap Confirm To Continue"
        Me.selectLocationLabel.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'cbxInitLocation
        '
        Me.cbxInitLocation.Items.Add("ATL")
        Me.cbxInitLocation.Items.Add("BOS")
        Me.cbxInitLocation.Items.Add("BTV")
        Me.cbxInitLocation.Items.Add("BUF")
        Me.cbxInitLocation.Items.Add("DEN")
        Me.cbxInitLocation.Items.Add("FLL")
        Me.cbxInitLocation.Items.Add("IAD")
        Me.cbxInitLocation.Items.Add("JFK")
        Me.cbxInitLocation.Items.Add("LAS")
        Me.cbxInitLocation.Items.Add("LGB")
        Me.cbxInitLocation.Items.Add("MCO")
        Me.cbxInitLocation.Items.Add("MSY")
        Me.cbxInitLocation.Items.Add("OAK")
        Me.cbxInitLocation.Items.Add("ONT")
        Me.cbxInitLocation.Items.Add("PBI")
        Me.cbxInitLocation.Items.Add("ROC")
        Me.cbxInitLocation.Items.Add("RSW")
        Me.cbxInitLocation.Items.Add("SAN")
        Me.cbxInitLocation.Items.Add("SEA")
        Me.cbxInitLocation.Items.Add("SJU")
        Me.cbxInitLocation.Items.Add("SLC")
        Me.cbxInitLocation.Items.Add("SYR")
        Me.cbxInitLocation.Items.Add("TPA")
        Me.cbxInitLocation.Location = New System.Drawing.Point(16, 107)
        Me.cbxInitLocation.Size = New System.Drawing.Size(80, 22)
        '
        'exitButton
        '
        Me.exitButton.Location = New System.Drawing.Point(72, 248)
        Me.exitButton.Size = New System.Drawing.Size(64, 24)
        Me.exitButton.Text = "Exit"
        '
        'initializationForm
        '
        Me.ClientSize = New System.Drawing.Size(234, 288)
        Me.ControlBox = False
        Me.Controls.Add(Me.exitButton)
        Me.Controls.Add(Me.initFormLogoPictureBox)
        Me.Controls.Add(Me.dateTimePanel)
        Me.Controls.Add(Me.continueToScanButton)
        Me.Controls.Add(Me.uploadDownLoadButton)
        Me.Controls.Add(Me.confirmLocationButton)
        Me.Controls.Add(Me.selectLocationLabel)
        Me.Controls.Add(Me.cbxInitLocation)
        Me.Text = "Scanner Initialization"

    End Sub

#End Region

    Private Sub confirmLocationButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles confirmLocationButton.Click

        Dim result As String
        Dim boolResult As Boolean

        Application.DoEvents()

        If (Not isNonNullString(cbxInitLocation.Text.Trim())) Then
            MsgBox("A valid location must be selected.")
            Return
        End If

        boolResult = TagTrakGlobals.scanLocation.update(cbxInitLocation.Text, cbxInitLocation)
        If Not boolResult Then Exit Sub

        Dim location As String = Substring(scanLocation.currentLocation, 0, 3).ToUpper

        'If airportSetClass.Instance.ContainsKey(location) Then

        '    Dim airport As locationClass = airportSetClass.Instance.Item(location)

        '    scannerTimeZone = airport.timeZone

        '    saveLastLocation(location)

        'Else

        '    MsgBox("Airport '" & location & "' not in current location set.")
        '    Stop

        'End If

        saveLastLocation(cbxInitLocation.Text.Trim())

        If Not TagTrakDataDirectory Is Nothing Then

            If Not scanLocation Is Nothing Then

                Dim currentLocation As String = scanLocation.currentLocation

                If Not currentLocation Is Nothing Then

                    Dim timeZoneFilePath As String = TagTrakDataDirectory & "\tz2.txt"

                    scannerTimeZone = Time.TimeZone.Load(timeZoneFilePath, currentLocation)

                End If

            End If

        End If

        ''Added by MX
        'tagTrakFormRepository.TagTrakLogin.Show()

        cbxInitLocation.Enabled = False
        confirmLocationButton.Enabled = False

        uploadDownLoadButton.Enabled = True
        uploadDownLoadButton.Visible = True

        Application.DoEvents()

    End Sub

    Private Sub dateTimeCorrectButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles dateTimeCorrectButton.Click

        If newApplicationVersionFound Or newConfigurationFileFound Then
            Dim newVersionDisplayForm As New newVersionNotification
            newVersionDisplayForm.ShowDialog()
            Me.DialogResult = DialogResult.Abort
            Exit Sub
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

        Application.DoEvents()

        dateAndTimeVerified()

        Application.DoEvents()

    End Sub

    Private Sub dateTimeIncorrectButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles dateTimeIncorrectButton.Click

        dateAndTimeNotVerified()

        If Time.Local.IsKnown(scannerTimeZone) Then
            dateTimeLabel.Text = String.Format("{0:yyyy-MM-dd HH:mm} local", Time.Local.GetTime(scannerTimeZone))
        Else
            dateTimeLabel.Text = "LOCAL TIME UNKNOWN"
        End If


    End Sub

    Dim ignoreUploadDownloadButtonClick As Boolean = False

    Private Sub uploadDownLoadButton_Click(ByVal sender As System.Object, ByVal e As EventArgs) Handles uploadDownLoadButton.Click

        If ignoreUploadDownloadButtonClick Then Exit Sub

        ignoreUploadDownloadButtonClick = True

        Application.DoEvents()

        '' Save last time zone used
        userSpecRecord.scanRecordSet.TimeZoneUsed.OffsetUTC = scannerTimeZone.OffsetInfo.OffsetUTC

        Dim ftpProcessDisplayForm As New ftpProcessForm

        Dim ftpDialogResult As DialogResult = ftpProcessDisplayForm.ShowDialog()

        Application.DoEvents()

        If auxInstallAvailable Then
            Dim dlg As New adminFunctionsNotificationForm
            dlg.ShowDialog()
        End If

        If ftpDialogResult = DialogResult.Abort Then
            Me.DialogResult = DialogResult.Abort
            Me.Close()
            Exit Sub
        End If

        If Time.Local.IsKnown(scannerTimeZone) Then
            dateTimeLabel.Text = String.Format("{0:yyyy-MM-dd HH:mm} local", Time.Local.GetTime(scannerTimeZone))
            dateTimeCorrectButton.Enabled = True
            dateTimeIncorrectButton.Enabled = True
        Else
            dateTimeLabel.Text = "LOCAL TIME UNKNOWN"
            dateTimeCorrectButton.Enabled = False
            dateTimeIncorrectButton.Enabled = True
        End If

        cbxInitLocation.Enabled = False
        confirmLocationButton.Enabled = False
        selectLocationLabel.Enabled = False

        verifyDateTimeLabel.Enabled = True
        dateTimeLabel.Enabled = True

        dateTimePanel.Visible = True
        dateTimePanel.Enabled = True

        uploadDownLoadButton.Enabled = False

        ignoreUploadDownloadButtonClick = False

        Exit Sub

    End Sub

    Private Function processLocationChangePassword() As String

        If Not isNonNullString(lastLocation) Then Return "OK"

        Util.verify(Length(lastLocation) >= 3, 3)

        lastLocation = Substring(lastLocation, 0, 3)

        If Not userSpecRecord.passwordRequiredForLocationChangeOnScanForm Then
            Return "OK"
        End If

        Dim newLocation As String = Me.cbxInitLocation.SelectedItem

        Util.verify(Length(newLocation) >= 3, 8)

        newLocation = Substring(newLocation, 0, 3).ToUpper

        If newLocation = lastLocation Then ' this can happen because of suffixes on locations
            Return "OK"
        End If

        Select Case lastLocation

            Case "TPA"

                If newLocation = "PIE" Then
                    Return "OK"
                End If

            Case "PIE"

                If newLocation = "TPA" Then
                    Return "OK"
                End If

            Case "SFO"

                If newLocation = "SMF" Then
                    Return "OK"
                End If

            Case "SMF"

                If newLocation = "SFO" Then
                    Return "OK"
                End If

        End Select

        Dim changeLocationPasswordDialog As New changeLocationInputBox

        Dim result As DialogResult = changeLocationPasswordDialog.ShowDialog

        If result = DialogResult.Cancel Then
            Return "Invalid password"
        End If

        Return "OK"

    End Function

    'Public Function locationConfirmed() As String

    '    Dim result As String

    '    Dim locationIndex As Integer
    '    Dim newLocation As String

    '    'With activeReaderForm

    '    locationIndex = cbxInitLocation.SelectedIndex

    '    If locationIndex <= 0 Then
    '        MsgBox("A Valid Location Must Be Selected", MsgBoxStyle.Exclamation, "Select A Valid Location")
    '        Return "Invalid location selected"
    '    End If

    '    newLocation = Trim(cbxInitLocation.Text)

    '    If Not isNonNullString(newLocation) Then
    '        MsgBox("A Valid Location Must Be Selected", MsgBoxStyle.Exclamation, "Select A Valid Location")
    '        Return "Invalid location selected"
    '    End If

    '    If Length(newLocation) < 3 Then
    '        MsgBox("A Valid Location Must Be Selected", MsgBoxStyle.Exclamation, "Select A Valid Location")
    '        Return "Invalid location selected"
    '    End If

    '    result = processLocationChangePassword()
    '    If result <> "OK" Then
    '        cbxInitLocation.SelectedIndex = lastLocationIndex
    '        Return "Invalid password"
    '    End If

    '    scanLocation = newLocation

    '    cbxInitLocation.Enabled = False
    '    confirmLocationButton.Enabled = False

    '    uploadDownLoadButton.Enabled = True
    '    uploadDownLoadButton.Visible = True

    '    'End With

    '    saveLastLocation(newLocation)

    '    Return "OK"

    'End Function

    Public Sub dateAndTimeVerified()
        dateTimePanel.Enabled = False
        continueToScanButton.Enabled = True
        continueToScanButton.Visible = True
    End Sub

    Public Sub dateAndTimeNotVerified()

        If Not Time.Local.IsKnown(scannerTimeZone) Then
            '' Time is not known, allow without password.
            Dim dlg As New adminDateTimeForm
            dlg.ShowDialog()
        Else
            Dim dialogResult As DialogResult
            Dim dlg As New setDateAndTimeLoginForm
            dlg.ShowDialog()
        End If

        If Time.Local.IsKnown(scannerTimeZone) Then
            dateTimeLabel.Text = String.Format("{0:yyyy-MM-dd HH:mm} local", Time.Local.GetTime(scannerTimeZone))
            dateTimeCorrectButton.Enabled = True
            dateTimeIncorrectButton.Enabled = True
        Else
            dateTimeLabel.Text = "LOCAL TIME UNKNOWN"
            dateTimeCorrectButton.Enabled = False
            dateTimeIncorrectButton.Enabled = True
        End If

        dateTimeCorrectButton.Enabled = True

    End Sub

    Public continueToScanButtonClickEvent As Boolean = False

    Private Sub continueToScanButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles continueToScanButton.Click

        continueToScanButtonClickEvent = True

        dateAndTimeSet = True
        '' NOTE: If we didn't get the timezone information from the server and didn't get the user to enter it
        '' 0 is used with IsKnown set to False.

        Me.Close()

    End Sub

    Private Sub exitButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles exitButton.Click

        AdminFormRepository.adminLoginForm.Show()

        If Time.Local.IsKnown(scannerTimeZone) Then
            dateTimeLabel.Text = String.Format("{0:yyyy-MM-dd HH:mm} local", Time.Local.GetTime(scannerTimeZone))
        Else
            dateTimeLabel.Text = "LOCAL TIME UNKNOWN"
        End If

    End Sub

    Private Sub loadInitFormLogo()

        Dim initFormLogoPath As String

        If Not userSpecRecord Is Nothing Then

            initFormLogoPath = TagTrakConfigDirectory & "\" & userSpecRecord.userName & "initFormLogo.bmp"

            If File.Exists(initFormLogoPath) Then
                initFormLogoPictureBox.Image = New System.Drawing.Bitmap(initFormLogoPath)
                Exit Sub
            End If

        End If

        initFormLogoPath = TagTrakConfigDirectory & "\initFormLogo.bmp"

        If File.Exists(initFormLogoPath) Then
            initFormLogoPictureBox.Image = New System.Drawing.Bitmap(initFormLogoPath)
        End If

    End Sub

    Private Sub reloadInitFormLocationComboBox()

        cbxInitLocation.Items.Clear()

        cbxInitLocation.Items.Add("")

        Dim city As String

        For Each city In userSpecRecord.cityList
            cbxInitLocation.Items.Add(city)
        Next

        Dim lastLocation As String = getLastLocation()

        If cbxInitLocation.Items.Contains(lastLocation) Then
            cbxInitLocation.SelectedItem = lastLocation
        Else
            cbxInitLocation.SelectedItem = userSpecRecord.defaultLocation
        End If

    End Sub
End Class
