using System.IO;
using System.Text;
using System.Threading.Tasks;
using RenderWare.Helpers;
using RenderWare.Structures;

namespace RenderWare.Loaders
{
	public static class Text
	{
		private static readonly StringDictionary<string> entries = new StringDictionary<string>();

		public static event System.Action<string> OnLoad;

		public static bool TryGet(string key, out string value)
		{
			return Text.entries.TryGetValue(key, out value);
		}

		public static async Task Load(string filePath)
		{
			await Task.Run(() =>
			{
				if (Text.OnLoad != null)
				{
					Text.OnLoad(filePath);
				}
			});

			var sb = new StringBuilder();

			var buffer = File.ReadAllBytes(FileSystem.GetPath(filePath));

			using (var ms = new MemoryStream(buffer))
			using (var br = new BinaryReader(ms, Encoding.Unicode))
			{
				var reader = new RwBinaryReader(buffer);

				var magic = reader.ReadString(4);

				if (!String.Equals(magic, TKey.Magic))
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

					Text.entries.Add(key, sb.ToString());
				}
			}
		}
	}
}