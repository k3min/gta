using System.Runtime.InteropServices;
using RenderWare.Types;
using RenderWare.Loaders;
namespace RenderWare.Structures
{
	[StructLayout(LayoutKind.Sequential)]
	public struct PathNode : IAscii
	{
		public PathNodeType Type;
		public int NextNode;
		[MarshalAs(UnmanagedType.Bool)]
		public bool IsCrossRoad;
		public UnityEngine.Vector3 Center;
		public float Unknown;
		public int LanesLeft;
		public int LanesRight;

		public static PathNode Read(AsciiReader lr)
		{
			return new PathNode
			{
				Type = (PathNodeType)lr.ReadInt(),
				NextNode = lr.ReadInt(),
				IsCrossRoad = lr.ReadBoolean(),
				Center = lr.ReadVector3(),
				Unknown = lr.ReadFloat(),
				LanesLeft = lr.ReadInt(),
				LanesRight = lr.ReadInt()
			};
		}
	}
}