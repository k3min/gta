using System.Runtime.InteropServices;

namespace RenderWare.Structures
{
	[StructLayout(LayoutKind.Sequential)]
	public struct TKey
	{
		public const string Magic = "TKEY";
		public const int SizeOf = 12;
	}
}