using System.IO;
using System.Runtime.InteropServices;
using RenderWare.Extensions;

namespace RenderWare.Structures
{
	[StructLayout(LayoutKind.Sequential)]
	public struct DirectoryEntry
	{
		public const int NameLength = 24;
		public const int SizeOf = 4 + 4 + DirectoryEntry.NameLength;
		public const int Padding = 2048;

		public int Offset;
		public int Size;

		[MarshalAs(UnmanagedType.LPStr, SizeConst = DirectoryEntry.NameLength)]
		public string Name;

		public static DirectoryEntry Read(BinaryReader reader)
		{
			return new DirectoryEntry
			{
				Offset = reader.ReadInt32(),
				Size = reader.ReadInt32(),
				Name = reader.ReadString(DirectoryEntry.NameLength).ToLower()
			};
		}
	}
}