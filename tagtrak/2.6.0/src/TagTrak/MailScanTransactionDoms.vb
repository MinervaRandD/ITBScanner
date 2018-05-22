Imports System
Imports System.io

Module mailScanTransactionDoms

    Private transactionDandRTag As String = ""
    Private transactionFlightNumber As String = ""
    Private transactionOperation As String = ""
    Private transactionLocation As String = ""
    Private transactionWeightString As String = ""
    Private transactionTailNumber As String = ""
    Private transactionCarrierCode As String = ""
    Private transactionDestination As String = ""
    Private transactionBatchID As String = ""
    Private transactionTransferPoint As String = ""
    Private transactionRejectReason As String = ""

    Private transactionOpCode As String = ""

    Public transactionScanRecord As New scanRecordClass
    Public transactionMailDomsScanRecord As New MailDomsScanRecordClass
    'Public transaction

    Public resditFilePath As String
    Public resditFileDirectory As String
    Public resditFileName As String

    Private Function transactionWarning(ByVal warningString As String, ByVal msgType As MsgBoxStyle, ByVal warningTitle As String) As String

        Util.warning(warningString, msgType, warningTitle)
        Return warningTitle

    End Function

    Private Function validateDestination() As String

        If Not Util.isValidLocation(transactionDestination) Then
            Return transactionWarning("A Valid Destination Is Required For This Operation", MsgBoxStyle.Exclamation, "Invalid Destination")
        End If

        Return "OK"

    End Function

    Private Function validateFlightNumber() As String

        If Not Util.isValidFlightNumber(transactionFlightNumber) Then
            Return transactionWarning("A Valid Flight Number Is Required For This Operation", MsgBoxStyle.Exclamation, "Invalid Flight Number")
        End If

        Return "OK"

    End Function

    Private Function validateBatchID() As String

        If Not Util.isValidBatchID(transactionBatchID) Then
            Return transactionWarning("A Valid A Cart ID Is Required For This Operation", MsgBoxStyle.Exclamation, "Invalid Cart ID")
        End If

        Return "OK"

    End Function

    Private Function validateTransferPoint() As String

        If Not Util.isValidLocationCode(transactionTransferPoint) Then
            Return transactionWarning("A Valid Transfer Point is Required For This Operation", MsgBoxStyle.Exclamation, "Invalid Location Code")
        End If

        Return "OK"

    End Function

    '' Validate D and R tag
    '' MUST be 10 characters
    Private Function validateDandRTag() As String

        If Length(transactionDandRTag) <= 0 Then
            Return transactionWarning("Missing D and R Tag", MsgBoxStyle.Exclamation, "Missing D and R Tag")
        End If

        If Length(transactionDandRTag) < 10 Then
            Return transactionWarning("Invalid or missing D and R tag: Too Few Characters", MsgBoxStyle.Exclamation, "Invalid D and R Tag")
        End If

        If Length(transactionDandRTag) > 10 Then
            Return transactionWarning("Invalid or missing D and R tag: Too Many Characters", MsgBoxStyle.Exclamation, "Invalid D and R Tag")
        End If

        Return "OK"

    End Function

    Private Function validateCarrierCode() As String

        If Length(transactionCarrierCode) <= 1 Then
            Return transactionWarning("A Valid Carrier Code Is Required For This Operation", MsgBoxStyle.Exclamation, "Invalid Carrier Code")
        End If

        Return "OK"

    End Function

    Private Function validateRejectReason() As String

        If Length(transactionRejectReason) <= 0 Then
            Return transactionWarning("A Valid Reject Reason Is Required For This Operation", MsgBoxStyle.Exclamation, "Invalid Carrier Code")
        End If

        Return "OK"

    End Function

    '' Populate class variables with data from form
    Private Function setupAndConditionTransactionDataFromReaderForm() As String

        With MailScanFormRepository.MailScanDomsForm

            If isNonNullString(.operationComboBox.Text) Then
                transactionOperation = Trim(userSpecRecord.operationsMapping.GetOperation(.operationComboBox.Text))
            Else
                transactionOperation = ""
            End If

            If isNonNullString(.flightNumberTextBox.Text) Then
                transactionFlightNumber = Trim(.flightNumberTextBox.Text)
            Else
                transactionFlightNumber = ""
            End If

            .flightNumberTextBox.Text = transactionFlightNumber

            'If isNonNullString(.lblMailScanLocation.Text) Then
            '    transactionLocation = Trim(.lblMailScanLocation.Text)
            'Else
            '    transactionLocation = ""
            'End If

            If isNonNullString(.cbxMailScanLocation.Text) Then
                transactionLocation = Trim(.cbxMailScanLocation.Text)
            Else
                transactionLocation = ""
            End If

            If Length(transactionLocation) < 3 Then
                logScanSequenceEvent(41100, " Transaction rejected: invalid location code: " & transactionLocation)
                Return transactionWarning("The current location is invalid.", MsgBoxStyle.Exclamation, "Invalid Location")
            End If

            Util.scanSequenceVerify(Length(transactionLocation) >= 3, 10)

            transactionLocation = Substring(transactionLocation, 0, 3)

            If Not isNonNullString(transactionOperation) Then
                logScanSequenceEvent(41100, " Transaction rejected: no operation code specified")
                Return transactionWarning("Please Select An Operation", MsgBoxStyle.Exclamation, "No Operation Selected")
            End If

            If isNonNullString(.DandRTextBox.Text) Then
                transactionDandRTag = Trim(.DandRTextBox.Text)
            Else
                transactionDandRTag = ""
            End If

            .DandRTextBox.Text = transactionDandRTag

            If isNonNullString(.weightTextBox.Text) Then
                transactionWeightString = Trim(.weightTextBox.Text.ToUpper)
            Else
                transactionWeightString = ""
            End If

            .weightTextBox.Text = transactionWeightString

            transactionTailNumber = ""

            If isNonNullString(.mailCarrierCodeLabel.Text) Then
                transactionCarrierCode = Trim(.mailCarrierCodeLabel.Text)
            Else
                transactionCarrierCode = ""
            End If

            If isNonNullString(.mailDestinationComboBox.Text) Then
                transactionDestination = Trim(.mailDestinationComboBox.Text)
            Else
                transactionDestination = ""
            End If

            If isNonNullString(.groupNumberTextBox.Text) Then
                transactionBatchID = Trim(.groupNumberTextBox.Text)
            Else
                transactionBatchID = ""
            End If

            .groupNumberTextBox.Text = transactionBatchID

            If isNonNullString(.txtRejectReason.Text) Then
                transactionRejectReason = Trim(.txtRejectReason.Text)
            Else
                transactionRejectReason = ""
            End If

            'Chnaged by MX
            '.rejectReasonTextBox.Text = transactionRejectReason

            If isNonNullString(.transferPointTextBox.Text) Then
                transactionTransferPoint = Trim(.transferPointTextBox.Text)
            Else
                transactionTransferPoint = ""
            End If

            .transferPointTextBox.Text = transactionTransferPoint

            transactionTailNumber = ""

        End With

        Return "OK"

    End Function

    '' Validate existing data
    Private Function validateNonNullFields() As String

        If isNonNullString(transactionFlightNumber) Then
            If Not Util.isValidFlightNumber(transactionFlightNumber) Then
                Return transactionWarning("Invalid Flight Number Specified For Transaction", MsgBoxStyle.Exclamation, "Invalid Flight Number")
            End If
        End If

        If isNonNullString(transactionWeightString) Then
            If Not Util.isValidWeight(transactionWeightString) Then
                Return transactionWarning("Invalid Weight Specified For Transaction", MsgBoxStyle.Exclamation, "Invalid Flight Number")
            End If
        End If

        If isNonNullString(transactionTailNumber) Then
            If Not Util.isValidTailNumber(transactionTailNumber) Then
                Return transactionWarning("Invalid Tail Number Specified For Transaction", MsgBoxStyle.Exclamation, "Invalid Tail Number")
            End If
        End If

        If isNonNullString(transactionBatchID) Then
            If Not Util.isValidBatchID(transactionBatchID) Then
                Return transactionWarning("Invalid Transaction Cart ID Number Specified For Transaction", MsgBoxStyle.Exclamation, "Invalid Tail Number")
            End If
        End If

        If isNonNullString(transactionTransferPoint) Then
            If Not Util.isValidLocationCode(transactionTransferPoint) Then
                Return transactionWarning("Invalid Transaction Cart ID Number Specified For Transaction", MsgBoxStyle.Exclamation, "Invalid Tail Number")
            End If
        End If

        If isNonNullString(transactionDandRTag) Then
            If Not Util.isValidDandRTag(transactionDandRTag) Then
                Return transactionWarning("Invalid D and R Tag Specified For Transaction", MsgBoxStyle.Exclamation, "Invalid Tail Number")
            End If
        End If

        Return "OK"

    End Function

    '' Validate data based on operation code
    Private Function setupAndValidateOperationCode() As String

        Dim result As String

        Select Case transactionOperation

            Case "Possession"
                '' No requirements 

                transactionOpCode = "P"

                '' Validate the flight/destination if entered
                If isNonNullString(transactionFlightNumber) Then
                    result = Data.FlightSchedule.Validation.ValidateOutboundFlight(transactionFlightNumber, transactionLocation, transactionDestination)
                    If result <> "OK" Then Return result
                End If

            Case "Load"
                '' Requires destination, flight number, cart ID

                transactionOpCode = "L"

                result = validateDestination()
                If result <> "OK" Then Return result

                result = validateFlightNumber()
                If result <> "OK" Then Return result

                result = validateBatchID()
                If result <> "OK" Then Return result

                result = Data.FlightSchedule.Validation.ValidateOutboundFlight(transactionFlightNumber, transactionLocation, transactionDestination)
                If result <> "OK" Then Return result

            Case "Possession & Load"
                '' Requires destination, flight number, cart ID

                transactionOpCode = "PL"

                result = validateDestination()
                If result <> "OK" Then Return result

                result = validateFlightNumber()
                If result <> "OK" Then Return result

                result = validateBatchID()
                If result <> "OK" Then Return result

                result = Data.FlightSchedule.Validation.ValidateOutboundFlight(transactionFlightNumber, transactionLocation, transactionDestination)
                If result <> "OK" Then Return result

            Case "Transfer"

                If userSpecRecord.treatTransferScansAsLoadScans Then

                    transactionOpCode = "L"
                    '' Requires destination, flight number, cart ID

                    result = validateDestination()
                    If result <> "OK" Then Return result

                    result = validateFlightNumber()
                    If result <> "OK" Then Return result

                    result = validateBatchID()
                    If result <> "OK" Then Return result

                    result = Data.FlightSchedule.Validation.ValidateOutboundFlight(transactionFlightNumber, transactionLocation, transactionDestination)
                    If result <> "OK" Then Return result

                Else

                    transactionOpCode = "T"
                    '' Requires destination, cart ID, carrier

                    result = validateDestination()
                    If result <> "OK" Then Return result

                    result = validateBatchID()
                    If result <> "OK" Then Return result

                    result = validateTransferPoint()
                    If result <> "OK" Then Return result

                    result = validateCarrierCode()
                    If result <> "OK" Then Return result

                    If isNonNullString(transactionFlightNumber) Then
                        result = Data.FlightSchedule.Validation.ValidateOutboundFlight(transactionFlightNumber, transactionLocation, transactionDestination)
                        If result <> "OK" Then Return result
                    End If

                End If

            Case "Unload"
                '' Requires flight number

                transactionOpCode = "U"

                result = validateFlightNumber()
                If result <> "OK" Then Return result

                result = Data.FlightSchedule.Validation.ValidateInboundFlight(transactionFlightNumber, transactionLocation)
                If result <> "OK" Then Return result

            Case "Partial Offload"
                '' Requires flight number, cart ID

                transactionOpCode = "O"

                result = validateFlightNumber()
                If result <> "OK" Then Return result

                result = validateBatchID()
                If result <> "OK" Then Return result

                result = Data.FlightSchedule.Validation.ValidateOutboundFlight(transactionFlightNumber, transactionLocation, transactionDestination)
                If result <> "OK" Then Return result

            Case "Complete Offload"
                '' Requires flight number, cart ID

                transactionOpCode = "X"

                result = validateFlightNumber()
                If result <> "OK" Then Return result

                result = validateBatchID()
                If result <> "OK" Then Return result

                result = Data.FlightSchedule.Validation.ValidateOutboundFlight(transactionFlightNumber, transactionLocation, transactionDestination)
                If result <> "OK" Then Return result

            Case "Reroute"
                '' Requires destination, flight number, cart ID

                transactionOpCode = "L"

                result = validateDestination()
                If result <> "OK" Then Return result

                result = validateFlightNumber()
                If result <> "OK" Then Return result

                result = validateBatchID()
                If result <> "OK" Then Return result

                result = Data.FlightSchedule.Validation.ValidateOutboundFlight(transactionFlightNumber, transactionLocation, transactionDestination)
                If result <> "OK" Then Return result

            Case "Delivery"
                '' No requirements

                transactionOpCode = "D"

                If isNonNullString(transactionFlightNumber) Then
                    result = Data.FlightSchedule.Validation.ValidateInboundFlight(transactionFlightNumber, transactionLocation)
                    If result <> "OK" Then Return result
                End If

            Case "Return"
                '' Requires reject reason 

                transactionOpCode = "R"

                result = validateRejectReason()
                If result <> "OK" Then Return result

            Case Else
                '' Requires operation code

                Util.warning("Invalid or missing operation code", MsgBoxStyle.Exclamation, "Invalid Operation Code")
                Return "Invalid Operation Code"

        End Select

        Return "OK"

    End Function

    '' Save weight to scan record,
    '' ask if too large
    Public Function processWeightString() As String

        '' Set weight to 0 if not specified
        If Not isNonNullString(transactionWeightString) Then
            transactionMailDomsScanRecord.weight = 0.0
            Return "OK"

        End If

        '' Ask user to input weight if too large
        If transactionWeightString = "US" Then

            Dim weightResult As Integer = Util.getWeightInExcessOf100Pounds()

            If weightResult <= 0 Then
                Util.warning("No Weight Specified For This Item", MsgBoxStyle.Exclamation, "Missing Weight")
                Return "Missing Weight"
            End If

            transactionMailDomsScanRecord.weight = weightResult

            Return "OK"

        End If

        '' Make sure weight is numeric
        If Not IsNumeric(transactionWeightString) Then

            Util.warning("Invalid Weight Specified For This Item", MsgBoxStyle.Exclamation, "Invalid Weight")
            Return "Invalid Weight"

        End If

        '' Set weight (00 means 100)
        If transactionWeightString = "00" Then
            transactionMailDomsScanRecord.weight = 100.0
        Else
            transactionMailDomsScanRecord.weight = CDbl(transactionWeightString)
        End If

        '' Sanity check range
        If transactionMailDomsScanRecord.weight < 0.0 Or transactionMailDomsScanRecord.weight >= 65536 Then

            Util.warning("Invalid Weight Specified For This Item", MsgBoxStyle.Exclamation, "Invalid Weight")
            Return "Invalid Weight"

        End If

        Return "OK"

    End Function

    Public msRoutingCode As String

    Public Function validateTransactionRouting() As String

        If transactionDandRTag = "DUMMYSCANN" Then Return "OK"

        If transactionOperation = "Delivery" Then Return "OK"

        msRoutingCode = Substring(transactionDandRTag, 4, 4).ToUpper

        '' If route code is not in proper format, ask user until it's correct
        While Not Util.isValidRoutingCode(msRoutingCode)

            Dim msMsgInvalidRoutingDisplay As New msMsgInvalidRouting(msRoutingCode)
            Dim result As DialogResult = msMsgInvalidRoutingDisplay.ShowDialog()

            If result = DialogResult.Cancel Then Return "Cancel"

            transactionDandRTag = transactionDandRTag.Substring(0, 4) & msRoutingCode & transactionDandRTag.Substring(8)

        End While

        '' If route code exists, validate
        If routingSet.containsRouting(msRoutingCode) Then Return "OK"

        withinAddRoutingForm = True

        '' At this point we know route code does not exist in our set,
        '' Ask user for routing.
        Dim addRoutingsDisplayForm As New addRoutingForm(msRoutingCode)

        addRoutingsDisplayForm.ShowDialog()

        withinAddRoutingForm = False

        Return "OK"

    End Function

    '' Make sure we didn't scan this tag already.
    '' If allowed ask user to accept if duplicate,
    '' otherwise reject.
    Public Function validateNonDuplicateDandRTag() As String

        Dim scanRecordHashKey As String = transactionScanRecord.getHashKey()

        If userSpecRecord.scanRecordSet.ContainsKey(scanRecordHashKey) Then

            Dim localScanRecord As scanRecordClass = userSpecRecord.scanRecordSet.Item(scanRecordHashKey)

            localScanRecord.duplicateCount += 1

            If Not userSpecRecord.warnOnDuplicateScan Then Return "Duplicate Transaction Ignored"

            Dim msgBoxAnswer As MsgBoxResult = MsgBox("Duplicate Scan Item. Save Anyway?", MsgBoxStyle.YesNo, "Duplicate Scan Item")

            If msgBoxAnswer = MsgBoxResult.No Then Return "Duplicate Transaction Ignored"

            'Else

            '    Dim newScanRecord As scanRecordClass = transactionScanRecord.CreateCopy()

            '    userSpecRecord.scanRecordSet.Add(scanRecordHashKey, transactionScanRecord)

        End If

        Return "OK"

    End Function

    '' Load class variables into scan record and domestic scan record (which is a part of scan record)
    Public Function loadTransactionRecordFromFields() As String

