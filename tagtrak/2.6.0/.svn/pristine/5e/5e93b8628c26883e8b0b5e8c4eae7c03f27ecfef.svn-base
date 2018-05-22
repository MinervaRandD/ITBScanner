' Copyright (c) 2003-2004 Airline Software, Inc.,
' All Rights Reserved. 
' Reproduction of this document in whole or in part without written permission of   
' Airline Software, Inc. is strictly prohibited.
'
' Airline Software, Inc., Confidential - Restricted Access
'
' This document contains proprietary information that shall be
' distributed or routed only within Airline Software, Inc.,
' and its authorized clients, except with written permission of
' Airline Software, Inc. 

Imports System
Imports System.IO

Public Class resditRecordClass

    Inherits shippedItemRecordClass

    Public scanState As New scanStateClass
    Public locationCode As String
    Public statusCode As String
    Public scanDate As String
    Public scanTime As String
    Public flightNumber As String
    Public destinationCode As String
    Public tailNumber As String
    Public carrierCode As String
    Public rejectReason As String
    Public groupNumber As String
    Public oldFlightNumber As String
    Public oldDestinationCode As String
    Public globalScanCountOnCreation As Integer = 0
    Public duplicateCount As Integer = 0

    Public transactionCode As String

    'Public delCode As String

    Public Const scanStateFieldWidth = 1
    Public Const locationCodeFieldWidth = 3
    Public Const statusCodeFieldWidth = 1
    Public Const scanDateFieldWidth = 6
    Public Const scanTimeFieldWidth = 6
    Public Const DandRTagFieldWidth = 10
    Public Const weightStringFieldWidth = 2
    Public Const flightNumberFieldWidth = 4
    Public Const destinationCodeFieldWidth = 3
    Public Const tailNumberFieldWidth = 6
    Public Const carrierCodeFieldWidth = 2
    Public Const rejectReasonFieldWidth = 6
    Public Const groupNumberFieldWidth = 10
    Public Const delCodeFieldWidth = 1

    Public Const scanStateFieldLocationStart = 0
    Public Const locationCodeFieldLocationStart = 1
    Public Const statusCodeFieldLocationStart = 4
    Public Const scanDateFieldLocationStart = 5
    Public Const scanTimeFieldLocationStart = 11
    Public Const DandRTagFieldLocationStart = 17
    Public Const weightStringFieldLocationStart = 27
    Public Const flightNumberFieldLocationStart = 30
    Public Const destinationCodeFieldLocationStart = 36
    Public Const tailNumberFieldLocationStart = 39
    Public Const carrierCodeFieldLocationStart = 45
    Public Const rejectReasonFieldLocationStart = 47
    Public Const groupNumberFieldLocationStart = 53
    Public Const delCodeFieldLocationStart = 95

    Public Sub reset()

        scanState.reset()

        locationCode = ""
        statusCode = ""
        scanDate = ""
        scanTime = ""
        flightNumber = ""
        destinationCode = ""
        tailNumber = ""
        carrierCode = ""
        rejectReason = ""
        groupNumber = ""
        oldFlightNumber = ""
        oldDestinationCode = ""

        transactionCode = ""

        globalScanCountOnCreation = 0
        duplicateCount = 0

    End Sub

    Public Sub New()
        MyBase.New()
        duplicateCount = 0
        globalScanCountOnCreation = globalScanCount
    End Sub

    Public Sub New(ByRef initString As String)

#if ValidationLevel >= 3 then
        if diagnosticLevel >= 2 then
            verify(not initString is nothing, 13000)
        end if
#end if

        If initString.StartsWith("_ASI_") Then
            Me.parseASI(initString)
        Else
            Me.parseNormal(initString)
        End If

        oldFlightNumber = ""
        oldDestinationCode = ""

        duplicateCount = 0
        globalScanCountOnCreation = globalScanCount

    End Sub

    Public Sub New(ByRef initString As String, ByRef formatType As String)

