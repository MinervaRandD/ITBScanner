''' <summary>
''' Starts and Initializes CABBuilder and keeps track of frequently used directories.
''' </summary>
''' <remarks></remarks>

Module ModuleMain

    Public Const CabWizPath As String = ".\CabWiz\CabWiz.exe"
    Public Const DistroConfigFileName As String = "Distributions.xml"

    Public InDir As IO.DirectoryInfo
    Public BINDir As IO.DirectoryInfo
    Public CABDir As IO.DirectoryInfo
    Public TempDir As IO.DirectoryInfo
    Public TempLogDir As IO.DirectoryInfo
    Public DistoConfigDir As IO.DirectoryInfo

    ''' <summary>
    ''' Runs the entire build process.
    ''' </summary>
    ''' <remarks></remarks>
    Sub Main()
        Console.WriteLine("CABBuilder " & My.Application.Info.Version.ToString & " started.")
        Console.WriteLine()

        My.Settings.Upgrade()

        If Not InitDirs() Then Return

        Dim CB As New CABBuilder
        Dim CarrierBINDirs() As IO.DirectoryInfo = BINDir.GetDirectories("??")
        Dim CarrierBINDir As IO.DirectoryInfo

        Dim BINFiles() As IO.FileInfo
        Dim BINFile As IO.FileInfo

        '' Update files
        Console.WriteLine("UPDATING Files:")
        AutoUpdate()

        '' Build NetTest files
        Console.WriteLine("Building NETTEST Files:")
        CB.BuildNetTestCABs()

        '' Build dependent files
        Console.WriteLine("Building DEPENDENT Files:")
        Dim CarrierCABDir As IO.DirectoryInfo
        For Each CarrierBINDir In CarrierBINDirs

            '' Get the bin file to use
            BINFiles = CarrierBINDir.GetFiles("*Config.bin")
            If BINFiles.Length > 1 Then
                BINFile = CarrierBINDir.GetFiles("*Config.bin")(0)
                Console.WriteLine("WARNING: More than one bin file found for carrier " & CarrierBINDir.Name & ", will use " & BINFile.Name & ".")
            ElseIf BINFiles.Length = 1 Then
                BINFile = CarrierBINDir.GetFiles("*Config.bin")(0)
            Else
                Console.WriteLine("WARNING: No bin file found for carrier " & CarrierBINDir.Name & ", skipping.")
                Continue For
            End If

            If Not IO.Directory.Exists(CABDir.FullName & "\" & CarrierBINDir.Name) Then
                IO.Directory.CreateDirectory(CABDir.FullName & "\" & CarrierBINDir.Name)
            End If
            CarrierCABDir = New IO.DirectoryInfo(CABDir.FullName & "\" & CarrierBINDir.Name)

            '' Build the CAB
            CB.BuildDependentCABs(CarrierBINDir.Name, BINFile, CarrierCABDir)
        Next

        Console.WriteLine("Building MAIN Files:")
        CB.BuildMainCABs()

        Console.WriteLine("Building DISTRIBUTION Files:")
        CB.BuildDistributionCABs()

        Console.WriteLine("Cleaning up...")
        CB.Dispose()

        Console.WriteLine("Done.")
    End Sub

    ''' <summary>
    ''' Verifies/creates the necessary sub-folders and initialized global DirectoryInfo variables.
    ''' </summary>
    ''' <returns>True on success, False on failure.</returns>
    ''' <remarks></remarks>
    Private Function InitDirs() As Boolean
        Dim CABPath As String = DirectCast(My.Settings.Item("CABPath"), String)
        If Not IO.Directory.Exists(CABPath) Then IO.Directory.CreateDirectory(CABPath)
        CABDir = New IO.DirectoryInfo(CABPath)

        If Not IO.Directory.Exists(".\Temp") Then IO.Directory.CreateDirectory(".\Temp")
        TempDir = New IO.DirectoryInfo(".\Temp")

        If Not IO.Directory.Exists(".\Temp\ErrorLogs") Then IO.Directory.CreateDirectory(".\Temp\ErrorLogs")
        TempLogDir = New IO.DirectoryInfo(".\Temp\ErrorLogs")

        BINDir = New IO.DirectoryInfo(DirectCast(My.Settings.Item("BINPath"), String))

        '' Verify input path
        If Not IO.Directory.Exists(DirectCast(My.Settings.Item("InputPath"), String)) Then IO.Directory.CreateDirectory(DirectCast(My.Settings.Item("InputPath"), String))
        InDir = New IO.DirectoryInfo(DirectCast(My.Settings.Item("InputPath"), String))

        Dim Devices() As String = [Enum].GetNames(GetType(InfWriter.Devices))
        Dim Device As String
        Dim Processors() As String = [Enum].GetNames(GetType(InfWriter.Processors))
        Dim Processor As String
        Dim OSes() As String = [Enum].GetNames(GetType(InfWriter.OSes))
        Dim OS As String

        For Each Device In Devices
            If Not IO.Directory.Exists(InDir.FullName & "\" & Device) Then
                IO.Directory.CreateDirectory(InDir.FullName & "\" & Device.ToString)
            End If
            For Each Processor In Processors
                For Each OS In OSes
                    If Not IO.Directory.Exists(InDir.FullName & "\" & Device & "\" & Processor & "\" & OS) Then
                        IO.Directory.CreateDirectory(InDir.FullName & "\" & Device & "\" & Processor & "\" & OS)
                    End If
                Next
            Next
        Next

        If Not IO.File.Exists(CabWizPath) Then
            Console.WriteLine("ERROR: """ & CabWizPath & """ was not found.")
            Return False
        End If

        DistoConfigDir = New IO.DirectoryInfo(DirectCast(My.Settings.Item("DistroConfigPath"), String))

        Return True

    End Function

    ''' <summary>
    ''' Automatically updates files
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub AutoUpdate()
        Dim TheInputDir As IO.DirectoryInfo

        Dim Procs() As InfWriter.Processors = [Enum].GetValues(GetType(InfWriter.Processors))
        Dim Proc As InfWriter.Processors

        Dim Devs() As InfWriter.Devices = [Enum].GetValues(GetType(InfWriter.Devices))
        Dim Dev As InfWriter.Devices

        Dim OSes() As InfWriter.Devices = [Enum].GetValues(GetType(InfWriter.OSes))
        Dim OS As InfWriter.OSes

        For Each Proc In Procs
            For Each Dev In Devs
                For Each OS In OSes
                    TheInputDir = New IO.DirectoryInfo(InDir.FullName & "\" & Dev.ToString & "\" & Proc.ToString & "\" & OS.ToString)
                    Console.WriteLine("Updating files for " & Dev.ToString & " (" & Proc.ToString & ") on " & OS.ToString & ".")

                    '' Auto update
                    Dim AUr As AutoUpdate.Reader = Nothing
                    Try
                        AUr = New AutoUpdate.Reader(TheInputDir)
                    Catch ex As Exception
                        Console.WriteLine("WARNING: No valid AutoUpdate.xml in " & TheInputDir.FullName & ".")
                    End Try

                    '' AutoUpdate read successfully, copy files
                    If Not AUr Is Nothing Then
                        Dim AUp As New AutoUpdate.Processor(AUr)
                        AUp.Update()
                    End If

                Next
            Next
        Next

    End Sub
End Module
