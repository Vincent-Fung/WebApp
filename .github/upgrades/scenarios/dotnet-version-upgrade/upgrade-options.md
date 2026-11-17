# Upgrade Options — WebApplication

Assessment: 1 SDK-style Razor Pages project, currently on .NET 8, upgrading to .NET 10 LTS; no incompatible packages or source-breaking API usages detected.

## Strategy

### Upgrade Strategy
A single modern .NET project with a straightforward target-framework update is best handled atomically.

| Value | Description |
|-------|-------------|
| **All-at-Once** (selected) | Aktualisiert das Projekt in einem gemeinsamen Vorgang und validiert anschließend die gesamte Solution. |
| Top-Down | Aktualisiert Anwendungen zuerst und verwendet vorübergehend Multi-Targeting für gemeinsame Bibliotheken. Für dieses Einzelprojekt nicht erforderlich. |
