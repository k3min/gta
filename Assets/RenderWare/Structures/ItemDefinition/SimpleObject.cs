using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Runtime.Serialization;
using RenderWare.Extensions;
using RenderWare.Types;
using RenderWare.Loaders;

namespace RenderWare.Structures
{
	[System.Serializable]
	[StructLayout(LayoutKind.Sequential)]
	public struct SimpleObject : IAscii, IAttachableObject
	{
		public const string Keyword = "objs";
		
		private int id; // 0
		private string modelName; // 1
		private string textureName; // 2

		public int MeshCount; // 3

		[MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 3)]
		public float[] DrawDistance; // 4

		private ObjectFlags flags; // 5

		private Dictionary<System.Type, List<IAttachment>> attachments;

		public int Id => this.id;
		public string ModelName => this.modelName;
		public string TextureName => this.textureName;
		public ObjectFlags Flags => this.flags;

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

			info.flags = lr.ReadEnum<ObjectFlags>();

			info.attachments = new Dictionary<System.Type, List<IAttachment>>();

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

			info.AddValue("Flags", this.flags,typeof(int));
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

			this.flags = info.GetEnum<ObjectFlags>("Flags",typeof(int));
			
			this.attachments = new Dictionary<System.Type, List<IAttachment>>();
		}

		public void Attach<T>(T attachment) where T : IAttachment
		{
			var type = typeof(T);

			if (!this.attachments.ContainsKey(type))
			{
				this.attachments[type] = new List<IAttachment>();
			}

			this.attachments[type].Add(attachment);
		}
	}
}