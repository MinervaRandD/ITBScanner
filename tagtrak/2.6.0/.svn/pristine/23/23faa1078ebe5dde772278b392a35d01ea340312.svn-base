''' <summary>
''' Reads distribution from the config XML file.
''' </summary>
''' <remarks></remarks>
Public Class Distributions
    Implements IDisposable

    Const FormatVersion As Integer = 1

    Public Class Distribution
        Public Name As String
        Public Carriers As ArrayList

        Sub New(ByVal TheName As String)
            Name = TheName
            Carriers = New ArrayList()
        End Sub

    End Class

    Dim MyFS As IO.FileStream
    Dim MyR As Xml.XmlReader

    Sub New(ByVal TheConfigFileName As String)
        MyFS = New IO.FileStream(TheConfigFileName, IO.FileMode.Open)
        MyR = Xml.XmlReader.Create(MyFS)

        Try
            MyR.ReadToFollowing("distributions")
        Catch ex As Exception
        End Try

        If Integer.Parse(MyR.GetAttribute("formatversion")) <> FormatVersion Then
            Throw New ApplicationException("Unknown distributions file format.")
        End If

    End Sub

    Public Function GetDistribution() As Distribution
        Dim R As Distribution = Nothing

        If Not MyR.ReadToFollowing("distribution") Then Return R

        R = New Distribution(MyR.GetAttribute("name"))
        MyR.ReadStartElement("distribution")

        Do
            Try
                MyR.ReadStartElement("carrier")
            Catch ex As Exception
                Exit Do
            End Try
            R.Carriers.Add(MyR.ReadContentAsString())
            MyR.ReadEndElement()
        Loop
        MyR.ReadEndElement()

        Return R

    End Function

    Private disposedValue As Boolean = False        ' To detect redundant calls

    ' IDisposable
    Protected Overridable Sub Dispose(ByVal disposing As Boolean)
        If Not Me.disposedValue Then
            If disposing Then
                MyR.Close()
                MyFS.Close()
            End If

        End If
        Me.disposedValue = True
    End Sub

#Region " IDisposable Support "
    ' This code added by Visual Basic to correctly implement the disposable pattern.
    Public Sub Dispose() Implements IDisposable.Dispose
        ' Do not change this code.  Put cleanup code in Dispose(ByVal disposing As Boolean) above.
        Dispose(True)
        GC.SuppressFinalize(Me)
    End Sub
#End Region

End Class
