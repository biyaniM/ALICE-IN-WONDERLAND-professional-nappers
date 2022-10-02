using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FadingObject : MonoBehaviour, IEquatable<FadingObject>
{
    public List<Renderer> renderers = new List<Renderer>();
    public Vector3 position;
    public List<Material> materials = new List<Material>();
    [HideInInspector] public float initialAlpha;

    // Start is called before the first frame update
    void Awake()
    {
        position = transform.position;
        if(renderers.Count == 0){
            renderers.AddRange(GetComponentsInChildren<Renderer>());
        }
        for (int i=0; i< renderers.Count; i++){
            materials.AddRange(renderers[i].materials);
        }
    }

    public bool Equals(FadingObject other){
        return position.Equals(other.position);
    }

    public override int GetHashCode()
    {
        return position.GetHashCode();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
