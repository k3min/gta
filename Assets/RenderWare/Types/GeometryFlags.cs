namespace RenderWare.Types
{
	[System.Flags]
	public enum GeometryFlags
	{
		None=0,
		IsTriangleStrip = 1 << 0,
		HasTranslation = 1 << 1,
		HasTexCoords = 1 << 2,
		HasColors = 1 << 3,
		HasNormals = 1 << 4,
		IsLit = 1 << 5,
		ModulateMaterialColor = 1 << 6,
		HasMultipleTexCoords = 1 << 7,
		Native = 1 << 24
	}
}