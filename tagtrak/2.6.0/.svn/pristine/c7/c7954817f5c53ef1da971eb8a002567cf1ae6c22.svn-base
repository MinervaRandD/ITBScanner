Namespace Test

    '' Thread safe log writer
    Public Class Writer
        Implements IDisposable

        '' Log files will be created in the following format (using String.Format) 
        '' "{0}" being an incrementing integer
        Const LogNameFormat As String = "Log.{0}.txt"

        Dim MyLogWriter As System.IO.StreamWriter

        Sub New()
            Dim LogFileName As String = GetUniqueName()
            MyLogWriter = New System.IO.StreamWriter(New System.IO.FileStream(LogFileName, System.IO.FileMode.Create))
        End Sub

        '' Gets the base IO.Stream for access to the underlying data
        Public Function GetStream() As System.IO.Stream
            Return MyLogWriter.BaseStream
        End Function

        '' Stars a new section
        Public Sub Clear()
            SyncLock Me
                MyLogWriter.WriteLine()
                MyLogWriter.WriteLine("-- NEW SECTION --")
                MyLogWriter.WriteLine()

            End SyncLock
        End Sub

        Public Sub WriteLine(ByVal TheOut As String)
            SyncLock Me
                MyLogWriter.WriteLine(TheOut)
                '' Flush to force a write in case of crash
                MyLogWriter.Flush()
            End SyncLock
        End Sub

        '' Writes a blank line
        Public Sub WriteLine()
            WriteLine("")
        End Sub

        '' Writes N blank lines
        Public Sub WriteLine(ByVal TheNumLines As Integer)
            For I As Integer = 1 To TheNumLines
                WriteLine()
            Next
        End Sub

        '' Read the file that's written so far into a string and return it.
        '' This could get big.
        Public Overrides Function ToString() As String
            SyncLock Me
                Dim R As String

                Dim LogFS As System.IO.Stream = MyLogWriter.BaseStream

                LogFS.Seek(0, System.IO.SeekOrigin.Begin)
                Dim MyReader As New System.IO.StreamReader(LogFS)

                R = MyReader.ReadToEnd()

                Return R
            End SyncLock
        End Function

        '' Returns the application path
        Private Function AppPath() As String
            Return System.IO.Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly.GetModules(0).FullyQualifiedName) & "\"
        End Function

        '' Gets a log file unique name based on our log file format
        Private Function GetUniqueName() As String
            Dim I As Integer = 0
            Dim Name As String = AppPath() & String.Format(LogNameFormat, I.ToString)
            Do While System.IO.File.Exists(Name)
                I += 1
                Name = AppPath() & String.Format(LogNameFormat, I.ToString)
            Loop

            Return Name
        End Function

        Public Sub Dispose() Implements System.IDisposable.Dispose
            SyncLock Me
                MyLogWriter.Close()
            End SyncLock
        End Sub

    End Class

End Namespace