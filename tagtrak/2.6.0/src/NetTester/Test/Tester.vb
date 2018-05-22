Namespace Test
    Public Class Tester

        Public Const TestCount As Integer = 6
        Public TestsDone As Integer
        Public TestsPassed As Integer

        Public WithEvents NetworkSettingsTest As NetworkSettings
        Public WithEvents DNSTest As DNS
        Public WithEvents PingTest As Ping
        Public WithEvents TraceRouteTest As TraceRoute
        Public WithEvents FTPTest As FTP
        Public WithEvents NTPTest As NTP

        Private MyWriter As Writer
        Private MyForm As Form
        '' For test timing
        Private T1 As Double

        Public Event Finished()
        Public Event ProgressUpdate(ByVal TheProgress As Integer, ByVal TheStatus As String)

        '' Gets the total score (0 to 100)
        Public ReadOnly Property Score() As Integer
            Get
                Return CInt((TestsPassed / TestCount) * 100)
            End Get
        End Property

        Sub New(ByVal TheForm As Form, ByVal TheWriter As Writer)
            Timing.Init()
            MyForm = TheForm
            MyWriter = TheWriter

            '' Instantiate all our tests
            NetworkSettingsTest = New NetworkSettings(TheForm, TheWriter)
            DNSTest = New DNS(TheForm, TheWriter, "ftp.asiscan.com")
            PingTest = New Ping(TheForm, TheWriter, "ftp.asiscan.com")
            TraceRouteTest = New TraceRoute(TheForm, TheWriter, "ftp.asiscan.com")
            FTPTest = New FTP(TheForm, TheWriter, "ftp.asiscan.com")
            NTPTest = New NTP(TheForm, TheWriter, "pool.ntp.org")

        End Sub

        Public Sub Start()
            MyWriter.WriteLine(System.Reflection.Assembly.GetExecutingAssembly.GetName.Name.ToString)
            MyWriter.WriteLine("Version: " & System.Reflection.Assembly.GetExecutingAssembly.GetName.Version.ToString)
            MyWriter.WriteLine("Local Time: " & Now.ToString)
            MyWriter.WriteLine("UTC Time: " & Now.ToUniversalTime.ToString)
            MyWriter.WriteLine("Scanner Serial: " & Util.SerialNumber.ToString)
            MyWriter.WriteLine(2)

            '' Initialize high resolution timer
            '' Used for reporting overall test length
            Timing.Init()

            '' Start DNS test (and the chain of testing)
            RaiseEvent ProgressUpdate(CInt((TestsDone / TestCount) * 100), "Connecting and Testing DNS")

            MyWriter.WriteLine("DNS test started")
            MyWriter.WriteLine("----------------")
            T1 = Timing.MS
            DNSTest.Start()
        End Sub

        '' Test chain handlers:

        '' DNS test finished
        Private Sub DNSTest_Finished(ByVal TheResult As Generic.Results, ByVal TheDetails As String) Handles DNSTest.Finished
            If TheResult = Generic.Results.Pass Then
                TestsPassed += 1
            End If

            '' DNS test finished
            MyWriter.WriteLine("DNS test length (ms): " & Convert.ToString(Timing.MS - T1))
            MyWriter.WriteLine(2)

            TestsDone += 1
            RaiseEvent ProgressUpdate(CInt((TestsDone / TestCount) * 100), "Testing Network Settings")

            '' Network Settings Test
            MyWriter.WriteLine("Network settings test started")
            MyWriter.WriteLine("-----------------------------")
            T1 = Timing.MS
            NetworkSettingsTest.Start()
        End Sub

        '' Network settings test finished
        Private Sub NetworkSettings_Finished(ByVal TheResult As Generic.Results, ByVal TheDetail As String) Handles NetworkSettingsTest.Finished
            If TheResult = Generic.Results.Pass Then
                TestsPassed += 1
            End If

            '' Network settings test finished
            MyWriter.WriteLine("Network settings test length (ms): " & Convert.ToString(Timing.MS - T1))
            MyWriter.WriteLine(2)

            TestsDone += 1
            RaiseEvent ProgressUpdate(CInt((TestsDone / TestCount) * 100), "Testing PING")

            '' Start PING test
            MyWriter.WriteLine("PING test started")
            MyWriter.WriteLine("-----------------")
            T1 = Timing.MS
            PingTest.Start()
        End Sub

        Private Sub Ping_Finished(ByVal TheResult As Generic.Results, ByVal TheDetail As String) Handles PingTest.Finished
            If TheResult = Generic.Results.Pass Then
                TestsPassed += 1
            End If

            '' PING Finished
            PingTest.Dispose()
            MyWriter.WriteLine("PING test length (ms): " & Convert.ToString(Timing.MS - T1))
            MyWriter.WriteLine(2)

            TestsDone += 1
            RaiseEvent ProgressUpdate(CInt((TestsDone / TestCount) * 100), "Testing Traceroute")

            '' Start traceroute
            MyWriter.WriteLine("Traceroute test started")
            MyWriter.WriteLine("-----------------------")
            T1 = Timing.MS
            TraceRouteTest.Start()
        End Sub

        Private Sub TraceRoute_Finished(ByVal TheResult As Generic.Results, ByVal TheDetail As String) Handles TraceRouteTest.Finished
            If TheResult = Generic.Results.Pass Then
                TestsPassed += 1
            End If

            '' Traceroute finished
            TraceRouteTest.Dispose()
            MyWriter.WriteLine("Traceroute test length (ms): " & Convert.ToString(Timing.MS - T1))
            MyWriter.WriteLine(2)

            TestsDone += 1
            RaiseEvent ProgressUpdate(CInt((TestsDone / TestCount) * 100), "Testing FTP")

            '' Start FTP test
            MyWriter.WriteLine("FTP test started")
            MyWriter.WriteLine("----------------")
            T1 = Timing.MS
            FTPTest.Start()
        End Sub

        Private Sub FTP_Finished(ByVal TheResult As Generic.Results, ByVal TheDetail As String) Handles FTPTest.Finished
            If TheResult = Generic.Results.Pass Then
                TestsPassed += 1
            End If

            '' FTP finished
            MyWriter.WriteLine("FTP test length (ms): " & Convert.ToString(Timing.MS - T1))
            MyWriter.WriteLine(2)

            TestsDone += 1
            RaiseEvent ProgressUpdate(CInt((TestsDone / TestCount) * 100), "Testing NTP")

            '' Start FTP test
            MyWriter.WriteLine("NTP test started")
            MyWriter.WriteLine("----------------")
            T1 = Timing.MS
            NTPTest.Start()
        End Sub

        Private Sub NTP_Finished(ByVal TheResult As Generic.Results, ByVal TheDetail As String) Handles NTPTest.Finished
            If TheResult = Generic.Results.Pass Then
                TestsPassed += 1
            End If

            '' NTP finished
            MyWriter.WriteLine("NTP test length (ms): " & Convert.ToString(Timing.MS - T1))
            MyWriter.WriteLine(2)

            TestsDone += 1
            WriteOverall()
            RaiseEvent ProgressUpdate(CInt((TestsDone / TestCount) * 100), "Testing Complete")
            RaiseEvent Finished()

        End Sub

        '' Write overall test results
        Private Sub WriteOverall()
            With MyWriter
                .WriteLine("Overall Results")
                .WriteLine("---------------")
                .WriteLine("DNS: " & DNSTest.Result.ToString)
                .WriteLine("Network Settings: " & NetworkSettingsTest.Result.ToString)
                .WriteLine("PING: " & PingTest.Result.ToString)
                .WriteLine("Traceroute: " & TraceRouteTest.Result.ToString)
                .WriteLine("FTP: " & FTPTest.Result.ToString)
                .WriteLine("NTP: " & NTPTest.Result.ToString)
                .WriteLine()
                .WriteLine("Score: " & Me.Score.ToString & "%")
                .WriteLine("Passed: " & Me.TestsPassed.ToString & " / " & Me.TestsDone.ToString)
            End With
        End Sub

        '' In test progress updates (marshaled out of testing thread)
        Private Sub DNSTest_ProgressUpdate(ByVal ThePercentComplete As Integer) Handles DNSTest.ProgressUpdate
            RaiseEvent ProgressUpdate(CInt((TestsDone / TestCount) * 100), "Testing DNS (" & ThePercentComplete.ToString & "%)")
        End Sub

        Private Sub NetworkSettingsTest_ProgressUpdate(ByVal ThePercentComplete As Integer) Handles NetworkSettingsTest.ProgressUpdate
            RaiseEvent ProgressUpdate(CInt((TestsDone / TestCount) * 100), "Testing Network Settings (" & ThePercentComplete.ToString & "%)")
        End Sub

        Private Sub PingTest_ProgressUpdate(ByVal ThePercentComplete As Integer) Handles PingTest.ProgressUpdate
            RaiseEvent ProgressUpdate(CInt((TestsDone / TestCount) * 100), "Testing PING (" & ThePercentComplete.ToString & "%)")
        End Sub

        Private Sub TraceRouteTest_ProgressUpdate(ByVal ThePercentComplete As Integer) Handles TraceRouteTest.ProgressUpdate
            RaiseEvent ProgressUpdate(CInt((TestsDone / TestCount) * 100), "Testing Traceroute (" & ThePercentComplete.ToString & "%)")
        End Sub

        Private Sub FTPTest_ProgressUpdate(ByVal ThePercentComplete As Integer) Handles FTPTest.ProgressUpdate
            RaiseEvent ProgressUpdate(CInt((TestsDone / TestCount) * 100), "Testing FTP (" & ThePercentComplete.ToString & "%)")
        End Sub

        Private Sub NTPTest_ProgressUpdate(ByVal ThePercentComplete As Integer) Handles NTPTest.ProgressUpdate
            RaiseEvent ProgressUpdate(CInt((TestsDone / TestCount) * 100), "Testing NTP (" & ThePercentComplete.ToString & "%)")
        End Sub

    End Class

End Namespace
