using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using RenderWare.Structures;
using RenderWare.Types;
using Path = System.IO.Path;

namespace RenderWare.Loaders
{
	public static class Model
	{
		public const string Keyword = "MODELFILE";

		private static readonly Dictionary<string, RwClump> models = new Dictionary<string, RwClump>();

		public static event System.Action<string> OnLoad;

		public static async Task ForEach(System.Func<string, RwClump, Task> action)
		{
			foreach (var model in Model.models)
			{
				await action(model.Key, model.Value);
			}
		}

		public static async Task Load(string filePath)
		{
			await Task.Run(() =>
			{
				if (Model.OnLoad != null)
				{
					Model.OnLoad(filePath);
				}
			});

			RwBinaryReader.LoadChunk(filePath, (stream, chunk) =>
			{
				switch (chunk.Type)
				{
					case SectionType.TextureDictionary:
						Model.Add(filePath, stream.Read(chunk, RwClump.Read));
						break;
				}
			});
		}

		public static RwClump Add(string name, RwClump dff)
		{
			name = Path.GetFileNameWithoutExtension(name).ToLower();

			Model.models.Add(name, dff);

			return dff;
		}

		public static async Task<RwClump> Find(string name)
		{
			name = Path.GetFileNameWithoutExtension(name).ToLower();

			if (Model.models.TryGetValue(name, out var result))
			{
				return result;
			}

			name = Path.ChangeExtension(name, "dff");

			var found = await Archive.TryFind(name, (dff) =>
			{
				result = (RwClump)dff;
			});

			if (found)
			{
				return result;
			}

			throw new FileNotFoundException(name);
		}
	}
}