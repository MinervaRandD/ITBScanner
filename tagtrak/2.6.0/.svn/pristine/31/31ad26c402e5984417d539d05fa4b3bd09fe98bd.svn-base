Module StringUtilities

    Public Function Substring(ByVal inputString As String, ByVal startLocation As Integer, ByVal resultLength As Integer) As String

        If resultLength < 0 Then
            MsgBox("Non-positive result length passed to Substring function.")
            Stop
        End If

        If startLocation < 0 Then
            MsgBox("Non-positive start location passed to Substring function.")
            Stop
        End If

        If inputString Is Nothing Then Return ""
        If resultLength = 0 Then Return ""

        Return Mid(inputString, 1 + startLocation, resultLength)

    End Function

    Public Function Substring(ByVal inputString As String, ByVal startLocation As Integer) As String

        If startLocation < 0 Then
            MsgBox("Non-positive result length passed to Substring function.")
            Stop
        End If

        If startLocation = 0 Then Return ""
        If inputString Is Nothing Then Return ""

        Return Mid(inputString, 1 + startLocation)

    End Function

    Public Function Length(ByVal inputString As String) As Integer

        If inputString Is Nothing Then Return 0

        Return Len(inputString)

    End Function

    Public Function isNonNullString(ByRef x As String) As Boolean

        If x Is Nothing Then Return False

        If Length(x) <= 0 Then Return False

        Return True

    End Function

    Public Function isNullString(ByRef x As String) As Boolean

        If x Is Nothing Then Return True

        If Length(x) <= 0 Then Return True

        Return False

    End Function
End Module
