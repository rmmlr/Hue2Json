# Hue to Json
Speichert alle Parameter eines Hue-Systems in einer JSON-Datei.

## Parameter
Folgende Parameter können angewählt werden:

* Lights
* Groups
* Schedules
* Scenes
* Sensors
* Rules
* Configuration
* Capability
* ResourceLinks
* WhiteList

## Anonymisierung
Standardgemäß werden alle ausgelesenen __Usernames__ anonymisiert und durch generische Namen (User 1, User 2 ...) ersetzt. Eine Zuordnung der einzelnen User zu den angelegten Szenen, Regeln und Links bleibt dabei erhalten.

Optional können folgende Daten anonymisiert werden:

### Seriennummern
Alle ausgelesenen Unique-IDs, Seriennummern sowie die Ethernet-Konfiguration werden anonymisiert.

### Namen
Alle ausgelesenen Beschreibungnen und Namen einschließlich Gerätenamen werden anonymisiert.

## Programm
Hauptfenster:

![MainView 0.2a - Screenshot][MainView_0_1a]

[MainView_0_1a]: docu/img/MainView_0.2a.png "MainView 0.2a - Screenshot"
