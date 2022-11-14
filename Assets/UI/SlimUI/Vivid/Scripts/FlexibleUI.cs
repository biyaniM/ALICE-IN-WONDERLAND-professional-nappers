using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SlimUI.Vivid{
	[ExecuteInEditMode()]
	[System.Serializable]
	public class FlexibleUI : MonoBehaviour {

		public FlexibleUIData themeController;

		protected virtual void OnSkinUI(){

		}

		public virtual void Awake(){
			OnSkinUI();
		}

		public virtual void Update(){
			//if(Application.isEditor){
				OnSkinUI();
			//}
		}
	}
}
