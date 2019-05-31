using System.Runtime.InteropServices;
using RenderWare.Loaders;
using RenderWare.Types;

namespace RenderWare.Structures
{
	[StructLayout(LayoutKind.Sequential)]
	public struct RwMaterial : IRwBinaryStream
	{
		public int Flags;
		public UnityEngine.Color32 Color;
		public int Unknown;
		[MarshalAs(UnmanagedType.Bool)] public bool IsTextured;
		public float Ambient;
		public float Specular;
		public float Diffuse;
		public RwTexture Texture;

		public static RwMaterial Read(RwBinaryReader reader)
		{
			var material = new RwMaterial
			{
				Flags = reader.ReadInt()
			};

			reader.Read(4, ref material.Color);

			material.Unknown = reader.ReadInt();
			material.IsTextured = reader.ReadBoolean();
			material.Ambient = reader.ReadFloat();
			material.Specular = reader.ReadFloat();
			material.Diffuse = reader.ReadFloat();

			while (reader.TryReadChunk(out var chunk))
			{
				switch (chunk.Type)
				{
					case SectionType.Texture:
						material.Texture = RwTexture.Read(reader.ReadInnerChunk(chunk.Size));
						break;
				}
			}

			return material;
		}
	}
}