using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Runtime.Serialization;
using RenderWare.Types;
using RenderWare.Loaders;

namespace RenderWare.Structures
{
	[System.Serializable]
	[StructLayout(LayoutKind.Sequential)]
	public struct SimpleObject : IAscii, IItemDefinition, ISerializable
	{
		private int id; // 0
		private string modelName; // 1
		private string textureName; // 2

		public int MeshCount; // 3

		[MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 3)]
		public float[] DrawDistance; // 4

		public ObjectFlags Flags; // 5

		[System.NonSerialized] public List<PathGroup> Paths;

		public int Id => this.id;
		public string ModelName => this.modelName;
		public string TextureName => this.textureName;

		public static SimpleObject Read(AsciiReader lr)
		{
			var info = new SimpleObject
			{
				id = lr.ReadInt(),
				modelName = lr.ReadString(),
				textureName = lr.ReadString(),
				MeshCount = lr.ReadInt()
			};

			info.DrawDistance = new float[info.MeshCount];

			for (var i = 0; i < info.MeshCount; i++)
			{
				info.DrawDistance[i] = lr.ReadFloat();
			}

			info.Flags = lr.ReadEnum<ObjectFlags>();

			info.Paths = new List<PathGroup>();

			return info;
		}

		public void GetObjectData(SerializationInfo info, StreamingContext context)
		{
			info.AddValue("Id", this.id);
			info.AddValue("ModelName", this.modelName, typeof(string));
			info.AddValue("TextureName", this.textureName, typeof(string));
			info.AddValue("MeshCount", this.MeshCount);

			for (var i = 0; i < this.MeshCount; i++)
			{
				info.AddValue($"DrawDistance{i}", this.DrawDistance[i]);
			}

			info.AddValue("Flags", (int)this.Flags);
		}

		public SimpleObject(SerializationInfo info, StreamingContext context)
		{
			this.id = info.GetInt32("Id");
			this.modelName = info.GetString("ModelName");
			this.textureName = info.GetString("TextureName");
			this.MeshCount = info.GetInt32("MeshCount");

			this.DrawDistance = new float[this.MeshCount];

			for (var i = 0; i < this.MeshCount; i++)
			{
				this.DrawDistance[i] = info.GetSingle($"DrawDistance{i}");
			}

			this.Flags = (ObjectFlags)info.GetInt32("Flags");
			
			this.Paths = new List<PathGroup>();
		}
	}
}