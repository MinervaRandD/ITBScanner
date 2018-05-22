Namespace AutoUpdate

    Public Class Reader

        Public MyUpdateDir As IO.DirectoryInfo
        Public Updates() As UpdateStruct

        Public Structure UpdateStruct
            Public FileName As String
            Public Source As IO.DirectoryInfo
        End Structure

        Private MyFsReader As IO.FileStream
        Private MyXMLR As Xml.XmlTextReader

        '' Throws ApplicationException on parse error, and IO exception on file error.
        Sub New(ByVal TheAutoUpdateDir As IO.DirectoryInfo)
            MyUpdateDir = TheAutoUpdateDir

            MyFsReader = New IO.FileStream(TheAutoUpdateDir.FullName & "\AutoUpdate.xml", IO.FileMode.Open)
            MyXMLR = New Xml.XmlTextReader(MyFsReader)
            Parse()

            MyXMLR.Close()
            MyFsReader.Close()
        End Sub

        ''' <summary>
        ''' Parse the AutoUpdate.xml file
        ''' </summary>
        ''' <remarks></remarks>
        Private Sub Parse()
            Dim R As New ArrayList
            Dim Update As UpdateStruct

            With MyXMLR

                Try
                    .ReadStartElement("updates")
                Catch ex As Exception
                    Throw New ApplicationException("Error parsing AutoUpdate.xml: " & ex.ToString)
                    Return
                End Try

                Do While Not .EOF
                    Try
                        Try
                            .ReadStartElement("update")
                        Catch ex As Exception
                            Exit Do
                        End Try

                        .ReadStartElement("filename")
                        Update.FileName = .ReadString
                        .ReadEndElement()

                        .ReadStartElement("source")
                        Update.Source = New IO.DirectoryInfo(.ReadString)
                        .ReadEndElement()

                        .ReadEndElement()
                    Catch ex As Exception
                        '' Error pasring XML
                        Throw New ApplicationException("Error parsing AutoUpdate.xml: " & ex.ToString)
                        Return
                    End Try

                    R.Add(Update)
                Loop

                Try
                    .ReadEndElement()
                Catch ex As Exception
                    Throw New ApplicationException("Error parsing AutoUpdate.xml: " & ex.ToString)
                    Return
                End Try

            End With

            Updates = R.ToArray(GetType(UpdateStruct))
        End Sub

    End Class

End Namespace