#if ValidationLevel >= 3

        if diagnosticLevel >= 2 then
            verify(not initString is nothing, 13010)
            verify(Not formatType Is Nothing, 13011)
        end if

#end if


        If formatType = "Normal" Then
            Me.parseNormal(initString)
        ElseIf formatType = "ASI" Then
            Me.parseASI(initString)
        End If

        oldFlightNumber = ""
        oldDestinationCode = ""

        duplicateCount = 0
        globalScanCountOnCreation = globalScanCount

    End Sub

    Public Sub New(ByRef inputResditRecord As resditRecordClass)

#if ValidationLevel >= 3

        if diagnosticLevel >= 2 then
            verify(not inputResditRecord is nothing, 13020)
        end if

#end if

        Me.scanState.scanStateValue = inputResditRecord.scanState.scanStateValue
        Me.locationCode = inputResditRecord.locationCode
        Me.statusCode = inputResditRecord.statusCode
        Me.scanDate = inputResditRecord.scanDate
        Me.scanTime = inputResditRecord.scanTime
        Me.flightNumber = inputResditRecord.flightNumber
        Me.destinationCode = inputResditRecord.destinationCode
        Me.tailNumber = inputResditRecord.tailNumber
        Me.carrierCode = inputResditRecord.carrierCode
        Me.rejectReason = inputResditRecord.rejectReason
        Me.groupNumber = inputResditRecord.groupNumber
        Me.DandRTag.DandRTagValue = inputResditRecord.DandRTag.DandRTagValue
        Me.weight = inputResditRecord.weight

        Me.oldFlightNumber = inputResditRecord.oldFlightNumber
        Me.oldDestinationCode = inputResditRecord.oldDestinationCode

        Me.transactionCode = inputResditRecord.transactionCode

        globalScanCountOnCreation = globalScanCount
        duplicateCount = 0

    End Sub

    Public Function formatNormal() As String

        Dim returnString As String
        Dim formatString As String
        Dim weightString As String
        Dim scanTimeString As String
        Dim flightNumberString As String
        Dim weightValue As Integer

        weightValue = CInt(weight)

        If weightValue < 0 Then
            weightString = "00"
        ElseIf weightValue < 10 Then
            weightString = "0" & weightValue
        ElseIf weight < 100 Then
            weightString = weightValue
        Else
            weightString = "US"
        End If


        If Length(scanTime) = 4 Then

#If ValidationLevel >= 3 Then

            If diagnosticLevel >= 2 Then
                verify(IsNumeric(scanTime), 14000)
            End If

