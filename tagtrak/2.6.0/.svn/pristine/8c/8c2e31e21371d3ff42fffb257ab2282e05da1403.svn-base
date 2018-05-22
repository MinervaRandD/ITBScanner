Imports System
Imports System.IO

Public Class getCarditRouteForm
    Inherits System.Windows.Forms.Form

    Dim routingString As String

    Dim textBoxList() As System.Windows.Forms.TextBox

    Public cbxCarrierList() As ComboBox

    public tbxFlightNumberList() As TextBox 

    Public cbxCityList() As ComboBox

    Public strIntlBarcode As String

    Private baseFormCheckBox As System.Windows.Forms.CheckBox


#Region " Windows Form Designer generated code "

    Public Sub New()

        MyBase.New()

        Cursor.Current = Cursors.WaitCursor

#If ValidationLevel >= 3 Then

	if diagnosticLevel >= 2 then
            verify(Not inputRoutingString Is Nothing, 1)
        end if

#End If
        ignoreCbxCheckCarditBarCode_CheckStateChanged = True

        InitializeComponent()

        cbxCarrierList = New ComboBox() { _
            Me.cbxCarrierLeg1, _
            Me.cbxCarrierLeg2, _
            Me.cbxCarrierLeg3, _
            Me.cbxCarrierLeg4, _
            Me.cbxCarrierLeg5, _
            Me.cbxCarrierLeg6, _
            Me.cbxCarrierLeg7}

        tbxFlightNumberList = New TextBox() { _
            Me.tbxFlightLeg1, _
            Me.tbxFlightLeg2, _
            Me.tbxFlightLeg3, _
            Me.tbxFlightLeg4, _
            Me.tbxFlightLeg5, _
            Me.tbxFlightLeg6, _
            Me.tbxFlightLeg7}

        cbxCityList = New ComboBox() { _
            Me.cbxCity1, _
            Me.cbxCity2, _
            Me.cbxCity3, _
            Me.cbxCity4, _
            Me.cbxCity5, _
            Me.cbxCity6, _
            Me.cbxCity7, _
            Me.Origin}


        Dim cbxCarrierCode As ComboBox
        Dim tbxFlightNumber As TextBox
        Dim cbxCityCode As ComboBox

        Dim carrierCodeList() As Object
        If userSpecRecord.CarditRouteCarrierList.Count() > 0 Then
            carrierCodeList = userSpecRecord.CarditRouteCarrierList.ToArray()
        Else
            carrierCodeList = New String() {userSpecRecord.carrierCode}
        End If

        For Each cbxCarrierCode In Me.cbxCarrierList
            cbxCarrierCode.Items.Add("")
            Dim airlineCode As String
            For Each airlineCode In carrierCodeList
                cbxCarrierCode.Items.Add(airlineCode)
            Next
        Next

        Dim cityCodeList() As Object
        If userSpecRecord.CarditRouteCityList.Count() > 0 Then
            cityCodeList = userSpecRecord.CarditRouteCityList.ToArray()
        Else
            cityCodeList = Data.Cities.List.ToArray()
        End If

        For Each cbxCityCode In Me.cbxCityList
            Dim locationCode As String
            cbxCityCode.Items.Add("")
            For Each locationCode In cityCodeList
                cbxCityCode.Items.Add(locationCode)
            Next
        Next

        ignoreCbxCheckCarditBarCode_CheckStateChanged = False

        Cursor.Current = Cursors.Default

    End Sub

    Public Sub init(ByVal inputIntlBarcode As String, ByRef prompt As System.Windows.Forms.CheckBox)

        ignoreCbxCheckCarditBarCode_CheckStateChanged = True
        cbxCheckCarditBarCode.Checked = prompt.Checked
        ignoreCbxCheckCarditBarCode_CheckStateChanged = False

        Dim cbxCarrierCode As ComboBox
        Dim tbxFlightNumber As TextBox
        Dim cbxCityCode As ComboBox
        Dim cbxCountryCode As ComboBox

        For Each cbxCarrierCode In Me.cbxCarrierList
            cbxCarrierCode.SelectedIndex = -1
        Next

        For Each tbxFlightNumber In Me.tbxFlightNumberList
            tbxFlightNumber.Text = ""
        Next

        For Each cbxCityCode In Me.cbxCityList
            cbxCityCode.SelectedIndex = -1
        Next

        Me.Origin.SelectedItem = scanLocation.currentLocation

        strIntlBarcode = inputIntlBarcode

        Me.baseFormCheckBox = prompt

    End Sub

    Protected Overloads Overrides Sub Dispose(ByVal disposing As Boolean)
        MyBase.Dispose(disposing)
    End Sub

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    Friend WithEvents OKButton As System.Windows.Forms.Button
    Friend WithEvents cancelButton As System.Windows.Forms.Button
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents btnHelp As System.Windows.Forms.Button
    Friend WithEvents cbxCarrierLeg2 As System.Windows.Forms.ComboBox
    Friend WithEvents cbxCarrierLeg3 As System.Windows.Forms.ComboBox
    Friend WithEvents cbxCarrierLeg4 As System.Windows.Forms.ComboBox
    Friend WithEvents cbxCarrierLeg1 As System.Windows.Forms.ComboBox
    Friend WithEvents cbxCity2 As System.Windows.Forms.ComboBox
    Friend WithEvents cbxCity3 As System.Windows.Forms.ComboBox
    Friend WithEvents cbxCarrierLeg5 As System.Windows.Forms.ComboBox
    Friend WithEvents cbxCity5 As System.Windows.Forms.ComboBox
    Friend WithEvents cbxCity4 As System.Windows.Forms.ComboBox
    Friend WithEvents cbxCarrierLeg6 As System.Windows.Forms.ComboBox
    Friend WithEvents cbxCity6 As System.Windows.Forms.ComboBox
    Friend WithEvents cbxCity1 As System.Windows.Forms.ComboBox
    Friend WithEvents tbxFlightLeg1 As System.Windows.Forms.TextBox
    Friend WithEvents tbxFlightLeg2 As System.Windows.Forms.TextBox
    Friend WithEvents tbxFlightLeg3 As System.Windows.Forms.TextBox
    Friend WithEvents tbxFlightLeg4 As System.Windows.Forms.TextBox
    Friend WithEvents tbxFlightLeg5 As System.Windows.Forms.TextBox
    Friend WithEvents tbxFlightLeg6 As System.Windows.Forms.TextBox
    Public WithEvents cbxCheckCarditBarCode As System.Windows.Forms.CheckBox
    Friend WithEvents tbxFlightLeg7 As System.Windows.Forms.TextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents cbxCarrierLeg7 As System.Windows.Forms.ComboBox
    Friend WithEvents cbxCity7 As System.Windows.Forms.ComboBox
    Friend WithEvents MainMenu1 As System.Windows.Forms.MainMenu
