using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.PostProcessing;
public class ColorGradient : MonoBehaviour
{
    private PostProcessVolume _postProcessVolume;
    private ColorGrading _colorGrading;

    private int increaseFactor;

    [SerializeField] Player player;

    // Start is called before the first frame update
    void Start()
    {
        _colorGrading = ScriptableObject.CreateInstance<ColorGrading>();
        _colorGrading.enabled.Override(true);
        _colorGrading.saturation.Override(-100f);

        _postProcessVolume = PostProcessManager.instance.QuickVolume(gameObject.layer, 100f, _colorGrading);

    }

    // Update is called once per frame
    void Update()
    {
        _colorGrading.saturation.value = player.GetSaturation();

    }
}
