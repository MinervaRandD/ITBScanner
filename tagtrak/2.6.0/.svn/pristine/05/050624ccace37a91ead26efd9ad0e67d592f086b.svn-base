Imports System
Imports System.io

Public Class adminResditFileDisplayForm
    Inherits System.Windows.Forms.Form
    Friend WithEvents saveButton As System.Windows.Forms.Button
    Friend WithEvents exitButton As System.Windows.Forms.Button
    Friend WithEvents saveAndExitButton As System.Windows.Forms.Button

    Dim filePath As String
    Dim textChangedSinceLastSave As Boolean = False
    Dim filePathChangedSinceLastSave As Boolean = False

    Dim ignoreTextBoxChanges As Boolean = True
    Dim ignoreFileNameChanges As Boolean = True

#Region " Windows Form Designer generated code "

    Public Sub New()

        MyBase.New()

        InitializeComponent()

    End Sub

    Public Sub init(ByVal inputFilePath As String)

        filePath = inputFilePath

        saveButton.Enabled = False
        saveAndExitButton.Enabled = False

    End Sub


    Protected Overloads Overrides Sub Dispose(ByVal disposing As Boolean)
        MyBase.Dispose(disposing)
    End Sub

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    Friend WithEvents fileTextBox As System.Windows.Forms.TextBox
    Friend WithEvents filePathTextBox As System.Windows.Forms.TextBox
    Friend WithEvents MainMenu1 As System.Windows.Forms.MainMenu
#If deviceType <> "PC" Then
    Friend WithEvents InputPanel1 As Microsoft.WindowsCE.Forms.InputPanel
#End If
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.fileTextBox = New System.Windows.Forms.TextBox
        Me.saveButton = New System.Windows.Forms.Button
        Me.exitButton = New System.Windows.Forms.Button
        Me.saveAndExitButton = New System.Windows.Forms.Button
        Me.filePathTextBox = New System.Windows.Forms.TextBox
        Me.MainMenu1 = New System.Windows.Forms.MainMenu
#If devicetype <> "PC" Then
        Me.InputPanel1 = New Microsoft.WindowsCE.Forms.InputPanel
#End If
        '
        'fileTextBox
        '
        Me.fileTextBox.Font = New System.Drawing.Font("Courier New", 9.0!, System.Drawing.FontStyle.Regular)
        Me.fileTextBox.Location = New System.Drawing.Point(9, 31)
        Me.fileTextBox.MaxLength = 65536
        Me.fileTextBox.Multiline = True
        Me.fileTextBox.ScrollBars = System.Windows.Forms.ScrollBars.Both
        Me.fileTextBox.Size = New System.Drawing.Size(213, 203)
        Me.fileTextBox.Text = ""
        Me.fileTextBox.WordWrap = False
        '
        'saveButton
        '
        Me.saveButton.Location = New System.Drawing.Point(9, 242)
        Me.saveButton.Size = New System.Drawing.Size(59, 23)
        Me.saveButton.Text = "Save"
        '
        'exitButton
        '
        Me.exitButton.Location = New System.Drawing.Point(72, 242)
        Me.exitButton.Size = New System.Drawing.Size(46, 23)
        Me.exitButton.Text = "Exit"
        '
        'saveAndExitButton
        '
        Me.saveAndExitButton.Location = New System.Drawing.Point(121, 242)
        Me.saveAndExitButton.Size = New System.Drawing.Size(102, 23)
        Me.saveAndExitButton.Text = "Save And Exit"
        '
        'filePathTextBox
        '
        Me.filePathTextBox.Location = New System.Drawing.Point(9, 7)
        Me.filePathTextBox.Size = New System.Drawing.Size(213, 22)
        Me.filePathTextBox.Text = ""
        '
        'adminResditFileDisplayForm
        '
        Me.ClientSize = New System.Drawing.Size(234, 309)
        Me.ControlBox = False
        Me.Controls.Add(Me.filePathTextBox)
        Me.Controls.Add(Me.saveAndExitButton)
        Me.Controls.Add(Me.exitButton)
        Me.Controls.Add(Me.saveButton)
        Me.Controls.Add(Me.fileTextBox)
        Me.Menu = Me.MainMenu1
        Me.Text = "Resdit File Display"

    End Sub

