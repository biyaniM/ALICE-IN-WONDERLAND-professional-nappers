using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

namespace SlimUI.Vivid{
	public class WindowDetection : MonoBehaviour {
		[Tooltip("A sub window is any sub menu outside the Main. If you press 'Campaign' the menu that loads is a sub menu, but the main menu is not.")]
		public bool isSubMenu = false;
		[Tooltip("If there is another operation overriding the B button in the current menu.")]
		public bool canCloseMenu = true;
		[Tooltip("The button the starts highlighted when the current menu loads.")]
		public Button startingSelectedButton;
		GameObject tempReturnButton; // the button that is highlighted after returning from a sub-menu. This can be different than the starting button.
		public UI_Manager_Vivid uiManager;
		[Tooltip("The array value in UI_Manager_Future of the return menu when closing current.")]
		public int returnMenuIndex = 0;

		[Header("Child Menu Parameters")]
		[Tooltip("If the opened menu has an option for child menus beyond the main navigation.")]
		public bool hasChildMenus = false;
		bool isInChildMenu = false;
		[Tooltip("If the opened menu has an option for a pop up window.")]
		public bool hasPopUpMenu = false;
		bool isInPopUpMenu = false;
		public GameObject popUpMenu;
		[Tooltip("The Vertical Layout object holding the menus main buttons.")]
		public CanvasGroup verticalLayout;
		public GameObject[] childMenus;
		int currentChildMenuOpenIndex = -1;

		[Header("Platform Parameters")]
		[Tooltip("Not all buttons should be active on specific platforms. Control those settings here.")]
		public GameObject[] desktopOnlyButtons;
		[Tooltip("Not all buttons should be active on specific platforms. Control those settings here.")]
		public GameObject[] consoleOnlyButtons;

		void OnEnable () {
			if(UI_Manager_Vivid.onPC == false){
				StartCoroutine(StartingSelected());
			}

			if(isSubMenu){
				uiManager.ShowBackButtonPrompt();
			}else if(!isSubMenu){
				uiManager.HideBackButtonPromot();
			}

			if(UI_Manager_Vivid.onConsole == true){
				for(int i = 0; i < desktopOnlyButtons.Length; i++)
				{
					desktopOnlyButtons[i].SetActive(false);
				}
				for(int i = 0; i < consoleOnlyButtons.Length; i++)
				{
					consoleOnlyButtons[i].SetActive(true);
				}
			}else if(UI_Manager_Vivid.onConsole == false){
				for(int i = 0; i < consoleOnlyButtons.Length; i++)
				{
					consoleOnlyButtons[i].SetActive(false);
				}
				for(int i = 0; i < desktopOnlyButtons.Length; i++)
				{
					desktopOnlyButtons[i].SetActive(true);
				}
			}
		}

		// So the user can see the Menu buttons switching on platform switch at runtime
		public void ReloadConsoleSettings(){
			if(UI_Manager_Vivid.onConsole == true){
				for(int i = 0; i < desktopOnlyButtons.Length; i++)
				{
					desktopOnlyButtons[i].SetActive(false);
				}
				for(int i = 0; i < consoleOnlyButtons.Length; i++)
				{
					consoleOnlyButtons[i].SetActive(true);
				}
			}else if(UI_Manager_Vivid.onConsole == false){
				for(int i = 0; i < consoleOnlyButtons.Length; i++)
				{
					consoleOnlyButtons[i].SetActive(false);
				}
				for(int i = 0; i < desktopOnlyButtons.Length; i++)
				{
					desktopOnlyButtons[i].SetActive(true);
				}
			}
		}

		IEnumerator StartingSelected(){
			yield return new WaitForSeconds(0.01f);
			if(UI_Manager_Vivid.onConsole == true){
				EventSystem.current.SetSelectedGameObject(startingSelectedButton.gameObject);
			}
		}

		void Update(){
			if((Input.GetButtonDown("Cancel") || Input.GetButtonDown("Fire2"))){
				CancelButton();
			}
		}

		public void CancelButton(){
			if(isSubMenu && canCloseMenu && !isInChildMenu && !isInPopUpMenu){
				CloseWindow();
			}else if(isSubMenu && canCloseMenu && hasChildMenus && isInChildMenu && !isInPopUpMenu){
				childMenus[currentChildMenuOpenIndex].SetActive(false);
				SetCurrentOpenChildMenu(-1); // set it to NO menu
				if(UI_Manager_Vivid.onPC == false){
					StartCoroutine(StartingSelected());
				}
				isInChildMenu = false;
				EnableVerticalLayout();
			}else if(isSubMenu && isInPopUpMenu){
				popUpMenu.SetActive(false);
				if(UI_Manager_Vivid.onPC == false){
					StartCoroutine(StartingSelected());
				}
				ToggleClosingWindow();
				isInPopUpMenu = false;
			}
		}

		public void ToggleClosingWindow(){
			canCloseMenu = !canCloseMenu;
		}


		public void CloseWindow(){
			gameObject.SetActive(false);
			uiManager.windows[returnMenuIndex].SetActive(true);
		}

		public void PhysicalBackButton(){ // for pressing the back button with a mouse instead of a controller
			if(isSubMenu && canCloseMenu){
				gameObject.SetActive(false);
				uiManager.windows[returnMenuIndex].SetActive(true);
			}
		}

		public void StartingSelectedChange(){
			tempReturnButton = EventSystem.current.currentSelectedGameObject;
			startingSelectedButton = tempReturnButton.GetComponent<Button>();
		}

		public void SetCurrentOpenChildMenu(int index){
			currentChildMenuOpenIndex = index;
			isInChildMenu = true;
		}

		public void SetPopUpOpenTrue(){
			isInPopUpMenu = true;
		}

		public void SetPopUpOpenFalse(){
			isInPopUpMenu = false;
		}


		public void EnableVerticalLayout(){ // enable the menu buttons again
			verticalLayout.alpha = 1.0f;
			verticalLayout.blocksRaycasts = true;
			verticalLayout.interactable = true;
		}

		public void DisableVerticalLayout(){ // disable the menu buttons again
			verticalLayout.alpha = 0.4f;
			verticalLayout.blocksRaycasts = false;
			StartCoroutine(DisableVerticalLayoutTiming());
		}

		IEnumerator DisableVerticalLayoutTiming(){
			yield return new WaitForSeconds(0.01f);
			verticalLayout.interactable = false;
		}
	}
}