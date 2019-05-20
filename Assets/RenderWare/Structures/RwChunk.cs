using System.Runtime.InteropServices;
using RenderWare.Loaders;
using RenderWare.Types;

namespace RenderWare.Structures
{
	[StructLayout(LayoutKind.Sequential)]
	public struct RwChunk : IRwBinaryStream
	{
		public const int SizeOf = 12;

		public SectionType Type;
		public int Size;
		public int Version;

		public static RwChunk Read(RwBinaryReader reader)
		{
			var position = reader.Position;

			if (position + RwChunk.SizeOf > reader.Size)
			{
				throw new EndOfRwBinaryStreamException();
			}

			var chunk = new RwChunk
			{
				Type = (SectionType)reader.ReadInt(),
				Size = reader.ReadInt(),
				Version = reader.ReadInt()
			};

			if (position + chunk.Size > reader.Size)
			{
				throw new EndOfRwBinaryStreamException(chunk.Type.ToString());
			}

			return chunk;
		}

		public override string ToString()
		{
			return $"Type: {this.Type}, Size: {this.Size}";
		}
	}
}