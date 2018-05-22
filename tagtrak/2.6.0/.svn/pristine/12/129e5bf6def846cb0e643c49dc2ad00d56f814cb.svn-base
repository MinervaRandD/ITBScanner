Imports System
Imports System.IO
Imports System.Windows.Forms

Module ProcessInternationalMail

    Private strIntlOpCode As String
    Private strIntlBarcode As String
    Private strIntlLoc As String
    Private strIntlWeight As String
    Private strIntlPieces As String
    Private strIntlCarrier As String
    Private strIntlFlight As String
    Private strIntlHandoverPt As String
    Private strIntlDest As String
    Private strIntlCartID As String
    Private strIntlRejectReason As String
    Private strIntlOldFlight As String
    Private strIntlOldDestination As String
    Private strIntlPostOffice As String
    Private strCN41 As String

    Private scanRecord As New scanRecordClass
    Private mailIntlScanRecord As New MailIntlScanRecordClass

    Public carditRecordTableDateStamp As DateTime
    Public carditRecordTable As New Hashtable

    Public carditExpirationTimeSpan As TimeSpan = New TimeSpan(8, 0, 0, 0)

    Private strLastCartID As String = ""
    Private strLastDestination As String = ""

    Public Function loadNewCarditRoutings() As String

        Dim result As String = ""

        If Not File.Exists(carditRoutingFilePath) Then Return "OK"

        Dim inputFileStream As StreamReader

        Try
            inputFileStream = New StreamReader(carditRoutingFilePath)
        Catch ex As Exception
            Return "Open on new cardit routing file " & carditRoutingFilePath & " failed: " & ex.Message
        End Try

        Dim inputLine As String
        Dim fieldSet() As String

        Dim validFlightList As New ArrayList

        Try
            inputLine = inputFileStream.ReadLine

            While Not inputLine Is Nothing

                If inputLine.StartsWith("*") Then

                    'Here the cardit routing record is created (parsed) to get the valid flight list only. Individual records
                    'are created below because each one has a unique time stamp.

                    Dim carditRoutingRecord As CarditRoutingRecord = generateNewCarditRoutingRecord(inputLine, DateTime.Now, result)

                    If result <> "OK" Then
                        inputFileStream.Close()
                        Return result
                    End If

                    validFlightList = carditRoutingRecord.validFlightList

                Else

                    fieldSet = inputLine.Split(Chr(9))

                    If fieldSet.Length >= 2 Then

                        Dim barcode As String = fieldSet(0)
                        Dim dateStamp As DateTime = DateTime.Parse(fieldSet(1))

                        Dim dateStampDelta = DateTime.UtcNow.Subtract(dateStamp)

                        If TimeSpan.Compare(dateStampDelta, carditExpirationTimeSpan) < 0 And Not carditRecordTable.ContainsKey(barcode) Then

                            'Here, each routing record is unique, even though the valid fight lists may be the same, the time stamps differ.

                            Dim carditRoutingRecord As New CarditRoutingRecord(dateStamp, validFlightList)

                            carditRecordTable.Add(barcode, carditRoutingRecord)

                        End If

                    End If

                End If

                inputLine = inputFileStream.ReadLine

            End While

        Catch ex As Exception
            inputFileStream.Close()
            Return "Read on new cardit routing file " & carditRoutingFilePath & " failed: " & ex.Message
        End Try

        inputFileStream.Close()

        Return "OK"

    End Function

    '' Loads CARDIT records from Cardit.txt.
    ''
    '' Format:
    '' [*FLIGHT[,FLIGHT]...]
    '' BARCODE
    ''
    '' Example:
    '' *123,456,789,001,002,003
    '' USJFKADKCPHAAUR6022300111
    '' USJFKASESTOAAUX6025001300
    ''
    '' Note that even though we load and can check the flight list, it is actually never done anywhere.
    Public Function loadCarditRoutingFile() As String

        Dim localFilePath As String = TagTrakDataDirectory & "\Cardit.txt"

        If Not File.Exists(localFilePath) Then Return "OK"

        Dim dateStampFilePath As String = TagTrakConfigDirectory & "\CarditDateStamp.txt"
        Dim localFileDateStamp As DateTime

        Dim result As String = ""

        If File.Exists(dateStampFilePath) Then

            result = getDateStampFromDateStampFile(dateStampFilePath, localFileDateStamp)

            If result <> "OK" Then
                localFileDateStamp = DateTime.UtcNow
            End If

        End If

        carditRecordTable.Clear()

        Dim dateStampDelta As TimeSpan = DateTime.UtcNow.Subtract(localFileDateStamp)

        If TimeSpan.Compare(dateStampDelta, carditExpirationTimeSpan) >= 0 Then Return "OK"

        Dim inputFileStream As StreamReader

        Try
            inputFileStream = New StreamReader(localFilePath)
        Catch ex As Exception
            Return "Open on cardit routings file " & localFilePath & " failed: " & ex.Message
        End Try

        Dim carditRoutingRecord As New CarditRoutingRecord(localFileDateStamp)

        Try
            Dim inputLine As String

            inputLine = inputFileStream.ReadLine()

            While Not inputLine Is Nothing

                If inputLine.StartsWith("*") Then

                    carditRoutingRecord = generateNewCarditRoutingRecord(inputLine, localFileDateStamp, result)

                    If result <> "OK" Then
                        inputFileStream.Close()
                        Return result
                    End If

                Else

                    If Not carditRecordTable.ContainsKey(inputLine) Then
                        carditRecordTable.Add(inputLine, carditRoutingRecord)
                    End If

                End If

                inputLine = inputFileStream.ReadLine()

            End While

        Catch ex As Exception
            inputFileStream.Close()
            Return "Read on cardit routings file " & localFilePath & " failed: " & ex.Message
        End Try

        inputFileStream.Close()

    End Function

    Private Function generateNewCarditRoutingRecord(ByVal inputLine As String, ByVal dateStamp As DateTime, ByRef result As String) As CarditRoutingRecord

        result = "OK"

        Dim carditRoutingRecord As CarditRoutingRecord = New CarditRoutingRecord(dateStamp)

        If inputLine.Length <= 1 Then
            Return carditRoutingRecord
        End If

        Dim strFlightNumberList As String()

        strFlightNumberList = inputLine.Substring(1).Split(",")

        Dim strFlightNumber As String

        Dim i, ilmt As Integer

        ilmt = strFlightNumberList.Length - 1

        If ilmt < 0 Then
            Return carditRoutingRecord
        End If

        For i = 0 To ilmt

            strFlightNumber = strFlightNumberList(i).Trim()

            If Not Util.IsInteger(strFlightNumber) Then
                result = "Read on cardit routings file failed: Invalid flight number in valid flight number list"
                Return Nothing
            End If

            Dim intFlightNumber As Integer = 0

            Try
                intFlightNumber = System.Int32.Parse(strFlightNumber)
            Catch ex As Exception
                result = "Read on cardit routings file failed: Invalid flight number in valid flight number list"
                Return Nothing
            End Try

            If intFlightNumber < 0 Or intFlightNumber > 9999 Then
                result = "Read on cardit routings file failed: Invalid flight number in valid flight number list"
                Return Nothing
            End If

            carditRoutingRecord.validFlightList.Add(intFlightNumber)

        Next

        Return carditRoutingRecord

    End Function

    Private Function intlMailScanError(ByVal errorString As String) As String
        MsgBox(errorString)
        Return errorString
    End Function

    Private Function intlMailScanError(ByVal errorString As String, ByVal msgboxStyle As MsgBoxStyle, ByVal title As String) As String
        MsgBox(errorString, msgboxStyle, title)
        Return errorString
    End Function

    Public Function intlMailOpCodeMap(ByVal strOpCodeLongForm As String) As String

        Select Case strOpCodeLongForm

            Case "POSSESSION" : Return "P"
            Case "LOAD" : Return "L"
            Case "DELIVERY" : Return "D"
            Case "PARTIAL OFFLOAD" : Return "O"
            Case "COMPLETE OFFLOAD" : Return "X"
            Case "OFFLINE TRNS. CONVEYED" : Return "Y"
            Case "OFFLINE TRNS. RECEIVED" : Return "V"
            Case "ONLINE TRANSFER" : Return "T"
            Case "UNLOAD" : Return "U"
            Case "ARRIVED" : Return "A"
            Case "RETURN" : Return "R"
            Case Else : Return ""

        End Select

    End Function

    Private Sub incrementIntlPieceCount(ByRef counter As System.Windows.Forms.Label, ByVal opCode As String)

        Dim intTotalPieceCount As Integer
        Dim strTotalPieceCount As String

        strTotalPieceCount = counter.Text.Trim()

        If isNullString(strTotalPieceCount) Then
            intTotalPieceCount = 0
        ElseIf Util.IsInteger(strTotalPieceCount) Then
            intTotalPieceCount = strTotalPieceCount
        Else
            intTotalPieceCount = 0
        End If

        'If opCode = "O" Then
        '    intTotalPieceCount -= 1
        'ElseIf opCode = "X" Then
        '    intTotalPieceCount = 0
        'Else
        intTotalPieceCount += 1
        'End If

        counter.Text = intTotalPieceCount

    End Sub

    Private Sub incrementIntlWeight(ByRef totalWeight As System.Windows.Forms.Label, ByVal weight As System.Windows.Forms.TextBox, ByVal opCode As String)

        Dim intTotalWeight As Double
        Dim strTotalWeight As String

        strTotalWeight = totalWeight.Text.Trim()

        If isNullString(strTotalWeight) Then
            intTotalWeight = 0
        ElseIf Util.IsDouble(strTotalWeight) Then
            intTotalWeight = strTotalWeight
        Else
            intTotalWeight = 0
        End If

        Dim weightIncrement As Double
        Dim strWeight As String = weight.Text.Trim()
        Try
            weightIncrement = Double.Parse(strWeight)
        Catch ex As Exception
            weightIncrement = 0
        End Try

        'If opCode = "O" Then
        '    intTotalWeight -= weightIncrement
        'ElseIf opCode = "X" Then
        '    intTotalWeight = 0.0
        'Else
        intTotalWeight += weightIncrement
        'End If

        totalWeight.Text = intTotalWeight

    End Sub

    '' Validate the various fields from the reader form 
    '' and save them to local class level variables
    Private Function loadAndValidateIntlFormFieldTypes(ByVal readerForm As MailScanIntlForm) As String

        With readerForm

            strIntlOpCode = intlMailOpCodeMap(userSpecRecord.operationsMapping.GetOperation(.cbxInternationalMailOperations.Text).Trim().ToUpper)

            If Not isNonNullString(strIntlOpCode) Then
                Return intlMailScanError("A valid operation must be specified to perform a scan operation.")
            End If

            strIntlBarcode = .tbxInternationalBarcode.Text.Trim()

            '' Check length of bar code
            If Not ValidateInternationalFields.isValidIntlBarcode(strIntlBarcode, .IntlPostOffice) Then
                Return intlMailScanError("Scanned barcode is invalid. Scan operation will be ignored.")
            End If

            '' Warn on non-US mail if necessary
            If userSpecRecord.nonUSMailWarning Then
                If Not .IntlPostOffice = "US" Then
                    Dim frmNonUSMailWarning As New NonUSMailWarning
                    If frmNonUSMailWarning.ShowDialog = DialogResult.No Then
                        Return intlMailScanError("Non US mail. Scan operation will be ignored.")
                    End If
                End If
            End If

            '' Save Intl. location
            strIntlLoc = .cbxIntlMailScanLocation.Text.Trim()

            If isNonNullString(strIntlLoc) Then
                '' Validate location sanity
                If Not ValidateInternationalFields.isValidIntlLoc(strIntlLoc) Then
                    Return intlMailScanError("Specified location code is invalid. Scan operation will be ignored.")
                End If
            End If

            '' Save Intl. weight
            strIntlWeight = .tbxInternationalWeight.Text.Trim()

            If isNonNullString(strIntlWeight) Then
                '' Validate weight for sanity
                If Not ValidateInternationalFields.isValidIntlWeight(strIntlWeight) Then
                    Return intlMailScanError("Specified weight code is invalid. Scan operation will be ignored.")
                End If
            End If

            '' Save pieces
            strIntlPieces = .tbxPieces.Text.Trim()

            If isNonNullString(strIntlPieces) Then
                '' Validate piece count for sanity
                If Not ValidateInternationalFields.isValidIntlPieceCount(strIntlPieces) Then
                    Return intlMailScanError("Specified piece count is invalid. Scan operation will be ignored.")
                End If

            End If

            '' Save carrier
            strIntlCarrier = .btnCarrier.Text.Trim()

            If isNonNullString(strIntlCarrier) Then
                '' Validate carrier for sanity
                If Not ValidateInternationalFields.isValidIntlCarrier(strIntlCarrier) Then
                    Return intlMailScanError("Specified carrier is invalid. Scan operation will be ignored.")
                End If
            End If

            '' Save flight
            strIntlFlight = .tbxFlightNumber.Text.Trim()

            If isNonNullString(strIntlFlight) Then
                '' Validate flight number for sanity
                If Not ValidateInternationalFields.isValidIntlFlight(strIntlFlight) Then
                    Return intlMailScanError("Specified flight is invalid. Scan operation will be ignored.")
                End If

            End If

            '' Save "handover" point
            strIntlHandoverPt = .tbxHandoverPoint.Text.Trim()

            If isNonNullString(strIntlHandoverPt) Then
                '' Validate "handover" point for sanity
                If Not ValidateInternationalFields.isValidIntlHandoverPt(strIntlHandoverPt) Then
                    Return intlMailScanError("Specified handover point is invalid. Scan operation will be ignored.")
                End If

            End If

            '' Save destination 
            strIntlDest = .cbxDestination.Text.Trim()

            If isNonNullString(strIntlDest) Then
                '' Validate destination location for sanity
                If Not ValidateInternationalFields.isValidIntlLoc(strIntlDest) Then
                    Return intlMailScanError("Specified destination point is invalid. Scan operation will be ignored.")
                End If

            End If

            '' Save cart id
            strIntlCartID = .tbxCartID.Text.Trim()

            If isNonNullString(strIntlCartID) Then
                '' Validate cart id
                If Not ValidateInternationalFields.isValidIntlCartID(strIntlCartID) Then
                    Return intlMailScanError("Specified destination point is invalid. Scan operation will be ignored.")
                End If

            End If

            '' Save international post office
            strIntlPostOffice = .IntlPostOffice

            '' If bar code length (1 based) is 13 characters or more save bar code type at char 12 (0 based)
            Dim barCodeType As String
            If strIntlBarcode.Length >= 13 Then
                barCodeType = strIntlBarcode.Substring(12, 1).ToUpper()
            Else
                barCodeType = ""
            End If

            '' If operation is a Posession or offline transfer received AND bar code type is "B" or "C"
            '' CN41 is required
            If (strIntlOpCode = "P" Or strIntlOpCode = "V") _
            And .IntlPostOffice = "US" _
            And (barCodeType = "B" Or barCodeType = "C") Then
                '' If no CN41 specified
                If .CN41.Text = "" Then
                    '' Prompt for CN41, and populate .CN41 control
                    Dim dlg As CN41Entry = New CN41Entry(.CN41)
                    dlg.ShowDialog()
                End If
            Else
                '' Clear CN41 if not needed
                .CN41.Text = ""
            End If

            '' Save CN41
            strCN41 = .CN41.Text.Trim()

            If isNonNullString(strIntlPostOffice) Then
                '' Validate post office
                If Not ValidateInternationalFields.isValidIntlPostOffice(strIntlPostOffice) Then
                    Return intlMailScanError("Specified post office is invalid. Scan operation will be ignored.")
                End If
            Else
                '' Post office is required
                Return intlMailScanError("Post office is missing. Scan operation will be ignored.")
            End If

        End With

        '' Clear old destination and flight
        strIntlOldDestination = ""
        strIntlOldFlight = ""

        '' If load scans require a preset,
        If (strIntlOpCode = "L") And userSpecRecord.loadScansRequireSelectionFromPreset Then

            '' Check to make sure scan screen was populated from a preset
            If Not readerForm.currentScanScreenPopulatedFromPreset Then
                Return intlMailScanError("You Must Select A Preset Record Before Doing A Load Scan. Current Scan Ignored.", MsgBoxStyle.Exclamation, "No Preset Selected For Scan")
            End If

            Dim presetRecord As presetRecordClass = lastSelectedPresetForScanScreen

            '' If reroute preset,
            If presetRecord.isReroutePreset Then
                '' Save old destination and old flight
                strIntlOldDestination = presetRecord.destination
                strIntlOldFlight = presetRecord.flightNumber
            End If

        End If

        Return "OK"

    End Function

    Private Function loadAndValidateIntlFormFieldTypes(ByVal readerForm As MailScanIntlSimpleForm) As String

        With readerForm

            If scanLocation Is Nothing Then
                strIntlLoc = userSpecRecord.defaultLocation
            Else
                strIntlLoc = scanLocation.currentLocation
            End If

            '' Get the mapped operation (if any) and translate it to a single character operation code)
            strIntlOpCode = intlMailOpCodeMap(userSpecRecord.operationsMapping.GetOperation(.cbxInternationalMailOperations.Text).Trim().ToUpper)

            If Not isNonNullString(strIntlOpCode) Then
                Return intlMailScanError("A valid operation must be specified to perform a scan operation.")
            End If

            strIntlBarcode = .tbxInternationalBarcode.Text.Trim()

            If Not ValidateInternationalFields.isValidIntlBarcode(strIntlBarcode, .IntlPostOffice) Then
                Return intlMailScanError("Scanned barcode is invalid. Scan operation will be ignored.")
            End If

            If isNonNullString(strIntlLoc) Then
                If Not ValidateInternationalFields.isValidIntlLoc(strIntlLoc) Then
                    Return intlMailScanError("Specified location code is invalid. Scan operation will be ignored.")
                End If
            End If

            strIntlWeight = .tbxInternationalWeight.Text.Trim()

            If isNonNullString(strIntlWeight) Then

                If Not ValidateInternationalFields.isValidIntlWeight(strIntlWeight) Then
                    Return intlMailScanError("Specified weight code is invalid. Scan operation will be ignored.")
                End If

            End If

            strIntlPieces = "1"

            If isNonNullString(strIntlPieces) Then

                If Not ValidateInternationalFields.isValidIntlPieceCount(strIntlPieces) Then
                    Return intlMailScanError("Specified piece count is invalid. Scan operation will be ignored.")
                End If

            End If

            strIntlCarrier = .btnCarrier.Text.Trim()

            If isNonNullString(strIntlCarrier) Then

                If Not ValidateInternationalFields.isValidIntlCarrier(strIntlCarrier) Then
                    Return intlMailScanError("Specified carrier is invalid. Scan operation will be ignored.")
                End If

            End If

            strIntlFlight = ""

            If isNonNullString(strIntlFlight) Then

                If Not ValidateInternationalFields.isValidIntlFlight(strIntlFlight) Then
                    Return intlMailScanError("Specified flight is invalid. Scan operation will be ignored.")
                End If

            End If

            strIntlHandoverPt = .tbxHandoverPoint.Text.Trim()

            If isNonNullString(strIntlHandoverPt) Then

                If Not ValidateInternationalFields.isValidIntlHandoverPt(strIntlHandoverPt) Then
                    Return intlMailScanError("Specified handover point is invalid. Scan operation will be ignored.")
                End If

            End If

            If isNonNullString(strIntlDest) Then

                If Not ValidateInternationalFields.isValidIntlLoc(strIntlDest) Then
                    Return intlMailScanError("Specified destination point is invalid. Scan operation will be ignored.")
                End If

            End If

            strIntlCartID = .tbxCartID.Text.Trim()

            If isNonNullString(strIntlCartID) Then

                If Not ValidateInternationalFields.isValidIntlCartID(strIntlCartID) Then
                    Return intlMailScanError("Specified destination point is invalid. Scan operation will be ignored.")
                End If

            End If

            strIntlPostOffice = .IntlPostOffice

            Dim barCodeType As String
            If strIntlBarcode.Length >= 13 Then
                barCodeType = strIntlBarcode.Substring(12, 1)
            Else
                barCodeType = ""
            End If

            If (strIntlOpCode = "P" Or strIntlOpCode = "V") _
            And .IntlPostOffice = "US" _
            And barCodeType.ToUpper() = "B" Then
                If .CN41.Text = "" Then
                    Dim dlg As CN41Entry = New CN41Entry(.CN41)
                    dlg.ShowDialog()
                End If
            Else
                .CN41.Text = ""
            End If

            strCN41 = .CN41.Text.Trim()

            If isNonNullString(strIntlPostOffice) Then
                If Not ValidateInternationalFields.isValidIntlPostOffice(strIntlPostOffice) Then
                    Return intlMailScanError("Specified post office is invalid. Scan operation will be ignored.")
                End If
            Else
                Return intlMailScanError("Post office is missing. Scan operation will be ignored.")
            End If

        End With

        strIntlOldDestination = ""
        strIntlOldFlight = ""

        If (strIntlOpCode = "L") And userSpecRecord.loadScansRequireSelectionFromPreset Then

            If Not readerForm.currentScanScreenPopulatedFromPreset Then
                Return intlMailScanError("You Must Select A Preset Record Before Doing A Load Scan. Current Scan Ignored.", MsgBoxStyle.Exclamation, "No Preset Selected For Scan")
            End If

            Dim presetRecord As presetRecordClass = lastSelectedPresetForScanScreen

            If presetRecord.isReroutePreset Then
                strIntlOldDestination = presetRecord.destination
                strIntlOldFlight = presetRecord.flightNumber
            End If

        End If

        Return "OK"

    End Function

    '' Certain operations require certain fields to be present, make sure they are there
    Private Function validateFormFieldValuesAgainstOpType() As String

        '' Make sure there is a bar code for Posession, Delivery, and Partial Offload
        '' If not, there must be a cart ID.
        If Not isNonNullString(strIntlBarcode) Then
            If strIntlOpCode = "P" _
            Or strIntlOpCode = "D" _
            Or strIntlOpCode = "O" Then
                Return intlMailScanError("Missing or invalid required bar code. Operation will be ignored.")
            ElseIf Not isNonNullString(strIntlCartID) Then
                Return intlMailScanError("Either bar code or Cart ID has to be entered. Operation will be ignored.")
            End If

        End If

        '' International location MUST exist
        If Not isNonNullString(strIntlLoc) Then
            Return intlMailScanError("Missing or invalid required location. Operation will be ignored.")
        End If

        '' Weight MUST exist for Posession, Partial Offload, Offline Transfer Received, Online Transfer.
        If Not isNonNullString(strIntlWeight) Then
            If strIntlOpCode = "P" _
            Or strIntlOpCode = "O" _
            Or strIntlOpCode = "V" _
            Or strIntlOpCode = "T" Then
                Return intlMailScanError("Missing or invalid required weight. Operation will be ignored.")
            End If
        End If

        '' Pieces MUST exist for Posession, Offline trans. conveyed, Offline trans. received, Online transfer, Return
        If Not isNonNullString(strIntlPieces) Then
            If strIntlOpCode = "P" _
            Or strIntlOpCode = "Y" _
            Or strIntlOpCode = "V" _
            Or strIntlOpCode = "T" _
            Or strIntlOpCode = "R" Then
                Return intlMailScanError("Missing or invalid required pieces. Operation will be ignored.")
            End If
        End If

        '' International carrier MUST exist for Load, Offline Trans. Conveyed, Offline Trans. Received.
        If Not isNonNullString(strIntlCarrier) Then
            If strIntlOpCode = "L" _
            Or strIntlOpCode = "Y" _
            Or strIntlOpCode = "V" Then
                Return intlMailScanError("Missing or invalid required carrier. Operation will be ignored.")
            End If
        End If

        '' Flight MUST exist for Load, Partial Offload, Complete Offload, Online Transfer, Unload.
        If Not isNonNullString(strIntlFlight) Then
            If strIntlOpCode = "L" _
            Or strIntlOpCode = "O" _
            Or strIntlOpCode = "X" _
            Or strIntlOpCode = "T" _
            Or strIntlOpCode = "U" Then
                Return intlMailScanError("Missing or invalid required flight. Operation will be ignored.")
            End If
        End If

        'Disabled Handover point validation at the request of SAS
        'If Not isNonNullString(strIntlHandoverPt) Then
        '    If strIntlOpCode = "Y" _
        '    Or strIntlOpCode = "V" Then
        '        Return intlMailScanError("Missing or invalid required handover point. Operation will be ignored.")
        '    End If
        'End If

        '' Destination/origin MUST exist for Load, Online Transfer, Unload
        If Not isNonNullString(strIntlDest) Then
            If strIntlOpCode = "L" _
            Or strIntlOpCode = "T" Then
                Return intlMailScanError("Missing or invalid required destination. Operation will be ignored.")
            End If

            If strIntlOpCode = "U" Then
                Return intlMailScanError("Missing or invalid required flight origin. Operation will be ignored.")
            End If

        End If

        '' Added at the request of SAS
        '' Cart ID MUST be present for Offline Trans. Conveyed, Online Transfer
        If Not isNonNullString(strIntlCartID) Then
            If strIntlOpCode = "Y" _
            Or strIntlOpCode = "T" Then
                Return intlMailScanError("Missing or invalid required Cart ID. Operation will be ignored.")
            End If
        End If

        '' If required, Cart ID MUST always be present
        If userSpecRecord.intlCartIDRequired Then
            If Not isNonNullString(strIntlCartID) Then
                Return intlMailScanError("Missing or invalid required cart ID. Operation will be ignored.")
            End If
        End If

        '' If required, make sure the destination is the same as before if the cart is the same as before
        '' for Posession and Offline Trans. Received
        If userSpecRecord.differentDestinationWarning Then
            If strIntlOpCode = "P" Or strIntlOpCode = "V" Then
                Dim strNewDestination As String = strIntlBarcode.Substring(8, 3)
                If Not isNonNullString(strIntlCartID) Then
                    '' No cart id
                    Return intlMailScanError("Missing or invalid required cart ID. Operation will be ignored.")

                ElseIf String.Equals(strIntlCartID.ToUpper, strLastCartID.ToUpper) Then
                    '' Same cart ID as last
                    If Not String.Equals(strNewDestination.ToUpper, strLastDestination.ToUpper) Then
                        '' Different destination from last
                        '' Pop up message for confirmation.
                        Dim frmDestinationWarning As New DestinationWarning
                        If frmDestinationWarning.ShowDialog() = DialogResult.No Then
                            Return intlMailScanError("Operation will be ignored.")
                        End If

                    End If

                Else
                    '' Cart ID exists and is not the same as last, save as last cart id
                    strLastCartID = strIntlCartID
                    strLastDestination = strNewDestination

                End If

            End If

        End If

        '' If required, make sure international location is the same as bar code destination
        '' for deliveries.
        If userSpecRecord.deliveryDestinationCheck Then
            If strIntlOpCode = "D" Then
                Dim strBarcodeDestination As String = strIntlBarcode.Substring(8, 3)
                If Not String.Equals(strIntlLoc.ToUpper, strBarcodeDestination.ToUpper) Then
                    Return intlMailScanError("The scanning location is different from delivery destination. Operation will be ignored.")

                End If

            End If

        End If

        Return "OK"

    End Function

    Public Function loadAndValidateIntlFormFields(ByVal readerForm As MailScanIntlForm) As String

        Dim result As String

        '' Validate form fields for sanity and load them into class variables
        result = loadAndValidateIntlFormFieldTypes(readerForm)
        If result <> "OK" Then Return result

        '' Certain operations require certain fields to be present, make sure that they are there
        result = validateFormFieldValuesAgainstOpType()
        If result <> "OK" Then Return result

        Return "OK"

    End Function

    Public Function loadAndValidateIntlFormFields(ByVal readerForm As MailScanIntlSimpleForm) As String

        Dim result As String

        result = loadAndValidateIntlFormFieldTypes(readerForm)
        If result <> "OK" Then Return result

        result = validateFormFieldValuesAgainstOpType()
        If result <> "OK" Then Return result

        Return "OK"

    End Function

    '' If this scan record already exists in our scan record set
    '' If allowed, ask whether to accept the duplicate scan, otherwise reject
    Private Function verifyNonDuplicateScan() As String
        If userSpecRecord.scanRecordSet.containsRecord(scanRecord) Then
            Dim localScanRecord As scanRecordClass = userSpecRecord.scanRecordSet(scanRecord.getHashKey())
            localScanRecord.duplicateCount += 1
            If Not userSpecRecord.warnOnDuplicateScan Then Return "Duplicate Transaction Ignored"
            Dim msgBoxAnswer As MsgBoxResult = MsgBox("Duplicate Scan Item. Save Anyway?", MsgBoxStyle.YesNo, "Duplicate Scan Item")
            If msgBoxAnswer = MsgBoxResult.No Then Return "Duplicate Transaction Ignored"

        End If

        Return "OK"

    End Function

    '' If "prompt" is checked and operation is a Posession or Offline Trans. received or an Unload,
    '' check to make sure the bar code is in the CARDIT table and not expired. If it has, or if it's
    '' not in the table, ask for routing information. 
    Private Function verifyCarditRecordAvailable(ByVal readerForm As MailScanIntlForm) As String
        If Not readerForm.cbxCheckCarditBarCode.Checked Then Return "OK"
        If strIntlOpCode <> "P" And strIntlOpCode <> "V" And strIntlOpCode <> "U" Then Return "OK"
        If carditRecordTable.ContainsKey(strIntlBarcode) Then
            Dim carditRoutingRecord As CarditRoutingRecord = carditRecordTable(strIntlBarcode)
            Dim carditRecordDateStamp As DateTime = carditRoutingRecord.dateTimeStamp
            Dim dateStampDelta As TimeSpan = DateTime.UtcNow.Subtract(carditRecordDateStamp)

            If TimeSpan.Compare(dateStampDelta, carditExpirationTimeSpan) < 0 Then
                Return "OK"
            End If

            carditRecordTable.Remove(strIntlBarcode)

        End If

        Dim mailScanGetCarditRouteForm As getCarditRouteForm = MailScanFormRepository.MailScanGetCarditRouting
        mailScanGetCarditRouteForm.init(strIntlBarcode, readerForm.cbxCheckCarditBarCode)

        mailScanGetCarditRouteForm.Show()
        mailScanGetCarditRouteForm.WindowState = FormWindowState.Maximized

        Return "OK"

    End Function

    Private Function verifyCarditRecordAvailable(ByVal readerForm As MailScanIntlSimpleForm) As String

        If Not readerForm.cbxCheckCarditBarCode.Checked Then Return "OK"

        If strIntlOpCode <> "P" And strIntlOpCode <> "V" And strIntlOpCode <> "U" Then Return "OK"

        If carditRecordTable.ContainsKey(strIntlBarcode) Then

            Dim carditRecordDateStamp As DateTime = carditRecordTable(strIntlBarcode)

            Dim dateStampDelta As TimeSpan = DateTime.UtcNow.Subtract(carditRecordDateStamp)

            If TimeSpan.Compare(dateStampDelta, carditExpirationTimeSpan) < 0 Then
                Return "OK"
            End If

            carditRecordTable.Remove(strIntlBarcode)

        End If

        Dim mailScanGetCarditRouteForm As getCarditRouteForm = MailScanFormRepository.MailScanGetCarditRouting

        mailScanGetCarditRouteForm.init(strIntlBarcode, readerForm.cbxCheckCarditBarCode)

        mailScanGetCarditRouteForm.Show()
        mailScanGetCarditRouteForm.WindowState = FormWindowState.Maximized

        Return "OK"

    End Function

    '' If doing a Posession, Load, Offline Trans. Received, or Online Transfer and CARDIT exists 
    '' with a valid flight number list, make sure the specified flight number is in that list.
    Private Function verifyCarditFlightNumberCorrect(ByVal barcodePrompt As Boolean) As String
        If Not barcodePrompt Then Return "OK"
        If strIntlOpCode <> "P" And strIntlOpCode <> "L" And strIntlOpCode <> "V" And strIntlOpCode <> "T" Then Return "OK"
        If carditRecordTable.ContainsKey(strIntlBarcode) Then
            Dim carditRoutingRecord As CarditRoutingRecord = carditRecordTable(strIntlBarcode)
            Dim validFlightList As ArrayList = carditRoutingRecord.validFlightList

            If validFlightList Is Nothing Then
                Return "OK"
            End If

            If validFlightList.Count <= 0 Then
                Return "OK"
            End If

            Dim scanFlightNumber As Integer = -1
            If Util.IsInteger(strIntlFlight) Then
                Try
                    scanFlightNumber = System.Int32.Parse(strIntlFlight)

                Catch ex As Exception
                    scanFlightNumber = -1
                End Try

            End If

            If Not validFlightList.Contains(scanFlightNumber) Then
                Dim dr As DialogResult = _
                    MessageBox.Show( _
                        "The flight number """ + strIntlFlight + """ is not listed as a valid flight for the scanned barcode. Do you wish to save this scan anyway?", _
                        "Invalid Or Missing Flight Number For This Barcode", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1)

                If dr = DialogResult.Yes Then
                    Return "OK"
                End If

                Return "Ignore Scan"

            End If

        End If

        Return "OK"

    End Function

    Public Sub setIntlSaveButtonStatus(ByVal readerForm As MailScanIntlForm)
        With readerForm
            .btnInternationalSave.Enabled = False
        End With
    End Sub

    '' If doing a Posession and the destination or origin is in the list of Embargoed cities
    '' Show a warning.
    Public Function ValidateEmbargoCity() As String
        If strIntlOpCode.ToUpper = "P" Then
            If userSpecRecord.embargoCityTable.ContainsKey(scanRecord.scanLoc) Or _
                userSpecRecord.embargoCityTable.ContainsKey(scanRecord.destination) Then
                Dim embargoWarning As String = "The origin or destination of the flight is in the embargo city list, please return the mail to post office"
                MsgBox(embargoWarning, MsgBoxStyle.Exclamation, "Embargo City")

                Return embargoWarning

            End If

        End If

        Return "OK"

    End Function

    '' Populate the scan records
    Private Function loadScanRecord() As String

        '' Populate regular scan record
        scanRecord.scanType = "I"
        scanRecord.scanOp = strIntlOpCode
        scanRecord.scanCode = strIntlBarcode
        scanRecord.scanLoc = strIntlLoc
        scanRecord.scanDateAndTime = Time.Local.GetTime(scannerTimeZone)
        'scanRecord.carrierCode = strIntlCarrier
        'Modified by MX
        scanRecord.carrierCode = userSpecRecord.carrierCode
        scanRecord.flightNumber = strIntlFlight
        scanRecord.destination = strIntlDest

        '' Populate fields particular to international scan record
        mailIntlScanRecord.handoverPoint = strIntlHandoverPt
        mailIntlScanRecord.rejectReason = strIntlRejectReason
        mailIntlScanRecord.cartID = strIntlCartID
        mailIntlScanRecord.IntlPostOffice = strIntlPostOffice
        mailIntlScanRecord.CN41 = strCN41
        mailIntlScanRecord.secondCarrier = strIntlCarrier

        '' Save weight
        If Not isNonNullString(strIntlWeight.Trim()) Then
            mailIntlScanRecord.weight = 0
        Else
            Try
                mailIntlScanRecord.weight = Double.Parse(strIntlWeight)
            Catch ex As Exception
                Return intlMailScanError("Invalid weight specification. Scan will be ignored", MsgBoxStyle.Exclamation, "Invalid Weight Specification")
            End Try
        End If

        '' Save pieces
        If Not isNonNullString(strIntlPieces.Trim()) Then
            mailIntlScanRecord.pieceCount = 0
        Else
            Try
                mailIntlScanRecord.pieceCount = Integer.Parse(strIntlPieces)
            Catch ex As Exception
                Return intlMailScanError("Invalid peice count specification. Scan will be ignored", MsgBoxStyle.Exclamation, "Invalid Piece Count Specification")
            End Try
        End If

        '' Save international specific record to scan record.
        scanRecord.scanRecord = mailIntlScanRecord

        Return "OK"

    End Function

    Public Function processIntlMailScanTransaction(ByVal readerForm As MailScanIntlForm) As String

        Dim result As String

        '' Bulk operation do not generate a scan record in the traditional sense.
        '' Also, they are not counted.
        Dim fBulkOp As Boolean

        '' Validate the various form fields for sanity and save them to class variables
        result = loadAndValidateIntlFormFields(readerForm)
        If result <> "OK" Then : readerForm.tbxInternationalBarcode.Text = "" : Return result : End If

        '' Load scan information into scanRecord
        result = loadScanRecord()
        If result <> "OK" Then : readerForm.tbxInternationalBarcode.Text = "" : Return result : End If

        '' If destination or origin is in the embargoed city list do not accept the scan
        result = ValidateEmbargoCity()
        If result <> "OK" Then Return result

        '' Accept/reject duplicate records
        result = verifyNonDuplicateScan()
        If result <> "OK" Then Return result

        '' If necessary, make sure a CARDIT record for this bar code exist, if not, prompt
        result = verifyCarditRecordAvailable(readerForm)
        If result <> "OK" Then Return result

        '' Make sure there is either a CARDIT or a flight number and destination specified.
        result = requireFlightDestForNoPrompt(readerForm)
        If result <> "OK" Then Return result

        '' Make sure flight number is valid with the CARDIT
        '' CARDIT contains flight number list
        result = verifyCarditFlightNumberCorrect(readerForm.cbxCheckCarditBarCode.Checked)
        If result <> "OK" Then Return result

        '' Validate flight number with destination/origin (according to flight schedule)
        Select Case strIntlOpCode
            Case "P", "L", "T", "O", "X"
                If isNonNullString(scanRecord.flightNumber) Then
                    result = Data.FlightSchedule.Validation.ValidateOutboundFlight(scanRecord.flightNumber, scanRecord.scanLoc, scanRecord.destination)
                End If

            Case "U"
                If isNonNullString(scanRecord.flightNumber) Then
                    result = Data.FlightSchedule.Validation.ValidateInboundFlight(scanRecord.flightNumber, scanRecord.scanLoc, scanRecord.destination)
                End If

            Case "D"
                '' Delivery has no "Destination" in the UI
                '' So in this case just verify that the flight is inbound.
                If isNonNullString(scanRecord.flightNumber) Then
                    result = Data.FlightSchedule.Validation.ValidateInboundFlight(scanRecord.flightNumber, scanRecord.scanLoc)
                End If

        End Select
        If result <> "OK" Then Return result

        '' If unload entire cart is checked and Unload entire cart is enabled,
        If userSpecRecord.UnloadEntireCart And readerForm.cbxUnloadEntireCart.Checked Then
            '' If operation is Unload
            If strIntlOpCode = "U" Then
                '' Generate full cart unload record
                result = generateFullCartUnloadRecord()
                If result = "OK" Then
                    '' Generated Ok
                    fBulkOp = True
                ElseIf result = "No" Then
                    '' User declined to unload entire cart
                    fBulkOp = False
                ElseIf result = "Cancel" Then
                    '' User cancelled scan operation
                    Exit Function
                End If
            End If
        End If

        '' Unload entire flight?
        If userSpecRecord.UnloadEntireFlight And strIntlOpCode = "U" Then
            '' Check flight number with our records
            If isNonNullString(scanRecord.flightNumber) AndAlso flightLoadInfo.IsFlightLoadKnown(scanRecord.flightNumber) Then
                '' This flight has load data
                result = generateFullFlightUnloadRecord()
                If result = "OK" Then
                    '' Generated unload entire flight record
                    fBulkOp = True
                ElseIf result = "No" Then
                    '' User declined to unload the entire flight
                    fBulkOp = False
                End If
            End If
        End If

        '' Ask for reject reason if a return
        If strIntlOpCode = "R" Then
            'strIntlRejectReason = InputBox("Please Specify A Return Reason" , "Specify Reject Reason", "")
            Dim dlg As New RejectReason
            If dlg.ShowDialog() = DialogResult.OK Then
                strIntlRejectReason = dlg.ReasonVal()
            Else
                Return ""
            End If
        Else
            strIntlRejectReason = ""
        End If

        '' If it's a possession update global scan count
        If strIntlOpCode = "P" Then
            Util.updateGlobalScanCount()
            scanRecord.globalScanCountOnCreation = globalScanCount

            currentSummaryFileIsValid = False

        End If

        '' We don't save individual bar code scans for bulk operartions like unload entire flight/cart,
        '' those are considered "Bulk" operation and are treated differently
        If Not fBulkOp Then
            '' Save this scan record in the scan record set
            userSpecRecord.scanRecordSet.addRecord(scanRecord.CreateCopy())

            '' Increment piece/weight counts
            incrementIntlPieceCount(readerForm.lblIntMailTotCountLabel, strIntlOpCode)
            incrementIntlWeight(readerForm.lblIntMailTotWgt, readerForm.tbxInternationalWeight, strIntlOpCode)

            '' Save counters to a counter file
            saveCounters(readerForm.lblIntMailTotCountLabel, readerForm.lblIntMailTotWgt, "IntlMailScanPieceCounts.txt")
        End If


    End Function

    '' Returns "No", "Cancel", "OK"
    '' No = Unload one piece
    '' Cancel = Don't unload
    '' OK = Unload cart
    Private Function generateFullCartUnloadRecord() As String

        If Not userSpecRecord.UnloadEntireCart Then
            Return "No"
        End If

        Dim dr As DialogResult = MessageBox.Show("Do you want to unload the entire cart/flight?", "Unload Entire Cart/Flight?", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1)

        If dr = DialogResult.Cancel Or dr = DialogResult.No Then
            Return dr.ToString
        End If

        Dim fullCartUnloadFileWriter As StreamWriter

        Try
            fullCartUnloadFileWriter = New StreamWriter(fullCartUnloadFilePath, True)
        Catch ex As Exception
            MessageBox.Show("Attempt to open full cart unload file failed: " & ex.Message & ". Full cart unload will not be recorded")
            Return "Open On Full Cart Unload File Failed: " & ex.Message
        End Try

        Dim outputLine As String

        Dim eventTimeAndDate As DateTime = Time.Local.GetTime(scannerTimeZone)

        Dim strDate As String = eventTimeAndDate.ToString("yyyy-MM-dd")
        Dim strTime As String = eventTimeAndDate.ToString("HH:mm:ss")

        outputLine = strIntlFlight & Chr(9) & strIntlCartID & Chr(9) & strIntlBarcode & Chr(9) & strDate & Chr(9) & strTime & Chr(9) & "I"

        Try
            fullCartUnloadFileWriter.WriteLine(outputLine)
        Catch ex As Exception
            MessageBox.Show("Attempt to write to full cart unload file failed: " & ex.Message & ". Full cart unload will not be recorded")
            Return "Write On Full Cart Unload File Failed: " & ex.Message
        End Try

        fullCartUnloadFileWriter.Flush()
        fullCartUnloadFileWriter.Close()

        '' Save the UTC offset used to save the scan time
        userSpecRecord.scanRecordSet.TimeZoneUsed.OffsetUTC = scannerTimeZone.OffsetInfo.OffsetUTC

        MessageBox.Show("Unload operation for the entire flight or cart has been recorded.")

        Application.DoEvents()

        Return "OK"

    End Function

    '' Returns "No", "Cancel", "OK"
    '' No = Unload one piece
    '' OK = Unload flight
    Private Function generateFullFlightUnloadRecord() As String

        If Not userSpecRecord.UnloadEntireFlight Then
            Return "No"
        End If

        Dim dr As DialogResult = MessageBox.Show("Do you want to unload the entire flight?", "Unload Entire Flight?", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1)

        If dr = DialogResult.No Then
            Return dr.ToString
        End If

        Dim fullFlightUnloadFileWriter As StreamWriter

        Try
            fullFlightUnloadFileWriter = New StreamWriter(fullFlightUnloadFilePath, True)
        Catch ex As Exception
            MessageBox.Show("Attempt to open full flight unload file failed: " & ex.Message & ". Full flight unload will not be recorded")
            Return "Open On Full Flight Unload File Failed: " & ex.Message
        End Try

        Dim outputLine As String

        Dim eventTimeAndDate As DateTime = Time.Local.GetTime(scannerTimeZone)

        Dim strDate As String = eventTimeAndDate.ToString("yyyy-MM-dd")
        Dim strTime As String = eventTimeAndDate.ToString("HH:mm:ss")

        outputLine = strIntlFlight & Chr(9) & strDate & Chr(9) & strTime & Chr(9) & "I"

        Try
            fullFlightUnloadFileWriter.WriteLine(outputLine)
        Catch ex As Exception
            MessageBox.Show("Attempt to write to full flight unload file failed: " & ex.Message & ". Full flight unload will not be recorded")
            Return "Write On Full Flight Unload File Failed: " & ex.Message
        End Try

        fullFlightUnloadFileWriter.Flush()
        fullFlightUnloadFileWriter.Close()

        '' Save the UTC offset used to save the scan time
        userSpecRecord.scanRecordSet.TimeZoneUsed.OffsetUTC = scannerTimeZone.OffsetInfo.OffsetUTC

        MessageBox.Show("Unload operation for the entire flight has been recorded.")

        Application.DoEvents()

        Return "OK"

    End Function

    Public Function processIntlMailScanTransaction(ByVal readerForm As MailScanIntlSimpleForm) As String

        Dim result As String
        Dim fBulkOp As Boolean

        result = loadAndValidateIntlFormFields(readerForm)
        If result <> "OK" Then : readerForm.tbxInternationalBarcode.Text = "" : Return result : End If

        result = loadScanRecord()
        If result <> "OK" Then : readerForm.tbxInternationalBarcode.Text = "" : Return result : End If

        'Added by MX
        result = ValidateEmbargoCity()
        If result <> "OK" Then Return result

        result = verifyNonDuplicateScan()
        If result <> "OK" Then Return result

        result = verifyCarditRecordAvailable(readerForm)
        If result <> "OK" Then Return result

        result = verifyCarditFlightNumberCorrect(readerForm.cbxCheckCarditBarCode.Checked)
        If result <> "OK" Then Return result

        '' Validate flight number with destination/origin (according to flight schedule)
        Select Case strIntlOpCode
            Case "P", "L", "T", "O", "X"
                If isNonNullString(scanRecord.flightNumber) Then
                    result = Data.FlightSchedule.Validation.ValidateOutboundFlight(scanRecord.flightNumber, scanRecord.scanLoc, scanRecord.destination)
                End If
            Case "U"
                If isNonNullString(scanRecord.flightNumber) Then
                    result = Data.FlightSchedule.Validation.ValidateInboundFlight(scanRecord.flightNumber, scanRecord.scanLoc, scanRecord.destination)
                End If
            Case "D"
                '' Delivery has a "Destination" in the UI, this makes no sense when validating
                '' So in this case just verify that the flight is inbound.
                If isNonNullString(scanRecord.flightNumber) Then
                    result = Data.FlightSchedule.Validation.ValidateInboundFlight(scanRecord.flightNumber, scanRecord.scanLoc)
                End If

        End Select
        If result <> "OK" Then Return result

        If userSpecRecord.UnloadEntireCart And readerForm.cbxUnloadEntireCart.Checked Then
            If strIntlOpCode = "U" Then
                result = generateFullCartUnloadRecord()
                If result = "OK" Then
                    fBulkOp = True
                ElseIf result = "No" Then
                    fBulkOp = False
                ElseIf result = "Cancel" Then
                    Exit Function
                End If
            End If
        End If

        '' Unload entire flight?
        If userSpecRecord.UnloadEntireFlight And strIntlOpCode = "U" Then
            '' Check flight number with our records
            If isNonNullString(scanRecord.flightNumber) AndAlso flightLoadInfo.IsFlightLoadKnown(scanRecord.flightNumber) Then
                '' This flight has load data
                result = generateFullFlightUnloadRecord()
                If result = "OK" Then
                    fBulkOp = True
                ElseIf result = "No" Then
                    fBulkOp = False
                End If
            End If
        End If

        If strIntlOpCode = "R" Then
            'strIntlRejectReason = InputBox("Please Specify A Return Reason", "Specify Reject Reason", "")
            Dim dlg As New RejectReason
            If dlg.ShowDialog() = DialogResult.OK Then
                strIntlRejectReason = dlg.ReasonVal()
            Else
                Return ""
            End If
        Else
            strIntlRejectReason = ""
        End If

        If strIntlOpCode = "P" Then

            Util.updateGlobalScanCount()
            scanRecord.globalScanCountOnCreation = globalScanCount

            currentSummaryFileIsValid = False

        End If

        If Not fBulkOp Then
            userSpecRecord.scanRecordSet.addRecord(scanRecord.CreateCopy())

            incrementIntlPieceCount(readerForm.lblIntMailTotCountLabel, strIntlOpCode)
            incrementIntlWeight(readerForm.lblIntMailTotWgt, readerForm.tbxInternationalWeight, strIntlOpCode)


            saveCounters(readerForm.lblIntMailTotCountLabel, readerForm.lblIntMailTotWgt, "IntlMailScanPieceCounts.txt")
        End If

    End Function

    Dim previousIntlOperation As String = ""

    Private Sub clearAllIntlTextBoxes(ByVal readerForm As MailScanIntlForm)

        With readerForm

            .tbxInternationalBarcode.Text = ""
            .tbxInternationalWeight.Text = ""
            .tbxPieces.Text = ""
            .tbxFlightNumber.Text = ""
            .tbxHandoverPoint.Text = ""
            .tbxCartID.Text = ""
            .CN41.Text = ""

        End With

    End Sub

    '' If not prompt for intl. cardit, and there is not cardit for this bar code, and doing a 
    '' Posession or offline Trans. received and there is no flight number or destination, reject scan.
    '' In this case, require flight number and destination.
    Private Function requireFlightDestForNoPrompt(ByVal readerForm As MailScanIntlForm) As String
        If userSpecRecord.IntlPromptCardit Then Return "OK"
        If strIntlOpCode <> "P" And strIntlOpCode <> "V" Then Return "OK"
        If isNonNullString(readerForm.tbxFlightNumber.Text) And isNonNullString(readerForm.cbxDestination.SelectedItem) Then
            Return "OK"
        End If
        If carditRecordTable.ContainsKey(strIntlBarcode) Then
            Dim carditRoutingRecord As CarditRoutingRecord = carditRecordTable(strIntlBarcode)
            Dim carditRecordDateStamp As DateTime = carditRoutingRecord.dateTimeStamp
            Dim dateStampDelta As TimeSpan = DateTime.UtcNow.Subtract(carditRecordDateStamp)
            If TimeSpan.Compare(dateStampDelta, carditExpirationTimeSpan) < 0 Then
                Return "OK"
            End If

            carditRecordTable.Remove(strIntlBarcode)

        End If

        MsgBox("Cardit routing information cannot be found for this barcode. Please enter flight and destination.")
        Return "Flight and destination required"

    End Function

End Module
