Namespace PanelHelpers
    Public Class Finish
        Inherits General

        '' Exits app
        Private WithEvents ButtonFinish As Button
        '' Lists out tests
        Private WithEvents ComboBoxTests As ComboBox
        '' Test description
        Private LabelDescription As Label
        '' PASS/FAIL status
        Private LabelPassFail As Label


        Sub New(ByVal TheForm As FormMain)
            MyBase.New(TheForm)
        End Sub

        Public Overrides Sub Load()
            With MyForm
                ButtonFinish = .ButtonFinish
                LabelDescription = .LabelFinishDescription
                LabelPassFail = .LabelFinishPassFail
                ComboBoxTests = .ComboBoxFinishTests
            End With

            ComboBoxTests.Items.Clear()
            ComboBoxTests.Items.Add("Network Settings")
            ComboBoxTests.Items.Add("DNS")
            ComboBoxTests.Items.Add("PING 100")
            ComboBoxTests.Items.Add("PING 500")
            ComboBoxTests.Items.Add("PING 1000")
            ComboBoxTests.Items.Add("PING 1500")
            ComboBoxTests.Items.Add("PING 2000")
            ComboBoxTests.Items.Add("Traceroute")
            ComboBoxTests.Items.Add("NTP")
            ComboBoxTests.Items.Add("FTP")

            LabelDescription.Text = ""

            '' Select first item for display
            ComboBoxTests.SelectedIndex = 0
            ComboBoxTests.Focus()

        End Sub

        '' Display the test result and details for each test selected
        Private Sub ComboBoxTests_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles ComboBoxTests.SelectedIndexChanged
            Select Case ComboBoxTests.SelectedItem.ToString() 'AP-082109
                Case "Network Settings"
                    LabelDescription.Text = MyForm.MyTester.NetworkSettingsTest.Details
                    If MyForm.MyTester.NetworkSettingsTest.Result = Test.Generic.Results.Pass Then
                        LabelPassFail.ForeColor = Color.Green
                        LabelPassFail.Text = "PASSED"
                    Else
                        LabelPassFail.ForeColor = Color.Red
                        LabelPassFail.Text = "FAILED"
                    End If

                Case "DNS"
                    LabelDescription.Text = MyForm.MyTester.DNSTest.Details
                    If MyForm.MyTester.DNSTest.Result = Test.Generic.Results.Pass Then
                        LabelPassFail.ForeColor = Color.Green
                        LabelPassFail.Text = "PASSED"
                    Else
                        LabelPassFail.ForeColor = Color.Red
                        LabelPassFail.Text = "FAILED"
                    End If

                Case "PING 100"
                    LabelDescription.Text = MyForm.MyTester.PingTest100.Details
                    If MyForm.MyTester.PingTest100.Result = Test.Generic.Results.Pass Then
                        LabelPassFail.ForeColor = Color.Green
                        LabelPassFail.Text = "PASSED"
                    Else
                        LabelPassFail.ForeColor = Color.Red
                        LabelPassFail.Text = "FAILED"
                    End If

                Case "PING 500"
                    LabelDescription.Text = MyForm.MyTester.PingTest500.Details
                    If MyForm.MyTester.PingTest500.Result = Test.Generic.Results.Pass Then
                        LabelPassFail.ForeColor = Color.Green
                        LabelPassFail.Text = "PASSED"
                    Else
                        LabelPassFail.ForeColor = Color.Red
                        LabelPassFail.Text = "FAILED"
                    End If

                Case "PING 1000"
                    LabelDescription.Text = MyForm.MyTester.PingTest1000.Details
                    If MyForm.MyTester.PingTest1000.Result = Test.Generic.Results.Pass Then
                        LabelPassFail.ForeColor = Color.Green
                        LabelPassFail.Text = "PASSED"
                    Else
                        LabelPassFail.ForeColor = Color.Red
                        LabelPassFail.Text = "FAILED"
                    End If

                Case "PING 1500"
                    LabelDescription.Text = MyForm.MyTester.PingTest1500.Details
                    If MyForm.MyTester.PingTest1500.Result = Test.Generic.Results.Pass Then
                        LabelPassFail.ForeColor = Color.Green
                        LabelPassFail.Text = "PASSED"
                    Else
                        LabelPassFail.ForeColor = Color.Red
                        LabelPassFail.Text = "FAILED"
                    End If

                Case "PING 2000"
                    LabelDescription.Text = MyForm.MyTester.PingTest2000.Details
                    If MyForm.MyTester.PingTest100.Result = Test.Generic.Results.Pass Then
                        LabelPassFail.ForeColor = Color.Green
                        LabelPassFail.Text = "PASSED"
                    Else
                        LabelPassFail.ForeColor = Color.Red
                        LabelPassFail.Text = "FAILED"
                    End If

                Case "Traceroute"
                    LabelDescription.Text = MyForm.MyTester.TraceRouteTest.Details
                    If MyForm.MyTester.TraceRouteTest.Result = Test.Generic.Results.Pass Then
                        LabelPassFail.ForeColor = Color.Green
                        LabelPassFail.Text = "PASSED"
                    Else
                        LabelPassFail.ForeColor = Color.Red
                        LabelPassFail.Text = "FAILED"
                    End If


                Case "NTP"
                    LabelDescription.Text = MyForm.MyTester.NTPTest.Details
                    If MyForm.MyTester.NTPTest.Result = Test.Generic.Results.Pass Then
                        LabelPassFail.ForeColor = Color.Green
                        LabelPassFail.Text = "PASSED"
                    Else
                        LabelPassFail.ForeColor = Color.Red
                        LabelPassFail.Text = "FAILED"
                    End If


                Case "FTP"
                    LabelDescription.Text = MyForm.MyTester.FTPTest.Details
                    If MyForm.MyTester.FTPTest.Result = Test.Generic.Results.Pass Then
                        LabelPassFail.ForeColor = Color.Green
                        LabelPassFail.Text = "PASSED"
                    Else
                        LabelPassFail.ForeColor = Color.Red
                        LabelPassFail.Text = "FAILED"
                    End If

            End Select
        End Sub

        '' Exit app
        Private Sub ButtonFinish_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles ButtonFinish.Click
            MyForm.Close()
        End Sub

    End Class

End Namespace
