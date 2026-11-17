# 01-upgrade-webapp: WebApp auf .NET 10 aktualisieren

Das SDK-basierte Razor-Pages-Projekt `WebApplication/WebApp.csproj` wird einschließlich der erforderlichen Paket- und Framework-Einstellungen auf `net10.0` aktualisiert. Dabei werden die im Assessment identifizierten EF-Core-Paketupdates auf kompatible, stabile Versionen geprüft und angewendet. Die vorhandenen Nullable- und Implicit-Usings-Einstellungen bleiben erhalten; erkannte API- oder Compilerprobleme werden im betroffenen Razor-Pages-Code und in den zugehörigen C#-Dateien behoben.

Die Änderung umfasst auch die Prüfung von `global.json` und der installierten SDK-Konfiguration. Der Upgrade-Schritt bleibt auf das bestehende SDK-Style-Projekt begrenzt; eine SDK-Konvertierung oder Multi-Targeting ist nicht erforderlich.

## Research Findings

- **Betroffenes Projekt**: `WebApplication/WebApp.csproj`; ein SDK-basiertes ASP.NET-Core-Razor-Pages-Projekt mit insgesamt 20 Dateien.
- **Aktuelles Zielframework**: `net8.0`; bestätigtes Ziel: `net10.0`.
- **Projektkonfiguration**: `TargetFramework`, `Nullable` und `ImplicitUsings` sind direkt in `WebApp.csproj` definiert. Es wurden keine `global.json`, `Directory.Build.props` oder `Directory.Packages.props`-Dateien im Repository gefunden.
- **Paketverwaltung**: Standardmäßige PackageReferences, kein Central Package Management. Beide Versionen sind direkt in `WebApp.csproj` definiert:
  - `Microsoft.EntityFrameworkCore.Sqlite`: `9.0.9` → Assessment-Empfehlung `10.0.15`
  - `Microsoft.EntityFrameworkCore.Tools`: `9.0.9` → Assessment-Empfehlung `10.0.15`
- **Assessment-Issues**: `Project.0002` für die TFM-Änderung, zwei `NuGet.0002`-Empfehlungen und ein `Api.0003`-Hinweis.
- **API-Hinweis**: `WebApplication/Program.cs:20` verwendet `app.UseExceptionHandler("/Error")`. Dieser Aufruf muss nach der TFM- und Paketänderung durch den Build validiert werden; der Scan meldet eine mögliche Verhaltensänderung, aber keine entfernte oder signaturgeänderte API.
- **Stubs**: Keine `// STUB:`-Marker in C#-Dateien gefunden.
- **SDK**: Ein kompatibles .NET-10-SDK ist installiert.

**Done when**: `WebApp.csproj` zielt auf `net10.0`, alle erforderlichen Paketversionen sind kompatibel, Restore ist erfolgreich und der Build erzeugt keine Fehler oder Warnungen.
