Public Class CarditFlightLegClass

    Public carrierCode As String
    Public flightNumber As String
    Public cityCode As String

    Public Sub New(ByVal cbxCarrierCode As ComboBox, ByVal tbxFlightNumber As TextBox, ByVal cbxCityCode As ComboBox)

        carrierCode = ""
        flightNumber = ""
        cityCode = ""

        If isNonNullString(cbxCarrierCode.Text) Then carrierCode = cbxCarrierCode.Text
        If isNonNullString(tbxFlightNumber.Text) Then flightNumber = tbxFlightNumber.Text
        If isNonNullString(cbxCityCode.Text) Then cityCode = cbxCityCode.Text

    End Sub

    Public Function isValid() As Boolean

        If Not isNonNullString(carrierCode) Then Return False
        If Not isNonNullString(flightNumber) Then Return False
        If Not isNonNullString(cityCode) Then Return False

        Return True

    End Function

    Public Function containsANonNullEntry() As Boolean

        If isNonNullString(carrierCode) Then Return True
        If isNonNullString(flightNumber) Then Return True
        If isNonNullString(cityCode) Then Return True

        Return False

    End Function

    Public Overrides Function ToString() As String

        If Not isValid() Then
            Return "??" & Chr(9) & "????" & Chr(9) & "??" & Chr(9) & "??"
        End If

        Return carrierCode & Chr(9) & flightNumber & Chr(9) & cityCode & Chr(9) & "  " '"  " for country code

    End Function
End Class
