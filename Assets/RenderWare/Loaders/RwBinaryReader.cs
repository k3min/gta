using System.IO;
using RenderWare.Helpers;
using RenderWare.Structures;
using RenderWare.Types;

namespace RenderWare.Loaders
{
	public class RwBinaryReader
	{
		private readonly byte[] buffer;
		private readonly int offset;

		private int index;

		public readonly int Size;

		public int Position => (this.index - this.offset);

		public RwBinaryReader(byte[] buffer, int offset, int size)
		{
			this.buffer = buffer;
			this.offset = offset;
			this.index = offset;
			this.Size = size;
		}

		public RwBinaryReader(byte[] buffer, int offset = 0) : this(buffer, offset, buffer.Length)
		{
		}

		public RwBinaryReader GetInnerStream(int count)
		{
			var inner = new RwBinaryReader(this.buffer, this.index, count);

			this.index += count;

			return inner;
		}

		public static RwBinaryReader Load(string filePath)
		{
			return new RwBinaryReader(File.ReadAllBytes(FileSystem.GetPath(filePath)));
		}

		public byte ReadByte()
		{
			return this.buffer[this.index++];
		}

		public unsafe short ReadShort()
		{
			short @short;

			fixed (byte* @byte = &this.buffer[this.index])
			{
				@short = *((short*)@byte);
			}

			this.index += 2;

			return @short;
		}

		public unsafe int ReadInt()
		{
			int @int;

			fixed (byte* @byte = &this.buffer[this.index])
			{
				@int = *((int*)@byte);
			}

			this.index += 4;

			return @int;
		}

		public bool ReadBoolean(int size = 4)
		{
			var @bool = (this.buffer[this.index] != 0);

			this.index += size;

			return @bool;
		}

		public unsafe float ReadFloat()
		{
			var @int = this.ReadInt();

			return *(float*)&@int;
		}

		/// <todo>Refactor</todo>
		public string ReadString(int count)
		{
			var @string = new char[count];
			var end = false;

			for (var i = 0; i < count; i++)
			{
				var @char = (char)this.ReadByte();

				if (end)
				{
					continue;
				}

				if (@char == (char)0)
				{
					end = true;
					continue;
				}

				@string[i] = @char;
			}

			return new string(@string);
		}

		public bool TryReadChunk(out RwChunk chunk)
		{
			chunk = default;

			var position = this.Position;

			if (position + RwChunk.SizeOf > this.Size)
			{
				return false;
			}

			this.Read(RwChunk.SizeOf, ref chunk);

			return (position + chunk.Size <= this.Size);
		}

		public RwBinaryReader ReadInnerChunk(int size)
		{
			var innerStream = this.GetInnerStream(size);
			var innerChunk = new RwChunk();

			innerStream.Read(RwChunk.SizeOf, ref innerChunk);

			if (innerChunk.Type != SectionType.Struct)
			{
				throw new InvalidDataException();
			}

			return innerStream;
		}

		public unsafe void Read<T>(int count, int size, ref T[] result, int dstOffset = 0) where T : unmanaged
		{
			if (count == 0)
			{
				return;
			}

			size *= count;

			fixed (void* src = &this.buffer[this.index], dst = &result[dstOffset])
			{
				System.Buffer.MemoryCopy(src, dst, size, size);
			}

			this.index += size;
		}

		public unsafe void Read<T>(int size, ref T result) where T : unmanaged
		{
			fixed (void* src = &this.buffer[this.index], dst = &result)
			{
				System.Buffer.MemoryCopy(src, dst, size, size);
			}

			this.index += size;
		}
	}
}