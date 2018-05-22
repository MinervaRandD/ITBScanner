Imports System
Imports System.io

Module mailScanTransaction

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

    Public transactionResditRecord As New resditRecordClass

    Public resditFilePath As String
    Public resditFileDirectory As String
    Public resditFileName As String

    Private Function transactionWarning(ByVal warningString As String, ByVal msgType As MsgBoxStyle, ByVal warningTitle As String) As String

        warning(warningString, msgType, warningTitle)
        Return warningTitle

    End Function

    Private Function validateDestination() As String

        If Not isValidLocation(transactionDestination) Then
            Return transactionWarning("A Valid Destination Is Required For This Operation", MsgBoxStyle.Exclamation, "Invalid Destination")
        End If

        Return "OK"

    End Function

    Private Function validateFlightNumber() As String

        If Not isValidFlightNumber(transactionFlightNumber) Then
            Return transactionWarning("A Valid Flight Number Is Required For This Operation", MsgBoxStyle.Exclamation, "Invalid Flight Number")
        End If

        Return "OK"

    End Function

    Private Function validateBatchID() As String

        If Not isValidBatchID(transactionBatchID) Then
            If user = "ATA" Or user = "USAirways" Then
                Return transactionWarning("A Valid A Cart ID Is Required For This Operation", MsgBoxStyle.Exclamation, "Invalid Cart ID")
            Else
                Return transactionWarning("A Valid Cart ID Is Required For This Operation", MsgBoxStyle.Exclamation, "Invalid Cart ID")
            End If

        End If

        Return "OK"

    End Function

    Private Function validateTransferPoint() As String

        If Not isValidLocationCode(transactionTransferPoint) Then
            Return transactionWarning("A Valid Transfer Point is Required For This Operation", MsgBoxStyle.Exclamation, "Invalid Location Code")
        End If

        Return "OK"

    End Function

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

    Public Sub validateOutboundFlight(ByVal flightNumberString As String, ByVal locationCode As String)

#If ValidationLevel >= 3 Then

        If diagnosticLevel >= 2 Then
            verify(Not flightNumberString Is Nothing, 24000)
            verify(Not locationCode Is Nothing, 24001)
        End If

#End If

        If Not userSpecRecord.displayFlightValidationMessages Then Exit Sub

        If flightValidationMessageDisplayed Then Exit Sub

        flightNumberString = Trim(flightNumberString).PadLeft(4, "0")

        If Not isValidFlightNumber(flightNumberString) Then
            systemError("Invalid value passed to validateOutboundFlight")
            Stop
        End If

        Dim inboundFlight, outboundFlight As Boolean

        flightRecordSet.getRecord(flightNumberString, locationCode, inboundFlight, outboundFlight)

        If Not outboundFlight Then
            MsgBox("Warning: flight number " & flightNumberString & " is not a scheduled outbound flight for " & locationCode, MsgBoxStyle.Information, "Non-scheduled Outbound Flight")
            flightValidationMessageDisplayed = True
            Exit Sub
        End If

    End Sub

    Public Sub validateInboundFlight(ByVal flightNumberString As String, ByVal locationCode As String)

#If ValidationLevel >= 3 Then

        If diagnosticLevel >= 2 Then
            verify(Not flightNumberString Is Nothing, 25000)
            verify(Not locationCode Is Nothing, 25001)
        End If

