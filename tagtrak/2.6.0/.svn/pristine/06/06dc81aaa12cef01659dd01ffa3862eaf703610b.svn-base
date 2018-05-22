''' <summary>
''' Parses our custom XML config file.
''' </summary>
''' <remarks></remarks>
Public Class XMLer

    Private MyXMLFile As IO.FileInfo
    Private XD As Xml.XmlDocument

    Sub New()

    End Sub

    Public Function Load(ByVal TheXMLFile As IO.FileInfo) As Boolean
        MyXMLFile = TheXMLFile
        XD = New Xml.XmlDocument
        Try
            XD.Load(MyXMLFile.FullName)
        Catch ex As Exception
            Return False
        End Try

        Return True
    End Function

    Public Function GetVersionNumber() As String
        Dim xNL As Xml.XmlNodeList = XD.GetElementsByTagName("myConfigVersion")
        Return xNL.Item(0).InnerText

    End Function

    Public Function Validate() As Boolean
        If Not ValidateUserName() Then Return False
        If Not ValidateConfigVersion() Then Return False
        If Not ValidateFTPAddress() Then Return False

        Return True
    End Function

    Private Function ValidateUserName() As Boolean
        Dim xNL As Xml.XmlNodeList = XD.GetElementsByTagName("UserName")
        If xNL.Count <> 1 Then
            Console.WriteLine(MyXMLFile.Name & " has an incorrect number of <UserName> tags. Should have one.")
            Return False
        End If

        Dim xN As Xml.XmlNode = xNL.Item(0)
        If xN.InnerText().IndexOf(" "c) <> -1 Then
            Console.WriteLine(MyXMLFile.Name & " has a <UserName> tag with spaces. No spaces allowed.")
            Return False
        End If

        Return True

    End Function

    Private Function ValidateConfigVersion() As Boolean
        Dim xNL As Xml.XmlNodeList = XD.GetElementsByTagName("myConfigVersion")
        If xNL.Count <> 1 Then
            Console.WriteLine(MyXMLFile.Name & " has an incorrect number of <myConfigVersion> tags. Should have one.")
            Return False
        End If

        Return True

    End Function

    Private Function ValidateFTPAddress() As Boolean
        Dim xNL As Xml.XmlNodeList = XD.GetElementsByTagName("FtpHostName")

        If xNL.Count = 0 Then
            Console.WriteLine(MyXMLFile.Name & " needs a <FtpHostName> tag.")
            Return False
        End If

        Dim xN As Xml.XmlNode

        For Each xN In xNL
            If xN.ParentNode.Name = "User" Then
                If xN.InnerText().ToLower = "ftp.airline-software.com" Then
                    Console.WriteLine(MyXMLFile.Name & " has a <FtpHostName> tag set to ""ftp.airline-software.com"". Deprecated.")
                    Return False
                End If
            End If
        Next

        Return True

    End Function

End Class
