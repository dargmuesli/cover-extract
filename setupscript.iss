#define MyAppName "CoverExtract"
#define MyAppVersion "1.0.3.0"
#define MyAppPublisher "Jonas Thelemann"
#define MyAppURL "https://jonas-thelemann.de/"
#define MyAppExeName "CoverExtract.exe"

[Setup]
AppId={{9625E872-E081-4121-BFDE-191E5BA934E6}
AppName={#MyAppName}
AppVersion={#MyAppVersion}
AppPublisher={#MyAppPublisher}
AppPublisherURL={#MyAppURL}
AppSupportURL={#MyAppURL}
AppUpdatesURL={#MyAppURL}
DefaultDirName={pf}\{#MyAppName}
DisableProgramGroupPage=yes
LicenseFile={#SourcePath}\LICENSE
OutputDir={#SourcePath}
OutputBaseFilename=CoverExtract-{#MyAppVersion}-Setup
SetupIconFile={#SourcePath}\CoverExtract\CE.ico              
UninstallDisplayIcon={#SourcePath}\CoverExtract\CE.ico
Compression=lzma
SolidCompression=yes

[Languages]
Name: "english"; MessagesFile: "compiler:Default.isl"

[Tasks]
Name: "desktopicon"; Description: "{cm:CreateDesktopIcon}"; GroupDescription: "{cm:AdditionalIcons}"; Flags: unchecked
Name: "quicklaunchicon"; Description: "{cm:CreateQuickLaunchIcon}"; GroupDescription: "{cm:AdditionalIcons}"; Flags: unchecked; OnlyBelowVersion: 0,6.1

[Files]
Source: "{#SourcePath}\CoverExtract\bin\Release\CoverExtract.exe"; DestDir: "{app}"; Flags: ignoreversion   
Source: "{#SourcePath}\CoverExtract\bin\Release\CoverExtract.exe.config"; DestDir: "{app}"; Flags: ignoreversion
Source: "{#SourcePath}\CoverExtract\bin\Release\ffmpeg.exe"; DestDir: "{app}"; Flags: ignoreversion
Source: "{#SourcePath}\CoverExtract\bin\Release\NReco.VideoConverter.dll"; DestDir: "{app}"; Flags: ignoreversion

[Icons]
Name: "{commonprograms}\{#MyAppName}"; Filename: "{app}\{#MyAppExeName}"
Name: "{commondesktop}\{#MyAppName}"; Filename: "{app}\{#MyAppExeName}"; Tasks: desktopicon
Name: "{userappdata}\Microsoft\Internet Explorer\Quick Launch\{#MyAppName}"; Filename: "{app}\{#MyAppExeName}"; Tasks: quicklaunchicon

[Run]
Filename: "{app}\{#MyAppExeName}"; Description: "{cm:LaunchProgram,{#StringChange(MyAppName, '&', '&&')}}"; Flags: nowait postinstall skipifsilent