#End If

            Dim hh As Integer = Substring(scanTime, 0, 2)
            Dim mm As Integer = Substring(scanTime, 2, 2)

            Dim hhString As String = CStr(hh).PadLeft(2, "0")
            Dim mmString As String = CStr(mm).PadLeft(2, "0")

            Dim AMPMValue As String

            If hh = 0 Then

                hhString = "12"
                AMPMValue = "AM"

                ' The following patch requested by Gordon. Never have "1200AM"

                If mmString = "00" Then mmString = "01"

            ElseIf hh > 0 And hh < 12 Then

                AMPMValue = "AM"

            ElseIf hh = 12 Then

                AMPMValue = "PM"

                ' The following patch requested by Gordon. Never have "1200PM"

                If mmString = "00" Then mmString = "01"

            ElseIf hh > 12 Then

                hhString = CStr(hh - 12).PadLeft(2, "0")
                AMPMValue = "PM"

            End If

            scanTimeString = hhString & mmString & AMPMValue

        ElseIf Length(scanTime) = 6 Then

            Dim hhString As String = Substring(scanTime, 0, 2)
            Dim mmString As String = Substring(scanTime, 2, 2)
            Dim APString As String = Substring(scanTime, 4, 2)

            If hhString = "12" And mmString = "00" Then
                mmString = "01"
            End If

            scanTimeString = hhString & mmString & APString

        End If

        returnString = scanState.format()
        returnString &= createFixedWidthField(locationCode, 3, " ")
        returnString &= createFixedWidthField(statusCode, 1, " ")
        returnString &= createFixedWidthField(scanDate, 6, " ")
        returnString &= scanTimeString
        returnString &= DandRTag.format()
        returnString &= weightString
        returnString &= " "
        returnString &= createFixedWidthField(flightNumber, -4, " ")
        returnString &= "  "
        returnString &= createFixedWidthField(destinationCode, 3, " ")
        returnString &= createFixedWidthField(tailNumber, 6, " ")
        returnString &= createFixedWidthField(carrierCode, 2, " ")
        returnString &= createFixedWidthField(rejectReason, 6, " ")
        returnString &= createFixedWidthField(groupNumber, 10, " ")

        If isNonNullString(oldFlightNumber) Then
            returnString &= createFixedWidthField(oldFlightNumber, 4, "0")
        Else
            returnString &= "    "
        End If

        returnString &= createFixedWidthField(oldDestinationCode, 4, " ")

        weightValue = CInt(weight)

        If weightValue < 0 Then
            weightValue = 0
        ElseIf weightValue > 65536 Then
            weightValue = 65536
        End If

        returnString &= globalScanCountOnCreation.ToString.PadLeft(5)

        weightString = CStr(weightValue).PadLeft(5, "0")

        returnString &= weightString

        returnString = returnString.PadRight(81)

        returnString &= resditVersionNumber

        Return returnString

    End Function

    Public Function formatASI() As String

        Dim returnString As String
        Dim formatString As String
        Dim weightString As String

        formatString = CInt(weight)
        weightString = formatString.PadLeft(weightStringFieldWidth, "0")

        returnString = "_ASI_|"

        returnString &= scanState.format() & "|"
        returnString &= createFixedWidthField(locationCode, 3, " ") & "|"
        returnString &= createFixedWidthField(statusCode, 1, " ") & "|"
        returnString &= createFixedWidthField(scanDate, 6, " ") & "|"
        returnString &= createFixedWidthField(scanTime, 6, " ") & "|"
        returnString &= DandRTag.format() & "|"
        returnString &= weightString & "|"
        returnString &= createFixedWidthField(flightNumber, 4, " ") & "|"
        returnString &= createFixedWidthField(destinationCode, 3, " ") & "|"
        returnString &= createFixedWidthField(tailNumber, 6, " ") & "|"
        returnString &= createFixedWidthField(carrierCode, 2, " ") & "|"
        returnString &= createFixedWidthField(rejectReason, 6, " ") & "|"
        returnString &= createFixedWidthField(groupNumber, 10, " ") & "|"
        'returnString &= createFixedWidthField(delCode, 1, " ")

        Return returnString

    End Function

    Public Function generateHashKey() As String

        Dim returnString As String

        returnString = scanState.scanStateValue
        returnString &= locationCode
        returnString &= DandRTag.DandRTagValue
        returnString &= flightNumber.PadLeft(4, "0")
        returnString &= destinationCode
        returnString &= carrierCode
        returnString &= Trim(groupNumber)
        returnString &= tailNumber

        Return returnString

    End Function

    Public Sub parseNormal(ByRef inputString As String)

#if ValidationLevel >= 3

        if diagnosticLevel >= 2 then
            verify(not inputString is nothing, 14000)
        end if

