using System.Runtime.InteropServices;
using System.Runtime.Serialization;
using RenderWare.Extensions;
using RenderWare.Types;
using RenderWare.Loaders;

namespace RenderWare.Structures
{
	[System.Serializable]
	[StructLayout(LayoutKind.Sequential)]
	public struct Zone : IAscii, IItemPlacement
	{
		public const string Keyword = "zone";

		public string Name;
		public int Type;
		public UnityEngine.Vector3 Min;
		public UnityEngine.Vector3 Max;
		public ZoneType Level;

		public static Zone Read(AsciiReader ar)
		{
			return new Zone
			{
				Name = ar.ReadString(),
				Type = ar.ReadInt(),
				Min = ar.ReadVector3(),
				Max = ar.ReadVector3(),
				Level = ar.ReadEnum<ZoneType>()
			};
		}

		public void GetObjectData(SerializationInfo info, StreamingContext context)
		{
			info.AddValue("Name", this.Name, typeof(string));
			info.AddValue("Type", this.Type);
			info.AddValue("Min", this.Min.x, this.Min.y, this.Min.z);
			info.AddValue("Max", this.Max.x, this.Max.y, this.Max.z);
			info.AddValue("Level", this.Level,typeof(int));
		}

		public Zone(SerializationInfo info, StreamingContext context)
		{
			this.Name = info.GetString("Name");
			this.Type = info.GetInt32("Type");
			this.Min = info.GetVector3("Min");
			this.Max = info.GetVector3("Max");
			this.Level = info.GetEnum<ZoneType>("Level", typeof(int));
		}
	}
}