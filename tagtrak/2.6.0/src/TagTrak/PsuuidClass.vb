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

Public Class psuuidClass

    Declare Function GetSerNum Lib "PSUUID0C.DLL" Alias "?GetSerNum@@YAHPAGK@Z" (ByVal SerNum() As Byte, ByVal SizeSerNum As Int32) As Integer

End Class
