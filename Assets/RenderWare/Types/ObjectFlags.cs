namespace RenderWare.Types
{
	[System.Flags]
	public enum ObjectFlags
	{
		Wet = 1 << 0,
		TimeObjectNight = 1 << 1,
		AlphaTransparency1 = 1 << 2,
		AlphaTransparency2 = 1 << 3,
		TimeObjectDay = 1 << 4,
		InteriorObject = 1 << 5,
		Shadows = 1 << 6
	}
}