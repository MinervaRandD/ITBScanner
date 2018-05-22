Imports System
Imports System.IO

Public Class MailScanManifestSummaryForm
    Inherits System.Windows.Forms.Form
    Friend WithEvents summaryListBox As System.Windows.Forms.ListBox
    Friend WithEvents OKButton As System.Windows.Forms.Button

#Region " Windows Form Designer generated code "

    Public Sub New()
        MyBase.New()

        Cursor.Current = Cursors.WaitCursor

        'This call is required by the Windows Form Designer.
        InitializeComponent()

        'Add any initialization after the InitializeComponent() call

        Cursor.Current = Cursors.Default

    End Sub

    Protected Overloads Overrides Sub Dispose(ByVal disposing As Boolean)
        MyBase.Dispose(disposing)
    End Sub

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    Friend WithEvents LabelDate As System.Windows.Forms.Label
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.summaryListBox = New System.Windows.Forms.ListBox
        Me.OKButton = New System.Windows.Forms.Button
        Me.LabelDate = New System.Windows.Forms.Label
        '
        'summaryListBox
        '
        Me.summaryListBox.Font = New System.Drawing.Font("Lucida Console", 9.0!, System.Drawing.FontStyle.Regular)
        Me.summaryListBox.Location = New System.Drawing.Point(4, 32)
        Me.summaryListBox.Size = New System.Drawing.Size(232, 206)
        '
        'OKButton
        '
        Me.OKButton.Location = New System.Drawing.Point(72, 248)
        Me.OKButton.Size = New System.Drawing.Size(92, 30)
        Me.OKButton.Text = "OK"
        '
        'LabelDate
        '
        Me.LabelDate.Location = New System.Drawing.Point(8, 8)
        Me.LabelDate.Size = New System.Drawing.Size(224, 20)
        Me.LabelDate.TextAlign = System.Drawing.ContentAlignment.TopCenter
        Me.LabelDate.Visible = False
        '
        'MailScanManifestSummaryForm
        '
        Me.ClientSize = New System.Drawing.Size(240, 288)
        Me.ControlBox = False
        Me.Controls.Add(Me.LabelDate)
        Me.Controls.Add(Me.OKButton)
        Me.Controls.Add(Me.summaryListBox)
        Me.Text = "Manifest Summary"

    End Sub

