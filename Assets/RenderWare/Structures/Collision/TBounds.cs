using System.Runtime.InteropServices;
using RenderWare.Extensions;

namespace RenderWare.Structures
{
	[StructLayout(LayoutKind.Sequential)]
	public struct TBounds
	{
		public const int SizeOf = 4 + (3 * 4) + (3 * 4) + (3 * 4);
		
		public float SphereRadius;
		public UnityEngine.Vector3 SphereCenter;

		public UnityEngine.Vector3 BoxMin;
		public UnityEngine.Vector3 BoxMax;
		
		public UnityEngine.Vector3 BoxCenter => this.BoxMin.xzy() + this.BoxExtents;
		public UnityEngine.Vector3 BoxExtents => (this.BoxMax.xzy() - this.BoxMin.xzy()) * 0.5f;
		public UnityEngine.Vector3 BoxSize => this.BoxExtents * 2f;
	}
}