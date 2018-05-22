<html>
<body>
<pre>
<h1>Build Log</h1>
<h3>
--------------------Configuration: AirlineSoftware - Win32 (WCE x86) Debug--------------------
</h3>
<h3>Command Lines</h3>
Creating temporary file "C:\DOCUME~1\DECISI~1\LOCALS~1\Temp\RSP138.tmp" with contents
[
/nologo /W3 /Zi /Od /D "DEBUG" /D _WIN32_WCE=300 /D "WIN32_PLATFORM_PSPC=310" /D "_i386_" /D UNDER_CE=300 /D "UNICODE" /D "_UNICODE" /D "_X86_" /D "x86" /D "_USRDLL" /D "AIRLINESOFTWARE_EXPORTS" /Fp"X86Dbg/AirlineSoftware.pch" /Yu"stdafx.h" /Fo"X86Dbg/" /Fd"X86Dbg/" /Gs8192 /GF /c 
"C:\Airline Software\Projects\USPS Mail\USPS Mail.Dev.New\Lib\MD5 Lib\Md5.cpp"
]
Creating command line "cl.exe @C:\DOCUME~1\DECISI~1\LOCALS~1\Temp\RSP138.tmp" 
Creating temporary file "C:\DOCUME~1\DECISI~1\LOCALS~1\Temp\RSP139.tmp" with contents
[
commctrl.lib coredll.lib corelibc.lib /nologo /base:"0x00100000" /stack:0x10000,0x1000 /entry:"_DllMainCRTStartup" /dll /incremental:yes /pdb:"X86Dbg/AirlineSoftware.pdb" /debug /nodefaultlib:"OLDNAMES.lib" /nodefaultlib:libc.lib /nodefaultlib:libcd.lib /nodefaultlib:libcmt.lib /nodefaultlib:libcmtd.lib /nodefaultlib:msvcrt.lib /nodefaultlib:msvcrtd.lib /nodefaultlib:oldnames.lib /out:"X86Dbg/AirlineSoftware.dll" /implib:"X86Dbg/AirlineSoftware.lib" /subsystem:windowsce,3.00 /MACHINE:IX86 
".\X86Dbg\Md5.obj"
".\X86Dbg\StdAfx.obj"
]
Creating command line "link.exe @C:\DOCUME~1\DECISI~1\LOCALS~1\Temp\RSP139.tmp"
<h3>Output Window</h3>
Compiling...
Md5.cpp
Linking...
   Creating library X86Dbg/AirlineSoftware.lib and object X86Dbg/AirlineSoftware.exp




<h3>Results</h3>
AirlineSoftware.dll - 0 error(s), 0 warning(s)
</pre>
</body>
</html>
