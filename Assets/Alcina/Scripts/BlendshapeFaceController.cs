using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BlendshapeFaceController : MonoBehaviour {

	public SkinnedMeshRenderer head;

	public bool mirroredHeadMovement = true;

	public float globalMultiplier = 100f;
	public float smoothing = 2f;

	public Text importStatus;

	[System.Serializable]
	public class BlendshapeInfo
	{
		[SerializeField]
		public KinectInterop.FaceShapeAnimations source;
		[SerializeField, Range(0, 4)]
		public float weight = 1f;
		[SerializeField]
		public BlendshapeMode mode;

		public enum BlendshapeMode
		{
			Default,
			Positive,
			Negative
		}

		internal float value;
	}

	public BlendshapeInfo[] blendshapes;

	private FacetrackingManager manager;
	private KinectInterop.DepthSensorPlatform platform;

	internal class BlendshapesContainer
	{
		public BlendshapeInfo[] blendshapes;
	}

	public void ImportJSON()
	{
		if (importStatus == null)
			return;
		string path = Application.dataPath;
		if (Application.platform == RuntimePlatform.OSXPlayer)
		{
			path += "/../../";
		}
		else if (Application.platform == RuntimePlatform.WindowsPlayer)
		{
			path += "/../";
		}
		else
		{
			path += "/";
		}
		path += "blendshapes.json";
		importStatus.text = "reading json";
		try
		{
			string json = System.IO.File.ReadAllText(path);
			BlendshapesContainer cont = JsonUtility.FromJson<BlendshapesContainer>(json);
			if (cont == null)
			{
				importStatus.text = "null json!";
				return;
			}
			blendshapes = cont.blendshapes;
			importStatus.text = "imported blendshapes.json";
		}
		catch (System.IO.FileNotFoundException)
		{
			importStatus.text = "blendshapes.json not found";
		}
		catch (System.IO.IOException)
		{
			importStatus.text = "File read error";
		}
		catch (System.Exception)
		{
			importStatus.text = "parse error";
		}
	}

	public void ResetFace()
	{
		for (int i = 0; i < blendshapes.Length; i++)
		{
			head.SetBlendShapeWeight(i, 0f);
		}
	}

	public void ResetEyes()
	{
		for (int i = 0; i < blendshapes.Length; i++)
		{
			if (blendshapes[i].source == KinectInterop.FaceShapeAnimations.LefteyeClosed ||
				blendshapes[i].source == KinectInterop.FaceShapeAnimations.RighteyeClosed)
			{
				head.SetBlendShapeWeight(i, 0f);
			}
		}
	}

	// Use this for initialization
	void Start () {
		KinectManager kinectManager = KinectManager.Instance;
		if (kinectManager && kinectManager.IsInitialized())
		{
			platform = kinectManager.GetSensorPlatform();
		}
		ImportJSON();
	}

	// Update is called once per frame
	void Update()
	{
		if (Input.GetKeyDown(KeyCode.B))
		{
			ImportJSON();
		}
		if (Input.GetKeyDown(KeyCode.F))
		{
			ResetFace();
		}
		if (Input.GetKeyDown(KeyCode.I))
		{
			ResetEyes();
		}

		if (head == null)
		{
			return;
		}

		// get the face-tracking manager instance
		if (manager == null)
		{
			manager = FacetrackingManager.Instance;
		}

		if (manager && manager.GetFaceTrackingID() != 0)
		{
			for (int i = 0; i < blendshapes.Length; i++)
			{
				BlendshapeInfo blend = blendshapes[i];

				if (!manager.IsGotAU())
					return;

				float value = manager.GetAnimUnit(blend.source);
				if (blend.mode == BlendshapeInfo.BlendshapeMode.Positive)
				{
					value = Mathf.Max(0f, value);
				}
				else if (blend.mode == BlendshapeInfo.BlendshapeMode.Negative)
				{
					value = Mathf.Max(0f, -value);
				}
				value *= blend.weight * globalMultiplier;

				blend.value = Mathf.Lerp(blend.value, value, smoothing * Time.deltaTime);

				head.SetBlendShapeWeight(i, blend.value);
			}
		}
	}
}
