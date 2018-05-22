Imports System
Imports System.io
Imports System.xml

Module configuration

    Private configurationData As String = ""
    Private configParameterList() As String
    Private configFileBuffer() As Byte
    Private configBufferSize As Integer

    Public Function processUserSpecRecordChange() As String

        If Not MailScanFormRepository.MailScanDomsForm Is Nothing Then
            With MailScanFormRepository.MailScanDomsForm
                .mailCarrierCodeLabel.Text = userSpecRecord.carrierCode
                'activeReaderForm.cargoCarrierCodeLabel.Text = userSpecRecord.carrierCode

                'transfer point spec

                .transferPointLabel.Enabled = userSpecRecord.transferPointOnScanForm
                .transferPointTextBox.Enabled = userSpecRecord.transferPointOnScanForm
                .transferPointLabel.Visible = userSpecRecord.transferPointOnScanForm
                .transferPointTextBox.Visible = userSpecRecord.transferPointOnScanForm

                .loadLocationComboBox()
                .loadOperationComboBox()

                .loadMailFormLogo()
                .loadMailSimpleFormLogo()

            End With
        End If

    End Function

    Public Function loadConfigurationFiles() As String

        Dim result As String
        Dim configFileBuffer() As Byte
        Dim configBufferSize As Integer

        Dim i, ilmt As Integer

        If forceCreationOfConfigFilesFromDefaults Or emulatingPlatform Then
            setupConfigurationFromDefaults()
        End If

        Dim binFilePath As String
        Dim secondaryBinFilePath As String
        Dim binFileFound As Boolean = False

        binFilePath = TagTrakConfigDirectory & "\ScannerConfig.bin"

        If File.Exists(binFilePath) Then
            binFileFound = True
        End If

        If binFileFound Then
            ' Even if loading binary file failed, the program should still try to load from
            ' text config file
            result = loadConfigurationsFromBinaryFile(binFilePath)
            If result = "OK" Then
                fileUtilities.deleteLocalFile(binFilePath)
                result = setupInitialConfigurationRecord()
                If result = "OK" Then
                    Return result
                End If
            End If
        End If

        Dim userFilePath As String

        userFilePath = TagTrakConfigDirectory & "\UserList.txt"

        If File.Exists(userFilePath) Then

            result = loadConfigurationsFromUserList(userFilePath)
            If result <> "OK" Then Return result

            result = setupInitialConfigurationRecord()
            If result <> "OK" Then Return result

            Return "OK"

        End If

        Return "OK"

    End Function

    Private Function loadConfigurationsFromBinaryFile(ByVal binFilePath As String) As String

        Dim result As String

        If Not File.Exists(binFilePath) Then Return "File Does Not Exist"

        result = removeAllTempConfigFiles()
        If result <> "OK" Then Return result

        result = loadBinaryConfigFile(binFilePath)
        If result <> "OK" Then Return result

        loadedUserList.Clear()

        Dim binFileIndex As Integer = 0

        While binFileIndex < configBufferSize

            result = buildUserConfig(binFileIndex)
            If result <> "OK" Then Return result

        End While

        result = writeUserListFile()
        If result <> "OK" Then Return result

        result = removeOldConfigFiles()
        If result <> "OK" Then Return result

        result = moveTempFilesToConfigDirectory()
        If result <> "OK" Then Return result

        Return "OK"

    End Function

    Public Function setLastActiveUser(ByVal lastActiveUser As String) As String

        Dim lastUserFilePath As String = TagTrakConfigDirectory & "\LastUser.txt"

        deleteLocalFile(lastUserFilePath)

        Dim lastUserFileOutputStream As StreamWriter

        Try
            lastUserFileOutputStream = New StreamWriter(lastUserFilePath)
        Catch ex As Exception
            Return "Open on last user file failed: " & ex.Message
        End Try

        Try
            lastUserFileOutputStream.WriteLine(lastActiveUser)
        Catch ex As Exception
            lastUserFileOutputStream.Close()
            Return "Write on last user file failed: " & ex.message
        End Try

        lastUserFileOutputStream.Close()

    End Function

    Public Function getLastActiveUser(ByRef lastActiveUser As String) As String

        Dim lastUserFilePath As String = TagTrakConfigDirectory & "\LastUser.txt"

        If Not File.Exists(lastUserFilePath) Then
            lastActiveUser = ""
            Return "OK"
        End If

        Dim lastUserFileInputStream As StreamReader

        Try
            lastUserFileInputStream = New StreamReader(lastUserFilePath)
        Catch ex As Exception
            Return "Open on last user file failed: " & ex.Message
        End Try

        Try
            lastActiveUser = lastUserFileInputStream.ReadLine()
        Catch ex As Exception
            lastUserFileInputStream.Close()
            Return "Read on last user file failed: " & ex.message
        End Try

        lastUserFileInputStream.Close()

        Return "OK"

    End Function

    Private Function loadConfigurationBufferFromDefaultString(ByRef configFileBuffer() As Byte, ByRef configBufferSize As Integer) As String

        Dim configString As String = ""
        Dim configStringComponent As String
        Dim defaultConfigurationString() As String = defaultXMLConfigurationList(userNumber)

        For Each configStringComponent In defaultConfigurationString
            configString &= configStringComponent
        Next

        configBufferSize = Len(configString)

        Dim i, ilmt As Integer

        ilmt = configBufferSize - 1

        ReDim configFileBuffer(configBufferSize)

        For i = 0 To ilmt
            configFileBuffer(i) = Asc(configString.Chars(i))
        Next

        Return "OK"

    End Function

    Private Function loadConfigurationBufferFromBinaryFile(ByRef configFileBuffer() As Byte, ByRef configBufferSize As Integer) As String

        Dim binConfigFilePath As String = TagTrakConfigDirectory & "\ScannerConfig.bin"

        If Not File.Exists(binConfigFilePath) Then Return "File Does Not Exist"

        Dim configFileInputStream As FileStream

        Dim fi As FileInfo

        Try
            fi = New FileInfo(binConfigFilePath)
        Catch ex As Exception
            Return "Stat on configuration file '" & binConfigFilePath & "' failed: " & ex.Message
        End Try

        Try
            fi.Attributes = FileAttributes.Normal
        Catch ex As Exception
            Return "Attribute change configuration file '" & binConfigFilePath & "' failed: " & ex.Message
        End Try

        Try
            configFileInputStream = New FileStream(binConfigFilePath, FileMode.Open)
        Catch ex As Exception
            Return "Open on configuration file '" & binConfigFilePath & "' failed: " & ex.Message
        End Try

        Dim configFileSize As Integer = getFileSize(binConfigFilePath)

        If configFileSize < 0 Then
            Return "Stat on configuration file failed: invalid file size"
        End If

        Dim bytesRead As Integer
        Dim configFileInputBuffer(configFileSize) As Byte

        Try
            bytesRead = configFileInputStream.Read(configFileInputBuffer, 0, configFileSize)
        Catch ex As Exception
            Return "Read on configuration file '" & binConfigFilePath & "' failed: " & ex.message
        End Try

        configFileInputStream.Close()

        If bytesRead <> configFileSize Then
            Return "Read on configuration file '" & binConfigFilePath & "' failed: wrong number of bytes read"
        End If

        Dim configFileOutputBuffer(configFileSize + 4096) As Byte

        Dim result As Object

        'If userNumber < 0 Then

        '    'configBufferSize = decryptBufferWithUnknownKey(configFileInputBuffer, configFileSize, configFileOutputBuffer)
        '    'If configBufferSize < 0 Then Return "Corrupt data in configuration file: unable to decrypt"
        '    Return "Corrupt data in configuration file: unable to decrypt"

        'Else

        configBufferSize = decryptBuffer(configFileInputBuffer, configFileSize, configFileOutputBuffer)

            If configBufferSize < 0 Then
                'configBufferSize = decryptBufferWithUnknownKey(configFileInputBuffer, configFileSize, configFileOutputBuffer)
                'If configBufferSize < 0 Then Return "Corrupt data in configuration file: unable to decrypt"
                Return "Corrupt data in configuration file: unable to decrypt"
            End If

        'End If

        Dim configFileTextSize As Int32
        Dim adminLogoFileSize As Int32
        Dim scanLogoFileSize As Int32
        Dim initLogoFileSize As Int32

        Dim testInt As Int32

        testInt = Util.getIntegerFromByteBuffer(configFileOutputBuffer, 0)

        configFileTextSize = Util.getIntegerFromByteBuffer(configFileOutputBuffer, 4)
        adminLogoFileSize = Util.getIntegerFromByteBuffer(configFileOutputBuffer, 8)
        initLogoFileSize = Util.getIntegerFromByteBuffer(configFileOutputBuffer, 12)
        scanLogoFileSize = Util.getIntegerFromByteBuffer(configFileOutputBuffer, 16)

        ReDim configFileBuffer(configFileTextSize)
        configBufferSize = configFileTextSize

        Dim i, ilmt

        ilmt = configBufferSize - 1

        If configTextFileIsEncrypted Then
            For i = 0 To ilmt
                configFileBuffer(i) = configFileOutputBuffer(i + 20) Or &H80
            Next
        Else
            For i = 0 To ilmt
                configFileBuffer(i) = configFileOutputBuffer(i + 20)
            Next
        End If

        Dim textConfigFilePath As String = TagTrakConfigDirectory & "\ScannerConfig.txt"

        Dim adminLogoFilePath As String = TagTrakConfigDirectory & "\adminFormLogo.bmp"
        Dim initLogoFilePath As String = TagTrakConfigDirectory & "\initFormLogo.bmp"
        Dim scanLogoFilePath As String = TagTrakConfigDirectory & "\scanFormLogo.bmp"

        result = writeLocalFileFromBuffer(textConfigFilePath, configFileBuffer, 0, configBufferSize)
        If result <> "OK" Then Return result

        For i = 0 To ilmt
            configFileBuffer(i) = configFileBuffer(i) And &H7F
        Next

        Dim offset As Integer = 20 + configFileTextSize

        result = writeLocalFileFromBuffer(adminLogoFilePath, configFileOutputBuffer, offset, adminLogoFileSize)
        If result <> "OK" Then Return result

        offset += adminLogoFileSize

        result = writeLocalFileFromBuffer(initLogoFilePath, configFileOutputBuffer, offset, initLogoFileSize)
        If result <> "OK" Then Return result

        offset += initLogoFileSize

        result = writeLocalFileFromBuffer(scanLogoFilePath, configFileOutputBuffer, offset, scanLogoFileSize)
        If result <> "OK" Then Return result

        binConfigFilePath = TagTrakConfigDirectory & "\ScannerConfig.bin"

        deleteLocalFile(binConfigFilePath)

        Return "OK"

    End Function

    Private Function loadConfigurationBufferFromTextFile(ByRef configFileBuffer() As Byte, ByRef configBufferSize As Integer) As String

