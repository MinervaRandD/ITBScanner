'' Used OS for high resolution timing
Public Class Timing

    <System.Runtime.InteropServices.DllImport("coredll.dll")> _
    Private Shared Function QueryPerformanceCounter(ByRef TheCounter As Long) As Integer
    End Function

    <System.Runtime.InteropServices.DllImport("coredll.dll")> _
    Private Shared Function QueryPerformanceFrequency(ByRef TheFrequency As Long) As Integer
    End Function

    Private Shared MyFreq As Long

    '' Save frequency
    Public Shared Sub Init()
        QueryPerformanceFrequency(MyFreq)
    End Sub

    '' Get the performance counter
    Public Shared ReadOnly Property Counter() As Long
        Get
            Dim R As Long
            Timing.QueryPerformanceCounter(R)
            Return R
        End Get
    End Property

    '' (Counter / Frequency) * 1000 is milliseconds
    Public Shared ReadOnly Property MS() As Double
        Get
            Return (Counter / MyFreq) * 1000
        End Get
    End Property

End Class
