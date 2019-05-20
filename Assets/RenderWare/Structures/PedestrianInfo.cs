using System.Runtime.InteropServices;
using RenderWare.Types;
using RenderWare.Loaders;
namespace RenderWare.Structures
{
	[StructLayout(LayoutKind.Sequential)]
	public struct PedestrianInfo : IAscii, IObjectInfo
	{
		public TObjectInfo Info;
		public string TypeString;
		public string Behavior;
		public string AnimationGroup;
		/// <todo>[MarshalAs(UnmanagedType.Hex)]</todo>
		public VehicleClass Cars;

		public int Id => this.Info.Id;
		public string ModelName => this.Info.ModelName;
		public string TextureName => this.Info.TextureName;
		
		public PedestrianType Type
		{
			get
			{
				switch (this.TypeString)
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

		public static PedestrianInfo Read(AsciiReader lr)
		{
			return new PedestrianInfo
			{
				Info = TObjectInfo.Read(lr),
				TypeString = lr.ReadString(),
				Behavior = lr.ReadString(),
				AnimationGroup = lr.ReadString(),
				Cars = (VehicleClass)lr.ReadHex()
			};
		}
	}
}