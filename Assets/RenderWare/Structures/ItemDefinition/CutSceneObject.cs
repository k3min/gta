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

		private int id;
		private string modelName; 
		private string textureName;

		public int Id => this.id;
		public string ModelName => this.modelName;
		public string TextureName => this.textureName;

		public static CutSceneObject Read(AsciiReader lr)
		{
			return new CutSceneObject
			{
				id = lr.ReadInt(),
				modelName = lr.ReadString(),
				textureName = lr.ReadString()
			};
		}
		
		public void GetObjectData(SerializationInfo info, StreamingContext context)
		{
			info.AddValue("Id", this.id);
			info.AddValue("ModelName", this.modelName, typeof(string));
			info.AddValue("TextureName", this.textureName, typeof(string));
		}
		
		public CutSceneObject(SerializationInfo info, StreamingContext context)
		{
			this.id = info.GetInt32("Id");
			this.modelName = info.GetString("ModelName");
			this.textureName = info.GetString("TextureName");
		}
	}
}