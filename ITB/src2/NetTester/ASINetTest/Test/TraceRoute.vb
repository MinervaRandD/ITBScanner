Namespace Test

    '' Does a standard ICMP traceroute to a given host
    Public Class TraceRoute
        Inherits Generic
        Implements IDisposable

        Const ResponsesNeededToPass As Integer = 2

        Const AttemptCount As Integer = 3

        Private MyTraceRoute As ToolBox.TraceRoute
        Private MyTimeoutMS As Integer = -1
        Private MyHost As String
        Private MyIP As System.Net.IPAddress

        Sub New(ByVal TheForm As Form, ByVal TheWriter As Writer, ByVal TheHost As String)
            MyBase.New(TheForm, TheWriter)
            MyTraceRoute = New ToolBox.TraceRoute
            MyHost = TheHost
        End Sub

        Sub New(ByVal TheForm As Form, ByVal TheWriter As Writer, ByVal TheHost As String, ByVal ThePacketSize As Short, ByVal TheTimeout As TimeSpan)
            MyBase.New(TheForm, TheWriter)
            MyTraceRoute = New ToolBox.TraceRoute(ThePacketSize)
            MyTimeoutMS = Convert.ToInt32(TheTimeout.TotalMilliseconds)
            MyHost = TheHost
        End Sub

        Sub New(ByVal TheForm As Form, ByVal TheWriter As Writer, ByVal TheIP As System.Net.IPAddress, ByVal ThePacketSize As Short, ByVal TheTimeout As TimeSpan)
            MyBase.New(TheForm, TheWriter)
            MyTraceRoute = New ToolBox.TraceRoute(ThePacketSize)
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
                MyWriter.WriteLine("Traceroute Success: False (no destination)")
                DoProgressUpdate(100)
                DoFinished(Generic.Results.Fail, "No IP or Host specified." & vbCrLf)
                Return
            End If

            MyWriter.WriteLine("Traceroute to Host: " & TheDestination)

            '' Send traceroute to host/IP (with or without specific timeout)
            Dim TraceResponse As ToolBox.TraceRoute.TraceResponse
            Try
                If MyTimeoutMS <> -1 Then
                    If MyIP Is Nothing Then
                        MyTraceRoute.Trace(MyHost, MyTimeoutMS)
                    Else
                        MyTraceRoute.Trace(MyIP, MyTimeoutMS)
                    End If
                Else
                    If MyIP Is Nothing Then
                        MyTraceRoute.Trace(MyHost)
                    Else
                        MyTraceRoute.Trace(MyIP)
                    End If
                End If
            Catch ex As ToolBox.TraceRoute.TraceRouteException
                MyWriter.WriteLine("Traceroute Exception: " & ex.ToString)
                DoProgressUpdate(100)
                DoFinished(Generic.Results.Fail, "Error during traceroute." & vbCrLf)
                Return
            End Try

            Dim TraceSuccessCount As Integer
            Do
                TraceResponse = MyTraceRoute.GetNextTraceResponse(AttemptCount)

                '' One success = total success on trace
                If TraceResponse.IsSuccess Then
                    TraceSuccessCount += 1
                End If

                MyWriter.WriteLine(TraceResponse.ToString)
            Loop While Not TraceResponse.IsEndOfTrace

            '' Grade test
            If TraceSuccessCount >= ResponsesNeededToPass Then
                DoProgressUpdate(100)
                DoFinished(Generic.Results.Pass, "Traceroute passes with " & TraceSuccessCount.ToString & " good responses." & vbCrLf)
            Else
                DoProgressUpdate(100)
                DoFinished(Generic.Results.Fail, "Traceroute failed with " & TraceSuccessCount.ToString & " good responses." & vbCrLf)
            End If

        End Sub

        Public Sub Dispose() Implements System.IDisposable.Dispose
            MyTraceRoute.Dispose()
        End Sub

    End Class

End Namespace