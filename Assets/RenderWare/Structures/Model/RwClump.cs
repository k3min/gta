using System.Runtime.InteropServices;
using RenderWare.Loaders;
using RenderWare.Types;

namespace RenderWare.Structures
{
	[StructLayout(LayoutKind.Sequential)]
	public struct RwClump : IRwBinaryStream, System.IDisposable
	{
		public RwFrameList FrameList; // 0
		public RwGeometryList GeometryList; // 1

		public int AtomicCount; // 2
		[MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 2)]
		public RwAtomic[] Atomics; // 3

		public static RwClump Read(RwBinaryReader reader)
		{
			var clump = new RwClump
			{
				AtomicCount = reader.ReadInt()
			};

			clump.Atomics = new RwAtomic[clump.AtomicCount];

			var atomicIndex = 0;

			foreach (var chunk in reader.ConsumeChunk())
			{
				switch (chunk.Type)
				{
					case SectionType.FrameList:
						clump.FrameList = RwFrameList.Read(reader.ReadInnerChunk(chunk));
						break;

					case SectionType.GeometryList:
						clump.GeometryList = RwGeometryList.Read(reader.ReadInnerChunk(chunk));
						break;

					case SectionType.Atomic:
					{
						if (atomicIndex < clump.AtomicCount)
						{
							clump.Atomics[atomicIndex++] = reader.ReadInnerChunk(chunk).Read<RwAtomic>(RwAtomic.SizeOf);
						}

						break;
					}
				}
			}
			
			return clump;
		}
		
		public void Dispose()
		{
			this.GeometryList.Dispose();
		}
	}
}