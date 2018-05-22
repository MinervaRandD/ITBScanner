Public Class keyboardClass

    Friend WithEvents baseForm As System.Windows.Forms.Form
    Friend WithEvents keyboardPanel As System.Windows.Forms.Panel
    Friend WithEvents lowerCasePictureBox As System.Windows.Forms.PictureBox
    Friend WithEvents upperCasePictureBox As System.Windows.Forms.PictureBox
    Friend WithEvents keyboardTextBox As System.Windows.Forms.TextBox

    Friend WithEvents Button1 As System.Windows.Forms.Button
    Friend WithEvents Button2 As System.Windows.Forms.Button

    Friend WithEvents pressButton As System.Windows.Forms.Button

    Dim row0LowerCase As String = "`1234567890-="
    Dim row1LowerCase As String = "qwertyuiop[]\"
    Dim row2LowerCase As String = "asdfghjkl;'"
    Dim row3LowerCase As String = "zxcvbnm,./"

    Dim row0upperCase As String = "~!@#$%^" & "&"c & "*()_+"
    Dim row1upperCase As String = "QWERTYUIOP{}|"
    Dim row2upperCase As String = "ASDFGHJKL:" & "'"c
    Dim row3upperCase As String = "ZXCVBNM<>?"

    Dim rowLowerCase() As String = {row0LowerCase, row1LowerCase, row2LowerCase, row3LowerCase}
    Dim rowUpperCase() As String = {row0upperCase, row1upperCase, row2upperCase, row3upperCase}

    Dim rowBaseLocation(4) As System.Drawing.Point
    Dim rowEndLocation(4) As Integer

    Dim baseKeySize As New System.Drawing.Size(17, 17)

    Dim row0BaseKeyLocation() As Point
    Dim row1BaseKeyLocation() As Point
    Dim row2BaseKeyLocation() As Point
    Dim row3BaseKeyLocation() As Point
    Dim row4BaseKeyLocation() As Point

    Dim rowBaseKeyLocation(3)() As Point

    Dim backspaceBaseLocation As Point
    Dim tabBaseLocation As Point
    Dim capsLockBaseLocation As Point
    Dim enterBaseLocation As Point
    Dim shift1BaseLocation As Point
    Dim shift2BaseLocation As Point
    Dim spaceBaseLocation As Point
    Dim closeButtonBaseLocation As Point

    Dim backspaceSize As Size
    Dim tabSize As Size
    Dim capsLockSize As Size
    Dim enterSize As Size
    Dim shift1Size As Size
    Dim shift2Size As Size
    Dim spaceSize As Size
    Dim closeButtonSize As Size

    Dim closeButtonEnd As Integer

    Dim shift As Boolean = False
    Dim shiftLock As Boolean = False

    Delegate Sub tabKeyDelegate(ByVal sender As System.Windows.Forms.TextBox)
    Delegate Sub enterKeyDelegate(ByVal sender As Object, ByVal e As EventArgs)

    Dim keyboardEnterDelegate As enterKeyDelegate = Nothing
    Friend WithEvents keyboardIcon As Windows.Forms.PictureBox = Nothing

    Dim tabbedTextBoxSet As New Hashtable

    Dim manualEnterKeys As Boolean = False

