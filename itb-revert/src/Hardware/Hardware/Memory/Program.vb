Imports System.Runtime.InteropServices

Namespace Memory

    '' Returns some useful information on program memory usage
    Public Class Program

        Private MyMS As DLL.MEMORYSTATUS

        Private IsValidProp As Boolean
        Public ReadOnly Property IsValid()
            Get
                Return IsValidProp
            End Get
        End Property

        Sub New()
            Try
                MyMS.dwLength = Convert.ToUInt32(Marshal.SizeOf(MyMS))
                DLL.GlobalMemoryStatus(MyMS)
                IsValidProp = True
            Catch ex As Exception
                IsValidProp = False
            End Try
        End Sub

#Region "DLL"
        Private Class DLL
            Public Structure MEMORYSTATUS
                Public dwLength As UInt32
                Public dwMemoryLoad As UInt32
                Public dwTotalPhys As UInt32
                Public dwAvailPhys As UInt32
                Public dwTotalPageFile As UInt32
                Public dwAvailPageFile As UInt32
                Public dwTotalVirtual As UInt32
                Public dwAvailVirtual As UInt32
            End Structure

            <DllImport("coredll.dll")> _
            Public Shared Sub GlobalMemoryStatus(ByRef ms As MEMORYSTATUS)
            End Sub

        End Class
#End Region

        Public ReadOnly Property MemoryLoadPercent() As Long
            Get
                Return Convert.ToInt64(MyMS.dwMemoryLoad)
            End Get
        End Property

        Public ReadOnly Property PhysicalTotal() As Long
            Get
                Return Convert.ToInt64(MyMS.dwTotalPhys)
            End Get
        End Property

        Public ReadOnly Property PhysicalAvailable() As Long
            Get
                Return Convert.ToInt64(MyMS.dwAvailPhys)
            End Get
        End Property

        Public ReadOnly Property PhysicalUsed() As Long
            Get
                Return Convert.ToInt64(MyMS.dwTotalPhys) - Convert.ToInt64(MyMS.dwAvailPhys)
            End Get
        End Property

    End Class

End Namespace
