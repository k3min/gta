namespace RenderWare.Loaders
{
	public interface IReader
	{
		byte ReadByte();

		int ReadInt();

		short ReadShort();

		float ReadFloat();

		bool ReadBoolean();

		UnityEngine.Vector2 ReadVector2();

		UnityEngine.Vector3 ReadVector3();

		UnityEngine.Vector4 ReadVector4();

		UnityEngine.Quaternion ReadQuaternion();

		UnityEngine.Color32 ReadColor();
	}
}