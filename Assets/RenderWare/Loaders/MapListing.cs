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
					{
						var imgPath = lr.ReadString();

						UnityEngine.Debug.LogWarningFormat("CDIMAGE: {0}", imgPath);

						break;
					}

					case ItemDefinition.Keyword:
					{
						var idePath = lr.ReadString();

						ItemDefinition.Load(idePath);

						break;
					}

					case TextureArchive.Keyword:
					{
						var txdPath = lr.ReadString();

						TextureArchive.Load(txdPath);

						break;
					}

					case Model.Keyword:
					{
						var dffPath = lr.ReadString();

						Model.Load(dffPath);

						break;
					}

					case Collision.Keyword:
					{
						var zone = (ZoneType)lr.ReadInt();
						var colPath = lr.ReadString();

						Collision.Load(zone, colPath);

						break;
					}

					case ItemPlacement.Keyword:
					{
						var iplPath = lr.ReadString();

						ItemPlacement.Load(iplPath);

						break;
					}
				}
			});
		}
	}
}