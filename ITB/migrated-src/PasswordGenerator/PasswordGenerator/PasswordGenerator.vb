Module PasswordGenerator

    Public productionDistribution As Boolean = True

    Public adminPasswordSet As New Hashtable
    Public exitPasswordSet As New Hashtable
    Public dateAndTimePasswordSet As New Hashtable
    Public locationChangePasswordSet As New Hashtable

    Public passwordSetList() As Hashtable = { _
        adminPasswordSet, _
        exitPasswordSet, _
        dateAndTimePasswordSet, _
        locationChangePasswordSet}

    Public passwordKernel As String = ""

    Public WithEvents passwordKernelTimer As New System.Windows.Forms.Timer
    Public passwordKernelAge As Integer = 0

    Public randList() As Int32 = { _
     5019786, 1780964, 12536989, 1321388, 12108916, 8306623, 12064202, 5376355, _
     6825432, 11139068, 12882681, 7367920, 3752069, 9845324, 7376743, 6522420, _
     4821565, 10831578, 12925342, 6915176, 3315065, 13003012, 14739668, 8005981, _
    12251579, 113849, 14358596, 6812327, 16650060, 13036577, 8829481, 13226242, _
     9259046, 4125247, 619502, 14323360, 13086751, 15055319, 4226018, 436013, _
     7437583, 48369, 8814416, 16265610, 12227133, 11680297, 9915022, 4015560, _
    13905794, 5806672, 5113623, 10229578, 6257414, 2668271, 2625005, 13915373, _
    15999693, 1123549, 15289563, 6258959, 1062289, 857002, 14779803, 16294646, _
    12174816, 1194763, 10042038, 9929737, 14315016, 15022117, 13696036, 9376133, _
    13186596, 5771312, 10168293, 8361191, 11108915, 1966843, 9333826, 340195, _
     5929864, 7025978, 985809, 4723986, 8811521, 4612413, 3572979, 12616662, _
    12039904, 1619904, 7822780, 8195476, 11007819, 15729945, 2732947, 276935, _
     5415655, 6921142, 11575985, 8879750, 3598572, 12305712, 11660530, 334414, _
    16269261, 14534080, 2194519, 13973027, 11790253, 16048326, 8983373, 14648568, _
     2505063, 10369201, 1771591, 4368017, 2501661, 10511069, 2542332, 7292002, _
    13139238, 10430482, 16409472, 15809832, 15553455, 14248005, 11225469, 5789258, _
     1861243, 12422870, 4637352, 13617432, 9156197, 673705, 9780913, 12326358, _
    13089695, 10414931, 14678507, 11323981, 200897, 13624751, 13931079, 2472871, _
    12983024, 2982127, 14772675, 13397433, 12809487, 9950939, 4432342, 13473836, _
     8182982, 5746655, 2892288, 4881986, 250198, 11269440, 1421268, 3176263, _
     8776274, 10774358, 4610572, 2270566, 5858986, 15572536, 321157, 3516086, _
     7520131, 5446287, 5766465, 12890918, 4380261, 5308982, 16250735, 357746, _
    10528656, 7489371, 5339866, 789020, 1435841, 12076858, 12224968, 7194129, _
     8227702, 8734785, 5961976, 3623259, 3097443, 6443158, 14923561, 2080688, _
     3330876, 503266, 13615807, 9970894, 15861402, 1922771, 12711333, 2284627, _
     9733547, 131685, 4974490, 2757343, 4980632, 12747864, 8734051, 15529719, _
    16020117, 380082, 11789954, 13120467, 10628745, 610994, 14648195, 15617135, _
     2116774, 5408582, 4559698, 5950666, 9990349, 5605582, 9922021, 5645658, _
      854344, 5445201, 11873776, 14251530, 12285366, 13163936, 1338504, 12430448, _
    11947843, 3458396, 11366831, 1598171, 12484189, 2873761, 7472814, 10509010, _
    15872327, 8557607, 10731978, 7826794, 14058237, 9784047, 9559207, 15995861, _
    13826750, 1272231, 15878645, 3491693, 2830033, 14232906, 13926063, 3541786}


    Private Function getPasswordStringValue(ByRef inputString As String) As Integer

        If inputString Is Nothing Then
            MsgBox("System Error")
            Stop
        End If

        If inputString.Length <> 4 Then
            MsgBox("System Error")
            Stop
        End If

        Dim returnValue As Integer = 0

        returnValue = ((returnValue << 3) + randList(Asc(inputString.Chars(0)))) Mod 2 ^ 24
        returnValue = ((returnValue << 3) + randList(Asc(inputString.Chars(1)))) Mod 2 ^ 24
        returnValue = ((returnValue << 3) + randList(Asc(inputString.Chars(2)))) Mod 2 ^ 24
        returnValue = ((returnValue << 3) + randList(Asc(inputString.Chars(3)))) Mod 2 ^ 24

        Return returnValue

    End Function

    Dim passwordSeedCharacterList() As Char = { _
         "D"c, "B"c, "J"c, "3"c, "V"c, "L"c, "U"c, "7"c, "W"c, "E"c, "9"c, "R"c, "P"c, "F"c, "N"c, _
         "G"c, "4"c, "T"c, "Y"c, "C"c, "6"c, "M"c, "H"c, "X"c, "K"c, "A"c, "8"c}


    Public Function generatePasswordSeed() As String

        Dim randSeed As Integer

        Dim dateAndTimeUTC As DateTime = DateTime.UtcNow

        randSeed = dateAndTimeUTC.Millisecond + 1000 * (dateAndTimeUTC.Second + 60 * dateAndTimeUTC.Minute)

        Dim randSeedValue As New Random(randSeed)

        Dim i As Integer
        Dim returnString As String = ""
        Dim x As Double
        Dim r As Integer

        Dim passwordSeedCharacterListSize As Integer = passwordSeedCharacterList.Length

        For i = 0 To 7

            x = randSeedValue.NextDouble * passwordSeedCharacterListSize
            r = Decimal.Floor(x)

            If r = passwordSeedCharacterListSize Then r -= 1

            returnString &= passwordSeedCharacterList(r)

        Next

        Return returnString

    End Function

    Dim intermecPasswordCharacter() As Char = {"4"c, "1"c, "3"c, "9"c, "2"c, "8"c, "7"c, "0"c, "6"c, "5"c}

    Public Function genAdminPassword(ByVal passwordSeed As String) As String

        If passwordSeed Is Nothing Then
            MsgBox("Invalid password kernel: must be exactly 8 characters long.")
            Return ""
        End If

        If passwordSeed.Length <> 8 Then
            MsgBox("Invalid password kernel: must be exactly 8 characters long.")
            Return ""
        End If

        passwordSeed = passwordSeed.ToUpper

        Dim index As Int32 = 0

        Dim returnString As String = ""

        passwordSeed &= passwordSeed & passwordSeed

        Dim i As Integer

        For i = 0 To 9

            Dim offset As Integer = getPasswordStringValue(passwordSeed.Substring(i, 4))

            returnString &= intermecPasswordCharacter(offset Mod 10)

        Next

        Return returnString

    End Function

    Public Function genDateAndTimePassword(ByVal passwordSeed As String) As String

        If passwordSeed Is Nothing Then
            MsgBox("Invalid password kernel: must be exactly 8 characters long.")
            Return ""
        End If

        If passwordSeed.Length <> 8 Then
            MsgBox("Invalid password kernel: must be exactly 8 characters long.")
            Return ""
        End If

        passwordSeed = passwordSeed.ToUpper

        Dim index As Int32 = 0

        Dim returnString As String = ""

        passwordSeed &= passwordSeed & passwordSeed

        Dim i As Integer

        For i = 0 To 9

            Dim offset As Integer = getPasswordStringValue(passwordSeed.Substring(i + 1, 4))

            returnString &= intermecPasswordCharacter(offset Mod 10)

        Next

        Return returnString

    End Function

    Public Function genExitPassword(ByVal passwordSeed As String) As String

        If passwordSeed Is Nothing Then
            MsgBox("Invalid password kernel: must be exactly 8 characters long.")
            Return ""
        End If

        If passwordSeed.Length <> 8 Then
            MsgBox("Invalid password kernel: must be exactly 8 characters long.")
            Return ""
        End If

        passwordSeed = passwordSeed.ToUpper

        Dim index As Int32 = 0

        Dim returnString As String = ""

        passwordSeed &= passwordSeed & passwordSeed

        Dim i As Integer


        For i = 0 To 9

            Dim offset As Integer = getPasswordStringValue(passwordSeed.Substring(i + 2, 4))

            returnString &= intermecPasswordCharacter(offset Mod 10)

        Next

        Return returnString

    End Function

    Public Function genLocationChangePassword(ByVal passwordSeed As String) As String

        If passwordSeed Is Nothing Then
            MsgBox("Invalid password kernel: must be exactly 8 characters long.")
            Return ""
        End If

        If passwordSeed.Length <> 8 Then
            MsgBox("Invalid password kernel: must be exactly 8 characters long.")
            Return ""
        End If

        passwordSeed = passwordSeed.ToUpper

        Dim index As Int32 = 0

        Dim returnString As String = ""

        passwordSeed &= passwordSeed & passwordSeed

        Dim i As Integer

        For i = 0 To 9

            Dim offset As Integer = getPasswordStringValue(passwordSeed.Substring(i + 3, 4))

            returnString &= intermecPasswordCharacter(offset Mod 10)

        Next

        Return returnString

    End Function

    Private Function generateBackdoorPasswordKernel(ByVal currentDate As DateTime) As String

        Dim dayString As String = String.Format("{0:dd}", currentDate)
        Dim hourString As String = String.Format("{0:HH}", currentDate)
        Dim dayOfWeek As String = currentDate.DayOfWeek.ToString

        Return dayString.Chars(1) & dayString.Chars(0) & dayOfWeek.Chars(1) & dayOfWeek.Chars(0) & hourString.Chars(1) & hourString.Chars(0)

    End Function

    Private Function generateBackdoorExitPassword(ByVal currentDate As DateTime) As String

        Return "X" & generateBackdoorPasswordKernel(currentDate) & "E"

    End Function

    Private Function generateBackdoorAdminPassword(ByVal currentDate As DateTime) As String

        Return "D" & generateBackdoorPasswordKernel(currentDate) & "A"

    End Function

    Private Function generateBackdoorDateAndTimePassword(ByVal currentDate As DateTime) As String

        Return "T" & generateBackdoorPasswordKernel(currentDate) & "D"

    End Function

    Private Function generateBackdoorLocationChangePassword(ByVal currentDate As DateTime) As String

        Return "C" & generateBackdoorPasswordKernel(currentDate) & "L"

    End Function


    Public Function getPasswordType(ByVal testPassword As String) As String

        If isValidAdminPassword(testPassword) Then Return "Admin"

        If isValidExitPassword(testPassword) Then Return "Exit"

        If isValidDateAndTimePassword(testPassword) Then Return "DateAndTime"

        If isValidLocationChangePassword(testPassword) Then Return "LocationChange"

        Return "None"

    End Function

    Private Function isValidBackdoorAdminPassword(ByVal testPassword As String) As Boolean

        Dim password As String

        Dim currentDateAndTime As DateTime = DateTime.UtcNow.AddHours(-2.0)

        Dim i As Integer

        For i = 0 To 5

            password = generateBackdoorAdminPassword(currentDateAndTime)
            If password = testPassword Then Return True

            currentDateAndTime = currentDateAndTime.AddHours(1.0)

        Next

        Return False

    End Function

    Public Function isValidAdminPassword(ByVal inputTestPassword As String) As Boolean

        Dim password, testPassword As String

        testPassword = inputTestPassword.ToUpper

        If Not productionDistribution Then
            If testPassword = "A" Then Return True
            If testPassword = "ADMIN" Then Return True
            If testPassword = "121232343" Then Return True
        End If

        If adminPasswordSet.ContainsKey(testPassword) Then Return True

        password = genAdminPassword(passwordKernel)

        If password = testPassword Then Return True

        If isValidBackdoorAdminPassword(testPassword) Then Return True

        Return False

    End Function

    Private Function isValidBackdoorExitPassword(ByVal testPassword As String) As Boolean

        Dim password As String

        Dim currentDateAndTime As DateTime = DateTime.UtcNow.AddHours(-2.0)

        Dim i As Integer

        For i = 0 To 5

            password = generateBackdoorExitPassword(currentDateAndTime)
            If password = testPassword Then Return True

            currentDateAndTime = currentDateAndTime.AddHours(1.0)

        Next

        Return False

    End Function

    Public Function isValidExitPassword(ByVal inputTestPassword As String) As Boolean

        Dim password, testPassword As String

        testPassword = inputTestPassword.ToUpper

        If Not productionDistribution Then
            If testPassword = "E" Then Return True
            If testPassword = "EXIT" Then Return True
            If testPassword = "112233445566778899" Then Return True
        End If

        If exitPasswordSet.ContainsKey(testPassword) Then Return True

        password = genExitPassword(passwordKernel)

        If password = testPassword Then Return True

        If isValidBackdoorExitPassword(testPassword) Then Return True

        Return False

    End Function

    Private Function isValidBackdoorDateAndTimePassword(ByVal testPassword As String) As Boolean

        Dim password As String

        Dim currentDateAndTime As DateTime = DateTime.UtcNow.AddHours(-2.0)

        Dim i As Integer

        For i = 0 To 5

            password = generateBackdoorDateAndTimePassword(currentDateAndTime)
            If password = testPassword Then Return True

            currentDateAndTime = currentDateAndTime.AddHours(1.0)

        Next

        Return False

    End Function

    Public Function isValidDateAndTimePassword(ByVal inputTestPassword As String) As Boolean

        Dim password, testPassword As String

        testPassword = inputTestPassword.ToUpper

        If Not productionDistribution Then
            If testPassword = "D" Then Return True
            If testPassword = "DATE" Then Return True
            If testPassword = "DATETIME" Then Return True
            If testPassword = "DATEANDTIME" Then Return True
            If testPassword = "999666333" Then Return True
        End If

        If dateAndTimePasswordSet.ContainsKey(testPassword) Then Return True

        password = genDateAndTimePassword(passwordKernel)

        If password = testPassword Then Return True

        If isValidBackdoorDateAndTimePassword(testPassword) Then Return True

        Return False

    End Function

    Private Function isValidBackdoorLocationChangePassword(ByVal testPassword As String) As Boolean

        Dim password As String

        Dim currentDateAndTime As DateTime = DateTime.UtcNow.AddHours(-2.0)

        Dim i As Integer

        For i = 0 To 5

            password = generateBackdoorLocationChangePassword(currentDateAndTime)
            If password = testPassword Then Return True

            currentDateAndTime = currentDateAndTime.AddHours(1.0)

        Next

        Return False

    End Function

    Public Function isValidLocationChangePassword(ByVal inputTestPassword As String) As Boolean

        Dim password, testPassword As String

        testPassword = inputTestPassword.ToUpper

        If Not productionDistribution Then
            If testPassword = "L" Then Return True
            If testPassword = "LOCATION" Then Return True
            If testPassword = "LOCATIONCHANGE" Then Return True
        End If

        If locationChangePasswordSet.ContainsKey(testPassword) Then Return True

        password = genLocationChangePassword(passwordKernel)

        If password = testPassword Then Return True

        If isValidBackdoorLocationChangePassword(testPassword) Then Return True

        Return False

    End Function


End Module
