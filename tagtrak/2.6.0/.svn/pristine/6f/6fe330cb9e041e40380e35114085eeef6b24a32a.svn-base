' Copyright (c) 2003-2004 Aviation Software, Inc.,
' All Rights Reserved. 
' Reproduction of this document in whole or in part without written permission of   
' Aviation Software, Inc. is strictly prohibited.
'
' Aviation Software, Inc., Confidential - Restricted Access
'
' This document contains proprietary information that shall be
' distributed or routed only within Aviation Software, Inc.,
' and its authorized clients, except with written permission of
' Aviation Software, Inc. 

Imports System
Imports System.io
Imports System.Text
Imports System.Security.Cryptography
Imports ICSharpCode.SharpZipLib.GZip

Module fileUtilities

    Public Function setupDeviceFileSystem() As String

#If deviceType = "Intermec" Then

        If emulatingPlatform Then
            createLocalDirectoryIfNecessary("\SDMMC Disk")
            createLocalDirectoryIfNecessary("\Flash File Store")
            createLocalDirectoryIfNecessary("\Temp")
        End If

        If Directory.Exists("\SDMMC Disk") Then

            deviceNonVolatileMemoryDirectory = "\SDMMC Disk"
            deviceBackupDirectory = "\Flash File Store" & selectedCarrierPath

        ElseIf Directory.Exists("\Flash File Store") Then

            deviceNonVolatileMemoryDirectory = "\Flash File Store"
            deviceBackupDirectory = "\Temp" & selectedCarrierPath

        Else

            MsgBox("Cannot find non-volatile memory directory")
            Return "Cannot find non-volatile memory directory"

        End If

#ElseIf deviceType = "Symbol" Then

        If emulatingPlatform Then
            createLocalDirectoryIfNecessary("\Application")
            createLocalDirectoryIfNecessary("\Flash File Store")
            createLocalDirectoryIfNecessary("\Temp")
        End If

        'If Directory.Exists("\Application") Then

            'deviceNonVolatileMemoryDirectory = "\Application"
            'deviceBackupDirectory = "\Flash File Store"

        'Modified by MX
        If Directory.Exists("\SDMMC Disk") Then

            deviceNonVolatileMemoryDirectory = "\SDMMC Disk"
            deviceBackupDirectory = "\Temp" & selectedCarrierPath

        ElseIf Directory.Exists("\Storage Card") Then
            deviceNonVolatileMemoryDirectory = "\Storage Card"
            deviceBackupDirectory = "\Temp" & selectedCarrierPath

        ElseIf Directory.Exists("\Flash File Store") Then

            'deviceNonVolatileMemoryDirectory = "\Flash File Store"
            'deviceBackupDirectory = "\Temp"

            deviceNonVolatileMemoryDirectory = "\Flash File Store"
            deviceBackupDirectory = "\Temp" & selectedCarrierPath
        ElseIf Directory.Exists("\Application") Then

            deviceNonVolatileMemoryDirectory = "\Application"
            deviceBackupDirectory = "\Temp" & selectedCarrierPath

        Else

            MsgBox("Cannot find non-volatile memory directory")
            Return "Cannot find non-volatile memory directory"

        End If

#ElseIf deviceType = "Dolphin" Then

        If emulatingPlatform Then
            createLocalDirectoryIfNecessary("\Storage Card")
            createLocalDirectoryIfNecessary("\IPSM")
            createLocalDirectoryIfNecessary("\Temp")
        End If

        If Directory.Exists("\Storage Card") Then

            deviceNonVolatileMemoryDirectory = "\Storage Card"
            deviceBackupDirectory = "\IPSM" & selectedCarrierPath

        ElseIf Directory.Exists("\IPSM") Then

            deviceNonVolatileMemoryDirectory = "\IPSM"
            deviceBackupDirectory = "\Temp" & selectedCarrierPath

        Else

            MsgBox("Cannot find non-volatile memory directory")
            Return "Cannot find non-volatile memory directory"

        End If

#ElseIf deviceType = "ViewSonic" Then

        If emulatingPlatform Then
            createLocalDirectoryIfNecessary("\My Flash Disk")
            createLocalDirectoryIfNecessary("\Temp")
        End If

        If Directory.Exists("\My Flash Disk") Then

            deviceNonVolatileMemoryDirectory = "\My Flash Disk"
            deviceBackupDirectory = "\Flash File Store"

        ElseIf Directory.Exists("\Flash File Store") Then

            deviceNonVolatileMemoryDirectory = "\Flash File Store"
            deviceBackupDirectory = "\Temp"

        Else

            MsgBox("Cannot find non-volatile memory directory")
            Return "Cannot find non-volatile memory directory"

        End If

#ElseIf deviceType = "PC" Then

        deviceNonVolatileMemoryDirectory = "C:\SDMMC Disk"
        deviceBackupDirectory = "C:\Flash File Store"

        createLocalDirectoryIfNecessary(deviceNonVolatileMemoryDirectory)

        lockDown = False

#End If
        'May need to be disabled (MX)
        'createLocalDirectoryIfNecessary(deviceBackupDirectory)

        Util.verify(Directory.Exists(deviceNonVolatileMemoryDirectory), 2600)

        TagTrakTempDirectory = deviceNonVolatileMemoryDirectory & selectedCarrierPath & "\TagTrakTemp"
        D2577Directory = deviceNonVolatileMemoryDirectory & "\2577"
        TagTrakConfigDirectory = deviceNonVolatileMemoryDirectory & selectedCarrierPath & "\TagTrakConfig"
        TagTrakBackupDirectory = deviceNonVolatileMemoryDirectory & selectedCarrierPath & "\TagTrakBackup"
        'TagTrakReloadDirectory = deviceNonVolatileMemoryDirectory & "\TagTrakReload"
        TagTrakDataDirectory = deviceNonVolatileMemoryDirectory & selectedCarrierPath & "\TagTrakData"
        TagTrakSummariesDirectory = TagTrakDataDirectory & "\Summaries"
        CabfilesDirectory = deviceNonVolatileMemoryDirectory & "\cabfiles"

        'Modified by MX

        backupResditFilePath = deviceBackupDirectory & "\" & userSpecRecord.userName & "MailData.txt"
        backupCargoFilePath = deviceBackupDirectory & "\" & userSpecRecord.userName & "CargoData.txt"
        backupBaggageFilePath = deviceBackupDirectory & "\" & userSpecRecord.userName & "BaggageData.txt"

#If deviceType = "Intermec" Then
        createLocalDirectoryIfNecessary(D2577Directory)
        createLocalDirectoryIfNecessary(CabfilesDirectory)
