using System.Runtime.InteropServices;
using System.Runtime.Serialization;
using RenderWare.Loaders;

namespace RenderWare.Structures
{
	[System.Serializable]
	[StructLayout(LayoutKind.Sequential)]
	public struct CutSceneObject : IAscii, IItemDefinition
	{
		public const string Keyword = "hier";

		private int modelId;
		private string modelName; 
		private string textureName;

		public int ModelId => this.modelId;
		public string ModelName => this.modelName;
		public string TextureName => this.textureName;

		public static CutSceneObject Read(AsciiReader lr)
		{
			return new CutSceneObject
			{
				modelId = lr.ReadInt(),
				modelName = lr.ReadString(),
				textureName = lr.ReadString()
			};
		}
		
		public void GetObjectData(SerializationInfo info, StreamingContext context)
		{
			info.AddValue("ModelId", this.modelId);
			info.AddValue("ModelName", this.modelName, typeof(string));
			info.AddValue("TextureName", this.textureName, typeof(string));
		}
		
		public CutSceneObject(SerializationInfo info, StreamingContext context)
		{
			this.modelId = info.GetInt32("ModelId");
			this.modelName = info.GetString("ModelName");
			this.textureName = info.GetString("TextureName");
		}
	}
}