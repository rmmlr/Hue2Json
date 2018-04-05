using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Q42.HueApi;
using Q42.HueApi.Models;
using Rca.Hue2Json;
using Rca.Hue2Json.Remapping;

namespace Hue2Json_Tests
{
	[TestClass]
	public class RemappingInfo_Tests
	{
		bool idPairComparer(IdPair a, IdPair b)
		{
			return String.Equals(a.UniqueId, b.UniqueId, StringComparison.InvariantCultureIgnoreCase)
				&& String.Equals(a.CurrentId, b.CurrentId, StringComparison.InvariantCultureIgnoreCase)
				&& String.Equals(a.BackupId, b.BackupId, StringComparison.InvariantCultureIgnoreCase);
		}

		[TestMethod, TestCategory("RemappingInfo")]
		public void Create()
		{
			var backup = new HueParameters
			{
				Configuration = new BridgeConfig
				{
					BridgeId = "bridge_uid001"
				},
				Lights = new List<Light>
				{
					new Light {Id = "1", UniqueId = "uid001"},
					new Light {Id = "2", UniqueId = "uid002" },
					new Light {Id = "3", UniqueId = "uid003" }
				},
				Sensors = new List<Sensor>
				{
					new Sensor {Id = "1", UniqueId = "uid001" },
					new Sensor {Id = "2", UniqueId = "uid002" }
				}
			};

			var current = new HueParameters
			{
				Configuration = new BridgeConfig
				{
					BridgeId = "bridge_uid002"
				},
				Lights = new List<Light>
				{
					new Light {Id = "2", UniqueId = "uid001"},
					new Light {Id = "3", UniqueId = "uid002"},
					new Light {Id = "4", UniqueId = "uid003"}
				},
				Sensors = new List<Sensor>
				{
					new Sensor {Id = "2", UniqueId = "uid001"}
				}
			};

			var expectedResult = new RemappingInfo
			{
				BridgeBackupUniqueId = "bridge_uid001",
				BridgeCurrentUniqueId = "bridge_uid002",
				Lights = new List<IdPair>
				{
					new IdPair {BackupId = "1", CurrentId = "2", UniqueId = "uid001"},
					new IdPair {BackupId = "2", CurrentId = "3", UniqueId = "uid002"},
					new IdPair {BackupId = "3", CurrentId = "4", UniqueId = "uid003"}
				},
				Sensors = new List<IdPair>
				{
					new IdPair {BackupId = "1", CurrentId = "2", UniqueId = "uid001"},
					new IdPair {BackupId = "2", CurrentId = null, UniqueId = "uid002"}
				}
			};




			var testObj = RemappingInfo.Create(backup, current);




			Assert.AreEqual(expectedResult.BridgeBackupUniqueId, testObj.BridgeBackupUniqueId, "Backup Unique ID der Bridge fehlerhaft");
			Assert.AreEqual(expectedResult.BridgeCurrentUniqueId, testObj.BridgeCurrentUniqueId, "Aktuelle Unique ID der Bridge fehlerhaft");

			Assert.AreEqual(expectedResult.Lights.Count, testObj.Lights.Count, "Anzahl der gemappten Light-IDs fehlerhaft");
			Assert.AreEqual(expectedResult.Sensors.Count, testObj.Sensors.Count, "Anzahl der gemappten Sensor-IDs fehlerhaft");

			for (int i = 0; i < expectedResult.Lights.Count; i++)
				Assert.IsTrue(idPairComparer(expectedResult.Lights[i], testObj.Lights[i]), "Gemappte Light-IDs fehlerhaft");
			for (int i = 0; i < expectedResult.Sensors.Count; i++)
				Assert.IsTrue(idPairComparer(expectedResult.Sensors[i], testObj.Sensors[i]), "Gemappte Sensor-IDs fehlerhaft");

		}

