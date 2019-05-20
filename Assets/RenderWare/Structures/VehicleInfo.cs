using System.Runtime.InteropServices;
using RenderWare.Types;
using RenderWare.Loaders;
namespace RenderWare.Structures
{
	[StructLayout(LayoutKind.Sequential)]
	public struct VehicleInfo : IAscii, IObjectInfo
	{
		public TObjectInfo Info;
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
		
		public int Id => this.Info.Id;
		public string ModelName => this.Info.ModelName;
		public string TextureName => this.Info.TextureName;

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

		public static VehicleInfo Read(AsciiReader lr)
		{
			var info = new VehicleInfo
			{
				Info = TObjectInfo.Read(lr),
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