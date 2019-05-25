using System.IO;

namespace RenderWare
{
	public static class FileSystem
	{
		public static string BasePath { get; set; }

		public static string GetPath(string path)
		{
			return Path.Combine(FileSystem.BasePath, path).Replace('\\', '/');
		}
	}
}