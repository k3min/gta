using System.Collections.Generic;
using RenderWare.Structures;
using RenderWare.Types;

namespace RenderWare.Loaders
{
	public static class ItemDefinition
	{
		public const string Keyword = "IDE";

		private static readonly Dictionary<int, IObjectInfo> objects = new Dictionary<int, IObjectInfo>();

		public static void Add<T>(T info) where T : IObjectInfo
		{
			ItemDefinition.objects.Add(info.Id, info);
		}

		public static T Get<T>(Instance inst) where T : IObjectInfo
		{
			return (T)ItemDefinition.objects[inst.ModelId];
		}

		private static IdeSection GetSection(string line)
		{
			switch (line.ToLower())
			{
				case "objs":
					return IdeSection.Objects;

				case "tobj":
					return IdeSection.TimedObjects;

				case "hier":
					return IdeSection.CutSceneObjects;

				case "cars":
					return IdeSection.Vehicles;

				case "peds":
					return IdeSection.Pedestrians;

				case "path":
					return IdeSection.Paths;
				
				default:
					throw new System.IndexOutOfRangeException();
			}
		}
		
		public static void Load(string filePath)
		{
			var section = IdeSection.None;

			AsciiReader.Read(filePath, (sr, line) =>
			{
				if (line == "end")
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
						case IdeSection.Objects:
						case IdeSection.TimedObjects:
						{
							var model = ModelInfo.Read(lr);

							if (section == IdeSection.TimedObjects)
							{
								model.TimeOn = lr.ReadInt();
								model.TimeOff = lr.ReadInt();
							}

							ItemDefinition.Add(model);

							break;
						}

						case IdeSection.Vehicles:
							ItemDefinition.Add(VehicleInfo.Read(lr));
							break;

						case IdeSection.Pedestrians:
							ItemDefinition.Add(PedestrianInfo.Read(lr));
							break;

						case IdeSection.Paths:
						{
							var group = PathGroup.Read(lr);

							for (var i = 0; i < 12; i++)
							{
								line = sr.ReadLine();
								lr = new AsciiReader(line, new[] {'\t', ' ', ','});

								group.Nodes[i] = PathNode.Read(lr);
							}

							var model = (ModelInfo)ItemDefinition.objects[group.ModelIndex];

							model.Paths?.Add(group);

							break;
						}
						
						default:
							throw new System.NotSupportedException();
					}
				}
			});
		}
	}
}