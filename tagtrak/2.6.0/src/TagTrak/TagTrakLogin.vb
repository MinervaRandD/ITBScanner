Imports Rebex.Net
Imports System.io
Imports System.Text
Imports OpenNETCF.Security.Cryptography
Imports System.Threading.Thread


Public Class TagTrakLogin
    Inherits System.Windows.Forms.Form

    Friend WithEvents lblUserName As System.Windows.Forms.Label
    Friend WithEvents lblPassword As System.Windows.Forms.Label
    Friend WithEvents initFormLogoPictureBox As System.Windows.Forms.PictureBox

    Friend WithEvents cm As New OpenNETCF.Net.ConnectionManager

    Dim ftpConnectionState As Integer = 0

#Region " Windows Form Designer generated code "

    Public Sub New()
        MyBase.New()

        'This call is required by the Windows Form Designer.
        InitializeComponent()

        'Add any initialization after the InitializeComponent() call

    End Sub

    Protected Overloads Overrides Sub Dispose(ByVal disposing As Boolean)
        MyBase.Dispose(disposing)
    End Sub

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    Friend WithEvents txtUserName As System.Windows.Forms.TextBox
    Friend WithEvents txtPassword As System.Windows.Forms.TextBox
    Friend WithEvents btnLogin As System.Windows.Forms.Button
    Friend WithEvents InputPanel1 As Microsoft.WindowsCE.Forms.InputPanel
    Friend WithEvents MainMenu1 As System.Windows.Forms.MainMenu
    Friend WithEvents lblDescription As System.Windows.Forms.Label
    Friend WithEvents lblPassString As System.Windows.Forms.Label
    Friend WithEvents lblValidating As System.Windows.Forms.Label
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Dim resources As System.Resources.ResourceManager = New System.Resources.ResourceManager(GetType(TagTrakLogin))
        Me.initFormLogoPictureBox = New System.Windows.Forms.PictureBox
        Me.lblUserName = New System.Windows.Forms.Label
        Me.lblPassword = New System.Windows.Forms.Label
        Me.txtUserName = New System.Windows.Forms.TextBox
        Me.txtPassword = New System.Windows.Forms.TextBox
        Me.btnLogin = New System.Windows.Forms.Button
        Me.InputPanel1 = New Microsoft.WindowsCE.Forms.InputPanel
        Me.MainMenu1 = New System.Windows.Forms.MainMenu
        Me.lblDescription = New System.Windows.Forms.Label
        Me.lblPassString = New System.Windows.Forms.Label
        Me.lblValidating = New System.Windows.Forms.Label
        '
        'initFormLogoPictureBox
        '
        Me.initFormLogoPictureBox.Image = CType(resources.GetObject("initFormLogoPictureBox.Image"), System.Drawing.Image)
        Me.initFormLogoPictureBox.Location = New System.Drawing.Point(8, 8)
        Me.initFormLogoPictureBox.Size = New System.Drawing.Size(224, 64)
        '
        'lblUserName
        '
        Me.lblUserName.Location = New System.Drawing.Point(24, 96)
        Me.lblUserName.Size = New System.Drawing.Size(72, 20)
        Me.lblUserName.Text = "User Name"
        Me.lblUserName.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'lblPassword
        '
        Me.lblPassword.Location = New System.Drawing.Point(24, 128)
        Me.lblPassword.Size = New System.Drawing.Size(72, 20)
        Me.lblPassword.Text = "Password"
        Me.lblPassword.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'txtUserName
        '
        Me.txtUserName.Location = New System.Drawing.Point(104, 96)
        Me.txtUserName.Text = ""
        '
        'txtPassword
        '
        Me.txtPassword.Location = New System.Drawing.Point(104, 128)
        Me.txtPassword.PasswordChar = Microsoft.VisualBasic.ChrW(42)
        Me.txtPassword.Text = ""
        '
        'btnLogin
        '
        Me.btnLogin.Location = New System.Drawing.Point(86, 192)
        Me.btnLogin.Text = "Login"
        '
        'lblDescription
        '
        Me.lblDescription.Location = New System.Drawing.Point(18, 224)
        Me.lblDescription.Size = New System.Drawing.Size(208, 20)
        Me.lblDescription.Text = "Temporary Password Request String"
        '
        'lblPassString
        '
        Me.lblPassString.Location = New System.Drawing.Point(72, 248)
        Me.lblPassString.Size = New System.Drawing.Size(100, 16)
        '
        'lblValidating
        '
        Me.lblValidating.Location = New System.Drawing.Point(72, 160)
        '
        'TagTrakLogin
        '
        Me.ControlBox = False
        Me.Controls.Add(Me.lblValidating)
        Me.Controls.Add(Me.lblPassString)
        Me.Controls.Add(Me.lblDescription)
        Me.Controls.Add(Me.btnLogin)
        Me.Controls.Add(Me.txtPassword)
        Me.Controls.Add(Me.txtUserName)
        Me.Controls.Add(Me.lblPassword)
        Me.Controls.Add(Me.lblUserName)
        Me.Controls.Add(Me.initFormLogoPictureBox)
        Me.MaximizeBox = False
        Me.Menu = Me.MainMenu1
        Me.MinimizeBox = False
        Me.Text = "TagTrak Login"

    End Sub

