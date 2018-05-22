Namespace AutoUpdate

    Public Class Processor

        Private MyReader As Reader

        Sub New(ByVal TheReader As Reader)
            MyReader = TheReader
        End Sub

        Public Sub Update()
            Dim U As Reader.UpdateStruct
            For Each U In MyReader.Updates
                Try
                    IO.File.Copy(U.Source.FullName & "\" & U.FileName, MyReader.MyUpdateDir.FullName & "\" & U.FileName, True)
                    Console.WriteLine("Updated " & U.FileName & ".")
                Catch ex As Exception
                    Console.WriteLine("WARNING: Couldn't update " & MyReader.MyUpdateDir.FullName & "\" & U.FileName)
                End Try
            Next
        End Sub

    End Class

End Namespace