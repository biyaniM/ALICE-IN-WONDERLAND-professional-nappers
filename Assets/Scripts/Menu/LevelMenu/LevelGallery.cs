using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class LevelGallery : MonoBehaviour,IPointerEnterHandler, IPointerExitHandler, IPointerClickHandler{
    public RectTransform levelPreview;
    public GameObject levelBrief;
 
    Vector3 cachedScale;
 
    void Start() {
 
        cachedScale = levelPreview.localScale;
    }
 
    public void OnPointerEnter(PointerEventData eventData) {
         
        levelPreview.localScale = new Vector3(1.1f, 1.1f, 1.1f);
        levelBrief.SetActive(true);
        Debug.Log("Hover In!");

    }
 
    public void OnPointerExit(PointerEventData eventData) {
        levelPreview.localScale = cachedScale;
        levelBrief.SetActive(false);
        Debug.Log("Hover Out");
    }

    public void OnPointerClick(PointerEventData eventData){
        //go to level
        
    }
 }