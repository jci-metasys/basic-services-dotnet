@echo off
TITLE Create the release package for Metasys Services COM
REM Go to the current directory
cd %~dp0
REM Build and pack in a zip file the release configuration of the project
dotnet build -r win-x64 -f net472 -c release
REM This packet https://www.nuget.org/packages/dotnet-zip/ is needed to create the zip file
dotnet zip -r win-x64 -f net472 -c release
echo.  
echo Release package was created successfully
echo.
pause