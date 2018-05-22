Option Explicit On 
Option Strict On

Namespace Data.Cities
    '' Encapsulates a list of all cities
    Public Class List

        Private Shared CityList As New ArrayList

        Public Shared Function IsEmpty() As Boolean
            If Count() = 0 Then
                Return True
            Else
                Return False
            End If

        End Function

        Public Shared Function Count() As Integer
            Return CityList.Count
        End Function

        Public Shared Function Item(ByVal TheIndex As Integer) As String
            Return DirectCast(CityList.Item(TheIndex), String)
        End Function

        Public Shared Sub Clear()
            CityList.Clear()
        End Sub

        Public Shared Function ToArray() As String()
            '' Return as string array
            Return DirectCast(CityList.ToArray(GetType(String)), String())
        End Function

        Private Shared Sub Add(ByVal TheCityName As String)
            If TheCityName.Length = 3 Then
                TheCityName = TheCityName.ToUpper
                CityList.Add(TheCityName)
            End If
        End Sub

#Region "Load"
        '' Load list from file
        Public Shared Sub Load(ByVal TheFileName As String)
            Clear()

            Dim fs As IO.FileStream
            Dim sr As IO.StreamReader

            Try
                fs = New IO.FileStream(TheFileName, IO.FileMode.Open)
                sr = New IO.StreamReader(fs)

                Dim Input As String
                Input = sr.ReadLine
                Do While Input Is Nothing = False
                    Add(Input)
                    Input = sr.ReadLine
                Loop

                sr.Close()
                fs.Close()
            Catch ex As Exception
                If sr Is Nothing = False Then sr.Close()
                If fs Is Nothing = False Then fs.Close()
                '' Clear R if parsing error, might be junk data
                Clear()
            End Try

        End Sub
#End Region

    End Class
End Namespace