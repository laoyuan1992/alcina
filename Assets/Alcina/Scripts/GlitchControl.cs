using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GlitchControl : MonoBehaviour {

	public Material mat;
	public AlcinaCrossfader crossfader;

	[SerializeField, Range(0, 1)]
	private float _alpha;
	public float alpha
	{
		get { return _alpha; }
		set { _alpha = value; }
	}

	[SerializeField, Range(0, 2)]
	private float _brightness;
	public float brightness
	{
		get { return _brightness; }
		set { _brightness = value; }
	}

	[SerializeField, Range(0, 1)]
	private float _hue;
	public float hue
	{
		get { return _hue; }
		set { _hue = value; }
	}

	[SerializeField, Range(0, 0.5f)]
	private float _hueRange;
	public float hueRange
	{
		get { return _hueRange; }
		set { _hueRange = value; }
	}

	[SerializeField, Range(0, 1)]
	private float _saturation;
	public float saturation
	{
		get { return _saturation; }
		set { _saturation = value; }
	}

	[SerializeField, Range(0, 1)]
	private float _sparkle;
	public float sparkle
	{
		get { return _sparkle; }
		set { _sparkle = value; }
	}

	// Update is called once per frame
	void Update()
	{
		float brightness = 1.5f;
		float brightnessOffset = 0.90f;

		mat.SetFloat("_BaseHue", _hue);
		mat.SetFloat("_HueRandomness", _hueRange);
		mat.SetFloat("_Saturation", _saturation);
		mat.SetFloat("_Brightness", brightness * _brightness);
		mat.SetFloat("_EmissionProb", _sparkle);
		mat.SetFloat("_BrightnessOffs", brightnessOffset * _brightness);
		mat.SetFloat("_Alpha", Mathf.Min(_alpha, crossfader.crossfadeFx));
	}
}
