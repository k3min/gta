using System.Runtime.InteropServices;
using RenderWare.Loaders;
using RenderWare.Types;

namespace RenderWare.Structures
{
	[StructLayout(LayoutKind.Sequential)]
	public struct RwMaterialList : IRwBinaryStream
	{
		public int MaterialCount; // 0
		[MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 0)]
		public int[] Instances; // 1
		[MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 0)]
		public RwMaterial[] Materials; // 2

		public static RwMaterialList Read(RwBinaryReader reader)
		{
			var materialList = new RwMaterialList
			{
				MaterialCount = reader.ReadInt()
			};

			materialList.Instances = reader.ReadInt(materialList.MaterialCount);

			materialList.Materials = new RwMaterial[materialList.MaterialCount];

			var materialIndex = 0;

			reader.ConsumeChunk((chunk) =>
			{
				switch (chunk.Type)
				{
					case SectionType.Material:
					{
						if (materialIndex < materialList.MaterialCount)
						{
							materialList.Materials[materialIndex++] = reader.Read(chunk, RwMaterial.Read);
						}

						break;
					}
				}
			});

			return materialList;
		}
	}
}