#Region " Windows Form Designer generated code "

    Private Sub init( _
       ByRef inputBaseForm As Windows.Forms.Form, _
       ByRef inputTabbedTextBoxList() As tabbedTextBoxSpecClass, _
       Optional ByRef inputKeyboardIcon As Windows.Forms.PictureBox = Nothing, _
       Optional ByRef inputEnterKeyDelegate As enterKeyDelegate = Nothing)

        baseForm = inputBaseForm
        keyboardPanel = globalKeyboardPanel
        lowerCasePictureBox = globalLowerCasePictureBox
        upperCasePictureBox = globalUpperCasePictureBox
        keyboardTextBox = Nothing

        keyboardIcon = inputKeyboardIcon

        keyboardEnterDelegate = inputEnterKeyDelegate

        lowerCasePictureBox = New System.Windows.Forms.PictureBox
        upperCasePictureBox = New System.Windows.Forms.PictureBox
        keyboardPanel = New System.Windows.Forms.Panel

        Me.upperCasePictureBox.Size = New System.Drawing.Size(238, 83)
        Me.upperCasePictureBox.Image = globalUpperCasePictureBox.Image
        '
        'lowerCasePictureBox
        '
        Me.lowerCasePictureBox.Size = New System.Drawing.Size(238, 83)
        Me.lowerCasePictureBox.Image = globalLowerCasePictureBox.Image

        keyboardPanel.Location = New System.Drawing.Point(1, 300)
        keyboardPanel.Size = New System.Drawing.Size(238, 83)

        keyboardPanel.Controls.Add(upperCasePictureBox)
        keyboardPanel.Controls.Add(lowerCasePictureBox)

        baseForm.Controls.Add(keyboardPanel)

        If Not keyboardIcon Is Nothing Then
            keyboardIcon.Image = globalKeyboardIcon.Image
            keyboardIcon.Visible = True
        End If

        pressButton = New System.Windows.Forms.Button
        baseForm.Controls.Add(pressButton)

        pressButton.Size = New System.Drawing.Size(17, 17)
        pressButton.Font = New System.Drawing.Font("Lucida Console", 9.0!, System.Drawing.FontStyle.Bold)
        pressButton.Visible = False
        pressButton.Enabled = False

        rowBaseLocation(0) = New System.Drawing.Point(1, 1)

        rowBaseLocation(1) = New System.Drawing.Point(rowBaseLocation(0).X + 1.5 * baseKeySize.Width, rowBaseLocation(0).Y + baseKeySize.Height - 1)
        rowBaseLocation(2) = New System.Drawing.Point(rowBaseLocation(1).X + 0.25 * baseKeySize.Width, rowBaseLocation(1).Y + baseKeySize.Height - 1)
        rowBaseLocation(3) = New System.Drawing.Point(rowBaseLocation(2).X + 0.5 * baseKeySize.Width, rowBaseLocation(2).Y + baseKeySize.Height - 1)
        rowBaseLocation(4) = New System.Drawing.Point(rowBaseLocation(3).X, rowBaseLocation(3).Y + baseKeySize.Height - 1)

        buildKeyboardKeyLocations()

        lowerCasePictureBox.BringToFront()

        Dim textBoxControlHandler As EventHandler
        Dim textBoxKeyPressControlHandler As KeyPressEventHandler
        Dim textBoxMouseDownControlHandler As MouseEventHandler

        Dim textBoxControl As System.Windows.Forms.TextBox
        Dim tabbedTextBoxSpec As tabbedTextBoxSpecClass

        For Each tabbedTextBoxSpec In inputTabbedTextBoxList

            textBoxControl = tabbedTextBoxSpec.textBoxControl

            textBoxControlHandler = New EventHandler(AddressOf textBoxGotFocus)
            AddHandler textBoxControl.GotFocus, textBoxControlHandler

            textBoxControlHandler = New EventHandler(AddressOf textBoxLostFocus)
            AddHandler textBoxControl.LostFocus, textBoxControlHandler

            tabbedTextBoxSet.Add(textBoxControl, tabbedTextBoxSpec)

        Next

        Me.hide()

    End Sub

    Public Sub New( _
        ByRef inputBaseForm As Windows.Forms.Form, _
        ByRef inputTabbedTextBoxList() As tabbedTextBoxSpecClass, _
        Optional ByRef inputKeyboardIcon As Windows.Forms.PictureBox = Nothing, _
        Optional ByRef inputEnterKeyDelegate As enterKeyDelegate = Nothing)

        init(inputBaseForm, inputTabbedTextBoxList, inputKeyboardIcon, inputEnterKeyDelegate)

    End Sub

    Public Sub New( _
        ByRef inputBaseForm As Windows.Forms.Form, _
        ByRef inputTextBoxList() As System.Windows.Forms.Control, _
        Optional ByRef inputKeyboardIcon As Windows.Forms.PictureBox = Nothing, _
        Optional ByRef inputEnterKeyDelegate As enterKeyDelegate = Nothing)

        Dim listLength As Integer = inputTextBoxList.Length

        Dim tabbedTextBoxList(listLength - 1) As tabbedTextBoxSpecClass

        Dim textBoxControl As System.Windows.Forms.TextBox

        Dim tabbedTextBoxSpec As tabbedTextBoxSpecClass

        If listLength = 1 Then
            tabbedTextBoxSpec = New tabbedTextBoxSpecClass(inputTextBoxList(0), 0, Nothing, 0)
            tabbedTextBoxList(0) = tabbedTextBoxSpec
        Else
            Dim i, ilmt, j As Integer

            i = 0
            ilmt = listLength - 1

            For i = 0 To ilmt
                tabbedTextBoxSpec = New tabbedTextBoxSpecClass(inputTextBoxList(i), i, Nothing, 0)
                tabbedTextBoxList(i) = tabbedTextBoxSpec
            Next

            tabbedTextBoxSpec = tabbedTextBoxList(0)

            For i = 0 To ilmt

                Dim nextTabbedTextBoxSpec As tabbedTextBoxSpecClass = tabbedTextBoxList((i + 1) Mod listLength)
                tabbedTextBoxSpec.nextTextBoxSpec = nextTabbedTextBoxSpec

                tabbedTextBoxSpec = nextTabbedTextBoxSpec

            Next

        End If

        init(inputBaseForm, tabbedTextBoxList, inputKeyboardIcon, inputEnterKeyDelegate)

    End Sub

    Private Sub keyboardIconClickEventHandler(ByVal sender As Object, ByVal e As EventArgs) Handles keyboardIcon.Click

        Dim tabbedTextBoxSpec As tabbedTextBoxSpecClass

        For Each tabbedTextBoxSpec In tabbedTextBoxSet.Values

            Dim textBoxControl As System.Windows.Forms.TextBox

            textBoxControl = tabbedTextBoxSpec.textBoxControl

            If textBoxControl.Focused Then

                Me.expose(textBoxControl)
                Exit Sub

            End If
        Next

        Me.expose(239)

    End Sub