#End Region

    'Dim passwordFilePath As String = TagTrakConfigDirectory & "\password.txt"
    'Dim accessLogFilePath As String = TagTrakConfigDirectory & "\AccessLog.txt"
    Dim passwordFilePath As String = TagTrakConfigDirectory & "\password.txt"
    Dim accessLogFilePath As String = TagTrakConfigDirectory & "\AccessLog.txt"
    Dim passwordRecord As String
    Dim passwordRecordFields() As String
    Dim userName As String
    Dim password As String
    Dim carriers As String

    'Public Shared Sub Main()

    '    Try
    '        Application.Run(New TagTrakLogin)
    '    Catch ex As Exception
    '        MsgBox("An unexpected error occurred: " & vbCrLf _
    '        & ex.Message & ". " & vbCrLf _
    '        & "Please reboot the device.")
    '    End Try

    'End Sub

    Private Sub btnLogin_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnLogin.Click

        Dim passwordType As String

        btnLogin.Enabled = False
        lblValidating.Text = "Validating..."
        Application.DoEvents()

        passwordType = getPasswordType(txtPassword.Text.Trim)

        If passwordType = "Login" Then

            loginUserName = txtUserName.Text

            WriteLogRecord(True)

            Me.Close()
            Exit Sub

        End If

        If passwordType = "Exit" Then
            Me.Close()
            Application.Exit()
            Exit Sub
        End If

        'Establish ftp connection using generic username/password and get encrypted password file
        If DownloadPasswordFile() Then

            If Authenticated() Then

                loginUserName = txtUserName.Text

                WriteLogRecord(True)

                Me.Close()
                Exit Sub

            Else
                lblValidating.Text = ""
                MsgBox("Your username or password is not correct, please try again or contact your administrator!")
            End If

        Else

            If File.Exists(passwordFilePath) Then

                Dim fileInfo As New FileInfo(passwordFilePath)

                If (DateTime.Compare(DateTime.Now, fileInfo.LastWriteTime.AddHours(72)) < 0) Then

                    If Authenticated() Then

                        loginUserName = txtUserName.Text

                        WriteLogRecord(True)

                        Me.Close()
                        Exit Sub

                    Else
                        lblValidating.Text = ""
                        MsgBox("Your username or password is not correct, please try again or contact your administrator!")
                    End If

                Else
                    lblValidating.Text = ""
                    MsgBox("Password file is invalid. Please connect to the network and login again or contact your administrator!")
                End If

            Else

                lblValidating.Text = ""
                MsgBox("Password file does not exist. Please connect to the network and login again or contact your administrator!")

            End If

        End If

        btnLogin.Enabled = True
        lblValidating.Text = ""

    End Sub

    Private Function DownloadPasswordFile() As Boolean

        Dim ftp As New Ftp

        Dim ftpServerName As String = "ftp.asiscan.com"
        Dim ftpServerPort As Integer = 21
        Dim ftpUserName As String = "asi_general"
        Dim ftpPassword As String = "g3n3r@l!ti3s"
        Dim ftpRemotePath As String = "/scanner_passwd.gz"
        Dim ftpLocalPath As String = TagTrakConfigDirectory & "\scanner_passwd.gz"
        Dim ftpRemoteFileDate As Date
        Dim localPasswdFileDate As Date

        Dim localPasswdStampFilePath As String = TagTrakConfigDirectory & "\passwdTimeStamp.txt"

        If File.Exists(localPasswdStampFilePath) Then

            If getDateStampFromDateStampFile(localPasswdStampFilePath, localPasswdFileDate) <> "OK" Then
                localPasswdFileDate = Date.MinValue
            End If

        Else
            localPasswdFileDate = Date.MinValue
        End If


        Dim ethernetFlag As Boolean = True

        'Connecting using proxy (copied from FtpProcessClass)
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

        Try
            ftp.Connect(ftpServerName, ftpServerPort)
        Catch ex As Exception
            ethernetFlag = False
        End Try

        If Not ethernetFlag Then

            Dim lastUsedLocation As String = getLastLocation()

            If lastUsedLocation.Trim.Length = 0 Then

                If ftpConnectWireless(120) <> "OK" Then
                    Return False
                End If

                Try
                    ftp.Connect(ftpServerName, ftpServerPort)
                Catch ex As Exception
                    Return False
                End Try

            Else

                'If userSpecRecord.cityTable.ContainsKey(scanLocation.currentLocation) Then
                If userSpecRecord.cityTable.ContainsKey(lastUsedLocation.Trim) Then

                    Dim cityConfig As CityConfig = CType(userSpecRecord.cityTable.Item(lastUsedLocation.Trim), CityConfig)

                    If cityConfig.GetSetWireless Or cityConfig.GetSetWireless802 Then

                        If ftpConnectWireless(120) <> "OK" Then
                            Return False
                        End If

                        Try
                            ftp.Connect(ftpServerName, ftpServerPort)
                        Catch ex As Exception
                            Return False
                        End Try

                    Else
                        Return False
                    End If

                Else
                    Return False
                End If

            End If

        End If

        Try
            ftp.Login(ftpUserName, ftpPassword)
        Catch ex As Exception
            Return False
        End Try

        Try
            ftp.SetTransferType(FtpTransferType.Binary)
        Catch ex As Exception
            Return False
        End Try

        Try
            ftpRemoteFileDate = ftp.GetFileDateTime(ftpRemotePath)
        Catch ex As Exception
            Return False
        End Try

        If Date.Compare(localPasswdFileDate, ftpRemoteFileDate) < 0 Then

            Try
                ftp.GetFile(ftpRemotePath, ftpLocalPath)
            Catch ex As Exception
                Return False
            End Try

            Try
                If ftp.State <> FtpState.Disconnected Then
                    ftp.Disconnect()
                    ftp.Dispose()
                End If
            Catch ex As Exception
                Return False
            End Try

            Try
                ftpDisconnectWireless()
            Catch ex As Exception
                Return False
            End Try

            Try
                gunzip(ftpLocalPath, passwordFilePath)
                deleteLocalFile(ftpLocalPath)
            Catch ex As Exception
                Return False
            End Try

            Try
                If saveDateStampToDateStampFile(ftpRemoteFileDate, localPasswdStampFilePath) <> "OK" Then
                    Return False
                End If
            Catch ex As Exception
                Return False
            End Try

        End If

        Return True

    End Function

    Private Function Authenticated() As Boolean

        Dim userNameHash As String
        Dim passwordHash As String
        Dim carrierFields() As String

        'passwordTable.Clear()
        userNameHash = GenerateHashDigest(txtUserName.Text.Trim)
        passwordHash = GenerateHashDigest(txtPassword.Text.Trim)

        Try

            Dim sr As New StreamReader(passwordFilePath)

            While True

                passwordRecord = sr.ReadLine

                If passwordRecord Is Nothing Then
                    Exit While
                End If

                passwordRecordFields = passwordRecord.Split(vbTab)

                userName = passwordRecordFields(0).Trim.ToUpper
                password = passwordRecordFields(1).Trim.ToUpper
                carriers = passwordRecordFields(2).Trim

                If String.equals(userNameHash, userName) And String.equals(passwordHash, password) Then

                    Dim carrier As String

                    carrierFields = carriers.Split(":")

                    For Each carrier In carrierFields

                        'If userSpecRecord.carrierCode.ToUpper = carrier.Trim.ToUpper Then
                        If TagTrakBaseConfigParms.user.ToUpper = carrier.Trim.ToUpper Then
                            sr.Close()
                            Return True

                        End If

                    Next

                End If

            End While

            sr.Close()
            Return False

        Catch ex As Exception

            Return False

        End Try

    End Function

    Private Function GenerateHashDigest(ByVal source As String) As String

        Dim AsciiEncode As Encoding = Encoding.ASCII
        Dim bytSource() As Byte = AsciiEncode.GetBytes(source)
        Dim bytHashs() As Byte
        Dim hexHashValue As String

        Dim md5 As New MD5CryptoServiceProvider

        bytHashs = md5.ComputeHash(bytSource)

        For Each bytHash As Byte In bytHashs

            If Hex(bytHash).Length = 1 Then
                hexHashValue &= "0"
            End If

            hexHashValue &= Hex(bytHash)

        Next

        Return hexHashValue.ToUpper

    End Function


    Private Sub TextBox_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtUserName.GotFocus, txtPassword.GotFocus

