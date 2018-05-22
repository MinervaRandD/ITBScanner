Imports System
Imports System.IO

Module Emulator

    ' Emulator specific functionality.
    '
    ' Emulator is used during debug and test only. Routines in this module are project
    ' add-ons required to make emulator work with the rest of the system.

    Private Function userFileConfigurationExists() As Boolean

        Dim userFilePath As String

        userFilePath = TagTrakConfigDirectory & "\UserList.txt"

        If Not File.Exists(userFilePath) Then Return False

        Dim userFileInputStream As StreamReader

        Try
            userFileInputStream = New StreamReader(userFilePath)
        Catch ex As Exception
            MsgBox("Unable to read user list file: " & ex.Message)
            Stop
        End Try

        Dim userName As String
        Dim emulatorConfigFilePath As String

        Try
            userName = userFileInputStream.ReadLine
        Catch ex As Exception
            MsgBox("Read on user list file failed: " & ex.message)
            Stop
        End Try

        If userName Is Nothing Then Return False

        While Not userName Is Nothing

            emulatorConfigFilePath = TagTrakConfigDirectory & "\ScannerConfig.txt"

            If Not File.Exists(emulatorConfigFilePath) Then
                userFileInputStream.Close()
                Return False
            End If

            Try
                userName = userFileInputStream.ReadLine
            Catch ex As Exception
                MsgBox("Read on user list file failed: " & ex.message)
                Stop
            End Try

        End While

        userFileInputStream.Close()

        Return True

    End Function

    Private Function configurationFilesExist() As Boolean

        Dim binFilePath As String
        Dim binFileFound As Boolean = False

        binFilePath = TagTrakConfigDirectory & "\TagTrakConfig.bin"

        If File.Exists(binFilePath) Then Return True

        binFilePath = TagTrakConfigDirectory & "\ScannerConfig.bin"

        If File.Exists(binFilePath) Then Return True

        If userFileConfigurationExists() Then Return True

        Return False

    End Function

    Private Function createEmulatorConfigurationFiles() As String

        Dim userNumber As Integer = Util.getUserNumber()

        If userNumber < 0 Then
            MsgBox("Unable to get user number.")
            Stop
        End If

        Dim userFilePath As String

        userFilePath = TagTrakConfigDirectory & "\UserList.txt"

        deleteLocalFile(userFilePath)

        Dim userFileOutputStream As StreamWriter

        Try
            userFileOutputStream = New StreamWriter(userFilePath)
        Catch ex As Exception
            MsgBox("Unable to create user list file: " & ex.Message)
            Stop
        End Try

        Dim userName As String
        Dim emulatorConfigFilePath As String

        Try
            userFileOutputStream.WriteLine(user)
        Catch ex As Exception
            MsgBox("Write on user list file failed: " & ex.message)
            Stop
        End Try

        userFileOutputStream.Close()

        Dim configFilePath As String

        configFilePath = TagTrakConfigDirectory & "\ScannerConfig.txt"

        deleteLocalFile(configFilePath)

        Dim configFileOutputStream As FileStream

        Try
            configFileOutputStream = New FileStream(configFilePath, FileMode.Create)
        Catch ex As Exception
            MsgBox("Unable to create user list file: " & ex.Message)
            Stop
        End Try

        Dim configTextArray() As String = defaultXMLConfigurationList(userNumber)

        Dim configTextString As String

        For Each configTextString In configTextArray

            Dim c As Char

            For Each c In configTextString

                Try

                    If configTextFileIsEncrypted Then
                        configFileOutputStream.WriteByte(Asc(c) Or &H80)
                    Else
                        configFileOutputStream.WriteByte(Asc(c))
                    End If

                Catch ex As Exception
                    MsgBox("Write on output file failed: " & ex.Message)
                    Stop
                End Try

            Next

        Next

        configFileOutputStream.Close()

        Return "OK"

    End Function

    Public Function setupConfigurationForEmulator() As String

        Dim result As String

        ' Check to see if some configuration mechanism exists on the emulator file system.

        If configurationFilesExist() Then Return "OK"
    
        ' No configuration mechanism exists. Create one.

        result = createEmulatorConfigurationFiles()

        Return result

    End Function


End Module
