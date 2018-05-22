Imports System
Imports System.IO
Imports System.Collections

Public Class ScanRecordSetClass

    Inherits Hashtable

#Region "TimeZoneUsedRecord"
    '' This is the record of time zone information used while scanning
    '' We use this to determine the confidence level of our times
    Public Class TimeZoneUsedRecord
        Private OffsetUTCProp As Double = Double.NaN
        Private IsMixedProp As Boolean = False

        Public Property OffsetUTC() As Double
            Get
                Return OffsetUTCProp
            End Get
            Set(ByVal Value As Double)
                If Not Double.IsNaN(OffsetUTCProp) Then
                    '' If we already set the offset before and we are setting it to a new value, flag this as mixed info.
                    '' Scans generated with mixed timezone information are not reliable.
                    If OffsetUTCProp <> Value Then
                        IsMixedProp = True
                    End If
                End If

                OffsetUTCProp = Value
            End Set
        End Property

        Public ReadOnly Property IsMixed() As Boolean
            Get
                Return IsMixedProp
            End Get
        End Property

        Public Sub Reset()
            OffsetUTCProp = Double.NaN
            IsMixedProp = False
        End Sub

    End Class

#End Region

    Public TimeZoneUsed As New TimeZoneUsedRecord

    Dim primaryOutputFullPath As String
    Dim secondaryOutputFullPath As String

    Dim primaryOutputPathIsValid As Boolean = True
    Dim secondaryOutputPathIsValid As Boolean = True

    Dim scanRecordQueue As New Queue

    Dim scanRecordPrimarySaveSemiphore As New Object
    Dim scanRecordSecondarySaveSemiphore As New Object

    Public Sub New(ByVal inputPrimaryOutputPath As String, ByVal inputSecondaryOutputPath As String)

        primaryOutputFullPath = inputPrimaryOutputPath
        secondaryOutputFullPath = inputSecondaryOutputPath

    End Sub

    Public Function containsRecord(ByVal scanRecord As scanRecordClass) As Boolean

        Dim hashKey As String = scanRecord.getHashKey()
        Return Me.ContainsKey(hashKey)

    End Function

    Public Function addRecord(ByVal scanRecord As scanRecordClass) As String

        If Not Me.ContainsKey(scanRecord.getHashKey()) Then
            Me.Add(scanRecord.getHashKey(), scanRecord)
        End If

        SyncLock scanRecordQueue

            scanRecordQueue.Enqueue(scanRecord)

            TimeZoneUsed.OffsetUTC = scannerTimeZone.OffsetInfo.OffsetUTC

        End SyncLock

        Dim saveScanRecordThread As New System.Threading.Thread(AddressOf saveNewScanRecordsThread)

        saveScanRecordThread.Priority = Threading.ThreadPriority.BelowNormal

        saveScanRecordThread.Start()

        Return "OK"

    End Function

    Public Sub saveNewScanRecordsThread()

        Dim scanRecord As scanRecordClass

        While True

            SyncLock scanRecordQueue

                If scanRecordQueue.Count > 0 Then
                    scanRecord = scanRecordQueue.Dequeue
                Else
                    scanRecord = Nothing
                End If

            End SyncLock

            If scanRecord Is Nothing Then Exit Sub

            threadedSaveNewScanRecords(scanRecord)

        End While

    End Sub

    Public Function threadedSaveNewScanRecords(ByRef scanRecord As scanRecordClass) As String

        Dim result As String

        SyncLock scanRecordPrimarySaveSemiphore

            Dim outputOpCode As Char

            For Each outputOpCode In scanRecord.scanOp

                scanRecord.scanOutputOpCode = outputOpCode

                If primaryOutputPathIsValid Then

                    result = scanRecord.appendToFile(primaryOutputFullPath)

                    If result <> "OK" Then
                        MsgBox("Save of scan record failed: " & result, MsgBoxStyle.Information, "Primary transaction directory failed")
                        primaryDataFileDirectoryIsValid = False
                    End If

                End If

            Next

        End SyncLock

        SyncLock scanRecordSecondarySaveSemiphore

            Dim outputOpCode As Char

            For Each outputOpCode In scanRecord.scanOp

                scanRecord.scanOutputOpCode = outputOpCode

                If secondaryOutputPathIsValid Then

                    result = scanRecord.appendToFile(scanDataSecondaryFilePath)

                    If result <> "OK" Then

                        MsgBox("Save of scan record failed: " & result, MsgBoxStyle.Information, "Secondary transaction directory failed")
                        secondaryOutputPathIsValid = False

                    End If

                End If

            Next

        End SyncLock

        Return "OK"

    End Function

End Class