#If deviceType <> "PC" Then

        If userSpecRecord.showKeyboardOnFocus Then
            Me.InputPanel1.Enabled = True
        End If

#End If

    End Sub

    Private Sub TagTrakLogin_Activated(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Activated

        lblPassString.Text = enterPasswordForm()

    End Sub


    Private Function ftpConnectWireless(ByVal timeoutValue As Integer) As String

        Dim i As Integer = 0

        ftpConnectionState = 0

        ftpDisconnectWireless()

        Try

            cm.Connect(True, OpenNETCF.Net.ConnectionMode.Asynchronous)

        Catch ex As Exception

            Return ex.Message

        End Try

        For i = 1 To timeoutValue

            Application.DoEvents()

            Select Case ftpConnectionState

                Case 0
                    Sleep(1000)

                Case 1
                    'Sleep(1000)
                    Return "OK"

                Case -1

                    Return "Connection failed."

                Case Else
                    Sleep(1000)

            End Select

        Next i

        Return "Unable to connect after " & timeoutValue & " seconds."

    End Function

    Public Sub ftpDisconnectWireless()

        If Not cm Is Nothing Then
            cm.Disconnect()
        End If

    End Sub

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

    Public Function WriteLogRecord(ByVal login As Boolean) As String

        Dim sw As New StreamWriter(accessLogFilePath, True)

        Try

            If login = True Then
                sw.WriteLine("User Login:" & loginUserName & vbTab & String.Format("{0:yyyy-MM-dd" & vbTab & "HH:mm:ss}", DateTime.UtcNow))
            Else
                sw.WriteLine("User Logout:" & loginUserName & vbTab & String.Format("{0:yyyy-MM-dd" & vbTab & "HH:mm:ss}", DateTime.UtcNow))
            End If

            sw.Flush()

        Catch ex As Exception

            sw.Close()
            Return "Login/Logout recording failed"

        End Try

        sw.Close()
        Return "OK"

    End Function

    Private Sub loadInitFormLogo()

        Dim initFormLogoPath As String

        If Not userSpecRecord Is Nothing Then

            initFormLogoPath = TagTrakConfigDirectory & "\" & userSpecRecord.userName & "initFormLogo.bmp"

            If File.Exists(initFormLogoPath) Then
                initFormLogoPictureBox.Image = New System.Drawing.Bitmap(initFormLogoPath)
                Exit Sub
            End If

        End If

        initFormLogoPath = TagTrakConfigDirectory & "\initFormLogo.bmp"

        If File.Exists(initFormLogoPath) Then
            initFormLogoPictureBox.Image = New System.Drawing.Bitmap(initFormLogoPath)
        End If

    End Sub

    Private Sub TagTrakLogin_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        loadInitFormLogo()
    End Sub

End Class
