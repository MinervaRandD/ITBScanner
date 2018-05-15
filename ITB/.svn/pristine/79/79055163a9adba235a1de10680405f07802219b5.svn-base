Imports OpenNETCF.Net

Namespace Test
    '' Test scanner network settings (including registry network settings)
    Public Class NetworkSettings
        Inherits Generic

        '' Write these registry keys to log file if present
        '' These are all known registry keys containing important network settings
        Dim HKLMTestKeys() As String = {"Comm\Tcpip\Parms", "Comm\LAN90001\Parms\TcpIp", "Comm\USB Cable:\Parms\TcpIp", "Comm\ppp1\Parms\TcpIp", "Comm\PRISMNDS1\Parms\TcpIp", "Comm\SWLD26C1\Parms\TcpIp", "Comm\WLAGS46f1\Parms\TcpIp"}

        Sub New(ByVal TheForm As Form, ByVal TheWriter As Writer)
            MyBase.New(TheForm, TheWriter)
        End Sub

        '' Runs on a separate thread
        Protected Overrides Sub StartTestThread()
            Dim DetailsBuilder As New System.Text.StringBuilder 'AP-082109

            Dim TestCount As Integer
            Dim TestIdx As Integer

            '' Start with a Fail and test adapters, if one passes it's considered a total pass.
            Dim TestTotalResult As Results = Generic.Results.Fail
            Dim TestResult As Results

            Dim ac As AdapterCollection = Networking.GetAdapters
            Dim a As Adapter

            '' Set the number of tests to run
            TestCount = ac.Count + 3

            For Each a In ac
                TestResult = TestAdapter(a, DetailsBuilder)
                '' If one passes, they all pass
                If TestResult > TestTotalResult Then TestTotalResult = TestResult

                MyWriter.WriteLine()
                MyWriter.WriteLine("   ---   ")
                MyWriter.WriteLine()

                '' Update progress bar
                TestIdx += 1
                DoProgressUpdate(CInt((TestIdx / TestCount) * 100))
            Next
            MyWriter.WriteLine()

            Dim ConMan As New OpenNETCF.Net.ConnectionManager
            MyWriter.WriteLine("Connection Info")
            MyWriter.WriteLine("---------------")
            TestResult = TestConnection(ConMan, DetailsBuilder)
            '' If one Fails, total fails
            If TestResult < TestTotalResult Then TestTotalResult = TestResult
            MyWriter.WriteLine()

            '' Update progress bar
            TestIdx += 1
            DoProgressUpdate(CInt((TestIdx / TestCount) * 100))

            MyWriter.WriteLine("Connections")
            MyWriter.WriteLine("-----------")
            TestResult = TestConnections(ConMan, DetailsBuilder)
            '' If one Fails, total fails
            If TestResult < TestTotalResult Then TestTotalResult = TestResult
            MyWriter.WriteLine()

            '' Update progress bar
            TestIdx += 1
            DoProgressUpdate(CInt((TestIdx / TestCount) * 100))

            MyWriter.WriteLine("Network Registry")
            MyWriter.WriteLine("----------------")
            TestResult = TestRegistry(DetailsBuilder)
            '' If one Fails, total fails
            If TestResult < TestTotalResult Then TestTotalResult = TestResult
            MyWriter.WriteLine()

            '' Update progress bar
            TestIdx += 1
            DoProgressUpdate(CInt((TestIdx / TestCount) * 100))

            DoFinished(TestTotalResult, DetailsBuilder.ToString)

        End Sub

        Private Function TestAdapter(ByVal TheAdapter As Adapter, ByVal TheDetailsBuilder As System.Text.StringBuilder) As Results 'AP-082109
            With TheAdapter
                '' Write log file
                MyWriter.WriteLine("Adapter(" & .Index.ToString & "): " & .Name)
                MyWriter.WriteLine("Type: " & .Type.ToString)
                MyWriter.WriteLine("IP: " & .CurrentIpAddress)
                MyWriter.WriteLine("Subnet: " & .CurrentSubnetMask)
                MyWriter.WriteLine("Gateway: " & .Gateway)
                MyWriter.WriteLine("DHCP Enabled: " & .DhcpEnabled.ToString)
                MyWriter.WriteLine("DHCP Server: " & .DhcpServer)
                MyWriter.WriteLine("*Description: " & .Description)
                MyWriter.WriteLine("*HasWins: " & .HasWins.ToString)
                MyWriter.WriteLine("*LeaseExpires: " & .LeaseExpires.ToString)
                MyWriter.WriteLine("*LeaseObtained: " & .LeaseObtained.ToString)
                MyWriter.WriteLine("*MacAddress: " & MACToString(.MacAddress))
                MyWriter.WriteLine("*PrimaryWinsServer: " & .PrimaryWinsServer)
                MyWriter.WriteLine("*SecondaryWinsServer: " & .SecondaryWinsServer)

                Try
                    MyWriter.WriteLine("Wireless: " & .IsWireless.ToString)
                    If .IsWireless Then
                        MyWriter.WriteLine("*AssociatedAccessPoint: " & .AssociatedAccessPoint)
                        MyWriter.WriteLine("*IsWirelessZeroConfigCompatible: " & .IsWirelessZeroConfigCompatible.ToString)
                        MyWriter.WriteLine("*NearbyAccessPoints: " & .NearbyAccessPoints.Count.ToString)
                        MyWriter.WriteLine("*NearbyPreferredAccessPoints: " & .NearbyPreferredAccessPoints.ToString)
                        MyWriter.WriteLine("*PreferredAccessPoints: " & .PreferredAccessPoints.Count)
                        MyWriter.WriteLine("*SignalStrengthInDecibels: " & .SignalStrengthInDecibels.ToString)
                        MyWriter.WriteLine("*WZCFallbackEnabled: " & .WZCFallbackEnabled.ToString)
                    End If
                Catch ex As Exception
                    MyWriter.WriteLine("Wireless Error: True")
                End Try

                '' PING Gateway if it's valid
                If IsIPValid(.Gateway) Then
                    MyWriter.WriteLine("Pinging Gateway: " & .Gateway)
                    Dim P As New ToolBox.Ping
                    Dim PR As ToolBox.Ping.PingResponse
                    Try
                        '' Try to ping gateway, no reverse DNS lookup
                        PR = P.SendPing(System.Net.IPAddress.Parse(.Gateway), , , False)
                    Catch ex As Exception
                        MyWriter.WriteLine("Ping Exception: " & ex.ToString)
                        PR = New ToolBox.Ping.PingResponse(False)
                    End Try

                    '' Save ping output to log file
                    '' We don't grade this because even if you're unable to ping your gateway your 
                    '' network settings might still be correct.
                    MyWriter.WriteLine("Ping Success: " & PR.IsSuccess.ToString)
                    If PR.IsSuccess Then
                        MyWriter.WriteLine("Ping RTT (ms): " & PR.RTT.ToString)
                        MyWriter.WriteLine("Ping Response Address: " & PR.IPAddress.ToString)
                    End If

                End If

                '' Grade test
                If IsIPValid(.CurrentIpAddress) And IsIPValid(.CurrentSubnetMask) And IsIPValid(.Gateway) Then
                    TheDetailsBuilder.Append("For adapter " & .Name & " the IP, subnet, and gateway appear to be valid." & vbCrLf)
                    Return Generic.Results.Pass
                Else
                    TheDetailsBuilder.Append("For adapter " & .Name & " either the IP, subnet, or gateway appear to be invalid." & vbCrLf)
                    Return Generic.Results.Fail
                End If

            End With

        End Function

        '' Returns whether an IP is valid
        Private Function IsIPValid(ByVal TheIp As String) As Boolean
            Try
                'If System.Net.IPAddress.Parse(TheIp).Address <> 0 Then Return True 'AP-082109 obsolete
                Dim IP As System.Net.IPAddress = System.Net.IPAddress.Parse(TheIp)
                Dim IPbytes As Byte() = IP.GetAddressBytes()
                Dim totbytes As Long = 0

                For Each b As Byte In IPbytes
                    totbytes += b
                Next

                If totbytes <> 0 Then Return True

            Catch ex As Exception
                Return False
            End Try
            Return False
        End Function

        Private Function TestConnection(ByVal TheConnectionMan As ConnectionManager, ByVal TheDetailsBuilder As System.Text.StringBuilder) As Results 'AP-082109
            '' Write log file
            With TheConnectionMan
                Try
                    MyWriter.WriteLine("Connection Status: " & .Status.ToString)
                    MyWriter.WriteLine("Timeout: " & .Timeout.ToString)
                Catch ex As Exception
                End Try
            End With

            '' Grade test
            '' Nothing to fail here
            Return Generic.Results.Pass

        End Function

        Private Function TestConnections(ByVal TheConnectionMan As ConnectionManager, ByVal TheDetailsBuilder As System.Text.StringBuilder) As Results 'AP-082109
            '' Test RAS connections
            Dim RAS As New ToolBox.RAS
            Dim RASNames() As ToolBox.RAS.RASENTRYNAME = RAS.GetRASENTRYNAMES
            Dim RASEntry As ToolBox.RAS.RASENTRY

            '' Write default connection
            RASEntry = RAS.GetRASENTRY("")
            MyWriter.WriteLine("Connection name: [Default]")
            MyWriter.WriteLine(RASEntry.ToString)

            For I As Integer = 0 To RASNames.Length - 1
                RASEntry = RAS.GetRASENTRY(RASNames(I).szEntryName)
                MyWriter.WriteLine("Connection name: " & RASNames(I).szEntryName)
                MyWriter.WriteLine(RASEntry.ToString)
            Next

            '' Grade test
            '' Nothing to fail here
            Return Generic.Results.Pass

        End Function

        Private Function TestRegistry(ByVal TheDetailsBuilder As System.Text.StringBuilder) As Results 'AP-082109
            '' Write log file
            Dim RegTool As ToolBox.Registry
            Dim RegKey As Win32.RegistryKey
            Dim HKLMTestKey As String
            For Each HKLMTestKey In HKLMTestKeys
                RegKey = Win32.Registry.LocalMachine.OpenSubKey(HKLMTestKey)
                If RegKey Is Nothing = False Then
                    RegTool = New ToolBox.Registry(RegKey)
                    MyWriter.WriteLine(RegTool.ToString())
                    RegKey.Close()
                Else
                    MyWriter.WriteLine("HKLM\" & HKLMTestKey & ": Not Found")
                    MyWriter.WriteLine()
                End If
            Next

            '' Grade test
            '' Nothing to fail here
            Return Generic.Results.Pass

        End Function

        Private Function MACToString(ByVal TheMACBytes() As Byte) As String
            Dim R As New System.Text.StringBuilder 'AP-082109
            For I As Integer = 0 To TheMACBytes.Length - 2
                R.Append(String.Format("{0:X2}", TheMACBytes(I)))
                R.Append("-"c)
            Next
            R.Append(String.Format("{0:X2}", TheMACBytes(TheMACBytes.Length - 1)))

            Return R.ToString

        End Function

    End Class

End Namespace
