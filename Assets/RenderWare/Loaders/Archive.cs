using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using RenderWare.Structures;
using RenderWare.Types;

namespace RenderWare.Loaders
{
	public static class Archive
	{
		public const string Keyword = "CDIMAGE";

		private static readonly Dictionary<string, ImgArchive> archives = new Dictionary<string, ImgArchive>();

		public static event System.Action<ImgArchive, DirectoryEntry> OnLoad;

		public static readonly List<string> Excluded = new List<string>
		{
			"islandlodcomindnt.txd"
		};

		public static void Add(string name, ImgArchive img)
		{
			Archive.archives.Add(name.ToLower(), img);
		}

		private static bool IsExcluded(string name)
		{
			name = name.ToLower();

			foreach (var excluded in Archive.Excluded)
			{
				if (name.Contains(excluded.ToLower()))
				{
					return true;
				}
			}

			return false;
		}

		public static ImgArchive Load(string filePath)
		{
			var img = new ImgArchive(filePath);

			Archive.Add(filePath, img);

			return img;
		}

		public static async Task<bool> TryFind(string name, System.Action<IRwBinaryStream> action)
		{
			name = name.ToLower();

			foreach (var img in Archive.archives.Values)
			{
				var found = await img.TryFind(name, async (entry, stream, chunk) =>
				{
					if (Archive.IsExcluded(entry.Name))
					{
						return;
					}

					await Task.Run(() =>
					{
						if (Archive.OnLoad != null)
						{
							Archive.OnLoad(img, entry);
						}
					});

					switch (chunk.Type)
					{
						case SectionType.TextureDictionary:
							action(TextureArchive.Add(entry.Name, stream.Read(chunk, RwTextureDictionary.Read)));
							break;

						case SectionType.Clump:
							action(Model.Add(entry.Name, stream.Read(chunk, RwClump.Read)));
							break;

						default:
							throw new System.NotSupportedException();
					}
				});

				if (found)
				{
					return true;
				}
			}

			return false;
		}
	}
}