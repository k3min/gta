namespace RenderWare.Extensions
{
	public static class QuaternionExtensions
	{
		public static UnityEngine.Quaternion xzyw(this UnityEngine.Quaternion quat)
		{
			return new UnityEngine.Quaternion(quat.x, quat.z, quat.y, quat.w);
		}
	}
}