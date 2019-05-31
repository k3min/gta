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

			materialList.Instances = new int[materialList.MaterialCount];
			reader.Read(materialList.MaterialCount, 4, ref materialList.Instances);

			materialList.Materials = new RwMaterial[materialList.MaterialCount];

			var materialIndex = 0;

			foreach (var chunk in reader.ConsumeChunk())
			{
				switch (chunk.Type)
				{
					case SectionType.Material:
					{
						if (materialIndex < materialList.MaterialCount)
						{
							materialList.Materials[materialIndex++] = RwMaterial.Read(reader.ReadInnerChunk(chunk));
						}

						break;
					}
				}
			}

			return materialList;
		}
	}
}