Module TagTrakBaseConfigParms

    ' !!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!
    ' !!  Note: Items in the following collection must be set to correct values before the       !!
    ' !!  application is released. Release values are indicated in the comments after each item. !!
    ' !!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!

    ' The following choice specifies the user.

    'Public user As String = "ATA"
    'Public user As String = "JetBlue"
    'Public user As String = "ASI"
    'Public user As String = "USAirways"
    'Public user As String = "PacificAirCargo"
    'Public user As String = "MNAviation"
    'Public user as string = "SpiritAir"
    'Public user As String = "Roblex"
    'Public user As String = "AirFlamenco"
    'Public user As String = "Olympic"
    'Public user As String = "Aloha"

    '' Version declaration:
    '' Use this to modify the Revision.
    Private MyVersionRevision As Integer = 0

    Private MyVersionMajor As Integer = System.Reflection.Assembly.GetExecutingAssembly.GetName.Version.Major
    Private MyVersionMinor As Integer = System.Reflection.Assembly.GetExecutingAssembly.GetName.Version.Minor

    '' Build represents an ever increasing time based identifier of when this version was compiled.
    '' Build calculation:
    '' Integer.MaxValue -> &h7FFFF FFF
    ''                       ^^^^^ ^^^
    ''                       Days  Seconds
    '' Days = Days since Jan 1 2000
    '' Seconds = Seconds since midnight / 22d    (Max &hF57)
    ''
    '' This gives us a granularity of a new build number every 22 seconds 
    '' with a limit of approximately 1,436 years from Jan 1 2000.

    Private DaysSince2k As Integer = System.Reflection.Assembly.GetExecutingAssembly.GetName.Version.Build
    Private SecSinceMidnight As Integer = System.Reflection.Assembly.GetExecutingAssembly.GetName.Version.Revision * 2

    Private MyVersionBuild As Integer = (DaysSince2k << 12) Or (SecSinceMidnight \ 22)

    '' Version number distinguishing public releases
    Public myVersion As String = MyVersionMajor.ToString & _
                                "." & MyVersionMinor.ToString & _
                                "." & MyVersionRevision.ToString

    '' Version distinguishing internal builds
    Public myVersionFull As String = MyVersionMajor.ToString & _
                                "." & MyVersionMinor.ToString & _
                                "." & MyVersionRevision.ToString & _
                                    "." & MyVersionBuild.ToString

    Public diagnosticLevel As Integer = 1

    Public userNumber As Integer = 1

    'use carrier code here
    Public user As String = "99"
    Public singleCarrier As Boolean = True

#If DEBUG Then
    Public productionDistribution As Boolean = False
#Else
    Public productionDistribution As Boolean = True
#End If

#If deviceType = "PC" Then
    Public Const emulatingPlatform As Boolean = True
#Else
    Public Const emulatingPlatform As Boolean = False
#End If

    Public usingEncryption As Boolean = True
    Public usingMD5Validation As Boolean = False

    Public forceCreationOfConfigFilesFromDefaults As Boolean = False

End Module