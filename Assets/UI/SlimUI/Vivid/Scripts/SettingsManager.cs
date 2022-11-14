using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

namespace SlimUI.Vivid{
	public class SettingsManager : MonoBehaviour {
		[Header("Visual Settings")]
		public TMP_Text textButtonLayout;
		public TMP_Text textHLook;
		public TMP_Text textVLook;
		public TMP_Text textSpeakerType;
		public TMP_Text textConfiguration;
		public GameObject[] buttonLayoutGraphics;
		public List<string> buttonLayout = new List<string>();
		public List<string> hLook = new List<string>();
		public List<string> vLook = new List<string>();
		public List<string> speakerType = new List<string>();
		public List<string> configuration = new List<string>();

		[Header("Starting Options Values")]
		public int buttonLayoutDefault = 0;
		public int hLookDefault = 0;
		public int vLookDefault = 0;
		public int speakerTypeDefault = 0;
		public int configurationDefault = 0;

		[Header("List Indexing")]
		int buttonLayoutIndex = 0;
		int buttonLayoutGraphicsIndex = 0;
		int hLookIndex = 0;
		int vLookIndex = 0;
		int speakerTypeIndex = 0;
		int configurationIndex = 0;

		// Gathered from the sliders
		[HideInInspector]
		public float verticalSensitivity;
		[HideInInspector]
		public float horizontalSensitivity;
		[HideInInspector]
		public float masterVolume;
		[HideInInspector]
		public float sfxVolume;
		[HideInInspector]
		public float voiceVolume;

		void Start () {
			buttonLayoutIndex = buttonLayoutDefault;
			buttonLayoutGraphicsIndex = buttonLayoutDefault;
			buttonLayoutGraphics[buttonLayoutIndex].SetActive(true);
			hLookIndex = hLookDefault;
			vLookIndex = vLookDefault;
			speakerTypeIndex = speakerTypeDefault;
			configurationIndex = configurationDefault;

			textButtonLayout.text = buttonLayout[buttonLayoutIndex];
			textHLook.text = hLook[hLookIndex];
			textVLook.text = vLook[vLookIndex];
			textSpeakerType.text = speakerType[speakerTypeIndex];
			textConfiguration.text = configuration[configurationIndex];
		}
		
		public void IncreaseIndex(int i){
			switch (i){
				case 0:
					buttonLayoutGraphics[buttonLayoutIndex].SetActive(false);
					if(buttonLayoutIndex != buttonLayout.Count -1){buttonLayoutIndex++;buttonLayoutGraphicsIndex++;}else{buttonLayoutIndex = 0;buttonLayoutGraphicsIndex = 0;}
					textButtonLayout.text = buttonLayout[buttonLayoutIndex];
					buttonLayoutGraphics[buttonLayoutIndex].SetActive(true);
					break;
				case 1:
					if(hLookIndex != hLook.Count -1){hLookIndex++;}else{hLookIndex = 0;}
					textHLook.text = hLook[hLookIndex];
					break;
				case 2:
					if(vLookIndex != vLook.Count -1){vLookIndex++;}else{vLookIndex = 0;}
					textVLook.text = vLook[vLookIndex];
					break;
				case 3:
					if(speakerTypeIndex != speakerType.Count -1){speakerTypeIndex++;}else{speakerTypeIndex = 0;}
					textSpeakerType.text = speakerType[speakerTypeIndex];
					break;
				case 4:
					if(configurationIndex != configuration.Count -1){configurationIndex++;}else{configurationIndex = 0;}
					textConfiguration.text = configuration[configurationIndex];
					break;
			}
		}

		public void DecreaseIndex(int i){
			switch (i){
				case 0:
					buttonLayoutGraphics[buttonLayoutIndex].SetActive(false);
					if(buttonLayoutIndex == 0){buttonLayoutIndex = buttonLayout.Count;buttonLayoutGraphicsIndex = buttonLayout.Count;}buttonLayoutIndex--; buttonLayoutGraphicsIndex--;
					textButtonLayout.text = buttonLayout[buttonLayoutIndex];
					buttonLayoutGraphics[buttonLayoutIndex].SetActive(true);
					break;
				case 1:
					if(hLookIndex == 0){hLookIndex = hLook.Count;}hLookIndex--;
					textHLook.text = hLook[hLookIndex];
					break;
				case 2:
					if(vLookIndex == 0){vLookIndex = vLook.Count;}vLookIndex--;
					textVLook.text = vLook[vLookIndex];
					break;
				case 3:
					if(speakerTypeIndex == 0){speakerTypeIndex = speakerType.Count;}speakerTypeIndex--;
					textSpeakerType.text = speakerType[speakerTypeIndex];
					break;
				case 4:
					if(configurationIndex == 0){configurationIndex = configuration.Count;}configurationIndex--;
					textConfiguration.text = configuration[configurationIndex];
					break;
			}
		}
	}
}
