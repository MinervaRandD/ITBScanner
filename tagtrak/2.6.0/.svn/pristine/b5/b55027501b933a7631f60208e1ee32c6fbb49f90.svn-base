Public Class dateTimeIntervalRecordClass

    Public minValue As New DateTime(0)
    Public maxValue As New DateTime(0)

    Public Function isValid() As Boolean

        If minValue > maxValue Then
            Return False
        Else
            Return True
        End If

    End Function

    Public Sub New(ByVal inputMinValue as datetime, ByVal inputMaxValue as datetime)

#if ValidationLevel >= 3 then

        if diagnosticLevel >= 2 then
            verify(datetime.compare(inputMinValue, inputMaxValue) <= 0, 2400)
        end if

#endif

        minValue = inputMinValue
        maxValue = inputMaxValue

        If Not isValid() Then
            MsgBox("Invalid date time interval")
            Stop
        End If

    End Sub

End Class
