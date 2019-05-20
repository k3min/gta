using System.Runtime.InteropServices;
using RenderWare.Loaders;

namespace RenderWare.Structures
{
	[StructLayout(LayoutKind.Sequential)]
	public struct Instance : IAscii, IItem
	{
		public const string Keyword = "inst";
		
		public int ModelId;
		public string ModelName;
		public UnityEngine.Vector3 Position;
		public UnityEngine.Vector3 Scale;
		public UnityEngine.Quaternion Rotation;

		public static Instance Read(AsciiReader ar)
		{
			return new Instance
			{
				ModelId = ar.ReadInt(),
				ModelName = ar.ReadString(),
				Position = ar.ReadVector3(),
				Scale = ar.ReadVector3(),
				Rotation = ar.ReadQuaternion()
			};
		}
	}
}