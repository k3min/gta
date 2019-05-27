using System.Collections.Generic;
using System.Threading.Tasks;
using RenderWare;
using RenderWare.Extensions;
using RenderWare.Loaders;
using RenderWare.Structures;
using RenderWare.Types;
using UnityEngine;
using Collision = RenderWare.Loaders.Collision;

public class Test : MonoBehaviour
{
	public string BasePath =
		"/Users/k3min/Applications/Wineskin/GTA III.app/Contents/Resources/drive_c/Program Files/GTA III";

	private readonly List<GameObject> gameObjects = new List<GameObject>();
	private readonly Dictionary<string, Material[][]> materials = new Dictionary<string, Material[][]>();
	private Material material;

	private string load;

	private async void Start()
	{
#if UNITY_EDITOR
		this.material = UnityEditor.AssetDatabase.GetBuiltinExtraResource<Material>("Default-Material.mat");
#endif

		FileSystem.BasePath = this.BasePath;

		Archive.OnLoad += (img, x) => this.load = $"{img.FilePath}: {x}";
		TextureArchive.OnLoad += (x) => this.load = x.ToLower();
		Model.OnLoad += (x) => this.load = x.ToLower();
		Collision.OnLoad += (x) => this.load = x.ToLower();

		Text.Load("text/american.gxt");
		Archive.Load("models/gta3.img");

		await MapListing.Load("data/default.dat");
		await MapListing.Load("data/gta3.dat");

		//await this.ProcessMaterials();

		foreach (var inst in ItemPlacement.All<Instance>())
		{
			var ide = ItemDefinition.Get<IAttachableObject>(inst);

			if ((ide.Flags & ObjectFlags.Shadows) == ObjectFlags.Shadows)
			{
				continue;
			}

			var go = new GameObject(inst.ModelName.ToLower())
			{
				hideFlags = HideFlags.DontSaveInEditor | HideFlags.DontSaveInBuild
			};

			go.transform.localPosition = inst.Position.xzy();
			go.transform.localRotation = inst.Rotation.xzyw();
			go.transform.localScale = inst.Scale;

			this.gameObjects.Add(go);

			var model = await Model.Find(ide.ModelName);

			if (model.AtomicCount == 0)
			{
				continue;
			}

			var atomic = model.Atomics[model.AtomicCount-1];

			var frameList = model.FrameList;

			var frameName = frameList.FrameNames[atomic.FrameIndex];
			var geometry = model.GeometryList.Geometries[atomic.GeometryIndex];
			var binMesh = geometry.BinMesh;

			var child = new GameObject(frameName)
			{
				hideFlags = HideFlags.DontSaveInEditor | HideFlags.DontSaveInBuild,
			};

			child.transform.parent = go.transform;

			child.transform.localPosition = Vector3.zero;
			child.transform.localRotation = Quaternion.identity;

			this.gameObjects.Add(child);

			if (Collision.TryFind(ide, out var coll))
			{
				if (coll.BoxCount != 0)
				{
					foreach (var box in coll.Boxes)
					{
						var boxCollider = child.AddComponent<BoxCollider>();
						boxCollider.center = box.Center;
						boxCollider.size = box.Size;
					}
				}

				if (coll.SphereCount != 0)
				{
					foreach (var sphere in coll.Spheres)
					{
						var sphereCollider = child.AddComponent<SphereCollider>();
						sphereCollider.radius = sphere.Radius;
						sphereCollider.center = sphere.Center.xzy();
					}
				}
				
				if (coll.Mesh != null)
				{
					var meshCollider = child.AddComponent<MeshCollider>();
					meshCollider.sharedMesh = coll.Mesh;
				}
			}

			var meshFilter = child.AddComponent<MeshFilter>();

			meshFilter.sharedMesh = geometry.Mesh;

			var meshRenderer = child.AddComponent<MeshRenderer>();

			meshRenderer.motionVectorGenerationMode = MotionVectorGenerationMode.Camera;

			var sharedMaterials = new Material[binMesh.MeshCount];

			for (var j = 0; j < binMesh.MeshCount; j++)
			{
				var index = binMesh.Meshes[j].MaterialIndex;

				sharedMaterials[index] = this.material;
				//sharedMaterials[index] = this.materials[ide.ModelName.ToLower()][atomic.GeometryIndex][index];
			}

			meshRenderer.sharedMaterials = sharedMaterials;

			var drawDistance = go.AddComponent<DrawDistance>();

			drawDistance.Max = ide.DrawDistance;

			DrawDistance.FindParent(drawDistance);
		}
	}

	/// <todo>Optimize this</todo>
	private async Task ProcessMaterials()
	{
		await Model.ForEach(async (id, model) =>
		{
			await Task.Run(() => this.load = $"Processing material {id}");

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

	private void OnGUI()
	{
		if (this.load != null)
		{
			GUI.Label(new Rect(10, 10, 600, 20), this.load);
		}
	}

	private void OnDrawGizmos()
	{
		var color = Gizmos.color;

		Gizmos.color = new Color(1f, 0.5f, 0.5f, 0.5f);
		foreach (var zone in ItemPlacement.All<Zone>())
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
		}

		Gizmos.color = new Color(0.5f, 1f, 0.5f, 0.5f);
		foreach (var cull in ItemPlacement.All<Cull>())
		{
			var min = cull.Min.xzy();
			var max = cull.Max.xzy();

			var extents = (max - min) * 0.5f;
			var center = min + extents;

			Gizmos.DrawSphere(center, 1f);
			Gizmos.DrawWireCube(center, extents * 2f);
		}

		Gizmos.color = color;
	}
}