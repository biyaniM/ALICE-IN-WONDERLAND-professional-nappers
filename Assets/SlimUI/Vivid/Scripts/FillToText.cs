using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

namespace SlimUI.Vivid{
	public class FillToText : MonoBehaviour {
		public TMP_Text fillText;
		string fillValue;
		public Image fillImage;
		
		// for demonstration purposes only
		void Update(){
			UpdateText();
		}

		public void UpdateText(){
			fillValue = Mathf.Round(fillImage.fillAmount * 100).ToString();
			fillText.text = fillValue;
		}
	}
}