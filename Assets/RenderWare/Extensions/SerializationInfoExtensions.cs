using System.Runtime.Serialization;

namespace RenderWare.Extensions
{
	public static class SerializationInfoExtensions
	{
		public static T GetEnum<T>(this SerializationInfo info, string name, System.Type type) where T : struct
		{
			return (T)System.Enum.Parse(typeof(T), (string)info.GetValue(name, type));
		}

		public static UnityEngine.Vector2 GetVector2(this SerializationInfo info, string name)
		{
			return new UnityEngine.Vector2(
				info.GetSingle($"{name}X"),
				info.GetSingle($"{name}Y")
			);
		}

		public static UnityEngine.Vector3 GetVector3(this SerializationInfo info, string name)
		{
			return new UnityEngine.Vector3(
				info.GetSingle($"{name}X"),
				info.GetSingle($"{name}Y"),
				info.GetSingle($"{name}Z")
			);
		}

		public static UnityEngine.Vector4 GetVector4(this SerializationInfo info, string name)
		{
			return new UnityEngine.Vector4(
				info.GetSingle($"{name}X"),
				info.GetSingle($"{name}Y"),
				info.GetSingle($"{name}Z"),
				info.GetSingle($"{name}W")
			);
		}

		public static UnityEngine.Quaternion GetQuaternion(this SerializationInfo info, string name)
		{
			return new UnityEngine.Quaternion(
				info.GetSingle($"{name}X"),
				info.GetSingle($"{name}Y"),
				info.GetSingle($"{name}Z"),
				info.GetSingle($"{name}W")
			);
		}

		public static int GetHex(this SerializationInfo info, string name)
		{
			return System.Convert.ToInt32(info.GetString(name), 16);
		}

		public static void AddValue(this SerializationInfo info, string name, float x, float y)
		{
			info.AddValue($"{name}X", x);
			info.AddValue($"{name}Y", y);
		}

		public static void AddValue(this SerializationInfo info, string name, float x, float y, float z)
		{
			info.AddValue($"{name}X", x);
			info.AddValue($"{name}Y", y);
			info.AddValue($"{name}Z", z);
		}

		public static void AddValue(this SerializationInfo info, string name, float x, float y, float z, float w)
		{
			info.AddValue($"{name}X", x);
			info.AddValue($"{name}Y", y);
			info.AddValue($"{name}Z", z);
			info.AddValue($"{name}W", w);
		}
	}
}