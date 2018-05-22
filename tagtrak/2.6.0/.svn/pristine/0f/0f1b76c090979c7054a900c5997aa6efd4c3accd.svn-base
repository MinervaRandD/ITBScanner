Namespace Data.FlightSchedule

    '' Validates flight information
    Public Class Validation

        '' TheFlightNumber MUST be valid.
        Public Shared Function ValidateOutboundFlight(ByVal TheFlightNumber As String, ByVal TheLocationCode As String, Optional ByVal TheDestinationCity As String = "") As String

#If ValidationLevel >= 3 Then

        If diagnosticLevel >= 2 Then
            verify(Not flightNumberString Is Nothing, 24000)
            verify(Not locationCode Is Nothing, 24001)
        End If

#End If

            If Not userSpecRecord.displayFlightValidationMessages Then Return "OK"

            TheFlightNumber = Trim(TheFlightNumber).PadLeft(4, "0")

            If Not Util.isValidFlightNumber(TheFlightNumber) Then
                Util.systemError("Invalid value passed to ValidateOutboundFlight")
                Stop
            End If

            '' Validate flight
            Dim IsOutboundFlight As Boolean = True
            Dim F As Flights.Flight = flightScheduleSet.GetFlight(TheFlightNumber)
            If Not F Is Nothing Then
                If TheDestinationCity <> "" Then
                    '' Validate with destination city
                    IsOutboundFlight = False
                    Dim C As Flights.City = F.GetCity(TheDestinationCity)
                    If Not C Is Nothing Then
                        If (C.Direction And Flights.City.Directions.Outbound) = 0 Then
                            '' Flight to this city is not outbound
                            IsOutboundFlight = False
                        Else
                            '' Flight to this city is outbound
                            IsOutboundFlight = True
                        End If
                    End If
                Else
                    '' Just validate flight direction
                    IsOutboundFlight = (F.Direction And Flights.Flight.Directions.Outbound) > 0
                End If
            Else
                '' No Flight exists
                If flightScheduleSet.IsInclusive Then IsOutboundFlight = False
            End If

            If Not IsOutboundFlight Then
                '' Show warning
                Dim ErrMsg As FlightScheduleError
                If TheDestinationCity = "" Then
                    ErrMsg = New FlightScheduleError("Warning: flight number " & TheFlightNumber & " is not a scheduled outbound flight from " & TheLocationCode & ". Accept this scan anyway?")
                Else
                    ErrMsg = New FlightScheduleError("Warning: flight number " & TheFlightNumber & " is not a scheduled outbound flight from " & TheLocationCode & " to " & TheDestinationCity & ". Accept this scan anyway?")
                End If
                Dim R As DialogResult = ErrMsg.ShowDialog()
                If R = DialogResult.Yes Then
                    Return "OK"
                Else
                    Return "User cancelled."
                End If
            End If

            Return "OK"
        End Function

        '' TheFlightNumber MUST be valid.
        Public Shared Function ValidateInboundFlight(ByVal TheFlightNumber As String, ByVal TheLocationCode As String, Optional ByVal TheOriginCity As String = "") As String

#If ValidationLevel >= 3 Then

        If diagnosticLevel >= 2 Then
            verify(Not flightNumberString Is Nothing, 25000)
            verify(Not locationCode Is Nothing, 25001)
        End If

#End If

            If Not userSpecRecord.displayFlightValidationMessages Then Return "OK"

            TheFlightNumber = Trim(TheFlightNumber).PadLeft(4, "0")

            If Not Util.isValidFlightNumber(TheFlightNumber) Then
                Util.systemError("Invalid value passed to ValidateOutboundFlight")
                Stop
            End If

            '' Validate flight
            Dim IsInboundFlight As Boolean = True
            Dim F As Flights.Flight = flightScheduleSet.GetFlight(TheFlightNumber)
            If Not F Is Nothing Then
                '' This flight exist
                If TheOriginCity <> "" Then
                    '' Validate with destination city
                    IsInboundFlight = False
                    Dim C As Flights.City = F.GetCity(TheOriginCity)
                    If Not C Is Nothing Then
                        If (C.Direction And Flights.City.Directions.Inbound) = 0 Then
                            '' Flight to this city is not outbound
                            IsInboundFlight = False
                        Else
                            '' Flight to this city is outbound
                            IsInboundFlight = True
                        End If
                    End If
                Else
                    '' Just validate flight direction
                    IsInboundFlight = (F.Direction And Flights.Flight.Directions.Inbound) > 0
                End If
            Else
                '' No Flight exists
                If flightScheduleSet.IsInclusive Then IsInboundFlight = False
            End If

            If Not IsInboundFlight Then
                '' Show warning
                Dim ErrMsg As FlightScheduleError
                If TheOriginCity = "" Then
                    ErrMsg = New FlightScheduleError("Warning: flight number " & TheFlightNumber & " is not a scheduled inbound flight to " & TheLocationCode & ". Accept this scan anyway?")
                Else
                    ErrMsg = New FlightScheduleError("Warning: flight number " & TheFlightNumber & " is not a scheduled inbound flight from " & TheOriginCity & " to " & TheLocationCode & ". Accept this scan anyway?")
                End If
                Dim R As DialogResult = ErrMsg.ShowDialog()
                If R = DialogResult.Yes Then
                    Return "OK"
                Else
                    Return "User cancelled."
                End If
            End If

            Return "OK"
        End Function

    End Class

End Namespace