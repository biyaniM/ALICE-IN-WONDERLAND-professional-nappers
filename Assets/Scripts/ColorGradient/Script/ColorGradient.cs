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
        //_postProcessVolume = GetComponent<PostProcessVolume>();
        _postProcessVolume.profile.TryGetSettings(out _colorGrading);
        _colorGrading.active = true;

        _colorGrading.saturation.value = -100;
    }

    // Update is called once per frame
    void Update()
    {
        /* if(_colorGrading.saturation.value < 0){
            _colorGrading.saturation.value += player.GetSaturationIncreaseFactor();

            if(_colorGrading.tone.saturation.value > 0){
                _colorGrading.saturation.value = 0;
            }
        } */

    }
}
