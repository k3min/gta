Shader "RW/Alpha"
{
	Properties
	{
		_Color("Color", Color) = (1, 1, 1, 1)
		_MainTex("Texture", 2D) = "white" {}
		[HideInInspector]
		_Cutoff("Cutoff", Float) = 0.5
	}

	SubShader
	{
		Tags
		{
			"Queue" = "AlphaTest"
			"RenderType" = "TransparentCutout"
		}

		CGPROGRAM

		#pragma surface Surface Standard nofog exclude_path:prepass alphatest:_Cutoff

		fixed4 _Color;
		sampler2D _MainTex;

		struct Input {
			float2 uv_MainTex;
		};

		inline void Surface(Input i, inout SurfaceOutputStandard o)
		{
			fixed4 color = tex2D(_MainTex, i.uv_MainTex) * _Color;

			o.Albedo = color.rgb;
			o.Alpha = color.a;

			o.Metallic = 0.0;
			o.Smoothness = 0.5;
		}

		ENDCG
	}

	Fallback "Legacy Shaders/Transparent/Cutout/VertexLit"
}