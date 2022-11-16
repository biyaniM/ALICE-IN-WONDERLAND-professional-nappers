using System.Collections;
using UnityEngine;

public class GrayScaleFunctions : MonoBehaviour
{
    [System.Serializable]
    public class MaterialObj {
        public Material material;
        public int isCoin;
    } 
    private float shadeFactor = 1;
    private float initialShadeFactor;
    public MaterialObj[] materials;


    public void DoTheFade(int index)
    {
       // StartCoroutine(DoTheFadeCR(materials[index]));
    }

    private IEnumerator DoTheFadeCR(Material material)
    {
        float time = 0;
        while (time < 1f)
        {
            material.SetFloat("_Blend", time);
            time += Time.deltaTime;
            yield return null;
        }

        material.SetFloat("_Blend", 1);
    }

    public void fadeAllExceptCoins() {
        Debug.Log("fadeAll");
        foreach(MaterialObj m in materials) {
            if(m.isCoin == 0) {
                Material material = m.material;
                material.SetFloat("_Blend", 1);
            }
        }
    }

    public void setColorToCoins(int[] indexes) {
        foreach(int i in indexes) {
           // materials[i].SetFloat("_Blend", 0);
        }

    }

    public void colorAll() {
        foreach(MaterialObj m in materials) {
            if(m.isCoin == 0) {
                Material material = m.material;
                Debug.Log("shade value");
                Debug.Log(shadeFactor);
                material.SetFloat("_Blend", shadeFactor);
            }
        }
    }

    public float getShadeFactor() {
        return shadeFactor;
    }

    public void setShadeFactor(float newFactor) {
        shadeFactor = newFactor;
    }

    public void setInitialShadeFactor(int numberOfCoins) {
        float factor = (float) 1/numberOfCoins;
        Debug.Log("Factor Value");
        Debug.Log(factor);
        Debug.Log(numberOfCoins);
        initialShadeFactor = factor;
        shadeFactor = 1;
    }

    public float getInitialShadeFactor(int numberOfCoins) {
        return initialShadeFactor;
    }

    public void addNewShade() {   
        float newShadeFactor = shadeFactor - initialShadeFactor;
        Debug.Log("New Values");
        Debug.Log(newShadeFactor); 
        Debug.Log(initialShadeFactor);
        Debug.Log(shadeFactor);
            if(newShadeFactor >= 0) {
                setShadeFactor(newShadeFactor);
                colorAll();
            }
    }
}