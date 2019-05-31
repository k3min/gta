using System.IO;

namespace RenderWare.Extensions
{
	public static class BinaryReaderExtensions
	{
		public static string ReadString(this BinaryReader reader, int count)
		{
			var @string = new char[count];
			var end = false;

			for (var i = 0; i < count; i++)
			{
				var @char = (char)reader.Read();

				if (end)
				{
					continue;
				}

				if (@char == (char)0)
				{
					end = true;
					continue;
				}

				@string[i] = @char;
			}

			return (new string(@string)).TrimEnd((char)0);
		}
	}
}