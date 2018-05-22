'' Responsible for validating the various entry fields for International
Class ValidateInternationalFields

    '' Validate location sanity
    '' MUST be 3 or 4 characters
    '' MUST start with a letter
    '' MUST contain either letters of digits
    Public Shared Function isValidIntlLoc(ByVal strLoc As String) As Boolean
        Dim strLength As Integer = Len(strLoc)
        If strLength < 3 Or strLength > 4 Then Return False
        If Not Char.IsLetter(strLoc.Chars(0)) Then Return False
        Dim i, ilmt As Integer
        ilmt = strLength - 1
        For i = 1 To ilmt
            If Not Char.IsLetterOrDigit(strLoc.Chars(i)) Then Return False
        Next

        Return True

    End Function

    '' Validate bar code sanity
    '' MUST be 0 to 35 characters
    '' MUST be 25 characters if "US" post office
    Public Shared Function isValidIntlBarcode(ByVal strBarcode, ByVal postOffice) As Boolean

        '' Check length
        If Len(strBarcode) <= 0 Or Len(strBarcode) > 35 Then
            Return False
        End If
        If postOffice = "US" And Len(strBarcode) <> 25 Then
            Return False
        End If

        Return True

    End Function

    '' Validate weight sanity
    '' MUST be 0 to 5 characters
    '' MUST be parsable to a Double
    '' MUST be <= 35000
    Public Shared Function isValidIntlWeight(ByVal strWeight As String) As Boolean
        Dim strLength As Integer = Len(strWeight)
        If strLength <= 0 Or strLength > 5 Then Return False

        'Dim i, ilmt As Integer

        'ilmt = strLength - 1

        'For i = 0 To ilmt
        '    If Not Char.IsDigit(strWeight.Chars(i)) Then Return False
        'Next

        Try
            Dim x As Double = System.Double.Parse(strWeight)
            If x > 35000 Then Return False
            Return True
        Catch ex As Exception
            Return False
        End Try

    End Function

    '' Validate piece count for sanity
    '' MUST be 0 to 5 characters
    '' MUST be all digits
    '' MUST be parsable to an Integer
    '' MUST be evaluated to <= 999999
    Public Shared Function isValidIntlPieceCount(ByVal strIntlPieces As String) As Boolean
        Dim strLength As Integer = Len(strIntlPieces)
        If strLength <= 0 Or strLength > 5 Then Return False
        Dim i, ilmt As Integer
        ilmt = strLength - 1
        For i = 0 To ilmt
            If Not Char.IsDigit(strIntlPieces.Chars(i)) Then Return False
        Next

        Try
            Dim x As Integer = Integer.Parse(strIntlPieces)
            If x > 999999 Then Return False
        Catch ex As Exception
            Return False
        End Try

        Return True

    End Function

    '' Validate carrier for sanity
    '' MUST be 2 or 3 chars long
    '' MUST be letters or digits
    Public Shared Function isValidIntlCarrier(ByVal strIntlCarrier As String) As Boolean
        Dim strLength As Integer = Len(strIntlCarrier)
        If strLength < 2 Or strLength > 3 Then Return False
        Dim i, ilmt As Integer
        ilmt = strLength - 1
        For i = 0 To ilmt
            If Not Char.IsLetterOrDigit(strIntlCarrier.Chars(i)) Then Return False
        Next

        Return True

    End Function

    '' Validate international flight
    '' MUST be 1 to 4 characters long
    '' MUST be all digits
    Public Shared Function isValidIntlFlight(ByVal strIntlFlight As String) As Boolean
        Dim strLength As Integer = Len(strIntlFlight)
        If strLength < 1 Or strLength > 4 Then Return False
        Dim i, ilmt As Integer
        ilmt = strLength - 1
        For i = 0 To ilmt
            If Not Char.IsDigit(strIntlFlight.Chars(i)) Then Return False
        Next

        Return True

    End Function

    '' Validate "handover" point
    '' MUST be 1 to 6 characters long
    '' MUST be either letter or digits
    Public Shared Function isValidIntlHandoverPt(ByVal strIntlHandoverPt As String) As Boolean
        Dim strLength As Integer = Len(strIntlHandoverPt)
        If strLength < 1 Or strLength > 6 Then Return False
        Dim i, ilmt As Integer
        ilmt = strLength - 1
        For i = 0 To ilmt
            If Not Char.IsLetterOrDigit(strIntlHandoverPt.Chars(i)) Then Return False
        Next

        Return True

    End Function

    '' Validate cart ID for sanity
    '' MUST be 1 to 18 characters long
    Public Shared Function isValidIntlCartID(ByVal strIntlCartID As String) As Boolean
        Dim strLength As Integer = Len(strIntlCartID)
        If strLength < 1 Or strLength > 18 Then Return False

        Return True

    End Function

    '' Validate post office for sanity
    '' MUST be 2 capital letters (regex: "^[A-Z]{2}$")
    Public Shared Function isValidIntlPostOffice(ByVal strIntlPostOffice As String) As Boolean
        Dim regex As System.Text.RegularExpressions.Regex
        Return regex.IsMatch(strIntlPostOffice, "^[A-Z]{2}$")
    End Function

End Class
