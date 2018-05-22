Imports System
Imports System.io
Imports System.Xml

Public Class userSpecRecordClass

    Public userName As String
    Public userFullName As String
    Public carrierCode As String

    Public defaultLocation As String

    Public ftpHostName As String
    Public ftpPortNumber As Integer
    Public ftpLoginID As String
    Public ftpPassword As String

    'Added by MX
    Public ftpSecureConnection As Boolean = False
    Public screenTimeOutValue As Integer = -1
    Public screenBlankAfterSend As Boolean = True
    Public ftpAuthorization As Boolean = False
    Public FirstReminderInterval As Integer = 0
    Public SecondReminderInterval As Integer = 0
    Public sendRerouteHeader As Boolean = False
    Public myConfigVersion As String
    Public autoMailSwitch As Boolean = False
    Public continuousMailScan As Boolean = False
    Public differentDestinationWarning As Boolean = False
    Public deliveryDestinationCheck As Boolean = False
    Public nonUSMailWarning As Boolean = False
    Public loginEnabled As Boolean = False
    Public logoutTimeOutValue As Integer = 120

    Public transferPointOnScanForm As Boolean
    Public passwordRequiredForLocationChangeOnScanForm As Boolean
    Public treatTransferScansAsLoadScans As Boolean
    Public loadScansRequireSelectionFromPreset As Boolean
    Public presetsRequireDestinationSpecifications As Boolean
    Public lockDownReleasedInAdminForm As Boolean
    Public warnOnDuplicateScan As Boolean
    Public displayFlightValidationMessages As Boolean
    Public triStateLargeBarcodeCheckBox As Boolean

    Public mailScanEnabled As Boolean = True
    Public mailSimpleScanEnabled As Boolean = True
    Public messagesEnabled As Boolean = True

    Public cargoScanEnabled As Boolean = False
    Public baggageScanEnabled As Boolean = False
    Public internationalMailEnabled As Boolean = False
    Public internationalSimpleMailEnabled As Boolean = False
    Public intlCartIDRequired As Boolean = False

    Public CanExitProgram As Boolean = False

    Public cityTable As New Hashtable

    Public cityList As New ArrayList
    Public embargoCityTable As New Hashtable

    Public operationsMapping As New OperationsMapClass

    Public operationsTable As New Hashtable
    Public operationsList As New ArrayList

    Public internationalOperationsTable As New Hashtable
    Public internationalOperationsList As New ArrayList
    Public intlSimpleOperationsList As New ArrayList

    Public AdjunctCarrierList As New ArrayList
    Public AdjunctCarrierTable As New Hashtable

    Public cargoOperationsList As New ArrayList
    Public cargoOperationsTable As New Hashtable

    Public cityListString As String
    Public embargoCityListString As String

    Public operationListString As String
    Public internationalOperationListString As String
    Public adjunctCarrierListString As String
    Public cargoOperationsListString As String

    Dim userSpecRecordXMLDocument As New XmlDocument

    Dim trimChars() As Char = {" "c, Chr(9), Chr(10), Chr(11), Chr(12), Chr(13), vbNullChar}

    Public scanRecordSet As ScanRecordSetClass

    Public presetList As New ArrayList

    Public uploadSequenceNumber As Integer

    Public beepOnScan As Boolean = True
    Public buzzOnScan As Boolean = True
    Public buzzLength As Integer = 0

    Public showKeyboardOnFocus As Boolean = True

    Public DisplayInternationalPostOffices As Boolean = False
    Public IntlPostOfficeList As New ArrayList
    Public DefaultIntlPostOffice As String = "US"

    Public UseFtpProxy As Boolean = False
    Public ProxyHost As String = ""
    Public ProxyPort As Integer = 21
    Public ProxyUser As String = ""
    Public ProxyPassword As String = ""
    Public ProxyType As String = ""

    Public IntlPromptCardit As Boolean = True

    Public UnloadEntireCart As Boolean = False
    Public UnloadEntireFlight As Boolean = False

    Public IntlCartIdPattern As String = ""
    Public MailCartIdPattern As String = ""

    Public CarditRouteCityList As New ArrayList
    Public CarditRouteCarrierList As New ArrayList

    Public NTPServers As New ArrayList

    Public Sub reset()

        userName = ""
        userFullName = ""
        carrierCode = ""

        ftpHostName = ""
        ftpPortNumber = -1
        ftpLoginID = ""
        ftpPassword = ""
        ftpSecureConnection = False

        screenTimeOutValue = -1
        transferPointOnScanForm = False
        passwordRequiredForLocationChangeOnScanForm = False
        treatTransferScansAsLoadScans = False
        loadScansRequireSelectionFromPreset = False
        presetsRequireDestinationSpecifications = False
        lockDownReleasedInAdminForm = False
        warnOnDuplicateScan = False
        displayFlightValidationMessages = True
        triStateLargeBarcodeCheckBox = False

        mailScanEnabled = True
        mailSimpleScanEnabled = True
        messagesEnabled = True

        cargoScanEnabled = False
        baggageScanEnabled = False
        internationalMailEnabled = False
        internationalSimpleMailEnabled = False
        intlCartIDRequired = False

        cityTable.Clear()
        cityList.Clear()
        embargoCityTable.Clear()
        operationsTable.Clear()
        internationalOperationsTable.Clear()

        AdjunctCarrierTable.Clear()
        AdjunctCarrierList.Clear()

        cargoOperationsTable.Clear()
        cargoOperationsList.Clear()

        IntlPromptCardit = True
        IntlCartIdPattern = ""
        MailCartIdPattern = ""

        NTPServers = New ArrayList
        operationsMapping = New OperationsMapClass

        UseFtpProxy = False
        ProxyHost = ""
        ProxyPort = 21
        ProxyUser = ""
        ProxyPassword = ""
        ProxyType = ""
    End Sub

    Public Function isValid() As Object

        If Not isNonNullString(userName) Then
            Return "Invalid user name"
        End If

        If Not isNonNullString(carrierCode) Then
            Return "Invalid carrier code"
        End If

        If Length(carrierCode) <> 2 Then
            Return "Invalid carrier code"
        End If

        If Not isNonNullString(defaultLocation) Then
            Return "Invalid default location"
        End If

        If Length(defaultLocation) <> 3 Then
            Return "Invalid default location"
        End If

        If Not isNonNullString(ftpHostName) Then
            Return "Invalid ftp host name"
        End If

        If ftpPortNumber <= 0 Then
            Return "Invalid port number"
        End If

        If Not isNonNullString(ftpLoginID) Then
            Return "Invalid ftp login id"
        End If

        If Not isNonNullString(ftpPassword) Then
            Return "Invalid ftp password"
        End If

        If cityList.Count <= 0 Then
            Return "Invalid city list"
        End If

        If operationsTable Is Nothing Then
            Return "Invalid operations table"
        End If

        If internationalOperationsTable Is Nothing Then
            Return "Invalid international operations table"
        End If

        If AdjunctCarrierTable Is Nothing Then
            Return "Invalid adjunct carrier table"
        End If

        Return True

    End Function

    Private Function parseBooleanValue(ByVal tagName As String, ByRef switch As Boolean) As String

        Dim nodelist As XmlNodeList
        Dim xmlText As String

        nodelist = userSpecRecordXMLDocument.GetElementsByTagName(tagName)

        If nodelist.Count > 1 Then
            Return "Corrupt XML User Specification: invalid number of '" & tagName & "' nodes."
        End If

        If nodelist.Count = 1 Then

            xmlText = Trim(nodelist(0).InnerText)
            xmlText = xmlText.ToUpper

            If xmlText = "TRUE" Then
                switch = True
            ElseIf xmlText = "T" Then
                switch = True
            ElseIf xmlText = "FALSE" Then
                switch = False
            ElseIf xmlText = "F" Then
                switch = False
            Else
                Return "Parse of '" & tagName & "' failed: invalid boolean value."
            End If

        End If

        Return "OK"

    End Function

    Private Function parseStringValue(ByVal tagName As String, ByRef tagValue As String) As String

        Dim nodelist As XmlNodeList
        Dim xmlText As String

        nodelist = userSpecRecordXMLDocument.GetElementsByTagName(tagName)

        If nodelist.Count > 1 Then
            Return "Corrupt XML User Specification: invalid number of '" & tagName & "' nodes."
        End If

        If nodelist.Count = 1 Then
            xmlText = Trim(nodelist(0).InnerText)
            If isNonNullString(xmlText) Then
                tagValue = xmlText
            End If
        End If

        Return "OK"

    End Function

    Private Function parseIntegerValue(ByVal tagName As String, ByRef returnValue As Integer) As String

        Dim nodelist As XmlNodeList
        Dim xmlText As String

        nodelist = userSpecRecordXMLDocument.GetElementsByTagName(tagName)

        If nodelist.Count > 1 Then
            Return "Corrupt XML User Specification: invalid number of '" & tagName & "' nodes."
        End If

        If nodelist.Count = 1 Then

            xmlText = Trim(nodelist(0).InnerText)

            Try
                returnValue = CInt(xmlText)
            Catch ex As Exception
                Return "Invalid Integral Value"
            End Try

        End If

        Return "OK"

    End Function

    Private Function parseCarrierCode() As String

        Dim nodelist As XmlNodeList

        nodelist = userSpecRecordXMLDocument.GetElementsByTagName("CarrierCode")

        If nodelist.Count > 1 Then
            Return "Corrupt XML User Specification: invalid number of carrier code nodes."
        End If

        If nodelist.Count = 1 Then

            carrierCode = Trim(nodelist(0).InnerText)

            If Not Util.isValidCarrierCode(carrierCode) Then Return "Parse of carrier code failed: invalid carrier code."

        End If

        Return "OK"

    End Function

    Private Function parseDefaultLocation() As String

        Dim nodelist As XmlNodeList

        nodelist = userSpecRecordXMLDocument.GetElementsByTagName("DefaultLocation")

        If nodelist.Count > 1 Then
            Return "Corrupt XML User Specification: invalid number of default location nodes."
        End If

        If nodelist.Count = 1 Then

            defaultLocation = Trim(nodelist(0).InnerText)

            If isNonNullString(defaultLocation) And Not Util.isValidLocationCode(defaultLocation) Then Return "Parse of default location failed: invalid default location."

        End If

        Return "OK"

    End Function

    Private Function parseFtpHostName() As String

        Dim nodelist As XmlNodeList

        nodelist = userSpecRecordXMLDocument.GetElementsByTagName("FtpHostName")

        If nodelist.Count = 0 Then
            Return "Corrupt XML User Specification: no ftp host name nodes."
        End If

        Dim xN As Xml.XmlNode

        For Each xN In nodelist
            If xN.ParentNode.Name = "User" Then
                ftpHostName = Trim(xN.InnerText)
                If ftpHostName.Length <= 0 Then Return "Parse of ftp host name failed: ftp host name."
            End If
        Next

        Return "OK"

    End Function

    Private Function parseFtpLoginID() As String

        Dim nodelist As XmlNodeList

        nodelist = userSpecRecordXMLDocument.GetElementsByTagName("FtpLoginID")

        If nodelist.Count = 0 Then
            Return "Corrupt XML User Specification: no FtpLoginID nodes."
        End If

        Dim xN As Xml.XmlNode

        For Each xN In nodelist
            If xN.ParentNode.Name = "User" Then
                ftpLoginID = Trim(xN.InnerText)
                If ftpLoginID.Length <= 0 Then Return "Parse of FtpLoginID failed: FtpLoginID."
            End If
        Next

        Return "OK"

    End Function

    Private Function parseFtpPassword() As String

        Dim nodelist As XmlNodeList

        nodelist = userSpecRecordXMLDocument.GetElementsByTagName("FtpPassword")

        If nodelist.Count = 0 Then
            Return "Corrupt XML User Specification: no FtpPassword nodes."
        End If

        Dim xN As Xml.XmlNode

        For Each xN In nodelist
            If xN.ParentNode.Name = "User" Then
                ftpPassword = Trim(xN.InnerText)
                If ftpPassword.Length <= 0 Then Return "Parse of ftpPassword failed: ftpPassword."
            End If
        Next

        Return "OK"

    End Function

    Private Function parseFtpPortNumber() As String
        Dim nodelist As XmlNodeList

        nodelist = userSpecRecordXMLDocument.GetElementsByTagName("FtpPortNumber")

        If nodelist.Count = 0 Then
            Return "Corrupt XML User Specification: no FtpPortNumber nodes."
        End If

        Dim xN As Xml.XmlNode

        For Each xN In nodelist
            If xN.ParentNode.Name = "User" Then
                Try
                    ftpPortNumber = Integer.Parse(xN.InnerText)
                Catch ex As Exception
                    Return "Parse of ftp port number failed: non-integral value."
                End Try
            End If
        Next

        Return "OK"

    End Function

    Private Function parseUserFullName() As String

        Dim nodelist As XmlNodeList

        nodelist = userSpecRecordXMLDocument.GetElementsByTagName("UserFullName")

        If nodelist.Count >= 1 Then

            userFullName = Trim(nodelist(nodelist.Count - 1).InnerText)

            If userFullName.Length <= 0 Then Return "Parse of user full name failed: invalid value."

        End If

        Return "OK"

    End Function

    Private Function parseUserName() As String

        Dim nodelist As XmlNodeList

        nodelist = userSpecRecordXMLDocument.GetElementsByTagName("UserName")

        If nodelist.Count > 1 Then
            Return "Corrupt XML User Specification: invalid number of user name nodes."
        End If

        If nodelist.Count = 1 Then

            userName = Trim(nodelist(0).InnerText)

            If userName.Length <= 0 Then Return "Parse of user name failed: invalid value."

        End If

        Return "OK"

    End Function


    'Added by MX
    Private Function parseCityList() As String

        Dim result As String
        Dim nodelist, cityNameNodeList, cityConfigNodeList As XmlNodeList
        Dim i, j As Integer
        Dim strValue As String

        cityList.Clear()
        cityTable.Clear()

        nodelist = userSpecRecordXMLDocument.GetElementsByTagName("CityList")

        If nodelist.Count > 1 Then
            Return "Corrupt XML User Specification: invalid number of city list nodes."
        End If

        If nodelist.Count = 1 Then

            cityNameNodeList = nodelist(0).ChildNodes

            'Test here
            Dim testStr As String = nodelist(0).InnerText

            For i = 0 To cityNameNodeList.Count - 1

                Dim city As New CityConfig

                cityConfigNodeList = cityNameNodeList.Item(i).ChildNodes

                For j = 0 To cityConfigNodeList.Count - 1

                    strValue = Trim(cityConfigNodeList.Item(j).InnerText)

                    If strValue.Length <> 0 Then

                        Select Case cityConfigNodeList.Item(j).Name.ToUpper
                            Case "WIRELESS802.11"
                                city.GetSetWireless802 = CBool(strValue)
                            Case "WIRELESS"
                                city.GetSetWireless = CBool(strValue)
                            Case "WIRED"
                                city.GetSetWired = CBool(strValue)
                            Case "AUTOSENDWHENDOCKED"
                                city.GetSetAutosendWhenDocked = CBool(strValue)
                            Case "AUTOSEND"
                                city.GetSetAutosend = CBool(strValue)
                            Case "AUTOSENDPERIODICITY"
                                city.GetSetAutosendPeriodicity = CInt(strValue)
                            Case "GROUNDHANDLER"
                                city.GetSetgroundHandler = CBool(strValue)
                            Case "LATEMAILPROMPT"
                                city.GetSetlateMailPrompt = CBool(strValue)
                            Case "ALLOWLATEMAILACCEPT"
                                city.GetSetAllowLateMailAccept = CBool(strValue)
                            Case "ALLOWLATEMAILACCEPTPERIOD"
                                city.GetSetAllowLateMailAcceptPeriod = CInt(strValue)
                            Case "FTPHOSTNAME"
                                city.FTPHostName = strValue
                            Case "FTPPORTNUMBER"
                                city.FTPPort = CInt(strValue)
                            Case "FTPLOGINID"
                                city.FTPLogin = strValue
                            Case "FTPPASSWORD"
                                city.FTPPassword = strValue
                            Case Else
                                Return "City Configuration Parsing Failed!"
                        End Select

                    End If

                Next

                If Not cityTable.ContainsKey(cityNameNodeList.Item(i).Name) Then
                    Dim cityName As String = cityNameNodeList.Item(i).Name
                    cityList.Add(cityNameNodeList.Item(i).Name)
                    cityTable.Add(cityNameNodeList.Item(i).Name, city)
                End If

            Next

        End If

        Dim engComparer As New Comparer(cultureInfo)

        cityList.Sort(engComparer)

        Return "OK"

    End Function

    Public Function parseOperationListString() As String

        Dim operation As String
        Dim i As Integer

        operationsTable.Clear()

        If operationListString Is Nothing Then
            operationListString = ""
        End If

        operationListString = operationListString.Trim(trimChars)

        If operationListString.ToUpper = "FULLLIST" Then

            For Each operation In operationsMasterList
                operationsTable.Add(operation, Nothing)
                operationsList.Add(operation)
            Next

        Else

            Dim tempOperationsList() As String = operationListString.Split(",")

            For Each operation In tempOperationsList

                operation = operation.Trim(trimChars)

                If isNonNullString(operation) Then

                    If operation = "PartialOffload" Then
                        operation = "Partial Offload"
                    ElseIf operation = "CompleteOffload" Then
                        operation = "Complete Offload"
                    ElseIf operation = "Possession&Load" Then
                        operation = "Possession & Load"
                    End If

                    operationsTable.Add(operation, i)
                    operationsList.Add(operation)

                    i += 1

                End If

            Next

        End If

        Return "OK"

    End Function

    Private Function parseInternationalOperationListString() As String

        Dim operation As String
        Dim i As Integer

        internationalOperationsTable.Clear()

        If internationalOperationListString Is Nothing Then
            internationalOperationListString = ""
        End If

        internationalOperationListString = internationalOperationListString.Trim(trimChars)

        If internationalOperationListString.ToUpper = "FULLLIST" Then

            For Each operation In internationalOperationsMasterList
                internationalOperationsTable.Add(operation, Nothing)
                internationalOperationsList.Add(operation)
            Next

        Else

            Dim tempOperationsList() As String = internationalOperationListString.Split(",")

            For Each operation In tempOperationsList

                operation = operation.Trim(trimChars)

                If isNonNullString(operation) Then

                    internationalOperationsTable.Add(operation, i)
                    internationalOperationsList.Add(operation)

                    i += 1

                End If

            Next

        End If

        Return "OK"

    End Function

    Private Function parseIntlSimpleOperationListString(ByVal listString As String) As String

        Dim operation As String
        Dim i As Integer

        If listString Is Nothing Then
            listString = ""
        End If

        listString = listString.Trim(trimChars)

        If listString.ToUpper = "FULLLIST" Then

            For Each operation In internationalOperationsMasterList
                intlSimpleOperationsList.Add(operation)
            Next

        Else

            Dim tempOperationsList() As String = listString.Split(",")

            For Each operation In tempOperationsList

                operation = operation.Trim(trimChars)

                If isNonNullString(operation) Then

                    intlSimpleOperationsList.Add(operation)

                    i += 1

                End If

            Next

        End If

        Return "OK"

    End Function

    Private Function parseOperationsList() As String

        Dim nodelist As XmlNodeList

        Dim result As String

        nodelist = userSpecRecordXMLDocument.GetElementsByTagName("OperationsList")

        If nodelist.Count > 1 Then
            Return "Corrupt XML User Specification: invalid number of operation list nodes."
        End If

        If nodelist.Count = 1 Then

            operationListString = Trim(nodelist(0).InnerText)

            result = parseOperationListString()

            Return result

        End If

        Return "OK"

    End Function

    Private Function parseInternationalOperationsList() As String

        Dim nodelist As XmlNodeList

        Dim result As String

        nodelist = userSpecRecordXMLDocument.GetElementsByTagName("InternationalOperationsList")

        If nodelist.Count > 1 Then
            Return "Corrupt XML User Specification: invalid number of international operation list nodes."
        End If

        If nodelist.Count = 1 Then

            internationalOperationListString = Trim(nodelist(0).InnerText)

            result = parseInternationalOperationListString()

            Return result

        End If

        Return "OK"

    End Function
    Private Function parseIntlSimpleOperationsList() As String

        Dim nodelist As XmlNodeList

        Dim result As String

        nodelist = userSpecRecordXMLDocument.GetElementsByTagName("IntlSimpleOperationsList")

        If nodelist.Count > 1 Then
            Return "Corrupt XML User Specification: invalid number of international simple operation list nodes."
        End If

        If nodelist.Count = 1 Then

            Dim listString As String = Trim(nodelist(0).InnerText)

            result = parseIntlSimpleOperationListString(listString)

            Return result

        End If

        Return "OK"

    End Function

    Public Function parseAdjunctCarrierListString() As String

        Dim carrier As String
        Dim i As Integer

        AdjunctCarrierTable.Clear()
        AdjunctCarrierList.Clear()

        If adjunctCarrierListString Is Nothing Then
            adjunctCarrierListString = ""
        End If

        adjunctCarrierListString = adjunctCarrierListString.Trim(trimChars)

        Dim tempCarrierList() As String = adjunctCarrierListString.Split(",")

        For Each carrier In tempCarrierList

            carrier = carrier.Trim(trimChars)

            If isNonNullString(carrier) Then

                AdjunctCarrierTable.Add(carrier, i)
                AdjunctCarrierList.Add(carrier)

                i += 1

            End If

        Next

        Return "OK"

    End Function

    Private Function parseAdjunctCarrierList() As String

        Dim nodelist As XmlNodeList

        Dim result As String

        nodelist = userSpecRecordXMLDocument.GetElementsByTagName("AdjunctCarrierList")

        If nodelist.Count > 1 Then
            Return "Corrupt XML User Specification: invalid number of adjunct carrier list nodes."
        End If

        If nodelist.Count = 1 Then

            adjunctCarrierListString = Trim(nodelist(0).InnerText)

            result = parseAdjunctCarrierListString()

            Return result

        End If

        Return "OK"

    End Function

    Public Function parseCargoOperationsListString() As String

        Dim carrier As String
        Dim i As Integer

        cargoOperationsTable.Clear()
        cargoOperationsList.Clear()

        If cargoOperationsListString Is Nothing Then
            cargoOperationsListString = ""
        End If

        cargoOperationsListString = cargoOperationsListString.Trim(trimChars)

        Dim tempCargoOperationsList() As String = cargoOperationsListString.Split(",")

        For Each carrier In tempCargoOperationsList

            carrier = carrier.Trim(trimChars)

            If isNonNullString(carrier) Then

                cargoOperationsTable.Add(carrier, i)
                cargoOperationsList.Add(carrier)

                i += 1

            End If

        Next

        Return "OK"

    End Function

    Private Function parseCargoOperationsList() As String

        Dim nodelist As XmlNodeList

        Dim result As String

        nodelist = userSpecRecordXMLDocument.GetElementsByTagName("CargoOperationsList")

        If nodelist.Count > 1 Then
            Return "Corrupt XML User Specification: invalid number of cargo operations list nodes."
        End If

        If nodelist.Count = 1 Then

            cargoOperationsListString = Trim(nodelist(0).InnerText)

            result = parseCargoOperationsListString()

            Return result

        End If

        Return "OK"

    End Function

    '' Parse <EmbargoCityList>
    '' Is a comma separated list of cities (locations)
    Public Function parseEmbargoCityList() As String

        Dim nodelist As XmlNodeList

        Dim result As String

        nodelist = userSpecRecordXMLDocument.GetElementsByTagName("EmbargoCityList")

        If nodelist.Count > 1 Then
            Return "Corrupt XML User Specification: invalid number of embargo city list nodes."
        End If

        If nodelist.Count = 1 Then

            embargoCityListString = Trim(nodelist(0).InnerText)

            result = parseEmbargoCityListString()

            Return result

        End If

        Return "OK"

    End Function

    '' Parse a comma separated list of cities (locations) and add them to the embargo city table
    Public Function parseEmbargoCityListString() As String

        Dim embargoCity As String

        embargoCityTable.Clear()

        embargoCityListString = embargoCityListString.Trim(trimChars)

        Dim tempEmbargoCityList() As String = embargoCityListString.Split(",")

        For Each embargoCity In tempEmbargoCityList

            embargoCity = embargoCity.Trim(trimChars)

            If isNonNullString(embargoCity) Then

                embargoCityTable.Add(embargoCity, Nothing)

            End If

        Next

        Return "OK"

    End Function

    Public Function parse(ByVal inputString As String) As String

        Dim result As String

        reset()

        inputString = inputString.Trim(trimChars)

        Try
            userSpecRecordXMLDocument.LoadXml(inputString)
        Catch ex As Exception

