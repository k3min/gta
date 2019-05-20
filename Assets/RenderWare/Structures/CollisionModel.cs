using System.IO;
using System.Runtime.InteropServices;
using RenderWare.Loaders;

namespace RenderWare.Structures
{
	[StructLayout(LayoutKind.Sequential)]
	public struct CollisionModel : IRwBinaryStream
	{
		public const string COLL = "COLL";

		[MarshalAs(UnmanagedType.LPStr, SizeConst = 4)]
		public string Magic; // 0

		public int Size; // 1

		[MarshalAs(UnmanagedType.LPStr, SizeConst = 22)]
		public string Name; // 2

		public short ModelIndex; // 3
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

		public static CollisionModel Read(RwBinaryReader ar)
		{
			var magic = ar.ReadString(4);

			if (magic != CollisionModel.COLL)
			{
				throw new InvalidDataException();
			}

			var coll = new CollisionModel
			{
				Magic = CollisionModel.COLL,
				Size = ar.ReadInt(),
				Name = ar.ReadString(22),
				ModelIndex = ar.ReadShort(),
				Bounds = TBounds.Read(ar)
			};

			coll.SphereCount = ar.ReadInt();
			coll.Spheres = ar.Read(TSphere.Read, coll.SphereCount);

			coll.Unknown = ar.ReadInt();

			coll.BoxCount = ar.ReadInt();
			coll.Boxes = ar.Read(TBox.Read, coll.BoxCount);

			coll.VertexCount = ar.ReadInt();
			coll.Vertices = ar.ReadVector3(coll.VertexCount);

			coll.FaceCount = ar.ReadInt();
			coll.Faces = ar.Read(TFace.Read, coll.FaceCount);

			return coll;
		}
	}
}