Public Class crticalSectionSemiphoreClass

    Private semiphoreState As Boolean

    Public Sub New(ByVal initialValue As Boolean)
        semiphoreState = initialValue
    End Sub

    Public Function getSemiphoreState() As Boolean

        Return semiphoreState

    End Function

    Public Function setSemiphoreState(ByVal newState As Boolean) As Boolean

        semiphoreState = newState

        Return semiphoreState

    End Function

End Class
