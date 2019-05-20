using System.Runtime.InteropServices;
using RenderWare.Loaders;

namespace RenderWare.Structures
{
	[StructLayout(LayoutKind.Sequential)]
	public struct TSphere
	{
		public float Radius;
		public UnityEngine.Vector3 Center;
		public TSurface Surface;

		public static TSphere Read(RwBinaryReader br)
		{
			return new TSphere
			{
				Radius = br.ReadFloat(),
				Center = br.ReadVector3(),
				Surface = TSurface.Read(br)
			};
		}
	}
}