using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Runtime.Serialization;
using RenderWare.Types;
using RenderWare.Loaders;

namespace RenderWare.Structures
{
	[System.Serializable]
	[StructLayout(LayoutKind.Sequential)]
	public struct TimedObject : IAscii, IObject, ISerializable
	{
		public const string Keyword = "tobj";
		
		private int id; // 0
		private string modelName; // 1
		private string textureName; // 2

		public int MeshCount; // 3

		[MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 3)]
		public float[] DrawDistance; // 4

		public ObjectFlags Flags; // 5

		public int TimeOn; // 6
		public int TimeOff; // 7

		private List<PathGroup> paths;

		public int Id => this.id;
		public string ModelName => this.modelName;
		public string TextureName => this.textureName;

		public List<PathGroup> Paths => this.paths;
		
		public static TimedObject Read(AsciiReader lr)
		{
			var info = new TimedObject
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

			info.TimeOn = lr.ReadInt();
			info.TimeOff = lr.ReadInt();

			info.paths = new List<PathGroup>();

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
			info.AddValue("TimeOn",this.TimeOn);
			info.AddValue("TimeOff",this.TimeOff);
		}

		public TimedObject(SerializationInfo info, StreamingContext context)
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

			this.TimeOn = info.GetInt32("TimeOn");
			this.TimeOff = info.GetInt32("TimeOff");

			this.paths = new List<PathGroup>();
		}
	}
}