''' <summary>
''' Responsible for building the various CAB files.
''' </summary>
''' <remarks>Generates CAB files for all supported devices</remarks>
Public Class CABBuilder
    Implements IDisposable



    ''' <summary>
    ''' Builds Dependent cab files.
    ''' </summary>
    ''' <remarks></remarks>
    Public Sub BuildDependentCABs(ByVal TheCarrier As String, ByVal TheBINFile As IO.FileInfo, ByVal TheCABDir As IO.DirectoryInfo)
        Console.WriteLine("Building dependent files for carrier " & TheCarrier & ".")

        Dim Procs() As InfWriter.Processors = [Enum].GetValues(GetType(InfWriter.Processors))
        Dim Proc As InfWriter.Processors

        Dim Devs() As InfWriter.Devices = [Enum].GetValues(GetType(InfWriter.Devices))
        Dim Dev As InfWriter.Devices

        Dim CurCABDir As IO.DirectoryInfo
        Dim CurInputDir As IO.DirectoryInfo

        '' Build Dependent cab files for every processor on every device, for this carrier
        For Each Proc In Procs
            For Each Dev In Devs
                '' Create Directory
                If Not IO.Directory.Exists(TheCABDir.FullName & "\" & Dev.ToString & "\" & Proc.ToString) Then
                    IO.Directory.CreateDirectory(TheCABDir.FullName & "\" & Dev.ToString & "\" & Proc.ToString)
                End If
                CurCABDir = New IO.DirectoryInfo(TheCABDir.FullName & "\" & Dev.ToString & "\" & Proc.ToString)
                CurInputDir = New IO.DirectoryInfo(InDir.FullName & "\" & Dev.ToString & "\" & Proc.ToString & "\" & InfWriter.OSes.PPC2002.ToString)
                BuildDependent(TheCarrier, Proc, Dev, CurCABDir, CurInputDir, TheBINFile)
            Next
        Next

    End Sub

    ''' <summary>
    ''' Builds Main cab files.
    ''' </summary>
    Public Sub BuildMainCABs()
        Dim Procs() As InfWriter.Processors = [Enum].GetValues(GetType(InfWriter.Processors))
        Dim Proc As InfWriter.Processors

        Dim Devs() As InfWriter.Devices = [Enum].GetValues(GetType(InfWriter.Devices))
        Dim Dev As InfWriter.Devices

        Dim CurCABDir As IO.DirectoryInfo
        Dim CurInputDir As IO.DirectoryInfo

        '' Build Main cab files for every processor on every device
        Dim DirPath As String
        For Each Proc In Procs
            For Each Dev In Devs
                Console.WriteLine("Building main files for " & Proc.ToString & " to run on " & Dev.ToString & ".")

                '' Create Directory
                DirPath = CABDir.FullName & "\" & "TagTrak" & "\" & Dev.ToString & "\" & Proc.ToString
                If Not IO.Directory.Exists(DirPath) Then
                    IO.Directory.CreateDirectory(DirPath)
                End If
                CurCABDir = New IO.DirectoryInfo(DirPath)
                CurInputDir = New IO.DirectoryInfo(InDir.FullName & "\" & Dev.ToString & "\" & Proc.ToString & "\" & InfWriter.OSes.PPC2002.ToString)
                BuildMain(Proc, Dev, CurCABDir, CurInputDir)
            Next
        Next

    End Sub

    ''' <summary>
    ''' Builds Distribution cab files.
    ''' </summary>
    Public Sub BuildDistributionCABs()
        Dim Procs() As InfWriter.Processors = [Enum].GetValues(GetType(InfWriter.Processors))
        Dim Proc As InfWriter.Processors

        Dim Devs() As InfWriter.Devices = [Enum].GetValues(GetType(InfWriter.Devices))
        Dim Dev As InfWriter.Devices

        Dim OSes() As InfWriter.Devices = [Enum].GetValues(GetType(InfWriter.OSes))
        Dim OS As InfWriter.OSes

        Dim DirPath As String

        Dim CurCABDir As IO.DirectoryInfo
        Dim CurInputDir As IO.DirectoryInfo

        Dim Carrier As String

        '' Build Distribution cab files for every processor on every OS on every device, for every distribution
        Dim Distros As New Distributions(DistoConfigDir.FullName & DistroConfigFileName)
        Dim Distro As Distributions.Distribution

        Dim NetTestCABDir As IO.FileInfo
        Dim MainCABDir As IO.FileInfo
        Dim DependentCABDirs As New ArrayList
        Distro = Distros.GetDistribution()
        If Distro Is Nothing = False Then
            Do
                Console.WriteLine("Building distribution named " & Distro.Name & ".")
                For Each Proc In Procs
                    For Each Dev In Devs
                        For Each OS In OSes
                            '' Create Directory (Non-Wireless)
                            DirPath = CABDir.FullName & "\" & "Distributions" & "\" & Distro.Name & "\" & Dev.ToString & "\" & Proc.ToString & "\" & OS.ToString & "\NonWireless"
                            If Not IO.Directory.Exists(DirPath) Then
                                IO.Directory.CreateDirectory(DirPath)
                            End If
                            CurCABDir = New IO.DirectoryInfo(DirPath)
                            CurInputDir = New IO.DirectoryInfo(InDir.FullName & "\" & Dev.ToString & "\" & Proc.ToString & "\" & OS.ToString)

                            '' Construct main CAB dir and dependent dirs.
                            MainCABDir = New IO.FileInfo(CABDir.FullName & "\TagTrak\" & Dev.ToString & "\" & Proc.ToString & "\TagTrak.cab")
                            DependentCABDirs.Clear()
                            For Each Carrier In Distro.Carriers
                                DependentCABDirs.Add(New IO.FileInfo(CABDir.FullName & "\" & Carrier & "\" & Dev.ToString & "\" & Proc.ToString & "\DependentFiles." & Carrier & ".cab"))
                            Next

                            '' Construct NetTest CAB dir 
                            NetTestCABDir = New IO.FileInfo(CABDir.FullName & "\NetTest\" & Dev.ToString & "\" & Proc.ToString & "\NetTest.cab")

                            BuildDistro(Proc, Dev, OS, False, NetTestCABDir, MainCABDir, DependentCABDirs.ToArray(GetType(IO.FileInfo)), CurCABDir, CurInputDir, Distro.Name)

                            If OS > InfWriter.OSes.PPC2002 Then
                                '' Create Directory (Wireless)
                                DirPath = CABDir.FullName & "\" & "Distributions" & "\" & Distro.Name & "\" & Dev.ToString & "\" & Proc.ToString & "\" & OS.ToString & "\Wireless"
                                If Not IO.Directory.Exists(DirPath) Then
                                    IO.Directory.CreateDirectory(DirPath)
                                End If
                                CurCABDir = New IO.DirectoryInfo(DirPath)
                                CurInputDir = New IO.DirectoryInfo(InDir.FullName & "\" & Dev.ToString & "\" & Proc.ToString & "\" & OS.ToString)

                                BuildDistro(Proc, Dev, OS, True, NetTestCABDir, MainCABDir, DependentCABDirs.ToArray(GetType(IO.FileInfo)), CurCABDir, CurInputDir, Distro.Name)
                            End If
                        Next
                    Next
                Next
                Distro = Distros.GetDistribution()
            Loop Until Distro Is Nothing

            Distros.Dispose()
        End If

    End Sub

    ''' <summary>
    ''' Builds the NetTest CABs
    ''' </summary>
    ''' <remarks></remarks>
    Public Sub BuildNetTestCABs()
        Dim Procs() As InfWriter.Processors = [Enum].GetValues(GetType(InfWriter.Processors))
        Dim Proc As InfWriter.Processors

        Dim Devs() As InfWriter.Devices = [Enum].GetValues(GetType(InfWriter.Devices))
        Dim Dev As InfWriter.Devices

        Dim CurCABDir As IO.DirectoryInfo
        Dim CurInputDir As IO.DirectoryInfo

        '' Build Main cab files for every processor on every device
        Dim DirPath As String
        For Each Proc In Procs
            For Each Dev In Devs
                Console.WriteLine("Building NetTest files for " & Proc.ToString & " to run on " & Dev.ToString & ".")

                '' Create Directory
                DirPath = CABDir.FullName & "\" & "NetTest" & "\" & Dev.ToString & "\" & Proc.ToString
                If Not IO.Directory.Exists(DirPath) Then
                    IO.Directory.CreateDirectory(DirPath)
                End If
                CurCABDir = New IO.DirectoryInfo(DirPath)
                CurInputDir = New IO.DirectoryInfo(InDir.FullName & "\" & Dev.ToString & "\" & Proc.ToString & "\" & InfWriter.OSes.PPC2002.ToString)
                BuildNetTest(Proc, Dev, CurCABDir, CurInputDir)
            Next
        Next
    End Sub

    ''' <summary>
    ''' Builds the dependent CAB file.
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub BuildDependent(ByVal TheCarrier As String, ByVal TheProcessor As InfWriter.Processors, ByVal TheDevice As InfWriter.Devices, ByVal TheCABDir As IO.DirectoryInfo, ByVal TheInputDir As IO.DirectoryInfo, ByVal TheBINFile As IO.FileInfo)
        '' Write INF file
        Dim INFfs As New IO.FileStream(TempDir.FullName & "\Dependent." & TheCarrier & "." & TheDevice.ToString & "." & TheProcessor.ToString & ".inf", IO.FileMode.Create)

        Dim InfW As New InfWriter(TheBINFile, TheInputDir)
        InfW.WriteDependent(INFfs, TheDevice, TheProcessor, TheCarrier)

        INFfs.Close()

        '' Build cab file
        Dim ErrFilePath As String = IO.Path.GetFullPath(IO.Path.GetDirectoryName(INFfs.Name))
        ErrFilePath &= "\ErrorLogs"
        ErrFilePath &= "\" & IO.Path.GetFileNameWithoutExtension(INFfs.Name) & ".log"

        Dim Args As String = """" & INFfs.Name & """" & " /dest """ & TheCABDir.FullName & """ /err """ & ErrFilePath & """ /cpu " & TheProcessor.ToString
        Dim PSI As New ProcessStartInfo(CabWizPath, Args)
        Dim CabWizProc As Process = Process.Start(PSI)
        CabWizProc.WaitForExit()

        Dim OutFileName As String = TheCABDir.FullName & "\Dependent." & TheProcessor.ToString & ".cab"
        If IO.File.Exists(OutFileName) Then
            Dim BINv As Versioning.BIN
            Dim BINVer As String

            Try
                BINv = New Versioning.BIN(TheBINFile.Directory)
                BINVer = BINv.GetFullVersion()
            Catch ex As Exception
                IO.File.Delete(OutFileName)
                Console.WriteLine("Carrier " & TheCarrier & " was skipped. (error parsing version.xml)")
                Return
            End Try

            Dim NewName1 As String = TheCABDir.FullName & "\DependentFiles." & TheCarrier & "." & BINVer & ".cab"
            Dim NewName2 As String = TheCABDir.FullName & "\DependentFiles." & TheCarrier & ".cab"
            If IO.File.Exists(NewName1) Then
                IO.File.SetAttributes(NewName1, IO.FileAttributes.Normal)
                IO.File.Delete(NewName1)
            End If

            If IO.File.Exists(NewName2) Then
                IO.File.SetAttributes(NewName2, IO.FileAttributes.Normal)
                IO.File.Delete(NewName2)
            End If
            IO.File.Copy(OutFileName, NewName1)
            IO.File.Copy(OutFileName, NewName2)
            IO.File.SetAttributes(OutFileName, IO.FileAttributes.Normal)
            IO.File.Delete(OutFileName)

            '' Mark Read-Only
            IO.File.SetAttributes(NewName2, IO.FileAttributes.ReadOnly)

        End If

        '' Delete .dat files
        Dim DATFiles() As String = IO.Directory.GetFiles(TheCABDir.FullName, "*.dat")
        Dim DATFile As String
        For Each DATFile In DATFiles
            IO.File.Delete(DATFile)
        Next

    End Sub

    ''' <summary>
    ''' Builds the main CAB file.
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub BuildMain(ByVal TheProcessor As InfWriter.Processors, ByVal TheDevice As InfWriter.Devices, ByVal TheCABDir As IO.DirectoryInfo, ByVal TheInputDir As IO.DirectoryInfo)
        '' Write INF file
        Dim INFfs As New IO.FileStream(TempDir.FullName & "\TagTrak." & TheDevice.ToString & "." & TheProcessor.ToString & ".inf", IO.FileMode.Create)

        Dim InfW As New InfWriter(TheInputDir)
        InfW.WriteMain(INFfs, TheDevice, TheProcessor)

        INFfs.Close()

        '' Build cab file
        Dim ErrFilePath As String = IO.Path.GetFullPath(IO.Path.GetDirectoryName(INFfs.Name))
        ErrFilePath &= "\ErrorLogs"
        ErrFilePath &= "\" & IO.Path.GetFileNameWithoutExtension(INFfs.Name) & ".log"

        Dim Args As String = """" & INFfs.Name & """" & " /dest """ & TheCABDir.FullName & """ /err """ & ErrFilePath & """ /cpu " & TheProcessor.ToString
        Dim PSI As New ProcessStartInfo(CabWizPath, Args)
        PSI.WindowStyle = ProcessWindowStyle.Hidden
        Dim CabWizProc As Process = Process.Start(PSI)
        CabWizProc.WaitForExit()

        Dim OutFileName As String = TheCABDir.FullName & "\TagTrak." & TheProcessor.ToString & ".cab"
        If IO.File.Exists(OutFileName) Then
            Dim TTVer As New Versioning.TagTrak(New IO.FileInfo(InDir.FullName & "\" & TheDevice.ToString & "\" & TheProcessor.ToString & "\" & InfWriter.OSes.PPC2002.ToString & "\TagTrak.exe"))

            Dim NewName1 As String = TheCABDir.FullName & "\TagTrak." & TTVer.GetFullVersion & ".cab"
            Dim NewName2 As String = TheCABDir.FullName & "\TagTrak.cab"
            If IO.File.Exists(NewName1) Then
                IO.File.SetAttributes(NewName1, IO.FileAttributes.Normal)
                IO.File.Delete(NewName1)
            End If

            If IO.File.Exists(NewName2) Then
                IO.File.SetAttributes(NewName2, IO.FileAttributes.Normal)
                IO.File.Delete(NewName2)
            End If

            IO.File.Copy(OutFileName, NewName1)
            IO.File.Copy(OutFileName, NewName2)
            IO.File.SetAttributes(OutFileName, IO.FileAttributes.Normal)
            IO.File.Delete(OutFileName)

            '' Mark Read-Only
            IO.File.SetAttributes(NewName2, IO.FileAttributes.ReadOnly)

        End If

        '' Delete .dat files
        Dim DATFiles() As String = IO.Directory.GetFiles(TheCABDir.FullName, "*.dat")
        Dim DATFile As String
        For Each DATFile In DATFiles
            IO.File.Delete(DATFile)
        Next

    End Sub

    ''' <summary>
    ''' Builds the distribution CAB file.
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub BuildDistro(ByVal TheProcessor As InfWriter.Processors, ByVal TheDevice As InfWriter.Devices, ByVal TheOS As InfWriter.OSes, ByVal IsWireless As Boolean, ByVal TheNetTestCAB As IO.FileInfo, ByVal TheMainCAB As IO.FileInfo, ByVal TheDependentCABs() As IO.FileInfo, ByVal TheCABDir As IO.DirectoryInfo, ByVal TheInputDir As IO.DirectoryInfo, ByVal TheName As String)
        '' Write INF file
        Dim INFFileName As String
        If Not IsWireless Then
            INFFileName = TempDir.FullName & "\Distribution." & TheDevice.ToString & "." & TheProcessor.ToString & "." & TheOS.ToString & ".inf"
        Else
            INFFileName = TempDir.FullName & "\Distribution." & TheDevice.ToString & "." & TheProcessor.ToString & "." & TheOS.ToString & ".W.inf"
        End If

        Dim INFfs As New IO.FileStream(INFFileName, IO.FileMode.Create)

        Dim InfW As New InfWriter(TheInputDir, TheNetTestCAB, TheMainCAB, TheDependentCABs)
        InfW.WriteDisribution(INFfs, TheDevice, TheProcessor, TheOS, IsWireless)

        INFfs.Close()

        ' '' Build cab file
        Dim ErrFilePath As String = IO.Path.GetFullPath(IO.Path.GetDirectoryName(INFfs.Name))
        ErrFilePath &= "\ErrorLogs"
        ErrFilePath &= "\" & IO.Path.GetFileNameWithoutExtension(INFfs.Name) & ".log"

        Dim Args As String = """" & INFfs.Name & """" & " /dest """ & TheCABDir.FullName & """ /err """ & ErrFilePath & """ /cpu " & TheProcessor.ToString
        Dim PSI As New ProcessStartInfo(CabWizPath, Args)
        PSI.WindowStyle = ProcessWindowStyle.Hidden
        Dim CabWizProc As Process = Process.Start(PSI)
        CabWizProc.WaitForExit()

        Dim OutFileName As String = TheCABDir.FullName & "\Distribution." & TheProcessor.ToString & ".cab"
        If IO.File.Exists(OutFileName) Then
            Dim NewName As String
            Dim TTVer As New Versioning.TagTrak(New IO.FileInfo(InDir.FullName & "\" & TheDevice.ToString & "\" & TheProcessor.ToString & "\" & TheOS.ToString & "\TagTrak.exe"))
            Dim Ver As String
            If DirectCast(My.Settings.Item("FullVersionInDistro"), Boolean) Then
                Ver = TTVer.GetFullVersion
            Else
                Ver = TTVer.GetVersion
            End If

            If IsWireless Then
                NewName = TheCABDir.FullName & "\" & TheName & ".TagTrak-" & Ver & "-" & TheOS.ToString & "-W.cab"
            Else
                NewName = TheCABDir.FullName & "\" & TheName & ".TagTrak-" & Ver & "-" & TheOS.ToString & ".cab"
            End If
            If IO.File.Exists(NewName) Then
                IO.File.SetAttributes(NewName, IO.FileAttributes.Normal)
                IO.File.Delete(NewName)
            End If
            IO.File.Move(OutFileName, NewName)
            'IO.File.Delete(OutFileName)
        End If

        '' Delete .dat files
        Dim DATFiles() As String = IO.Directory.GetFiles(TheCABDir.FullName, "*.dat")
        Dim DATFile As String
        For Each DATFile In DATFiles
            IO.File.Delete(DATFile)
        Next

    End Sub

    ''' <summary>
    ''' Builds the NetTest CAB file.
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub BuildNetTest(ByVal TheProcessor As InfWriter.Processors, ByVal TheDevice As InfWriter.Devices, ByVal TheCABDir As IO.DirectoryInfo, ByVal TheInputDir As IO.DirectoryInfo)
        '' Write INF file
        Dim INFfs As New IO.FileStream(TempDir.FullName & "\NetTest." & TheDevice.ToString & "." & TheProcessor.ToString & ".inf", IO.FileMode.Create)

        Dim InfW As New InfWriter(TheInputDir)
        InfW.WriteNetTester(INFfs, TheDevice, TheProcessor)

        INFfs.Close()

        '' Build cab file
        Dim ErrFilePath As String = IO.Path.GetFullPath(IO.Path.GetDirectoryName(INFfs.Name))
        ErrFilePath &= "\ErrorLogs"
        ErrFilePath &= "\" & IO.Path.GetFileNameWithoutExtension(INFfs.Name) & ".log"

        Dim Args As String = """" & INFfs.Name & """" & " /dest """ & TheCABDir.FullName & """ /err """ & ErrFilePath & """ /cpu " & TheProcessor.ToString
        Dim PSI As New ProcessStartInfo(CabWizPath, Args)
        PSI.WindowStyle = ProcessWindowStyle.Hidden
        Dim CabWizProc As Process = Process.Start(PSI)
        CabWizProc.WaitForExit()

        Dim OutFileName As String = TheCABDir.FullName & "\NetTest." & TheProcessor.ToString & ".cab"
        If IO.File.Exists(OutFileName) Then
            Dim NTFileVInfo As System.Diagnostics.FileVersionInfo = System.Diagnostics.FileVersionInfo.GetVersionInfo(InDir.FullName & "\" & TheDevice.ToString & "\" & TheProcessor.ToString & "\" & InfWriter.OSes.PPC2002.ToString & "\ASINetTest.exe")

            Dim NewName1 As String = TheCABDir.FullName & "\NetTest." & NTFileVInfo.FileVersion & ".cab"
            Dim NewName2 As String = TheCABDir.FullName & "\NetTest.cab"
            If IO.File.Exists(NewName1) Then
                IO.File.SetAttributes(NewName1, IO.FileAttributes.Normal)
                IO.File.Delete(NewName1)
            End If

            If IO.File.Exists(NewName2) Then
                IO.File.SetAttributes(NewName2, IO.FileAttributes.Normal)
                IO.File.Delete(NewName2)
            End If

            IO.File.Copy(OutFileName, NewName1)
            IO.File.Copy(OutFileName, NewName2)
            IO.File.SetAttributes(OutFileName, IO.FileAttributes.Normal)
            IO.File.Delete(OutFileName)

            '' Mark Read-Only
            IO.File.SetAttributes(NewName2, IO.FileAttributes.ReadOnly)

        End If

        '' Delete .dat files
        Dim DATFiles() As String = IO.Directory.GetFiles(TheCABDir.FullName, "*.dat")
        Dim DATFile As String
        For Each DATFile In DATFiles
            IO.File.Delete(DATFile)
        Next

    End Sub

    ''' <summary>
    ''' Cleans up files that were used to generate Distributions.
    ''' </summary>
    ''' <remarks></remarks>
    Public Sub Cleanup(ByVal TheCABDir As IO.DirectoryInfo)
        Dim CarrierDirs() As IO.DirectoryInfo = TheCABDir.GetDirectories("??")
        Dim CarrierDir As IO.DirectoryInfo

        Dim Procs() As InfWriter.Processors = [Enum].GetValues(GetType(InfWriter.Processors))
        Dim Proc As InfWriter.Processors

        Dim Devs() As InfWriter.Devices = [Enum].GetValues(GetType(InfWriter.Devices))
        Dim Dev As InfWriter.Devices

        '' Clean up "DepenedentFiles.??.cab"
        For Each CarrierDir In CarrierDirs
            For Each Proc In Procs
                For Each Dev In Devs
                    Dim DepCABFileName As String = CarrierDir.FullName & "\" & Dev.ToString & "\" & Proc.ToString & "\DependentFiles." & CarrierDir.Name & ".cab"
                    If IO.File.Exists(DepCABFileName) Then
                        '' Clear Read-Only
                        IO.File.SetAttributes(DepCABFileName, IO.FileAttributes.Normal)
                        IO.File.Delete(DepCABFileName)
                    End If
                Next
            Next
        Next

        '' Clean up "TagTrak.cab"
        For Each Proc In Procs
            For Each Dev In Devs
                Dim TTCABFileName As String = TheCABDir.FullName & "\TagTrak\" & Dev.ToString & "\" & Proc.ToString & "\TagTrak.cab"
                If IO.File.Exists(TTCABFileName) Then
                    '' Clear Read-Only
                    IO.File.SetAttributes(TTCABFileName, IO.FileAttributes.Normal)
                    IO.File.Delete(TTCABFileName)
                End If
            Next
        Next

        '' Clean up "NetTest.cab"
        For Each Proc In Procs
            For Each Dev In Devs
                Dim TTCABFileName As String = TheCABDir.FullName & "\NetTest\" & Dev.ToString & "\" & Proc.ToString & "\NetTest.cab"
                If IO.File.Exists(TTCABFileName) Then
                    '' Clear Read-Only
                    IO.File.SetAttributes(TTCABFileName, IO.FileAttributes.Normal)
                    IO.File.Delete(TTCABFileName)
                End If
            Next
        Next

    End Sub

    Private disposedValue As Boolean = False        ' To detect redundant calls
    ' IDisposable
    Protected Overridable Sub Dispose(ByVal disposing As Boolean)
        If Not Me.disposedValue Then
            If disposing Then
            End If

            Cleanup(CABDir)
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
