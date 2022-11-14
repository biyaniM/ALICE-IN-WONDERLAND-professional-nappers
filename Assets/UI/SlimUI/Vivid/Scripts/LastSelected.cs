using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

namespace SlimUI.Vivid{
	public class LastSelected : MonoBehaviour {

		[Tooltip("The button the starts highlighted when the current menu loads.")]
		public Button startingSelectedButton;
		GameObject tempReturnButton; // the button that is highlighted after returning from a sub-menu. This can be different than the starting button.
		[Header("Key Binding Parameters")]
		public bool usingPromptWindow = false;
		public GameObject promptWindow;
		public Button promptWindowCancel;

		public void OnEnable(){
			if(UI_Manager_Vivid.onPC == false){
				StartCoroutine(StartingSelected());
			}
		}

		IEnumerator StartingSelected(){
			yield return new WaitForSeconds(0.01f);
			if(startingSelectedButton != null){
				EventSystem.current.SetSelectedGameObject(startingSelectedButton.gameObject);
			}
		}
		
		public void SelectedChange(){
			tempReturnButton = EventSystem.current.currentSelectedGameObject;
			if(tempReturnButton != null){
				startingSelectedButton = tempReturnButton.GetComponent<Button>();
			}
			
			if(usingPromptWindow){
				promptWindow.SetActive(true);
				HighlightCancelButton();
			}
		}

		public void HighlightCancelButton(){
			EventSystem.current.SetSelectedGameObject(promptWindowCancel.gameObject);
		}

		public void SelectLastButton(){
			if(startingSelectedButton != null){
				EventSystem.current.SetSelectedGameObject(startingSelectedButton.gameObject);
			}
		}
	}
}