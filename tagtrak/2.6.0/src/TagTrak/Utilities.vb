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
Imports System.Math
Imports Microsoft.VisualBasic
Imports OpenNETCF
Imports OpenNETCF.Win32


Class Util

    Public Shared Function senseIPAddress() As String

        'You should be able to use GetSetting() and open the registry setting for
        '80211 in:

        '[HKEY_LOCAL_MACHINE\Comm\NETWLAN1\Parms\TcpIP] IPAddress
        'Dim x As String = getsettings("ab", "c", "d")


    End Function

    Public Shared Function getWeightInExcessOf100Pounds() As Integer

        MailScanFormRepository.MailScanGetWeightForm.Show()

        If MailScanFormRepository.MailScanGetWeightForm.DialogResult <> DialogResult.OK Then Return -1

        Return MailScanFormRepository.MailScanGetWeightForm.weight

    End Function

    Public Shared Function convertByteBufferToString(ByRef byteBuffer() As Byte, ByVal startByteNumber As Integer, ByVal byteCount As Integer) As String

#If ValidationLevel >= 3 Then

        if diagnosticLevel >= 2 then

            verify(Not byteBuffer Is Nothing, 27000)
            verify(startByteNumber >= 0, 27001)
            verify(byteCount >= 0, 27002)
            verify(startByteNumber + byteCount <= byteBuffer.Length, 27003)

        End If

#End If

        Dim i, ilmt As Integer

        Dim returnString As String = ""

        ilmt = startByteNumber + byteCount - 1

        For i = startByteNumber To ilmt
            returnString &= Chr(byteBuffer(i))
        Next

        Return returnString

    End Function

    Public Shared Function convertStringArrayToStringBuffer(ByRef stringArray() As String) As String

        If stringArray Is Nothing Then Return ""

        Dim returnString As String = ""

        Dim nextString As String

        For Each nextString In stringArray
            returnString &= nextString & Chr(13) & Chr(10)
        Next

        Return returnString

    End Function

    Public Shared Function formatFixedField(ByRef inputString As String, ByVal fieldWidth As Integer) As String

#If ValidationLevel >= 3 Then

        If diagnosticLevel >= 2 Then
            verify(Not inputString Is Nothing, 27010)
        End If

#End If

        If fieldWidth <= 0 Then Return ""

        If inputString Is Nothing Then
            Stop
            Return ""
        End If

        Dim returnString As String

        Dim stringLength As Integer

        stringLength = Len(inputString)

        If stringLength > fieldWidth Then
            Return Substring(inputString, 0, fieldWidth)
        End If

        If stringLength < fieldWidth Then
            Return inputString.PadRight(fieldWidth)
        End If

        Return inputString

    End Function

    Public Shared Function createFixedWidthField(ByRef inputString As String, ByVal fieldWidth As Integer, ByVal padChar As Char) As String

#If ValidationLevel >= 3 Then

	if diagnosticLevel >= 2 then
            verify(not inputString is nothing, 27020)
        End If

#End If


        Dim returnString As String
        Dim padRight As Boolean

        If fieldWidth < 0 Then
            padRight = False
            fieldWidth = -fieldWidth
        Else
            padRight = True
        End If

        If inputString Is Nothing Then
            returnString = ""
            returnString = returnString.PadRight(fieldWidth, padChar)
            Return returnString
        End If

        If Length(inputString) <= 0 Then
            returnString = ""
            returnString = returnString.PadRight(fieldWidth, padChar)
            Return returnString
        End If

        If Length(inputString) = fieldWidth Then Return inputString

        If Length(inputString) < fieldWidth Then
            If padRight Then
                returnString = inputString.PadRight(fieldWidth, padChar)
            Else
                returnString = inputString.PadLeft(fieldWidth, padChar)
            End If

            Return returnString
        End If

        Return Substring(inputString, 0, fieldWidth)

    End Function


    Public Shared Sub configError(ByRef errorDescription As String)

#If ValidationLevel >= 3 Then

	if diagnosticLevel >= 2 then
            verify(not errorDescription is nothing, 27030)
        End If

#End If

        Application.DoEvents()
        MsgBox(errorDescription)
        Application.DoEvents()

    End Sub

    Public Shared Sub systemError(ByRef errorDescription As String)

