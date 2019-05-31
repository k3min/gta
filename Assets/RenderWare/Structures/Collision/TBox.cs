using System.Runtime.InteropServices;

namespace RenderWare.Structures
{
	[StructLayout(LayoutKind.Sequential)]
	public struct TBox
	{
		public const int SizeOf = (3 * 4) + (3 * 4) + TSurface.SizeOf;

		public UnityEngine.Vector3 Min;
		public UnityEngine.Vector3 Max;
		public TSurface Surface;

		public UnityEngine.Vector3 Center => this.Min + this.Extents;
		public UnityEngine.Vector3 Extents => (this.Max - this.Min) * 0.5f;
		public UnityEngine.Vector3 Size => this.Extents * 2f;
	}
}