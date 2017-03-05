using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using OscJack;

public class HexInputControl : MonoBehaviour
{

	[SerializeField]
	string _path = "path";

	[SerializeField]
	InputField _input;

	[SerializeField]
	Text _status;

	[SerializeField]
	Camera _camera;

	// Update is called once per frame
	void Update()
	{
		var data = OscMaster.GetData(_path);
		if (data != null)
		{
			var val = (string)data[0];
			SetData(val);
		}
		OscMaster.ClearData(_path);
	}

	Color HexToColor(string hex)
	{
		byte r = byte.Parse(hex.Substring(0, 2), System.Globalization.NumberStyles.HexNumber);
		byte g = byte.Parse(hex.Substring(2, 2), System.Globalization.NumberStyles.HexNumber);
		byte b = byte.Parse(hex.Substring(4, 2), System.Globalization.NumberStyles.HexNumber);
		return new Color32(r, g, b, 255);
	}

	public void SetData(string data)
	{
		if (data.StartsWith("#"))
		{
			data = data.Substring(1);
		}
		Color c;
		try
		{
			c = HexToColor(data);
		}
		catch (System.Exception e)
		{
			_status.text = "Illegal hex value";
			return;
		}

		_input.text = data;
		_status.text = "";
		_camera.backgroundColor = c;
	}
}
