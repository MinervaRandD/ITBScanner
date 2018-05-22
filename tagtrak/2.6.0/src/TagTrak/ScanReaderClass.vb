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

Imports System.Text.RegularExpressions

Class scanReaderClass
    Implements IDisposable

#Region "Intermec"

#If deviceType = "Intermec" Then

    Public WithEvents MyReader As Intermec.DataCollection.BarcodeReader = Nothing
    Private MyReaderData As Intermec.DataCollection.BarcodeReadEventArgs = Nothing

    Public Sub New()

        Dim buffSize As UInt32 = UInt32.Parse("65536")

        'Try
        MyReader = New Intermec.DataCollection.BarcodeReader(buffSize)

        If userSpecRecord.continuousMailScan = True Then
            MyReader.ContinuesScan = True
        End If
        'Catch ex As Exception
        '    MsgBox(ex.Message & vbCrLf)
        '    scannerLibClass.WarmBoot()
        'End Try


    End Sub

#Region "IDisposable Support"
    Private disposedValue As Boolean = False        ' To detect redundant calls

    ' IDisposable
    Protected Overridable Sub Dispose(ByVal disposing As Boolean)
        If Not Me.disposedValue Then
            If disposing Then
                '' Free when explicitly called
            End If

            '' Free shared resources
            'MyReader.ScannerEnable = False
            MyReader.Dispose()
        End If
        Me.disposedValue = True
    End Sub

    Public Sub Dispose() Implements IDisposable.Dispose
        ' Do not change this code.  Put cleanup code in Dispose(ByVal disposing As Boolean) above.
        Dispose(True)
        GC.SuppressFinalize(Me)
    End Sub
#End Region

    Private Sub BarcodeRead(ByVal sender As System.Object, ByVal e As Intermec.DataCollection.BarcodeReadEventArgs) Handles MyReader.BarcodeRead

        logDataScanEvent(1, e.strDataBuffer)

        If emulatingPlatform Then Exit Sub

        ' The following semiphore should never be needed by this event handler. It is used in
        '    1. The various timers and
        '    2. Ftp processes
        ' to avoid having anything interrupt the scan handling process.

        Try

            SyncLock criticalSectionSemiphore

                If criticalSectionSemiphore.getSemiphoreState = False Then

                    criticalSectionSemiphore.setSemiphoreState(True)

                    Util.turnScannerOff(1)

                    TagTrakGlobals.backgroundFtpTimer.Enabled = False

                    If userSpecRecord.buzzOnScan Then
                        tagTrakFormRepository.TagTrakBaseForm.buzzLengthTimer.Interval = userSpecRecord.buzzLength
                        tagTrakFormRepository.TagTrakBaseForm.buzzLengthTimer.Enabled = True
                        scannerLib.VibrateON()
                    End If

                    If userSpecRecord.beepOnScan Then
                        scannerLib.BeepSound()
                    End If

                    Dim strBarcode As String = e.strDataBuffer
                    Dim i As Integer = 0

                    For i = 0 To e.strDataBuffer.Length - 1
                        If Not Char.IsLetterOrDigit(e.strDataBuffer.Chars(i)) Then
                            strBarcode = strBarcode.Remove(i, 1)
                        End If
                    Next

                    Dim blnResult As Boolean

                    If userSpecRecord.autoMailSwitch = True Then
                        blnResult = BarcodeCheck(TagTrakGlobals.currentScanOperation, strBarcode)
                    End If

                    Application.DoEvents()

                    Dim result As String = ""

                    If Not blnResult Then

                        If TagTrakGlobals.currentScanOperation = "MailScanDoms" Then
                            MailScanFormRepository.MailScanDomsForm.ProcessScanData(e.strDataBuffer, e.Symbology)
                        ElseIf TagTrakGlobals.currentScanOperation = "MailScanIntl" Then
                            MailScanFormRepository.MailScanIntlForm.ProcessScanData(e.strDataBuffer, e.Symbology)
                        ElseIf TagTrakGlobals.currentScanOperation = "MailScanIntlSimple" Then
                            MailScanIntlSimpleForm.GetInstance.ProcessScanData(e.strDataBuffer, e.Symbology)
                        ElseIf TagTrakGlobals.currentScanOperation = "CargoScan" Then
                            CargoScanFormRepository.CargoScanBaseForm.ProcessScanData(e.strDataBuffer, e.Symbology)
                        ElseIf TagTrakGlobals.currentScanOperation = "BagScan" Then
                            BagScanFormRepository.BagScanBaseForm.ProcessScanData(e.strDataBuffer, e.Symbology)
                        End If

                    End If

                    Util.turnScannerOn(2)

                    TagTrakGlobals.backgroundFtpTimer.Enabled = True

                    If userSpecRecord.FirstReminderInterval > 0 Then
                        TagTrakGlobals.uploadReminderTimer.Enabled = True
                    End If

                    criticalSectionSemiphore.setSemiphoreState(False)

                End If

            End SyncLock

        Catch ex As Exception

            logExceptionEvent(1, "Scan error: " & ex.Message)

            MsgBox("A Scan Related Error Has Occured. Please Report The Following Message To Your Systems Administrator: " _
                    & ex.Message, MsgBoxStyle.Exclamation, "Scan Error")

            Util.turnScannerOn(2)

            TagTrakGlobals.backgroundFtpTimer.Enabled = True

            criticalSectionSemiphore.setSemiphoreState(False)


        End Try

        Application.DoEvents()

    End Sub

    Public Sub disable()

        If MyReader Is Nothing Then Exit Sub

        MyReader.ScannerEnable = False

    End Sub

    Public Sub enable()

        If MyReader Is Nothing Then Exit Sub

        MyReader.ScannerEnable = True
        MyReader.ThreadedRead(True)

    End Sub

