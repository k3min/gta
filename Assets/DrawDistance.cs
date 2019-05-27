using Boo.Lang;
using UnityEngine;

public class DrawDistance : MonoBehaviour
{
	private static readonly List<DrawDistance> parents = new List<DrawDistance>();

	public float Min;
	public float Max;

	public MeshRenderer Renderer;

	private Vector3 pos;
	private Transform cam;
	private string id;

	private void Awake()
	{
		this.pos = this.transform.position;
		this.cam = Camera.main.transform;
		this.id = this.gameObject.name;
		this.Renderer = this.GetComponentInChildren<MeshRenderer>();
	}

	public static void FindParent(DrawDistance dd)
	{
		if (!dd.id.StartsWith("lod"))
		{
			DrawDistance.parents.Add(dd);
			return;
		}

		foreach (var parent in DrawDistance.parents)
		{
			if (parent.id.Substring(3) != dd.id.Substring(3))
			{
				continue;
			}

			dd.Min = parent.Max;

			return;
		}
	}

	private void Update()
	{
		var distance = Vector3.Distance(this.cam.position, this.pos);

		this.Renderer.enabled = (distance > this.Min && distance <= this.Max);
	}
}