#End If

        createLocalDirectoryIfNecessary(TagTrakTempDirectory)
        createLocalDirectoryIfNecessary(TagTrakConfigDirectory)
        createLocalDirectoryIfNecessary(TagTrakBackupDirectory)
        'createLocalDirectoryIfNecessary(TagTrakReloadDirectory)
        createLocalDirectoryIfNecessary(TagTrakDataDirectory)
        createLocalDirectoryIfNecessary(TagTrakSummariesDirectory)

        'createLocalDirectoryIfNecessary(backupResditFilePath)
        'createLocalDirectoryIfNecessary(backupCargoFilePath)
        'createLocalDirectoryIfNecessary(backupBaggageFilePath)

        Return "OK"

    End Function

    Public Function getDateStampFromDateStampFile(ByVal dateStampFilePath As String, ByRef fileDateStamp As DateTime) As String

        Dim dateStampFileInputStream As StreamReader
        Dim dateStampString As String

        Try
            dateStampFileInputStream = New StreamReader(dateStampFilePath)
        Catch ex As Exception
            Return "getDateStampFromDateStampFile|Open on date stamp file failed|" & ex.Message
        End Try

        Try
            dateStampString = dateStampFileInputStream.ReadLine()
        Catch ex As Exception
            dateStampFileInputStream.Close()
            Return "getDateStampFromDateStampFile|Read on date stamp file failed|" & ex.Message
        End Try

        dateStampFileInputStream.Close()

        Try
            fileDateStamp = DateTime.Parse(dateStampString)
        Catch ex As Exception
            Return "getDateStampFromDateStampFile|Unable to parse local date stamp '" & dateStampString & "'" & ex.Message
        End Try

        Return "OK"

    End Function

    Public Function saveDateStampToDateStampFile(ByVal dateStamp As DateTime, ByVal dateStampFilePath As String) As String

        deleteLocalFile(dateStampFilePath)

        Dim dateStampFileOutputStream As StreamWriter

        Try
            dateStampFileOutputStream = New StreamWriter(dateStampFilePath)
        Catch ex As Exception
            Return "saveDateStampToDateStampFile|Unable to open date stamp file '" & dateStampFilePath & "' for write|" & ex.Message
        End Try

        Dim dateStampString As String = String.Format("{0:yyyy-MM-dd HH:mm:ss}", dateStamp)

        Try
            dateStampFileOutputStream.WriteLine(dateStampString)
        Catch ex As Exception
            dateStampFileOutputStream.Close()
            Return "saveDateStampToDateStampFile|Write on date stamp file '" & dateStampFilePath & "' failed|" & ex.Message
        End Try

        dateStampFileOutputStream.Close()

        Return "OK"

    End Function

    Public Function getFileSize(ByRef inputFilePath As String) As Integer

#If ValidationLevel >= 3 Then

        If diagnosticLevel >= 2 Then
            verify(Not inputFilePath Is Nothing, 804)
        End If

#End If

        If Not File.Exists(inputFilePath) Then
            Return -1
        End If

        Dim fi As FileInfo

        Try
            fi = New FileInfo(inputFilePath)
        Catch ex As Exception
            MsgBox("Get file information failed: " & ex.Message)
            Return -1
        End Try

        Return fi.Length

    End Function

    Public Function getFileSize(ByRef inputFileName As String, ByRef inputDirectory As String) As Integer

#If ValidationLevel >= 3 Then

        If diagnosticLevel >= 2 Then
            verify(Not inputFileName Is Nothing, 805)
            verify(Not inputDirectory Is Nothing, 806)
        End If

#End If

        If Not isNonNullString(inputFileName) Then
            Return "Invalid input file name."
        End If

        If Not isNonNullString(inputDirectory) Then
            Return "Invalid input directory."
        End If

        If Not Directory.Exists(inputDirectory) Then
            Return -1
        End If

        Dim filePath As String

        filePath = inputDirectory

        Dim filePathLength As String = Length(filePath)

        If filePath.EndsWith("/") Then
            filePath = Substring(filePath, 0, filePathLength - 1) & backSlash
        ElseIf Not filePath.EndsWith(backSlash) Then
            filePath &= backSlash
        End If

        filePath &= inputFileName

        Dim returnFileSize = getFileSize(filePath)

        Return returnFileSize

    End Function


    Public Function deleteLocalFile(ByRef fileNameString As String)

#If ValidationLevel >= 3 Then

        If diagnosticLevel >= 2 Then
            verify(Not fileNameString Is Nothing, 807)
        End If

#End If

        If Not File.Exists(fileNameString) Then Exit Function

        Dim localFileInfo As FileInfo

        Try
            localFileInfo = New FileInfo(fileNameString)
        Catch ex As Exception
            MsgBox("Delete of file " & fileNameString & " failed: " & ex.Message)
            Exit Function
        End Try

        Try
            localFileInfo.Attributes = FileAttributes.Normal
        Catch ex As Exception
            MsgBox("Delete of file " & fileNameString & " failed: " & ex.Message)
            Exit Function
        End Try

        Try
            System.IO.File.Delete(fileNameString)
        Catch ex As Exception
            MsgBox("Delete of file " & fileNameString & " failed: " & ex.Message)
            Return False
        End Try

        Return True

    End Function

    Public Function deleteLocalDirectory(ByRef directoryNameString As String)

#If ValidationLevel >= 3 Then

        If diagnosticLevel >= 2 Then
            verify(Not directoryNameString Is Nothing, 808)
        End If

