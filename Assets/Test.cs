using System.Collections.Generic;
using System.Threading.Tasks;
using RenderWare.Extensions;
using RenderWare.Helpers;
using RenderWare.Loaders;
using RenderWare.Structures;
using RenderWare.Types;

public class Test : UnityEngine.MonoBehaviour
{
	public string BasePath =
		"/Users/k3min/Applications/Wineskin/GTA III.app/Contents/Resources/drive_c/Program Files/GTA III";

	private readonly HashSet<UnityEngine.GameObject> gameObjects = new HashSet<UnityEngine.GameObject>();

	private readonly StringDictionary<UnityEngine.Material[][]> materials =
		new StringDictionary<UnityEngine.Material[][]>();

	private UnityEngine.Material material;

	private string load;

	private async void Start()
	{
#if UNITY_EDITOR
		this.material = UnityEditor.AssetDatabase.GetBuiltinExtraResource<UnityEngine.Material>("Default-Material.mat");
		this.material.enableInstancing = true;
#endif

		FileSystem.BasePath = this.BasePath;

		Text.OnLoad += (x) => this.load = x;
		Archive.OnLoad += (x) => this.load = x;
		TextureArchive.OnLoad += (x) => this.load = x;
		Model.OnLoad += (x) => this.load = x;
		Collision.OnLoad += (x) => this.load = x;

		await Text.Load("text/american.gxt");
		await Archive.Load("models/gta3.img");

		await MapListing.Load("data/default.dat");
		await MapListing.Load("data/gta3.dat");

		//await this.ProcessMaterials();

		var parent = new UnityEngine.GameObject("GTA")
		{
			hideFlags = UnityEngine.HideFlags.DontSaveInEditor | UnityEngine.HideFlags.DontSaveInBuild
		};

		this.gameObjects.Add(parent);

		foreach (var inst in ItemPlacement.All<Instance>())
		{
			var ide = ItemDefinition.Get<IAttachableObject>(inst);

			if ((ide.Flags & ObjectFlags.Shadows) == ObjectFlags.Shadows)
			{
				continue;
			}

			var go = new UnityEngine.GameObject(inst.ModelName.ToLower())
			{
				isStatic = true,
				hideFlags = UnityEngine.HideFlags.DontSaveInEditor | UnityEngine.HideFlags.DontSaveInBuild
			};

			go.transform.parent = parent.transform;
			go.transform.localPosition = inst.Position.xzy();
			go.transform.localRotation = inst.Rotation.xzyw();

			this.gameObjects.Add(go);

			var model = await Model.Find(ide.ModelName);

			if (model.AtomicCount == 0)
			{
				continue;
			}

			var atomic = model.Atomics[model.AtomicCount - 1];

			var frameList = model.FrameList;

			var frameName = frameList.FrameNames[atomic.FrameIndex];
			var geometry = model.GeometryList.Geometries[atomic.GeometryIndex];
			var binMesh = geometry.BinMesh;

			var child = new UnityEngine.GameObject(frameName)
			{
				isStatic = true,
				hideFlags = UnityEngine.HideFlags.DontSaveInEditor | UnityEngine.HideFlags.DontSaveInBuild
			};

			child.transform.parent = go.transform;

			child.transform.localPosition = UnityEngine.Vector3.zero;
			child.transform.localRotation = UnityEngine.Quaternion.identity;

			this.gameObjects.Add(child);

			if (Collision.TryFind(ide.ModelName, out var coll))
			{
				if (coll.BoxCount != 0)
				{
					foreach (var box in coll.Boxes)
					{
						var boxCollider = child.AddComponent<UnityEngine.BoxCollider>();
						boxCollider.center = box.Center.xzy();
						boxCollider.size = box.Size.xzy();
					}
				}

				if (coll.SphereCount != 0)
				{
					foreach (var sphere in coll.Spheres)
					{
						var sphereCollider = child.AddComponent<UnityEngine.SphereCollider>();
						sphereCollider.radius = sphere.Radius;
						sphereCollider.center = sphere.Center.xzy();
					}
				}

				if (coll.Mesh != null)
				{
					var meshCollider = child.AddComponent<UnityEngine.MeshCollider>();
					meshCollider.sharedMesh = coll.Mesh;
				}
			}

			var meshFilter = child.AddComponent<UnityEngine.MeshFilter>();

			meshFilter.sharedMesh = geometry.Mesh;

			var meshRenderer = child.AddComponent<UnityEngine.MeshRenderer>();

			meshRenderer.motionVectorGenerationMode = UnityEngine.MotionVectorGenerationMode.Camera;
			meshRenderer.hideFlags = UnityEngine.HideFlags.HideInInspector;
			meshRenderer.shadowCastingMode = UnityEngine.Rendering.ShadowCastingMode.TwoSided;

			var sharedMaterials = new UnityEngine.Material[binMesh.MeshCount];

			for (var j = 0; j < binMesh.MeshCount; j++)
			{
				var index = binMesh.Meshes[j].MaterialIndex;

				sharedMaterials[index] = this.material;
				//sharedMaterials[index] = this.materials[ide.ModelName][atomic.GeometryIndex][index];
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

			this.materials[id] = new UnityEngine.Material[geometryList.GeometryCount][];

			for (var i = 0; i < geometryList.GeometryCount; i++)
			{
				var geometry = geometryList.Geometries[i];
				var materialList = geometry.MaterialList;
				var binMesh = geometry.BinMesh;

				this.materials[id][i] = new UnityEngine.Material[binMesh.MeshCount];

				for (var j = 0; j < binMesh.MeshCount; j++)
				{
					var materialIndex = binMesh.Meshes[j].MaterialIndex;
					var material = materialList.Materials[materialIndex];

					var shaderName = "RW/Opaque";

					if (material.IsTextured)
					{
						shaderName = "RW/Alpha";
					}

					this.materials[id][i][materialIndex] = new UnityEngine.Material(UnityEngine.Shader.Find(shaderName))
					{
						hideFlags = UnityEngine.HideFlags.DontSaveInBuild | UnityEngine.HideFlags.DontSaveInEditor,
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
			UnityEngine.Object.DestroyImmediate(go);
		}
	}

	private void OnGUI()
	{
		if (this.load != null)
		{
			UnityEngine.GUI.Label(new UnityEngine.Rect(10, 10, 600, 20), this.load);
		}
	}

	private void OnDrawGizmos()
	{
		var color = UnityEngine.Gizmos.color;

		UnityEngine.Gizmos.color = new UnityEngine.Color(1f, 0.5f, 0.5f, 0.5f);
		foreach (var zone in ItemPlacement.All<Zone>())
		{
			var min = zone.Min.xzy();
			var max = zone.Max.xzy();

			var extents = (max - min) * 0.5f;
			var center = min + extents;

			UnityEngine.Gizmos.DrawWireCube(center, extents * 2f);

#if UNITY_EDITOR
			if (Text.TryGet(zone.Name, out var zoneName))
			{
				UnityEditor.Handles.Label(center, zoneName);
			}
#endif
		}

		UnityEngine.Gizmos.color = new UnityEngine.Color(0.5f, 1f, 0.5f, 0.5f);
		foreach (var cull in ItemPlacement.All<Cull>())
		{
			var min = cull.Min.xzy();
			var max = cull.Max.xzy();

			var extents = (max - min) * 0.5f;
			var center = min + extents;

			UnityEngine.Gizmos.DrawSphere(center, 1f);
			UnityEngine.Gizmos.DrawWireCube(center, extents * 2f);
		}

		UnityEngine.Gizmos.color = color;
	}
}