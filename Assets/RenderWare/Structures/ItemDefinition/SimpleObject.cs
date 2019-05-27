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
		
		private int modelId; // 0
		private string modelName; // 1
		private string textureName; // 2

		public int MeshCount; // 3

		[MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 3)]
		public float[] drawDistance; // 4

		private ObjectFlags flags; // 5

		private Dictionary<System.Type, List<IAttachment>> attachments;

		public int ModelId => this.modelId;
		public string ModelName => this.modelName;
		public string TextureName => this.textureName;
		public float DrawDistance => this.drawDistance[0];
		public ObjectFlags Flags => this.flags;

		public static SimpleObject Read(AsciiReader lr)
		{
			var info = new SimpleObject
			{
				modelId = lr.ReadInt(),
				modelName = lr.ReadString(),
				textureName = lr.ReadString(),
				MeshCount = lr.ReadInt()
			};

			info.drawDistance = new float[info.MeshCount];

			for (var i = 0; i < info.MeshCount; i++)
			{
				info.drawDistance[i] = lr.ReadFloat();
			}

			info.flags = (ObjectFlags)lr.ReadInt();

			info.attachments = new Dictionary<System.Type, List<IAttachment>>();

			return info;
		}

		public void GetObjectData(SerializationInfo info, StreamingContext context)
		{
			info.AddValue("ModelId", this.modelId);
			info.AddValue("ModelName", this.modelName, typeof(string));
			info.AddValue("TextureName", this.textureName, typeof(string));
			info.AddValue("MeshCount", this.MeshCount);

			for (var i = 0; i < this.MeshCount; i++)
			{
				info.AddValue($"DrawDistance{i}", this.drawDistance[i]);
			}

			info.AddValue("Flags", this.flags,typeof(int));
		}

		public SimpleObject(SerializationInfo info, StreamingContext context)
		{
			this.modelId = info.GetInt32("ModelId");
			this.modelName = info.GetString("ModelName");
			this.textureName = info.GetString("TextureName");
			this.MeshCount = info.GetInt32("MeshCount");

			this.drawDistance = new float[this.MeshCount];

			for (var i = 0; i < this.MeshCount; i++)
			{
				this.drawDistance[i] = info.GetSingle($"DrawDistance{i}");
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