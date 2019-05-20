using System.Collections.Generic;
using RenderWare.Structures;
using RenderWare.Types;

namespace RenderWare.Loaders
{
	public static class ItemPlacement
	{
		public const string Keyword = "IPL";
		public const string End = "end";

		private static readonly Dictionary<System.Type, List<IItem>> items = new Dictionary<System.Type, List<IItem>>
		{
			{typeof(Instance), new List<IItem>()},
			{typeof(Zone), new List<IItem>()},
			{typeof(Cull), new List<IItem>()}
		};

		public static void Add<T>(T instance) where T : IItem
		{
			ItemPlacement.items[typeof(T)].Add(instance);
		}

		public static void ForEach<T>(System.Action<T> action) where T : IItem
		{
			foreach (var item in ItemPlacement.items[typeof(T)])
			{
				action((T)item);
			}
		}

		private static IplSection GetSection(string line)
		{
			switch (line.ToLower())
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
					throw new System.IndexOutOfRangeException();
			}
		}

		public static void Load(string filePath)
		{
			var section = IplSection.None;

			AsciiReader.Read(filePath, (line) =>
			{
				if (line.ToLower() == ItemPlacement.End)
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
					}
				}
			});
		}
	}
}