#If ValidationLevel >= 3 Then

	if diagnosticLevel >= 2 then
            verify(not errorDescription is nothing, 27040)
        End If

#End If

        Application.DoEvents()
        MsgBox("System Error: " & errorDescription, MsgBoxStyle.Exclamation, "System Error")
        Application.DoEvents()
        Stop

    End Sub

    Public Shared Sub warning(ByRef warningMessage As String, ByVal style As MsgBoxStyle, ByRef titleString As String)

#If ValidationLevel >= 3 Then

        If diagnosticLevel >= 2 Then
            verify(Not warningMessage Is Nothing, 27050)
            verify(Not titleString Is Nothing, 27051)
        End If

#End If

        Application.DoEvents()
        MsgBox(warningMessage, style, titleString)
        Application.DoEvents()

    End Sub

    Public Shared Sub verify(ByVal x As Boolean)

        If Not x Then
            Application.DoEvents()
            MsgBox("Verify fails.")
            Application.DoEvents()
            Stop
        End If

    End Sub

    Public Shared Sub verify(ByVal x As Boolean, ByVal locCode As Integer)

        If Not x Then
            Application.DoEvents()
            MsgBox("Verify fails at point" & locCode & ".")
            Application.DoEvents()
            Stop
        End If

    End Sub

    Public Shared Sub scanSequenceVerify(ByVal x As Boolean, ByVal locCode As Integer)

        If Not x Then
            Application.DoEvents()
            MsgBox("Verify fails.")
            Application.DoEvents()
            Stop
        End If

    End Sub

    Public Shared Function isAlphaNumeric(ByVal x As String) As Boolean

        Dim c As Char

        For Each c In x
            If Not Char.IsLetterOrDigit(c) Then Return False
        Next

        Return True

    End Function

    Public Shared Function isValidManifestID(ByVal manifestID As String) As Boolean

        If manifestID Is Nothing Then Return False

        manifestID = Trim(manifestID)

        If Not isNonNullString(manifestID) Then Return False

        If Length(manifestID) <> 10 Then Return False

        Dim i As Integer

        For i = 0 To 9

            If Not Char.IsLetterOrDigit(manifestID.Chars(i)) Then Return False

        Next

        Return True

    End Function

    Public Shared Function isValidFlightNumber(ByVal inputFlightNumber As String) As Boolean

        If inputFlightNumber Is Nothing Then Return False

        Dim flightNumber As String = Trim(inputFlightNumber)

        If Not isNonNullString(flightNumber) Then Return False

        If Length(flightNumber) > 4 Then Return False

        Dim c As Char

        For Each c In flightNumber
            If Not Char.IsDigit(c) Then Return False
        Next

        Return True

    End Function

    Public Shared Function isValidTailNumber(ByRef tailNumber As String) As Boolean

        If Not isNonNullString(tailNumber) Then Return False

        If Length(tailNumber) > 5 Then Return False

        Dim c As Char

        For Each c In tailNumber
            If Not Char.IsLetterOrDigit(c) Then Return False
        Next

        Return True

    End Function

    Public Shared Function isValidLocationCode(ByRef locationCode As String) As Boolean

        If Not isNonNullString(locationCode) Then Return False

        If Length(locationCode) <> 3 Then Return False

        Return True

    End Function

    Public Shared Function isValidBatchID(ByRef batchID As String) As Boolean

        If Not isNonNullString(batchID) Then Return False

        If Length(batchID) > 10 Then Return False

        Return True

    End Function

    Public Shared Function isValidACBinID(ByRef ACBinID As String) As Boolean

        If Not isNonNullString(ACBinID) Then Return False

        If Length(ACBinID) > 6 Then Return False

        If Not isAlphaNumeric(ACBinID) Then Return False

        Return True

    End Function

    Public Shared Function isValidCargoContainer(ByVal cargoContainer As String) As Boolean

        If Not isNonNullString(cargoContainer) Then Return False

        If Length(cargoContainer) > 10 Then Return False

        If Not isAlphaNumeric(cargoContainer) Then Return False

        Return True

    End Function

    Public Shared Function isValidBaggageContainerPosition(ByVal baggageContainerPosition As String) As Boolean

        If Not isNonNullString(baggageContainerPosition) Then Return False

        If Length(baggageContainerPosition) > 10 Then Return False

        If Not isAlphaNumeric(baggageContainerPosition) Then Return False

        Return True

    End Function

    Public Shared Function isValidBaggageHoldPosition(ByVal baggageHoldPosition As String) As Boolean

        If Not isNonNullString(baggageHoldPosition) Then Return False

        If Length(baggageHoldPosition) > 6 Then Return False

        If Not isAlphaNumeric(baggageHoldPosition) Then Return False

        Return True

    End Function

    Public Shared Function isValidCarrierCode(ByVal inputCarrierCode As String) As Boolean

        If Not isNonNullString(inputCarrierCode) Then Return False

        Dim testCarrierCode As String = Trim(inputCarrierCode)

        If Length(testCarrierCode) <> 2 Then Return False

        If Not Char.IsLetterOrDigit(testCarrierCode.Chars(0)) Then Return False
        If Not Char.IsLetterOrDigit(testCarrierCode.Chars(1)) Then Return False

        Return True

    End Function

    Public Shared Function IsInteger(ByRef inputString As String) As Boolean

        If Not isNonNullString(inputString) Then Return False

        Dim c As Char

        Dim x As String = Trim(inputString)

        If Length(x) <= 0 Then Return False

        For Each c In x
            If Not Char.IsDigit(c) Then Return False
        Next

        Return True

    End Function

    Public Shared Function isValidDandRTag(ByRef inputDandRTagString As String) As Boolean
        If Not isNonNullString(inputDandRTagString) Then Return False
        Dim DandRTagString As String = Trim(inputDandRTagString)
        If Length(DandRTagString) <> 10 Then Return False

        DandRTagString = DandRTagString.ToUpper

        Dim i As Integer
        Dim c As Char
        For i = 0 To 2
            If Not Char.IsLetterOrDigit(DandRTagString.Chars(i)) Then Return False
        Next

        ' MDD
        Return True

        'If emulatingPlatform Or device = "PC" Then Return True
        'c = DandRTagString.Chars(3)

        'If Not (c = "F"c Or c = "P"c Or c = "E"c Or c = "R"c) Then Return False

        'For i = 4 To 7
        '    If Not Char.IsLetterOrDigit(DandRTagString.Chars(i)) Then Return False
        'Next

        'Const specialCharSet As String = "-$/+%."

        'For i = 8 To 9
        '    c = DandRTagString.Chars(i)
        '    If Not (Char.IsLetterOrDigit(c) Or specialCharSet.IndexOf(c)) Then Return False
        'Next

        'Return True

    End Function

    '' Validates weight
    '' COULD be "US" or
    '' MUST be <=5 characters long
    '' MUST be an integer
    '' MUST be <= 65536
    Public Shared Function isValidWeight(ByRef inputWeightString As String) As Boolean
        If Not isNonNullString(inputWeightString) Then Return False
        Dim weightString As String = Trim(inputWeightString)
        If weightString.ToUpper = "US" Then Return True
        If Length(weightString) > 5 Then Return False
        If Not IsInteger(weightString) Then Return False
        If CInt(weightString) > 65536 Then Return False

        Return True

    End Function

    Public Shared Function isValidRoutingCode(ByVal routingCode As String) As Boolean

        If Length(routingCode) <> 4 Then Return False

        Dim c As Char

        For Each c In routingCode
            If Not Char.IsLetterOrDigit(c) Then Return False
        Next

        Return True

    End Function

    Public Shared Function isValidLocation(ByRef inputLocationString As String) As Boolean

        If Not isNonNullString(inputLocationString) Then Return False

        Dim LocationString As String = Trim(inputLocationString)

        If Length(LocationString) <> 3 Then Return False

        Return True

    End Function

    Public Shared Function isValidCarrier(ByRef inputCarrierString As String) As Boolean

        If Not isNonNullString(inputCarrierString) Then Return False

        Dim LocationString As String = Trim(inputCarrierString)

        If Length(LocationString) <> 2 Then Return False

        Return True

    End Function

    'Public Shared Function validateCity(ByVal city As String) As Boolean

    '    If Not airportSetClass.Instance.ContainsKey(city) Then
    '        MsgBox("City " & city & " is not in the current city list.")
    '        Stop
    '    End If

    '    Dim cityRecord As locationClass = airportSetClass.Instance.Item(city)

    '    Dim timeZone As TimeZoneRecordClass = cityRecord.timeZone

    '    If timeZone Is Nothing Then
    '        MsgBox("City " & city & " does not have a time zone")
    '    End If

    '    Dim timeZoneDSTProtocolName As DSTChangeDateProtocolClass.DSTChangeDatesProtocolType = timeZone.DSTChangeDatesProtocolType

    '    If timeZoneDSTProtocolName = DSTChangeDateProtocolClass.DSTChangeDatesProtocolType.NoChange Then
    '        Return True
    '    End If

    '    If timeZoneDSTProtocolName = DSTChangeDateProtocolClass.DSTChangeDatesProtocolType.Unknown Then
    '        MsgBox("Unknown time zone date change protocol for city " & city)
    '        Stop
    '    End If

    '    If Not DSTChangeDatesSet.ContainsKey(timeZoneDSTProtocolName) Then
    '        MsgBox("Time zone date change protocol for city " & city & " not in set")
    '        Stop
    '    End If

    '    Return True

    'End Function

    'Public Shared Function validateUserAirportSet() As Boolean

    '    Dim city As String

    '    For Each city In userSpecRecord.cityList
    '        If Not validateCity(city) Then Return False
    '    Next

    'End Function

    Public Shared Function isTextCharacter(ByVal inputChar As Byte) As Boolean

        If inputChar = 13 Then Return True
        If inputChar = 10 Then Return True
        If inputChar = 9 Then Return True

        If inputChar >= 32 And inputChar <= 126 Then Return True

        Return False

    End Function

    Public Shared Function getTrimmedBufferLength(ByVal inputBuffer() As Byte, ByVal recordSize As Integer) As Integer

