using System.IO;
using System.Runtime.InteropServices;
using RenderWare.Extensions;
using RenderWare.Loaders;

namespace RenderWare.Structures
{
	[StructLayout(LayoutKind.Sequential)]
	public struct CollisionModel : IRwBinaryStream, System.IDisposable
	{
		public const int ModelNameLength = 24;
		public const string COLL = "COLL";

		[MarshalAs(UnmanagedType.LPStr, SizeConst = 4)]
		public string Magic; // 0

		public int Size; // 1

		[MarshalAs(UnmanagedType.LPStr, SizeConst = CollisionModel.ModelNameLength)]
		public string ModelName; // 2

		public TBounds Bounds; // 4

		public int SphereCount; // 5

		[MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 5)]
		public TSphere[] Spheres; // 6

		public int Unknown; // 7
		public int BoxCount; // 8

		[MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 8)]
		public TBox[] Boxes; // 9

		public int VertexCount; // 10

		[MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 10)]
		public UnityEngine.Vector3[] Vertices; // 11

		public int FaceCount; // 12

		[MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 12)]
		public TFace[] Faces; // 13

		[System.NonSerialized] public UnityEngine.Mesh Mesh;

		public static CollisionModel Read(RwBinaryReader ar)
		{
			var magic = ar.ReadString(4);

			if (!Helpers.EqualsCaseIgnore(magic,CollisionModel.COLL))
			{
				throw new InvalidDataException();
			}

			// ReSharper disable once UseObjectOrCollectionInitializer
			var coll = new CollisionModel
			{
				Magic = CollisionModel.COLL,
				Size = ar.ReadInt(),
				ModelName = ar.ReadString(CollisionModel.ModelNameLength),
				Bounds = ar.Read<TBounds>(TBounds.SizeOf)
			};

			coll.SphereCount = ar.ReadInt();
			coll.Spheres = ar.Read<TSphere>(coll.SphereCount, TSphere.SizeOf);

			coll.Unknown = ar.ReadInt();

			coll.BoxCount = ar.ReadInt();
			coll.Boxes = ar.Read<TBox>(coll.BoxCount, TBox.SizeOf);

			coll.VertexCount = ar.ReadInt();
			coll.Vertices = ar.Read<UnityEngine.Vector3>(coll.VertexCount, 3 * 4);

			coll.FaceCount = ar.ReadInt();
			coll.Faces = ar.Read<TFace>(coll.FaceCount, TFace.SizeOf);

			if (coll.VertexCount != 0)
			{
				coll.CreateMesh();
			}

			return coll;
		}

		private void CreateMesh()
		{
			var vertices = new UnityEngine.Vector3[this.VertexCount];

			for (var i = 0; i < this.VertexCount; i++)
			{
				vertices[i] = this.Vertices[i].xzy();
			}
			
			this.Mesh = new UnityEngine.Mesh
			{
				hideFlags = UnityEngine.HideFlags.DontSaveInEditor | UnityEngine.HideFlags.DontSaveInBuild,
				vertices = vertices
			};

			var indices = new int[this.FaceCount * 3];

			unsafe
			{
				for (var i = 0; i < this.FaceCount; i++)
				{
					for (var j = 0; j < 3; j++)
					{
						indices[(i * 3) + j] = this.Faces[i].Triangle[j];
					}
				}
			}
			
			this.Mesh.SetIndices(indices, UnityEngine.MeshTopology.Triangles, 0, true);
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