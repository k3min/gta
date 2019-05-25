using System.Runtime.InteropServices;
using RenderWare.Loaders;

namespace RenderWare.Structures
{
	[StructLayout(LayoutKind.Sequential)]
	public struct CutSceneObject : IAscii, IItemDefinition
	{
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
	}
}