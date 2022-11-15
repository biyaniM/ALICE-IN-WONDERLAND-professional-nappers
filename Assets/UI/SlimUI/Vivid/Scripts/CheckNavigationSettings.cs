using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace SlimUI.Vivid{
	public class CheckNavigationSettings : MonoBehaviour {
		Button button;
		Navigation customNav = new Navigation();
		[HideInInspector]
		public int navigationModeIndex = 0;

		// Use this for initialization
		void Start () {
			if(GetComponent<Button>() != null){
				button = GetComponent<Button>();
			}

			if(button.navigation.mode == Navigation.Mode.Automatic){
				navigationModeIndex = 0;
			}else if(button.navigation.mode == Navigation.Mode.Explicit){
				navigationModeIndex = 1;
			}else if(button.navigation.mode == Navigation.Mode.Horizontal){
				navigationModeIndex = 2;
			}else if(button.navigation.mode == Navigation.Mode.Vertical){
				navigationModeIndex = 3;
			}
		}

		public void SetNavigationToNone(){
			button = GetComponent<Button>();
			customNav.mode = Navigation.Mode.None;
			button.navigation = customNav;
		}

		public void RestoreNavigation(){
			button = GetComponent<Button>();
			if(navigationModeIndex == 0){
				customNav.mode = Navigation.Mode.Automatic;
				button.navigation = customNav;
			}else if(navigationModeIndex == 1){
				customNav.mode = Navigation.Mode.Explicit;
				button.navigation = customNav;
			}else if(navigationModeIndex == 2){
				customNav.mode = Navigation.Mode.Horizontal;
				button.navigation = customNav;
			}else if(navigationModeIndex == 3){
				customNav.mode = Navigation.Mode.Vertical;
				button.navigation = customNav;
			}
		}
	}
}