#End If
#End Region

#Region "Symbol"

#If deviceType = "Symbol" Then

    Public WithEvents MyReader As Symbol.Barcode.Reader = Nothing
    Private MyReaderData As Symbol.Barcode.ReaderData = Nothing
    Private IsEnabled As Boolean = False

    Public Sub New()
        MyReader = New Symbol.Barcode.Reader
        MyReaderData = New Symbol.Barcode.ReaderData(Symbol.Barcode.ReaderDataTypes.Text, Symbol.Barcode.ReaderDataLengths.MaximumLabel)

        Enable()

    End Sub

#Region "IDisposable Support"
    Private disposedValue As Boolean = False        ' To detect redundant calls

    ' IDisposable
    Protected Overridable Sub Dispose(ByVal disposing As Boolean)
        If Not Me.disposedValue Then
            If disposing Then
                '' Free when explicitly called
            End If

            '' Free shared resources
            MyReaderData.Dispose()
            MyReader.Dispose()
        End If
        Me.disposedValue = True
    End Sub

    Public Sub Dispose() Implements IDisposable.Dispose
        ' Do not change this code.  Put cleanup code in Dispose(ByVal disposing As Boolean) above.
        Dispose(True)
        GC.SuppressFinalize(Me)
    End Sub
#End Region

    Private Sub BarcodeRead(ByVal sender As Object, ByVal e As System.EventArgs)

        If emulatingPlatform Then Exit Sub

        Dim TheReaderData As Symbol.Barcode.ReaderData = Me.MyReader.GetNextReaderData()

        If (TheReaderData.Result = Symbol.Results.SUCCESS) Then

            'logDataScanEvent(1, e.strDataBuffer)

            ' The following semiphore should never be needed by this event handler. It is used in
            '    1. The various timers and
            '    2. Ftp processes
            ' to avoid having anything interrupt the scan handling process.

            Try

                SyncLock criticalSectionSemiphore

                    If criticalSectionSemiphore.getSemiphoreState = False Then

                        criticalSectionSemiphore.setSemiphoreState(True)

                        'turnScannerOff(1)
                        MyReader.Actions.Disable()

                        TagTrakGlobals.backgroundFtpTimer.Enabled = False

                        'If userSpecRecord.buzzOnScan Then
                        '    tagTrakFormRepository.TagTrakBaseForm.buzzLengthTimer.Interval = userSpecRecord.buzzLength
                        '    tagTrakFormRepository.TagTrakBaseForm.buzzLengthTimer.Enabled = True
                        '    scannerLib.VibrateON()
                        'End If

                        'If userSpecRecord.beepOnScan Then
                        '    scannerLib.BeepSound()
                        'End If

                        'Modified by MX
                        Dim strBarcode As String = TheReaderData.Text

                        Dim i As Integer = 0
                        For i = 0 To TheReaderData.Text.Length - 1
                            If Not Char.IsLetterOrDigit(TheReaderData.Text.Chars(i)) Then
                                strBarcode = strBarcode.Remove(i, 1)
                            End If
                        Next

                        Dim blnResult As Boolean

                        If userSpecRecord.autoMailSwitch = True Then
                            blnResult = BarcodeCheck(TagTrakGlobals.currentScanOperation, strBarcode)
                        End If

                        Application.DoEvents()

                        Dim result As String = ""

                        If Not blnResult Then

                            If TagTrakGlobals.currentScanOperation = "MailScanDoms" Then
                                MailScanFormRepository.MailScanDomsForm.ProcessScanData(strBarcode, TheReaderData.RequestId)
                            ElseIf TagTrakGlobals.currentScanOperation = "MailScanIntl" Then
                                MailScanFormRepository.MailScanIntlForm.ProcessScanData(strBarcode, TheReaderData.RequestId)
                            ElseIf TagTrakGlobals.currentScanOperation = "MailScanIntlSimple" Then
                                MailScanIntlSimpleForm.GetInstance.ProcessScanData(strBarcode, TheReaderData.RequestId)
                            ElseIf TagTrakGlobals.currentScanOperation = "CargoScan" Then
                                CargoScanFormRepository.CargoScanBaseForm.ProcessScanData(strBarcode, TheReaderData.RequestId)
                            ElseIf TagTrakGlobals.currentScanOperation = "BagScan" Then
                                BagScanFormRepository.BagScanBaseForm.ProcessScanData(strBarcode, TheReaderData.RequestId)
                            End If

                        End If

                        'turnScannerOn(2)
                        MyReader.Actions.Enable()
                        MyReader.Actions.Read(MyReaderData)

                        TagTrakGlobals.backgroundFtpTimer.Enabled = True

                        'Added by MX
                        If userSpecRecord.FirstReminderInterval > 0 Then
                            TagTrakGlobals.uploadReminderTimer.Enabled = True
                        End If

                        criticalSectionSemiphore.setSemiphoreState(False)

                    End If

                End SyncLock

            Catch ex As Exception

                logExceptionEvent(1, "Scan error: " & ex.Message)

                MsgBox("A Scan Related Error Has Occured. Please Report The Following Message To Your Systems Administrator: " _
                        & ex.Message, MsgBoxStyle.Exclamation, "Scan Error")

                'turnScannerOn(2)
                MyReader.Actions.Enable()
                MyReader.Actions.Read(MyReaderData)

                TagTrakGlobals.backgroundFtpTimer.Enabled = True

                criticalSectionSemiphore.setSemiphoreState(False)

            End Try

            Application.DoEvents()

        End If

    End Sub

    Public Sub Disable()
        If IsEnabled Then
            'Flush (Cancel all pending reads)
            RemoveHandler MyReader.ReadNotify, AddressOf BarcodeRead
            Me.MyReader.Actions.Disable()
            Me.MyReader.Actions.Flush()

            IsEnabled = False

        End If

    End Sub

    Public Sub Enable()

        If IsEnabled = False Then
            Me.MyReader.Actions.Enable()

            'Submit a read
            AddHandler MyReader.ReadNotify, AddressOf BarcodeRead
            Me.MyReader.Actions.Read(Me.MyReaderData)

            IsEnabled = True

        End If

    End Sub

