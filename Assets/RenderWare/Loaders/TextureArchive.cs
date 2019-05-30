using System.Collections.Generic;
using System.Threading.Tasks;
using RenderWare.Extensions;
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

		public static async Task<RwTextureDictionary> Load(string filePath)
		{
			await Task.Run(() =>
			{
				if (TextureArchive.OnLoad != null)
				{
					TextureArchive.OnLoad(filePath);
				}
			});

			return TextureArchive.Add(filePath, RwBinaryReader.Load(filePath));
		}

		private static RwTextureDictionary Add(string name, RwBinaryReader stream)
		{
			name = Path.GetFileNameWithoutExtension(name).ToLower();

			var txd = RwTextureDictionary.Read(stream.ReadInnerChunk(stream.Read<RwChunk>(RwChunk.SizeOf)));
			
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

					if (Helpers.EqualsCaseIgnore(result.Texture.Name, name))
					{
						return true;
					}
				}
			}

			return false;
		}
	}
}