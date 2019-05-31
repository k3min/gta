using System.Runtime.InteropServices;
using RenderWare.Loaders;
using RenderWare.Types;

namespace RenderWare.Structures
{
	[StructLayout(LayoutKind.Sequential)]
	public struct RwString : IRwBinaryStream
	{
		public SectionType Type; // 0
		public int Size; // 1
		public int Version; // 2

		[MarshalAs(UnmanagedType.LPStr, SizeParamIndex = 1)]
		public string Value; // 3

		public static RwString Read(RwBinaryReader reader)
		{
			var @string = new RwString
			{
				Type = (SectionType)reader.ReadInt(),
				Size = reader.ReadInt(),
				Version = reader.ReadInt()
			};

			@string.Value = reader.ReadString(@string.Size);

			return @string;
		}

		public override string ToString()
		{
			return this.Value;
		}

		public static implicit operator string(RwString @string)
		{
			return @string.Value;
		}
	}
}