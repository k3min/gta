using System.Threading.Tasks;
using RenderWare.Helpers;
using RenderWare.Structures;

namespace RenderWare.Loaders
{
	public static class TextureArchive
	{
		public const string Keyword = "TEXDICTION";

		private static readonly StringDictionary<RwTextureDictionary> textures =
			new StringDictionary<RwTextureDictionary>();

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
			var chunk = new RwChunk();

			stream.Read(RwChunk.SizeOf, ref chunk);

			var txd = RwTextureDictionary.Read(stream.ReadInnerChunk(chunk));

			TextureArchive.textures.Add(FileSystem.RemoveExtension(name), txd);

			return txd;
		}

		public static bool TryFindTexture(string name, out RwTextureNative result)
		{
			result = default;

			foreach (var texture in TextureArchive.textures.Values)
			{
				for (var i = 0; i < texture.TextureCount; i++)
				{
					result = texture.Textures[i];

					if (String.Equals(result.Texture.Name, name))
					{
						return true;
					}
				}
			}

			return false;
		}
	}
}