#If deviceType <> "Dolphin" Then
            Return "Parse of user spec record failed: " & ex.Message
#End If

        End Try

        'Added by MX
        result = parseStringValue("myConfigVersion", Me.myConfigVersion)
        If result <> "OK" Then Return result

        result = parseBooleanValue("ftpSecureConnection", ftpSecureConnection)
        If result <> "OK" Then Return result

        result = parseBooleanValue("autoMailSwitch", autoMailSwitch)
        If result <> "OK" Then Return result

        result = parseBooleanValue("continuousMailScan", continuousMailScan)
        If result <> "OK" Then Return result

        result = parseIntegerValue("ScreenTimeOutValue", screenTimeOutValue)
        If result <> "OK" Then Return result

        result = parseBooleanValue("ScreenBlankAfterSend", screenBlankAfterSend)
        If result <> "OK" Then Return result

        result = parseBooleanValue("ftpAuthorization", ftpAuthorization)
        If result <> "OK" Then Return result

        result = parseIntegerValue("FirstReminderInterval", FirstReminderInterval)
        If result <> "OK" Then Return result

        result = parseIntegerValue("SecondReminderInterval", SecondReminderInterval)
        If result <> "OK" Then Return result

        result = parseBooleanValue("sendRerouteHeader", sendRerouteHeader)
        If result <> "OK" Then Return result

        result = parseBooleanValue("differentDestinationWarning", differentDestinationWarning)
        If result <> "OK" Then Return result

        result = parseBooleanValue("deliveryDestinationCheck", deliveryDestinationCheck)
        If result <> "OK" Then Return result

        result = parseBooleanValue("nonUSMailWarning", nonUSMailWarning)
        If result <> "OK" Then Return result

        result = parseBooleanValue("loginEnabled", loginEnabled)
        If result <> "OK" Then Return result

        result = parseIntegerValue("logoutTimeOutValue", logoutTimeOutValue)
        If result <> "OK" Then Return result

        result = parseBooleanValue("buzzOnScan", buzzOnScan)
        If result <> "OK" Then Return result

        result = parseBooleanValue("showKeyboardOnFocus", showKeyboardOnFocus)
        If result <> "OK" Then Return result

        result = parseBooleanValue("DisplayFlightValidationMessages", displayFlightValidationMessages)
        If result <> "OK" Then Return result

        result = parseBooleanValue("LoadScansRequireSelectionFromPreset", loadScansRequireSelectionFromPreset)
        If result <> "OK" Then Return result

        result = parseBooleanValue("LockDownReleasedInAdminForm", lockDownReleasedInAdminForm)
        If result <> "OK" Then Return result

        result = parseBooleanValue("PasswordRequiredForLocationChangeOnScanForm", passwordRequiredForLocationChangeOnScanForm)
        If result <> "OK" Then Return result

        result = parseBooleanValue("PresetsRequireDestinationSpecifications", presetsRequireDestinationSpecifications)
        If result <> "OK" Then Return result

        result = parseBooleanValue("TransferPointOnScanForm", transferPointOnScanForm)
        If result <> "OK" Then Return result

        result = parseBooleanValue("TreatTransferScansAsLoadScans", treatTransferScansAsLoadScans)
        If result <> "OK" Then Return result

        result = parseBooleanValue("TriStateLargeBarcodeCheckBox", triStateLargeBarcodeCheckBox)
        If result <> "OK" Then Return result

        result = parseBooleanValue("WarnOnDuplicateScan", warnOnDuplicateScan)
        If result <> "OK" Then Return result

        result = parseBooleanValue("MailScanEnabled", mailScanEnabled)
        If result <> "OK" Then Return result

        result = parseBooleanValue("MailSimpleScanEnabled", mailSimpleScanEnabled)
        If result <> "OK" Then Return result

        result = parseBooleanValue("MessagesEnabled", messagesEnabled)
        If result <> "OK" Then Return result

        result = parseBooleanValue("CargoScanEnabled", cargoScanEnabled)
        If result <> "OK" Then Return result

        result = parseBooleanValue("BaggageScanEnabled", baggageScanEnabled)
        If result <> "OK" Then Return result

        result = parseBooleanValue("InternationalMailEnabled", internationalMailEnabled)
        If result <> "OK" Then Return result

        result = parseBooleanValue("InternationalSimpleMailEnabled", internationalSimpleMailEnabled)
        If result <> "OK" Then Return result

        result = parseBooleanValue("InternationalCartIDRequired", intlCartIDRequired)
        If result <> "OK" Then Return result

        result = parseBooleanValue("CanExitProgram", CanExitProgram)
        If result <> "OK" Then Return result

        result = parseCarrierCode()
        If result <> "OK" Then Return result

        result = parseDefaultLocation()
        If result <> "OK" Then Return result

        result = parseFtpHostName()
        If result <> "OK" Then Return result

        result = parseFtpLoginID()
        If result <> "OK" Then Return result

        result = parseFtpPassword()
        If result <> "OK" Then Return result

        result = parseFtpPortNumber()
        If result <> "OK" Then Return result

        result = parseUserFullName()
        If result <> "OK" Then Return result

        result = parseUserName()
        If result <> "OK" Then Return result

        result = parseCityList()
        If result <> "OK" Then Return result

        result = parseEmbargoCityList()
        If result <> "OK" Then Return result

        result = parseOperationsList()
        If result <> "OK" Then Return result

        result = parseInternationalOperationsList()
        If result <> "OK" Then Return result

        result = parseIntlSimpleOperationsList()
        If result <> "OK" Then Return result

        result = parseAdjunctCarrierList()
        If result <> "OK" Then Return result

        result = parseCargoOperationsList()
        If result <> "OK" Then Return result

        result = parseBooleanValue("DisplayInternationalPostOffices", DisplayInternationalPostOffices)
        If result <> "OK" Then Return result

        result = Me.parseIntlPostOfficeList()
        If result <> "OK" Then Return result

        result = Me.parseStringValue("DefaultIntlPostOffice", DefaultIntlPostOffice)
        If result <> "OK" Then Return result

        result = Me.parseBooleanValue("UseFtpProxy", Me.UseFtpProxy)
        If result <> "OK" Then Return result

        result = Me.parseStringValue("ProxyType", Me.ProxyType)
        If result <> "OK" Then Return result

        result = Me.parseStringValue("ProxyHost", Me.ProxyHost)
        If result <> "OK" Then Return result

        result = Me.parseIntegerValue("ProxyPort", Me.ProxyPort)
        If result <> "OK" Then Return result

        result = Me.parseStringValue("ProxyUser", Me.ProxyUser)
        If result <> "OK" Then Return result

        result = Me.parseStringValue("ProxyPassword", Me.ProxyPassword)
        If result <> "OK" Then Return result

        'result = Me.parseCN41CodeList()
        'If result <> "OK" Then Return result

        result = parseBooleanValue("IntlPromptCardit", IntlPromptCardit)
        If result <> "OK" Then Return result

        result = parseBooleanValue("UnloadEntireCart", UnloadEntireCart)
        If result <> "OK" Then Return result

        result = parseBooleanValue("UnloadEntireFlight", UnloadEntireFlight)
        If result <> "OK" Then Return result

        result = Me.parseStringValue("IntlCartIdPattern", Me.IntlCartIdPattern)
        If result <> "OK" Then Return result

        result = Me.parseStringValue("MailCartIdPattern", Me.MailCartIdPattern)
        If result <> "OK" Then Return result

        result = Me.parseList("CarditRouteCityList", Me.CarditRouteCityList)
        If result <> "OK" Then Return result

        result = Me.parseList("CarditRouteCarrierList", Me.CarditRouteCarrierList)
        If result <> "OK" Then Return result

        result = Me.parseList("NTPList", Me.NTPServers)
        If result <> "OK" Then Return result

        result = Me.parseOperationsMapping()
        If result <> "OK" Then Return result

        Return "OK"

    End Function

    Private Function getOrCreateRootNode() As XmlNode

        Dim nodeList As XmlNodeList
        Dim rootNode As XmlNode

        nodeList = userSpecRecordXMLDocument.GetElementsByTagName("User")

        If nodeList.Count = 0 Then

            rootNode = userSpecRecordXMLDocument.CreateNode(XmlNodeType.Element, "User", "")

        ElseIf nodeList.Count = 1 Then

            rootNode = nodeList(0)

        Else

            rootNode = Nothing

        End If

        Return rootNode

    End Function

    Public Function updateTextValue(ByVal tagName As String, ByVal textValue As String) As String

        Dim nodelist As XmlNodeList
        Dim xmlText As String

        Dim rootNode As XmlNode
        Dim childNode As XmlNode

        nodelist = userSpecRecordXMLDocument.GetElementsByTagName(tagName)

        If nodelist.Count = 0 Then

            rootNode = getOrCreateRootNode()

            If rootNode Is Nothing Then
                Return "Corrupt XML Document: missing root node <User>"
            End If

            childNode = userSpecRecordXMLDocument.CreateNode(XmlNodeType.Element, tagName, "")

            If childNode Is Nothing Then
                Return "Creation of new node for text value failed."
            End If

            rootNode.AppendChild(childNode)

        ElseIf nodelist.Count = 1 Then

            childNode = nodelist(0)

        Else

            Return "Corrupt XML User Spec Representation. Fails on tag '" & tagName & "'"

        End If

        childNode.InnerText = Trim(textValue)

        Return "OK"

    End Function

    Private Function updateBooleanValue(ByVal tagName As String, ByVal switch As Boolean) As String

        Return updateTextValue(tagName, CStr(switch))

    End Function

    Public Function updateXMLDocument() As String

        Dim result As String

        'reset()

        result = updateTextValue("UserName", userName)
        If result <> "OK" Then Return result

        result = updateTextValue("UserFullName", userFullName)
        If result <> "OK" Then Return result

        result = updateTextValue("CarrierCode", carrierCode)
        If result <> "OK" Then Return result

        result = updateBooleanValue("DisplayFlightValidationMessages", displayFlightValidationMessages)
        If result <> "OK" Then Return result

        result = updateBooleanValue("LoadScansRequireSelectionFromPreset", loadScansRequireSelectionFromPreset)
        If result <> "OK" Then Return result

        result = updateBooleanValue("LockDownReleasedInAdminForm", lockDownReleasedInAdminForm)
        If result <> "OK" Then Return result

        result = updateBooleanValue("PasswordRequiredForLocationChangeOnScanForm", passwordRequiredForLocationChangeOnScanForm)
        If result <> "OK" Then Return result

        result = updateBooleanValue("PresetsRequireDestinationSpecifications", presetsRequireDestinationSpecifications)
        If result <> "OK" Then Return result

        result = updateBooleanValue("TransferPointOnScanForm", transferPointOnScanForm)
        If result <> "OK" Then Return result

        result = updateBooleanValue("TreatTransferScansAsLoadScans", treatTransferScansAsLoadScans)
        If result <> "OK" Then Return result

        result = updateBooleanValue("TriStateLargeBarcodeCheckBox", triStateLargeBarcodeCheckBox)
        If result <> "OK" Then Return result

        result = updateBooleanValue("WarnOnDuplicateScan", warnOnDuplicateScan)
        If result <> "OK" Then Return result

        result = updateBooleanValue("MailScanEnabled", mailScanEnabled)
        If result <> "OK" Then Return result

        result = updateBooleanValue("MailSimpleScanEnabled", mailSimpleScanEnabled)
        If result <> "OK" Then Return result

        result = updateBooleanValue("MessagesEnabled", messagesEnabled)
        If result <> "OK" Then Return result

        result = updateBooleanValue("CargoScanEnabled", cargoScanEnabled)
        If result <> "OK" Then Return result

        result = updateBooleanValue("BaggageScanEnabled", baggageScanEnabled)
        If result <> "OK" Then Return result

        result = updateBooleanValue("InternationalMailEnabled", internationalMailEnabled)
        If result <> "OK" Then Return result

        result = updateBooleanValue("InternationalCartIDRequired", intlCartIDRequired)
        If result <> "OK" Then Return result

        result = updateTextValue("CarrierCode", carrierCode)
        If result <> "OK" Then Return result

        result = updateTextValue("DefaultLocation", defaultLocation)
        If result <> "OK" Then Return result

        result = updateTextValue("FtpHostName", ftpHostName)
        If result <> "OK" Then Return result

        result = updateTextValue("FtpLoginID", ftpLoginID)
        If result <> "OK" Then Return result

        result = updateTextValue("FtpPassword", ftpPassword)
        If result <> "OK" Then Return result

        result = updateTextValue("FtpPortNumber", CStr(ftpPortNumber))
        If result <> "OK" Then Return result

        result = updateBooleanValue("UseFtpProxy", Me.UseFtpProxy)
        If result <> "OK" Then Return result

        result = updateTextValue("ProxyType", Me.ProxyType)
        If result <> "OK" Then Return result

        result = updateTextValue("ProxyHost", Me.ProxyHost)
        If result <> "OK" Then Return result

        result = updateTextValue("ProxyPort", CStr(Me.ProxyPort))
        If result <> "OK" Then Return result

        result = updateTextValue("ProxyUser", Me.ProxyUser)
        If result <> "OK" Then Return result

        result = updateTextValue("ProxyPassword", Me.ProxyPassword)
        If result <> "OK" Then Return result

        'Added by MX
        'result = updateBooleanValue("ftpSecureConnection", ftpSecureConnection)
        'If result <> "OK" Then Return result

        'result = updateTextValue("screenTimeOutValue", CStr(screenTimeOutValue))
        'If result <> "OK" Then Return result

        result = updateTextValue("UserFullName", userFullName)
        If result <> "OK" Then Return result

        result = updateTextValue("UserName", userName)
        If result <> "OK" Then Return result

        'Modified by MX: disabled here and will be implemented later
        'result = updateTextValue("CityList", cityListString)
        'If result <> "OK" Then Return result

        result = updateTextValue("OperationsList", operationListString)
        If result <> "OK" Then Return result

        result = updateTextValue("InternationalOperationsList", internationalOperationListString)
        If result <> "OK" Then Return result

        result = updateTextValue("AdjunctCarrierList", adjunctCarrierListString)
        If result <> "OK" Then Return result

        result = updateTextValue("CargoOperationsList", cargoOperationsListString)
        If result <> "OK" Then Return result

    End Function

    Public Function saveXMLDocument() As String

        Dim textConfigFilePath As String = TagTrakConfigDirectory & "\ScannerConfig.txt"

        deleteLocalFile(textConfigFilePath)

        Try
            Me.userSpecRecordXMLDocument.Save(textConfigFilePath)
        Catch ex As Exception
            Return "Write of updated configuration file failed: " & ex.Message
        End Try

        'Added by MX
        Dim result As String
        Dim configBufferSize As Integer
        Dim configFileBuffer() As Byte

        If Not File.Exists(textConfigFilePath) Then
            Return "File Does Not Exist"
        End If

        Dim configFileInputStream As FileStream

        Try
            configFileInputStream = New FileStream(textConfigFilePath, FileMode.Open)
        Catch ex As Exception
            Return "Open on configuration file '" & textConfigFilePath & "' failed: " & ex.Message
        End Try

        configBufferSize = getFileSize(textConfigFilePath)

        If configBufferSize < 0 Then
            Return "Stat on configuration file failed: invalid file size"
        End If

        Dim bytesRead As Integer
        ReDim configFileBuffer(configBufferSize)

        Try
            bytesRead = configFileInputStream.Read(configFileBuffer, 0, configBufferSize)
        Catch ex As Exception
            Return "Read on configuration file '" & textConfigFilePath & "' failed: " & ex.message
        End Try

        configFileInputStream.Close()

        If bytesRead <> configBufferSize Then
            Return "Read on configuration file '" & textConfigFilePath & "' failed: wrong number of bytes read"
        End If

        Dim i, ilmt As Integer

        ilmt = configBufferSize - 1

        If configTextFileIsEncrypted Then
            For i = 0 To ilmt
                configFileBuffer(i) = configFileBuffer(i) Or &H80
            Next
        End If

        result = writeLocalFileFromBuffer(textConfigFilePath, configFileBuffer, 0, configBufferSize)
        If result <> "OK" Then Return result

        Return "OK"

    End Function

    Public Sub New()
        reset()
    End Sub

    Public Overrides Function ToString() As String

        Dim returnString As String = ""
        Const newLine As String = Chr(10) & Chr(13)
        Const commaNewLine As String = "," & newLine

        returnString &= "User={UserName=" & userName & ",UserFullName='" & userFullName & "',CarrierCode=" & carrierCode & commaNewLine
        returnString &= newLine
        returnString &= "        FtpHostName=" & ftpHostName & commaNewLine
        returnString &= "        FtpPortNumber=" & ftpPortNumber & commaNewLine
        returnString &= "        FtpLoginID=" & ftpLoginID & commaNewLine
        returnString &= "        FtpPassword=" & ftpPassword & commaNewLine
        returnString &= "        TransferPointOnScanForm=" & transferPointOnScanForm & commaNewLine
        returnString &= "        PasswordRequiredForLocationChangeOnScanForm=" & passwordRequiredForLocationChangeOnScanForm & commaNewLine
        returnString &= "        TreatTransferScansAsLoadScans=" & treatTransferScansAsLoadScans & commaNewLine
        returnString &= "        LoadScansRequireSelectionFromPreset=" & loadScansRequireSelectionFromPreset & commaNewLine
        returnString &= "        PresetsRequireDestinationSpecifications=" & presetsRequireDestinationSpecifications & commaNewLine
        returnString &= "        LockDownReleasedInAdminForm=" & lockDownReleasedInAdminForm & commaNewLine
        returnString &= "        DefaultLocation=" & defaultLocation & commaNewLine
        'returnString &= "        CanCreateBinChangeRecords=" & canCreateBinChangeRecords & commaNewLine
        'returnString &= "        CanCreateBinUploadRecords=" & canCreateBinUploadRecords & commaNewLine
        returnString &= "        WarnOnDuplicateScan=" & warnOnDuplicateScan & commaNewLine
        returnString &= newLine

        Dim i, ilmt As Integer

        'Changed by MX 9/14
        If cityList.Count > 0 Then

            i = 0
            ilmt = cityList.Count - 1

            returnString &= "        CityList={ "

            Dim city As String

            For Each city In cityList

                If i <> 0 And ((i Mod 16)) = 0 Then
                    returnString &= newLine & "               "
                End If

                returnString &= city

                If i <> ilmt Then returnString &= ", "

                i += 1

            Next

            returnString &= newLine & "                 }" & newLine & newLine

        End If

        If operationsList.Count > 0 Then

            i = 0

            ilmt = operationsList.Count - 1

            returnString &= "        OperationsList={" & newLine

            Dim operation As String

            For Each operation In operationsList

                If i <> ilmt Then
                    returnString &= "                         " & operation & commaNewLine
                Else
                    returnString &= "                         " & operation & newLine
                End If

                i += 1

            Next

            returnString &= "                         }" & newLine

        End If

        returnString &= "     }" & newLine

        Return returnString

    End Function

    Public Function write(ByVal filePath As String) As String

