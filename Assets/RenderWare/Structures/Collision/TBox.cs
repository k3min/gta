using System.Runtime.InteropServices;
using RenderWare.Extensions;

namespace RenderWare.Structures
{
	[StructLayout(LayoutKind.Sequential)]
	public struct TBox
	{
		public const int SizeOf = (3 * 4) + (3 * 4) + TSurface.SizeOf;
		
		public UnityEngine.Vector3 Min;
		public UnityEngine.Vector3 Max;
		public TSurface Surface;

		public UnityEngine.Vector3 Center => this.Min.xzy() + this.Extents;
		public UnityEngine.Vector3 Extents => (this.Max.xzy() - this.Min.xzy()) * 0.5f;
		public UnityEngine.Vector3 Size => this.Extents * 2f;
	}
}