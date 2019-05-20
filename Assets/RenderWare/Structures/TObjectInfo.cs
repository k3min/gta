using System.Runtime.InteropServices;
using RenderWare.Loaders;
namespace RenderWare.Structures
{
	[StructLayout(LayoutKind.Sequential)]
	public struct TObjectInfo
	{
		public int Id;
		public string ModelName;
		public string TextureName;

		public static TObjectInfo Read(AsciiReader lr)
		{
			return new TObjectInfo
			{
				Id = lr.ReadInt(),
				ModelName = lr.ReadString(),
				TextureName = lr.ReadString()
			};
		}
	}
}