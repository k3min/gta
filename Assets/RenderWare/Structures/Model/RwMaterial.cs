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
		[MarshalAs(UnmanagedType.Bool)]
		public bool IsTextured;
		public float Ambient;
		public float Specular;
		public float Diffuse;
		public RwTexture Texture;

		public static RwMaterial Read(RwBinaryReader reader)
		{
			var material = new RwMaterial
			{
				Flags = reader.ReadInt(),
				Color = reader.ReadColor(),
				Unknown = reader.ReadInt(),
				IsTextured = reader.ReadBoolean(),
				Ambient = reader.ReadFloat(),
				Specular = reader.ReadFloat(),
				Diffuse = reader.ReadFloat()
			};

			foreach (var chunk in reader.ConsumeChunk())
			{
				switch (chunk.Type)
				{
					case SectionType.Texture:
						material.Texture = RwTexture.Read(reader.ReadInnerChunk(chunk));
						break;
				}
			}

			return material;
		}
	}
}