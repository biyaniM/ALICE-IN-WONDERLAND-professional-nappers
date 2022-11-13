using System.Collections;
using UnityEngine;

public class FadeToGray : MonoBehaviour
{
    public Material[] materials;

    


    public void DoTheFade(int index)
    {
        StartCoroutine(DoTheFadeCR(materials[index]));
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

    public void fadeAll() {
        foreach(Material m in materials) {
            m.SetFloat("_Blend", 1);
        }
    }

    public void setColorToCoins(int[] indexes) {
        foreach(int i in indexes) {
            materials[i].SetFloat("_Blend", 0);
        }

    }

    public void colorAll() {
        foreach(Material m in materials) {
            m.SetFloat("_Blend", 0);
        }
    }
}