#End If

        If Not Directory.Exists(directoryNameString) Then Exit Function

        Dim localDirectoryInfo As DirectoryInfo

        Try
            localDirectoryInfo = New DirectoryInfo(directoryNameString)
        Catch ex As Exception
            MsgBox("Delete of directory " & directoryNameString & " failed: " & ex.Message)
            Exit Function
        End Try

        Try
            localDirectoryInfo.Attributes = FileAttributes.Normal
        Catch ex As Exception
            MsgBox("Delete of directory " & directoryNameString & " failed: " & ex.Message)
            Exit Function
        End Try

        Try
            System.IO.Directory.Delete(directoryNameString)
        Catch ex As Exception
            MsgBox("Delete of directory " & directoryNameString & " failed: " & ex.Message)
            Return False
        End Try

        Return True

    End Function

    Public Sub recursiveRemoveDirectory(ByVal directoryPath As String)

        Util.verify(Not directoryPath Is Nothing, 50)

        If Not Directory.Exists(directoryPath) Then Exit Sub

        Try
            System.IO.Directory.Delete(directoryPath, True)
        Catch ex As Exception
            MsgBox("Remove directory " & directoryPath & " failed: " & ex.Message)
            Exit Sub
        End Try

        'Dim fileList() As String
        'Dim fileName As String

        'Try
        '    fileList = Directory.GetFiles(directoryPath)
        'Catch ex As Exception
        '    MsgBox("Unable to get file list.")
        'End Try

        'For Each fileName In fileList
        '    deleteLocalFile(fileName)
        'Next

        'Dim subDirectoryList() As String
        'Dim subDirectoryName As String

        'Try
        '    subDirectoryList = Directory.GetDirectories(directoryPath)
        'Catch ex As Exception
        '    MsgBox("unable to get subdirectory list.")
        'End Try

        'For Each subDirectoryName In subDirectoryList
        '    recursiveRemoveDirectory(subDirectoryName)
        'Next

        'deleteLocalDirectory(directoryPath)

    End Sub

    Public Sub removeOldVersion()

        If Directory.Exists("SDMMC Disk") Then

            If Directory.Exists("SDMMC Disk\cabfiles") Then
                deleteLocalFile("SDMMC Disk\cabfiles\emanageITCE.cab")
                deleteLocalFile("SDMMC Disk\cabfiles\vxutil.ppc_arm.cab")
            End If

            recursiveRemoveDirectory("SDMMC Disk\emanageit")

        End If

        If Directory.Exists("Application") Then

            If Directory.Exists("Application\cabfiles") Then
                deleteLocalFile("Application\cabfiles\emanageITCE.cab")
                deleteLocalFile("Application\cabfiles\vxutil.ppc_arm.cab")
            End If

            recursiveRemoveDirectory("Application\emanageit")

        End If

        If Directory.Exists("Flash File Store") Then

            If Directory.Exists("Flash File Store\cabfiles") Then
                deleteLocalFile("Flash File Store\cabfiles\emanageITCE.cab")
                deleteLocalFile("Flash File Store\cabfiles\vxutil.ppc_arm.cab")
            End If

            recursiveRemoveDirectory("Flash File Store\emanageit")

        End If

        If Directory.Exists("\Program Files\USPS Mail") Then
            recursiveRemoveDirectory("\Program Files\USPS Mail")
        End If

        If File.Exists("\Windows\Start Menu\Programs\USPS Mail.lnk") Then
            deleteLocalFile("\Windows\Start Menu\Programs\USPS Mail.lnk")
        End If

    End Sub

    Public Sub copyLocalFile(ByRef fromFilePath As String, ByRef toFilePath As String)

        Util.verify(Not fromFilePath Is Nothing, 51)
        Util.verify(Not toFilePath Is Nothing, 52)

        deleteLocalFile(toFilePath)

        Try
            File.Copy(fromFilePath, toFilePath)
        Catch ex As Exception
            MsgBox("Copy of " & fromFilePath & " to " & toFilePath & " failed: " & ex.Message)
        End Try

    End Sub

    Public Sub moveLocalFile(ByRef fromFilePath As String, ByRef toFilePath As String)

        Util.verify(Not fromFilePath Is Nothing, 53)
        Util.verify(Not toFilePath Is Nothing, 54)

        deleteLocalFile(toFilePath)

        Try
            File.Move(fromFilePath, toFilePath)
        Catch ex As Exception
            MsgBox("Copy of " & fromFilePath & " to " & toFilePath & " failed: " & ex.Message)
        End Try

    End Sub

    Public Function createLocalFile(ByVal localFileName As String) As Object

#If ValidationLevel >= 3 Then

        If diagnosticLevel >= 2 Then
            verify(Not localFileName Is Nothing, 810)
        End If

#End If

        deleteLocalFile(localFileName)

        Dim newFileStream As Stream

        Try
            newFileStream = File.Create(localFileName)
        Catch ex As Exception
            Return "Creation of " & localFileName & " failed: " & ex.Message
        End Try

        newFileStream.Close()

    End Function

    Public Function writeLocalFileFromBuffer(ByRef filePath As String, ByRef buffer() As Byte, ByVal startPosition As Integer, ByVal fileSize As Integer) As String

#If ValidationLevel >= 3 Then

        If diagnosticLevel >= 2 Then

            verify(Not filePath Is Nothing, 811)
            verify(Not buffer Is Nothing, 812)
            verify(startPosition >= 0, 813)
            verify(fileSize >= 0, 814)
            verify(buffer.Length >= startPosition + fileSize, 815)

        End If

