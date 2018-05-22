Namespace Test.ToolBox
    '' A class that outputs registry key contents. 
    '' Heavily utilizes recursion.
    Public Class Registry
        Private MyKey As Win32.RegistryKey
        Sub New(ByVal TheKey As Win32.RegistryKey)
            MyKey = TheKey
        End Sub

        '' Returns the current registry key name/value pairs and the name/value pairs of all sub keys
        Public Overrides Function ToString() As String
            Dim SB As New System.Text.StringBuilder 'AP-082109
            AppendKey(SB, MyKey, 0)
            Return SB.ToString
        End Function

        '' Appends the contents of the current key and all sub keys
        Private Sub AppendKey(ByVal TheSB As System.Text.StringBuilder, ByVal TheKey As Win32.RegistryKey, ByVal TheIndentCount As Integer) 'AP-082109
            AppendTabs(TheSB, TheIndentCount)
            TheSB.Append(TheKey.Name & ":" & vbCrLf)

            '' Output the Name/Value pairs for current key
            Dim Names() As String = TheKey.GetValueNames
            Dim Name As String
            For Each Name In Names
                Select Case TheKey.GetValueKind(Name)
                    Case Win32.RegistryValueKind.String
                        Dim Value As String = CType(TheKey.GetValue(Name), String)
                        AppendTabs(TheSB, TheIndentCount)
                        TheSB.Append(Name & " (String)" & vbCrLf)
                        AppendTabs(TheSB, TheIndentCount + 1)
                        TheSB.Append(Value & vbCrLf)

                    Case Win32.RegistryValueKind.DWord
                        Dim Value As Integer = CType(TheKey.GetValue(Name), Integer)
                        AppendTabs(TheSB, TheIndentCount)
                        TheSB.Append(Name & " (DWord)" & vbCrLf)
                        AppendTabs(TheSB, TheIndentCount + 1)
                        TheSB.Append(Value & vbCrLf)

                    Case Win32.RegistryValueKind.ExpandString
                        Dim Value As String = CType(TheKey.GetValue(Name), String)
                        AppendTabs(TheSB, TheIndentCount)
                        TheSB.Append(Name & " (ExpandedString)" & vbCrLf)
                        AppendTabs(TheSB, TheIndentCount + 1)
                        TheSB.Append(Value & vbCrLf)

                    Case Win32.RegistryValueKind.MultiString
                        Dim Value() As String = CType(TheKey.GetValue(Name), String())
                        AppendTabs(TheSB, TheIndentCount)
                        TheSB.Append(Name & " (MultiString)" & vbCrLf)
                        TheSB.Append(StringArrayToString(Value, TheIndentCount + 1))

                    Case Win32.RegistryValueKind.Binary
                        Dim Value() As Byte = CType(TheKey.GetValue(Name), Byte())
                        AppendTabs(TheSB, TheIndentCount)
                        TheSB.Append(Name & " (Binary)" & vbCrLf)
                        TheSB.Append(ByteArrayToString(Value, TheIndentCount + 1))
                End Select
            Next

            Dim SubKeyNames() As String = TheKey.GetSubKeyNames()
            Dim SubKeyName As String
            Dim SubKey As Win32.RegistryKey
            For Each SubKeyName In SubKeyNames
                SubKey = TheKey.OpenSubKey(SubKeyName, False)
                AppendKey(TheSB, SubKey, TheIndentCount + 1)
                SubKey.Close()
            Next

            Return
        End Sub

        '' Outputs the byte array to a formatted string with the given indenting (up to a maximum)
        Private Function ByteArrayToString(ByVal TheBytes() As Byte, ByVal TheIndentCount As Integer, Optional ByVal TheMaxOutput As Integer = 128) As String
            Dim SB As New System.Text.StringBuilder 'AP-082109

            '' First appent the tabs
            AppendTabs(SB, TheIndentCount)

            For I As Integer = 1 To TheBytes.Length
                '' Append each byte as a two character hex value followed by a space
                SB.Append(TheBytes(I - 1).ToString("X2") & " ")

                '' Check for maximum output
                If I = TheMaxOutput Then
                    '' Maximum output exceeded, end output
                    SB.Append(vbCrLf)
                    AppendTabs(SB, TheIndentCount)
                    SB.Append("...")
                    Exit For
                End If

                '' Put a tab on 8 byte boundry
                If I Mod 8 = 0 Then SB.Append(vbTab)

                '' Put a line break on a 16 byte boundry
                If I Mod 16 = 0 Then
                    SB.Append(vbCrLf)
                    '' Indent to the necessary width
                    AppendTabs(SB, TheIndentCount)
                End If
            Next

            '' Always end output on a new line
            SB.Append(vbCrLf)

            Return SB.ToString

        End Function

        Private Function StringArrayToString(ByVal TheStrings() As String, ByVal TheIndentCount As Integer, Optional ByVal TheMaxOutput As Integer = 5) As String
            Dim SB As New System.Text.StringBuilder 'AP-082109
            AppendTabs(SB, TheIndentCount)
            For I As Integer = 0 To TheStrings.Length - 1
                SB.Append(TheStrings(I))
                If I = TheMaxOutput Then
                    SB.Append(vbCrLf)
                    AppendTabs(SB, TheIndentCount)
                    SB.Append("...")
                    SB.Append(vbCrLf)
                    Exit For
                End If

                SB.Append(vbCrLf)
                If I <> TheStrings.Length - 1 Then AppendTabs(SB, TheIndentCount)
            Next

            Return SB.ToString

        End Function

        Private Sub AppendTabs(ByVal TheSB As System.Text.StringBuilder, ByVal TheNumber As Integer) 'AP-082109
            TheSB.Append(CChar(vbTab), TheNumber)
        End Sub

    End Class

End Namespace