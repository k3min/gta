namespace RenderWare.Types
{
	public enum PlatformId
	{
		Xbox = 0x05,
		D3D8 = 0x08,
		D3D9 = 0x09,
		Ps2 = 'P' | 'S' << 8 | '2' << 16 | 0x00 << 24
	}
}