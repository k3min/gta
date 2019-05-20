using System.Runtime.InteropServices;
using RenderWare.Loaders;

namespace RenderWare.Structures
{
	[StructLayout(LayoutKind.Sequential)]
	public struct Pickup : IAscii, IItem
	{
		public const string Keyword = "pick";

		public static Pickup Read(AsciiReader lr)
		{
			throw new System.NotImplementedException();
		}
	}
}