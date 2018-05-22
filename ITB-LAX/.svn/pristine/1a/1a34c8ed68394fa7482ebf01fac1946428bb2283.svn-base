Imports Microsoft.WindowsMobile
Imports Microsoft.WindowsMobile.Status

Namespace Networking
    Public Class GPRS

        Public Enum SignalBars
            RadioOff = -1
            Bar0 = 0
            Bar1 = 1
            Bar2 = 2
            Bar3 = 3
            Bar4 = 4
        End Enum

        Private State As SystemState

        Public Sub New()
            State = New SystemState(SystemProperty.PhoneSignalStrength)
            AddHandler State.Changed, New ChangeEventHandler(AddressOf SignalStrengthState_Changed)
        End Sub

        Public Delegate Sub SignalStrengthChangedDel(ByVal SignalStrength As SignalBars)
        Public Event SignalStrengthChanged As SignalStrengthChangedDel

        Private Sub SignalStrengthState_Changed(ByVal Sender As Object, ByVal Args As ChangeEventArgs)

            Dim SignalBar As SignalBars = GetSignalStrength(SystemState.PhoneSignalStrength)
            RaiseEvent SignalStrengthChanged(SignalBar)

        End Sub

        Public Function GetFirstSignalStrength() As SignalBars

            Dim SignalBar As SignalBars = GetSignalStrength(CInt(State.CurrentValue))
            Return SignalBar

        End Function

        Private Function GetSignalStrength(ByVal PercentVal As Integer) As SignalBars

            Dim SignalBar As SignalBars

            If PercentVal < 30 Then
                Signalbar = SignalBars.Bar0
            ElseIf PercentVal >= 30 And PercentVal < 49 Then
                Signalbar = SignalBars.Bar1
            ElseIf PercentVal >= 50 And PercentVal < 69 Then
                Signalbar = SignalBars.Bar2
            ElseIf PercentVal >= 70 And PercentVal < 89 Then
                Signalbar = SignalBars.Bar3
            ElseIf PercentVal >= 90 And PercentVal <= 100 Then
                Signalbar = SignalBars.Bar4
            Else
                Signalbar = SignalBars.Bar0
            End If

            Return SignalBar

        End Function

    End Class
End Namespace