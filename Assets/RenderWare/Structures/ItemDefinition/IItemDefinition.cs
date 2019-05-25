namespace RenderWare.Structures
{
	public interface IItemDefinition
	{
		int Id { get; }
		string ModelName { get; }
		string TextureName { get; }
	}
}