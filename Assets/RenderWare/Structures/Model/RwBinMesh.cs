using System.Runtime.InteropServices;
using RenderWare.Loaders;
using RenderWare.Types;

namespace RenderWare.Structures
{
	[StructLayout(LayoutKind.Sequential)]
	public struct RwBinMesh : IRwBinaryStream
	{
		public BinMeshType Type; // 0
		public int MeshCount; // 1
		public int IndexCount; // 2

		[MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 1)]
		public RwMesh[] Meshes; // 3

		public static RwBinMesh Read(RwBinaryReader reader)
		{
			var binMesh = new RwBinMesh
			{
				Type = (BinMeshType)reader.ReadInt(),
				MeshCount = reader.ReadInt(),
				IndexCount = reader.ReadInt()
			};

			binMesh.Meshes = new RwMesh[binMesh.MeshCount];
			for (var i = 0; i < binMesh.MeshCount; i++)
			{
				binMesh.Meshes[i] = RwMesh.Read(reader);
			}

			return binMesh;
		}
	}
}