#If ValidationLevel >= 3 Then

        If diagnosticLevel >= 2 Then

            verify(Not inputBuffer Is Nothing)
            verify(recordSize >= 0 And recordSize <= inputBuffer.Length)

        End If
#End If

        Dim i As Integer = recordSize - 1

        While (i >= 0)

            Dim nextChar As Char = Chr(inputBuffer(i))

            If Not Char.IsWhiteSpace(nextChar) Then
                Return i + 1
            End If

            i -= 1

        End While

        Return 0

    End Function

    Public Shared Sub LoadComboBoxFromList(ByRef destComboBox As ComboBox, ByRef sourceArray As ArrayList)

#If ValidationLevel >= 3 Then

        If diagnosticLevel >= 2 Then
            verify(Not sourceArray Is Nothing)
        End If

#End If

        destComboBox.Items.Clear()

        Dim item As String

        For Each item In sourceArray
            destComboBox.Items.Add(item)
        Next

    End Sub

    Public Shared Sub updateGlobalScanCount()

        If globalScanCount >= 99999 Then
            globalScanCount = 1
        Else
            globalScanCount += 1
        End If

    End Sub

    Public Shared Sub loadComboBoxFromStringArray(ByRef inputComboBox As ComboBox, ByRef inputArray() As String)

#If ValidationLevel >= 3 Then

        If diagnosticLevel >= 2 Then
            verify(Not inputArray Is Nothing)
        End If

