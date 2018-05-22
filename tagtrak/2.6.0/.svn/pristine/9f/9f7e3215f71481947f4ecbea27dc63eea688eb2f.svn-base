Namespace Versioning

    ''' <summary>
    ''' Gets the version of TagTrak.exe being distributed.
    ''' </summary>
    ''' <remarks></remarks>
    Public Class TagTrak

        Private Shared MyRevision As String = ""
        Private MyTagTrakEXEFile As IO.FileInfo
        Sub New(ByVal TheTagTrakEXE As IO.FileInfo)
            If Not TheTagTrakEXE.Exists Then Throw New ApplicationException("No TagTrak.exe found.")
            MyTagTrakEXEFile = TheTagTrakEXE
        End Sub

        Public Function GetFullVersion() As String
            Dim Ver As System.Diagnostics.FileVersionInfo = System.Diagnostics.FileVersionInfo.GetVersionInfo(MyTagTrakEXEFile.FullName)
            Return ComputeTagTrakVersion(Ver.FileVersion)

        End Function

        Public Function GetVersion() As String
            Dim Ver As System.Diagnostics.FileVersionInfo = System.Diagnostics.FileVersionInfo.GetVersionInfo(MyTagTrakEXEFile.FullName)
            Dim VerParts() As String = Ver.FileVersion.Split("."c)

            Return VerParts(0) & "." & VerParts(1) & "." & GetRevision()

        End Function

        Private Function ComputeTagTrakVersion(ByVal TheFileVersion As String) As String
            Dim VerParts() As String = TheFileVersion.Split("."c)

            Dim DaysSince2k As Integer = Integer.Parse(VerParts(2))
            Dim SecSinceMidnight As Integer = Integer.Parse(VerParts(3)) * 2
            Dim MyVersionBuild As Integer = (DaysSince2k << 12) Or (SecSinceMidnight \ 22)

            Return VerParts(0) & "." & VerParts(1) & "." & GetRevision() & "." & MyVersionBuild.ToString

        End Function

        Private Function GetRevision() As String
            Do While TagTrak.MyRevision = ""
                Console.Write("Please enter TagTrak's revision number: ")
                Try
                    TagTrak.MyRevision = Integer.Parse(Console.ReadLine()).ToString
                Catch ex As Exception
                    TagTrak.MyRevision = ""
                End Try
            Loop

            Return TagTrak.MyRevision
        End Function

    End Class

End Namespace