using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamPreview : MonoBehaviour
{
    public GameObject mainCam;
    public GameObject previewCam;

    public GameObject player;

    public CharacterController playerController;


    //public GameObject playerController;

    // Start is called before the first frame update
    void Start()
    {
        
        playerController.enabled=false;
        StartCoroutine(Preview());
    }

    IEnumerator Preview(){
        yield return new WaitForSeconds(10);
        mainCam.SetActive(true);
        previewCam.SetActive(false);
        playerController.enabled=true;
    }
}
