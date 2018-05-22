Option Explicit On 
Option Strict On

Namespace Time

    '' Returns the Local time computing it from the UTC time and out TimeZone class bypassing the OS
    '' timezone information and DST rules.
    Public Class Local
        Public Shared Function IsKnown(ByVal TheTimeZone As Time.TimeZone) As Boolean
            If TheTimeZone Is Nothing Then Throw New ApplicationException("No time zone specified, can not determine if known.")

            Return TheTimeZone.IsKnown
        End Function

        '' Returns the local time
        '' If Time zone is not known (Me.IsKnown = False), returns UTC time.
        Public Shared Function GetTime(ByVal TheTimeZone As Time.TimeZone) As Date
            If TheTimeZone Is Nothing Then Throw New ApplicationException("No time zone specified, can not determine local time.")
#If DEBUG Then
            If Not IsKnown(TheTimeZone) Then
                MsgBox("Warning: Time zone is unknown, can not determine local time reliably. Please set the time and time zone.", MsgBoxStyle.Exclamation, "TagTrak")
            End If
#End If

            Return DateTime.UtcNow.AddHours(TheTimeZone.OffsetInfo.OffsetUTC)

        End Function

    End Class

End Namespace