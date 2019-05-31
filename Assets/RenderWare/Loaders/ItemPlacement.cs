using System.Collections.Generic;
using RenderWare.Structures;
using RenderWare.Types;
using RenderWare.Helpers;

namespace RenderWare.Loaders
{
	public static class ItemPlacement
	{
		public const string Keyword = "IPL";
		public const string End = "end";

		private static readonly Dictionary<System.Type, HashSet<IItemPlacement>> items =
			new Dictionary<System.Type, HashSet<IItemPlacement>>
			{
				{typeof(Instance), new HashSet<IItemPlacement>()},
				{typeof(Zone), new HashSet<IItemPlacement>()},
				{typeof(Cull), new HashSet<IItemPlacement>()},
				{typeof(Pickup), new HashSet<IItemPlacement>()}
			};

		private static void Add<T>(T instance) where T : IItemPlacement
		{
			ItemPlacement.items[typeof(T)].Add(instance);
		}

		public static IEnumerable<T> All<T>() where T : IItemPlacement
		{
			var type = typeof(T);
			var results = ItemPlacement.items[type];

			foreach (var item in results)
			{
				yield return (T)item;
			}
		}

		private static IplSection GetSection(string keyword)
		{
			switch (keyword)
			{
				case Instance.Keyword:
					return IplSection.Instances;

				case Zone.Keyword:
					return IplSection.Zones;

				case Cull.Keyword:
					return IplSection.Culls;

				case Pickup.Keyword:
					return IplSection.Pickups;

				default:
					throw new System.IndexOutOfRangeException(keyword);
			}
		}


		public static void Load(string filePath)
		{
			var section = IplSection.None;

			AsciiReader.Read(filePath, (sr, line) =>
			{
				if (String.Equals(line, ItemPlacement.End))
				{
					section = IplSection.None;
				}
				else if (section == IplSection.None)
				{
					section = ItemPlacement.GetSection(line);
				}
				else
				{
					var lr = new AsciiReader(line, new[] {", "}, System.StringSplitOptions.None);

					switch (section)
					{
						case IplSection.Instances:
							ItemPlacement.Add(Instance.Read(lr));
							break;

						case IplSection.Zones:
							ItemPlacement.Add(Zone.Read(lr));
							break;

						case IplSection.Culls:
							ItemPlacement.Add(Cull.Read(lr));
							break;

						case IplSection.Pickups:
							ItemPlacement.Add(Pickup.Read(lr));
							break;

						default:
							throw new System.NotSupportedException();
					}
				}
			});
		}
	}
}