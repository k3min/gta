using System.Runtime.InteropServices;
using System.Runtime.Serialization;
using RenderWare.Extensions;
using RenderWare.Loaders;

namespace RenderWare.Structures
{
	[System.Serializable]
	[StructLayout(LayoutKind.Sequential)]
	public struct Instance : IAscii, IItemPlacement
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

		public void GetObjectData(SerializationInfo info, StreamingContext context)
		{
			info.AddValue("ModelId", this.ModelId);
			info.AddValue("ModelName", this.ModelName, typeof(string));
			info.AddValue("Position", this.Position.x, this.Position.y, this.Position.z);
			info.AddValue("Scale", this.Scale.x, this.Scale.y, this.Scale.z);
			info.AddValue("Rotation", this.Rotation.x, this.Rotation.y, this.Rotation.z, this.Rotation.w);
		}

		public Instance(SerializationInfo info, StreamingContext context)
		{
			this.ModelId = info.GetInt32("ModelId");
			this.ModelName = info.GetString("ModelName");
			this.Position = info.GetVector3("Position");
			this.Scale = info.GetVector3("Scale");
			this.Rotation = info.GetQuaternion("Rotation");
		}
	}
}