@echo off

REM extract Home drive from Win Dir path
SET Home_Drive=%windir:~0,2%

REM set base path for DLL
SET JCI_APP=%Home_Drive%\Program Files (x86)\Johnson Controls\Metasys Services

REM Register using x86 .NET Framework according to the client lib
cd %windir%\Microsoft.NET\Framework\v4.0.30319
regasm "%JCI_APP%\MetasysServicesCom.dll" /codebase /tlb:"%JCI_APP%\MetasysServicesCom.tlb"

cd \

REM Register using x64 .NET Framework according to the client lib
cd %windir%\Microsoft.NET\Framework64\v4.0.30319
regasm "%JCI_APP%\MetasysServicesCom.dll" /codebase /tlb:"%JCI_APP%\MetasysServicesCom.tlb"
