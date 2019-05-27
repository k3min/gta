using System.Runtime.InteropServices;

namespace RenderWare.Structures
{
	[StructLayout(LayoutKind.Sequential)]
	public struct RpTriangle : IRwBinaryStream
	{
		public const int SizeOf = 2 + 2 + 2 + 2;

		public short A;
		public short B;
		public short MaterialId;
		public short C;
	}
}