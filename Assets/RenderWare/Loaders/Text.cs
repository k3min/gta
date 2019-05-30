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

			var buffer = File.ReadAllBytes(FileSystem.GetPath(filePath));

			using (var ms = new MemoryStream(buffer))
			using (var br = new BinaryReader(ms, Encoding.Unicode))
			{
				var reader = new RwBinaryReader(buffer);

				var magic = reader.ReadString(4);

				if (!Helpers.EqualsCaseIgnore(magic, TKey.Magic))
				{
					throw new InvalidDataException();
				}

				var size = reader.ReadInt();

				for (var i = 0; i < size / TKey.SizeOf; i++)
				{
					var offset = reader.ReadInt();
					var key = reader.ReadString(8);

					br.BaseStream.Seek(offset + size + 8 + 8, SeekOrigin.Begin);

					sb.Clear();

					char @char;
					while ((@char = br.ReadChar()) != (char)0)
					{
						sb.Append(@char);
					}

					Text.entries.Add(key.ToLower(), sb.ToString());
				}
			}
		}
	}
}