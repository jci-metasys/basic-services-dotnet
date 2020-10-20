@echo off
TITLE Create the release package for Metasys Services COM
REM Go to the current directory
REM cd %~dp0/..
REM Build and pack in a zip file the release configuration of the project
dotnet build -r any -f net472 -c release

echo.  
echo Release package was created successfully.
echo.
pause