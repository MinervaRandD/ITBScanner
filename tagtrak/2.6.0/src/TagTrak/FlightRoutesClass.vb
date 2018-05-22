Imports System
Imports System.IO


Public Class FlightRoutesClass

    Inherits Hashtable

    Public effectiveDate As Date = Nothing
    Public discontinueDate As Date = Nothing

    Public Sub New(ByVal inputFileName As String)

        Me.Clear()

        Dim inputStream As StreamReader

        Try

            inputStream = New StreamReader(inputFileName)

        Catch ex As Exception

            Return

        End Try

        Try

            Dim inputLine As String

            inputLine = inputStream.ReadLine()

            Dim fieldSet As String() = inputLine.Split("|"c)

            If fieldSet.Length <> 2 Then

                Return

            End If

            Me.effectiveDate = Date.Parse(fieldSet(0).Trim(), cultureInfo)
            Me.discontinueDate = Date.Parse(fieldSet(1).Trim(), cultureInfo)

            inputLine = inputStream.ReadLine()

            While Not inputLine Is Nothing

                Dim lineLength As Integer = inputLine.Length

                If (lineLength Mod 4) = 0 Then

                    Dim flightNumber As String = inputLine.Substring(0, 4)

                    Dim ilmt As Integer = (lineLength / 4) - 1

                    Dim i As Integer

                    For i = 1 To ilmt

                        Dim routeCode As String = inputLine.Substring(4 * i, 4)

                        If Not Me.ContainsKey(routeCode) Then
                            Me.Add(routeCode, flightNumber)
                        End If

                    Next

                End If

                inputLine = inputStream.ReadLine()

            End While

        Catch ex As Exception

            Return

        End Try
    End Sub

End Class
