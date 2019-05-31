using System.IO;
using RenderWare.Helpers;
using RenderWare.Loaders;

namespace RenderWare.Structures
{
	public class ImgArchive
	{
		private readonly int directoryEntryCount;
		private readonly DirectoryEntry[] directoryEntries;

		private readonly byte[] buffer;

		public ImgArchive(string filePath)
		{
			var dirFilePath = FileSystem.ChangeExtension(filePath, "dir");
			var imgFilePath = FileSystem.ChangeExtension(filePath, "img");

			var reader = RwBinaryReader.Load(dirFilePath);

			this.directoryEntryCount = reader.Size / DirectoryEntry.SizeOf;
			this.directoryEntries = new DirectoryEntry[this.directoryEntryCount];

			for (var i = 0; i < this.directoryEntryCount; i++)
			{
				this.directoryEntries[i] = DirectoryEntry.Read(reader);
			}

			this.buffer = File.ReadAllBytes(FileSystem.GetPath(imgFilePath));
		}

		public RwBinaryReader GetStream(DirectoryEntry entry)
		{
			return new RwBinaryReader(
				this.buffer,
				entry.Offset * DirectoryEntry.Padding,
				entry.Size * DirectoryEntry.Padding
			);
		}

		public bool TryFind(string name, out DirectoryEntry entry)
		{
			entry = default;

			for (var i = 0; i < this.directoryEntryCount; i++)
			{
				entry = this.directoryEntries[i];

				if (String.Equals(entry.Name, name))
				{
					return true;
				}
			}

			return false;
		}
	}
}