#End Region

    Private Sub buildKeyboardKeyLocations()

        Dim clickEventHandler As EventHandler

        Dim i As Integer
        Dim j, jlmt As Integer

        Dim locX, locY As Integer
        Dim sizeX, sizeY As Integer

        ReDim row0BaseKeyLocation(row0LowerCase.Length - 1)
        ReDim row1BaseKeyLocation(row1LowerCase.Length - 1)
        ReDim row2BaseKeyLocation(row2LowerCase.Length - 1)
        ReDim row3BaseKeyLocation(row3LowerCase.Length - 1)

        rowBaseKeyLocation(0) = row0BaseKeyLocation
        rowBaseKeyLocation(1) = row1BaseKeyLocation
        rowBaseKeyLocation(2) = row2BaseKeyLocation
        rowBaseKeyLocation(3) = row3BaseKeyLocation

        For i = 0 To 3

            Dim rowLowerCaseString As String = rowLowerCase(i)
            Dim rowBaseLocationValue As System.Drawing.Point = rowBaseLocation(i)

            jlmt = rowLowerCaseString.Length - 1

            locY = rowBaseLocationValue.Y
            locX = rowBaseLocationValue.X

            Dim rowBaseKey() As Point = rowBaseKeyLocation(i)

            For j = 0 To jlmt

                Dim c As Char = rowLowerCaseString.Chars(j)

                rowBaseKey(j) = New System.Drawing.Point(locX, locY)

                If c = "\"c Or c = "|"c Then
                    locX += baseKeySize.Width + 1
                Else
                    locX += baseKeySize.Width - 1
                End If

            Next

            rowEndLocation(i) = locX

        Next

        ' Backspace

        locX = rowEndLocation(0)
        locY = rowBaseLocation(0).Y

        sizeX = rowEndLocation(1) - locX + 1
        sizeY = baseKeySize.Height

        backspaceBaseLocation = New System.Drawing.Point(locX, locY)
        backspaceSize = New System.Drawing.Size(sizeX, sizeY)

        ' Tab

        locX = rowBaseLocation(0).X
        locY = rowBaseLocation(1).Y

        sizeX = rowBaseLocation(1).X - locX + 1
        sizeY = baseKeySize.Height

        tabBaseLocation = New System.Drawing.Point(locX, locY)
        tabSize = New System.Drawing.Size(sizeX, sizeY)

        ' Caps Lock

        locX = rowBaseLocation(0).X
        locY = rowBaseLocation(2).Y

        sizeX = rowBaseLocation(2).X - locX + 1
        sizeY = baseKeySize.Height

        capsLockBaseLocation = New System.Drawing.Point(locX, locY)
        capsLockSize = New System.Drawing.Size(sizeX, sizeY)

        ' Enter

        locX = rowEndLocation(2)
        locY = rowBaseLocation(2).Y

        sizeX = rowEndLocation(1) - locX + 1
        sizeY = baseKeySize.Height

        enterBaseLocation = New System.Drawing.Point(locX, locY)
        enterSize = New System.Drawing.Size(sizeX, sizeY)

        ' Shift1

        locX = rowBaseLocation(0).X
        locY = rowBaseLocation(3).Y

        sizeX = rowBaseLocation(3).X - locX + 1
        sizeY = baseKeySize.Height

        shift1BaseLocation = New System.Drawing.Point(locX, locY)
        shift1Size = New System.Drawing.Size(sizeX, sizeY)

        ' Shift2

        locX = rowEndLocation(3)
        locY = rowBaseLocation(3).Y

        sizeX = rowEndLocation(1) - locX + 1
        sizeY = baseKeySize.Height

        shift2BaseLocation = New System.Drawing.Point(locX, locY)
        shift2Size = New System.Drawing.Size(sizeX, sizeY)

        ' Space

        locX = rowBaseLocation(3).X + 1 * baseKeySize.Width
        locY = rowBaseLocation(4).Y

        sizeX = rowEndLocation(3) - 2 * baseKeySize.Width - locX + 3
        sizeY = baseKeySize.Height

        spaceBaseLocation = New System.Drawing.Point(locX, locY)
        spaceSize = New System.Drawing.Size(sizeX, sizeY)

        rowEndLocation(4) = locX + sizeX - 1

        ' Close button

        locX = rowEndLocation(1) - 17
        locY = rowBaseLocation(4).Y

        sizeX = 17
        sizeY = 17

        closeButtonBaseLocation = New System.Drawing.Point(locX, locY)
        closeButtonSize = New System.Drawing.Size(sizeX, sizeY)

        closeButtonEnd = closeButtonBaseLocation.X + closeButtonSize.Width

    End Sub

    Private Function getKeyNumber(ByVal row As Integer, ByVal x As Integer) As Integer

        Dim i, ilmt As Integer

        Dim locationArray() As Point = rowBaseKeyLocation(row)

        ilmt = locationArray.Length - 1

        For i = 1 To ilmt

            If x < locationArray(i).X Then
                Return i - 1
            End If
        Next

        Return ilmt

    End Function

    Private Function getButtonLocation(ByVal x As Integer, ByVal y As Integer, ByRef keyBaseLocation As System.Drawing.Point, ByRef keySize As System.Drawing.Size) As String

        If x < 1 Or y < 1 Then Return Nothing

        If x > rowEndLocation(1) Or y > rowBaseLocation(4).Y + baseKeySize.Height Then Return Nothing

        Dim row As Integer

        If y < rowBaseLocation(2).Y Then

            If y < rowBaseLocation(1).Y Then
                row = 0
            Else
                row = 1
            End If

        ElseIf y < rowBaseLocation(3).Y Then

            row = 2

        Else

            If y < rowBaseLocation(4).Y Then
                row = 3
            Else
                row = 4
            End If

        End If

        Select Case row

            Case 0

                If x >= rowEndLocation(0) Then
                    keyBaseLocation = backspaceBaseLocation
                    keySize = backspaceSize
                    Return "Bsp"
                End If

                Dim i As Integer = getKeyNumber(0, x)

                keyBaseLocation = rowBaseKeyLocation(0)(i)
                keySize = baseKeySize

                If shift Then
                    Return rowUpperCase(0).Chars(i)
                Else
                    Return rowLowerCase(0).Chars(i)
                End If

            Case 1

                If x < rowBaseLocation(1).X Then
                    keyBaseLocation = tabBaseLocation
                    keySize = tabSize
                    Return "Tab"
                End If

                Dim i As Integer = getKeyNumber(1, x)

                keyBaseLocation = rowBaseKeyLocation(1)(i)
                keySize = baseKeySize

                If shift Then
                    Return rowUpperCase(1).Chars(i)
                Else
                    Return rowLowerCase(1).Chars(i)
                End If

            Case 2

                If x < rowBaseLocation(2).X Then
                    keyBaseLocation = capsLockBaseLocation
                    keySize = capsLockSize
                    Return "Lock"
                End If

                If x >= rowEndLocation(2) Then
                    keyBaseLocation = enterBaseLocation
                    keySize = enterSize
                    Return "Enter"
                End If

                Dim i As Integer = getKeyNumber(2, x)

                keyBaseLocation = rowBaseKeyLocation(2)(i)
                keySize = baseKeySize

                If shift Then
                    Return rowUpperCase(2).Chars(i)
                Else
                    Return rowLowerCase(2).Chars(i)
                End If

            Case 3

                If x < rowBaseLocation(3).X Then
                    keyBaseLocation = shift1BaseLocation
                    keySize = shift1Size
                    Return "Shift"
                End If

                If x >= rowEndLocation(3) Then
                    keyBaseLocation = shift2BaseLocation
                    keySize = shift2Size
                    Return "Shift"
                End If

                Dim i As Integer = getKeyNumber(3, x)

                keyBaseLocation = rowBaseKeyLocation(3)(i)
                keySize = baseKeySize

                If shift Then
                    Return rowUpperCase(3).Chars(i)
                Else
                    Return rowLowerCase(3).Chars(i)
                End If

            Case 4

                If x >= rowBaseLocation(4).X And x <= rowEndLocation(4) Then
                    keyBaseLocation = spaceBaseLocation
                    keySize = spaceSize
                    Return " "
                End If

                If x >= closeButtonBaseLocation.X And x <= closeButtonEnd Then
                    keyBaseLocation = closeButtonBaseLocation
                    keySize = closeButtonSize
                    Return "Close"
                End If

                Return Nothing

            Case Else

                Return Nothing

        End Select

    End Function

    Dim pressButtonText As String = Nothing

    Private Sub mouseDown(ByVal sender As System.Object, ByVal e As MouseEventArgs) Handles lowerCasePictureBox.MouseDown, upperCasePictureBox.MouseDown

        Dim x, y As Integer

        Dim pressButtonLocation As System.Drawing.Point
        Dim pressButtonSize As System.Drawing.Size

        pressButtonText = getButtonLocation(e.X, e.Y, pressButtonLocation, pressButtonSize)

        If pressButtonText Is Nothing Then Exit Sub

        If pressButtonText = "Close" Then
            pressButton.Text = "x"
        Else
            pressButton.Text = pressButtonText
        End If

        pressButton.Size = pressButtonSize
        pressButton.Location = New System.Drawing.Point(pressButtonLocation.X + keyboardPanel.Location.X, pressButtonLocation.Y + keyboardPanel.Location.Y)

        pressButton.Visible = True
        pressButton.BringToFront()

    End Sub

    Private Sub processShiftLockKeyPress()

        If shiftLock Then

            shiftLock = False
            shift = False

            lowerCasePictureBox.Visible = True
            lowerCasePictureBox.Enabled = True

            upperCasePictureBox.Visible = False
            upperCasePictureBox.Enabled = False

            lowerCasePictureBox.BringToFront()

        Else

            shiftLock = True
            shift = True

            lowerCasePictureBox.Visible = False
            lowerCasePictureBox.Enabled = False

            upperCasePictureBox.Visible = True
            upperCasePictureBox.Enabled = True

            upperCasePictureBox.BringToFront()

        End If

    End Sub

    Private Sub processShiftKeyPress()

        If shiftLock Then Exit Sub

        If shift Then

            shift = False

            lowerCasePictureBox.Visible = True
            lowerCasePictureBox.Enabled = True

            upperCasePictureBox.Visible = False
            upperCasePictureBox.Enabled = False

            lowerCasePictureBox.BringToFront()

        Else

            shift = True

            lowerCasePictureBox.Visible = False
            lowerCasePictureBox.Enabled = False

            upperCasePictureBox.Visible = True
            upperCasePictureBox.Enabled = True

            upperCasePictureBox.BringToFront()

        End If

    End Sub

    Private Sub processBackspaceKeyPress()

        If keyboardTextBox Is Nothing Then Exit Sub

        If Not keyboardTextBox.Focused Then Exit Sub

        Dim selectionStart As Integer = keyboardTextBox.SelectionStart
        Dim selectionLength As Integer = keyboardTextBox.SelectionLength

        If selectionLength = 0 Then

            If selectionStart > 0 Then

                keyboardTextBox.Enabled = False

                keyboardTextBox.Text = keyboardTextBox.Text.Remove(selectionStart - 1, 1)

                keyboardTextBox.Enabled = True

                keyboardTextBox.SelectionStart = selectionStart - 1
                keyboardTextBox.Focus()

            End If

        Else

            keyboardTextBox.Enabled = False

            keyboardTextBox.Text = keyboardTextBox.Text.Remove(selectionStart, selectionLength)

            keyboardTextBox.Enabled = True

            keyboardTextBox.SelectionLength = 0
            keyboardTextBox.SelectionStart = selectionStart
            keyboardTextBox.Focus()
        End If

    End Sub

    Private Sub processKeyPress(ByVal keyChar As Char)

        If keyboardTextBox Is Nothing Then Exit Sub

        If keyChar = TagTrakGlobals.tabKeyChar Then Exit Sub

        If Not keyboardTextBox.Focused Then Exit Sub

        Dim selectionStart As Integer = keyboardTextBox.SelectionStart
        Dim selectionLength As Integer = keyboardTextBox.SelectionLength

        If keyboardTextBox.Text Is Nothing Then
            keyboardTextBox.Text = ""
        End If

        If selectionLength = 0 Then

            keyboardTextBox.Enabled = False

            keyboardTextBox.Text = keyboardTextBox.Text.Insert(selectionStart, keyChar)

            keyboardTextBox.Enabled = True

            keyboardTextBox.SelectionStart = selectionStart + 1
            keyboardTextBox.Focus()

        Else

            keyboardTextBox.Enabled = False

            keyboardTextBox.Text = keyboardTextBox.Text.Remove(selectionStart, selectionLength).Insert(selectionStart, keyChar)

            keyboardTextBox.Enabled = True

            keyboardTextBox.SelectionStart = selectionStart + 1
            keyboardTextBox.SelectionLength = 0
            keyboardTextBox.Focus()

        End If

    End Sub

    Dim withinMouseUpHandler As Boolean = False

    Private Sub mouseUp(ByVal sender As System.Object, ByVal e As MouseEventArgs) _
            Handles lowerCasePictureBox.MouseUp, upperCasePictureBox.MouseUp, keyboardPanel.MouseUp

        If withinMouseUpHandler Then Exit Sub
        withinMouseUpHandler = True

        pressButton.Visible = False
        pressButton.SendToBack()

        Application.DoEvents()

        If pressButtonText Is Nothing Then
            withinMouseUpHandler = False
            Exit Sub
        End If

        Application.DoEvents()

        Select Case pressButtonText

            Case "Lock"

                processShiftLockKeyPress()

            Case "Shift"

                processShiftKeyPress()

            Case "Tab"

                processTabRoutine(keyboardTextBox)

            Case "Enter"

                '    keyboardEnterDelegate(keyboardTextBox, Nothing)

            Case "Bsp"

                processBackspaceKeyPress()

            Case ("Close")

                hide()

            Case Else

                If pressButtonText.Length <> 1 Then
                    MsgBox("Invalid key value")
                    Stop
                End If

                processKeyPress(pressButtonText.Chars(0))

        End Select

        Application.DoEvents()

        withinMouseUpHandler = False

    End Sub

    Public Sub processTabRoutine(ByVal sender As Windows.Forms.TextBox)

        If sender Is Nothing Then Exit Sub

        Dim tabbedTextBoxSpec As tabbedTextBoxSpecClass = Me.tabbedTextBoxSet(sender)

        If tabbedTextBoxSpec Is Nothing Then Exit Sub

        Dim ilmt As Integer = tabbedTextBoxSet.Count - 1
        Dim i As Integer = 0

        Dim nextTextBoxSpec As tabbedTextBoxSpecClass

        nextTextBoxSpec = tabbedTextBoxSpec.nextTextBoxSpec

        While i < ilmt

            If nextTextBoxSpec Is Nothing Then
                Exit Sub
            End If

            If nextTextBoxSpec.textBoxControl.Enabled Then
                nextTextBoxSpec.textBoxControl.Focus()
                Exit Sub

            End If

            nextTextBoxSpec = nextTextBoxSpec.nextTextBoxSpec

            i += 1

        End While

    End Sub

    Private Sub processEnterRoutine(ByVal sender As Windows.Forms.TextBox)

        If sender Is Nothing Then Exit Sub

        Dim tabbedTextBoxSpec As tabbedTextBoxSpecClass = Me.tabbedTextBoxSet(sender)

        If Not tabbedTextBoxSpec Is Nothing Then

            If Not tabbedTextBoxSpec.enterKeyDelegate Is Nothing Then
                tabbedTextBoxSpec.enterKeyDelegate(sender, Nothing)
                Exit Sub
            End If

        End If

        If Not Me.keyboardEnterDelegate Is Nothing Then
            Me.keyboardEnterDelegate(sender, Nothing)
        End If

    End Sub

    Private Sub expose()

        If keyboardPanel.Visible Then
            Application.DoEvents()
            Exit Sub
        End If

        keyboardPanel.Visible = True
        keyboardPanel.BringToFront()
        Application.DoEvents()

    End Sub

    Private Sub expose(ByVal Y As Integer)

        If keyboardPanel.Visible Then
            If keyboardPanel.Location.Y = Y Then
                Application.DoEvents()
                Exit Sub
            End If
        End If

        keyboardPanel.Location = New System.Drawing.Point(1, Y)
        keyboardPanel.Visible = True
        keyboardPanel.BringToFront()

        Application.DoEvents()

    End Sub

    Private Sub expose(ByRef inputKeyboardTextBox As System.Windows.Forms.TextBox)

        Dim Y As Integer
        If inputKeyboardTextBox.Location.Y > 205 Then
            Y = 0
        Else
            Y = 239
        End If

        If keyboardPanel.Visible Then
            If keyboardPanel.Location.Y = Y Then
                keyboardTextBox = inputKeyboardTextBox
                keyboardTextBox.Focus()
                Application.DoEvents()
                Exit Sub
            End If
        End If

        manualEnterKeys = True

        keyboardPanel.Location = New System.Drawing.Point(1, Y)
        keyboardPanel.Visible = True
        keyboardPanel.BringToFront()
        'keyboardPanel.Focus()

        keyboardTextBox = inputKeyboardTextBox

        'keyboardTextBox.Focus()

        Application.DoEvents()

    End Sub

    Public Sub hide()

        keyboardPanel.Visible = False
        pressButton.Visible = False

    End Sub

    Private Sub textBoxGotFocus(ByVal sender As Object, ByVal e As System.EventArgs)

        If Not userSpecRecord.showKeyboardOnFocus Then Exit Sub

        Dim sendingTextBox As System.Windows.Forms.TextBox = sender

        Dim senderLocation As Integer = sendingTextBox.Location.Y

        expose(sendingTextBox)

    End Sub

    Private Sub textBoxLostFocus(ByVal sender As Object, ByVal e As System.EventArgs)

        'keyboard.expose(239, Nothing, Nothing, Nothing)

    End Sub

    Private Sub keyPress(ByVal sender As Object, ByVal e As KeyPressEventArgs) Handles keyboardTextBox.KeyPress

        Dim c As Char = e.KeyChar
        Dim a As Integer = Asc(c)

        e.Handled = True

        Select Case a

            Case 8
                pressButtonText = "Bsp"

            Case 9
                pressButtonText = "Tab"

            Case 13
                pressButtonText = "Enter"

            Case Else
                pressButtonText = c

        End Select

        mouseUp(Nothing, Nothing)

        If ProgEnded Then
            Application.Exit()
        End If

    End Sub

End Class
