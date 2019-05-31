namespace RenderWare.Helpers
{
	public static class String
	{
		public static bool Equals(string a, string b)
		{
			var length = a.Length;

			if (length != b.Length)
			{
				return false;
			}

			for (var i = 0; i < length; i++)
			{
				if ((a[i] | 32) != (b[i] | 32))
				{
					return false;
				}
			}

			return true;
		}

		public static char Replace(char @char, char from, char to)
		{
			return (@char == from) ? to : @char;
		}
	}
}