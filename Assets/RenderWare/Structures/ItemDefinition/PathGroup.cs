using System.Runtime.InteropServices;
using RenderWare.Types;
using RenderWare.Loaders;

namespace RenderWare.Structures
{
	[StructLayout(LayoutKind.Sequential)]
	public struct PathGroup : IAscii
	{
		public const string Keyword = "path";
		public const int NodeCount = 12;

		public string TypeString;
		public int ModelIndex;
		public string ModelName;
		
		[MarshalAs(UnmanagedType.ByValArray, SizeConst = PathGroup.NodeCount)]
		public PathNode[] Nodes;

		public PathGroupType Type
		{
			get
			{
				switch (this.TypeString)
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

		public static PathGroup Read(AsciiReader lr)
		{
			return new PathGroup
			{
				TypeString = lr.ReadString(),
				ModelIndex = lr.ReadInt(),
				ModelName = lr.ReadString(),
				Nodes = new PathNode[PathGroup.NodeCount]
			};
		}
	}
}