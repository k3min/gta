using System.Runtime.InteropServices;

namespace RenderWare.Structures
{
	[StructLayout(LayoutKind.Sequential)]
	public struct TSurface
	{
		public const int SizeOf = 1 + 1 + 1 + 1;

		public byte Material;
		public byte Flag;
		public byte Brightness;
		public byte Light;
	}
}