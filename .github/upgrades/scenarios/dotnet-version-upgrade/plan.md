# .NET-Version-Upgrade Plan

## Overview

**Target**: Das Razor-Pages-Projekt `WebApplication/WebApp.csproj` von .NET 8 (`net8.0`) auf .NET 10 LTS (`net10.0`) aktualisieren.
**Scope**: Eine kleine Solution mit einem SDK-basierten ASP.NET-Core-Razor-Pages-Projekt.

### Selected Strategy
**All-At-Once** — Das Projekt wird gemeinsam in einem atomaren Vorgang aktualisiert.
**Rationale**: Ein einzelnes Projekt auf modernem .NET mit klarer Projektstruktur und ohne erkannte quellcodebrechende API-Verwendungen.

## Tasks

### 01-upgrade-webapp: WebApp auf .NET 10 aktualisieren

Das SDK-basierte Razor-Pages-Projekt `WebApplication/WebApp.csproj` wird einschließlich der erforderlichen Paket- und Framework-Einstellungen auf `net10.0` aktualisiert. Dabei werden die im Assessment identifizierten EF-Core-Paketupdates auf kompatible, stabile Versionen geprüft und angewendet. Die vorhandenen Nullable- und Implicit-Usings-Einstellungen bleiben erhalten; erkannte API- oder Compilerprobleme werden im betroffenen Razor-Pages-Code und in den zugehörigen C#-Dateien behoben.

Die Änderung umfasst auch die Prüfung von `global.json` und der installierten SDK-Konfiguration. Der Upgrade-Schritt bleibt auf das bestehende SDK-Style-Projekt begrenzt; eine SDK-Konvertierung oder Multi-Targeting ist nicht erforderlich.

**Done when**: `WebApp.csproj` zielt auf `net10.0`, alle erforderlichen Paketversionen sind kompatibel, Restore ist erfolgreich und der Build erzeugt keine Fehler oder Warnungen.

---

### 02-solution-validation: Solution und Razor-Pages-Anwendung validieren

Nach dem atomaren Upgrade werden die gesamte Solution und die vorhandenen Tests validiert. Dabei werden Restore, Build und Testlauf mit den aktualisierten Abhängigkeiten ausgeführt; verbleibende Fehler oder Warnungen werden behoben und die Ergebnisse dokumentiert.

**Done when**: Die Solution baut erfolgreich und warnungsfrei, alle vorhandenen Tests bestehen und der Arbeitsstand ist für den abschließenden Upgrade-Commit bereit.