#If deviceType <> "PC" Then
    Friend WithEvents InputPanel1 As Microsoft.WindowsCE.Forms.InputPanel
#End If
    Friend WithEvents OriginLabel As System.Windows.Forms.Label
    Friend WithEvents Origin As System.Windows.Forms.ComboBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.OKButton = New System.Windows.Forms.Button
        Me.cancelButton = New System.Windows.Forms.Button
        Me.cbxCarrierLeg2 = New System.Windows.Forms.ComboBox
        Me.cbxCity2 = New System.Windows.Forms.ComboBox
        Me.cbxCarrierLeg3 = New System.Windows.Forms.ComboBox
        Me.cbxCity3 = New System.Windows.Forms.ComboBox
        Me.cbxCarrierLeg5 = New System.Windows.Forms.ComboBox
        Me.cbxCity5 = New System.Windows.Forms.ComboBox
        Me.cbxCarrierLeg4 = New System.Windows.Forms.ComboBox
        Me.cbxCity4 = New System.Windows.Forms.ComboBox
        Me.cbxCarrierLeg6 = New System.Windows.Forms.ComboBox
        Me.cbxCity6 = New System.Windows.Forms.ComboBox
        Me.Label3 = New System.Windows.Forms.Label
        Me.Label4 = New System.Windows.Forms.Label
        Me.Label5 = New System.Windows.Forms.Label
        Me.cbxCarrierLeg1 = New System.Windows.Forms.ComboBox
        Me.cbxCity1 = New System.Windows.Forms.ComboBox
        Me.tbxFlightLeg1 = New System.Windows.Forms.TextBox
        Me.Label6 = New System.Windows.Forms.Label
        Me.Label7 = New System.Windows.Forms.Label
        Me.Label8 = New System.Windows.Forms.Label
        Me.Label9 = New System.Windows.Forms.Label
        Me.Label10 = New System.Windows.Forms.Label
        Me.Label11 = New System.Windows.Forms.Label
        Me.btnHelp = New System.Windows.Forms.Button
        Me.tbxFlightLeg2 = New System.Windows.Forms.TextBox
        Me.tbxFlightLeg3 = New System.Windows.Forms.TextBox
        Me.tbxFlightLeg4 = New System.Windows.Forms.TextBox
        Me.tbxFlightLeg5 = New System.Windows.Forms.TextBox
        Me.tbxFlightLeg6 = New System.Windows.Forms.TextBox
        Me.cbxCheckCarditBarCode = New System.Windows.Forms.CheckBox
        Me.tbxFlightLeg7 = New System.Windows.Forms.TextBox
        Me.Label2 = New System.Windows.Forms.Label
        Me.cbxCarrierLeg7 = New System.Windows.Forms.ComboBox
        Me.cbxCity7 = New System.Windows.Forms.ComboBox
        Me.MainMenu1 = New System.Windows.Forms.MainMenu
