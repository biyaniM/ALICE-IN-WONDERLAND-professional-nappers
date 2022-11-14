using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class LevelGallery : MonoBehaviour,IPointerEnterHandler, IPointerExitHandler{
    public RectTransform levelPreview;
 
    Vector3 cachedScale;
 
    void Start() {
 
        cachedScale = levelPreview.localScale;
    }
 
    public void OnPointerEnter(PointerEventData eventData) {
         
        levelPreview.localScale = new Vector3(1.1f, 1.1f, 1.1f);
        Debug.Log("Hover In!");

    }
 
    public void OnPointerExit(PointerEventData eventData) {
 
        levelPreview.localScale = cachedScale;
        Debug.Log("Hover Out");
    }
 }