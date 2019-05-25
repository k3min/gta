using System.Runtime.InteropServices;
using System.Runtime.Serialization;
using RenderWare.Extensions;
using RenderWare.Types;
using RenderWare.Loaders;

namespace RenderWare.Structures
{
	[System.Serializable]
	[StructLayout(LayoutKind.Sequential)]
	public struct PathNode : IAscii
	{
		public PathNodeType Type;
		public int NextNode;
		[MarshalAs(UnmanagedType.Bool)] public bool IsCrossRoad;
		public UnityEngine.Vector3 Center;
		public float Unknown;
		public int LanesLeft;
		public int LanesRight;

		public static PathNode Read(AsciiReader lr)
		{
			return new PathNode
			{
				Type = lr.ReadEnum<PathNodeType>(),
				NextNode = lr.ReadInt(),
				IsCrossRoad = lr.ReadBoolean(),
				Center = lr.ReadVector3(),
				Unknown = lr.ReadFloat(),
				LanesLeft = lr.ReadInt(),
				LanesRight = lr.ReadInt()
			};
		}

		public void GetObjectData(SerializationInfo info, StreamingContext context)
		{
			info.AddValue("Type", this.Type,typeof(int));
			info.AddValue("NextNode", this.NextNode);
			info.AddValue("IsCrossRoad", this.IsCrossRoad ? 1 : 0);
			info.AddValue("Center", this.Center.x, this.Center.y, this.Center.z);
			info.AddValue("Unknown", this.Unknown);
			info.AddValue("LanesLeft", this.LanesLeft);
			info.AddValue("LanesRight", this.LanesRight);
		}

		public PathNode(SerializationInfo info, StreamingContext context)
		{
			this.Type = info.GetEnum<PathNodeType>("Type", typeof(int));
			this.NextNode = info.GetInt32("NextNode");
			this.IsCrossRoad = (info.GetInt32("IsCrossRoad") != 0);
			this.Center = info.GetVector3("Center");
			this.Unknown = info.GetSingle("Unknown");
			this.LanesLeft = info.GetInt32("LanesLeft");
			this.LanesRight = info.GetInt32("LanesRight");
		}
	}
}