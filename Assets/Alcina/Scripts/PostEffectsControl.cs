using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.PostProcessing;

public class PostEffectsControl : MonoBehaviour {

	public float focusDistance {
		get { return this.profile.depthOfField.settings.focusDistance; }
		set {
			var settings = this.profile.depthOfField.settings;
			settings.focusDistance = value;
			this.profile.depthOfField.settings = settings;
		}
	}

	public float focalLength {
		get { return this.profile.depthOfField.settings.focalLength; }
		set {
			var settings = this.profile.depthOfField.settings;
			settings.focalLength = value;
			this.profile.depthOfField.settings = settings;
		}
	}

	public float bloomIntensity {
		get { return this.profile.bloom.settings.bloom.intensity; }
		set {
			var settings = this.profile.bloom.settings;
			settings.bloom.intensity = value;
			this.profile.bloom.settings = settings;
		}
	}

	public float bloomThreshold {
		get { return this.profile.bloom.settings.bloom.threshold; }
		set {
			var settings = this.profile.bloom.settings;
			settings.bloom.threshold = value;
			this.profile.bloom.settings = settings;
		}
	}

	public float bloomRadius {
		get { return this.profile.bloom.settings.bloom.radius; }
		set {
			var settings = this.profile.bloom.settings;
			settings.bloom.radius = value;
			this.profile.bloom.settings = settings;
		}
	}

	private PostProcessingProfile _profile;
	private PostProcessingProfile profile {
		get {
			if (_profile == null)
				_profile = GetComponent<PostProcessingBehaviour>().profile;
			return _profile;
		}
	}
}
