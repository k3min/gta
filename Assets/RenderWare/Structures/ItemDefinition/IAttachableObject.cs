using RenderWare.Types;

namespace RenderWare.Structures
{
	public interface IAttachableObject : IItemDefinition
	{
		ObjectFlags Flags { get; }
		
		float DrawDistance { get; }

		void Attach<T>(T attachment) where T : IAttachment;
	}
}