#If ValidationLevel >= 3 Then
        'verify(not configFileBuffer is nothing, 2203)
        'verify(configBufferSize > 0, 2204)
        'verify(configFileBuffer.Length >= configBufferSize, 2205)
#End If

        Dim textConfigFilePath As String = TagTrakConfigDirectory & "\ScannerConfig.txt"

        If Not File.Exists(textConfigFilePath) Then Return "File Does Not Exist"

        Dim configFileInputStream As FileStream

        Try
            configFileInputStream = New FileStream(textConfigFilePath, FileMode.Open)
        Catch ex As Exception
            Return "Open on configuration file '" & textConfigFilePath & "' failed: " & ex.Message
        End Try

        configBufferSize = getFileSize(textConfigFilePath)

        If configBufferSize < 0 Then
            Return "Stat on configuration file failed: invalid file size"
        End If

        Dim bytesRead As Integer
        ReDim configFileBuffer(configBufferSize)

        Try
            bytesRead = configFileInputStream.Read(configFileBuffer, 0, configBufferSize)
        Catch ex As Exception
            Return "Read on configuration file '" & textConfigFilePath & "' failed: " & ex.message
        End Try

        configFileInputStream.Close()

        If bytesRead <> configBufferSize Then
            Return "Read on configuration file '" & textConfigFilePath & "' failed: wrong number of bytes read"
        End If

        Dim i, ilmt As Integer

        ilmt = configBufferSize - 1

        For i = 0 To ilmt
            configFileBuffer(i) = configFileBuffer(i) And &H7F
        Next

        Return "OK"

    End Function

    Private Function loadConfigurationBufferFromFile(ByRef configFileBuffer() As Byte, ByRef configBufferSize As Integer) As String

