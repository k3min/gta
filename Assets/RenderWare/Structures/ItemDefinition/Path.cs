using System.Runtime.InteropServices;
using System.Runtime.Serialization;
using RenderWare.Types;
using RenderWare.Loaders;

namespace RenderWare.Structures
{
	[System.Serializable]
	[StructLayout(LayoutKind.Sequential)]
	public struct Path : IAscii, IAttachment
	{
		public const string Keyword = "path";
		public const int NodeCount = 12;

		private string groupType;
		public int ObjectId;
		public string ModelName;

		[MarshalAs(UnmanagedType.ByValArray, SizeConst = Path.NodeCount)]
		public PathNode[] Nodes;

		public PathGroupType GroupType
		{
			get
			{
				switch (this.groupType)
				{
					case "ped":
						return PathGroupType.Pedestrian;

					case "car":
						return PathGroupType.Road;

					default:
						throw new System.IndexOutOfRangeException();
				}
			}
		}

		public static Path Read(AsciiReader lr)
		{
			return new Path
			{
				groupType = lr.ReadString(),
				ObjectId = lr.ReadInt(),
				ModelName = lr.ReadString(),
				Nodes = new PathNode[Path.NodeCount]
			};
		}

		public void GetObjectData(SerializationInfo info, StreamingContext context)
		{
			info.AddValue("GroupType", this.groupType, typeof(string));
			info.AddValue("ObjectId", this.ObjectId);
			info.AddValue("ModelName", this.ModelName, typeof(string));
		}

		public Path(SerializationInfo info, StreamingContext context)
		{
			this.groupType = info.GetString("GroupType");
			this.ObjectId = info.GetInt32("ObjectId");
			this.ModelName = info.GetString("ModelName");

			this.Nodes = new PathNode[Path.NodeCount];
		}
	}
}