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

		[System.NonSerialized] public string[] FrameNames;

		public static RwFrameList Read(RwBinaryReader reader)
		{
			var frameList = new RwFrameList
			{
				FrameCount = reader.ReadInt()
			};

			frameList.Frames = reader.Read<RwFrame>(frameList.FrameCount, RwFrame.SizeOf);

			frameList.FrameNames = new string[frameList.FrameCount];

			var frameIndex = 0;

			foreach (var chunk in reader.ConsumeChunk())
			{
				switch (chunk.Type)
				{
					case SectionType.Extension:
					{
						var innerStream = reader.GetInnerStream(chunk.Size);

						foreach (var innerChunk in innerStream.ConsumeChunk())
						{
							switch (innerChunk.Type)
							{
								case SectionType.Frame:
								{
									if (frameIndex < frameList.FrameCount)
									{
										frameList.FrameNames[frameIndex++] = innerStream.ReadString(innerStream.Size);
									}

									break;
								}
							}
						}

						break;
					}
				}
			}

			return frameList;
		}
	}
}