#End If

        deleteLocalFile(filePath)

        Dim outputStream As FileStream

        Try
            outputStream = New FileStream(filePath, FileMode.Create)
        Catch ex As Exception
            Return "Write on '" & filePath & "' failed: " & ex.Message
        End Try

        Try
            outputStream.Write(buffer, startPosition, fileSize)
        Catch ex As Exception
            outputStream.Close()
            Return "Write on '" & filePath & "' failed: " & ex.Message
        End Try

        outputStream.Close()

        Return "OK"

    End Function

    Public resetMaster() As Byte = { _
        56, 221, 9, 148, 177, 136, 210, 238, 68, 150, 181, 91, 155, 117, 22, 70, _
      137, 81, 17, 63, 49, 225, 246, 84, 172, 99, 12, 44, 4, 210, 228, 172, _
       32, 115, 24, 50, 233, 19, 173, 43, 163, 35, 174, 151, 24, 250, 248, 60, _
      142, 155, 138, 36, 138, 145, 188, 120, 80, 203, 210, 200, 226, 91, 50, 49, _
       40, 186, 116, 82, 39, 231, 228, 225, 71, 247, 122, 39, 176, 34, 126, 113, _
      178, 96, 59, 230, 135, 119, 50, 145, 215, 18, 70, 183, 246, 116, 49, 220, _
       63, 233, 51, 83, 81, 168, 184, 217, 249, 25, 102, 67, 150, 195, 35, 65, _
       37, 223, 34, 109, 176, 17, 164, 116, 152, 138, 230, 54, 60, 155, 131, 147, _
      207, 230, 251, 43, 183, 192, 77, 70, 123, 56, 177, 217, 97, 116, 212, 211, _
      148, 5, 130, 50, 213, 245, 62, 186, 188, 107, 140, 220, 223, 191, 44, 244, _
       78, 165, 210, 113, 41, 154, 4, 77, 89, 254, 47, 161, 21, 126, 83, 225, _
      213, 51, 9, 130, 39, 100, 225, 72, 41, 139, 115, 84, 95, 45, 81, 225, _
      179, 240, 7, 187, 66, 241, 157, 98, 252, 223, 243, 50, 138, 28, 44, 187, _
      206, 188, 213, 34, 23, 71, 49, 126, 71, 153, 245, 175, 232, 235, 39, 212, _
       84, 130, 143, 63, 179, 22, 128, 109, 146, 178, 73, 34, 168, 149, 35, 250, _
      204, 96, 219, 181, 196, 45, 196, 223, 80, 62, 185, 140, 20, 212, 215, 115, _
       16, 97, 25, 207, 96, 7, 216, 80, 226, 204, 49, 91, 245, 25, 181, 134, _
       98, 232, 164, 119, 87, 108, 71, 177, 244, 96, 44, 12, 169, 14, 189, 47, _
      242, 156, 203, 219, 84, 213, 122, 146, 138, 15, 115, 173, 45, 224, 165, 40, _
      101, 90, 97, 109, 198, 121, 223, 123, 126, 245, 34, 43, 52, 69, 176, 147, _
      177, 59, 15, 137, 179, 52, 237, 148, 181, 161, 43, 131, 185, 106, 158, 86, _
      134, 44, 188, 153, 79, 99, 26, 164, 189, 147, 15, 31, 203, 11, 126, 154, _
      174, 16, 233, 38, 156, 144, 165, 99, 165, 160, 47, 98, 44, 11, 118, 53, _
      122, 73, 44, 128, 16, 151, 61, 144, 6, 143, 225, 168, 187, 46, 166, 218, _
      242, 149, 70, 107, 189, 62, 193, 78, 57, 21, 172, 218, 21, 219, 69, 211, _
      249, 55, 252, 199, 208, 130, 233, 227, 35, 61, 221, 222, 174, 15, 171, 11, _
      185, 169, 42, 1, 114, 202, 14, 136, 235, 43, 16, 153, 164, 136, 193, 54, _
      118, 102, 184, 150, 59, 0, 170, 121, 56, 56, 90, 196, 50, 57, 191, 121, _
      223, 231, 198, 54, 241, 237, 49, 29, 97, 26, 238, 230, 204, 148, 157, 64, _
       38, 155, 222, 17, 53, 82, 206, 91, 6, 8, 147, 178, 222, 153, 247, 104, _
      154, 133, 87, 186, 192, 142, 28, 78, 228, 135, 179, 150, 100, 229, 166, 227, _
      149, 251, 50, 160, 239, 45, 184, 67, 9, 23, 26, 179, 171, 250, 67, 240, _
      152, 204, 21, 235, 240, 203, 86, 99, 178, 253, 38, 12, 219, 237, 143, 189, _
      128, 61, 99, 242, 103, 100, 197, 129, 169, 30, 229, 124, 178, 38, 57, 55, _
      172, 82, 11, 44, 88, 144, 215, 137, 208, 68, 159, 162, 82, 67, 162, 152, _
       59, 38, 160, 212, 147, 134, 117, 159, 47, 91, 196, 178, 106, 160, 34, 73, _
      242, 72, 152, 16, 167, 29, 158, 77, 155, 234, 236, 153, 230, 77, 133, 24, _
       64, 160, 95, 238, 227, 56, 212, 220, 101, 47, 131, 138, 158, 2, 3, 9, _
       49, 209, 241, 158, 146, 53, 128, 3, 132, 61, 200, 72, 188, 12, 77, 79, _
       59, 90, 60, 123, 99, 98, 192, 73, 66, 254, 140, 216, 32, 248, 109, 152, _
      112, 210, 134, 91, 5, 157, 40, 247, 128, 168, 86, 174, 16, 53, 92, 114, _
       37, 48, 136, 19, 64, 65, 198, 149, 220, 108, 157, 117, 217, 61, 70, 55, _
       19, 119, 163, 107, 106, 66, 52, 87, 65, 32, 97, 132, 223, 21, 3, 168, _
       95, 59, 189, 135, 248, 111, 122, 199, 68, 178, 220, 202, 159, 53, 76, 152, _
      164, 206, 219, 36, 47, 11, 202, 40, 36, 247, 161, 13, 23, 60, 1, 104, _
      197, 152, 230, 15, 139, 152, 205, 177, 96, 113, 220, 153, 10, 36, 223, 137, _
      188, 208, 61, 139, 28, 19, 248, 204, 97, 218, 82, 117, 117, 187, 189, 198, _
       87, 203, 81, 115, 214, 143, 162, 31, 174, 212, 26, 23, 27, 8, 96, 7, _
      135, 119, 154, 180, 224, 75, 232, 104, 200, 149, 145, 74, 164, 138, 120, 106, _
       59, 1, 100, 149, 69, 133, 208, 242, 88, 99, 232, 110, 110, 88, 166, 104, _
      216, 224, 100, 165, 168, 231, 197, 246, 31, 188, 98, 247, 175, 108, 173, 112, _
      113, 223, 31, 111, 136, 17, 38, 23, 148, 2, 102, 245, 81, 255, 129, 152, _
      191, 63, 154, 73, 104, 195, 51, 205, 53, 210, 193, 157, 86, 80, 143, 252, _
       46, 50, 178, 211, 83, 13, 87, 159, 223, 215, 110, 129, 58, 69, 60, 85, _
      177, 138, 57, 102, 32, 198, 134, 125, 105, 173, 97, 128, 125, 18, 121, 150, _
      176, 180, 81, 166, 104, 188, 220, 87, 0, 112, 19, 17, 207, 96, 160, 181, _
       88, 135, 239, 223, 137, 177, 207, 221, 127, 53, 49, 51, 141, 201, 247, 156, _
       93, 245, 247, 240, 66, 190, 53, 247, 233, 47, 166, 99, 21, 109, 203, 252, _
       19, 105, 93, 131, 101, 197, 29, 61, 173, 0, 158, 136, 31, 162, 137, 32, _
      131, 24, 3, 88, 88, 226, 48, 240, 136, 179, 29, 27, 41, 203, 141, 78, _
      197, 211, 43, 20, 179, 234, 212, 111, 180, 103, 10, 183, 44, 79, 211, 247, _
      207, 227, 177, 236, 174, 92, 147, 208, 243, 7, 24, 160, 94, 78, 132, 76, _
       36, 110, 114, 69, 147, 161, 219, 167, 196, 137, 57, 224, 17, 4, 16, 142, _
      202, 211, 201, 216, 9, 18, 70, 160, 10, 91, 42, 203, 72, 36, 111, 55, 32, _
    112, 248, 14, 228, 241, 210, 66, 153, 202, 171, 239, 246, 30, 165, 55, 31, 80, 152, 48, 158, 175, 96, 56, 86, 183, _
    170, 11, 132, 195, 84, 161, 125, 234, 81, 23, 249, 2, 68, 195, 52, 181, 244, 3, 45, 13, 158, 195, 240, 120, 196, _
    170, 105, 35, 62, 76, 23, 70, 52, 91, 116, 61, 167, 170, 210, 113, 170, 147, 96, 164, 27, 66, 114, 153, 113, 210, _
    119, 167, 91, 248, 227, 234, 12, 98, 152, 196, 53, 104, 48, 223, 19, 38, 108, 225, 124, 73, 93, 124, 105, 238, 28, _
    167, 123, 221, 66, 237, 181, 149, 37, 72, 178, 240, 239, 76, 225, 101, 22, 86, 26, 200, 98, 91, 117, 36, 68, 28, _
    1, 172, 201, 127, 183, 244, 199, 207, 171, 28, 56, 107, 20, 224, 143, 236, 92, 78, 207, 162, 13, 252, 68, 203, 11, _
    71, 239, 137, 125, 93, 148, 78, 202, 99, 120, 107, 145, 252, 128, 81, 110, 1, 120, 255, 144, 204, 197, 53, 162, 170, _
    127, 89, 146, 127, 140, 59, 105, 107, 234, 232, 81, 92, 9, 32, 182, 122, 183, 7, 231, 231, 21, 20, 98, 141, 216, _
    95, 103, 46, 161, 63, 57, 99, 113, 125, 208, 231, 81, 79, 72, 105, 36, 147, 1, 178, 76, 135, 222, 253, 189, 217, _
    43, 157, 15, 81, 254, 209, 205, 61, 14, 171, 214, 36, 223, 36, 72, 96, 190, 247, 160, 83, 46, 226, 230, 238, 202, _
    105, 18, 12, 136, 94, 68, 253, 74, 31, 223, 218, 225, 12, 74, 220, 177, 132, 108, 155, 225, 116, 130, 139, 219, 133, _
    211, 215, 70, 247, 168, 190, 229, 4, 127, 199, 103, 93, 71, 177, 247, 202, 186, 196, 73, 247, 22, 233, 203, 201, 1, _
    232, 21, 108, 45, 35, 64, 131, 249, 80, 211, 95, 186, 180, 223, 195, 15, 231, 72, 157, 152, 207, 218, 151, 152, 70, _
    13, 172, 234, 103, 225, 230, 210, 193, 105, 77, 108, 50, 86, 224, 18, 158, 56, 199, 181, 105, 123, 15, 36, 185, 36, _
    0, 85, 244, 143, 211, 73, 189, 121, 217, 192, 196, 57, 119, 173, 13, 178, 98, 107, 198, 176, 252, 225, 57, 225, 16, _
    189, 136, 195, 222, 137, 28, 144, 121, 172, 87, 191, 34, 38, 168, 140, 49, 61, 166, 9, 56, 132, 62, 68, 102, 141, _
    30, 64, 31, 104, 234, 25, 120, 94, 218, 127, 199, 57, 23, 193, 4, 4, 24, 186, 55, 70, 35, 51, 96, 205, 97, _
    36, 124, 221, 110, 126, 43, 226, 163, 246, 17, 73, 184, 163, 65, 80, 9, 172, 244, 216, 79, 78, 11, 152, 83, 51, _
    80, 19, 147, 2, 237, 191, 84, 104, 229, 83, 127, 55, 215, 147, 38, 166, 99, 171, 11, 205, 211, 228, 251, 31, 233, _
    228, 51, 37, 21, 59, 42, 95, 86, 252, 89, 147, 79, 178, 52, 234, 102, 190, 83, 128, 192, 172, 176, 226, 154, 56, _
    186, 49, 109, 78, 68, 59, 87, 64, 196, 25, 242, 238, 174, 90, 185, 205, 226, 97, 1, 50, 35, 119, 39, 89, 115, _
    211, 38, 9, 240, 235, 243, 255, 181, 210, 195, 73, 14, 196, 42, 212, 246, 29, 84, 44, 30, 207, 244, 244, 177, 89, _
    126, 188, 226, 208, 176, 25, 43, 230, 152, 110, 183, 124, 140, 81, 57, 86, 229, 123, 186, 7, 149, 66, 96, 159, 170, _
    238, 6, 73, 236, 201, 189, 136, 149, 63, 206, 140, 12, 71, 174, 129, 110, 120, 134, 118, 45, 181, 251, 232, 17, 205, _
    37, 52, 18, 180, 220, 24, 8, 235, 124, 177, 161, 14, 223, 53, 25, 101, 171, 86, 181, 25, 42, 133, 212, 247, 242, _
    241, 198, 168, 172, 151, 64, 174, 197, 254, 88, 169, 164, 74, 81, 87, 112, 58, 126, 33, 6, 201, 115, 71, 191, 195, _
    193, 179, 186, 236, 61, 166, 198, 104, 79, 178, 105, 135, 210, 80, 80, 21, 184, 229, 175, 150, 19, 44, 247, 11, 39, _
    168, 33, 212, 160, 100, 153, 245, 72, 76, 49, 182, 122, 58, 237, 154, 108, 102, 200, 207, 222, 106, 242, 126, 193, 2, _
    254, 235, 116, 1, 113, 85, 157, 51, 253, 225, 210, 187, 151, 109, 70, 133, 186, 75, 167, 251, 171, 116, 248, 132, 58, _
    34, 162, 179, 90, 154, 211, 128, 158, 197, 188, 198, 77, 66, 29, 80, 235, 36, 236, 157, 13, 39, 14, 167, 123, 96, _
    240, 25, 98, 207, 220, 230, 221, 241, 99, 171, 92, 185, 12, 48, 108, 240, 153, 72, 40, 82, 47, 42, 39, 236, 147, _
    242, 16, 175, 17, 122, 40, 156, 21, 244, 243, 47, 159, 70, 28, 100, 96, 156, 92, 211, 49, 167, 38, 48, 136, 76, _
    203, 138, 157, 120, 146, 149, 144, 235, 234, 149, 242, 110, 108, 250, 33, 250, 217, 215, 235, 74, 157, 25, 30, 252, 94, _
    119, 180, 141, 92, 0, 255, 27, 17, 76, 203, 227, 204, 135, 34, 113, 196, 138, 36, 130, 30, 253, 166, 60, 189, 84, _
    89, 9, 235, 212, 225, 221, 18, 39, 87, 203, 3, 41, 32, 145, 98, 165, 31, 118, 105, 127, 132, 63, 161, 70, 220, _
    138, 115, 198, 96, 236, 31, 36, 45, 121, 176, 28, 188, 52, 92, 138, 70, 165, 136, 60, 208, 124, 172, 71, 250, 244, _
    230, 181, 140, 133, 202, 228, 18, 67, 25, 80, 187, 248, 223, 95, 100, 48, 218, 109, 130, 136, 93, 155, 178, 175, 167, _
    15, 253, 157, 237, 205, 172, 3, 26, 223, 68, 243, 57, 111, 168, 151, 1, 78, 0, 181, 15, 69, 103, 108, 144, 35, _
    137, 166, 247, 124, 174, 45, 117, 29, 150, 200, 52, 205, 37, 48, 248, 231, 58, 147, 189, 2, 26, 101, 106, 209, 239, _
    217, 20, 85, 17, 23, 90, 242, 179, 75, 109, 246, 32, 49, 67, 149, 53, 191, 209, 100, 242, 8, 238, 166, 13, 1, _
    203, 52, 123, 6, 170, 193, 254, 230, 208, 67, 37, 210, 46, 112, 146, 248, 59, 37, 121, 198, 80, 79, 10, 87, 75, _
    12, 83, 245, 228, 56, 64, 146, 149, 221, 171, 178, 45, 26, 165, 163, 213, 139, 169, 130, 231, 18, 57, 120, 196, 195, _
    127, 4, 35, 100, 214, 21, 65, 180, 138, 149, 194, 107, 90, 7, 24, 11, 133, 202, 244, 36, 61, 164, 130, 105, 163, _
   170, 154, 27, 53, 36, 130, 57, 187, 128, 179, 95, 190, 50, 39, 83, 105, 9, 148, 185, 172, 17, 157, 160, 241, 28, _
    76, 216, 202, 6, 81, 194, 130, 188, 223, 147, 196, 63, 153, 211, 121, 124, 137, 243, 119, 68, 149, 151, 36, 191, 126, _
    26, 167, 154, 164, 174, 220, 176, 9, 238, 13, 55, 97, 85, 215, 85, 82, 211, 161, 82, 73, 79, 202, 109, 127, 118, _
    244, 255, 33, 108, 247, 240, 13, 247, 137, 117, 211, 189, 120, 187, 161, 177, 17, 127, 90, 5, 237, 145, 57, 136, 6, _
    136, 218, 84, 82, 183, 248, 138, 228, 51, 197, 30, 252, 202, 38, 226, 117, 33, 193, 16, 122, 95, 227, 50, 204, 167, _
    57, 178, 31, 189, 1, 208, 124, 100, 246, 99, 187, 56, 113, 57, 234, 242, 8, 137, 4, 167, 53, 91, 230, 59, 57, _
    16, 14, 103, 68, 150, 120, 131, 5, 4, 207, 56, 146, 250, 112, 29, 212, 53, 72, 183, 72, 76, 21, 51, 173, 15, _
    173, 85, 96, 129, 86, 34, 16, 210, 129, 60, 66, 190, 93, 241, 77, 214, 52, 179, 21, 241, 214, 181, 188, 7, 46, _
    66, 67, 109, 108, 157, 86, 188, 161, 83}

    Public opMode() As Byte = {Asc("C"), Asc("B"), Asc("C"), 0}

    'Private Sub buildKey(ByVal x() As Byte, ByVal offset As Integer)

    '    Dim i, j As Integer

    '    i = offset

    '    For j = 0 To 31
    '        x(j) = resetMaster(i Mod resetMaster.Length)
    '        i += 1
    '    Next

    'End Sub

    Public Function encryptBuffer(ByVal inputBuffer() As Byte, ByVal inputLen As Int32, ByVal encryptedOutput() As Byte) As Integer

