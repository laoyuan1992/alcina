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

	public float _ambientIntensity = 4.45f;
	public Light _light;
	public float _lightIntensity = 1.22f;

	private Color _emissionColor;


	// Use this for initialization
	void Start () {
		Update();
	}

	void Update()
	{
		float invCrossfade = Mathf.Max(0f, 1f - _crossfade);

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

		RenderSettings.ambientIntensity = invCrossfade * Mathf.Max(1f, _ambientIntensity);
		_light.intensity = invCrossfade * Mathf.Max(1f, _lightIntensity);
	}
}
