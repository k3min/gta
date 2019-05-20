using System.Collections.Generic;
using RenderWare.Structures;
using RenderWare.Types;

namespace RenderWare.Loaders
{
	public static class Collision
	{
		public const string Keyword = "COLFILE";

		private static readonly Dictionary<int, List<CollisionModel>>[] collisions =
		{
			new Dictionary<int, List<CollisionModel>>(), // World
			new Dictionary<int, List<CollisionModel>>(), // Portland
			new Dictionary<int, List<CollisionModel>>(), // Staunton
			new Dictionary<int, List<CollisionModel>>() // Shoreside Vale
		};
		
		public static void Load(ZoneType zone, string filePath)
		{
			RwBinaryReader.Load(filePath).Consume(CollisionModel.Read, (coll) => Collision.Add(zone, coll));
		}

		public static void Add(ZoneType zone, CollisionModel coll)
		{
			var collision = Collision.collisions[(int)zone];
			
			if (!collision.ContainsKey(coll.ModelIndex))
			{
				collision[coll.ModelIndex] = new List<CollisionModel>();
			}

			collision[coll.ModelIndex].Add(coll);
		}
	}
}