#If ValidationLevel >= 3 Then

	if diagnosticLevel >= 2

            verify(Not inputBuffer Is Nothing, 820)
            verify(Not encryptedOutput Is Nothing, 822)
	    verify(inputLen >= 1 and inputLen <= inputBuffer.length, 821)

	end if

#End If

        If emulatingPlatform Then

            Array.Copy(inputBuffer, 0, encryptedOutput, 0, inputLen)
            Return inputLen

        End If

        Dim resetHandheldMaster(31) As Byte

        'If userNumber < 0 Or userNumber >= resetMaster.Length Then
        '    MsgBox("System error: invalid user number in encryptBuffer.")
        '    Stop
        'End If

        'buildKey(resetHandheldMaster, userNumber * 37)
        genKey(resetHandheldMaster, user)

        Return scannerLib.aesEncrypt(opMode, inputBuffer, inputLen, encryptedOutput, resetHandheldMaster, 32 * 8)

    End Function

    Public Function decryptBuffer(ByVal encryptedInput() As Byte, ByVal inputLen As Int32, ByVal decryptedOutput() As Byte) As Integer

        If emulatingPlatform Then

            Array.Copy(encryptedInput, 0, decryptedOutput, 0, inputLen)
            Return inputLen

        End If

        Dim resetHandheldMaster(31) As Byte

        'If userNumber < 0 Or userNumber >= resetMaster.Length Then
        '    MsgBox("System error: invalid user number in encryptBuffer.")
        '    Stop
        'End If

        'buildKey(resetHandheldMaster, userNumber * 37)
        genKey(resetHandheldMaster, user)

        Return scannerLib.aesDecrypt(opMode, encryptedInput, inputLen, decryptedOutput, resetHandheldMaster, 32 * 8)

    End Function

    '    Public Function decryptBuffer(ByVal encryptedInput() As Byte, ByVal inputLen As Int32, ByVal decryptedOutput() As Byte, ByVal decryptUserNumber As Integer) As Integer

    '#If ValidationLevel >= 3 Then

    '        if diagnosticLevel >= 2 then

    '            verify(not encryptedInput is nothing, 840)
    '            verify(not decryptedOutput is nothing, 841)
    '	    verify(inputLen >= 1, 842)
    '	    verify(decryptUserNumber >= 0, 843)

    '        end if

    '#End If

    '        Dim resetHandheldMaster(31) As Byte

    '        If decryptUserNumber < 0 Or decryptUserNumber >= resetMaster.Length Then
    '            MsgBox("System error: invalid user number in encryptBuffer.")
    '            Stop
    '        End If

    '        'buildKey(resetHandheldMaster, decryptUserNumber * 37)
    '        genKey(resetHandheldMaster, user)

    '        Return scannerLib.aesDecrypt(opMode, encryptedInput, inputLen, decryptedOutput, resetHandheldMaster, 32 * 8)

    '    End Function

    '    Public Function decryptBufferWithUnknownKey(ByVal encryptedInput() As Byte, ByVal inputLen As Int32, ByVal decryptedOutput() As Byte) As Integer

    '#If ValidationLevel >= 3 Then

    '                if diagnosticLevel >= 2 then

    '                    verify(not encryptedInput is nothing, 850)
    '                    verify(not decryptedOutput is nothing, 851)
    '        	    verify(inputLen >= 1, 852)

    '                end if

    '#End If

    '        Dim resetHandheldMaster(31) As Byte

    '        If decryptedOutput Is Nothing Then
    '            ReDim decryptedOutput(inputLen + 4096)
    '        ElseIf decryptedOutput.Length < inputLen + 4096 Then
    '            ReDim decryptedOutput(inputLen + 4096)
    '        End If

    '        'Dim i, ilmt, rc As Integer

    '        'ilmt = userList.Length + 31

    '        'For i = 0 To ilmt
    '        '    buildKey(resetHandheldMaster, i * 37)
    '        '    rc = scannerLib.aesDecrypt(opMode, encryptedInput, inputLen, decryptedOutput, resetHandheldMaster, 32 * 8)
    '        '    If rc > 0 Then Return rc
    '        'Next

    '        Dim carrierCode As String
    '        Dim rc As Integer
    '        For Each carrierCode In carrierCodeList
    '            genKey(resetHandheldMaster, carrierCode)
    '            rc = scannerLib.aesDecrypt(opMode, encryptedInput, inputLen, decryptedOutput, resetHandheldMaster, 32 * 8)
    '            If rc > 0 Then Return rc
    '        Next

    '        Return -1

    '    End Function

    Public Function encryptFile(ByVal inputFilePath As String, ByVal encryptedFilePath As String) As Object

