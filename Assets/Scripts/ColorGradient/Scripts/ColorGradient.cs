using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.PostProcessing;

public class ColorGradient : MonoBehaviour
{
    private PostProcessVolume m_Volume;
    private ColorGrading  m_ColorGrading;
    [SerializeField] Player player;
    // Start is called before the first frame update
    void Start()
    {
        m_ColorGrading = ScriptableObject.CreateInstance<ColorGrading>();
        m_ColorGrading.enabled.Override(true);
        m_ColorGrading.saturation.Override(-100f);

        m_Volume = PostProcessManager.instance.QuickVolume(gameObject.layer, 100f, m_ColorGrading);
    }

    // Update is called once per frame
    void Update()
    {
        m_ColorGrading.saturation.value = player.GetSaturation();
    }
}
