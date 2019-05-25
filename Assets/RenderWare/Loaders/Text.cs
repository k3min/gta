using System.Collections.Generic;
using System.IO;
using System.Text;
using RenderWare.Extensions;
using RenderWare.Structures;

namespace RenderWare.Loaders
{
	public static class Text
	{
		private static readonly Dictionary<string, string> entries = new Dictionary<string, string>();

		public static bool TryGet(string key, out string value)
		{
			return Text.entries.TryGetValue(key.ToLower(), out value);
		}
		
		public static void Load(string filePath)
		{
			var sb = new StringBuilder();

			using (var ms = File.OpenRead(FileSystem.GetPath(filePath)))
			using (var br = new BinaryReader(ms, Encoding.Unicode))
			{
				var magic = br.ReadString(4);

				if (magic != TKey.Magic)
				{
					throw new InvalidDataException();
				}

				var size = br.ReadInt32();

				for (var i = 0; i < size / TKey.SizeOf; i++)
				{
					var offset = br.ReadInt32();
					var key = br.ReadString(8);

					br.Mark((reader) =>
					{
						reader.BaseStream.Seek(offset + size + 8 + 8, SeekOrigin.Begin);

						sb.Clear();

						char value;

						while ((value = reader.ReadChar()) != '\0')
						{
							sb.Append(value);
						}

						Text.entries.Add(key.ToLower(), sb.ToString());
					});
				}
			}
		}
	}
}