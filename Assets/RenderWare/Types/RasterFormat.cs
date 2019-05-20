namespace RenderWare.Types
{
	[System.Flags]
	public enum RasterFormat
	{
		Default = 0x0000,
		ARGB1555 = 0x0100,
		RGB565 = 0x0200,
		RGBA4444 = 0x0300,
		LUM8 = 0x0400,
		RGBA32 = 0x0500,
		RGB24 = 0x0600,
		RGB555 = 0x0a00,
		AutoMipmaps = 0x1000,
		Pal8 = 0x2000,
		Pal4 = 0x4000,
		Mipmaps = 0x8000
	}
}