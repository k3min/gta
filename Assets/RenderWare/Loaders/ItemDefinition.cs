using System.Collections.Generic;
using RenderWare.Extensions;
using RenderWare.Structures;
using RenderWare.Types;

namespace RenderWare.Loaders
{
	public static class ItemDefinition
	{
		public const string Keyword = "IDE";
		public const string End = "end";
		
		private static readonly Dictionary<int, IItemDefinition> objects = new Dictionary<int, IItemDefinition>();

		private static void Add<T>(T info) where T : IItemDefinition
		{
			ItemDefinition.objects.Add(info.ModelId, info);
		}

		public static T Get<T>(Instance inst) where T : IItemDefinition
		{
			return (T)ItemDefinition.objects[inst.ModelId];
		}

		private static IdeSection GetSection(string line)
		{
			var keyword = line.ToLower();

			switch (keyword)
			{
				case SimpleObject.Keyword:
					return IdeSection.SimpleObjects;

				case TimedObject.Keyword:
					return IdeSection.TimedObjects;

				case CutSceneObject.Keyword:
					return IdeSection.CutSceneObjects;

				case VehicleObject.Keyword:
					return IdeSection.VehicleObjects;

				case PedestrianObject.Keyword:
					return IdeSection.PedestrianObjects;

				case Path.Keyword:
					return IdeSection.Paths;

				case Effect.Keyword:
					return IdeSection.Effects;

				default:
					throw new System.IndexOutOfRangeException(keyword);
			}
		}

		public static void Load(string filePath)
		{
			var section = IdeSection.None;

			AsciiReader.Read(filePath, (sr, line) =>
			{
				if (Helpers.EqualsCaseIgnore(line,ItemDefinition.End))
				{
					section = IdeSection.None;
				}
				else if (section == IdeSection.None)
				{
					section = ItemDefinition.GetSection(line);
				}
				else
				{
					var lr = new AsciiReader(line, new[] {'\t', ' ', ','});

					switch (section)
					{
						case IdeSection.SimpleObjects:
							ItemDefinition.Add(SimpleObject.Read(lr));
							break;

						case IdeSection.TimedObjects:
							ItemDefinition.Add(TimedObject.Read(lr));
							break;

						case IdeSection.CutSceneObjects:
							ItemDefinition.Add(CutSceneObject.Read(lr));
							break;

						case IdeSection.VehicleObjects:
							ItemDefinition.Add(VehicleObject.Read(lr));
							break;

						case IdeSection.PedestrianObjects:
							ItemDefinition.Add(PedestrianObject.Read(lr));
							break;

						case IdeSection.Paths:
						{
							var path = Path.Read(lr);

							for (var i = 0; i < 12; i++)
							{
								line = sr.ReadLine();
								lr = new AsciiReader(line, new[] {'\t', ' ', ','});

								path.Nodes[i] = PathNode.Read(lr);
							}

							((IAttachableObject)ItemDefinition.objects[path.ModelId]).Attach(path);

							break;
						}

						case IdeSection.Effects:
						{
							var effect = Effect.Read(lr);

							((IAttachableObject)ItemDefinition.objects[effect.ObjectId]).Attach(effect);

							break;
						}

						default:
							throw new System.IndexOutOfRangeException(section.ToString());
					}
				}
			});
		}
	}
}