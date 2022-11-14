using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SlimUI.Vivid{
	public class MissionOption : MonoBehaviour {
		[Tooltip("You can use this index to identify which mission the game will launch in your own code.")]
		public int missionIndex = 0;

		[Header("Selected Mission Difficulty")]
		[Range(0,4)]
		public int difficultyCompleted;
		public CountdownManager missionsManager;

		public void GetInformation(){
			// Reset bars
			for(int i = 0; i < CountdownManager.difficulties; i++){
				missionsManager.difficultyBars[i].SetActive(false);
			}

			for(int i = 0; i < difficultyCompleted; i++){
				missionsManager.difficultyBars[i].SetActive(true);
			}

		}
	}
}