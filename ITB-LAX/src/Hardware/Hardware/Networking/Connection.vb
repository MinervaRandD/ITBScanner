Imports System.Runtime.InteropServices

'Connection Manager identifies which connections are available,
'selects the most optimal connection, and then establishes that connection as necessary
'Reference: http://msdn.microsoft.com/en-us/library/bb840031.aspx

Namespace Networking

    Public Class Connection

        <Flags()> _
        Enum ConnMgrParam As Integer
            GuidDestNet = &H1
            MaxCost = &H2
            MinRcvBw = &H4
            MaxConnLatency = &H8
        End Enum

        <Flags()> _
        Enum ConnMgrProxy As Integer
            NoProxy = &H0
            Http = &H1
            Wap = &H2
            Socks4 = &H4
            Socks5 = &H8
        End Enum

        Enum ConnMgrPriority
            UserInteractive = &H8000
            HighPriorityBackground = &H200
            LowPriorityBackground = &H8
        End Enum

        Enum ConnMgrStatus
            Unknown = &H0
            Connected = &H10
            Suspended = &H11
            Disconnected = &H20
            ConnectionFailed = &H21
            ConnectionCanceled = &H22
            ConnectionDisabled = &H23
            NoPathToDestination = &H24
            WaitingForPath = &H25
            WaitingForPhone = &H26
            PhoneOff = &H27
            ExclusiveConflict = &H28
            NoResources = &H29
            ConnectionLinkFailed = &H2A
            AuthenticationFailed = &H2B
            NoPathWithProperty = &H2C
            WaitingConnection = &H40
            WaitingForResource = &H41
            WaitingForNetwork = &H42
            WaitingDisconnection = &H80
            WaitingConnectionAbort = &H81
        End Enum

        <StructLayout(LayoutKind.Sequential)> _
        Class ConnMgrConnectionInfo
            Private cbSize As Int32
            Public dwParams As ConnMgrParam = 0
            Public dwFlags As ConnMgrProxy = 0
            Public dwPriority As ConnMgrPriority = 0
            Public bExclusive As Int32 = 0
            Public bDisabled As Int32 = 0
            Public guidDestNet As Guid = Guid.Empty
            Public hWnd As IntPtr = IntPtr.Zero
            Public uMsg As UInt32 = 0
            Public lParam As Int32 = 0
            Public ulMaxCost As UInt32 = 0
            Public ulMinRcvBw As UInt32 = 0
            Public ulMaxConnLatency As UInt32 = 0

            Public Sub New()
                cbSize = Marshal.SizeOf(GetType(ConnMgrConnectionInfo))
            End Sub

            Public Sub New(ByVal destination As Guid)
                Me.New(destination, ConnMgrPriority.UserInteractive)
            End Sub

            Public Sub New(ByVal destination As Guid, ByVal priority As ConnMgrPriority)
                Me.New(destination, priority, ConnMgrProxy.NoProxy)
            End Sub

            Public Sub New(ByVal destination As Guid, ByVal priority As ConnMgrPriority, ByVal proxy As ConnMgrProxy)
                Me.New()
                guidDestNet = destination
                dwParams = ConnMgrParam.GuidDestNet
                dwPriority = priority
                dwFlags = proxy
            End Sub
        End Class

        <DllImport("CellCore.dll")> _
        Private Shared Function ConnMgrMapURL(ByVal url As String, ByRef networkGuid As Guid, ByVal passZero As Integer) As Integer
        End Function
        <DllImport("CellCore.dll")> _
        Private Shared Function ConnMgrEstablishConnection(ByVal connectionInfo As ConnMgrConnectionInfo, ByRef connectionHandle As IntPtr) As Integer
        End Function
        <DllImport("CellCore.dll")> _
        Private Shared Function ConnMgrEstablishConnectionSync(ByVal connectionInfo As ConnMgrConnectionInfo, ByRef connectionHandle As IntPtr, ByVal dwTimeout As UInteger, ByRef dwStatus As ConnMgrStatus) As Integer
        End Function
        <DllImport("CellCore.dll")> _
        Private Shared Function ConnMgrReleaseConnection(ByVal connectionHandle As IntPtr, ByVal cache As Integer) As Integer
        End Function
        <DllImport("CellCore.dll")> _
        Private Shared Function ConnMgrConnectionStatus(ByVal connectionHandle As IntPtr, ByRef status As ConnMgrStatus) As Integer
        End Function

        Const _syncConnectTimeout As Integer = 60000
        Private _connectionHandle As IntPtr = IntPtr.Zero

        Public Function DoConnect(ByVal url As String) As Boolean
            Dim NetworkGuid As Guid = Guid.Empty
            Dim Status As ConnMgrStatus = ConnMgrStatus.Unknown
            ConnMgrMapURL(url, NetworkGuid, 0)
            Dim Info As New ConnMgrConnectionInfo(NetworkGuid, ConnMgrPriority.HighPriorityBackground)

            ConnMgrEstablishConnectionSync(Info, _connectionHandle, _syncConnectTimeout, Status)

            If Status = ConnMgrStatus.Connected Then
                Return True
            Else
                Return False
                'Debug.WriteLine("Connect failed: " + status.ToString())
            End If
        End Function
    End Class
End Namespace