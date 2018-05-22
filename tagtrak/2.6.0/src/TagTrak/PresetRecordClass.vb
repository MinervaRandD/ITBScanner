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

Public Class presetRecordClass

    Public staticPresetFlag As Boolean
    Public origin As String
    Public destination As String
    Public batchID As String
    Public newDestination As String
    Public newFlightNumber As String
    Public flightNumber As String
    Public presetCreationDateAndTime As DateTime
    Public presetLastUsedDateAndTime As DateTime = New DateTime(0)
    Public globalScanCountOnCreation As Integer = 0
    Public progType As Char = " "c

    Public IsValid As Boolean

    Public Sub New()

        origin = ""
        destination = ""
        batchID = ""
        newDestination = ""
        newFlightNumber = ""
        flightNumber = ""
        staticPresetFlag = False
        presetCreationDateAndTime = DateTime.UtcNow()
        presetLastUsedDateAndTime = New DateTime(0)

        Util.updateGlobalScanCount()

        globalScanCountOnCreation = globalScanCount

        IsValid = False

    End Sub

    Public Sub New( _
            ByRef inputStaticPreset As String, _
            ByRef inputOrigin As String, _
            ByRef inputDestination As String, _
            ByRef inputFlightNumber As String, _
            ByRef inputBatchID As String, _
            ByVal inputProgType As Char)

#If ValidationLevel >= 3 Then

        if diagnosticLevel >= 2 then
            verify(not inputStaticPreset is nothing, 10010)
	    verify(not inputOrigin is nothing, 10011)
	    verify(not inputDestination is nothing, 10012)
	    verify(not inputFlightNumber is nothing, 10013)
	    verify(not inputBatchID is nothing, 10014)
        end if

#End If

        staticPresetFlag = Boolean.Parse(inputStaticPreset)
        origin = inputOrigin.ToUpper
        destination = inputDestination.ToUpper
        flightNumber = inputFlightNumber.PadLeft(4, "0")
        batchID = inputBatchID
        newDestination = ""
        newFlightNumber = ""
        presetCreationDateAndTime = DateTime.UtcNow()
        presetLastUsedDateAndTime = New DateTime(0)
        progType = inputProgType

        IsValid = True

        Util.updateGlobalScanCount()

        globalScanCountOnCreation = globalScanCount

    End Sub

    Public Sub New( _
        ByVal inputStaticPresetFlag As String, _
        ByRef inputOrigin As String, _
        ByRef inputDestination As String, _
        ByRef inputFlightNumber As String, _
        ByRef inputbatchID As String, _
        ByRef inputNewDestination As String, _
        ByRef inputNewFlightNumber As String, _
        ByRef inputCreationDate As String, _
        ByRef inputGlobalScanCountOnCreation As Integer, _
        ByVal inputProgType As Char)

#If ValidationLevel >= 3 Then

        if diagnosticLevel >= 2 then

            verify(not inputStaticPresetFlag is nothing, 10030)
            verify(not inputOrigin is nothing, 10031)
            verify(not inputDestination is nothing, 10032)
            verify(not inputFlightNumber is nothing, 10033)
            verify(not inputbatchID is nothing, 10034)
            verify(not inputNewDestination is nothing, 10035)
            verify(not inputNewFlightNumber is nothing, 10036)
            verify(not inputCreationDate is nothing, 10037)
            verify(inputGlobalScanCountOnCreation >= 0, 10038)

        end if

