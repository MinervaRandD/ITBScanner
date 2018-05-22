Public Class MailDomsScanRecordClass

    Public tailNumber As String
    Public rejectReason As String
    Public groupNumber As String
    Public oldFlightNumber As String
    Public oldDestinationCode As String
    Public weight As Double

    Public Overrides Function ToString() As String

        Dim returnString As String

        returnString = weight.ToString(cultureInfo) & TagTrakGlobals.fieldSepChar & tailNumber & TagTrakGlobals.fieldSepChar & groupNumber & TagTrakGlobals.fieldSepChar
        returnString &= rejectReason & TagTrakGlobals.fieldSepChar & oldFlightNumber & TagTrakGlobals.fieldSepChar & oldDestinationCode

        Return returnString

    End Function

    Public Function CreateCopy() As MailDomsScanRecordClass

        Dim newMailDomsScanRecord As New MailDomsScanRecordClass

        newMailDomsScanRecord.tailNumber = tailNumber
        newMailDomsScanRecord.rejectReason = rejectReason
        newMailDomsScanRecord.groupNumber = groupNumber
        newMailDomsScanRecord.oldFlightNumber = oldFlightNumber
        newMailDomsScanRecord.oldDestinationCode = oldDestinationCode
        newMailDomsScanRecord.weight = weight

        Return newMailDomsScanRecord

    End Function

End Class