#end if

        Dim weightString As String

        scanState.parse(substring(inputString, scanStateFieldLocationStart, scanStateFieldWidth))
        locationCode = substring(inputString, locationCodeFieldLocationStart, locationCodeFieldWidth)
        statusCode = Substring(inputString, statusCodeFieldLocationStart, statusCodeFieldWidth)
        scanDate = Substring(inputString, scanDateFieldLocationStart, scanDateFieldWidth)
        scanTime = Substring(inputString, scanTimeFieldLocationStart, scanTimeFieldWidth)
        DandRTag.parse(substring(inputString, DandRTagFieldLocationStart, DandRTagFieldWidth))
        weightString = Substring(inputString, weightStringFieldLocationStart, weightStringFieldWidth)
        flightNumber = Substring(inputString, flightNumberFieldLocationStart, flightNumberFieldWidth)
        destinationCode = Substring(inputString, destinationCodeFieldLocationStart, destinationCodeFieldWidth)
        tailNumber = Substring(inputString, tailNumberFieldLocationStart, tailNumberFieldWidth)
        carrierCode = Substring(inputString, carrierCodeFieldLocationStart, carrierCodeFieldWidth)
        rejectReason = Substring(inputString, rejectReasonFieldLocationStart, rejectReasonFieldWidth)
        groupNumber = Substring(inputString, groupNumberFieldLocationStart, groupNumberFieldWidth)
        'delCode = substrng(inputString, delCodeFieldLocationStart, delCodeFieldWidth)

        weight = CDbl(weightString)

    End Sub

    Public Sub parseASI(ByRef inputString As String)

#if ValidationLevel >= 3

        if diagnosticLevel >= 2 then
            verify(not inputString is nothing, 14010)
        end if

#end if

        Dim weightString As String
        Dim tokenSet As String()
        Dim j As Integer

        j = 1

        tokenSet = inputString.Split("|")

        scanState.parse(tokenSet(j)) : j += 1
        locationCode = tokenSet(j) : j += 1
        statusCode = tokenSet(j) : j += 1
        scanDate = tokenSet(j) : j += 1
        scanTime = tokenSet(j) : j += 1
        DandRTag.parse(tokenSet(j)) : j += 1
        weightString = tokenSet(j) : j += 1
        flightNumber = tokenSet(j) : j += 1
        destinationCode = tokenSet(j) : j += 1
        tailNumber = tokenSet(j) : j += 1
        carrierCode = tokenSet(j) : j += 1
        rejectReason = tokenSet(j) : j += 1
        groupNumber = tokenSet(j) : j += 1
        'delCode = tokenSet(j) : j += 1

        weight = CDbl(weightString)

    End Sub

    Private Sub scanStateError()
        MsgBox("Non-matching scan state")
        Stop
    End Sub

    Private Sub validateOpCode()

        exit sub ' removed because it doesn't work in a multithreaded environment

        Dim opcode As String = scanState.scanStateValue

        Select Case activeReaderForm.operationComboBox.Text

            Case "Possession"

                If opcode <> "P" Then scanStateError()

            Case "Load"

                If opcode <> "L" Then scanStateError()

            Case "Reroute"

                If opcode <> "L" Then scanStateError()

            Case "Possession & Load"

                opcode = "PL"

            Case "Transfer"

                If userSpecRecord.treatTransferScansAsLoadScans Then
                    If opcode <> "L" Then scanStateError()
                Else
                    If opcode <> "T" Then scanStateError()
                End If

            Case "Unload"

                If opcode <> "U" Then scanStateError()

            Case "Partial Offload"

                If opcode <> "O" Then scanStateError()

            Case "Complete Offload"

                If opcode <> "X" Then scanStateError()

            Case "Return"

                If opcode <> "R" Then scanStateError()

            Case "Delivery"

                If opcode <> "D" Then scanStateError()

            Case Else
                warning("Invalid or missing operation code", MsgBoxStyle.Exclamation, "Invalid Operation Code")
                Exit Sub
        End Select

    End Sub

    Public Function appendToFile(ByRef outputFileName As String) As String

        Dim outputStream As StreamWriter

        Try
            outputStream = New StreamWriter(outputFileName, True)
        Catch ex As Exception
            Return "Unable to open resdit file for output: " & ex.Message
        End Try

        If Not isValid() Then
            outputStream.Close()
            Return "Attempt to write invalid resdit record"
        End If

        validateOpCode()

        Dim outputLine As String

        If usingNormalOutputFormat Then
            outputLine = formatNormal()
        Else
            outputLine = formatASI()
        End If

        Try
            outputStream.WriteLine(outputLine)
        Catch ex As Exception
            outputStream.Close()
            Return "Write to resdit file failed: " & ex.Message
        End Try

        Try
            outputStream.Close()
        Catch ex As Exception
            Return "Unable to close resdit file output stream: " & ex.message
        End Try

        Dim resditRecordLength As Integer = Length(outputLine)

        Dim validationOutputFileStream As FileStream

        Try
            validationOutputFileStream = New FileStream(outputFileName, FileMode.Open)
        Catch ex As Exception
            Return "Open for validate failed: " & ex.message
        End Try

        Try
            validationOutputFileStream.Seek(-(resditRecordLength + 2), SeekOrigin.End)
        Catch ex As Exception
            validationOutputFileStream.Close()
            Return "Seek on resdit file failed: " & ex.message
        End Try

        Dim inputBuffer(resditRecordLength) As Byte
        Dim bytesRead As Integer

        Try
            bytesRead = validationOutputFileStream.Read(inputBuffer, 0, resditRecordLength)
        Catch ex As Exception
            validationOutputFileStream.Close()
            Return "Validation read on resdit file failed: " & ex.Message
        End Try

        If bytesRead <> resditRecordLength Then
            validationOutputFileStream.Close()
            Return "Validation read on resdit file failed: wrong number of bytes read."
        End If

        Dim i, ilmt As Integer

        ilmt = resditRecordLength - 1

        'Dim testString As String = ""

        For i = 0 To ilmt
            If Chr(inputBuffer(i)) <> outputLine.Chars(i) Then
                validationOutputFileStream.Close()
                Return "Validation of write failed."
            End If
        Next

        validationOutputFileStream.Close()

        Return "OK"

    End Function

    Public Function isValid() As Boolean

        If Not scanState.isValid() Then Return False
        If Not DandRTag.isValid() Then Return False

        Return True

    End Function

    Public Function compare(ByRef compareResditRecord As resditRecordClass) As Integer

