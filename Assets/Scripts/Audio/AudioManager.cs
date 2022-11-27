using UnityEngine.Audio;
using System;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public Sound[] sounds;
    float defaultVolume = 0.35f;
    public int isMute = 0;

    void Awake() {
            foreach (Sound s in sounds) {
            s.source = gameObject.AddComponent<AudioSource>();
            s.source.clip = s.clip;
            s.source.volume = s.volume;
            s.source.pitch = s.pitch;
        }
    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void play (string name) {
        Sound s = Array.Find(sounds, sound => sound.name == name);
        if (s == null)
        {  
            Debug.LogWarning("Sound: " + name + " not found in "+gameObject.scene);
            return;
        }
        isMute = 1;
        Debug.Log("ISMUTE===");
        Debug.Log(isMute);
        if(isMute == 1) {
            Debug.Log("MUTED!");
            return;
        }
        s.source.volume = defaultVolume;
        s.source.Play();
    }

    public void muteAudio() {
        isMute = 1;
    }

    public void unMuteAudio() {
        isMute = 0;
    }


}
