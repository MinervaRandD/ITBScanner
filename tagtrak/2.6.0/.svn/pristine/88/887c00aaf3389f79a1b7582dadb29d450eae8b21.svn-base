Public Class OperationsMapClass

    Dim MyOpMap As New Specialized.ListDictionary
    Dim MyRevOpMap As New Specialized.ListDictionary

    '' Returns the operation given the mapped operation
    Public Function GetOperation(ByVal TheMappedOperation As String) As String
        If MyRevOpMap.Contains(TheMappedOperation) Then
            Return MyRevOpMap.Item(TheMappedOperation)
        Else
            Return TheMappedOperation
        End If
    End Function

    '' Returns the mapped operartion given the mapped name
    Public Function GetMappedOperation(ByVal TheOperation As String) As String
        If MyOpMap.Contains(TheOperation) Then
            Return MyOpMap.Item(TheOperation)
        Else
            Return TheOperation
        End If
    End Function

    Public Sub SetMapping(ByVal TheOperation As String, ByVal TheMappedOperation As String)
        MyOpMap.Add(TheOperation, TheMappedOperation)
        MyRevOpMap.Add(TheMappedOperation, TheOperation)
    End Sub

    Public Sub Clear()
        MyOpMap = New Specialized.ListDictionary
        MyRevOpMap = New Specialized.ListDictionary
    End Sub

End Class
