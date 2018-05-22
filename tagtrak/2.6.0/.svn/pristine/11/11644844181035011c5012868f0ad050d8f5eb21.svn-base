Public Class BagScanRecordClass

    Public cartID As String
    Public holdPosition As String
    Public containerPosition As String
    Public pieceCount As String

    Public Overrides Function ToString() As String

        Dim returnString As String

        returnString = cartID & TagTrakGlobals.fieldSepChar & holdPosition & TagTrakGlobals.fieldSepChar
        returnString &= containerPosition & TagTrakGlobals.fieldSepChar & pieceCount

        Return returnString

    End Function

    Public Function CreateCopy() As BagScanRecordClass

        Dim newBagScanRecord As New BagScanRecordClass

        newBagScanRecord.cartID = cartID
        newBagScanRecord.holdPosition = holdPosition
        newBagScanRecord.pieceCount = pieceCount
        newBagScanRecord.containerPosition = containerPosition

        Return newBagScanRecord

    End Function

End Class
