namespace RenderWare.Extensions
{
	public static class StringExtensions
	{
		public static bool EqualsCaseIgnore(this string @this, string compare)
		{
			var length = @this.Length;

			if (length != compare.Length)
			{
				return false;
			}

			for (var i = 0; i < length; i++)
			{
				if ((@this[i] | 32) != (compare[i] | 32))
				{
					return false;
				}
			}

			return true;
		}
	}
}