Public Class BinChangeRecordClass

    Public oldBin As String
    Public newBin As String
    Public flightNumber As String
    Public location As String
    Public creationDateAndTime As DateTime
    Public progType As Char

    Public Sub New(ByVal inputOldBin As String, ByVal inputNewBin As String, ByVal inputFlightNumber As String, ByVal inputLocation As String, ByVal inputProgType As Char)

#If ValidationLevel >= 3 Then

        if diagnosticLevel >= 2 then
            verify(not inputOldBin is nothing, 201)
            verify(not inputNewBin is nothing, 202)
            verify(not inputFlightNumber is nothing, 203)
            verify(not inputLocation is nothing, 204)
	end if

#End If

        oldBin = inputOldBin
        newBin = inputNewBin
        flightNumber = inputFlightNumber
        location = inputLocation
        creationDateAndTime = Time.Local.GetTime(scannerTimeZone)
        progType = inputProgType

    End Sub

    Public Overrides Function ToString() As String

#If ValidationLevel >= 3 Then

	if diagnosticLevel >= 2 then

            verify(not oldBin is nothing, 205)
            verify(not newBin is nothing, 206)
            verify(not flightNumber is nothing, 207)
            verify(not location is nothing, 208)

        end if

#End If

        Dim returnString As String

        If Not isNonNullString(oldBin) Then
            returnString = TagTrakGlobals.fieldSepChar
        Else
            returnString = oldBin & TagTrakGlobals.fieldSepChar
        End If

        If Not isNonNullString(newBin) Then
            returnString &= TagTrakGlobals.fieldSepChar
        Else
            returnString &= newBin & TagTrakGlobals.fieldSepChar
        End If

        If Not isNonNullString(flightNumber) Then
            returnString &= TagTrakGlobals.fieldSepChar
        Else
            returnString &= flightNumber & TagTrakGlobals.fieldSepChar
        End If

        returnString &= TagTrakGlobals.fieldSepChar

        returnString &= String.Format("{0:MM/dd/yyyy" & TagTrakGlobals.fieldSepChar & "HH:mm}", creationDateAndTime)

        returnString &= TagTrakGlobals.fieldSepChar & progType

        Return returnString

    End Function

End Class
