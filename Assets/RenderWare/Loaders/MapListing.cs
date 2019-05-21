using RenderWare.Types;

namespace RenderWare.Loaders
{
	public static class MapListing
	{
		public static void Load(string filePath)
		{
			AsciiReader.Read(filePath, (line) =>
			{
				var lr = new AsciiReader(line, new[] {' '}, System.StringSplitOptions.None);

				switch (lr.ReadString())
				{
					case Archive.Keyword:
						throw new System.NotSupportedException($"{Archive.Keyword}: {lr.ReadString()}");

					case ItemDefinition.Keyword:
						ItemDefinition.Load(lr.ReadString());
						break;

					case TextureArchive.Keyword:
						TextureArchive.Load(lr.ReadString());
						break;

					case Model.Keyword:
						Model.Load(lr.ReadString());
						break;

					case Collision.Keyword:
						Collision.Load(lr.ReadEnum<ZoneType>(), lr.ReadString());
						break;

					case ItemPlacement.Keyword:
						ItemPlacement.Load(lr.ReadString());
						break;

					default:
						throw new System.NotSupportedException();
				}
			});
		}
	}
}