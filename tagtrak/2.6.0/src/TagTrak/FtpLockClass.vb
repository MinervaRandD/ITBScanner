Public Class ftpLockClass
    Public ftpOnGoing As Boolean = False

    Public Function getLock() As Boolean
        If ftpOnGoing Then Return False
        ftpOnGoing = True
        Return True
    End Function

End Class
