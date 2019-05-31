using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using RenderWare.Structures;

namespace RenderWare.Loaders
{
	public static class Archive
	{
		public const string Keyword = "CDIMAGE";

		private static readonly HashSet<ImgArchive> archives = new HashSet<ImgArchive>();

		public static event System.Action<string> OnLoad;

		public static async Task Load(string filePath)
		{
			await Task.Run(() =>
			{
				if (Archive.OnLoad != null)
				{
					Archive.OnLoad(filePath);
				}
			});

			Archive.archives.Add(new ImgArchive(filePath));
		}

		public static RwBinaryReader Find(string name)
		{
			foreach (var img in Archive.archives)
			{
				if (img.TryFind(name, out var entry))
				{
					return img.GetStream(entry);
				}
			}

			throw new FileNotFoundException(name);
		}
	}
}