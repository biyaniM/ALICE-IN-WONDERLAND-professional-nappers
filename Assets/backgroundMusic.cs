using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class backgroundMusic : MonoBehaviour
{   
    public int isMute = 0;
    AudioSource audioSource;
    // Start is called before the first frame update
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    public void muteAudio() {
        isMute = 1;
    }

    public void unMuteAudio() {
        isMute = 0;
    }
}
