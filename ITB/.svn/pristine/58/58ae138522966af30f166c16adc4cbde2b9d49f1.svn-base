Namespace Networking
    Public Class Ping
        Implements IDisposable

        '' Default packet size used to send ping
        Const DefaultPacketSize As Short = 32
        '' The string length of the return address (In UNICODE characters not bytes)
        Const AddressCapacity As Integer = 32
        Const DefaultTTL As Byte = 55
        Const DefaultTimeoutMS As Integer = 1500

        Private PacketSizeParam As UInt16
        Private IsInit As Boolean
        Private IsPingSuccess As Boolean


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

            <System.Runtime.InteropServices.DllImport("icmpwrap.dll", EntryPoint:="Ping2")> _
            Public Shared Function SendPing2(ByVal TheAddress As String, ByVal TheTTL As Byte, ByVal TheTimeoutMS As UInt32, ByVal ThePacketSize As UInt16) As Boolean
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

        Private Sub New(ByVal ThePacketSize As Short)

            'TODO: Organize. Same code in Hardware.Device (PSUUIDOC.DLL)
            Dim FI As New IO.FileInfo(Device.AppPath.FullName & "\icmpwrap.dll")
            Dim ResourceStream As IO.Stream = System.Reflection.Assembly.GetExecutingAssembly().GetManifestResourceStream("Hardware.icmpwrap.dll")
            If Not FI.Exists OrElse FI.Length <> ResourceStream.Length Then
                Using WriteFS As IO.FileStream = IO.File.OpenWrite(Device.AppPath.FullName & "\icmpwrap.dll")
                    Dim Buffer(CInt(ResourceStream.Length - 1)) As Byte
                    ResourceStream.Read(Buffer, 0, Buffer.Length)
                    WriteFS.Write(Buffer, 0, Buffer.Length)
                    WriteFS.Close()
                End Using
            End If

            Try
                PacketSizeParam = Convert.ToUInt16(ThePacketSize)
                DLL.Init(PacketSizeParam)
                IsInit = True
            Catch ex As Exception
            End Try

        End Sub

        Public Function SendPing(ByVal TheHost As String) As Boolean

            If Not IsInit Then
                Throw New PingException
            End If

            Dim IPHostEnt As System.Net.IPHostEntry
            Try
                IPHostEnt = System.Net.Dns.GetHostEntry(TheHost)
            Catch ex As Exception
                Return False
            End Try

            If IPHostEnt.AddressList.Length = 0 Then
                Return False
            End If

            Return SendPing(IPHostEnt.AddressList(0))

        End Function

        Private Function SendPing(ByVal TheIP As System.Net.IPAddress, Optional ByVal TheTimeoutMS As Integer = DefaultTimeoutMS, Optional ByVal TheTTL As Byte = DefaultTTL) As Boolean

            If Not IsInit Then
                Throw New PingException
            End If

            Try
                IsPingSuccess = DLL.SendPing2(TheIP.ToString, TheTTL, Convert.ToUInt32(TheTimeoutMS), PacketSizeParam)
            Catch ex As Exception
                IsPingSuccess = False
                Return IsPingSuccess
            End Try

            Return IsPingSuccess

        End Function

        Private disposedValue As Boolean = False        ' To detect redundant calls

        ' IDisposable
        Protected Overridable Sub Dispose(ByVal disposing As Boolean)
            If Not Me.disposedValue Then
                If disposing Then
                    ' TODO: free other state (managed objects).
                End If

                If IsInit Then
                    Try
                        DLL.Shutdown()
                    Catch ex As Exception
                    End Try
                    IsInit = False
                End If

                ' TODO: free your own state (unmanaged objects).
                ' TODO: set large fields to null.
            End If
            Me.disposedValue = True
        End Sub

#Region " IDisposable Support "
        ' This code added by Visual Basic to correctly implement the disposable pattern.
        Public Sub Dispose() Implements IDisposable.Dispose
            ' Do not change this code.  Put cleanup code in Dispose(ByVal disposing As Boolean) above.
            Dispose(True)
            GC.SuppressFinalize(Me)
        End Sub
#End Region

    End Class


End Namespace
