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
		
		public static char[] RemoveExtension(char[] path)
		{
			var result = new char[path.Length];

			for (var i = 0; i < path.Length; i++)
			{
				result[i] = path[i];

				if (path[i] == '.')
				{
					break;
				}
			}

			return result;
		}

		public static char[] ChangeExtension(char[] path, char[] ext)
		{
			int length;

			var i = Helpers.IndexOf(path, '.');

			if (i == -1)
			{
				length = path.Length + ext.Length;
			}
			else
			{
				length = (path.Length + (i - path.Length)) + ext.Length;
			}
			
			var result = new char[length];

			return result;
		}
	}
}