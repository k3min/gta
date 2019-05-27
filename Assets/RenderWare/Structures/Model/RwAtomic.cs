using System.Runtime.InteropServices;

namespace RenderWare.Structures
{
	[StructLayout(LayoutKind.Sequential)]
	public struct RwAtomic : IRwBinaryStream
	{
		public const int SizeOf = 4 + 4 + 4 + 4;

		public int FrameIndex;
		public int GeometryIndex;
		public int Unknown1;
		public int Unknown2;
	}
}