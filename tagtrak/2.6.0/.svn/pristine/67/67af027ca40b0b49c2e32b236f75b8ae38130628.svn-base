Public Class CargoScanRecordClass

    Public cartID As String
    Public pieces As String
    Public hazmatFlag As Boolean
    Public weight As String
    Public transCarrier As String
    Public shelf As String
    Public bin As String
    Public oldFlightNumber As String

    Public Overrides Function ToString() As String

        Dim returnString As String

        returnString = cartID
        returnString &= TagTrakGlobals.fieldSepChar & pieces
        returnString &= TagTrakGlobals.fieldSepChar & weight
        returnString &= TagTrakGlobals.fieldSepChar & transCarrier
        returnString &= TagTrakGlobals.fieldSepChar & hazmatFlag.ToString()
        returnString &= TagTrakGlobals.fieldSepChar & shelf
        returnString &= TagTrakGlobals.fieldSepChar & bin
        returnString &= TagTrakGlobals.fieldSepChar & oldFlightNumber

        Return returnString

    End Function

    Public Function CreateCopy() As CargoScanRecordClass

        Dim newCargoScanRecord As New CargoScanRecordClass

        newCargoScanRecord.cartID = cartID
        newCargoScanRecord.pieces = pieces
        newCargoScanRecord.hazmatFlag = hazmatFlag
        newCargoScanRecord.weight = weight
        newCargoScanRecord.transCarrier = transCarrier
        newCargoScanRecord.shelf = shelf
        newCargoScanRecord.bin = bin
        newCargoScanRecord.oldFlightNumber = oldFlightNumber

        Return newCargoScanRecord

    End Function

End Class
