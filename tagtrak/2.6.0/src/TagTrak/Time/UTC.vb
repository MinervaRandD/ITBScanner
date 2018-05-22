Option Explicit On 
Option Strict On

Namespace Time

    '' Manages time in UTC.
    Public Class UTC

        Public Shared Function GetTime() As Date
            Return DateTime.Now.ToUniversalTime
        End Function

    End Class

End Namespace