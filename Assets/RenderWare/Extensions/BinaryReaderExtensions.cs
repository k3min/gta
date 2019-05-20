using System.IO;
using RenderWare.Structures;

namespace RenderWare.Extensions
{
	public static class BinaryReaderExtensions
	{
		public static string ReadString(this BinaryReader reader, int count)
		{
			return System.Text.Encoding.ASCII.GetString(reader.ReadBytes(count)).TrimEnd((char)0);
		}

		public static DirectoryEntry ReadDirectoryEntry(this BinaryReader reader)
		{
			return DirectoryEntry.Read(reader);
		}

		public static UnityEngine.Vector2 ReadVector2(this BinaryReader reader)
		{
			return new UnityEngine.Vector2(reader.ReadSingle(), reader.ReadSingle());
		}

		public static UnityEngine.Vector3 ReadVector3(this BinaryReader reader)
		{
			return new UnityEngine.Vector3(reader.ReadSingle(), reader.ReadSingle(), reader.ReadSingle());
		}

		public static UnityEngine.Vector4 ReadVector4(this BinaryReader reader)
		{
			return new UnityEngine.Vector4(reader.ReadSingle(), reader.ReadSingle(), reader.ReadSingle(),
				reader.ReadSingle());
		}

		public static UnityEngine.Quaternion ReadQuaternion(this BinaryReader reader)
		{
			return new UnityEngine.Quaternion(reader.ReadSingle(), reader.ReadSingle(), reader.ReadSingle(),
				reader.ReadSingle());
		}

		public static UnityEngine.Color32 ReadColor(this BinaryReader reader)
		{
			return new UnityEngine.Color32(reader.ReadByte(), reader.ReadByte(), reader.ReadByte(), reader.ReadByte());
		}
	}
}