Imports System
Imports System.IO

Public Class MailScanManifestForm

    Inherits System.Windows.Forms.Form
    Friend WithEvents OKButton As System.Windows.Forms.Button
    Friend WithEvents carrierTextBox1 As System.Windows.Forms.TextBox
    Friend WithEvents flightTextBox1 As System.Windows.Forms.TextBox
    Friend WithEvents destTextBox1 As System.Windows.Forms.TextBox
    Friend WithEvents originTextBox As System.Windows.Forms.TextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label15 As System.Windows.Forms.Label

#Region " Windows Form Designer generated code "

    Public Sub New()

        MyBase.New()

        Cursor.Current = Cursors.WaitCursor

        'This call is required by the Windows Form Designer.
        InitializeComponent()

        Cursor.Current = Cursors.Default

    End Sub



    Protected Overloads Overrides Sub Dispose(ByVal disposing As Boolean)
        MyBase.Dispose(disposing)
    End Sub

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    Friend WithEvents Label16 As System.Windows.Forms.Label
    Friend WithEvents Label17 As System.Windows.Forms.Label
    Friend WithEvents Label18 As System.Windows.Forms.Label
    Friend WithEvents Label19 As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents clearButton As System.Windows.Forms.Button
    Friend WithEvents exitButton As System.Windows.Forms.Button
    Friend WithEvents manifestIDTextBox As System.Windows.Forms.TextBox
    Friend WithEvents dateTextBox As System.Windows.Forms.TextBox
    Friend WithEvents timeTextBox As System.Windows.Forms.TextBox
    Friend WithEvents weightTextBox As System.Windows.Forms.TextBox
    Friend WithEvents pieceCountTextBox As System.Windows.Forms.TextBox
    Friend WithEvents carrierTextBox2 As System.Windows.Forms.TextBox
    Friend WithEvents flightTextBox2 As System.Windows.Forms.TextBox
    Friend WithEvents destTextBox2 As System.Windows.Forms.TextBox
    Friend WithEvents carrierTextBox3 As System.Windows.Forms.TextBox
    Friend WithEvents flightTextBox3 As System.Windows.Forms.TextBox
    Friend WithEvents destTextBox3 As System.Windows.Forms.TextBox
    Friend WithEvents carrierTextBox4 As System.Windows.Forms.TextBox
    Friend WithEvents flightTextBox4 As System.Windows.Forms.TextBox
    Friend WithEvents destTextBox4 As System.Windows.Forms.TextBox
    Friend WithEvents MainMenu1 As System.Windows.Forms.MainMenu
#If deviceType <> "PC" Then
    Friend WithEvents InputPanel1 As Microsoft.WindowsCE.Forms.InputPanel
#End If
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents txtMailType As System.Windows.Forms.TextBox
    Friend WithEvents txtPriority As System.Windows.Forms.TextBox
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.clearButton = New System.Windows.Forms.Button
        Me.OKButton = New System.Windows.Forms.Button
        Me.carrierTextBox1 = New System.Windows.Forms.TextBox
        Me.flightTextBox1 = New System.Windows.Forms.TextBox
        Me.destTextBox1 = New System.Windows.Forms.TextBox
        Me.originTextBox = New System.Windows.Forms.TextBox
        Me.Label2 = New System.Windows.Forms.Label
        Me.manifestIDTextBox = New System.Windows.Forms.TextBox
        Me.Label15 = New System.Windows.Forms.Label
        Me.Label16 = New System.Windows.Forms.Label
        Me.dateTextBox = New System.Windows.Forms.TextBox
        Me.Label17 = New System.Windows.Forms.Label
        Me.timeTextBox = New System.Windows.Forms.TextBox
        Me.Label18 = New System.Windows.Forms.Label
        Me.weightTextBox = New System.Windows.Forms.TextBox
        Me.Label19 = New System.Windows.Forms.Label
        Me.pieceCountTextBox = New System.Windows.Forms.TextBox
        Me.Label6 = New System.Windows.Forms.Label
        Me.Label7 = New System.Windows.Forms.Label
        Me.Label8 = New System.Windows.Forms.Label
        Me.carrierTextBox2 = New System.Windows.Forms.TextBox
        Me.flightTextBox2 = New System.Windows.Forms.TextBox
        Me.destTextBox2 = New System.Windows.Forms.TextBox
        Me.carrierTextBox3 = New System.Windows.Forms.TextBox
        Me.flightTextBox3 = New System.Windows.Forms.TextBox
        Me.destTextBox3 = New System.Windows.Forms.TextBox
        Me.carrierTextBox4 = New System.Windows.Forms.TextBox
        Me.flightTextBox4 = New System.Windows.Forms.TextBox
        Me.destTextBox4 = New System.Windows.Forms.TextBox
        Me.Label3 = New System.Windows.Forms.Label
        Me.Label4 = New System.Windows.Forms.Label
        Me.Label5 = New System.Windows.Forms.Label
        Me.Label9 = New System.Windows.Forms.Label
        Me.exitButton = New System.Windows.Forms.Button
        Me.MainMenu1 = New System.Windows.Forms.MainMenu
