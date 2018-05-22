Public Class OntimeRecord

    Public DandRTag As String
    Public closeoutDateAndTime As DateTime
    Public departureDateAndTime As DateTime
    Public flightNumber As String
    Public acceptWithoutPrompting As Boolean = False

    Public isValid As Boolean = True

    Public Sub New(ByVal inputDandRTag As String, ByVal inputCloseoutDateAndTime As DateTime, ByVal inputDepartureDateAndTime As DateTime, ByVal inputFlightNumber As String)

        If inputDandRTag.Length <> 10 Then
            isValid = False
            Return
        End If

        DandRTag = inputDandRTag

        closeoutDateAndTime = inputCloseoutDateAndTime
        departureDateAndTime = inputDepartureDateAndTime

        flightNumber = inputFlightNumber

        isValid = True

    End Sub

End Class