#End Region

    Private Sub formOnLoad(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        If isNonNullString(filePath) Then

            filePathTextBox.Text = filePath

            If File.Exists(filePath) Then

                Dim inputFileInfo As FileInfo

                Try

                    inputFileInfo = New FileInfo(filePath)

                Catch ex As Exception

                    MsgBox("Cannot get info for file '" & filePath & "': " & ex.Message)
                    Me.Hide()
                    Exit Sub

                End Try

                Dim inputFileLength As Integer = inputFileInfo.Length

                If inputFileLength > 0 Then

                    Dim inputFileStream As FileStream

                    Try

                        inputFileStream = New FileStream(filePath, FileMode.Open)

                    Catch ex As Exception

                        MsgBox("Cannot open file '" & filePath & "': " & ex.Message)
                        Me.Hide()
                        Exit Sub

                    End Try

                    Dim inputFileBuff(inputFileLength) As Byte

                    Dim bytesRead As Integer

                    Try

                        bytesRead = inputFileStream.Read(inputFileBuff, 0, inputFileLength)

                    Catch ex As Exception

                        MsgBox("Read on file '" & filePath & "' failed: " & ex.Message)

                        inputFileStream.Close()

                        Me.Hide()
                        Exit Sub

                    End Try

                    If bytesRead <> inputFileLength Then

                        MsgBox("Read on file '" & filePath & "' failed: Wrong Number Of Bytes Read")

                        inputFileStream.Close()

                        Me.Hide()
                        Exit Sub

                    End If

                    inputFileStream.Close()

                    Dim i, ilmt As Integer

                    Dim decryptBuff(inputFileLength + 4096) As Byte
                    Dim decryptBuffSize As Integer = -1

                    If isAsciiBuffer(inputFileBuff, inputFileLength) Then

                        decryptBuffSize = inputFileLength

                        ilmt = decryptBuffSize - 1

                        For i = 0 To ilmt
                            decryptBuff(i) = inputFileBuff(i)
                        Next

                    Else

                        decryptBuffSize = -1

                        'If userNumber >= 0 Then
                        decryptBuffSize = decryptBuffer(inputFileBuff, inputFileLength, decryptBuff)
                        'End If

                        'If decryptBuffSize < 0 Then
                        '    decryptBuffSize = decryptBufferWithUnknownKey(inputFileBuff, inputFileLength, decryptBuff)
                        'End If

                        If decryptBuffSize < 0 Then
                            MsgBox("Cannot decrypt file.", MsgBoxStyle.Exclamation, "Invalid Resdit File")
                            Exit Sub
                        End If

                    End If

                    ilmt = decryptBuffSize - 1

                    Dim charBuff(ilmt) As Char

                    For i = 0 To ilmt
                        charBuff(i) = Chr(decryptBuff(i))
                    Next i

                    Dim fileString As String = charBuff

                    fileTextBox.Text = charBuff

                End If

            End If

        End If

        textChangedSinceLastSave = False
        filePathChangedSinceLastSave = False

        saveButton.Enabled = False
        saveAndExitButton.Enabled = False

        ignoreFileNameChanges = False
        ignoreTextBoxChanges = False

    End Sub

    Private Sub fileNameTextBox_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles filePathTextBox.TextChanged

        If ignoreFileNameChanges Then Exit Sub

        filePathChangedSinceLastSave = True
        saveButton.Enabled = True
        saveAndExitButton.Enabled = True

    End Sub

    Private Sub doSave()

        filePath = filePathTextBox.Text

        If filePathChangedSinceLastSave Then

            If File.Exists(filePath) Then

                Dim result As MsgBoxResult = MsgBox("File '" & filePath & "' exists. Do you want to replace it?", MsgBoxStyle.YesNo, "Replace Existing File?")

                If result = MsgBoxResult.No Then Exit Sub

                deleteLocalFile(filePath)

            End If

        End If

        Dim outputFileLength As Integer = Length(fileTextBox.Text)

        Dim outputFileStream As FileStream

        Try

            outputFileStream = New FileStream(filePath, FileMode.Create)

        Catch ex As Exception

            MsgBox("Creation of output file '" & filePath & "' failed: " & ex.Message)
            Exit Sub

        End Try

        Dim outputFileBuff(outputFileLength) As Byte

        Dim i, ilmt As Integer

        ilmt = outputFileLength - 1

        For i = 0 To ilmt
            outputFileBuff(i) = Asc(fileTextBox.Text.Chars(i))
        Next

        Try

            outputFileStream.Write(outputFileBuff, 0, outputFileLength)

        Catch ex As Exception

            MsgBox("Write to output file '" & filePath & "' failed: " & ex.Message)

            outputFileStream.Close()

            Exit Sub

        End Try

        outputFileStream.Close()

        saveButton.Enabled = True
        saveAndExitButton.Enabled = False

        textChangedSinceLastSave = False
        filePathChangedSinceLastSave = False

        ignoreTextBoxChanges = False
        ignoreFileNameChanges = False

    End Sub

    Dim withinSaveButtonClick As Boolean = False

    Private Sub saveButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles saveButton.Click

        If withinSaveButtonClick Then Exit Sub

        withinSaveButtonClick = True

        doSave()

        withinSaveButtonClick = False

    End Sub

    Private Sub fileTextBox_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles fileTextBox.TextChanged

        If ignoreTextBoxChanges Then Exit Sub

        textChangedSinceLastSave = True
        saveButton.Enabled = True
        saveAndExitButton.Enabled = True

    End Sub

    Private Sub saveAndExitButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles saveAndExitButton.Click

        If withinSaveButtonClick Then Exit Sub

        withinSaveButtonClick = True

        doSave()

        withinSaveButtonClick = False

        Me.Close()

    End Sub

    Private Sub exitButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles exitButton.Click

        If withinSaveButtonClick Then Exit Sub

        withinSaveButtonClick = True

        If textChangedSinceLastSave Or filePathChangedSinceLastSave Then

            Dim result As MsgBoxResult = MsgBox("The file or file name has changed since the last save. Save changes now?", MsgBoxStyle.YesNo, "Save Changes Before Exit?")

            If result = MsgBoxResult.Yes Then
                doSave()
            End If

        End If

        withinSaveButtonClick = False

        Me.Close()

    End Sub
End Class
