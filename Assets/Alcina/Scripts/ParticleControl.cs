using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticleControl : MonoBehaviour {

	public Skinner.SkinnerParticle[] particles;
	public Material mat;

	[SerializeField, Range(0, 1)]
	private float _alpha;
	public float alpha
	{
		get { return _alpha; }
		set { _alpha = value; }
	}

	[SerializeField, Range(0, 4)]
	private float _life;
	public float life
	{
		get { return _life; }
		set { _life = value; }
	}

	[SerializeField, Range(0, 4)]
	private float _scale;
	public float scale
	{
		get { return _scale; }
		set { _scale = value; }
	}

	[SerializeField, Range(0, 5)]
	private float _drag;
	public float drag
	{
		get { return _drag; }
		set { _drag = value; }
	}

	[SerializeField, Range(0, 5)]
	private float _noiseAmp;
	public float noiseAmp
	{
		get { return _noiseAmp; }
		set { _noiseAmp = value; }
	}

	[SerializeField, Range(0, 5)]
	private float _noiseFreq;
	public float noiseFreq
	{
		get { return _noiseFreq; }
		set { _noiseFreq = value; }
	}

	[SerializeField, Range(0, 1)]
	private float _noiseMotion;
	public float noiseMotion
	{
		get { return _noiseMotion; }
		set { _noiseMotion = value; }
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

	[SerializeField, Range(-1, 1)]
	private float _hueShift;
	public float hueShift
	{
		get { return _hueShift; }
		set { _hueShift = value; }
	}

	// Use this for initialization
	void Start () {
		
	}

	// Update is called once per frame
	void Update()
	{
		for (int i = 0; i < particles.Length; i++)
		{
			Skinner.SkinnerParticle p = particles[i];
			p.drag = _drag;
			p.speedToLife = 1f * _life;
			p.maxLife = 2f * _life;
			p.minLife = 1.4f * _life;
			p.speedToScale = 0.08f * _scale;
			p.maxScale = 0.08f * _scale;
			p.minScale = 0.06f * _scale;
			p.noiseAmplitude = _noiseAmp;
			p.noiseFrequency = _noiseFreq;
			p.noiseMotion = _noiseMotion;
		}

		mat.SetFloat("_BaseHue", _hue);
		mat.SetFloat("_HueRandomness", _hueRange);
		mat.SetFloat("_Saturation", _saturation);
		mat.SetFloat("_EmissionProb", _sparkle);
		mat.SetFloat("_HueShift", _hueShift);
		mat.SetFloat("_Alpha", _alpha);
	}
}
