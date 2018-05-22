Imports System
Imports System.io

Public Class bagRecordClass

    Public baggageTagID As String = ""
    Public baggageFlightNumber As String = ""
    Public baggageLocation As String = ""
    Public baggageCarrierCode As String = ""
    Public baggageACBinID As String = ""
    Public baggageHoldPosition As String = ""
    Public baggageContainerPosition As String = ""
    Public baggageOpCode As String = ""
    Public baggageOperation As String = ""

    Public duplicateCount As Integer = 0

    Public scanDateAndTime As DateTime

    Public Sub reset()

        baggageTagID = ""
        baggageFlightNumber = ""
        baggageLocation = ""
        baggageCarrierCode = ""
        baggageACBinID = ""
        baggageHoldPosition = ""
        baggageContainerPosition = ""
        baggageOpCode = ""
        baggageOperation = ""

        duplicateCount = 0

        scanDateAndTime = #1/1/1900#

    End Sub

    Public Sub New()
        reset()
    End Sub

    Public Sub New(ByVal baggageRecord As bagRecordClass)

        reset()

        baggageTagID = baggageRecord.baggageTagID
        baggageFlightNumber = baggageRecord.baggageFlightNumber
        baggageLocation = baggageRecord.baggageLocation
        baggageCarrierCode = baggageRecord.baggageCarrierCode
        baggageACBinID = baggageRecord.baggageACBinID
        baggageHoldPosition = baggageRecord.baggageHoldPosition
        baggageContainerPosition = baggageRecord.baggageContainerPosition
        baggageOpCode = baggageRecord.baggageOpCode
        baggageOperation = baggageRecord.baggageOperation

    End Sub

    Public Function GetHashKey() As String

        Return baggageOpCode & baggageTagID & baggageLocation

    End Function

    Public Function formatNormal() As String

        Dim returnString As String
        Dim formatString As String
        Dim weightString As String

        Dim flightNumberString As String

        Dim scanDateString As String
        Dim scanTimeString As String

        scanDateString = String.Format("{0:MMddyy}", scanDateAndTime)
        scanTimeString = String.Format("{0:hhmmtt}", scanDateAndTime)

        returnString = baggageOpCode
        returnString &= Util.createFixedWidthField(baggageLocation, 3, " ")
        returnString &= " "
        returnString &= scanDateString
        returnString &= scanTimeString
        returnString &= Util.createFixedWidthField(baggageTagID, 12, " ")
        returnString &= " "
        returnString &= Util.createFixedWidthField(baggageFlightNumber, -4, " ")
        returnString &= "  "
        returnString &= "   "
        returnString &= Util.createFixedWidthField(baggageACBinID, 6, " ")
        returnString &= Util.createFixedWidthField(baggageCarrierCode, 2, " ")
        returnString &= Util.createFixedWidthField(baggageHoldPosition, 6, " ")
        returnString &= Util.createFixedWidthField(baggageContainerPosition, 10, " ")

        Return returnString

    End Function

    Public Function isValid() As Boolean

        Return True

    End Function

    Public Function appendToFile(ByRef outputFileName As String) As String

#If ValidationLevel >= 3 Then

        If diagnosticLevel >= 2 Then
            verify(Not outputFileName Is Nothing, 15000)
        End If

#End If
        Dim outputStream As StreamWriter

        Try
            outputStream = New StreamWriter(outputFileName, True)
        Catch ex As Exception
            Return "Unable to open baggage file for output: " & ex.Message
        End Try

        If Not isValid() Then
            outputStream.Close()
            Return "Attempt to write invalid baggage record"
        End If

        Dim outputLine As String

        outputLine = formatNormal()

        Try
            outputStream.WriteLine(outputLine)
        Catch ex As Exception
            outputStream.Close()
            Return "Write to baggage file failed: " & ex.Message
        End Try

        Try
            outputStream.Close()
        Catch ex As Exception
            Return "Unable to close baggage file output stream: " & ex.message
        End Try

        Dim baggageRecordLength As Integer = Length(outputLine)

        Dim validationOutputFileStream As FileStream

        Try
            validationOutputFileStream = New FileStream(outputFileName, FileMode.Open)
        Catch ex As Exception
            Return "Open for validate failed: " & ex.message
        End Try

        Try
            validationOutputFileStream.Seek(-(baggageRecordLength + 2), SeekOrigin.End)
        Catch ex As Exception
            validationOutputFileStream.Close()
            Return "Seek on baggage file failed: " & ex.message
        End Try

        Dim inputBuffer(baggageRecordLength) As Byte
        Dim bytesRead As Integer

        Try
            bytesRead = validationOutputFileStream.Read(inputBuffer, 0, baggageRecordLength)
        Catch ex As Exception
            validationOutputFileStream.Close()
            Return "Validation read on baggage file failed: " & ex.Message
        End Try

        If bytesRead <> baggageRecordLength Then
            validationOutputFileStream.Close()
            Return "Validation read on baggage file failed: wrong number of bytes read."
        End If

        Dim i, ilmt As Integer

        ilmt = baggageRecordLength - 1

        For i = 0 To ilmt
            If Chr(inputBuffer(i)) <> outputLine.Chars(i) Then
                validationOutputFileStream.Close()
                Return "Validation of write failed."
            End If
        Next

        validationOutputFileStream.Close()

        Return "OK"

    End Function
End Class