#If ValidationLevel >= 3 Then

        If diagnosticLevel >= 2 Then
            verify(Not filePath Is Nothing, 26)
        End If

#End If

        Dim outputString As String = Me.ToString()

        Dim outputFileSize As Integer = Length(outputString)

        Dim outputBuffer(outputFileSize) As Byte

        Dim i, ilmt As Integer

        ilmt = outputFileSize - 1

        For i = 0 To ilmt
            outputBuffer(i) = Asc(outputString.Chars(i))
        Next

        deleteLocalFile(filePath)

        Dim outputFileStream As FileStream

        Try
            outputFileStream = New FileStream(filePath, FileMode.Create)
        Catch ex As Exception
            Return "Unable to open output file '" & filePath & "': " & ex.message
        End Try

        Try
            outputFileStream.Write(outputBuffer, 0, outputFileSize)
        Catch ex As Exception
            outputFileStream.Close()
            Return "Write to output file '" & filePath & "' failed: " & ex.Message
        End Try

        Return "OK"

    End Function

    Public Function userNumber() As Integer
        Return userNumberTable(carrierCode)
    End Function

    Private Function parseIntlPostOfficeList() As String

        Dim result As String
        Dim nodelist As XmlNodeList
        Dim intlPostOfficeListString As String

        nodelist = userSpecRecordXMLDocument.GetElementsByTagName("IntlPostOfficeList")

        If nodelist.Count > 1 Then
            Return "Corrupt XML User Specification: invalid number of intl post office list nodes."
        End If

        If nodelist.Count = 1 Then
            intlPostOfficeListString = Trim(nodelist(0).InnerText)
        Else
            intlPostOfficeListString = defaultPostOfficeList ' default list
        End If

        Dim PoList() As String = intlPostOfficeListString.Split(",".ToCharArray())
        Dim po As String
        For Each po In PoList
            Me.IntlPostOfficeList.Add(po.Trim())
        Next

        Return "OK"

    End Function

    Private Function parseOperationsMapping() As String
        '' Format:
        '' <OperationsMapping>
        ''      <Map>
        ''          <Name>Unload</Name>
        ''          <MapTo>Beer Run</MapTo>
        ''      </Map>
        ''      <Map>
        ''          ...
        ''      </Map>
        ''      ...
        '' </OperaionsMapping>

        Dim nodelist As XmlNodeList

        nodelist = userSpecRecordXMLDocument.GetElementsByTagName("OperationsMapping")
        If nodelist.Count = 1 Then
            Dim MapNode As XmlNode
            Dim NameNode As XmlNode
            Dim MapToNode As XmlNode
            For Each MapNode In nodelist.Item(0).ChildNodes
                If MapNode.NodeType = XmlNodeType.Element AndAlso MapNode.Name = "Map" Then
                    If MapNode.HasChildNodes Then
                        If MapNode.ChildNodes.Count = 2 AndAlso (MapNode.ChildNodes.Item(0).NodeType = XmlNodeType.Element And MapNode.ChildNodes.Item(1).NodeType = XmlNodeType.Element) Then
                            NameNode = MapNode.ChildNodes.Item(0)
                            MapToNode = MapNode.ChildNodes.Item(1)
                            If NameNode.Name = "Name" And MapToNode.Name = "MapTo" Then
                                '' Add this valid mapping
                                Me.operationsMapping.SetMapping(NameNode.InnerText, MapToNode.InnerText)
                            Else
                                Return "Error parsing OperationsMapping, tags under Map invalid."
                            End If
                        Else
                            Return "Error parsing OperationsMapping, Map tag invalid."
                        End If
                    End If
                End If
            Next
        ElseIf nodelist.Count > 1 Then
            Return "Error parsing OperationsMapping, too many <OperationsMapping> tags. MUST be only one."
        End If

        Return "OK"

    End Function

    Private Function parseList(ByVal tagName As String, ByRef list As ArrayList) As String

        Dim result As String
        Dim nodelist As XmlNodeList
        Dim listString As String

        nodelist = userSpecRecordXMLDocument.GetElementsByTagName(tagName)

        If nodelist.Count > 1 Then
            Return "Corrupt XML User Specification: invalid number of " & tagName & " list nodes."
        End If

        If nodelist.Count = 1 Then
            listString = Trim(nodelist(0).InnerText)

            Dim listArr() As String = listString.Split(",".ToCharArray())
            Dim it As String
            For Each it In listArr
                list.Add(it.Trim())
            Next
        End If

        Return "OK"

    End Function

    'Private Function parseCN41CodeList() As String

    '    Dim result As String
    '    Dim nodelist As XmlNodeList
    '    Dim CN41CodeListString As String

    '    nodelist = userSpecRecordXMLDocument.GetElementsByTagName("CN41CodeList")

    '    If nodelist.Count > 1 Then
    '        Return "Corrupt XML User Specification: invalid number of CN41 code list nodes."
    '    End If

    '    If nodelist.Count = 1 Then
    '        CN41CodeListString = Trim(nodelist(0).InnerText)
    '        Dim ccList() As String = CN41CodeListString.Split(",".ToCharArray())
    '        Dim cc As String
    '        For Each cc In ccList
    '            If isNonNullString(cc.Trim()) Then
    '                Me.CN41CodeList.Add(cc.Trim())
    '            End If
    '        Next
    '    End If

    '    Return "OK"

    'End Function

End Class
