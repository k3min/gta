namespace RenderWare.Helpers
{
	public static class FileSystem
	{
		public static string BasePath;

		public static string GetPath(string path)
		{
			var basePathLength = FileSystem.BasePath.Length;
			var pathLength = path.Length;

			var result = new char[basePathLength + 1 + pathLength];
			var index = 0;

			for (var i = 0; i < basePathLength; i++)
			{
				result[index++] = String.Replace(FileSystem.BasePath[i], '\\', '/');
			}

			if (result[basePathLength - 1] != '/' && path[0] != '/')
			{
				result[index++] = '/';
			}

			for (var i = 0; i < pathLength; i++)
			{
				result[index++] = String.Replace(path[i], '\\', '/');
			}

			return new string(result).TrimEnd((char)0);
		}

		public static string RemoveExtension(string path)
		{
			var index = -1;
			var length = path.Length;
			var result = new char[length];

			for (var i = 0; i < length; i++)
			{
				result[i] = path[i];

				if (path[i] == '.')
				{
					index = i;
				}
			}

			if (index == -1)
			{
				return new string(result);
			}

			for (var i = index; i < length; i++)
			{
				result[i] = (char)0;
			}

			return (new string(result)).TrimEnd((char)0);
		}

		public static string ChangeExtension(string path, string ext)
		{
			return FileSystem.RemoveExtension(path) + '.' + ext;
		}
	}
}