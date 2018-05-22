Imports System.Net
Imports System.Net.Sockets
Imports System.Runtime.InteropServices

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
        'Pass it to DLL2
        Private PacketSize As Short

#Region "PingException"
        '' Ping exception is thrown when we can't ping
        Public Class PingException
            Inherits ApplicationException

        End Class
#End Region

#Region "Native Calls (DLL) icmpwrap.dll"
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

#Region "Native Calls (DLL) iphlpapi.dll"
        Private Class DLL2
            Public Const ICMP_SUCCESS As Long = 0
            Public Const ICMP_STATUS_BUFFER_TO_SMALL As Int32 = 11001                   'Buffer Too Small
            Public Const ICMP_STATUS_DESTINATION_NET_UNREACH As Int32 = 11002           'Destination Net Unreachable
            Public Const ICMP_STATUS_DESTINATION_HOST_UNREACH As Int32 = 11003          'Destination Host Unreachable
            Public Const ICMP_STATUS_DESTINATION_PROTOCOL_UNREACH As Int32 = 11004      'Destination Protocol Unreachable
            Public Const ICMP_STATUS_DESTINATION_PORT_UNREACH As Int32 = 11005          'Destination Port Unreachable
            Public Const ICMP_STATUS_NO_RESOURCE As Int32 = 11006                       'No Resources
            Public Const ICMP_STATUS_BAD_OPTION As Int32 = 11007                        'Bad Option
            Public Const ICMP_STATUS_HARDWARE_ERROR As Int32 = 11008                    'Hardware Error
            Public Const ICMP_STATUS_LARGE_PACKET As Int32 = 11009                      'Packet Too Big
            Public Const ICMP_STATUS_REQUEST_TIMED_OUT As Int32 = 11010                 'Request Timed Out
            Public Const ICMP_STATUS_BAD_REQUEST As Int32 = 11011                       'Bad Request
            Public Const ICMP_STATUS_BAD_ROUTE As Int32 = 11012                         'Bad Route
            Public Const ICMP_STATUS_TTL_EXPIRED_TRANSIT As Int32 = 11013               'TimeToLive Expired Transit
            Public Const ICMP_STATUS_TTL_EXPIRED_REASSEMBLY As Int32 = 11014            'TimeToLive Expired Reassembly
            Public Const ICMP_STATUS_PARAMETER As Int32 = 11015                         'Parameter Problem
            Public Const ICMP_STATUS_SOURCE_QUENCH As Int32 = 11016                     'Source Quench
            Public Const ICMP_STATUS_OPTION_TOO_BIG As Int32 = 11017                    'Option Too Big
            Public Const ICMP_STATUS_BAD_DESTINATION As Int32 = 11018                   'Bad Destination
            Public Const ICMP_STATUS_NEGOTIATING_IPSEC As Int32 = 11032                 'Negotiating IPSEC
            Public Const ICMP_STATUS_GENERAL_FAILURE As Int32 = 11050                   'General Failure

            <StructLayout(LayoutKind.Sequential, CharSet:=CharSet.Auto)> _
            Public Structure ICMP_OPTIONS
                Public Ttl As Byte
                Public Tos As Byte
                Public Flags As Byte
                Public OptionsSize As Byte
                Public OptionsData As IntPtr
            End Structure

            <StructLayout(LayoutKind.Sequential, CharSet:=CharSet.Auto)> _
            Public Structure ICMP_ECHO_REPLY
                Public Address As Integer
                Public Status As Integer
                Public RoundTripTime As Integer
                Public DataSize As Short
                Public Reserved As Short
                Public DataPtr As IntPtr
                Public Options As ICMP_OPTIONS
                'maximum packet size and icmp_echo_reply maximum data size must match
                <MarshalAs(UnmanagedType.ByValTStr, SizeConst:=2000)> _
                Public Data As String
            End Structure

            <DllImport("iphlpapi.dll", SetLastError:=True)> _
            Public Shared Function IcmpCreateFile() As IntPtr
            End Function

            <DllImport("iphlpapi.dll", SetLastError:=True)> _
            Public Shared Function IcmpCloseHandle(ByVal Handle As IntPtr) As Boolean
            End Function

            <DllImport("iphlpapi.dll", SetLastError:=True)> _
            Public Shared Function IcmpSendEcho( _
                ByVal IcmpHandle As IntPtr, _
                ByVal DestinationAddress As Integer, _
                ByVal RequestData As String, _
                ByVal RequestSize As Integer, _
                ByRef RequestOptions As ICMP_OPTIONS, _
                ByRef ReplyBuffer As ICMP_ECHO_REPLY, _
                ByVal ReplySize As Integer, _
                ByVal Timeout As Integer) As Integer
            End Function

            Public Shared Function EvaluatePingResponse(ByVal PingResponse As Long) As String

                Select Case PingResponse
                    'Success
                    Case ICMP_SUCCESS : EvaluatePingResponse = "Success!"
                        'Some error occurred
                    Case ICMP_STATUS_BUFFER_TO_SMALL : EvaluatePingResponse = "Buffer Too Small"
                    Case ICMP_STATUS_DESTINATION_NET_UNREACH : EvaluatePingResponse = "Destination Net Unreachable"
                    Case ICMP_STATUS_DESTINATION_HOST_UNREACH : EvaluatePingResponse = "Destination Host Unreachable"
                    Case ICMP_STATUS_DESTINATION_PROTOCOL_UNREACH : EvaluatePingResponse = "Destination Protocol Unreachable"
                    Case ICMP_STATUS_DESTINATION_PORT_UNREACH : EvaluatePingResponse = "Destination Port Unreachable"
                    Case ICMP_STATUS_NO_RESOURCE : EvaluatePingResponse = "No Resources"
                    Case ICMP_STATUS_BAD_OPTION : EvaluatePingResponse = "Bad Option"
                    Case ICMP_STATUS_HARDWARE_ERROR : EvaluatePingResponse = "Hardware Error"
                    Case ICMP_STATUS_LARGE_PACKET : EvaluatePingResponse = "Packet Too Big"
                    Case ICMP_STATUS_REQUEST_TIMED_OUT : EvaluatePingResponse = "Request Timed Out"
                    Case ICMP_STATUS_BAD_REQUEST : EvaluatePingResponse = "Bad Request"
                    Case ICMP_STATUS_BAD_ROUTE : EvaluatePingResponse = "Bad Route"
                    Case ICMP_STATUS_TTL_EXPIRED_TRANSIT : EvaluatePingResponse = "TimeToLive Expired Transit"
                    Case ICMP_STATUS_TTL_EXPIRED_REASSEMBLY : EvaluatePingResponse = "TimeToLive Expired Reassembly"
                    Case ICMP_STATUS_PARAMETER : EvaluatePingResponse = "Parameter Problem"
                    Case ICMP_STATUS_SOURCE_QUENCH : EvaluatePingResponse = "Source Quench"
                    Case ICMP_STATUS_OPTION_TOO_BIG : EvaluatePingResponse = "Option Too Big"
                    Case ICMP_STATUS_BAD_DESTINATION : EvaluatePingResponse = "Bad Destination"
                    Case ICMP_STATUS_NEGOTIATING_IPSEC : EvaluatePingResponse = "Negotiating IPSEC"
                    Case ICMP_STATUS_GENERAL_FAILURE : EvaluatePingResponse = "General Failure"
                        'Unknown error occurred
                    Case Else : EvaluatePingResponse = "Unknown Response"
                End Select

            End Function
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
                PacketSize = ThePacketSize
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
                'IPHostEnt = System.Net.Dns.Resolve(TheHost) 'AP-082109
                IPHostEnt = System.Net.Dns.GetHostEntry(TheHost)
            Catch ex As Exception
                '' Failed to resolve host name, return unsuccessful ping response
                Return New PingResponse(False)
            End Try

            If IPHostEnt.AddressList.Length = 0 Then
                '' No valud addresses
                Return New PingResponse(False)
            End If

            'Return SendPing(IPHostEnt.AddressList(0), TheTimeoutMS, TheTTL, ReverseDNS)
            Return SendPing2(IPHostEnt.AddressList(0), TheTimeoutMS, TheTTL, ReverseDNS)

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
                Dim SB As New System.Text.StringBuilder(AddressCapacity) 'AP-082109
                DLL.GetPingAddress(SB, AddressCapacity)

                Try
                    R.RTT = DLL.GetPingRTT()
                    R.IPAddress = System.Net.IPAddress.Parse(SB.ToString)
                    '' If IP gotten out successfully, try to get the host name
                    If ReverseDNS Then
                        'R.HostName = System.Net.Dns.GetHostByAddress(R.IPAddress) 'AP-082109
                        R.HostName = System.Net.Dns.GetHostEntry(R.IPAddress)
                    End If
                Catch ex As Exception
                    '' Either IP or HostName missing
                End Try

            End If

            Return R

        End Function

        Public Function SendPing2(ByVal TheIP As System.Net.IPAddress, Optional ByVal TheTimeoutMS As Integer = DefaultTimeoutMS, Optional ByVal TheTTL As Byte = DefaultTTL, Optional ByVal ReverseDNS As Boolean = True) As PingResponse

            Const ICMP_Reply_Init As Integer = -1

            Dim R As New PingResponse
            Dim ICMP_Handler As IntPtr
            Dim ICMP_Options As New DLL2.ICMP_OPTIONS
            Dim ICMP_Reply As New DLL2.ICMP_ECHO_REPLY
            Dim iIP As Int32
            Dim sData As String
            Dim iReply As Integer
            Dim bCloseHandle As Boolean

            Try
                iIP = System.BitConverter.ToInt32(TheIP.GetAddressBytes, 0)
                sData = New String(" "c, PacketSize)
                ICMP_Options.Ttl = TheTTL
                ICMP_Reply.Status = ICMP_Reply_Init
                ICMP_Handler = DLL2.IcmpCreateFile()
                iReply = DLL2.IcmpSendEcho(ICMP_Handler, iIP, sData, sData.Length, ICMP_Options, ICMP_Reply, Marshal.SizeOf(ICMP_Reply), TheTimeoutMS)
                bCloseHandle = DLL2.IcmpCloseHandle(ICMP_Handler)
            Catch ex As Exception
                bCloseHandle = DLL2.IcmpCloseHandle(ICMP_Handler)
                R.IsSuccess = False
                Return R
            End Try

            If ICMP_Reply.Status = 0 Then
                R.IsSuccess = True
                R.RTT = ICMP_Reply.RoundTripTime
                R.IPAddress = New System.Net.IPAddress(CLng(ICMP_Reply.Address))
                If ReverseDNS Then
                    R.HostName = System.Net.Dns.GetHostEntry(R.IPAddress)
                End If
            End If

            ICMP_Handler = Nothing
            ICMP_Options = Nothing
            ICMP_Reply = Nothing
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