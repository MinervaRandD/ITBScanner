Option Strict On
Option Explicit On 

Imports System.Runtime.InteropServices, System.io

Namespace Memory
    Public Class Storage

        Public Structure SizeResult
            '' Free bytes available to the calling thread
            Public FreeBytesToCaller As Long
            '' Total free bytes
            Public FreeBytes As Long
            '' Total bytes available to the calling thread
            Public TotalBytesToCaller As Long
            '' Is this response valid?
            Public IsValid As Boolean
        End Structure

        Public Class FlashLocationResult
            Public Locations() As String

            Sub New()
                ReDim Locations(-1)
            End Sub
        End Class

#Region "DLL"
        Private Class DLL
            Public Const WIN32_FIND_DATA_Size As Integer = 560
            Public Const MAX_PATH As Integer = 260
            Public Shared INVALID_HANDLE_VALUE As New IntPtr(-1)

            Public Structure FILETIME
                Public dwLowDateTime As UInt32
                Public dwHighDateTime As UInt32
            End Structure

            Public Structure WIN32_FIND_DATA
                Public dwFileAttributes As UInt32
                Public ftCreationTime As FILETIME
                Public ftLastAccessTime As FILETIME
                Public ftLastWriteTime As FILETIME
                Public nFileSizeHigh As UInt32
                Public nFileSizeLow As UInt32
                Public dwOID As UInt32
                Public cFileName As String
            End Structure

            <DllImport("coredll.dll")> _
            Public Shared Function GetDiskFreeSpaceEx(ByVal lpDirectoryName As String, ByRef lpFreeBytesAvailableToCaller As UInt64, ByRef lpTotalNumberOfBytes As UInt64, ByRef lpTotalNumberOfFreeBytes As UInt64) As Boolean
            End Function

            <DllImport("Note_prj.dll")> _
            Private Shared Function FindFirstFlashCard(ByVal lpFindFlashData() As Byte) As IntPtr
            End Function

            <DllImport("coredll.dll")> _
            Public Shared Function FindClose(ByVal hFindFile As IntPtr) As Boolean
            End Function

            <DllImport("Note_prj.dll")> _
            Private Shared Function FindNextFlashCard(ByVal hFlashCard As IntPtr, ByVal lpFindFlashData() As Byte) As Boolean
            End Function

            Public Shared Function FindFirstFlashCard(ByRef hFlashCard As IntPtr) As WIN32_FIND_DATA
                Try
                    Dim Win32FindData(WIN32_FIND_DATA_Size - 1) As Byte
                    hFlashCard = FindFirstFlashCard(Win32FindData)
                    If hFlashCard.Equals(INVALID_HANDLE_VALUE) = False Then
                        Return Parse_WIN32_FIND_DATA(Win32FindData)
                    Else
                        Return New WIN32_FIND_DATA
                    End If
                Catch ex As Exception
                    Return New WIN32_FIND_DATA
                End Try

            End Function

            Public Shared Function FindNextFlashCard(ByVal hFlashCard As IntPtr, ByRef TheResult As Boolean) As WIN32_FIND_DATA
                Try
                    Dim Win32FindData(WIN32_FIND_DATA_Size - 1) As Byte
                    TheResult = FindNextFlashCard(hFlashCard, Win32FindData)
                    If TheResult Then
                        Return Parse_WIN32_FIND_DATA(Win32FindData)
                    Else
                        Return New WIN32_FIND_DATA
                    End If
                Catch ex As Exception
                    Return New WIN32_FIND_DATA
                End Try

            End Function

            Private Shared Function Parse_WIN32_FIND_DATA(ByVal TheBytes() As Byte) As WIN32_FIND_DATA
                If TheBytes.Length <> WIN32_FIND_DATA_Size Then
                    Throw New ApplicationException("WIN32_FIND_DATA is wrong size")
                End If

                Dim Idx As Integer
                Dim R As New WIN32_FIND_DATA

                R.dwFileAttributes = BitConverter.ToUInt32(TheBytes, Idx)
                Idx += 4

                R.ftCreationTime.dwLowDateTime = BitConverter.ToUInt32(TheBytes, Idx)
                Idx += 4

                R.ftCreationTime.dwHighDateTime = BitConverter.ToUInt32(TheBytes, Idx)
                Idx += 4

                R.ftLastAccessTime.dwLowDateTime = BitConverter.ToUInt32(TheBytes, Idx)
                Idx += 4

                R.ftLastAccessTime.dwHighDateTime = BitConverter.ToUInt32(TheBytes, Idx)
                Idx += 4

                R.ftLastWriteTime.dwLowDateTime = BitConverter.ToUInt32(TheBytes, Idx)
                Idx += 4

                R.ftLastWriteTime.dwHighDateTime = BitConverter.ToUInt32(TheBytes, Idx)
                Idx += 4

                R.nFileSizeHigh = BitConverter.ToUInt32(TheBytes, Idx)
                Idx += 4

                R.nFileSizeLow = BitConverter.ToUInt32(TheBytes, Idx)
                Idx += 4

                R.dwOID = BitConverter.ToUInt32(TheBytes, Idx)
                Idx += 4

                R.cFileName = BytesToString(TheBytes, Idx, MAX_PATH * 2)
                Idx += (MAX_PATH * 2)

                Return R

            End Function

            '' Converts bytes (unicode) to string
            Private Shared Function BytesToString(ByVal TheBytes() As Byte, ByVal TheIndex As Integer, ByVal TheLength As Integer) As String
                Dim R As String = System.Text.UnicodeEncoding.Unicode.GetString(TheBytes, TheIndex, TheLength)
                Return R.TrimEnd(Chr(0))
            End Function

        End Class
