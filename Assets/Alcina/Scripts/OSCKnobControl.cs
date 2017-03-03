using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using OscJack;

[ExecuteInEditMode]
public class OSCKnobControl : MonoBehaviour {

	[SerializeField] string _path = "path";

	[SerializeField] Text _label;
	[SerializeField] Text _value;

	private VJUI.Knob _knob;

	// Use this for initialization
	void OnEnable() {
		_knob = GetComponent<VJUI.Knob>();
		_knob.onValueChanged.AddListener(this.Listener);
		_knob.onValueChanged.Invoke(_knob.value);
	}

	void OnDisable() {
		_knob.onValueChanged.RemoveListener(this.Listener);
	}

#if UNITY_EDITOR
	protected void OnValidate() {
		_label.text = _path;
	}
#endif

	void Update() {
		var data = OscMaster.GetData(_path);
		if (data != null) {
			var val = (float)data[0];
			_knob.value = val;
		}
	}
	
	private void Listener(float newValue) {
		_value.text = newValue.ToString("0.00");
	}
}
