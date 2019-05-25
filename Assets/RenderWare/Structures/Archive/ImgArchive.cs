using System.IO;
using RenderWare.Extensions;
using RenderWare.Loaders;

namespace RenderWare.Structures
{
	public class ImgArchive
	{
		public readonly DirectoryEntry[] DirFileEntries;

		public readonly byte[] ImgFileBuffer;

		public readonly int FileCount;

		public ImgArchive(string filePath)
		{
			filePath = FileSystem.GetPath(filePath);

			var dirFilePath = System.IO.Path.ChangeExtension(filePath, "dir");
			var imgFilePath = System.IO.Path.ChangeExtension(filePath, "img");

			using (var fs = File.OpenRead(dirFilePath))
			using (var br = new BinaryReader(fs))
			{
				this.FileCount = (int)fs.Length / DirectoryEntry.SizeOf;
				this.DirFileEntries = new DirectoryEntry[this.FileCount];

				for (var index = 0; index < this.FileCount; index++)
				{
					this.DirFileEntries[index] = br.ReadDirectoryEntry();
				}
			}

			this.ImgFileBuffer = File.ReadAllBytes(imgFilePath);
		}

		public void ForEach(System.Action<DirectoryEntry, RwBinaryReader, RwChunk> action)
		{
			this.ForEach((entry, stream) => action(entry, stream, RwChunk.Read(stream)));
		}

		public void ForEach(System.Action<DirectoryEntry, RwBinaryReader> action)
		{
			for (var i = 0; i < this.FileCount; i++)
			{
				var entry = this.DirFileEntries[i];

				if (entry.Size == 0)
				{
					continue;
				}

				action(entry, new RwBinaryReader(this.ImgFileBuffer, entry.Offset, entry.Size));
			}
		}
	}
}