Namespace Test

    '' The PING test
    Public Class Ping
        Inherits Generic
        Implements IDisposable

        Private MyPing As ToolBox.Ping
        Private MyTimeoutMS As Integer = -1

        Private MyHost As String
        Private MyIP As System.Net.IPAddress

        Sub New(ByVal TheForm As Form, ByVal TheWriter As Writer, ByVal TheHost As String)
            MyBase.New(TheForm, TheWriter)
            MyPing = New ToolBox.Ping
            MyHost = TheHost
        End Sub

        Sub New(ByVal TheForm As Form, ByVal TheWriter As Writer, ByVal TheHost As String, ByVal ThePacketSize As Short, ByVal TheTimeout As TimeSpan)
            MyBase.New(TheForm, TheWriter)
            MyPing = New ToolBox.Ping(ThePacketSize)
            MyTimeoutMS = Convert.ToInt32(TheTimeout.TotalMilliseconds)
            MyHost = TheHost
        End Sub

        Sub New(ByVal TheForm As Form, ByVal TheWriter As Writer, ByVal TheIP As System.Net.IPAddress, ByVal ThePacketSize As Short, ByVal TheTimeout As TimeSpan)
            MyBase.New(TheForm, TheWriter)
            MyPing = New ToolBox.Ping(ThePacketSize)
            MyTimeoutMS = Convert.ToInt32(TheTimeout.TotalMilliseconds)
            MyIP = TheIP
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
                DoFinished(Generic.Results.Fail, "PING failed." & vbCrLf)
                Return
            End Try

            MyWriter.WriteLine("Ping Success: " & PingResponse.IsSuccess.ToString)
            If PingResponse.IsSuccess Then
                MyWriter.WriteLine("Ping RTT (ms): " & PingResponse.RTT.ToString)
                If PingResponse.HostName Is Nothing = False Then
                    MyWriter.WriteLine("Ping Response Address: " & PingResponse.IPAddress.ToString & " (" & PingResponse.HostName.HostName & ")")
                Else
                    MyWriter.WriteLine("Ping Response Address: " & PingResponse.IPAddress.ToString)
                End If
                DoProgressUpdate(100)
                DoFinished(Generic.Results.Pass, "Ping response received from " & PingResponse.IPAddress.ToString & "." & vbCrLf)
            Else
                DoProgressUpdate(100)
                DoFinished(Generic.Results.Fail, "Ping response not received." & vbCrLf)
            End If

        End Sub

        Public Sub Dispose() Implements System.IDisposable.Dispose
            MyPing.Dispose()
        End Sub

    End Class

End Namespace