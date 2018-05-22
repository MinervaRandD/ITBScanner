Imports System.Security.Cryptography
Imports System.IO
Public Class BinBuilder

    Const BINRevision As Integer = 1

    Private MyCarrier As String
    Private MyXMLFile As IO.FileInfo
    Private MyInitImageFile As IO.FileInfo
    Private MyAdminImageFile As IO.FileInfo
    Private MyScanImageFile As IO.FileInfo
    Private MyOutputFile As IO.FileInfo

    Sub New(ByVal TheCarrier As String, ByVal TheXMLFile As IO.FileInfo, ByVal TheInitImageFile As IO.FileInfo, ByVal TheAdminImageFile As IO.FileInfo, ByVal TheScanImageFile As IO.FileInfo, ByVal TheOutputFile As IO.FileInfo)
        MyCarrier = TheCarrier
        MyXMLFile = TheXMLFile
        MyAdminImageFile = TheAdminImageFile
        MyScanImageFile = TheScanImageFile
        MyInitImageFile = TheInitImageFile
        MyOutputFile = TheOutputFile

    End Sub

    ''' <summary>
    ''' Generates a BIN file for a carrier.
    ''' </summary>
    ''' <returns>True on success, False on failure.</returns>
    ''' <remarks></remarks>
    Public Function Generate() As Boolean
        Dim R As Boolean

        R = EncryptBINFile(WriteBINfile())

        Return R

    End Function

    Private Function WriteBINfile() As Byte()
        ''Binary(Contents):
        ''   FormatVersion = [Integer]
        ''   Config File Text Size = [Integer]
        ''   Admin Logo File Size = [Integer]
        ''   Init Logo File Size = [Integer]
        ''   Scan Logo File Size = [Integer]
        ''   [ConfigFileText]
        ''   [AdminLogo]
        ''   [InitLogo]
        ''   [ScanLogo]

        Dim OutMS As New IO.MemoryStream
        Dim OutBW As New IO.BinaryWriter(OutMS)
        Dim OutSW As New IO.StreamWriter(OutMS)

        Dim XMLFS As New IO.FileStream(MyXMLFile.FullName, IO.FileMode.Open)
        Dim XMLSR As New IO.StreamReader(XMLFS)

        Dim AdminLogoFS As New IO.FileStream(MyAdminImageFile.FullName, IO.FileMode.Open)
        Dim InitLogoFS As New IO.FileStream(MyInitImageFile.FullName, IO.FileMode.Open)
        Dim ScanLogoFS As New IO.FileStream(MyScanImageFile.FullName, IO.FileMode.Open)

        OutBW.Write(BINRevision)
        OutBW.Write(Convert.ToInt32(XMLFS.Length))
        OutBW.Write(Convert.ToInt32(AdminLogoFS.Length))
        OutBW.Write(Convert.ToInt32(InitLogoFS.Length))
        OutBW.Write(Convert.ToInt32(ScanLogoFS.Length))

        '' Use StreamWriter for raw string output
        OutSW.Write(XMLSR.ReadToEnd())
        OutSW.Flush()

        Dim BinBuf() As Byte

        ReDim BinBuf(CInt(AdminLogoFS.Length - 1))
        AdminLogoFS.Read(BinBuf, 0, CInt(AdminLogoFS.Length))
        OutBW.Write(BinBuf)

        ReDim BinBuf(CInt(InitLogoFS.Length - 1))
        InitLogoFS.Read(BinBuf, 0, CInt(InitLogoFS.Length))
        OutBW.Write(BinBuf)

        ReDim BinBuf(CInt(ScanLogoFS.Length - 1))
        ScanLogoFS.Read(BinBuf, 0, CInt(ScanLogoFS.Length))
        OutBW.Write(BinBuf)

        OutBW.Close()

        XMLSR.Close()
        XMLFS.Close()
        AdminLogoFS.Close()
        InitLogoFS.Close()
        ScanLogoFS.Close()
        OutMS.Close()

        Return OutMS.ToArray()

    End Function

    Private Function EncryptBINFile(ByVal InBytes As Byte()) As Boolean

        Dim InMS As New IO.MemoryStream(InBytes)

        Dim OutFS As FileStream = File.Open(MyOutputFile.FullName, FileMode.Create)
        Dim RijndaelAlg As Rijndael = Rijndael.Create
        RijndaelAlg.Mode = CipherMode.CBC
        RijndaelAlg.Key = GetKey()
        Dim IV(15) As Byte
        RijndaelAlg.IV = IV
        Dim cStream As New CryptoStream(OutFS, RijndaelAlg.CreateEncryptor(), CryptoStreamMode.Write)

        Dim OutBW As New IO.BinaryWriter(cStream)

        Dim BinBuf() As Byte
        ReDim BinBuf(CInt(InMS.Length - 1))
        InMS.Read(BinBuf, 0, CInt(InMS.Length))
        OutBW.Write(BinBuf)

        OutBW.Close()
        cStream.Close()
        OutFS.Close()
        InMS.Close()

        Return True

    End Function

    Private Function GetKey() As Byte()
        Dim R(31) As Byte
        Dim MasterOffset As Integer = Asc(MyCarrier.Chars(0)) * 36 + Asc(MyCarrier.Chars(1))
        R(0) = Not Convert.ToByte(Asc(MyCarrier.Chars(0)))
        R(1) = Not Convert.ToByte(Asc(MyCarrier.Chars(1)))

        For I As Integer = 2 To 31
            R(I) = MyMaster((I + MasterOffset) Mod MyMaster.Length)
        Next

        Return R

    End Function

End Class
