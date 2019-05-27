using System.Threading.Tasks;
using RenderWare.Types;

namespace RenderWare.Loaders
{
	public static class MapListing
	{
		public static async Task Load(string filePath)
		{
			await AsciiReader.Read(filePath, async (sr,line) =>
			{
				var lr = new AsciiReader(line, new[] {' '}, System.StringSplitOptions.None);
				var keyword = lr.ReadString();

				switch (keyword)
				{
					case Archive.Keyword:
						throw new System.NotImplementedException($"{Archive.Keyword}: {lr.ReadString()}");

					case ItemDefinition.Keyword:
						ItemDefinition.Load(lr.ReadString());
						break;

					case TextureArchive.Keyword:
						await TextureArchive.Load(lr.ReadString());
						break;

					case Model.Keyword:
						await Model.Load(lr.ReadString());
						break;

					case Collision.Keyword:
						await Collision.Load((ZoneType)lr.ReadInt(), lr.ReadString());
						break;

					case ItemPlacement.Keyword:
					case "MAPZONE":
						ItemPlacement.Load(lr.ReadString());
						break;

					case "SPLASH":
						UnityEngine.Debug.LogWarning($"SPLASH: {lr.ReadString()}");
						break;

					default:
						throw new System.IndexOutOfRangeException(keyword);
				}
			});
		}
	}
}