#If deviceType <> "PC" Then
        Me.InputPanel1 = New Microsoft.WindowsCE.Forms.InputPanel
#End If
        Me.Label1 = New System.Windows.Forms.Label
        Me.Label10 = New System.Windows.Forms.Label
        Me.txtMailType = New System.Windows.Forms.TextBox
        Me.Label11 = New System.Windows.Forms.Label
        Me.txtPriority = New System.Windows.Forms.TextBox
        '
        'clearButton
        '
        Me.clearButton.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold)
        Me.clearButton.Location = New System.Drawing.Point(120, 236)
        Me.clearButton.Size = New System.Drawing.Size(48, 26)
        Me.clearButton.Text = "Clear"
        '
        'OKButton
        '
        Me.OKButton.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold)
        Me.OKButton.Location = New System.Drawing.Point(8, 236)
        Me.OKButton.Size = New System.Drawing.Size(104, 26)
        Me.OKButton.Text = "Create Record"
        '
        'carrierTextBox1
        '
        Me.carrierTextBox1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular)
        Me.carrierTextBox1.Location = New System.Drawing.Point(144, 128)
        Me.carrierTextBox1.Size = New System.Drawing.Size(32, 21)
        Me.carrierTextBox1.Text = ""
        '
        'flightTextBox1
        '
        Me.flightTextBox1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular)
        Me.flightTextBox1.Location = New System.Drawing.Point(88, 128)
        Me.flightTextBox1.Size = New System.Drawing.Size(48, 21)
        Me.flightTextBox1.Text = ""
        '
        'destTextBox1
        '
        Me.destTextBox1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular)
        Me.destTextBox1.Location = New System.Drawing.Point(184, 128)
        Me.destTextBox1.Size = New System.Drawing.Size(40, 21)
        Me.destTextBox1.Text = ""
        '
        'originTextBox
        '
        Me.originTextBox.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular)
        Me.originTextBox.Location = New System.Drawing.Point(40, 128)
        Me.originTextBox.Size = New System.Drawing.Size(40, 21)
        Me.originTextBox.Text = ""
        '
        'Label2
        '
        Me.Label2.Location = New System.Drawing.Point(40, 112)
        Me.Label2.Size = New System.Drawing.Size(32, 12)
        Me.Label2.Text = "Start"
        '
        'manifestIDTextBox
        '
        Me.manifestIDTextBox.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular)
        Me.manifestIDTextBox.Location = New System.Drawing.Point(112, 8)
        Me.manifestIDTextBox.Size = New System.Drawing.Size(112, 21)
        Me.manifestIDTextBox.Text = ""
        '
        'Label15
        '
        Me.Label15.Location = New System.Drawing.Point(8, 8)
        Me.Label15.Size = New System.Drawing.Size(104, 16)
        Me.Label15.Text = "Manifest Number:"
        '
        'Label16
        '
        Me.Label16.Location = New System.Drawing.Point(8, 32)
        Me.Label16.Size = New System.Drawing.Size(32, 16)
        Me.Label16.Text = "Date:"
        '
        'dateTextBox
        '
        Me.dateTextBox.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular)
        Me.dateTextBox.Location = New System.Drawing.Point(48, 32)
        Me.dateTextBox.Size = New System.Drawing.Size(72, 21)
        Me.dateTextBox.Text = ""
        '
        'Label17
        '
        Me.Label17.Location = New System.Drawing.Point(128, 32)
        Me.Label17.Size = New System.Drawing.Size(32, 16)
        Me.Label17.Text = "Time"
        '
        'timeTextBox
        '
        Me.timeTextBox.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular)
        Me.timeTextBox.Location = New System.Drawing.Point(168, 32)
        Me.timeTextBox.Size = New System.Drawing.Size(56, 21)
        Me.timeTextBox.Text = ""
        '
        'Label18
        '
        Me.Label18.Location = New System.Drawing.Point(120, 56)
        Me.Label18.Size = New System.Drawing.Size(48, 16)
        Me.Label18.Text = "Weight"
        '
        'weightTextBox
        '
        Me.weightTextBox.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular)
        Me.weightTextBox.Location = New System.Drawing.Point(168, 56)
        Me.weightTextBox.Size = New System.Drawing.Size(56, 21)
        Me.weightTextBox.Text = ""
        '
        'Label19
        '
        Me.Label19.Location = New System.Drawing.Point(8, 56)
        Me.Label19.Size = New System.Drawing.Size(40, 16)
        Me.Label19.Text = "Pieces"
        '
        'pieceCountTextBox
        '
        Me.pieceCountTextBox.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular)
        Me.pieceCountTextBox.Location = New System.Drawing.Point(48, 56)
        Me.pieceCountTextBox.Size = New System.Drawing.Size(40, 21)
        Me.pieceCountTextBox.Text = ""
        '
        'Label6
        '
        Me.Label6.Location = New System.Drawing.Point(136, 112)
        Me.Label6.Size = New System.Drawing.Size(48, 16)
        Me.Label6.Text = "Carrier"
        Me.Label6.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'Label7
        '
        Me.Label7.Location = New System.Drawing.Point(72, 112)
        Me.Label7.Size = New System.Drawing.Size(64, 16)
        Me.Label7.Text = "Flight Nbr"
        Me.Label7.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'Label8
        '
        Me.Label8.Location = New System.Drawing.Point(184, 112)
        Me.Label8.Size = New System.Drawing.Size(40, 16)
        Me.Label8.Text = "Dest"
        Me.Label8.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'carrierTextBox2
        '
        Me.carrierTextBox2.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular)
        Me.carrierTextBox2.Location = New System.Drawing.Point(144, 152)
        Me.carrierTextBox2.Size = New System.Drawing.Size(32, 21)
        Me.carrierTextBox2.Text = ""
        '
        'flightTextBox2
        '
        Me.flightTextBox2.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular)
        Me.flightTextBox2.Location = New System.Drawing.Point(88, 152)
        Me.flightTextBox2.Size = New System.Drawing.Size(48, 21)
        Me.flightTextBox2.Text = ""
        '
        'destTextBox2
        '
        Me.destTextBox2.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular)
        Me.destTextBox2.Location = New System.Drawing.Point(184, 152)
        Me.destTextBox2.Size = New System.Drawing.Size(40, 21)
        Me.destTextBox2.Text = ""
        '
        'carrierTextBox3
        '
        Me.carrierTextBox3.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular)
        Me.carrierTextBox3.Location = New System.Drawing.Point(144, 176)
        Me.carrierTextBox3.Size = New System.Drawing.Size(32, 21)
        Me.carrierTextBox3.Text = ""
        '
        'flightTextBox3
        '
        Me.flightTextBox3.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular)
        Me.flightTextBox3.Location = New System.Drawing.Point(88, 176)
        Me.flightTextBox3.Size = New System.Drawing.Size(48, 21)
        Me.flightTextBox3.Text = ""
        '
        'destTextBox3
        '
        Me.destTextBox3.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular)
        Me.destTextBox3.Location = New System.Drawing.Point(184, 176)
        Me.destTextBox3.Size = New System.Drawing.Size(40, 21)
        Me.destTextBox3.Text = ""
        '
        'carrierTextBox4
        '
        Me.carrierTextBox4.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular)
        Me.carrierTextBox4.Location = New System.Drawing.Point(144, 200)
        Me.carrierTextBox4.Size = New System.Drawing.Size(32, 21)
        Me.carrierTextBox4.Text = ""
        '
        'flightTextBox4
        '
        Me.flightTextBox4.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular)
        Me.flightTextBox4.Location = New System.Drawing.Point(88, 200)
        Me.flightTextBox4.Size = New System.Drawing.Size(48, 21)
        Me.flightTextBox4.Text = ""
        '
        'destTextBox4
        '
        Me.destTextBox4.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular)
        Me.destTextBox4.Location = New System.Drawing.Point(184, 200)
        Me.destTextBox4.Size = New System.Drawing.Size(40, 21)
        Me.destTextBox4.Text = ""
        '
        'Label3
        '
        Me.Label3.Location = New System.Drawing.Point(8, 128)
        Me.Label3.Size = New System.Drawing.Size(16, 18)
        Me.Label3.Text = "1"
        Me.Label3.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'Label4
        '
        Me.Label4.Location = New System.Drawing.Point(8, 152)
        Me.Label4.Size = New System.Drawing.Size(16, 18)
        Me.Label4.Text = "2"
        Me.Label4.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'Label5
        '
        Me.Label5.Location = New System.Drawing.Point(8, 200)
        Me.Label5.Size = New System.Drawing.Size(16, 18)
        Me.Label5.Text = "4"
        Me.Label5.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'Label9
        '
        Me.Label9.Location = New System.Drawing.Point(8, 176)
        Me.Label9.Size = New System.Drawing.Size(16, 18)
        Me.Label9.Text = "3"
        Me.Label9.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'exitButton
        '
        Me.exitButton.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold)
        Me.exitButton.Location = New System.Drawing.Point(176, 236)
        Me.exitButton.Size = New System.Drawing.Size(48, 26)
        Me.exitButton.Text = "Exit"
        '
        'Label1
        '
        Me.Label1.Location = New System.Drawing.Point(8, 112)
        Me.Label1.Size = New System.Drawing.Size(24, 16)
        Me.Label1.Text = "Leg"
        '
        'Label10
        '
        Me.Label10.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular)
        Me.Label10.Location = New System.Drawing.Point(8, 84)
        Me.Label10.Size = New System.Drawing.Size(60, 16)
        Me.Label10.Text = "Mail Type"
        '
        'txtMailType
        '
        Me.txtMailType.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular)
        Me.txtMailType.Location = New System.Drawing.Point(68, 80)
        Me.txtMailType.Size = New System.Drawing.Size(40, 21)
        Me.txtMailType.Text = ""
        '
        'Label11
        '
        Me.Label11.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular)
        Me.Label11.Location = New System.Drawing.Point(120, 84)
        Me.Label11.Size = New System.Drawing.Size(48, 16)
        Me.Label11.Text = "Priority"
        '
        'txtPriority
        '
        Me.txtPriority.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular)
        Me.txtPriority.Location = New System.Drawing.Point(168, 80)
        Me.txtPriority.Size = New System.Drawing.Size(56, 21)
        Me.txtPriority.Text = ""
        '
        'MailScanManifestForm
        '
        Me.ClientSize = New System.Drawing.Size(234, 288)
        Me.ControlBox = False
        Me.Controls.Add(Me.txtPriority)
        Me.Controls.Add(Me.Label11)
        Me.Controls.Add(Me.txtMailType)
        Me.Controls.Add(Me.Label10)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.exitButton)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.Label9)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.carrierTextBox4)
        Me.Controls.Add(Me.flightTextBox4)
        Me.Controls.Add(Me.destTextBox4)
        Me.Controls.Add(Me.carrierTextBox3)
        Me.Controls.Add(Me.flightTextBox3)
        Me.Controls.Add(Me.destTextBox3)
        Me.Controls.Add(Me.carrierTextBox2)
        Me.Controls.Add(Me.flightTextBox2)
        Me.Controls.Add(Me.destTextBox2)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.Label8)
        Me.Controls.Add(Me.Label18)
        Me.Controls.Add(Me.weightTextBox)
        Me.Controls.Add(Me.Label19)
        Me.Controls.Add(Me.pieceCountTextBox)
        Me.Controls.Add(Me.Label17)
        Me.Controls.Add(Me.timeTextBox)
        Me.Controls.Add(Me.Label16)
        Me.Controls.Add(Me.dateTextBox)
        Me.Controls.Add(Me.Label15)
        Me.Controls.Add(Me.manifestIDTextBox)
        Me.Controls.Add(Me.clearButton)
        Me.Controls.Add(Me.OKButton)
        Me.Controls.Add(Me.carrierTextBox1)
        Me.Controls.Add(Me.flightTextBox1)
        Me.Controls.Add(Me.destTextBox1)
        Me.Controls.Add(Me.originTextBox)
        Me.Controls.Add(Me.Label2)
        Me.Menu = Me.MainMenu1
        Me.Text = "Create Manifest Record"

    End Sub

