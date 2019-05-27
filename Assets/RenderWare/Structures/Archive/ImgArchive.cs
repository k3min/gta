using System.Collections.Generic;
using System.IO;
using System.Text;
using RenderWare.Loaders;

namespace RenderWare.Structures
{
	public class ImgArchive
	{
		private readonly DirectoryEntry[] dirFileEntries;
		private readonly byte[] imgFileBuffer;

		public readonly int FileCount;
		public readonly string FilePath;

		public IEnumerable<DirectoryEntry> DirectoryEntries
		{
			get
			{
				for (var i = 0; i < this.FileCount; i++)
				{
					var entry = this.dirFileEntries[i];

					if (entry.Size == 0)
					{
						continue;
					}

					yield return entry;
				}
			}
		}

		public ImgArchive(string filePath)
		{
			this.FilePath = filePath.ToLower();

			filePath = FileSystem.GetPath(filePath);

			var dirFilePath = System.IO.Path.ChangeExtension(filePath, "dir");
			var imgFilePath = System.IO.Path.ChangeExtension(filePath, "img");

			using (var fs = File.OpenRead(dirFilePath))
			using (var br = new BinaryReader(fs, Encoding.ASCII))
			{
				this.FileCount = (int)fs.Length / DirectoryEntry.SizeOf;
				this.dirFileEntries = new DirectoryEntry[this.FileCount];

				for (var index = 0; index < this.FileCount; index++)
				{
					this.dirFileEntries[index] = DirectoryEntry.Read(br);
				}
			}

			this.imgFileBuffer = File.ReadAllBytes(imgFilePath);
		}

		public RwBinaryReader GetStream(DirectoryEntry entry)
		{
			return new RwBinaryReader(
				this.imgFileBuffer,
				entry.Offset * DirectoryEntry.Padding,
				entry.Size * DirectoryEntry.Padding
			);
		}
	}
}