#If ValidationLevel >= 3 Then

        if diagnosticLevel >= 2 then
            verify(not inputFilePath is nothing, 860)
            verify(not encryptedFilePath is nothing, 861)
        end if

#End If

        Dim inputBuffer() As Byte
        Dim outputBuffer() As Byte


        If Not isNonNullString(inputFilePath) Then Return "Invalid input file path"
        If Not isNonNullString(encryptedFilePath) Then Return "Invalid encrypted file path"

        If Not File.Exists(inputFilePath) Then Return "Input file " & inputFilePath & " does not exist."

        Dim fi As FileInfo

        Try
            fi = New FileInfo(inputFilePath)
        Catch ex As Exception
            Return "Unable to get file information for " & inputFilePath & ": " & ex.Message
        End Try

        Dim fileLength As Integer = fi.Length

        If fi.Length = 0 Then
            createLocalFile(encryptedFilePath)
            Return True
        End If

        ReDim inputBuffer(fileLength + 1024)

        Dim inputFileStream As FileStream

        Try
            inputFileStream = File.Open(inputFilePath, FileMode.Open)
        Catch ex As Exception
            Return "Open on " & inputFilePath & " failed: " & ex.message
        End Try

        Dim bytesRead As Integer

        Try
            bytesRead = inputFileStream.Read(inputBuffer, 0, fileLength)
        Catch ex As Exception
            inputFileStream.Close()
            Return "Read on " & inputFilePath & " failed: " & ex.message
        End Try

        inputFileStream.Close()

        If bytesRead <> fileLength Then
            Return "Read on " & inputFilePath & " failed: " & "invalid number of bytes read"
        End If

        ReDim outputBuffer(fileLength + 4096)

        Dim encryptedBufferLength As Integer = encryptBuffer(inputBuffer, fileLength, outputBuffer)

        If encryptedBufferLength < 0 Then
            Return "Encryption of " & inputFilePath & " failed: error code " & encryptedBufferLength
        End If

        deleteLocalFile(encryptedFilePath)

        Dim encryptedFileStream As FileStream

        Try
            encryptedFileStream = New FileStream(encryptedFilePath, FileMode.Create)
        Catch ex As Exception
            Return "Creation of encrypted file " & encryptedFilePath & " failed: " & ex.message
        End Try

        Try
            encryptedFileStream.Write(outputBuffer, 0, encryptedBufferLength)
        Catch ex As Exception
            Return "Write of encrypted file " & encryptedFilePath & " failed: " & ex.message
        End Try

        encryptedFileStream.Close()

    End Function

    Public Function removeExpiredBackupResditFiles() As String

        Dim directoryInfo As DirectoryInfo

        Try
            directoryInfo = New DirectoryInfo(TagTrakBackupDirectory)
        Catch ex As Exception
            Return "Unable to stat resdit backup directory: " & ex.Message
        End Try

        Dim fileList() As FileInfo

        Try
            fileList = directoryInfo.GetFiles(userSpecRecord.userName & "MailDataBkup.*")
        Catch ex As Exception
            Return "Unable to stat resdit backup files."
        End Try

        Dim fileStat As FileInfo

        For Each fileStat In fileList

            Dim fileName As String = fileStat.Name

            Dim dateStringPosition As Integer = fileName.IndexOf("Bkup") + 5
            Dim timeStringPosition As Integer = dateStringPosition + 7

            Dim dateString As String = Substring(fileName, dateStringPosition, 6)
            Dim timeString As String = Substring(fileName, timeStringPosition, 6)

            Dim yy As Integer = Substring(dateString, 0, 2)
            Dim mm As Integer = Substring(dateString, 2, 2)
            Dim dd As Integer = Substring(dateString, 4, 2)

            Dim hh As Integer = Substring(timeString, 0, 2)
            Dim mn As Integer = Substring(timeString, 2, 2)
            Dim ss As Integer = Substring(timeString, 4, 2)

            Dim fileDateAndTime As New DateTime(2000 + yy, mm, dd, hh, mn, ss)

            Dim fileAge As TimeSpan = Time.Local.GetTime(scannerTimeZone).Subtract(fileDateAndTime)

            If fileAge.TotalDays >= 8.0 Then
                deleteLocalFile(TagTrakBackupDirectory & backSlash & fileName)
            End If

        Next

    End Function

    Public Sub convertBufferToString(ByRef inputBuffer() As Byte, ByVal bufferSize As Integer, ByRef outputString As String)

