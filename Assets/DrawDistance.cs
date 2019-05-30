using System.Collections.Generic;
using UnityEngine;

public class DrawDistance : MonoBehaviour
{
	private static readonly HashSet<DrawDistance> parents = new HashSet<DrawDistance>();

	private string id;
	
	public float Min;
	public float Max;
	
	public MeshRenderer Renderer { get; private set; }
	public Vector3 Position { get; private set; }
	public bool IsLod { get; private set; }

	private void Awake()
	{
		this.Position = this.transform.position;
		this.id = this.gameObject.name;
		this.Renderer = this.GetComponentInChildren<MeshRenderer>();

		if (this.id.StartsWith("lod"))
		{
			this.IsLod = true;
		}
	}

	private void OnEnable()
	{
		DrawDistances.LODs.Add(this);
	}

	private void OnDisable()
	{
		DrawDistances.LODs.Remove(this);
	}

	public static void FindParent(DrawDistance dd)
	{
		if (!dd.IsLod)
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
}