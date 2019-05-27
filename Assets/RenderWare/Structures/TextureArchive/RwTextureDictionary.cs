using System.Runtime.InteropServices;
using RenderWare.Loaders;
using RenderWare.Types;

namespace RenderWare.Structures
{
	[StructLayout(LayoutKind.Sequential)]
	public struct RwTextureDictionary : IRwBinaryStream, System.IDisposable
	{
		public short TextureCount; // 0
		public short Device; // 1
		[MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 0)]
		public RwTextureNative[] Textures; // 2

		public static RwTextureDictionary Read(RwBinaryReader reader)
		{
			var textureDictionary = new RwTextureDictionary
			{
				TextureCount = reader.ReadShort(),
				Device = reader.ReadShort()
			};

			textureDictionary.Textures = new RwTextureNative[textureDictionary.TextureCount];

			var textureIndex = 0;

			foreach (var chunk in reader.ConsumeChunk())
			{
				switch (chunk.Type)
				{
					case SectionType.TextureNative:
					{
						if (textureIndex < textureDictionary.TextureCount)
						{
							textureDictionary.Textures[textureIndex++] = RwTextureNative.Read(reader.ReadInnerChunk(chunk));
						}

						break;
					}
				}
			}

			return textureDictionary;
		}

		public void Dispose()
		{
			foreach (var texture in this.Textures)
			{
				texture.Dispose();
			}
		}
	}
}