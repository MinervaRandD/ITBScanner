Namespace Util
    Public Class SerialNumber

        Private Class DLL
            <System.Runtime.InteropServices.DllImport("PSUUID0C.DLL", EntryPoint:="?GetSerNum@@YAHPAGK@Z")> _
            Public Shared Function GetSerNum(ByVal SerNum() As Byte, ByVal SizeSerNum As Int32) As Integer
            End Function
        End Class

        '' Retrieves scanner serial number
        '' Currently supports Intermec only
        Public Shared Shadows Function ToString() As String
            Dim SN(128) As Byte
            Try
                DLL.GetSerNum(SN, 22)
                Return System.Text.UnicodeEncoding.Unicode.GetString(SN, 0, 22)
            Catch ex As Exception
                Return ""
            End Try

        End Function

    End Class

End Namespace
