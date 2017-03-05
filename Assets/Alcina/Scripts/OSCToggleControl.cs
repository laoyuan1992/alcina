using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using OscJack;

public class OSCToggleControl : MonoBehaviour
{
	[SerializeField]
	string _path = "path";

	[SerializeField]
	Text _label;

	private VJUI.Toggle _toggle;

#if UNITY_EDITOR
	protected void OnValidate()
	{
		_label.text = _path;
	}
#endif

	// Update is called once per frame
	void Update()
	{
		var data = OscMaster.GetData(_path);
		if (data != null)
		{
			var val = (bool)data[0];
			_toggle.isOn = val;
		}
		OscMaster.ClearData(_path);
	}
}
