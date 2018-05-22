<html>
<body>
<pre>
<h1>Build Log</h1>
<h3>
--------------------Configuration: icmpwrap - Win32 (WCE ARM) Release--------------------
</h3>
<h3>Command Lines</h3>
Creating temporary file "C:\DOCUME~1\Alex\LOCALS~1\Temp\RSP7F0.tmp" with contents
[
/nologo /W3 /D _WIN32_WCE=300 /D "WIN32_PLATFORM_PSPC=310" /D "ARM" /D "_ARM_" /D UNDER_CE=300 /D "UNICODE" /D "_UNICODE" /D "NDEBUG" /D "_USRDLL" /D "ICMPWRAP_EXPORTS" /Fp"ARMRel/icmpwrap.pch" /Yu"stdafx.h" /Fo"ARMRel/" /MC /c 
"c:\Documents and Settings\Alex\My Documents\svn\tagtraklocal\branches\2.6.0\src\ICMPwrap\icmpwrap.cpp"
]
Creating command line "clarm.exe @C:\DOCUME~1\Alex\LOCALS~1\Temp\RSP7F0.tmp" 
Creating temporary file "C:\DOCUME~1\Alex\LOCALS~1\Temp\RSP7F1.tmp" with contents
[
/nologo /W3 /D _WIN32_WCE=300 /D "WIN32_PLATFORM_PSPC=310" /D "ARM" /D "_ARM_" /D UNDER_CE=300 /D "UNICODE" /D "_UNICODE" /D "NDEBUG" /D "_USRDLL" /D "ICMPWRAP_EXPORTS" /Fp"ARMRel/icmpwrap.pch" /Yc"stdafx.h" /Fo"ARMRel/" /MC /c 
"c:\Documents and Settings\Alex\My Documents\svn\tagtraklocal\branches\2.6.0\src\ICMPwrap\StdAfx.cpp"
]
Creating command line "clarm.exe @C:\DOCUME~1\Alex\LOCALS~1\Temp\RSP7F1.tmp" 
Creating temporary file "C:\DOCUME~1\Alex\LOCALS~1\Temp\RSP7F2.tmp" with contents
[
commctrl.lib coredll.lib Icmplib.lib icmplib.lib winsock.lib /nologo /base:"0x00100000" /stack:0x10000,0x1000 /entry:"_DllMainCRTStartup" /dll /incremental:no /pdb:"ARMRel/icmpwrap.pdb" /nodefaultlib:"libc.lib /nodefaultlib:libcd.lib /nodefaultlib:libcmt.lib /nodefaultlib:libcmtd.lib /nodefaultlib:msvcrt.lib /nodefaultlib:msvcrtd.lib /nodefaultlib:oldnames.lib" /out:"ARMRel/icmpwrap.dll" /implib:"ARMRel/icmpwrap.lib" /subsystem:windowsce,3.00 /align:"4096" /MACHINE:ARM 
".\ARMRel\icmpwrap.obj"
".\ARMRel\StdAfx.obj"
]
Creating command line "link.exe @C:\DOCUME~1\Alex\LOCALS~1\Temp\RSP7F2.tmp"
<h3>Output Window</h3>
Compiling...
StdAfx.cpp
Compiling...
icmpwrap.cpp
Linking...
   Creating library ARMRel/icmpwrap.lib and object ARMRel/icmpwrap.exp



<h3>Results</h3>
icmpwrap.dll - 0 error(s), 0 warning(s)
</pre>
</body>
</html>
