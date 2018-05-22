Option Explicit On 
Option Strict On

Namespace Data.FlightSchedule

    '' Efficiently keeps track of flight/city combination inbound/outbound records.
    Public Class Flights

        '' Represents one city information record (including In/Out combinations)
#Region "City Record"
        Class City
            Public Name As String
            Enum Directions
                Inbound = 1
                Outbound = 2
            End Enum
            Public Direction As Directions

            Sub New(ByVal TheName As String, ByVal TheDirection As Directions)
                Name = TheName
                Direction = TheDirection
            End Sub

        End Class
#End Region

        '' Represents one flight record (containing information for multiple cities).
#Region "Flight Record"
        Class Flight
            Implements IComparable

            Public Number As Integer

            '' The direction of the flight
            Enum Directions
                Inbound = 1
                Outbound = 2
            End Enum
            Private DirectionProp As Directions
            Public ReadOnly Property Direction() As Directions
                Get
                    Return DirectionProp
                End Get
            End Property

            Private MyCities As New Specialized.HybridDictionary

            Sub New(ByVal TheNumber As Integer)
                Number = TheNumber
            End Sub

            Sub New(ByVal TheNumber As String)
                Number = Integer.Parse(TheNumber)
            End Sub

            '' Add the city or add the In/Out to a current city
            Public Sub AddCity(ByVal TheCity As City)
                If Not MyCities.Contains(TheCity.Name) Then
                    MyCities.Add(TheCity.Name, TheCity)
                Else
                    '' Update city direction information on an already existing city
                    Dim C As City = GetCity(TheCity.Name)
                    C.Direction = C.Direction Or TheCity.Direction
                End If

                '' Update flight direction
                DirectionProp = CType(DirectionProp Or TheCity.Direction, Directions)
            End Sub

            Public Sub AddCity(ByVal TheCityName As String, ByVal TheDirection As City.Directions)
                AddCity(New City(TheCityName, TheDirection))
            End Sub

            Public Function GetCity(ByVal TheCityName As String) As City
                If MyCities.Contains(TheCityName) Then
                    Return DirectCast(MyCities.Item(TheCityName), City)
                Else
                    Return Nothing
                End If
            End Function

            '' Implements default comparison by flight number
            Public Function CompareTo(ByVal obj As Object) As Integer Implements System.IComparable.CompareTo
                Dim F1 As Flight = Me
                Dim F2 As Flight = DirectCast(obj, Flight)
                Return F1.Number.CompareTo(F2.Number)
            End Function
        End Class
#End Region

        '' This tells us whether the flights list is "inclusive".
        '' In other words, if it includes all possible flights and is not missing any information.
        '' If so, we assume that any unknwon flight entered do not exist, and we warn the user.
        '' If the list is not inclusive, unknown flights do not generate a mismatch warning, only known flights
        '' used incorrectly generate a warning.
        '' Currently: All parsed schedules are considered inclusive.
        Public IsInclusive As Boolean

        Private MyFlights As New Specialized.HybridDictionary

        Sub New(ByVal Inclusive As Boolean)
            IsInclusive = Inclusive
        End Sub

        Public Sub AddFlight(ByVal TheFlight As Flight)
            If Not MyFlights.Contains(TheFlight.Number) Then
                MyFlights.Add(TheFlight.Number, TheFlight)
            End If
        End Sub

        '' Returns the flight information for a given flight number if one exists.
        '' If not, returns Nothing.
        Public Function GetFlight(ByVal TheFlightNumber As Integer) As Flight
            If MyFlights.Contains(TheFlightNumber) Then
                Return DirectCast(MyFlights.Item(TheFlightNumber), Flight)
            End If

            Return Nothing
        End Function

        Public Function GetFlight(ByVal TheFlightNumber As String) As Flight
            Return GetFlight(Integer.Parse(TheFlightNumber))
        End Function

        Public Function GetFlights() As Flight()
            Dim R(MyFlights.Count - 1) As Flight
            MyFlights.Values.CopyTo(R, 0)
            Return R
        End Function

#Region "Parse"

        '' Returns an instance of FlightScheduleClass from the input string data.
        '' Returns Nothing on invalid input.
        Public Shared Function Parse(ByVal TheData As String) As Flights
            '' Data format:
            ''
            '' CLT,ABX|0234|DFW
            '' -------               Origin cities (comma separated) (optional)
            ''         ----          Flight number
            ''              ---      Destination cities (comma separated) (optional)

            '' Currently: All parsed schedules are considered inclusive.
            Dim Result As New Flights(True)

            Dim sr As New IO.StringReader(TheData)
            Dim LineIn As String = sr.ReadLine
            Dim LineRecord() As String

            '' Above records
            Dim OriginCities As String
            Dim FlightNumber As String
            Dim DestinationCities As String

            '' The individual cities
            Dim OriginCity() As String
            Dim DestinationCity() As String

            '' For enumeration/insertion
            Dim CityStr As String
            Dim NewFlight As Flight

            Do While Not LineIn Is Nothing
                LineRecord = LineIn.Split("|"c)
                '' Record always contains 3 inputs
                If LineRecord.Length = 3 Then
                    '' Extract the information
                    OriginCities = LineRecord(0)
                    FlightNumber = LineRecord(1)
                    DestinationCities = LineRecord(2)

                    OriginCity = OriginCities.Split(","c)
                    DestinationCity = DestinationCities.Split(","c)

                    '' Ok, add the records
                    NewFlight = New Flight(FlightNumber)
                    For Each CityStr In OriginCity
                        If CityStr <> "" Then
                            NewFlight.AddCity(New City(CityStr, City.Directions.Inbound))
                        End If
                    Next

                    For Each CityStr In DestinationCity
                        If CityStr <> "" Then
                            NewFlight.AddCity(New City(CityStr, City.Directions.Outbound))
                        End If
                    Next

                    Result.AddFlight(NewFlight)

                End If
                LineIn = sr.ReadLine
            Loop

            sr.Close()

            Return Result

        End Function

        '' Parse from a filename.
        '' Returns Nothing on an error.
        Public Shared Function ParseFile(ByVal TheFileName As String) As Flights
            Dim sr As IO.StreamReader
            Dim Input As String
            Try
                sr = New IO.StreamReader(TheFileName)
                Input = sr.ReadToEnd
                sr.Close()
            Catch ex As Exception
                Return Nothing
            End Try

            Return Parse(Input)

        End Function

#End Region

    End Class

End Namespace