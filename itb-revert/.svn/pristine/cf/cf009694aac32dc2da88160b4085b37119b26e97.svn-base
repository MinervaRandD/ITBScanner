Imports System
Imports System.Collections.Generic
Imports System.Text
Imports System.Runtime.InteropServices

Namespace RadioManager
    Public Enum Status
        Disabled = 0
        Enabled
        Unknown
    End Enum

    Public Enum DeviceType
        Phone = 2
        Bluetooth = 3
        WiFi = 1
        Unknown = 4
    End Enum

    Public Class RadioDevice
        Implements IDisposable
        Private _manager As RadioDeviceManager
        Private _deviceName As String
        Private _displayName As String
        Private _status As Status
        Private _type As DeviceType

        Public Property DeviceName() As String
            Get
                Return _deviceName
            End Get
            Friend Set(ByVal value As String)
                _deviceName = value
            End Set
        End Property

        Public Property DisplayName() As String
            Get
                Return _displayName
            End Get
            Friend Set(ByVal value As String)
                _displayName = value
            End Set
        End Property

        Public Property Status() As Status
            Get
                Return _status
            End Get
            Friend Set(ByVal value As Status)
                _status = value
            End Set
        End Property

        Public Property Type() As DeviceType
            Get
                Return _type
            End Get
            Friend Set(ByVal value As DeviceType)
                _type = value
            End Set
        End Property

        Friend Sub New(ByVal manager As RadioDeviceManager, ByVal deviceName As String, ByVal displayName As String, ByVal status__1 As Integer, ByVal type As Integer)
            _manager = manager
            _deviceName = deviceName
            _displayName = displayName

            '_status = If(status__1 = 0, Status.Disabled, If(status__1 = 1, Status.Enabled, Status.Unknown))
            Select Case status__1
                Case 0
                    _status = RadioManager.Status.Disabled
                Case 1
                    _status = RadioManager.Status.Enabled
                Case Else
                    _status = RadioManager.Status.Unknown
            End Select

            Select Case type
                Case 1
                    _type = DeviceType.WiFi
                    Exit Select
                Case 2
                    _type = DeviceType.Phone
                    Exit Select
                Case 3
                    _type = DeviceType.Bluetooth
                    Exit Select
                Case Else
                    _type = DeviceType.Unknown
                    Exit Select
            End Select
        End Sub

        Public Function ChangeState(ByVal enable As Boolean) As String
            Dim [error] As String = ""
            Dim pDevices As New IntPtr()

            Try
                Dim rdd As RDD = _manager.GetDevices(pDevices)
                Dim tmpRDD As New System.Nullable(Of RDD)(rdd)
                Dim currPtr As IntPtr = pDevices

                While tmpRDD.HasValue
                    If CInt(tmpRDD.Value.DeviceType) = CInt(_type) Then
                        Dim result As Integer = Win32.ChangeRadioState(currPtr, (IIf(enable, 1, 0)), SAVEACTION.RADIODEVICES_PRE_SAVE)
                        If result <> Win32.S_OK Then
                            [error] = "Device already in desired state or error while changing state!"
                        End If
                        Exit While
                    End If

                    If tmpRDD.Value.pNext <> IntPtr.Zero Then
                        currPtr = tmpRDD.Value.pNext
                        tmpRDD = DirectCast(Marshal.PtrToStructure(tmpRDD.Value.pNext, GetType(RDD)), RDD)
                    Else
                        tmpRDD = Nothing
                    End If
                End While
            Catch e As Exception
                Return e.Message
            Finally
                If pDevices <> IntPtr.Zero Then
                    Win32.FreeDevicesList(pDevices)
                End If
            End Try

            Return [error]
        End Function

        Private disposedValue As Boolean = False        ' To detect redundant calls

        ' IDisposable
        Protected Overridable Sub Dispose(ByVal disposing As Boolean)
            If Not Me.disposedValue Then
                If disposing Then
                    _manager = Nothing
                    ' TODO: free other state (managed objects).
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

