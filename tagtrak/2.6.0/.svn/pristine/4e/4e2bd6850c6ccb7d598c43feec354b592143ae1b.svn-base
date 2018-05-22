Public Class MailIntlScanRecordClass

    Public handoverPoint As String
    Public rejectReason As String
    Public cartID As String
    Public pieceCount As Integer
    Public oldFlightNumber As String
    Public oldDestinationCode As String
    Public weight As Double
    Public IntlPostOffice As String
    Public CN41 As String
    Public secondCarrier As String


    Public Overrides Function ToString() As String

        Dim returnString As String

        returnString = weight.ToString(cultureInfo) & TagTrakGlobals.fieldSepChar & handoverPoint & TagTrakGlobals.fieldSepChar
        returnString &= pieceCount & TagTrakGlobals.fieldSepChar & cartID & TagTrakGlobals.fieldSepChar
        returnString &= rejectReason & TagTrakGlobals.fieldSepChar & oldFlightNumber & TagTrakGlobals.fieldSepChar & oldDestinationCode
        returnString &= TagTrakGlobals.fieldSepChar & IntlPostOffice
        returnString &= TagTrakGlobals.fieldSepChar & CN41
        returnString &= TagTrakGlobals.fieldSepChar & secondCarrier

        Return returnString

    End Function

    Public Function CreateCopy() As MailIntlScanRecordClass

        Dim newMailIntlScanRecord As New MailIntlScanRecordClass

        newMailIntlScanRecord.handoverPoint = handoverPoint
        newMailIntlScanRecord.rejectReason = rejectReason
        newMailIntlScanRecord.cartID = cartID
        newMailIntlScanRecord.pieceCount = pieceCount
        newMailIntlScanRecord.oldFlightNumber = oldFlightNumber
        newMailIntlScanRecord.oldDestinationCode = oldDestinationCode
        newMailIntlScanRecord.weight = weight
        newMailIntlScanRecord.IntlPostOffice = IntlPostOffice
        newMailIntlScanRecord.CN41 = CN41
        newMailIntlScanRecord.secondCarrier = secondCarrier

        Return newMailIntlScanRecord

    End Function

End Class
