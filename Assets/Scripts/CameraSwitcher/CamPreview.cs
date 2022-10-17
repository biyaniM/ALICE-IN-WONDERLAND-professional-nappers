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
    [SerializeField] protected Player hudObject;
    
    [Header("Game Objects to Disable")]
    [Tooltip("Add the Game Objects You Want to be disabled in the beginninng of the level")]
    [SerializeField] protected List<GameObject> gameObjectsToDisableInBeginning;


    //public GameObject playerController;

    void Awake()
    {
        player.GetComponent<ThirdPersonShooterController>().enabled = false;
        playerController.enabled=false;
        foreach(GameObject gO in gameObjectsToDisableInBeginning){
            gO.SetActive(false);
        }
    }
    
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(Preview());
    }

    IEnumerator Preview(){
        timer.pauseTimer();
        yield return new WaitForSeconds(10);
        foreach(GameObject gO in gameObjectsToDisableInBeginning){
            if(!gO.activeSelf){
                gO.SetActive(true);
            }
        }
        mainCam.SetActive(true);
        previewCam.SetActive(false);
        playerController.enabled=true;
        player.GetComponent<ThirdPersonShooterController>().enabled= true;
        hudObject.initializeStartup();
        timer.unPauseTimer();
    }
}
