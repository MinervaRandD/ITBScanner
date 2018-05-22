'Public Class DSTChangeDateProtocolClass

'    Inherits ArrayList

'    Public timeChangeIncrement As Double = 1.0

'    Enum DSTChangeDatesProtocolType
'        NoChange
'        NorthAmerican
'        European
'        Australian
'        Unknown
'        NewZealand
'        MidEast
'    End Enum

'    Public appliesToRange As dateTimeIntervalRecordClass

'    Public Function isValid() As Boolean

'        Dim dateTimeIntervalRecord As dateTimeIntervalRecordClass

'        If appliesToRange Is Nothing Then
'            If Me.Count > 0 Then
'                Return False
'            Else
'                Return True
'            End If
'        End If

'        If Me.Count <= 0 Then Return True

'        For Each dateTimeIntervalRecord In Me
'            If Not dateTimeIntervalRecord.isValid Then Return False
'        Next

'        Dim i, ilmt As Integer

'        ilmt = Me.Count - 1

'        dateTimeIntervalRecord = Me.Item(ilmt)

'        If appliesToRange.maxValue < dateTimeIntervalRecord.maxValue Then Return False

'        dateTimeIntervalRecord = Me.Item(0)

'        If appliesToRange.minValue > dateTimeIntervalRecord.minValue Then Return False

'        If ilmt = 0 Then Return True

'        For i = 1 To ilmt

'            Dim nextDateTimeIntervalRecord As dateTimeIntervalRecordClass = Me.Item(i)

'            If dateTimeIntervalRecord.maxValue > nextDateTimeIntervalRecord.minValue Then Return False

'            dateTimeIntervalRecord = nextDateTimeIntervalRecord

'        Next

'        Return True

'    End Function

'    Public Sub New()
'        Me.Clear()
'    End Sub

'    Public Sub New(ByVal inputAppliesToRange As dateTimeIntervalRecordClass, ByVal inputDateTimeIntervalList() As dateTimeIntervalRecordClass, Optional ByVal inputTimeChangeIncrement As Double = 1.0)

'#if ValidationLevel >= 3

'	if diagnosticLevel >= 2 then
'            verify(Not inputAppliesToRange Is Nothing, 400)
'            verify(Not inputDateTimeIntervalList Is Nothing, 401)
'        end if

'#endif

'        appliesToRange = inputAppliesToRange

'        If inputDateTimeIntervalList Is Nothing Then Exit Sub

'        Dim dateTimeIntervalRecord As dateTimeIntervalRecordClass

'        For Each dateTimeIntervalRecord In inputDateTimeIntervalList
'            Me.Add(dateTimeIntervalRecord)
'        Next

'        If Not isValid() Then
'            MsgBox("Invalid daylight saving time change date protocol")
'            Stop
'        End If

'    End Sub

'    Public Function isDaylightSavingTime(ByVal baseUTCOffset As Double) As Boolean

'#if ValidationLevel >= 3

'	if diagnosticLevel >= 2 then
'            verify(baseUTCOffset >= -13 and baseUTCOffset <= 13, 500)
'        end if

'#endif


'        If appliesToRange Is Nothing Then Return False

'        Dim compareDate As DateTime = DateTime.UtcNow

'        If compareDate < appliesToRange.minValue Then
'            MsgBox("Current date is out of range of internal daylight savings time tables. Daylight savings time may be incorrect")
'            Return False
'        End If

'        If compareDate > appliesToRange.maxValue Then
'            MsgBox("Current date is out of range of internal daylight savings time tables. Daylight savings time may be incorrect")
'            Return False
'        End If

'        Dim compareForward As DateTime = compareDate.AddHours(-baseUTCOffset)
'        Dim compareBackward As DateTime = compareDate.AddHours(-baseUTCOffset + timeChangeIncrement)

'        Dim dateTimeIntervalRecord As dateTimeIntervalRecordClass

'        For Each dateTimeIntervalRecord In Me
'            If compareForward < dateTimeIntervalRecord.minValue Then Return False
'            If compareBackward < dateTimeIntervalRecord.maxValue Then Return True
'        Next

'        Return False

'    End Function

'End Class
