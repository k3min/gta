using System.Collections.Generic;
using RenderWare.Structures;
using RenderWare.Types;

namespace RenderWare.Loaders
{
	public static class Archive
	{
		public const string Keyword = "CDIMAGE";

		private static readonly Dictionary<string, ImgArchive> archives = new Dictionary<string, ImgArchive>();

		public static readonly List<string> Excluded = new List<string>
		{
			"islandlodcomindnt.txd"
		};

		public static void Add(string name, ImgArchive img)
		{
			Archive.archives.Add(name.ToLower(), img);
		}

		public static void Load(string filePath)
		{
			var img = new ImgArchive(filePath);

			img.ForEach((entry, stream, chunk) =>
			{
				if (Archive.Excluded.Contains(entry.Name.ToLower()))
				{
					return;
				}

				switch (chunk.Type)
				{
					case SectionType.TextureDictionary:
						TextureArchive.Add(entry.Name, stream.Read(chunk, RwTextureDictionary.Read));
						break;

					case SectionType.Clump:
						Model.Add(entry.Name, stream.Read(chunk, RwClump.Read));
						break;
				}
			});

			Archive.Add(filePath, img);
		}
	}
}