'Imports System
'Imports System.IO

'Public Class flightRecordSetClass
'    Inherits Hashtable

'    Public scheduleBuffer() As Byte
'    Public numberOfRecords As Integer

'    Dim compareBuffer(7) As Byte

'    Event Updated()

'    Public Function addRecord(ByRef flightRecord As flightRecordClass) As Boolean

'        Dim hashKey As String = flightRecord.genHashKey

'        If Me.ContainsKey(hashKey) Then Return False

'        Me.Add(hashKey, flightRecord)

'        Return True

'    End Function

'    Public Overloads ReadOnly Property Values(ByVal city As String) As flightRecordClass()
'        Get
'            Cursor.Current = Cursors.WaitCursor()

'            ' Really populate the set with records read from buffer
'            Dim fl() As flightRecordClass
'            ReDim fl(numberOfRecords)

'            Dim i As Integer
'            Dim j As Integer = 0
'            For i = 0 To numberOfRecords - 1
'                Dim curBase As Integer = i * 10
'                Dim cityCode As String = Chr(scheduleBuffer(curBase)) & _
'                    Chr(scheduleBuffer(curBase + 1)) & _
'                    Chr(scheduleBuffer(curBase + 2))
'                If cityCode = city Then
'                    Dim flight As New flightRecordClass
'                    flight.cityCode = cityCode
'                    flight.flightNumber = Chr(scheduleBuffer(curBase + 3)) & _
'                        Chr(scheduleBuffer(curBase + 4)) & _
'                        Chr(scheduleBuffer(curBase + 5)) & _
'                        Chr(scheduleBuffer(curBase + 6))
'                    If Chr(scheduleBuffer(curBase + 7)) = "I" Or Chr(scheduleBuffer(curBase + 8)) = "I" Then flight.isInboundFlight = True
'                    If Chr(scheduleBuffer(curBase + 7)) = "O" Or Chr(scheduleBuffer(curBase + 8)) = "O" Then flight.isOutboundFlight = True
'                    fl(j) = flight
'                    j = j + 1
'                End If
'            Next

'            ReDim Preserve fl(j - 1)

'            Cursor.Current = Cursors.Default

'            Return fl
'        End Get
'    End Property



'    Private Function recordCompare(ByVal recordNumber As Integer) As Integer

'#If ValidationLevel >= 3 Then

'        if diagnosticLevel >= 2 then
'             verify(recordNumber >= 0, 3000)
'	end if

'#End If

'        Dim recordIndex As Integer = recordNumber * 10
'        Dim recordIndexLimit As Integer = recordIndex + 7
'        Dim i As Integer = 0

'        Dim delta As Integer

'        While recordIndex < recordIndexLimit

'            If compareBuffer(i) < scheduleBuffer(recordIndex) Then Return -1
'            If compareBuffer(i) > scheduleBuffer(recordIndex) Then Return 1

'            i += 1
'            recordIndex += 1

'        End While

'        Return 0

'    End Function

'    Private Sub setRecordValues(ByVal recordIndex As Integer, ByRef inboundFlight As Boolean, ByRef outboundFlight As Boolean)

'#If ValidationLevel >= 3 Then

'        if diagnosticLevel >= 2 then
'             verify(recordIndex >= 0, 3001)
'	end if

'#End If

'        recordIndex = 10 * recordIndex + 7

'        If scheduleBuffer(recordIndex) = Asc("I"c) Then
'            inboundFlight = True
'        ElseIf scheduleBuffer(recordIndex) = Asc("O"c) Then
'            outboundFlight = True
'        End If

'        recordIndex += 1

'        If scheduleBuffer(recordIndex) = Asc("I"c) Then
'            inboundFlight = True
'        ElseIf scheduleBuffer(recordIndex) = Asc("O"c) Then
'            outboundFlight = True
'        End If

'    End Sub

'    Public Sub getRecord(ByVal flightNumber As String, ByVal cityCode As String, ByRef inboundFlight As Boolean, ByRef outboundFlight As Boolean)

