using System.IO;
using System.Runtime.InteropServices;
using RenderWare.Extensions;

namespace RenderWare.Structures
{
	[StructLayout(LayoutKind.Sequential)]
	public struct DirectoryEntry
	{
		public const int SizeOf = 32;
		
		public int Offset;
		public int Size;
		[MarshalAs(UnmanagedType.LPStr, SizeConst = 24)]
		public string Name;

		public static DirectoryEntry Read(BinaryReader reader)
		{
			return new DirectoryEntry
			{
				Offset = reader.ReadInt32() * 2048,
				Size = reader.ReadInt32() * 2048,
				Name = reader.ReadString(24)
			};
		}
		
		public override string ToString()
		{
			return $"Offset: {this.Offset}, Size: {this.Size}, Name: {this.Name}";
		}
	}
}