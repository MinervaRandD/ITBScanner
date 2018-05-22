Namespace Test

    '' Generic test, all tests run on a separate thread with automatic marshaling
    '' back to the UI thread for progress updates.
    Public MustInherit Class Generic

        Enum Results
            Fail
            Pass
        End Enum

        Private MyForm As Form
        Private TestThread As System.Threading.Thread

        Protected MyWriter As Writer

        '' Following are set by the event marshalers
        Private MyResult As Results
        Public ReadOnly Property Result() As Results
            Get
                SyncLock Me
                    Return MyResult
                End SyncLock
            End Get
        End Property

        Private MyDetails As String
        Public ReadOnly Property Details() As String
            Get
                SyncLock Me
                    Return MyDetails
                End SyncLock
            End Get
        End Property

        Private MyPercentComplete As Integer
        Public ReadOnly Property PercentComplete() As Integer
            Get
                SyncLock Me
                    Return MyPercentComplete
                End SyncLock
            End Get
        End Property


        Public Event ProgressUpdate(ByVal ThePercentComplete As Integer)
        Public Event Finished(ByVal TheResult As Results, ByVal TheDetails As String)

        Sub New(ByVal TheForm As Form, ByVal TheWriter As Writer)
            MyForm = TheForm
            MyWriter = TheWriter
        End Sub

        Public Sub Start()
            TestThread = New System.Threading.Thread(AddressOf StartTestThread)
            TestThread.Start()
        End Sub

        Protected MustOverride Sub StartTestThread()

#Region "Event marshalers"
        '' Thread safe event callers
        Protected Sub DoProgressUpdate(ByVal ThePercentComplete As Integer)
            '' In test thread
            SyncLock Me
                MyPercentComplete = ThePercentComplete
            End SyncLock
            MyForm.Invoke(New EventHandler(AddressOf CallProgressUpdate))
        End Sub

        Private Sub CallProgressUpdate(ByVal s As Object, ByVal e As EventArgs)
            '' In UI thread
            RaiseEvent ProgressUpdate(MyPercentComplete)
        End Sub

        '' Thread safe event callers
        Protected Sub DoFinished(ByVal TheResult As Results, ByVal TheDetails As String)
            '' In test thread
            SyncLock Me
                MyResult = TheResult
                MyDetails = TheDetails
            End SyncLock
            MyForm.Invoke(New EventHandler(AddressOf CallFinished))
        End Sub

        Private Sub CallFinished(ByVal s As Object, ByVal e As EventArgs)
            '' In UI thread
            RaiseEvent Finished(Result, Details)
        End Sub

#End Region

    End Class

End Namespace