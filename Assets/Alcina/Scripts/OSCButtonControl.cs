using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using OscJack;

public class OSCButtonControl : MonoBehaviour {

	[SerializeField]
	string _path = "path";

	[SerializeField]
	Text _label;

	private VJUI.Button _button;

	// Use this for initialization
	void Start()
	{
		_button = GetComponent<VJUI.Button>();
	}

#if UNITY_EDITOR
	protected void OnValidate()
	{
		_label.text = _path;
	}
#endif

	// Update is called once per frame
	void Update () {
		if (OscMaster.HasData(_path))
		{
			_button.onButtonDown.Invoke();
			OscMaster.ClearData(_path);
		}
	}
}
