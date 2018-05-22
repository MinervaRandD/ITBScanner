Namespace Test.ToolBox
    Public Class TraceRoute
        Implements IDisposable

#Region "Trace Response"
        '' Trace response given at each hop
        Public Class TraceResponse
            '' Is set to True if ICMP packet made it back (not set if packet was not sent)
            Public IsSuccess As Boolean
            '' This means 
            Public IsEndOfTrace As Boolean

            Public PingResponses() As Ping.PingResponse

            Public Hop As Integer

            Public IPAddress As System.Net.IPAddress
            Public HostName As System.Net.IPHostEntry

            Public Overrides Function ToString() As String
                '' Example Output:
                '' 1 25ms   15ms    10ms    192.168.0.1 (gateway.host.com)

                Dim SB As New Text.StringBuilder

                SB.Append(Hop)
                SB.Append(" "c)

                If IsSuccess Then
                    For I As Integer = 0 To PingResponses.Length - 1
                        With PingResponses(I)
                            If .IsSuccess Then
                                SB.Append(.RTT.ToString & "ms")
                                SB.Append(vbTab)
                            Else
                                SB.Append("*"c)
                                SB.Append(vbTab)
                            End If
                        End With
                    Next

                    If IPAddress Is Nothing = False Then
                        SB.Append(IPAddress.ToString)
                        SB.Append(" "c)
                    End If

                    If HostName Is Nothing = False Then
                        SB.Append("(")
                        SB.Append(HostName.HostName)
                        SB.Append(")")
                    End If
                Else
                    SB.Append("Failed")
                End If

                Return SB.ToString

            End Function

        End Class
#End Region

#Region "TraceRouteException"
        '' Traceroute exception is thrown when we can't ping
        Public Class TraceRouteException
            Inherits ApplicationException

        End Class
#End Region

        '' Never exceed this number of hops
        Const MaxHops As Integer = 30
        '' Maximum consecutive failures before the trace is ended
        Const MaxFailures As Integer = 5

        Private MyPing As Ping
        Private MyHop As Byte
        Private MyIpAddress As System.Net.IPAddress
        Private MyTimeoutMS As Integer
        '' Consecutive failures
        Private MyFailures As Integer

        Private LastTraceResponse As TraceResponse

        Sub New()
            MyPing = New Ping
        End Sub

        Sub New(ByVal ThePacketSize As Short)
            MyPing = New Ping(ThePacketSize)
        End Sub

        Public Sub Trace(ByVal TheHost As String, ByVal TheTimeoutMS As Integer)
            '' Try to resolve host name
            Try
                MyIpAddress = System.Net.Dns.Resolve(TheHost).AddressList(0)
            Catch ex As Exception
                Throw New TraceRouteException
            End Try

            MyHop = 0
            MyTimeoutMS = TheTimeoutMS
            LastTraceResponse = Nothing
        End Sub

        Public Sub Trace(ByVal TheHost As String)
            '' Try to resolve host name
            Try
                MyIpAddress = System.Net.Dns.Resolve(TheHost).AddressList(0)
            Catch ex As Exception
                Throw New TraceRouteException
            End Try

            MyHop = 0
            MyTimeoutMS = -1
            LastTraceResponse = Nothing
        End Sub

        Public Sub Trace(ByVal TheIpAddress As System.Net.IPAddress, ByVal TheTimeoutMS As Integer)
            MyIpAddress = TheIpAddress
            MyHop = 0
            MyTimeoutMS = TheTimeoutMS
            LastTraceResponse = Nothing
        End Sub

        Public Sub Trace(ByVal TheIpAddress As System.Net.IPAddress)
            MyIpAddress = TheIpAddress
            MyHop = 0
            MyTimeoutMS = -1
            LastTraceResponse = Nothing
        End Sub

        '' Thows TraceRouteException
        '' Pings the next hop in the trace route and returns a response
        Public Function GetNextTraceResponse(ByVal TheAttemptCount As Integer) As TraceResponse
            Dim TR As New TraceResponse

            '' If we already ended tracing, do not send another ping
            If LastTraceResponse Is Nothing = False Then
                If LastTraceResponse.IsEndOfTrace Then
                    '' We already finished tracing
                    TR.IsEndOfTrace = True
                    Return TR
                End If
            End If

            MyHop += CByte(1)

            ReDim TR.PingResponses(TheAttemptCount - 1)
            Dim PR As Ping.PingResponse

            '' Ping with N attempts
            For I As Integer = 0 To TheAttemptCount - 1
                If MyTimeoutMS = -1 Then
                    Try
                        PR = MyPing.SendPing(MyIpAddress, , MyHop, False)
                    Catch ex As Ping.PingException
                        PR = New Ping.PingResponse
                        PR.IsSuccess = False
                    End Try
                Else
                    Try
                        PR = MyPing.SendPing(MyIpAddress, MyTimeoutMS, MyHop, False)
                    Catch ex As Ping.PingException
                        PR = New Ping.PingResponse
                        PR.IsSuccess = False
                    End Try
                End If
                TR.PingResponses(I) = PR

                '' The success of this trace response is true if at least one ping succeeds 
                TR.IsSuccess = TR.IsSuccess Or PR.IsSuccess

                If TR.IPAddress Is Nothing And PR.IPAddress Is Nothing = False Then
                    TR.IPAddress = PR.IPAddress
                End If
            Next

            If TR.IPAddress Is Nothing = False Then
                '' Resolve IP to host name
                Try
                    TR.HostName = System.Net.Dns.GetHostByAddress(TR.IPAddress)
                Catch ex As Exception
                End Try

                '' Set end of trace
                If TR.IPAddress.Equals(MyIpAddress) Then
                    TR.IsEndOfTrace = True
                End If
            End If

            TR.Hop = MyHop

            '' Maximum hops end traceroute
            If MyHop = MaxHops Then
                TR.IsEndOfTrace = True
            End If

            '' Keep track of consecutive failures
            If TR.IsSuccess = False Then
                MyFailures += 1
                If MyFailures = MaxFailures Then
                    '' Maximum consecutive failures exceeded
                    TR.IsEndOfTrace = True
                End If
            Else
                '' Not a failure, reset consecutive failure count
                MyFailures = 0
            End If

            LastTraceResponse = TR

            Return TR

        End Function

        Public Function GetNextTraceResponse() As TraceResponse
            GetNextTraceResponse(3)
        End Function

        Public Sub Dispose() Implements System.IDisposable.Dispose
            MyPing.Dispose()
        End Sub

    End Class

End Namespace