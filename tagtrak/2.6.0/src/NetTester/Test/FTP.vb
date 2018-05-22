Namespace Test
    '' Test FTP connection, login and file download
    Public Class FTP
        Inherits Generic

        Private MyHost As String
        Sub New(ByVal TheForm As Form, ByVal TheWriter As Writer, ByVal TheHost As String)
            MyBase.New(TheForm, TheWriter)
            MyHost = TheHost
        End Sub

        Protected Overrides Sub StartTestThread()
            Dim TestCount As Integer
            Dim TestIdx As Integer

            TestCount = 4

            Dim T2 As Double
            Dim T1 As Double

            Dim F As New Rebex.Net.Ftp

            T1 = Timing.MS
            Try
                F.Connect(MyHost)
                T2 = Timing.MS
            Catch ex As Exception
                T2 = Timing.MS
                MyWriter.WriteLine("Connect Result: Failed")
                MyWriter.WriteLine("Connect Exception: " & ex.ToString)
                MyWriter.WriteLine("Connect Delay: " & CStr(T2 - T1) & "ms")
                MyWriter.WriteLine(2)

                DoProgressUpdate(100)
                DoFinished(Generic.Results.Fail, "Cannot connect to " & MyHost & ".")
                Return
            End Try

            MyWriter.WriteLine("Connect Result: Success")
            MyWriter.WriteLine("Connect Delay: " & CStr(T2 - T1) & "ms")

            TestIdx += 1
            DoProgressUpdate(CInt((TestIdx / TestCount) * 100))

            T1 = Timing.MS
            Try
                F.Login("asi_general", "g3n3r@l!ti3s")
                T2 = Timing.MS
            Catch ex As Exception
                T2 = Timing.MS
                MyWriter.WriteLine("Login Result: Failed")
                MyWriter.WriteLine("Login Delay: " & CStr(T2 - T1) & "ms")
                MyWriter.WriteLine(2)

                DoProgressUpdate(100)
                DoFinished(Generic.Results.Fail, "Login to " & MyHost & " failed.")
                Return
            End Try

            MyWriter.WriteLine("Login Result: Success")
            MyWriter.WriteLine("Login Delay: " & CStr(T2 - T1) & "ms")

            TestIdx += 1
            DoProgressUpdate(CInt((TestIdx / TestCount) * 100))

            Dim MS As New System.IO.MemoryStream
            Dim GotBytes As Long
            T1 = Timing.MS
            Try
                GotBytes = F.GetFile("/airport_codes.gz", MS)
                T2 = Timing.MS
            Catch ex As Exception
                T2 = Timing.MS
                MyWriter.WriteLine("Download Result: Failed")
                MyWriter.WriteLine("Download Delay: " & CStr(T2 - T1) & "ms")
                MyWriter.WriteLine(2)

                DoProgressUpdate(100)
                DoFinished(Generic.Results.Fail, "Downloading file from " & MyHost & " failed.")
                Return
            End Try

            '' Check if the download was successful and flag it for grading later
            Dim DLSuccess As Boolean
            If GotBytes = MS.Length Then
                MyWriter.WriteLine("Download Result: Success")
                DLSuccess = True
            Else
                MyWriter.WriteLine("Download Result: Failed")
                DLSuccess = False
            End If

            TestIdx += 1
            DoProgressUpdate(CInt((TestIdx / TestCount) * 100))

            Try
                F.Disconnect()
            Catch ex As Exception
                MyWriter.WriteLine("Disconnect Result: Failed")
                MyWriter.WriteLine(2)
                Return
            End Try

            MyWriter.WriteLine("Disconnect Result: Success")

            MyWriter.WriteLine(2)

            TestIdx += 1
            DoProgressUpdate(CInt((TestIdx / TestCount) * 100))

            If DLSuccess Then
                DoFinished(Generic.Results.Pass, "Connected, logged in, and downloaded a file from " & MyHost & " successfully.")
            Else
                DoFinished(Generic.Results.Fail, "Download from " & MyHost & " incomplete.")
            End If

        End Sub

    End Class

End Namespace
