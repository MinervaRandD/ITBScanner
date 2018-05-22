Namespace Test

    '' The PING test
    Public Class Ping
        Inherits Generic
        Implements IDisposable

        Private MyPing As ToolBox.Ping
        Private MyTimeoutMS As Integer = -1

        Private MyHost As String
        Private MyIP As System.Net.IPAddress

        Private MyRetries As Integer = 1

        Sub New(ByVal TheForm As Form, ByVal TheWriter As Writer, ByVal TheHost As String)
            MyBase.New(TheForm, TheWriter)
            MyPing = New ToolBox.Ping
            MyHost = TheHost
        End Sub

        Sub New(ByVal TheForm As Form, ByVal TheWriter As Writer, ByVal TheHost As String, ByVal ThePacketSize As Short, ByVal TheTimeout As TimeSpan, ByVal TheRetries As Integer)
            MyBase.New(TheForm, TheWriter)
            MyPing = New ToolBox.Ping(ThePacketSize)
            MyTimeoutMS = Convert.ToInt32(TheTimeout.TotalMilliseconds)
            MyHost = TheHost
            MyRetries = TheRetries
        End Sub

        Sub New(ByVal TheForm As Form, ByVal TheWriter As Writer, ByVal TheIP As System.Net.IPAddress, ByVal ThePacketSize As Short, ByVal TheTimeout As TimeSpan, ByVal TheRetries As Integer)
            MyBase.New(TheForm, TheWriter)
            MyPing = New ToolBox.Ping(ThePacketSize)
            MyTimeoutMS = Convert.ToInt32(TheTimeout.TotalMilliseconds)
            MyIP = TheIP
            MyRetries = TheRetries
        End Sub

        Protected Overrides Sub StartTestThread()
            '' Set up the ping destination
            Dim TheDestination As String
            If MyIP Is Nothing And MyHost <> "" Then
                TheDestination = MyHost
            ElseIf MyIP Is Nothing = False Then
                TheDestination = MyIP.ToString
            Else
                MyWriter.WriteLine("Ping Success: False (no destination)")
                DoProgressUpdate(100)
                DoFinished(Generic.Results.Fail, "No IP or Host specified." & vbCrLf)
                Return
            End If

            Dim PingSuccessCount As Integer
            For I As Integer = 1 To MyRetries
                MyWriter.WriteLine("Pinging: " & TheDestination)

                '' Send ping
                Dim PingResponse As ToolBox.Ping.PingResponse
                Try
                    '' Do ping to Host/IP (with or without specific timeout)
                    If MyTimeoutMS <> -1 Then
                        If MyIP Is Nothing Then
                            PingResponse = MyPing.SendPing(MyHost, MyTimeoutMS)
                        Else
                            PingResponse = MyPing.SendPing(MyIP, MyTimeoutMS)
                        End If
                    Else
                        If MyIP Is Nothing Then
                            PingResponse = MyPing.SendPing(MyHost)
                        Else
                            PingResponse = MyPing.SendPing(MyIP)
                        End If
                    End If
                Catch ex As ToolBox.Ping.PingException
                    MyWriter.WriteLine("Ping Exception: " & ex.ToString)
                    DoProgressUpdate(100)
                    DoFinished(Generic.Results.Fail, "Ping failed." & vbCrLf)
                    Return
                End Try

                MyWriter.WriteLine("Ping Success: " & PingResponse.IsSuccess.ToString)

                If PingResponse.IsSuccess Then
                    PingSuccessCount += 1

                    MyWriter.WriteLine("Ping RTT (ms): " & PingResponse.RTT.ToString)
                    If PingResponse.HostName Is Nothing = False Then
                        MyWriter.WriteLine("Ping Response Address: " & PingResponse.IPAddress.ToString & " (" & PingResponse.HostName.HostName & ")")
                    Else
                        MyWriter.WriteLine("Ping Response Address: " & PingResponse.IPAddress.ToString)
                    End If
                End If

                MyWriter.WriteLine()
                DoProgressUpdate(CInt((I / MyRetries) * 100))
            Next

            DoProgressUpdate(100)
            If PingSuccessCount > 0 Then
                DoFinished(Generic.Results.Pass, "Ping success rate: " & CStr(CInt((PingSuccessCount / MyRetries)) * 100) & "% (" & CStr(PingSuccessCount) & "/" & CStr(MyRetries) & ")." & vbCrLf)
            Else
                DoFinished(Generic.Results.Fail, "No pings received." & vbCrLf)
            End If

        End Sub

        Public Sub Dispose() Implements System.IDisposable.Dispose
            MyPing.Dispose()
        End Sub

    End Class

End Namespace