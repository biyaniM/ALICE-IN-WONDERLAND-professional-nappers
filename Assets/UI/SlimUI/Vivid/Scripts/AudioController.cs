using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SlimUI.Vivid{
	public class AudioController : MonoBehaviour {
		public AudioClip sound;
		public void PlayAudio(){
			GetComponent<AudioSource>().PlayOneShot(sound, 0.4F);
		}
	}
}