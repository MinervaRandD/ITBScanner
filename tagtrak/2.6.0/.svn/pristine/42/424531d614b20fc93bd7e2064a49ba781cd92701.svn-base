Option Explicit On 
Option Strict On

Namespace Data.FlightLoadInfo
    Public Class Info
        Private MyLoadInfo As Specialized.HybridDictionary

        Sub New()
            Clear()
        End Sub

        '' Returns whether a flight load is know.
        Public Function IsFlightLoadKnown(ByVal TheFlightNumber As Integer) As Boolean
            If MyLoadInfo.Contains(TheFlightNumber) Then
                Return True
            Else
                Return False
            End If

        End Function

        Public Function IsFlightLoadKnown(ByVal TheFlightNumber As String) As Boolean
            Dim FLNum As Integer
            Try
                FLNum = Integer.Parse(TheFlightNumber)
            Catch ex As Exception
                Return False
            End Try
            Return IsFlightLoadKnown(FLNum)

        End Function

        Public Sub Clear()
            MyLoadInfo = New Specialized.HybridDictionary
        End Sub

        Private Sub Add(ByVal TheFlightNumber As Integer)
            MyLoadInfo.Add(TheFlightNumber, True)
        End Sub

#Region "Parse"

        '' Returns an instance of Info from the input string data.
        '' Returns empty Info on invalid input.
        Public Shared Function Parse(ByVal TheData As String) As Info
            '' Data format:
            ''
            '' 0234
            '' 0123
            '' 0432
            '' ----                 Flight number

            Dim Result As New Info

            Dim sr As New IO.StringReader(TheData)
            Dim LineIn As String = sr.ReadLine

            Dim FlightNumber As Integer

            Do While Not LineIn Is Nothing
                '' Extract the information
                Try
                    FlightNumber = Integer.Parse(LineIn)
                Catch ex As Exception
                    '' Error parsing flight number, possibly corrupt data.
                    Return New Info
                End Try
                Result.Add(FlightNumber)

                LineIn = sr.ReadLine
            Loop

            sr.Close()

            Return Result

        End Function

        '' Parse from a filename.
        '' Returns Nothing on an error.
        Public Shared Function ParseFile(ByVal TheFileName As String) As Info
            Dim sr As IO.StreamReader
            Dim Input As String
            Try
                sr = New IO.StreamReader(TheFileName)
                Input = sr.ReadToEnd
                sr.Close()
            Catch ex As Exception
                Return Nothing
            End Try

            Return Parse(Input)

        End Function

#End Region

    End Class

End Namespace