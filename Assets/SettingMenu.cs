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
        if(!PlayerPrefs.HasKey("volume")){
            volume = 5;
            Save(volume);
        }else{
            Load();
        }
        Debug.Log("Load Volume: " + volume);
        updateSlider(volume);
        
    }

    public void updateSlider(int volume){
        slider.value = volume;
        volume_text.text = volume.ToString();
    }
    
    public void changeVolume(){
        int volume = (int) Math.Round(slider.value, 0);
        Save(volume);
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
