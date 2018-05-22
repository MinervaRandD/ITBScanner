'Public Class flightRecordClass

'    Public flightNumber As Short
'    Public cityCode As String
'    Public isInboundFlight As Boolean
'    Public isOutboundFlight As Boolean

'    Private Sub reset()
'        flightNumber = -1
'        cityCode = ""
'        isInboundFlight = False
'        isOutboundFlight = False
'    End Sub

'    Public Function isValid() As Boolean

'        If flightNumber < 0 Then Return False
'        If Not isNonNullString(cityCode) Then Return False
'        If Length(cityCode) <> 3 Then Return False

'        Return True

'    End Function

'    Public Sub New()
'        reset()
'    End Sub

'    Public Sub New(ByVal flightRecordString As String)

'#if ValidationLevel >= 3 then

'        if diagnosticLevel >= 2 then
'            verify(not flightRecordString is nothing, 900)
'	end if

'#end if

'        parse(flightRecordString)

'    End Sub

'    Public Sub New(ByVal buffer() As Byte, ByRef buffIndex As Integer, ByVal bufferSize As Integer)

'#if ValidationLevel >= 3 then

'        if diagnosticLevel >= 2 then
'            verify(not buffer is nothing, 901)
'            verify(buffIndex >= 0, 902)
'            verify(bufferSize >= 0, 903)
'            verify(buffer.Length >= buffIndex + bufferSize, 1904)
'        End If

'#End If

'        Dim parseString As String = ""
'        Dim nextChar As Char

'        While buffIndex < bufferSize

'            nextChar = Chr(buffer(buffIndex))

'            If Char.IsLetterOrDigit(nextChar) Then Exit While

'            buffIndex += 1

'        End While

'        If buffIndex >= bufferSize Then
'            reset()
'            Exit Sub
'        End If

'        parseString = nextChar

'        buffIndex += 1

'        While buffIndex < bufferSize

'            nextChar = Chr(buffer(buffIndex))

'            If Not Char.IsLetterOrDigit(nextChar) Then Exit While

'            parseString &= nextChar

'            buffIndex += 1

'        End While

'        Me.parse(parseString)

'    End Sub

'    Public Sub parse(ByVal flightRecordString As String)

'#if ValidationLevel >= 3

'        if diagnosticLevel >= 2 then
'            verify(not flightRecordString is nothing, 904)
'	end if

'#end if

'        Dim flightNumberString As String = Substring(flightRecordString, 3, 4)
'        Dim cityCodeString As String = Trim(Substring(flightRecordString, 0, 3).ToUpper)
'        Dim directionString As String = Trim(Substring(flightRecordString, 7).ToUpper)

'        If Not Util.IsInteger(flightNumberString) Then
'            reset()
'            Exit Sub
'        End If

'        If Length(cityCodeString) <> 3 Then
'            reset()
'            Exit Sub
'        End If

'        If Not isNonNullString(directionString) Then
'            reset()
'            Exit Sub
'        End If

'        If Length(directionString) > 2 Then
'            reset()
'            Exit Sub
'        End If

'        flightNumber = flightNumberString
'        cityCode = cityCodeString

'        Me.isInboundFlight = False
'        Me.isOutboundFlight = False

'        If directionString.Chars(0) = "I"c Then
'            Me.isInboundFlight = True
'        ElseIf directionString.Chars(0) = "O"c Then
'            Me.isOutboundFlight = True
'        Else
'            reset()
'            Exit Sub
'        End If

'        If Length(directionString) = 1 Then Exit Sub

'        If directionString.Chars(1) = "I"c Then
'            Me.isInboundFlight = True
'        ElseIf directionString.Chars(1) = "O"c Then
'            Me.isOutboundFlight = True
'        Else
'            reset()
'            Exit Sub
'        End If

'    End Sub

'    Public Function genHashKey() As String

'        Return genHashKey(flightNumber, cityCode)

'    End Function

'    Private Function genHashKey(ByVal flightNumber As Short, ByVal cityCode As String)

'#If ValidationLevel >= 3 Then

'        if diagnosticLevel >= 2 then
'            verify(flightNumber >= 0 and flightNumber <= 9999, 920)
'            verify(not cityCode is nothing, 921)
'	end if

'#End If

'        Return String.Format("{0:000#}", flightNumber) & cityCode

'    End Function


'End Class
