using System.Runtime.InteropServices;
using RenderWare.Loaders;

namespace RenderWare.Structures
{
	[StructLayout(LayoutKind.Sequential)]
	public struct RpTriangle : IRwBinaryStream
	{
		public short A;
		public short B;
		public short MaterialId;
		public short C;

		public static RpTriangle Read(RwBinaryReader reader)
		{
			return new RpTriangle
			{
				A = reader.ReadShort(),
				B = reader.ReadShort(),
				MaterialId = reader.ReadShort(),
				C = reader.ReadShort()
			};
		}
	}
}