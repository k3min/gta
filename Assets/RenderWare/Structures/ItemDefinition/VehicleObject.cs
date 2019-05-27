using System.Runtime.InteropServices;
using System.Runtime.Serialization;
using RenderWare.Extensions;
using RenderWare.Types;
using RenderWare.Loaders;

namespace RenderWare.Structures
{
	[System.Serializable]
	[StructLayout(LayoutKind.Sequential)]
	public struct VehicleObject : IAscii, IItemDefinition
	{
		public const string Keyword = "cars";

		private int modelId;
		private string modelName;
		private string textureName;

		public string type;
		public string HandlingId;
		public string Name;
		public string @class;
		public int Frequency;
		public int Level;
		public int ComponentRules;

		// Car
		public int WheelModelId;
		public float WheelScale;

		// Plane
		public int LodModelId;

		public int ModelId => this.modelId;
		public string ModelName => this.modelName;
		public string TextureName => this.textureName;

		public VehicleType Type
		{
			get
			{
				switch (this.type)
				{
					case "car":
						return VehicleType.Car;

					case "boat":
						return VehicleType.Boat;

					case "train":
						return VehicleType.Train;

					case "heli":
						return VehicleType.Helicopter;

					case "plane":
						return VehicleType.Plane;

					default:
						throw new System.IndexOutOfRangeException();
				}
			}
		}

		public VehicleClass Class
		{
			get
			{
				switch (this.@class)
				{
					case "poorfamily":
						return VehicleClass.PoorFamily;

					case "richfamily":
						return VehicleClass.RichFamily;

					case "executive":
						return VehicleClass.Executive;

					case "worker":
						return VehicleClass.Worker;

					case "special":
						return VehicleClass.Special;

					case "big":
						return VehicleClass.Big;

					case "taxi":
						return VehicleClass.Taxi;

					case "ignore":
						return VehicleClass.None;

					default:
						throw new System.IndexOutOfRangeException();
				}
			}
		}

		public static VehicleObject Read(AsciiReader lr)
		{
			var info = new VehicleObject
			{
				modelId = lr.ReadInt(),
				modelName = lr.ReadString(),
				textureName = lr.ReadString(),
				type = lr.ReadString(),
				HandlingId = lr.ReadString(),
				Name = lr.ReadString(),
				@class = lr.ReadString(),
				Frequency = lr.ReadInt(),
				Level = lr.ReadInt(),
				ComponentRules = lr.ReadHex()
			};

			switch (info.Type)
			{
				case VehicleType.Car:
					info.WheelModelId = lr.ReadInt();
					info.WheelScale = lr.ReadFloat();
					break;

				case VehicleType.Plane:
					info.LodModelId = lr.ReadInt();
					break;
			}

			return info;
		}

		public void GetObjectData(SerializationInfo info, StreamingContext context)
		{
			info.AddValue("ModelId", this.modelId);
			info.AddValue("ModelName", this.modelName, typeof(string));
			info.AddValue("TextureName", this.textureName, typeof(string));
			info.AddValue("Type", this.type, typeof(string));
			info.AddValue("HandlingId", this.HandlingId, typeof(string));
			info.AddValue("Name", this.Name, typeof(string));
			info.AddValue("Class", this.@class, typeof(string));
			info.AddValue("Frequency", this.Frequency);
			info.AddValue("Level", this.Level);
			info.AddValue("ComponentRules", this.Level.ToString("X"));

			switch (this.Type)
			{
				case VehicleType.Car:
					info.AddValue("WheelModelId", this.WheelModelId);
					info.AddValue("WheelScale", this.WheelScale);
					break;

				case VehicleType.Plane:
					info.AddValue("LodModelId", this.LodModelId);
					break;
			}
		}

		public VehicleObject(SerializationInfo info, StreamingContext context)
		{
			this.modelId = info.GetInt32("ModelId");
			this.modelName = info.GetString("ModelName");
			this.textureName = info.GetString("TextureName");
			this.type = info.GetString("Type");
			this.HandlingId = info.GetString("HandlingId");
			this.Name = info.GetString("Name");
			this.@class = info.GetString("Class");
			this.Frequency = info.GetInt32("Frequency");
			this.Level = info.GetInt32("Level");
			this.ComponentRules = info.GetHex("ComponentRules");

			this.WheelModelId = default;
			this.WheelScale = default;
			this.LodModelId = default;

			switch (this.Type)
			{
				case VehicleType.Car:
					this.WheelModelId = info.GetInt32("WheelModelId");
					this.WheelScale = info.GetSingle("WheelScale");
					break;

				case VehicleType.Plane:
					this.LodModelId = info.GetInt32("LodModelId");
					break;
			}
		}
	}
}