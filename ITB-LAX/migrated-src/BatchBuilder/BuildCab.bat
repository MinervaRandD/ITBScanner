set distribution=%1

if not defined distribution (
    echo Usage: %0 ^<distribution number^>
    goto :EOF
)

del /F /Q cabs\*

REM set obfuscator="C:\Program Files\PreEmptive Solutions\Dotfuscator Professional Edition 4.1\dotfuscator.exe"

REM %obfuscator% /in:+"..\TagTrakCs\Resources\obj\Intermec Release\Resources.dll",+"..\TagTrakCs\TagTrakLib\obj\Intermec Release\TagTrakLib.dll",+"..\TagTrakCs\Baggage\obj\Intermec Release\Baggage.dll",+"..\TagTrakCs\TagTrak\obj\Intermec Release\TagTrak.exe",+"..\TagTrakCs\TagTrakLib\Support DLLs\OpenNETCF.dll",+"..\TagTrakCs\TagTrakLib\Support DLLs\Intermec.DataCollection.dll"

copy "..\TagTrakCs\Resources\obj\Intermec Release\Resources.dll" "C:\TagTrakBaggage\BatchBuilder\Dotfuscated\Resources.dll" /y
copy "..\TagTrakCs\TagTrakLib\obj\Intermec Release\TagTrakLib.dll" "C:\TagTrakBaggage\BatchBuilder\Dotfuscated\TagTrakLib.dll" /y
copy "..\TagTrakCs\Baggage\obj\Intermec Release\Baggage.dll" "C:\TagTrakBaggage\BatchBuilder\Dotfuscated\Baggage.dll" /y
copy "..\TagTrakCs\TagTrak\obj\Intermec Release\TagTrak.exe" "C:\TagTrakBaggage\BatchBuilder\Dotfuscated\TagTrak.exe" /y
copy "..\TagTrakCs\TagTrakLib\Support DLLs\OpenNETCF.dll" "C:\TagTrakBaggage\BatchBuilder\Dotfuscated\OpenNETCF.dll" /y
copy "..\TagTrakCs\TagTrakLib\Support DLLs\Intermec.DataCollection.dll" "C:\TagTrakBaggage\BatchBuilder\Dotfuscated\Intermec.DataCollection.dll" /y

set cabwiz="C:\Program Files\Microsoft Visual Studio .NET 2003\CompactFrameworkSDK\v1.0.5000\Windows CE\..\bin\..\bin\cabwiz.exe"

%cabwiz% "infs\TagTrak.inf" /dest "%cd%\cabs"
attrib +R cabs\TagTrak.cab

%cabwiz% "infs\TagTrakLib.inf" /dest "%cd%\cabs"
attrib +R cabs\TagTrakLib.cab

%cabwiz% "infs\Baggage.inf" /dest "%cd%\cabs"
attrib +R cabs\Baggage.cab

%cabwiz% "infs\Resources.inf" /dest "%cd%\cabs"
attrib +R cabs\Resources.cab

attrib +R "ARM Files\netcf.core.ppc3.arm.cab"
attrib +R "ARM Files\sqlce30.ppc.wce4.armv4.CAB"
attrib +R "ARM Files\sqlce30.repl.ppc.wce4.armv4.CAB"
attrib +R "ARM Files\System_SR_enu.cab"
attrib +R "ARM Files\NETCFv2.ppc.armv4.cab"
attrib +R "Intermec Files\PPC2002\regflush.cab"

%cabwiz% "infs\Distribution-2002.inf" /dest "C:\TagTrakBaggage\BatchBuilder\cabs"

%cabwiz% "infs\Distribution-2003.inf" /dest "C:\TagTrakBaggage\BatchBuilder\cabs"

if not exist C:\TagTrakBaggageDist\%distribution%\nul md C:\TagTrakBaggageDist\%distribution%\

copy cabs\*.cab C:\TagTrakBaggageDist\%distribution%\