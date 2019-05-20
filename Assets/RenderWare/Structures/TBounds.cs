using System.Runtime.InteropServices;
using RenderWare.Loaders;

namespace RenderWare.Structures
{
	[StructLayout(LayoutKind.Sequential)]
	public struct TBounds
	{
		public float Radius;
		public UnityEngine.Vector3 Center;
		public UnityEngine.Vector3 Min;
		public UnityEngine.Vector3 Max;

		public static TBounds Read(RwBinaryReader br)
		{
			return new TBounds
			{
				Radius = br.ReadFloat(),
				Center = br.ReadVector3(),
				Min = br.ReadVector3(),
				Max = br.ReadVector3()
			};
		}
	}
}