Option Explicit On 
Option Strict On

Namespace Time
    '' Represents our knowledge of time zone information, normally obtained from the server.
    Public Class TimeZone

#Region "Offset"
        Public Class Offset
            Enum ConfidenceLevels
                UTC0
                AskedUser
                LoadedFromFile
                ServerProvided
            End Enum

            Public Confidence As ConfidenceLevels
            Public OffsetUTC As Double

            Sub New(ByVal TheOffsetUTC As Double, ByVal TheConfidence As ConfidenceLevels)
                OffsetUTC = TheOffsetUTC
                Confidence = TheConfidence
            End Sub

        End Class

#End Region

        Public IsKnown As Boolean = False
        Public CityName As String = ""

        Private PropOffsetInfo As Offset = New Offset(0, Offset.ConfidenceLevels.UTC0)
        Public Property OffsetInfo() As Offset
            Get
                Return PropOffsetInfo
            End Get
            Set(ByVal Value As Offset)
                PropOffsetInfo = Value
                If (Value Is Nothing = False) Then
                    IsKnown = True
                Else
                    IsKnown = False
                End If
            End Set
        End Property

        Sub New()
            '' Empty constructor to accommodate state of unknown time zone
        End Sub

        Sub New(ByVal TheCityName As String)
            CityName = TheCityName
        End Sub

        '' Writes the current time zone record to a "tz2.txt" file with an obsolete date so 
        '' that it can be replaced by an accurate one from the server on a successful sync.
        '' We can do this to prevent prompting multiple times for the time zone if the first one did not
        '' yield a valid response.
        Public Sub WriteToFile(ByVal TheCityCode As String)
            If IsKnown = False Then Return

            Dim localFilePath As String = TagTrakDataDirectory & "\tz2.txt"
            Dim dateStampFilePath As String = TagTrakConfigDirectory & "\tz2TimeStamp.txt"

            Dim fs As IO.FileStream
            Dim sw As IO.StreamWriter

            Try
                fs = New IO.FileStream(localFilePath, IO.FileMode.Create)
                sw = New IO.StreamWriter(fs)

                sw.WriteLine("*" & TheCityCode & " " & OffsetInfo.OffsetUTC)

            Catch ex As Exception
                If sw Is Nothing = False Then sw.Close()
                If fs Is Nothing = False Then fs.Close()
                Return
            End Try

            If sw Is Nothing = False Then sw.Close()
            If fs Is Nothing = False Then fs.Close()

            saveDateStampToDateStampFile(Date.MinValue, dateStampFilePath)

        End Sub

#Region "Load"
        '' Load timezone information from file.
        '' Returns TimeZone object with IsKnown set if load was successful
        Public Shared Function Load(ByVal TheFileName As String, ByVal TheCityName As String) As TimeZone

            TheCityName = TheCityName.ToUpper

            Dim R As New TimeZone(TheCityName)

            If Not IO.File.Exists(TheFileName) Then
                Return R
            End If

            Dim fs As IO.FileStream
            Dim sr As IO.StreamReader
            Try
                fs = New IO.FileStream(TheFileName, IO.FileMode.Open)
            Catch ex As Exception
                Return R
            End Try

            Try
                sr = New IO.StreamReader(fs)
            Catch ex As Exception
                fs.Close()
                Return R
            End Try

            Dim Record() As String
            Try
                Dim ReadOffsetLine As String = sr.ReadLine()
                Dim CityName As String
                Dim Offset As String
                Dim IsProgramSaved As Boolean
                Do While Not ReadOffsetLine Is Nothing
                    '' Make sure record is > 3 characters
                    If ReadOffsetLine.Length > 3 Then
                        IsProgramSaved = (ReadOffsetLine.Substring(0, 1) = "*")
                        If IsProgramSaved Then
                            ReadOffsetLine = ReadOffsetLine.Substring(1)
                        End If
                        CityName = ReadOffsetLine.Substring(0, 3)
                        Offset = ReadOffsetLine.Substring(3).Trim
                        If CityName = TheCityName Then
                            If IsProgramSaved Then
                                R.OffsetInfo = New Offset(Double.Parse(Offset), Time.TimeZone.Offset.ConfidenceLevels.AskedUser)
                            Else
                                R.OffsetInfo = New Offset(Double.Parse(Offset), Time.TimeZone.Offset.ConfidenceLevels.LoadedFromFile)
                            End If
                            Exit Do
                        End If
                    End If
                    ReadOffsetLine = sr.ReadLine()
                Loop

            Catch ex As Exception
            Finally
                sr.Close()
                fs.Close()
            End Try

            Return R

        End Function
#End Region

        '' Gets the offset as used in the OS
        Public Shared Function GetOSUTCOffset() As Double
            Dim CurTime As Date = Now
            Return CurTime.Subtract(CurTime.ToUniversalTime).TotalHours
        End Function

    End Class

End Namespace