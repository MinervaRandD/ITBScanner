Namespace Versioning

    ''' <summary>
    ''' Gets the version of the BIN files used from Version.xml.
    ''' </summary>
    ''' <remarks></remarks>
    Public Class BIN

        Private MyVersionXML As IO.FileInfo
        Sub New(ByVal TheVersionXMLDir As IO.DirectoryInfo)
            MyVersionXML = New IO.FileInfo(TheVersionXMLDir.FullName & "\Version.xml")
            If Not MyVersionXML.Exists Then Throw New ApplicationException("Version.XML not found.")
        End Sub

        Public Function GetFullVersion() As String
            Dim fsR As New IO.FileStream(MyVersionXML.FullName, IO.FileMode.Open)
            Dim Xtr As New Xml.XmlTextReader(fsR)
            Dim R As String
            Try
                Xtr.ReadStartElement("Version")
                R = Xtr.ReadString()
                Xtr.ReadEndElement()
            Catch ex As Exception
                Throw New ApplicationException("Error parsing Version.XML")
            Finally
                Xtr.Close()
                fsR.Close()
            End Try

            Return R

        End Function

    End Class

End Namespace