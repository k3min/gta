using System.Runtime.InteropServices;
using System.Runtime.Serialization;
using RenderWare.Extensions;
using RenderWare.Types;
using RenderWare.Loaders;

namespace RenderWare.Structures
{
	[System.Serializable]
	[StructLayout(LayoutKind.Sequential)]
	public struct PedestrianObject : IAscii, IItemDefinition
	{
		public const string Keyword = "peds";

		private int modelId;
		private string modelName;
		private string textureName;

		private string type;
		public string Behavior;
		public string AnimationGroup;

		public VehicleClass Cars;

		public int ModelId => this.modelId;
		public string ModelName => this.modelName;
		public string TextureName => this.textureName;

		public PedestrianType Type
		{
			get
			{
				switch (this.type)
				{
					case "PLAYER1":
						return PedestrianType.Player1;

					case "PLAYER2":
						return PedestrianType.Player2;

					case "PLAYER3":
						return PedestrianType.Player3;

					case "PLAYER4":
						return PedestrianType.Player4;

					case "CIVMALE":
						return PedestrianType.MaleCivilian;

					case "CIVFEMALE":
						return PedestrianType.FemaleCivilian;

					case "COP":
						return PedestrianType.Cop;

					case "GANG1":
						return PedestrianType.Gang1;

					case "GANG2":
						return PedestrianType.Gang2;

					case "GANG3":
						return PedestrianType.Gang3;

					case "GANG4":
						return PedestrianType.Gang4;

					case "GANG5":
						return PedestrianType.Gang5;

					case "GANG6":
						return PedestrianType.Gang6;

					case "GANG7":
						return PedestrianType.Gang7;

					case "GANG8":
						return PedestrianType.Gang8;

					case "GANG9":
						return PedestrianType.Gang9;

					case "EMERGENCY":
						return PedestrianType.Emergency;

					case "FIREMAN":
						return PedestrianType.Fireman;

					case "CRIMINAL":
						return PedestrianType.Criminal;

					case "_UNNAMED":
						return PedestrianType.Unnamed;

					case "PROSTITUTE":
						return PedestrianType.Prostitute;

					case "SPECIAL":
						return PedestrianType.Special;

					default:
						throw new System.IndexOutOfRangeException();
				}
			}
		}

		public static PedestrianObject Read(AsciiReader lr)
		{
			return new PedestrianObject
			{
				modelId = lr.ReadInt(),
				modelName = lr.ReadString(),
				textureName = lr.ReadString(),
				type = lr.ReadString(),
				Behavior = lr.ReadString(),
				AnimationGroup = lr.ReadString(),
				Cars = (VehicleClass)lr.ReadHex()
			};
		}

		public void GetObjectData(SerializationInfo info, StreamingContext context)
		{
			info.AddValue("ModelId", this.modelId);
			info.AddValue("ModelName", this.modelName, typeof(string));
			info.AddValue("TextureName", this.textureName, typeof(string));
			info.AddValue("Type", this.type, typeof(string));
			info.AddValue("Behavior", this.Behavior, typeof(string));
			info.AddValue("AnimationGroup", this.AnimationGroup, typeof(string));
			info.AddValue("Cars", this.Cars.ToString("X"), typeof(string));
		}

		public PedestrianObject(SerializationInfo info, StreamingContext context)
		{
			this.modelId = info.GetInt32("ModelId");
			this.modelName = info.GetString("ModelName");
			this.textureName = info.GetString("TextureName");
			this.type = info.GetString("Type");
			this.Behavior = info.GetString("Behavior");
			this.AnimationGroup = info.GetString("AnimationGroup");
			this.Cars = (VehicleClass)info.GetHex("Cars");
		}
	}
}