#End If

        staticPresetFlag = Boolean.Parse(inputStaticPresetFlag)
        staticPresetFlag = inputStaticPresetFlag
        origin = inputOrigin.ToUpper
        destination = inputDestination.ToUpper
        flightNumber = inputFlightNumber.PadLeft(4, "0")
        batchID = inputbatchID
        newDestination = inputNewDestination
        newFlightNumber = inputNewFlightNumber

        If inputCreationDate Is Nothing Then
            presetCreationDateAndTime = DateTime.UtcNow()
        Else
            presetCreationDateAndTime = DateTime.Parse(inputCreationDate)
        End If

        presetLastUsedDateAndTime = New DateTime(0)

        globalScanCountOnCreation = inputGlobalScanCountOnCreation
        progType = inputProgType

        IsValid = True

    End Sub

    Public Sub New(ByVal presetRecord As presetRecordClass)


        staticPresetFlag = presetRecord.staticPresetFlag
        origin = presetRecord.origin
        destination = presetRecord.destination
        batchID = presetRecord.batchID
        newDestination = presetRecord.newDestination
        newFlightNumber = presetRecord.newFlightNumber
        flightNumber = presetRecord.flightNumber
        presetCreationDateAndTime = presetRecord.presetCreationDateAndTime
        presetLastUsedDateAndTime = New DateTime(0)
        progType = presetRecord.progType

        Util.updateGlobalScanCount()

        globalScanCountOnCreation = globalScanCount

        IsValid = presetRecord.IsValid

    End Sub

    Public Sub New(ByVal inputPresetRecordString As String)

        Dim tokenSet() As String = inputPresetRecordString.Split(",")

        If tokenSet.Length <> 11 Then
            IsValid = False
            Return
        End If

        Try
            staticPresetFlag = Trim(tokenSet(0))
        Catch ex As Exception
            IsValid = False
            Util.systemError("Invalid Record In Preset File")
            Return
        End Try

        origin = Trim(tokenSet(1))
        destination = Trim(tokenSet(2))
        flightNumber = Trim(tokenSet(3))
        batchID = Trim(tokenSet(4))
        newDestination = Trim(tokenSet(5))
        newFlightNumber = Trim(tokenSet(6))

        Try
            presetCreationDateAndTime = Trim(tokenSet(7))
        Catch ex As Exception
            IsValid = False
            Util.systemError("Invalid Record In Preset File")
            Return
        End Try

        Try
            globalScanCountOnCreation = Trim(tokenSet(8))
        Catch ex As Exception
            IsValid = False
            Util.systemError("Invalid Record In Preset File")
            Return
        End Try

        Try
            presetLastUsedDateAndTime = Trim(tokenSet(9))
        Catch ex As Exception
            IsValid = False
            Util.systemError("Invalid Record In Preset File")
            Return
        End Try

        Try
            progType = Trim(tokenSet(10))
        Catch ex As Exception
            IsValid = False
            Util.systemError("Invalid Record In Preset File")
            Return
        End Try

        IsValid = True

    End Sub

    Public Function isReroutePreset() As Boolean

        If isNonNullString(newDestination) And isNonNullString(newFlightNumber) Then
            Return True
        Else
            Return False
        End If

    End Function

    Public Function formatForListBox() As String

        Dim returnString As String = ""

        If staticPresetFlag Then
            returnString &= "K "
        Else
            If Me.presetHasExpired() Then
                returnString &= "E "
            Else
                returnString &= "  "
            End If
        End If

        returnString &= origin & " "

        If isNonNullString(destination) Then
            returnString &= destination & " "
        Else
            returnString &= "    "
        End If

        returnString &= flightNumber.PadLeft(4, "0") & " "
        returnString &= batchID.PadRight(10)

        If isReroutePreset() Then
            returnString &= " " & newDestination & "/" & newFlightNumber.PadLeft(4, "0")
        End If

        Return returnString

    End Function

    Public Function formatForUpload() As String

        Dim returnString As String = ""

        returnString = globalScanCountOnCreation.ToString()

        returnString &= TagTrakGlobals.fieldSepChar

        If staticPresetFlag Then
            returnString &= "K"
        Else
            If Me.presetHasExpired() Then
                returnString &= "E"
            Else
                returnString &= "T"
            End If
        End If

        returnString &= TagTrakGlobals.fieldSepChar

        returnString &= origin & TagTrakGlobals.fieldSepChar

        If isNonNullString(destination) Then
            returnString &= destination & TagTrakGlobals.fieldSepChar
        Else
            returnString &= TagTrakGlobals.fieldSepChar
        End If

        returnString &= flightNumber & TagTrakGlobals.fieldSepChar
        returnString &= batchID

        If isReroutePreset() Then
            returnString &= TagTrakGlobals.fieldSepChar & newDestination & "/" & newFlightNumber
        End If

        returnString &= TagTrakGlobals.fieldSepChar & progType

        Return returnString

    End Function

    Public Function formatForOutput() As String

        Dim returnString As String = ""

        returnString &= staticPresetFlag.ToString & ","

        returnString &= origin & ","

        returnString &= destination & ","

        returnString &= flightNumber.PadLeft(4, "0") & ","

        returnString &= batchID.PadRight(10) & ","

        If isNonNullString(newDestination) Then
            returnString &= newDestination & ","
        Else
            returnString &= "   ,"
        End If

        If isNonNullString(newFlightNumber) Then
            returnString &= newFlightNumber.PadLeft(4, "0") & ","
        Else
            returnString &= "    ,"
        End If

        returnString &= presetCreationDateAndTime.ToString & ","

        returnString &= Me.globalScanCountOnCreation.ToString.PadLeft(4) & ","

        returnString &= presetLastUsedDateAndTime.ToString

        returnString &= "," & Me.progType

        Return returnString

    End Function

    Public Function compare(ByRef comparePresetRecord As presetRecordClass) As Integer

#If ValidationLevel >= 3 Then

        If diagnosticLevel >= 2 Then
            verify(Not comparePresetRecord Is Nothing, 11000)
        End If

#End If


        Dim rc As Integer
        Dim flight1, flight2 As String

        rc = String.Compare(origin, comparePresetRecord.origin)
        If rc <> 0 Then Return rc

        rc = String.Compare(destination, comparePresetRecord.destination)
        If rc <> 0 Then Return rc

        If Util.IsInteger(flightNumber) Then
            flight1 = flightNumber.PadLeft(4, "0")
        Else
            flight1 = flightNumber
        End If

        If Util.IsInteger(comparePresetRecord.flightNumber) Then
            flight2 = comparePresetRecord.flightNumber.PadLeft(4, "0")
        Else
            flight2 = comparePresetRecord.flightNumber
        End If

        rc = String.Compare(flight1, flight2)
        If rc <> 0 Then Return rc

        rc = String.Compare(batchID, comparePresetRecord.batchID)
        If rc <> 0 Then Return rc

        rc = String.Compare(newDestination, comparePresetRecord.newDestination)
        If rc <> 0 Then Return rc

        If Util.IsInteger(newFlightNumber) Then
            flight1 = newFlightNumber.PadLeft(4, "0")
        Else
            flight1 = newFlightNumber
        End If

        If Util.IsInteger(comparePresetRecord.newFlightNumber) Then
            flight2 = comparePresetRecord.newFlightNumber.PadLeft(4, "0")
        Else
            flight2 = comparePresetRecord.newFlightNumber
        End If

        rc = String.Compare(flight1, flight2)
        If rc <> 0 Then Return rc

        Return 0

    End Function

    Public Function presetHasExpired() As Boolean
        ' static preset should never expire
        If Me.staticPresetFlag Then Return False

        Dim expirationTime As DateTime = DateTime.UtcNow().AddHours(-8.0)

        If DateTime.Compare(expirationTime, presetCreationDateAndTime) > 0 Then
            Return True
        Else
            Return False
        End If

    End Function

    Public Overrides Function ToString() As String
        Return Me.formatForListBox()
    End Function

End Class
