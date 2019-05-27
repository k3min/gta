using System.IO;

namespace RenderWare.Extensions
{
	public static class BinaryReaderExtensions
	{
		public static string ReadString(this BinaryReader reader, int count)
		{
			var @string = new char[count];

			for (var i = 0; i < count; i++)
			{
				@string[i] = (char)reader.Read();
			}

			return (new string(@string)).TrimEnd((char)0);
		}
	}
}