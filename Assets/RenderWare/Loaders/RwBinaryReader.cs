using System.Collections.Generic;
using System.IO;
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

		public RwBinaryReader(byte[] buffer, int offset = 0) : this(buffer, offset, buffer.Length)
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

		public static RwBinaryReader Load(string filePath)
		{
			return new RwBinaryReader(File.ReadAllBytes(FileSystem.GetPath(filePath)));
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

		public bool ReadBoolean()
		{
			return this.ReadBoolean(4);
		}

		public bool ReadBoolean(int size)
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
			
			return (new string(@string)).TrimEnd((char)0);
		}

		public IEnumerable<RwChunk> ConsumeChunk()
		{
			while (RwChunk.TryRead(this, out var chunk))
			{
				yield return chunk;
			}
		}

		public RwBinaryReader ReadInnerChunk(RwChunk chunk)
		{
			var innerStream = this.GetInnerStream(chunk.Size);
			var innerChunk = innerStream.Read<RwChunk>(RwChunk.SizeOf);

			if (innerChunk.Type != SectionType.Struct)
			{
				throw new InvalidDataException();
			}

			return innerStream;
		}

		public unsafe T[] Read<T>(int count, int size) where T : unmanaged
		{
			var result = new T[count];

			if (count == 0)
			{
				return result;
			}

			size *= count;

			fixed (void* src = &this.buffer[this.index], dst = &result[0])
			{
				System.Buffer.MemoryCopy(src, dst, size, size);
			}

			this.index += size;

			return result;
		}

		public unsafe T Read<T>(int size) where T : unmanaged
		{
			var result = new T();

			fixed (void* src = &this.buffer[this.index])
			{
				System.Buffer.MemoryCopy(src, &result, size, size);
			}

			this.index += size;

			return result;
		}

		public UnityEngine.Vector2 ReadVector2()
		{
			return this.Read<UnityEngine.Vector2>(2 * 4);
		}

		public UnityEngine.Vector3 ReadVector3()
		{
			return this.Read<UnityEngine.Vector3>(3 * 4);
		}

		public UnityEngine.Vector4 ReadVector4()
		{
			return this.Read<UnityEngine.Vector4>(4 * 4);
		}

		public UnityEngine.Quaternion ReadQuaternion()
		{
			return this.Read<UnityEngine.Quaternion>(4 * 4);
		}

		public UnityEngine.Color32 ReadColor()
		{
			return this.Read<UnityEngine.Color32>(4);
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