#End If

#End Region

#Region "Dolphin"

#If deviceType = "Dolphin" Then

    Friend WithEvents dcReader As HHP.DataCollection.Decoding.DecodeControl

    Public Sub New()
        Create()
        Enable()
    End Sub

    Private Sub Create()
        If Not dcReader Is Nothing Then Return

        dcReader = New HHP.DataCollection.Decoding.DecodeControl

        If userSpecRecord.continuousMailScan = True Then
            dcReader.ContinuousScan = True
        End If
    End Sub

#Region "IDisposable Support"
    Private disposedValue As Boolean = False        ' To detect redundant calls

    ' IDisposable
    Protected Overridable Sub Dispose(ByVal disposing As Boolean)
        If Not Me.disposedValue Then
            If disposing Then
                '' Free when explicitly called
            End If

            '' Free shared resources
            If dcReader Is Nothing = False Then
                dcReader.Dispose()
                dcReader = Nothing
            End If
        End If
        Me.disposedValue = True
    End Sub

    Public Sub Dispose() Implements IDisposable.Dispose
        ' Do not change this code.  Put cleanup code in Dispose(ByVal disposing As Boolean) above.
        Dispose(True)
        GC.SuppressFinalize(Me)
    End Sub
#End Region

    Private Sub BarcodeRead(ByVal sender As Object, ByVal e As HHP.DataCollection.Decoding.DecodeEventArgs) Handles dcReader.DecodeEvent

        If e.DecodeResults.pchMessage.Trim = "" Then
            Exit Sub
        End If

        logDataScanEvent(1, e.DecodeResults.pchMessage)

        If emulatingPlatform Then Exit Sub

        ' The following semiphore should never be needed by this event handler. It is used in
        '    1. The various timers and
        '    2. Ftp processes
        ' to avoid having anything interrupt the scan handling process.

        Try

            SyncLock criticalSectionSemiphore

                If criticalSectionSemiphore.getSemiphoreState = False Then

                    criticalSectionSemiphore.setSemiphoreState(True)

                    Util.turnScannerOff(1)

                    TagTrakGlobals.backgroundFtpTimer.Enabled = False

                    'If userSpecRecord.buzzOnScan Then
                    '    tagTrakFormRepository.TagTrakBaseForm.buzzLengthTimer.Interval = userSpecRecord.buzzLength
                    '    tagTrakFormRepository.TagTrakBaseForm.buzzLengthTimer.Enabled = True
                    '    scannerLib.VibrateON()
                    'End If

                    'If userSpecRecord.beepOnScan Then
                    '    scannerLib.BeepSound()
                    'End If

                    Dim strBarcode As String = e.DecodeResults.pchMessage
                    Dim i As Integer = 0

                    For i = 0 To e.DecodeResults.pchMessage.Length - 1
                        If Not Char.IsLetterOrDigit(e.DecodeResults.pchMessage.Chars(i)) Then
                            strBarcode = strBarcode.Remove(i, 1)
                        End If
                    Next

                    Dim blnResult As Boolean

                    If userSpecRecord.autoMailSwitch = True Then
                        blnResult = BarcodeCheck(TagTrakGlobals.currentScanOperation, strBarcode)
                    End If

                    Application.DoEvents()

                    Dim result As String = ""

                    If Not blnResult Then

                        If TagTrakGlobals.currentScanOperation = "MailScanDoms" Then
                            MailScanFormRepository.MailScanDomsForm.ProcessScanData(strBarcode, e.DecodeResults.nLength)
                        ElseIf TagTrakGlobals.currentScanOperation = "MailScanIntl" Then
                            MailScanFormRepository.MailScanIntlForm.ProcessScanData(strBarcode, e.DecodeResults.nLength)
                        ElseIf TagTrakGlobals.currentScanOperation = "MailScanIntlSimple" Then
                            MailScanIntlSimpleForm.GetInstance.ProcessScanData(strBarcode, e.DecodeResults.nLength)
                        ElseIf TagTrakGlobals.currentScanOperation = "CargoScan" Then
                            CargoScanFormRepository.CargoScanBaseForm.ProcessScanData(strBarcode, e.DecodeResults.nLength)
                        ElseIf TagTrakGlobals.currentScanOperation = "BagScan" Then
                            BagScanFormRepository.BagScanBaseForm.ProcessScanData(strBarcode, e.DecodeResults.nLength)
                        End If

                    End If

                    Util.turnScannerOn(2)

                    TagTrakGlobals.backgroundFtpTimer.Enabled = True

                    'Added by MX
                    If userSpecRecord.FirstReminderInterval > 0 Then
                        TagTrakGlobals.uploadReminderTimer.Enabled = True
                    End If

                    criticalSectionSemiphore.setSemiphoreState(False)

                End If

            End SyncLock

        Catch ex As Exception

            logExceptionEvent(1, "Scan error: " & ex.Message)

            MsgBox("A Scan Related Error Has Occured. Please Report The Following Message To Your Systems Administrator: " _
                    & ex.Message, MsgBoxStyle.Exclamation, "Scan Error")

            Util.turnScannerOn(2)

            TagTrakGlobals.backgroundFtpTimer.Enabled = True

            criticalSectionSemiphore.setSemiphoreState(False)


        End Try

        Application.DoEvents()

    End Sub


    Public Sub Disable()
        dcReader.AutoScan = False
    End Sub

    Public Sub Enable()
        dcReader.AutoScan = True
    End Sub

