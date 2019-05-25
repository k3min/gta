using System.Runtime.InteropServices;
using RenderWare.Types;
using RenderWare.Loaders;
namespace RenderWare.Structures
{
	[StructLayout(LayoutKind.Sequential)]
	public struct VehicleObject : IAscii, IItemDefinition
	{
		private int id;
		private string modelName;
		private string textureName;

		public string TypeString;
		public string HandlingId;
		public string Name;
		public string ClassString;
		public int Frequency;
		public int Level;
		public int ComponentRules;

		// Car
		public int WheelModelId;
		public float WheelScale;

		// Plane
		public int LodModelId;
		
		public int Id => this.id;
		public string ModelName => this.modelName;
		public string TextureName => this.textureName;

		public VehicleType Type
		{
			get
			{
				switch (this.TypeString)
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
				switch (this.ClassString)
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
				id = lr.ReadInt(),
				modelName = lr.ReadString(),
				textureName = lr.ReadString(),
				TypeString = lr.ReadString(),
				HandlingId = lr.ReadString(),
				Name = lr.ReadString(),
				ClassString = lr.ReadString(),
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
	}
}