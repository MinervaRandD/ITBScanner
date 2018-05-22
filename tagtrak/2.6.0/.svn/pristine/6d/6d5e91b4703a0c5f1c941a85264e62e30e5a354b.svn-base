' Copyright (c) 2003-2004 Aviation Software, Inc.,
' All Rights Reserved. 
' Reproduction of this document in whole or in part without written permission of   
' Aviation Software, Inc. is strictly prohibited.
'
' Aviation Software, Inc., Confidential - Restricted Access
'
' This document contains proprietary information that shall be
' distributed or routed only within Aviation Software, Inc.,
' and its authorized clients, except with written permission of
' Aviation Software, Inc. 

Imports System
Imports System.Globalization

Module dateAndTimeUtilities

    '    Public Function extractServerDateAndTime(ByRef ftpConnectString As String) As String

    '#if ValidationLevel >= 3

    '	if diagnosticLevel >= 2 then
    '            verify(Not ftpConnectString Is Nothing, 700)
    '        end if

    '#endif

    '        Dim dateOffset As Integer
    '        Const dateSearchString As String = "GMT time is now "
    '        Dim separatorSet() As Char = {" ", "."}

    '        dateOffset = ftpConnectString.IndexOf(dateSearchString)

    '        If dateOffset < 0 Then
    '            systemError("date search string not found.")
    '            Return "Date search string not found"
    '        End If

    '        dateOffset += Length(dateSearchString)

    '        Dim dateTimeString As String = Trim(Substring(ftpConnectString, dateOffset, 17))

    '        Try
    '            serverDateAndTimeUTC = DateTime.Parse(dateTimeString)
    '        Catch ex As Exception
    '            systemError("invalid date string in ftp connection string")
    '            Exit Function
    '        End Try

    '        Return "OK"

    '    End Function

    Public Function setDeviceDateAndTime(ByRef inputUTCDateAndTime As DateTime) As Boolean

#If deviceType = "PC" Then
        return true
#End If

        Dim updateTime As New SystemTime

        updateTime.Year = inputUTCDateAndTime.Year
        updateTime.Month = inputUTCDateAndTime.Month
        updateTime.Day = inputUTCDateAndTime.Day
        updateTime.DayOfWeek = inputUTCDateAndTime.DayOfWeek
        updateTime.Hour = inputUTCDateAndTime.Hour
        updateTime.Minute = inputUTCDateAndTime.Minute
        updateTime.Second = inputUTCDateAndTime.Second

        Dim updateLib As New LibWrap

        updateLib.SetSystemTime(updateTime)

        Return True

    End Function

    Public Function getYear(ByRef inputYearString As String) As Integer

#if ValidationLevel >= 3 then
        
	if diagnosticLevel >= 2 then
            verify(not inputYearString is nothing, 701)
        end if

#endif

        Dim yearString As String = Trim(inputYearString)

        If Not Util.IsInteger(yearString) Then Return -1

        Dim year As Integer = CInt(yearString)

        If year >= 0 And year < 50 Then Return 2000 + year

        If year > 50 And year < 100 Then Return 1900 + year

        If year >= 1900 And year <= 2050 Then Return year

        Return -1

    End Function

    Dim monthList1() As String = { _
        "JANUARY", "FEBRUARY", "MARCH", "APRIL", "MAY", "JUNE", "JULY", "AUGUST", "SEPTEMBER", "OCTOBER", "NOVEMBER", "DECEMBER"}
    Dim monthList2() As String = { _
        "JAN", "FEB", "MAR", "APR", "MAY", "JUN", "JUL", "AUG", "SEP", "OCT", "NOV", "DEC"}

    Public Function getMonth(ByRef inputMonthString As String) As Integer

#if ValidationLevel >= 3

        if diagnosticLevel >= 2 then
            verify(not inputMonthString is nothing, 702)
	end if

#endif

        Dim monthString As String = Trim(inputMonthString)
        Dim month As String

        If Util.IsInteger(monthString) Then

            month = CInt(monthString)

            If month < 1 Or month > 12 Then Return -1

            Return month

        End If

        monthString = monthString.ToUpper

        If monthString.EndsWith(".") And Length(monthString) = 4 Then
            monthString = Substring(monthString, 0, 3)
        End If

        Dim i As Integer

        For i = 0 To 11
            If monthString = monthList1(i) Or monthString = monthList2(i) Then
                Return i + 1
            End If
        Next

        Return -1

    End Function

    Public Function getDay(ByRef inputDayString As String) As Integer

#if ValidationLevel >= 3 then

        if diagnosticLevel >= 2 then
            verify(not inputDayString is nothing, 703)
	end if

#endif

        Dim dayString As String = Trim(inputDayString)

        If Not Util.IsInteger(dayString) Then Return -1

        Dim day As Integer = CInt(dayString)

        If day < 1 Or day > 31 Then Return -1

        Return day

    End Function

    Public Function getHour(ByRef inputHourString As String) As Integer

#if ValidationLevel >= 3 then
   
        if diagnosticLevel >= 2 then
            verify(not inputHourString is nothing, 704)
        end if

