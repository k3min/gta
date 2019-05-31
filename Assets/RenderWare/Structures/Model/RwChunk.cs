using System.Runtime.InteropServices;
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

		public override string ToString()
		{
			return $"Type: {this.Type}, Size: {this.Size}";
		}
	}
}