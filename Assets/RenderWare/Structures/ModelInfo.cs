using System.Collections.Generic;
using System.Runtime.InteropServices;
using RenderWare.Types;
using RenderWare.Loaders;
namespace RenderWare.Structures
{
	[StructLayout(LayoutKind.Sequential)]
	public struct ModelInfo : IAscii, IObjectInfo
	{
		public TObjectInfo Info;
		public int MeshCount;
		public float[] DrawDistance;
		public ObjectFlags Flags;

		public int TimeOn;
		public int TimeOff;

		[System.NonSerialized] public List<PathGroup> Paths;
		
		public int Id => this.Info.Id;
		public string ModelName => this.Info.ModelName;
		public string TextureName => this.Info.TextureName;
		
		public static ModelInfo Read(AsciiReader lr)
		{
			var info = new ModelInfo
			{
				Info = TObjectInfo.Read(lr),
				MeshCount = lr.ReadInt(),
				DrawDistance = new float[3]
			};

			for (var i = 0; i < info.MeshCount; i++)
			{
				info.DrawDistance[i] = lr.ReadFloat();
			}

			info.Flags = lr.ReadEnum<ObjectFlags>();
			info.TimeOn = 0;
			info.TimeOff = 24;

			info.Paths = new List<PathGroup>();

			return info;
		}
	}
}