using System.Collections.Generic;

namespace RenderWare.Helpers
{
	public sealed class StringDictionary<T> : Dictionary<string, T>
	{
		public StringDictionary() : base(new StringDictionary<T>.StringComparer())
		{
		}

		private sealed class StringComparer : IEqualityComparer<string>
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
}