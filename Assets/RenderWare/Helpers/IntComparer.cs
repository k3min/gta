using System.Collections.Generic;

namespace RenderWare.Helpers
{
	internal sealed class IntComparer : IEqualityComparer<int>
	{
		public bool Equals(int x, int y)
		{
			return (x == y);
		}

		public int GetHashCode(int obj)
		{
			return obj.GetHashCode();
		}
	}
}