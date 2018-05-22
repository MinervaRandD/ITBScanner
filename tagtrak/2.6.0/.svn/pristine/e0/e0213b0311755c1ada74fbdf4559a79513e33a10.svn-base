Public Class buttonSpecRecordClass

    Public visible As Boolean
    Public location As System.Drawing.Point
    Public size As System.Drawing.Size
    Public text As String
    Public buttonName As String

    Public Sub reset()

        visible = False

        location = New System.Drawing.Point(-1, -1)
        size = New System.Drawing.Size(-1, -1)
        text = ""
        buttonName = ""

    End Sub

    Public Sub New(ByVal inputButtonName As String, ByVal inputVisible As Boolean, ByVal inputLocation As System.Drawing.Point, ByVal inputSize As System.Drawing.Size, ByVal inputText As String)

#If ValidationLevel >= 3 Then

        If diagnosticLevel >= 2 Then
            verify(Not inputText Is Nothing, 600)
            verify(Not inputButtonName Is Nothing, 601)
        End If

#End If

        buttonName = inputButtonName
        visible = inputVisible
        location = New System.Drawing.Point(inputLocation.X, inputLocation.Y)
        size = New System.Drawing.Size(inputSize.Width, inputSize.Height)
        text = inputText

    End Sub

    Public Sub New(ByRef inputButtonSpecRecord As buttonSpecRecordClass)

        buttonName = inputButtonSpecRecord.buttonName
        visible = inputButtonSpecRecord.visible
        location = New System.Drawing.Point(inputButtonSpecRecord.location.X, inputButtonSpecRecord.location.Y)
        size = New System.Drawing.Size(inputButtonSpecRecord.size.Width, inputButtonSpecRecord.size.Height)
        text = inputButtonSpecRecord.text

    End Sub

    Public Sub setEqualTo(ByRef inputButtonSpecRecord As buttonSpecRecordClass)

        buttonName = inputButtonSpecRecord.buttonName
        visible = inputButtonSpecRecord.visible
        location = New System.Drawing.Point(inputButtonSpecRecord.location.X, inputButtonSpecRecord.location.Y)
        size = New System.Drawing.Size(inputButtonSpecRecord.size.Width, inputButtonSpecRecord.size.Height)
        text = inputButtonSpecRecord.text

    End Sub

    Public Function parseIntegerPair(ByVal parmString As String, ByRef x As Integer, ByRef y As Integer) As String

#If ValidationLevel >= 3 Then

        If diagnosticLevel >= 2 Then
            verify(Not parmString Is Nothing, 601)
        End If

#End If

        Dim tokenSet() As String = parmString.Split(","c)

        If tokenSet.Length <> 2 Then Return "Invalid integer pair"

        x = CInt(Trim(tokenSet(0)))
        y = CInt(Trim(tokenSet(1)))

        Return "OK"

    End Function

    Public Function parseParm(ByVal parmString As String) As String

#If ValidationLevel >= 3 Then

        If diagnosticLevel >= 2 Then
            verify(Not parmString Is Nothing, 602)
        End If

#End If

        Dim parmSubstring As String
        Dim x, y As Integer
        Dim result As String

        If parmString.StartsWith("Location=(") Then

            If Not parmString.EndsWith(")") Then
                Return "Invalid parameter"
            End If

            result = parseIntegerPair(Substring(parmString, 10, Length(parmString) - 11), x, y)

            If result <> "OK" Then
                Return "Invalid parameter"
            End If

            location = New System.Drawing.Point(x, y)

            Return "OK"

        ElseIf parmString.StartsWith("Size=(") Then

            If Not parmString.EndsWith(")") Then
                Return "Invalid parameter"
            End If

            result = parseIntegerPair(Substring(parmString, 6, Length(parmString) - 7), x, y)

            If result <> "OK" Then
                Return "Invalid parameter"
            End If

            size = New System.Drawing.Size(x, y)

            Return "OK"

        ElseIf parmString.StartsWith("Text=") Then

            text = Substring(parmString, 5)

            Return "OK"

        Else

            Return "Invalid parameter"

        End If

        Return "OK"

    End Function

    Public Sub parse(ByVal parmString As String)

#If ValidationLevel >= 3 Then

        If diagnosticLevel >= 2 Then
            verify(Not parmString Is Nothing, 604)
        End If

#End If

        Dim parmSubstring As String
        Dim result As String

        Dim separatorLocation As Integer

        visible = True

        Do

            separatorLocation = parmString.IndexOf(",Location")

            If separatorLocation < 0 Then
                separatorLocation = parmString.IndexOf(",Size")
            End If

            If separatorLocation < 0 Then
                separatorLocation = parmString.IndexOf(",Text")
            End If

            If separatorLocation > 0 Then

                parmSubstring = Substring(parmString, 0, separatorLocation)
                parmString = Substring(parmString, separatorLocation + 1)

                result = parseParm(parmSubstring)

                If result <> "OK" Then
                    reset()
                    Exit Sub
                End If

            End If

        Loop While separatorLocation > 0

        If isNonNullString(parmString) Then
            result = parseParm(parmString)
            If result <> "OK" Then
                reset()
                Exit Sub
            End If
        End If

    End Sub

    Public Sub parse(ByVal locationString As String, ByVal sizeString As String, ByVal textString As String)

#If ValidationLevel >= 3 Then

        If diagnosticLevel >= 2 Then

            verify(Not locationString Is Nothing, 7500)
            verify(Not sizeString Is Nothing, 7501)
            verify(Not textString Is Nothing, 7502)

        End If
#End If

        locationString = Trim(locationString)
        sizeString = Trim(sizeString)
        textString = Trim(textString)

        If Not (isNonNullString(locationString) And isNonNullString(sizeString) And isNonNullString(textString)) Then

            Me.visible = False
            Exit Sub

        End If

        Dim tokenSet() As String

        Dim xString As String
        Dim yString As String

        tokenSet = locationString.Split(",")

        If tokenSet.Length <> 2 Then
            Me.visible = False
            Exit Sub
        End If

        xString = Trim(tokenSet(0))
        yString = Trim(tokenSet(1))

        If Not (IsInteger(xString) And IsInteger(yString)) Then
            Me.visible = False
            Exit Sub
        End If

        Try
            Me.location.X = CInt(xString)
            Me.location.Y = CInt(yString)
        Catch ex As Exception
            Me.visible = False
            Exit Sub
        End Try

        tokenSet = sizeString.Split(",")

        If tokenSet.Length <> 2 Then
            Me.visible = False
            Exit Sub
        End If

        xString = Trim(tokenSet(0))
        yString = Trim(tokenSet(1))

        If Not (IsInteger(xString) And IsInteger(yString)) Then
            Me.visible = False
            Exit Sub
        End If

        Try
            Me.size.Width = CInt(xString)
            Me.size.Height = CInt(yString)
        Catch ex As Exception
            Me.visible = False
            Exit Sub
        End Try

        Me.text = Trim(textString)

        Me.visible = True

    End Sub
End Class
