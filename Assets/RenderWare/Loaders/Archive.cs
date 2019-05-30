using System.Collections.Generic;
using System.Threading.Tasks;
using RenderWare.Structures;

namespace RenderWare.Loaders
{
	public static class Archive
	{
		public const string Keyword = "CDIMAGE";

		private static readonly Dictionary<string, ImgArchive> archives = new Dictionary<string, ImgArchive>();

		public static event System.Action<ImgArchive, string> OnLoad;

		private static void Add(string name, ImgArchive img)
		{
			Archive.archives.Add(name.ToLower(), img);
		}

		public static ImgArchive Load(string filePath)
		{
			var img = new ImgArchive(filePath);

			Archive.Add(filePath, img);

			return img;
		}

		public static async Task<RwBinaryReader> TryFind(string name)
		{
			foreach (var img in Archive.archives.Values)
			{
				foreach (var entry in img.DirectoryEntries)
				{
					if (!Helpers.EqualsCaseIgnore(entry.Name, name))
					{
						continue;
					}

					await Task.Run(() =>
					{
						if (Archive.OnLoad != null)
						{
							Archive.OnLoad(img, name);
						}
					});

					return img.GetStream(entry);
				}
			}

			return null;
		}
	}
}