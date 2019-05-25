using System.Runtime.InteropServices;
using System.Runtime.Serialization;
using RenderWare.Loaders;

namespace RenderWare.Structures
{
	[System.Serializable]
	[StructLayout(LayoutKind.Sequential)]
	public struct Pickup : IAscii, IItemPlacement
	{
		public const string Keyword = "pick";

		public static Pickup Read(AsciiReader lr)
		{
			throw new System.NotImplementedException();
		}

		public void GetObjectData(SerializationInfo info, StreamingContext context)
		{
			throw new System.NotImplementedException();
		}
	}
}