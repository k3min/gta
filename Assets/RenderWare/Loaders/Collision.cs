using System.Collections.Generic;
using System.Threading.Tasks;
using RenderWare.Structures;
using RenderWare.Types;

namespace RenderWare.Loaders
{
	public static class Collision
	{
		public const string Keyword = "COLFILE";

		private static readonly Dictionary<ZoneType, Dictionary<string, CollisionModel>> collisions =
			new Dictionary<ZoneType, Dictionary<string, CollisionModel>>
			{
				{ZoneType.None, new Dictionary<string, CollisionModel>()}, // World
				{ZoneType.Portland, new Dictionary<string, CollisionModel>()}, // Portland
				{ZoneType.Staunton, new Dictionary<string, CollisionModel>()}, // Staunton
				{ZoneType.ShoresideVale, new Dictionary<string, CollisionModel>()} // Shoreside Vale
			};

		public static event System.Action<string> OnLoad;

		public static async Task Load(ZoneType zone, string filePath)
		{
			await Task.Run(() =>
			{
				if (Collision.OnLoad != null)
				{
					Collision.OnLoad(filePath);
				}
			});

			var stream = RwBinaryReader.Load(filePath);

			while (stream.Position < stream.Size)
			{
				Collision.Add(zone, CollisionModel.Read(stream));
			}
		}

		private static void Add(ZoneType zone, CollisionModel coll)
		{
			Collision.collisions[zone].Add(coll.ModelName.ToLower(), coll);
		}

		public static bool TryFind(IItemDefinition ide, out CollisionModel coll)
		{
			coll = default;

			foreach (var zones in Collision.collisions.Values)
			{
				if (zones.TryGetValue(ide.ModelName, out coll))
				{
					return true;
				}

				foreach (var zone in zones.Values)
				{
					if (zone.ModelId != ide.ModelId)
					{
						continue;
					}

					coll = zone;

					return true;
				}
			}

			return false;
		}
	}
}