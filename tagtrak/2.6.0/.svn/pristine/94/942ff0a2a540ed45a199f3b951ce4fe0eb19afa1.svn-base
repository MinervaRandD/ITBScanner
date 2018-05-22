Imports System
Imports System.IO

Public Class addRoutingForm
    Inherits System.Windows.Forms.Form
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label

    Dim routingString As String

    Dim textBoxList() As System.Windows.Forms.TextBox


#Region " Windows Form Designer generated code "

    Public Sub New(ByRef inputRoutingString As String)

        MyBase.New()

        Cursor.Current = Cursors.WaitCursor

#if ValidationLevel >= 3 then
        
	if diagnosticLevel >= 2 then
            verify(Not inputRoutingString Is Nothing, 1)
        end if

#endif

        'This call is required by the Windows Form Designer.
        InitializeComponent()

        routingString = inputRoutingString

        originTextBox.Text = ""

        destTextBox1.Text = ""
        destTextBox2.Text = ""
        destTextBox3.Text = ""
        destTextBox4.Text = ""

        flightTextBox1.Text = ""
        flightTextBox2.Text = ""
        flightTextBox3.Text = ""
        flightTextBox4.Text = ""

        carrierTextBox1.Text = ""
        carrierTextBox2.Text = ""
        carrierTextBox3.Text = ""
        carrierTextBox4.Text = ""

        'Add any initialization after the InitializeComponent() call

        Cursor.Current = Cursors.Default

    End Sub

    Protected Overloads Overrides Sub Dispose(ByVal disposing As Boolean)
        MyBase.Dispose(disposing)
    End Sub

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    Friend WithEvents originTextBox As System.Windows.Forms.TextBox
    Friend WithEvents destTextBox1 As System.Windows.Forms.TextBox
    Friend WithEvents flightTextBox1 As System.Windows.Forms.TextBox
    Friend WithEvents carrierTextBox1 As System.Windows.Forms.TextBox
    Friend WithEvents carrierTextBox2 As System.Windows.Forms.TextBox
    Friend WithEvents flightTextBox2 As System.Windows.Forms.TextBox
    Friend WithEvents destTextBox2 As System.Windows.Forms.TextBox
    Friend WithEvents carrierTextBox3 As System.Windows.Forms.TextBox
    Friend WithEvents flightTextBox3 As System.Windows.Forms.TextBox
    Friend WithEvents destTextBox3 As System.Windows.Forms.TextBox
    Friend WithEvents carrierTextBox4 As System.Windows.Forms.TextBox
    Friend WithEvents flightTextBox4 As System.Windows.Forms.TextBox
    Friend WithEvents destTextBox4 As System.Windows.Forms.TextBox
    Friend WithEvents OKButton As System.Windows.Forms.Button
    Friend WithEvents cancelButton As System.Windows.Forms.Button
    Friend WithEvents MainMenu1 As System.Windows.Forms.MainMenu
#If deviceType <> "PC" Then
    Friend WithEvents InputPanel1 As Microsoft.WindowsCE.Forms.InputPanel
#End If
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents Label9 As System.Windows.Forms.Label
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Dim resources As System.Resources.ResourceManager = New System.Resources.ResourceManager(GetType(addRoutingForm))
        Me.Label1 = New System.Windows.Forms.Label
        Me.Label2 = New System.Windows.Forms.Label
        Me.originTextBox = New System.Windows.Forms.TextBox
        Me.destTextBox1 = New System.Windows.Forms.TextBox
        Me.flightTextBox1 = New System.Windows.Forms.TextBox
        Me.carrierTextBox1 = New System.Windows.Forms.TextBox
        Me.Label3 = New System.Windows.Forms.Label
        Me.Label4 = New System.Windows.Forms.Label
        Me.Label5 = New System.Windows.Forms.Label
        Me.carrierTextBox2 = New System.Windows.Forms.TextBox
        Me.flightTextBox2 = New System.Windows.Forms.TextBox
        Me.destTextBox2 = New System.Windows.Forms.TextBox
        Me.carrierTextBox3 = New System.Windows.Forms.TextBox
        Me.flightTextBox3 = New System.Windows.Forms.TextBox
        Me.destTextBox3 = New System.Windows.Forms.TextBox
        Me.carrierTextBox4 = New System.Windows.Forms.TextBox
        Me.flightTextBox4 = New System.Windows.Forms.TextBox
        Me.destTextBox4 = New System.Windows.Forms.TextBox
        Me.OKButton = New System.Windows.Forms.Button
        Me.cancelButton = New System.Windows.Forms.Button
        Me.MainMenu1 = New System.Windows.Forms.MainMenu
#If deviceType <> "PC" Then
        Me.InputPanel1 = New Microsoft.WindowsCE.Forms.InputPanel
