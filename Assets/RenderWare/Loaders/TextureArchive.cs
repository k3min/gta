using System.Collections.Generic;
using System.Threading.Tasks;
using RenderWare.Structures;
using RenderWare.Types;
using Path = System.IO.Path;

namespace RenderWare.Loaders
{
	public static class TextureArchive
	{
		public const string Keyword = "TEXDICTION";

		private static readonly Dictionary<string, RwTextureDictionary> textures =
			new Dictionary<string, RwTextureDictionary>();
		
		public static event System.Action<string> OnLoad;

		public static async Task Load(string filePath)
		{
			await Task.Run(() =>
			{
				if (TextureArchive.OnLoad != null)
				{
					TextureArchive.OnLoad(filePath);
				}
			});
			
			RwBinaryReader.LoadChunk(filePath, (stream, chunk) =>
			{
				switch (chunk.Type)
				{
					case SectionType.TextureDictionary:
						TextureArchive.Add(filePath, stream.Read(chunk, RwTextureDictionary.Read));
						break;

					default:
						throw new System.NotSupportedException();
				}
			});
		}

		public static RwTextureDictionary Add(string name, RwTextureDictionary txd)
		{
			name = Path.GetFileNameWithoutExtension(name).ToLower();

			TextureArchive.textures.Add(name, txd);

			return txd;
		}

		public static bool TryFindTexture(string name, out RwTextureNative result)
		{
			name = name.ToLower();
			
			result = default;

			foreach (var texture in TextureArchive.textures.Values)
			{
				for (var i = 0; i < texture.TextureCount; i++)
				{
					result = texture.Textures[i];

					if (result.Texture.Name.ToLower() == name)
					{
						return true;
					}
				}
			}

			return false;
		}
	}
}