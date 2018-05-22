Imports System.IO

Public Class FlightStatusMessage
    Inherits System.Windows.Forms.Form
    Friend WithEvents flightStatusOKButton As System.Windows.Forms.Button
    Private CurLocation As String = ""
    Private Shared Singlet As FlightStatusMessage = Nothing

    Public Shared Function GetInstance() As FlightStatusMessage
        If Singlet Is Nothing Then Singlet = New FlightStatusMessage(scanLocation.currentLocation)
        If Singlet.CurLocation <> scanLocation.currentLocation Then Singlet = New FlightStatusMessage(scanLocation.currentLocation)
        Return Singlet
    End Function

#Region " Windows Form Designer generated code "

    Private Sub New(ByVal location As String)
        MyBase.New()

        'This call is required by the Windows Form Designer.
        InitializeComponent()

        Me.CurLocation = location
        Me.LoadFlightList()


    End Sub

    Protected Overloads Overrides Sub Dispose(ByVal disposing As Boolean)
        MyBase.Dispose(disposing)
    End Sub

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    Friend WithEvents flightStatusCancelButton As System.Windows.Forms.Button
    Friend WithEvents arrivingFlightRadioButton As System.Windows.Forms.RadioButton
    Friend WithEvents departingFlightRadioButton As System.Windows.Forms.RadioButton
    Friend WithEvents arrivingFlightComboBox As System.Windows.Forms.ComboBox
    Friend WithEvents departingFlightComboBox As System.Windows.Forms.ComboBox
    Friend WithEvents Time As System.Windows.Forms.TextBox
    Friend WithEvents TimeLable As System.Windows.Forms.Label
    Friend WithEvents MainMenu1 As System.Windows.Forms.MainMenu
#If deviceType <> "PC" Then
    Friend WithEvents InputPanel1 As Microsoft.WindowsCE.Forms.InputPanel
#End If
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.flightStatusCancelButton = New System.Windows.Forms.Button
        Me.flightStatusOKButton = New System.Windows.Forms.Button
        Me.arrivingFlightRadioButton = New System.Windows.Forms.RadioButton
        Me.departingFlightRadioButton = New System.Windows.Forms.RadioButton
        Me.arrivingFlightComboBox = New System.Windows.Forms.ComboBox
        Me.departingFlightComboBox = New System.Windows.Forms.ComboBox
        Me.Time = New System.Windows.Forms.TextBox
        Me.TimeLable = New System.Windows.Forms.Label
        Me.MainMenu1 = New System.Windows.Forms.MainMenu
#If devicetype <> "PC" Then
        Me.InputPanel1 = New Microsoft.WindowsCE.Forms.InputPanel
#End If
        '
        'flightStatusCancelButton
        '
        Me.flightStatusCancelButton.Location = New System.Drawing.Point(144, 136)
        Me.flightStatusCancelButton.Size = New System.Drawing.Size(80, 29)
        Me.flightStatusCancelButton.Text = "Cancel"
        '
        'flightStatusOKButton
        '
        Me.flightStatusOKButton.Location = New System.Drawing.Point(56, 136)
        Me.flightStatusOKButton.Size = New System.Drawing.Size(80, 29)
        Me.flightStatusOKButton.Text = "OK"
        '
        'arrivingFlightRadioButton
        '
        Me.arrivingFlightRadioButton.Checked = True
        Me.arrivingFlightRadioButton.Location = New System.Drawing.Point(8, 24)
        Me.arrivingFlightRadioButton.Size = New System.Drawing.Size(116, 21)
        Me.arrivingFlightRadioButton.Text = "Arriving Into BOS"
        '
        'departingFlightRadioButton
        '
        Me.departingFlightRadioButton.Location = New System.Drawing.Point(8, 56)
        Me.departingFlightRadioButton.Size = New System.Drawing.Size(141, 21)
        Me.departingFlightRadioButton.Text = "Departing From BOS"
        '
        'arrivingFlightComboBox
        '
        Me.arrivingFlightComboBox.Location = New System.Drawing.Point(144, 24)
        Me.arrivingFlightComboBox.Size = New System.Drawing.Size(77, 22)
        '
        'departingFlightComboBox
        '
        Me.departingFlightComboBox.Enabled = False
        Me.departingFlightComboBox.Location = New System.Drawing.Point(144, 56)
        Me.departingFlightComboBox.Size = New System.Drawing.Size(77, 22)
        '
        'Time
        '
        Me.Time.Location = New System.Drawing.Point(144, 96)
        Me.Time.Size = New System.Drawing.Size(40, 22)
        Me.Time.Text = ""
        '
        'TimeLable
        '
        Me.TimeLable.Location = New System.Drawing.Point(8, 96)
        Me.TimeLable.Size = New System.Drawing.Size(120, 20)
        Me.TimeLable.Text = "Actual Time (hhmm)"
        '
        'FlightStatusMessage
        '
        Me.ClientSize = New System.Drawing.Size(234, 328)
        Me.ControlBox = False
        Me.Controls.Add(Me.TimeLable)
        Me.Controls.Add(Me.Time)
        Me.Controls.Add(Me.departingFlightComboBox)
        Me.Controls.Add(Me.arrivingFlightComboBox)
        Me.Controls.Add(Me.departingFlightRadioButton)
        Me.Controls.Add(Me.arrivingFlightRadioButton)
        Me.Controls.Add(Me.flightStatusCancelButton)
        Me.Controls.Add(Me.flightStatusOKButton)
        Me.Menu = Me.MainMenu1
        Me.Text = "Transmit Flight Status"

    End Sub

