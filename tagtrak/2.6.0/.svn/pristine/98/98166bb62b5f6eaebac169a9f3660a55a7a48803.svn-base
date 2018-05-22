''' <summary>
''' Writes the various INF files required for CAB generation.
''' </summary>
''' <remarks></remarks>
Public Class InfWriter

    Enum Devices
        Intermec
        Dolphin
        Symbol
    End Enum

    Enum Processors
        ARMV4
    End Enum

    Enum OSes
        PPC2002
        PPC2003
    End Enum

    Private MyBINFiles() As IO.FileInfo
    Private MyInputDir As IO.DirectoryInfo
    Private MyNetTestFile As IO.FileInfo
    Private MyMainFile As IO.FileInfo
    Private MyDependentFiles() As IO.FileInfo

    Sub New(ByVal TheInputDir As IO.DirectoryInfo)
        MyInputDir = TheInputDir
    End Sub

    Sub New(ByVal TheBINFiles() As IO.FileInfo, ByVal TheInputDir As IO.DirectoryInfo)
        MyBINFiles = TheBINFiles
        MyInputDir = TheInputDir
    End Sub

    Sub New(ByVal TheBINFile As IO.FileInfo, ByVal TheInputDir As IO.DirectoryInfo)
        ReDim MyBINFiles(0)
        MyBINFiles(0) = TheBINFile
        MyInputDir = TheInputDir
    End Sub

    '' For writing Main inf
    Sub New(ByVal TheInputDir As IO.DirectoryInfo, ByVal TheNetTestFile As IO.FileInfo, ByVal TheMainFile As IO.FileInfo, ByVal TheDependentFiles() As IO.FileInfo)
        MyInputDir = TheInputDir
        MyDependentFiles = TheDependentFiles
        MyNetTestFile = TheNetTestFile
        MyMainFile = TheMainFile
        MyDependentFiles = TheDependentFiles
    End Sub

    Public Sub WriteDisribution(ByVal TheOut As IO.Stream, ByVal TheDevice As Devices, ByVal TheProcessor As Processors, ByVal TheOS As OSes, ByVal IsWireless As Boolean)
        Dim SW As New IO.StreamWriter(TheOut)

        SW.WriteLine()
        SW.WriteLine(";==================================================")
        SW.WriteLine("")
        SW.WriteLine("[Version]")
        SW.WriteLine()
        SW.WriteLine("Signature	= ""$Windows NT$""")
        SW.WriteLine("Provider	= ""Aviation Software, Inc.""")
        SW.WriteLine("CESignature	= ""$Windows CE$""")
        SW.WriteLine()
        SW.WriteLine("[CEDevice]")
        SW.WriteLine("Processortype	= 2577")
        SW.WriteLine("VersionMin 	= 3.0")
        SW.WriteLine("VersionMax	= 100")
        SW.WriteLine()
        SW.WriteLine("[CEStrings]")
        SW.WriteLine()

        If TheDevice = Devices.Intermec Then
            SW.WriteLine("InstallDir = ""\SDMMC Disk\""")

        ElseIf TheDevice = Devices.Dolphin Then
            SW.WriteLine("InstallDir = ""\IPSP\""")

        ElseIf TheDevice = Devices.Symbol Then
            SW.WriteLine("InstallDir = ""\Storage Card\""")

        End If

        SW.WriteLine("AppName=TagTrak Installer")
        SW.WriteLine()
        SW.WriteLine("[Strings]")
        SW.WriteLine()

        If TheDevice = Devices.Intermec Then
            SW.WriteLine("SDMMC  = ""\SDMMC Disk\""")
            SW.WriteLine("Flash  = ""\Flash File Store\""")
            SW.WriteLine("CABS   = ""cabfiles\""")
            SW.WriteLine("OTH	   = ""2577\""")
            SW.WriteLine("CRE	   = ""CORE\""")
            SW.WriteLine("MDL	   = ""Modules\""")
            SW.WriteLine("Instl	   = ""Installed\""")

        ElseIf TheDevice = Devices.Dolphin Then
            SW.WriteLine("SDMMC  = ""\Storage Card\""")
            SW.WriteLine("Flash  = ""\IPSM\""")
            SW.WriteLine("CABS   = ""cabfiles\""")
            SW.WriteLine("AutoInstall = ""AutoInstall\""")

        ElseIf TheDevice = Devices.Symbol Then
            SW.WriteLine("SDMMC  = ""\Storage Card\""")
            SW.WriteLine("Flash  = ""\Application\""")
            SW.WriteLine("CABS   = ""Application\""")
            SW.WriteLine("Startup = ""Startup\""")
        End If

        SW.WriteLine()
        SW.WriteLine(";==================================================")
        SW.WriteLine()
        SW.WriteLine("[DefaultInstall]")
        SW.WriteLine()

        If TheDevice = Devices.Intermec Then
            If Not IsWireless Then
                SW.WriteLine("CopyFiles	= Cabs,Start1,Start2")
            Else
                SW.WriteLine("CopyFiles	= Cabs,Start1,Start2,CORE,CORE_Modules_Installed")
            End If
        ElseIf TheDevice = Devices.Dolphin Then
            SW.WriteLine("CopyFiles = Cabs, Dolphin1")

        ElseIf TheDevice = Devices.Symbol Then
            SW.WriteLine("CopyFiles = Cabs, Symbol1")
        End If

        SW.WriteLine("")
        SW.WriteLine(";==================================================")
        SW.WriteLine("")
        SW.WriteLine("[SourceDisksNames]")
        SW.WriteLine("")
        SW.WriteLine("1 =, ""BuildSource"" ,, """ & MyInputDir.FullName & """")
        SW.WriteLine("2 =, ""MainCABSource"" ,, """ & MyMainFile.DirectoryName & """")
        SW.WriteLine("3 =, ""NetTestCABSource"" ,, """ & MyNetTestFile.DirectoryName & """")
        Dim I As Integer
        For I = 0 To MyDependentFiles.Length - 1
            SW.WriteLine(CStr(I + 10) & "=, ""MainCABSource" & I.ToString & """ ,, """ & MyDependentFiles(I).DirectoryName & """")
        Next

        SW.WriteLine("")
        SW.WriteLine("[SourceDisksFiles]")
        SW.WriteLine("")

        SW.WriteLine(MyMainFile.Name & "=2")
        SW.WriteLine(MyNetTestFile.Name & "=3")

        Dim DepFile As IO.FileInfo
        I = 10
        For Each DepFile In MyDependentFiles
            SW.WriteLine(DepFile.Name & "=" & I.ToString)
            I += 1
        Next

        If TheDevice = Devices.Intermec Then
            If TheOS = OSes.PPC2003 Then
                If IsWireless Then
                    SW.WriteLine("autouser.wireless.dat=1")
                    SW.WriteLine("CORE.exe=1")
                    SW.WriteLine("WAN_Module.dll=1")
                Else
                    SW.WriteLine("autouser.wired.dat=1")
                End If
                SW.WriteLine("autorun.dat=1")
                SW.WriteLine("RegEnableAndFlush Mobile 2003.exe=1")
                SW.WriteLine("autorun.exe=1")
                SW.WriteLine("autocab.exe=1")
            Else
                SW.WriteLine("autouser.dat=1")
                SW.WriteLine("autorun.dat=1")
                SW.WriteLine("netcf.core.ppc3.arm.cab=1")
                SW.WriteLine("autorun.exe=1")
                SW.WriteLine("autocab.exe=1")
                SW.WriteLine("regflush.cab=1")
            End If
            SW.WriteLine("bootstrap.exe=1")
            SW.WriteLine("flash_autorun.dat=1")

        ElseIf TheDevice = Devices.Dolphin Then
            SW.WriteLine("netcf.hhp.wce4.armv4_2.05.CAB=1")
            'SW.WriteLine("Autorun.exm=1")

        ElseIf TheDevice = Devices.Symbol Then
            If TheOS < OSes.PPC2003 Then
                SW.WriteLine("netcf.core.ppc3.arm.cab=1")
            End If
            SW.WriteLine("AppCenter.reg=1")
        End If

        SW.WriteLine("")
        SW.WriteLine(";==================================================")
        SW.WriteLine("")
        SW.WriteLine("; Output directories for files & shortcuts")

        SW.WriteLine("")
        SW.WriteLine("[DestinationDirs]")

        If TheDevice = Devices.Intermec Then
            SW.WriteLine("Cabs = 0, %SDMMC%%CABS%")
            SW.WriteLine("Start1 = 0, %Flash%%OTH%")
            SW.WriteLine("Start2  = 0, %SDMMC%%OTH%")

        ElseIf TheDevice = Devices.Dolphin Then
            SW.WriteLine("Cabs = 0, %Flash%%AutoInstall%")
            SW.WriteLine("Dolphin1 = 0, %Flash%")

        ElseIf TheDevice = Devices.Symbol Then
            SW.WriteLine("Cabs = 0, %Flash%%CABS%")
            SW.WriteLine("Symbol1 = 0, %Flash%")
        End If

        If TheOS = OSes.PPC2003 And IsWireless Then
            SW.WriteLine("CORE=0, %SDMMC%%CRE%")
            SW.WriteLine("CORE_Modules_Installed=0, %SDMMC%%CRE%%MDL%%Instl%")
        End If

        SW.WriteLine("")
        SW.WriteLine("[Cabs]")

        SW.WriteLine(MyMainFile.Name & ",,,0x40000000")
        SW.WriteLine(MyNetTestFile.Name & ",,,0x40000000")

        For Each DepFile In MyDependentFiles
            SW.WriteLine(DepFile.Name & ",,,0x40000000")
        Next

        If TheDevice = Devices.Intermec Then
            If TheOS <> OSes.PPC2003 Then
                SW.WriteLine("FCDotNet.cab,netcf.core.ppc3.arm.cab,,0x40000000")
                SW.WriteLine("regflush.cab,,,0x40000000")
            End If

        ElseIf TheDevice = Devices.Dolphin Then
            SW.WriteLine("netcf.hhp.wce4.armv4_2.05.CAB,,,0x40000000")

        ElseIf TheDevice = Devices.Symbol Then
            If TheOS < OSes.PPC2003 Then
                SW.WriteLine("FCDotNet.cab,netcf.core.ppc3.arm.cab,,0x40000000")
            End If
        End If

        If TheDevice = Devices.Intermec Then
            SW.WriteLine("")
            SW.WriteLine("[Start1]")
            If TheOS = OSes.PPC2002 Then
                SW.WriteLine("autorun.exe,,,0x40000000")
                SW.WriteLine("autorun.dat,flash_autorun.dat,,0x40000000")
                SW.WriteLine("bootstrap.exe,,,0x40000000")
            End If
            SW.WriteLine("[Start2]")
            SW.WriteLine("")
            SW.WriteLine("autorun.exe,,,0x40000000")
            SW.WriteLine("autorun.dat,,,0x40000000")
            SW.WriteLine("autocab.exe,,,0x40000000")
            If TheOS = OSes.PPC2003 Then
                If IsWireless Then
                    SW.WriteLine("autouser.dat,autouser.wireless.dat,,0x40000000")
                    SW.WriteLine("RegEnableAndFlush Mobile 2003.exe,,,0x40000000")
                    SW.WriteLine("")
                    SW.WriteLine("[CORE]")
                    SW.WriteLine("")
                    SW.WriteLine("core.exe,,,0x40000000")
                    SW.WriteLine("")
                    SW.WriteLine("[CORE_Modules_Installed]")
                    SW.WriteLine("")
                    SW.WriteLine("WAN_Module.dll,,,0x40000000")
                Else
                    SW.WriteLine("autouser.dat,autouser.wired.dat,,0x40000000")
                    SW.WriteLine("RegEnableAndFlush Mobile 2003.exe,,,0x40000000")
                End If
            Else

                SW.WriteLine("autouser.dat,,,0x40000000")
            End If
        ElseIf TheDevice = Devices.Dolphin Then
            SW.WriteLine("")
            SW.WriteLine("[Dolphin1]")
            'SW.WriteLine("Autorun.exm,,,0x40000000")

        ElseIf TheDevice = Devices.Symbol Then
            SW.WriteLine("")
            SW.WriteLine("[Symbol1]")
            SW.WriteLine("AppCenter.reg,,,0x40000000")

        End If

        SW.Close()
    End Sub

    Public Sub WriteNetTester(ByVal TheOut As IO.Stream, ByVal TheDevice As Devices, ByVal TheProcessor As Processors)
        '' Only ARMV4
        If TheProcessor <> Processors.ARMV4 Then Return

        Dim SW As New IO.StreamWriter(TheOut)

        SW.WriteLine("[Version]")
        SW.WriteLine("Signature = ""$Windows NT$""")
        SW.WriteLine("Provider = ""ASI""")
        SW.WriteLine("CESignature = ""$Windows CE$""")
        SW.WriteLine()
        SW.WriteLine("[CEStrings]")
        SW.WriteLine("AppName = ""ASI Net Test""")
        SW.WriteLine("InstallDir=%CE1%\%AppName%")
        SW.WriteLine()
        SW.WriteLine("[CEDevice]")
        SW.WriteLine("VersionMin=3.0")
        SW.WriteLine("VersionMax=4.99")
        SW.WriteLine()
        SW.WriteLine("[DefaultInstall]")
        SW.WriteLine("CEShortcuts=Shortcuts")
        SW.WriteLine("CopyFiles=Files.Common")
        SW.WriteLine()
        SW.WriteLine("[SourceDisksNames]")
        SW.WriteLine("1=,""Common1"",,""" & InDir.FullName & "\" & TheDevice.ToString & "\" & TheProcessor.ToString & "\" & OSes.PPC2002.ToString & """")
        SW.WriteLine()
        SW.WriteLine("[SourceDisksFiles]")
        SW.WriteLine("ASINetTest.exe=1")
        SW.WriteLine("icmpwrap.dll=1")
        If TheDevice = Devices.Intermec Then
            SW.WriteLine("psuuid0c.dll=1")
        End If
        SW.WriteLine("Rebex.Net.Time.dll=1")
        SW.WriteLine("Rebex.Security.dll=1")
        SW.WriteLine("Rebex.Net.SecureSocket.dll=1")
        SW.WriteLine("Rebex.Net.Ftp.dll=1")
        SW.WriteLine("Rebex.Net.ProxySocket.dll=1")
        SW.WriteLine("OpenNETCF.dll=1")
        SW.WriteLine("OpenNETCF.Drawing.dll=1")
        SW.WriteLine("OpenNETCF.Net.dll=1")
        SW.WriteLine("OpenNETCF.VisualBasic.dll=1")
        SW.WriteLine("OpenNETCF.Windows.Forms.dll=1")
        SW.WriteLine()
        SW.WriteLine("[DestinationDirs]")
        SW.WriteLine("Files.Common=0,%InstallDir%")
        SW.WriteLine("Shortcuts=0,%CE2%\Start Menu")
        SW.WriteLine()
        SW.WriteLine("[Files.Common]")
        SW.WriteLine("ASINetTest.exe, , , 0")
        SW.WriteLine("icmpwrap.dll, , , 0")
        If TheDevice = Devices.Intermec Then
            SW.WriteLine("psuuid0c.dll, , , 0")
        End If
        SW.WriteLine("Rebex.Net.Time.dll, , , 0")
        SW.WriteLine("Rebex.Security.dll, , , 0")
        SW.WriteLine("Rebex.Net.SecureSocket.dll, , , 0")
        SW.WriteLine("Rebex.Net.Ftp.dll, , , 0")
        SW.WriteLine("Rebex.Net.ProxySocket.dll, , , 0")
        SW.WriteLine("OpenNETCF.dll, , , 0")
        SW.WriteLine("OpenNETCF.Drawing.dll, , , 0")
        SW.WriteLine("OpenNETCF.Net.dll, , , 0")
        SW.WriteLine("OpenNETCF.VisualBasic.dll, , , 0")
        SW.WriteLine("OpenNETCF.Windows.Forms.dll, , , 0")
        SW.WriteLine()
        SW.WriteLine("[Shortcuts]")
        SW.WriteLine("ASI Net Test,0,ASINetTest.exe,%CE11%")

        SW.Close()

    End Sub

    Public Sub WriteMain(ByVal TheOut As IO.Stream, ByVal TheDevice As Devices, ByVal TheProcessor As Processors)
        Dim SW As New IO.StreamWriter(TheOut)

        SW.WriteLine("[Version]")
        SW.WriteLine("Signature=""$Windows NT$""")
        SW.WriteLine("Provider=""Aviation Software, Inc.""")
        SW.WriteLine("CESignature=""$Windows CE$""")
        SW.WriteLine()
        SW.WriteLine("[CEStrings]")
        SW.WriteLine("AppName=""TagTrak""")
        SW.WriteLine("InstallDir=%CE1%\%AppName%")
        SW.WriteLine("")
        SW.WriteLine("[CEDevice]")
        SW.WriteLine("UnsupportedPlatforms = ""HPC"",""Jupiter"",""Smartphone""")
        SW.WriteLine()

        SW.WriteLine("[Strings]")
        SW.WriteLine()

        If TheDevice = Devices.Intermec Then
            SW.WriteLine("Flash 	= ""\SDMMC Disk\""")
        ElseIf TheDevice = Devices.Dolphin Then
            SW.WriteLine("Flash 	= ""\IPSM\""")
        ElseIf TheDevice = Devices.Symbol Then
            SW.WriteLine("Flash 	= ""\Storage Card\""")
        End If

        SW.WriteLine()

        SW.WriteLine("[DefaultInstall]")
        SW.WriteLine("CEShortcuts=Shortcuts")
        SW.WriteLine("addreg= regsettings.all")
        SW.WriteLine()
        SW.WriteLine("[DefaultInstall." + TheProcessor.ToString + "]")

        SW.WriteLine("Copyfiles=Files.ARMV4")

        SW.WriteLine()
        SW.WriteLine("[SourceDisksNames]")
        SW.WriteLine("1=,""Common1"",,""" & InDir.FullName & "\" & TheDevice.ToString & "\" & TheProcessor.ToString & "\" & OSes.PPC2002.ToString & """")

        SW.WriteLine("[SourceDisksFiles]")
        SW.WriteLine("TagTrak.exe=1")
        SW.WriteLine("OpenNETCF.dll=1")
        SW.WriteLine("OpenNETCF.Net.dll=1")
        SW.WriteLine("Rebex.Net.Ftp.dll=1")
        SW.WriteLine("Rebex.Net.Time.dll=1")
        SW.WriteLine("Rebex.Net.ProxySocket.dll=1")
        SW.WriteLine("Rebex.Net.SecureSocket.dll=1")
        SW.WriteLine("Rebex.Security.dll=1")
        SW.WriteLine("SharpZipLib.dll=1")

        If TheDevice = Devices.Intermec Then
            SW.WriteLine("Intermec.DataCollection.dll=1")
            SW.WriteLine("itcscan.dll=1")
            SW.WriteLine("psuuid0c.dll=1")
            SW.WriteLine("AirlineSoftware.dll=1")

        ElseIf TheDevice = Devices.Dolphin Then
            SW.WriteLine("HHP.DataCollection.Common.dll=1")
            SW.WriteLine("HHP.DataCollection.Decoding.dll=1")
            SW.WriteLine("AirlineSoftware.dll=1")

        ElseIf TheDevice = Devices.Symbol Then
            SW.WriteLine("Symbol.dll=1")
            SW.WriteLine("Symbol.Barcode.dll=1")
            SW.WriteLine("Symbol.ResourceCoordination.dll=1")
            SW.WriteLine("AirlineSoftware.dll=1")

        End If

        SW.WriteLine()
        SW.WriteLine("[DestinationDirs]")
        SW.WriteLine("Shortcuts=0,%CE2%\Start Menu")
        SW.WriteLine("Files." & TheProcessor.ToString & "=0,%InstallDir%")

        SW.WriteLine()
        SW.WriteLine("[Files." & TheProcessor.ToString & "]")
        SW.WriteLine("TagTrak.exe,,,0x40000000")
        SW.WriteLine("OpenNETCF.dll,,,0x40000000")
        SW.WriteLine("OpenNETCF.Net.dll,,,0x40000000")
        SW.WriteLine("Rebex.Net.ProxySocket.dll,,,0x40000000")
        SW.WriteLine("Rebex.Net.Ftp.dll,,,0x40000000")
        SW.WriteLine("Rebex.Net.SecureSocket.dll,,,0x40000000")
        SW.WriteLine("Rebex.Net.Time.dll,,,0x40000000")
        SW.WriteLine("Rebex.Security.dll,,,0x40000000")
        SW.WriteLine("SharpZipLib.dll,,,0x40000000")

        If TheDevice = Devices.Intermec Then
            SW.WriteLine("Intermec.DataCollection.dll,,,0x40000000")
            SW.WriteLine("itcscan.dll,,,0x40000000")
            SW.WriteLine("psuuid0c.dll,,,0x40000000")
            SW.WriteLine("AirlineSoftware.dll,,,0x40000000")

        ElseIf TheDevice = Devices.Dolphin Then
            SW.WriteLine("HHP.DataCollection.Common.dll,,,0x40000000")
            SW.WriteLine("HHP.DataCollection.Decoding.dll,,,0x40000000")
            SW.WriteLine("AirlineSoftware.dll,,,0x40000000")

        ElseIf TheDevice = Devices.Symbol Then
            SW.WriteLine("Symbol.dll,,,0x40000000")
            SW.WriteLine("Symbol.Barcode.dll,,,0x40000000")
            SW.WriteLine("Symbol.ResourceCoordination.dll,,,0x40000000")
            SW.WriteLine("AirlineSoftware.dll,,,0x40000000")

        End If

        SW.WriteLine()

        SW.WriteLine("[Shortcuts]")
        SW.WriteLine("TagTrak,0,TagTrak.exe,%CE11%")
        SW.WriteLine()
        SW.WriteLine("[RegSettings.All]")
        SW.WriteLine("HKLM,""Hardware\Devicemap\Keybd"",""vkeyGold"",0x00000001," & _
                     "00,00,0B,05,02,03,00,00,04,03,BE,00,34,00,00,00," & _
                     "09,01,00,00,BF,00,03,02,00,00,BD,00,75,00,72,00," & _
                     "21,00,01,02,00,00,76,00,09,00,73,00,38,01,00,00," & _
                     "35,00,00,00,BB,01,09,05,22,00,32,01,36,00,00,00," & _
                     "00,00,00,00,00,00,00,00,00,00,00,00,00,00,00,00," & _
                     "00,00,00,00,00,00,00,00,00,00,00,00,00,00,00,00," & _
                     "00,00,00,00,00,00,00,00,00,00,00,00,00,00,00,00," & _
                     "00,00,00,00,00,00,00,00,00,00,00,00,00,00,00,00," & _
                     "00,00,07,05,01,05,03,05,02,05")

        SW.WriteLine("HKLM,""Hardware\Devicemap\Keybd\ALPHA"",""vkeyGold"",0x00000001," & _
                     "00,00,0B,05,02,03,03,03,04,03,00,00,00,00,72,00," & _
                     "09,01,76,00,75,00,09,00,73,00,00,00,BB,00,38,01," & _
                     "00,00,BF,00,00,00,21,00,32,01,BD,00,31,00,32,00," & _
                     "09,05,22,00,BC,00,BB,01,34,00,35,00,33,00,02,02," & _
                     "08,00,BE,00,37,00,38,00,36,00,03,02,01,02,20,00," & _
                     "30,00,0D,00,39,00,00,00,00,00,00,00,00,00,00,00," & _
                     "00,00,00,00,00,00,00,00,00,00,00,00,00,00,00,00," & _
                     "00,00,00,00,00,00,00,00,00,00,00,00,00,00,00,00," & _
                     "00,00,07,05,01,05,03,05,02,05")

        SW.Close()

    End Sub

    Public Sub WriteDependent(ByVal TheOut As IO.Stream, ByVal TheDevice As Devices, ByVal TheProcessor As Processors, ByVal TheCarrier As String)
        Dim SW As New IO.StreamWriter(TheOut)

        SW.WriteLine("[Version]")
        SW.WriteLine("Signature=""$Windows NT$""")
        SW.WriteLine("Provider=""Aviation Software, Inc.""")
        SW.WriteLine("CESignature=""$Windows CE$""")
        SW.WriteLine()
        SW.WriteLine("[CEStrings]")
        SW.WriteLine("AppName=""TagTrak Support Files""")

        If TheDevice = Devices.Intermec Then
            SW.WriteLine("InstallDir = ""\SDMMC Disk\""")

        ElseIf TheDevice = Devices.Dolphin Then
            SW.WriteLine("InstallDir = ""\IPSM\""")

        ElseIf TheDevice = Devices.Symbol Then
            SW.WriteLine("InstallDir = ""\Storage Card\""")

        End If

        SW.WriteLine()
        SW.WriteLine("[CEDevice]")
        SW.WriteLine("VersionMin=3.00")
        SW.WriteLine("VersionMax=100")
        SW.WriteLine()
        SW.WriteLine("[Strings]")
        SW.WriteLine()

        If TheDevice = Devices.Intermec Then
            SW.WriteLine("Flash 	= ""\SDMMC Disk\""")
        ElseIf TheDevice = Devices.Dolphin Then
            SW.WriteLine("Flash 	= ""\IPSM\""")
        ElseIf TheDevice = Devices.Symbol Then
            SW.WriteLine("Flash 	= ""\Storage Card\""")
        End If

        SW.WriteLine("Windows = %CE2%")
        SW.WriteLine("")
        SW.WriteLine(";==================================================")
        SW.WriteLine("")
        SW.WriteLine("[DefaultInstall]")
        SW.WriteLine("")
        SW.WriteLine("CopyFiles=Config, Fonts")
        SW.WriteLine("")
        SW.WriteLine(";==================================================")
        SW.WriteLine("")
        SW.WriteLine("[SourceDisksNames]")
        SW.WriteLine("")
        SW.WriteLine("1 =, ""Config"" ,, """ & MyBINFiles(0).Directory.FullName & """")
        SW.WriteLine("2 =, ""Common1"",, """ & MyInputDir.FullName & """")
        SW.WriteLine()
        SW.WriteLine("[SourceDisksFiles]")
        SW.WriteLine()
        SW.WriteLine(MyBINFiles(0).Name & "=1")
        SW.WriteLine("ARIALN.TTF=2")
        SW.WriteLine("lucon.ttf=2")
        SW.WriteLine()
        SW.WriteLine(";==================================================")
        SW.WriteLine()
        SW.WriteLine("; Output directories for files & shortcuts")
        SW.WriteLine()
        SW.WriteLine("[DestinationDirs]")
        SW.WriteLine()

        SW.WriteLine("Config = 0, %Flash%carriers\" & TheCarrier & "\TagTrakConfig")

        SW.WriteLine("Fonts = 0, %CE15%")
        SW.WriteLine()

        SW.WriteLine("[Config]")
        SW.WriteLine("ScannerConfig.bin," & MyBINFiles(0).Name & ",,0x20000000")

        SW.WriteLine()

        SW.WriteLine("[Fonts]")
        SW.WriteLine()
        SW.WriteLine("ARIALN.TTF,,,0x00000010")
        SW.WriteLine("lucon.ttf,,,0x00000010")

        SW.Close()
    End Sub

End Class
