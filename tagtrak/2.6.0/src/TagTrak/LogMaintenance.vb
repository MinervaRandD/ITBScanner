Imports System
Imports System.io
Imports System.collections

Public Class myReverserClass
    Implements IComparer

    ' Calls CaseInsensitiveComparer.Compare with the parameters reversed.
    Function Compare(ByVal x As [Object], ByVal y As [Object]) As Integer _
       Implements IComparer.Compare

        Return -String.Compare(x, y)

        'Return New CaseInsensitiveComparer().Compare(y, x)
    End Function 'IComparer.Compare

End Class 'myReverserClass


Module LogMaintenance

    Public logRecordSize As Integer = 128
    Public logFileTotalRecordCount As Integer = 2048

    Public logFilePath As String = ""
    Public logIndexPath As String = ""

    Public logFileIndex As Integer = 0

    Public logStack() As String
    Public logStackTop As Integer = -1

    Public logFileAccessSemiphore As New Object
    Public logStackAccessSemiphore As New Object

    Public logOperationChanged As String = Util.createFixedWidthField("OperationChanged", 16, " "c)
    Public logLocationChanged As String = Util.createFixedWidthField("LocationChanged", 16, " "c)
    Public logCradleStatusChanged As String = Util.createFixedWidthField("CradleStatusChng", 16, " "c)
    Public logScanStateChanged As String = Util.createFixedWidthField("ScanStateChanged", 16, " "c)
    Public logDataScanned As String = Util.createFixedWidthField("DataScanned", 16, " "c)
    Public logPresetChanged As String = Util.createFixedWidthField("Preset", 16, " "c)
    Public logReaderFormChanged As String = Util.createFixedWidthField("ReaderTabChanged", 16, " "c)
    Public logScanSequence As String = Util.createFixedWidthField("ScanSequence", 16, " "c)
    Public logScan As String = Util.createFixedWidthField("Scan", 16, " "c)
    Public logUploadEvent As String = Util.createFixedWidthField("UploadButton", 16, " "c)
    Public logException As String = Util.createFixedWidthField("Exception Event", 16, " "c)

    Public logOperationLastState As String = ""
    Public logLocationLastState As String = ""
    Public logDisplayScreenLastState As String = ""
    Public logReaderFormLastTabPage As String = ""

    Private Function logSaveLogFileIndex() As String

        Dim outputString As String = CStr(logFileIndex)

        outputString = outputString.PadRight(12)

        Dim logIndexFileStream As FileStream

        Dim i As Integer

        If Not File.Exists(logIndexPath) Then

            Try
                logIndexFileStream = New FileStream(logIndexPath, FileMode.CreateNew)
            Catch ex As Exception
                Return "Create of new log index file failed: " & ex.Message
            End Try

        Else

            Dim logIndexFileInfo As FileInfo

            Try
                logIndexFileInfo = New FileInfo(logIndexPath)
            Catch ex As Exception
                Return "Stat on log index file failed: " & ex.message
            End Try

            Try
                logIndexFileInfo.Attributes = FileAttributes.Normal
            Catch ex As Exception
                Return "Attribute change of log index file failed: " & ex.message
            End Try

            Try
                logIndexFileStream = New FileStream(logIndexPath, FileMode.Truncate)
            Catch ex As Exception
                Return "Open of log index file failed: " & ex.Message
            End Try

        End If

        For i = 0 To 11
            Try
                logIndexFileStream.WriteByte(Asc(outputString.Chars(i)))
            Catch ex As Exception
                logIndexFileStream.Close()
                Return "Write to logfile failed: " & ex.message
            End Try
        Next

        logIndexFileStream.Close()

        Return "OK"

    End Function

    Function logGetLogFileIndex() As String

        If Not File.Exists(logIndexPath) Then Return "File Does Not Exist"

        Dim logIndexInputStream As StreamReader

        Try
            logIndexInputStream = New StreamReader(logIndexPath)
        Catch ex As Exception
            Return "Open of log index file failed: " & ex.Message
        End Try

        Dim inputLine As String

        Try
            inputLine = logIndexInputStream.ReadLine()
        Catch ex As Exception
            logIndexInputStream.Close()
            Return "Read on log index file failed: " & ex.message
        End Try

        logIndexInputStream.Close()

        If inputLine Is Nothing Then Return "Log File Index File is empty"

        inputLine = Trim(inputLine)

        If Not Util.IsInteger(inputLine) Then Return "Log Index File contains an invalid value"

        logFileIndex = CInt(inputLine)

        If logFileIndex < 0 Or logFileIndex >= logFileTotalRecordCount Then
            logFileIndex = -1
        End If

        Return "OK"

    End Function

    Public Function logCreateNewLogFile() As String

        If diagnosticLevel < 1 Then Exit Function

        Dim logFileStream As FileStream

        deleteLocalFile(logFilePath)

        Try
            logFileStream = File.Create(logFilePath)
        Catch ex As Exception
            Return "Unable to create log file: " & ex.Message
        End Try

        Dim outputRecord(logRecordSize) As Byte

        Dim i, ilmt As Integer

        ilmt = logRecordSize - 1

        For i = 0 To ilmt
            outputRecord(i) = Asc(" "c)
        Next

        For i = 1 To logFileTotalRecordCount

            Try
                logFileStream.Write(outputRecord, 0, logRecordSize)
            Catch ex As Exception
                Return "Unable to write to log file: " & ex.Message
            End Try

        Next

        logFileStream.Close()

        Return "OK"

    End Function

    Public Function logSetupLoggingFunction() As String

        Dim result As String

        logFileIndex = -1

        If File.Exists(logIndexPath) Then
            logGetLogFileIndex()
        End If

        If logFileIndex < 0 Or Not File.Exists(logFilePath) Then

            result = logCreateNewLogFile()

            If result <> "OK" Then Return result

            logFileIndex = 0

            result = logSaveLogFileIndex()

            Return result

        End If

        Dim logFileInfo As FileInfo

        Try
            logFileInfo = New FileInfo(logFilePath)
        Catch ex As Exception
            Return "Stat on log file failed: " & ex.Message
        End Try

        Dim logFileSize As Integer = logFileInfo.Length

        If logFileSize <> logRecordSize * logFileTotalRecordCount Then

            result = logCreateNewLogFile()

            If result <> "OK" Then Return result

            logFileIndex = 0

            result = logSaveLogFileIndex()

            Return result

        End If

        Return "OK"

    End Function

    Public Function logSetupLogging() As String

        If diagnosticLevel < 1 Then Exit Function

        Dim result As String

        logFilePath = deviceNonVolatileMemoryDirectory & "\" & selectedCarrierPath & "\ScannerLog.txt"
        logIndexPath = deviceNonVolatileMemoryDirectory & "\" & selectedCarrierPath & "\LogIndex.txt"

        SyncLock logStackAccessSemiphore

            ReDim logStack(logFileTotalRecordCount)

            Dim i, ilmt As Integer

            ilmt = logFileTotalRecordCount - 1

            For i = 0 To ilmt
                logStack(i) = Nothing
            Next

            logStackTop = -1

        End SyncLock

        SyncLock logFileAccessSemiphore
            result = logSetupLoggingFunction()
        End SyncLock

        If result <> "OK" Then Return result

        logMaintenanceThread = New System.threading.Thread(AddressOf logMaintenanceThreadSub)

        logMaintenanceThread.Priority = Threading.ThreadPriority.Lowest

        loggingIsActive = True

        logMaintenanceThread.Start()

        Return "OK"

    End Function

    Public Function logClearLogFile() As String

        If diagnosticLevel < 1 Then Exit Function

        Dim result As String

        SyncLock logStackAccessSemiphore

            Dim i, ilmt As Integer

            ilmt = logFileTotalRecordCount - 1

            For i = 0 To ilmt
                logStack(i) = Nothing
            Next

            logStackTop = -1

        End SyncLock

        SyncLock logFileAccessSemiphore

            result = logCreateNewLogFile()

            If result = "OK" Then

                logFileIndex = 0

                result = logSaveLogFileIndex()

            End If

        End SyncLock

        Return result

    End Function

    Dim logSequenceNumber As Integer = 0

    Public Function logEvent(ByVal locCode As Integer, ByVal eventDescription As String) As String

        If diagnosticLevel < 1 Then Exit Function

