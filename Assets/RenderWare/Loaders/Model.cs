using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using RenderWare.Structures;
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

		private static RwClump Read(string name, RwBinaryReader stream)
		{
			name = Path.GetFileNameWithoutExtension(name).ToLower();

			var dff = RwClump.Read(stream.ReadInnerChunk(stream.Read<RwChunk>(RwChunk.SizeOf)));
			
			Model.models.Add(name, dff);

			return dff;
		}

		public static async Task<RwClump> Load(string filePath)
		{
			await Task.Run(() =>
			{
				if (Model.OnLoad != null)
				{
					Model.OnLoad(filePath);
				}
			});

			return Model.Read(filePath, RwBinaryReader.Load(filePath));
		}

		public static async Task<RwClump> Find(string name)
		{
			name = Path.GetFileNameWithoutExtension(name).ToLower();

			if (Model.models.TryGetValue(name, out var result))
			{
				return result;
			}

			name = Path.ChangeExtension(name, "dff");

			var stream = await Archive.TryFind(name);

			if (stream == null)
			{
				throw new FileNotFoundException(name);
			}

			return Model.Read(name, stream);
		}
	}
}