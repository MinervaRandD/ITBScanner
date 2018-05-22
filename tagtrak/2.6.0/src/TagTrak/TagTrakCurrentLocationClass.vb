Public Class TagTrakCurrentLocationClass

    Public ignoreLocationChange As Boolean = True

    Public locationComboBoxes As New ArrayList
    Public locationLabels As New ArrayList

    Private strCurrentLocation As String = ""
    Private strPreviousLocation As String = ""

    Public Sub addControl(ByVal newComboBox As ComboBox)

        Dim comboBox As ComboBox

        For Each comboBox In locationComboBoxes
            If comboBox Is newComboBox Then Return
        Next

        locationComboBoxes.Add(newComboBox)

    End Sub

    Public Sub addControl(ByVal newLabel As Label)

        Dim label As Label

        For Each label In locationLabels
            If label Is newLabel Then Return
        Next

        locationLabels.Add(newLabel)

    End Sub

    Public Property currentLocation() As String

        Get
            Return strCurrentLocation
        End Get

        Set(ByVal Value As String)
            update(Value)
        End Set

    End Property

  

    Private Function setNewLocation(ByVal strNewLocation As String) As Boolean

        'Dim airport As locationClass = airportSetClass.Instance.Item(Substring(strNewLocation, 0, 3).ToUpper)

        'If airport Is Nothing Then
        '    MsgBox("Airport '" & strCurrentLocation & "' is not in the current location set.")
        '    Return False
        'End If

        'scannerTimeZone = airport.timeZone

        'Note that the routine 'loadTimeZoneOffsetInfo' effectively does the same thing as the the previous statement -- it sets
        'the scannerTimeZone -- assuming the time zone file exists and has a value for the new location. The previous statement
        'is retained as a means of setting a default value for the time zone given that the routine loadTimeZoneOffsetInfo may fail.

        Dim timeZoneFilePath As String = TagTrakDataDirectory & "\tz2.txt"

        scannerTimeZone = Time.TimeZone.Load(timeZoneFilePath, strNewLocation)


        '' If we have a current location and we are switching to a new location then
        Dim oldLoc As String
        If strCurrentLocation = "" Then
            oldLoc = getLastLocation()
        Else
            oldLoc = strCurrentLocation
        End If

        If strNewLocation <> oldLoc Then
            '' New location resets some data

            '' Reset flight schedules
            deleteLocalFile(TagTrakDataDirectory & "\FlightScheduleExt.txt.gz")
            deleteLocalFile(TagTrakDataDirectory & "\FlightScheduleExt.txt")
            deleteLocalFile(TagTrakConfigDirectory & "\FlightScheduleExtDateStamp.txt")

            flightScheduleSet = New Data.FlightSchedule.Flights(False)
            newFlightScheduleFileFound = False

            '' Reset Flight Load Info
            deleteLocalFile(TagTrakDataDirectory & "\FlightLoadInfo.txt.gz")
            deleteLocalFile(TagTrakDataDirectory & "\FlightLoadInfo.txt")
            deleteLocalFile(TagTrakConfigDirectory & "\FlightLoadInfoDateStamp.txt")

            flightLoadInfo = New Data.FlightLoadInfo.Info
            newFlightLoadInfoFound = False

        End If

        strPreviousLocation = strCurrentLocation
        strCurrentLocation = strNewLocation

        'Added by MX
        saveLastLocation(strNewLocation)
        Return True

    End Function

    Public Function processLocationChange(ByVal strNewLocation As String) As Boolean

        strNewLocation = strNewLocation.Trim().ToUpper()

        If strNewLocation = strCurrentLocation Then Return True

        If Not isNonNullString(Trim(strNewLocation)) Then
            MsgBox("Please select a valid location.", MsgBoxStyle.Exclamation, "Select Valid Location")
        End If

        If Not isNonNullString(strCurrentLocation) Then
            Return setNewLocation(strNewLocation)
        End If

        If Not userSpecRecord.passwordRequiredForLocationChangeOnScanForm Then
            Return setNewLocation(strNewLocation)
        End If

        Select Case strCurrentLocation

            Case "TPA"

                If strNewLocation = "PIE" Then
                    Return setNewLocation(strNewLocation)
                End If

            Case "PIE"

                If strNewLocation = "TPA" Then
                    Return setNewLocation(strNewLocation)
                End If

            Case "SFO"

                If strNewLocation = "SMF" Then
                    Return setNewLocation(strNewLocation)
                End If

            Case "SMF"

                If strNewLocation = "SFO" Then
                    Return setNewLocation(strNewLocation)
                End If

        End Select

        Dim changeLocationPasswordDialog As New changeLocationInputBox

        Dim result As DialogResult = changeLocationPasswordDialog.ShowDialog

        If result = DialogResult.Cancel Then

            Return False

        End If

        Return setNewLocation(strNewLocation)

    End Function

    Public Sub setComboBoxValue(ByRef comboBox As ComboBox, ByVal strComboBoxValue As String)

        ' in early versions of .Net CF combobox combobox.selecteditem = did not
        ' work properly. This may have changed.

        Dim i, ilmt As Integer

        ilmt = comboBox.Items.Count - 1

        If ilmt < 0 Then Exit Sub

        For i = 0 To ilmt

            If comboBox.Items.Item(i) = strComboBoxValue Then
                comboBox.SelectedIndex = i
                Exit Sub
            End If

        Next
    End Sub

    Public Function processUpdate(ByVal strNewLocation As String, ByVal locationComboBox As System.Windows.Forms.ComboBox) As Boolean

        Dim returnValue As Boolean

        returnValue = processLocationChange(strNewLocation)

        If returnValue = False Then
            setComboBoxValue(locationComboBox, strCurrentLocation)
            Return False
        End If

        Dim comboBox As ComboBox

        For Each comboBox In Me.locationComboBoxes

            If Not comboBox Is locationComboBox Then
                setComboBoxValue(comboBox, strCurrentLocation)
            End If

        Next

        Dim label As Label

        For Each label In Me.locationLabels

            label.Text = strNewLocation

        Next

        Return True

    End Function

    Public Function processUpdate(ByVal strNewLocation As String, ByVal locationLabel As System.Windows.Forms.Label) As Boolean

        Dim returnValue As Boolean

        returnValue = processLocationChange(strNewLocation)

        If returnValue = False Then
            locationLabel.Text = strCurrentLocation
            Return False
        End If

        Dim comboBox As ComboBox

        For Each comboBox In Me.locationComboBoxes
            setComboBoxValue(comboBox, strCurrentLocation)
        Next

        Dim label As Label

        For Each label In Me.locationLabels

            label.Text = strNewLocation

        Next

        Return True

    End Function

    Private Function processUpdate(ByVal strNewLocation As String) As Boolean

        Dim returnValue As Boolean

        returnValue = processLocationChange(strNewLocation)

        strCurrentLocation = strNewLocation

        Dim comboBox As ComboBox

        For Each comboBox In Me.locationComboBoxes
            setComboBoxValue(comboBox, strCurrentLocation)
        Next

        Dim label As Label

        For Each label In Me.locationLabels

            label.Text = strNewLocation

        Next

        Return True

    End Function

    Dim withinUpdate As Boolean = False

    Public Function update(ByVal strNewLocation As String, ByVal locationComboBox As System.Windows.Forms.ComboBox) As Boolean

        Dim returnValue As Boolean

        If withinUpdate Then Return False

        withinUpdate = True

        ignoreLocationChange = True

        returnValue = processUpdate(strNewLocation, locationComboBox)

        ignoreLocationChange = False

        withinUpdate = False

        Return returnValue

    End Function

    Public Function update(ByVal strNewLocation As String, ByVal locationLabel As System.Windows.Forms.Label) As Boolean

        Dim returnValue As Boolean

        If withinUpdate Then Return False

        withinUpdate = True

        ignoreLocationChange = True

        returnValue = processUpdate(strNewLocation, locationLabel)

        ignoreLocationChange = False

        withinUpdate = False

        Return returnValue

    End Function

    Public Function update(ByVal strNewLocation As String) As Boolean

        Dim returnValue As Boolean

        If withinUpdate Then Return False

        withinUpdate = True

        ignoreLocationChange = True

        returnValue = processUpdate(strNewLocation)

        ignoreLocationChange = False

        withinUpdate = False

        Return returnValue

    End Function

End Class
