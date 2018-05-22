' Copyright (c) 2003-2004 Airline Software, Inc.,
' All Rights Reserved. 
' Reproduction of this document in whole or in part without written permission of   
' Airline Software, Inc. is strictly prohibited.
'
' Airline Software, Inc., Confidential - Restricted Access
'
' This document contains proprietary information that shall be
' distributed or routed only within Airline Software, Inc.,
' and its authorized clients, except with written permission of
' Airline Software, Inc. 

Public Class shippedItemRecordClass

    Public resditRecordList As Collection
    Public DandRTag As DandRTagClass
    Public weight As Double


    Public Sub New(ByRef resditRecord As resditRecordClass)

#if ValidationLevel >= 3 then

        if diagnosticLevel >= 2 then
            verify(not resditRecord is nothing, 22000)
        end if

#end if

        resditRecordList = New Collection
        DandRTag = resditRecord.DandRTag
        weight = resditRecord.weight
        resditRecordList.Add(resditRecord)

    End Sub

    Public Sub New()

        resditRecordList = New Collection
        DandRTag = New DandRTagClass
        weight = -1.0

    End Sub

End Class
