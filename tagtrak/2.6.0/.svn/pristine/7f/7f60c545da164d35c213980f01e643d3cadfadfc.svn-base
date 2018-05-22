Imports System
Imports System.io

'' This handles our Routings.bin file.
'' Essentially Routings.bin is a bit-map of routing code hash values.
'' Using Routings.bin we can determine if a certain routing code is enabled or not.
Class routingSetClass

    'Inherits Hashtable

    Public routingSetLoaded As Boolean = False

    Public sourceFileDateAndTime As New DateTime(0)

    Public locationCode As String = ""

    Public Const routingTableSize As Integer = (36 ^ 4) / 8

    Public routingFilePath As String
    Public routingFileStream As System.IO.Stream
    Public routingTable(routingTableSize) As Byte

    Public setBitMask() As Byte = {&H1, &H2, &H4, &H8, &H10, &H20, &H40, &H80}
    Public clrBitMask(8) As Byte

    Public Sub clear()
        Dim i, ilmt As Integer

        ilmt = routingTableSize - 1

        For i = 0 To ilmt
            routingTable(i) = 0
        Next

        routingSetLoaded = False

    End Sub

    Public Sub New(ByRef inputRoutingTablePath As String)

#if ValidationLevel >= 3 then
        
	if diagnosticLevel >= 2 then
            verify(not inputRoutingTablePath is nothing, 1600)
	end if

#endif

        routingFilePath = inputRoutingTablePath

        Dim i, ilmt As Integer

        For i = 0 To 7
            clrBitMask(i) = Not setBitMask(i)
        Next

        clear()

    End Sub

    Public Sub New()
        routingFilePath = ""

        Dim i, ilmt As Integer

        For i = 0 To 7
            clrBitMask(i) = Not setBitMask(i)
        Next

        clear()

    End Sub

    Public Function read() As String

        If Not isNonNullString(routingFilePath) Then
            Return "Invalid routing file path"
        End If

        Try
            routingFileStream = File.OpenRead(routingFilePath)
        Catch ex As Exception
            Return "Open on routing file failed: " & ex.Message
        End Try

        Try
            routingFileStream.Read(routingTable, 0, routingTableSize)
        Catch ex As Exception
            routingFileStream.Close()
            Return "Read on routing file failed: " & ex.message
        End Try

        routingSetLoaded = True

        routingFileStream.Close()

        Return "OK"

    End Function

    Public Function read(ByRef inputRoutingFilePath As String) As String

#if ValidationLevel >= 3 then

        if diagnosticLevel >= 2 then
            verify(not inputRoutingFilePath is nothing, 1700)
	end if

#end if

        routingFilePath = inputRoutingFilePath

        Return read()

    End Function

    Public Function write() As Object

        If Not isNonNullString(routingFilePath) Then
            Return "Invalid routing file path"
        End If

        deleteLocalFile(routingFilePath)

        Try
            routingFileStream = File.OpenWrite(routingFilePath)
        Catch ex As Exception
            Return "Open on routing file for write failed: " & ex.Message
        End Try

        Try
            routingFileStream.Write(routingTable, 0, routingTableSize)
        Catch ex As Exception
            routingFileStream.Close()
            Return "Write on routing file failed: " & ex.message
        End Try

        routingFileStream.Close()

    End Function

    Public Function write(ByRef outputRoutingFilePath As String) As Boolean

#if ValidationLevel >= 3 then

        if diagnosticLevel >= 2 then
            verify(not outputRoutingFilePath is nothing, 1701)
	end if

#end if

        routingFilePath = outputRoutingFilePath

        Return write()

    End Function

    Private Function getCharvalue(ByVal nextChar As Char)

        Dim byteValue As Integer

        If Char.IsDigit(nextChar) Then
            Return Asc(nextChar) - Asc("0"c)
        End If

        If Char.IsLetter(nextChar) Then
            Return Asc(nextChar) - Asc("A"c) + 10
        End If

        MsgBox("System error: invalid character in buffer")

    End Function

    Private Function getRoutingIndex(ByRef routingKey As String) As Integer