#If ValidationLevel >= 3 Then

        If diagnosticLevel >= 2 Then
            verify(Length(transactionOpCode) >= 1, 25100)
        End If

#End If

        transactionScanRecord.scanType = "M"
        transactionScanRecord.scanOp = transactionOpCode
        transactionScanRecord.scanLoc = transactionLocation
        transactionScanRecord.scanCode = transactionDandRTag
        'transactionScanRecord.statusCode = "1"

        transactionScanRecord.scanDateAndTime = Time.Local.GetTime(scannerTimeZone)

        transactionMailDomsScanRecord.tailNumber = transactionTailNumber
        transactionMailDomsScanRecord.rejectReason = transactionRejectReason
        transactionMailDomsScanRecord.groupNumber = transactionBatchID
        transactionScanRecord.flightNumber = transactionFlightNumber
        transactionScanRecord.carrierCode = transactionCarrierCode
        transactionScanRecord.scanRecord = transactionMailDomsScanRecord

        Return "OK"

    End Function

    Dim resditRecordQueue As New Queue

    Dim resditRecordPrimarySaveSemiphore As New Object
    Dim resditRecordSecondarySaveSemiphore As New Object

    'Public Function threadedSaveNewScanRecords(ByRef scanRecord As scanRecordClass) As String

    '    Dim result As String

    '    SyncLock resditRecordPrimarySaveSemiphore

    '        If primaryDataFileDirectoryIsValid Then

    '            result = scanRecord.appendToFile(scanDataPrimaryFilePath)

    '            If result = "OK" Then

    '                If Length(scanRecord.scanOp) > 1 Then
    '                    scanRecord.scanState.parse(Substring(scanRecord.transactionCode, 1, 1))
    '                    result = scanRecord.appendToFile(scanDataPrimaryFilePath)
    '                End If

    '            End If

    '            If result <> "OK" Then

    '                transactionWarning("Save of resdit record failed: " & result, MsgBoxStyle.Information, "Primary transaction directory failed")
    '                primaryDataFileDirectoryIsValid = False

    '            End If

    '        End If

    '    End SyncLock

    '    SyncLock resditRecordSecondarySaveSemiphore

    '        If secondaryDataFileDirectoryIsValid Then

    '            result = scanRecord.appendToFile(scanDataSecondaryFilePath)

    '            If result = "OK" Then

    '                If Length(scanRecord.scanOp) > 1 Then
    '                    scanRecord.scanState.parse(Substring(scanRecord.scanOp, 1, 1))
    '                    result = scanRecord.appendToFile(scanDataSecondaryFilePath)
    '                End If

    '            End If

    '            If result <> "OK" Then

    '                transactionWarning("Save of resdit record failed: " & result, MsgBoxStyle.Information, "Secondary transaction directory failed")
    '                secondaryDataFileDirectoryIsValid = False

    '            End If

    '        End If

    '    End SyncLock

    '    Return "OK"

    'End Function

    'Public Sub saveNewScanRecordsThread()

    '    Dim scanRecord As scanRecordClass

    '    While True

    '        SyncLock resditRecordQueue

    '            If resditRecordQueue.Count > 0 Then
    '                scanRecord = resditRecordQueue.Dequeue
    '            Else
    '                scanRecord = Nothing
    '            End If

    '        End SyncLock

    '        If scanRecord Is Nothing Then Exit Sub

    '        threadedSaveNewScanRecords(scanRecord)

    '    End While

    'End Sub

    'Public Function saveNewScanRecords() As String

    '    Dim newScanRecord As scanRecordClass = transactionScanRecord.CreateCopy()

    '    newScanRecord.scanOp = transactionOpCode

    '    SyncLock resditRecordQueue

    '        resditRecordQueue.Enqueue(newScanRecord)

    '    End SyncLock

    '    Dim saveScanRecordThread As New System.Threading.Thread(AddressOf saveNewScanRecordsThread)

    '    saveScanRecordThread.Priority = Threading.ThreadPriority.BelowNormal

    '    saveScanRecordThread.Start()

    '    Return "OK"

    'End Function

    'Public Function saveUpdatedMailScanCounts() As String

    '    Dim countFilePath As String = deviceNonVolatileMemoryDirectory & backSlash & "MailScanPieceCounts.txt"

    '    deleteLocalFile(countFilePath)

    '    Dim countFileOutputStream As StreamWriter

    '    Try
    '        countFileOutputStream = New StreamWriter(countFilePath)
    '    Catch ex As Exception
    '        Return "Unable to create scanner counts file: " & ex.message
    '    End Try

    '    Dim outputRecord As String = Trim(MailScanFormRepository.MailScanDomsForm.mailPieceCountLabel.Text) & "," & Trim(MailScanFormRepository.MailScanDomsForm.totalWeightLabel.Text)

    '    Try
    '        countFileOutputStream.WriteLine(outputRecord)
    '    Catch ex As Exception
    '        countFileOutputStream.Close()
    '        Return "Write on counts file failed: " & ex.message
    '    End Try

    '    countFileOutputStream.Close()

    '    Return "OK"

    'End Function

    '' Update our weight and count
    Public Function updateCounts() As String
        Dim readerForm As MailScanDomsForm = MailScanFormRepository.MailScanDomsForm

        Dim totalWeight As Double = 0.0

        If Length(readerForm.totalWeightLabel.Text) > 0 Then
            '' If weight already exists

            If Not IsNumeric(readerForm.totalWeightLabel.Text) Then
                transactionWarning("System Error: Invalid total weight value display", MsgBoxStyle.Exclamation, "Invalid Total Weight In Display")
                Stop
            End If

            If transactionOpCode = "O" Then
                '' For an offload decrement the weight
                totalWeight = CDbl(readerForm.totalWeightLabel.Text) - transactionMailDomsScanRecord.weight
            ElseIf transactionOpCode = "X" Then
                '' For a transfer reset the weight
                totalWeight = 0.0
            Else
                '' For all others add weight
                totalWeight = CDbl(readerForm.totalWeightLabel.Text) + transactionMailDomsScanRecord.weight
            End If

        Else
            '' No previous weight 

            If transactionOpCode = "O" Then
                '' Show negative weight for an offload
                totalWeight = -transactionMailDomsScanRecord.weight
            ElseIf transactionOpCode = "X" Then
                '' Weight = 0 for a Transfer
                totalWeight = 0.0
            Else
                '' Weight = scan record weight for everything else
                totalWeight = transactionMailDomsScanRecord.weight
            End If
        End If

        '' Update label with total weight
        readerForm.totalWeightLabel.Text = CStr(totalWeight)

        Dim pieceCount As Integer

        If transactionOpCode = "O" Then
            pieceCount = -1
        ElseIf transactionOpCode = "X" Then
            pieceCount = 0
        Else
            pieceCount = 1
        End If

        If Length(readerForm.mailPieceCountLabel.Text) > 0 Then

            If Not IsNumeric(readerForm.mailPieceCountLabel.Text) Then
                transactionWarning("System Error: Invalid piece count value display", MsgBoxStyle.Exclamation, "Invalid Piece Count Value")
                Stop
            End If

            If transactionOpCode = "O" Then
                pieceCount = CInt(readerForm.mailPieceCountLabel.Text) - 1
            ElseIf transactionOpCode = "X" Then
                pieceCount = 0
            Else
                pieceCount = CInt(readerForm.mailPieceCountLabel.Text) + 1
            End If

        End If

        '' Update label with piece counts
        readerForm.mailPieceCountLabel.Text = CStr(pieceCount)

        'saveUpdatedMailScanCounts()

        '' Save weight/piece count to file
        fileUtilities.saveCounters(readerForm.mailPieceCountLabel, readerForm.totalWeightLabel, "MailScanPieceCounts.txt")

        Return "OK"

    End Function

    '' Make sure scan location and destination in not in the embargo city list
    Public Function ValidateEmbargoCity() As String

        If transactionOperation.ToUpper = "POSSESSION" Then

            If userSpecRecord.embargoCityTable.ContainsKey(transactionScanRecord.scanLoc) Or _
                userSpecRecord.embargoCityTable.ContainsKey(transactionScanRecord.destination) Then

                Dim embargoWarning As String = "The origin or destination of the flight is in the embargo city list, please return the email(s) to post office"

                transactionWarning(embargoWarning, MsgBoxStyle.Exclamation, "Embargo City")

                Return embargoWarning

            End If

        End If

        Return "OK"

    End Function

    '' Process domestic scan
    Public Function processDomsMailScanTransaction() As String
        transactionScanRecord.reset()

        Dim result As String

        If MailScanFormRepository.MailScanDomsForm Is Nothing Then
            logScanSequenceEvent(40200, "Attempt to do mail scan with inactive reader form.")
            Return "Active Reader Form Not Instantiated."
        End If

        '' Load various form fields into class variables
        result = setupAndConditionTransactionDataFromReaderForm()
        If result <> "OK" Then Return result

        '' Validate this scan with ontime accept rules.
        result = checkOntime(transactionOperation, transactionDandRTag)
        If result <> "OK" Then Return result

        '' Validate existing data
        result = validateNonNullFields()
        If result <> "OK" Then Return result

        '' Validate data based on operation 
        result = setupAndValidateOperationCode()
        If result <> "OK" Then Return result

        '' Validate D and R tag length
        result = validateDandRTag()
        If result <> "OK" Then Return result

        '' Put weight in scan record
        result = processWeightString()
        If result <> "OK" Then Return result

        '' Make sure the routing part of the bar code is correct and exists in our routing set,
        '' If not, ask user
        result = validateTransactionRouting()
        If result <> "OK" Then Return result

        '' Load class variables into our scan record (transactionScanRecord)
        result = loadTransactionRecordFromFields()
        If result <> "OK" Then Return result

        '' If scan is Possession or Possession and Load and we require presets,
        If (transactionOpCode = "L" Or transactionOpCode = "PL") And userSpecRecord.loadScansRequireSelectionFromPreset Then

            logScanEvent(40108, " Validating Load Operation From Preset")

            '' If preset was not used,
            If Not MailScanFormRepository.MailScanDomsForm.currentScanScreenPopulatedFromPreset Then
                '' Disallow scan
                MsgBox("You Must Select A Preset Record Before Doing A Load Scan. Current Scan Ignored.", MsgBoxStyle.Exclamation, "No Preset Selected For Scan")
                Exit Function
            End If

            Dim presetRecord As presetRecordClass = lastSelectedPresetForScanScreen

            '' If the preset was a reroute preset,
            If presetRecord.isReroutePreset Then
                transactionMailDomsScanRecord.oldDestinationCode = presetRecord.destination
                transactionMailDomsScanRecord.oldFlightNumber = presetRecord.flightNumber
            End If

        End If

        '' Save destination into scan record for transfers 
        If transactionOpCode = "T" Then
            transactionScanRecord.destination = transactionTransferPoint
        Else
            transactionScanRecord.destination = transactionDestination
        End If

        '' Make sure scan location and destination is not in embargo city list
        result = ValidateEmbargoCity()
        If result <> "OK" Then Return result

        MailScanFormRepository.MailScanDomsForm.saveButton.Enabled = False
        MailScanFormRepository.MailScanDomsForm.simpleSaveButton.Enabled = False

        '' Check to make sure this is a unique scan
        result = validateNonDuplicateDandRTag()

        '' Do not show error on duplicate scan
        If result = "Duplicate Transaction Ignored" Then Return "OK"
        If result <> "OK" Then Return result

        '' If operation code is Posession or Posession and Load,
        If transactionOpCode = "P" Or transactionOpCode = "PL" Then
            '' Increment global scan count
            logScanEvent(40110, " Updating Global Scan Counts")

            Util.updateGlobalScanCount()
            transactionScanRecord.globalScanCountOnCreation = globalScanCount

            currentSummaryFileIsValid = False

        End If

        logScanEvent(40111, " Saving Resdit Record")

        '' Add this scan record to our scan record set
        userSpecRecord.scanRecordSet.addRecord(transactionScanRecord.CreateCopy())

        logScanEvent(40112, " Updating Counts")

        '' Update/save weight piece counts
        result = updateCounts()
        If result <> "OK" Then Return result

        logScanEvent(40113, " Exiting Process Transaction")

        Return "OK"

    End Function

End Module
