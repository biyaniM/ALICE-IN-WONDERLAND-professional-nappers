using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace JohnFarmer.KeyboardMouseSprites.Demo
{
	public class Demo : MonoBehaviour
	{
		[SerializeField] private Sprite[] blackKeySprites;
		[SerializeField] private Sprite[] whiteKeySprites;
		[SerializeField] private Image blackButtonDisplay;
		[SerializeField] private Image whiteButtonDisplay;
		[SerializeField] private Dictionary<string, Sprite> blackKeys = new Dictionary<string, Sprite>();
		[SerializeField] private Dictionary<string, Sprite> whiteKeys = new Dictionary<string, Sprite>();

		private void Start()
		{
			foreach (Sprite keySprite in blackKeySprites)
				blackKeys.Add(keySprite.name, keySprite);
			foreach (Sprite keySprite in whiteKeySprites)
				whiteKeys.Add(keySprite.name, keySprite);
		}

		private void OnGUI()
		{
			Event ev = Event.current;
			if (ev.isKey || ev.isMouse)
			{
				string keyName = ev.isMouse ? string.Concat("Mouse", ev.button) : ev.keyCode.ToString();
				blackButtonDisplay.sprite = blackKeys.ContainsKey(keyName) ? blackKeys[keyName] : blackButtonDisplay.sprite;
				blackButtonDisplay.SetNativeSize();
				whiteButtonDisplay.sprite = whiteKeys.ContainsKey(keyName) ? whiteKeys[keyName] : whiteButtonDisplay.sprite;
				whiteButtonDisplay.SetNativeSize();
			}
		}
	}
}