#if ValidationLevel >= 3 then

        if diagnosticLevel >= 2 then
            verify(not routingKey is nothing, 1702)
	end if

#end if

        Dim routingKeyBuffer As Char()

        routingKeyBuffer = routingKey.ToCharArray

        Dim charIndex As Integer

        Dim returnValue As Integer

        charIndex = getCharvalue(Char.ToUpper(routingKeyBuffer(0)))

        returnValue = charIndex

        charIndex = getCharvalue(Char.ToUpper(routingKeyBuffer(1)))

        returnValue = returnValue * 36 + charIndex

        charIndex = getCharvalue(Char.ToUpper(routingKeyBuffer(2)))

        returnValue = returnValue * 36 + charIndex

        charIndex = getCharvalue(Char.ToUpper(routingKeyBuffer(3)))

        returnValue = returnValue * 36 + charIndex

        Return returnValue

    End Function

    Private Function getOffsets(ByVal routingIndex As Integer, ByRef byteOffset As Integer, ByRef bitOffset As Integer)

#if ValidationLevel >= 3 then

        if diagnosticLevel >= 2 then
            verify(routingIndex >= 0, 1703)
            verify(byteOffset >= 0, 1704)
            verify(bitOffset >= 0, 1705)
	end if

#end if

        byteOffset = routingIndex >> 3
        bitOffset = routingIndex Mod 8

    End Function

    Private Function getOffsets(ByRef routingKey As String, ByRef byteOffset As Integer, ByRef bitOffset As Integer)

#if ValidationLevel >= 3 then

        if diagnosticLevel >= 2 then
            verify(not routingKey is nothing, 1706)
            verify(byteOffset >= 0, 1707)
            verify(bitOffset >= 0, 1708)
	end if

#end if

        Dim routingIndex As Integer = getRoutingIndex(routingKey)

        byteOffset = routingIndex >> 3
        bitOffset = routingIndex Mod 8

    End Function

    Public Function isValidRoutingKey(ByRef routingKey As String) As Boolean

#if ValidationLevel >= 3 then

        if diagnosticLevel >= 2 then
            verify(not routingKey is nothing, 1710)
	end if

#end if

        If Not isNonNullString(routingKey) Then Return False

        If Length(routingKey) <> 4 Then Return False

        Dim c As Char

        For Each c In routingKey
            If Not Char.IsLetterOrDigit(c) Then Return False
        Next
      
        Return True

    End Function

    Public Function containsRouting(ByRef routingKey As String) As Boolean

#if ValidationLevel >= 3 then

        if diagnosticLevel >= 2 then
            verify(not routingKey is nothing, 1711)
	end if

#end if

        If Not isValidRoutingKey(routingKey) Then
            MsgBox("Invalid routing key in containsRouting")
            Return False
        End If

        Dim byteOffset As Integer
        Dim bitOffset As Integer

        getOffsets(routingKey, byteOffset, bitOffset)

        Dim returnValue As Boolean = (routingTable(byteOffset) And setBitMask(bitOffset)) <> 0

        Return returnValue

    End Function

    Private Function saveUpdatedByteToRoutingTableSource(ByVal byteOffset As Integer) As String

#if ValidationLevel >= 3 then

        if diagnosticLevel >= 2 then
            verify(byteOffset >= 0, 1712)
	end if

