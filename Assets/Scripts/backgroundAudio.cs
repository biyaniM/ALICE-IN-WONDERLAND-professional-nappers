using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class backgroundAudio : MonoBehaviour
{   
    AudioSource audioSource;
    // Start is called before the first frame update
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        muteAudio();
    }

    public void muteAudio() {
        audioSource.mute = true;
    }

    public void unMuteAudio() {
        audioSource.mute = false;
    }
}




