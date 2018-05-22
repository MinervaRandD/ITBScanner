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
Imports System.Threading.Thread
Imports System.Net
Imports System.IO
Imports System.Text
Imports System.Net.Sockets
Imports System.Diagnostics
Imports System.Net.Sockets.TcpClient
Imports Rebex.Net
Imports System.Security.Cryptography
Imports System.Runtime.InteropServices
Imports System.Text.RegularExpressions

' Ftp process class contains all methods and attributes required to
' effect the upload download of information to/from the server.

Class ftpProcessClass

    ' stateLabel, ftpTransferProgressBar, transferStatusLabel are controls on the
    ' derived form that provide the user visual feedback on the current
    ' ftp process. The methods in this class update these values. If
    ' set to nothing, the associated updates are ignored.

    Friend WithEvents stateLabel As System.Windows.Forms.Label
    Friend WithEvents ftpTransferProgressBar As System.Windows.Forms.ProgressBar
    Friend WithEvents transferStatusLabel As System.Windows.Forms.Label
    Friend WithEvents transferBaseForm As Windows.Forms.Form

    Private ftp As ftp = Nothing                    ' Base ftp class provided by Rebex

    Private ftpState As ftpState = ftpState.Ready   ' The current state of the ftp process. Refer to Rebex documentation for possible values.
    Private ftpBytesTransferred As Long = 0         ' Total number of bytes transferred during the current transfer operation (not a cumulative total)
    Private ftpTransferFileSize As Long             ' Size of the current file being transferred.

    Private ftpShowErrorMessageBoxes As Boolean = True

    Dim ftpDigest(31) As Byte

    Private DialogResult As DialogResult

    Public ShowErrors As Boolean = True

    Const ftpCommandTimeout As Integer = 60000
#If deviceType = "PC" Then
    Friend WithEvents cm As OpenNETCF.Net.ConnectionManager
#Else
    Friend WithEvents cm As New OpenNETCF.Net.ConnectionManager
#End If

    Const ResditVersion As Integer = 12

    Public Sub New( _
        ByRef inputTransferBaseForm As Windows.Forms.Form, _
        ByRef inputStateLabel As System.Windows.Forms.Label, _
        ByRef inputPbProgressBar As System.Windows.Forms.ProgressBar, _
        ByRef inputTransferStatusLabel As System.Windows.Forms.Label, _
        Optional ByVal inputShowErrorMessageBoxes As Boolean = True)

#If ValidationLevel >= 3 Then

        If diagnosticLevel >= 2 Then

            verify(Not inputTransferBaseForm Is Nothing, 5010)
            verify(Not inputStateLabel Is Nothing, 5011)
            verify(Not inputPbProgressBar Is Nothing, 5012)
            verify(Not inputTransferStatusLabel Is Nothing, 5013)

        End If

#End If

        transferBaseForm = inputTransferBaseForm
        stateLabel = inputStateLabel
        ftpTransferProgressBar = inputPbProgressBar
        transferStatusLabel = inputTransferStatusLabel

        ftpShowErrorMessageBoxes = inputShowErrorMessageBoxes

        ftpDoNotDisconnectWireless = False

        DialogResult = DialogResult.OK

    End Sub

    Public Sub TransferProgress(ByVal sender As Object, ByVal e As FtpTransferProgressEventArgs)

        ftpBytesTransferred = e.BytesTransfered
        transferBaseForm.Invoke(New EventHandler(AddressOf TransferProgressRefresh))

    End Sub 'TransferProgress

    Public Sub StateChanged(ByVal sender As Object, ByVal e As FtpStateChangedEventArgs)

        ftpState = e.NewState
        transferBaseForm.Invoke(New EventHandler(AddressOf StateRefresh))
        'StateRefresh(Nothing, Nothing)

        Application.DoEvents()

    End Sub 'StateChanged

    Private Sub TransferProgressRefresh(ByVal sender As Object, ByVal e As EventArgs)

        Dim index As Double

        If ftpTransferProgressBar Is Nothing Then Exit Sub

        If Not updateProgressBar Then Exit Sub

        If ftpBytesTransferred = 0 Then
            StateRefresh(sender, e)
            Return
        End If

        If ftpTransferFileSize > 0 Then

            index = (10000.0 * CDbl(ftpBytesTransferred)) / CDbl(ftpTransferFileSize)

            If index < 0.0 Then
                index = 0.0
            ElseIf index > 10000.0 Then
                index = 10000.0
            End If

            ftpTransferProgressBar.Value = CInt(index)

        End If

        Application.DoEvents()

    End Sub 'TransferProgressRefresh

    Private Sub StateRefresh(ByVal sender As Object, ByVal e As EventArgs)

        If stateLabel Is Nothing Then Exit Sub

        Select Case ftpState

            Case ftpState.Disconnected, ftpState.Disposed

                stateLabel.Text = "Transfer Completed"

            Case ftpState.Ready

                stateLabel.Text = "Ready"

            Case Else

                stateLabel.Text = "Working"

        End Select

        Application.DoEvents()

    End Sub 'StateRefresh

    Dim ftpResponseString As String = ""
    Dim ignoreResponseReadEvent As Boolean = True

    Private Sub ResponseReadHandler(ByVal sender As Object, ByVal e As FtpResponseReadEventArgs)

        If ignoreResponseReadEvent Then Exit Sub

        Dim result As String = e.Response

        ftpResponseString &= result & " "

    End Sub

    Public Sub ftpCloseFtpSession()

        If Not ftp Is Nothing Then
            'ftp.Disconnect()

            ftp.Dispose()

            ftp = Nothing

        End If

    End Sub

    Public Sub ftpDisconnectWireless()

        If ftpDoNotDisconnectWireless Then Exit Sub

        If Not cm Is Nothing Then
            cm.Disconnect()
        End If

    End Sub

    Dim ftpIsEthernetCity As Boolean
    Dim ftpIsWirelessCity As Boolean
    Dim ftpDeviceInCradle As Boolean

    Public ftpDoNotDisconnectWireless As Boolean = False

    ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
    '                                                                              '
    ' Function: ftpDisplayDeviceNotInCradleError.                                  '
    '                                                                              '
    ' Returns:  Status information provided by the user:                           '
    '                                                                              '
    '           "Retry"  (string) -- User wishes to reattempt process that caused  '
    '                                this error (presumbably after he/she places   '
    '                                device in the cradle.                         '
    '                                                                              '
    '           "Cancel" (string) -- User does not with to reattempt process that  '
    '                                caused this error.                            '
    '                                                                              '
    ' Author:   Marc Diamond                                                       '
    '                                                                              '
    ' Displays an error message indicating that the device is not in the cradle or '
    ' that there is some reason why the cradle is not being detected, when it is   '
    ' required for the current operation.                                          '
    '                                                                              '
    ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

    Public Function ftpDisplayDeviceNotInCradleError() As String
        If Not Me.ShowErrors Then Return "Cancel"

        'Me.DialogResult = FtpFormRepository.ftpMsgFormDeviceNotInCradle.ShowDialog()
        Dim dlg As New ftpMsgFormDeviceNotInCradle
        Me.DialogResult = dlg.ShowDialog()

        If Me.DialogResult = DialogResult.Abort Then Return "Abort"

        If Me.DialogResult = DialogResult.Retry Then

            transferBaseForm.BringToFront()
            Application.DoEvents()

            Return "Retry"

        End If

        transferBaseForm.BringToFront()
        Application.DoEvents()

        Return "Cancel"

    End Function

    ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
    '                                                                              '
    ' Function: ftpDisplayEthernetConnectivityError                                '
    '                                                                              '
    ' Returns:  Status information provided by the user:                           '
    '                                                                              '
    '           "Retry"  (string) -- User wishes to reattempt process that caused  '
    '                                this error (presumbably after he/she places   '
    '                                device in the cradle.                         '
    '                                                                              '
    '           "Cancel" (string) -- User does not with to reattempt process that  '
    '                                caused this error.                            '
    '                                                                              '
    ' Author:   Marc Diamond                                                       '
    '                                                                              '
    ' Displays an error message indicating that the attempt to open an ftp         '
    ' connection failed. Return code is based on the users response on the error   '
    ' display form.                                                                '
    '                                                                              '
    ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

    Public Function ftpDisplayEthernetConnectivityError(ByVal errorMessage As String) As String
        If Not Me.ShowErrors Then Return "Cancel"

        'FtpFormRepository.ftpMsgFormEtherConnFail.init(errorMessage)
        'Me.DialogResult = FtpFormRepository.ftpMsgFormEtherConnFail.ShowDialog()
        Dim dlg As New ftpMsgFormEtherConnFail
        dlg.init(errorMessage)
        Me.DialogResult = dlg.ShowDialog()

        If Me.DialogResult = DialogResult.Abort Then
            Return "Abort"
        End If

        If Me.DialogResult = DialogResult.Retry Then

            Me.transferBaseForm.BringToFront()

            Application.DoEvents()
            Return "Retry"

        End If

        Me.transferBaseForm.BringToFront()

        Application.DoEvents()
        Return "Cancel"

    End Function

    Public Function ftpDisplayLoginFailureError(ByVal errorMessage As String) As String
        If Not Me.ShowErrors Then Return "Cancel"

        'FtpFormRepository.ftpMsgFormLoginFailure.init(errorMessage)
        'Me.DialogResult = FtpFormRepository.ftpMsgFormLoginFailure.ShowDialog()
        Dim dlg As New ftpMsgFormLoginFailure
        dlg.init(errorMessage)
        Me.DialogResult = dlg.ShowDialog()

        If Me.DialogResult = DialogResult.Abort Then
            Return "Abort"
        End If


        If Me.DialogResult = DialogResult.Retry Then

            Me.transferBaseForm.BringToFront()

            Application.DoEvents()
            Return "Retry"

        End If

        Me.transferBaseForm.BringToFront()

        Application.DoEvents()

        Return "Cancel"

    End Function

    Public Function ftpDisplayWirelessConnectionFailure(ByVal errorMessage As String) As String
        If Not Me.ShowErrors Then Return "Cancel"

        'FtpFormRepository.ftpMsgFormWirelessConnFail.init(errorMessage)
        'Me.DialogResult = FtpFormRepository.ftpMsgFormWirelessConnFail.ShowDialog()
        Dim dlg As New ftpMsgFormWirelessConnFail
        Me.DialogResult = dlg.ShowDialog()

        If Me.DialogResult = DialogResult.Abort Then Return "Abort"

        If Me.DialogResult = DialogResult.Retry Then Return "Retry"

        Return "Cancel"

    End Function

    Public Function ftpDisplayWirelessConnectivityError(ByVal errorMessage As String) As String
        If Not Me.ShowErrors Then Return "Cancel"

        Dim ftpMsgFormWirelessFtpConnFailDisplayForm As New ftpMsgFormWirelessFtpConnFail(errorMessage)
        Dim result As DialogResult = ftpMsgFormWirelessFtpConnFailDisplayForm.ShowDialog()

        If result = DialogResult.Retry Then
            Return "Retry"
        End If

        Return "Cancel"

    End Function

    ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
    '                                                                              '
    ' Function: ftpEstablishFtpSession. Returns: status information as a string    '
    '                                                                              '
    ' Note: Status information is a cascaded record of error strings propogated    '
    '       upward from subroutine calls.                                          '
    '                                                                              '
    ' Establishes (sets up) an ftp session. This involves:                         '
    ' 1. Connecting to the ISP (in the case of a wireless connection),             '
    ' 2. Establishing an Ftp connection, and                                       '
    ' 3. Logging in to the ASI server.                                             '
    '                                                                              '
    ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

    Public Function ftpEstablishFtpSession() As String

        Dim result As String

        'Dim location As String = scanLocation.currentLocation

        'If Not isValidLocation(location) Then

        '    ftpDisplaySystemError("Attempt to connect from an invalid location '" & location & "'.")
        '    Return "Attempt to connect from an invalid location '" & location & "'."

        'End If

        '' Establish the type of connection required. There are two possibilities
        '' (1) Built-in Ethernet, and
        '' (2) Wireless.
        '' Every city on the system must be one or the other.

        'ftpIsEthernetCity = userSpecRecord.ethernetCityTable.ContainsKey(location)
        'ftpIsWirelessCity = userSpecRecord.wirelessCityTable.ContainsKey(location)

        'If Not ftpIsEthernetCity And Not ftpIsWirelessCity Then

        '    ftpDisplaySystemWarning("Ftp connection protocol not specified for " & location & ". Wireless connection will be assumed.")
        '    ftpIsWirelessCity = True

        'ElseIf ftpIsEthernetCity And ftpIsWirelessCity Then

        '    ftpDisplaySystemWarning("Ambiguous Ftp protocol specified for " & location & ". Wireless connection will be assumed.")
        '    ftpIsEthernetCity = False

        'End If

        If Not ftp Is Nothing Then

            If ftp.State <> ftpState.Disconnected Then
                ftp.Disconnect()
            End If

            ftp.Dispose()
            ftp = Nothing

        End If

        ftp = New Ftp
        ftp.Passive = True
        ftp.Options = FtpOptions.KeepAliveDuringTransfer
        ftp.KeepAliveDuringTransferInterval = 60

        AddHandler ftp.TransferProgress, AddressOf TransferProgress
        AddHandler ftp.StateChanged, AddressOf StateChanged
        AddHandler ftp.ResponseRead, AddressOf ResponseReadHandler

        'Test connecting using proxy
        With userSpecRecord
            If .UseFtpProxy And isNonNullString(.ProxyHost) And .ProxyPort <> Nothing Then
                Dim t As FtpProxyType
                Select Case .ProxyType.ToLower()
                    Case "ftpopen"
                        t = FtpProxyType.FtpOpen
                    Case "ftpsite"
                        t = FtpProxyType.FtpSite
                    Case "ftpuser"
                        t = FtpProxyType.FtpUser
                    Case "httpconnect"
                        t = FtpProxyType.HttpConnect
                    Case "socks4"
                        t = FtpProxyType.Socks4
                    Case "socks4a"
                        t = FtpProxyType.Socks4a
                    Case "socks5"
                        t = FtpProxyType.Socks5
                    Case Else
                        t = FtpProxyType.None
                End Select

                If isNonNullString(.ProxyUser) And isNonNullString(.ProxyPassword) Then
                    Dim crd As New System.Net.NetworkCredential(.ProxyUser, .ProxyPassword)
                    ftp.Proxy = New Rebex.Net.FtpProxy(t, .ProxyHost, .ProxyPort, crd)
                ElseIf isNonNullString(.ProxyUser) Then
                    ftp.Proxy = New Rebex.Net.FtpProxy(t, .ProxyHost, .ProxyPort, .ProxyUser)
                Else
                    ftp.Proxy = New Rebex.Net.FtpProxy(t, .ProxyHost, .ProxyPort)
                End If
            End If
        End With

        ' Establish connectivity via built-in ethernet.

        ' MDD

        'ftpIsEthernetCity = True

        'If ftpIsEthernetCity Then

        '    result = ftpEstablishEthernetSession()
        '    'If result <> "OK" Then ftp.Disconnect()

        '    Return result
        'End If

        '' Establish wireless connectivity.

        'If ftpIsWirelessCity Then

        '    result = ftpEstablishWirelessSession()
        '    If result <> "OK" Then ftp.Disconnect()

        '    Return result
        'End If

        ' Instead of relying on the location, depending on whether the device is in the cradle for 
        ' determining whether to try ethernet or wireless connection

        'If scannerLib.SystemPowerStatus() = 1 Then 'this line is now reverted back

        'If userSpecRecord.wirelessCityTable.ContainsKey(scanLocation.currentLocation) Then
        '    result = ftpEstablishWirelessSession()
        '    If result <> "OK" Then ftp.Disconnect()
        '    Return result
        'Else
        '    result = ftpEstablishEthernetSession()
        '    'If result <> "OK" Then ftp.Disconnect()
        '    Return result
        'End If

        If userSpecRecord.cityTable.ContainsKey(scanLocation.currentLocation) Then

            Dim cityConfig As CityConfig = CType(userSpecRecord.cityTable.Item(scanLocation.currentLocation), CityConfig)

            If cityConfig.GetSetWired And (Not cityConfig.GetSetWireless) And (Not cityConfig.GetSetWireless802) Then
                result = ftpEstablishEthernetSession()
                Return result
            Else
                result = ftpEstablishWirelessSession()
                If result <> "OK" Then ftp.Disconnect()
                Return result
            End If

        Else
            result = ftpEstablishWirelessSession()
            If result <> "OK" Then ftp.Disconnect()
            Return result
        End If

        Return "OK"

    End Function

    ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
    '                                                                              '
    ' Function: ftpEstablishEthernetSession. Returns: status information as a      '
    '           string.                                                            '
    '                                                                              '
    ' Note: Status information is a cascaded record of error strings propogated    '
    '       upward from subroutine calls. Error messages are accessible to the     '
    '       user from windows forms displayed at this level as a result of various '
    '       error conditions that occur in this function and sub-routines.         '
    '                                                                              '
    ' Establishes (sets up) an ftp session via built-in ethernet. This involves,   '
    ' 1. Establishing an Ftp connection, and                                       '
    ' 2. Logging in to the ASI server.                                             '
    '                                                                              '
    ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

    Public Function ftpEstablishEthernetSession() As String

        Dim result As String
        Dim errorMessage As String

#If deviceType = "Dolphin" Then
        '' Dolphins don't have power while connected w/serial cable
        ftpDeviceInCradle = True
#Else
        If scannerLib.SystemPowerStatus() = 1 Then
            ftpDeviceInCradle = True
        Else
            ftpDeviceInCradle = False
        End If
#End If

        ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
        '                                                                          '
        ' Verify that the device is in the cradle. This is required for built-in   '
        ' ethernet connectivity.                                                   '
        '                                                                          '
        ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

        While Not ftpDeviceInCradle

            result = ftpDisplayDeviceNotInCradleError()
            If result <> "Retry" Then Return "Ftp Connection Failure|Device Not In Cradle"

#If deviceType = "Dolphin" Then
            '' Dolphins don't have power while connected w/serial cable
            ftpDeviceInCradle = True
#Else
            If scannerLib.SystemPowerStatus() = 1 Then
                ftpDeviceInCradle = True
            Else
                ftpDeviceInCradle = False
            End If