		[TestMethod, TestCategory("RemappingInfo")]
		public void GetIds()
		{
			var backup = new HueParameters
			{
				Configuration = new BridgeConfig
				{
					BridgeId = "bridge_uid001"
				},
				Lights = new List<Light>
				{
					new Light {Id = "1", UniqueId = "uid001"},
					new Light {Id = "2", UniqueId = "uid002" },
					new Light {Id = "3", UniqueId = "uid003" }
				},
				Sensors = new List<Sensor>
				{
					new Sensor {Id = "1", UniqueId = "uid001" },
					new Sensor {Id = "2", UniqueId = "uid002" }
				}
			};

			var current = new HueParameters
			{
				Configuration = new BridgeConfig
				{
					BridgeId = "bridge_uid002"
				},
				Lights = new List<Light>
				{
					new Light {Id = "2", UniqueId = "uid001"},
					new Light {Id = "3", UniqueId = "uid002"},
					new Light {Id = "4", UniqueId = "uid003"}
				},
				Sensors = new List<Sensor>
				{
					new Sensor {Id = "2", UniqueId = "uid001"}
				}
			};



			var testObj = RemappingInfo.Create(backup, current);


			Assert.AreEqual("2", testObj.GetCurrentLightId("1"), true, "Falsche Light-ID zur gegebenen Light-Backup-Id (1) gefunden");
			Assert.AreEqual("3", testObj.GetCurrentLightId("2"), true, "Falsche Light-ID zur gegebenen Light-Backup-Id (2) gefunden");
			Assert.AreEqual("4", testObj.GetCurrentLightId("3"), true, "Falsche Light-ID zur gegebenen Light-Backup-Id (3) gefunden");
			Assert.ThrowsException<BackupIdNotFoundException>(() => testObj.GetCurrentLightId("4"), "Fehler bei Abfrage von Light-Backup-ID (4) welche nicht verfügbar ist.");

			Assert.AreEqual("2", testObj.GetCurrentSensorId("1"), true, "Falsche Sensor-ID zur gegebenen Sensor-Backup-Id (1) gefunden");
			Assert.ThrowsException<CurrentIdNotFoundException>(() => testObj.GetCurrentSensorId("2"), "Fehler bei Abfrage von Sensor-Current-ID (2) welche nicht verfügbar ist.");
			Assert.ThrowsException<BackupIdNotFoundException>(() => testObj.GetCurrentSensorId("3"), "Fehler bei Abfrage von Sensor-Backup-ID (3) welche nicht verfügbar ist.");
		}

		[TestMethod, TestCategory("RemappingInfo")]
		public void GetIds_EmptyIdMap()
		{
			var backup = new HueParameters
			{
				Configuration = new BridgeConfig
				{
					BridgeId = "bridge_uid001"
				},
				Sensors = new List<Sensor>
				{
					new Sensor {Id = "1", UniqueId = "uid001" },
					new Sensor {Id = "2", UniqueId = "uid002" }
				}
			};

			var current = new HueParameters
			{
				Configuration = new BridgeConfig
				{
					BridgeId = "bridge_uid002"
				},
				Lights = new List<Light>
				{
					new Light {Id = "2", UniqueId = "uid001"},
					new Light {Id = "3", UniqueId = "uid002"},
					new Light {Id = "4", UniqueId = "uid003"}
				},
				Sensors = new List<Sensor>
				{
					new Sensor {Id = "2", UniqueId = "uid001"}
				}
			};



			var testObj = RemappingInfo.Create(backup, current);


			Assert.ThrowsException<EmptyIdMapException>(() => testObj.GetCurrentLightId("1"), "Leere Light-ID-Map nicht identifiziert.");
			Assert.AreEqual("2", testObj.GetCurrentSensorId("1"), true, "Falsche Sensor-ID zur gegebenen Sensor-Backup-Id (1) gefunden");
		}

		[TestMethod, TestCategory("RemappingInfo")]
		public void GetIds_DuplicatedBackupId()
		{
			var backup = new HueParameters
			{
				Configuration = new BridgeConfig
				{
					BridgeId = "bridge_uid001"
				},
				Lights = new List<Light>
				{
					new Light {Id = "1", UniqueId = "uid001"},
                    new Light {Id = "2", UniqueId = "uid002" },
                    new Light {Id = "2", UniqueId = "uid002_duplicate" },
                    new Light {Id = "3", UniqueId = "uid003" }
				}
			};

			var current = new HueParameters
			{
				Configuration = new BridgeConfig
				{
					BridgeId = "bridge_uid002"
				},
				Lights = new List<Light>
				{
					new Light {Id = "2", UniqueId = "uid001"},
					new Light {Id = "3", UniqueId = "uid002"},
					new Light {Id = "4", UniqueId = "uid003"}
				}
			};



			var testObj = RemappingInfo.Create(backup, current);


			Assert.ThrowsException<RemappingException>(() => testObj.GetCurrentLightId("2"), "Doppelte Light-Backup-ID nicht gefunden.");
            Assert.AreEqual("4", testObj.GetCurrentLightId("3"), true, "Falsche Light-ID zur gegebenen Light-Backup-Id (3) gefunden");
        }
	}
}
