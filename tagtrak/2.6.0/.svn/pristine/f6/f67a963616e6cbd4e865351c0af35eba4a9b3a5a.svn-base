Public Class CarditRoutingRecord

    Public dateTimeStamp As DateTime
    Public validFlightList As ArrayList

    Public Sub New()

        dateTimeStamp = DateTime.UtcNow

        validFlightList = New ArrayList

    End Sub

    Public Sub New(ByVal inputDateTimeStamp As DateTime)

        dateTimeStamp = inputDateTimeStamp

        validFlightList = New ArrayList

    End Sub

    Public Sub New(ByVal inputDateTimeStamp As DateTime, ByVal inputValidFlightList As ArrayList)

        dateTimeStamp = inputDateTimeStamp
        validFlightList = inputValidFlightList

    End Sub

    Public Function isAValidFlight(ByVal flightNumber As Integer)

        If validFlightList Is Nothing Then Return False

        Return validFlightList.Contains(flightNumber)

    End Function

End Class