#endif

        Dim hourString As String = Trim(inputHourString)

        If Not Util.IsInteger(hourString) Then Return -1

        Dim hour As Integer = CInt(hourString)

        If hour < 0 Or hour > 12 Then Return -1

        If hour = 12 Then
            hour = 0
        End If

        Return hour

    End Function

    Public Function getMinute(ByRef inputMinuteString As String) As Integer

#If ValidationLevel >= 3 Then

        if diagnosticLevel >= 2 then
            verify(Not inputMinuteString Is Nothing, 705)
	end if

#End If


        Dim minuteString As String = Trim(inputminuteString)

        If Not Util.IsInteger(minuteString) Then Return -1

        Dim minute As Integer = CInt(minuteString)

        If minute < 0 Or minute > 59 Then Return -1

        Return minute

    End Function

    Public Function setSystemDateAndTime( _
        ByRef dayString As String, _
        ByRef monthString As String, _
        ByRef yearString As String, _
        ByRef HourString As String, _
        ByRef MinuteString As String, _
        ByVal AmValue As Boolean, _
        ByVal GmtValue As Boolean) As String

#If ValidationLevel >= 3 Then

        if diagnosticLevel >= 2 then
            verify(Not dayString Is Nothing, 705)
            verify(Not monthString Is Nothing, 706)
            verify(Not yearString Is Nothing, 707)
            verify(Not HourString Is Nothing, 708)
            verify(Not MinuteString Is Nothing, 709)
        end if

#End If

        Dim day As Integer
        Dim month As Integer
        Dim year As Integer
        Dim hour As Integer
        Dim minute As Integer

        year = getYear(yearString)

        If year < 0 Then Return "Invalid Year"

        month = getMonth(monthString)

        If month < 1 Then Return "Invalid Month"

        day = getDay(dayString)

        If day < 0 Then Return "Invalid Day"

        Dim cal As New GregorianCalendar

        If day > cal.GetDaysInMonth(year, month, GregorianCalendar.CurrentEra) Then
            Return "Invalid Day For This Month"
        End If

        hour = getHour(HourString)

        If hour < 0 Then Return "Invalid Hour"

        minute = getMinute(MinuteString)

        If minute < 0 Then Return "Invalid Minute"

        If Not AmValue Then
            hour += 12
        End If

        Dim newDateAndTime As New DateTime(year, month, day, hour, minute, 0)

        If Not GmtValue Then

            If Not scannerTimeZone.IsKnown Then
                Return "Time zone is not known, can not set time"
            End If

            Dim offset As Double = scannerTimeZone.OffsetInfo.OffsetUTC

            newDateAndTime = newDateAndTime.AddHours(-offset)

        End If

        setDeviceDateAndTime(newDateAndTime)

        Return "OK"

    End Function

    'Private Function standardNameAbbreviation() As String

    '    If isNonNullString(scannerTimeZone.standardAbbreviation) Then
    '        Return " (" & scannerTimeZone.standardAbbreviation & ")"
    '    End If

    '    If isNonNullString(scannerTimeZone.fullName) Then
    '        Return " (" & scannerTimeZone.fullName & ")"
    '    End If

    '    Return ""

    'End Function

    'Private Function DSTNameAbbreviation() As String

    '    If isNonNullString(scannerTimeZone.DSTAbbreviation) Then
    '        Return " (" & scannerTimeZone.DSTAbbreviation & ")"
    '    End If

    '    If isNonNullString(scannerTimeZone.standardAbbreviation) Then
    '        Return " (" & scannerTimeZone.standardAbbreviation & "-DST)"
    '    End If

    '    If isNonNullString(scannerTimeZone.fullName) Then
    '        Return " (" & scannerTimeZone.fullName & "-DST)"
    '    End If

    '    Return ""

    'End Function

    'Public Function getTimeZoneName() As String

    '    If scannerTimeZone Is Nothing Then Return ""

    '    Dim baseUTCOffset As Double = scannerTimeZone.BaseUTCOffset

    '    If scannerTimeZone.DSTChangeDatesProtocolType = DSTChangeDateProtocolClass.DSTChangeDatesProtocolType.Unknown Then
    '        Return standardNameAbbreviation()
    '    End If

    '    If scannerTimeZone.DSTChangeDatesProtocolType = DSTChangeDateProtocolClass.DSTChangeDatesProtocolType.NoChange Then
    '        Return standardNameAbbreviation()
    '    End If

    '    Dim DSTChangeProtocol As DSTChangeDateProtocolClass = scannerTimeZone.DSTChangeDatesProtocol

    '    If Not DSTChangeProtocol Is Nothing Then

    '        If Not DSTChangeProtocol.isDaylightSavingTime(baseUTCOffset) Then
    '            Return standardNameAbbreviation()
    '        End If

    '        Return DSTNameAbbreviation()

    '    Else

    '        Return standardNameAbbreviation()

    '    End If

    'End Function

    'Public Function formatNowForLoginDateAndTime() As String

    '    Dim currentDateAndTime As DateTime = scannerNow()
    '    Dim returnString As String

    '    returnString = currentDateAndTime.ToString() & getTimeZoneName()

    '    Return returnString

    'End Function

End Module
