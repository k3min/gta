using System.Runtime.InteropServices;
using RenderWare.Loaders;

namespace RenderWare.Structures
{
	[StructLayout(LayoutKind.Sequential)]
	public struct RwFrame : IRwBinaryStream
	{
		public UnityEngine.Vector3 Right;
		public UnityEngine.Vector3 Up;
		public UnityEngine.Vector3 Forward;
		
		public UnityEngine.Vector3 Position;
		
		public int ParentIndex;

		public int Unknown;
		
		[System.NonSerialized]
		public string Name;

		public static RwFrame Read(RwBinaryReader reader)
		{
			return new RwFrame
			{
				Right = reader.ReadVector3(),
				Up = reader.ReadVector3(),
				Forward = reader.ReadVector3(),
				Position = reader.ReadVector3(),
				ParentIndex = reader.ReadInt(),
				Unknown = reader.ReadInt()
			};
		}
		
		public override string ToString()
		{
			return string.IsNullOrEmpty(this.Name) ? base.ToString() : this.Name;
		}
	}
}