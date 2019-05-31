namespace RenderWare.Helpers
{
	public static class String
	{
		public static bool Equals(string a, string b)
		{
			var la = a.Length;
			var lb = b.Length;

			var l = (la < lb) ? la : lb;

			for (var i = 0; i < l; i++)
			{
				var ca = a[i] | 32;
				var cb = b[i] | 32;

				if (ca != cb)
				{
					return false;
				}

				if (ca == (char)0)
				{
					return true;
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