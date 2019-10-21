@echo off
:: BatchGotAdmin
:-------------------------------------
REM  --> Check for permissions
    IF "%PROCESSOR_ARCHITECTURE%" EQU "amd64" (
>nul 2>&1 "%SYSTEMROOT%\SysWOW64\cacls.exe" "%SYSTEMROOT%\SysWOW64\config\system"
) ELSE (
>nul 2>&1 "%SYSTEMROOT%\system32\cacls.exe" "%SYSTEMROOT%\system32\config\system"
)

REM --> If error flag set, we do not have admin.
if '%errorlevel%' NEQ '0' (
    echo Requesting administrative privileges...
    goto UACPrompt
) else ( goto gotAdmin )

:UACPrompt
    echo Set UAC = CreateObject^("Shell.Application"^) > "%temp%\getadmin.vbs"
    set params= %*
    echo UAC.ShellExecute "cmd.exe", "/c ""%~s0"" %params:"=""%", "", "runas", 1 >> "%temp%\getadmin.vbs"

    "%temp%\getadmin.vbs"
    del "%temp%\getadmin.vbs"
    exit /B

:gotAdmin
    pushd "%CD%"
    CD /D "%~dp0"
:--------------------------------------  
:check_Permissions
  echo Administrative permissions required. Detecting permissions...

  net session >nul 2>&1
  if %errorLevel% == 0 (
    echo Success : Administrative permissions confirmed.
  ) else (
    echo Failure : Current permissions inadequate.
    echo Please, run this file as administrator.
  )


SET newPath=HKEY_LOCAL_MACHINE\SOFTWARE\Microsoft\NET Framework Setup\NDP\v4\Full

SET Key_Name=Version

REM query the value. pipe it through findstr in order to find the matching line that has the value
FOR /f "tokens=2,*" %%a IN ('reg query "%newPath%" /v %Key_Name% ^| findstr %Key_Name%') DO (
    SET Key_Value=%%b
)
REM extract Home drive from Win Dir path
SET Home_Drive=%windir:~0,2%
REM check registry .NET Version that required version is installed
IF "%Key_Value%"=="4.7.03062" ( 
    echo .NET Framework 4.7.2 is Installed
) ELSE (
   dotnetfx472_full_x86_x64-4.7.3081.0.exe \q \norestart
)
REM set base path for DLL
SET JCI_COM_PATH=%Home_Drive%\ProgramData\Johnson Controls\Metasys Services
if not exist "%JCI_COM_PATH%" mkdir "%JCI_COM_PATH%"
REM copy COM DLL to predefined JCI folder
xcopy  ".\.." "%JCI_COM_PATH%"
REM Register using x64 .NET Framework
cd %windir%\Microsoft.NET\Framework64\v4.0.30319
regasm "%JCI_COM_PATH%\MetasysServicesCom.dll" /tlb:"%JCI_COM_PATH%\MetasysServicesCom.tlb"

pause

