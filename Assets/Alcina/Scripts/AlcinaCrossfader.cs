using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ExecuteInEditMode]
public class AlcinaCrossfader : MonoBehaviour {

	[SerializeField, Range(0, 1)]
	private float _crossfade = 0f;

	public float crossfade
	{
		get { return _crossfade; }
		set { _crossfade = value; }
	}

	[SerializeField, Range(0, 1)]
	private float _crossfadeFx = 0f;

	public float crossfadeFx
	{
		get { return _crossfadeFx; }
		set { _crossfadeFx = value; }
	}

	[SerializeField, Range(0, 1)]
	private float _emissionHue = 0f;
	public float emissionHue
	{
		get { return _emissionHue; }
		set { _emissionHue = value; }
	}

	[SerializeField, Range(0, 1)]
	private float _emissionSaturation = 0f;
	public float emissionSaturation
	{
		get { return _emissionSaturation; }
		set { _emissionSaturation = value; }
	}

	[SerializeField, Range(0, 10)]
	private float _emissionBrightness = 1f;
	public float emissionBrightness
	{
		get { return _emissionBrightness; }
		set { _emissionBrightness = value; }
	}

	public Material[] fadeOpacityLeft;
	public Material[] fadeOpacityRight;

	public Material[] fadeEmissionRight;
	public Renderer[] enableRight;

	public Material[] fadeOpacityFxLeft;
	public Material[] fadeOpacityFxRight;
	public Renderer[] enableFxLeft;

	public Material[] fadeOpacityBothLeft;
	public Renderer[] enableBothLeft;

	[System.Serializable]
	public struct LightInfo
	{
		public Light light;
		[Range(0, 1)]
		public float intensity;
	}

	public LightInfo[] lights;

	[Range(0, 1)]
	public float _ambientIntensity = 1f;
	[Range(0, 1)]
	public float _reflectionIntensity = 1f;

	private Color _emissionColor;


	// Use this for initialization
	void Start () {
		Update();
	}

	void Update()
	{
		float invCrossfade = Mathf.Max(0f, 1f - _crossfade);
		float invFxCrossfade = Mathf.Max(0f, 1f - _crossfadeFx);

		for (int i = 0; i < fadeOpacityLeft.Length; i++)
		{
			fadeOpacityLeft[i].color = new Color(1, 1, 1, invCrossfade);
		}

		for (int i = 0; i < fadeOpacityRight.Length; i++)
		{
			fadeOpacityRight[i].color = new Color(1, 1, 1, _crossfade);
		}

		for (int i = 0; i < fadeEmissionRight.Length; i++)
		{
			fadeEmissionRight[i].SetColor("_EmissionColor", Color.HSVToRGB(_emissionHue, _emissionSaturation, _emissionBrightness * _crossfade));
		}

		for (int i = 0; i < enableRight.Length; i++)
		{
			enableRight[i].enabled = !(crossfade < 0.5f);
		}

		for (int i = 0; i < fadeOpacityFxLeft.Length; i++)
		{
			fadeOpacityFxLeft[i].color = new Color(1, 1, 1, invFxCrossfade);
		}

		for (int i = 0; i < fadeOpacityFxRight.Length; i++)
		{
			fadeOpacityFxRight[i].color = new Color(1, 1, 1, _crossfadeFx);
		}

		for (int i = 0; i < enableFxLeft.Length; i++)
		{
			enableFxLeft[i].enabled = (_crossfadeFx < 0.99f);
		}

		for (int i = 0; i < fadeOpacityBothLeft.Length; i++)
		{
			fadeOpacityBothLeft[i].color = new Color(1, 1, 1, Mathf.Min(invCrossfade, invFxCrossfade));
		}

		for (int i = 0; i < enableBothLeft.Length; i++)
		{
			enableBothLeft[i].enabled = (_crossfade < 0.5f) && (_crossfadeFx < 0.99f);
		}

		float fade = Mathf.Min(invFxCrossfade, invCrossfade);

		RenderSettings.ambientIntensity = fade* _ambientIntensity;
		RenderSettings.reflectionIntensity = fade * _reflectionIntensity;

		for (int i = 0; i < lights.Length; i++)
		{
			lights[i].light.intensity = fade * lights[i].intensity;
		}
	}
}
