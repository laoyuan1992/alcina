﻿using UnityEngine;
using UnityEngine.Rendering;

namespace Phantom
{
    [ExecuteInEditMode]
    public class ScreenBlit : MonoBehaviour
    {
        [SerializeField] RenderTexture _source;

        [SerializeField, Range(0, 1)] float _invert = 0;

        public float invert {
            get { return _invert; }
            set { _invert = value; }
        }

        [SerializeField] Color _overlayColor;

        public Color overlayColor {
            get { return _overlayColor; }
            set { _overlayColor = value; }
        }

        [SerializeField, Range(0, 1)] float _intensity = 1;

        public float intensity
		{
			get { return _intensity; }
			set { _intensity = value; }
		}

		[SerializeField, Range(0, 1)]
		float _brightness = 0;
		public float brightness
		{
			get { return _brightness; }
			set { _brightness = value; }
		}

		[SerializeField, Range(0, 5)]
		float _softness = 1;
		public float softness
		{
			get { return _softness; }
			set { _softness = value; }
		}

		[SerializeField] Shader _shader;

        Material _material;
        CommandBuffer _blitCommand;

        void OnEnable()
        {
            _material = new Material(_shader);
            _material.hideFlags = HideFlags.HideAndDontSave;

            if (_blitCommand == null) _blitCommand = new CommandBuffer();
            _blitCommand.Clear();
            _blitCommand.Blit((Texture)_source, BuiltinRenderTextureType.CurrentActive, _material, 0);

			Camera camera = GetComponent<Camera>();
            camera.AddCommandBuffer(CameraEvent.AfterEverything, _blitCommand);

			if (camera.targetDisplay != 0 && Display.displays.Length > camera.targetDisplay) {
				Display.displays[camera.targetDisplay].Activate();
			}
        }

        void OnDisable()
        {
            GetComponent<Camera>().RemoveCommandBuffer(CameraEvent.AfterEverything, _blitCommand);
        }

        void OnDestroy()
        {
            if (Application.isPlaying)
                Destroy(_material);
            else
                DestroyImmediate(_material);

            _material = null;
        }

        void LateUpdate()
        {
			if (_material)
			{
				_material.SetFloat("_Invert", _invert);
				_material.SetColor("_Color", _overlayColor);
				_material.SetFloat("_Intensity", _intensity);
				_material.SetFloat("_Brightness", _brightness);
				_material.SetFloat("_Softness", _softness);
			}
		}
    }
}
