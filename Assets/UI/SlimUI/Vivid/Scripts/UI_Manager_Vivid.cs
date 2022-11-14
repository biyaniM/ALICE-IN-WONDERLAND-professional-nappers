using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
using UnityEngine.EventSystems;

namespace SlimUI.Vivid{
	public class UI_Manager_Vivid : MonoBehaviour, IPointerEnterHandler {
		[Header("Menus")]
		[Tooltip("All the menu and sub-menu windows")]
		public GameObject[] windows;
		public GameObject[] allButtons;
		[Header("Platform Parameters")]
		public Platform platform;
		public enum Platform {PC, Console};
		public static bool onConsole = false;
		public EventSystem eventSystem;
		Tints tint;
		Transform tintParent;
		public enum Tints {blue = 0, orange = 1, red = 2, green = 3, purple = 4, pink = 5, custom1 = 6, custom2 = 7, custom3 = 8};
		public static bool onPC = false;
		List<GameObject> tintChildren;
		public enum Theme {blue, orange, red, green, purple, pink, custom1, custom2, custom3};
		[Header("Theme Settings")]
		public Theme theme;
		int themeIndex;
		public FlexibleUIData themeController;
		public GameObject lensDirt;
		public bool useLensDirt = true;
		[Header("Input Prompts")]
		[Tooltip("Back button UI Prompt")]
		public GameObject backButtonPrompt;
		public GameObject selectButtonPrompt;
		[Header("Loading Parameters")]
		public string newGameScene;
		public string finishedLoadingMessage;
		public TMP_Text loadScreenDisplay;
		[Header("Splash Screen Parameters")]
		//public bool usingSplashScreen = false;
		//bool canCloseSplashScreen = false;
		//public GameObject splashScreen;
		public GameObject mainMenu;
		//public AudioSource splashSource;
		//public AudioClip splashSound;
		public bool playSpashSound = true;
		[Header("Demo Stuff")]
		public bool inDemoMode = false;
		
		void Start()
        {
            // if (usingSplashScreen)
            // {
            //     splashScreen.SetActive(true);
            //     mainMenu.SetActive(false);
            //     backButtonPrompt.SetActive(false);
            //     selectButtonPrompt.SetActive(false);
            //     SplashScreen();
            // }

            // Set Platform
            if (platform == Platform.Console)
            {
                eventSystem.sendNavigationEvents = true;
                onConsole = true;
				ChangePlatform(0);
            }
            else if (platform == Platform.PC)
            {
                eventSystem.sendNavigationEvents = false;
                onConsole = false;
				ChangePlatform(1);
            }

            SetThemeColors();

            //Start always on the main menu
            for (int i = 0; i < windows.Length; i++)
            {
                windows[i].SetActive(false);
            }
            windows[0].SetActive(true);

            if (!useLensDirt)
            {
                lensDirt.gameObject.SetActive(false);
            }

            tintParent = transform.Find("TINTS");
            tintChildren = new List<GameObject>();
            foreach (Transform child in tintParent)
            {
                tintChildren.Add(child.gameObject);
            }
            int toInteger = (int)tint;
            Tints backToTint = (Tints)toInteger;

            tintChildren[themeIndex].SetActive(true);
        }

        private void SetThemeColors(){
            if (theme == Theme.blue){
                themeController.currentColor = themeController.blue.blueText;
                themeController.accentColor = themeController.blue.blueAccent;
                themeController.shadowColor = themeController.blue.blueShadow;
                themeIndex = 0;
            }else if (theme == Theme.orange){
                themeController.currentColor = themeController.orange.orangeText;
                themeController.accentColor = themeController.orange.orangeAccent;
                themeController.shadowColor = themeController.orange.orangeShadow;
                themeIndex = 1;
            }else if (theme == Theme.red){
                themeController.currentColor = themeController.red.redText;
                themeController.accentColor = themeController.red.redAccent;
                themeController.shadowColor = themeController.red.redShadow;
                themeIndex = 2;
            }else if (theme == Theme.green){
                themeController.currentColor = themeController.green.greenText;
                themeController.accentColor = themeController.green.greenAccent;
                themeController.shadowColor = themeController.green.greenShadow;
                themeIndex = 3;
            }else if (theme == Theme.purple){
                themeController.currentColor = themeController.purple.purpleText;
                themeController.accentColor = themeController.purple.purpleAccent;
                themeController.shadowColor = themeController.purple.purpleShadow;
                themeIndex = 4;
            }else if (theme == Theme.pink){
                themeController.currentColor = themeController.pink.pinkText;
                themeController.accentColor = themeController.pink.pinkAccent;
                themeController.shadowColor = themeController.pink.pinkShadow;
                themeIndex = 5;
            }else if (theme == Theme.custom1){
                themeController.currentColor = themeController.custom1.customText1;
                themeController.accentColor = themeController.custom1.custom1Accent;
                themeController.shadowColor = themeController.custom1.custom1Shadow;
                themeIndex = 6;
            }else if (theme == Theme.custom2){
                themeController.currentColor = themeController.custom2.customText2;
                themeController.accentColor = themeController.custom2.custom2Accent;
                themeController.shadowColor = themeController.custom2.custom2Shadow;
                themeIndex = 7;
            }else if (theme == Theme.custom3){
                themeController.currentColor = themeController.custom3.customText3;
                themeController.accentColor = themeController.custom3.custom3Accent;
                themeController.shadowColor = themeController.custom3.custom3Shadow;
                themeIndex = 8;
            }
        }

    //     void SplashScreen(){
		// 	StartCoroutine(StartSplashScreen());
		// }

		// IEnumerator StartSplashScreen(){
		// 	yield return new WaitForSeconds(2f);
		// 	canCloseSplashScreen = true;
		// }

