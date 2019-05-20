namespace RenderWare.Types
{
	[System.Flags]
	public enum CullAttributeFlags
	{
		CamCloseInForPlayer = 1 << 0,
		CamStairsForPlayer = 1 << 1,
		Cam1StPersonForPlayer = 1 << 2,
		CamNoRain = 1 << 3,
		NoPolice = 1 << 4,
		Unknown1 = 1 << 5,
		DoINeedToLoadCollision = 1 << 6,
		Unknown2 = 1 << 7,
		PoliceAbandonCars = 1 << 8
	}
}