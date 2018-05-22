Imports System
Imports System.IO
Imports System.Collections

Module Ontime

    Public ontimeTable As New Hashtable
    Public ontimePrompt As New Hashtable

    Public Function loadOntimeFile(ByVal localOntimeFilePath As String, Optional ByVal displayErrors As Boolean = True) As String

        Dim closeoutDateAndTime As DateTime = Nothing
        Dim departureDateAndTime As DateTime = Nothing
        Dim flightNumber As String = Nothing

        If Not File.Exists(localOntimeFilePath) Then

            Dim errorMessage As String = "Ontime file """ & localOntimeFilePath & """ not found."

            If displayErrors Then
                MsgBox(errorMessage)
            End If

            Return errorMessage

        End If

        ontimeTable.Clear()
        ontimePrompt.Clear()

        Dim ontimeInputStream As StreamReader

        Try

            ontimeInputStream = New StreamReader(localOntimeFilePath)

        Catch ex As Exception

            Dim errorMessage As String = "Unable to open ontime file """ & localOntimeFilePath & """: " & ex.Message

            If displayErrors Then
                MsgBox(errorMessage)
            End If

            Return errorMessage

        End Try

        Try

            Dim inputRecord As String
            Dim ontimeRecord As OntimeRecord

            inputRecord = ontimeInputStream.ReadLine

            While Not inputRecord Is Nothing

                If inputRecord.StartsWith("+") Then
                    Dim fieldList As String() = inputRecord.Substring(1).Split(",")

                    Try

                        closeoutDateAndTime = DateTime.Parse(fieldList(0).Trim())
                        departureDateAndTime = DateTime.Parse(fieldList(1).Trim())
                        flightNumber = fieldList(2).Trim()


                    Catch ex As Exception

                        Dim errorMessage As String = "Invalid date / time header information in ontime file."

                        If displayErrors Then
                            MsgBox(errorMessage)
                        End If

                        Return errorMessage

                    End Try

                Else

                    If flightNumber Is Nothing Then

                        Dim errorMessage As String = "Unitialized ontime header fields."

                        If displayErrors Then
                            MsgBox(errorMessage)
                        End If

                        Return errorMessage

                    End If

                    ontimeRecord = New OntimeRecord(inputRecord, closeoutDateAndTime, departureDateAndTime, flightNumber)

                    If ontimeRecord.isValid Then

                        If Not ontimeTable.ContainsKey(ontimeRecord.DandRTag) Then

                            ontimeTable.Add(ontimeRecord.DandRTag, ontimeRecord)

                        End If

                    End If

                End If

                inputRecord = ontimeInputStream.ReadLine

            End While

        Catch ex As Exception

            Dim errorMessage As String = "Read on ontime file """ & localOntimeFilePath & """ failed: " & ex.Message

            If displayErrors Then
                MsgBox(errorMessage)
            End If

            Return errorMessage

        End Try

        Return "OK"

    End Function

    '' Validate this record with ontime accept rules:
    '' If ontime record exists and is not set to accept without prompting,
    '' and city config is set to prompt,
    '' and we didn't already prompt before,
    '' then check if the mail is late and prompt (sometimes we allow somewhat late mail).
    Public Function checkOntime(ByVal operation As String, ByVal DandRTag As String) As String

        'Added by MX
        Dim currentCityConfig As CityConfig = CType(userSpecRecord.cityTable.Item(scanLocation.currentLocation), CityConfig)

        If operation.ToUpper <> "POSSESSION" Then Return "OK"

        Dim ontimeRecord As OntimeRecord = ontimeTable(DandRTag)

        If DandRTag Is Nothing Then Return "OK"

        If ontimeRecord Is Nothing Then Return "OK"

        If ontimeRecord.acceptWithoutPrompting Then Return "OK"

        If Not CType(userSpecRecord.cityTable.Item(scanLocation.currentLocation), CityConfig).GetSetlateMailPrompt Then
            Return "OK"
        End If

        If ontimePrompt.ContainsKey(ontimeRecord.flightNumber & ontimeRecord.departureDateAndTime) Then
            If CBool(ontimePrompt.Item(ontimeRecord.flightNumber & ontimeRecord.departureDateAndTime)) Then Return "OK"
        End If

        '' Accept somewhat late mail without prompting?
        If currentCityConfig.GetSetAllowLateMailAccept Then
            If currentCityConfig.GetSetAllowLateMailAcceptPeriod > 0 Then
                Dim tempDateTime As DateTime
                tempDateTime = ontimeRecord.closeoutDateAndTime.AddMinutes(currentCityConfig.GetSetAllowLateMailAcceptPeriod)

                If DateTime.Compare(tempDateTime, Time.Local.GetTime(scannerTimeZone)) <= 0 Then
                    Dim ontimeMangementForm As New OntimeManagementForm(ontimeRecord)
                    Dim result As DialogResult = ontimeMangementForm.ShowDialog

                    If result <> DialogResult.OK Then Return "Pickup time after closeout time."

                    Return "OK"
                Else
                    Return "OK"
                End If

            End If

        End If

        ''Is is late?
        If DateTime.Compare(ontimeRecord.closeoutDateAndTime, Time.Local.GetTime(scannerTimeZone)) <= 0 Then
            '' Prompt

            Dim ontimeMangementForm As New OntimeManagementForm(ontimeRecord)
            Dim result As DialogResult = ontimeMangementForm.ShowDialog

            If result <> DialogResult.OK Then Return "Pickup time after closeout time."

        End If

        Return "OK"

    End Function

End Module