#If deviceType <> "PC" Then
        Me.InputPanel1 = New Microsoft.WindowsCE.Forms.InputPanel
#End If
        Me.OriginLabel = New System.Windows.Forms.Label
        Me.Origin = New System.Windows.Forms.ComboBox
        Me.Label1 = New System.Windows.Forms.Label
        '
        'OKButton
        '
        Me.OKButton.Location = New System.Drawing.Point(40, 216)
        Me.OKButton.Size = New System.Drawing.Size(56, 24)
        Me.OKButton.Text = "OK"
        '
        'cancelButton
        '
        Me.cancelButton.Location = New System.Drawing.Point(104, 216)
        Me.cancelButton.Size = New System.Drawing.Size(56, 24)
        Me.cancelButton.Text = "Cancel"
        '
        'cbxCarrierLeg2
        '
        Me.cbxCarrierLeg2.Location = New System.Drawing.Point(88, 48)
        Me.cbxCarrierLeg2.Size = New System.Drawing.Size(40, 22)
        '
        'cbxCity2
        '
        Me.cbxCity2.Location = New System.Drawing.Point(184, 48)
        Me.cbxCity2.Size = New System.Drawing.Size(48, 22)
        '
        'cbxCarrierLeg3
        '
        Me.cbxCarrierLeg3.Location = New System.Drawing.Point(88, 72)
        Me.cbxCarrierLeg3.Size = New System.Drawing.Size(40, 22)
        '
        'cbxCity3
        '
        Me.cbxCity3.Location = New System.Drawing.Point(184, 72)
        Me.cbxCity3.Size = New System.Drawing.Size(48, 22)
        '
        'cbxCarrierLeg5
        '
        Me.cbxCarrierLeg5.Location = New System.Drawing.Point(88, 120)
        Me.cbxCarrierLeg5.Size = New System.Drawing.Size(40, 22)
        '
        'cbxCity5
        '
        Me.cbxCity5.Location = New System.Drawing.Point(184, 120)
        Me.cbxCity5.Size = New System.Drawing.Size(48, 22)
        '
        'cbxCarrierLeg4
        '
        Me.cbxCarrierLeg4.Location = New System.Drawing.Point(88, 96)
        Me.cbxCarrierLeg4.Size = New System.Drawing.Size(40, 22)
        '
        'cbxCity4
        '
        Me.cbxCity4.Location = New System.Drawing.Point(184, 96)
        Me.cbxCity4.Size = New System.Drawing.Size(48, 22)
        '
        'cbxCarrierLeg6
        '
        Me.cbxCarrierLeg6.Location = New System.Drawing.Point(88, 144)
        Me.cbxCarrierLeg6.Size = New System.Drawing.Size(40, 22)
        '
        'cbxCity6
        '
        Me.cbxCity6.Location = New System.Drawing.Point(184, 144)
        Me.cbxCity6.Size = New System.Drawing.Size(48, 22)
        '
        'Label3
        '
        Me.Label3.Location = New System.Drawing.Point(88, 8)
        Me.Label3.Size = New System.Drawing.Size(32, 16)
        Me.Label3.Text = "Carr."
        Me.Label3.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'Label4
        '
        Me.Label4.Location = New System.Drawing.Point(136, 8)
        Me.Label4.Size = New System.Drawing.Size(32, 16)
        Me.Label4.Text = "Flgt."
        Me.Label4.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'Label5
        '
        Me.Label5.Location = New System.Drawing.Point(192, 8)
        Me.Label5.Size = New System.Drawing.Size(32, 16)
        Me.Label5.Text = "Dest."
        Me.Label5.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'cbxCarrierLeg1
        '
        Me.cbxCarrierLeg1.Location = New System.Drawing.Point(88, 24)
        Me.cbxCarrierLeg1.Size = New System.Drawing.Size(40, 22)
        '
        'cbxCity1
        '
        Me.cbxCity1.Location = New System.Drawing.Point(184, 24)
        Me.cbxCity1.Size = New System.Drawing.Size(48, 22)
        '
        'tbxFlightLeg1
        '
        Me.tbxFlightLeg1.Location = New System.Drawing.Point(136, 24)
        Me.tbxFlightLeg1.Size = New System.Drawing.Size(40, 22)
        Me.tbxFlightLeg1.Text = "0000"
        '
        'Label6
        '
        Me.Label6.Location = New System.Drawing.Point(8, 24)
        Me.Label6.Size = New System.Drawing.Size(16, 16)
        Me.Label6.Text = "1"
        Me.Label6.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'Label7
        '
        Me.Label7.Location = New System.Drawing.Point(8, 48)
        Me.Label7.Size = New System.Drawing.Size(16, 16)
        Me.Label7.Text = "2"
        Me.Label7.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'Label8
        '
        Me.Label8.Location = New System.Drawing.Point(8, 72)
        Me.Label8.Size = New System.Drawing.Size(16, 16)
        Me.Label8.Text = "3"
        Me.Label8.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'Label9
        '
        Me.Label9.Location = New System.Drawing.Point(8, 144)
        Me.Label9.Size = New System.Drawing.Size(16, 16)
        Me.Label9.Text = "6"
        Me.Label9.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'Label10
        '
        Me.Label10.Location = New System.Drawing.Point(8, 120)
        Me.Label10.Size = New System.Drawing.Size(16, 16)
        Me.Label10.Text = "5"
        Me.Label10.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'Label11
        '
        Me.Label11.Location = New System.Drawing.Point(8, 96)
        Me.Label11.Size = New System.Drawing.Size(16, 16)
        Me.Label11.Text = "4"
        Me.Label11.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'btnHelp
        '
        Me.btnHelp.Font = New System.Drawing.Font("Tahoma", 12.0!, System.Drawing.FontStyle.Bold)
        Me.btnHelp.Location = New System.Drawing.Point(8, 216)
        Me.btnHelp.Size = New System.Drawing.Size(24, 24)
        Me.btnHelp.Text = "?"
        '
        'tbxFlightLeg2
        '
        Me.tbxFlightLeg2.Location = New System.Drawing.Point(136, 48)
        Me.tbxFlightLeg2.Size = New System.Drawing.Size(40, 22)
        Me.tbxFlightLeg2.Text = "0000"
        '
        'tbxFlightLeg3
        '
        Me.tbxFlightLeg3.Location = New System.Drawing.Point(136, 72)
        Me.tbxFlightLeg3.Size = New System.Drawing.Size(40, 22)
        Me.tbxFlightLeg3.Text = "0000"
        '
        'tbxFlightLeg4
        '
        Me.tbxFlightLeg4.Location = New System.Drawing.Point(136, 96)
        Me.tbxFlightLeg4.Size = New System.Drawing.Size(40, 22)
        Me.tbxFlightLeg4.Text = "0000"
        '
        'tbxFlightLeg5
        '
        Me.tbxFlightLeg5.Location = New System.Drawing.Point(136, 120)
        Me.tbxFlightLeg5.Size = New System.Drawing.Size(40, 22)
        Me.tbxFlightLeg5.Text = "0000"
        '
        'tbxFlightLeg6
        '
        Me.tbxFlightLeg6.Location = New System.Drawing.Point(136, 144)
        Me.tbxFlightLeg6.Size = New System.Drawing.Size(40, 22)
        Me.tbxFlightLeg6.Text = "0000"
        '
        'cbxCheckCarditBarCode
        '
        Me.cbxCheckCarditBarCode.Checked = True
        Me.cbxCheckCarditBarCode.CheckState = System.Windows.Forms.CheckState.Checked
        Me.cbxCheckCarditBarCode.Location = New System.Drawing.Point(168, 216)
        Me.cbxCheckCarditBarCode.Size = New System.Drawing.Size(64, 24)
        Me.cbxCheckCarditBarCode.Text = "Prompt"
        '
        'tbxFlightLeg7
        '
        Me.tbxFlightLeg7.Location = New System.Drawing.Point(136, 168)
        Me.tbxFlightLeg7.Size = New System.Drawing.Size(40, 22)
        Me.tbxFlightLeg7.Text = "0000"
        '
        'Label2
        '
        Me.Label2.Location = New System.Drawing.Point(8, 168)
        Me.Label2.Size = New System.Drawing.Size(16, 16)
        Me.Label2.Text = "7"
        Me.Label2.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'cbxCarrierLeg7
        '
        Me.cbxCarrierLeg7.Location = New System.Drawing.Point(88, 168)
        Me.cbxCarrierLeg7.Size = New System.Drawing.Size(40, 22)
        '
        'cbxCity7
        '
        Me.cbxCity7.Location = New System.Drawing.Point(184, 168)
        Me.cbxCity7.Size = New System.Drawing.Size(48, 22)
        '
        'OriginLabel
        '
        Me.OriginLabel.Location = New System.Drawing.Point(40, 8)
        Me.OriginLabel.Size = New System.Drawing.Size(40, 20)
        Me.OriginLabel.Text = "Origin"
        '
        'Origin
        '
        Me.Origin.Location = New System.Drawing.Point(32, 24)
        Me.Origin.Size = New System.Drawing.Size(48, 22)
        '
        'Label1
        '
        Me.Label1.Location = New System.Drawing.Point(8, 8)
        Me.Label1.Size = New System.Drawing.Size(24, 20)
        Me.Label1.Text = "Leg"
        '
        'getCarditRouteForm
        '
        Me.ClientSize = New System.Drawing.Size(234, 288)
        Me.ControlBox = False
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.Origin)
        Me.Controls.Add(Me.OriginLabel)
        Me.Controls.Add(Me.tbxFlightLeg7)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.cbxCarrierLeg7)
        Me.Controls.Add(Me.cbxCity7)
        Me.Controls.Add(Me.cbxCheckCarditBarCode)
        Me.Controls.Add(Me.tbxFlightLeg6)
        Me.Controls.Add(Me.tbxFlightLeg5)
        Me.Controls.Add(Me.tbxFlightLeg4)
        Me.Controls.Add(Me.tbxFlightLeg3)
        Me.Controls.Add(Me.tbxFlightLeg2)
        Me.Controls.Add(Me.btnHelp)
        Me.Controls.Add(Me.Label9)
        Me.Controls.Add(Me.Label10)
        Me.Controls.Add(Me.Label11)
        Me.Controls.Add(Me.Label8)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.cbxCarrierLeg1)
        Me.Controls.Add(Me.cbxCity1)
        Me.Controls.Add(Me.tbxFlightLeg1)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.cbxCarrierLeg6)
        Me.Controls.Add(Me.cbxCity6)
        Me.Controls.Add(Me.cbxCarrierLeg5)
        Me.Controls.Add(Me.cbxCity5)
        Me.Controls.Add(Me.cbxCarrierLeg4)
        Me.Controls.Add(Me.cbxCity4)
        Me.Controls.Add(Me.cbxCarrierLeg3)
        Me.Controls.Add(Me.cbxCity3)
        Me.Controls.Add(Me.cancelButton)
        Me.Controls.Add(Me.OKButton)
        Me.Controls.Add(Me.cbxCarrierLeg2)
        Me.Controls.Add(Me.cbxCity2)
        Me.Menu = Me.MainMenu1
        Me.Text = "Specify Package Routing"

    End Sub

