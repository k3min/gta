using System.Collections.Generic;
using RenderWare.Structures;
using RenderWare.Types;

namespace RenderWare.Loaders
{
	public static class Collision
	{
		public const string Keyword = "COLFILE";

		private static readonly Dictionary<ZoneType, Dictionary<int, List<CollisionModel>>> collisions =
			new Dictionary<ZoneType, Dictionary<int, List<CollisionModel>>>
			{
				{ZoneType.None, new Dictionary<int, List<CollisionModel>>()}, // World
				{ZoneType.Portland, new Dictionary<int, List<CollisionModel>>()}, // Portland
				{ZoneType.Staunton, new Dictionary<int, List<CollisionModel>>()}, // Staunton
				{ZoneType.ShoresideVale, new Dictionary<int, List<CollisionModel>>()} // Shoreside Vale
			};

		public static void Load(ZoneType zone, string filePath)
		{
			RwBinaryReader.Load(filePath).Consume(CollisionModel.Read, (coll) => Collision.Add(zone, coll));
		}

		public static void Add(ZoneType zone, CollisionModel coll)
		{
			var collision = Collision.collisions[zone];

			if (collision.ContainsKey(coll.ModelIndex))
			{
				collision[coll.ModelIndex].Add(coll);
			}
			else
			{
				collision[coll.ModelIndex] = new List<CollisionModel>
				{
					coll
				};
			}
		}
	}
}