#End If

        inputComboBox.Items.Clear()

        Dim itemString As String

        For Each itemString In inputArray
            inputComboBox.Items.Add(itemString)
        Next

    End Sub


    Public Shared Function getIntegerFromByteBuffer(ByRef byteBuffer() As Byte, ByVal offset As Integer) As Int32

#If ValidationLevel >= 3 Then

        If diagnosticLevel >= 2 Then
            verify(Not byteBuffer Is Nothing)
            verify(offset >= 0 And offset < byteBuffer.Length)
        End If

#End If

        Dim result As Int32 = 0

        Dim byte1 As Byte = byteBuffer(offset)

        Dim byte2 As Byte = byteBuffer(offset + 1)

        Dim byte3 As Byte = byteBuffer(offset + 2)

        Dim byte4 As Byte = byteBuffer(offset + 3)

        result = ((byte4 * 256 + byte3) * 256 + byte2) * 256 + byte1

        Return result

    End Function

    Public Shared Sub turnScannerOff(ByVal locCode As Integer)
#If deviceType <> "PC" Then

        If emulatingPlatform Then Exit Sub

#If deviceType = "ViewSonic" Then
        Exit Sub
#End If

        'Modified by MX
        '#If deviceType = "Intermec" Then
        '        If scanReader Is Nothing Then Exit Sub
        '#ElseIf deviceType = "Symbol" Then
        '        If symbolReader.MyReader Is Nothing Then Exit Sub
        '#End If

        If scanReader Is Nothing Then Exit Sub

        logScanStateChange(locCode * 1000 + 1, False)

        '#If deviceType = "Intermec" Then
        '        scanReader.disable()
        '#End If

        '#If deviceType = "Symbol" Then
        '        symbolReader.disable()
        '#End If

        scanReader.disable()
