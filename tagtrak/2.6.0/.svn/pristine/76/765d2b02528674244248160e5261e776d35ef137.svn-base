Public Class CarditRoutingClass

    Public strIntlBarCode As String
    Public carditLegList As New ArrayList
    'Public destinationCity As String
    Public creationDateStamp As DateTime
    Public Origin As String


    Private Sub reset()

        strIntlBarCode = ""
        carditLegList.Clear()
        Origin = ""
        creationDateStamp = New DateTime(0)

    End Sub

    Public Sub New(ByVal mailScanGetCarditRoute As getCarditRouteForm)

        Dim cbxCarrierCode As ComboBox
        Dim tbxFlightNumber As TextBox
        Dim cbxCityCode As ComboBox

        Dim i As Integer

        reset()

        If isNonNullString(mailScanGetCarditRoute.strIntlBarcode) Then
            strIntlBarCode = mailScanGetCarditRoute.strIntlBarcode
        End If

        Origin = mailScanGetCarditRoute.Origin.SelectedItem

        For i = 0 To 5

            cbxCarrierCode = mailScanGetCarditRoute.cbxCarrierList(i)
            tbxFlightNumber = mailScanGetCarditRoute.tbxFlightNumberList(i)
            cbxCityCode = mailScanGetCarditRoute.cbxCityList(i)

            Dim carditFlightLeg As New CarditFlightLegClass(cbxCarrierCode, tbxFlightNumber, cbxCityCode)

            If carditFlightLeg.containsANonNullEntry Then

                If Not carditFlightLeg.isValid Then
                    reset()
                    Return
                End If

                carditLegList.Add(carditFlightLeg)

                'destinationCity = carditFlightLeg.cityCode ' always default to last one

            End If

        Next

        'cbxCityCode = mailScanGetCarditRoute.cbxCityList(6)

        'If isNonNullString(cbxCityCode.Text) Then destinationCity = cbxCityCode.Text

        creationDateStamp = Time.Local.GetTime(scannerTimeZone)

    End Sub

    Public Function isValid() As Boolean

        If Not isNonNullString(strIntlBarCode) Then Return False
        If Not isNonNullString(Origin) Then Return False

        If Me.carditLegList.Count <= 0 Then Return False

        If DateTime.Compare(creationDateStamp, New DateTime(0)) <= 0 Then Return False

        Return True

    End Function

    Public Overrides Function ToString() As String

        Dim returnString As String

        If Not isValid() Then
            Return "??????????"
        End If

        returnString = "I" & TagTrakGlobals.fieldSepChar & Me.strIntlBarCode & TagTrakGlobals.fieldSepChar
        returnString &= String.Format("{0:MM/dd/yyyy" & TagTrakGlobals.fieldSepChar & "HH:mm}", Me.creationDateStamp) & TagTrakGlobals.fieldSepChar

        returnString &= Me.Origin & TagTrakGlobals.fieldSepChar
        returnString &= "  " ' place-holder for country-code, to be compatible with server script, which need to work with earlier versions having country code

        Dim carditFlightLeg As CarditFlightLegClass

        For Each carditFlightLeg In Me.carditLegList
            returnString &= TagTrakGlobals.fieldSepChar & carditFlightLeg.ToString()
        Next

        Return returnString

    End Function
End Class
