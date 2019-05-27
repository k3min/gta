using System.Runtime.InteropServices;

namespace RenderWare.Structures
{
	[StructLayout(LayoutKind.Sequential)]
	public struct TSphere
	{
		public const int SizeOf = 4 + (3 * 4) + TSurface.SizeOf;

		public float Radius;
		public UnityEngine.Vector3 Center;
		public TSurface Surface;
	}
}