; ====================================================================================================
; Sinemaci - Cinema Ticket Booking System
; Inno Setup Script v5.5.9 Compatible
; ====================================================================================================
; Bu script, Sinemaci uygulamasini tek bir .exe kurulum dosyasi haline getirir.
; Self-contained deployment kullanildigi icin hedef bilgisayarda .NET 8.0 kurulu olmasi gerekmez.
; ====================================================================================================

#define MyAppName "Sinemaci-V1"
#define MyAppVersion "1.0.0"
#define MyAppPublisher "Sinemaci Yazilim"
#define MyAppURL "https://github.com/ahmertsengol/SinemaBilet-DevExpress"
#define MyAppExeName "SinemaBilet.DevExpress.exe"
#define MyAppId "{{8A7D9C3E-4F2B-4A6C-9E8D-1B5C7F9A2E4D}"

[Setup]
; ====================================================================================================
; TEMEL AYARLAR
; ====================================================================================================
AppId={#MyAppId}
AppName={#MyAppName}
AppVersion={#MyAppVersion}
AppVerName={#MyAppName} {#MyAppVersion}
AppPublisher={#MyAppPublisher}
AppPublisherURL={#MyAppURL}
AppSupportURL={#MyAppURL}
AppUpdatesURL={#MyAppURL}

; ====================================================================================================
; KURULUM KLASORU VE PROGRAM GRUBU
; ====================================================================================================
DefaultDirName={pf}\{#MyAppName}
DefaultGroupName={#MyAppName}
DisableProgramGroupPage=yes

; ====================================================================================================
; CIKIS AYARLARI
; ====================================================================================================
; Setup dosyasi olusturulacak klasor (projenin bulundugu dizin)
OutputDir=C:\Users\mert-windows\Desktop\ntp-winformlar\deneme\SinemaBilet-DevExpress\Setup-Output
OutputBaseFilename=Sinemaci-Setup-v{#MyAppVersion}

; ====================================================================================================
; SIKISTIRMA VE DIGER AYARLAR
; ====================================================================================================
Compression=lzma2/max
SolidCompression=yes
WizardStyle=modern

; ====================================================================================================
; YETKI VE UYUMLULUK
; ====================================================================================================
; Windows Vista ve sonrasi icin admin yetkisi gerekli (Program Files'a kurulum icin)
PrivilegesRequired=admin
; Windows 7 ve uzeri desteklenir
MinVersion=6.1

; ====================================================================================================
; LISANS VE DOKUMANLAR (varsa)
; ====================================================================================================
; LicenseFile=C:\Users\mert-windows\Desktop\ntp-winformlar\deneme\SinemaBilet-DevExpress\LICENSE.txt
; InfoBeforeFile=C:\Users\mert-windows\Desktop\ntp-winformlar\deneme\SinemaBilet-DevExpress\README.txt

; ====================================================================================================
; IKON AYARI
; ====================================================================================================
SetupIconFile=C:\Users\mert-windows\Desktop\ntp-winformlar\deneme\SinemaBilet-DevExpress\app-icon.ico
UninstallDisplayIcon={app}\{#MyAppExeName}

; ====================================================================================================
; KALDIRMA AYARLARI
; ====================================================================================================
UninstallDisplayName={#MyAppName}
; Kaldirirken kullanici verileri (AppData) silinmez, sadece program dosyalari silinir
UninstallFilesDir={app}\Uninstall

; ====================================================================================================
; DIL AYARLARI
; ====================================================================================================
[Languages]
Name: "turkish"; MessagesFile: "compiler:Languages\Turkish.isl"

; ====================================================================================================
; GOREVLER (Kullaniciya sunulan secenekler)
; ====================================================================================================
[Tasks]
Name: "desktopicon"; Description: "Masaustunde kisayol olustur"; GroupDescription: "Ek kisayollar:"; Flags: unchecked
Name: "quicklaunchicon"; Description: "Hizli baslatma cubugunda kisayol olustur"; GroupDescription: "Ek kisayollar:"; Flags: unchecked; OnlyBelowVersion: 6.1

; ====================================================================================================
; DOSYALAR
; ====================================================================================================
; Publish klasorundeki TUM dosyalari ve alt klasorleri kopyala
[Files]
Source: "C:\Users\mert-windows\Desktop\ntp-winformlar\deneme\SinemaBilet-DevExpress\publish\*"; DestDir: "{app}"; Flags: ignoreversion recursesubdirs createallsubdirs
; NOT: "recursesubdirs" tum alt klasorleri de kopyalar (DevExpress, localization dosyalari vs.)

; ====================================================================================================
; KISAYOLLAR
; ====================================================================================================
[Icons]
; Baslat menusunde kisayol
Name: "{group}\{#MyAppName}"; Filename: "{app}\{#MyAppExeName}"
Name: "{group}\{cm:UninstallProgram,{#MyAppName}}"; Filename: "{uninstallexe}"

; Masaustu kisayolu (kullanici secerse)
Name: "{commondesktop}\{#MyAppName}"; Filename: "{app}\{#MyAppExeName}"; Tasks: desktopicon

; Hizli baslatma kisayolu (kullanici secerse, sadece Windows 7 ve alti)
Name: "{userappdata}\Microsoft\Internet Explorer\Quick Launch\{#MyAppName}"; Filename: "{app}\{#MyAppExeName}"; Tasks: quicklaunchicon

; ====================================================================================================
; KURULUM SONRASI CALISTIRMA
; ====================================================================================================
[Run]
; Kurulum tamamlandiktan sonra uygulamayi calistirma secenegi
Filename: "{app}\{#MyAppExeName}"; Description: "{cm:LaunchProgram,{#StringChange(MyAppName, '&', '&&')}}"; Flags: nowait postinstall skipifsilent

; ====================================================================================================
; KALDIRMA SONRASI TEMIZLIK (Opsiyonel)
; ====================================================================================================
[UninstallDelete]
; Kaldirma sirasinda log dosyalarini sil (eger varsa)
Type: files; Name: "{app}\*.log"

; ====================================================================================================
; KURULUM SIRASINDA CALISACAK KOD (Pascal Script)
; ====================================================================================================
[Code]
// Eski surum kontrolu - Eger eski surum varsa kaldirilmasini oner
function InitializeSetup(): Boolean;
var
  ResultCode: Integer;
  OldVersion: String;
begin
  Result := True;

  // Eski surum yuklu mu kontrol et
  if RegQueryStringValue(HKEY_LOCAL_MACHINE,
    'Software\Microsoft\Windows\CurrentVersion\Uninstall\{#MyAppId}_is1',
    'DisplayVersion', OldVersion) then
  begin
    // Eski surum bulundu
    if MsgBox('Sistemde zaten ' + '{#MyAppName}' + ' ' + OldVersion + ' surumu yuklu.' + #13#13 +
              'Yeni surumu yuklemek icin once eski surumu kaldirmaniz onerilir.' + #13#13 +
              'Eski surumu simdi kaldirmak ister misiniz?',
              mbConfirmation, MB_YESNO) = IDYES then
    begin
      // Eski surumun uninstaller'ini calistir
      if RegQueryStringValue(HKEY_LOCAL_MACHINE,
        'Software\Microsoft\Windows\CurrentVersion\Uninstall\{#MyAppId}_is1',
        'UninstallString', OldVersion) then
      begin
        Exec(RemoveQuotes(OldVersion), '/SILENT', '', SW_SHOW, ewWaitUntilTerminated, ResultCode);
      end;
    end;
  end;
end;

// Kurulum tamamlandiginda
procedure CurStepChanged(CurStep: TSetupStep);
begin
  if CurStep = ssPostInstall then
  begin
    // Kurulum tamamlandi - gerekirse ek islemler yapilabilir
    // Ornek: Veritabani klasorunu olustur (ancak uygulama bunu otomatik yapiyor)
    // ForceDirectories(ExpandConstant('{localappdata}\Sinemaci'));
  end;
end;

// Kaldirma islemi basladiginda
function InitializeUninstall(): Boolean;
begin
  Result := True;

  if MsgBox('Sinemaci uygulamasini kaldirmak istediginizden emin misiniz?' + #13#13 +
            'NOT: Kullanici verileri (veritabani) korunacaktir.',
            mbConfirmation, MB_YESNO or MB_DEFBUTTON2) = IDYES then
  begin
    Result := True;
  end
  else
  begin
    Result := False;
  end;
end;

// Kaldirma tamamlandiginda
procedure CurUninstallStepChanged(CurUninstallStep: TUninstallStep);
var
  ResultCode: Integer;
begin
  if CurUninstallStep = usPostUninstall then
  begin
    // Kullaniciya veritabanini silmek isteyip istemedigini sor
    if MsgBox('Kullanici verileri ve veritabanini da silmek ister misiniz?' + #13#13 +
              'Konum: %LOCALAPPDATA%\Sinemaci' + #13#13 +
              'Hayir secerseniz, yeniden kurdugunuzda verileriniz korunacaktir.',
              mbConfirmation, MB_YESNO or MB_DEFBUTTON2) = IDYES then
    begin
      // Veritabani klasorunu sil
      DelTree(ExpandConstant('{localappdata}\Sinemaci'), True, True, True);
    end;
  end;
end;
