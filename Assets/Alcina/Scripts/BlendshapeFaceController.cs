using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlendshapeFaceController : MonoBehaviour {

	public SkinnedMeshRenderer head;

	public bool mirroredHeadMovement = true;

	public float globalMultiplier = 100f;
	public float smoothing = 2f;

	[System.Serializable]
	public class BlendshapeInfo
	{
		[SerializeField]
		public KinectInterop.FaceShapeAnimations source;
		[SerializeField, Range(0, 2)]
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

	// Use this for initialization
	void Start () {
		KinectManager kinectManager = KinectManager.Instance;
		if (kinectManager && kinectManager.IsInitialized())
		{
			platform = kinectManager.GetSensorPlatform();
		}
	}

	// Update is called once per frame
	void Update()
	{
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
