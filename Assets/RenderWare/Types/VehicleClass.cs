namespace RenderWare.Types
{
	[System.Flags]
	public enum VehicleClass
	{
		None = 0,
		PoorFamily = 1 << 0,
		RichFamily = 1 << 1,
		Executive = 1 << 2,
		Worker = 1 << 3,
		Special = 1 << 4,
		Big = 1 << 5,
		Taxi = 1 << 6
	}
}