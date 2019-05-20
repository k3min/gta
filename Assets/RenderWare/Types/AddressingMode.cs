namespace RenderWare.Types
{
	[System.Flags]
	public enum AddressingMode : byte
	{
		None = 0x00,
		WrapU = 0x10,
		WrapV = 0x01,
		MirrorU = 0x20,
		MirrorV = 0x02,
		ClampU = 0x30,
		ClampV = 0x03
	}
}