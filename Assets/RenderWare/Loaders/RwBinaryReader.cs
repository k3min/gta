using System.IO;
using System.Runtime.InteropServices;
using RenderWare.Structures;
using RenderWare.Types;

namespace RenderWare.Loaders
{
	public class RwBinaryReader : IReader
	{
		private readonly byte[] buffer;
		private readonly int offset;

		private int index;

		public readonly int Size;

		public int Depth { get; private set; }

		public int Position => (this.index - this.offset);

		public RwBinaryReader(byte[] buffer, int offset, int size)
		{
			this.buffer = buffer;
			this.offset = offset;
			this.index = offset;
			this.Size = size;
		}

		protected RwBinaryReader(byte[] buffer, int offset = 0) : this(buffer, offset, buffer.Length)
		{
		}

		public RwBinaryReader GetInnerStream(int count)
		{
			var inner = new RwBinaryReader(this.buffer, this.index, count)
			{
				Depth = (this.Depth + 1)
			};

			this.index += count;

			return inner;
		}

		public RwBinaryReader GetInnerStream(RwChunk chunk)
		{
			return this.GetInnerStream(chunk.Size);
		}

		public static RwBinaryReader Load(string filePath)
		{
			return new RwBinaryReader(File.ReadAllBytes(FileSystem.GetPath(filePath)));
		}

		public static void LoadChunk(string filePath, System.Action<RwBinaryReader, RwChunk> action)
		{
			var stream = RwBinaryReader.Load(filePath);

			action(stream, RwChunk.Read(stream));
		}

		public byte ReadByte()
		{
			return this.buffer[this.index++];
		}

		public void BlockCopy(byte[] dst, int dstOffset, int count)
		{
			System.Buffer.BlockCopy(this.buffer, this.index, dst, dstOffset, count);

			this.index += count;
		}

		public int ReadPacked(int bytes)
		{
			var result = 0;

			for (var i = 0; i < bytes; i++)
			{
				result |= this.ReadByte() << (i << 0x3);
			}

			return result;
		}

		public short ReadShort()
		{
			return (short)this.ReadPacked(2);
		}

		public int ReadInt()
		{
			return this.ReadPacked(4);
		}

		public T ReadEnum<T>() where T : struct
		{
			var type = typeof(T);
			var size = Marshal.SizeOf(System.Enum.GetUnderlyingType(type));
			var value = this.ReadPacked(size).ToString();

			return (T)System.Enum.Parse(type, value);
		}

		public int[] ReadInt(int count)
		{
			return RwBinaryReader.Read(this.ReadInt, count);
		}

		public bool ReadBoolean(int bytes = 4)
		{
			return (this.ReadPacked(bytes) != 0);
		}

		public float ReadFloat()
		{
			var @float = System.BitConverter.ToSingle(this.buffer, this.index);

			this.index += 4;

			return @float;
		}

		public string ReadString(int count)
		{
			return new string(RwBinaryReader.Read(() => (char)this.ReadByte(), count)).TrimEnd((char)0);
		}

		public static T[] Read<T>(System.Func<T> func, int count)
		{
			var result = new T[count];

			for (var i = 0; i < count; i++)
			{
				result[i] = func();
			}

			return result;
		}

		public T[] Read<T>(System.Func<RwBinaryReader, T> func, int count)
		{
			return RwBinaryReader.Read(() => func(this), count);
		}

		public void Consume<T>(System.Func<RwBinaryReader, T> func, System.Action<T> action = null)
			where T : IRwBinaryStream
		{
			while (this.Position < this.Size)
			{
				var result = func(this);

				// ReSharper disable once UseNullPropagation
				if (action != null)
				{
					action.Invoke(result);
				}
			}
		}

		public void ConsumeChunk(System.Action<RwChunk> action)
		{
			while (this.TryReadChunk(out var chunk))
			{
				action(chunk);
			}
		}

		public void ConsumeChunk(System.Action<RwBinaryReader, RwChunk> action)
		{
			this.ConsumeChunk((chunk) => action(this, chunk));
		}

		public void ConsumeInnerChunk(RwChunk chunk, System.Action<RwBinaryReader, RwChunk> action)
		{
			this.GetInnerStream(chunk).ConsumeChunk(action);
		}

		public bool TryReadChunk(out RwChunk chunk)
		{
			chunk = default;

			try
			{
				chunk = RwChunk.Read(this);
			}
			catch
			{
				return false;
			}

			return true;
		}

		public T Read<T>(RwChunk chunk, System.Func<RwBinaryReader, T> into) where T : IRwBinaryStream
		{
			var innerStream = this.GetInnerStream(chunk);

			var @struct = RwChunk.Read(innerStream);

			if (@struct.Type != SectionType.Struct)
			{
				throw new InvalidDataException();
			}

			return into(innerStream);
		}

		public UnityEngine.Vector2 ReadVector2()
		{
			return new UnityEngine.Vector2(this.ReadFloat(), this.ReadFloat());
		}

		public UnityEngine.Vector2[] ReadVector2(int count)
		{
			return RwBinaryReader.Read(this.ReadVector2, count);
		}

		public UnityEngine.Vector3 ReadVector3()
		{
			return new UnityEngine.Vector3(this.ReadFloat(), this.ReadFloat(), this.ReadFloat());
		}

		public UnityEngine.Vector3[] ReadVector3(int count)
		{
			return RwBinaryReader.Read(this.ReadVector3, count);
		}

		public UnityEngine.Vector4 ReadVector4()
		{
			return new UnityEngine.Vector4(this.ReadFloat(), this.ReadFloat(), this.ReadFloat(), this.ReadFloat());
		}

		public UnityEngine.Vector4[] ReadVector4(int count)
		{
			return RwBinaryReader.Read(this.ReadVector4, count);
		}

		public UnityEngine.Quaternion ReadQuaternion()
		{
			return new UnityEngine.Quaternion(this.ReadFloat(), this.ReadFloat(), this.ReadFloat(), this.ReadFloat());
		}

		public UnityEngine.Quaternion[] ReadQuaternion(int count)
		{
			return RwBinaryReader.Read(this.ReadQuaternion, count);
		}

		public UnityEngine.Color32 ReadColor()
		{
			return new UnityEngine.Color32(this.ReadByte(), this.ReadByte(), this.ReadByte(), this.ReadByte());
		}

		public UnityEngine.Color32[] ReadColor(int count)
		{
			return RwBinaryReader.Read(this.ReadColor, count);
		}
	}

	public class EndOfRwBinaryStreamException : EndOfStreamException
	{
		public EndOfRwBinaryStreamException(string type = "stream") : base(
			$"Attempted to read past the end of the {type}.")
		{
		}
	}
}