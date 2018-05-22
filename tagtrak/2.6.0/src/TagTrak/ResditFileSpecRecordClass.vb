Imports System
Imports System.io

Public Class myResditRecordReverserClass
    Implements IComparer

    ' Calls CaseInsensitiveComparer.Compare with the parameters reversed.
    Function Compare(ByVal x As [Object], ByVal y As [Object]) As Integer _
       Implements IComparer.Compare

        Dim r1 As resditFileSpecRecordClass = x
        Dim r2 As resditFileSpecRecordClass = y

        Return r1.Compare(r2)

    End Function 'IComparer.Compare

End Class 'myReverserClass

Public Class resditFileSpecRecordClass
    Public fileName As String
    Public dateCreated As DateTime
    Public fileSize As Integer

    Public Sub New()
        fileName = ""
        dateCreated = Nothing
        fileSize = -1
    End Sub

    Public Sub New(ByVal filePath As String)

#If ValidationLevel >= 3 Then

        If diagnosticLevel >= 2 Then
            verify(Not filePath Is Nothing, 1400)
        End If

#End If

        If Not File.Exists(filePath) Then
            fileName = ""
            dateCreated = #1/1/1900#
            fileSize = -1

            Exit Sub
        End If

        fileName = filePath

        Dim resditFileInfo As FileInfo

        Try

            resditFileInfo = New FileInfo(filePath)

        Catch ex As Exception

            fileName = ""
            dateCreated = #1/1/1900#
            fileSize = -1

            Exit Sub

        End Try

        dateCreated = resditFileInfo.CreationTime
        fileSize = resditFileInfo.Length

    End Sub

    Public Overrides Function ToString() As String

        Dim returnString As String = ""

        If fileName Is Nothing Or dateCreated = #1/1/1900# Or fileSize < 0 Then
            Return ""
        End If

        If fileName.EndsWith("MailData.txt") Then
            returnString = "Curr "
        ElseIf fileName.IndexOf(userSpecRecord.userName & "MailDataBkup.") >= 0 Then
            returnString = "Bkup "
        Else
            returnString = "???? "
        End If

        returnString &= String.Format("{0:yyyy-MM-dd HH:mm} ", dateCreated)

        returnString &= String.Format("{0:#,##0}", fileSize).PadLeft(10)

        Return returnString

    End Function

    Public Function Compare(ByVal r2 As resditFileSpecRecordClass) As Integer

#If ValidationLevel >= 3 Then

        If diagnosticLevel >= 2 Then
            verify(Not Me.fileName Is Nothing, 99001)
            verify(Not r2.fileName Is Nothing, 99002)
        End If

#End If

        If Me.fileName.ToUpper.EndsWith("MAILDATA.TXT") Then

            If r2.fileName.ToUpper.EndsWith("MAILDATA.TXT") Then
                DateTime.Compare(Me.dateCreated, r2.dateCreated)
            Else
                Return -1
            End If

        Else

            If r2.fileName.ToUpper.EndsWith("MAILDATA.TXT") Then
                Return 1
            Else
                Return DateTime.Compare(Me.dateCreated, r2.dateCreated)
            End If

        End If

        Return 0

    End Function

End Class