#End If
        Me.Label6 = New System.Windows.Forms.Label
        Me.Label7 = New System.Windows.Forms.Label
        Me.Label8 = New System.Windows.Forms.Label
        Me.Label9 = New System.Windows.Forms.Label
        '
        'Label1
        '
        Me.Label1.Location = New System.Drawing.Point(18, 184)
        Me.Label1.Size = New System.Drawing.Size(201, 42)
        Me.Label1.Text = "The routing of this package is not recognized. Please fill in the missing informa" & _
        "tion above."
        '
        'Label2
        '
        Me.Label2.Location = New System.Drawing.Point(8, 8)
        Me.Label2.Size = New System.Drawing.Size(87, 18)
        Me.Label2.Text = "ROUTE START:"
        '
        'originTextBox
        '
        Me.originTextBox.Location = New System.Drawing.Point(112, 8)
        Me.originTextBox.Size = New System.Drawing.Size(58, 22)
        Me.originTextBox.Text = ""
        '
        'destTextBox1
        '
        Me.destTextBox1.Location = New System.Drawing.Point(48, 64)
        Me.destTextBox1.Size = New System.Drawing.Size(50, 22)
        Me.destTextBox1.Text = ""
        '
        'flightTextBox1
        '
        Me.flightTextBox1.Location = New System.Drawing.Point(104, 64)
        Me.flightTextBox1.Size = New System.Drawing.Size(50, 22)
        Me.flightTextBox1.Text = ""
        '
        'carrierTextBox1
        '
        Me.carrierTextBox1.Location = New System.Drawing.Point(160, 64)
        Me.carrierTextBox1.Size = New System.Drawing.Size(50, 22)
        Me.carrierTextBox1.Text = ""
        '
        'Label3
        '
        Me.Label3.Location = New System.Drawing.Point(48, 40)
        Me.Label3.Size = New System.Drawing.Size(40, 16)
        Me.Label3.Text = "Dest."
        '
        'Label4
        '
        Me.Label4.Location = New System.Drawing.Point(96, 40)
        Me.Label4.Size = New System.Drawing.Size(61, 18)
        Me.Label4.Text = "On Flight"
        Me.Label4.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'Label5
        '
        Me.Label5.Location = New System.Drawing.Point(160, 40)
        Me.Label5.Size = New System.Drawing.Size(50, 18)
        Me.Label5.Text = "Carrier"
        Me.Label5.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'carrierTextBox2
        '
        Me.carrierTextBox2.Location = New System.Drawing.Point(160, 96)
        Me.carrierTextBox2.Size = New System.Drawing.Size(50, 22)
        Me.carrierTextBox2.Text = ""
        '
        'flightTextBox2
        '
        Me.flightTextBox2.Location = New System.Drawing.Point(104, 96)
        Me.flightTextBox2.Size = New System.Drawing.Size(50, 22)
        Me.flightTextBox2.Text = ""
        '
        'destTextBox2
        '
        Me.destTextBox2.Location = New System.Drawing.Point(48, 96)
        Me.destTextBox2.Size = New System.Drawing.Size(50, 22)
        Me.destTextBox2.Text = ""
        '
        'carrierTextBox3
        '
        Me.carrierTextBox3.Location = New System.Drawing.Point(160, 128)
        Me.carrierTextBox3.Size = New System.Drawing.Size(50, 22)
        Me.carrierTextBox3.Text = ""
        '
        'flightTextBox3
        '
        Me.flightTextBox3.Location = New System.Drawing.Point(104, 128)
        Me.flightTextBox3.Size = New System.Drawing.Size(50, 22)
        Me.flightTextBox3.Text = ""
        '
        'destTextBox3
        '
        Me.destTextBox3.Location = New System.Drawing.Point(48, 128)
        Me.destTextBox3.Size = New System.Drawing.Size(50, 22)
        Me.destTextBox3.Text = ""
        '
        'carrierTextBox4
        '
        Me.carrierTextBox4.Location = New System.Drawing.Point(160, 160)
        Me.carrierTextBox4.Size = New System.Drawing.Size(50, 22)
        Me.carrierTextBox4.Text = ""
        '
        'flightTextBox4
        '
        Me.flightTextBox4.Location = New System.Drawing.Point(104, 160)
        Me.flightTextBox4.Size = New System.Drawing.Size(50, 22)
        Me.flightTextBox4.Text = ""
        '
        'destTextBox4
        '
        Me.destTextBox4.Location = New System.Drawing.Point(48, 160)
        Me.destTextBox4.Size = New System.Drawing.Size(50, 22)
        Me.destTextBox4.Text = ""
        '
        'OKButton
        '
        Me.OKButton.Location = New System.Drawing.Point(32, 232)
        Me.OKButton.Size = New System.Drawing.Size(64, 26)
        Me.OKButton.Text = "OK"
        '
        'cancelButton
        '
        Me.cancelButton.Location = New System.Drawing.Point(104, 232)
        Me.cancelButton.Size = New System.Drawing.Size(62, 26)
        Me.cancelButton.Text = "Cancel"
        '
        'Label6
        '
        Me.Label6.Location = New System.Drawing.Point(8, 64)
        Me.Label6.Size = New System.Drawing.Size(24, 20)
        Me.Label6.Text = "1st"
        '
        'Label7
        '
        Me.Label7.Location = New System.Drawing.Point(8, 96)
        Me.Label7.Size = New System.Drawing.Size(32, 20)
        Me.Label7.Text = "2nd"
        '
        'Label8
        '
        Me.Label8.Location = New System.Drawing.Point(8, 128)
        Me.Label8.Size = New System.Drawing.Size(32, 20)
        Me.Label8.Text = "3rd"
        '
        'Label9
        '
        Me.Label9.Location = New System.Drawing.Point(8, 160)
        Me.Label9.Size = New System.Drawing.Size(24, 20)
        Me.Label9.Text = "4th"
        '
        'addRoutingForm
        '
        Me.ClientSize = New System.Drawing.Size(234, 288)
        Me.ControlBox = False
        Me.Controls.Add(Me.Label9)
        Me.Controls.Add(Me.Label8)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.cancelButton)
        Me.Controls.Add(Me.OKButton)
        Me.Controls.Add(Me.carrierTextBox4)
        Me.Controls.Add(Me.flightTextBox4)
        Me.Controls.Add(Me.destTextBox4)
        Me.Controls.Add(Me.carrierTextBox3)
        Me.Controls.Add(Me.flightTextBox3)
        Me.Controls.Add(Me.destTextBox3)
        Me.Controls.Add(Me.carrierTextBox2)
        Me.Controls.Add(Me.flightTextBox2)
        Me.Controls.Add(Me.destTextBox2)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.carrierTextBox1)
        Me.Controls.Add(Me.flightTextBox1)
        Me.Controls.Add(Me.destTextBox1)
        Me.Controls.Add(Me.originTextBox)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Menu = Me.MainMenu1
        Me.Text = "Add New Route"

    End Sub

