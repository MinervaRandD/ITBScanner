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

Public Class DandRTagClass

    Public DandRTagValue As String

    Public Function format() As String

        If Not isValid() Then
            MsgBox("Attempt to format invalid D and R tag")
            Stop
        End If

        Return DandRTagValue.ToUpper

    End Function

    Public Sub parse(ByRef inputString As String)

#if ValidationLevel >= 3
        
	if diagnosticLevel >= 2 then
            verify(Not inputString Is Nothing, 2300)
        end if

#endif

        Dim trimmedString As String = Trim(inputString)

        If Length(trimmedString) <> 10 Then
            DandRTagValue = ""
            Exit Sub
        End If

        trimmedString.ToUpper()

        DandRTagValue = trimmedString

        If Not isValid() Then
            DandRTagValue = ""
            Exit Sub
        End If

    End Sub

    Public Function isValid() As Boolean

        If Length(DandRTagValue) <> 10 Then Return False

        Return True

    End Function

End Class
