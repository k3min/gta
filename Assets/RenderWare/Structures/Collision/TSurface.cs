using System.Runtime.InteropServices;
using RenderWare.Loaders;

namespace RenderWare.Structures
{
	[StructLayout(LayoutKind.Sequential)]
	public struct TSurface
	{
		public byte Material;
		public byte Flag;
		public byte Brightness;
		public byte Light;

		public static TSurface Read(RwBinaryReader br)
		{
			return new TSurface
			{
				Material = br.ReadByte(),
				Flag = br.ReadByte(),
				Brightness = br.ReadByte(),
				Light = br.ReadByte()
			};
		}
	}
}