'#If ValidationLevel >= 3 Then

'        if diagnosticLevel >= 2 then
'             verify(not flightNumber is nothing, 3002)
'	     verify(not cityCode is nothing, 3003)
'	end if

'#End If

'        inboundFlight = False
'        outboundFlight = False

'        If Not isNonNullString(cityCode) Then Exit Sub

'        If numberOfRecords <= 0 Then Exit Sub

'        cityCode = Trim(cityCode)

'        If Length(cityCode) <> 3 Then Exit Sub

'        If Not isNonNullString(flightNumber) Then Exit Sub

'        flightNumber = Trim(flightNumber).PadLeft(4, "0")

'        If Length(flightNumber) <> 4 Then Exit Sub


'        compareBuffer(0) = Asc(cityCode.Chars(0))
'        compareBuffer(1) = Asc(cityCode.Chars(1))
'        compareBuffer(2) = Asc(cityCode.Chars(2))

'        compareBuffer(3) = Asc(flightNumber.Chars(0))
'        compareBuffer(4) = Asc(flightNumber.Chars(1))
'        compareBuffer(5) = Asc(flightNumber.Chars(2))
'        compareBuffer(6) = Asc(flightNumber.Chars(3))

'        Dim upperIndex, lowerIndex, middleIndex As Integer
'        Dim compareResult As Integer

'        upperIndex = numberOfRecords - 1
'        lowerIndex = 0
'        middleIndex = CInt((upperIndex + lowerIndex) / 2)

'        While (upperIndex - lowerIndex >= 2)

'            middleIndex = CInt(Math.Floor((upperIndex + lowerIndex) / 2))

'            compareResult = recordCompare(middleIndex)

'            If compareResult < 0 Then
'                upperIndex = middleIndex
'            ElseIf compareResult > 0 Then
'                lowerIndex = middleIndex
'            Else
'                setRecordValues(middleIndex, inboundFlight, outboundFlight)
'                Exit Sub
'            End If

'        End While

'        compareResult = recordCompare(lowerIndex)

'        If compareResult = 0 Then
'            setRecordValues(lowerIndex, inboundFlight, outboundFlight)
'            Exit Sub
'        End If

'        compareResult = recordCompare(upperIndex)

'        If compareResult = 0 Then
'            setRecordValues(lowerIndex, inboundFlight, outboundFlight)
'            Exit Sub
'        End If

'        Exit Sub

'    End Sub

'    ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
'    '                                                                              '
'    ' Function: read. Returns: status information as a string                      '
'    '                                                                              '
'    ' Populates the flight record set with elements drawn from the input file      '
'    ' path.                                                                        '
'    '                                                                              '
'    ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

'    Public Function read(ByVal filePath As String) As String

'        Dim result As String

'        If Not File.Exists(filePath) Then
'            result = "flightRecordSetClass::read|Input file '" & filePath & "' does not exist"
'            Return result
'        End If

'        Dim inputFileStream As FileStream

'        Dim inputFileSize As Integer = getFileSize(filePath)

'        If inputFileSize < 0 Then
'            result = "flightRecordSetClass::read|Unable to stat input file '" & filePath & "'"
'            Return result
'        End If

'        If inputFileSize Mod 10 <> 0 Then
'            Return "Invalid routing file."
'        End If

'        Try
'            inputFileStream = New FileStream(filePath, FileMode.Open)
'        Catch ex As Exception
'            Return "flightRecordSetClass::read|Open on input file '" & filePath & "' failed|" & ex.Message
'        End Try

'        ReDim scheduleBuffer(inputFileSize)

'        Try
'            inputFileStream.Read(scheduleBuffer, 0, inputFileSize)
'        Catch ex As Exception
'            Return "flightRecordSetClass::read|Read on input file '" & filePath & "' failed|" & ex.message
'        End Try

'        numberOfRecords = inputFileSize / 10

'        inputFileStream.Close()

'        RaiseEvent Updated()

'        Return "OK"

'    End Function

'End Class
