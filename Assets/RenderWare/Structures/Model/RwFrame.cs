using System.Runtime.InteropServices;

namespace RenderWare.Structures
{
	[StructLayout(LayoutKind.Sequential)]
	public struct RwFrame : IRwBinaryStream
	{
		public const int SizeOf = (3 * 4) + (3 * 4) + (3 * 4) + (3 * 4) + 4 + 4;

		public UnityEngine.Vector3 Right;
		public UnityEngine.Vector3 Up;
		public UnityEngine.Vector3 Forward;
		public UnityEngine.Vector3 Position;
		public int ParentIndex;
		public int Unknown;
	}
}