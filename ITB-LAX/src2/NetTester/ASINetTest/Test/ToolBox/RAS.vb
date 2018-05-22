Namespace Test.ToolBox

    '' Enumerated all RAS connections and gets information on them
    Public Class RAS

        Private Class DLL
            Public Const RASENTRYSize As Integer = 3276
            Public Const RASENTRYNAMESize As Integer = 46

            Private Const RASBASE As Integer = 600
            Public Const ERROR_BUFFER_TOO_SMALL As Integer = RASBASE + 3

            <System.Runtime.InteropServices.DllImport("coredll.dll")> _
            Public Shared Function RasGetEntryProperties(ByVal ThePhoneBook As IntPtr, ByVal TheEntryName As String, ByVal TheEntry As Byte(), ByRef TheEntrySize As Integer, ByVal TheBPtr As IntPtr, ByVal TheBSizePtr As IntPtr) As Integer
            End Function

            <System.Runtime.InteropServices.DllImport("coredll.dll")> _
            Public Shared Function RasEnumEntries(ByVal TheNullPtr1 As IntPtr, ByVal TheNullPtr2 As IntPtr, ByVal TheEntryName() As Byte, ByRef TheEntryNameSize As Integer, ByRef TheCountWritten As Integer) As Integer
            End Function

        End Class

        '' These are bit flags for dwfOptions
        <Flags()> _
        Enum RASOptions As Integer
            RASEO_UseCountryAndAreaCodes = &H1
            RASEO_SpecificIpAddr = &H2
            RASEO_SpecificNameServers = &H4
            RASEO_IpHeaderCompression = &H8
            RASEO_RemoteDefaultGateway = &H10
            RASEO_DisableLcpExtensions = &H20
            RASEO_TerminalBeforeDial = &H40
            RASEO_TerminalAfterDial = &H80
            RASEO_ModemLights = &H100
            RASEO_SwCompression = &H200
            RASEO_RequireEncryptedPw = &H400
            RASEO_RequireMsEncryptedPw = &H800
            RASEO_RequireDataEncryption = &H1000
            RASEO_NetworkLogon = &H2000
            RASEO_UseLogonCredentials = &H4000
            RASEO_PromoteAlternates = &H8000
            RASEO_SecureLocalFiles = &H10000
            RASEO_DialAsLocalCall = &H20000
        End Enum

        '' These are bit flags for dwfNetProtocols
        <Flags()> _
        Enum RASNetProtocols As Integer
            RASNP_NetBEUI = &H1              '' Negotiate NetBEUI
            RASNP_Ipx = &H2                  '' Negotiate IPX
            RASNP_Ip = &H4                   '' Negotiate TCP/IP
        End Enum

        Enum RASFramingProtocol As Integer
            RASFP_Ppp = &H1                   '' Point-to-Point Protocol (PPP)
            RASFP_Slip = &H2                  '' Serial Line Internet Protocol (SLIP)
            RASFP_Ras = &H4                   '' Microsoft proprietary protocol
        End Enum

        Public Structure RASENTRY
            Dim dwSize As Integer
            Dim dwfOptions As RASOptions
            Dim dwCountryID As Integer
            Dim dwCountryCode As Integer
            Dim szAreaCode As String
            Dim szLocalPhoneNumber As String
            Dim dwAlternatesOffset As Integer
            Dim ipaddr As System.Net.IPAddress
            Dim ipaddrDns As System.Net.IPAddress
            Dim ipaddrDnsAlt As System.Net.IPAddress
            Dim ipaddrWins As System.Net.IPAddress
            Dim ipaddrWinsAlt As System.Net.IPAddress
            Dim dwFrameSize As Integer
            Dim dwfNetProtocols As RASNetProtocols
            Dim dwFramingProtocol As RASFramingProtocol
            Dim szScript As String
            Dim szAutoDialDll As String
            Dim szAutoDialFunc As String
            Dim szDeviceType As String
            Dim szDeviceName As String
            Dim szX25PadType As String
            Dim szX25Address As String
            Dim szX25Facilities As String
            Dim szX25UserData As String
            Dim dwChannels As Integer
            Dim dwReserved1 As Integer
            Dim dwReserved2 As Integer

            Public Overrides Function ToString() As String
                Dim SB As New System.Text.StringBuilder 'AP-082109
                SB.Append("Options: " & OptionsToString())
                SB.Append(vbCrLf)
                SB.Append("Country ID: " & dwCountryID.ToString)
                SB.Append(vbCrLf)
                SB.Append("Country code: " & dwCountryCode.ToString)
                SB.Append(vbCrLf)
                SB.Append("Area code: " & szAreaCode)
                SB.Append(vbCrLf)
                SB.Append("Local phone number: " & szLocalPhoneNumber)
                SB.Append(vbCrLf)
                SB.Append("Alternates offset: " & dwAlternatesOffset.ToString)
                SB.Append(vbCrLf)
                SB.Append("IP: " & ipaddr.ToString)
                SB.Append(vbCrLf)
                SB.Append("DNS: " & ipaddrDns.ToString)
                SB.Append(vbCrLf)
                SB.Append("DNS Alt.: " & ipaddrDnsAlt.ToString)
                SB.Append(vbCrLf)
                SB.Append("WINS: " & ipaddrWins.ToString)
                SB.Append(vbCrLf)
                SB.Append("WINS Alt.: " & ipaddrWinsAlt.ToString)
                SB.Append(vbCrLf)
                SB.Append("Frame size: " & dwFrameSize.ToString)
                SB.Append(vbCrLf)
                SB.Append("Area code: " & szAreaCode)
                SB.Append(vbCrLf)
                SB.Append("Net protocols: " & NetProtocolsToString())
                SB.Append(vbCrLf)
                SB.Append("Framing protocol: " & FramingProtocolToString())
                SB.Append(vbCrLf)
                SB.Append("Script: " & szScript)
                SB.Append(vbCrLf)
                SB.Append("Auto dial DLL: " & szAutoDialDll)
                SB.Append(vbCrLf)
                SB.Append("Auto dial function: " & szAutoDialFunc)
                SB.Append(vbCrLf)
                SB.Append("Device type: " & szDeviceType)
                SB.Append(vbCrLf)
                SB.Append("Device name: " & szDeviceName)
                SB.Append(vbCrLf)
                SB.Append("X25 pad type: " & szX25PadType)
                SB.Append(vbCrLf)
                SB.Append("X25 address: " & szX25Address)
                SB.Append(vbCrLf)
                SB.Append("X25 facilities: " & szX25Facilities)
                SB.Append(vbCrLf)
                SB.Append("X25 user data: " & szX25UserData)
                SB.Append(vbCrLf)
                SB.Append("Channels: " & dwChannels.ToString)
                SB.Append(vbCrLf)
                SB.Append("Reserved 1: " & dwReserved1.ToString)
                SB.Append(vbCrLf)
                SB.Append("Reserved 2: " & dwReserved2.ToString)
                SB.Append(vbCrLf)

                Return SB.ToString

            End Function

            Private Function OptionsToString() As String
                Dim R As String = String.Empty 'AP-082109
                If (dwfOptions And RASOptions.RASEO_DialAsLocalCall) > 0 Then
                    R &= "dial as local call, "
                End If
                If (dwfOptions And RASOptions.RASEO_DisableLcpExtensions) > 0 Then
                    R &= "disable LCP extensions, "
                End If
                If (dwfOptions And RASOptions.RASEO_IpHeaderCompression) > 0 Then
                    R &= "IP header compression, "
                End If
                If (dwfOptions And RASOptions.RASEO_ModemLights) > 0 Then
                    R &= "modem lights, "
                End If
                If (dwfOptions And RASOptions.RASEO_NetworkLogon) > 0 Then
                    R &= "network logon, "
                End If
                If (dwfOptions And RASOptions.RASEO_PromoteAlternates) > 0 Then
                    R &= "promote alternates, "
                End If
                If (dwfOptions And RASOptions.RASEO_RemoteDefaultGateway) > 0 Then
                    R &= "remote default gateway, "
                End If
                If (dwfOptions And RASOptions.RASEO_RequireDataEncryption) > 0 Then
                    R &= "require data encryption, "
                End If
                If (dwfOptions And RASOptions.RASEO_RequireEncryptedPw) > 0 Then
                    R &= "require encrypted pw, "
                End If
                If (dwfOptions And RASOptions.RASEO_RequireMsEncryptedPw) > 0 Then
                    R &= "require MS encrypted pw, "
                End If
                If (dwfOptions And RASOptions.RASEO_SecureLocalFiles) > 0 Then
                    R &= "secure local files, "
                End If
                If (dwfOptions And RASOptions.RASEO_SpecificIpAddr) > 0 Then
                    R &= "specific IP address, "
                End If
                If (dwfOptions And RASOptions.RASEO_SpecificNameServers) > 0 Then
                    R &= "specific name servers, "
                End If
                If (dwfOptions And RASOptions.RASEO_SwCompression) > 0 Then
                    R &= "software compression, "
                End If
                If (dwfOptions And RASOptions.RASEO_TerminalAfterDial) > 0 Then
                    R &= "terminal after dial, "
                End If
                If (dwfOptions And RASOptions.RASEO_TerminalBeforeDial) > 0 Then
                    R &= "terminal before dial, "
                End If
                If (dwfOptions And RASOptions.RASEO_UseCountryAndAreaCodes) > 0 Then
                    R &= "use country and area codes, "
                End If
                If (dwfOptions And RASOptions.RASEO_UseLogonCredentials) > 0 Then
                    R &= "use logon credentials, "
                End If

                R = R.TrimEnd(" "c, ","c)

                Return R

            End Function

            Private Function NetProtocolsToString() As String
                Dim R As String = String.Empty 'AP-082109
                If (dwfNetProtocols And RASNetProtocols.RASNP_Ip) > 0 Then
                    R &= "IP, "
                End If
                If (dwfNetProtocols And RASNetProtocols.RASNP_Ipx) > 0 Then
                    R &= "IPX, "
                End If
                If (dwfNetProtocols And RASNetProtocols.RASNP_NetBEUI) > 0 Then
                    R &= "NetBEUI, "
                End If

                R = R.TrimEnd(" "c, ","c)

                Return R

            End Function

            Private Function FramingProtocolToString() As String
                'AP-082109
                Dim RasFrP As String = String.Empty
                Select Case dwFramingProtocol
                    Case RASFramingProtocol.RASFP_Ppp
                        RasFrP = "PPP"
                    Case RASFramingProtocol.RASFP_Ras
                        RasFrP = "RAS"
                    Case RASFramingProtocol.RASFP_Slip
                        RasFrP = "Slip"
                End Select
                Return RasFrP
            End Function

        End Structure

        Public Structure RASENTRYNAME
            Dim dwSize As Integer
            Dim szEntryName As String
        End Structure

        '' Gets the RASENTRY
        Public Function GetRASENTRY(ByVal TheName As String) As RASENTRY
            Dim RasEntryBytes(DLL.RASENTRYSize - 1) As Byte
            Dim dwSize() As Byte = BitConverter.GetBytes(DLL.RASENTRYSize)
            Array.Copy(dwSize, 0, RasEntryBytes, 0, 4)

            Dim EntrySize As Integer = 3276
            Dim R As Integer
            Try
                R = DLL.RasGetEntryProperties(Nothing, TheName, RasEntryBytes, EntrySize, Nothing, Nothing)
            Catch ex As Exception
                '' Error retrieving RASENTRY, return blank one
                Return New RASENTRY
            End Try

            If R = 0 Then
                Return BytesToRASENTRY(RasEntryBytes)
            Else
                Return New RASENTRY 'AP-082109
            End If
        End Function

        Public Function GetRASENTRYNAMES() As RASENTRYNAME()
            Dim Result As Integer
            Dim Size As Integer
            Dim Written As Integer
            '' Get the size required
            Try
                Result = DLL.RasEnumEntries(Nothing, Nothing, Nothing, Size, Written)
            Catch ex As Exception
                '' Error, return empty array
                Return New RASENTRYNAME() {}
            End Try

            If Result = DLL.ERROR_BUFFER_TOO_SMALL Then
                '' Create byte array to hold data
                Dim Bytes(Size - 1) As Byte
                '' set dwSize
                Dim dwSize() As Byte = BitConverter.GetBytes(DLL.RASENTRYNAMESize)
                Array.Copy(dwSize, 0, Bytes, 0, 4)

                Try
                    Result = DLL.RasEnumEntries(Nothing, Nothing, Bytes, Size, Written)
                Catch ex As Exception
                    '' Error, return empty array
                    Return New RASENTRYNAME() {}
                End Try

                If Result = 0 Then
                    '' Return result in a structure array
                    Return BytesToRASENTRYNAMEs(Bytes, Written)
                Else
                    '' Error, return empty array
                    Return New RASENTRYNAME() {}
                End If
            Else
                '' Error, return empty array
                Return New RASENTRYNAME() {}
            End If

        End Function

        '' Convert bytes to a RASENTRY
        Private Function BytesToRASENTRY(ByVal TheBytes() As Byte) As RASENTRY
            If TheBytes.Length <> DLL.RASENTRYSize Then
                Throw New ApplicationException("RASENTRY is wrong size")
            End If

            Dim Idx As Integer
            Dim R As New RASENTRY

            R.dwSize = BitConverter.ToInt32(TheBytes, Idx)
            Idx += 4

            R.dwfOptions = CType(BitConverter.ToInt32(TheBytes, Idx), RASOptions)
            Idx += 4

            R.dwCountryID = BitConverter.ToInt32(TheBytes, Idx)
            Idx += 4

            R.dwCountryCode = BitConverter.ToInt32(TheBytes, Idx)
            Idx += 4

            R.szAreaCode = BytesToString(TheBytes, Idx, 22)
            Idx += 22

            R.szLocalPhoneNumber = BytesToString(TheBytes, Idx, 258)
            Idx += 258

            R.dwAlternatesOffset = BitConverter.ToInt32(TheBytes, Idx)
            Idx += 4

            R.ipaddr = New System.Net.IPAddress(BitConverter.ToInt32(TheBytes, Idx))
            Idx += 4

            R.ipaddrDns = New System.Net.IPAddress(BitConverter.ToInt32(TheBytes, Idx))
            Idx += 4

            R.ipaddrDnsAlt = New System.Net.IPAddress(BitConverter.ToInt32(TheBytes, Idx))
            Idx += 4

            R.ipaddrWins = New System.Net.IPAddress(BitConverter.ToInt32(TheBytes, Idx))
            Idx += 4

            R.ipaddrWinsAlt = New System.Net.IPAddress(BitConverter.ToInt32(TheBytes, Idx))
            Idx += 4

            R.dwFrameSize = BitConverter.ToInt32(TheBytes, Idx)
            Idx += 4

            R.dwfNetProtocols = CType(BitConverter.ToInt32(TheBytes, Idx), RASNetProtocols)
            Idx += 4

            R.dwFramingProtocol = CType(BitConverter.ToInt32(TheBytes, Idx), RASFramingProtocol)
            Idx += 4

            R.szScript = BytesToString(TheBytes, Idx, 520)
            Idx += 520

            R.szAutoDialDll = BytesToString(TheBytes, Idx, 520)
            Idx += 520

            R.szAutoDialFunc = BytesToString(TheBytes, Idx, 520)
            Idx += 520

            R.szDeviceType = BytesToString(TheBytes, Idx, 34)
            Idx += 34

            R.szDeviceName = BytesToString(TheBytes, Idx, 66)
            Idx += 66

            R.szX25PadType = BytesToString(TheBytes, Idx, 66)
            Idx += 66

            R.szX25Address = BytesToString(TheBytes, Idx, 402)
            Idx += 402

            R.szX25Facilities = BytesToString(TheBytes, Idx, 402)
            Idx += 402

            R.szX25UserData = BytesToString(TheBytes, Idx, 402)
            Idx += 402

            R.dwChannels = BitConverter.ToInt32(TheBytes, Idx)
            Idx += 4

            R.dwReserved1 = BitConverter.ToInt32(TheBytes, Idx)
            Idx += 4

            R.dwReserved2 = BitConverter.ToInt32(TheBytes, Idx)
            Idx += 4

            Return R

        End Function

        '' Convers RASENTRYNAMEs byte array to managed structure array
        Private Function BytesToRASENTRYNAMEs(ByVal TheBytes() As Byte, ByVal TheCount As Integer) As RASENTRYNAME()
            Dim Idx As Integer
            Dim R(TheCount - 1) As RASENTRYNAME

            For I As Integer = 0 To TheCount - 1
                With R(I)
                    .dwSize = BitConverter.ToInt32(TheBytes, Idx)
                    Idx += 4

                    .szEntryName = BytesToString(TheBytes, Idx, 42)
                    Idx += 42

                    Idx += 2

                End With
            Next

            Return R

        End Function

        '' Converts bytes (unicode) to string
        Private Function BytesToString(ByVal TheBytes() As Byte, ByVal TheIndex As Integer, ByVal TheLength As Integer) As String
            Dim R As String = System.Text.UnicodeEncoding.Unicode.GetString(TheBytes, TheIndex, TheLength)
            Return R.TrimEnd(Chr(0))
        End Function


    End Class

End Namespace