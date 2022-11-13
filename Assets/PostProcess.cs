using UnityEngine;

public class PostProcess : MonoBehaviour
{
    private Material _material;
    public Shader _shader;


    // Start is called before the first frame update
    void Start()
    {
        _material = new Material(_shader);
    }

    private void OnRenderImage(RenderTexture source, RenderTexture destination)
    {
        Graphics.Blit(source, destination, _material);
    }
}