#End Region

    Private Sub OKButton_Click(ByVal sender As System.Object, ByVal e As EventArgs) Handles OKButton.Click

        'Below is validation before proceed
        If Not FlightNumberValidation(tbxFlightLeg1.Text) Then
            MsgBox("The flight number of leg 1 is not valid.")
            Exit Sub
        End If

        If Not FlightNumberValidation(tbxFlightLeg2.Text) Then
            MsgBox("The flight number of leg 2 is not valid.")
            Exit Sub
        End If

        If Not FlightNumberValidation(tbxFlightLeg3.Text) Then
            MsgBox("The flight number of leg 3 is not valid.")
            Exit Sub
        End If

        If Not FlightNumberValidation(tbxFlightLeg4.Text) Then
            MsgBox("The flight number of leg 4 is not valid.")
            Exit Sub
        End If

        If Not FlightNumberValidation(tbxFlightLeg5.Text) Then
            MsgBox("The flight number of leg 5 is not valid.")
            Exit Sub
        End If

        If Not FlightNumberValidation(tbxFlightLeg6.Text) Then
            MsgBox("The flight number of leg 6 is not valid.")
            Exit Sub
        End If

        If Not FlightNumberValidation(tbxFlightLeg7.Text) Then
            MsgBox("The flight number of leg 7 is not valid.")
            Exit Sub
        End If

        Dim carditRouting As New CarditRoutingClass(Me)

        If Not carditRouting.isValid() Then
            MsgBox("The specified routing is invalid. Click on the help button for more information, or cancel to close this form.", MsgBoxStyle.OKOnly, "Invalid Routing")
            Exit Sub
        End If

        ' This really can't happen, but check anyway

        If carditRecordTable.ContainsKey(carditRouting.strIntlBarCode) Then
            MsgBox("The specified routing is is already in the table", MsgBoxStyle.OKOnly, "Duplicate Routing")
            Exit Sub
        End If

        Dim carditRoutingRecord As New CarditRoutingRecord(carditRouting.creationDateStamp)

        carditRecordTable.Add(carditRouting.strIntlBarCode, carditRoutingRecord)

        Dim outputFileStream As StreamWriter

        Try
            outputFileStream = New StreamWriter(carditRoutingFilePath, True)
        Catch ex As Exception
            MsgBox("Attempt to open cardit routings file " & carditRoutingFilePath & " failed: " & ex.Message)
            Exit Sub
        End Try

        Try
            outputFileStream.WriteLine(carditRouting.ToString())
        Catch ex As Exception
            MsgBox("Attempt to write to cardit routings file " & carditRoutingFilePath & " failed: " & ex.Message)
            Exit Sub
        End Try

        outputFileStream.Flush()
        outputFileStream.Close()

        Me.Hide()

    End Sub

    Private Sub cancelButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cancelButton.Click

        Me.Hide()

    End Sub

    Private Sub btnHelp_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnHelp.Click

        Dim msMsgGetCarditRoutingHelp As New MsMsgGetCarditRoutingHelp
        msMsgGetCarditRoutingHelp.Show()
    End Sub


    Public ignoreCbxCheckCarditBarCode_CheckStateChanged As Boolean = False

    Private Sub cbxCheckCarditBarCode_CheckStateChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cbxCheckCarditBarCode.CheckStateChanged

        If ignoreCbxCheckCarditBarCode_CheckStateChanged Then Exit Sub

        Me.baseFormCheckBox.Checked = cbxCheckCarditBarCode.Checked

    End Sub

    Private Function FlightNumberValidation(ByVal flightNumber As String) As Boolean

        Dim flightNumberArray() As Char

        If flightNumber.Trim.Length <= 4 Then

            flightNumberArray = flightNumber.Trim.ToCharArray

            For Each flightNumberChar As Char In flightNumberArray
                If Not Char.IsDigit(flightNumberChar) Then
                    Return False
                End If
            Next

        Else

            Return False

        End If

        Return True

    End Function


End Class