#End Region


    Public scanType As String

    Private Sub formOnLoad(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        Dim currentDateAndTime As DateTime = Time.Local.GetTime(scannerTimeZone)

        dateTextBox.Text = String.Format("{0:d}", currentDateAndTime)
        timeTextBox.Text = String.Format("{0:HH:mm:ss}", currentDateAndTime)

    End Sub

    'Private Sub formKeyPress(ByVal sender As System.Object, ByVal ex As KeyPressEventArgs) Handles MyBase.KeyPress

    '    If ex.KeyChar = "0" Then
    '        exitString = ""
    '        Exit Sub
    '    End If

    '    exitString &= ex.KeyChar

    '    If isValidExitPassword(exitString) Then
    '        appExitFlag.exitFlag = True
    '        Me.Close()
    '    End If

    'End Sub

    Private Function genRouteExtension(ByVal inputFlightString As String, ByVal inputCarrierString As String, ByVal inputDestinationString As String) As String

#If ValidationLevel >= 3 Then

        if diagnosticLevel >= 2 then

             verify(not inputFlightString is nothing, 1100)
             verify(not inputCarrierString is nothing, 1101)
             verify(not inputCarrierString is nothing, 1102)

	end if

#End If

        Dim flightString As String = ""
        Dim carrierString As String = ""
        Dim destinationString As String = ""

        If isNonNullString(inputFlightString) Then flightString = Trim(inputFlightString)
        If isNonNullString(inputCarrierString) Then carrierString = Trim(inputCarrierString).ToUpper
        If isNonNullString(inputDestinationString) Then destinationString = Trim(inputDestinationString).ToUpper

        If Not (isNonNullString(flightString) Or isNonNullString(carrierString) Or isNonNullString(destinationString)) Then
            Return ""
        End If

        If Not Util.isValidFlightNumber(flightString) Then
            Return "Invalid or missing flight number"
        End If

        If Not Util.isValidCarrierCode(carrierString) Then
            Return "Invalid or missing carrier code"
        End If

        If Not Util.isValidLocation(destinationString) Then
            Return "Invalid or missing destination"
        End If

        Return flightString.PadLeft(4, "0") & "," & carrierString & "," & destinationString

    End Function

    Private Sub OKButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles OKButton.Click

        Dim manifestID As String = ""
        Dim manifestDateString As String = ""
        Dim manifestDateTime As DateTime
        Dim manifestTimeString As String = ""
        Dim manifestDateTimeString As String = ""
        Dim manifestPieceCountString As String = ""
        Dim manifestPieceCount As Integer
        Dim manifestWeightString As String
        Dim manifestWeight As Integer
        Dim manifestOrigin As String
        Dim routeList As New ArrayList
        Dim routeString1 As String = ""
        Dim routeString2 As String = ""
        Dim routeString3 As String = ""
        Dim routeString4 As String = ""

        routeList.Clear()

        If Not manifestIDTextBox.Text Is Nothing Then
            manifestID = Trim(manifestIDTextBox.Text).ToUpper
        End If

        If Not Util.isValidManifestID(manifestID) Then
            MsgBox("The manifest ID must be a 10 character alpha numeric string.", MsgBoxStyle.Exclamation, "Invalid Manifest ID")
            Exit Sub
        End If

        If Not dateTextBox.Text Is Nothing Then
            manifestDateString = Trim(dateTextBox.Text)
        End If

        If Not isNonNullString(manifestDateString) Then
            MsgBox("A date must be specified to create a manifest record.", MsgBoxStyle.Exclamation, "Missing Date")
        End If

        If Not timeTextBox.Text Is Nothing Then
            manifestTimeString = Trim(timeTextBox.Text)
        End If

        If Not isNonNullString(manifestTimeString) Then
            MsgBox("A time must be specified to create a manifest record.", MsgBoxStyle.Exclamation, "Missing Date")
        End If

        manifestDateTimeString = manifestDateString & " " & manifestTimeString

        Try
            manifestDateTime = DateTime.Parse(manifestDateTimeString)
        Catch ex As Exception
            MsgBox("Invalid date or time specified.", MsgBoxStyle.Exclamation, "Invalid Date Or Time")
            Exit Sub
        End Try

        If Not pieceCountTextBox.Text Is Nothing Then
            manifestPieceCountString = Trim(pieceCountTextBox.Text)
        End If

        If Not Util.IsInteger(manifestPieceCountString) Then
            MsgBox("Invalid piece count specified.", MsgBoxStyle.Exclamation, "Invalid piece count")
            Exit Sub
        End If

        Try
            manifestPieceCount = Integer.Parse(manifestPieceCountString)
        Catch ex As Exception
            MsgBox("Invalid piece count specified.", MsgBoxStyle.Exclamation, "Invalid piece count")
            Exit Sub
        End Try

        If Not weightTextBox.Text Is Nothing Then
            manifestWeightString = Trim(weightTextBox.Text)
        End If

        If Not Util.IsInteger(manifestWeightString) Then
            MsgBox("Invalid weight specified.", MsgBoxStyle.Exclamation, "Invalid weight")
            Exit Sub
        End If

        Try
            manifestWeight = Integer.Parse(manifestWeightString)
        Catch ex As Exception
            MsgBox("Invalid weight specified.", MsgBoxStyle.Exclamation, "Invalid weight")
            Exit Sub
        End Try

        If Not MailTypeValidation(txtMailType.Text.Trim) Then
            MsgBox("Invalid mail type specified. It must be one character.", MsgBoxStyle.Exclamation, "Invalid mail type")
        End If

        If Not PriorityValidation(txtPriority.Text.Trim) Then
            MsgBox("Invalid priority specified. It must be two characters.", MsgBoxStyle.Exclamation, "Invalid priority")
        End If

        If Not originTextBox.Text Is Nothing Then
            manifestOrigin = Trim(originTextBox.Text)
        End If

        If Not Util.isValidLocation(manifestOrigin) Then
            MsgBox("Invalid route origin specified.", MsgBoxStyle.Exclamation, "Invalid route origin")
            Exit Sub
        End If

        routeString1 = genRouteExtension(flightTextBox1.Text, carrierTextBox1.Text, destTextBox1.Text)

        If routeString1.StartsWith("Invalid") Then
            MsgBox("Invalid flight leg specified for leg 1: " & routeString1, MsgBoxStyle.Exclamation, "Invalid Flight Leg")
            Exit Sub
        End If

        If isNonNullString(routeString1) Then
            routeList.Add(routeString1)
        End If

        routeString2 = genRouteExtension(flightTextBox2.Text, carrierTextBox2.Text, destTextBox2.Text)

        If routeString2.StartsWith("Invalid") Then
            MsgBox("Invalid flight leg specified for leg 2: " & routeString2, MsgBoxStyle.Exclamation, "Invalid Flight Leg")
            Exit Sub
        End If

        If isNonNullString(routeString2) Then
            routeList.Add(routeString2)
        End If

        routeString3 = genRouteExtension(flightTextBox3.Text, carrierTextBox3.Text, destTextBox3.Text)

        If routeString3.StartsWith("Invalid") Then
            MsgBox("Invalid flight leg specified for leg 3: " & routeString3, MsgBoxStyle.Exclamation, "Invalid Flight Leg")
            Exit Sub
        End If

        If isNonNullString(routeString3) Then
            routeList.Add(routeString3)
        End If

        routeString4 = genRouteExtension(flightTextBox4.Text, carrierTextBox4.Text, destTextBox4.Text)

        If routeString4.StartsWith("Invalid") Then
            MsgBox("Invalid flight leg specified for leg 4: " & routeString4, MsgBoxStyle.Exclamation, "Invalid Flight Leg")
            Exit Sub
        End If

        If isNonNullString(routeString4) Then
            routeList.Add(routeString4)
        End If

        If routeList.Count <= 0 Then
            MsgBox("At least one flight leg must be specified.", MsgBoxStyle.Exclamation, "Missing Flight Leg")
            Exit Sub
        End If

        Dim outputString As String

        outputString = scanType & TagTrakGlobals.fieldSepChar & manifestID & TagTrakGlobals.fieldSepChar & String.Format("{0:MM/dd/yyyy" & TagTrakGlobals.fieldSepChar & "HH:mm:ss}", manifestDateTime)
        outputString &= TagTrakGlobals.fieldSepChar & manifestPieceCount.ToString & TagTrakGlobals.fieldSepChar & manifestWeight.ToString
        outputString &= TagTrakGlobals.fieldSepChar & txtMailType.Text.Trim & TagTrakGlobals.fieldSepChar & txtPriority.Text.Trim & TagTrakGlobals.fieldSepChar & "[" & manifestOrigin.ToUpper

        Dim routeString As String

        For Each routeString In routeList
            outputString &= "," & routeString
        Next

        outputString &= "]"

        Dim outputStream As StreamWriter

        Try
            outputStream = New StreamWriter(manifestFilePath, True)
        Catch ex As Exception
            MsgBox("Attempt to open the manifest file failed: " & ex.Message, MsgBoxStyle.Exclamation, "Open Of Manifest File Failed")
            Exit Sub
        End Try

        Try
            outputStream.WriteLine(outputString)
        Catch ex As Exception
            outputStream.Close()
            MsgBox("Attempt to write to manifest file failed: " & ex.Message, MsgBoxStyle.Exclamation, "Write To Manifest File Failed")
            Exit Sub
        End Try

        outputStream.Close()

        ''Save current time zone at time of manifest creation
        userSpecRecord.scanRecordSet.TimeZoneUsed.OffsetUTC = scannerTimeZone.OffsetInfo.OffsetUTC

        MsgBox("Manifest saved.", , "TagTrak")

        clearButton_Click(Nothing, Nothing)

    End Sub

    Private Sub clearButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles clearButton.Click

        manifestIDTextBox.Text = ""
        dateTextBox.Text = ""
        timeTextBox.Text = ""
        pieceCountTextBox.Text = ""
        weightTextBox.Text = ""
        originTextBox.Text = ""

        flightTextBox1.Text = ""
        carrierTextBox1.Text = ""
        destTextBox1.Text = ""

        flightTextBox2.Text = ""
        carrierTextBox2.Text = ""
        destTextBox2.Text = ""

        flightTextBox3.Text = ""
        carrierTextBox3.Text = ""
        destTextBox3.Text = ""

        flightTextBox4.Text = ""
        carrierTextBox4.Text = ""
        destTextBox4.Text = ""

        Dim currentDateAndTime As DateTime = Time.Local.GetTime(scannerTimeZone)

        dateTextBox.Text = String.Format("{0:d}", currentDateAndTime)
        timeTextBox.Text = String.Format("{0:HH:mm:ss}", currentDateAndTime)

        txtMailType.Text = ""
        txtPriority.Text = ""

    End Sub

    Private Sub exitButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles exitButton.Click
        Me.Hide()
    End Sub

    Private Function MailTypeValidation(ByVal mailType As String) As Boolean

        If mailType.Length = 1 Then
            If Char.IsLetter(mailType.Chars(0)) Then
                Return True
            End If
        End If

        Return False

    End Function

    Private Function PriorityValidation(ByVal priority As String) As Boolean

        If priority.Length = 2 Then
            If Char.IsLetter(priority.Chars(0)) And Char.IsLetter(priority.Chars(1)) Then
                Return True
            End If
        End If

        Return False

    End Function
End Class
