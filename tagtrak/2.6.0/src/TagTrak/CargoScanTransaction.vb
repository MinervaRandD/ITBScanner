Imports System
Imports System.io

Module cargoScanTransaction

    Private transactionScanDateAndTime As DateTime
    Private transactionAirWaybillNumber As String = ""
    Private transactionACBinID As String = ""
    Private transactionFlightNumber As String = ""
    Private transactionDestination As String = ""
    Private transactionLocation As String = ""
    Private transactionCarrierCode As String = ""
    Private transactionOperation As String = ""
    Private transactionHazmat As Boolean = False
    Private transactionPieces As String = ""
    Private transactionWeight As String = ""
    Private transactionTransCarrier As String = ""
    Private transactionShelf As String = ""
    Private transactionBin As String = ""
    Private transactionOldFlightNumber As String = ""


    Private transactionOpCode As String = ""

    Private operationSet() As String = {"Acceptance", "Load", "Unload", "Delivery", "Offload", "Offline Transfer", "Online Transfer", "Warehouse Move"}

    Public cargoFilePath As String
    Public cargoFileDirectory As String
    Public cargoFileName As String

    Private scanRecord As New scanRecordClass
    Private cargoRecord As New CargoScanRecordClass

    Private Function cargoTransactionWarning(ByVal warningString As String, ByVal msgType As MsgBoxStyle, ByVal warningTitle As String) As String

        Util.warning(warningString, msgType, warningTitle)
        Return warningTitle

    End Function

    Private Function validateCargoOperation() As String

        If Not isNonNullString(transactionOperation) Then
            Return cargoTransactionWarning("Missing Operation", MsgBoxStyle.Exclamation, "Missing Operation")
        End If

        Dim cargoOperation As String

        For Each cargoOperation In operationSet
            If transactionOperation = cargoOperation Then Return "OK"
        Next

        Return cargoTransactionWarning("Invalid Operation: " & transactionOperation, MsgBoxStyle.Exclamation, "Invalid Operation")

    End Function

    Private Function validateCargoAirWaybillNumber() As String

        If Not isNonNullString(transactionAirWaybillNumber) Then
            Return cargoTransactionWarning("Missing Air Waybill Number", MsgBoxStyle.Exclamation, "Missing Air Waybill Number")
        End If

        Dim len As Integer = transactionAirWaybillNumber.Length

        If len <> 11 And len <> 15 Then
            Return cargoTransactionWarning("Invalid air waybill number", MsgBoxStyle.Exclamation, "Invalid Air Waybill Number")
        End If

        Return "OK"

    End Function

    Private Function validateCargoACBinID() As String

        If Not isNonNullString(transactionACBinID) Then Return "OK"

        If Not Util.isValidACBinID(transactionACBinID) Then
            Return cargoTransactionWarning("A Valid A/C Cart ID is required For This Operation", MsgBoxStyle.Exclamation, "Invalid A/C Cart ID")
        End If

        Return "OK"

    End Function

    Private Function validateCargoFlightNumber() As String

        If isNonNullString(transactionFlightNumber) Then Return "OK"

        If Not Util.isValidFlightNumber(transactionFlightNumber) Then
            Return cargoTransactionWarning("A Valid Flight Number Is Required For This Operation", MsgBoxStyle.Exclamation, "Invalid Flight Number")
        End If

        Return "OK"

    End Function

    Private Function validateCargoDestination() As String

        If Not isNonNullString(transactionDestination) Then Return "OK"

        If Not Util.isValidLocation(transactionDestination) Then
            Return cargoTransactionWarning("A Valid Destination Is Required For This Operation", MsgBoxStyle.Exclamation, "Invalid Destination")
        End If

        Return "OK"

    End Function

    Private Function validateCargoLocation() As String

        If Not isNonNullString(transactionLocation) Then
            Return cargoTransactionWarning("A Valid Location Is Required For This Operation", MsgBoxStyle.Exclamation, "Invalid Location")

        End If

        If Not Util.isValidLocation(transactionLocation) Then
            Return cargoTransactionWarning("A Valid Location Is Required For This Operation", MsgBoxStyle.Exclamation, "Invalid Location")
        End If

        Return "OK"

    End Function

    Private Function validateCargoCarrierCode() As String

        If Length(transactionCarrierCode) <= 1 Then
            Return cargoTransactionWarning("A Valid Carrier Code Is Required For This Operation", MsgBoxStyle.Exclamation, "Invalid Carrier Code")
        End If

        Return "OK"

    End Function

    Private Function validateOldFlightNumber() As String

        If Not isNonNullString(transactionOldFlightNumber) Then Return "OK"

        If Not Util.isValidFlightNumber(transactionOldFlightNumber) Then
            Return cargoTransactionWarning("A Valid Old Flight Number Is Required For This Operation", MsgBoxStyle.Exclamation, "Invalid Old Flight Number")
        End If

        Return "OK"

    End Function

    Private Function validateNonNullCargoFields() As String

        Dim result As String

        result = validateCargoOperation()
        If result <> "OK" Then Return result

        result = validateCargoAirWaybillNumber()
        If result <> "OK" Then Return result

        result = validateCargoACBinID()
        If result <> "OK" Then Return result

        result = validateCargoFlightNumber()
        If result <> "OK" Then Return result

        result = validateCargoDestination()
        If result <> "OK" Then Return result

        result = validateCargoLocation()
        If result <> "OK" Then Return result

        result = validateCargoCarrierCode()
        If result <> "OK" Then Return result

        result = validateOldFlightNumber()
        If result <> "OK" Then Return result

        Return "OK"

    End Function

    Private Function setupAndValidateCargoOperationCode() As String

        Dim result As String

        Select Case transactionOperation

            Case "Acceptance"

                transactionOpCode = "A"

            Case "Load"

                transactionOpCode = "L"

            Case "Unload"

                transactionOpCode = "U"

            Case "Offload"

                transactionOpCode = "O"

            Case "Offline Transfer"

                transactionOpCode = "T"

            Case "Delivery"

                transactionOpCode = "D"

            Case "Online Transfer"

                transactionOpCode = "X"

            Case "Warehouse Move"

                transactionOpCode = "W"

            Case Else

                Util.warning("Invalid or missing operation code", MsgBoxStyle.Exclamation, "Invalid Operation Code")
                Return "Invalid Operation Code"

        End Select

        Return "OK"

    End Function


    Public Function saveUpdatedCargoScanCounts(ByVal cargoScanBaseForm As CargoScanBaseForm) As String

        Dim countFilePath As String = deviceNonVolatileMemoryDirectory & "\" & selectedCarrierPath & backSlash & "CargoScanPieceCounts.txt"

        deleteLocalFile(countFilePath)

        Dim countFileOutputStream As StreamWriter

        Try
            countFileOutputStream = New StreamWriter(countFilePath)
        Catch ex As Exception
            Return "Unable to create cargo scan counts file: " & ex.message
        End Try

        Dim outputRecord As String = Trim(cargoScanBaseForm.PieceCount.Text)

        Try
            countFileOutputStream.WriteLine(outputRecord)
        Catch ex As Exception
            countFileOutputStream.Close()
            Return "Write on counts file failed: " & ex.message
        End Try

        countFileOutputStream.Close()

        Return "OK"

    End Function

    Private Function setupAndConditionCargoTransactionDataFromReaderForm(ByVal cargoScanBaseForm As CargoScanBaseForm) As String

        With cargoScanBaseForm

            If isNonNullString(.Operations.Text) Then
                transactionOperation = Trim(.Operations.Text)
            Else
                transactionOperation = ""
            End If

            If Not isNonNullString(transactionOperation) Then
                logScanSequenceEvent(41100, " Transaction rejected: no operation code specified")
                Return cargoTransactionWarning("Please Select An Operation", MsgBoxStyle.Exclamation, "No Operation Selected")
            End If

            If isNonNullString(.AirwayBill.Text) Then

                'Modified by MX
                If Trim(.AirwayBill.Text).Length = 16 Then
                    .AirwayBill.Text = Trim(.AirwayBill.Text).Remove(11, 1)
                End If

                transactionAirWaybillNumber = Trim(.AirwayBill.Text)
            Else
                transactionAirWaybillNumber = ""
            End If

            .AirwayBill.Text = transactionAirWaybillNumber

            If isNonNullString(.AcCartId.Text) Then
                transactionACBinID = Trim(.AcCartId.Text)
            Else
                transactionACBinID = ""
            End If

            .AcCartId.Text = transactionACBinID

            If isNonNullString(.Flight.Text) Then
                transactionFlightNumber = Trim(.Flight.Text)
            Else
                transactionFlightNumber = ""
            End If

            .Flight.Text = transactionFlightNumber

            If isNonNullString(.Destination.Text) Then
                transactionDestination = Trim(.Destination.Text)
            Else
                transactionDestination = ""
            End If

            .Destination.Text = transactionDestination

            If isNonNullString(.ScanLocation.Text) Then
                transactionLocation = Trim(.ScanLocation.Text)
            Else
                transactionLocation = ""
            End If

            If Length(transactionLocation) < 3 Then
                logScanSequenceEvent(41100, " Transaction rejected: invalid location code: " & transactionLocation)
                Return cargoTransactionWarning("The current location is invalid.", MsgBoxStyle.Exclamation, "Invalid Location")
            End If

            If isNonNullString(.Carrier.Text) Then
                transactionCarrierCode = Trim(.Carrier.Text)
            Else
                transactionCarrierCode = ""
            End If

            If isNonNullString(.Pieces.Text) Then
                transactionPieces = Trim(.Pieces.Text)
            Else
                transactionPieces = ""
            End If

            If isNonNullString(.Weight.Text) Then
                transactionWeight = Trim(.Weight.Text)
            Else
                transactionWeight = ""
            End If

            If isNonNullString(.txtShelf.Text) Then
                transactionShelf = Trim(.txtShelf.Text)
            Else
                transactionShelf = ""
            End If

            If isNonNullString(.txtBin.Text) Then
                transactionBin = Trim(.txtBin.Text)
            Else
                transactionBin = ""
            End If

            If isNonNullString(.OldFlight.Text) Then
                transactionOldFlightNumber = Trim(.OldFlight.Text)
            Else
                transactionOldFlightNumber = ""
            End If

            .OldFlight.Text = transactionOldFlightNumber

            transactionHazmat = .Hazmat.Checked

            Util.scanSequenceVerify(Length(transactionLocation) >= 3, 10)

            transactionLocation = Substring(transactionLocation, 0, 3)

        End With

        Return "OK"

    End Function

    Public Function processCargoScanData(ByVal scanForm As CargoScanBaseForm) As String

        Dim result As String

        result = setupAndConditionCargoTransactionDataFromReaderForm(scanForm)
        If result <> "OK" Then Return result

        result = setupAndValidateCargoOperationCode()
        If result <> "OK" Then Return result

        result = loadScanRecord()
        If result <> "OK" Then : scanForm.AirwayBill.Text = "" : Return result : End If


        result = validateNonNullCargoFields()
        If result <> "OK" Then Return result

        result = verifyNonDuplicateScan()
        If result <> "OK" Then Return result



        userSpecRecord.scanRecordSet.addRecord(scanRecord.CreateCopy())

        If isNonNullString(scanForm.Pieces.Text) Then
            scanForm.PieceCount.Text += Integer.Parse(scanForm.Pieces.Text)
        End If

        If isNonNullString(scanForm.Weight.Text) Then
            scanForm.TotalWeight.Text += Integer.Parse(scanForm.Weight.Text)
        End If

        saveCounters(scanForm.PieceCount, scanForm.TotalWeight, "CargoPieceCounts.txt")

        Return "OK"

    End Function

    Private Function loadScanRecord() As String

        scanRecord.scanType = "C"
        scanRecord.scanOp = transactionOpCode
        scanRecord.scanCode = transactionAirWaybillNumber
        scanRecord.scanLoc = transactionLocation
        scanRecord.scanDateAndTime = DateTime.Now
        scanRecord.carrierCode = transactionCarrierCode
        scanRecord.flightNumber = transactionFlightNumber
        scanRecord.destination = transactionDestination

        cargoRecord.cartID = transactionACBinID
        cargoRecord.hazmatFlag = transactionHazmat
        cargoRecord.pieces = transactionPieces
        cargoRecord.weight = transactionWeight
        cargoRecord.transCarrier = transactionTransCarrier
        cargoRecord.shelf = transactionShelf
        cargoRecord.bin = transactionBin
        cargoRecord.oldFlightNumber = transactionOldFlightNumber

        scanRecord.scanRecord = cargoRecord

        Return "OK"

    End Function

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


End Module