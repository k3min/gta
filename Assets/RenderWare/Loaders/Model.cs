using System.Threading.Tasks;
using RenderWare.Helpers;
using RenderWare.Structures;

namespace RenderWare.Loaders
{
	public static class Model
	{
		public const string Keyword = "MODELFILE";

		private static readonly StringDictionary<RwClump> models = new StringDictionary<RwClump>();

		public static event System.Action<string> OnLoad;

		private static async Task<RwClump> Read(string name, RwBinaryReader stream)
		{
			await Task.Run(() =>
			{
				if (Model.OnLoad != null)
				{
					Model.OnLoad(name);
				}
			});

			var chunk = new RwChunk();

			stream.Read(RwChunk.SizeOf, ref chunk);

			var dff = RwClump.Read(stream.ReadInnerChunk(chunk));

			Model.models.Add(FileSystem.RemoveExtension(name), dff);

			return dff;
		}

		public static async Task<RwClump> Load(string filePath)
		{
			return await Model.Read(filePath, RwBinaryReader.Load(filePath));
		}

		public static async Task<RwClump> Find(string name)
		{
			name = FileSystem.RemoveExtension(name);

			if (Model.models.TryGetValue(name, out var result))
			{
				return result;
			}

			name += ".dff";

			return await Model.Read(name, Archive.Find(name));
		}
	}
}