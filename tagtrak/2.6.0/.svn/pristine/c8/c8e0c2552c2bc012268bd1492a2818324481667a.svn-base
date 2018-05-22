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
Imports System.IO

Module tabPageActivation

    Public Sub selectMailScanTabPage(ByRef mainDisplay As MailScanDomsForm)

#If ValidationLevel >= 3 Then

        If diagnosticLevel >= 2 Then
            verify(Not mainDisplay Is Nothing, 1400)
        End If

#End If

        Dim tabPage As Windows.Forms.TabPage
        Dim index As Integer

        With mainDisplay

            index = 0

            For Each tabPage In .mainTabControl.TabPages

                If tabPage.Text = "mail scan" Then

                    .mainTabControl.SelectedIndex = index

                    If Not isNonNullString(mainDisplay.operationComboBox.Text) Then

                        Util.turnScannerOff(4)

                    Else

                        Util.turnScannerOn(5)

                    End If

                    previousTabPage = currentTabPage
                    currentTabPage = "mail scan"
                    lastUsedMailScanPage = "mail scan"

                    Dim lastValue As Boolean = userSpecRecord.showKeyboardOnFocus

                    userSpecRecord.showKeyboardOnFocus = False

                    'activeReaderForm.groupNumberTextBox.Focus()

                    userSpecRecord.showKeyboardOnFocus = lastValue

                    Application.DoEvents()

                    tabPage.Show()

                    tabPage.BringToFront()
                    tabPage.Visible = True
                    .setSaveButtonStatus()
                    Application.DoEvents()

                    Exit Sub

                End If

                index += 1

            Next

        End With

        Application.DoEvents()

    End Sub

    Public Sub selectMailScanSimpleTabPage(ByRef mainDisplay As MailScanDomsForm)

#If ValidationLevel >= 3 Then

        If diagnosticLevel >= 2 Then
            verify(Not mainDisplay Is Nothing, 1400)
        End If