#End If

        If Not userSpecRecord.displayFlightValidationMessages Then Exit Sub

        If flightValidationMessageDisplayed Then Exit Sub

        flightNumberString = Trim(flightNumberString).PadLeft(4, "0")

        If Not isValidFlightNumber(flightNumberString) Then
            systemError("Invalid value passed to validateOutboundFlight")
            Stop
        End If

        Dim inboundFlight, outboundFlight As Boolean

        flightRecordSet.getRecord(flightNumberString, locationCode, inboundFlight, outboundFlight)

        If Not inboundFlight Then
            MsgBox("Warning: flight number " & flightNumberString & " is not a scheduled inbound flight for " & locationCode, MsgBoxStyle.Information, "Non-scheduled Outbound Flight")
            flightValidationMessageDisplayed = True
            Exit Sub
        End If

    End Sub

    Private Function setupAndConditionTransactionDataFromReaderForm() As String

        With activeReaderForm

            If isNonNullString(.operationComboBox.Text) Then
                transactionOperation = Trim(.operationComboBox.Text)
            Else
                transactionOperation = ""
            End If

            If isNonNullString(.flightNumberTextBox.Text) Then
                transactionFlightNumber = Trim(.flightNumberTextBox.Text)
            Else
                transactionFlightNumber = ""
            End If

            .flightNumberTextBox.Text = transactionFlightNumber

            If isNonNullString(.mailLocationLabel.Text) Then
                transactionLocation = Trim(.mailLocationLabel.Text)
            Else
                transactionLocation = ""
            End If

            If Length(transactionLocation) < 3 Then
                logScanSequenceEvent(41100, " Transaction rejected: invalid location code: " & transactionLocation)
                Return transactionWarning("The current location is invalid.", MsgBoxStyle.Exclamation, "Invalid Location")
            End If

            scanSequenceVerify(Length(transactionLocation) >= 3, 10)

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

            If isNonNullString(.tailNumberTextBox.Text) Then
                transactionTailNumber = Trim(.tailNumberTextBox.Text)
            Else
                transactionTailNumber = ""
            End If

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

            If isNonNullString(.rejectReasonTextBox.Text) Then
                transactionRejectReason = Trim(.rejectReasonTextBox.Text)
            Else
                transactionRejectReason = ""
            End If

            .rejectReasonTextBox.Text = transactionRejectReason

            If isNonNullString(.transferPointTextBox.Text) Then
                transactionTransferPoint = Trim(.rejectReasonTextBox.Text)
            Else
                transactionTransferPoint = ""
            End If

            .transferPointTextBox.Text = transactionTransferPoint

            If isNonNullString(.tailNumberTextBox.Text) Then
                transactionTailNumber = Trim(.rejectReasonTextBox.Text)
            Else
                transactionTailNumber = ""
            End If

            .tailNumberTextBox.Text = transactionTailNumber

        End With

        Return "OK"

    End Function

    Private Function validateNonNullFields() As String

        If isNonNullString(transactionFlightNumber) Then
            If Not isValidFlightNumber(transactionFlightNumber) Then
                Return transactionWarning("Invalid Flight Number Specified For Transaction", MsgBoxStyle.Exclamation, "Invalid Flight Number")
            End If
        End If

        If isNonNullString(transactionWeightString) Then
            If Not isValidWeight(transactionWeightString) Then
                Return transactionWarning("Invalid Weight Specified For Transaction", MsgBoxStyle.Exclamation, "Invalid Flight Number")
            End If
        End If

        If isNonNullString(transactionTailNumber) Then
            If Not isValidTailNumber(transactionTailNumber) Then
                Return transactionWarning("Invalid Tail Number Specified For Transaction", MsgBoxStyle.Exclamation, "Invalid Tail Number")
            End If
        End If

        If isNonNullString(transactionBatchID) Then
            If Not isValidBatchID(transactionBatchID) Then
                Return transactionWarning("Invalid Transaction Cart ID Number Specified For Transaction", MsgBoxStyle.Exclamation, "Invalid Tail Number")
            End If
        End If

        If isNonNullString(transactionTransferPoint) Then
            If Not isValidLocationCode(transactionTransferPoint) Then
                Return transactionWarning("Invalid Transaction Cart ID Number Specified For Transaction", MsgBoxStyle.Exclamation, "Invalid Tail Number")
            End If
        End If

        If isNonNullString(transactionDandRTag) Then
            If Not isValidDandRTag(transactionDandRTag) Then
                Return transactionWarning("Invalid D and R Tag Specified For Transaction", MsgBoxStyle.Exclamation, "Invalid Tail Number")
            End If
        End If

        Return "OK"

    End Function

    Private Function setupAndValidateOperationCode() As String

        Dim result As String

        Select Case transactionOperation

            Case "Possession"

                transactionOpCode = "P"

            Case "Load"

                transactionOpCode = "L"

                result = validateDestination()
                If result <> "OK" Then Return result

                result = validateFlightNumber()
                If result <> "OK" Then Return result

                result = validateBatchID()
                If result <> "OK" Then Return result

                validateOutboundFlight(transactionFlightNumber, transactionLocation)

            Case "Possession & Load"

                transactionOpCode = "PL"

                result = validateDestination()
                If result <> "OK" Then Return result

                result = validateFlightNumber()
                If result <> "OK" Then Return result

                result = validateBatchID()
                If result <> "OK" Then Return result

                validateOutboundFlight(transactionFlightNumber, transactionLocation)

            Case "Transfer"

                If userSpecRecord.treatTransferScansAsLoadScans Then

                    transactionOpCode = "L"

                    result = validateDestination()
                    If result <> "OK" Then Return result

                    result = validateFlightNumber()
                    If result <> "OK" Then Return result

                    result = validateBatchID()
                    If result <> "OK" Then Return result

                    validateOutboundFlight(transactionFlightNumber, transactionLocation)

                Else

                    transactionOpCode = "T"

                    result = validateDestination()
                    If result <> "OK" Then Return result

                    result = validateBatchID()
                    If result <> "OK" Then Return result

                    result = validateTransferPoint()
                    If result <> "OK" Then Return result


                    result = validateCarrierCode()
                    If result <> "OK" Then Return result

                    If isNonNullString(transactionFlightNumber) Then
                        validateOutboundFlight(transactionFlightNumber, transactionLocation)
                    End If

                End If

            Case "Unload"

                transactionOpCode = "U"

                result = validateFlightNumber()
                If result <> "OK" Then Return result

            Case "Partial Offload"

                transactionOpCode = "O"

                result = validateFlightNumber()
                If result <> "OK" Then Return result

                result = validateBatchID()
                If result <> "OK" Then Return result

                validateOutboundFlight(transactionFlightNumber, transactionLocation)

            Case "Complete Offload"

                transactionOpCode = "X"

                result = validateFlightNumber()
                If result <> "OK" Then Return result

                result = validateBatchID()
                If result <> "OK" Then Return result

                validateOutboundFlight(transactionFlightNumber, transactionLocation)

            Case "Reroute"

                transactionOpCode = "L"

                result = validateDestination()
                If result <> "OK" Then Return result

                result = validateFlightNumber()
                If result <> "OK" Then Return result

                result = validateBatchID()
                If result <> "OK" Then Return result

                validateOutboundFlight(transactionFlightNumber, transactionLocation)

            Case "Delivery"

                transactionOpCode = "D"

                If isNonNullString(transactionFlightNumber) Then
                    validateInboundFlight(transactionFlightNumber, transactionLocation)
                End If

            Case "Return"

                transactionOpCode = "R"

                result = validateRejectReason()
                If result <> "OK" Then Return result

            Case Else

                warning("Invalid or missing operation code", MsgBoxStyle.Exclamation, "Invalid Operation Code")
                Return "Invalid Operation Code"

        End Select

        Return "OK"

    End Function

    Public Function processWeightString() As String

        If Not isNonNullString(transactionWeightString) Then

            transactionResditRecord.weight = 0.0
            Return "OK"

        End If

        If transactionWeightString = "US" Then

            Dim weightResult As Integer = getWeightInExcessOf100Pounds()

            If weightResult <= 0 Then
                warning("No Weight Specified For This Item", MsgBoxStyle.Exclamation, "Missing Weight")
                Return "Missing Weight"
            End If

            transactionResditRecord.weight = weightResult

            Return "OK"

        End If

        If Not IsNumeric(transactionWeightString) Then

            warning("Invalid Weight Specified For This Item", MsgBoxStyle.Exclamation, "Invalid Weight")
            Return "Invalid Weight"

        End If

        If transactionWeightString = "00" Then
            transactionResditRecord.weight = 100.0
        Else
            transactionResditRecord.weight = CDbl(transactionWeightString)
        End If

        If transactionResditRecord.weight < 0.0 Or transactionResditRecord.weight >= 65536 Then

            warning("Invalid Weight Specified For This Item", MsgBoxStyle.Exclamation, "Invalid Weight")
            Return "Invalid Weight"

        End If

        Return "OK"

    End Function

    Public msRoutingCode As String

    Public Function validateTransactionRouting() As String

        If transactionDandRTag = "DUMMYSCANN" Then Return "OK"

        If transactionOperation = "Delivery" Then Return "OK"

        msRoutingCode = Substring(transactionDandRTag, 4, 4).ToUpper

        While Not isValidRoutingCode(msRoutingCode)

            Dim msMsgInvalidRoutingDisplay As New msMsgInvalidRouting(msRoutingCode)
            Dim result As DialogResult = msMsgInvalidRoutingDisplay.ShowDialog()

            If result = DialogResult.Cancel Then Return "Cancel"

            transactionDandRTag = transactionDandRTag.Substring(0, 4) & msRoutingCode & transactionDandRTag.Substring(8)

        End While

        If routingSet.containsRouting(msRoutingCode) Then Return "OK"

        withinAddRoutingForm = True

        Dim addRoutingsDisplayForm As New addRoutingForm(msRoutingCode)

        addRoutingsDisplayForm.ShowDialog()

        withinAddRoutingForm = False

        Return "OK"

    End Function

    Public Function validateNonDuplicateDandRTag() As String

        Dim resditRecordHashKey As String = transactionResditRecord.generateHashKey

        If userSpecRecord.resditRecordSet.ContainsKey(resditRecordHashKey) Then

            Dim localResditRecord As resditRecordClass = userSpecRecord.resditRecordSet.Item(resditRecordHashKey)

            localResditRecord.duplicateCount += 1

            If Not userSpecRecord.warnOnDuplicateScan Then Return "Duplicate Transaction Ignored"

            Dim msgBoxAnswer As MsgBoxResult = MsgBox("Duplicate Scan Item. Save Anyway?", MsgBoxStyle.YesNo, "Duplicate Scan Item")

            If msgBoxAnswer = MsgBoxResult.No Then Return "Duplicate Transaction Ignored"

        Else

            Dim newResditRecord As New resditRecordClass(transactionResditRecord)

            userSpecRecord.resditRecordSet.Add(resditRecordHashKey, transactionResditRecord)

        End If

        Return "OK"

    End Function

    Public Function loadTransactionRecordFromFields() As String

        Dim currentDate As String
        Dim currentTime As String

        currentDate = String.Format("{0:MMddyy}", scannerNow())
        currentTime = String.Format("{0:HHmm}", scannerNow())

