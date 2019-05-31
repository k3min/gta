using System.Collections.Generic;
using System.Threading.Tasks;
using RenderWare.Helpers;
using RenderWare.Structures;
using RenderWare.Types;

namespace RenderWare.Loaders
{
	public static class Collision
	{
		public const string Keyword = "COLFILE";

		private static readonly Dictionary<int, HashSet<CollisionModel>> collisions =
			new Dictionary<int, HashSet<CollisionModel>>(new IntComparer())
			{
				{(int)ZoneType.None, new HashSet<CollisionModel>()}, // World
				{(int)ZoneType.Portland, new HashSet<CollisionModel>()}, // Portland
				{(int)ZoneType.Staunton, new HashSet<CollisionModel>()}, // Staunton
				{(int)ZoneType.ShoresideVale, new HashSet<CollisionModel>()} // Shoreside Vale
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
			Collision.collisions[(int)zone].Add(coll);
		}

		public static bool TryFind(string name, out CollisionModel coll)
		{
			coll = default;

			foreach (var zones in Collision.collisions.Values)
			{
				foreach (var zone in zones)
				{
					if (!String.Equals(zone.ModelName, name))
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