#End If

    End Sub

    Public Shared Sub turnScannerOn(ByVal locCode As Integer)

#If deviceType <> "PC" Then

        If emulatingPlatform Then Exit Sub

#If deviceType = "ViewSonic" Then
        Exit Sub
#End If

        '#If deviceType = "Intermec" Then
        '        If scanReader Is Nothing Then Exit Sub
        '#ElseIf deviceType = "Symbol" Then
        '        If symbolReader.MyReader Is Nothing Then Exit Sub
        '#End If

        If scanReader Is Nothing Then Exit Sub

        logScanStateChange(locCode * 1000 + 2, True)

        '#If deviceType = "Intermec" Then
        '        scanReader.enable()
        '#End If

        '#If deviceType = "Symbol" Then
        '        symbolReader.enable()
        '#End If

        scanReader.enable()

#End If

    End Sub

    Public Shared Sub dx(ByVal x As Integer)
        MsgBox("At point " & x)
    End Sub

    Public Shared Function stringCompare(ByVal string1 As String, ByVal string2 As String) As Integer

        If string1 Is Nothing Then string1 = ""
        If string2 Is Nothing Then string2 = ""

        Dim result As Integer = String.Compare(string1, string2)

        Return result

    End Function

    Public Shared programLoadProgressBarIncrementCount As Double = 0.0
    Public Shared programLoadProgressBarIncrementMax As Double = 9.0

    Public Shared Sub incrementProgramLoadProgressBar()

        Dim programLoadProgressBarValue As Integer

        programLoadProgressBarIncrementCount += 1.0

        programLoadProgressBarValue = Math.Floor((100.0 * programLoadProgressBarIncrementCount / programLoadProgressBarIncrementMax) + 0.5)

        If programLoadProgressBarValue > 100 Then programLoadProgressBarValue = 100

        programLoadProgressBar.Value = programLoadProgressBarValue

    End Sub

    Public Shared Function getUserNumber() As Integer

        If userNumberTable.ContainsKey(user) Then Return userNumberTable(user)

        Return -1

    End Function

    Public Shared Function getIPAddress() As String
        Try
            Dim HostName As String = System.Net.Dns.GetHostName()
            Dim thisHost As System.Net.IPHostEntry = System.Net.Dns.GetHostByName(HostName)
            Dim thisIpAddr As String = thisHost.AddressList(0).ToString
            Return thisIpAddr
        Catch ex As Exception
            Return "0.0.0.0"
        End Try
    End Function

    Public Shared Function IsDouble(ByRef inputString As String) As Boolean

        If Not isNonNullString(inputString) Then Return False
        Try
            System.Double.Parse(inputString)
            Return True
        Catch ex As Exception
            Return False
        End Try

    End Function

    Public Shared Function parseBase62Char(ByVal inputChar As Char) As Integer

        If (inputChar >= "a"c And inputChar <= "z"c) Then
            Return Asc(inputChar) - Asc("a"c)
        End If

        If (inputChar >= "A"c And inputChar <= "Z"c) Then
            Return Asc(inputChar) - Asc("A"c) + 26
        End If

        If (inputChar >= "0"c And inputChar <= "9"c) Then
            Return Asc(inputChar) - Asc("0"c) + 52
        End If

        Throw New Exception("Invalid base 62 digit provided to parseBase62Char")

    End Function

End Class
