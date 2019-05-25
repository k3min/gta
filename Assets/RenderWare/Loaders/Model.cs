using System.Collections.Generic;
using System.IO;
using RenderWare.Structures;
using RenderWare.Types;

namespace RenderWare.Loaders
{
	public static class Model
	{
		public const string Keyword = "MODELFILE";

		private static readonly Dictionary<string, RwClump> models = new Dictionary<string, RwClump>();

		public static RwClump Get(IObjectInfo info)
		{
			return Model.models[info.ModelName.ToLower()];
		}

		public static void ForEach(System.Action<string, RwClump> action)
		{
			foreach (var model in Model.models)
			{
				action(model.Key, model.Value);
			}
		}

		public static void Load(string filePath)
		{
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

		public static void Add(string name, RwClump dff)
		{
			Model.models.Add(Path.GetFileNameWithoutExtension(name).ToLower(), dff);
		}
	}
}