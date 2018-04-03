## Projekt in Arbeit
| #  | Milestone                                | Status              |
|----|------------------------------------------|:-------------------:|
| 1. | Auslesen und Serialisieren der Parameter | :heavy_check_mark:  |
| 2. | Remapping von IDs zu UniqueIDs           |                     |
| 3. | Wiederherstellen der Parameter           |                     |

---

# Hue to Json
Neben dem reinen sichern der Parameter im JSON-Format (Backup), ermöglicht __Hue to JSON__ das Wiederherstellen der ausgelesenen Parameter auf die Bridge (Restore). Somit wird eine Möglichkeit geboten *Datensicherungen* der Bridge anzulegen.


## Parameter
Folgende Parameter können verarbeitet werden. Ausgelesen werden alle Parameter, ein Restore ist hingegen nicht vollumfänglich möglich.

| Parameter     | Beschreibung         | Restore                               |
| ------------- |----------------------|:-------------------------------------:|
| Lights        | Leuchtmittel         | [siehe Remapping](#Remapping)         |
| Groups        | Gruppen u. Räume     | :heavy_check_mark:                    |
| Schedules     | Timer                | :heavy_check_mark:                    |
| Scenes        | Szenen               | :heavy_check_mark:                    |
| Sensors       | Sensoren u. Schalter | *siehe Remapping*                     |
| Rules         | Regeln               | :heavy_check_mark:                    |
| Configuration | allg. Konfiguration  | bedingt möglich                       |
| Capability    | Speicherbelegung     | nur lesender Zugriff, rein Informativ |
| ResourceLinks | Links                | :heavy_check_mark:                    |
| WhiteList     | Benutzerliste        | :x:                                   |



## Remapping
Soll ein Backup auf einen neuen, respektive zurückgesetzten System wiederhergestellt werden, so ist es erforderlich alle Teilnehmer/Geräte (Leuchtmittel, Sensoren, Schalter, ...) manuell an die Bridge anzulernen. Hierbei vergibt die Bridge den Geräten neue IDs. Diese IDs werden intern für die Steuerung und Verknüpfung verwendet und sind somit essentiell. __Hue to JSON__ kann die *neuen IDs* auslesen und im vorhandenen Backup ein Remapping vornehmen, hierbei werden die alten IDs durch die neuen ersetzt. Da hierbei jedoch auch die UniqueIDs der Geräte herangezogen werden, bleibt die ursprüngliche Zuordnung erhalten.

## Anonymisierung
Standardgemäß werden alle ausgelesenen __Usernames__ anonymisiert und durch generische Namen (User 1, User 2 ...) ersetzt. Eine Zuordnung der einzelnen User zu den angelegten Szenen, Regeln und Links bleibt dabei erhalten.

Gerade wenn man die ausgelesenen Parameter-Dateien weiter geben möchte (z.B. zur Fehlerdiagnose), können optional Seriennummern und Namen anonymisiert werden.

### Seriennummern
Alle ausgelesenen Unique-IDs, Seriennummern sowie die Ethernet-Konfiguration werden anonymisiert.

### Namen
Alle ausgelesenen Beschreibungen und Namen einschließlich Gerätenamen werden anonymisiert.



## Programm
Hauptfenster:

![MainView 0.2a - Screenshot][MainView_0_2a]

[MainView_0_2a]: docu/img/MainView_0.2a-2.png "MainView 0.2a - Screenshot"


## Release
Dieses Projekt wird auf der Continuous Integration Plattform [AppVeyor](https://www.appveyor.com/) kompiliert und im [Release-Feed](https://github.com/rmmlr/Hue2Json/releases) veröffentlicht.

[![AppVeyor](https://img.shields.io/appveyor/ci/rmmlr/Hue2Json.svg)](https://ci.appveyor.com/project/rmmlr/hue2json)  
[![GitHub release](https://img.shields.io/github/release/rmmlr/Hue2Json.svg)](https://github.com/rmmlr/Hue2Json/releases/latest)  
[![GitHub (pre-)release](https://img.shields.io/github/release/rmmlr/Hue2Json/all.svg)](https://github.com/rmmlr/Hue2Json/releases) (Pre-)Release


## Credits
Aktuell gibt es keine weiteren Unterstützer für dieses Software-Projekt.

### Open Source Project Credits

* [Q42.HueApi](https://github.com/Q42/Q42.HueApi) Bedienung der Hue-API
* [Newtonsoft.Json](https://www.newtonsoft.com/json) Parameter-Serialisierung
* [UIkit](https://github.com/uikit/uikit) Parameter-Visualisierung

## Lizenz

Diese Software (Hue to JSON) ist lizenziert unter der [MIT Lizenz](http://www.opensource.org/licenses/mit-license.php "Read more about the MIT license form").

[![license](https://img.shields.io/github/license/rmmlr/hue2json.svg)](https://github.com/rmmlr/Hue2Json/blob/master/LICENSE) Siehe auch [LICENSE](https://github.com/rmmlr/Hue2Json/blob/master/LICENSE)
