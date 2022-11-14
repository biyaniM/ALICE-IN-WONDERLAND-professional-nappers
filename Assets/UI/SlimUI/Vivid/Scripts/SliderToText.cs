using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

namespace SlimUI.Vivid{
	public class SliderToText : MonoBehaviour {

		public TMP_Text valNum;
		string fillValue;
		public Slider mainSlider;
		[Header("Demo Parameters")]
		public float sliderSpeed = 0.1f;
		public bool sliderAnimated = false;

		// for demonstration purposes only
		void Start()
		{
			if(sliderAnimated){
				InvokeRepeating("Counter", 0.0f, sliderSpeed);
			}
		}

		void Counter()
		{
			mainSlider.value++;

			if(mainSlider.value == mainSlider.maxValue){
				mainSlider.value = 0;
			}
		}

		void Update(){
			UpdateText();
		}

		public void UpdateText(){
			fillValue = Mathf.Round(mainSlider.value).ToString();
			if(valNum){
				valNum.text = fillValue;
			}
		}
	}
}
