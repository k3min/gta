namespace RenderWare
{
	public static class Helpers
	{
		public static bool EqualsCaseIgnore(string a, string b)
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

		public static int IndexOf(char[] @string, char @char)
		{
			for (var i = 0; i < @string.Length; i++)
			{
				if (@string[i] == @char)
				{
					return i;
				}
			}

			return -1;
		}
	}
}