#if ValidationLevel >= 3

        if diagnosticLevel >= 2 then
            verify(not compareResditRecord is nothing, 16010)
        end if

#end if

        Dim result As Integer

        If scanState.scanStateValue < compareResditRecord.scanState.scanStateValue Then
            Return -1
        ElseIf scanState.scanStateValue > compareResditRecord.scanState.scanStateValue Then
            Return 1
        End If

        result = stringCompare(flightNumber, compareResditRecord.flightNumber)
        If result <> 0 Then Stop

        result = stringCompare(locationCode, compareResditRecord.locationCode)
        If result <> 0 Then Stop

        result = stringCompare(destinationCode, compareResditRecord.destinationCode)
        If result <> 0 Then Stop

        result = stringCompare(scanDate, compareResditRecord.scanDate)
        If result <> 0 Then Stop

        result = stringCompare(scanTime, compareResditRecord.scanTime)
        If result <> 0 Then Stop

        result = stringCompare(statusCode, compareResditRecord.statusCode)
        If result <> 0 Then Stop

        result = stringCompare(tailNumber, compareResditRecord.tailNumber)
        If result <> 0 Then Stop

        result = stringCompare(carrierCode, compareResditRecord.carrierCode)
        If result <> 0 Then Stop

        result = stringCompare(groupNumber, compareResditRecord.groupNumber)
        If result <> 0 Then Stop

        result = stringCompare(oldDestinationCode, compareResditRecord.oldDestinationCode)
        If result <> 0 Then Stop

        result = stringCompare(oldFlightNumber, compareResditRecord.oldFlightNumber)
        If result <> 0 Then Stop

        result = stringCompare(rejectReason, rejectReason)
        If result <> 0 Then Stop

        'result = duplicateCount - compareResditRecord.duplicateCount
        'If result <> 0 Then Stop

        'result = globalScanCountOnCreation - compareResditRecord.globalScanCountOnCreation
        'If result <> 0 Then Stop

        Return 0

    End Function

End Class
