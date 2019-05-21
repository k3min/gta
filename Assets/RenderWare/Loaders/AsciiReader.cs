using System.IO;

namespace RenderWare.Loaders
{
	public class AsciiReader : IReader
	{
		private int index;
		private readonly string[] tokens;

		public AsciiReader(string line, string[] delimiters,
			System.StringSplitOptions options = System.StringSplitOptions.RemoveEmptyEntries)
		{
			this.tokens = line.Split(delimiters, options);
		}

		public AsciiReader(string line, char[] delimiters,
			System.StringSplitOptions options = System.StringSplitOptions.RemoveEmptyEntries)
		{
			this.tokens = line.Split(delimiters, options);
		}

		public static void Read(string filePath, System.Action<string> action)
		{
			AsciiReader.Read(filePath, (reader, line) => action(line));
		}

		public static void Read(string filePath, System.Action<StreamReader, string> action)
		{
			using (var reader = new StreamReader(FileSystem.GetPath(filePath)))
			{
				string line;

				while ((line = reader.ReadLine()) != null)
				{
					line = line.Trim();

					if (string.IsNullOrWhiteSpace(line) || line[0] == '#')
					{
						continue;
					}

					action(reader, line);
				}
			}
		}

		public string ReadString()
		{
			try
			{
				return this.tokens[this.index++];
			}
			catch
			{
				throw new System.Exception(string.Join(", ", this.tokens));
			}
		}

		public int ReadInt()
		{
			return int.Parse(this.ReadString());
		}

		public T ReadEnum<T>() where T : struct
		{
			var type = typeof(T);
			var value = this.ReadString();
			
			return (T)System.Enum.Parse(type, value);
		}

		public bool ReadBoolean()
		{
			return (this.ReadInt() != 0);
		}

		public float ReadFloat()
		{
			return float.Parse(this.ReadString());
		}

		public byte ReadByte()
		{
			return byte.Parse(this.ReadString());
		}

		public int ReadHex()
		{
			return System.Convert.ToInt32(this.ReadString(), 16);
		}

		public UnityEngine.Vector2 ReadVector2()
		{
			return new UnityEngine.Vector2(this.ReadFloat(), this.ReadFloat());
		}

		public UnityEngine.Vector3 ReadVector3()
		{
			return new UnityEngine.Vector3(this.ReadFloat(), this.ReadFloat(), this.ReadFloat());
		}

		public UnityEngine.Vector4 ReadVector4()
		{
			return new UnityEngine.Vector4(this.ReadFloat(), this.ReadFloat(), this.ReadFloat(), this.ReadFloat());
		}

		public UnityEngine.Quaternion ReadQuaternion()
		{
			return new UnityEngine.Quaternion(this.ReadFloat(), this.ReadFloat(), this.ReadFloat(), this.ReadFloat());
		}

		public UnityEngine.Color32 ReadColor()
		{
			return new UnityEngine.Color32(this.ReadByte(), this.ReadByte(), this.ReadByte(), this.ReadByte());
		}
	}
}