#end if

        If Not routingSetLoaded Then
            Return "Attempt to save unloaded routing file."
        End If

        If Not isNonNullString(routingFilePath) Then
            Return "Invalid routing file path"
        End If

        Dim routingWriteByteStream As System.IO.FileStream
        Dim routingFileStream As System.IO.FileStream

        'Modified by MX
        Dim localFilePath As String = deviceNonVolatileMemoryDirectory & selectedCarrierPath & "\Routings.bin"

        If Not File.Exists(localFilePath) Then Return False

        Dim fi As FileInfo

        Try
            fi = New FileInfo(localFilePath)
        Catch ex As Exception
            Return "Unable to stat routings file: " & ex.message
        End Try

        Try
            fi.Attributes = FileAttributes.Normal
        Catch ex As Exception
            Return "Unable to change routings file attributes: " & ex.message
        End Try

        Try
            routingFileStream = New System.IO.FileStream(localFilePath, FileMode.Open)

        Catch ex As Exception

            Return "Attempt to update routing file failed: " & ex.Message

        End Try

        Try

            routingFileStream.Seek(byteOffset, SeekOrigin.Begin)

        Catch ex As Exception

            routingFileStream.Close()
            Return "Seek on add failed: " & ex.Message

        End Try

        Try
            routingFileStream.WriteByte(routingTable(byteOffset))
        Catch ex As Exception
            routingFileStream.Close()
            Return "Write Byte on add failed: " & ex.Message

        End Try

        routingFileStream.Close()

        Return "OK"

    End Function

    Public Function add(ByRef routingKey As String, Optional ByVal updateFile As Boolean = True) As String

#if ValidationLevel >= 3 then

        if diagnosticLevel >= 2 then
            verify(not routingKey is nothing, 1713)
	end if

#end if

        If Not isValidRoutingKey(routingKey) Then
            Return "Invalid routing key in add"
        End If

        Dim byteOffset As Integer
        Dim bitOffset As Integer

        getOffsets(routingKey, byteOffset, bitOffset)

        routingTable(byteOffset) = routingTable(byteOffset) Or setBitMask(bitOffset)

        If Not updateFile Then Return "OK"

        Return saveUpdatedByteToRoutingTableSource(byteOffset)

    End Function

    Public Function delete(ByRef routingKey As String, Optional ByVal updateFile As Boolean = True) As Object

#if ValidationLevel >= 3 then

        if diagnosticLevel >= 2 then
            verify(not routingKey is nothing, 1714)
	end if

#end if

        If Not isValidRoutingKey(routingKey) Then
            MsgBox("Invalid routing key in delete")
            Exit Function
        End If

        Dim byteOffset As Integer
        Dim bitOffset As Integer

        getOffsets(routingKey, byteOffset, bitOffset)

        routingTable(byteOffset) = routingTable(byteOffset) And clrBitMask(bitOffset)

        If Not updateFile Then Return "OK"

        Return saveUpdatedByteToRoutingTableSource(byteOffset)

    End Function

    Public Function update(ByVal updateFileName As String) As String

#if ValidationLevel >= 3 then

        if diagnosticLevel >= 2 then
            verify(not updateFileName is nothing, 1715)
	end if

#end if

        Dim result As String

        Dim routingUpdateFileStream As StreamReader

        Try
            routingUpdateFileStream = New StreamReader(updateFileName)
        Catch ex As Exception
            Return "Unable to open updates file '" & updateFileName & "': " & ex.Message
        End Try

        Dim routingRecord As String

        routingRecord = routingUpdateFileStream.ReadLine()

        While Not routingRecord Is Nothing

            If Length(routingRecord) <> 5 Then
                routingUpdateFileStream.Close()
                Return "Invalid record in routing update file"
            End If

            Dim updateType As String = substring(routingRecord, 0, 1).ToUpper

            routingRecord = substring(routingRecord, 1).ToUpper

            If updateType = "A" Then

                result = routingSet.add(routingRecord, False)

                If result <> "OK" Then
                    routingUpdateFileStream.Close()
                    Return "Add to routings table failed: " & result
                End If

            ElseIf updateType = "D" Then

                result = routingSet.delete(routingRecord, False)

                If result <> "OK" Then
                    routingUpdateFileStream.Close()
                    Return "Delete from routings table failed: " & result
                End If

            Else
                routingUpdateFileStream.Close()
                Return "Invalid record in routing update file"
            End If

            routingRecord = routingUpdateFileStream.ReadLine()

        End While

        routingUpdateFileStream.Close()
        routingSet.write()

        Return "OK"

    End Function

End Class

