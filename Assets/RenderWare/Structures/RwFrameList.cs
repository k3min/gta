using System.Runtime.InteropServices;
using RenderWare.Loaders;
using RenderWare.Types;

namespace RenderWare.Structures
{
	[StructLayout(LayoutKind.Sequential)]
	public struct RwFrameList : IRwBinaryStream
	{
		public int FrameCount; // 0
		[MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 0)]
		public RwFrame[] Frames; // 1

		public static RwFrameList Read(RwBinaryReader reader)
		{
			var frameList = new RwFrameList
			{
				FrameCount = reader.ReadInt()
			};

			frameList.Frames = reader.Read(RwFrame.Read, frameList.FrameCount);

			var frameIndex = 0;

			reader.ConsumeChunk((chunk) =>
			{
				switch (chunk.Type)
				{
					case SectionType.Extension:
					{
						reader.ConsumeInnerChunk(chunk,(innerStream, extension) =>
						{
							switch (extension.Type)
							{
								case SectionType.Frame:
								{
									if (frameIndex < frameList.FrameCount)
									{
										frameList.Frames[frameIndex++].Name = innerStream.ReadString(innerStream.Size);
									}

									break;
								}
							}
						});

						break;
					}
				}
			});

			return frameList;
		}
	}
}