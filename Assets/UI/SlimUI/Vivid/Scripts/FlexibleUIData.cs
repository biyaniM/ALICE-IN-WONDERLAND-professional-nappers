using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

namespace SlimUI.Vivid{
	[CreateAssetMenu(menuName = "ThemeSettings")]
	[System.Serializable]
	public class FlexibleUIData : ScriptableObject {

		[System.Serializable]
		public class Blue{
			[Header("Text")]	
			public Color blueText;
			public Color32 blueAccent;
			public Color32 blueShadow;
		}

		[System.Serializable]
		public class Orange{
			[Header("Text")]	
			public Color orangeText;
			public Color32 orangeAccent;
			public Color32 orangeShadow;
		}

		[System.Serializable]
		public class Red{
			[Header("Text")]	
			public Color redText;
			public Color32 redAccent;
			public Color32 redShadow;
		}

		[System.Serializable]
		public class Green{
			[Header("Text")]	
			public Color greenText;
			public Color32 greenAccent;
			public Color32 greenShadow;
		}

		[System.Serializable]
		public class Purple{
			[Header("Text")]	
			public Color purpleText;
			public Color32 purpleAccent;
			public Color32 purpleShadow;
		}

		[System.Serializable]
		public class Pink{
			[Header("Text")]	
			public Color pinkText;
			public Color32 pinkAccent;
			public Color32 pinkShadow;
		}

		[System.Serializable]
		public class Custom1{
			[Header("Text")]	
			public Color customText1;
			public Color32 custom1Accent;
			public Color32 custom1Shadow;
		}

		[System.Serializable]
		public class Custom2{
			[Header("Text")]	
			public Color customText2;
			public Color32 custom2Accent;
			public Color32 custom2Shadow;
		}

		[System.Serializable]
		public class Custom3{
			[Header("Text")]	
			public Color customText3;
			public Color32 custom3Accent;
			public Color32 custom3Shadow;
		}

		[Header("PRESETS")]
		public Blue blue;
		public Orange orange;
		public Red red;
		public Green green;
		public Purple purple;
		public Pink pink;
		[Header("CUSTOM SETTINGS")]
		public Custom1 custom1;
		public Custom2 custom2;
		public Custom3 custom3;

		[HideInInspector]
		public Color currentColor;
		[HideInInspector]
		public Color32 accentColor;
		[HideInInspector]
		public Color32 shadowColor;
	}
}