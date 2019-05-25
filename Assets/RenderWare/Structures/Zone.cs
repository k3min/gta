using System.Runtime.InteropServices;
using RenderWare.Types;
using RenderWare.Loaders;

namespace RenderWare.Structures
{
	[StructLayout(LayoutKind.Sequential)]
	public struct Zone : IAscii, IItem
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
	}
}