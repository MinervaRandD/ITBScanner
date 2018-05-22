Public Class FlightLoadingRecord

    Dim totalWeight As Double = 0.0
    Dim totalPieces As Integer = 0

    Public Sub New(ByVal initPieces As Integer, ByVal initWeight As Double)

        totalWeight = initWeight
        totalPieces = initPieces

    End Sub

    Public Sub accumulate(ByVal accumPieces As Integer, ByVal accumWeight As Double)

        totalWeight += accumWeight
        totalPieces += accumPieces

    End Sub

    Public Overrides Function ToString() As String

        Return totalPieces.ToString.PadLeft(7) & " | " & totalWeight.ToString("0.00").PadLeft(10)

    End Function

End Class
