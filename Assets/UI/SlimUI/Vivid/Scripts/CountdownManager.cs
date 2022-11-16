using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

namespace SlimUI.Vivid{
    public class CountdownManager : MonoBehaviour{
        [Header("Countdown Parameters")]
        public WindowDetection menu;
        public GameObject menuParent;
        [Tooltip("The Grid Layout game object")]
        public CanvasGroup missionLayout;
        public TMP_Text cancelText;
        bool canCancel = true;
        public GameObject descriptionText;
        bool countingDown = false;
        [Range(3,30)]
        public int countdownLength = 5;
        int timer = 0;
        public TMP_Text countdownText;
        public Animator fade;
        public AudioSource countSource;
        public AudioClip countSound;
        public AudioSource startSource;
        public AudioClip startSound;

        [Header("Loading Screen Parameters")]
        public GameObject bottomBarA;
        public GameObject bottomBarB;
        public Animator loadingIcon;

        public UI_Manager_Vivid loadingManager;

        [Header("Mission Thumbnails")]
        public Sprite[] thumbnails;
        public Image currentThumbnail;

        [Header("Difficulty Parameters")]
		public static int difficulties;
        [Header("Always have the same # of difficulties and bars!!!")]
        [Tooltip("How many difficulties are in the game")]
        [Range(1,8)]
        public int difficultyCount = 4;
        public GameObject[] difficultyBars;

        void Start(){
            difficulties = difficultyCount;
        }

        public virtual void Update(){
            if((countingDown && canCancel) && (Input.GetButtonDown("Cancel") || Input.GetButtonDown("Fire2"))){
                fade.SetBool("Fade",false);
                countingDown = false;
                canCancel = true;
                missionLayout.alpha = 1f;
                missionLayout.interactable = true;
                missionLayout.blocksRaycasts = true;
                cancelText.text = "Back";
                countdownText.text = "";
                this.GetComponent<CanvasGroup>().interactable = true;
                this.GetComponent<CanvasGroup>().blocksRaycasts = true;
                StartCoroutine(InputDelay());
                StopCoroutine(CountDownTimer());
            }

            if(countingDown){
                if(timer >= 0){
                    countdownText.text = "STARTING IN " + timer.ToString();

                    if(timer <= 3){
                        fade.SetBool("Fade",true);
                    }

                    if(timer <= 0){
                        canCancel = false;
                        countingDown = false;
                        menu.canCloseMenu = false;
                        menuParent.GetComponent<CanvasGroup>().alpha = 0.0f;
                        StartCoroutine(SwitchToLoadScreen());
                    }
                }
            }
        }

        IEnumerator CountDownTimer(){
            while(timer > 0 && countingDown){
                countSource.PlayOneShot(countSound, 0.7f);
                yield return new WaitForSeconds(1.0f);
                timer--;
            }

            if(timer == 0){
                startSource.PlayOneShot(startSound, 0.8F);
            }
        }

        void PlayCountdownSound(){
            countSource.PlayOneShot(countSound, 0.7f);
        }

        IEnumerator SwitchToLoadScreen(){
            loadingManager.LoadNewLevel();
            yield return new WaitForSeconds(0.5f);
            fade.SetBool("Fade",false);
            bottomBarA.SetActive(false);
            bottomBarB.SetActive(false);
            loadingIcon.SetTrigger("Fade");
        }

        IEnumerator InputDelay(){
            yield return new WaitForSeconds(0.01f);
            menu.canCloseMenu = true;
        }

        public void ChangeThumbnail(int index){
            currentThumbnail.sprite = thumbnails[index];
        }

        public void StartCountdown(){
            if(!countingDown){
                countingDown = true;
                menu.canCloseMenu = false;
                cancelText.text = "Cancel";
                timer = countdownLength;
                missionLayout.alpha = 0.5f;
                missionLayout.interactable = false;
                missionLayout.blocksRaycasts = false;
                this.GetComponent<CanvasGroup>().interactable = false;
                this.GetComponent<CanvasGroup>().blocksRaycasts = false;
                StartCoroutine(CountDownTimer());
            }
        }
    }
}