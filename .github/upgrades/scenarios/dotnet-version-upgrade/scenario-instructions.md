# .NET-Version-Upgrade

## Preferences
- **Flow Mode**: Guided
- **Scope**: Gesamte Solution
- **Projekt**: `WebApplication/WebApp.csproj`
- **Ausgangsframework**: `net8.0`
- **Zielframework**: `net10.0` (.NET 10 LTS)

## Source Control
- **Source Branch**: upgrade-nuget-packages
- **Working Branch**: upgrade-dotnet-10
- **Pending Changes**: Vor dem Upgrade in Commit `34ae774` gesichert
- **Commit Strategy**: Single Commit at End
- **Branch Sync**: Disabled

## Upgrade Options
**Source**: .github/upgrades/scenarios/dotnet-version-upgrade/upgrade-options.md

### Strategy
- Upgrade Strategy: All-at-Once

## Strategy
**Selected**: All-at-Once
**Rationale**: Einzelnes SDK-basiertes Razor-Pages-Projekt auf modernem .NET; die Analyse ergab keine inkompatiblen Pakete oder quellcodebrechenden API-Verwendungen.

### Execution Constraints
- Das Projekt und alle erforderlichen Paketänderungen werden in einem atomaren Upgrade-Vorgang aktualisiert.
- Das vollständige Restore und der Solution-Build erfolgen nach den Projektänderungen.
- Alle Compilerfehler und Warnungen werden vor Abschluss behoben.
- Tests werden nach erfolgreichem Build ausgeführt.
- Der Upgrade-Commit wird am Ende des Vorgangs erstellt.

## Build Tool Decisions
- **WebApplication/WebApp.csproj**: `dotnet build` (SDK-style, modernes .NET, keine speziellen MSBuild-Anforderungen)
