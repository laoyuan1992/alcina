using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WindController : MonoBehaviour {

	[SerializeField, Range(-10, 10)]
	private float _velX = 0f;
	public float velX
	{
		get { return _velX; }
		set { _velX = value; UpdateVelocities(); }
	}

	[SerializeField, Range(-10, 10)]
	private float _velY = 0f;
	public float velY
	{
		get { return _velY; }
		set { _velY = value; UpdateVelocities(); }
	}

	[SerializeField, Range(-10, 10)]
	private float _velZ = 0f;
	public float velZ
	{
		get { return _velZ; }
		set { _velZ = value; UpdateVelocities(); }
	}

	[SerializeField, Range(0, 10)]
	private float _velRandom = 2f;
	public float velRandom
	{
		get { return _velRandom; }
		set { _velRandom = value; UpdateVelocities(); }
	}

	public Cloth[] cloths = new Cloth[] { };

	// Use this for initialization
	void Start () {
		UpdateVelocities();
	}
	
	void UpdateVelocities () {
		for (int i = 0; i < cloths.Length; i++)
		{
			cloths[i].externalAcceleration = new Vector3(_velX, _velY, _velZ);
			cloths[i].randomAcceleration = new Vector3(_velRandom, _velRandom, _velRandom);
		}
	}
}
