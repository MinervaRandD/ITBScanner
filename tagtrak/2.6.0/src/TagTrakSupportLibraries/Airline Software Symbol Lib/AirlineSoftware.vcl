<html>
<body>
<pre>
<h1>Build Log</h1>
<h3>
--------------------Configuration: AirlineSoftware - Win32 (WCE ARM) Release--------------------
</h3>
<h3>Command Lines</h3>
Creating temporary file "C:\DOCUME~1\max\LOCALS~1\Temp\RSP2B7.tmp" with contents
[
/nologo /W3 /D _WIN32_WCE=300 /D "WIN32_PLATFORM_PSPC=310" /D "ARM" /D "_ARM_" /D UNDER_CE=300 /D "UNICODE" /D "_UNICODE" /D "NDEBUG" /D "_USRDLL" /D "AIRLINESOFTWARE_EXPORTS" /FR"ARMRel/" /Fp"ARMRel/AirlineSoftware.pch" /Yu"stdafx.h" /Fo"ARMRel/" /Oxs /MC /c 
"C:\TagTrakMainBranch\TagTrak Support Libraries\Airline Software Symbol Lib\AirlineSoftware.cpp"
"C:\TagTrakMainBranch\TagTrak Support Libraries\Airline Software Symbol Lib\rijndael.cpp"
]
Creating command line "clarm.exe @C:\DOCUME~1\max\LOCALS~1\Temp\RSP2B7.tmp" 
Creating temporary file "C:\DOCUME~1\max\LOCALS~1\Temp\RSP2B8.tmp" with contents
[
/nologo /W3 /D _WIN32_WCE=300 /D "WIN32_PLATFORM_PSPC=310" /D "ARM" /D "_ARM_" /D UNDER_CE=300 /D "UNICODE" /D "_UNICODE" /D "NDEBUG" /D "_USRDLL" /D "AIRLINESOFTWARE_EXPORTS" /FR"ARMRel/" /Fp"ARMRel/AirlineSoftware.pch" /Yc"stdafx.h" /Fo"ARMRel/" /Oxs /MC /c 
"C:\TagTrakMainBranch\TagTrak Support Libraries\Airline Software Symbol Lib\StdAfx.cpp"
]
Creating command line "clarm.exe @C:\DOCUME~1\max\LOCALS~1\Temp\RSP2B8.tmp" 
Creating temporary file "C:\DOCUME~1\max\LOCALS~1\Temp\RSP2B9.tmp" with contents
[
commctrl.lib coredll.lib itcuuid.lib ITCAdcDevMgmt.lib /nologo /base:"0x00100000" /stack:0x10000,0x1000 /entry:"_DllMainCRTStartup" /dll /incremental:no /pdb:"ARMRel/AirlineSoftware.pdb" /nodefaultlib:"libc.lib /nodefaultlib:libcd.lib /nodefaultlib:libcmt.lib /nodefaultlib:libcmtd.lib /nodefaultlib:msvcrt.lib /nodefaultlib:msvcrtd.lib /nodefaultlib:oldnames.lib" /out:"ARMRel/AirlineSoftware.dll" /implib:"ARMRel/AirlineSoftware.lib" /subsystem:windowsce,3.00 /align:"4096" /MACHINE:ARM 
".\ARMRel\AirlineSoftware.obj"
".\ARMRel\rijndael.obj"
".\ARMRel\StdAfx.obj"
]
Creating command line "link.exe @C:\DOCUME~1\max\LOCALS~1\Temp\RSP2B9.tmp"
<h3>Output Window</h3>
Compiling...
StdAfx.cpp
Compiling...
AirlineSoftware.cpp
C:\TagTrakMainBranch\TagTrak Support Libraries\Airline Software Symbol Lib\IS9Cconfig.h(580) : warning C4786: '?GetPDF417@IS9CConfig@@UAAJPAW4tagPdf417Decoding@@PAW4tagPdf417MacroPdf@@PAW4tagPdf417ControlHeader@@PAW4tagPdf417FileName@@PAW4tagPdf417SegmentCount@@PAW4tagPdf417TimeStamp@@PAW4tagPdf417Sender@@PAW4tagPdf417Addressee@@PAW4tagPdf417FileSize@@PAW4tagPdf417Checksum@@@Z' : identifier was truncated to '255' characters in the browser information
C:\TagTrakMainBranch\TagTrak Support Libraries\Airline Software Symbol Lib\IS9Cconfig.h(645) : warning C4786: '?GetUpcEan@IS9CConfig@@UAAJPAW4tagUpcEanDecoding@@PAW4tagUpcASelect@@PAW4tagUpcESelect@@PAW4tagEan8Select@@PAW4tagEan13Select@@PAW4tagUpcEanAddonDigits@@PAW4tagUpcEanAddonTwo@@PAW4tagUpcEanAddonFive@@PAW4tagUpcACheckDigit@@PAW4tagUpcECheckDigit@@PAW4tagEan8CheckDigit@@PAW4tagEan13CheckDigit@@PAW4tagUpcANumberSystem@@PAW4tagUpcENumberSystem@@PAW4tagUpcAReencode@@PAW4tagUpcEReencode@@PAW4tagEan8Reencode@@@Z' : identifier was truncated to '255' characters in the browser information
C:\TagTrakMainBranch\TagTrak Support Libraries\Airline Software Symbol Lib\IS9Cconfig.h(664) : warning C4786: '?SetUpcEan@IS9CConfig@@UAAJW4tagUpcEanDecoding@@W4tagUpcASelect@@W4tagUpcESelect@@W4tagEan8Select@@W4tagEan13Select@@W4tagUpcEanAddonDigits@@W4tagUpcEanAddonTwo@@W4tagUpcEanAddonFive@@W4tagUpcACheckDigit@@W4tagUpcECheckDigit@@W4tagEan8CheckDigit@@W4tagEan13CheckDigit@@W4tagUpcANumberSystem@@W4tagUpcENumberSystem@@W4tagUpcAReencode@@W4tagUpcEReencode@@W4tagEan8Reencode@@@Z' : identifier was truncated to '255' characters in the browser information
rijndael.cpp
C:\TagTrakMainBranch\TagTrak Support Libraries\Airline Software Symbol Lib\rijndael.cpp(1378) : warning C4018: '<=' : signed/unsigned mismatch
C:\TagTrakMainBranch\TagTrak Support Libraries\Airline Software Symbol Lib\rijndael.cpp(1393) : warning C4018: '<=' : signed/unsigned mismatch
C:\TagTrakMainBranch\TagTrak Support Libraries\Airline Software Symbol Lib\rijndael.cpp(1421) : warning C4018: '<=' : signed/unsigned mismatch
C:\TagTrakMainBranch\TagTrak Support Libraries\Airline Software Symbol Lib\rijndael.cpp(1441) : warning C4018: '<' : signed/unsigned mismatch
C:\TagTrakMainBranch\TagTrak Support Libraries\Airline Software Symbol Lib\rijndael.cpp(1479) : warning C4018: '<' : signed/unsigned mismatch
Generating Code...
C:\TagTrakMainBranch\TagTrak Support Libraries\Airline Software Symbol Lib\AirlineSoftware.cpp(115) : warning C4700: local variable 'pS9CConfig' used without having been initialized
C:\TagTrakMainBranch\TagTrak Support Libraries\Airline Software Symbol Lib\AirlineSoftware.cpp(124) : warning C4700: local variable 'pS9CConfig' used without having been initialized
Linking...
   Creating library ARMRel/AirlineSoftware.lib and object ARMRel/AirlineSoftware.exp




<h3>Results</h3>
AirlineSoftware.dll - 0 error(s), 10 warning(s)
</pre>
</body>
</html>