#End If

        Dim tabPage As Windows.Forms.TabPage
        Dim index As Integer

        With mainDisplay

            index = 0

            For Each tabPage In .mainTabControl.TabPages

                If tabPage.Text = "mail scan simple" Then

                    .mainTabControl.SelectedIndex = index

                    If Not isNonNullString(mainDisplay.mailScanSimpleOperationComboBox.Text) Then

                        Util.turnScannerOff(4)

                    Else

                        Util.turnScannerOn(5)

                    End If

                    previousTabPage = currentTabPage
                    currentTabPage = "mail scan simple"
                    lastUsedMailScanPage = "mail scan simple"

                    loadPresetListFromFile(userSpecRecord, userSpecRecord.presetList, "M"c)

                    Dim presetRecord As presetRecordClass

                    .mailScanSimplePresetListBox.Items.Clear()

                    For Each presetRecord In userSpecRecord.presetList
                        .mailScanSimplePresetListBox.Items.Add(presetRecord.formatForListBox)
                    Next

                    .mailScanSimpleOperationComboBox.Items.Clear()

                    Dim operation As String

                    For Each operation In .operationComboBox.Items
                        .mailScanSimpleOperationComboBox.Items.Add(operation)
                    Next

                    .mailScanSimpleOperationComboBox.SelectedIndex = .operationComboBox.SelectedIndex

                    If .lastSimplePresetBoxIndex >= 0 And .lastSimplePresetBoxIndex < .mailScanSimplePresetListBox.Items.Count Then
                        .mailScanSimplePresetListBox.SelectedIndex = .lastSimplePresetBoxIndex
                    End If

                    tabPage.Show()

                    tabPage.BringToFront()
                    tabPage.Visible = True
                    .setSaveButtonStatus()
                    Application.DoEvents()


                    Exit Sub

                End If

                index += 1

            Next

        End With

        Application.DoEvents()

    End Sub

    '    Public Sub selectNotifyTabPage(ByRef mainDisplay As MailScanDomsForm)

    '#If ValidationLevel >= 3 Then

    '        If diagnosticLevel >= 2 Then
    '            verify(Not mainDisplay Is Nothing, 1502)
    '        End If

    '#End If

    '        Dim tabPage As Windows.Forms.TabPage
    '        Dim index As Integer

    '        index = 0

    '        mainDisplay.resetOperationComboBoxWithoutWarning()

    '        With mainDisplay

    '            For Each tabPage In .mainTabControl.TabPages

    '                If tabPage.Text = "notify" Then


    '                    previousTabPage = currentTabPage
    '                    currentTabPage = "notify"

    '                    .mainTabControl.SelectedIndex = index

    '                    tabPage.Show()
    '                    tabPage.BringToFront()
    '                    tabPage.Visible = True

    '                    Application.DoEvents()

    '                    Exit Sub

    '                End If

    '                index += 1

    '            Next

    '        End With

    '    End Sub

    '    Public Sub selectErrorTabPage(ByRef mainDisplay As MailScanDomsForm)

    '#If ValidationLevel >= 3 Then

    '        If diagnosticLevel >= 2 Then
    '            verify(Not mainDisplay Is Nothing, 1503)
    '        End If

    '#End If

    '        Dim tabPage As Windows.Forms.TabPage
    '        Dim index As Integer

    '        mainDisplay.resetOperationComboBoxWithoutWarning()

    '        With mainDisplay

    '            index = 0

    '            For Each tabPage In .mainTabControl.TabPages

    '                If tabPage.Text = "error" Then

    '                    previousTabPage = currentTabPage
    '                    currentTabPage = "error"

    '                    .mainTabControl.SelectedIndex = index

    '                    tabPage.Show()
    '                    tabPage.BringToFront()
    '                    tabPage.Visible = True

    '                    Application.DoEvents()

    '                    Exit Sub

    '                End If

    '                index += 1

    '            Next

    '        End With

    '    End Sub

    '    Public Sub selectSummaryTabPage(ByRef mainDisplay As MailScanDomsForm)

    '#If ValidationLevel >= 3 Then

    '        If diagnosticLevel >= 2 Then
    '            verify(Not mainDisplay Is Nothing, 1505)
    '        End If

    '#End If

    '        Dim tabPage As Windows.Forms.TabPage
    '        Dim index As Integer

    '        enableMenu()

    '        mainDisplay.resetOperationComboBoxWithoutWarning()

    '        With mainDisplay

    '            index = 0

    '            For Each tabPage In .mainTabControl.TabPages

    '                If tabPage.Text = "summary" Then

    '                    previousTabPage = currentTabPage
    '                    currentTabPage = "summary"

    '                    System.Threading.Monitor.Enter(summaryFileAccessCriticalSection)
    '                    loadSummaryInformation(mainDisplay)
    '                    System.Threading.Monitor.Exit(summaryFileAccessCriticalSection)

    '                    .mainTabControl.SelectedIndex = index

    '                    tabPage.Show()
    '                    tabPage.BringToFront()
    '                    tabPage.Visible = True

    '                    Application.DoEvents()

    '                    Exit Sub

    '                End If

    '                index += 1

    '            Next

    '        End With

    '    End Sub


    '    Public Sub selectTabPage(ByRef mainDisplay As MailScanDomsForm, ByRef tabPageToGoTo As String)

    '#If ValidationLevel >= 3 Then

    '        If diagnosticLevel >= 2 Then
    '            verify(Not mainDisplay Is Nothing, 1509)
    '            verify(Not tabPageToGoTo Is Nothing, 1510)
    '        End If

    '#End If

    '        Select Case (tabPageToGoTo)

    '            Case "mail scan"

    '                selectMailScanTabPage(mainDisplay)
    '                Exit Sub

    '            Case "notify"


    '                mainDisplay.resetOperationComboBoxWithoutWarning()

    '                selectNotifyTabPage(mainDisplay)
    '                Exit Sub

    '            Case "error"


    '                mainDisplay.resetOperationComboBoxWithoutWarning()

    '                selectErrorTabPage(mainDisplay)
    '                Exit Sub

    '                'Case "summary"


    '                '    mainDisplay.resetOperationComboBoxWithoutWarning()

    '                '    selectSummaryTabPage(mainDisplay)
    '                '    Exit Sub



    '            Case Else

    '                systemError("Invalid call to selectTabPage")
    '                activeReaderForm.Close()

    '        End Select

    '    End Sub

End Module