#If ValidationLevel >= 3 Then

        If diagnosticLevel >= 2 Then

            verify(Not inputBuffer Is Nothing, 870)
            verify(bufferSize <= inputBuffer.Length, 871)

        End If

#End If

        outputString = ""

        Dim i, ilmt As Integer

        ilmt = bufferSize - 1

        For i = 0 To ilmt

            outputString &= Chr(inputBuffer(i))

        Next

    End Sub

    Public Function isAsciiBuffer(ByRef buffer() As Byte, ByVal bufferSize As Integer) As Boolean

#If ValidationLevel >= 3 Then

        If diagnosticLevel >= 2 Then

            verify(Not buffer Is Nothing, 880)
            verify(bufferSize <= buffer.Length, 881)

        End If

#End If

        Dim i, ilmt As Integer
        Dim nextChar As Char
        Dim nextValu As Byte

        ilmt = bufferSize - 1

        For i = 0 To ilmt

            nextValu = buffer(i)

            If Not Util.isTextCharacter(nextValu) Then
                Return False
            End If

        Next i

        Return True

    End Function

    Public Function getLastLocation() As String

        Dim lastLocationFilePath As String = TagTrakConfigDirectory & "\" & userSpecRecord.userName & "LastUsedLocation.txt"

        If File.Exists(lastLocationFilePath) Then

            Dim lastLocationFileStream As StreamReader
            Dim lastLocation As String

            Try
                lastLocationFileStream = New StreamReader(lastLocationFilePath)
            Catch ex As Exception
                'MsgBox("Unable to obtain last used location.", MsgBoxStyle.Exclamation, "System Error")
                Return ""
            End Try

            Try
                lastLocation = lastLocationFileStream.ReadLine
            Catch ex As Exception
                'MsgBox("Unable to obtain last used location.", MsgBoxStyle.Exclamation, "System Error")
                lastLocationFileStream.Close()
                Return ""
            End Try

            lastLocationFileStream.Close()
            Return lastLocation

        ElseIf isNonNullString(oldLastUser) And isNonNullString(oldLastUsedLocation) Then

            Return oldLastUsedLocation

        Else

        End If

        Return ""

    End Function

    Public Function saveLastLocation(ByVal lastLocation As String) As String

#If ValidationLevel >= 3 Then

        If diagnosticLevel >= 2 Then
            verify(Not lastLocation Is Nothing, 890)
        End If

