Imports Rebex.Net

'' Class responsible for handling the NTP duties of TagTrak
Public Class NtpClass

    Const TimeoutMS As Integer = 2000

    Private MyNTP As Rebex.Net.Ntp
    Private MyNTPServersIdx As Integer = 0

    Private MyUserRecord As userSpecRecordClass

    Private MyCurrentServer As String
    Public ReadOnly Property CurrentServer() As String
        Get
            Return MyCurrentServer
        End Get
    End Property

    '' Conneects to NTP
    Sub New(ByRef TheUserRecord As userSpecRecordClass)
        MyUserRecord = TheUserRecord
        SwitchServers()

    End Sub

    '' Connects to NTP server and returns the time offset
    Public Function GetOffset() As TimeSpan ' throws Exception
        Dim R As NtpResponse

        '' Try to get time from NTP servers
        Do
            Try
                R = MyNTP.GetTime()
                Exit Do
            Catch ex As Exception
                '' Error retrieving NTP time from selected server
                '' If no more servers throw exception
                If Not SwitchServers() Then Throw ex
            End Try
        Loop

        Return R.TimeOffset.ToTimeSpan()

    End Function

    '' Sets the system time using NTP
    Public Sub SetTime()
        '' Try to get time from NTP servers
        Do
            Try
                MyNTP.SynchronizeSystemClock()
                Exit Do
            Catch ex As Exception
                '' Error retrieving NTP time from selected server
                '' If no more servers throw exception
                If Not SwitchServers() Then Throw ex
            End Try
        Loop
    End Sub

    '' Connects to a NTP server and returns the current time
    Public Function GetTime() As DateTime ' throws Exception
        Return Now.Add(GetOffset())
    End Function

    Public Function GetTimeUTC() As DateTime ' throws Exception
        Return GetTime.ToUniversalTime

    End Function

    '' Selects the next server in the list
    '' Returs True if successful, False if no more servers.
    Private Function SwitchServers() As Boolean
        If MyNTPServersIdx < MyUserRecord.NTPServers.Count Then

            '' Find a valid server
            Dim fGoodServer As Boolean = False
            Do
                Try
                    MyCurrentServer = DirectCast(MyUserRecord.NTPServers.Item(MyNTPServersIdx), String)
                    MyNTP = New Rebex.Net.Ntp(MyCurrentServer)
                    fGoodServer = True
                Catch ex As Exception
                    '' DNS error
                    fGoodServer = False
                Finally
                    MyNTPServersIdx += 1
                End Try
                If MyNTPServersIdx = MyUserRecord.NTPServers.Count Then Return False
            Loop Until fGoodServer

            MyNTP.Timeout = TimeoutMS
            Return True
        Else
            Return False
        End If

    End Function

End Class
