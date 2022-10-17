using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamPreview : MonoBehaviour
{
    public GameObject mainCam;
    public GameObject previewCam;

    public GameObject player;

    public CharacterController playerController;
    [SerializeField] private CountDownTimer timer;


    //public GameObject playerController;

    void Awake()
    {
        player.GetComponent<ThirdPersonShooterController>().enabled = false;
        playerController.enabled=false;
    }
    
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(Preview());
    }

    IEnumerator Preview(){
        timer.pauseTimer();
        yield return new WaitForSeconds(10);
        mainCam.SetActive(true);
        previewCam.SetActive(false);
        playerController.enabled=true;
        player.GetComponent<ThirdPersonShooterController>().enabled= true;
        timer.unPauseTimer();
    }
}
