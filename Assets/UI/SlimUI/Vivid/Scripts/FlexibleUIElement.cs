using UnityEngine;
using UnityEngine.UI;
using TMPro;

namespace SlimUI.Vivid{
	[System.Serializable]
	public class FlexibleUIElement : FlexibleUI {
		[Header("Parameters")]
		Color outline;
		Image image;
		GameObject message;
		public enum OutlineStyle {solidThin, solidThick, dottedThin, dottedThick};
		public bool hasImage = false;
		public bool isText = false;
		public bool isShadow = false;

		protected override void OnSkinUI(){
			base.OnSkinUI();

			if(hasImage){
				image = GetComponent<Image>();
				image.color = themeController.currentColor;
			}

			message = gameObject;

			if(isShadow){
				message.GetComponent<TextMeshProUGUI>().color = themeController.shadowColor;
			}else if(isText){
				message.GetComponent<TextMeshProUGUI>().color = themeController.accentColor;
			}
		}
	}
}