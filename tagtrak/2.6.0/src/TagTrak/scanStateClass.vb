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

Public Class scanStateClass

    Public scanStateValue As Char

    Public Const scanStateLegalValues As String = "PLTUOXRD"

    Public Function reset()
        scanStateValue = " "c
    End Function

    Public Function format() As String

        If Not isValid() Then
            MsgBox("Attempt to format invalid scan state")
            Stop
        End If

        Return CStr(scanStateValue)

    End Function

    Public Sub parse(ByRef inputString As String)

#if ValidationLevel >= 3 then

        if diagnosticLevel >= 2 then
            verify(Not inputString Is Nothing, 18000)
        end if

#end if

        Dim trimmedString As String = Trim(inputString)

        If Length(trimmedString) <> 1 Then
            scanStateValue = Chr(0)
            Exit Sub
        End If

        trimmedString.ToUpper()

        scanStateValue = Chr(Asc(trimmedString))

        If Not isValid() Then
            scanStateValue = Chr(0)
            Exit Sub
        End If

    End Sub

    Public Function isValid() As Boolean

        If scanStateLegalValues.IndexOf(scanStateValue) < 0 Then Return False

        Return True

    End Function

    Public Overloads Function equals(ByRef compareScanState As scanStateClass) As Boolean

        Return Me.scanStateValue = compareScanState.scanStateValue

    End Function

    Public Overloads Function equals(ByRef s1 As scanStateClass, ByRef s2 As scanStateClass) As Boolean

        Return s1.scanStateValue = s2.scanStateValue

    End Function

End Class