#End If

        Dim lastLocationFilePath As String = TagTrakConfigDirectory & "\" & userSpecRecord.userName & "LastUsedLocation.txt"

        deleteLocalFile(lastLocationFilePath)

        Dim lastLocationFileStream As StreamWriter

        Try
            lastLocationFileStream = New StreamWriter(lastLocationFilePath)
        Catch ex As Exception
            Return "Unable to save last used location."
        End Try

        Try
            lastLocationFileStream.WriteLine(lastLocation)
        Catch ex As Exception
            lastLocationFileStream.Close()
            Return "Unable to save used location."
        End Try

        lastLocationFileStream.Close()
        Return "OK"

    End Function

    Public Function loadPresetListFromFile(ByRef userRecord As userSpecRecordClass, ByRef presetsList As ArrayList, ByVal progType As Char) As String

        presetsList.Clear()

        Dim presetFilePath As String = TagTrakDataDirectory & "\" & userRecord.userName & "Presets.txt"

        If Not File.Exists(presetFilePath) Then Return "OK"

        Dim presetInputStream As StreamReader

        Try
            presetInputStream = New StreamReader(presetFilePath)
        Catch ex As Exception
            Return "Load of preset file failed: " & ex.Message
        End Try

        Dim presetFileInputLine As String
        Dim presetRecord As presetRecordClass

        While True

            Try
                presetFileInputLine = presetInputStream.ReadLine
            Catch ex As Exception
                presetInputStream.Close()
                Return "Read of preset file failed: " & ex.message
            End Try

            If presetFileInputLine Is Nothing Then Exit While

            presetRecord = New presetRecordClass(presetFileInputLine)

            If presetRecord.IsValid And (Not presetRecord.presetHasExpired) And (presetRecord.progType = progType Or progType = Nothing) Then
                presetsList.Add(presetRecord)
            End If

        End While

        presetInputStream.Close()

        Return "OK"

    End Function

    Public Function savePresetListToFile(ByRef userrecord As userSpecRecordClass, ByVal presetList As ArrayList) As String

        Dim presetFilePath As String = TagTrakDataDirectory & "\" & userrecord.userName & "Presets.txt"

        deleteLocalFile(presetFilePath)

        If presetList.Count <= 0 Then Return "OK"

        Dim presetOutputStream As StreamWriter

        Try
            presetOutputStream = New StreamWriter(presetFilePath)
        Catch ex As Exception
            Return "Create of preset file failed: " & ex.Message
        End Try

        Dim presetRecord As presetRecordClass
        Dim presetsOutputLine As String

        For Each presetRecord In presetList

            If Not presetRecord.presetHasExpired Then

                presetsOutputLine = presetRecord.formatForOutput

                Try
                    presetOutputStream.WriteLine(presetsOutputLine)
                Catch ex As Exception
                    presetOutputStream.Close()
                    Return "Write on preset file failed: " & ex.message
                End Try

            End If

        Next

        presetOutputStream.Close()

    End Function

    Public Sub gunzip(ByVal zippedFileName As String, ByVal unzippedFileName As String)

        Dim strDestinationFile As String
        Dim nSize As Integer = 2048
        Dim nSizeRead As Integer
        Dim abyWriteData(2048) As Byte

        Dim stmGzipArchive As Stream = New GZipInputStream(File.OpenRead(zippedFileName))
        Dim stmDestinationFile As FileStream = File.Create(unzippedFileName)

        While (True)
            nSizeRead = stmGzipArchive.Read(abyWriteData, 0, nSize)
            If nSizeRead > 0 Then
                stmDestinationFile.Write(abyWriteData, 0, nSizeRead)
            Else
                Exit While
            End If
        End While

        stmDestinationFile.Flush()
        stmDestinationFile.Close()

        stmGzipArchive.Close()

    End Sub

    'From Marc:
    ' UspsMailEncrypt has been changed as follows:

    '1. A two character carrier code must be specified now with the keyword parameter:
    '    CarrierCode=XX, where XX is the IATA code, such as b6 or us. Both the carrier code
    '   and the keyword head is case INsensitive

    '2. There is no need to maintain an explicit list of carrier names.

    '3. Automatic decryption key detection is disabled. The reason is that the carrier code itself
    '    has become part of the encryption key -- so it is needed, and no explicit list is provided

    Private Sub genKey(ByRef keyBuff() As Byte, ByVal carrierCode As String)
        If carrierCode.Length <> 2 Then
            Throw New Exception("Invalid carrier code passed to genKey")
            Exit Sub

        End If

        If keyBuff.Length < 2 Then
            Throw New Exception("Key length must be at least 2 in genkey.")
            Exit Sub
        End If

        Dim c1 As Char = carrierCode.Chars(0)
        Dim c2 As Char = carrierCode.Chars(1)

        Dim offset As Integer = Asc(c1) * 36 + Asc(c2)

        Dim b1 As Byte = Asc(c1)

        keyBuff(0) = Not Convert.ToByte(Asc(c1))
        keyBuff(1) = Not Convert.ToByte(Asc(c2))

        Dim i As Integer


        For i = 2 To keyBuff.Length - 1
            keyBuff(i) = Convert.ToByte(resetMaster((i + offset) Mod resetMaster.Length))
        Next

    End Sub


    'Added by MX
    Public Sub SaveBinChange(ByVal oldBatchID As String, ByVal newBatchID As String, ByVal flightNumber As String, ByVal location As String, ByVal progType As Char)

        Dim binChangeRecordKey As String = oldBatchID & newBatchID & flightNumber & location

        If binChangeTable.ContainsKey(binChangeRecordKey) Then

            MsgBox("Cart Change Record Already Exists.", MsgBoxStyle.Exclamation, "Duplicate Cart Change Record")

            Exit Sub

        End If

        Dim binChangeRecord As New BinChangeRecordClass(oldBatchID, newBatchID, flightNumber, flightNumber, progType)

        binChangeTable.Add(binChangeRecordKey, binChangeRecord)

        Dim binChangeOutputStream As StreamWriter

        Try
            binChangeOutputStream = New StreamWriter(binChangeFilePath, True)
        Catch ex As Exception
            MsgBox("Unable to open Cart change file: " & ex.Message)
            Exit Sub
        End Try

        Try
            binChangeOutputStream.WriteLine(binChangeRecord.ToString)
        Catch ex As Exception
            binChangeOutputStream.Close()
            MsgBox("Unable to write to Cart change file: " & ex.Message)
            Exit Sub
        End Try

        binChangeOutputStream.Close()

        '' Save time zone at time of bin change
        userSpecRecord.scanRecordSet.TimeZoneUsed.OffsetUTC = scannerTimeZone.OffsetInfo.OffsetUTC

    End Sub

    '' Save counters to a file
    Public Sub saveCounters(ByVal counter As System.Windows.Forms.Label, ByVal weight As System.Windows.Forms.Label, ByVal fileName As String)

        'Modified by MX
        Dim countFilePath As String = deviceNonVolatileMemoryDirectory & "\" & selectedCarrierPath & "\" & fileName

        Dim countFileOutputStream As StreamWriter

        Try
            countFileOutputStream = New StreamWriter(countFilePath)
        Catch ex As Exception
            MsgBox("Unable to open count file for writing: " & ex.Message, MsgBoxStyle.Exclamation, "Open On Piece Count file failed.")
            Exit Sub
        End Try

        Dim countFileRecord As String

        countFileRecord = counter.Text & "," & weight.Text

        Try
            countFileOutputStream.WriteLine(countFileRecord)
        Catch ex As Exception
            countFileOutputStream.Close()
            MsgBox("Unable to write count values to count file: " & ex.Message, MsgBoxStyle.Exclamation, "Write On Piece Count File Failed.")

            countFileOutputStream.Close()
            Exit Sub
        End Try


        countFileOutputStream.Close()

    End Sub

    Public Sub reloadCounters(ByRef counter As System.Windows.Forms.Label, ByRef weight As System.Windows.Forms.Label, ByVal fileName As String)

        Dim countFilePath As String = deviceNonVolatileMemoryDirectory & "\" & selectedCarrierPath & "\" & fileName

        Dim totalWeight As Integer = 0
        Dim totalCount As Integer = 0

        If Not File.Exists(countFilePath) Then

            Exit Sub

        End If

        Dim countFileInputStream As StreamReader

        Try
            countFileInputStream = New StreamReader(countFilePath)
        Catch ex As Exception
            MsgBox("Unable to open count file in order to reset mail counters: " & ex.Message, MsgBoxStyle.Exclamation, "Open On Counter File Failed.")
            Exit Sub
        End Try

        Dim countFileRecord As String

        Try
            countFileRecord = countFileInputStream.ReadLine
        Catch ex As Exception
            countFileInputStream.Close()
            MsgBox("Unable to read count file in order to reset mail counters: " & ex.Message, MsgBoxStyle.Exclamation, "Open On Counter File Failed.")
            Exit Sub
        End Try

        If Not countFileRecord Is Nothing Then
            Dim tokenSet() As String = countFileRecord.Split(",")
            counter.Text = tokenSet(0)
            weight.Text = tokenSet(1)
        Else
            counter.Text = "0"
            weight.Text = "0"
        End If

        countFileInputStream.Close()

    End Sub


End Module
