Imports System
Imports System.Collections.Generic
Imports System.Text
Imports System.Runtime.InteropServices

Namespace RadioManager
    Enum RADIODEVTYPE
        RADIODEVICES_MANAGED = 1
        RADIODEVICES_PHONE
        RADIODEVICES_BLUETOOTH
    End Enum

    ' whether to save before or after changing state
    Enum SAVEACTION
        RADIODEVICES_DONT_SAVE = 0
        RADIODEVICES_PRE_SAVE
        RADIODEVICES_POST_SAVE
    End Enum

    ' Details of radio devices
    <StructLayout(LayoutKind.Sequential)> _
    Structure RDD
        Public pszDeviceName As IntPtr
        ' Device name for registry setting.
        Public pszDisplayName As IntPtr
        ' Name to show the world
        Public dwState As Integer
        ' ON/off/[Discoverable for BT]
        Public dwDesired As Integer
        ' desired state - used for setting registry etc.
        Public DeviceType As RADIODEVTYPE
        ' Managed, phone, BT etc.
        Public pNext As IntPtr
        ' Next device in list
    End Structure

    Public Class RadioDeviceManager
        Implements IDisposable
        Private devicesList As New List(Of RadioDevice)()

#Region "Properties"
        Public ReadOnly Property WiFiDevice() As RadioDevice
            Get
                RefreshDevicesList()
                Return devicesList.Find(AddressOf FindWiFi)
                'Return devicesList.Find(DirectCast(Function(rd As RadioDevice) rd.Type = DeviceType.WiFi, Predicate(Of RadioDevice)))
            End Get
        End Property

        Public ReadOnly Property BluetoothDevice() As RadioDevice
            Get
                RefreshDevicesList()
                Return devicesList.Find(AddressOf FindBluetooth)
                'Return devicesList.Find(DirectCast(Function(rd As RadioDevice) rd.Type = DeviceType.Bluetooth, Predicate(Of RadioDevice)))
            End Get
        End Property

        Public ReadOnly Property PhoneDevice() As RadioDevice
            Get
                RefreshDevicesList()
                Return devicesList.Find(AddressOf FindPhone)
                'Return devicesList.Find(DirectCast(Function(rd As RadioDevice) rd.Type = DeviceType.Phone, Predicate(Of RadioDevice)))
            End Get
        End Property

        Public ReadOnly Property UnknownDevice() As RadioDevice
            Get
                RefreshDevicesList()
                Return devicesList.Find(AddressOf FindUnknown)
                'Return devicesList.Find(DirectCast(Function(rd As RadioDevice) rd.Type = DeviceType.Unknown, Predicate(Of RadioDevice)))
            End Get
        End Property

        Public ReadOnly Property AllDevice() As List(Of RadioDevice)
            Get
                RefreshDevicesList()
                Return devicesList
            End Get
        End Property
#End Region

        Public Sub New()

        End Sub

        Private Sub ClearDevicesList()
            For i As Integer = 0 To devicesList.Count - 1
                devicesList(i).Dispose()
            Next
        End Sub

        Private Function RefreshDevicesList() As String
            ClearDevicesList()
            Dim pDevices As New IntPtr()

            Try
                Dim rdd As RDD = GetDevices(pDevices)

                While True
                    devicesList.Add(GetRadioDevice(rdd))
                    If rdd.pNext <> IntPtr.Zero Then
                        rdd = DirectCast(Marshal.PtrToStructure(rdd.pNext, GetType(RDD)), RDD)
                    Else
                        Exit While
                    End If
                End While
                Return ""
            Catch e As Exception
                Return e.Message
            Finally
                If pDevices <> IntPtr.Zero Then
                    Win32.FreeDevicesList(pDevices)
                End If
            End Try
        End Function

        Private Function GetRadioDevice(ByVal device As RDD) As RadioDevice
            Return New RadioDevice(Me, Marshal.PtrToStringUni(device.pszDeviceName), Marshal.PtrToStringUni(device.pszDisplayName), device.dwState, CInt(device.DeviceType))
        End Function

        Friend Function GetDevices(ByRef pDevices As IntPtr) As RDD
            Dim ptrRDD As New IntPtr()
            Try
                If Win32.GetWirelessDevices(ptrRDD, 0) = Win32.S_OK Then
                    If ptrRDD <> IntPtr.Zero Then
                        pDevices = ptrRDD
                        Dim devices As RDD = DirectCast(Marshal.PtrToStructure(ptrRDD, GetType(RDD)), RDD)
                        Return devices
                    Else
                        Throw New Exception("Radio devices not found!")
                    End If
                Else
                    Throw New Exception("Error while getting list of radio devices!")
                End If
            Catch e As Exception
                Throw e
            End Try

        End Function

        Private Function FindPhone(ByVal rd As RadioDevice) As Boolean
            If rd.Type = DeviceType.Phone Then
                Return True
            Else
                Return False
            End If
        End Function

        Private Function FindWiFi(ByVal rd As RadioDevice) As Boolean
            If rd.Type = DeviceType.WiFi Then
                Return True
            Else
                Return False
            End If
        End Function

        Private Function FindBluetooth(ByVal rd As RadioDevice) As Boolean
            If rd.Type = DeviceType.Bluetooth Then
                Return True
            Else
                Return False
            End If
        End Function

        Private Function FindUnknown(ByVal rd As RadioDevice) As Boolean
            If rd.Type = DeviceType.Unknown Then
                Return True
            Else
                Return False
            End If
        End Function

        Private disposedValue As Boolean = False        ' To detect redundant calls

        ' IDisposable
        Protected Overridable Sub Dispose(ByVal disposing As Boolean)
            If Not Me.disposedValue Then
                If disposing Then
                    ' TODO: free other state (managed objects).
                    ClearDevicesList()
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