#End If

        End While

        ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
        '                                                                          '
        ' Device is in the cradle. Attempt to establish an ftp connection. Allow   '
        ' user to force retries as desired.                                        '
        '                                                                          '
        ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

        While True

            result = ftpAttemptFtpConnection(3, 30)

            If result = "OK" Then Exit While

            errorMessage = "Ftp Connection Failure|Unable To Establish Ftp Connection|" & result

            result = ftpDisplayEthernetConnectivityError(errorMessage)
            If result <> "Retry" Then Return errorMessage

        End While

        ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
        '                                                                          '
        ' Ftp connectivity has been established. Attempt to log in to server.      '
        ' user to retry on failure as desired.                                     '
        '                                                                          '
        ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

        While True

            result = ftpAttemptFtpLogin()
            If result = "OK" Then Exit While

            errorMessage = "Ftp Connection Failure|Unable To Log In To Server|" & result

            result = ftpDisplayLoginFailureError(errorMessage)
            If result <> "Retry" Then Return errorMessage

        End While

        ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
        '                                                                          '
        ' Session has been esablished.                                             '
        '                                                                          '
        ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

        Return "OK"

    End Function

    Public Function ftpEstablishWirelessSession() As String

        Dim result As String
        Dim errorMessage As String

        result = ftpAttemptFtpConnection(1, 15)

        If result = "OK" Then

            While True

                result = ftpAttemptFtpLogin()
                If result = "OK" Then Exit While

                errorMessage = "Ftp Connection Failure|Unable To Log In To Server|" & result

                result = ftpDisplayLoginFailureError(errorMessage)
                If result <> "Retry" Then Return errorMessage

            End While

            Return "OK"

        End If

        While True

            AttemptingWireless = True
            result = ftpConnectWireless(120)
            AttemptingWireless = False

            If result = "OK" Then Exit While

            errorMessage = "Wireless Connection Failure|Unable To Connect To Wireless Service|" & result

            result = ftpDisplayWirelessConnectionFailure(errorMessage)
            If result <> "Retry" Then Return errorMessage

        End While

        While True

            result = ftpAttemptFtpConnection(3, 15)
            If result = "OK" Then Exit While

            errorMessage = "Wireless Ftp Connection Failure|Unable To Establish Wireless Ftp Connection|" & result

            result = ftpDisplayWirelessConnectivityError(errorMessage)
            If result <> "Retry" Then Return errorMessage

        End While

        While True

            result = ftpAttemptFtpLogin()
            If result = "OK" Then Exit While

            errorMessage = "Ftp Connection Failure|Unable To Log In To Server|" & result

            result = ftpDisplayLoginFailureError(errorMessage)
            If result <> "Retry" Then Return errorMessage

        End While

        Return "OK"

    End Function

    ' Attempts to set up the ftp connection.

    Private Function ftpAttemptFtpConnection(ByVal numberOfTries As Integer, ByVal secondsPerTry As Integer) As String

        Dim result As String

        ftp.Timeout = 1000 * secondsPerTry

        ftp.Passive = True

        Dim ftpConnectString As String

        Dim hostName As String
        Dim portNumber As Integer

        If userSpecRecord.cityTable.ContainsKey(scanLocation.currentLocation) Then
            Dim cityConfig As CityConfig = CType(userSpecRecord.cityTable.Item(scanLocation.currentLocation), CityConfig)
            If cityConfig.IsFTPOverride Then
                hostName = cityConfig.FTPHostName
                portNumber = cityConfig.FTPPort
            Else
                hostName = userSpecRecord.ftpHostName
                portNumber = userSpecRecord.ftpPortNumber
            End If
        Else
            hostName = userSpecRecord.ftpHostName
            portNumber = userSpecRecord.ftpPortNumber
        End If

        '' MDD

        'hostName = "ftp.asiscan.com"
        'portNumber = 21

        Dim connectionEstablished As Boolean = False
        Dim i As Integer = 1

        While Not connectionEstablished

#If deviceType = "Symbol" Then
            'If userSpecRecord.ftpConnectionDelay > 0 Then
            '    Dim waitingForConnectionForm As waitingToConnectNotificationForm = New waitingToConnectNotificationForm(userRecord.ftpConnectionDelay, i)
            '    waitingForConnectionForm.showdialog()
            'End If
#End If

            Try

                connectionEstablished = True
                'Modified by MX
                If userSpecRecord.ftpSecureConnection = True Then

                    Dim security As FtpSecurity = FtpSecurity.Explicit
                    Dim par As TlsParameters = New TlsParameters
                    par.CommonName = hostName
                    par.CertificateVerifier = CertificateVerifier.AcceptAll

                    ftpConnectString = ftp.Connect(hostName, portNumber, par, security)

                Else

                    ftpConnectString = ftp.Connect(hostName, portNumber)

                End If


            Catch ex As Exception

                connectionEstablished = False
                If i >= numberOfTries Then Return ex.Message

            End Try

            i += 1

        End While

        'serverDateAndTimeUTC = #1/1/1900#

        'result = extractServerDateAndTime(ftpConnectString)

        'If result = "OK" Then
        '    setDeviceDateAndTime(serverDateAndTimeUTC)
        'End If

        Return "OK"

    End Function

    Private Function ftpAttemptFtpLogin() As String

        Dim ftpLoginString As String

        Dim loginID As String
        Dim loginPassword As String

        If userSpecRecord.cityTable.ContainsKey(scanLocation.currentLocation) Then
            Dim cityConfig As CityConfig = CType(userSpecRecord.cityTable.Item(scanLocation.currentLocation), CityConfig)
            If cityConfig.IsFTPOverride Then
                loginID = cityConfig.FTPLogin
                loginPassword = cityConfig.FTPPassword
            Else
                loginID = userSpecRecord.ftpLoginID
                loginPassword = userSpecRecord.ftpPassword
            End If
        Else
            loginID = userSpecRecord.ftpLoginID
            loginPassword = userSpecRecord.ftpPassword
        End If

        Try
            ftpLoginString = ftp.Login(loginID, loginPassword)
        Catch ex As Exception
            Return ex.Message.ToString
        End Try

        Try
            ftp.SetTransferType(FtpTransferType.Binary)
        Catch ex As Exception
            Return "Ftp attempt to set binary mode failed: " & ex.message
        End Try

        Return "OK"

    End Function

    Dim ftpConnectionState As Integer = 0

    Private Sub connectionFailed(ByVal sender As Object, ByVal e As EventArgs) Handles cm.OnConnectionFailed
        ftpConnectionState = -1
    End Sub

    Private Sub connectionMade(ByVal sender As Object, ByVal e As EventArgs) Handles cm.OnConnect
        ftpConnectionState = 1
    End Sub

    Private Sub disconnectedEvent(ByVal sender As Object, ByVal e As EventArgs) Handles cm.OnDisconnect
        ftpConnectionState = 0
    End Sub

    Private Sub connectionChanged(ByVal sender As Object, ByVal e As EventArgs) Handles cm.OnConnectionStateChanged
        ftpConnectionState = 2
    End Sub

    ' ftpConnectionWireless attempts to make a wireless connection throw the OpenNetCF connection
    ' manager.

    Public Function ftpConnectWireless(ByVal timeoutValue As Integer) As String

        Dim result As String

        Dim i As Integer = 0
        Dim failures As Integer

        ftpConnectionState = 0

        ftpDisconnectWireless()

        Try

            cm.Connect()

        Catch ex As Exception

            Return ex.Message

        End Try

        For i = 1 To timeoutValue

            Application.DoEvents()

            Select Case ftpConnectionState

                Case 0
                    Sleep(1000)

                Case 1
                    Sleep(1000)
                    Return "OK"

                Case -1
                    failures += 1
                    If failures >= 5 Then Return "Connection manager reports too many failures."
                    Sleep(1000)

                Case Else
                    Sleep(1000)

            End Select

        Next i

        Return "Unable to connect after " & timeoutValue & " seconds."

        Return "OK"

    End Function


    Private Function ftpCreateDirectoryIfNecessary(ByRef directoryString As String) As String

        Dim fileAndDirectoryList As Rebex.Net.FtpList

        Try
            fileAndDirectoryList = ftp.GetList
        Catch ex As Exception
            Return "Unable To Get Directory List|" & ex.Message
        End Try

        Dim nextFtpItem As Rebex.Net.FtpItem

        For Each nextFtpItem In fileAndDirectoryList

            If nextFtpItem.IsDirectory Then

                If nextFtpItem.Name = directoryString Then
                    Return "OK"
                End If

            End If

        Next

        Try
            ftp.CreateDirectory(directoryString)
        Catch ex As Exception
            Return "Creation of directory '" & directoryString & "' failed|" & ex.message
        End Try

        Return "OK"

    End Function

    ' Routine ftpDownloadWithValidation transmits a file from the server to the device with
    ' a check to see if the correct number of bytes have been transmitted. It will retry
    ' the transmission a specified number of times if necessary.

    Public Function ftpDownloadWithValidation(ByVal remoteFilePath As String, ByVal localFilePath As String, Optional ByVal numberOfRetries As Integer = 0) As String

        Try
            ftpTransferFileSize = ftp.GetFileLength(remoteFilePath)
        Catch ex As Exception
            Return "Stat on remote file '" & remoteFilePath & "' failed: " & ex.message
        End Try

        Dim baseFileName As String = Path.GetFileName(localFilePath)

        If Not isNonNullString(baseFileName) Then
            Return "Invalid local file path: " & localFilePath
        End If

        Dim tempFileDirectory = TagTrakTempDirectory

        If Not Directory.Exists(tempFileDirectory) Then

            'Modified by MX
            tempFileDirectory = deviceNonVolatileMemoryDirectory & selectedCarrierPath

            If Not Directory.Exists(tempFileDirectory) Then
                Return "Unable to access a temporary file directory for this operation"
            End If

        End If

        Dim tempFilePath As String = tempFileDirectory & backSlash & baseFileName

        updateProgressBar = True

        Dim bytesTransferred As Integer
        Dim remoteFileSize As Integer = ftpTransferFileSize

        transferStatusLabel.Visible = True

        Dim retry As Integer

        ' Note zero starting point fo retry. Note that "retry" means 1 + number of tries so
        ' indexing works out ok.

        For retry = 0 To numberOfRetries

            deleteLocalFile(tempFilePath)

            ftpTransferProgressBar.Value = 0

            Try

                bytesTransferred = ftp.GetFile(remoteFilePath, tempFilePath)

            Catch ex As Exception

                updateProgressBar = False
                transferStatusLabel.Visible = False

                Return "Download failed: " & ex.Message

            End Try

            If bytesTransferred = remoteFileSize Then Exit For

        Next

        If bytesTransferred <> remoteFileSize Then

            updateProgressBar = False
            transferStatusLabel.Visible = False

            Return "Download failed: wrong number of bytes transferred."

        End If

        updateProgressBar = False
        transferStatusLabel.Visible = False

        moveLocalFile(tempFilePath, localFilePath)

        Return "OK"

    End Function


    'File download function for resuming broken transmission-MX
    Public Function ftpDownloadWithResumption(ByVal remoteFilePath As String, ByVal localFilePath As String, Optional ByVal numberOfRetries As Integer = 0) As String

        Dim local As Stream = Nothing
        Dim remoteFileLength As Long
        Dim remoteOffset As Long
        Dim tempFilePath As String

        Try
            remoteFileLength = ftp.GetFileLength(remoteFilePath)
        Catch ex As FtpException
            Return ex.Response.Description
        End Try

        ftpTransferFileSize = remoteFileLength

        If Not Directory.Exists(TagTrakTempDirectory) Then
            Directory.CreateDirectory(TagTrakTempDirectory)
        End If

        tempFilePath = TagTrakTempDirectory & "\" & Path.GetFileName(localFilePath)

        deleteLocalFile(tempFilePath)

        ftpTransferProgressBar.Value = 0

        For i As Integer = 0 To numberOfRetries

            updateProgressBar = True
            transferStatusLabel.Visible = True

            If File.Exists(tempFilePath) Then
                local = File.OpenWrite(tempFilePath)
                local.Seek(0, SeekOrigin.End)
            Else
                local = File.Create(tempFilePath)
            End If

            If local.Length < remoteFileLength Then

                remoteOffset = local.Position

                Try

                    ftp.GetFile(remoteFilePath, local, remoteOffset)

                    updateProgressBar = False
                    transferStatusLabel.Visible = False

                    local.Flush()
                    local.Close()

                    moveLocalFile(tempFilePath, localFilePath)

                    Return "OK"

                Catch ex As Exception

                    updateProgressBar = False

                End Try

            End If

        Next

        Return "Download failed: " & remoteFilePath

    End Function


    ' Routine ftpUploadWithValidation transmits a file from the device to the server with
    ' a check to see if the correct number of bytes have been transmitted. It will retry
    ' the transmission a specified number of times if necessary.

    Public Function ftpUploadWithValidation(ByVal localFilePath As String, ByVal remoteFilePath As String, Optional ByVal numberOfRetries As Integer = 0) As String

#If ValidationLevel >= 3 Then

        If diagnosticLevel >= 2 Then

            verify(Not remoteFilePath Is Nothing, 4043)
            verify(Not localFilePath Is Nothing, 4044)
            verify(numberOfRetries >= 0, 4045)

        End If

#End If

        If Not File.Exists(localFilePath) Then Return "Local file '" & localFilePath & "' does not exist."

        ftpTransferFileSize = getFileSize(localFilePath)

        If ftpTransferFileSize < 0 Then Return "Local file '" & localFilePath & "' does not exist."

        updateProgressBar = True

        Dim bytesTransferred As Integer
        Dim remoteFileSize As Integer = ftpTransferFileSize

        While numberOfRetries >= 0

            ftpTransferProgressBar.Value = 0

            Try

                bytesTransferred = ftp.PutFile(localFilePath, remoteFilePath)

            Catch ex As Exception

                updateProgressBar = False

                Return "Upload failed: " & ex.Message

            End Try

            If bytesTransferred <> remoteFileSize Then

                If numberOfRetries <= 0 Then

                    updateProgressBar = False

                    Return "Upload failed: wrong number of bytes transferred."

                End If

            Else

                updateProgressBar = False

                Return "OK"

            End If

            numberOfRetries -= 1

        End While

        updateProgressBar = False

        Return "OK"

    End Function

    Public Function ftpUploadUniqueWithValidation(ByVal localFilePath As String, Optional ByVal numberOfRetries As Integer = 0) As String

#If ValidationLevel >= 3 Then

        If diagnosticLevel >= 2 Then

            verify(Not localFilePath Is Nothing, 4041)
            verify(numberOfRetries >= 0, 4042)

        End If

#End If

        Dim result As String

        If Not File.Exists(localFilePath) Then Return "Local file '" & localFilePath & "' does not exist."

        ftpTransferFileSize = getFileSize(localFilePath)

        If ftpTransferFileSize < 0 Then Return "Local file '" & localFilePath & "' does not exist."

        updateProgressBar = True

        Dim bytesTransferred As Integer

        While numberOfRetries > 0

            ftpTransferProgressBar.Value = 0

            ignoreResponseReadEvent = False
            ftpResponseString = ""

            Try

                result = ftp.PutUniqueFile(localFilePath)

            Catch ex As Exception

                updateProgressBar = False
                ignoreResponseReadEvent = True
                Return "Upload failed: " & ex.Message

            End Try

            ignoreResponseReadEvent = True

            If ftpResponseString.IndexOf("File successfully transferred") >= 0 Then

                updateProgressBar = False
                Return "OK"

            Else

                If numberOfRetries <= 0 Then

                    updateProgressBar = False
                    Return "Upload failed."

                End If

            End If

            numberOfRetries -= 1

        End While

        ignoreResponseReadEvent = True
        updateProgressBar = False

        Return "OK"

    End Function


    Private Function ftpGetRemoteFileName(ByVal responseString As String) As String

        Dim fileName As String = ""

        If Not isNonNullString(responseString) Then Return "File not found."

        Dim fileNameIndex As Integer = responseString.IndexOf("150 FILE: ")

        If fileNameIndex < 0 Then Return Nothing

        fileNameIndex += Length("150 FILE: ")

        While Char.IsWhiteSpace(responseString.Chars(fileNameIndex))
            fileNameIndex += 1
        End While

        While Not Char.IsWhiteSpace(responseString.Chars(fileNameIndex))
            fileName &= responseString.Chars(fileNameIndex)
            fileNameIndex += 1
        End While

        Return fileName

    End Function

    Public Function ftpWaitForRemoteMD5FileToBeCreated(ByVal remoteFileName As String) As String

        Dim i As Integer

        Dim remoteDirectory As String = ftp.GetCurrentDirectory()

        Dim remoteFileLength As Integer


        For i = 0 To 2

            Try
                remoteFileLength = ftp.GetFileLength(remoteFileName)
            Catch ex As Exception
                remoteFileLength = 0
            End Try

            If remoteFileLength > 0 Then Return "OK"

            System.Threading.Thread.Sleep(500)

        Next

        Return "Cannot find remote file '" & remoteFileName & "' after 3 tries."

    End Function

    Private Function ftpValidateMD5Digest(ByVal remoteFileName As String) As String

        Dim result As String

        If Not usingMD5Validation Then
            Return "OK"
        End If

        If scanLocation.currentLocation Is Nothing Then
            Return "Unable to determine location"
        End If

        remoteFileName = remoteFileName & ".md5"

        result = ftpWaitForRemoteMD5FileToBeCreated(remoteFileName)
        If result <> "OK" Then Return result

        Dim localFilePath As String = TagTrakTempDirectory & "\Digest.txt"

        Try
            ftp.GetFile(remoteFileName, localFilePath)
        Catch ex As Exception
            Return "Digest validation failed: unable to get remote file: " & ex.Message
        End Try

        Dim remoteDigest As String
        Dim bytesRead As Integer

        Dim digestFileStream As StreamReader

        Try
            digestFileStream = New StreamReader(localFilePath)
        Catch ex As Exception
            Return "Digest validation failed: unable to open local digest file: " & ex.Message
        End Try

        Try
            remoteDigest = digestFileStream.ReadLine()
        Catch ex As Exception
            digestFileStream.Close()
            Return "Digest validation failed: unable to get remote file: " & ex.Message
        End Try

        Dim i As Integer

        For i = 0 To 31
            If ftpDigest(i) <> Asc(remoteDigest.Chars(i)) Then
                digestFileStream.Close()
                Return "Digest validation failed: digest values are different."
            End If
        Next

        digestFileStream.Close()

        Return "OK"

    End Function

    Private Function ftpGenerateResditFileDigest(ByVal localFilePath As String) As String

        If Not File.Exists(localFilePath) Then Return "Cannot create digest: input file '" & localFilePath & "' not found."

        Dim fileSize As Integer = getFileSize(localFilePath)

        If fileSize < 0 Then Return "Cannot create digest: input file '" & localFilePath & "' not found."

        Dim inputFileBuffer(fileSize - 1) As Byte

        Dim inputFileStream As FileStream

        Try
            inputFileStream = New FileStream(localFilePath, FileMode.Open)
        Catch ex As Exception
            Return "Cannot create digest: cannot open '" & localFilePath & "': " & ex.Message
        End Try

        Dim bytesRead As Integer

        Try
            bytesRead = inputFileStream.Read(inputFileBuffer, 0, fileSize)
        Catch ex As Exception
            Return "Cannot create digest: read on '" & localFilePath & "' failed: " & ex.Message
        End Try

        scannerLib.md5(inputFileBuffer, fileSize, ftpDigest)

        Return "OK"

    End Function

    Public Function ftpUploadUniqueResditFileWithValidation(ByVal localFilePath As String, Optional ByVal numberOfRetries As Integer = 0) As String

