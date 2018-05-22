Imports System
Imports System.io

Public Class binUploadRecordClass

    Public binID As String
    Public flightNumber As String
    Public destination As String
    Public creationDateAndTime As DateTime
    Public scanType As String = "" ' Scan type: "C" -> Cargo, "B" -> Baggage, "M" -> Domestic Mail, "I" -> International Mail

    Public Sub New(ByVal inputBinID As String, ByVal inputFlightNumber As String, ByVal inputLocation As String, ByVal inputScanType As String)

#If ValidationLevel >= 3 Then

        if diagnosticLevel >= 2 then

            verify(not inputBinID Is Nothing, 300)
            verify(not inputFlightNumber Is Nothing, 301)
            verify(Not inputLocation Is Nothing, 302)
            verify(Not inputScanType Is Nothing, 302)

        end if

#End If

        binID = inputBinID
        flightNumber = inputFlightNumber
        destination = inputLocation
        scanType = inputScanType
        creationDateAndTime = Time.Local.GetTime(scannerTimeZone)

    End Sub

    Public Overrides Function ToString() As String

#If ValidationLevel >= 3 Then

        if diagnosticLevel >= 2 then

            verify(not BinID Is Nothing, 303)
            verify(not flightNumber Is Nothing, 304)
            verify(Not destination Is Nothing, 305)
            verify(Not scanType Is Nothing, 306)

	end if

#End If
        Dim returnString As String = ""

        If Not isNonNullString(binID) Then
            returnString &= TagTrakGlobals.fieldSepChar
        Else
            returnString &= binID.PadRight(10) & TagTrakGlobals.fieldSepChar
        End If

        If Not isNonNullString(flightNumber) Then
            returnString &= TagTrakGlobals.fieldSepChar
        Else
            returnString &= flightNumber & TagTrakGlobals.fieldSepChar
        End If

        If Not isNonNullString(destination) Then
            returnString &= TagTrakGlobals.fieldSepChar
        Else
            returnString &= destination & TagTrakGlobals.fieldSepChar
        End If

        If Not isNonNullString(scanType) Then
            returnString &= TagTrakGlobals.fieldSepChar
        Else
            returnString &= scanType & TagTrakGlobals.fieldSepChar
        End If

        returnString &= String.Format("{0:MM/dd/yyyy" & TagTrakGlobals.fieldSepChar & "HH:mm}", creationDateAndTime)

        Return returnString

    End Function

    Public Function write(ByVal outputFilePath As String) As String

#If ValidationLevel >= 3 Then

        if diagnosticLevel >= 2 then
            verify(not outputFilePath is nothing, 306)
	end if

#End If

        Dim binUploadOutputStream As StreamWriter

        Try
            binUploadOutputStream = New StreamWriter(binUploadFilePath, True)
        Catch ex As Exception
            Return "Unable to open cart upload file: " & ex.Message
        End Try

        Try
            binUploadOutputStream.WriteLine(Me.ToString)
        Catch ex As Exception
            Return "Unable to write cart upload file: " & ex.Message
        End Try

        binUploadOutputStream.Close()

        Return "OK"

    End Function

End Class
