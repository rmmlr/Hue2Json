## Projekt in Arbeit
### Milestones
1. Auslesen und Serialisieren der Parameter :heavy_check_mark:
2. Remapping von IDs zu UniqueIDs
3. Rückspielen der Parameter

---------------------------------------------------------------------

# Hue to Json
Neben den reinen sichern (Backup) der Parameter im JSON-Format ermöglicht __Hue to JSON__ das zurück Übertragen (Restore) der ausgelesenen Parameter auf die Bridge. Somit wird die Möglichkeit geboten eine Datensicherung der Bridge anzulegen.


## Parameter
Folgende Parameter verarbeitet werden:

* Lights *Restore nicht möglich, siehe Remapping*
* Groups
* Schedules
* Scenes
* Sensors *Restore nicht möglich, siehe Remapping*
* Rules
* Configuration *Restore nur bedingt möglich*
* Capability *nur lesender Zugriff, rein Informativ*
* ResourceLinks
* WhiteList *Restore nicht möglich*


## Remapping
...

## Anonymisierung
Standardgemäß werden alle ausgelesenen __Usernames__ anonymisiert und durch generische Namen (User 1, User 2 ...) ersetzt. Eine Zuordnung der einzelnen User zu den angelegten Szenen, Regeln und Links bleibt dabei erhalten.

Optional können folgende Daten anonymisiert werden:

### Seriennummern
Alle ausgelesenen Unique-IDs, Seriennummern sowie die Ethernet-Konfiguration werden anonymisiert.

### Namen
Alle ausgelesenen Beschreibungnen und Namen einschließlich Gerätenamen werden anonymisiert.


## Programm
Hauptfenster:

![MainView 0.2a - Screenshot][MainView_0_2a]

[MainView_0_2a]: docu/img/MainView_0.2a-2.png "MainView 0.2a - Screenshot"
