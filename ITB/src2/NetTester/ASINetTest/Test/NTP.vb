Namespace Test
    Public Class NTP
        Inherits Generic

        Private MyHost As String
        Sub New(ByVal TheForm As Form, ByVal TheWriter As Writer, ByVal TheHost As String)
            MyBase.New(TheForm, TheWriter)
            MyHost = TheHost
        End Sub

        Protected Overrides Sub StartTestThread()
            MyWriter.WriteLine("Server: pool.ntp.org")

            Dim N As Rebex.Net.Ntp

            Dim T1 As Double = Timing.MS
            Dim T2 As Double
            Try
                N = New Rebex.Net.Ntp(MyHost)
                T2 = Timing.MS
            Catch ex As Exception
                T2 = Timing.MS
                MyWriter.WriteLine("Resolution: Failed")
                MyWriter.WriteLine("NTP Exception: " & ex.ToString)
                MyWriter.WriteLine("Resolution Delay: " & CStr(T2 - T1) & "ms")
                MyWriter.WriteLine(2)

                DoProgressUpdate(100)
                DoFinished(Generic.Results.Fail, "Cannot resolve host " & MyHost & ".")
                Return
            End Try

            MyWriter.WriteLine("Resolution: Success")
            MyWriter.WriteLine("Resolution Delay: " & CStr(T2 - T1) & "ms")

            N.Timeout = 2000

            Dim ntpR As Rebex.Net.NtpResponse
            T1 = Timing.MS
            Try
                ntpR = N.GetTime()
                T2 = Timing.MS
            Catch ex As Exception
                T2 = Timing.MS
                MyWriter.WriteLine("Time Retrieval: Failed")
                MyWriter.WriteLine("Time Retrieval Delay: " & CStr(T2 - T1) & "ms")
                MyWriter.WriteLine(2)

                DoProgressUpdate(100)
                DoFinished(Generic.Results.Fail, "Cannot retrieve time from " & MyHost & ".")
                Return
            End Try

            MyWriter.WriteLine("Time Retrieval: Success")
            MyWriter.WriteLine("Time Retrieval Delay: " & CStr(T2 - T1) & "ms")
            MyWriter.WriteLine("Time Offset: " & ntpR.TimeOffset.ToString)

            MyWriter.WriteLine(2)

            DoProgressUpdate(100)
            DoFinished(Generic.Results.Pass, "Connected and retrieved time from " & MyHost & " successfully.")

        End Sub

    End Class

End Namespace
