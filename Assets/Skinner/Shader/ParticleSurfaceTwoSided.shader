// Surface shader for Skinner Particle (two-sided, non-textured)
Shader "Skinner/Particle/Two-Sided, Non-Textured"
{
    Properties
    {
		_Alpha("Alpha", Range(0, 1)) = 1
        _Albedo("Albedo", Color) = (0.5, 0.5, 0.5)
        _Smoothness("Smoothness", Range(0, 1)) = 0.5
        _Metallic("Metallic", Range(0, 1)) = 0

        [Header(Self Illumination)]
        _BaseHue("Base Hue", Range(0, 1)) = 0
        _HueRandomness("Hue Randomness", Range(0, 1)) = 0.2
        _Saturation("Saturation", Range(0, 1)) = 1
        _Brightness("Brightness", Range(0, 6)) = 0.8
        _EmissionProb("Probability", Range(0, 1)) = 0.2

        [Header(Color Modifier (By Speed))]
        _CutoffSpeed("Cutoff Speed", Float) = 0.5
        _SpeedToIntensity("Sensitivity", Float) = 1
        _BrightnessOffs("Brightness Offset", Range(0, 6)) = 1.0
        _HueShift("Hue Shift", Range(-1, 1)) = 0.2

        [HideInInspector] _PositionBuffer("", 2D) = ""{}
        [HideInInspector] _VelocityBuffer("", 2D) = ""{}
        [HideInInspector] _RotationBuffer("", 2D) = ""{}

        [HideInInspector] _PreviousPositionBuffer("", 2D) = ""{}
        [HideInInspector] _PreviousRotationBuffer("", 2D) = ""{}
    }
    SubShader
    {
		Tags{ "RenderType" = "Transparent" Queue = Transparent }

        Pass
        {
            Tags { "LightMode" = "MotionVectors" }
            Cull Off ZWrite Off
            CGPROGRAM
            #pragma vertex vert
            #pragma fragment frag
            #pragma target 4.0
            #include "ParticleMotion.cginc"
            ENDCG
        }

		Blend SrcAlpha One
		Cull Off ZTest Always ZWrite Off
        CGPROGRAM
        #pragma surface surf Standard vertex:vert nolightmap addshadow keepalpha 
        #pragma target 3.0
        #pragma multi_compile __ UNITY_COLORSPACE_GAMMA
        #define SKINNER_TWO_SIDED
        #include "ParticleSurface.cginc"
        ENDCG
    }
}
