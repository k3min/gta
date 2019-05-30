using System.Collections.Generic;
using UnityEngine;

public class DrawDistances : MonoBehaviour
{
	public static readonly HashSet<DrawDistance> LODs = new HashSet<DrawDistance>();

	private void OnEnable()
	{
		Camera.onPreCull += DrawDistances.PreCull;
	}

	private static void PreCull(Camera cam)
	{
		var pos = cam.transform.position;

		foreach (var lod in DrawDistances.LODs)
		{
			var distance = Vector3.Distance(pos, lod.Position);

			lod.Renderer.enabled = (distance > lod.Min && distance <= lod.Max);
		}
	}

	private void OnDisable()
	{
		// ReSharper disable once DelegateSubtraction
		Camera.onPreCull -= DrawDistances.PreCull;
	}
}