#If ValidationLevel >= 3 Then

        If diagnosticLevel >= 2 Then
            verify(Length(transactionOpCode) >= 1, 25100)
        End If

#End If


        transactionResditRecord.scanState.parse(Substring(transactionOpCode, 0, 1))
        transactionResditRecord.locationCode = transactionLocation
        transactionResditRecord.DandRTag.parse(transactionDandRTag)
        transactionResditRecord.statusCode = "1"
        transactionResditRecord.scanDate = currentDate
        transactionResditRecord.scanTime = currentTime
        transactionResditRecord.flightNumber = transactionFlightNumber
        transactionResditRecord.tailNumber = transactionTailNumber
        transactionResditRecord.carrierCode = transactionCarrierCode
        transactionResditRecord.rejectReason = transactionRejectReason
        transactionResditRecord.groupNumber = transactionBatchID

        Return "OK"

    End Function

    Dim resditRecordQueue As New Queue

    Dim resditRecordPrimarySaveSemiphore As New Object
    Dim resditRecordSecondarySaveSemiphore As New Object

    Public Function threadedSaveNewResditRecords(ByRef resditRecord As resditRecordClass) As String

        Dim result As String

        SyncLock resditRecordPrimarySaveSemiphore

            If primaryDataFileDirectoryIsValid Then

                result = resditRecord.appendToFile(mailDataFilePath)

                If result = "OK" Then

                    If Length(resditRecord.transactionCode) > 1 Then
                        resditRecord.scanState.parse(Substring(resditRecord.transactionCode, 1, 1))
                        result = resditRecord.appendToFile(mailDataFilePath)
                    End If

                End If

                If result <> "OK" Then

                    transactionWarning("Save of resdit record failed: " & result, MsgBoxStyle.Information, "Primary transaction directory failed")
                    primaryDataFileDirectoryIsValid = False

                End If

            End If

        End SyncLock

        SyncLock resditRecordSecondarySaveSemiphore

            If secondaryDataFileDirectoryIsValid Then

                result = resditRecord.appendToFile(backupMailDataFilePath)

                If result = "OK" Then

                    If Length(resditRecord.transactionCode) > 1 Then
                        resditRecord.scanState.parse(Substring(resditRecord.transactionCode, 1, 1))
                        result = resditRecord.appendToFile(backupMailDataFilePath)
                    End If

                End If

                If result <> "OK" Then

                    transactionWarning("Save of resdit record failed: " & result, MsgBoxStyle.Information, "Secondary transaction directory failed")
                    secondaryDataFileDirectoryIsValid = False

                End If

            End If

        End SyncLock

        Return "OK"

    End Function


    Public Sub saveNewResditRecordsThread()

        Dim resditRecord As resditRecordClass

        While True

            SyncLock resditRecordQueue

                If resditRecordQueue.Count > 0 Then
                    resditRecord = resditRecordQueue.Dequeue
                Else
                    resditRecord = Nothing
                End If

            End SyncLock

            If resditRecord Is Nothing Then Exit Sub

            threadedSaveNewResditRecords(resditRecord)

        End While

    End Sub

    Public Function saveNewResditRecords() As String

        Dim newResditRecord As New resditRecordClass(transactionResditRecord)

        newResditRecord.transactionCode = transactionOpCode

        SyncLock resditRecordQueue

            resditRecordQueue.Enqueue(newResditRecord)

        End SyncLock

        Dim saveResditRecordThread As New System.Threading.Thread(AddressOf saveNewResditRecordsThread)

        saveResditRecordThread.Priority = Threading.ThreadPriority.BelowNormal

        saveResditRecordThread.Start()

        Return "OK"

    End Function

    Public Function saveUpdatedMailScanCounts() As String

        Dim countFilePath As String = deviceNonVolatileMemoryDirectory & backSlash & "MailScanPieceCounts.txt"

        deleteLocalFile(countFilePath)

        Dim countFileOutputStream As StreamWriter

        Try
            countFileOutputStream = New StreamWriter(countFilePath)
        Catch ex As Exception
            Return "Unable to create scanner counts file: " & ex.message
        End Try

        Dim outputRecord As String = Trim(activeReaderForm.mailPieceCountLabel.Text) & "," & Trim(activeReaderForm.totalWeightLabel.Text)

        Try
            countFileOutputStream.WriteLine(outputRecord)
        Catch ex As Exception
            countFileOutputStream.Close()
            Return "Write on counts file failed: " & ex.message
        End Try

        countFileOutputStream.Close()

        Return "OK"

    End Function

    Public Function updateCounts() As String

        Dim totalWeight As Double = 0.0

        If Length(activeReaderForm.totalWeightLabel.Text) > 0 Then

            If Not IsNumeric(activeReaderForm.totalWeightLabel.Text) Then
                transactionWarning("System Error: Invalid total weight value display", MsgBoxStyle.Exclamation, "Invalid Total Weight In Display")
                Stop
            End If

            If transactionOpCode = "O" Then
                totalWeight = CDbl(activeReaderForm.totalWeightLabel.Text) - transactionResditRecord.weight
            ElseIf transactionOpCode = "X" Then
                totalWeight = 0.0
            Else
                totalWeight = CDbl(activeReaderForm.totalWeightLabel.Text) + transactionResditRecord.weight
            End If

        Else
            If transactionOpCode = "O" Then
                totalWeight = -transactionResditRecord.weight
            ElseIf transactionOpCode = "X" Then
                totalWeight = 0.0
            Else
                totalWeight = transactionResditRecord.weight
            End If
        End If

        activeReaderForm.totalWeightLabel.Text = CStr(totalWeight)

        Dim pieceCount As Integer

        If transactionOpCode = "O" Then
            pieceCount = -1
        ElseIf transactionOpCode = "X" Then
            pieceCount = 0
        Else
            pieceCount = 1
        End If

        If Length(activeReaderForm.mailPieceCountLabel.Text) > 0 Then

            If Not IsNumeric(activeReaderForm.mailPieceCountLabel.Text) Then
                transactionWarning("System Error: Invalid piece count value display", MsgBoxStyle.Exclamation, "Invalid Piece Count Value")
                Stop
            End If

            If transactionOpCode = "O" Then
                pieceCount = CInt(activeReaderForm.mailPieceCountLabel.Text) - 1
            ElseIf transactionOpCode = "X" Then
                pieceCount = 0
            Else
                pieceCount = CInt(activeReaderForm.mailPieceCountLabel.Text) + 1
            End If

        End If

        activeReaderForm.mailPieceCountLabel.Text = CStr(pieceCount)

        saveUpdatedMailScanCounts()

        Return "OK"

    End Function

    Public Function processMailScanTransaction() As String

        transactionResditRecord.reset()

        Dim result As String

        logScanEvent(40100, " Entering processMailScanTransaction")

        If activeReaderForm Is Nothing Then
            logScanSequenceEvent(40200, "Attempt to do mail scan with inactive reader form.")
            Return "Active Reader Form Not Instantiated."
        End If

        'logScanEvent(40101, " Setting Up Transaction Fields")

        result = setupAndConditionTransactionDataFromReaderForm()
        If result <> "OK" Then Return result

        'logScanEvent(40102, " Validating Non-Null Fields")

        result = validateNonNullFields()
        If result <> "OK" Then Return result

        'logScanEvent(40103, " Validating Operation Code")

        result = setupAndValidateOperationCode()
        If result <> "OK" Then Return result

        'logScanEvent(40104, " Validating D and R Tag")

        result = validateDandRTag()
        If result <> "OK" Then Return result

        'logScanEvent(40105, " Processing Weight String")

        result = processWeightString()
        If result <> "OK" Then Return result

        'logScanEvent(40106, " Validating Transaction Routing")

        result = validateTransactionRouting()
        If result <> "OK" Then Return result

        'logScanEvent(40107, " Building Transaction Record")

        result = loadTransactionRecordFromFields()
        If result <> "OK" Then Return result

        If (transactionOpCode = "L" Or transactionOpCode = "PL") And userSpecRecord.loadScansRequireSelectionFromPreset Then

            logScanEvent(40108, " Validating Load Operation From Preset")

            If Not activeReaderForm.currentScanScreenPopulatedFromPreset Then
                MsgBox("You Must Select A Preset Record Before Doing A Load Scan. Current Scan Ignored.", MsgBoxStyle.Exclamation, "No Preset Selected For Scan")
                Exit Function
            End If

            Dim presetRecord As presetRecordClass = lastSelectedPresetForScanScreen

            If presetRecord.isReroutePreset Then
                transactionResditRecord.oldDestinationCode = presetRecord.destination
                transactionResditRecord.oldFlightNumber = presetRecord.flightNumber
            End If

        End If

        If transactionOpCode = "T" Then
            transactionResditRecord.destinationCode = transactionTransferPoint
        Else
            transactionResditRecord.destinationCode = transactionDestination
        End If

        activeReaderForm.saveButton.Enabled = False

        'logScanEvent(40109, " Validating Non-Duplicate D and R Tag")

        result = validateNonDuplicateDandRTag()

        If result = "Duplicate Transaction Ignored" Then Return "OK"
        If result <> "OK" Then Return result

        If transactionOpCode = "P" Or transactionOpCode = "PL" Then

            logScanEvent(40110, " Updating Global Scan Counts")

            updateGlobalScanCount()
            transactionResditRecord.globalScanCountOnCreation = globalScanCount

        End If

        logScanEvent(40111, " Saving Resdit Record")

        result = saveNewResditRecords()
        If result <> "OK" Then Return result

        logScanEvent(40112, " Updating Counts")

        result = updateCounts()
        If result <> "OK" Then Return result

        logScanEvent(40113, " Exiting Process Transaction")

        Return "OK"

    End Function

End Module
