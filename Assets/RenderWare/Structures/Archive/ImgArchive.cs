using System.IO;
using System.Threading.Tasks;
using RenderWare.Extensions;
using RenderWare.Loaders;

namespace RenderWare.Structures
{
	public class ImgArchive
	{
		public readonly DirectoryEntry[] DirFileEntries;

		private readonly byte[] imgFileBuffer;

		public readonly int FileCount;

		public readonly string FilePath;

		public ImgArchive(string filePath)
		{
			this.FilePath = filePath.ToLower();

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

			this.imgFileBuffer = File.ReadAllBytes(imgFilePath);
		}

		public async Task<bool> TryFind(string name,
			System.Func<DirectoryEntry, RwBinaryReader, RwChunk, Task> action)
		{
			for (var i = 0; i < this.FileCount; i++)
			{
				var entry = this.DirFileEntries[i];

				if (entry.Size == 0 || entry.Name.ToLower() != name)
				{
					continue;
				}

				var stream = new RwBinaryReader(this.imgFileBuffer, entry.Offset, entry.Size);

				await action(entry, stream, RwChunk.Read(stream));

				return true;
			}

			return false;
		}
	}
}