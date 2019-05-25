using System.Runtime.InteropServices;
using System.Runtime.Serialization;
using RenderWare.Extensions;
using RenderWare.Loaders;
using RenderWare.Types;

namespace RenderWare.Structures
{
	[System.Serializable]
	[StructLayout(LayoutKind.Sequential)]
	public struct Cull : IAscii, IItemPlacement
	{
		public const string Keyword = "cull";

		public UnityEngine.Vector3 Center;
		public UnityEngine.Vector3 Min;
		public UnityEngine.Vector3 Max;
		public CullAttributeFlags Attribute;
		public int WantedLevelDrop;

		public static Cull Read(AsciiReader ar)
		{
			return new Cull
			{
				Center = ar.ReadVector3(),
				Min = ar.ReadVector3(),
				Max = ar.ReadVector3(),
				Attribute = ar.ReadEnum<CullAttributeFlags>(),
				WantedLevelDrop = ar.ReadInt()
			};
		}
		
		public void GetObjectData(SerializationInfo info, StreamingContext context)
		{
			info.AddValue("Center", this.Center.x,this.Center.y,this.Center.z);
			info.AddValue("Min",this.Min.x,this.Min.y,this.Min.z);
			info.AddValue("Max", this.Max.x,this.Max.y,this.Max.z);
			info.AddValue("Attribute", this.Attribute,typeof(int));
			info.AddValue("WantedLevelDrop", this.WantedLevelDrop);
		}
		
		public Cull(SerializationInfo info, StreamingContext context)
		{
			this.Center = info.GetVector3("Center");
			this.Min = info.GetVector3("Min");
			this.Max = info.GetVector3("Max");
			this.Attribute = info.GetEnum<CullAttributeFlags>("Attribute", typeof(int));
			this.WantedLevelDrop = info.GetInt32("WantedLevelDrop");
		}
	}
}