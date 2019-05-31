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

		private static async Task<RwTextureDictionary> Read(string name, RwBinaryReader stream)
		{
			await Task.Run(() =>
			{
				if (TextureArchive.OnLoad != null)
				{
					TextureArchive.OnLoad(name);
				}
			});

			var chunk = new RwChunk();

			stream.Read(RwChunk.SizeOf, ref chunk);

			var txd = RwTextureDictionary.Read(stream.ReadInnerChunk(chunk.Size));

			TextureArchive.textures.Add(FileSystem.RemoveExtension(name), txd);

			return txd;
		}

		public static async Task<RwTextureDictionary> Load(string filePath)
		{
			return await TextureArchive.Read(filePath, RwBinaryReader.Load(filePath));
		}
	}
}