#End Region

    Private Sub OKButton_Click(ByVal sender As System.Object, ByVal e As EventArgs) Handles OKButton.Click

        If Not Util.isValidLocation(originTextBox.Text) Then
            MsgBox("Invalid Routing: Missing or invalid origin.", MsgBoxStyle.Exclamation, "Invalid Origin")
            Exit Sub
        End If

        If Not Util.isValidLocation(destTextBox1.Text) Then
            MsgBox("Missing or invalid first destination (required).", MsgBoxStyle.Exclamation, "Invalid First Destination")
            Exit Sub
        End If

        If Not Util.isValidFlightNumber(flightTextBox1.Text) Then
            MsgBox("Missing or invalid first flight number (required).", MsgBoxStyle.Exclamation, "Invalid Flight Number")
            Exit Sub
        End If

        If Not Util.isValidCarrier(carrierTextBox1.Text) Then
            MsgBox("Missing or invalid first carrier code (required).", MsgBoxStyle.Exclamation, "Invalid Carrier Code")
            Exit Sub
        End If

        Dim newRoutingRecord As New newRoutingRecordClass

        newRoutingRecord.origin = originTextBox.Text.ToUpper

        newRoutingRecord.routingCode = routingString

        newRoutingRecord.destination(0) = destTextBox1.Text.ToUpper
        newRoutingRecord.destination(1) = destTextBox2.Text.ToUpper
        newRoutingRecord.destination(2) = destTextBox3.Text.ToUpper
        newRoutingRecord.destination(3) = destTextBox4.Text.ToUpper

        newRoutingRecord.flight(0) = flightTextBox1.Text.ToUpper
        newRoutingRecord.flight(1) = flightTextBox2.Text.ToUpper
        newRoutingRecord.flight(2) = flightTextBox3.Text.ToUpper
        newRoutingRecord.flight(3) = flightTextBox4.Text.ToUpper

        newRoutingRecord.carrier(0) = carrierTextBox1.Text.ToUpper
        newRoutingRecord.carrier(1) = carrierTextBox2.Text.ToUpper
        newRoutingRecord.carrier(2) = carrierTextBox3.Text.ToUpper
        newRoutingRecord.carrier(3) = carrierTextBox4.Text.ToUpper

        newRoutingsRecordSet.Add(newRoutingRecord)
        routingSet.add(routingString)

        Dim routingsFileStream As StreamWriter
        Dim localFilePath As String = deviceNonVolatileMemoryDirectory & selectedCarrierPath & "\Routings.txt"

        Try
            routingsFileStream = New StreamWriter(localFilePath, True)
        Catch ex As Exception
            MsgBox("Unable to open routings file " & localFilePath & " for append: " & ex.Message)
            Exit Sub
        End Try

        Try
            routingsFileStream.WriteLine(routingString)
        Catch ex As Exception
            MsgBox("Write of new routing to routings file failed: " & ex.Message)
        End Try

        routingsFileStream.Close()

        Me.Close()

    End Sub

    Private Sub cancelButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cancelButton.Click

        Me.Close()

    End Sub

End Class
