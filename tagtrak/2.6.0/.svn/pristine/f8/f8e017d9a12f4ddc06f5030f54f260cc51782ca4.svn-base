Namespace Uploader
    '' Uploads results up to our FTP server
    Public Class Results

        Private Const UploadTries As Integer = 3
        Private Const HostName As String = "ftp.asiscan.com"

        Private Ftp As New Rebex.Net.Ftp
        Private MyThread As System.Threading.Thread
        Private MyInStream As System.IO.Stream
        Private MyForm As Form

        Private MyPercent As Integer
        Public ReadOnly Property Percent() As Integer
            Get
                SyncLock Me
                    Return MyPercent
                End SyncLock
            End Get
        End Property

        Private MyStatus As String
        Public ReadOnly Property Status() As String
            Get
                SyncLock Me
                    Return MyStatus
                End SyncLock
            End Get
        End Property


        Private MySuccess As Boolean
        Public ReadOnly Property Success() As Boolean
            Get
                SyncLock Me
                    Return MySuccess
                End SyncLock
            End Get
        End Property

        Sub New(ByVal TheForm As Form, ByVal TheInStream As System.IO.Stream)
            MyInStream = TheInStream
            MyForm = TheForm
        End Sub

        Event ProgressUpdate(ByVal ThePercent As Integer, ByVal TheStatus As String)
        Event Finished(ByVal IsSuccess As Boolean)

        Public Sub Start()
            MyThread = New System.Threading.Thread(AddressOf UploadProcess)
            MyThread.Start()
        End Sub

        '' The uploading process
        Private Sub UploadProcess()
            For I As Integer = 1 To UploadTries
                If UploadFile() Then
                    '' Upload success
                    DoFinished(True)
                    Return
                End If
            Next

            DoFinished(False)
            Return

        End Sub

        '' Uploads file, returns True on success
        Private Function UploadFile() As Boolean
            Dim SN As String = Util.SerialNumber.ToString

            Dim ProgressStepCount As Integer = 3
            Dim ProgressStepIdx As Integer
            DoProgressUpdate(CInt((ProgressStepIdx / ProgressStepCount) * 100), "Connecting...")

            '' Connecto to FTP, create directories and switch to proper one.
            Try
                Ftp.Connect(HostName)
                ProgressStepIdx += 1
                DoProgressUpdate(CInt((ProgressStepIdx / ProgressStepCount) * 100), "Logging in")

                Ftp.Login("asi_general", "g3n3r@l!ti3s")

                If Not SubDirExists("NetTesterLogs") Then
                    Ftp.CreateDirectory("./NetTesterLogs")
                End If
                Ftp.ChangeDirectory("./NetTesterLogs")

                If SN <> "" Then
                    If Not SubDirExists("SN" & SN) Then
                        Ftp.CreateDirectory("./SN" & SN)
                    End If
                    Ftp.ChangeDirectory("./SN" & SN)
                End If
            Catch ex As Exception
                Return False
            End Try

            '' Position stream for upload
            MyInStream.Seek(0, System.IO.SeekOrigin.Begin)

            '' Upload file
            Dim FileName As String
            Try
                FileName = "Log." & Now.ToFileTimeUtc.ToString & ".txt"
                Dim I As Integer = 1
                Do While FileExists(FileName)
                    FileName = "Log." & Now.ToFileTimeUtc.ToString & "." & I.ToString & ".txt"
                Loop

                ProgressStepIdx += 1
                DoProgressUpdate(CInt((ProgressStepIdx / ProgressStepCount) * 100), "Uploading")

                Ftp.PutFile(MyInStream, "./" & FileName)
            Catch ex As Exception
                Return False
            End Try

            '' Disconnect, if faild not crucial
            Try
                Ftp.Disconnect()
            Catch ex As Exception
            End Try

            ProgressStepIdx += 1
            DoProgressUpdate(CInt((ProgressStepIdx / ProgressStepCount) * 100), "Finished")

            Return True

        End Function

        '' Returns true if a sub directory exists with the given name in the current directory
        Private Function SubDirExists(ByVal TheDirName As String) As Boolean
            Dim DirList As Rebex.Net.FtpList = Ftp.GetList()
            Dim FtpItem As Rebex.Net.FtpItem
            For Each FtpItem In DirList
                If FtpItem.IsDirectory And FtpItem.Name = TheDirName Then
                    Return True
                End If
            Next

            Return False
        End Function

        '' Returns true if a file exists with the given name in the current directory
        Private Function FileExists(ByVal TheFileName As String) As Boolean
            Dim DirList As Rebex.Net.FtpList = Ftp.GetList()
            Dim FtpItem As Rebex.Net.FtpItem
            For Each FtpItem In DirList
                If FtpItem.IsFile And FtpItem.Name = TheFileName Then
                    Return True
                End If
            Next

            Return False
        End Function

#Region "Event marshaling"
        Private Sub DoProgressUpdate(ByVal ThePercent As Integer, ByVal TheStatus As String)
            MyPercent = ThePercent
            MyStatus = TheStatus
            MyForm.Invoke(New EventHandler(AddressOf CallProgressUpdate))
        End Sub

        Private Sub CallProgressUpdate(ByVal s As Object, ByVal e As EventArgs)
            RaiseEvent ProgressUpdate(Percent, Status)
        End Sub

        Private Sub DoFinished(ByVal IsSuccess As Boolean)
            MySuccess = IsSuccess
            MyForm.Invoke(New EventHandler(AddressOf CallFinished))
        End Sub

        Private Sub CallFinished(ByVal s As Object, ByVal e As EventArgs)
            RaiseEvent Finished(Success)
        End Sub

#End Region

    End Class

End Namespace