#If ValidationLevel >= 3 Then

        If diagnosticLevel >= 2 Then

            verify(Not localFilePath Is Nothing, 4041)
            verify(numberOfRetries >= 0, 4042)

        End If

#End If

        Dim result As String

        If Not File.Exists(localFilePath) Then Return "Local file '" & localFilePath & "' does not exist."

        ftpTransferFileSize = getFileSize(localFilePath)

        If ftpTransferFileSize < 0 Then Return "Local file '" & localFilePath & "' does not exist."

        'If usingMD5Validation Then
        '    result = ftpGenerateResditFileDigest(localFilePath)
        '    If result <> "OK" Then Return result
        'End If

        Dim bytesTransferred As Integer

        While numberOfRetries >= 0

            updateProgressBar = True
            ftpTransferProgressBar.Value = 0

            ignoreResponseReadEvent = False
            ftpResponseString = ""

            Try

                result = ftp.PutUniqueFile(localFilePath)

            Catch ex As Exception

                updateProgressBar = False
                ignoreResponseReadEvent = True
                Return "Upload failed|" & ex.Message

            End Try

            ignoreResponseReadEvent = True
            updateProgressBar = False

            If ftpResponseString.IndexOf("File successfully transferred") > 0 Then

                Dim remoteFileName As String = ftpGetRemoteFileName(ftpResponseString)

                If Not remoteFileName Is Nothing Then

                    result = ftpValidateMD5Digest(remoteFileName)

                    Dim newRemoteFileName As String = remoteFileName

                    If result = "OK" Then
                        newRemoteFileName &= ".ok"
                    Else
                        newRemoteFileName &= ".bad"
                    End If

                    Try
                        ftp.Rename(remoteFileName, newRemoteFileName)
                    Catch ex As Exception
                        Return "Unable to rename file."
                    End Try

                    If result = "OK" Then Return "OK"

                End If

            End If

            If numberOfRetries < 0 Then

                updateProgressBar = False
                Return "Upload failed."

            End If

            numberOfRetries -= 1

        End While

        ignoreResponseReadEvent = True
        updateProgressBar = False

        Return "OK"

    End Function

    Dim tempResditFileOutputStream As StreamWriter

    Public Sub writeTempResditFileRecord(ByRef outputString As String)

#If ValidationLevel >= 3 Then

        If diagnosticLevel >= 2 Then
            verify(Not outputString Is Nothing, 4000)
        End If

#End If

        Try
            tempResditFileOutputStream.WriteLine(outputString)

        Catch ex As Exception

            Util.systemError("Write to resdit record file failed: " & ex.Message)

        End Try

    End Sub

    ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
    '                                                                              '
    ' Function: generateTemporaryNewRoutingsFile. Returns: status information as   '
    ' a string.                                                                    '
    '                                                                              '
    ' The temporary new routings file is simply a dump of the new routing record   '
    ' set.                                                                         '
    '                                                                              '
    ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

    Public Function generateTemporaryNewRoutingsFile(ByRef localFilePath As String) As String

        Dim outputStream As StreamWriter

        deleteLocalFile(localFilePath)

        Try
            outputStream = New StreamWriter(localFilePath)
        Catch ex As Exception
            Return "Unable to open new routing record output file|" & ex.Message
        End Try

        Dim newRoutingRecord As newRoutingRecordClass

        For Each newRoutingRecord In newRoutingsRecordSet

            Dim newRoutingRecordString As String = newRoutingRecord.ToString

            Try
                outputStream.WriteLine(newRoutingRecordString)
            Catch ex As Exception
                outputStream.Close()
                Return "Write on temporary new routing record file failed|" & ex.Message
            End Try

        Next

        outputStream.Close()

        Return "OK"

    End Function

    Public Function ftpRemoteFileExists(ByVal remoteFileName As String, ByRef remoteFileExists As Boolean) As String

        Dim fileLength As Long

        Try
            fileLength = ftp.GetFileLength(remoteFileName)
        Catch ex As Exception
            remoteFileExists = False
            Return "OK"
        End Try

        If fileLength >= 0 Then
            remoteFileExists = True
            Return "OK"
        End If

        remoteFileExists = False

        Return "OK"

    End Function

    Public Function ftpGetIndexOfFirstExistingRemoteFile(ByVal fileNameArray() As String, ByRef fileNameIndex As Integer) As String

        Dim result As String

        Dim fileName As String
        Dim i As Integer = 0
        Dim remoteFileExists As Boolean

        For Each fileName In fileNameArray

            result = ftpRemoteFileExists(fileName, remoteFileExists)
            If result <> "OK" Then Return "ftpGetIndexOfFirstExistingRemoteFile|" & result

            If remoteFileExists Then
                fileNameIndex = i
                Return "OK"
            End If

            i += 1
        Next

        fileNameIndex = -1

        Return "OK"


    End Function

    ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
    '                                                                              '
    ' Function: ftpUploadNewRoutings.   Returns: status information as a string    '
    '                                                                              '
    ' Note: Status information is a cascaded record of error strings propogated    '
    '       upward from subroutine calls.                                          '
    '                                                                              '
    ' Uploads routings created by the user. The user is prompted to create         '
    ' a routing record when a scan is made of a D and R tag with a routing not     '
    ' included in the USPS routing files.                                          '
    '                                                                              '
    ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

    Public Function ftpUploadNewRoutings() As String

        Dim result As String

        If newRoutingsRecordSet.Count <= 0 Then Return "OK"

        Dim localFilePath As String = TagTrakTempDirectory & "\NewRoutings.txt"

        result = generateTemporaryNewRoutingsFile(localFilePath)
        If result <> "OK" Then

            result = "ftpUploadNewRoutings|Unable to create temporary new routings file|" & result

            Me.ftpDisplaySystemError("Unable to create temporary new routings file", result)
            Return result

        End If

        Dim newRoutingRecordFileSize As Integer = getFileSize("NewRoutings.txt", TagTrakTempDirectory)

        If newRoutingRecordFileSize < 0 Then

            result = "ftpUploadNewRoutings|Creation of temporary new routing record file failed|" & result

            Me.ftpDisplaySystemError("Creation of temporary new routing record file failed", result)
            Return result

        End If

        Application.DoEvents()

        updateProgressBar = True

        transferStatusLabel.Text = "Uploading New Routing File"
        transferStatusLabel.Visible = True

        Application.DoEvents()

        Dim uploadFilePath As String = userSpecRecord.userName & ".Routings." & deviceSerialNumber & String.Format(".{0:yyMMdd.HHmmss}.txt", DateTime.UtcNow())

        While True

            result = ftpUploadWithValidation(localFilePath, uploadFilePath, 2)
            If result = "OK" Then Exit While

            result = "ftpUploadNewRoutings|" & result

            Dim dialogResult As String = ftpDisplayUploadDownloadProcessError(result)
            If dialogResult <> "OK" Then Return result

        End While

        newRoutingsRecordSet.Clear()

        Return "OK"

    End Function

    Private Function ftpGetUploadSequenceNumber() As Integer

        Dim returnValue As Integer

        Dim uploadSequenceNumberFilepath As String = TagTrakConfigDirectory & "\" & userSpecRecord.userName & "UploadSequenceNumberFile.txt"

        If Not File.Exists(uploadSequenceNumberFilepath) Then
            Return 1
        End If

        Dim uploadSequenceNumberInputStream As StreamReader

        Try
            uploadSequenceNumberInputStream = New StreamReader(uploadSequenceNumberFilepath)
        Catch ex As Exception
            Return -1
        End Try

        Dim uploadSequenceNumberString As String

        Try
            uploadSequenceNumberString = uploadSequenceNumberInputStream.ReadLine()
        Catch ex As Exception
            uploadSequenceNumberInputStream.Close()
            Return -2
        End Try

        If uploadSequenceNumberString Is Nothing Then
            uploadSequenceNumberInputStream.Close()
            Return -3
        End If

        Try
            returnValue = CInt(Trim(uploadSequenceNumberString))
        Catch ex As Exception
            uploadSequenceNumberInputStream.Close()
            Return -4
        End Try

        uploadSequenceNumberInputStream.Close()

        Return returnValue

    End Function

    Private Function ftpSaveUploadSequenceNumber(ByVal uploadSequenceNumber As Integer) As String

        Dim uploadSequenceNumberFilepath As String = TagTrakConfigDirectory & "\" & userSpecRecord.userName & "UploadSequenceNumberFile.txt"

        deleteLocalFile(uploadSequenceNumberFilepath)

        Dim uploadSequenceNumberOutputStream As StreamWriter

        Try
            uploadSequenceNumberOutputStream = New StreamWriter(uploadSequenceNumberFilepath)
        Catch ex As Exception
            Return "Open on upload sequence number file failed: " & ex.Message
        End Try

        Dim uploadSequenceNumberString As String = CStr(userSpecRecord.uploadSequenceNumber)

        Try
            uploadSequenceNumberOutputStream.WriteLine(uploadSequenceNumberString)
        Catch ex As Exception
            uploadSequenceNumberOutputStream.Close()
            Return "Write on upload sequence number file failed: " & ex.Message
        End Try

        uploadSequenceNumberOutputStream.Close()

        Return "OK"

    End Function

    Public Function generateTempResditFile() As String

        '' IMPORTANT: When changing the format of the Resdit, update the "ResditVersion" constant.

        Dim tempResditFilePath As String = TagTrakTempDirectory & "\" & userSpecRecord.userName & "TempMailDataFile.txt"
        Dim currResditFilePath As String

        If primaryDataFileDirectoryIsValid Then
            currResditFilePath = scanDataPrimaryFilePath
        ElseIf secondaryDataFileDirectoryIsValid Then
            currResditFilePath = scanDataSecondaryFilePath
        Else
            Return "No Resdit file directory available"
        End If

        Dim resditFileInputStream As StreamReader

        deleteLocalFile(tempResditFilePath)

        Try
            tempResditFileOutputStream = New StreamWriter(tempResditFilePath)
        Catch ex As Exception
            Return "Unable to open resdit header file for output|" & ex.message
        End Try

        '' IMPORTANT: When changing the format of the Resdit, update the "ResditVersion" constant.

        Dim outputFormatVersion As String = "Format Version:"
        Dim outputCarrierSpec As String = "Carrier:"
        Dim outputLocationSpec As String = "Location:"
        Dim outputScannerTimeSpec As String = "Scanner Date And Time:"
        Dim outputServerTimeSpec As String = "Server Date And Time:"
        Dim outputScannerUTCOffsetSpec As String = "Scanner UTC Offset:"
        Dim outputServerUTCOffsetSpec As String = "Server UTC Offset:"
        Dim outputIsUTCMixedSpec As String = "Mixed Scanner UTC Offset:"
        Dim outputDeviceTypeSpec As String = "Device Type:"
        Dim outputDeviceSerialNumberSpec As String = "Serial Number:"
        Dim outputVersionNumberSpec As String = "Version Number:"
        Dim outputUploadSequenceNumberSpec As String = "Upload Sequence Number:"
        Dim outputLastTimeQuerySpec As String = "Last Time Query:"
        Dim outputNTPServerSpec As String = "NTP Server:"

        userSpecRecord.uploadSequenceNumber = ftpGetUploadSequenceNumber()

        outputFormatVersion &= ResditVersion.ToString
        outputCarrierSpec = outputCarrierSpec & userSpecRecord.carrierCode.ToUpper
        outputLocationSpec = outputLocationSpec & Trim(Substring(scanLocation.currentLocation, 0, 3))
        outputScannerTimeSpec = outputScannerTimeSpec & String.Format("{0:yyyy-MM-dd" & TagTrakGlobals.fieldSepChar & "HH:mm:ss}", scannerDateAndTimeUTC)
        outputServerTimeSpec = outputServerTimeSpec & String.Format("{0:yyyy-MM-dd" & TagTrakGlobals.fieldSepChar & "HH:mm:ss}", serverDateAndTimeUTC)
        If Double.IsNaN(userSpecRecord.scanRecordSet.TimeZoneUsed.OffsetUTC) = False Then
            outputScannerUTCOffsetSpec &= userSpecRecord.scanRecordSet.TimeZoneUsed.OffsetUTC.ToString
            outputIsUTCMixedSpec &= userSpecRecord.scanRecordSet.TimeZoneUsed.IsMixed.ToString
        Else
            outputScannerUTCOffsetSpec = ""
            outputIsUTCMixedSpec = ""
        End If
        If scannerTimeZone.OffsetInfo.Confidence >= Time.TimeZone.Offset.ConfidenceLevels.LoadedFromFile Then
            outputServerUTCOffsetSpec &= scannerTimeZone.OffsetInfo.OffsetUTC.ToString
        Else
            outputServerUTCOffsetSpec = ""
        End If
        outputDeviceTypeSpec = outputDeviceTypeSpec & device
        outputDeviceSerialNumberSpec = outputDeviceSerialNumberSpec & deviceSerialNumber
        outputVersionNumberSpec = outputVersionNumberSpec & myVersion
        outputUploadSequenceNumberSpec = outputUploadSequenceNumberSpec & CStr(userSpecRecord.uploadSequenceNumber)
        outputLastTimeQuerySpec &= TagTrakGlobals.lastTimeSync.ToString
        If TagTrakGlobals.lastTimeSync = TagTrakGlobals.TimeSyncTypes.NTP Then
            outputNTPServerSpec &= TagTrakGlobals.serverDateAndTimeSource
        End If

        writeTempResditFileRecord(outputFormatVersion)
        writeTempResditFileRecord(outputCarrierSpec)
        writeTempResditFileRecord(outputLocationSpec)
        writeTempResditFileRecord(outputScannerTimeSpec)
        writeTempResditFileRecord(outputServerTimeSpec)
        If outputScannerUTCOffsetSpec <> "" Then writeTempResditFileRecord(outputScannerUTCOffsetSpec)
        If outputIsUTCMixedSpec <> "" Then writeTempResditFileRecord(outputIsUTCMixedSpec)
        If outputServerUTCOffsetSpec <> "" Then writeTempResditFileRecord(outputServerUTCOffsetSpec)
        writeTempResditFileRecord(outputDeviceTypeSpec)
        writeTempResditFileRecord(outputDeviceSerialNumberSpec)
        writeTempResditFileRecord(outputVersionNumberSpec)
        writeTempResditFileRecord(outputUploadSequenceNumberSpec)
        writeTempResditFileRecord(outputLastTimeQuerySpec)
        If TagTrakGlobals.lastTimeSync = TagTrakGlobals.TimeSyncTypes.NTP Then
            writeTempResditFileRecord(outputNTPServerSpec)
        End If

        'Added by MX for attaching login and logout record
        Dim accessLogFilePath As String = TagTrakConfigDirectory & "\AccessLog.txt"

        If File.Exists(accessLogFilePath) Then

            Dim sr As StreamReader

            Try
                sr = New StreamReader(accessLogFilePath)
            Catch ex As Exception
                Return "Unable to open login/logout file for read|" & ex.Message
            End Try

            Dim accessLogRecord As String

            Try
                accessLogRecord = sr.ReadLine()
            Catch ex As Exception
                Return "Read on accesslog file failed|" & ex.Message
            End Try

            While Not accessLogRecord Is Nothing

                writeTempResditFileRecord(accessLogRecord)

                Try
                    accessLogRecord = sr.ReadLine()
                Catch ex As Exception
                    Return "Read on accesslog file failed|" & ex.Message
                End Try

            End While

            sr.Close()

        End If


        Dim rerouteRecordFound As Boolean = False

        Dim presetRecord As presetRecordClass
        Dim outputRecord As String

        Dim result As String
        Dim presetsList As New ArrayList

        result = loadPresetListFromFile(userSpecRecord, presetsList, Nothing)
        If result <> "OK" Then Return "Load of preset file failed|" & result

        For Each presetRecord In presetsList

            If presetRecord.isReroutePreset Then

                rerouteRecordFound = True

                outputRecord = "Preset+Reroute:"

            Else

                outputRecord = "Preset:"

            End If

            outputRecord &= presetRecord.formatForUpload

            writeTempResditFileRecord(outputRecord)

        Next

        If File.Exists(binChangeFilePath) Then

            Dim binChangeInputStream As StreamReader

            Try
                binChangeInputStream = New StreamReader(binChangeFilePath)
            Catch ex As Exception
                Return "Unable to open cart change file for read|" & ex.Message
            End Try

            Dim binChangeInputString As String

            Try
                binChangeInputString = binChangeInputStream.ReadLine()
            Catch ex As Exception
                Return "Read on cart change file failed|" & ex.Message
            End Try

            While Not binChangeInputString Is Nothing

                Dim binChangeOutputString As String = "Cart Change:" & binChangeInputString
                writeTempResditFileRecord(binChangeOutputString)

                Try
                    binChangeInputString = binChangeInputStream.ReadLine()
                Catch ex As Exception
                    Return "Read on Cart change file failed|" & ex.Message
                End Try

            End While

            binChangeInputStream.Close()

        End If

        If File.Exists(binUploadFilePath) Then

            Dim binUploadInputStream As StreamReader

            Try
                binUploadInputStream = New StreamReader(binUploadFilePath)
            Catch ex As Exception
                Return "Unable to open cart upload file for read|" & ex.Message
            End Try

            Dim binUploadInputString As String

            Try
                binUploadInputString = binUploadInputStream.ReadLine()
            Catch ex As Exception
                Return "Read on cart upload file failed|" & ex.Message
            End Try

            While Not binUploadInputString Is Nothing

                Dim binUploadOutputString As String = "Cart Upload:" & binUploadInputString
                writeTempResditFileRecord(binUploadOutputString)

                Try
                    binUploadInputString = binUploadInputStream.ReadLine()
                Catch ex As Exception
                    Return "Read on cart change file failed|" & ex.Message
                End Try

            End While

            binUploadInputStream.Close()

        End If

        If File.Exists(manifestFilePath) Then

            Dim manifestInputStream As StreamReader

            Try
                manifestInputStream = New StreamReader(manifestFilePath)
            Catch ex As Exception
                Return "Unable to open manifest file for read|" & ex.Message
            End Try

            Dim manifestInputString As String

            Try
                manifestInputString = manifestInputStream.ReadLine()
            Catch ex As Exception
                Return "Read on manifest file failed|" & ex.Message
            End Try

            While Not manifestInputString Is Nothing

                Dim manifestOutputString As String = "Manifest:" & manifestInputString
                writeTempResditFileRecord(manifestOutputString)

                Try
                    manifestInputString = manifestInputStream.ReadLine()
                Catch ex As Exception
                    Return "Read on manifest file failed|" & ex.Message
                End Try

            End While

            manifestInputStream.Close()

        End If

        If File.Exists(flightStatusFilePath) Then

            Dim inputStream As StreamReader

            Try
                inputStream = New StreamReader(flightStatusFilePath)
            Catch ex As Exception
                Return "Unable to open flight status file for read|" & ex.Message
            End Try

            Dim inputString As String

            Try
                inputString = inputStream.ReadLine()
            Catch ex As Exception
                Return "Read on flight status file failed|" & ex.Message
            End Try

            While Not inputString Is Nothing

                Dim outputString As String = "Flight Status:" & inputString
                writeTempResditFileRecord(outputString)

                Try
                    inputString = inputStream.ReadLine()
                Catch ex As Exception
                    Return "Read on flight status file failed|" & ex.Message
                End Try

            End While

            inputStream.Close()

        End If

        Dim scanRecord As scanRecordClass

        For Each scanRecord In userSpecRecord.scanRecordSet.Values

            Dim duplicateScanCount As String = CStr(scanRecord.duplicateCount)

            If scanRecord.duplicateCount > 0 Then
                writeTempResditFileRecord("Duplicate Scan:" & scanRecord.duplicateCount & TagTrakGlobals.fieldSepChar & scanRecord.ToString)
            End If

        Next

        If File.Exists(carditRoutingFilePath) Then

            Dim inputStream As StreamReader

            Try
                inputStream = New StreamReader(carditRoutingFilePath)
            Catch ex As Exception
                Return "Open on new cardit routing file failed|" + ex.Message
            End Try

            Dim inputString As String

            Try
                inputString = inputStream.ReadLine()
            Catch ex As Exception
                Return "Read on new cardit routing file failed|" + ex.Message
            End Try

            While Not inputString Is Nothing

                Dim outputString As String = "CarditRouting:" & inputString
                writeTempResditFileRecord(outputString)

                Try
                    inputString = inputStream.ReadLine()
                Catch ex As Exception
                    Return "Read on new cardit routing file failed|" + ex.Message
                End Try

            End While

            inputStream.Close()

        End If

        If File.Exists(fullCartUnloadFilePath) Then
            Dim inputStream As StreamReader

            Try
                inputStream = New StreamReader(fullCartUnloadFilePath)
            Catch ex As Exception
                Return "Open on full cart unload file failed|" + ex.Message
            End Try

            Dim inputString As String

            Try
                inputString = inputStream.ReadLine()
            Catch ex As Exception
                Return "Read on full cart unload file failed|" + ex.Message
            End Try

            While Not inputString Is Nothing

                Dim outputString As String = "Cart Unload:" & inputString
                writeTempResditFileRecord(outputString)

                Try
                    inputString = inputStream.ReadLine()
                Catch ex As Exception
                    Return "Read on full cart unload file failed|" + ex.Message
                End Try

            End While

            inputStream.Close()

        End If

        '' Write "Flight Unload" header records
        If File.Exists(fullFlightUnloadFilePath) Then
            Dim inputStream As StreamReader

            Try
                inputStream = New StreamReader(fullFlightUnloadFilePath)
            Catch ex As Exception
                Return "Open on full flight unload file failed|" + ex.Message
            End Try

            Dim inputString As String

            Try
                inputString = inputStream.ReadLine()
            Catch ex As Exception
                Return "Read on full flight unload file failed|" + ex.Message
            End Try

            While Not inputString Is Nothing

                Dim outputString As String = "Flight Unload:" & inputString
                writeTempResditFileRecord(outputString)

                Try
                    inputString = inputStream.ReadLine()
                Catch ex As Exception
                    Return "Read on full flight unload file failed|" + ex.Message
                End Try

            End While

            inputStream.Close()

        End If

        'writeTempResditFileRecord("********  END OF RESDIT HEADER INFORMATION  ********")
        writeTempResditFileRecord("")

        If File.Exists(currResditFilePath) Then

            Try
                resditFileInputStream = New StreamReader(currResditFilePath)
            Catch ex As Exception
                Return "Open on resdit file failed|" & ex.Message
            End Try

            Dim resditRecord As String

            resditRecord = resditFileInputStream.ReadLine

            While Not resditRecord Is Nothing

                writeTempResditFileRecord(resditRecord)
                resditRecord = resditFileInputStream.ReadLine

            End While

            resditFileInputStream.Close()

        End If

        tempResditFileOutputStream.Close()

        Dim finalTempResditFilePath As String = TagTrakTempDirectory & "\TempResditFile.txt"

        If usingEncryption Then
            encryptFile(tempResditFilePath, finalTempResditFilePath)
        Else
            moveLocalFile(tempResditFilePath, finalTempResditFilePath)
        End If

        Return "OK"

    End Function

    ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
    '                                                                              '
    ' Function: ftpUploadResditFile. Returns: status information as a string       '
    '                                                                              '
    ' Note: Status information is a cascaded record of error strings propogated    '
    '       upward from subroutine calls.                                          '
    '                                                                              '
    ' Uploads a 'resdit file'. The resdit file contains a set of one or more       '
    ' resdit records. Over time, however, other information was included into      '
    ' the resdit file for upload. This includes:                                   '
    '                                                                              '
    ' 1. Preset records                                                            '
    ' 2. Bin Change Records                                                        '
    ' 3. Bin Upload Records                                                        '
    ' 4. Manifest Records                                                          '
    '                                                                              '
    ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

    Public Function ftpUploadResditFile() As String

        Dim result As String
        Dim rerouteFlag As Boolean = False

        If Not (File.Exists(binChangeFilePath) _
             Or File.Exists(binUploadFilePath) _
             Or File.Exists(scanDataPrimaryFilePath) _
             Or File.Exists(manifestFilePath) _
             Or File.Exists(flightStatusFilePath) _
             Or File.Exists(scanDataSecondaryFilePath) _
             Or File.Exists(carditRoutingFilePath) _
             Or File.Exists(fullFlightUnloadFilePath) _
             Or File.Exists(fullCartUnloadFilePath)) Then

            If Not userSpecRecord.sendRerouteHeader Then

                Return "OK"

            Else

                If userSpecRecord.presetList.Count = 0 Then
                    Return "OK"
                Else

                    Dim presetRecord As presetRecordClass

                    For Each presetRecord In userSpecRecord.presetList
                        If presetRecord.isReroutePreset() Then
                            rerouteFlag = True
                            Exit For
                        End If
                    Next

                    If Not rerouteFlag Then
                        Return "OK"
                    End If

                End If

            End If

        End If

        ftp.Timeout = 60000

        ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
        ' Reset remote directory to log in root directory.                         '
        ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

        While True

            result = ftpChangeToRootDirectory()
            If result = "OK" Then Exit While

            result = "ftpUploadResditFile|" & result

            Dim dialogResult As String = ftpDisplayUploadDownloadProcessError(result)
            If dialogResult <> "OK" Then Return result

        End While

        Dim uploadResditFileDirectory As String

        uploadResditFileDirectory = Path.GetDirectoryName(scanDataPrimaryFilePath)

        Application.DoEvents()

        ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
        ' Generate the full resdit file as a temporary file. This version of the   '
        ' resdit file includes all the auxillary information, such as bin upload   '
        ' bin change, and manifest information. It is a disk image of the file     '
        ' that will ultimately be transmitted to the server.                       '
        ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

        Dim tempResditFilePath As String = TagTrakTempDirectory & "\TempResditFile.txt"

        result = generateTempResditFile()
        If result <> "OK" Then
            ftpDisplaySystemError("Creation of temporary resdit file failed", "ftpUploadResditFile|Creation of temporary resdit file failed|" & result)
            Return result
        End If

        ftpTransferFileSize = getFileSize("TempResditFile.txt", TagTrakTempDirectory)

        If ftpTransferFileSize < 0 Then
            result = "ftpUploadResditFile|Creation of temporary resdit file failed|failure to stat temporary file"
            ftpDisplaySystemError("Resdit file upload failed", result)
            Return result
        End If

        updateProgressBar = True

        ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
        ' Create and change remote directory to the remote directory in which the  '
        ' current resdit file will be placed. If the remote directory does not     '
        ' exist on the server, it is created first.                                '
        ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

        Dim currentLocation As String = Substring(scanLocation.currentLocation, 0, 3)

        If Not isNonNullString(currentLocation) Then
            result = "ftpUploadResditFile|Resdit file upload failed|Invalid scan location"
            ftpDisplaySystemError("Resdit file upload failed", result)
            Return result
        End If

        If Length(currentLocation) <> 3 Then
            result = "ftpUploadResditFile|Resdit file upload failed|Invalid scan location"
            ftpDisplaySystemError("Resdit file upload failed", result)
            Return result
        End If

        While True

            result = ftpCreateDirectoryIfNecessary(currentLocation)
            If result = "OK" Then Exit While

            result = "ftpUploadResditFile|" & result

            Dim dialogResult As String = ftpDisplayUploadDownloadProcessError(result)
            If dialogResult <> "OK" Then Return result

        End While

        While True

            result = ftpChangeRemoteDirectory(currentLocation)
            If result = "OK" Then Exit While

            result = "ftpUploadResditFile|" & result

            Dim dialogResult As String = ftpDisplayUploadDownloadProcessError(result)
            If dialogResult <> "OK" Then Return result

        End While

        ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
        ' At this point all the groundwork necessary for uploading resdit          '
        ' related information has been completed. The next section actually        '
        ' uploads the information.                                                 '
        ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

        transferStatusLabel.Text = "Uploading Scanner File"
        transferStatusLabel.Visible = True

        Application.DoEvents()

        While True

            result = ftpUploadUniqueResditFileWithValidation(tempResditFilePath, 2)
            If result = "OK" Then Exit While

            result = "ftpUploadResditFile|" & result

            Dim dialogResult As String = ftpDisplayUploadDownloadProcessError("Upload of resdit file failed|" & result)
            If dialogResult <> "OK" Then Return result

        End While

        ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
        ' Resdit file information has been successfully uploaded to the server.    '
        ' Now reset all internal files and state variables so that only new data   '
        ' is collected.                                                            '
        ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

        deleteLocalFile(scanDataPrimaryFilePath)
        deleteLocalFile(scanDataSecondaryFilePath)
        deleteLocalFile(binChangeFilePath)
        deleteLocalFile(binUploadFilePath)
        deleteLocalFile(manifestFilePath)
        deleteLocalFile(flightStatusFilePath)
        deleteLocalFile(carditRoutingFilePath)
        deleteLocalFile(fullCartUnloadFilePath)
        deleteLocalFile(fullFlightUnloadFilePath)

        'Added by MX to delete 
        deleteLocalFile(TagTrakConfigDirectory & "\AccessLog.txt")

        userSpecRecord.uploadSequenceNumber += 1

        ftpSaveUploadSequenceNumber(userSpecRecord.uploadSequenceNumber)

        uploadReminderMinuteCount = 120

        '' Reset the time zone info for scans
        userSpecRecord.scanRecordSet.TimeZoneUsed.Reset()

        Dim currentDateAndTime As DateTime = Time.Local.GetTime(scannerTimeZone)
        Dim resditBackupFilePath As String = TagTrakBackupDirectory & "\" & userSpecRecord.userName & String.Format("MailDataBkup.{0:yyMMdd}.{0:HHmmss}.txt", currentDateAndTime, currentDateAndTime)

        copyLocalFile(tempResditFilePath, resditBackupFilePath)

        deleteLocalFile(tempResditFilePath)

        removeExpiredBackupResditFiles()

        Return "OK"

    End Function

    Public Function ftpUploadResditFileToServer(ByVal localFilePath As String, ByVal remoteFilePath As String, Optional ByVal uniqueFileNameOnServer As Boolean = False) As String

