using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

namespace SlimUI.Vivid{
	public class PlatformSpecific : MonoBehaviour {
		public Image currentIcon;
		public Sprite pcIcon;
		public Sprite consoleIcon;

		public void LateUpdate(){
			if(UI_Manager_Vivid.onPC){
				currentIcon.sprite = pcIcon;
			}else{
				currentIcon.sprite = consoleIcon;
			}
		}
	}
}
