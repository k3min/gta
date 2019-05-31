using System.Collections.Generic;

namespace RenderWare.Helpers
{
	internal sealed class StringComparer : IEqualityComparer<string>
	{
		public bool Equals(string x, string y)
		{
			return String.Equals(x, y);
		}

		public int GetHashCode(string obj)
		{
			return obj.GetHashCode();
		}
	}
}