#End If

#End Region

    Private Function BarcodeCheck(ByRef strScanOperation As String, ByVal strBarcode As String) As Boolean

        Dim rxDomestic As New Regex("^\w{12}$", RegexOptions.IgnoreCase)
        Dim rxInternational As New Regex("^\w{15}\d{14}$", RegexOptions.IgnoreCase)
        Dim rxCargo As New Regex("^\d{11}|\d{15}|\d{16}$")
        Dim rxBaggage As New Regex("^\d{10}$")

        Dim frmMailSwitch As New MailSwitch

        If rxDomestic.IsMatch(strBarcode) Then

            If strScanOperation = "MailScanDoms" Then
                Return False
            Else

                If userSpecRecord.mailScanEnabled = True Or userSpecRecord.mailSimpleScanEnabled = True Then

                    frmMailSwitch.lblScanSwitch.Text = "This is domestic mail barcode. Would you like to switch to domestic mail scan?"

                    If frmMailSwitch.ShowDialog() = DialogResult.OK Then
                        MailScanFormRepository.MailScanDomsForm.resetOperationComboBoxWithoutWarning()
                        MailScanFormRepository.MailScanDomsForm.Show()
                        frmMailSwitch.Hide()
                        Return True
                    Else
                        frmMailSwitch.Hide()
                        Return False
                    End If

                End If

                Return False

            End If

        ElseIf rxInternational.IsMatch(strBarcode) Then

            If strScanOperation = "MailScanIntl" Or strScanOperation = "MailScanIntlSimple" Then
                Return False
            Else

                If userSpecRecord.internationalMailEnabled = True Or userSpecRecord.internationalSimpleMailEnabled = True Then

                    frmMailSwitch.lblScanSwitch.Text = "This is international mail barcode. Would you like to switch to international mail scan?"

                    If frmMailSwitch.ShowDialog() = DialogResult.OK Then
                        MailScanFormRepository.MailScanIntlForm.resetOperationComboBoxWithoutWarning()
                        MailScanFormRepository.MailScanIntlForm.Show()
                        frmMailSwitch.Hide()
                        Return True
                    Else
                        frmMailSwitch.Hide()
                        Return False
                    End If

                End If

            End If

        ElseIf rxCargo.IsMatch(strBarcode) Then

            If strScanOperation = "CargoScan" Then
                Return False
            Else

                If userSpecRecord.cargoScanEnabled = True Then

                    frmMailSwitch.lblScanSwitch.Text = "This is cargo barcode. Would you like to switch to cargo scan?"

                    If frmMailSwitch.ShowDialog() = DialogResult.OK Then
                        CargoScanFormRepository.CargoScanBaseForm.Operations.SelectedIndex = -1
                        CargoScanFormRepository.CargoScanBaseForm.Show()
                        frmMailSwitch.Hide()
                        Return True
                    Else
                        frmMailSwitch.Hide()
                        Return False
                    End If

                End If

            End If

        ElseIf rxBaggage.IsMatch(strBarcode) Then

            If strScanOperation = "BagScan" Then
                Return False
            Else

                If userSpecRecord.baggageScanEnabled = True Then

                    frmMailSwitch.lblScanSwitch.Text = "This is baggage barcode. Would you like to switch to baggage scan?"

                    If frmMailSwitch.ShowDialog() = DialogResult.OK Then
                        BagScanFormRepository.BagScanBaseForm.baggageOperationComboBox.SelectedIndex = -1
                        BagScanFormRepository.BagScanBaseForm.Show()
                        frmMailSwitch.Hide()
                        Return True
                    Else
                        frmMailSwitch.Hide()
                        Return False
                    End If

                End If

            End If

        End If

        Return False

    End Function

End Class


