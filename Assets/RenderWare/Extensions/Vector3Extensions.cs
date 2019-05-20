namespace RenderWare.Extensions
{
	public static class Vector3Extensions
	{
		public static UnityEngine.Vector3 xzy(this UnityEngine.Vector3 vec)
		{
			return new UnityEngine.Vector3(vec.x, vec.z, vec.y);
		}
	}
}