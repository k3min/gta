using System.Runtime.InteropServices;
using RenderWare.Loaders;

namespace RenderWare.Structures
{
	[StructLayout(LayoutKind.Sequential)]
	public struct TFace
	{
		[MarshalAs(UnmanagedType.ByValArray, ArraySubType = UnmanagedType.I4, SizeConst = 3)]
		public int[] Triangle;
		public TSurface Surface;

		public static TFace Read(RwBinaryReader br)
		{
			return new TFace
			{
				Triangle = br.ReadInt(3),
				Surface = TSurface.Read(br)
			};
		}
	}
}