#If ValidationLevel >= 3 Then

        If diagnosticLevel >= 2 Then

            verify(Not remoteFilePath Is Nothing, 4060)
            verify(Not localFilePath Is Nothing, 4061)

        End If

#End If

        Dim result As String

        ' Known bugs: function will not work if remote directory path is longer than 1 directory.

        If Not isNonNullString(localFilePath) Then Return "Null file name passed to ftpUploadFileToServer"

        If Not File.Exists(localFilePath) Then Return "File '" & localFilePath & "' not found."

        result = ftpChangeToRootDirectory() : If result <> "OK" Then Return result

        ftpTransferFileSize = getFileSize(localFilePath)

        If uniqueFileNameOnServer Then

            ' It is assumed under these circumstances that the remote file path is actually a directory name

            If isNonNullString(remoteFilePath) Then

                If Not (remoteFilePath = backSlash And remoteFilePath = "/") Then

                    result = ftpCreateDirectoryIfNecessary(remoteFilePath)

                    If result <> "OK" Then Return result

                    Try
                        ftp.ChangeDirectory(remoteFilePath)
                    Catch ex As Exception
                        Return "Directory Change Failed:" & ex.message
                    End Try
                End If

            End If

            transferStatusLabel.Text = "Uploading File"
            transferStatusLabel.Visible = True

            Application.DoEvents()

            result = ftpUploadUniqueWithValidation(localFilePath, 2)

            If result <> "OK" Then
                Return "Upload of file '" & localFilePath & "' failed: " & result
            End If

        Else

            If Not isNonNullString(remoteFilePath) Then
                Return "Null remote file path."
            End If

            Dim fileName As String = Path.GetFileName(remoteFilePath)
            Dim filePath As String = Path.GetDirectoryName(remoteFilePath)

            If Not isNonNullString(fileName) Then
                Return "Null file name."
            End If

            If isNonNullString(filePath) Then

                If Not (filePath = backSlash And filePath = "/") Then

                    result = ftpCreateDirectoryIfNecessary(filePath)

                    If result <> "OK" Then Return result

                    Try
                        ftp.ChangeDirectory(filePath)
                    Catch ex As Exception
                        Return "Directory Change Failed: " & ex.message
                    End Try

                End If
            End If

            transferStatusLabel.Text = "Uploading File"
            transferStatusLabel.Visible = True

            Application.DoEvents()

            While True

                result = ftpUploadWithValidation(localFilePath, fileName, 2)
                If result = "OK" Then Exit While

                Dim dialogResult As String = ftpDisplayUploadDownloadProcessError(result)
                If dialogResult <> "OK" Then Return result

            End While

        End If

        updateProgressBar = False

        Return "OK"

    End Function

    Public Function ftpUploadFileToServer(ByVal localFilePath As String, ByVal remoteFilePath As String) As String

#If ValidationLevel >= 3 Then

        If diagnosticLevel >= 2 Then

            verify(Not remoteFilePath Is Nothing, 4070)
            verify(Not localFilePath Is Nothing, 4071)

        End If

