using System.Collections.Generic;
using System.IO;
using RenderWare.Structures;
using RenderWare.Types;

namespace RenderWare.Loaders
{
	public static class TextureArchive
	{
		public const string Keyword = "TEXDICTION";
		
		private static readonly Dictionary<string, RwTextureDictionary> textures = new Dictionary<string, RwTextureDictionary>();

		public static void Load(string filePath)
		{
			RwBinaryReader.LoadChunk(filePath, (stream, chunk) =>
			{
				switch (chunk.Type)
				{
					case SectionType.TextureDictionary:
						TextureArchive.Add(filePath, stream.Read(chunk, RwTextureDictionary.Read));
						break;
				}
			});
		}

		public static void Add(string filePath, RwTextureDictionary txd)
		{
			TextureArchive.textures.Add(Path.GetFileNameWithoutExtension(filePath).ToLower(), txd);
		}

		public static bool TryFindTexture(string name, out RwTextureNative result)
		{
			result = default;

			foreach (var texture in TextureArchive.textures.Values)
			{
				for (var i = 0; i < texture.TextureCount; i++)
				{
					result = texture.Textures[i];

					if (string.Equals(result.Texture.Name, name, System.StringComparison.CurrentCultureIgnoreCase))
					{
						return true;
					}
				}
			}

			return false;
		}
	}
}