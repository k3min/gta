using System.Runtime.InteropServices;

namespace RenderWare.Structures
{
	[StructLayout(LayoutKind.Sequential)]
	public unsafe struct TFace
	{
		public const int SizeOf = (3 * 4) + TSurface.SizeOf;
		
		public fixed int Triangle[3];
		public TSurface Surface;
	}
}