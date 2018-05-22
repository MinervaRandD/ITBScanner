Namespace Test.ToolBox
    '' Sends ICMP packets, gets response.
    Public Class Ping
        Implements IDisposable

        '' Default packet size used to send ping
        Const DefaultPacketSize As Short = 32
        '' The string length of the return address (In UNICODE characters not bytes)
        Const AddressCapacity As Integer = 32
        Const DefaultTTL As Byte = 55
        Const DefaultTimeoutMS As Integer = 1500

        Private IsInit As Boolean

#Region "PingException"
        '' Ping exception is thrown when we can't ping
        Public Class PingException
            Inherits ApplicationException

        End Class
#End Region

#Region "Native Calls (DLL)"
        Private Class DLL
            <System.Runtime.InteropServices.DllImport("icmpwrap.dll")> _
            Public Shared Function Init(ByVal ThePacketSize As UInt16) As Boolean
            End Function

            <System.Runtime.InteropServices.DllImport("icmpwrap.dll")> _
            Public Shared Sub Shutdown()
            End Sub

            <System.Runtime.InteropServices.DllImport("icmpwrap.dll", EntryPoint:="Ping")> _
            Public Shared Function SendPing(ByVal TheAddress As String, ByVal TheTTL As Byte, ByVal TheTimeoutMS As UInt32) As Boolean
            End Function

            <System.Runtime.InteropServices.DllImport("icmpwrap.dll")> _
            Public Shared Function GetPingRTT() As Integer
            End Function

            <System.Runtime.InteropServices.DllImport("icmpwrap.dll")> _
            Public Shared Sub GetPingAddress(ByVal TheAddress As System.Text.StringBuilder, ByVal TheAddressLen As Integer)
            End Sub

        End Class
#End Region

#Region "Ping Response"
        Public Class PingResponse
            Public IsSuccess As Boolean
            Public RTT As Integer
            Public IPAddress As System.Net.IPAddress
            Public HostName As System.Net.IPHostEntry

            Sub New(ByVal Success As Boolean)
                IsSuccess = Success
            End Sub

            Sub New()

            End Sub
        End Class
#End Region

        Sub New()
            Me.New(DefaultPacketSize)
        End Sub

        Sub New(ByVal ThePacketSize As Short)
            Try
                DLL.Init(Convert.ToUInt16(ThePacketSize))
                IsInit = True
            Catch ex As Exception
            End Try
        End Sub

        Public Function SendPing(ByVal TheHost As String, Optional ByVal TheTimeoutMS As Integer = DefaultTimeoutMS, Optional ByVal TheTTL As Byte = DefaultTTL, Optional ByVal ReverseDNS As Boolean = True) As PingResponse
            If Not IsInit Then
                '' Not properly initialized
                Throw New PingException
            End If

            Dim IPHostEnt As System.Net.IPHostEntry
            Try
                IPHostEnt = System.Net.Dns.Resolve(TheHost)
            Catch ex As Exception
                '' Failed to resolve host name, return unsuccessful ping response
                Return New PingResponse(False)
            End Try

            If IPHostEnt.AddressList.Length = 0 Then
                '' No valud addresses
                Return New PingResponse(False)
            End If

            Return SendPing(IPHostEnt.AddressList(0), TheTimeoutMS, TheTTL, ReverseDNS)

        End Function

        Public Function SendPing(ByVal TheIP As System.Net.IPAddress, Optional ByVal TheTimeoutMS As Integer = DefaultTimeoutMS, Optional ByVal TheTTL As Byte = DefaultTTL, Optional ByVal ReverseDNS As Boolean = True) As PingResponse
            If Not IsInit Then
                '' Not properly initialized
                Throw New PingException
            End If

            Dim R As New PingResponse
            Try
                R.IsSuccess = DLL.SendPing(TheIP.ToString, TheTTL, Convert.ToUInt32(TheTimeoutMS))
            Catch ex As Exception
                R.IsSuccess = False
                Return R
            End Try

            If R.IsSuccess Then
                Dim SB As New Text.StringBuilder(AddressCapacity)
                DLL.GetPingAddress(SB, AddressCapacity)

                Try
                    R.RTT = DLL.GetPingRTT()
                    R.IPAddress = System.Net.IPAddress.Parse(SB.ToString)
                    '' If IP gotten out successfully, try to get the host name
                    If ReverseDNS Then
                        R.HostName = System.Net.Dns.GetHostByAddress(R.IPAddress)
                    End If
                Catch ex As Exception
                    '' Either IP or HostName missing
                End Try

            End If

            Return R

        End Function

        Public Sub Dispose() Implements System.IDisposable.Dispose
            If IsInit Then
                Try
                    DLL.Shutdown()
                Catch ex As Exception
                End Try
                IsInit = False
            End If
        End Sub

    End Class
End Namespace