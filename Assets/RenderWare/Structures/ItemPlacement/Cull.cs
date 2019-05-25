using System.Runtime.InteropServices;
using RenderWare.Loaders;
using RenderWare.Types;

namespace RenderWare.Structures
{
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
	}
}