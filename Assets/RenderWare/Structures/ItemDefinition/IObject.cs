using System.Collections.Generic;

namespace RenderWare.Structures
{
	public interface IObject : IItemDefinition
	{
		List<PathGroup> Paths { get; }
	}
}