		IEnumerator LoadMainMenu(){
			yield return new WaitForSeconds(1.5f);
			mainMenu.SetActive(true);
			selectButtonPrompt.SetActive(true);
		}

		public void UpdateThemeColorsRuntime(int index){
			tintChildren[themeIndex].SetActive(false);
			if(index == 0){
				themeController.currentColor = themeController.blue.blueText;
				themeController.accentColor = themeController.blue.blueAccent;
				themeController.shadowColor = themeController.blue.blueShadow;
				theme = Theme.blue;
				themeIndex = 0;
			}else if(index == 1){
				themeController.currentColor = themeController.orange.orangeText;
				themeController.accentColor = themeController.orange.orangeAccent;
				themeController.shadowColor = themeController.orange.orangeShadow;
				theme = Theme.orange;
				themeIndex = 1;
			}else if(index == 2){
				themeController.currentColor = themeController.red.redText;
				themeController.accentColor = themeController.red.redAccent;
				themeController.shadowColor = themeController.red.redShadow;
				theme = Theme.red;
				themeIndex = 2;
			}else if(index == 3){
				themeController.currentColor = themeController.green.greenText;
				themeController.accentColor = themeController.green.greenAccent;
				themeController.shadowColor = themeController.green.greenShadow;
				theme = Theme.green;
				themeIndex = 3;
			}else if(index == 4){
				themeController.currentColor = themeController.purple.purpleText;
				themeController.accentColor = themeController.purple.purpleAccent;
				themeController.shadowColor = themeController.purple.purpleShadow;
				theme = Theme.purple;
				themeIndex = 4;
			}else if(index == 5){
				themeController.currentColor = themeController.pink.pinkText;
				themeController.accentColor = themeController.pink.pinkAccent;
				themeController.shadowColor = themeController.pink.pinkShadow;
				theme = Theme.pink;
				themeIndex = 5;
			}else if(index == 6){
				themeController.currentColor = themeController.custom1.customText1;
				themeController.accentColor = themeController.custom1.custom1Accent;
				themeController.shadowColor = themeController.custom1.custom1Shadow;
				theme = Theme.custom1;
				themeIndex = 6;
			}else if(index == 7){
				themeController.currentColor = themeController.custom2.customText2;
				themeController.accentColor = themeController.custom2.custom2Accent;
				themeController.shadowColor = themeController.custom2.custom2Shadow;
				theme = Theme.custom2;
				themeIndex = 7;
			}else if(index == 8){
				themeController.currentColor = themeController.custom3.customText3;
				themeController.accentColor = themeController.custom3.custom3Accent;
				themeController.shadowColor = themeController.custom3.custom3Shadow;
				theme = Theme.custom3;
				themeIndex = 8;
			}
			tintChildren[themeIndex].SetActive(true);
		}

		void Update(){
			if(platform == Platform.PC){
				onPC = true;
			}else if(platform == Platform.Console){
				onPC = false;
			}

			SetThemeColors();

			// FOR DEMO ONLY
			if(inDemoMode){
				if(Input.GetKeyDown("r") && Application.isEditor){
					SceneManager.LoadScene("SlimUI_Vivid_Demo", LoadSceneMode.Single);
				}
			}

			// if(canCloseSplashScreen){
			// 	if(Input.anyKey){
			// 		if(playSpashSound){
			// 			splashSource.PlayOneShot(splashSound, 0.5F);
			// 		}
			// 		splashScreen.GetComponent<Animator>().SetTrigger("Fade");
			// 		StartCoroutine(LoadMainMenu());
			// 		canCloseSplashScreen = false;
			// 	}
			// }
		}

		public void ShowBackButtonPrompt(){
			backButtonPrompt.SetActive(true);
		}

		public void HideBackButtonPromot(){
			backButtonPrompt.SetActive(false);
		}

		public void BackButton(){
			for (int i = 0; i < windows.Length; i++){
				if(windows[i].activeSelf == true){
					windows[i].GetComponent<WindowDetection>().CancelButton();
					Debug.Log("name of opened window: " + windows[i]);
				}
			}
		}

		public void Quit(){
			Application.Quit();
		}

		// At runtime, change the platform settings
		public void ChangePlatform(int plat){
			if(plat == 0){
				platform = Platform.Console;
				eventSystem.sendNavigationEvents = true;
				onConsole = true;
				for(int i = 0; i < allButtons.Length; i++)
				{
					allButtons[i].GetComponent<CheckNavigationSettings>().RestoreNavigation();
				}
			}else if(plat == 1){
				platform = Platform.PC;
				eventSystem.sendNavigationEvents = false;
				onConsole = false;
				for(int i = 0; i < allButtons.Length; i++)
				{
					allButtons[i].GetComponent<CheckNavigationSettings>().SetNavigationToNone();
				}
			}
		}

		public void LoadNewLevel(){
			if(newGameScene != ""){
				StartCoroutine(LoadAsynchronously(newGameScene));
			}
		}

		IEnumerator LoadAsynchronously (string sceneName){ // scene name is just the name of the current scene being loaded
			AsyncOperation operation = SceneManager.LoadSceneAsync(newGameScene);
			operation.allowSceneActivation = false;

			while (!operation.isDone){
				if(operation.progress >= 0.9f){
					loadScreenDisplay.text = finishedLoadingMessage;

					if(Input.anyKeyDown){
						operation.allowSceneActivation = true;
					}
				}
				
				yield return null;
			}
		}

		public void OnPointerEnter(PointerEventData eventData){
			EventSystem.current.GetComponent<EventSystem>().SetSelectedGameObject(null);
	 	}
	}
}