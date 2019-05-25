using RenderWare.Types;

namespace RenderWare.Structures
{
	public interface IAttachableObject : IItemDefinition
	{
		ObjectFlags Flags { get; }

		void Attach<T>(T attachment) where T : IAttachment;
	}
}