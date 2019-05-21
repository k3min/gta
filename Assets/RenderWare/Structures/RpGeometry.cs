using System.Runtime.InteropServices;
using RenderWare.Extensions;
using RenderWare.Loaders;
using RenderWare.Types;

namespace RenderWare.Structures
{
	[StructLayout(LayoutKind.Sequential)]
	public struct RpGeometry : IRwBinaryStream, System.IDisposable
	{
		public GeometryFlags Flags; // 0
		public int TriangleCount; // 1
		public int VertexCount; // 2
		public int MorphTargetCount; // 3
		public float Ambient; // 4
		public float Specular; // 5
		public float Diffuse; // 6

		[MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 2)]
		public UnityEngine.Color32[] Colors; // 7

		[MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 2)]
		public UnityEngine.Vector2[] TexCoords; // 8

		[MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 1)]
		public RpTriangle[] Triangles; // 9

		public UnityEngine.BoundingSphere BoundingSphere; // 10
		
		[MarshalAs(UnmanagedType.Bool)] public bool HasVertices; // 11
		[MarshalAs(UnmanagedType.Bool)] public bool HasNormals; // 12

		[MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 2)]
		public UnityEngine.Vector3[] Vertices; // 13

		[MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 2)]
		public UnityEngine.Vector3[] Normals; // 14

		public RwMaterialList MaterialList; // 15
		public RwBinMesh BinMesh; // 16

		[System.NonSerialized] public UnityEngine.Mesh Mesh;

		public static RpGeometry Read(RwBinaryReader reader)
		{
			var geometry = new RpGeometry
			{
				Flags = reader.ReadEnum<GeometryFlags>(),
				TriangleCount = reader.ReadInt(),
				VertexCount = reader.ReadInt(),
				MorphTargetCount = reader.ReadInt(),
				// #if (version < 0x34000)
				Ambient = reader.ReadFloat(),
				Specular = reader.ReadFloat(),
				Diffuse = reader.ReadFloat()
				// #endif
			};

			if ((geometry.Flags & GeometryFlags.Native) == GeometryFlags.None)
			{
				if ((geometry.Flags & GeometryFlags.HasColors) == GeometryFlags.HasColors)
				{
					geometry.Colors = reader.ReadColor(geometry.VertexCount);
				}

				if ((geometry.Flags & GeometryFlags.HasTexCoords) == GeometryFlags.HasTexCoords)
				{
					geometry.TexCoords = reader.ReadVector2(geometry.VertexCount);
				}

				geometry.Triangles = reader.Read(RpTriangle.Read, geometry.TriangleCount);
			}

			geometry.BoundingSphere = new UnityEngine.BoundingSphere(reader.ReadVector4());

			geometry.HasVertices = reader.ReadBoolean();
			geometry.HasNormals = reader.ReadBoolean();

			if (geometry.HasVertices)
			{
				geometry.Vertices = reader.ReadVector3(geometry.VertexCount);
			}
			
			if (geometry.HasNormals)
			{
				geometry.Normals = reader.ReadVector3(geometry.VertexCount);
			}

			reader.ConsumeChunk((chunk) =>
			{
				switch (chunk.Type)
				{
					case SectionType.MaterialList:
						geometry.MaterialList = reader.Read(chunk, RwMaterialList.Read);
						break;

					case SectionType.Extension:
					{
						reader.ConsumeInnerChunk(chunk, (innerStream, extension) =>
						{
							switch (extension.Type)
							{
								case SectionType.BinMeshPlugin:
								{
									geometry.BinMesh = RwBinMesh.Read(innerStream);
									break;
								}
							}
						});

						break;
					}
				}
			});

			geometry.CreateMesh();

			return geometry;
		}

		private void CreateMesh()
		{
			var vertices = new UnityEngine.Vector3[this.VertexCount];
			var normals = new UnityEngine.Vector3[this.VertexCount];

			for (var i = 0; i < this.VertexCount; i++)
			{
				vertices[i] = this.Vertices[i].xzy();

				if ((this.Flags & GeometryFlags.HasNormals) == GeometryFlags.HasNormals)
				{
					normals[i] = this.Normals[i].xzy();
				}
			}

			this.Mesh = new UnityEngine.Mesh
			{
				hideFlags = UnityEngine.HideFlags.DontSaveInEditor | UnityEngine.HideFlags.DontSaveInBuild,
				vertices = vertices,
				normals = normals,
				subMeshCount = this.BinMesh.MeshCount
			};

			if ((this.Flags & GeometryFlags.HasTexCoords) == GeometryFlags.HasTexCoords)
			{
				this.Mesh.uv = this.TexCoords;
			}

			if ((this.Flags & GeometryFlags.HasColors) == GeometryFlags.HasColors)
			{
				var colors = new UnityEngine.Color[this.VertexCount];

				for (var i = 0; i < this.VertexCount; i++)
				{
					colors[i] = this.Colors[i];
				}

				this.Mesh.colors = colors;
			}

			for (var i = 0; i < this.BinMesh.MeshCount; i++)
			{
				var mesh = this.BinMesh.Meshes[i];

				var indices = new int[mesh.IndexCount];

				for (var j = 0; j < mesh.IndexCount; j++)
				{
					indices[j] = mesh.Indices[(mesh.IndexCount - 1) - j];
				}

				var index = mesh.MaterialIndex;

				switch (this.BinMesh.Type)
				{
					case BinMeshType.TriangleList:
						this.Mesh.SetIndices(indices, UnityEngine.MeshTopology.Triangles, index, true);
						break;

					case BinMeshType.TriangleStrip:
						this.Mesh.SetIndices(indices, (UnityEngine.MeshTopology)1, index, true);
						break;
				}
			}

			if ((this.Flags & GeometryFlags.HasNormals) != GeometryFlags.HasNormals)
			{
				this.Mesh.RecalculateNormals();
			}

			this.Mesh.UploadMeshData(true);
		}

		public void Dispose()
		{
			if (this.Mesh != null)
			{
				UnityEngine.Object.DestroyImmediate(this.Mesh);
				this.Mesh = null;
			}
		}
	}
}