#If ValidationLevel >= 3 Then
        'verify(not configFileBuffer is nothing, 2206)
        'verify(configBufferSize > 0, 2207)
        'verify(configFileBuffer.Length >= configBufferSize, 2208)
#End If

        Dim result As String

        result = loadConfigurationBufferFromBinaryFile(configFileBuffer, configBufferSize)

        If result = "OK" Then

            Return "OK"

        ElseIf result <> "File Does Not Exist" Then

            Return result

        End If

        result = loadConfigurationBufferFromTextFile(configFileBuffer, configBufferSize)

        Return result

    End Function

    Private Function isXMLConfigurationBuffer(ByVal inputBuffer() As Byte) As Boolean

        Dim i, ilmt As Integer

        ilmt = inputBuffer.Length - 7

        For i = 0 To ilmt

            If Chr(inputBuffer(i)) = "<"c Then


                If Chr(inputBuffer(i + 1)) = "U"c And _
                    Chr(inputBuffer(i + 2)) = "s"c And _
                    Chr(inputBuffer(i + 3)) = "e"c And _
                    Chr(inputBuffer(i + 4)) = "r"c And _
                    Chr(inputBuffer(i + 5)) = ">"c Then
                    Return True

                End If

            End If

        Next

        Return False

    End Function

    Private Function removeAllTempConfigFiles() As String

        Dim di As DirectoryInfo

        'Modified by MX
        Dim tempDirectoryPath As String = TagTrakTempDirectory

        Try
            di = New DirectoryInfo(tempDirectoryPath)
        Catch ex As Exception
            Return "Distribution of new config files failed: " & ex.Message
        End Try

        Dim tempFileInfo As FileInfo

        For Each tempFileInfo In di.GetFiles
            If tempFileInfo.Name.IndexOf("TagTrakConfig") >= 0 Then
                deleteLocalFile(tempFileInfo.FullName)
            ElseIf tempFileInfo.Name.IndexOf("TagTrakScannerConfig") >= 0 Then
                deleteLocalFile(tempFileInfo.FullName)
            ElseIf tempFileInfo.Name.IndexOf("adminFormLogo") >= 0 Then
                deleteLocalFile(tempFileInfo.FullName)
            ElseIf tempFileInfo.Name.IndexOf("AdminFormLogo") >= 0 Then
                deleteLocalFile(tempFileInfo.FullName)
            ElseIf tempFileInfo.Name.IndexOf("initFormLogo") >= 0 Then
                deleteLocalFile(tempFileInfo.FullName)
            ElseIf tempFileInfo.Name.IndexOf("InitFormLogo") >= 0 Then
                deleteLocalFile(tempFileInfo.FullName)
            ElseIf tempFileInfo.Name.IndexOf("mailFormLogo") >= 0 Then
                deleteLocalFile(tempFileInfo.FullName)
            ElseIf tempFileInfo.Name.IndexOf("mailFormLogo") >= 0 Then
                deleteLocalFile(tempFileInfo.FullName)
            ElseIf tempFileInfo.Name.IndexOf("UserList") >= 0 Then
                deleteLocalFile(tempFileInfo.FullName)
            End If
        Next

        Return "OK"

    End Function

    Private Function removeOldConfigFiles() As String

        Dim di As DirectoryInfo
        Dim ConfigDirectoryPath As String = TagTrakConfigDirectory

        Try
            di = New DirectoryInfo(ConfigDirectoryPath)
        Catch ex As Exception
            Return "Distribution of new config files failed: " & ex.Message
        End Try

        Dim ConfigFileInfo As FileInfo

        For Each ConfigFileInfo In di.GetFiles
            If ConfigFileInfo.Name.IndexOf("TagTrakConfig") >= 0 Then
                deleteLocalFile(ConfigFileInfo.FullName)
            ElseIf ConfigFileInfo.Name.IndexOf("TagTrakScannerConfig") >= 0 Then
                deleteLocalFile(ConfigFileInfo.FullName)
            ElseIf ConfigFileInfo.Name.IndexOf("adminFormLogo") >= 0 Then
                deleteLocalFile(ConfigFileInfo.FullName)
            ElseIf ConfigFileInfo.Name.IndexOf("AdminFormLogo") >= 0 Then
                deleteLocalFile(ConfigFileInfo.FullName)
            ElseIf ConfigFileInfo.Name.IndexOf("initFormLogo") >= 0 Then
                deleteLocalFile(ConfigFileInfo.FullName)
            ElseIf ConfigFileInfo.Name.IndexOf("InitFormLogo") >= 0 Then
                deleteLocalFile(ConfigFileInfo.FullName)
            ElseIf ConfigFileInfo.Name.IndexOf("mailFormLogo") >= 0 Then
                deleteLocalFile(ConfigFileInfo.FullName)
            ElseIf ConfigFileInfo.Name.IndexOf("mailFormLogo") >= 0 Then
                deleteLocalFile(ConfigFileInfo.FullName)
            End If
        Next

        Return "OK"

    End Function

    Private Function loadBinaryConfigFile(ByVal binFilePath As String) As String

        Dim fi As FileInfo

        Try
            fi = New FileInfo(binFilePath)
        Catch ex As Exception
            Return "Stat on configuration file '" & binFilePath & "' failed: " & ex.Message
        End Try

        Try
            fi.Attributes = FileAttributes.Normal
        Catch ex As Exception
            Return "Attribute change configuration file '" & binFilePath & "' failed: " & ex.Message
        End Try

        Dim binFileInputStream As FileStream

        Try
            binFileInputStream = New FileStream(binFilePath, FileMode.Open)
        Catch ex As Exception
            Return "Open on configuration file '" & binFilePath & "' failed: " & ex.Message
        End Try

        Dim binFileSize As Integer = getFileSize(binFilePath)

        If binFileSize < 0 Then
            Return "Stat on configuration file failed: invalid file size"
        End If

        Dim bytesRead As Integer
        Dim configFileInputBuffer(binFileSize) As Byte

        Try
            bytesRead = binFileInputStream.Read(configFileInputBuffer, 0, binFileSize)
        Catch ex As Exception
            Return "Read on configuration file '" & binFilePath & "' failed: " & ex.message
        End Try

        binFileInputStream.Close()

        If bytesRead <> binFileSize Then
            Return "Read on configuration file '" & binFilePath & "' failed: wrong number of bytes read"
        End If

        ReDim configFileBuffer(binFileSize + 4096)

        If emulatingPlatform Then
            Array.Copy(configFileInputBuffer, 0, configFileBuffer, 0, binFileSize)
            Return "OK"
        End If

        'configBufferSize = decryptBufferWithUnknownKey(configFileInputBuffer, binFileSize, configFileBuffer)
        configBufferSize = fileUtilities.decryptBuffer(configFileInputBuffer, binFileSize, configFileBuffer)
        If configBufferSize < 0 Then Return "Corrupt data in configuration file: unable to decrypt"

        Return "OK"

    End Function

    Private Function buildUserConfig(ByRef binFileIndex As Integer) As String

        Dim result As String

        Dim i, ilmt As Integer

        Dim configFileTextSize As Int32
        Dim adminLogoFileSize As Int32
        Dim scanLogoFileSize As Int32
        Dim initLogoFileSize As Int32

        Dim testInt As Int32

        testInt = Util.getIntegerFromByteBuffer(configFileBuffer, binFileIndex)

        configFileTextSize = Util.getIntegerFromByteBuffer(configFileBuffer, binFileIndex + 4)
        adminLogoFileSize = Util.getIntegerFromByteBuffer(configFileBuffer, binFileIndex + 8)
        initLogoFileSize = Util.getIntegerFromByteBuffer(configFileBuffer, binFileIndex + 12)
        scanLogoFileSize = Util.getIntegerFromByteBuffer(configFileBuffer, binFileIndex + 16)

        Dim configTextOffset As Integer
        Dim adminLogoOffset As Integer
        Dim scanLogoOffset As Integer
        Dim initLogoOffset As Integer

        configTextOffset = binFileIndex + 20
        adminLogoOffset = configTextOffset + configFileTextSize
        initLogoOffset = adminLogoOffset + adminLogoFileSize
        scanLogoOffset = initLogoOffset + initLogoFileSize

        binFileIndex = scanLogoOffset + scanLogoFileSize

        Dim configByteBuffer(configFileTextSize) As Byte

        Array.Copy(configFileBuffer, configTextOffset, configByteBuffer, 0, configFileTextSize)

        Dim newUserSpecRecord As New userSpecRecordClass

        If Not isXMLConfigurationBuffer(configByteBuffer) Then
            Return "Configuration files must be in xml format"
        End If

        Dim configCharBuffer(configFileTextSize) As Char

        ilmt = configFileTextSize - 1

        For i = 0 To ilmt
            configCharBuffer(i) = Chr(configByteBuffer(i))
        Next

        Dim configFileString As String = configCharBuffer

        result = newUserSpecRecord.parse(configFileString)
        If result <> "OK" Then Return result

        loadedUserList.Add(newUserSpecRecord)

        Dim userName As String = newUserSpecRecord.userName

        Dim configTempFilePath As String = TagTrakTempDirectory & "\ScannerConfig.txt"
        Dim adminLogoTempFilePath As String = TagTrakTempDirectory & "\" & userName & "AdminFormLogo.bmp"
        Dim initLogoTempFilePath As String = TagTrakTempDirectory & "\" & userName & "InitFormLogo.bmp"
        Dim scanLogoTempFilePath As String = TagTrakTempDirectory & "\" & userName & "scanFormLogo.bmp"

        If configTextFileIsEncrypted Then
            For i = 0 To ilmt
                configByteBuffer(i) = configByteBuffer(i) Or &H80
            Next
        Else
            For i = 0 To ilmt
                configByteBuffer(i) = configByteBuffer(i)
            Next
        End If

        result = writeLocalFileFromBuffer(configTempFilePath, configByteBuffer, 0, configFileTextSize)
        If result <> "OK" Then Return result

        For i = 0 To ilmt
            configFileBuffer(i) = configFileBuffer(i) And &H7F
        Next

        result = writeLocalFileFromBuffer(adminLogoTempFilePath, configFileBuffer, adminLogoOffset, adminLogoFileSize)
        If result <> "OK" Then Return result

        result = writeLocalFileFromBuffer(initLogoTempFilePath, configFileBuffer, initLogoOffset, initLogoFileSize)
        If result <> "OK" Then Return result

        result = writeLocalFileFromBuffer(scanLogoTempFilePath, configFileBuffer, scanLogoOffset, scanLogoFileSize)
        If result <> "OK" Then Return result

        Return "OK"

    End Function

    Private Function writeUserListFile() As String

        Dim userListFilePath As String = TagTrakConfigDirectory & "\UserList.txt"

        deleteLocalFile(userListFilePath)

        Dim userListOutputStream As StreamWriter

        Try
            userListOutputStream = New StreamWriter(userListFilePath)
        Catch ex As Exception
            Return "Cannot open user list file for output: " & ex.Message
        End Try

        Dim localUserSpecRecord As userSpecRecordClass

        For Each localUserSpecRecord In loadedUserList

            Try
                userListOutputStream.WriteLine(localUserSpecRecord.userName)
            Catch ex As Exception
                Return "Write to user list file failed: " & ex.message
            End Try

        Next

        userListOutputStream.Close()

        Return "OK"

    End Function

    Private Function moveTempFilesToConfigDirectory() As String

        Dim configTempFilePath As String
        Dim adminLogoTempFilePath As String
        Dim initLogoTempFilePath As String
        Dim scanLogoTempFilePath As String

        Dim configConfigFilePath As String
        Dim adminLogoConfigFilePath As String
        Dim initLogoConfigFilePath As String
        Dim scanLogoConfigFilePath As String

        Dim userName As String

        Dim localUserSpecRecord As userSpecRecordClass

        For Each localUserSpecRecord In loadedUserList

            userName = localUserSpecRecord.userName

            configTempFilePath = TagTrakTempDirectory & "\ScannerConfig.txt"
            adminLogoTempFilePath = TagTrakTempDirectory & "\" & userName & "AdminFormLogo.bmp"
            initLogoTempFilePath = TagTrakTempDirectory & "\" & userName & "InitFormLogo.bmp"
            scanLogoTempFilePath = TagTrakTempDirectory & "\" & userName & "scanFormLogo.bmp"

            configConfigFilePath = TagTrakConfigDirectory & "\ScannerConfig.txt"
            adminLogoConfigFilePath = TagTrakConfigDirectory & "\" & userName & "AdminFormLogo.bmp"
            initLogoConfigFilePath = TagTrakConfigDirectory & "\" & userName & "InitFormLogo.bmp"
            scanLogoConfigFilePath = TagTrakConfigDirectory & "\" & userName & "scanFormLogo.bmp"

            moveLocalFile(configTempFilePath, configConfigFilePath)
            moveLocalFile(adminLogoTempFilePath, adminLogoConfigFilePath)
            moveLocalFile(initLogoTempFilePath, initLogoConfigFilePath)
            moveLocalFile(scanLogoTempFilePath, scanLogoConfigFilePath)

        Next

        Return "OK"

    End Function

    Private Function readUserListFile(ByVal userListFile As String, ByRef userListArray As ArrayList) As String

        userListArray.Clear()

        Dim userListInputStream As StreamReader

        Try
            userListInputStream = New StreamReader(userListFile)
        Catch ex As Exception
            Return "Open on user list file failed: " & ex.Message
        End Try

        Dim userName As String

        While True

            Try
                userName = userListInputStream.ReadLine()
            Catch ex As Exception
                Return "Read on user list file failed: " & ex.message
            End Try

            If userName Is Nothing Then Exit While

            userListArray.Add(userName)

        End While

        userListInputStream.Close()

        Return "OK"

    End Function

    Private Function loadConfigFile(ByVal userName As String) As String

        Dim configFilePath As String
        Dim result As String

        configFilePath = TagTrakConfigDirectory & "\ScannerConfig.txt"

        If Not File.Exists(configFilePath) Then
            Return "Configuration file for " & userName & " not found."
        End If

        Dim configFileInputStream As FileStream

        Try
            configFileInputStream = New FileStream(configFilePath, FileMode.Open)
        Catch ex As Exception
            Return "Open on configuration file '" & configFilePath & "' failed: " & ex.Message
        End Try

        configBufferSize = getFileSize(configFilePath)

        If configBufferSize < 0 Then
            Return "Stat on configuration file failed: invalid file size"
        End If

        Dim bytesRead As Integer
        ReDim configFileBuffer(configBufferSize)

        Try
            bytesRead = configFileInputStream.Read(configFileBuffer, 0, configBufferSize)
        Catch ex As Exception
            Return "Read on configuration file '" & configFilePath & "' failed: " & ex.message
        End Try

        configFileInputStream.Close()

        If bytesRead <> configBufferSize Then
            Return "Read on configuration file '" & configFilePath & "' failed: wrong number of bytes read"
        End If

        Dim i, ilmt As Integer

        ilmt = configBufferSize - 1

        For i = 0 To ilmt
            configFileBuffer(i) = configFileBuffer(i) And &H7F
        Next

        Dim newUserSpecRecord As New userSpecRecordClass

        If Not isXMLConfigurationBuffer(configFileBuffer) Then

            Return "Unable to parse non-xml configuration files"

        End If

        Dim configCharBuffer(configBufferSize) As Char
        Dim configString As String

        For i = 0 To ilmt
            configCharBuffer(i) = Chr(configFileBuffer(i))
        Next

        ''Test

        'Dim configTextArray() As String = defaultXMLConfigurationList(userNumber)

        'Dim s As String

        'Dim configTextString As String

        'For Each configTextString In configTextArray

        '    s = s + configTextString

        'Next

        ''Test

        'result = newUserSpecRecord.pars

        configString = New String(configCharBuffer)

        result = newUserSpecRecord.parse(configString)
        If result <> "OK" Then Return result

        loadedUserList.Add(newUserSpecRecord)

        Return "OK"

    End Function

    Private Function loadConfigurationsFromUserList(ByVal userFilePath As String) As String

        Dim result As String

        Dim userListArray As New ArrayList

        loadedUserList.Clear()

        result = readUserListFile(userFilePath, userListArray)
        If result <> "OK" Then Return result

        Dim i, ilmt As Integer

        ilmt = userListArray.Count - 1

        For i = 0 To ilmt

            result = loadConfigFile(userListArray(i))
            If result <> "OK" Then Return result

        Next

        Return "OK"

    End Function

    Private Function setupInitialConfigurationRecord() As String

        Dim result As String
        Dim lastActiveUser As String

        If loadedUserList.Count <= 0 Then
            userSpecRecord = Nothing
            Return "Unable to set up initial user"
        End If

        If loadedUserList.Count = 1 Then
            userSpecRecord = loadedUserList(0)
            Return "OK"
        End If

        result = getLastActiveUser(lastActiveUser)
        If result <> "OK" Then Return result

        Dim currentUserSpecRecord As userSpecRecordClass

        For Each currentUserSpecRecord In loadedUserList

            If currentUserSpecRecord.userName = lastActiveUser Then
                userSpecRecord = currentUserSpecRecord
                Return "OK"
            End If

        Next

        userSpecRecord = loadedUserList(0)

        Return "OK"

    End Function

    Private Function setupConfigurationFromDefaults() As String

        Dim result As String

        'Dim fileList() As String

        'Try
        '    fileList = Directory.GetFiles(TagTrakConfigDirectory)
        'Catch ex As Exception
        '    Return "Stat on config directory failed: " & result
        'End Try

        'Dim fileName As String

        'For Each fileName In fileList
        '    If fileName.IndexOf("ScannerConfig.txt") >= 0 Then
        '        deleteLocalFile(fileName)
        '    ElseIf fileName.IndexOf("FormLogo.bmp") >= 0 Then
        '        deleteLocalFile(fileName)
        '    End If
        'Next

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

        Dim configTextArray() As String = defaultXMLConfigurationList(Util.getUserNumber())

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


End Module
