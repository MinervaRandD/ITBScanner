Imports System
Imports System.io

Module baggageScanTransaction

    Private transactionTagID As String = ""
    Private transactionFlightNumber As String = ""
    Private transactionLocation As String = ""
    Private transactionCarrierCode As String = ""
    Private transactionACBinID As String = ""
    Private transactionHoldPosition As String = ""
    Private transactionContainerPosition As String = ""
    Private transactionOperation As String = ""
    Private transactionOpCode As String = ""

    Public baggageRecord As New baggageRecordClass

    Public baggageFilePath As String
    Public baggageFileDirectory As String
    Public baggageFileName As String

    Public operationSet() As String = {"Check Baggage", "Load", "Transfer Online", "Transfer OAL", "Unload", "Delivery"}

    Public baggageRecordSet As New Hashtable

    Public transactionScanDateAndTime As DateTime = #1/1/1900#

    Private Function baggageTransactionWarning(ByVal warningString As String, ByVal msgType As MsgBoxStyle, ByVal warningTitle As String) As String

        warning(warningString, msgType, warningTitle)
        Return warningTitle

    End Function

    Private Function validateBaggageOperation() As String

        If Not isNonNullString(transactionOperation) Then
            Return baggageTransactionWarning("Missing Operation", MsgBoxStyle.Exclamation, "Missing Operation")
        End If

        Dim operation As String

        For Each operation In operationSet
            If transactionOperation = operation Then Return "OK"
        Next

        Return baggageTransactionWarning("Invalid Operation: " & transactionOperation, MsgBoxStyle.Exclamation, "Invalid Operation")

    End Function

    Private Function validateBaggageFlightNumber() As String

        If isNonNullString(transactionFlightNumber) Then Return "OK"

        If Not isValidFlightNumber(transactionFlightNumber) Then
            Return baggageTransactionWarning("A Valid Flight Number Is Required For This Operation", MsgBoxStyle.Exclamation, "Invalid Flight Number")
        End If

        Return "OK"

    End Function

    Private Function validateCarrierCode() As String

        If Length(transactionCarrierCode) <= 1 Then
            Return baggageTransactionWarning("A Valid Carrier Code Is Required For This Operation", MsgBoxStyle.Exclamation, "Invalid Carrier Code")
        End If

        Return "OK"

    End Function

    Private Function validateBaggageTagID() As String

        If Not isNonNullString(transactionTagID) Then
            Return baggageTransactionWarning("Missing Transaction Tag ID", MsgBoxStyle.Exclamation, "Missing Transaction Tag ID")
        End If

        If Length(transactionTagID) > 12 Then
            Return baggageTransactionWarning("Invalid transaction tag id: Too Many Characters", MsgBoxStyle.Exclamation, "Missing Transaction Tag ID")
        End If

        Return "OK"

    End Function

    Private Function validateBaggageACBinID() As String

        If Not isNonNullString(transactionACBinID) Then Return "OK"

        If Not isValidACBinID(transactionACBinID) Then
            Return baggageTransactionWarning("A Valid A/C Cart ID is required For This Operation", MsgBoxStyle.Exclamation, "Invalid A/C Cart ID")
        End If

        Return "OK"

    End Function

    Private Function validateLocation() As String

        If Not isNonNullString(transactionLocation) Then
            Return baggageTransactionWarning("A Valid Location Is Required For This Operation", MsgBoxStyle.Exclamation, "Invalid Location")

        End If

        If Not isValidLocation(transactionLocation) Then
            Return baggageTransactionWarning("A Valid Location Is Required For This Operation", MsgBoxStyle.Exclamation, "Invalid Location")
        End If

        Return "OK"

    End Function

    Private Function validateBaggageContainerPosition() As String

        If Not isNonNullString(transactionContainerPosition) Then Return "OK"

        If Not isValidBaggageContainerPosition(transactionContainerPosition) Then
            Return baggageTransactionWarning("A Valid Container is required For This Operation", MsgBoxStyle.Exclamation, "Invalid Container")
        End If

        Return "OK"

    End Function

    Private Function validateBaggageHoldPosition() As String

        If Not isNonNullString(transactionHoldPosition) Then Return "OK"

        If Not isValidBaggageHoldPosition(transactionHoldPosition) Then
            Return baggageTransactionWarning("A valid hold position is required For This Operation", MsgBoxStyle.Exclamation, "Invalid Hold Position")
        End If

        Return "OK"

    End Function

    Private Function validateNonNullBaggageFields() As String

        Dim result As String

        result = validateBaggageTagID()
        If result <> "OK" Then Return result

        result = validateBaggageOperation()
        If result <> "OK" Then Return result

        result = validateBaggageACBinID()
        If result <> "OK" Then Return result

        result = validateBaggageFlightNumber()
        If result <> "OK" Then Return result

        result = validateBaggageContainerPosition()
        If result <> "OK" Then Return result

        result = validateBaggageHoldPosition()
        If result <> "OK" Then Return result

        result = validateLocation()
        If result <> "OK" Then Return result

        result = validateCarrierCode()
        If result <> "OK" Then Return result

        Return "OK"

    End Function

    Private Function setupAndValidateBaggageOpCode() As String

        Dim result As String

        Select Case transactionOperation

            Case "Check Baggage"
                transactionOpCode = "C"
            Case "Load"
                transactionOpCode = "L"
            Case "Transfer Online"
                transactionOpCode = "T"
            Case "Transfer OAL"
                transactionOpCode = "X"
            Case "Unload"
                transactionOpCode = "U"
            Case "Delivery"
                transactionOpCode = "D"

            Case Else

                warning("Invalid or missing Operation code", MsgBoxStyle.Exclamation, "Invalid Operation Code")
                Return "Invalid Operation Code"

        End Select

        Return "OK"

    End Function

    Public Function validateNonDuplicateBaggageTagID() As String

        Dim baggageRecordHashKey As String = baggageRecord.GetHashKey

        If baggageRecordSet.ContainsKey(baggageRecordHashKey) Then

            Dim localbaggageRecord As baggageRecordClass = baggageRecordSet.Item(baggageRecordHashKey)

            localbaggageRecord.duplicateCount += 1

            If Not userSpecRecord.warnOnDuplicateScan Then Return "Duplicate Transaction Ignored"

            Dim msgBoxAnswer As MsgBoxResult = MsgBox("Duplicate Scan Item. Save Anyway?", MsgBoxStyle.YesNo, "Duplicate Scan Item")

            If msgBoxAnswer = MsgBoxResult.No Then Return "Duplicate Transaction Ignored"

        Else

            Dim newbaggageRecord As New baggageRecordClass(baggageRecord)

            baggageRecordSet.Add(baggageRecordHashKey, baggageRecord)

        End If

        Return "OK"

    End Function

    Public Function loadBaggageTransactionRecordFromFields() As String

        baggageRecord.baggageTagID = transactionTagID
        baggageRecord.baggageFlightNumber = transactionFlightNumber
        baggageRecord.baggageLocation = transactionLocation
        baggageRecord.baggageCarrierCode = transactionCarrierCode
        baggageRecord.baggageACBinID = transactionACBinID
        baggageRecord.baggageHoldPosition = transactionHoldPosition
        baggageRecord.baggageContainerPosition = transactionContainerPosition
        baggageRecord.baggageOpCode = transactionOpCode
        baggageRecord.baggageOperation = transactionOperation

        Return "OK"

    End Function

    Dim baggageRecordQueue As New Queue

    Dim baggageRecordPrimarySaveSemiphore As New Object
    Dim baggageRecordSecondarySaveSemiphore As New Object

    Public Function threadedSaveNewBaggageRecords(ByRef baggageRecord As baggageRecordClass) As String

        Dim result As String

        SyncLock baggageRecordPrimarySaveSemiphore

            If primaryDataFileDirectoryIsValid Then

                result = baggageRecord.appendToFile(baggageFilePath)

                If result <> "OK" Then

                    baggageTransactionWarning("Save of baggage record failed: " & result, MsgBoxStyle.Information, "Primary transaction directory failed")
                    primaryDataFileDirectoryIsValid = False

                End If

            End If

        End SyncLock

        SyncLock baggageRecordSecondarySaveSemiphore

            If secondaryDataFileDirectoryIsValid Then

                result = baggageRecord.appendToFile(backupBaggageFilePath)

                If result <> "OK" Then

                    baggageTransactionWarning("Save of baggage record failed: " & result, MsgBoxStyle.Information, "Secondary transaction directory failed")
                    secondaryDataFileDirectoryIsValid = False

                End If

            End If

        End SyncLock

        Return "OK"

    End Function

    Public Sub saveNewBaggageRecordsThread()

        Dim baggageRecord As baggageRecordClass

        While True

            SyncLock baggageRecordQueue

                If baggageRecordQueue.Count > 0 Then
                    baggageRecord = baggageRecordQueue.Dequeue
                Else
                    baggageRecord = Nothing
                End If

            End SyncLock

            If baggageRecord Is Nothing Then Exit Sub

            threadedSaveNewBaggageRecords(baggageRecord)

        End While

    End Sub

    Public Function saveNewBaggageRecords() As String

        Dim newBaggageRecord As New baggageRecordClass(baggageRecord)

        newBaggageRecord.baggageOpCode = transactionOpCode

        SyncLock baggageRecordQueue

            baggageRecordQueue.Enqueue(newBaggageRecord)

        End SyncLock

        Dim saveBaggageRecordThread As New System.Threading.Thread(AddressOf saveNewBaggageRecordsThread)

        saveBaggageRecordThread.Priority = Threading.ThreadPriority.BelowNormal

        saveBaggageRecordThread.Start()

        Return "OK"

    End Function

    Public Function saveUpdatedBaggageScanCounts() As String

        Dim countFilePath As String = deviceNonVolatileMemoryDirectory & backSlash & "BaggageScanPieceCounts.txt"

        deleteLocalFile(countFilePath)

        Dim countFileOutputStream As StreamWriter

        Try
            countFileOutputStream = New StreamWriter(countFilePath)
        Catch ex As Exception
            Return "Unable to create baggage scan counts file: " & ex.message
        End Try

        Dim outputRecord As String = Trim(tagTrakFormRepository.luggageScanForm.baggagePieceCountLabel.Text)

        Try
            countFileOutputStream.WriteLine(outputRecord)
        Catch ex As Exception
            countFileOutputStream.Close()
            Return "Write on counts file failed: " & ex.message
        End Try

        countFileOutputStream.Close()

        Return "OK"

    End Function

    Private Function setupAndConditionBaggageTransactionDataFromReaderForm() As String

        With tagTrakFormRepository.luggageScanForm

            If isNonNullString(.baggageOperationComboBox.Text) Then
                transactionOperation = Trim(.baggageOperationComboBox.Text)
            Else
                transactionOperation = ""
            End If

            If Not isNonNullString(transactionOperation) Then
                logScanSequenceEvent(41100, " Transaction rejected: no Operation code specified")
                Return baggageTransactionWarning("Please Select An Operation", MsgBoxStyle.Exclamation, "No Operation Selected")
            End If

            If isNonNullString(tagTrakFormRepository.luggageScanForm.baggageTagIDTextBox.Text) Then
                transactionTagID = Trim(.baggageTagIDTextBox.Text)
            Else
                transactionTagID = ""
            End If

            .baggageTagIDTextBox.Text = transactionTagID

            If isNonNullString(.baggageACBinIDTextBox.Text) Then
                transactionACBinID = Trim(.baggageACBinIDTextBox.Text)
            Else
                transactionACBinID = ""
            End If

            .baggageACBinIDTextBox.Text = transactionACBinID

            If isNonNullString(.baggageFlightNumberTextBox.Text) Then
                transactionFlightNumber = Trim(.baggageFlightNumberTextBox.Text)
            Else
                transactionFlightNumber = ""
            End If

            .baggageFlightNumberTextBox.Text = transactionFlightNumber

            If isNonNullString(.baggageContainerPositionTextBox.Text) Then
                transactionContainerPosition = Trim(.baggageContainerPositionTextBox.Text)
            Else
                transactionContainerPosition = ""
            End If

            .baggageContainerPositionTextBox.Text = transactionContainerPosition

            If isNonNullString(.baggageHoldPositionTextBox.Text) Then
                transactionHoldPosition = Trim(.baggageHoldPositionTextBox.Text)
            Else
                transactionHoldPosition = ""
            End If

            .baggageHoldPositionTextBox.Text = transactionHoldPosition

            If isNonNullString(.baggageLocationLabel.Text) Then
                transactionLocation = Trim(.baggageLocationLabel.Text)
            Else
                transactionLocation = ""
            End If

            If Length(transactionLocation) < 3 Then
                logScanSequenceEvent(41100, " Transaction rejected: invalid location code: " & transactionLocation)
                Return baggageTransactionWarning("The current location is invalid.", MsgBoxStyle.Exclamation, "Invalid Location")
            End If

            scanSequenceVerify(Length(transactionLocation) >= 3, 10)

            transactionLocation = Substring(transactionLocation, 0, 3)

            MsgBox("Review the following.")

            'If isNonNullString(.mailCarrierCodeLabel.Text) Then
            '    transactionCarrierCode = Trim(.mailCarrierCodeLabel.Text)
            'Else
            '    transactionCarrierCode = ""
            'End If

        End With

        Return "OK"

    End Function

    Public Function processBaggageScanTransaction() As String

        transactionScanDateAndTime = DateTime.UtcNow

        baggageRecord.reset()

        Dim result As String

        logScanEvent(40100, " Entering processBaggageScanTransaction")

        If activeReaderForm Is Nothing Then
            logScanSequenceEvent(40200, "Attempt to do baggage scan with inactive reader form.")
            Return "Active Reader Form Not Instantiated."
        End If

        logScanEvent(40101, " Setting Up Baggage Transaction Fields")

        result = setupAndConditionBaggageTransactionDataFromReaderForm()
        If result <> "OK" Then Return result

        logScanEvent(40102, " Validating Non-Null Fields")

        result = validateNonNullBaggageFields()
        If result <> "OK" Then Return result

        logScanEvent(40103, " Validating Operation Code")

        result = setupAndValidateBaggageOpCode()
        If result <> "OK" Then Return result

        logScanEvent(40107, " Building Transaction Record")

        result = loadBaggageTransactionRecordFromFields()
        If result <> "OK" Then Return result

        logScanEvent(40104, " Validating Air Waybill")

        result = validateNonDuplicateBaggageTagID()

        If result = "Duplicate Transaction Ignored" Then Return "OK"
        If result <> "OK" Then Return result

        result = saveNewBaggageRecords()
        If result <> "OK" Then Return result

        Return "OK"

    End Function

End Module