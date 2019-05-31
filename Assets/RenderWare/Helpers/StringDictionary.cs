using System.Collections.Generic;

namespace RenderWare.Helpers
{
	public sealed class StringDictionary<T> : Dictionary<string, T>
	{
		public StringDictionary() : base(new StringComparer())
		{
		}
	}
}