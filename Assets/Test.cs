using System.Collections.Generic;
using RenderWare;
using RenderWare.Extensions;
using RenderWare.Loaders;
using RenderWare.Structures;
using RenderWare.Types;
using UnityEngine;

public class Test : MonoBehaviour
{
	public const string BasePath = "C:/Program Files (x86)/Steam/steamapps/common/Grand Theft Auto 3";

	private readonly List<GameObject> gameObjects = new List<GameObject>();
	private readonly Dictionary<string, Material[][]> materials = new Dictionary<string, Material[][]>();

	private void Start()
	{
		FileSystem.BasePath = Test.BasePath;

		Text.Load("text/american.gxt");

		Archive.Load("models/gta3.img");

		MapListing.Load("data/default.dat");
		MapListing.Load("data/gta3.dat");

		this.ProcessMaterials();

		ItemPlacement.ForEach<Instance>((inst) =>
		{
			if (inst.ModelName.ToLower().Contains("lod"))
			{
				return;
			}

			var ide = ItemDefinition.Get<IAttachableObject>(inst);

			if ((ide.Flags & ObjectFlags.Shadows) == ObjectFlags.Shadows)
			{
				return;
			}

			var go = new GameObject(inst.ModelName)
			{
				hideFlags = HideFlags.DontSaveInEditor | HideFlags.DontSaveInBuild
			};

			this.gameObjects.Add(go);

			go.transform.localPosition = inst.Position.xzy();
			go.transform.localRotation = inst.Rotation.xzyw();
			go.transform.localScale = inst.Scale;

			var model = Model.Get(ide);

			for (var i = 0; i < model.AtomicCount; i++)
			{
				var atomic = model.Atomics[i];

				var frameList = model.FrameList;

				var frame = frameList.Frames[atomic.FrameIndex];
				var geometry = model.GeometryList.Geometries[atomic.GeometryIndex];
				var binMesh = geometry.BinMesh;

				var child = new GameObject(frame.Name)
				{
					hideFlags = HideFlags.DontSaveInEditor | HideFlags.DontSaveInBuild
				};

				this.gameObjects.Add(child);

				child.transform.parent = go.transform;

				child.transform.localPosition = Vector3.zero;
				child.transform.localRotation = Quaternion.identity;

				var meshFilter = child.AddComponent<MeshFilter>();

				meshFilter.sharedMesh = geometry.Mesh;

				var meshRenderer = child.AddComponent<MeshRenderer>();

				var sharedMaterials = new Material[binMesh.MeshCount];

				for (var j = 0; j < binMesh.MeshCount; j++)
				{
					var index = binMesh.Meshes[j].MaterialIndex;

					sharedMaterials[index] = this.materials[ide.ModelName.ToLower()][atomic.GeometryIndex][index];
				}

				meshRenderer.sharedMaterials = sharedMaterials;
			}
		});
	}

	private void ProcessMaterials()
	{
		Model.ForEach((id, model) =>
		{
			var texture = default(RwTextureNative);
			var geometryList = model.GeometryList;

			this.materials[id] = new Material[geometryList.GeometryCount][];

			for (var i = 0; i < geometryList.GeometryCount; i++)
			{
				var geometry = geometryList.Geometries[i];
				var materialList = geometry.MaterialList;
				var binMesh = geometry.BinMesh;

				this.materials[id][i] = new Material[binMesh.MeshCount];

				for (var j = 0; j < binMesh.MeshCount; j++)
				{
					var materialIndex = binMesh.Meshes[j].MaterialIndex;
					var material = materialList.Materials[materialIndex];

					var shaderName = "RW/Opaque";

					if (material.IsTextured &&
					    TextureArchive.TryFindTexture(material.Texture.Name, out texture) &&
					    texture.Raster.HasAlpha)
					{
						shaderName = "RW/Alpha";
					}

					this.materials[id][i][materialIndex] = new Material(Shader.Find(shaderName))
					{
						hideFlags = HideFlags.DontSaveInBuild | HideFlags.DontSaveInEditor,
						color = material.Color,
						mainTexture = texture.Texture2D
					};
				}
			}
		});
	}

	private void OnDestroy()
	{
		foreach (var go in this.gameObjects)
		{
			Object.DestroyImmediate(go);
		}
	}

	private void OnDrawGizmos()
	{
		var color = Gizmos.color;

		Gizmos.color = new Color(1f, 0.5f, 0.5f, 0.5f);
		ItemPlacement.ForEach<Zone>((zone) =>
		{
			var min = zone.Min.xzy();
			var max = zone.Max.xzy();

			var extents = (max - min) * 0.5f;
			var center = min + extents;

			Gizmos.DrawWireCube(center, extents * 2f);

#if UNITY_EDITOR
			if (Text.TryGet(zone.Name, out var zoneName))
			{
				UnityEditor.Handles.Label(center, zoneName);
			}
#endif
		});

		Gizmos.color = new Color(0.5f, 1f, 0.5f, 0.5f);
		ItemPlacement.ForEach<Cull>((cull) =>
		{
			var min = cull.Min.xzy();
			var max = cull.Max.xzy();

			var extents = (max - min) * 0.5f;
			var center = min + extents;

			Gizmos.DrawSphere(center, 1f);
			Gizmos.DrawWireCube(center, extents * 2f);
		});

		Gizmos.color = color;
	}
}