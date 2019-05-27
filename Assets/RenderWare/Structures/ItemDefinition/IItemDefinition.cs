namespace RenderWare.Structures
{
	public interface IItemDefinition
	{
		int ModelId { get; }
		string ModelName { get; }
		string TextureName { get; }
	}
}