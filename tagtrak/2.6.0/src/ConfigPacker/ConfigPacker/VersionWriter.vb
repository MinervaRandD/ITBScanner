Public Class VersionWriter

    Public Shared Sub Write(ByVal TheOutDir As IO.DirectoryInfo, ByVal TheVersion As String)
        Dim xTW As New Xml.XmlTextWriter(TheOutDir.FullName & "\Version.xml", System.Text.Encoding.ASCII)
        xTW.WriteElementString("Version", TheVersion)
        xTW.Close()

    End Sub

End Class
