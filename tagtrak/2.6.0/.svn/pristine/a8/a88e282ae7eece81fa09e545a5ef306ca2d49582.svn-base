'Public Class TimeZoneRecordClass

'Public BaseUTCOffset As Double

'Public timeZone As timeZoneName
'Public DSTChangeDatesProtocol As DSTChangeDateProtocolClass
'Public DSTChangeDatesProtocolType As DSTChangeDateProtocolClass.DSTChangeDatesProtocolType
'Public fullName As String
'Public standardAbbreviation As String
'Public DSTAbbreviation As String


'    Public Sub New( _
'        ByVal inputTimeZone As timeZoneName, _
'        ByVal inputUTCOffset As Double, _
'        ByVal inputFullName As String, _
'        ByVal inputStandardAbbreviation As String, _
'        ByVal inputDSTAbbreviation As String, _
'        Optional ByVal inputDSTChangeDatesProtocol As DSTChangeDateProtocolClass.DSTChangeDatesProtocolType = DSTChangeDateProtocolClass.DSTChangeDatesProtocolType.Unknown)

'#if ValidationLevel >= 3 then

'        if diagnosticLevel >= 2 then
'            verify(inputUTCOffset >= -13.0 And inputUTCOffset <= 12.0, 24000)
'            verify(Not inputFullName Is Nothing, 24001)
'            verify(Not inputStandardAbbreviation Is Nothing, 24002)
'            verify(Not inputDSTAbbreviation Is Nothing, 24003)
'        end if

'#end if

'        BaseUTCOffset = inputUTCOffset
'        timeZone = inputTimeZone
'        DSTChangeDatesProtocolType = inputDSTChangeDatesProtocol
'        fullName = inputFullName
'        standardAbbreviation = inputStandardAbbreviation
'        DSTAbbreviation = inputDSTAbbreviation

'        If DSTChangeDatesProtocolType = DSTChangeDateProtocolClass.DSTChangeDatesProtocolType.NoChange _
'        Or DSTChangeDatesProtocolType = DSTChangeDateProtocolClass.DSTChangeDatesProtocolType.Unknown Then
'            Me.DSTChangeDatesProtocol = Nothing
'        Else
'            Me.DSTChangeDatesProtocol = DSTChangeDatesSet.Item(DSTChangeDatesProtocolType)
'        End If

'    End Sub

'    Public Function UTCOffset() As Double

'        If Me.DSTChangeDatesProtocolType = DSTChangeDateProtocolClass.DSTChangeDatesProtocolType.NoChange Then
'            Return BaseUTCOffset
'        End If

'        If Me.DSTChangeDatesProtocolType = DSTChangeDateProtocolClass.DSTChangeDatesProtocolType.Unknown Then
'            MsgBox("Unknown DST Change Protocol")
'            Stop
'        End If

'        Dim DSTChangeDatesProtocol As DSTChangeDateProtocolClass = Me.DSTChangeDatesProtocol

'#if ValidationLevel >= 3

'        if diagnosticLevel >= 2 then
'            verify(Not DSTChangeDatesProtocol Is Nothing, 24004)
'        end if

'#end if

'        If DSTChangeDatesProtocol.isDaylightSavingTime(BaseUTCOffset) Then
'            Return BaseUTCOffset - Me.DSTChangeDatesProtocol.timeChangeIncrement
'        End If

'        Return BaseUTCOffset

'    End Function

'End Class
