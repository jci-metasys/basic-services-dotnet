; Inno Setup script
; Johnson Controls © 2024
; Metasys Services COM Setup

#define MyAppName "Metasys Services COM"
#define MyAppShortName "MetasysServicesCOM"
#define MyAppVersion "6.0.1"
#define MyAppPublisher "Johnson Controls"


[Setup]
PrivilegesRequired=admin
AppId={{15BD2431-783C-431B-ADFE-9B775EA5CCAD}
AppName={#MyAppName}
AppVersion={#MyAppVersion}
AppPublisher={#MyAppPublisher}
AppPublisherURL=https://www.johnsoncontrols.com/
WizardStyle=modern
;DefaultDirName={commonappdata}\{#MyAppPublisher}\Metasys Services
DefaultDirName={pf}\Johnson Controls\Metasys Services
CreateAppDir=yes
UsePreviousAppDir=no
DefaultGroupName=JCI Metasys Services
Compression=lzma2
SolidCompression=yes
DisableDirPage=yes
DisableProgramGroupPage=yes
OutputBaseFilename={#MyAppShortName}_{#MyAppVersion}_Setup
OutputDir=Output
SetupIconFile=JCSetup.ico
UninstallDisplayIcon={app}\Icons\Uninstall.ico
LicenseFile=..\..\..\LICENSE

[Messages]
SetupAppTitle =Setup {#MyAppShortName}
SetupWindowTitle ={#MyAppPublisher} - {#MyAppName} {#MyAppVersion}

[Files]
Source: ..\..\bin\release\net472\any\*; DestDir: {app}; Flags: ignoreversion recursesubdirs

[Icons]
Name: {group}\COM Libraries; Filename: {app}; IconFilename: {app}\Icons\ComLib.ico
Name: {group}\Uninstall; Filename: {uninstallexe}; IconFilename: {app}\Icons\Uninstall.ico

[Run]
; postinstall launch: registering COM DLL
Filename: {app}\Scripts\CheckDotNetFramework.bat; Flags: runhidden
Filename: {app}\Scripts\RegCom.bat; Flags: runhidden
;Filename: {win}\Microsoft.NET\Framework\v4.0.30319\RegAsm.exe; Parameters: /codebase MetasysServicesCom.dll /tlb MetasysServicesCom.tlb; WorkingDir: {app}; Flags: waituntilterminated runhidden

[UninstallRun]
; postinstall launch: unregistering COM DLL
Filename: {app}\Scripts\UnregCom.bat; Flags: runhidden
;Filename: {win}\Microsoft.NET\Framework\v4.0.30319\RegAsm.exe; Parameters: /unregister /codebase MetasysServicesCom.dll /tlb MetasysServicesCom.tlb; WorkingDir: {app}; Flags: waituntilterminated runhidden

[UninstallDelete]
; remove registered DLL tlb file outside Setup
;Type: files; Name: {app}\MetasysServicesCom.tlb


[Code]
//# Uninstall an old version before you install a new one
procedure CurStepChanged(CurStep: TSetupStep);
var
  intRes: Integer;
  strUninstall: String;
begin
	if (CurStep = ssInstall) then begin
		if RegQueryStringValue(HKLM, 'Software\Microsoft\Windows\CurrentVersion\Uninstall\{15BD2431-783C-431B-ADFE-9B775EA5CCAD}_is1', 'UninstallString', strUninstall) then begin
			Exec(RemoveQuotes(strUninstall), ' /SILENT ', '', SW_SHOWNORMAL, ewWaitUntilTerminated, intRes);
		end;
	end;
end;
