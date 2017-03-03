using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TransformControl : MonoBehaviour
{

	[SerializeField, Range(-10, 10)]
	private float _posX;
	public float posX
	{
		get { return _posX; }
		set { _posX = value; UpdatePosition(); }
	}

	[SerializeField, Range(-10, 10)]
	private float _posY;
	public float posY
	{
		get { return _posY; }
		set { _posY = value; UpdatePosition(); }
	}

	[SerializeField, Range(-10, 10)]
	private float _posZ;
	public float posZ
	{
		get { return _posZ; }
		set { _posZ = value; UpdatePosition(); }
	}

	[SerializeField, Range(-180, 180)]
	private float _rotX;
	public float rotX
	{
		get { return _rotX; }
		set { _rotX = value; UpdateRotation(); }
	}

	[SerializeField, Range(-180, 180)]
	private float _rotY;
	public float rotY
	{
		get { return _rotY; }
		set { _rotY = value; UpdateRotation(); }
	}

	[SerializeField, Range(-180, 180)]
	private float _rotZ;
	public float rotZ
	{
		get { return _rotZ; }
		set { _rotZ = value; UpdateRotation(); }
	}

	// Use this for initialization
	void Start()
	{
		UpdatePosition();
		UpdateRotation();
	}

	// Update is called once per frame
	void UpdatePosition()
	{
		transform.position = new Vector3(_posX, _posY, _posZ);
	}

	void UpdateRotation()
	{
		transform.rotation = Quaternion.Euler(_rotX, _rotY, _rotZ);
	}
}