#End Region

    Public Function loadSummaryInformation() As Boolean

        If currentSummaryFileIsValid Then
            loadCurrentSummaryInformation()
        Else
            loadPriliminarySummaryInformation()
        End If

    End Function

    Public Function loadCurrentSummaryInformation()

        '' Show date of summary
        Dim dateStampFilePath As String = TagTrakConfigDirectory & "\" & scanLocation.currentLocation & "SummaryDateStamp.txt"
        Dim result As String
        Dim localFileDateStamp As Date
        result = getDateStampFromDateStampFile(dateStampFilePath, localFileDateStamp)

        If result = "OK" Then
            LabelDate.Visible = True
            LabelDate.Text = "As of: " & localFileDateStamp.ToShortDateString & " " & localFileDateStamp.ToShortTimeString
        End If

        Dim di As New DirectoryInfo(TagTrakSummariesDirectory)
        Dim i As Integer
        Dim nextFileName As String

        Me.Text = "Manifest Summary"

        Dim locationCode As String = Substring(scanLocation.currentLocation, 0, 3)
        'Dim flightNumber As String = activeReaderForm.flightNumberTextBox.Text

        Me.summaryListBox.Items.Clear()

        'activeReaderForm.resetOperationComboBoxWithoutWarning()

        If Not isNonNullString(locationCode) Then
            Me.summaryListBox.Items.Add("NO ORIGIN SPECIFIED")
            Return False
        End If

        If Length(locationCode) <> 3 Then
            Me.summaryListBox.Items.Add("INVALID ORIGIN SPECIFIED")
            Return False
        End If

        'If Not isNonNullString(flightNumber) Then
        '    Me.summaryListBox.Items.Add("NO FLIGHT NUMBER SPECIFIED")
        '    Return False
        'End If

        'flightNumber = Trim(flightNumber)

        'If Not isValidFlightNumber(flightNumber) Then
        '    Me.summaryListBox.Items.Add("INVALID FLIGHT NUMBER SPECIFIED")
        '    Return False
        'End If

        'flightNumber = flightNumber.PadLeft(4, "0")

        Dim files As FileInfo() = di.GetFiles()

        If files.Length <= 0 Then Exit Function

        Dim currentFileName As String = ""

        For i = 0 To files.Length - 1

            nextFileName = files(i).Name.ToUpper

            If nextFileName.EndsWith(".SUM") And nextFileName.StartsWith(locationCode) Then

                If nextFileName > currentFileName Then currentFileName = nextFileName

            End If

        Next i

        If Length(currentFileName) <= 0 Then
            Me.summaryListBox.Items.Add("NO SUMMARY INFORMATION AVAILABLE")
            Return False
        End If

        currentFileName = TagTrakSummariesDirectory & backSlash & currentFileName

        Dim summaryFileStream As New StreamReader(currentFileName)

        Dim nextInputLine As String

        nextInputLine = summaryFileStream.ReadLine()

        While Not nextInputLine Is Nothing

            'If Length(nextInputLine) >= 4 Then

            '    Dim compareFlightNumber As String = Substring(nextInputLine, 0, 4)

            '    compareFlightNumber = Trim(compareFlightNumber)

            '    compareFlightNumber = compareFlightNumber.PadLeft(4, "0")

            '    If compareFlightNumber = flightNumber Then

            '        Me.summaryListBox.Items.Add(Substring(nextInputLine, 4))

            '    End If

            'End If

            Me.summaryListBox.Items.Add(nextInputLine)

            nextInputLine = summaryFileStream.ReadLine()

        End While

        summaryFileStream.Close()

        Return True

    End Function

    Public Function loadPriliminarySummaryInformation()

        LabelDate.Visible = False

        Dim flightLoadingTable As New Hashtable

        Me.summaryListBox.Items.Clear()

        Me.Text = "Preliminary Manifest"

        If FlightRoutes Is Nothing Then
            summaryListBox.Items.Add("*** NO FLIGHT INFORMATION ***")
            Return True
        End If

        Dim scanRecord As scanRecordClass
        Dim flightLoading As FlightLoadingRecord
        Dim flightNumber As String

        For Each scanRecord In userSpecRecord.scanRecordSet.Values

            Dim scanDate As Date = scanRecord.scanDateAndTime.Date

            If scanDate >= FlightRoutes.effectiveDate And scanDate <= FlightRoutes.discontinueDate Then

                Dim scanCode As String = scanRecord.scanCode.Substring(4, 4)
                Dim weight As Double = scanRecord.getScanWeight()
                Dim pieces As Integer = scanRecord.getScanPieces()

                flightNumber = FlightRoutes(scanCode)

                If flightNumber Is Nothing Then

                    flightNumber = "0000"

                End If

                flightLoading = flightLoadingTable(flightNumber)

                If flightLoading Is Nothing Then

                    flightLoading = New FlightLoadingRecord(pieces, weight)

                    flightLoadingTable.Add(flightNumber, flightLoading)

                Else

                    flightLoading.accumulate(pieces, weight)

                End If

            End If

        Next

        Dim di As DictionaryEntry

        Dim flightSummaryList As ArrayList = New ArrayList

        For Each di In flightLoadingTable

            flightNumber = di.Key
            flightLoading = di.Value

            flightSummaryList.Add("| " & flightNumber & " | " & flightLoading.ToString() & " |")

        Next

        If flightSummaryList.Count <= 0 Then

            summaryListBox.Items.Add("*** NO FLIGHT INFORMATION ***")
            Return True

        End If

        summaryListBox.Items.Add("+------+---------+------------+")
        summaryListBox.Items.Add("| FLGT |  PIECE  |    TOTAL   |")
        summaryListBox.Items.Add("| NMBR |  COUNT  |    WEIGHT  |")
        summaryListBox.Items.Add("+------+---------+------------+")

        flightSummaryList.Sort()

        Dim summaryItem As String

        For Each summaryItem In flightSummaryList

            summaryListBox.Items.Add(summaryItem)

        Next

        summaryListBox.Items.Add("+------+---------+------------+")

        Return True

    End Function

    Private Sub OKButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles OKButton.Click
        Me.Hide()
    End Sub

    Private Sub Label1_ParentChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles LabelDate.ParentChanged

    End Sub
End Class
