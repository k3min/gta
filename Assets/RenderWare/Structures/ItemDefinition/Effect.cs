using System.Runtime.InteropServices;
using System.Runtime.Serialization;
using RenderWare.Loaders;

namespace RenderWare.Structures
{
	[System.Serializable]
	[StructLayout(LayoutKind.Sequential)]
	public struct Effect : IAscii, IAttachment
	{
		public const string Keyword = "2dfx";

		public int ObjectId;
		
		public static Effect Read(AsciiReader lr)
		{
			return new Effect
			{
				ObjectId = lr.ReadInt()
			};
		}

		public void GetObjectData(SerializationInfo info, StreamingContext context)
		{
			throw new System.NotImplementedException();
		}
		
		public Effect(SerializationInfo info, StreamingContext context)
		{
			throw new System.NotImplementedException();
		}
	}
}