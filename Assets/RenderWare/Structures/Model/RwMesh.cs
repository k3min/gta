using System.Runtime.InteropServices;
using RenderWare.Loaders;

namespace RenderWare.Structures
{
	[StructLayout(LayoutKind.Sequential)]
	public struct RwMesh : IRwBinaryStream
	{
		public int IndexCount; // 0
		public int MaterialIndex; // 1

		[MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 0)]
		public int[] Indices; // 2

		public static RwMesh Read(RwBinaryReader reader)
		{
			var mesh = new RwMesh
			{
				IndexCount = reader.ReadInt(),
				MaterialIndex = reader.ReadInt()
			};

			mesh.Indices = new int[mesh.IndexCount];
			reader.Read(mesh.IndexCount, 4, ref mesh.Indices);

			return mesh;
		}
	}
}