#End Region

        Private MyDirectory As DirectoryInfo
        Sub New(ByVal TheDirectory As DirectoryInfo)
            MyDirectory = TheDirectory
        End Sub

        '' Returns the free/total space for a path
        Public Shared Function QuerySize(ByVal TheDirectoryName As String) As SizeResult
            Try
                Dim R As SizeResult

                Dim FreeToCaller As UInt64
                Dim Free As UInt64
                Dim TotalToCaller As UInt64

                If DLL.GetDiskFreeSpaceEx(TheDirectoryName, FreeToCaller, TotalToCaller, Free) Then
                    R.FreeBytesToCaller = Convert.ToInt64(FreeToCaller)
                    R.FreeBytes = Convert.ToInt64(Free)
                    R.TotalBytesToCaller = Convert.ToInt64(TotalToCaller)
                    R.IsValid = True
                End If
                Return R

            Catch ex As Exception
                Return New SizeResult
            End Try

        End Function

#Region "Sample responses to QuerySize()"
        '' Sample responses:
        ''
        ''            TheDirectoryName = Nothing
        ''{TagTrak.Hardware.Memory.Storage.SizeResult}
        ''    FreeBytes: 19332944
        ''    FreeBytesToCaller: 19332944
        ''    TotalBytesToCaller: 22835200

        ''            TheDirectoryName = "\"
        ''{TagTrak.Hardware.Memory.Storage.SizeResult}
        ''    FreeBytes: 19332944
        ''    FreeBytesToCaller: 19332944
        ''    TotalBytesToCaller: 22835200

        ''            TheDirectoryName = "\\"
        ''{TagTrak.Hardware.Memory.Storage.SizeResult}
        ''    FreeBytes: 0
        ''    FreeBytesToCaller: 0
        ''    TotalBytesToCaller: 0

        ''            TheDirectoryName = "Flash File Store"
        ''{TagTrak.Hardware.Memory.Storage.SizeResult}
        ''    FreeBytes: 26384384
        ''    FreeBytesToCaller: 26384384
        ''    TotalBytesToCaller: 31613952

        ''            TheDirectoryName = "\Flash File Store"
        ''{TagTrak.Hardware.Memory.Storage.SizeResult}
        ''    FreeBytes: 26384384
        ''    FreeBytesToCaller: 26384384
        ''    TotalBytesToCaller: 31613952

        ''            TheDirectoryName = "\\Flash File Store"
        ''{TagTrak.Hardware.Memory.Storage.SizeResult}
        ''    FreeBytes: 0
        ''    FreeBytesToCaller: 0
        ''    TotalBytesToCaller: 0

        ''            TheDirectoryName = "\My Documents"
        ''{TagTrak.Hardware.Memory.Storage.SizeResult}
        ''    FreeBytes: 19332944
        ''    FreeBytesToCaller: 19332944
        ''    TotalBytesToCaller: 22835200

        ''            TheDirectoryName = "\\My Documents"
        ''{TagTrak.Hardware.Memory.Storage.SizeResult}
        ''    FreeBytes: 0
        ''    FreeBytesToCaller: 0
        ''    TotalBytesToCaller: 0
#End Region

        Public Shared Function QuerySize(ByVal TheDirectory As DirectoryInfo) As SizeResult
            Return QuerySize(TheDirectory.FullName)
        End Function

        Public Function QuerySize() As SizeResult
            Return Storage.QuerySize(MyDirectory)
        End Function

        '' Returns all locations of non-volatile flash storage
        Public Shared Function QueryFlashLocations() As FlashLocationResult
            Dim Result As Boolean
            Dim R As New FlashLocationResult
            Dim Locations As New ArrayList

            Dim Win32FindData As DLL.WIN32_FIND_DATA
            Try
                Dim H As New IntPtr(0)

                Win32FindData = DLL.FindFirstFlashCard(H)
                If H.Equals(DLL.INVALID_HANDLE_VALUE) Then
                    Return R
                End If

                Locations.Add("\" & Win32FindData.cFileName.TrimStart("\"c))

                Do
                    Win32FindData = DLL.FindNextFlashCard(H, Result)
                    If Not Result Then Exit Do

                    Locations.Add(Win32FindData.cFileName)
                Loop

                DLL.FindClose(H)

                R.Locations = CType(Locations.ToArray(GetType(String)), String())

                Return R

            Catch ex As Exception
                Return New FlashLocationResult
            End Try

        End Function


    End Class

End Namespace
