using System.Runtime.InteropServices;
using RenderWare.Loaders;
using RenderWare.Types;

namespace RenderWare.Structures
{
	[StructLayout(LayoutKind.Sequential)]
	public struct RwChunk : IRwBinaryStream
	{
		public const int SizeOf = 4 + 4 + 4;

		public SectionType Type;
		public int Size;
		public int Version;

		public static bool TryRead(RwBinaryReader reader, out RwChunk chunk)
		{
			chunk = default;

			var position = reader.Position;

			if (position + RwChunk.SizeOf > reader.Size)
			{
				return false;
			}

			reader.Read(RwChunk.SizeOf, ref chunk);

			return (position + chunk.Size <= reader.Size);
		}

		public override string ToString()
		{
			return $"Type: {this.Type}, Size: {this.Size}";
		}
	}
}