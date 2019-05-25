using System.Runtime.InteropServices;
using RenderWare.Loaders;

namespace RenderWare.Structures
{
	[StructLayout(LayoutKind.Sequential)]
	public struct TBox
	{
		public UnityEngine.Vector3 Min;
		public UnityEngine.Vector3 Max;
		public TSurface Surface;

		public static TBox Read(RwBinaryReader br)
		{
			return new TBox
			{
				Min = br.ReadVector3(),
				Max = br.ReadVector3(),
				Surface = TSurface.Read(br)
			};
		}
	}
}