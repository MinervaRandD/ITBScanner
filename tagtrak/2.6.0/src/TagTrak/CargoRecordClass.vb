Imports System
Imports System.io

Public Class cargoRecordClass

    Public cargoOperation As String
    Public cargoOpCode As Char
    Public cargoAirWaybillNumber As String
    Public cargoRejectReason As String
    Public cargoACBinID As String
    Public cargoFlightNumber As String
    Public cargoDestinationCode As String
    Public cargoContainerID As String
    Public cargoScanDateAndTime As DateTime = #1/1/1900#
    Public cargoLocationCode As String
    Public cargoCarrierCode As String
    Public cargoHazmat As Boolean

    Public cargoDuplicateCount As Integer = 0

    Public Sub reset()

        cargoOperation = ""
        cargoOpCode = " "c
        cargoAirWaybillNumber = ""
        cargoRejectReason = ""
        cargoACBinID = ""
        cargoFlightNumber = ""
        cargoDestinationCode = ""
        cargoContainerID = ""
        cargoScanDateAndTime = #1/1/1900#
        cargoLocationCode = ""
        cargoHazmat = False

        cargoDuplicateCount = 0

    End Sub

    Public Sub New()
        reset()
    End Sub

    Public Sub New(ByVal cargoRecord As cargoRecordClass)

        reset()

        cargoOperation = cargoRecord.cargoOperation
        cargoOpCode = cargoRecord.cargoOpCode
        cargoAirWaybillNumber = cargoRecord.cargoAirWaybillNumber
        cargoRejectReason = cargoRecord.cargoRejectReason
        cargoACBinID = cargoRecord.cargoACBinID
        cargoFlightNumber = cargoRecord.cargoFlightNumber
        cargoDestinationCode = cargoRecord.cargoDestinationCode
        cargoContainerID = cargoRecord.cargoContainerID
        cargoScanDateAndTime = cargoRecord.cargoScanDateAndTime
        cargoLocationCode = cargoRecord.cargoLocationCode
        cargoCarrierCode = cargoRecord.cargoCarrierCode
        cargoHazmat = cargoRecord.cargoHazmat

    End Sub

    Public Function GetHashKey() As String

        Return cargoOpCode & cargoAirWaybillNumber & cargoLocationCode

    End Function

    Public Function formatNormal() As String

        Dim returnString As String
        Dim formatString As String
        Dim weightString As String

        Dim flightNumberString As String

        Dim scanDateString As String
        Dim scanTimeString As String

        scanDateString = String.Format("{0:MMddyy}", cargoScanDateAndTime)
        scanTimeString = String.Format("{0:hhmmtt}", cargoScanDateAndTime)

        returnString = cargoOpCode
        returnString &= Util.createFixedWidthField(cargoLocationCode, 3, " ")
        returnString &= " "
        returnString &= scanDateString
        returnString &= scanTimeString
        returnString &= Util.createFixedWidthField(cargoAirWaybillNumber, 12, " ")
        returnString &= " "
        returnString &= Util.createFixedWidthField(cargoFlightNumber, -4, " ")
        returnString &= "  "
        returnString &= Util.createFixedWidthField(cargoDestinationCode, 3, " ")
        returnString &= Util.createFixedWidthField(cargoACBinID, 6, " ")
        returnString &= Util.createFixedWidthField(cargoCarrierCode, 2, " ")
        returnString &= Util.createFixedWidthField(cargoRejectReason, 6, " ")
        returnString &= Util.createFixedWidthField(cargoContainerID, 10, " ")

        If cargoHazmat Then
            returnString &= "H"
        Else
            returnString &= " "
        End If

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
            Return "Unable to open cargo file for output: " & ex.Message
        End Try

        If Not isValid() Then
            outputStream.Close()
            Return "Attempt to write invalid cargo record"
        End If

        Dim outputLine As String

        outputLine = formatNormal()

        Try
            outputStream.WriteLine(outputLine)
        Catch ex As Exception
            outputStream.Close()
            Return "Write to cargo file failed: " & ex.Message
        End Try

        Try
            outputStream.Close()
        Catch ex As Exception
            Return "Unable to close cargo file output stream: " & ex.message
        End Try

        Dim cargoRecordLength As Integer = Length(outputLine)

        Dim validationOutputFileStream As FileStream

        Try
            validationOutputFileStream = New FileStream(outputFileName, FileMode.Open)
        Catch ex As Exception
            Return "Open for validate failed: " & ex.message
        End Try

        Try
            validationOutputFileStream.Seek(-(cargoRecordLength + 2), SeekOrigin.End)
        Catch ex As Exception
            validationOutputFileStream.Close()
            Return "Seek on cargo file failed: " & ex.message
        End Try

        Dim inputBuffer(cargoRecordLength) As Byte
        Dim bytesRead As Integer

        Try
            bytesRead = validationOutputFileStream.Read(inputBuffer, 0, cargoRecordLength)
        Catch ex As Exception
            validationOutputFileStream.Close()
            Return "Validation read on cargo file failed: " & ex.Message
        End Try

        If bytesRead <> cargoRecordLength Then
            validationOutputFileStream.Close()
            Return "Validation read on cargo file failed: wrong number of bytes read."
        End If

        Dim i, ilmt As Integer

        ilmt = cargoRecordLength - 1

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
