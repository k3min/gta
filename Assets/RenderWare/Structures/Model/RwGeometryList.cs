using System.Runtime.InteropServices;
using RenderWare.Loaders;
using RenderWare.Types;

namespace RenderWare.Structures
{
	[StructLayout(LayoutKind.Sequential)]
	public struct RwGeometryList : IRwBinaryStream, System.IDisposable
	{
		public int GeometryCount; // 0

		[MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 0)]
		public RpGeometry[] Geometries; // 1

		public static RwGeometryList Read(RwBinaryReader reader)
		{
			var geometryList = new RwGeometryList
			{
				GeometryCount = reader.ReadInt()
			};

			geometryList.Geometries = new RpGeometry[geometryList.GeometryCount];

			var geometryIndex = 0;

			foreach (var chunk in reader.ConsumeChunk())
			{
				switch (chunk.Type)
				{
					case SectionType.Geometry:
					{
						if (geometryIndex < geometryList.GeometryCount)
						{
							geometryList.Geometries[geometryIndex++] = RpGeometry.Read(reader.ReadInnerChunk(chunk));
						}

						break;
					}
				}
			}

			return geometryList;
		}

		public void Dispose()
		{
			for (var i = 0; i < this.GeometryCount; i++)
			{
				this.Geometries[i].Dispose();
			}
		}
	}
}