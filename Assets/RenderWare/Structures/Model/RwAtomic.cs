using System.Runtime.InteropServices;
using RenderWare.Loaders;

namespace RenderWare.Structures
{
	[StructLayout(LayoutKind.Sequential)]
	public struct RwAtomic : IRwBinaryStream
	{
		public int FrameIndex;
		public int GeometryIndex;

		public int Unknown1;
		public int Unknown2;

		public static RwAtomic Read(RwBinaryReader reader)
		{
			return new RwAtomic
			{
				FrameIndex = reader.ReadInt(),
				GeometryIndex = reader.ReadInt(),
				Unknown1 = reader.ReadInt(),
				Unknown2 = reader.ReadInt()
			};
		}

		public override string ToString()
		{
			return $"FrameIndex: {this.FrameIndex}, GeometryIndex: {this.GeometryIndex}";
		}
	}
}