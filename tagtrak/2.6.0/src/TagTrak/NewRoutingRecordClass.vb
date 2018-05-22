Public Class newRoutingRecordClass

    Public origin As String
    Public destination(3) As String
    Public flight(3) As String
    Public carrier(3) As String
    Public routingCode As String

    Public Sub New()
        origin = ""

        routingCode = ""

        Dim i As Integer

        For i = 0 To 3
            destination(i) = ""
            flight(i) = ""
            carrier(i) = ""
        Next

    End Sub

    Public Overrides Function ToString() As String

        Dim returnString As String = ""

        returnString &= "D" & TagTrakGlobals.fieldSepChar
        returnString &= routingCode & TagTrakGlobals.fieldSepChar
        returnString &= origin & TagTrakGlobals.fieldSepChar

        Dim i As Integer

        For i = 0 To 3

            returnString &= destination(i) & TagTrakGlobals.fieldSepChar

            If Util.IsInteger(flight(i)) Then
                returnString &= flight(i) & TagTrakGlobals.fieldSepChar
            Else
                returnString &= TagTrakGlobals.fieldSepChar
            End If

            returnString &= carrier(i) & TagTrakGlobals.fieldSepChar
        Next

        Return returnString

    End Function

End Class
