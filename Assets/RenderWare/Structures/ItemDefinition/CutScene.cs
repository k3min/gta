using System.Runtime.InteropServices;
using RenderWare.Loaders;

namespace RenderWare.Structures
{
	[StructLayout(LayoutKind.Sequential)]
	public struct CutScene : IAscii, IItemDefinition
	{
		public const string Keyword = "hier";

		private int id;
		private string modelName; 
		private string textureName;

		public int Id => this.id;
		public string ModelName => this.modelName;
		public string TextureName => this.textureName;

		public static CutScene Read(AsciiReader lr)
		{
			return new CutScene
			{
				id = lr.ReadInt(),
				modelName = lr.ReadString(),
				textureName = lr.ReadString()
			};
		}
	}
}