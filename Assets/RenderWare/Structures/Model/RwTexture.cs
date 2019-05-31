using System.Runtime.InteropServices;
using RenderWare.Loaders;
using RenderWare.Types;

namespace RenderWare.Structures
{
	[StructLayout(LayoutKind.Sequential)]
	public struct RwTexture : IRwBinaryStream
	{
		public FilterMode Filtering;
		public AddressingMode Wrap;
		[MarshalAs(UnmanagedType.I1)] public bool UseMipmaps;
		public byte Padding;

		public RwString Name;
		public RwString MaskName;

		public static RwTexture Read(RwBinaryReader reader)
		{
			return new RwTexture
			{
				Filtering = (FilterMode)reader.ReadByte(),
				Wrap = (AddressingMode)reader.ReadByte(),
				UseMipmaps = reader.ReadBoolean(1),
				Padding = reader.ReadByte(),
				Name = RwString.Read(reader),
				MaskName = RwString.Read(reader)
			};
		}
	}
}