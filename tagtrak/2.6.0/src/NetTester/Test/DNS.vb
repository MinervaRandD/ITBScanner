Namespace Test

    '' Test for name resolution of a given host
    Public Class DNS
        Inherits Generic

        Private MyHost As String

        Sub New(ByVal TheForm As Form, ByVal TheWriter As Writer, ByVal TheHost As String)
            MyBase.New(TheForm, TheWriter)
            MyHost = TheHost
        End Sub

        Protected Overrides Sub StartTestThread()
            MyWriter.WriteLine("Resolving: " & MyHost)

            Dim IPHostEnt As System.Net.IPHostEntry

            IPHostEnt = ConnectAndResolve(MyHost)
            If IPHostEnt Is Nothing Then
                Return
            End If

            If IPHostEnt.AddressList.Length > 0 Then
                '' More than zero address resolved
                MyWriter.WriteLine("Resolved IP Count: " & IPHostEnt.AddressList.Length.ToString)
                For I As Integer = 0 To IPHostEnt.AddressList.Length - 1
                    MyWriter.WriteLine("Resolved IP " & CStr(I + 1) & ": " & IPHostEnt.AddressList(I).ToString)
                Next
                DoProgressUpdate(100)
                DoFinished(Generic.Results.Pass, "DNS resolution succeeded with " & IPHostEnt.AddressList.Length.ToString & " IP addresses returned.")
                Return
            Else
                '' Zero addresses resolved
                MyWriter.WriteLine("IP Count: 0")
                DoProgressUpdate(100)
                DoFinished(Generic.Results.Fail, "DNS resolution succeeded but 0 IP addresses returned.")
                Return
            End If

        End Sub

        Private Function ConnectAndResolve(ByVal TheHost As String) As System.Net.IPHostEntry
            Dim IPHostEnt As System.Net.IPHostEntry
            Try
                IPHostEnt = System.Net.Dns.Resolve(TheHost)
            Catch ex As Exception
                MyWriter.WriteLine("Resolution: Failed (will attempt connection)")
            End Try

            If IPHostEnt Is Nothing Then
                '' If resolution failed, try connecting to default connection
                Dim cm As New OpenNETCF.Net.ConnectionManager
                Try
                    cm.Connect(OpenNETCF.Net.ConnectionMode.Synchronous)
                Catch ex As Exception
                    MyWriter.WriteLine("Connection: Failed")
                    DoProgressUpdate(100)
                    DoFinished(Generic.Results.Fail, "DNS resolution failed, connection attempted and failed.")
                    Return Nothing
                End Try

                MyWriter.WriteLine("Connection: Succeeded")

                Try
                    IPHostEnt = System.Net.Dns.Resolve(TheHost)
                Catch ex As Exception
                    MyWriter.WriteLine("Resolution: Failed")
                    DoProgressUpdate(100)
                    DoFinished(Generic.Results.Fail, "DNS resolution failed after connection established.")
                    Return Nothing
                End Try

                MyWriter.WriteLine("Resolution: Succeeded")
                Return IPHostEnt

            Else
                MyWriter.WriteLine("Resolution: Succeeded")
                Return IPHostEnt

            End If

        End Function

    End Class
End Namespace
