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
	}
}