#End If

        Dim result As String
        Dim bytesTransferred As Integer

        ' Known bugs: function will not work if remote directory path is longer than 1 directory.

        If Not isNonNullString(remoteFilePath) Then Return "Null remote file path passed to ftpDownloadFileFromServer"
        If Not isNonNullString(localFilePath) Then Return "Null local file path passed to ftpDownloadFileFromServer"

        ftpTransferFileSize = getFileSize(localFilePath)

        If ftpTransferFileSize < 0 Then
            Return "Cannot stat local file"
        End If

        transferStatusLabel.Text = "Uploading File"
        transferStatusLabel.Visible = True

        Application.DoEvents()

        result = ftpUploadWithValidation(localFilePath, remoteFilePath)

        If result <> "OK" Then
            Return "Transfer of local file failed: " & result
        End If

        Return "OK"

    End Function

    Public Function ftpDownloadFileFromServer(ByVal remoteFilePath As String, ByVal localFilePath As String) As String

        Dim result As String

        ' Known bugs: function will not work if remote directory path is longer than 1 directory.

        If Not isNonNullString(remoteFilePath) Then Return "Null remote file path passed to ftpDownloadFileFromServer"
        If Not isNonNullString(localFilePath) Then Return "Null local file path passed to ftpDownloadFileFromServer"

        transferStatusLabel.Visible = False
        transferStatusLabel.Text = "Downloading File"

        Application.DoEvents()

        Try
            ftp.GetFile(remoteFilePath, localFilePath)
        Catch ex As Exception
            Return "Download failed: " & ex.Message
        End Try

        updateProgressBar = False

        Return "OK"

    End Function

    ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
    '                                                                              '
    ' Function: ftpGetProgramVersionNumber. Returns: status information as a       '
    '           string. Returns through reference the first version number found   '
    '           and the path on the server to the remote version file.             '
    '                                                                              '
    ' Note: Status information is a cascaded record of error strings propogated    '
    '       upward from subroutine calls.                                          '
    '                                                                              '
    ' The function downloads and reads the first instance of a version config      '
    ' file found on the server and uses this to generate the current version       '
    ' number. It returns the current version number along with the path on the     '
    ' server from which this version number was obtained.                          '
    '                                                                              '
    ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

    Public Function ftpGetVersionNumber(ByRef currentVersionNumber As String, ByRef currentVersionPath As String, _
                                               ByRef configVersionNumber As String, ByRef configVersionPath As String) As String

        Dim result As String

        'Dim rxProgram As New Regex("^TagTrak\.\d{4}\.\d{2}\.\d{2}\.\d{2}\.cab$")
        'Dim rxConfig As New Regex("^DependentFiles\." & TagTrakBaseConfigParms.user & "\.\d{4}\.\d{2}\.\d{2}\.\d{2}\.\d{2}\.cab$")
        Dim rxProgram As New Regex("^TagTrak\.\d+\.\d+\.\d+\.\d+\.cab$")
        Dim rxConfig As New Regex("^DependentFiles\." & TagTrakBaseConfigParms.user & "\.\d+\.\d+\.\d+\.\d+\.\d+\.cab$")

        'This is a one time change, will be removed from next upgrade.
        Dim rxOldProgram As New Regex("^TagTrak\.\d{4}\.\d{2}\.\d{2}\.\d{2}\.cab$")

        currentVersionNumber = ""
        currentVersionPath = ""
        configVersionNumber = ""
        configVersionPath = ""

        'Dim fileNameArray(7) As String
        Dim pathNameArray(2) As String

        ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
        ' Generate a list of possible remote file paths for files that may contain '
        ' the current version number. A search is conducted on the server for the  '
        ' first existing file in this list. The result of this search also determ- '
        ' ines where the updated program will be taken from.                       '
        ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

        ' Note fileNameArray and pathNameArray must be re-initialized here and can '
        ' not be statically defined. First, some of the values (e.g. deviceSerial- '
        ' Number) are not set at program load. Second, the values may change as a  '
        ' result of user config changes.                                           '

        'Modified by MX
        'fileNameArray(0) = "Serial/SN" & deviceSerialNumber & "/VersionConfig.txt"
        'fileNameArray(1) = "Serial/SN" & deviceSerialNumber & "/ScannerVersionConfig.txt"
        'fileNameArray(2) = scanLocation.currentLocation & "/VersionConfig.txt"
        'fileNameArray(3) = scanLocation.currentLocation & "/ScannerVersionConfig.txt"
        'fileNameArray(4) = "VersionConfig.txt"
        'fileNameArray(5) = "ScannerVersionConfig.txt"
        'fileNameArray(6) = userSpecRecord.userName & "VersionConfig.txt"
        'fileNameArray(7) = userSpecRecord.userName & "ScannerVersionConfig.txt"

        'pathNameArray(0) = "Serial/SN" & deviceSerialNumber
        'pathNameArray(1) = "Serial/SN" & deviceSerialNumber
        'pathNameArray(2) = scanLocation.currentLocation
        'pathNameArray(3) = scanLocation.currentLocation
        'pathNameArray(4) = ""
        'pathNameArray(5) = ""
        'pathNameArray(6) = ""
        'pathNameArray(7) = ""

        pathNameArray(0) = "Serial/SN" & deviceSerialNumber
        pathNameArray(1) = scanLocation.currentLocation
        pathNameArray(2) = ""

        For Each path As String In pathNameArray

            Dim ftpNameList() As String
            Dim nameItem As String

            Try
                ftpNameList = ftp.GetNameList(path)
            Catch ex As Exception
                result = ex.Message
                'Return result
                ftpNameList = Nothing
            End Try

            If Not ftpNameList Is Nothing Then

                For Each nameItem In ftpNameList

                    Dim splitArray() As String = Nothing
                    splitArray = nameItem.Split("/")

                    Dim fileName As String = splitArray(splitArray.Length - 1)

                    If rxProgram.IsMatch(fileName) Then

                        If Not rxOldProgram.IsMatch(fileName) Then

                            Dim verArray() As String = fileName.Split(".")

                            currentVersionNumber = verArray(1) & "." & verArray(2) & "." & verArray(3) & "." & verArray(4)
                            currentVersionPath = path

                        End If

                    ElseIf rxConfig.IsMatch(fileName) Then

                        Dim configArray() As String = fileName.Split(".")

                        configVersionNumber = configArray(2) & "." & configArray(3) & "." & configArray(4) & "." & configArray(5) & "." & configArray(6)
                        configVersionPath = path

                    End If

                Next

            End If

        Next

        'Dim fileNameIndex As Integer

        'result = ftpGetIndexOfFirstExistingRemoteFile(fileNameArray, fileNameIndex)
        'If result <> "OK" Then Return result

        'If fileNameIndex < 0 Then
        '    currentVersionNumber = "0000.00.00.00"
        '    currentVersionPath = ""

        '    Return "OK"
        'End If

        'Dim remoteConfigFileName As String = fileNameArray(fileNameIndex)

        'Dim remoteFileDateStamp As DateTime
        'Dim localFileDateStamp As DateTime

        'result = ftpGetRemoteFileDateStamp(remoteConfigFileName, remoteFileDateStamp)
        'If result <> "OK" Then Return "ftpGetProgramVersionNumber|" & result

        'Dim dateStampFilePath As String = TagTrakConfigDirectory & "\VersionConfigDateStamp.txt"
        'Dim versionFilePath As String = TagTrakConfigDirectory & "\VersionConfig.txt"

        'Dim newVersionConfigNeeded As Boolean = True

        'If File.Exists(dateStampFilePath) And File.Exists(versionFilePath) Then

        '    result = getDateStampFromDateStampFile(dateStampFilePath, localFileDateStamp)
        '    If result <> "OK" Then Return "ftpGetProgramVersionNumber|" & result

        '    If DateTime.Compare(localFileDateStamp, remoteFileDateStamp) >= 0 Then
        '        newVersionConfigNeeded = False
        '    End If

        'End If

        'If newVersionConfigNeeded Then

        '    transferStatusLabel.Visible = False
        '    transferStatusLabel.Text = "Downloading Program Version Information"

        '    Application.DoEvents()

        '    Dim bytesTransferred As Integer

        '    result = ftpDownloadWithValidation(remoteConfigFileName, versionFilePath, 2)
        '    If result <> "OK" Then
        '        currentVersionNumber = "0000.00.00.00"
        '        Return "ftpGetProgramVersionNumber|" & result
        '    End If

        '    result = saveDateStampToDateStampFile(remoteFileDateStamp, dateStampFilePath)
        '    If result <> "OK" Then Return "ftpGetProgramVersionNumber|" & result

        'End If

        'Dim configFileInputStream As StreamReader

        'Try

        '    configFileInputStream = New StreamReader(versionFilePath)

        'Catch ex As Exception

        '    configFileInputStream.Close()

        '    currentVersionNumber = "0000.00.00.00"
        '    currentVersionPath = ""

        '    Return "ftpGetProgramVersionNumber|Open on local version config file failed|" & ex.Message

        'End Try

        'Dim inputLine As String

        'Try

        '    inputLine = configFileInputStream.ReadLine()

        'Catch ex As Exception

        '    configFileInputStream.Close()

        '    currentVersionNumber = "0000.00.00.00"
        '    currentVersionPath = ""

        '    Return "ftpGetProgramVersionNumber|Read on local version config file failed|" & ex.Message

        'End Try

        'configFileInputStream.Close()

        'If Not inputLine.StartsWith("CurrentVersionNumber=") Then

        '    currentVersionNumber = "0000.00.00.00"
        '    configFileInputStream.Close()

        '    Return "ftpGetProgramVersionNumber|Invalid data '" & inputLine & "' found in version config file"

        'End If

        'currentVersionNumber = Substring(inputLine, Len("CurrentVersionNumber="))
        'currentVersionPath = pathNameArray(fileNameIndex)

        Return "OK"

    End Function

    ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
    '                                                                              '
    ' Function: ftpDownloadAuxillarySystem.                                         '
    '                                                                              '
    ' Returns:  status information as a string.                                    '
    '                                                                              '
    ' Note: Status information is a cascaded record of error strings propogated    '
    '       upward from subroutine calls.                                          '
    '                                                                              '
    ' Author:    Marc Diamond                                                      '
    '                                                                              '
    ' The function downloads an auxillary program to be run on the device. This    '
    ' is useful to implement arbitrary house-keeping operations that may be needed '
    ' from time to time.                                                           
    '                                                                              '
    ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

    Public Function ftpDownloadAuxillarySystem() As String

        Dim result As String
        ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
        '   Initiate transfer process by resetting remote directory to remote log  '
        '   in root directory.                                                     '
        ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

        While True

            result = ftpChangeToRootDirectory()
            If result = "OK" Then Exit While

            result = "ftpDownloadUpdatedProgram|" & result

            Dim dialogResult As String = ftpDisplayUploadDownloadProcessError(result)
            If dialogResult <> "OK" Then Return result

        End While

        Dim fileNameArray(2) As String
        Dim pathNameArray(2) As String

        ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
        ' Generate a list of possible remote file paths for files that may contain '
        ' the current configuration file. A search is conducted on the server for  '
        ' the first existing file in this list. The result of this search also     '
        ' determines where the updated program will be taken from.                 '
        ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

        ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
        ' Note fileNameArray and pathNameArray must be re-initialized here and can '
        ' not be statically defined. First, some of the values (e.g. deviceSerial- '
        ' Number) are not set at program load. Second, the values may change as a  '
        ' result of user config changes.                                           '
        ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

        fileNameArray(0) = "Serial/SN" & deviceSerialNumber & "/AuxInstall.cab"
        fileNameArray(1) = scanLocation.currentLocation & "/AuxInstall.cab"
        fileNameArray(2) = "AuxInstall.cab"

        pathNameArray(0) = "Serial/SN" & deviceSerialNumber
        pathNameArray(1) = scanLocation.currentLocation
        pathNameArray(2) = ""

        Dim fileNameIndex As Integer

        While True

            result = ftpGetIndexOfFirstExistingRemoteFile(fileNameArray, fileNameIndex)
            If result <> "OK" Then Return result

            result = "ftpDownloadAuxillarySystem|" & result

            Dim dialogResult As String = ftpDisplayUploadDownloadProcessError(result)
            If dialogResult <> "OK" Then Return result

        End While

        If fileNameIndex < 0 Then Return "OK" ' No remote auxillary file found. Nothing else to do.

        Dim remoteFileDateStamp As DateTime
        Dim localFileDateStamp As DateTime

        ' Needs to be completed.

        auxInstallAvailable = True

        Return "OK"

    End Function

    ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
    '                                                                              '
    ' Function: ftpDownloadUpdatedProgram.                                         '
    '                                                                              '
    ' Returns:  status information as a string.                                    '
    '                                                                              '
    ' Note: Status information is a cascaded record of error strings propogated    '
    '       upward from subroutine calls.                                          '
    '                                                                              '
    ' Author:    Marc Diamond                                                      '
    '                                                                              '
    ' The function determines if a newer version of the scanner program exists     '
    ' on the server. If it does, it downloads it to the scanner and puts it in     '
    ' a location so that it will replace the current version when the device is    '
    ' next cold booted. A flag is set that tells the calling routine to initiate   '
    ' the required cold boot.                                                      '
    '                                                                              '
    ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

    Public Function ftpDownloadUpdatedProgram() As String

        Dim result As String

        ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
        '   Initiate transfer process by resetting remote directory to remote log  '
        '   in root directory.                                                     '
        ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

        While True

            result = ftpChangeToRootDirectory()
            If result = "OK" Then Exit While

            result = "ftpDownloadUpdatedProgram|" & result

            Dim dialogResult As String = ftpDisplayUploadDownloadProcessError(result)
            If dialogResult <> "OK" Then Return result

        End While

        ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
        '   Determine the level at which this update will be addressed, either (1) '
        '   for the specific device, (2) for the specific location, or (3) system  '
        '   wide.                                                                  '
        ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

        Dim currentVersionNumber As String ' This will contain the program release number
        Dim currentVersionPath As String   ' This will contain the remote path to the release itself
        Dim configVersionNumber As String
        Dim configVersionPath As String

        While True

            result = ftpGetVersionNumber(currentVersionNumber, currentVersionPath, _
                                                configVersionNumber, configVersionPath)
            If result = "OK" Then Exit While

            result = "ftpDownloadUpdatedProgram|" & result

            Dim dialogResult As String = ftpDisplayUploadDownloadProcessError(result)
            If dialogResult <> "OK" Then Return result

        End While

        Dim newVersionFound As Boolean = False

        If Not currentVersionNumber.Trim.Length = 0 Then

            Dim strCurrentVer(4) As String
            Dim intCurrentVer(4) As Integer
            Dim strMyVersion(4) As String
            Dim intMyVersion(4) As Integer

            strCurrentVer = currentVersionNumber.Split(".")
            strMyVersion = myVersionFull.Split(".")

            Try

                For i As Integer = 0 To 3

                    intCurrentVer(i) = Integer.Parse(strCurrentVer(i))
                    intMyVersion(i) = Integer.Parse(strMyVersion(i))

                    If intCurrentVer(i) > intMyVersion(i) Then
                        newVersionFound = True
                        Exit For
                    ElseIf intCurrentVer(i) < intMyVersion(i) Then
                        Exit For
                    End If

                Next

            Catch ex As Exception
                newVersionFound = False
            End Try

        End If

        If newVersionFound Then

            ' Backup current program folder unless it is currently running from backup folder
            Dim strAppDir As String = _
                Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().GetModules(0).FullyQualifiedName)
            Dim oldAppDir As String = deviceNonVolatileMemoryDirectory & "\TagTrakOld"
            If strAppDir <> oldAppDir Then
                If Not Directory.Exists(oldAppDir) Then
                    Directory.CreateDirectory(oldAppDir)
                End If

                Dim S1di As New DirectoryInfo(strAppDir)
                Dim S1fi As FileInfo() = S1di.GetFiles()
                Dim STemp As FileInfo

                For Each STemp In S1fi
                    copyLocalFile(strAppDir & "\" & STemp.Name, oldAppDir & "\" & STemp.Name)
                Next STemp
            End If

            transferStatusLabel.Text = "Downloading Upgrade"
            transferStatusLabel.Visible = True

            Application.DoEvents()

            Dim remoteUpdateFileName As String
            Dim localUpdateFileName As String

            If isNonNullString(currentVersionPath) Then
                remoteUpdateFileName = currentVersionPath & "/TagTrak." & currentVersionNumber & ".cab"
            Else
                remoteUpdateFileName = "TagTrak." & currentVersionNumber & ".cab"
            End If

            localUpdateFileName = deviceNonVolatileMemoryDirectory & "\cabfiles\TagTrak.cab"

            transferStatusLabel.Visible = False
            transferStatusLabel.Text = "Downloading Updated Program"

            Application.DoEvents()

            While True

                'result = ftpDownloadWithValidation(remoteUpdateFileName, localUpdateFileName, 2)
                'If result = "OK" Then Exit While

                result = ftpDownloadWithResumption(remoteUpdateFileName, localUpdateFileName, 2)
                If result = "OK" Then Exit While

                result = "ftpDownloadUpdatedProgram|" & result

                Dim dialogResult As String = ftpDisplayUploadDownloadProcessError(result)
                If dialogResult <> "OK" Then Return result

            End While

            Dim localFileInfo As FileInfo

            Try
                localFileInfo = New FileInfo(localUpdateFileName)
            Catch ex As Exception
                result = "ftpDownloadUpdatedProgram|Stat of file '" & localUpdateFileName & "' failed|" & ex.Message
                ftpDisplaySystemError("Download of updated program failed", result)
                Return result
            End Try

            Try
                localFileInfo.Attributes = FileAttributes.ReadOnly
            Catch ex As Exception
                result = "ftpDownloadUpdatedProgram|Change of attributes for file '" & localUpdateFileName & "' failed|" & ex.Message
                ftpDisplaySystemError("Download of updated program failed", result)
                Return result
            End Try

            Dim oldCabFilePath As String

            oldCabFilePath = deviceNonVolatileMemoryDirectory & "\cabfiles\Usps" & userSpecRecord.userName & ".cab"
            deleteLocalFile(oldCabFilePath)

            'Dim bkupCabFileUpdateFilePath As String

            'bkupCabFileUpdateFilePath = deviceNonVolatileMemoryDirectory & "\TagTrakReload\TagTrak.cab"

            'copyLocalFile(localUpdateFileName, bkupCabFileUpdateFilePath)

            'Dim newCabFileInfo As FileInfo

            'Try
            '    newCabFileInfo = New FileInfo(bkupCabFileUpdateFilePath)
            'Catch ex As Exception
            '    result = "ftpDownloadUpdatedProgram|Change of attributes for file '" & bkupCabFileUpdateFilePath & "' failed|" & ex.Message
            '    ftpDisplaySystemError("Download of updated program failed", result)
            '    Return result
            'End Try

            'Try
            '    newCabFileInfo.Attributes = FileAttributes.ReadOnly
            'Catch ex As Exception
            '    result = "ftpDownloadUpdatedProgram|Change of attributes for file '" & bkupCabFileUpdateFilePath & "' failed|" & ex.Message
            '    ftpDisplaySystemError("Download of updated program failed", result)
            '    Return result
            'End Try

            newApplicationVersionFound = True

        End If

        Dim newConfigFound As Boolean = False

        If Not configVersionNumber.Trim.Length = 0 Then

            If userSpecRecord.myConfigVersion.Trim.Length = 0 Then

                newConfigFound = True

            Else

                Dim strConfigVer(5) As String
                Dim intConfigVer(5) As Integer
                Dim strMyConfigVer(5) As String
                Dim intMyConfigVer(5) As Integer

                strConfigVer = configVersionNumber.Split(".")
                strMyConfigVer = userSpecRecord.myConfigVersion.Trim.Split(".")

                Try

                    For i As Integer = 0 To 4

                        intConfigVer(i) = Integer.Parse(strConfigVer(i))
                        intMyConfigVer(i) = Integer.Parse(strMyConfigVer(i))

                        If intConfigVer(i) > intMyConfigVer(i) Then
                            newConfigFound = True
                            Exit For
                        ElseIf intConfigVer(i) < intMyConfigVer(i) Then
                            Exit For
                        End If

                    Next

                Catch ex As Exception
                    newConfigFound = False
                End Try

            End If

        End If

        If newConfigFound Then

            Dim remoteDependentFileName As String
            Dim localDependentFileName As String

            If isNonNullString(configVersionPath) Then
                remoteDependentFileName = configVersionPath & "/DependentFiles." & user & "." & configVersionNumber & ".cab"
            Else
                remoteDependentFileName = "DependentFiles." & user & "." & configVersionNumber & ".cab"
            End If

            localDependentFileName = deviceNonVolatileMemoryDirectory & "\cabfiles\DependentFiles." & user & ".cab"

            transferStatusLabel.Visible = False
            transferStatusLabel.Text = "Downloading Scanner Configuration"

            Application.DoEvents()

            While True

                result = ftpDownloadWithValidation(remoteDependentFileName, localDependentFileName, 2)
                If result = "OK" Then Exit While

                result = "ftpDownloadUpdatedProgram|" & result

                Dim dialogResult As String = ftpDisplayUploadDownloadProcessError(result)
                If dialogResult <> "OK" Then Return result

            End While

            Dim localFileInfo As FileInfo

            Try
                localFileInfo = New FileInfo(localDependentFileName)
            Catch ex As Exception
                result = "ftpDownloadUpdatedProgram|Stat of file '" & localDependentFileName & "' failed|" & ex.Message
                ftpDisplaySystemError("Download of updated program failed", result)
                Return result
            End Try

            Try
                localFileInfo.Attributes = FileAttributes.ReadOnly
            Catch ex As Exception
                result = "ftpDownloadUpdatedProgram|Change of attributes for file '" & localDependentFileName & "' failed|" & ex.Message
                ftpDisplaySystemError("Download of updated program failed", result)
                Return result
            End Try

            'Dim bkupCabFileUpdateFilePath As String

            'bkupCabFileUpdateFilePath = deviceNonVolatileMemoryDirectory & "\TagTrakReload\DependentFiles." & user & ".cab"

            'copyLocalFile(localDependentFileName, bkupCabFileUpdateFilePath)

            'Dim newCabFileInfo As FileInfo

            'Try
            '    newCabFileInfo = New FileInfo(bkupCabFileUpdateFilePath)
            'Catch ex As Exception
            '    result = "ftpDownloadUpdatedProgram|Change of attributes for file '" & bkupCabFileUpdateFilePath & "' failed|" & ex.Message
            '    ftpDisplaySystemError("Download of updated program failed", result)
            '    Return result
            'End Try

            'Try
            '    newCabFileInfo.Attributes = FileAttributes.ReadOnly
            'Catch ex As Exception
            '    result = "ftpDownloadUpdatedProgram|Change of attributes for file '" & bkupCabFileUpdateFilePath & "' failed|" & ex.Message
            '    ftpDisplaySystemError("Download of updated program failed", result)
            '    Return result
            'End Try

            newConfigurationFileFound = True

        End If

        Return "OK"

    End Function


    ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
    '                                                                              '
    ' Function: ftpDownloadCarditRoutings.                                          '
    '                                                                              '
    ' Returns:  Status information as a string.                                    '
    '                                                                              '
    ' Note:     Status information is a cascaded record of error strings           '
    '           propogated upward from subroutine calls.                           '
    '                                                                              '
    ' Author:   Marc Diamond                                                       '
    '                                                                              '
    ' The function determines if a newer version of the cardit routings file       '
    ' exists on the server. If it does, it downloads it to the scanner. A flag is  '
    ' then set so that the new configuration information will be read in by the    '
    ' calling routines.                                                            '
    '                                                                              '
    ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

    Public Function ftpDownloadCarditRoutings() As String

        Dim result As String

        ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
        '   Initiate transfer process by resetting remote directory to remote log  '
        '   in root directory.                                                     '
        ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

        While True

            result = ftpChangeToRootDirectory()
            If result = "OK" Then Exit While

            result = "ftpDownloadCarditRoutings|" & result

            Dim dialogResult As String = ftpDisplayUploadDownloadProcessError(result)
            If dialogResult <> "OK" Then Return result

        End While

        newCarditRoutingFileFound = False

        ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
        ' Determine if the file to be downloaded exists on the server. If it does  '
        ' then continue, otherwise, exit the download process for this file.       '
        ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

        Dim remoteFileExists As Boolean
        Dim remoteFilePath As String = "/" & scanLocation.currentLocation & "/" & "cardit.txt.gz"

        While True

            result = Me.ftpRemoteFileExists(remoteFilePath, remoteFileExists)
            If result = "OK" Then Exit While

            result = "ftpDownloadRoutings|" & result

            Dim dialogResult As String = ftpDisplayUploadDownloadProcessError(result)
            If dialogResult <> "OK" Then Return result

        End While

        If Not remoteFileExists Then Return "OK"

        ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
        '   Check date stamp on the remote routings file and the local routings    '
        '   file. If the remote file is newer then the local one then download the '
        '   file to the scanner.                                                   '
        ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

        Dim remoteFileDateStamp As DateTime
        Dim localFileDateStamp As DateTime

        While True

            result = ftpGetRemoteFileDateStamp(remoteFilePath, remoteFileDateStamp)
            If result = "OK" Then Exit While

            result = "ftpDownloadCarditRoutings|" & result

            Dim dialogResult As String = ftpDisplayUploadDownloadProcessError(result)
            If dialogResult <> "OK" Then Return result

        End While

        Dim localFilePathGz As String = TagTrakDataDirectory & "\Cardit.txt.gz"
        Dim localFilePath As String = TagTrakDataDirectory & "\Cardit.txt"


        Dim dateStampFilePath As String = TagTrakConfigDirectory & "\CarditDateStamp.txt"


        If File.Exists(dateStampFilePath) And File.Exists(localFilePath) Then

            result = getDateStampFromDateStampFile(dateStampFilePath, localFileDateStamp)

            If result <> "OK" Then
                result = "ftpDownCarditRoutings|Error obtaining local date stamp|" & result
                ftpDisplaySystemError("Error obtaining local date stamp for schedule file", result)
                Return result
            End If

            If DateTime.Compare(localFileDateStamp, remoteFileDateStamp) >= 0 Then
                Return "OK"
            End If

        End If

        deleteLocalFile(localFilePath)

        transferStatusLabel.Visible = False
        transferStatusLabel.Text = "Downloading International Routings File"

        While True

            result = ftpDownloadWithValidation(remoteFilePath, localFilePathGz, 3)
            If result = "OK" Then Exit While

            result = "ftpDownloadCarditRoutings|Download failed|" & result

            Dim dialogResult As String = ftpDisplayUploadDownloadProcessError(result)
            If dialogResult <> "OK" Then Return result

        End While

        updateProgressBar = False

        ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
        '   Save updated date stamp for the current schedule file.                 '
        ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

        result = saveDateStampToDateStampFile(remoteFileDateStamp, dateStampFilePath)

        If result <> "OK" Then
            result = "ftpDownloadCarditRoutings|Save of updated date stamp failed|" & result
            ftpDisplaySystemError("Load of scanner config file failed", result)
            Return result
        End If

        gunzip(localFilePathGz, localFilePath)

        newCarditRoutingFileFound = True
        carditRecordTableDateStamp = remoteFileDateStamp

        Return "OK"

    End Function

    '' Download a newer FlightScheduleExt.txt.gz if one exists in our city.
    Public Function ftpDownloadFlightSchedule() As String

        Dim result As String

        While True

            result = ftpChangeToRootDirectory()
            If result = "OK" Then Exit While

            result = "ftpDownloadFlightSchedule|" & result

            Dim dialogResult As String = ftpDisplayUploadDownloadProcessError(result)
            If dialogResult <> "OK" Then Return result

        End While

        newFlightScheduleFileFound = False

        Dim remoteFileExists As Boolean
        Dim remoteFilePath As String = "/" & scanLocation.currentLocation & "/" & "FlightScheduleExt.txt.gz"

        While True

            result = Me.ftpRemoteFileExists(remoteFilePath, remoteFileExists)
            If result = "OK" Then Exit While

            result = "ftpDownloadFlightSchedule|" & result

            Dim dialogResult As String = ftpDisplayUploadDownloadProcessError(result)
            If dialogResult <> "OK" Then Return result

        End While

        If Not remoteFileExists Then Return "OK"

        Dim remoteFileDateStamp As DateTime
        Dim localFileDateStamp As DateTime

        While True

            result = ftpGetRemoteFileDateStamp(remoteFilePath, remoteFileDateStamp)
            If result = "OK" Then Exit While

            result = "ftpDownloadFlightSchedule|" & result

            Dim dialogResult As String = ftpDisplayUploadDownloadProcessError(result)
            If dialogResult <> "OK" Then Return result

        End While

        Dim localFilePathGz As String = TagTrakDataDirectory & "\FlightScheduleExt.txt.gz"
        Dim localFilePath As String = TagTrakDataDirectory & "\FlightScheduleExt.txt"

        Dim dateStampFilePath As String = TagTrakConfigDirectory & "\FlightScheduleExtDateStamp.txt"


        If File.Exists(dateStampFilePath) And File.Exists(localFilePath) Then

            result = getDateStampFromDateStampFile(dateStampFilePath, localFileDateStamp)

            If result <> "OK" Then
                result = "ftpDownloadFlightSchedule|Error obtaining local date stamp|" & result
                ftpDisplaySystemError("Error obtaining local date stamp for flight schedule file", result)
                Return result
            End If

            If DateTime.Compare(localFileDateStamp, remoteFileDateStamp) >= 0 Then
                Return "OK"
            End If

        End If

        deleteLocalFile(localFilePath)

        transferStatusLabel.Visible = False
        transferStatusLabel.Text = "Downloading Flight Schedule File"
        transferStatusLabel.Update()

        While True

            result = ftpDownloadWithValidation(remoteFilePath, localFilePathGz, 3)
            If result = "OK" Then Exit While

            result = "ftpDownloadFlightSchedule|Download failed|" & result

            Dim dialogResult As String = ftpDisplayUploadDownloadProcessError(result)
            If dialogResult <> "OK" Then Return result

        End While

        updateProgressBar = False

        result = saveDateStampToDateStampFile(remoteFileDateStamp, dateStampFilePath)

        If result <> "OK" Then
            result = "ftpDownloadFlightSchedule|Save of updated date stamp failed|" & result
            ftpDisplaySystemError("Load of scanner config file failed", result)
            Return result
        End If

        gunzip(localFilePathGz, localFilePath)

        newFlightScheduleFileFound = True

        Return "OK"

    End Function

    '' Download a newer FlightLoadInfo.txt.gz if one exists in our city.
    Public Function ftpDownloadFlightLoadInfo() As String

        Dim result As String

        While True

            result = ftpChangeToRootDirectory()
            If result = "OK" Then Exit While

            result = "ftpDownloadFlightLoadInfo|" & result

            Dim dialogResult As String = ftpDisplayUploadDownloadProcessError(result)
            If dialogResult <> "OK" Then Return result

        End While

        newFlightLoadInfoFound = False

        Dim remoteFileExists As Boolean
        Dim remoteFilePath As String = "/" & scanLocation.currentLocation & "/" & "FlightLoadInfo.txt.gz"

        While True

            result = Me.ftpRemoteFileExists(remoteFilePath, remoteFileExists)
            If result = "OK" Then Exit While

            result = "ftpDownloadFlightLoadInfo|" & result

            Dim dialogResult As String = ftpDisplayUploadDownloadProcessError(result)
            If dialogResult <> "OK" Then Return result

        End While

        If Not remoteFileExists Then Return "OK"

        Dim remoteFileDateStamp As DateTime
        Dim localFileDateStamp As DateTime

        While True

            result = ftpGetRemoteFileDateStamp(remoteFilePath, remoteFileDateStamp)
            If result = "OK" Then Exit While

            result = "ftpDownloadFlightLoadInfo|" & result

            Dim dialogResult As String = ftpDisplayUploadDownloadProcessError(result)
            If dialogResult <> "OK" Then Return result

        End While

        Dim localFilePathGz As String = TagTrakDataDirectory & "\FlightLoadInfo.txt.gz"
        Dim localFilePath As String = TagTrakDataDirectory & "\FlightLoadInfo.txt"


        Dim dateStampFilePath As String = TagTrakConfigDirectory & "\FlightLoadInfoDateStamp.txt"


        If File.Exists(dateStampFilePath) And File.Exists(localFilePath) Then

            result = getDateStampFromDateStampFile(dateStampFilePath, localFileDateStamp)

            If result <> "OK" Then
                result = "ftpDownloadFlightLoadInfo|Error obtaining local date stamp|" & result
                ftpDisplaySystemError("Error obtaining local date stamp for flight load info file", result)
                Return result
            End If

            If DateTime.Compare(localFileDateStamp, remoteFileDateStamp) >= 0 Then
                Return "OK"
            End If

        End If

        deleteLocalFile(localFilePath)

        transferStatusLabel.Visible = False
        transferStatusLabel.Text = "Downloading Flight Load Information"
        transferStatusLabel.Update()

        While True

            result = ftpDownloadWithValidation(remoteFilePath, localFilePathGz, 3)
            If result = "OK" Then Exit While

            result = "ftpDownloadFlightLoadInfo|Download failed|" & result

            Dim dialogResult As String = ftpDisplayUploadDownloadProcessError(result)
            If dialogResult <> "OK" Then Return result

        End While

        updateProgressBar = False

        result = saveDateStampToDateStampFile(remoteFileDateStamp, dateStampFilePath)

        If result <> "OK" Then
            result = "ftpDownloadFlightLoadInfo|Save of updated date stamp failed|" & result
            ftpDisplaySystemError("Load of scanner config file failed", result)
            Return result
        End If

        gunzip(localFilePathGz, localFilePath)

        newFlightLoadInfoFound = True

        Return "OK"

    End Function

    Private Function isValidSummaryFileName(ByRef fileName As String) As Boolean

        Dim currentLocation As String = Substring(scanLocation.currentLocation, 0, 3).ToUpper
        Dim testString As String

        If Length(fileName) = 3 Then

            If fileName.ToUpper = currentLocation Then
                Return True
            Else
                Return False
            End If

        End If

        If Length(fileName) = 15 Then

            If Substring(fileName, 0, 3).ToUpper <> currentLocation Then Return False

            testString = Substring(fileName, 3)

            If Not IsNumeric(testString) Then Return False

            Return True

        End If

        Return False

    End Function

    Private Sub deleteExistingSummaryFiles()

        Dim di As New DirectoryInfo(TagTrakSummariesDirectory)
        Dim i As Integer
        Dim nextFileName As String

        Dim files As FileInfo() = di.GetFiles()

        If files.Length <= 0 Then Exit Sub

        For i = 0 To files.Length - 1

            nextFileName = files(i).Name

            If nextFileName.EndsWith(".sum") Then
                nextFileName = TagTrakSummariesDirectory & backSlash & nextFileName
                deleteLocalFile(nextFileName)
            End If

        Next i

    End Sub

    ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
    '                                                                              '
    ' Function: ftpDownloadSummaryFile. Returns: status information as a string    '
    '                                                                              '
    ' Note: Status information is a cascaded record of error strings propogated    '
    '       upward from subroutine calls.                                          '
    '                                                                              '
    ' Downloads to scanner a summarized version of the load-out for specific       '
    ' flights. This can be used to provide weight and balance information to       '
    ' flight crews.                                                                '
    '                                                                              '
    ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

    Public Function ftpDownloadSummaryFile() As String

        Dim result As String

        'MsgBox("Test the hell out of downloading the summary file.")

        ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
        '   Initiate transfer process by resetting remote directory to remote log  '
        '   in root directory.                                                     '
        ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

        While True

            result = ftpChangeToRootDirectory()
            If result = "OK" Then Exit While

            result = "ftpDownloadSummaryFile|" & result

            'FtpFormRepository.ftpUploadDownloadProcessFail.init(result)
            'Me.DialogResult = FtpFormRepository.ftpUploadDownloadProcessFail.ShowDialog
            Dim dlg As New ftpUploadDownloadProcessFail
            dlg.init(result)
            Me.DialogResult = dlg.ShowDialog()

            If Me.DialogResult <> DialogResult.Retry Then Return result

        End While

        ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
        '   Verify / validate scan location. Then set up current location to get   '
        '   summary files.                                                         '
        ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

        If Not isNonNullString(scanLocation.currentLocation) Then
            result = "ftpDownloadSummaryFile|Invalid (null) scan location"
            ftpDisplaySystemError("Invalid (null) scan location", result)
            Return result
        End If

        If Length(scanLocation.currentLocation) < 3 Then
            result = "ftpDownloadSummaryFile|Invalid scan location '" & scanLocation.currentLocation & "'"
            ftpDisplaySystemError("Invalid scan location '" & scanLocation.currentLocation & "'", result)
            Return result
        End If

        Dim currentLocation As String = Substring(scanLocation.currentLocation, 0, 3)

        ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
        '   Change remote directory to the ./summaries directory. Then get a list  '
        '   of all files in that directory.                                        '
        ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

        While True

            result = ftpChangeRemoteDirectory("./summaries")
            If result = "OK" Then Exit While

            result = "ftpDownloadSummaryFile|Change Remote Directory To Summaries" & result

            Dim dialogResult As String = ftpDisplayUploadDownloadProcessError(result)
            If dialogResult <> "OK" Then Return result

        End While

        Dim remoteDirectoryFileNameList() As String

        While True

            result = ftpGetRemoteNameList(remoteDirectoryFileNameList)
            If result = "OK" Then Exit While

            result = "ftpDownloadSummaryFile|Get Remote Name List" & result

            Dim dialogResult As String = ftpDisplayUploadDownloadProcessError(result)
            If dialogResult <> "OK" Then Return result

        End While

        ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
        '   Filter through the remote file name list and determine which if any    '
        '   file is the valid summary file for the current location.               '
        ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

        Dim fileName As String
        Dim currentFileName As String = ""

        Dim matchFileNamePrefix = currentLocation & systemDateString

        Dim summaryFileFound As Boolean = False

        If Not remoteDirectoryFileNameList Is Nothing Then
            For Each fileName In remoteDirectoryFileNameList

                If isValidSummaryFileName(fileName) Then

                    summaryFileFound = True

                    If fileName > currentFileName Then currentFileName = fileName

                End If
            Next
        End If

        If Not summaryFileFound Then Return "OK"

        If Length(currentFileName) > 3 Then

            Dim year As Integer = CInt(Substring(currentFileName, 3, 4))
            Dim month As Integer = CInt(Substring(currentFileName, 7, 2))
            Dim day As Integer = CInt(Substring(currentFileName, 9, 2))
            Dim hour As Integer = CInt(Substring(currentFileName, 11, 2))
            Dim minute As Integer = CInt(Substring(currentFileName, 13, 2))

            Dim fileTimeStamp As New DateTime(year, month, day, hour, minute, 0)

            Dim fileAge As TimeSpan = serverDateAndTimeUTC.Subtract(fileTimeStamp)

            Dim fileAgeHours As Integer = fileAge.Days * 24 + fileAge.Hours

            If fileAgeHours > 8 Then Return "OK"

        End If

        ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
        '   At this point, a valid remote summary file has been found. Set up to   '
        '   download it to the scanner. Before doing this, the remote file date    '
        '   is compared with a local date stamp for the file. It is not downloaded '
        '   if the local file is newer than the remote file.                       '
        ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

        Dim remoteFileDateStamp As DateTime
        Dim localFileDateStamp As DateTime

        While True

            result = ftpGetRemoteFileDateStamp(currentFileName, remoteFileDateStamp)
            If result = "OK" Then Exit While

            result = "ftpDownloadSummaryFile|" & result

            Dim dialogResult As String = ftpDisplayUploadDownloadProcessError(result)
            If dialogResult <> "OK" Then Return result

        End While

        Dim dateStampFilePath As String = TagTrakConfigDirectory & "\" & scanLocation.currentLocation & "SummaryDateStamp.txt"

        summaryFilePath = TagTrakSummariesDirectory & "\" & currentFileName
        Dim finalSummaryFilePath As String = summaryFilePath & ".sum"

        If File.Exists(dateStampFilePath) And File.Exists(finalSummaryFilePath) Then

            result = getDateStampFromDateStampFile(dateStampFilePath, localFileDateStamp)

            If result <> "OK" Then
                result = "ftpDownloadSummaryFile|Error obtaining local date stamp|" & result
                ftpDisplaySystemError("Error obtaining local date stamp for summary file", result)
                Return result
            End If

            If DateTime.Compare(localFileDateStamp, remoteFileDateStamp) >= 0 Then

                currentSummaryFileIsValid = True

                Return "OK"

            End If

        End If

        Dim bytesTransferred As Integer

        transferStatusLabel.Visible = False
        transferStatusLabel.Text = "Downloading Summary File"

        Application.DoEvents()

        While True

            result = ftpDownloadWithValidation(currentFileName, summaryFilePath, 3)
            If result = "OK" Then Exit While

            result = "ftpDownloadSummaryFile|Download failed|" & result

            Dim dialogResult As String = ftpDisplayUploadDownloadProcessError(result)
            If dialogResult <> "OK" Then Return result

        End While

        deleteExistingSummaryFiles()

        moveLocalFile(summaryFilePath, finalSummaryFilePath)

        ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
        '   Save the current date stamp in the summary file date stamp file.       '
        ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

        result = saveDateStampToDateStampFile(remoteFileDateStamp, dateStampFilePath)
        If result <> "OK" Then
            result = "ftpDownloadSummaryFile|Failed to save date stamp|" & result
            ftpDisplaySystemError("Download summary file failed to save date stamp", result)
            Return result
        End If


        ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
        '   Clean up process before exiting by reseting the remote directory to    '
        '   the ftp root directory.                                                '
        ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

        While True

            result = ftpChangeToRootDirectory()
            If result = "OK" Then Exit While

            result = "ftpDownloadSummaryFile|" & result

            Dim dialogResult As String = ftpDisplayUploadDownloadProcessError(result)
            If dialogResult <> "OK" Then Return result

        End While

        currentSummaryFileIsValid = True

        Return "OK"

    End Function

    ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
    '                                                                              '
    ' Function: ftpDownloadRoutingUpdates. Returns: status information as a string '
    '                                                                              '
    ' Note: Status information is a cascaded record of error strings propogated    '
    '       upward from subroutine calls.                                          '
    '                                                                              '
    ' Downloads to scanner updates to the routing table and inserts the updates    '
    ' into the table.                                                              '
    '                                                                              '
    ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

    Public Function ftpDownloadRoutingUpdates() As String

        Dim result As String

        ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
        '   Initiate transfer process by resetting remote directory to remote log  '
        '   in root directory.                                                     '
        ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

        While True

            result = ftpChangeToRootDirectory()
            If result = "OK" Then Exit While

            result = "ftpDownloadRoutingUpdates|" & result

            Dim dialogResult As String = ftpDisplayUploadDownloadProcessError(result)
            If dialogResult <> "OK" Then Return result

        End While

        ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
        ' Determine if the file to be downloaded exists on the server. If it does  '
        ' then continue, otherwise, exit the download process for this file.       '
        ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

        Dim remoteFileExists As Boolean
        Dim remoteFilePath As String = "RoutingUpdates.txt"

        While True

            result = ftpRemoteFileExists(remoteFilePath, remoteFileExists)
            If result = "OK" Then Exit While

            result = "ftpDownloadRoutingUpdates|" & result

            Dim dialogResult As String = ftpDisplayUploadDownloadProcessError(result)
            If dialogResult <> "OK" Then Return result

        End While

        If Not remoteFileExists Then Return "OK"

        Dim localFilePath As String = deviceNonVolatileMemoryDirectory & selectedCarrierPath & "\RoutingUpdates.txt"
        Dim dateStampFilePath As String = TagTrakConfigDirectory & "\RoutingUpdatesDateStamp.txt"

        ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
        '   Check date stamp on the remote routings update file and the local      '
        '   routings update file. If the remote file is newer then the local one   '
        '   then download the file to the scanner.                                 '
        ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

        Dim remoteFileDateStamp As DateTime
        Dim localFileDateStamp As DateTime

        While True

            result = ftpGetRemoteFileDateStamp(remoteFilePath, remoteFileDateStamp)
            If result = "OK" Then Exit While

            result = "ftpDownloadRoutingUpdates|" & result

            Dim dialogResult As String = ftpDisplayUploadDownloadProcessError(result)
            If dialogResult <> "OK" Then Return result

        End While

        If File.Exists(dateStampFilePath) And File.Exists(localFilePath) Then

            result = getDateStampFromDateStampFile(dateStampFilePath, localFileDateStamp)

            If result <> "OK" Then
                result = "ftpDownloadSchedule|Error obtaining local date stamp|" & result
                ftpDisplaySystemError("Error obtaining local date stamp for schedule file", result)
                Return result
            End If

            If DateTime.Compare(localFileDateStamp, remoteFileDateStamp) >= 0 Then
                Return "OK"
            End If

        End If

        deleteLocalFile(localFilePath)

        transferStatusLabel.Visible = False
        transferStatusLabel.Text = "Downloading Routing Updates"

        While True

            result = ftpDownloadWithValidation(remoteFilePath, localFilePath, 3)
            If result = "OK" Then Exit While

            result = "ftpDownloadRoutingUpdates|Download failed|" & result

            Dim dialogResult As String = ftpDisplayUploadDownloadProcessError(result)
            If dialogResult <> "OK" Then Return result

        End While

        updateProgressBar = False

        transferStatusLabel.Text = "Loading Routing Updates"
        transferStatusLabel.Visible = True

        Application.DoEvents()

        result = routingSet.update(localFilePath)

        transferStatusLabel.Visible = False

        If result <> "OK" Then
            result = "ftpDownloadRoutingUpdates|Import of updates failed|" & result
            ftpDisplaySystemError("Import of updates failed", result)
            Return result
        End If

        ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
        '   Save updated date stamp for the current schedule file.                 '
        ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

        result = saveDateStampToDateStampFile(remoteFileDateStamp, dateStampFilePath)

        If result <> "OK" Then
            result = "ftpDownloadRoutingUpdates|Save of updated date stamp failed|" & result
            ftpDisplaySystemError("Import of routing updates file failed", result)
            Return result
        End If

        Return "OK"

    End Function

    ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
    '                                                                              '
    ' Function: ftpDownloadRoutings. Returns: status information as a string       '
    '                                                                              '
    ' Note: Status information is a cascaded record of error strings propogated    '
    '       upward from subroutine calls.                                          '
    '                                                                              '
    ' Download routings file to the scanner if it exists and is newer than the     '
    ' current version on the scanner. The routings file is used to determine       '
    ' whether or not the routings codes in D and R tags that get scanned are       '
    ' known and valid.                                                             '
    '                                                                              '
    ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

    Public Function ftpDownloadRoutings() As String

        Dim result As String

        ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
        '   Initiate transfer process by resetting remote directory to remote log  '
        '   in root directory.                                                     '
        ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

        While True

            result = ftpChangeToRootDirectory()
            If result = "OK" Then Exit While

            result = "ftpDownloadRoutingUpdates|" & result

            Dim dialogResult As String = ftpDisplayUploadDownloadProcessError(result)
            If dialogResult <> "OK" Then Return result

        End While

        ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
        ' Determine if the file to be downloaded exists on the server. If it does  '
        ' then continue, otherwise, exit the download process for this file.       '
        ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

        Dim remoteFileExists As Boolean
        Dim remoteFilePath As String = "Routings.bin.gz"

        While True

            result = Me.ftpRemoteFileExists(remoteFilePath, remoteFileExists)
            If result = "OK" Then Exit While

            result = "ftpDownloadRoutings|" & result

            Dim dialogResult As String = ftpDisplayUploadDownloadProcessError(result)
            If dialogResult <> "OK" Then Return result

        End While

        If Not remoteFileExists Then Return "OK"

        'Modified by MX
        Dim localFilePath As String = deviceNonVolatileMemoryDirectory & selectedCarrierPath & "\Routings.bin.gz"
        Dim dateStampFilePath As String = TagTrakConfigDirectory & "\RoutingsDateStamp.txt"

        ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
        '   Check date stamp on the remote routings file and the local routings    '
        '   file. If the remote file is newer then the local one then download the '
        '   file to the scanner.                                                   '
        ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

        Dim remoteFileDateStamp As DateTime
        Dim localFileDateStamp As DateTime

        While True

            result = ftpGetRemoteFileDateStamp(remoteFilePath, remoteFileDateStamp)
            If result = "OK" Then Exit While

            result = "ftpDownloadRoutingUpdates|" & result

            Dim dialogResult As String = ftpDisplayUploadDownloadProcessError(result)
            If dialogResult <> "OK" Then Return result

        End While

        If File.Exists(dateStampFilePath) And File.Exists(localFilePath) Then

            result = getDateStampFromDateStampFile(dateStampFilePath, localFileDateStamp)

            If result <> "OK" Then
                result = "ftpDownloadRoutings|Error obtaining local date stamp|" & result
                ftpDisplaySystemError("Error obtaining local date stamp for schedule file", result)
                Return result
            End If

            If DateTime.Compare(localFileDateStamp, remoteFileDateStamp) >= 0 Then
                Return "OK"
            End If

        End If

        deleteLocalFile(localFilePath)

        transferStatusLabel.Visible = False
        transferStatusLabel.Text = "Downloading Routings"

        While True

            result = ftpDownloadWithValidation(remoteFilePath, localFilePath, 3)
            If result = "OK" Then Exit While

            result = "ftpDownloadRoutings|Download failed|" & result

            Dim dialogResult As String = ftpDisplayUploadDownloadProcessError(result)
            If dialogResult <> "OK" Then Return result

        End While

        updateProgressBar = False

        ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
        '   Unzip file to local file.                                              '
        ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

        Dim localGUnzippedFilePath As String = deviceNonVolatileMemoryDirectory & selectedCarrierPath & "\Routings.bin"

        gunzip(localFilePath, localGUnzippedFilePath)

        result = routingSet.read(localGUnzippedFilePath)

        If result <> "OK" Then
            result = "ftpDownloadRoutings|Load of routings table failed|" & result
            ftpDisplaySystemError("Load of routings table failed", result)
            Return result
        End If

        ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
        '   Save updated date stamp for the current schedule file.                 '
        ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

        result = saveDateStampToDateStampFile(remoteFileDateStamp, dateStampFilePath)

        If result <> "OK" Then
            result = "ftpDownloadRoutings|Save of updated date stamp failed|" & result
            ftpDisplaySystemError("Load of routing updates file failed", result)
            Return result
        End If

        Return "OK"

    End Function

    ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
    '                                                                              '
    ' Function: ftpDownloadOntimeFile.                                             '
    '                                                                              '
    ' Returns:  Status information as a string.                                    '
    '                                                                              '
    ' Note:     Status information is a cascaded record of error strings           '
    '           propogated upward from subroutine calls.                           '
    '                                                                              '
    ' Author:   Marc Diamond                                                       '
    '                                                                              '
    ' The function determines if a newer version of the ontime file exists on the  '
    ' server. If it does, it downloads it to the scanner. A flag is then set so    '
    ' that the new configuration information will be read in by the calling        '
    ' routines.                                                                    '
    '                                                                              '
    ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

    Public Function ftpDownloadOntimeFile() As String

        Dim result As String

#If deviceType = "PC" Then
        return "OK"
#End If

        ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
        '   Initiate transfer process by resetting remote directory to remote log  '
        '   in root directory.                                                     '
        ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

        While True

            result = ftpChangeToRootDirectory()
            If result = "OK" Then Exit While

            result = "ftpDownloadOntimeFile|" & result

            Dim dialogResult As String = ftpDisplayUploadDownloadProcessError(result)
            If dialogResult <> "OK" Then Return result

        End While

        newOntimeFileFound = False

        If Not Util.isValidLocation(scanLocation.currentLocation) Then

            Return "Cannot check for ontime file: invalid scan location."

        End If

        Dim remoteFilePath As String = scanLocation.currentLocation & "/" & scanLocation.currentLocation & ".ontime.gz"

        Dim remoteFileExists As Boolean

        While True

            result = Me.ftpRemoteFileExists(remoteFilePath, remoteFileExists)
            If result = "OK" Then Exit While

            result = "ftpDownloadOntimeFile|" & result

            Dim dialogResult As String = ftpDisplayUploadDownloadProcessError(result)
            If dialogResult <> "OK" Then Return result

        End While

        If Not remoteFileExists Then Return "OK"

        ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
        '   Check date stamp on the remote ontime file and the local ontime        '
        '   file. If the remote file is newer then the local one then download the '
        '   file to the scanner.                                                   '
        ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

        Dim remoteFileDateStamp As DateTime
        Dim localFileDateStamp As DateTime

        While True

            result = ftpGetRemoteFileDateStamp(remoteFilePath, remoteFileDateStamp)
            If result = "OK" Then Exit While

            result = "ftpDownloadScannerConfig|" & result

            Dim dialogResult As String = ftpDisplayUploadDownloadProcessError(result)
            If dialogResult <> "OK" Then Return result

        End While

        Dim localFilePath As String = TagTrakConfigDirectory & "\OnTime.txt"
        Dim dateStampFilePath As String = TagTrakConfigDirectory & "\OnTimeDateStamp.txt"

        If File.Exists(dateStampFilePath) And File.Exists(localFilePath) Then

            result = getDateStampFromDateStampFile(dateStampFilePath, localFileDateStamp)

            If result <> "OK" Then
                result = "ftpDownOntimeFile|Error obtaining local date stamp|" & result
                ftpDisplaySystemError("Error obtaining local date stamp for schedule file", result)
                Return result
            End If

            If DateTime.Compare(localFileDateStamp, remoteFileDateStamp) >= 0 Then
                Return "OK"
            End If

        End If

        Dim localGzipFilePath As String = TagTrakConfigDirectory & "\ontime.gz"

        deleteLocalFile(localGzipFilePath)

        transferStatusLabel.Visible = False
        transferStatusLabel.Text = "Downloading Ontime File"

        While True

            result = ftpDownloadWithValidation(remoteFilePath, localGzipFilePath, 3)
            If result = "OK" Then Exit While

            result = "ftpDownloadOntimeFile|Download failed|" & result

            Dim dialogResult As String = ftpDisplayUploadDownloadProcessError(result)
            If dialogResult <> "OK" Then Return result

        End While

        updateProgressBar = False

        ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
        '   Save updated date stamp for the current schedule file.                 '
        ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

        result = saveDateStampToDateStampFile(remoteFileDateStamp, dateStampFilePath)

        If result <> "OK" Then
            result = "ftpDownloadOntimeFile|Save of updated date stamp failed|" & result
            Return result
        End If

        ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
        '   Unzip file to local file.                                              '
        ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

        gunzip(localGzipFilePath, localFilePath)

        newOntimeFileFound = True

        Return "OK"

    End Function

    Public Function ftpLoadMessageListElementFromFile(ByVal filePath As String) As String

        Dim messagesInputStream As StreamReader

        Dim trimChars As String = " " & Chr(10) & Chr(13)

        Try
            messagesInputStream = New StreamReader(filePath)
        Catch ex As Exception
            Return ex.Message
        End Try

        Dim messageString As String = ""

        Dim inputRecord As String

        Dim emptyMessage As Boolean = True

        While True

            Try
                inputRecord = messagesInputStream.ReadLine
            Catch ex As Exception
                Return ex.message
            End Try

            If inputRecord Is Nothing Then Exit While

            If inputRecord.StartsWith("----") Then

                If Not emptyMessage Then
                    messageList.Add(messageString)
                End If

                messageString = ""
                emptyMessage = True

            Else

                If emptyMessage Then
                    If isNonNullString(inputRecord.TrimEnd(trimChars)) Then
                        emptyMessage = False
                    End If
                End If

                messageString &= inputRecord.TrimEnd(trimChars) & Chr(13) & Chr(10)

            End If

        End While

        If Not emptyMessage Then
            messageList.Add(messageString)
        End If

        Return "OK"

    End Function

    ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
    '                                                                              '
    ' Function: ftpDownloadFlightRoutesFile.                                 '
    '                                                                              '
    ' Returns:  Status information as a string.                                    '
    '                                                                              '
    ' Note:     Status information is a cascaded record of error strings           '
    '           propogated upward from subroutine calls.                           '
    '                                                                              '
    ' Author:   Marc Diamond                                                       '
    '                                                                              '
    ' The function determines if a newer version of the flight routes file         '
    ' exists on server. If it does, it downloads it to the scanner.
    '                                                                              '
    ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

    Public Function ftpDownloadFlightRoutesFile() As String

        Dim result As String

#If deviceType = "PC" Then
        return "OK"
#End If

        ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
        '   Initiate transfer process by resetting remote directory to remote log  '
        '   in root directory.                                                     '
        ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

        While True

            result = ftpChangeToRootDirectory()
            If result = "OK" Then Exit While

            result = "ftpDownloadFlightRoutesFile|" & result

            Dim dialogResult As String = ftpDisplayUploadDownloadProcessError(result)
            If dialogResult <> "OK" Then Return result

        End While

        newFlightRoutesFileFound = False

        If Not Util.isValidLocation(scanLocation.currentLocation) Then

            Return "Cannot check for first arrival cities file: invalid scan location."

        End If

        Dim remoteFilePath As String = "flightroutes.txt.gz"

        Dim remoteFileExists As Boolean

        While True

            result = Me.ftpRemoteFileExists(remoteFilePath, remoteFileExists)
            If result = "OK" Then Exit While

            result = "ftpDownloadFlightRoutesFile|" & result

            Dim dialogResult As String = ftpDisplayUploadDownloadProcessError(result)
            If dialogResult <> "OK" Then Return result

        End While

        If Not remoteFileExists Then Return "OK"

        ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
        '   Check date stamp on the remote ontime file and the local ontime        '
        '   file. If the remote file is newer then the local one then download the '
        '   file to the scanner.                                                   '
        ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

        Dim remoteFileDateStamp As DateTime
        Dim localFileDateStamp As DateTime

        While True

            result = ftpGetRemoteFileDateStamp(remoteFilePath, remoteFileDateStamp)
            If result = "OK" Then Exit While

            result = "ftpDownloadFlightRoutesFile|" & result

            Dim dialogResult As String = ftpDisplayUploadDownloadProcessError(result)
            If dialogResult <> "OK" Then Return result

        End While

        Dim localFilePath As String = TagTrakDataDirectory & "\FlightRoutes.txt"
        Dim dateStampFilePath As String = TagTrakConfigDirectory & "\FlightRoutesDateStamp.txt"

        If File.Exists(dateStampFilePath) And File.Exists(localFilePath) Then

            result = getDateStampFromDateStampFile(dateStampFilePath, localFileDateStamp)

            If result <> "OK" Then
                result = "ftpDownloadFlightRoutesFile|Error obtaining local date stamp|" & result
                ftpDisplaySystemError("Error obtaining local date stamp for flight routes file", result)
                Return result
            End If

            If DateTime.Compare(localFileDateStamp, remoteFileDateStamp) >= 0 Then
                Return "OK"
            End If

        End If

        Dim localGzipFilePath As String = TagTrakDataDirectory & "\FlightRoutes.txt.gz"

        deleteLocalFile(localGzipFilePath)

        transferStatusLabel.Visible = False
        transferStatusLabel.Text = "Downloading Flight Routes File"

        While True

            result = ftpDownloadWithValidation(remoteFilePath, localGzipFilePath, 3)
            If result = "OK" Then Exit While

            result = "ftpDownloadFlightRoutesFile|Download failed|" & result

            Dim dialogResult As String = ftpDisplayUploadDownloadProcessError(result)
            If dialogResult <> "OK" Then Return result

        End While

        updateProgressBar = False

        ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
        '   Save updated date stamp for the current schedule file.                 '
        ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

        result = saveDateStampToDateStampFile(remoteFileDateStamp, dateStampFilePath)

        If result <> "OK" Then
            result = "ftpDownloadFlightRoutesFile|Save of updated date stamp failed|" & result
            Return result
        End If

        ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
        '   Unzip file to local file.                                              '
        ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

        gunzip(localGzipFilePath, localFilePath)

        newFlightRoutesFileFound = True

        Return "OK"

    End Function


    ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
    '                                                                              '
    ' Function: ftpDownMessage
    '
    ' Returns:  status information as a string       '
    '
    ' Author:   Marc Diamond
    '
    ' Note: Status information is a cascaded record of error strings propogated    '
    '       upward from subroutine calls.                                          '
    '                                                                              '
    ' downloads any messages for the specific device and then loads the message    '
    ' form with the messages. A flag is set so that the user is informed of        '
    ' pending messages.                                                            '
    '                                                                              '
    ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

    Public Function ftpDownloadMessages(ByRef messagesFound As Boolean) As String

        Dim result As String

        ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
        '   Initiate transfer process by resetting remote directory to remote log  '
        '   in root directory.                                                     '
        ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

        While True

            result = ftpChangeToRootDirectory()
            If result = "OK" Then Exit While

            result = "ftpDownloadRoutingUpdates|" & result

            Dim dialogResult As String = ftpDisplayUploadDownloadProcessError(result)
            If dialogResult <> "OK" Then Return result

        End While

        messagesFound = False

        Dim messagesLocalPath(2) As String
        Dim messagesRemotePath(2) As String

        messageList.Clear()

        messagesRemotePath(0) = "Serial/SN" & deviceSerialNumber & "/Messages.txt"
        messagesRemotePath(1) = scanLocation.currentLocation & "/Messages.txt"
        messagesRemotePath(2) = "Messages.txt"

        messagesLocalPath(0) = deviceNonVolatileMemoryDirectory & selectedCarrierPath & "\MessagesForSN.txt"
        messagesLocalPath(1) = deviceNonVolatileMemoryDirectory & selectedCarrierPath & "\MessagesForLocation.txt"
        messagesLocalPath(2) = deviceNonVolatileMemoryDirectory & selectedCarrierPath & "\MessagesForSystem.txt"

        Dim i As Integer

        For i = 0 To 2

            Dim remoteFileExists As Boolean

            result = ftpRemoteFileExists(messagesRemotePath(i), remoteFileExists)

            If remoteFileExists Then

                deleteLocalFile(messagesLocalPath(i))

                transferStatusLabel.Visible = False
                transferStatusLabel.Text = "Downloading Messages"

                While True

                    result = ftpDownloadWithValidation(messagesRemotePath(i), messagesLocalPath(i), 2)
                    If result = "OK" Then Exit While

                    result = "ftpDownloadMessages|" & result

                    Dim dialogResult As String = ftpDisplayUploadDownloadProcessError(result)
                    If dialogResult <> "OK" Then Return result

                End While

                updateProgressBar = False

                result = ftpLoadMessageListElementFromFile(messagesLocalPath(i))

                If result <> "OK" Then
                    messagesFound = False
                End If

                messagesFound = True

            End If

        Next

        Return "OK"

    End Function

    ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
    '                                                                              '
    ' Function: ftpDownloadTimeZoneOffsetFile Returns: status information as       '
    '           string                                                             '
    '                                                                              '
    ' Gets the time zone offset file from the server and sets up the time zone     '
    ' offset for the current city.                                                 '
    '                                                                              '
    ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

    Public Function ftpDownloadTimeZoneOffsetFile() As String

        Dim result As String

#If deviceType = "PC" Then
        return "OK"
#End If

        ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
        '   Initiate transfer process by resetting remote directory to remote log  '
        '   in root directory.                                                     '
        ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

        While True

            result = ftpChangeToRootDirectory()
            If result = "OK" Then Exit While

            result = "ftpDownloadTimeZoneOffsetFile|" & result

            Dim dialogResult As String = ftpDisplayUploadDownloadProcessError(result)
            If dialogResult <> "OK" Then Return result

        End While


        If Not Util.isValidLocation(scanLocation.currentLocation) Then

            Return "Cannot check for first arrival cities file: invalid scan location."

        End If

        Dim remoteFilePath As String = "tz2.gz"
        Dim remoteFileExists As Boolean

        While True

            result = Me.ftpRemoteFileExists(remoteFilePath, remoteFileExists)
            If result = "OK" Then Exit While

            result = "ftpDownloadTimeZoneOffsetFile|" & result

            Dim dialogResult As String = ftpDisplayUploadDownloadProcessError(result)
            If dialogResult <> "OK" Then Return result

        End While

        If Not remoteFileExists Then Return "OK"

        ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
        '   Check date stamp on the remote ontime file and the local ontime        '
        '   file. If the remote file is newer then the local one then download the '
        '   file to the scanner.                                                   '
        ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

        Dim remoteFileDateStamp As DateTime
        Dim localFileDateStamp As DateTime

        While True

            result = ftpGetRemoteFileDateStamp(remoteFilePath, remoteFileDateStamp)
            If result = "OK" Then Exit While

            result = "ftpDownloadTimeZoneOffsetFile|" & result

            Dim dialogResult As String = ftpDisplayUploadDownloadProcessError(result)
            If dialogResult <> "OK" Then Return result

        End While

        Dim localFilePath As String = TagTrakDataDirectory & "\tz2.gz"
        Dim dateStampFilePath As String = TagTrakConfigDirectory & "\tz2TimeStamp.txt"

        If File.Exists(dateStampFilePath) And File.Exists(localFilePath) Then

            result = getDateStampFromDateStampFile(dateStampFilePath, localFileDateStamp)

            If result <> "OK" Then
                result = "ftpDownloadTimeZoneOffsetFile|Error obtaining local date stamp|" & result
                ftpDisplaySystemError("Error obtaining local date stamp for flight routes file", result)
                Return result
            End If

            If DateTime.Compare(localFileDateStamp, remoteFileDateStamp) >= 0 Then
                Return "OK"
            End If

        End If

        deleteLocalFile(localFilePath)

        transferStatusLabel.Visible = False
        transferStatusLabel.Text = "Downloading Time Zone File"

        While True

            result = ftpDownloadWithValidation(remoteFilePath, localFilePath, 3)
            If result = "OK" Then Exit While

            result = "ftpDownloadTimeZoneOffsetFile|Download failed|" & result

            Dim dialogResult As String = ftpDisplayUploadDownloadProcessError(result)
            If dialogResult <> "OK" Then Return result

        End While

        updateProgressBar = False

        ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
        '   Save updated date stamp for the current schedule file.                 '
        ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

        result = saveDateStampToDateStampFile(remoteFileDateStamp, dateStampFilePath)

        If result <> "OK" Then
            result = "ftpDownloadTimeZoneOffsetFile|Save of updated date stamp failed|" & result
            Return result
        End If

        ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
        '   Unzip file to local file.                                              '
        ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

        Dim localGunzipFilePath = TagTrakDataDirectory & "\tz2.txt"
        gunzip(localFilePath, localGunzipFilePath)

        If scanLocation Is Nothing Then Return "OK"

        Dim currentLocation As String = scanLocation.currentLocation

        If currentLocation Is Nothing Then Return "OK"

        If currentLocation.Length <> 3 Then Return "OK"

        scannerTimeZone = Time.TimeZone.Load(localGunzipFilePath, currentLocation)
        scannerTimeZone.OffsetInfo.Confidence = Time.TimeZone.Offset.ConfidenceLevels.ServerProvided

        Return "OK"

    End Function

    ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
    '                                                                              '
    ' Function: ftpGetRemoteFileDateStamp Returns: status information as a string  '
    '                                                                              '
    ' Gets the date and time a file on the server was last written.                '
    '                                                                              '
    ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

    Function ftpGetRemoteFileDateStamp(ByVal fileName As String, ByRef remoteFileDateStamp As DateTime) As String

        Try
            remoteFileDateStamp = ftp.GetFileDateTime(fileName)
        Catch ex As Exception
            Return "ftpGetRemoteFileDateStamp|File name: " & fileName & "|" & ex.Message
        End Try

        Return "OK"

    End Function

    ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
    '                                                                              '
    ' Function: ftpGetRemoteNameList.     Returns: status information as a string  '
    '                                                                              '
    ' Gets a list of file names on the remote server as a string array.            '
    '                                                                              '
    ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

    Function ftpGetRemoteNameList(ByRef remoteDirectoryFileNameList() As String) As String

        Try

            '' Do NOT use ftp.GetNameList(), causes crash on empty directory listing.
            '' (But only on some network topologies)
            remoteDirectoryFileNameList = ftp.GetList().GetFiles("*")

        Catch ex As Exception

            If ex.Message.IndexOf("No files found") >= 0 Then
                remoteDirectoryFileNameList = Nothing
                Return "OK"
            End If

            Return "ftpGetRemoteNameList|" & ex.Message

        End Try

        Return "OK"

    End Function

    ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
    '                                                                              '
    ' Function: ftpChangeToRootDirectory. Returns: status information as a string  '
    '                                                                              '
    ' Resets the remote default directory to the the login root directory. This    '
    ' clears the effects of any remote directory changes that may not have other-  '
    ' wise have been reset.                                                        '
    '                                                                              '
    ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

    Private Function ftpChangeToRootDirectory() As String

        Dim directoryChangeStartTime As DateTime = Now()
        Dim asyncResult As IAsyncResult
        Dim changeDirectoryMaxWaitTime As TimeSpan = New TimeSpan(0, 0, 30)

        Try
            ftp.ChangeDirectory("/")
            'asyncResult = ftp.BeginChangeDirectory("/", Nothing, Nothing)
        Catch ex As Exception
            Return "ftpChangeToRootDirectory|" & ex.Message
        End Try

        'While Not asyncResult.IsCompleted

        '    System.Threading.Thread.Sleep(100)
        '    Application.DoEvents()

        '    Dim elapsedTime As TimeSpan = Now().Subtract(directoryChangeStartTime)

        '    If TimeSpan.Compare(elapsedTime, changeDirectoryMaxWaitTime) > 0 Then
        '        ftp.Abort()
        '        Return "ftpChangeToRootDirectory|Operation Timed Out"
        '    End If

        'End While

        'ftp.EndChangeDirectory(asyncResult)

        Return "OK"

    End Function

    ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
    '                                                                              '
    ' Function: ftpChangeRemoteDirectory. Returns: status information as a string  '
    '                                                                              '
    ' Resets the remote default directory to the the login root directory. This    '
    ' clears the effects of any remote directory changes that may not have other-  '
    ' wise have been reset.                                                        '
    '                                                                              '
    ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

    Private Function ftpChangeRemoteDirectory(ByVal newDirectory As String) As String

        Try
            ftp.ChangeDirectory(newDirectory)
        Catch ex As Exception
            Return "ftpChangeRemoteDirectory|" & "|" & "Directory: " & newDirectory & "|" & ex.Message
        End Try

        Return "OK"

    End Function

    ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
    '                                                                              '
    ' Function: ftpDisplayUploadDownloadProcessError. Returns:                     '
    '   "OK"     -- user wants to attempt to continue with the upload/download     '
    '               process                                                        '
    '   "Cancel" -- user wants to abort current upload/download process            '
    '                                                                              '
    ' Displays generic upload / download process error. Allows user to view        '
    ' detailed error message information if desired.                               '
    '                                                                              '
    ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

    Function ftpDisplayUploadDownloadProcessError(ByVal errorMessage As String) As String
        If Not Me.ShowErrors Then Return "Cancel"

        'FtpFormRepository.ftpUploadDownloadProcessFail.init(errorMessage)
        Dim dlg As New ftpUploadDownloadProcessFail
        dlg.init(errorMessage)
        Me.DialogResult = dlg.ShowDialog()
        If Me.DialogResult = DialogResult.Abort Then Return "Abort"

        If Me.DialogResult = DialogResult.Retry Then
            Return "OK"
        Else
            Return "Cancel"
        End If

    End Function

    ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
    '                                                                              '
    ' Function: ftpDisplaySystemError                                              '
    '                                                                              '
    ' Author:   Marc Diamond                                                       '
    '                                                                              '
    ' Displays a system error message.                                             '
    '                                                                              '
    ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

    Public Sub ftpDisplaySystemError(ByVal sysErrorMessage As String, Optional ByVal fullErrorMessage As String = "")
        If Not Me.ShowErrors Then Exit Sub

        Dim dlg As New ftpMsgFormSysError
        dlg.init(sysErrorMessage, fullErrorMessage)
        Me.DialogResult = dlg.ShowDialog
        If Me.DialogResult = DialogResult.Abort Then Exit Sub

        Me.transferBaseForm.BringToFront()

    End Sub

    ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
    '                                                                              '
    ' Function: ftpDisplaySystemWarning.                                           '
    '                                                                              '
    ' Author:   Marc Diamond                                                       '
    '                                                                              '
    ' Displays a system warning message.                                           '
    '                                                                              '
    ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

    Public Sub ftpDisplaySystemWarning(ByVal sysWarningMessage As String)
        If Not Me.ShowErrors Then Exit Sub

        Dim dlg As New ftpMsgFormSysWarning
        dlg.init(sysWarningMessage)
        Me.DialogResult = dlg.ShowDialog()

        If Me.DialogResult = DialogResult.Abort Then Exit Sub

        Me.transferBaseForm.BringToFront()

    End Sub

    Public Function GetServerTime() As String

        Dim result As String

        Dim remoteTimeFile As String = "/time"
        Dim localTimeFile As String = TagTrakConfigDirectory & "\time"

        result = Me.ftpDownloadFileFromServer(remoteTimeFile, localTimeFile)

        If result <> "OK" Then
            Return result
        End If

        Dim rd As System.IO.StreamReader
        Dim ts As String

        Try
            rd = New System.IO.StreamReader(localTimeFile)
            ts = rd.ReadLine()
        Catch ex As Exception
            rd.Close()
            Return ex.Message
        End Try

        rd.Close()

        Try
            '' Set the time
            scannerDateAndTimeUTC = DateTime.UtcNow
            setDeviceDateAndTime(DateTime.Parse(ts.Trim(), cultureInfo))
            serverDateAndTimeUTC = DateTime.UtcNow
            lastTimeSync = TagTrakGlobals.TimeSyncTypes.FTPTime
        Catch ex As Exception
            Return ex.Message
        End Try

        Return "OK"

    End Function

    '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
    ' New way to adjust device time, not relying on the connect string
    '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

    'Public Function AdjustDeviceTime() As String

    '    Dim res As String
    '    res = Me.ftpChangeToRootDirectory()
    '    If res <> "OK" Then Exit Function

    '    Dim remoteTimeFile As String = "time"
    '    Dim localTimeFile As String = "time"
    '    res = Me.ftpDownloadFileFromServer(remoteTimeFile, localTimeFile)
    '    If res <> "OK" Then Return res

    '    Dim rd As New System.IO.StreamReader(localTimeFile)
    '    Dim ts As String = rd.ReadLine()
    '    rd.Close()

    '    deleteLocalFile(localTimeFile)

    '    Try
    '        serverDateAndTimeUTC = Date.Parse(ts.Trim())
    '    Catch ex As Exception
    '        Return ex.Message
    '    End Try

    '    setDeviceDateAndTime(serverDateAndTimeUTC)

    '    Return res

    'End Function

    Public Function UploadAuthFile() As String

        Dim localTimeFile As String = "time"
        Dim authTemp As String
        Dim authFileName As String
        Dim authLocalFile As String
        Dim authRemoteFile As String

        Dim serverGMT As DateTime

        serverGMT = DateTime.UtcNow

        'Try
        '    Dim sr As New System.IO.StreamReader(localTimeFile)
        '    serverGMT = DateTime.Parse(sr.ReadLine.Trim)
        '    sr.Close()
        'Catch ex As Exception
        '    serverGMT = DateTime.UtcNow
        'End Try

        'deleteLocalFile(localTimeFile)

        authTemp = TagTrakTempDirectory + "\AuthFileTemp.txt"
        authFileName = "auth_" + serverGMT.Ticks.ToString
        authLocalFile = TagTrakTempDirectory + "\" + authFileName
        authRemoteFile = authFileName

        Try
            Dim sw As New System.IO.StreamWriter(authTemp)
            sw.WriteLine(scannerLib.getDeviceSerialNumber() + vbTab + serverGMT.ToString)
            sw.Close()
        Catch ex As Exception
            Return ex.Message
        End Try

        encryptFile(authTemp, authLocalFile)

        deleteLocalFile(authTemp)

        ftpUploadWithValidation(authLocalFile, authRemoteFile, 1)

        deleteLocalFile(authLocalFile)

        Return "OK"

    End Function

End Class