#End Region

    Public Sub init(ByVal arriveFlightList As ArrayList, ByVal departFlightList As ArrayList)

        Me.arrivingFlightRadioButton.Text = "Arriving Into " & scanLocation.currentLocation
        Me.departingFlightRadioButton.Text = "Departing From " & scanLocation.currentLocation

        Dim flightNumber As String

        Me.arrivingFlightComboBox.Items.Clear()
        Me.arrivingFlightComboBox.Items.Add("")

        Me.departingFlightComboBox.Items.Clear()
        Me.departingFlightComboBox.Items.Add("")

        For Each flightNumber In arriveFlightList
            Me.arrivingFlightComboBox.Items.Add(flightNumber)
        Next

        For Each flightNumber In departFlightList
            Me.departingFlightComboBox.Items.Add(flightNumber)
        Next

    End Sub

    'Private Sub formOnLoad(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

    '    MyBase.MaximizeBox = False
    '    MyBase.MinimizeBox = False
    '    MyBase.ControlBox = False
    '    MyBase.WindowState = FormWindowState.Maximized

    'End Sub

    Private Sub flightStatusOKButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles flightStatusOKButton.Click
        If Me.Validate() Then
            Me.SaveFlightStatus()
            Me.ClearInputs()
            Me.Hide()
        End If
    End Sub

    Private Sub flightStatusCancelButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles flightStatusCancelButton.Click
        Me.ClearInputs()
        Me.Hide()
    End Sub

    Private Sub arrivingFlightRadioButton_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles arrivingFlightRadioButton.CheckedChanged

        If Not arrivingFlightRadioButton.Checked Then Exit Sub

        Me.arrivingFlightComboBox.Enabled = True
        Me.departingFlightComboBox.Enabled = False

    End Sub

    Private Sub departingFlightRadioButton_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles departingFlightRadioButton.CheckedChanged

        If Not departingFlightRadioButton.Checked Then Exit Sub

        Me.arrivingFlightComboBox.Enabled = False
        Me.departingFlightComboBox.Enabled = True

    End Sub

    Private Sub LoadFlightList()
        Me.arrivingFlightRadioButton.Text = "Arriving Into " & Me.CurLocation
        Me.departingFlightRadioButton.Text = "Departing From " & Me.CurLocation

        Me.arrivingFlightComboBox.Items.Clear()
        Me.arrivingFlightComboBox.Items.Add("")

        Me.departingFlightComboBox.Items.Clear()
        Me.departingFlightComboBox.Items.Add("")

        Dim Flight As Data.FlightSchedule.Flights.Flight
        Dim Flights() As Data.FlightSchedule.Flights.Flight = flightScheduleSet.GetFlights()

        '' Sort flights using the default comparer
        Array.Sort(Flights)

        For Each Flight In Flights
            If Flight.Direction And Data.FlightSchedule.Flights.Flight.Directions.Inbound <> 0 Then
                Me.arrivingFlightComboBox.Items.Add(Flight.Number.ToString)
            End If
            If Flight.Direction And Data.FlightSchedule.Flights.Flight.Directions.Outbound <> 0 Then
                Me.departingFlightComboBox.Items.Add(Flight.Number.ToString)
            End If
        Next

    End Sub

    Private Sub FlightStatusMessage_Closed(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Closed
        Singlet = Nothing
    End Sub

    Private Function Validate() As Boolean
        If Me.arrivingFlightComboBox.SelectedItem <> "" _
            And Me.arrivingFlightRadioButton.Checked _
            Or Me.departingFlightComboBox.SelectedItem <> "" _
            And Me.departingFlightRadioButton.Checked Then
            If System.Text.RegularExpressions.Regex.Match(Time.Text, "^[0-9]{4}$").Success Then
                If Time.Text.Substring(0, 2) <= 23 And Time.Text.Substring(2, 2) <= 59 Then
                    Return True
                End If
            End If
            MsgBox("Missing or invalid time")
            Return False
        Else
            MsgBox("Please select flight")
            Return False
        End If
    End Function

    Private Sub SaveFlightStatus()
        Dim outputString As String = ""
        Dim flightNumber As String = ""

        If Me.arrivingFlightRadioButton.Checked Then
            flightNumber = Me.arrivingFlightComboBox.SelectedItem
        ElseIf Me.departingFlightRadioButton.Checked Then
            flightNumber = Me.departingFlightComboBox.SelectedItem
        End If

        outputString = flightNumber & TagTrakGlobals.fieldSepChar & Me.Time.Text.Substring(0, 2) & ":" & Me.Time.Text.Substring(2, 2)

        Dim outputStream As StreamWriter

        Try
            outputStream = New StreamWriter(flightStatusFilePath, True)
        Catch ex As Exception
            MsgBox("Attempt to open the flight status file failed: " & ex.Message, MsgBoxStyle.Exclamation, "Open Of Flight Status File Failed")
            Exit Sub
        End Try

        Try
            outputStream.WriteLine(outputString)
        Catch ex As Exception
            outputStream.Close()
            MsgBox("Attempt to write to flight status file failed: " & ex.Message, MsgBoxStyle.Exclamation, "Write To Flight Status File Failed")
            Exit Sub
        End Try
        outputStream.Close()

        '' Save time zone at time of flight status change
        userSpecRecord.scanRecordSet.TimeZoneUsed.OffsetUTC = scannerTimeZone.OffsetInfo.OffsetUTC

    End Sub

    Private Sub ClearInputs()
        Me.Time.Text = ""
        Me.departingFlightComboBox.SelectedIndex = 0
        Me.arrivingFlightComboBox.SelectedIndex = 0
    End Sub

    Private Sub Time_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles Time.GotFocus
#If deviceType <> "PC" Then
        If userSpecRecord.showKeyboardOnFocus Then Me.InputPanel1.Enabled = True
#End If
    End Sub
End Class
