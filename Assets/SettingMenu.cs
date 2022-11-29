using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class SettingMenu : MonoBehaviour
{
    [SerializeField] Slider slider;
    [SerializeField] TextMeshProUGUI volume_text;
    int volume;
    // Start is called before the first frame update
    void Start()
    {
        int volume = (int) Math.Round(slider.value, 0);
        if(!PlayerPrefs.HasKey("volume")){
            Save(volume);
        }else{
            Load();
        }
        changeVolume();
    }

    public void changeVolume(){
        int volume = (int) Math.Round(slider.value, 0);
        volume_text.text = volume.ToString();
        AudioListener.volume = (float) volume / 10;
    }
    // Update is called once per frame
    void Update()
    {
        changeVolume();
    }

    private void Load(){
        volume = PlayerPrefs.GetInt("volume");
    }

    private void Save(int value){
        PlayerPrefs.SetInt("volume", value);
    }
}