#If ValidationLevel >= 3 Then

        If diagnosticLevel >= 2 Then
            verify(Not eventDescription Is Nothing, 50000)
        End If

#End If

        Dim logString As String

        Dim currentDateAndTime As DateTime = Time.Local.GetTime(scannerTimeZone)
        'Dim currentDateAndTimeMilliseconds = currentDateAndTime.Millisecond

        Dim currentDateAndTimeTicks As Long = currentDateAndTime.Ticks
        Dim currentDateAndTimeMilliseconds As Long = currentDateAndTimeTicks Mod TimeSpan.TicksPerSecond

        Dim locCodeString As String = CStr(locCode)

        locCodeString = locCodeString.PadLeft(6)

        SyncLock logStackAccessSemiphore

            logString = String.Format("{0:yy-MM-dd HH:mm:ss}.{1:000} [{2:000000}] ", currentDateAndTime, currentDateAndTimeMilliseconds, logSequenceNumber) & locCodeString & ": "

            logString &= eventDescription

            logSequenceNumber = (logSequenceNumber + 1) Mod 1000000

            logStackTop = (logStackTop + 1) Mod logFileTotalRecordCount
            logStack(logStackTop) = logString

        End SyncLock

    End Function

    Private Function writeLogFileRecord(ByVal outputFileStream As StreamWriter, ByVal logFileRecord As String) As String

        Try
            outputFileStream.WriteLine(logFileRecord)
        Catch ex As Exception
            Return "Write on log file failed: " & ex.Message
        End Try

        Return "OK"

    End Function

    Public Function logBuildLogRecordArray(ByRef logFileRecordArray() As String) As String

        Dim logFileStream As FileStream

        Try
            logFileStream = New FileStream(logFilePath, FileMode.Open)
        Catch ex As Exception
            Return "Unable to open log file: " & ex.Message
        End Try

        Dim tempArray As New ArrayList

        Dim i, ilmt As Integer
        Dim j, jlmt As Integer

        Dim inputBuffer(logRecordSize) As Byte
        Dim charBuffer() As Char

        ilmt = logFileTotalRecordCount - 1

        Dim inputString As String

        For i = 0 To ilmt

            Try
                logFileStream.Read(inputBuffer, 0, logRecordSize)
            Catch ex As Exception
                logFileStream.Close()
                Return "read on log file failed: " & ex.message
            End Try

            If inputBuffer(0) = Asc(" "c) Then Exit For

            Dim inputStringLength As Integer = Util.getTrimmedBufferLength(inputBuffer, logRecordSize)

            If inputStringLength > 0 Then

                jlmt = inputStringLength - 1

                ReDim charBuffer(jlmt)

                For j = 0 To jlmt
                    charBuffer(j) = Chr(inputBuffer(j))
                Next

                inputString = Trim(charBuffer)

                tempArray.Add(inputString)

            End If
        Next

        If tempArray.Count <= 0 Then
            logFileRecordArray = Nothing
            logFileStream.Close()
            Return "OK"
        End If

        Dim myComparer = New myReverserClass

        tempArray.Sort(myComparer)

        ilmt = tempArray.Count - 1

        ReDim logFileRecordArray(ilmt)

        Dim y As String

        For i = 0 To ilmt
            logFileRecordArray(i) = Trim(tempArray(i))
            y = logFileRecordArray(i)
        Next

        logFileStream.Close()

        Return "OK"

    End Function

    Public Function logCreateLogFileSummary(ByVal tempLogFilePath As String) As String

        If diagnosticLevel < 1 Then Exit Function

        deleteLocalFile(tempLogFilePath)

        Dim outputFileStream As StreamWriter

        Try
            outputFileStream = New StreamWriter(tempLogFilePath)
        Catch ex As Exception
            Return "Create on output temporary log file failed: " & ex.Message
        End Try

        Dim result As String

        result = writeLogFileRecord(outputFileStream, "*** Log File ***")

        If result <> "OK" Then
            outputFileStream.Close()
            Return result
        End If

        result = writeLogFileRecord(outputFileStream, "User: " & user)

        If result <> "OK" Then
            outputFileStream.Close()
            Return result
        End If

        result = writeLogFileRecord(outputFileStream, "Location: " & Substring(scanLocation.currentLocation, 0, 3))

        If result <> "OK" Then
            outputFileStream.Close()
            Return result
        End If

        result = writeLogFileRecord(outputFileStream, "Time Stamp (Local Device): " & Time.Local.GetTime(scannerTimeZone).ToString)

        If result <> "OK" Then
            outputFileStream.Close()
            Return result
        End If

        result = writeLogFileRecord(outputFileStream, "Device Serial Number: " & deviceSerialNumber)

        If result <> "OK" Then
            outputFileStream.Close()
            Return result
        End If

        result = writeLogFileRecord(outputFileStream, "")

        If result <> "OK" Then
            outputFileStream.Close()
            Return result
        End If

        Dim recordSet() As String

        SyncLock logFileAccessSemiphore
            result = logBuildLogRecordArray(recordSet)
        End SyncLock

        If result <> "OK" Then
            outputFileStream.Close()
            Return result
        End If

        Dim outputRecord As String

        If recordSet Is Nothing Then

            result = writeLogFileRecord(outputFileStream, "*** Log File Is Empty ***")

            If result <> "OK" Then
                outputFileStream.Close()
                Return result
            End If

        Else

            For Each outputRecord In recordSet

                result = writeLogFileRecord(outputFileStream, outputRecord)

                If result <> "OK" Then
                    outputFileStream.Close()
                    Return result
                End If

            Next
        End If

        outputFileStream.Close()

        Return "OK"

    End Function

    Public Sub logOperationChange(ByVal locCode As Integer)

        If diagnosticLevel < 2 Then Exit Sub

        Dim logOperationCurrentState As String = Trim(MailScanFormRepository.MailScanDomsForm.operationComboBox.Text)

        If Not isNonNullString(logOperationCurrentState) Then
            logOperationCurrentState = ""
        End If

        If logOperationCurrentState = logOperationLastState Then Exit Sub

        logOperationLastState = logOperationCurrentState

        logEvent(locCode, logOperationChanged & " '" & logOperationCurrentState & "'")

    End Sub

    Public Sub logLocationChange(ByVal locCode As Integer)

        If diagnosticLevel < 2 Then Exit Sub

        Dim logLocationCurrentState As String = Trim(scanLocation.currentLocation)

        If Not isNonNullString(logLocationCurrentState) Then
            logLocationCurrentState = ""
        End If

        If logLocationCurrentState = logLocationLastState Then Exit Sub

        logLocationLastState = logLocationCurrentState

        logEvent(locCode, logLocationChanged & " '" & logLocationCurrentState & "'")

    End Sub

    Public Sub logScanStateChange(ByVal locCode As Integer, ByVal state As Boolean)

        ' Note: here I do not censor "non-change" changes because I want to track the number
        ' activity related to redundant state change

        If diagnosticLevel < 2 Then Exit Sub

        Dim scanStateString As String

        If state Then
            scanStateString = " Scanner Turned On"
        Else
            scanStateString = " Scanner Turned Off"
        End If

        logEvent(locCode, logScanStateChanged & scanStateString)

    End Sub

    Public Sub logCradleStateChange(ByVal locCode As Integer, ByVal state As Boolean)

        If diagnosticLevel < 2 Then Exit Sub

        Dim cradleStateString As String

        If state Then
            cradleStateString = " Scanner Placed In Cradle"
        Else
            cradleStateString = " Scanner Removed From Cradle"
        End If

        logEvent(locCode, logScanStateChanged & cradleStateString)

    End Sub

    Public Sub logDataScanEvent(ByVal locCode As Integer, ByVal state As String)

        Util.verify(Not state Is Nothing)

        If diagnosticLevel < 2 Then Exit Sub

        logEvent(locCode, logDataScanned & " Data='" & state & "'")

    End Sub

    Public Sub logPresetEvent(ByVal locCode As Integer, ByVal presetAction As String, ByVal presetString As String)

        Util.verify(Not presetAction Is Nothing)
        Util.verify(Not presetString Is Nothing)

        If diagnosticLevel < 2 Then Exit Sub

        Dim actionCode As String

        actionCode = "Preset" & presetAction
        actionCode = actionCode.PadRight(16)
        actionCode = Substring(actionCode, 0, 16)

        logEvent(locCode, logPresetChanged & " " & actionCode & "='" & presetString & "'")

    End Sub

    Public Sub logResditUploadEvent(ByVal locCode As Integer)

        If diagnosticLevel < 1 Then Exit Sub

        logEvent(locCode, "ResditUpload")

    End Sub

    Public Sub logReaderFormTabChanged(ByVal locCode As Integer)

        If diagnosticLevel < 2 Then Exit Sub

        If MailScanFormRepository.MailScanDomsForm Is Nothing Then Exit Sub

        Dim tabPageIndex As Integer = MailScanFormRepository.MailScanDomsForm.mainTabControl.SelectedIndex
        Dim logReaderFormCurrentTabPage As String = Trim(MailScanFormRepository.MailScanDomsForm.mainTabControl.TabPages(tabPageIndex).Text)

        If Not isNonNullString(logReaderFormCurrentTabPage) Then
            logReaderFormCurrentTabPage = ""
        End If

        If logReaderFormCurrentTabPage = logReaderFormLastTabPage Then Exit Sub

        logReaderFormLastTabPage = logReaderFormCurrentTabPage

        logEvent(locCode, logReaderFormChanged & " ReaderTabPage=" & logReaderFormCurrentTabPage)

    End Sub

    Public Sub logScanEvent(ByVal locCode As Integer, ByVal state As String)

        Util.verify(Not state Is Nothing)

        If diagnosticLevel < 2 Then Exit Sub

        logEvent(locCode, logScan & " " & state)

    End Sub

    Public Sub logScanSequenceEvent(ByVal locCode As Integer, ByVal state As String)

        Util.verify(Not state Is Nothing)

        If diagnosticLevel < 4 Then Exit Sub

        logEvent(locCode, logScanSequence & " " & state)

    End Sub

    Public Sub logUploadButtonClickEvent(ByVal locCode As Integer, ByVal state As String)

        Util.verify(Not state Is Nothing)

        If diagnosticLevel < 2 Then Exit Sub

        logEvent(locCode, logUploadEvent & " " & state)

    End Sub


    Public Sub logExceptionEvent(ByVal locCode As Integer, ByVal state As String)

        Util.verify(Not state Is Nothing)

        If diagnosticLevel < 1 Then Exit Sub

        logEvent(locCode, logException & " " & state)

    End Sub

    Private Function logWriteLogFileRecord(ByVal logString As String) As String

        If diagnosticLevel < 1 Then Exit Function

        Dim logStringBuffer(logRecordSize) As Byte

        Dim i, ilmt As Integer

        ilmt = logString.Length - 1

        For i = 0 To ilmt
            logStringBuffer(i) = Asc(logString.Chars(i))
        Next

        i = ilmt + 1

        While i < logRecordSize
            logStringBuffer(i) = Asc(" "c)
            i += 1
        End While

        Dim logFileStream As FileStream

        Try
            logFileStream = New FileStream(logFilePath, FileMode.Open)
        Catch ex As Exception
            Return "Open on log file failed: " & ex.Message
        End Try

        If logFileIndex < 0 Then logFileIndex = 0

        Dim offset As Integer = logFileIndex * logRecordSize

        Try
            logFileStream.Seek(offset, SeekOrigin.Begin)
        Catch ex As Exception
            logFileStream.Close()
            Return "Seek on log file failed: " & ex.message
        End Try

        Try
            logFileStream.Write(logStringBuffer, 0, logRecordSize)
        Catch ex As Exception
            logFileStream.Close()
            Return "Write on log file failed: " & ex.message
        End Try

        logFileStream.Close()

        Return "OK"

    End Function

    Public Sub logMaintenanceThreadSub()

        Dim logString As String = Nothing

        While True

            SyncLock logStackAccessSemiphore

                If logStackTop >= 0 Then

                    logString = logStack(logStackTop)

                    If Not logString Is Nothing Then

                        logStack(logStackTop) = Nothing

                        logStackTop -= 1
                        If logStackTop < 0 Then logStackTop += logFileTotalRecordCount

                    End If

                ElseIf Not loggingIsActive Then
                    Exit Sub
                End If

            End SyncLock

            If Not logString Is Nothing Then

                SyncLock logFileAccessSemiphore

                    logWriteLogFileRecord(logString)

                    logFileIndex = (logFileIndex + 1) Mod logFileTotalRecordCount

                    logSaveLogFileIndex()

                End SyncLock

            End If

            System.Threading.Thread.Sleep(10)

        End While

    End Sub

End Module
