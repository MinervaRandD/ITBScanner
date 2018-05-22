Imports System
Imports System.IO
Imports System.Collections

Public Class scanRecordClass

    Public scanType As String = ""     ' Scan type: "C" -> Cargo, "B" -> Baggage, "M" -> Domestic Mail, "I" -> International Mail
    Public scanOp As String = ""       ' Operation within scan type -- scan type specific
    Public scanCode As String = ""     ' Usually refers to the bar code.
    Public scanLoc As String = ""      ' Location at which the scan was made
    Public scanDateAndTime As DateTime ' Date and time of scan
    Public carrierCode As String = ""  ' the (IATA) carrier code
    Public flightNumber As String = "" ' The flight number that the item will be placed on
    Public destination As String = ""  ' destination for whatever was scanned
    Public scanRecord As Object        ' Scan type specific record

    Public scanOutputOpCode As Char  ' actual output op code in case of multiple op codes per output

    Public globalScanCountOnCreation As Integer = 0
    Public duplicateCount As Integer = 0

    'Public Function getHashKey(ByVal inputScanType As String, ByVal inputScanOp As String, ByVal inputScanCode As String) As String
    '    Return inputScanType & TagTrakGlobals.fieldSepChar & inputScanOp & TagTrakGlobals.fieldSepChar & inputScanCode
    'End Function

    Public Overrides Function ToString() As String

        Dim returnString As String

        returnString = scanType & TagTrakGlobals.fieldSepChar & scanOp & TagTrakGlobals.fieldSepChar & scanCode & TagTrakGlobals.fieldSepChar
        returnString &= scanLoc & TagTrakGlobals.fieldSepChar
        returnString &= String.Format("{0:yyyy-MM-dd}", scanDateAndTime) & TagTrakGlobals.fieldSepChar & String.Format("{0:HH:mm:ss}", scanDateAndTime) & TagTrakGlobals.fieldSepChar
        returnString &= carrierCode & TagTrakGlobals.fieldSepChar & flightNumber & TagTrakGlobals.fieldSepChar & destination & TagTrakGlobals.fieldSepChar

        returnString &= globalScanCountOnCreation & TagTrakGlobals.fieldSepChar & duplicateCount & TagTrakGlobals.fieldSepChar

        If scanType = "C" Then

            Dim CargoScanRecordClass As CargoScanRecordClass = scanRecord

            returnString &= CargoScanRecordClass.ToString()

            Return returnString

        End If

        If scanType = "B" Then

            Dim baggageScanRecord As BagScanRecordClass = scanRecord

            returnString &= baggageScanRecord.ToString()

            Return returnString

        End If

        If scanType = "M" Then

            Dim mailDomsScanRecord As MailDomsScanRecordClass = scanRecord

            returnString &= mailDomsScanRecord.ToString()

            Return returnString

        End If

        If scanType = "I" Then

            Dim mailIntlScanRecord As MailIntlScanRecordClass = scanRecord

            returnString &= mailIntlScanRecord.ToString()

            Return returnString

        End If

    End Function

    Public Function appendToFile(ByRef outputFileName As String) As String

        Dim outputStream As StreamWriter

        Try
            outputStream = New StreamWriter(outputFileName, True)
        Catch ex As Exception
            Return "Unable to open scan file for output: " & ex.Message
        End Try

        ' TODO : define isValid and then add the following line back in
        'If Not isValid() Then : outputStream.Close() : Return "Attempt to write invalid scan record" : End If

        Dim outputLine As String = Me.ToString()

        Try
            outputStream.WriteLine(outputLine)
        Catch ex As Exception
            outputStream.Close()
            Return "Write to scan file failed: " & ex.Message
        End Try

        Try
            outputStream.Close()
        Catch ex As Exception
            Return "Unable to close scan file output stream: " & ex.message
        End Try

        Dim scanRecordLength As Integer = Length(outputLine)

        Dim validationOutputFileStream As FileStream

        Try
            validationOutputFileStream = New FileStream(outputFileName, FileMode.Open)
        Catch ex As Exception
            Return "Open for validate failed: " & ex.message
        End Try

        Try
            validationOutputFileStream.Seek(-(scanRecordLength + 2), SeekOrigin.End)
        Catch ex As Exception
            validationOutputFileStream.Close()
            Return "Seek on scan file failed: " & ex.message
        End Try

        Dim inputBuffer(scanRecordLength) As Byte
        Dim bytesRead As Integer

        Try
            bytesRead = validationOutputFileStream.Read(inputBuffer, 0, scanRecordLength)
        Catch ex As Exception
            validationOutputFileStream.Close()
            Return "Validation read on scan file failed: " & ex.Message
        End Try

        If bytesRead <> scanRecordLength Then
            validationOutputFileStream.Close()
            Return "Validation read on scan file failed: wrong number of bytes read."
        End If

        Dim i, ilmt As Integer

        ilmt = scanRecordLength - 1

        For i = 0 To ilmt
            If Chr(inputBuffer(i)) <> outputLine.Chars(i) Then
                validationOutputFileStream.Close()
                Return "Validation of write failed."
            End If
        Next

        validationOutputFileStream.Close()

        Return "OK"

    End Function

    Public Function getScanWeight() As Double

        If scanType = "C" Then

            Return -1.0

        ElseIf scanType = "B" Then

            Return -1.0

        ElseIf scanType = "M" Then

            Dim mailDomsScanRecord As MailDomsScanRecordClass
            mailDomsScanRecord = scanRecord

            Return mailDomsScanRecord.weight

        ElseIf scanType = "I" Then

            Dim mailIntlScanRecord As MailIntlScanRecordClass
            mailIntlScanRecord = scanRecord

            Return mailIntlScanRecord.weight

        Else

            Return -1.0

        End If

    End Function

    Public Function getScanPieces() As Integer

        If scanType = "C" Then

            Dim CargoScanRecordClass As CargoScanRecordClass
            CargoScanRecordClass = scanRecord

            Return CargoScanRecordClass.pieces

        ElseIf scanType = "B" Then

            Dim bagScanRecord As BagScanRecordClass
            bagScanRecord = scanRecord

            Return bagScanRecord.pieceCount

        ElseIf scanType = "M" Then

            Return 1

        ElseIf scanType = "I" Then

            Dim mailIntlScanRecord As MailIntlScanRecordClass
            mailIntlScanRecord = scanRecord

            Return mailIntlScanRecord.pieceCount

        Else

            Return -1.0

        End If

    End Function

    Public Function CreateCopy() As scanRecordClass

        Dim newScanRecord As New scanRecordClass

        newScanRecord.scanType = scanType
        newScanRecord.scanOp = scanOp
        newScanRecord.scanCode = scanCode
        newScanRecord.scanLoc = scanLoc
        newScanRecord.scanDateAndTime = scanDateAndTime
        newScanRecord.carrierCode = carrierCode
        newScanRecord.flightNumber = flightNumber
        newScanRecord.destination = destination
        newScanRecord.scanOutputOpCode = scanOutputOpCode
        newScanRecord.globalScanCountOnCreation = globalScanCountOnCreation
        newScanRecord.duplicateCount = duplicateCount

        If scanType = "C" Then

            Dim CargoScanRecordClass As CargoScanRecordClass

            CargoScanRecordClass = scanRecord
            newScanRecord.scanRecord = CargoScanRecordClass.CreateCopy()

        ElseIf scanType = "B" Then

            Dim bagScanRecord As BagScanRecordClass

            bagScanRecord = scanRecord
            newScanRecord.scanRecord = bagScanRecord.CreateCopy()

        ElseIf scanType = "M" Then

            Dim mailDomsScanRecord As MailDomsScanRecordClass

            mailDomsScanRecord = scanRecord
            newScanRecord.scanRecord = mailDomsScanRecord.CreateCopy()

        ElseIf scanType = "I" Then

            Dim mailIntlScanRecord As MailIntlScanRecordClass

            mailIntlScanRecord = scanRecord
            newScanRecord.scanRecord = mailIntlScanRecord.CreateCopy()

        Else

            newScanRecord.scanRecord = Nothing
        End If

        Return newScanRecord

    End Function

    Public Function getHashKey() As String

        Dim returnString As String

        returnString = Me.scanType & TagTrakGlobals.fieldSepChar
        returnString &= Me.scanOp & TagTrakGlobals.fieldSepChar
        returnString &= Me.scanLoc & TagTrakGlobals.fieldSepChar
        returnString &= Me.scanCode & TagTrakGlobals.fieldSepChar
        returnString &= Me.carrierCode & flightNumber.PadLeft(4, "0") & TagTrakGlobals.fieldSepChar

        Return returnString

    End Function

    Public Sub reset()

        scanType = ""      ' Scan type: "C" -> Cargo, "B" -> Baggage, "M" -> Domestic Mail, "I" -> International Mail
        scanOp = ""        ' Operation within scan type -- scan type specific
        scanCode = ""      ' Usually refers to the bar code.
        scanLoc = ""       ' Location at which the scan was made
        scanDateAndTime = New DateTime(0) ' Date and time of scan
        carrierCode = ""   ' the (IATA) carrier code
        flightNumber = ""  ' The flight number that the item will be placed on
        destination = ""   ' destination for whatever was scanned
        scanRecord = Nothing       ' Scan type specific record

        scanOutputOpCode = " "c 'actual output op code in case of multiple op codes per output

        globalScanCountOnCreation = 0
        duplicateCount = 0

    End Sub

End Class
