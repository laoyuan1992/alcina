using System;
using CinemaSuite.CinemaFaceCap.App.Core;
using CinemaSuite.CinemaFaceCap.App.Core.Editor.Utility;
using CinemaSuite.CinemaFaceCap.App.Core.Mapping;

namespace CinemaSuite.CinemaFaceCap.App.Modules.Editor.CapturePipeline.Output 
{
	[Name("Alcina C")]
	public class Alcinac : StandardOutputFace 
	{
		public override FaceStructure GetTargetStructure()
		{
			var faceStructure = new FaceStructure("Alcina C");
			faceStructure.OrientationNodePath = "ALCINA_JULLIARD:Root.ALCINA_JULLIARD:Pelvis.ALCINA_JULLIARD:Spine_02.ALCINA_JULLIARD:spine_3.ALCINA_JULLIARD:Spine_03.ALCINA_JULLIARD:Spine_04.ALCINA_JULLIARD:Neck1";
			faceStructure.FacePath = "ALCINA_JULLIARD:Alcina_Head";
			faceStructure.Add("_ncl1_20", FaceShapeAnimations.JawOpen, x => x * 100);
			faceStructure.Add("_ncl1_21", FaceShapeAnimations.RighteyebrowLowerer, x => Math.Max(x, 0f) * 100f);
			faceStructure.Add("_ncl1_22", FaceShapeAnimations.LowerlipDepressorRight, x => x * 100);
			faceStructure.Add("_ncl1_23", FaceShapeAnimations.LipCornerPullerLeft, x => x * 100);
			faceStructure.Add("_ncl1_24", FaceShapeAnimations.LowerlipDepressorLeft, x => x * 100);
			faceStructure.Add("_ncl1_25", FaceShapeAnimations.LipCornerDepressorLeft, x => x * 100);
			faceStructure.Add("_ncl1_26", FaceShapeAnimations.LefteyebrowLowerer, x => Math.Max(x, 0f) * 100f);
			faceStructure.Add("_ncl1_27", FaceShapeAnimations.LipCornerPullerRight, x => x * 100);
			faceStructure.Add("_ncl1_28", FaceShapeAnimations.LipCornerDepressorRight, x => x * 100);
			faceStructure.Add("_ncl1_29", FaceShapeAnimations.LipStretcherRight, x => x * 100);
			faceStructure.Add("_ncl1_30", FaceShapeAnimations.JawSlideRight, x => Math.Max(x, 0f) * 100f);
			faceStructure.Add("_ncl1_31", FaceShapeAnimations.LipStretcherLeft, x => x * 100);
			faceStructure.Add("_ncl1_32", FaceShapeAnimations.RightCheekPuff, x => x * 100);
			faceStructure.Add("_ncl1_33", FaceShapeAnimations.LeftEyeClosed, x => x * 100);
			faceStructure.Add("_ncl1_34", FaceShapeAnimations.LipPucker, x => x * 100);
			faceStructure.Add("_ncl1_35", FaceShapeAnimations.RightEyeClosed, x => x * 100);
			faceStructure.Add("_ncl1_36", FaceShapeAnimations.LefteyebrowLowerer, x => Math.Min(x, 0f) * -100f);
			faceStructure.Add("_ncl1_37", FaceShapeAnimations.LeftCheekPuff, x => x * 100);
			faceStructure.Add("_ncl1_38", FaceShapeAnimations.RighteyebrowLowerer, x => Math.Min(x, 0f) * -100f);
			faceStructure.Add("_ncl1_39", FaceShapeAnimations.JawSlideRight, x => Math.Min(x, 0f) * -100f);
			return faceStructure;
		}
	}
}