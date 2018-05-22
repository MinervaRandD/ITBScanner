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
Imports System.TimeZone
Imports System.IO

Module startupProcess

    Public Sub createLocalDirectoryIfNecessary(ByRef newDirectoryPath As String)

#if ValidationLevel >= 3

        if diagnosticLevel >= 2 then
            verify(not newDirectoryPath is nothing, 23000)
        end if

#end if

        If Not Directory.Exists(newDirectoryPath) Then

            Try

                Directory.CreateDirectory(newDirectoryPath)

            Catch ex As Exception

                MsgBox("Unable to createDirectory " & newDirectoryPath & ": " & ex.Message, MsgBoxStyle.Exclamation, "Directory Creation Failed")
                Stop

            End Try

        End If

    End Sub



End Module
